using PathWatch.App_Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace PathWatch
{
    public delegate void UIUpdatedelegate(string text);

    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 监控监听列表
        /// </summary>
        private List<DirectoryMonitor> watchList = new List<DirectoryMonitor>();
        private List<FileMoveInfor> fileList = new List<FileMoveInfor>();
        private List<string> fileNameList = new List<string>();
        public Queue<FileMoveInfor> fileQue = new Queue<FileMoveInfor>();

        UIUpdatedelegate ShowTextdelegate;
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            this.ShowInTaskbar = true;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ShowTextdelegate += ShowText;
            GetFileMap();
        }
        ///处理文件变更的方法
        private void UpLoadFile(object sender, FileSystemEventArgs e)
        {
            var text = string.Format("文件变更类型：{0}，文件名称：{1}  \r\n", e.ChangeType, e.FullPath);
            var task = Task.Factory.StartNew(
                () =>
                {
                    FileCopy(e.FullPath);
                }
            );
            Dispatcher.Invoke(ShowTextdelegate, text);
        }
        /// 获取监控的文件夹配置信息
        private void GetFileMap()
        {
            FileStream fs = new FileStream("FileMoveInFor.db", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            if (fs.Length > 0)
            {
                fileList = bf.Deserialize(fs) as List<FileMoveInfor>;
            }
            fs.Close();
            fileInforGird.ItemsSource = fileList;
        }

        ///展示信息
        private void ShowText(string text)
        {
            logOut.AppendText(DateTime.Now.ToString() + text);
            logOut.ScrollToEnd();
        }

        /// 复制到目标文件  加入复制队列
        private void FileCopy(string locaPath)
        {
            var fileName = System.IO.Path.GetFileName(locaPath);
            var path = System.IO.Path.GetDirectoryName(locaPath);
            var tarPath = fileList.Where(m => m.LocalFile == path).First().TargetFile + "\\" + fileName;

            var fileCount = fileNameList.Contains(fileName);

            if (fileCount)
            {
                Dispatcher.Invoke(ShowTextdelegate, locaPath + "队列已存在，跳过\r\n");
                return;
            }
            fileNameList.Add(fileName);

            var file = new FileMoveInfor()
            { LocalFile = locaPath, TargetFile = tarPath };
            fileQue.Enqueue(file);
            Dispatcher.Invoke(ShowTextdelegate, file.LocalFile + "已加入队列\r\n");
        }

        /// 启动监控任务
        private void StartTask()
        {
            EndPathWatch();

            ; foreach (var m in fileList)
            {
                ///启动勾选的监控目录
                if (m.IsCheck)
                {
                    var pathWatch = new DirectoryMonitor(m.LocalFile, UpLoadFile);
                    var infor = "目录——>" + m.LocalFile + "正在监控中。。。\r\n";
                    Dispatcher.Invoke(ShowTextdelegate, infor);
                    pathWatch.Start();
                    watchList.Add(pathWatch);
                }
            }

            //复制队列中的文件到目录
            Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(10);
                    if (fileQue.Count > 0)
                    {
                        Task.Factory.StartNew(
                        () =>
                        {
                            try
                            {
                                var file = fileQue.Dequeue();

                                fileNameList.Remove(System.IO.Path.GetFileName(file.LocalFile));
                                File.Copy(file.LocalFile, file.TargetFile, true);

                                Dispatcher.Invoke(ShowTextdelegate, "已移动：" + file.LocalFile + "至" + file.TargetFile + "\r\n");
                            }
                            catch (IOException ex)
                            {
                                Dispatcher.Invoke(ShowTextdelegate, ex.Message);
                            }
                        });
                    }
                }
            });
        }
        /// 启动监控
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            if (btn.Content.ToString() == "启动监控")
            {
                btn.Content = "关闭监控";
                StartTask();
                FileStream fs = new FileStream("FileMoveInFor.db", FileMode.OpenOrCreate);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, fileList);
                fs.Close();
            }
            else
            {
                btn.Content = "启动监控";
                EndPathWatch();
            }
        }

        private void EndPathWatch()
        {
            if (watchList.Count < 1) { return; }
            foreach (var m in watchList)
            {
                m.End();
                var infor = " 对目录=》" + m._path + "监控已关闭。。。\r\n";
                Dispatcher.Invoke(ShowTextdelegate, infor);
            }
            watchList.Clear();
        }
    }
}