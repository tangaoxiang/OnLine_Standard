﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlCompanyRegBaseInfo3_2.ascx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlCompanyRegBaseInfo3_2" %>

<%@ Register Src="ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc3" %>
<%@ Register Src="~/CommonCtrl/ctrlDropDownArea.ascx" TagName="ctrlDropDownArea"
    TagPrefix="uc4" %>
<%@ Register Src="ctrlDropDownSystemInfo.ascx" TagName="ctrlDropDownSystemInfo" TagPrefix="uc3" %>
<asp:HiddenField ID="HSingleProjectID" runat="server" />
<table id="tablemain" runat="server" class="zpxxxj" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td colspan="4" style="height: 10px"><strong>工程信息</strong>
            <asp:HiddenField ID="userid" runat="server" />
            <asp:HiddenField ID="companyid" runat="server" />
            <asp:HiddenField ID="constructionprojectid" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="ww">工程名称：</td>
        <td>
            <uc3:ctrlTextBoxEx ID="gcmc" labelTitle="工程名称" canEmpty="false" MaxLength="100"
                runat="server" CssClass="dd" />
        </td>
        <td class="ww">工程编号：</td>
        <td>
            <asp:TextBox ID="gcbm" runat="server" ReadOnly="true" CssClass="dd">自动生成</asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="ww">工程地点：</td>
        <td colspan="3">
            <uc3:ctrlDropDownSystemInfo ID="gcqy" CurrentType="SingleProjectCode" runat="server" Width="150" />
            <uc3:ctrlTextBoxEx ID="gcdd" CssClass="cd" canEmpty="false"
                width="485px" MaxLength="120" runat="server" labelTitle="工程地点" />
        </td>
    </tr>
    <tr>
        <td class="ww">开工时间：</td>
        <td>
            <uc3:ctrlTextBoxEx ID="kgsj" CssClass="dd" MaxLength="10" canEmpty="false" labelTitle="开工时间"
                mode="Date" runat="server" ShowLblDate="false" />
        </td>
        <td class="ww">竣工时间：</td>
        <td>
            <uc3:ctrlTextBoxEx ID="jgsj" CssClass="dd" MaxLength="10" canEmpty="false" runat="server"
                mode="Date" labelTitle="竣工时间" ShowLblDate="false" />
        </td>
    </tr>

    <tr>
        <td colspan="4" style="height: 10px">
            <strong>责任者项</strong>
        </td>
    </tr>
    <tr>
        <td class="ww">建设单位：</td>
        <td>
            <uc3:ctrlTextBoxEx ID="jsdw" CssClass="dd" MaxLength="100" canEmpty="false"
                labelTitle="建设单位" runat="server" />
        </td>
        <td class="ww">立项批准单位：</td>
        <td>
            <uc3:ctrlTextBoxEx ID="lxpzdw" CssClass="dd" labelTitle="立项批准单位"
                canEmpty="false" MaxLength="100" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="ww">设计单位：</td>
        <td>
            <uc3:ctrlTextBoxEx ID="sjdw" CssClass="dd" labelTitle="设计单位" canEmpty="false"
                MaxLength="100" runat="server" />
        </td>
        <td class="ww">勘察单位：</td>
        <td>
            <uc3:ctrlTextBoxEx ID="kcdw" CssClass="dd" labelTitle="勘察单位" canEmpty="false"
                MaxLength="100" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="ww">施工单位：</td>
        <td>
            <uc3:ctrlTextBoxEx ID="sgdw" CssClass="dd" labelTitle="施工单位" canEmpty="false"
                MaxLength="100" runat="server" />
        </td>
        <td class="ww">监理单位：</td>
        <td>
            <uc3:ctrlTextBoxEx ID="jldw" CssClass="dd" canEmpty="false" labelTitle="监理单位"
                MaxLength="100" runat="server" />
        </td>
    </tr>
    <tr>
        <td colspan="4" style="height: 10px">
            <strong>文号项</strong>
        </td>
    </tr>
    <tr>
        <td class="ww">规划许可证号：</td>
        <td>
            <uc3:ctrlTextBoxEx ID="ghxkzh" CssClass="dd" labelTitle="规划许可证号"
                canEmpty="false" MaxLength="80" runat="server" />
        </td>
        <td class="ww">施工许可证号：</td>
        <td>
            <uc3:ctrlTextBoxEx ID="sgxkzh" CssClass="dd" labelTitle="施工许可证号"
                MaxLength="80" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="ww">验收备案号：</td>
        <td>
            <uc3:ctrlTextBoxEx ID="ysbah" CssClass="dd" labelTitle="验收备案号"
                MaxLength="80" runat="server" />
        </td>
    </tr>
</table>

<asp:Literal runat="server" ID="ltPointHtml"></asp:Literal>
<asp:Literal runat="server" ID="ltImage"></asp:Literal>
