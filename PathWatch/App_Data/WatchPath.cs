using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PathWatch.App_Data
{
    /// <summary>
    /// 定义传入监控目录的委托
    /// </summary>
    /// <param name="path"></param>
    public delegate void FileSystemEvent(String path);

    /// <summary>
    /// 目录更改接口
    /// </summary>
    public interface IDirectoryMonitor
    {
        event FileSystemEvent Change;
        void Start();
    }
    /// <summary>
    /// 目录监控实现
    /// </summary>
    public class DirectoryMonitor : IDirectoryMonitor
    {
        /// <summary>初始化监控实例</summary>
        private readonly FileSystemWatcher m_fileSystemWatcher = new FileSystemWatcher();
        private readonly Dictionary<string, DateTime> m_pendingEvents = new Dictionary<string, DateTime>();
        private readonly Timer m_timer;
        private bool m_timerStarted = false;

        public string _path;

        public DirectoryMonitor(string dirPath, Action<object, FileSystemEventArgs> calback)
        {
            try
            {
                _path = dirPath;
                m_fileSystemWatcher.Path = dirPath;
                m_fileSystemWatcher.IncludeSubdirectories = false;
                m_fileSystemWatcher.Created += new FileSystemEventHandler((o, e) =>
                {
                    lock (m_pendingEvents)
                    {
                        // Save a timestamp for the most recent event for this path  
                        m_pendingEvents[e.FullPath] = DateTime.Now;

                        // Start a timer if not already started  
                        if (!m_timerStarted)
                        {
                            m_timer.Change(100, 100);
                            m_timerStarted = true;
                        }
                    }
                    calback(o, e);
                });
                //m_fileSystemWatcher.Changed += new FileSystemEventHandler((o, e) => {
                //    lock (m_pendingEvents)
                //    {
                //        // Save a timestamp for the most recent event for this path  
                //        m_pendingEvents[e.FullPath] = DateTime.Now;

                //        // Start a timer if not already started  
                //        if (!m_timerStarted)
                //        {
                //            m_timer.Change(100, 100);
                //            m_timerStarted = true;
                //        }
                //    }
                //    calback(o, e);
                //}
                //    );

                m_timer = new Timer(OnTimeout, null, Timeout.Infinite, Timeout.Infinite);
            }
            catch (IOException ex) {

            }
        }

        public event FileSystemEvent Change;
        /// <summary>
        /// 启动监控
        /// </summary>
        public void Start()
        {
            m_fileSystemWatcher.EnableRaisingEvents = true;
        }
        /// <summary>
        /// 停止监控
        /// </summary>
        public void End()
        {
            m_fileSystemWatcher.EnableRaisingEvents = false;
        }

        private void OnChange(object sender, FileSystemEventArgs e)
        {
            // Don't want other threads messing with the pending events right now  
            lock (m_pendingEvents)
            {
                // Save a timestamp for the most recent event for this path  
                m_pendingEvents[e.FullPath] = DateTime.Now;

                // Start a timer if not already started  
                if (!m_timerStarted)
                {
                    m_timer.Change(100, 100);
                    m_timerStarted = true;
                }
            }
        }

        private void OnTimeout(object state)
        {
            List<string> paths;

            // Don't want other threads messing with the pending events right now  
            lock (m_pendingEvents)
            {
                // Get a list of all paths that should have events thrown  
                paths = FindReadyPaths(m_pendingEvents);

                // Remove paths that are going to be used now  
                paths.ForEach(delegate (string path)
                {
                    m_pendingEvents.Remove(path);
                });

                // Stop the timer if there are no more events pending  
                if (m_pendingEvents.Count == 0)
                {
                    m_timer.Change(Timeout.Infinite, Timeout.Infinite);
                    m_timerStarted = false;
                }
            }

            // Fire an event for each path that has changed  
            paths.ForEach(delegate (string path)
            {
                FireEvent(path);
            });
        }

        private List<string> FindReadyPaths(Dictionary<string, DateTime> events)
        {
            List<string> results = new List<string>();
            DateTime now = DateTime.Now;

            foreach (KeyValuePair<string, DateTime> entry in events)
            {
                // If the path has not received a new event in the last 75ms  
                // an event for the path should be fired  
                double diff = now.Subtract(entry.Value).TotalMilliseconds;
                if (diff >= 75)
                {
                    results.Add(entry.Key);
                }
            }

            return results;
        }

        private void FireEvent(string path)
        {
            Change?.Invoke(path);
        }
    }
}
