
function comconfim(msg,url,data = null,ajaxtype = 'post') {
    var index =  layer.confirm(msg, {
        btn: ['确定', '取消'], //按钮
        offset: 't',
        skin: 'layui-layer-molv'
    }, function (index) {
        layer.close(index);
        doAjax(url,ajaxtype, data);
    }, function () {
        layer.msg('取消操作');
    }
  )
}
//ajax提交数据
function doAjax(url,ajaxtype = 'post', data = null) {
    var index = layer.load(1, {
        shade:0.5
    });
    $.ajax(
        {
            type: ajaxtype,
            url: url,
            data: data,
            success: function (data) {
                //parent.location.reload();//刷新应用程序
                layer.close(index);
                layer.alert(data.message, {
                    icon: 1,
                    skin: 'layui-layer-molv' ,
                    offset: 't',
                    time:3000
                });

            },
            error: function (e) {
                var message = e.responseText;
                layer.close(index);
                layer.alert(message, {
                    icon: 2,
                    skin: 'layui-layer-lan'
                });
            }
        }
    );
}

