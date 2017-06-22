//操作前确认方法
function comconfim(url, msg) {
    layer.confirm(msg, {
        btn: ['确定', '取消'] //按钮
    }, function () {
        layer.msg('点击了确定', { icon: 1 });
    }, function () {
        layer.msg('点击了取消');
    }
  )
}

function doAjax() {
    var index = layer.load(1);
    $.ajax(
        {
            type: 'post',
            url: url,
            success: function (data) {
                layer.close(index);
                element.tabAdd('tab', { title: title, content: data, id: id });
                //切换到指定索引的卡片
                element.tabChange('tab', id);
            },
            error: function (e) {
                var message = e.responseText;
                layer.close(index);
                layer.msg(message, { icon: 2 });
            }
        }
    );
}

