var errorBdColor = "#ffa8a8";
var errorBgColor = "#fff8f8";
var okBdColor = "#dddddd";
var okBgColor = "white";

var Common = {
    compareDate: function (startTime, endTime) {
        if (startTime != "" && endTime != "") {
            var t1 = new Date(startTime.replace(/-/g, "\/"));
            var t2 = new Date(endTime.replace(/-/g, "\/"));
            if (t1 == t2) return 0;
            else {
                return (t1 > t2) ? 1 : -1;
            }
        } else {
            return 100;
        }
    },
    display: function (obj, displayStyle) {/*显示或隐藏对象 true 显示*/
        if (displayStyle)
            $("#" + obj).css("display", "block");
        else
            $("#" + obj).css("display", "none");
    },
    checkExp: function (reg, text) {
        return reg.test(text)
    },
    isAlphaNumeric: function (contrlName) {//判断是否是字母或数字     
        if (this.isEmpty(contrlName))
            return true;

        var Obj = $('#' + contrlName);
        var reg = /^\w*$/gi;

        if (!this.checkExp(reg, Obj.val())) {
            return false;
        } else {
            return true;
        }
    },
    isChinese: function (contrlName) {//判断是否是中文 ,  
        if (this.isEmpty(contrlName))
            return true;

        var Obj = $('#' + contrlName);
        var reg = /^[\u4E00-\u9FA5]{1,100}$/;
        if (!this.checkExp(reg, Obj.val())) {
            return false;
        } else {
            return true;
        }
    },
    isCardNo: function (contrlName) {  //判断身份证号码
        if (this.isEmpty(contrlName))
            return true;

        var Obj = $('#' + contrlName);
        var reg = /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/;

        if (!this.checkExp(reg, Obj.val())) {
            return false;
        } else {
            return true;
        }
    },
    isPhone: function (contrlName) { //判断手机
        if (this.isEmpty(contrlName))
            return true;

        var Obj = $('#' + contrlName);
        var reg = /^1[34578]\d{9}$/;

        if (!this.checkExp(reg, Obj.val())) {
            return false;
        } else {
            return true;
        }
    },
    isEmpty: function (contrlName) {  //判断是否为空
        var Obj = $('#' + contrlName);
        if ($.trim(Obj.val()) == "") {
            return true;
        } else {
            return false;
        }
    },
    isEmail: function (contrlName) {   //判断Email是否合法
        if (this.isEmpty(contrlName))
            return true;

        var reg = /^[\w\-\.]+@[\w\-\.]+(\.\w+)+$/;
        var Obj = $('#' + contrlName);

        if (!this.checkExp(reg, Obj.val())) {
            return false;
        } else {
            return true;
        }
    },
    isPositiveNumber: function (contrlName) {//判断是否正整数
        if (this.isEmpty(contrlName))
            return true;

        var reg = /^\d*$/g;
        var Obj = $('#' + contrlName);

        if (!this.checkExp(reg, Obj.val())) {
            return false;
        } else {
            return true;
        }
    },
    isNumeric: function (contrlName) {//判断是否数字 0123456789
        if (this.isEmpty(contrlName))
            return true;

        var reg = /^-?\d*(\.?\d+)?$/g;
        var Obj = $('#' + contrlName);

        if (!this.checkExp(reg, Obj.val())) {
            return false;
        } else {
            return true;
        }
    },
    isFloat: function (contrlName) {//判断是否 数字和小数点
        if (this.isEmpty(contrlName))
            return true;

        var reg = /^\d*(\.\d+)?$/g;
        var Obj = $('#' + contrlName);

        if (!this.checkExp(reg, Obj.val())) {
            return false;
        } else {
            return true;
        }
    },
    isDate: function (contrlName) {//判断是否日期 2015-01-11
        if (this.isEmpty(contrlName))
            return true;

        var Obj = $('#' + contrlName);
        var reg = /^\d{4}-[01]?\d-[0-3]?\d$/g;

        if (!this.checkExp(reg, Obj.val())) {
            return false;
        }

        var arr = Obj.val().split("-");
        var year = arr[0];
        var month = arr[1];
        var day = arr[2];

        // 1 <= 月份 <= 12，1 <= 日期 <= 31
        if (!((1 <= month) && (12 >= month) && (31 >= day) && (1 <= day)))
            return false;

        // 润年检查
        if (!((year % 4) == 0) && (month == 2) && (day == 29))
            return false;

        // 7月以前的双月每月不超过30天
        if ((month <= 7) && ((month % 2) == 0) && (day >= 31))
            return false;

        // 8月以后的单月每月不超过30天
        if ((month >= 8) && ((month % 2) == 1) && (day >= 31))
            return false;

        // 2月最多29天
        if ((month == 2) && (day >= 30))
            return false;

        return true;
    },
    isDate2: function (contrlName, objThis) {//判断是否日期 2015-01-11    
        var Obj = $(objThis);
        var reg = /^\d{4}-[01]?\d-[0-3]?\d$/g;

        if (!this.checkExp(reg, Obj.val())) {
            return false;
        }

        var arr = Obj.val().split("-");
        var year = arr[0];
        var month = arr[1];
        var day = arr[2];

        // 1 <= 月份 <= 12，1 <= 日期 <= 31
        if (!((1 <= month) && (12 >= month) && (31 >= day) && (1 <= day)))
            return false;

        // 润年检查
        if (!((year % 4) == 0) && (month == 2) && (day == 29))
            return false;

        // 7月以前的双月每月不超过30天
        if ((month <= 7) && ((month % 2) == 0) && (day >= 31))
            return false;

        // 8月以后的单月每月不超过30天
        if ((month >= 8) && ((month % 2) == 1) && (day >= 31))
            return false;

        // 2月最多29天
        if ((month == 2) && (day >= 30))
            return false;

        return true;
    },
    isFileExt: function (obj) { //文件扩展名判断限制
        var fileExt = $(obj).val().substring($(obj).val().lastIndexOf(".") + 1).toLowerCase();
        if (fileExt != 'jpg' && fileExt != 'jpeg') {
            layer.alert("文件格式不合法,图片限于 jpg或jpeg 格式!");
            if (!window.addEventListener) {
                obj.outerHTML += '';
            }
            else {
                obj.value = '';
            }
            return;
        }
    },
    FinishExe: function (jqObj, alertFlag, message) {
        if (alertFlag) {
            jqObj.css("background-color", errorBgColor);
            jqObj.css("border", "1px solid " + errorBdColor);
            layer.alert("<strong style='color:red;font-size:13px;'>(" + jqObj.attr("labelTitle") + ")</strong>" + message, { btnAlign: 'c' }, function (index) {
                jqObj.focus();
                layer.close(index);
            });
        } else {
            jqObj.css("background-color", okBgColor);
            jqObj.css("border", "1px solid " + okBgColor);
            jqObj.css("border-bottom", "1px solid " + okBdColor);
        }
    },
    Validate: function (contrlName) {
        var obj = $('#' + contrlName);
        var objValue = $.trim(obj.val());
        var objMode = obj.attr("mode");
        if (typeof (objMode) != "undefined") {
            objMode = objMode.toLowerCase();
        }

        if (typeof (obj.attr("canEmpty")) != "undefined" && obj.attr("canEmpty") == "false" && objValue == "") {
            this.FinishExe(obj, true, "不能为空!");
            return false;
        }

        if (objValue != "") {
            if (objMode == "int" && !this.isPositiveNumber(contrlName)) {
                this.FinishExe(obj, true, "只能是0-9的数字");
                return false;
            } else if (objMode == "date" && !this.isDate(contrlName)) {
                this.FinishExe(obj, true, "日期格式不正确,如:2018-18-18");
                return false;
            } else if (objMode == "float" && !this.isFloat(contrlName)) {
                this.FinishExe(obj, true, "只能是数字或小数,如:100或100.15");
                return false;
            } else if (objMode == "email" && !this.isEmail(contrlName)) {
                this.FinishExe(obj, true, "Email格式不正确,如:jdk580@168.com");
                return false;
            } else if (objMode == "chinese" && !this.isChinese(contrlName)) {
                this.FinishExe(obj, true, "只能输入中文汉字");
                return false;
            }
            else {
                this.FinishExe(obj, false, null);
                return true;
            }
        } else {
            this.FinishExe(obj, false, null);
            return true;
        }
    },
    mouseClick: function (obj) {  //不让用户多次点击,在第一次没有运行完成情况下
        if ($(obj).attr("clickflag") == 'ok') {
            $(obj).attr("clickflag", "no");
            return true;
        } else {
            layer.alert("程序正在处理中,请稍后.......");
            return false;
        }
    },
    fnLayerTips: function (message, that) {
        if (message != "") {
            layer.tips(message, that, { time: 19000, closeBtn: [0, true] });
        }
    },
    fnLayerAlert: function (message) {
        layer.alert(message, { btnAlign: 'c', time: 5000 }, function (index) {
            layer.close(index);
        });
    },
    fnLayerAlertAndClosetime: function (message, closetime) {
        layer.alert(message, { btnAlign: 'c', time: closetime }, function (index) {
            layer.close(index);
        });
    },
    fnLayerAlertAndRefresh: function (message) {
        if (message.length > 0) {
            layer.alert(message, { btnAlign: 'c', time: 5000 }, function (index) {
                layer.close(index);
                window.location.href = getNewUrl();
            });
        } else {
            window.location.href = getNewUrl();
        }
    },
    fnLayerAlertAndCallBack: function (message, callback) {
        if (message.length > 0 && typeof callback == "function") {
            layer.alert(message, { btnAlign: 'c', time: 5000 }, function (index) {
                layer.close(index);
                callback();
            });
        } else {
            callback();
        }
    },
    fnLayerOpen: function (title, width, height, url, isRefresh, message) {
        var closeBtn = 1;
        if (typeof (title) == 'boolean')
            closeBtn = 0;//不显示关闭按钮    
        layer.open({
            closeBtn: closeBtn,
            type: 2,
            title: title,               //窗体题名
            maxmin: false,       //是否允许窗体最大化
            resize: false,          //是否允许拖动窗体放大缩小
            shadeClose: false, //点击遮罩关闭层
            area: [width, height],           //窗体高度,宽度
            content: url,          //url
            end: function () {  //窗体关闭回发事件
                if (isRefresh) {
                    if ($("#hidOpenFlag").val() == "1") {
                        Common.fnLayerAlertAndRefresh(message);
                    }
                }
            }
        });
    },
    selCheckBoxAll: function (obj) {
        var selFlag = false;
        if ($(obj).attr("selall") == "0")
            selFlag = true;

        $("input[type='checkbox'][name='checkOne']").each(function () {
            if ($(this).prop('disabled') != 'disabled') {
                $(this).prop('checked', selFlag);
            }
        });
        $(obj).attr("selall", (selFlag ? "1" : "0"))
    },
    isCheckBoxMoreChecked: function () {
        if ($("input[type='checkbox'][name='checkOne']:checked").length < 1) {
            this.fnLayerAlert("请至少选中一行再进行操作!");
            return false;
        } else {
            return true;
        }
    },
    isCheckBoxOneChecked: function () {
        if ($("input[type='checkbox'][name='checkOne']:checked").length != 1) {
            this.fnLayerAlert("每次只能选中一行再进行操作!");
            return false;
        } else {
            return true;
        }
    },
    isRadioCheck: function () {
        if ($("input[type='radio']:checked").length < 1) {
            this.fnLayerAlert("请至少选中一行再进行操作!");
            return false;
        } else {
            return true;
        }
    },
    getChkOneKeyToArray: function () {//获取选中单一行的相关信息
        var sp = new Array();
        $("input[type='checkbox'][name='checkOne']:checked").each(function () {
            sp = ($(this).val() + ',').split(',');
        });
        return sp;
    },
    getChkMoreKeyListToString: function (keyIndex) {//获取多行中某个key的所有信息,删除多条数据有用 
        var strKey = "";
        $("input[type='checkbox'][name='checkOne']:checked").each(function () {
            if (strKey == "")
                strKey = ($(this).val() + ',').split(',')[keyIndex];
            else
                strKey += "," + ($(this).val() + ',').split(',')[keyIndex];
        });
        return strKey;
    },
    getChkMoreKeyListToArray: function (keyIndex) {//获取多行中某个key的所有信息 
        var sp = new Array();
        $("input[type='checkbox'][name='checkOne']:checked").each(function () {
            sp.push(($(this).val() + ',').split(',')[keyIndex]);
        });
        return sp;
    },
    getRadioKeyToArray: function () {//获取选中单一行的相关信息
        var sp = new Array();
        $("input[type='radio'][name='radio']:checked").each(function () {
            sp = ($(this).val() + ',').split(',');
        });
        return sp;
    },
    urlreplace: function (url, paramname, paramvalue) {
        if (typeof url !== "string") {
            return;
        }
        if ($.trim(url).length > 0) {
            url = url.toLowerCase().replace("#", "")
        }

        var index = url.indexOf("?");
        if (index == -1) {
            url = url + "?" + paramname + "=" + paramvalue;
        } else {
            var s1 = url.split("?");
            var params = s1[1].split("&");
            var pn = "";
            var flag = false;
            for (i = 0; i < params.length; i++) {
                pn = params[i].split("=")[0];
                if (pn.toLowerCase() === paramname.toLowerCase()) {
                    params[i] = paramname + "=" + paramvalue;
                    flag = true;
                    break;
                }
            }
            if (!flag) {
                url = url + "&" + paramname + "=" + paramvalue;
            } else {
                url = s1[0] + "?";
                for (i = 0; i < params.length; i++) {
                    if (i > 0) {
                        url = url + "&";
                    }
                    url = url + params[i];
                }
            }

        }
        return url;
    },
    isTextAreaCheckLength: function (obj, maxlength) {
        if (obj.value.length > maxlength) {
            obj.value = obj.value.substring(0, maxlength);
        }
    },
    getFileTypeForProjectType: function (projectType) {
        if (Number(projectType) == 2 || Number(projectType) == 3)
            return 2;
        else if (Number(projectType) == 4 || Number(projectType) == 5)
            return 3;
        else if (Number(projectType) == 1)
            return 1;
        else
            return 0;
    },
    fnParentLayerClose: function () {  //子页面关闭父页面弹出的layui iframe
        var index = parent.layer.getFrameIndex(window.name);
        parent.layer.close(index);
    },
    fnParentLayerCloseAndRefresh: function () {  //子页面关闭父页面弹出的layui iframe
        var index = parent.layer.getFrameIndex(window.name);
        parent.document.getElementById('hidOpenFlag').value = '1';
        parent.layer.close(index);
    },
    getRedStrongString: function (msg) {
        return "<strong style='color:red'>" + msg + "</strong>";
    },
    getBlackStrongString: function (msg) {
        return "<strong style='color:black'>" + msg + "</strong>";
    },
    lookFileAttachToZH: function (attachPath, zh, title) {
        window.top.parent.ParentOpenDiv(title + '(' + this.getRedStrongString(zh) + ')' + '附件预览', attachPath, '80%', '95%');
    }
}


