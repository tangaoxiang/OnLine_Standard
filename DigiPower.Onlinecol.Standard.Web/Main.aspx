<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="DigiPower.Onlinecol.Standard.Web.Main" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache, must-revalidate" />
    <meta http-equiv="expires" content="0" />
    <%--作用是 让一些html5标签能被ie8-等版本解析 如header aside section--%>
    <script type="text/javascript" src="/Javascript/Common/custom.modernizr.js"></script>
    <title></title>
    <%= Link%>
    <script type="text/javascript">
        function ParentOpenDiv(title, url, width, height) {
            layer.open({
                type: 2,
                title: title,
                maxmin: false,
                resize: false,
                shadeClose: false,
                area: ['' + width + '', '' + height + ''],
                content: url
            });
        }
        function logout() {
            layer.confirm('确定要退出系统?', function () {
                $.ajax({
                    type: 'get',
                    dataType: 'text',
                    url: 'RequestHandler.ashx',
                    data: { FileType: 'logOut', rd: Math.random() },
                    success: function (msg) {
                        if (msg == "success") {
                            location.replace("UserLoginGather.aspx?rn=" + Math.random());
                        }
                    },
                    complete: function (text) {
                    }
                });
            });
        }
        function closeMenu() { //左侧菜单关闭     
            $(".layout-side").addClass("close");
            $(".layout-main").addClass("full-page");
            $(".layout-footer").addClass("full-page");
            $(".layout-side-arrow").addClass("close");
            $(".layout-side-arrow-icon").addClass("close");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="layout-admin">
            <header class="layout-header">
                <span class="header-logo" style="font-size: 24px;">
                    <img src="Javascript/Layer/image/gslogo.png" style="margin-bottom: 6px;" />
                    <asp:Literal runat="server" ID="ltAppTitle"></asp:Literal>
                </span>
                <a class="header-menu-btn" href="javascript:;"><i class="icon-font">&#xe600;</i></a>
                <ul class="header-bar">
                    <li class="header-bar-role"><a href="javascript:;">用户:(<asp:Literal runat="server" ID="ltUserName"></asp:Literal>)</a></li>
                    <li class="header-bar-role"><a href="javascript:;">角色:(<asp:Literal runat="server" ID="ltRoleName"></asp:Literal>)</a></li>
                    <li class="header-bar-role"><a href="javascript:;">单位信息:<asp:Literal runat="server" ID="ltCompanyName"></asp:Literal></a></li>
                    <li class="header-bar-role"><a href="javascript:;" onclick="logout()" title="退出系统">安全退出</a></li>
                    <li class="header-bar-nav">
                        <a href="javascript:;" title="换肤"><i class="icon-font">&#xe608;</i></a>
                        <ul class="header-dropdown-menu right dropdown-skin">
                            <li><a href="javascript:;" data-val="qingxin" title="清新">清新</a></li>
                            <li><a href="javascript:;" data-val="blue" title="蓝色">蓝色</a></li>
                            <li><a href="javascript:;" data-val="molv" title="墨绿">墨绿</a></li>
                        </ul>
                    </li>
                </ul>
            </header>
            <aside class="layout-side">
                <ul class="side-menu">
                </ul>
            </aside>
            <div class="layout-side-arrow">
                <div class="layout-side-arrow-icon"><i class="icon-font">&#xe60d;</i></div>
            </div>
            <section class="layout-main">
                <div class="layout-main-tab">
                    <button class="tab-btn btn-left" onclick="return false;"><i class="icon-font">&#xe60e;</i></button>
                    <nav class="tab-nav">
                        <div class="tab-nav-content">
                            <a href="javascript:;" class="content-tab active" data-id="home.html">我的任务</a>
                        </div>
                    </nav>
                    <button class="tab-btn btn-right" onclick="return false;"><i class="icon-font">&#xe60f;</i></button>
                </div>
                <div class="layout-main-body">
                    <iframe class="body-iframe" id="home.html" name="iframe0" width="100%" height="99%" src="DefaultMyTaskList.aspx"
                        frameborder="0" data-id="home.html" seamless></iframe>
                </div>
            </section>
            <div class="layout-footer">深圳市世纪伟图科技开发有限公司&nbsp;&nbsp;版权所有&nbsp;&nbsp;版本:V01 最佳分辨率:1440*900&nbsp;&nbsp;</div>
        </div>
    </form>
    <script type="text/javascript" src="/Javascript/Layer/lib/jquery-1.9.0.min.js"></script>
    <script type="text/javascript" src="/Javascript/Layer/js/sccl.js"></script>
    <script type="text/javascript" src="/Javascript/Layer/js/sccl-util.js"></script>
    <script type="text/javascript" src="/Javascript/Layer/layer/layer.js"></script>
</body>
</html>
