<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLoginGather.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.UserLoginGather" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Javascript/Layer/css/login.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="Javascript/Layer/lib/jquery-1.9.0.min.js"></script>
    <script type="text/javascript" src="Javascript/Common/Fn.js"></script>
    <script type="text/javascript" src="Javascript/Rsa/st.js"></script>
    <script type="text/javascript" src="Javascript/Rsa/jQuery.md5.js"></script>
    <script type="text/javascript" src="Javascript/Rsa/BigInt.js"></script>
    <script type="text/javascript" src="Javascript/Rsa/RSA.js"></script>
    <script type="text/javascript" src="Javascript/Rsa/Barrett.js"></script>
</head>
<body>
    <div class="hytitle">
        <img src="images/title.png" />
    </div>
    <div class="middle_bgjddw"></div>
    <div class="middle_bg">
        <div class="dlkk">
            <div class="srkdl">
                <ul>
                    <li class="user">
                        <input type="text" id="txtUserName" onfocus="if(this.value=='请输入用户名'){this.value='';}"
                            onkeydown="onKeyDown(event)" maxlength="12" value="请输入用户名" runat="server" />
                    </li>
                    <li class="password">
                        <input type="password" id="txtPwd" onfocus="if(this.value=='请输入密码'){this.value='';}"
                            onkeydown="onKeyDown(event)" maxlength="12" />
                    </li>
                </ul>
                <p><a class="retrieval" href="#">找回密码</a></p>
                <div>
                    <a href="#" class="yhdl" title="登录" id="imgSubmit" clickflag="ok" onclick="SubMit();">登 录</a>
                    <a href="#" class="gcbj" title="工程报建" id="btnQuickReg">工程报建</a>
                    <br />
                    <div id="sploadMsg"></div>
                </div>
            </div>
        </div>
    </div>
    <input type="hidden" id="hidOpenFlag" />
    <div class="bqsy">主办单位：市城建档案馆&nbsp;&nbsp;&nbsp;&nbsp;版权所有：深圳市世纪伟图科技开发有限公司</div>
    <link rel="stylesheet" href="/Javascript/Layer/skin/qingxin/skin.css" id="layout-skin" type="text/css" />
    <script type="text/javascript" src="/Javascript/Layer/layer/layer.js"></script>
    <script type="text/javascript">
        function onKeyDown(el) {//回车提交
            var e = el || window.event;
            var keyCode = e.which || e.keyCode;
            if (keyCode == 13) {
                SubMit();
            }
        }
        function SubMit() {
            var $username = $("#txtUserName");
            var $password = $("#txtPwd");
            var $msg = $("#sploadMsg");
            var $objSubmit = $("#imgSubmit");
            if ($username.val() == '' || $username.val() == "请输入用户名") {
                $msg.text("登录账号不能为空!");
                $username.focus();
                return false;
            }
            else if ($password.val() == '') {
                $msg.text("登录密码不能为空!");
                $password.focus();
                return false;
            } else {
                if ($objSubmit.attr("clickflag") == 'ok') {
                    $objSubmit.attr("clickflag", "no");
                    setMaxDigits(129);
                    var key = new RSAKeyPair("<%=strPublicKeyExponent%>", "", "<%=strPublicKeyModulus%>");
                    var pwdMD5 = $password.attr("value");
                    var pwdRtn = encryptedString(key, pwdMD5);
                    $password.val(pwdRtn.length > 40 ? pwdRtn.substring(0, 38) : pwdRtn);
                    $.ajax({
                        url: "RequestHandler.ashx",
                        data: { "FileType": "login", username: $.trim($username.val()), password: pwdRtn, rn: Math.random() },
                        type: "post",
                        dataType: "text",
                        success: function (data) {
                            if (data == "success") {
                                $msg.text("登录成功，正在跳转...");
                                window.setTimeout(function () {
                                    window.location.replace('Main.aspx?rn=' + Math.random());
                                }, 500);
                            } else {
                                $msg.html(data);
                                $objSubmit.attr("clickflag", "ok");
                            }
                        }
                    });
                } else {
                    $msg.text("程序正在处理中,请稍后...");
                    return false;
                }
            }
    }
    window.onload = function () {
        if (!$.support.leadingWhitespace) {
            layer.msg(Common.getRedStrongString("温馨提示:本系统优先支持IE11"), { icon: 5, time: 10000 });
        }
    }
    $("#btnQuickReg").click(function () {
        var width = "890px", height = "";
        if (screen.height >= 900)
            height = "700px";
        else
            height = "100%";

        Common.fnLayerOpen('在线业务指导系统-报建登记', width, height, 'QuickReg.aspx', false, '');
    });
    $(".retrieval").click(function () {
        Common.fnLayerOpen('在线业务指导系统-找回密码', "460px", "280px", 'FindPassword.aspx?rn=' + Math.random(), false, '');
    });

    //处理键盘事件   
    function doKey(e) {
        var ev = e || window.event; //获取event对象   
        var obj = ev.target || ev.srcElement; //获取事件源   
        var t = obj.type || obj.getAttribute('type'); //获取事件源类型   
        if (ev.keyCode == 8 && t != "password" && t != "text" && t != "textarea") {
            return false;
        }
    }
    //禁止后退键 作用于Firefox、Opera   
    document.onkeypress = doKey;
    //禁止后退键  作用于IE、Chrome   
    document.onkeydown = doKey;
    </script>
</body>
</html>
