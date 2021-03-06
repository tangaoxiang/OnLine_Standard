﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlCompanyQucikReg.ascx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlCompanyQucikReg" %>
<%@ Register Src="ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc2" %>
<%@ Register Src="ctrlDropDownArea.ascx" TagName="ctrlDropDownArea" TagPrefix="uc3" %>
<%@ Register Src="ctrlArchiveFormType.ascx" TagName="ctrlArchiveFormType" TagPrefix="uc4" %>
<asp:Panel ID="Panel1" runat="server">
    <table id="table_Company" runat="server" class="zpxxxj" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="ww">单位名称：</td>
            <td>
                <uc2:ctrlTextBoxEx ID="CompanyName" CssClass="dd" runat="server" canEmpty="false" />
            </td>
            <td class="ww">所属机构：
            </td>
            <td>
                <uc3:ctrlDropDownArea ID="CTRL_AREA" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="ww">单位地址：
            </td>
            <td colspan="3">
                <uc2:ctrlTextBoxEx ID="Addres" CssClass="dd" runat="server" canEmpty="false" />
            </td>
        </tr>
        <tr>
            <td class="ww">联系人：
            </td>
            <td>
                <uc2:ctrlTextBoxEx ID="ContactPerson" CssClass="dd" runat="server" canEmpty="false" />
            </td>
            <td class="ww">Email：
            </td>
            <td>
                <uc2:ctrlTextBoxEx ID="EMail" CssClass="dd" runat="server" canEmpty="false" mode="Email" />
            </td>
        </tr>
        <tr>
            <td class="ww">手机：
            </td>
            <td>
                <uc2:ctrlTextBoxEx ID="Mobile" CssClass="dd" runat="server" canEmpty="false" />
            </td>
            <td class="ww">电话：
            </td>
            <td>
                <uc2:ctrlTextBoxEx ID="Tel" CssClass="dd" runat="server" canEmpty="false" />
            </td>
        </tr>
    </table>
    <br />
    <table id="tablemain" runat="server" class="zpxxxj" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="ww">工程类别：
            </td>
            <td colspan="3">
                <uc4:ctrlArchiveFormType ID="ProjectType" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="ww">工程名称：
            </td>
            <td colspan="3">
                <uc2:ctrlTextBoxEx ID="gcmc" CssClass="dd" runat="server" canEmpty="false" />
            </td>
        </tr>
        <tr>
            <td class="ww">工程地点：
            </td>
            <td colspan="3">
                <uc2:ctrlTextBoxEx ID="gcdd" ShowLblDate="false"
                    CssClass="dd" runat="server" canEmpty="false" />
            </td>
        </tr>
        <tr>
            <td class="ww">开工时间：
            </td>
            <td>
                <uc2:ctrlTextBoxEx ID="kgsj" ShowLblDate="false"
                    CssClass="dd" runat="server" canEmpty="false" />
            </td>
            <td class="ww">竣工时间：
            </td>
            <td>
                <uc2:ctrlTextBoxEx ID="jgsj" CssClass="dd" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="ww">工程规划许可证号：
            </td>
            <td>
                <uc2:ctrlTextBoxEx ID="ghxkzh" CssClass="dd" runat="server" canEmpty="true" />
            </td>
            <td class="ww">施工许可证号：
            </td>
            <td>
                <uc2:ctrlTextBoxEx ID="sgxkzh" CssClass="dd" runat="server" canEmpty="true" />
            </td>
        </tr>
    </table>
</asp:Panel>

<table id="table1" runat="server" class="zpxxxj" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td class="ww">规划许可证附件：
        </td>
        <td colspan="3" style="word-break: break-all;">
            <asp:Literal runat="server" ID="ltghxkz" Text="&nbsp;&nbsp;无"></asp:Literal>
        </td>
    </tr>
    <tr>
        <td class="ww">施工许可证附件：
        </td>
        <td colspan="3" style="word-break: break-all;">
            <asp:Literal runat="server" ID="ltsgxkz" Text="&nbsp;&nbsp;无"></asp:Literal>
        </td>
    </tr>
    <tr style="display: none">
        <td class="ww">其它证件附件：
        </td>
        <td colspan="3" style="word-break: break-all;">
            <asp:Literal runat="server" ID="ltother" Text="&nbsp;&nbsp;无"></asp:Literal>
        </td>
    </tr>
</table>
