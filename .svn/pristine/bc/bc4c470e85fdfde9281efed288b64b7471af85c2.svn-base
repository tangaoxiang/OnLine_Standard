<%@ Page Language="C#" MasterPageFile="~/SiteSon.Master" AutoEventWireup="true" CodeBehind="ProjectDoInfo.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.CompanyManage.ProjectDoInfo" Title="工程动态跟踪" %>

<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link href="../Javascript/TimeAxis/css/history.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <table id="tbl" runat="server" class="zpxxxj" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td colspan="4" style="height: 10px"><strong>工程信息</strong>
            </td>
        </tr>
        <tr>
            <td class="ww">工程名称：</td>
            <td>
                <uc3:ctrlTextBoxEx ID="gcmc" runat="server" ShowLblDate="false" readOnly="true" CssClass="dd" />
            </td>
            <td class="ww">工程编号：</td>
            <td>
                <uc3:ctrlTextBoxEx ShowLblDate="false" readOnly="true" CssClass="dd" ID="gcbm" runat="server" />
            </td>
        </tr>

        <tr>
            <td class="ww">单位名称：</td>
            <td>
                <uc3:ctrlTextBoxEx ShowLblDate="false" readOnly="true" CssClass="dd" ID="companyName" runat="server" />  
            </td>
            <td class="ww">工程状态：</td>
            <td>
                <asp:Literal runat="server" ID="gczt"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="ww">开工时间：</td>
            <td>
                <uc3:ctrlTextBoxEx ShowLblDate="false" readOnly="true" CssClass="dd" ID="kgsj" runat="server" />
            </td>
            <td class="ww">竣工时间：</td>
            <td>
                <uc3:ctrlTextBoxEx ShowLblDate="false" readOnly="true" CssClass="dd" ID="jgsj" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="ww">建设单位：</td>
            <td>
                <uc3:ctrlTextBoxEx ShowLblDate="false" readOnly="true" CssClass="dd" ID="jsdw" runat="server" />
            </td>
            <td class="ww">工程地址：</td>
            <td>
                <uc3:ctrlTextBoxEx ShowLblDate="false" readOnly="true" CssClass="dd" ID="gcdd" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="ww">施工单位：</td>
            <td>
                <uc3:ctrlTextBoxEx ShowLblDate="false" readOnly="true" CssClass="dd" ID="sgdw" runat="server" />
            </td>
            <td class="ww">施工许可证：</td>
            <td>
                <uc3:ctrlTextBoxEx ShowLblDate="false" readOnly="true" CssClass="dd" ID="sgxkzh" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="ww">设计单位：</td>
            <td>
                <uc3:ctrlTextBoxEx ShowLblDate="false" readOnly="true" CssClass="dd" ID="sjdw" runat="server" />
            </td>
            <td class="ww">规划许可证：</td>
            <td>
                <uc3:ctrlTextBoxEx ShowLblDate="false" readOnly="true" CssClass="dd" ID="ghxkzh" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="ww">项目负责人：</td>
            <td>
                <uc3:ctrlTextBoxEx ShowLblDate="false" readOnly="true" CssClass="dd" ID="ChargeUserName" runat="server" />
            </td>
            <td class="ww">联系人及电话：</td>
            <td>
                <uc3:ctrlTextBoxEx ShowLblDate="false" readOnly="true" CssClass="dd" ID="ContactPerson_Tel" runat="server" />
            </td>
        </tr>
    </table>

    <div class="head-warp" style="margin: 10px 0;">
        <div class="head">
            <div class="nav-box">
                <ul>
                    <li class="cur" style="text-align: center; font-size: 30px; font-family: '微软雅黑', '宋体';">工程档案形成时间轴</li>
                </ul>
            </div>
        </div>
    </div>
    <div class="main">
        <div class="history">
            <div class="history-date">
                <ul>
                    <asp:Literal ID="ltWorkFlow" runat="server"></asp:Literal>
                </ul>
            </div>
        </div>
    </div>
    <script src="../Javascript/TimeAxis/js/main.js" type="text/javascript"></script>
</asp:Content>
