<%@ Page Language="C#" MasterPageFile="~/SiteSon.Master" AutoEventWireup="true" CodeBehind="SmZJList.aspx.cs" Inherits="DigiPower.Onlinecol.Standard.Web.WorkFlow.SmZJList" Title="整理组卷-补录" %>

<%@ Register Src="../CommonCtrl/ctrlDropDownCompanyInfo.ascx" TagName="ctrlDropDownCompanyInfo"
    TagPrefix="uc6" %>
<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc1" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownSystemInfo.ascx" TagName="ctrlDropDownSystemInfo"
    TagPrefix="uc3" %>
<%@ Register Src="../CommonCtrl/ctrlProjectBaseInfo.ascx" TagName="ctrlProjectBaseInfo"
    TagPrefix="uc8" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="../Javascript/Common/WebCalendar.js" type="text/javascript"></script>
    <style type="text/css">
        .divTree {
            border: 1px solid #e2e2e2;
            border-radius: 2px;
            padding: 2px;
            overflow: auto;
        }

            .divTree a {
                font-size: 13px;
                color: black;
            }

        .sr select {
            border: solid 1px #dcdcdc !important;
            height: 24px !important;
            line-height: 24px !important;
            font-size: 13px !important;
        }
    </style>
    <script type="text/javascript">
        //查看工程信息
        function btnLookSingle() {
            var height = "100%";
            if (screen.height >= 900) height = "680px";
            window.top.parent.ParentOpenDiv('工程信息-预览', '../CompanyManage/CompanyReg3_' +
                Common.getFileTypeForProjectType($("#HidPrpjectType").val()) + 'Edit.aspx?action=' +
                PageState.View + '&SingleProjectID=' + $("#HidSingleProjectID").val() + '&rn=' +
                Math.random() + '&ProjectType=' + $("#HidPrpjectType").val(), '900px', height);
        }
        function ParentNode(currentNode) {
            var par = currentNode.parentElement.parentElement.parentElement.parentElement.parentElement.previousSibling;
            if (par != null) {
                if (par.getElementsByTagName('INPUT').length > 0) {
                    par.getElementsByTagName('INPUT')[0].checked = currentNode.checked;
                    ParentNode(par.getElementsByTagName('INPUT')[0])
                }
            }
        }
        function OnTreeNodeChecked(e) {
            var ev = e || window.event; //获取event对象   
            var ele = ev.target || ev.srcElement; //获取事件源   
            var typeName = ele.type || ele.getAttribute('type'); //获取事件源类型   

            if (typeName == 'checkbox') {
                ParentNode(ele);
                var childrenDivID = ele.id.replace('CheckBox', 'Nodes');
                var div = document.getElementById(childrenDivID);
                if (div == null) return;
                var checkBoxs = div.getElementsByTagName('INPUT');
                for (var i = 0; i < checkBoxs.length; i++) {
                    if (checkBoxs[i].type == 'checkbox')
                        checkBoxs[i].checked = ele.checked;
                }
            }
        }
        function getNewUrl() {
            var url = window.location.href;
            url = Common.urlreplace(url, 'PageIndex', $('#CurrentPageIndex').text());
            url = Common.urlreplace(url, 'rn', Math.random());
            return url;
        }
        //新增文件
        function btnAddFile() {
            var height = "100%";
            if (screen.height >= 900) height = "620px";

            Common.fnLayerOpen("归档目录模板", "850px", height, "../WorkFlow/SelectFileListTpl.aspx?rn=" +
                Math.random() + "&SingleProjectID=" + $("#HidSingleProjectID").val(), true, "新增文件成功!");
        }
        //返回
        function btnBack() {
            window.location.href = 'SmArchiveList.aspx?ModuleID=<%= DigiPower.Onlinecol.Standard.Common.DNTRequest.GetQueryString("ModuleID")%>&rn=' + Math.random();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <input type="hidden" id="HidSingleProjectID" value="<%= singleProjectID%>" />
    <input type="hidden" id="HidPrpjectType" value="<%=projectType%>" />
    <input type="hidden" id="hidOpenFlag" />
    <uc8:ctrlProjectBaseInfo ID="ctrlProjectBaseInfo1" runat="server" />
    <div class="main-content">
        <div class="content-box-content">
            <div class="tab-content default-tab" id="tab1">
                <div class="anl">
                    <input type="button" title="工程详细信息" onclick="btnLookSingle()" value="工程信息" />
                    <input type="button" title="新增文件" onclick="btnAddFile()" value="新增文件" />
                    <asp:Button ID="btnZJ" runat="server" ToolTip="新增案卷" Text="按所选节点组卷"
                        clickflag="ok" OnClientClick="return saveSubmit(this);" OnClick="btnZJ_Click" />
                    <asp:Button ID="btnInsertZJ" runat="server" Text="加入到指定案卷" OnClick="btnInsertZJ_Click" />
                    <input type="button" title="返回列表页面" onclick="Common.fnParentLayerCloseAndRefresh()" value="返回" />

                </div>
            </div>
        </div>
    </div>

    <div class="content-box-content" style="float: left; width: 100%">
        <div style="float: left;">
            <asp:TreeView ID="TreeView1" runat="server" ShowCheckBoxes="All" ShowLines="True" OnClick="OnTreeNodeChecked(event)" ExpandDepth="1">
            </asp:TreeView>
        </div>
        <div style="float: left; width: 400px; margin-left: 4px; margin-right: 4px;" id="divMiddle">
            <table class="xzll" cellpadding="0" border="0" style="width: 100%">
                <tr>
                    <td colspan="2" style="height: 25px; text-align: center; font-size: 15px;">
                        <strong>案卷信息</strong>
                    </td>
                </tr>
                <tr>
                    <td class="mc">案卷题名：
                    </td>
                    <td class="sr">
                        <uc1:ctrlTextBoxEx ID="ajtm" labelTitle="案卷题名" canEmpty="false" MaxLength="100" CssClas="sour"
                            width="230" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="mc">编制单位： 
                    </td>
                    <td class="sr">
                        <uc1:ctrlTextBoxEx ID="bzdw" labelTitle="编制单位" canEmpty="false" CssClas="sour"
                            MaxLength="40" width="230" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="mc">案卷厚度： 
                    </td>
                    <td class="sr">
                        <uc3:ctrlDropDownSystemInfo ID="boxType" CurrentType="boxtype" runat="server" Width="130" />
                    </td>
                </tr>
                <tr>
                    <td class="mc">立卷人： 
                    </td>
                    <td class="sr">
                        <uc1:ctrlTextBoxEx ID="lrr" runat="server" labelTitle="立卷人" canEmpty="false"
                            width="230" MaxLength="20" CssClas="sour" />
                    </td>
                </tr>
                <tr>
                    <td class="mc">编制日期： 
                    </td>
                    <td class="sr">
                        <uc1:ctrlTextBoxEx ID="lrsj" mode="Date" ShowLblDate="false" labelTitle="编制日期"
                            runat="server" width="230" canEmpty="false" CssClas="sour" />
                    </td>
                </tr>
                <tr>
                    <td class="mc">案卷类型： 
                    </td>
                    <td class="sr">
                        <uc3:ctrlDropDownSystemInfo ID="ajlx" runat="server" CurrentType="06" Width="130" />
                    </td>
                </tr>
                <%--                <tr>
                    <td class="mc">保管期限： 
                    </td>
                    <td class="sr">
                        <uc3:ctrlDropDownSystemInfo ID="bgqx" runat="server" CurrentType="05" Width="130" />
                    </td>
                </tr>
                <tr>
                    <td class="mc">密级： 
                    </td>
                    <td class="sr">
                        <uc3:ctrlDropDownSystemInfo ID="mj" runat="server" CurrentType="04" Width="130" />
                    </td>
                </tr>--%>
                <tr>
                    <td class="mc">序号：
                    </td>
                    <td class="sr">
                        <uc1:ctrlTextBoxEx ID="xh" labelTitle="序号" CssClas="sour"
                            MaxLength="4" mode="Int" canEmpty="false" runat="server" width="230" />
                    </td>
                </tr>
                <tr>
                    <td class="mc">卷内备考：
                    </td>
                    <td class="sr">
                        <uc1:ctrlTextBoxEx labelTitle="卷内备考" ID="note" width="230" height="50"
                            runat="server" MaxLength="150" CssClass="sour txtMultiLine" TextMode="MultiLine" Rows="4" />
                    </td>
                </tr>
            </table>
        </div>
        <div style="float: left;">
            <asp:TreeView ID="TreeView2" runat="server" ShowCheckBoxes="All" ShowLines="True"
                OnClick="OnTreeNodeChecked(event)" ExpandDepth="1">
            </asp:TreeView>
        </div>
    </div>

    <script src="../Javascript/Common/jquery.maskedinput.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        $(function () {
            $("input[type='text'][mode='Date']").mask("9999-99-99");
        });
        function saveSubmit(obj) {
            var flag = true;
            $("input[type='text']").each(function () {
                flag = Common.Validate($(this).attr("id"));
                if (!flag)
                    return false;
            });
            if (!flag) {
                return false;
            }
            return Common.mouseClick(obj)
        }
        function setCss() {
            var divLeft = $("#ctl00_Main_TreeView1");
            var divMiddle = $("#divMiddle");
            var divRight = $("#ctl00_Main_TreeView2");

            var height = screen.height - 130 - 250 + "px";
            var width = (document.documentElement.clientWidth - 420 - 40) / 2 + "px";

            divLeft.css("height", height);
            divMiddle.css("height", height);
            divRight.css("height", height);

            divLeft.css("width", width);
            divRight.css("width", width);
        }
        window.onresize = function () {
            setCss();
        }
        window.onload = function () {
            $("#ctl00_Main_TreeView1").addClass("divTree");
            $("#divMiddle").addClass("divTree");
            $("#ctl00_Main_TreeView2").addClass("divTree");
            setCss();
        }
    </script>
</asp:Content>
