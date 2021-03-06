﻿<%@ Page Language="C#" MasterPageFile="~/SiteSon.Master" AutoEventWireup="true" CodeBehind="SystemAdd.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.SystemAdd" Title="字典维护" %>

<%@ Register Src="../CommonCtrl/ctrlDropDownCompanyInfo.ascx" TagName="ctrlDropDownCompanyInfo"
    TagPrefix="uc1" %>
<%@ Register Src="../CommonCtrl/ctrlBtnBack.ascx" TagName="ctrlBtnBack" TagPrefix="uc4" %>
<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc2" %>
<asp:Content ID="Content3" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Main" runat="server">

    <table id="tbl" runat="server" class="xzll" cellpadding="0" border="0">
        <tr>
            <td colspan="2" style="height: 5px;"></td>
        </tr>
        <tr>
            <td class="mc">当前类型代码：
            </td>
            <td class="sr">
                <uc2:ctrlTextBoxEx ID="CurrentType" runat="server" labelTitle="当前类型代码"
                    CssClass="sour" MaxLength="20" canEmpty="false" />
            </td>
        </tr>
        <tr>
            <td class="mc">当前类型中文：
            </td>
            <td class="sr">
                <uc2:ctrlTextBoxEx ID="CurrentTypeCNName" runat="server" labelTitle="当前类型中文"
                    CssClass="sour" MaxLength="20" canEmpty="false" />
            </td>
        </tr>
        <tr>
            <td class="mc">类型代码：
            </td>
            <td class="sr">
                <uc2:ctrlTextBoxEx ID="SystemInfoCode" runat="server" labelTitle="类型代码"
                    CssClass="sour" MaxLength="50" canEmpty="false" />
            </td>
        </tr>
        <tr>
            <td class="mc">显示文本：
            </td>
            <td class="sr">
                <uc2:ctrlTextBoxEx ID="SystemInfoName" runat="server" labelTitle="显示文本"
                    CssClass="sour" MaxLength="20" canEmpty="false" />
            </td>
        </tr>
        <tr>
            <td class="mc">子类型：
            </td>
            <td class="sr">
                <uc2:ctrlTextBoxEx ID="SubType" runat="server" CssClass="sour" MaxLength="30" labelTitle="子类型" />
            </td>
        </tr>
        <tr>
            <td class="mc">排序号：
            </td>
            <td class="sr">
                <uc2:ctrlTextBoxEx ID="OrderIndex" runat="server" mode="int" CssClass="sour" MaxLength="3" labelTitle="排序号" />
            </td>
        </tr>
        <tr>
            <td class="mc">上级：
            </td>
            <td class="sr">
                <uc2:ctrlTextBoxEx ID="ParentID" runat="server" CssClass="sour" mode="Int" MaxLength="3" labelTitle="上级" />
            </td>
        </tr>
        <tr>
            <td class="mc">是否显示：
            </td>
            <td class="sr dxan">
                <asp:CheckBox runat="server" ID="IsShow"></asp:CheckBox>
            </td>
        </tr>
        <tr>
            <td class="mc">Key：
            </td>
            <td class="sr">
                <uc2:ctrlTextBoxEx ID="SystemInfoID" runat="server" CssClass="sour" readOnly="true" />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="ljzc" style="height: 55px;">
                <asp:Button ID="btnSave" runat="server" Text=" 保存 " OnClick="btnSave_Click"
                    OnClientClick="return saveSubmit(this);" clickflag="ok" />
                <input type="button" id="btngoBack" value=" 返回 " onclick="Common.fnParentLayerClose()" />

            </td>
        </tr>
    </table>
    <script language="javascript" type="text/javascript">
        function saveSubmit(obj) {
            if (!Common.Validate('<%= CurrentType.ClientID%>')) return false;
            if (!Common.Validate('<%= CurrentTypeCNName.ClientID%>')) return false;
            if (!Common.Validate('<%= SystemInfoCode.ClientID%>')) return false;
            if (!Common.Validate('<%= SystemInfoName.ClientID%>')) return false;
            if (!Common.Validate('<%= OrderIndex.ClientID%>')) return false;
            if (!Common.Validate('<%= ParentID.ClientID%>')) return false;
            return Common.mouseClick(obj)
        }
    </script>
</asp:Content>
