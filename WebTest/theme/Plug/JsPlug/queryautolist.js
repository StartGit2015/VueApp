//*------------------------------
//*名称：录入查询下拉列表
//*功能：用于实现带文件的ajax表单提交
//*参数：valueControl: 存值控件
//*      valueFieldName: 数据源选中值字段名称
//*      textFieldName: 数据源选中文本字段名称,
//*      queryFields:查询的字段, 
//*      callbackType:查询方式,"js"-查询本地javascrpt脚本数据（json）,"ajax"-到服务取数据（json）
//*      ajaxUrl:callbackType为ajax时的服务器端地址
//*      selectedEvent:选中后事件函数
//*      selectEvent:选中前回事件函数
//*      dataList: callbackType为js时的数据对象
//*      maxRowCount: 显示的最大行数, 
//*      longDateFields: 要显示长时间格式的字段
//*      tableRowIndex:查询列表默认的选中行序号
//*      keyUpTime: null 
//*      buttons:显示出的查询快捷按钮
//*      focusShow:设置是否文本框获得焦点就显示下拉列表
//*      focusEvent:获得焦点时的事件
//*      nextFocusCtl:本控件失去焦点时获取焦点的下一个控件
//*      isShowPaging:是否显示分页栏      
//*      exId:控件id的补充，以防止控件重名
//*      initConditions:初始化查询条件[{name:'',value}]
//*      parentContainer:控件父容器
//*      textToQuery:是否将textControl的值赋值给查询录入控件(true,false)
//*      initConditions:初始化条件集合--[{ name: 'DeptIds', value:'aa'},{ name: 'DeptIds', value:'11'}]
//*      initConditionOrAnd:初始化条件集合的关系符号or,and
//*      initConditionExpr:复杂条件表达式 "({DeptIds}.indexOf({DeptIds.value})&&({MedTypeID}=={MedTypeID.value}||{MedTypeID}=={MedTypeID.value}))"
//*使用方法：
//*   (1)$("#txt_test").queryautolist("init", {
//*            valueFildName: "ID", textFieldName: "Name",
//*            queryFields: "ID,Name", dataList: aaa
//*      });
//*   (2)<input class="queryautolist" type="text" id="txt_test"  valueFieldName="ID" textFieldName="MenuName"
//*           queryFields="MenuID" maxRowCount="20" ajaxUrl="/Systems/Menu/Test", callbackType="ajax" />
//*   (3)<input type="text" class="queryautolist" valueFieldName="ID" textFieldName="Name" queryFields="ID,Name" dataList="aaa" id="txt_test2" />
//*--------------------------
//(function (jQuery) {
layui.define("jquery", function (exports) {
    var jQuery = layui.jquery;
    var queryJsList = function (_dataList, _queryFields, queryValue, maxRowCount, pageIndex, initConditions) {
        pageIndex = (!pageIndex || pageIndex < 1) ? 1 : pageIndex;
        var _list = new Array();
        var qfarray = _queryFields.split(",");
        var qlen = qfarray.length;
        var ilen = initConditions ? initConditions.length : 0;
        var queryValues = null;

        if (queryValue && queryValue.indexOf(" ") > -1 && queryValue.indexOf(" ") > 0)
            queryValues = queryValue.split(" ");


        for (var i = 0; i < _dataList.length; i++) {
            var data = _dataList[i];
            //查询初始化条件
            var isadd2 = false;
            var initConditionsExpr = initConditions && initConditions.expr ? initConditions.expr : "";
            for (var ii = 0; ii < ilen; ii++) {
                var ic = initConditions[ii];
                if (initConditions.expr) {
                    initConditionsExpr = initConditionsExpr.replace("{" + ic.name + "}", "data." + ic.name)
                        .replace("{" + ic.name + ".value}", ic.value);
                } else {
                    if (initConditions.orAnd && initConditions.orAnd == "and") {
                        if (!data[ic.name] || data[ic.name] == ic.value || (ic.opt && ic.opt == "like" && data[ic.name].indexOf(ic.value) > -1))
                            isadd2 = true;
                        else {
                            isadd2 = false;
                            break;
                        }
                    } else {
                        if (!data[ic.name] || data[ic.name] == ic.value || (ic.opt && ic.opt == "like" && data[ic.name].indexOf(ic.value) > -1))
                            isadd2 = true;
                    }
                }
            }
            if (initConditionsExpr != "")
                isadd2 = eval(initConditionsExpr);

            if (!isadd2 && initConditions && initConditions.length > 0) continue;

            //当前条件查询
            var isadd = false;
            var qCount = 0;

            for (var j = 0; j < qlen; j++) {
                if (queryValues != null && queryValues[j] && queryValues[j] != "" && data[qfarray[j]] && data[qfarray[j]].indexOf(queryValues[j]) > -1) {
                    //空格隔开的条件查询
                    qCount++;
                } else if (queryValues == null && data[qfarray[j]] && data[qfarray[j]].toString().indexOf(queryValue) > -1) {
                    isadd = true;
                }
            }

            if (queryValues && queryValues.length > 1 && qCount != queryValues.length)
                continue;
            else if (queryValues == null && !isadd)
                continue;

            _list.push(data);
        }

        var _len = _list.length;
        var end = maxRowCount * pageIndex - 1;
        var start = end - maxRowCount + 1;
        start = start < 0 ? 0 : start > _len ? _len - _len % maxRowCount : start;
        end = end > (_len - 1) ? _len : end;
        var relist = new Array();
        for (var i = start; i <= end; i++)
            relist.push(_list[i]);

        var maxPage = _len % maxRowCount == 0 ? _len / maxRowCount : parseInt(_len / maxRowCount) + 1;
        var tmpInt = _len - pageIndex * maxRowCount;
        pageIndex = tmpInt >= 0 ? pageIndex : (Math.abs(tmpInt) < maxRowCount ? pageIndex : maxPage);
        //alert("maxPage:" + maxPage + " pageIndex:" + pageIndex+" start:"+start+" end"+end);
        return { list: relist, pageIndex: pageIndex, rowCount: _len, maxPage: maxPage };
    }

    var createTableList = function ($txt, _dataList, showFields, longDateFields, parentContainer) {
        var id = $txt.attr("id");
        var isAjax = $txt.attr("callbacktype") == "ajax" ? true : false;
        var $table = $("#table_" + id, parentContainer);
        var $div = $("#div_" + id, parentContainer);

        if (_dataList && _dataList.length > 0 || isAjax)
            $div.show();
        else
            $div.hide();
        $table.empty();

        if ($txt.data("options").valueControl && $txt.data("options").valueControl.val() != "")
            $txt.data("options").tableRowIndex = -1;
        else
            $txt.data("options").tableRowIndex = 0;
        showFields = "," + showFields + ",";
        for (var i = 0; i < _dataList.length; i++) {
            var data = _dataList[i];
            var _row = $("<tr></tr>");
            if (i == $txt.data("options").tableRowIndex)
                _row.css("backgroundColor", "#7cc5e5");
            for (var p in data) {

                if (data[p] && typeof (data[p]).toString() == "function")
                    continue;
                if (showFields && showFields != "" && showFields.indexOf("," + p.toString() + ",") < 0)
                    continue;

                var valueStr = data[p] ? data[p].toString() : "&nbsp;&nbsp&nbsp;&nbsp";
                if (valueStr.indexOf("/Date(") > -1) {
                    valueStr = valueStr.replace("/", "").replace("/", "");
                    var date = eval(valueStr);
                    date = new Date(date);
                    if (longDateFields && longDateFields.indexOf(p) > -1)
                        valueStr = date.toLongString();
                    else
                        valueStr = date.toShortString();
                }
                var _cell = $("<td>" + valueStr + "</td>");
                _cell.appendTo(_row);
            }
            if (_row.html() != "")
                _row.appendTo($table);
        }


        $("tr", $table).bind("mouseover", function () {
            var rows = $table.find("tr");
            rows.css("backgroundColor", "");
            $txt.data("options").tableRowIndex = this.rowIndex;

            rows.eq(this.rowIndex).css("backgroundColor", "#7cc5e5");
        });
    }

    var getList = function ($this, pageIndex, fun, kcode) {
        if ($this.data("currMaxPage")) {
            if (pageIndex + 1 == 1)
                return;
            if (pageIndex - 1 == $this.data("currMaxPage"))
                return;
            if (pageIndex > $this.data("currMaxPage"))
                pageIndex = $this.data("currMaxPage");

        }
        var parentContainer = $this.data("options").parentContainer;

        var thisid = $this.attr("id");
        var $inputTxt = $("#inputtxt_" + thisid, parentContainer);
        if ($this.data("options").callbackType == "ajax" && $this.data("options").ajaxUrl) {
            if ((kcode != 40 && kcode != 38)) {

                $.getJSON($this.data("options").ajaxUrl,
                    {
                        queryFileds: $this.data("options").queryFileds,
                        queryValue: $inputTxt.val(),
                        pageIndex: pageIndex,
                        maxRowCount: $this.data("options").maxRowCount,
                        initConditions: $this.data("options").initConditions || ""
                    },
                    function (cdata) {
                        var _len = cdata.rowCount;
                        var maxRowCount = $this.data("options").maxRowCount;
                        var currMaxPage = _len % maxRowCount == 0 ? _len / maxRowCount : parseInt(_len / maxRowCount) + 1;
                        $this.data("currMaxPage", currMaxPage);
                        $this.data("queryList", cdata.list);
                        createTableList($this, cdata.list, $this.data("options").showFields, null, parentContainer);
                        $("#index_" + thisid, parentContainer).html(cdata.pageIndex);
                        $("#rowcount_" + thisid, parentContainer).html(cdata.rowCount);
                        setBtn(thisid, cdata.pageIndex, cdata.maxPage, parentContainer);

                        setTablePosition(thisid, parentContainer);
                        if (fun)
                            fun.apply($this, new Array(cdata));
                    });
            }
        }
        else {
            var list = typeof ($this.data("options").dataList) == "object" ? $this.data("options").dataList : window[$this.data("options").dataList];

            if (!list) {
                //alert(thisid + "[queryautolist]控件所设置的dataList:'" + $this.attr("dataList") + "'不存在");
                alert(thisid + "[queryautolist] set the dataList '" + $this.attr("dataList") + "' does not exist");
                return;
            }
            var cdata = queryJsList(list, $this.data("options").queryFields, $inputTxt.val(), $this.data("options").maxRowCount, pageIndex, $this.data("options").initConditions);
            $this.data("currMaxPage", cdata.maxPage);
            $this.data("queryList", cdata.list);
            createTableList($this, cdata.list, $this.data("options").showFields, null, parentContainer);
            $("#index_" + thisid, parentContainer).html(cdata.pageIndex);
            $("#rowcount_" + thisid, parentContainer).html(cdata.rowCount);
            setBtn(thisid, cdata.pageIndex, cdata.maxPage, parentContainer);

            if (fun)
                fun.apply($this, new Array(cdata));
        }
    }

    var setBtn = function (id, pageIndex, maxPage, parentContainer) {
        $("#a_per_" + id, parentContainer).attr("isDisabled", "false");
        $("#a_next_" + id, parentContainer).attr("isDisabled", "false");
        if (pageIndex == 1)
            $("#a_per_" + id, parentContainer).attr("isDisabled", "true");
        if (pageIndex == maxPage)
            $("#a_next_" + id, parentContainer).attr("isDisabled", "true");
    }

    var setTablePosition = function (id, parentContainer) {
        var winHeight = $(window).height(); //getWindowHeight();
        var $txt = $("#" + id, parentContainer);
        var $table = $("#table_" + id, parentContainer);
        var $div = $("#div_" + id, parentContainer);
        var $pDiv = $($table.parent());
        var btnsHeight = $("#" + id + "_buttons", parentContainer)[0] ? $("#" + id + "_buttons", parentContainer).height() : 0;
        var tableHeight = $table.height();
        var divTop = $div.scrollTop();
        var txtTop = $txt.scrollTop() + $txt.offset().top + 24;
        var stop = $txt.scrollTop();
        var sleft = $txt.scrollLeft();
        var pos = $txt.position();
        var offset = $txt.offset();

        var pagerHeight = $("#paging_" + id, parentContainer).css("display") == "block" ? $("#paging_" + id, parentContainer).height() : 0;
        var divTop = stop + offset.top;
        var divHeight = $div.height() + 20; //tableHeight + pagerHeight + btnsHeight + 20;
        if (winHeight - divTop < divHeight)
            divTop = winHeight - divHeight - 20;
        $div.css({ left: sleft + offset.left, top: divTop });
        if (divHeight > winHeight) {
            $pDiv.css("height", winHeight);
            $pDiv.css("overflow", "auto");
            $pDiv.css("overflow-x", "hidden");
            $pDiv.width($table.width() + 20);
            $table[0].style.width = "100%";
        }
    }

    var setValue = function (inputControl) {//, options) {

        var options = inputControl.data("options");
        if (!inputControl.data("queryList") || inputControl.data("queryList").length < 1) return;
        var val = inputControl.data("queryList")[options.tableRowIndex][options.valueFieldName];
        var txt = inputControl.data("queryList")[options.tableRowIndex][options.textFieldName];
        if (options.valueControl) {
            if (options.valueControl[0].tagName.toLowerCase() == "input")
                options.valueControl.val(val);
            else
                options.valueControl.html(val);
        }
        if (options.textControl) {
            if (options.textControl[0].tagName.toLowerCase() == "input")
                options.textControl.val(txt);
            else
                options.textControl.html(txt);
        }
    }

    var _init = function ($this, options) {
        //return this.each(function () {

        //var $this = $(this);
        var defaults = {
            valueControl: undefined,
            valueFieldName: "",
            textFieldName: "",
            showFields: "",
            initConditions: "",
            queryFields: "",
            dataList: "",
            maxRowCount: 20,
            textControl: undefined,
            focusShow: true,
            nextFocusCtl: undefined,
            longDateFields: "",
            tableRowIndex: -1,
            keyUpTime: null,
            buttons: "", //[{ text: "a", value: "a" }, { text: "b", value: "b"}],
            ajaxUrl: "",
            callbackType: "js",
            selectedEvent: function () { return true; },
            selectEvent: function () { return true; },
            focusEvent: function () { return true; },
            isShowPaging: true, exId: "",
            textToQuery: false,
            parentContainer: undefined,
            queryStrCase: "",
            popWidth: ""//upper,lower
        };

        options = $.extend({}, defaults, options);
        $this.data("options", options);
        if ($this.attr("parentContainer") || $this.attr("parentContainer") == false)
            $this.data("options").parentContainer = $("#" + $this.attr("parentContainer"));
        var parentContainer = $this.data("options").parentContainer || $this.parent();

        if ($this.attr("valueControl") && $this.attr("valueControl") != "")
            $this.data("options").valueControl = $("#" + $this.attr("valueControl"), parentContainer);
        else if (options.valueControl)
            $this.data("options").valueControl = options.valueControl;
        else
            $this.data("options").valueControl = undefined;

        if ($this.attr("valueFieldName") && $this.attr("valueFieldName") != "")
            $this.data("options").valueFieldName = $this.attr("valueFieldName");
        if ($this.attr("textFieldName") && $this.attr("textFieldName") != "")
            $this.data("options").textFieldName = $this.attr("textFieldName");
        if ($this.attr("queryFields") && $this.attr("queryFields") != "")
            $this.data("options").queryFields = $this.attr("queryFields");
        if ($this.attr("maxRowCount") && $this.attr("maxRowCount") != "")
            $this.data("options").maxRowCount = $this.attr("maxRowCount");
        if ($this.attr("longDateFields") && $this.attr("longDateFields") != "")
            $this.data("options").longDateFields = $this.attr("longDateFields");
        if ($this.attr("tableRowIndex") && $this.attr("tableRowIndex") != "")
            $this.data("options").tableRowIndex = $this.attr("tableRowIndex");
        if ($this.attr("keyUpTime") && $this.attr("keyUpTime") != "")
            $this.data("options").keyUpTime = $this.attr("keyUpTime");
        if ($this.attr("callbackType") && $this.attr("callbackType") != "")
            $this.data("options").callbackType = $this.attr("callbackType");
        if ($this.attr("ajaxUrl") && $this.attr("ajaxUrl") != "")
            $this.data("options").ajaxUrl = $this.attr("ajaxUrl");
        if ($this.attr("showFields") && $this.attr("showFields") != "")
            $this.data("options").showFields = $this.attr("showFields");
        if ($this.attr("focusShow") && $this.attr("focusShow") != "")
            $this.data("options").focusShow = $this.attr("focusShow");
        if ($this.attr("nextFocusCtl") && $this.attr("nextFocusCtl") != "") {
            var nfctl = $this.attr("nextFocusCtl");
            if (nfctl.indexOf("$") > -1)
                $this.data("options").nextFocusCtl = eval(nfctl);
            else
                $this.data("options").nextFocusCtl = $("#" + nfctl);
        }
        if ($this.attr("exId") && $this.attr("exId") != "")
            $this.data("options").exId = $this.attr("exId");

        if ($this.attr("initConditions") && $this.attr("initConditions") != "")
            $this.data("options").initConditions = eval("(" + $this.attr("initConditions") + ")");
        else
            $this.data("options").initConditions = new Array();

        if ($this.attr("initConditionOrAnd") && $this.attr("initConditionOrAnd") != "")
            $this.data("options").initConditions.orAnd = $this.attr("initConditionOrAnd");
        if ($this.attr("initConditionExpr") && $this.attr("initConditionExpr") != "")
            $this.data("options").initConditions.expr = $this.attr("initConditionExpr");

        if ($this.attr("focusEvent")) {
            var fun = $this.attr("focusEvent");
            $this.data("options").focusEvent = typeof (fun) == "object" ? fun : eval(fun);
        }
        if ($this.attr("selectedEvent")) {
            var fun = $this.attr("selectedEvent");
            $this.data("options").selectedEvent = typeof (fun) == "object" ? fun : eval(fun);
        }
        if ($this.attr("selectEvent")) {
            var fun = $this.attr("selectEvent");
            $this.data("options").selectEvent = typeof (fun) == "object" ? fun : eval(fun);
        }
        if ($this.attr("buttons") || $this.attr("buttons") == "")
            $this.data("options").buttons = ($this.attr("buttons") == "" ? "" : eval($this.attr("buttons")));
        if ($this.attr("textToQuery") || $this.attr("textToQuery") == false)
            $this.data("options").textToQuery = $this.attr("textToQuery") == "true" ? true : false;
        if ($this.attr("isShowPaging") || $this.attr("isShowPaging") == false)
            $this.data("options").isShowPaging = $this.attr("isShowPaging");
        if ($this.attr("queryStrCase") && $this.attr("queryStrCase") != "")
            $this.data("options").queryStrCase = $this.attr("queryStrCase");

        if ($this.attr("popWidth") && $this.attr("popWidth") != "")
            $this.data("options").popWidth = $this.attr("popWidth");
        var id = $this.attr("id");
        //id = $this.data("options").exId + ($this.data("options").exId ? "_" : "") + id;
        //$this.attr("id", id);
        var tableId = "table_" + id;
        var divId = "div_" + id;
        var pagingId = "paging_" + id;
        var inputtxtId = "inputtxt_" + id;
        var $div = $("#" + divId, parentContainer || $this.parent());
        var $inputTxt = $("#" + inputtxtId, $div);
        var isBtnsFocus = false;

        if (typeof ($this.data("options").textControl) == "string") {
            $this.data("options").textControl = $("#" + $this.data("options").textControl, parentContainer);
        }
        $this.data("options").textControl = $this;
        if ($this.attr("dataList"))
            $this.data("options").dataList = $this.attr("dataList");
        $this.attr("autocomplete", "off");

        var popWidth = $this.data("options").popWidth && $this.data("options").popWidth != "" ? "width:" + $this.data("options").popWidth + ";" : "";
        if ($div[0]) $div.remove();
        var html = "<div id='" + divId + "' class='qal_container' style='" + popWidth + "'>"
            + "<div><input type='text' id='inputtxt_" + id + "' autocomplete='off'/><div>"
            + (($this.data("options").buttons && $this.data("options").buttons != "") ? "<div id='" + divId + "_buttons' class='qal_btn_div'></div>" : "")
            + "<div><table  id='" + tableId + "'  class='qal_table'></table></div>"
            + "<div id='" + pagingId + "' class='qal_pager' >"
            + "<a id='a_per_" + id + "' href='javascript:void(0)'>上页</a>&nbsp;&nbsp;<a id='a_next_" + id + "' href='javascript:void(0)'>下页</a>"
            + "&nbsp;&nbsp;第<span id='index_" + id + "'>1</span>页&nbsp;&nbsp;共<span id='rowcount_" + id + "'>1</span>条</div></div>";
        $this.parent().append(html);
        $div = $("#" + divId, parentContainer);
        $inputTxt = $("#" + inputtxtId, $div);
        if ($this.data("options").isShowPaging == "false")
            $("#" + pagingId, $div).hide();
        //设置快捷按钮
        if ($this.data("options").buttons) {
            $divbtns = $("#" + divId + "_buttons", $div);
            $divbtns.css("textAlign", "center");
            var $btnDel = $("<button type='button' value='←' width='15px'>←</button>").appendTo($divbtns);
            $btnDel.blur();
            $btnDel.unbind("mouseup");
            $btnDel.mouseup(function () {

                isBtnsFocus = true;
                if ($inputTxt.val().trim() != "") {
                    var tlen = $inputTxt.val().length;
                    $inputTxt.focus();
                    $inputTxt.val($inputTxt.val().substr(0, tlen - 1));
                    getList($this, 1, null, 35);
                }
                return false;
            });
            for (var i = 0; i < $this.data("options").buttons.length; i++) {
                if ($this.data("options").buttons[i].text == "</br>" || $this.data("options").buttons[i].text == "<br>")
                    $("<br>").appendTo($divbtns);
                else {
                    var $btn = $("<button class='btn btn-blue' type='button' svalue='" + $this.data("options").buttons[i].value + "' width='10px'>" + $this.data("options").buttons[i].text + "</button>").appendTo($divbtns);
                    $btn.unbind("mouseup");
                    $btn.mouseup(function () {
                        isBtnsFocus = true;
                        $inputTxt.focus();
                        $inputTxt.val($inputTxt.val() + $(this).attr("svalue"));
                        getList($this, 1, null, 35);
                        return false;
                    });
                }
            }
        }
        $div.fadeIn(1000);
        $div.hide();

        var $table = $("#" + tableId, parentContainer);

        $("#a_per_" + id, $div).click(function () {
            isBtnsFocus = true;
            $inputTxt.focus();
            $this.data("options").tableRowIndex = -1;
            var index = parseInt($.trim($("#index_" + id).html())) - 1;
            getList($this, index, function (data) { });
        });

        $("#a_next_" + id, $div).click(function () {
            isBtnsFocus = true;
            $inputTxt.focus();
            $this.data("options").tableRowIndex = -1;
            var index = parseInt($.trim($("#index_" + id).html())) + 1;
            getList($this, index, function (data) { });
        });

        $this.click(function () {
            $this.focus();
        });

        if ($this.data("options").focusShow) {
            $this.focus(function () {
                if ($this.data("options").textToQuery == true) {
                    $inputTxt.val($this.val());
                }

                setTimeout(function () {
                    //
                    //$inputTxt.focus();

                    if ($this.data("options").focusEvent && $this.data("options").focusEvent != "")
                        $this.data("options").focusEvent.apply($this, new Array($this));

                    if (!$this.data("queryList") || $this.data("queryList").length == 0) {
                        getList($this, 1, undefined, 39);
                        $div.show();
                        $table.show();
                        $divbtns.show();
                        $("#" + pagingId).show();
                    }
                    else {
                        $div.show();
                        $table.show();
                        $divbtns.show();
                        $("#" + pagingId).show();
                    }
                    setTablePosition(id, parentContainer);
                    $this.blur();
                    $inputTxt.focus();
                }, 150);
            });
        }

        $inputTxt.unbind("keyup");
        $inputTxt.keyup(function (event) {
            if ($this.data("options").queryStrCase == "upper")
                $inputTxt.val($inputTxt.val().toUpperCase());
            else if ($this.data("options").queryStrCase == "lower")
                $inputTxt.val($inputTxt.val().toLowerCase());

            id = $this.attr("id");
            //如果为ajax方式查询数据
            var kcode = event.keyCode || event.which || event.charCode;
            if ((kcode > 64 && kcode < 91) || (kcode > 96 && kcode < 111) || (kcode > 47 && kcode < 58) || kcode == 32 || kcode == 8) {
                getList($this, 1, function (data) {
                    $("#index_" + id).html(data.pageIndex);
                }, kcode);
                setTablePosition(id, parentContainer);
                $this.data("options").tableRowIndex = -1;
            } else if (kcode == 40 || kcode == 38) {//上下键

                var rows = $table.find("tbody>tr");

                rows.css("backgroundColor", "");
                if (kcode == 40 && (rows.length > $this.data("options").tableRowIndex + 1)) {
                    var index = $this.data("options").tableRowIndex + 1;
                    $this.data("options").tableRowIndex = index;
                }
                if (kcode == 38 && $this.data("options").tableRowIndex > 0) {
                    var index = $this.data("options").tableRowIndex - 1;
                    $this.data("options").tableRowIndex = index;
                }
                //alert($this.data("options").tableRowIndex);
                var currRow = rows.eq($this.data("options").tableRowIndex);
                currRow.css("backgroundColor", "#7cc5e5");
                //$table.parent().scrollTop(currRow.offset().top + currRow.position().top);
            }

            else if (kcode == 37) {//"<-"向上翻页
                $this.data("options").tableRowIndex = -1;
                if ($div.css("display") == "block") {
                    var index = parseInt($.trim($("#index_" + id).html())) - 1;
                    getList($this, index, function (data) {
                        setBtn(id, data.pageIndex, data.maxPage, parentContainer);
                    });
                }
            }
            else if (kcode == 39) {//"->"下翻页
                $this.data("options").tableRowIndex = -1;
                if ($div.css("display") == "block") {
                    var index = parseInt($.trim($("#index_" + id).html())) + 1;
                    getList($this, index, function (data) {
                        setBtn(id, data.pageIndex, data.maxPage, parentContainer);
                    });
                }
            }
            else if (kcode == 27) {//"Esc"键
                $div.hide();
            }
        });
        $inputTxt.keydown(function (event) {
            var kcode = event.keyCode || event.which || event.charCode;
            if (kcode == 13) { //回车键
                if (!$this.data("options").textFieldName) {
                    alert("Please set textFieldName");
                    return;
                }
                if ($this.data("options").tableRowIndex > -1) {
                    var rdata = $this.data("queryList")[$this.data("options").tableRowIndex];
                    var selectEvent = $this.data("options").selectEvent;
                    var flag = true;
                    if (selectEvent && selectEvent != "")
                        flag = selectEvent.apply($this, new Array(rdata, $this))
                    if (!flag) return;
                    setValue($this, $this.data("options"));

                    var selectedEvent = $this.data("options").selectedEvent;
                    if (selectedEvent && selectedEvent != "")
                        selectedEvent.apply($this, new Array(rdata, $this))
                    if ($this.data("options").nextFocusCtl)
                        $this.data("options").nextFocusCtl.focus();
                    $div.hide();
                }
            }
        });
        //鼠标滚轮翻页
        var mousewheelName = navigator.userAgent.indexOf('rv:11.0') != -1 || !/firefox/.test(navigator.userAgent.toLowerCase()) ? "mousewheel" : "DOMMouseScroll";
        var mousewheelLen = 0;
        $table.bind(mousewheelName, function (e) {

            var wheelDelta = navigator.userAgent.indexOf('rv:11.0') != -1 || !/firefox/.test(navigator.userAgent.toLowerCase()) ? event.wheelDelta : e.originalEvent.detail * -1;
            mousewheelLen += 1;
            if (mousewheelLen == 3) {
                mousewheelLen = 0;
                $this.data("options").tableRowIndex = -1;
                if (wheelDelta > 0) {
                    var index = parseInt($.trim($("#index_" + id).html())) - 1;
                    getList($this, index, function (data) {
                        setBtn(id, data.pageIndex, data.maxPage, parentContainer);
                    });
                } else {
                    var index = parseInt($.trim($("#index_" + id).html())) + 1;
                    getList($this, index, function (data) {
                        setBtn(id, data.pageIndex, data.maxPage, parentContainer);
                    });
                }
            }
        });

        $inputTxt.bind("blur", function () {
            setTimeout(function () {
                if (!isBtnsFocus)
                    $div.hide();
                else
                    isBtnsFocus = false;
            }, 250);
        });

        $this.dblclick(function (event) {
            id = $this.attr("id");
            $div.show();
            setTablePosition(id, parentContainer);
        });

        $table.click(function () {
            var rdata = $this.data("queryList")[$this.data("options").tableRowIndex];
            var selectEvent = $this.data("options").selectEvent;
            var flag = true;
            if (selectEvent && selectEvent != "")
                flag = selectEvent.apply($this, new Array(rdata, $this));
            if (!flag) return;
            setValue($this, $this.data("options"));
            $div.hide();
            var selectedEvent = $this.data("options").selectedEvent;
            if (selectedEvent && selectedEvent != "")
                selectedEvent.apply($this, new Array(rdata, $this))
            if ($this.data("options").nextFocusCtl)
                $this.data("options").nextFocusCtl.focus();
        });
        //});
    }

    var methods = {
        init: function (options) {
            return this.each(function () {
                var $this = $(this);

                $this.one("focus click", function () {
                    if ($this.data("options")) return;
                    _init($this, options);
                    if (/msie/.test(navigator.userAgent.toLowerCase()) && !$.support.leadingWhitespace) {//判断IE8
                        $this.click();
                    }

                });
            });
        },
        clear: function () {
            return this.each(function () {
                var $this = $(this);
                if ($this.data("queryList")) {
                    $this.data("queryList").length = 0;
                }
                $this.data("options", "");
                var $table = $("#table_" + this.id);
                $table.empty();
            });
        }
    };
    $.fn.queryautolist = function () {

        var method = arguments[0];
        if (methods[method]) {
            method = methods[method];
            arguments = Array.prototype.slice.call(arguments, 1);
        } else if (typeof (method) == 'object' || !method) {
            method = methods.init;
        } else {
            $.error('Method ' + method + ' does not exist on jQuery.selectbox');
            return this;
        }
        return method.apply(this, arguments);
    }

    Date.prototype.toShortString = function () {
        return this.getYear() + "-" + this.getMonth() + "-" + this.getDay();
    }
    Date.prototype.toLongString = function () {
        return this.getYear() + "-" + this.getMonth() + "-" + this.getDay() + " " + this.getHours() + ":" + this.getMinutes() + ":" + this.getSeconds();
    }
//})(jQuery);
    exports('queryautolist', {});
});