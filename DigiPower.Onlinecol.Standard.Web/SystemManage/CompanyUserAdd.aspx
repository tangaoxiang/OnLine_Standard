﻿<%@ Page Language="C#" MasterPageFile="~/SiteSon.Master" AutoEventWireup="true" CodeBehind="CompanyUserAdd.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.CompanyUserAdd" Title="非档案馆用户管理" %>

<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc2" %>
<asp:Content ID="Content3" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Main" runat="server">
    <table id="tbl" runat="server" class="xzll" cellpadding="0" border="0">
        <tr>
            <td colspan="2" style="height: 25px;"></td>
        </tr>
        <tr>
            <td class="mc">单位名称：
            </td>
            <td class="sr">
                <uc2:ctrlTextBoxEx ID="txtCompanyName" readOnly="true" runat="server" MaxLength="50" CssClass="sour" />
                <asp:HiddenField runat="server" ID="CompanyID" />
            </td>
        </tr>
        <tr>
            <td class="mc">所属角色：
            </td>
            <td class="sr">
                <uc2:ctrlTextBoxEx ID="txtRoleName" readOnly="true" runat="server" MaxLength="10" CssClass="sour" />
                <asp:HiddenField runat="server" ID="RoleID" />
            </td>
        </tr>
        <tr>
            <td class="mc">登录账号：
            </td>
            <td class="sr">
                <uc2:ctrlTextBoxEx ID="LoginName" labelTitle="登录账号" canEmpty="false" runat="server" MaxLength="12" CssClass="sour" />
            </td>
        </tr>
        <tr>
            <td class="mc">登录密码：
            </td>
            <td class="sr">
                <uc2:ctrlTextBoxEx ID="Passwd" TextMode="Password" canEmpty="false"
                    labelTitle="登录密码" runat="server" MaxLength="12" CssClass="sour" />
            </td>
        </tr>
        <tr>
            <td class="mc">用户名称：
            </td>
            <td class="sr">
                <uc2:ctrlTextBoxEx ID="UserName" labelTitle="用户名称" mode="Chinese" 
                    canEmpty="false" runat="server" MaxLength="6" CssClass="sour" />
            </td>
        </tr>
        <tr>
            <td class="mc">个人电话：
            </td>
            <td class="sr">
                <uc2:ctrlTextBoxEx ID="Tel" labelTitle="个人电话" CssClass="sour" runat="server" MaxLength="20" />
            </td>
        </tr>
        <tr>
            <td class="mc">个人手机：
            </td>
            <td class="sr">
                <uc2:ctrlTextBoxEx ID="Mobile" labelTitle="个人手机" CssClass="sour" MaxLength="11" mode="Int" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="mc">是否有效：
            </td>
            <td class="sr dxan">
                <asp:CheckBox runat="server" ID="IsValid" Checked="True"></asp:CheckBox>
            </td>
        </tr>

        <tr>
            <td class="mc">创建时间：
            </td>
            <td class="sr ">
                <uc2:ctrlTextBoxEx ID="Createdate" readOnly="true" CssClass="sour" MaxLength="10" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="mc">创建人：
            </td>
            <td class="sr">
                <uc2:ctrlTextBoxEx ID="Createdby" readOnly="true" CssClass="sour" MaxLength="10" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="ljzc" style="height: 55px;">
                <asp:Button ID="btnSave" runat="server" Text="  保存  "
                    OnClientClick="return saveSubmit(this);" clickflag="ok" class="btn2" OnClick="btnSave_Click" />
                <input type="button" id="btngoBack" value=" 返回 " onclick="Common.fnParentLayerClose()" />
            </td>
        </tr>
    </table>
    <script language="javascript" type="text/javascript">
        function saveSubmit(obj) {
            var LoginNameValue = $("#<%= LoginName.ClientID%>").val();
            if (!Common.Validate('<%= LoginName.ClientID%>')) return false;
            if (CompanyUserAdd.CheckLoginName('<%= Action%>', Number(<%= ID%>), LoginNameValue).value) {
                Common.FinishExe($("#<%= LoginName.ClientID%>"), true, "(" + LoginNameValue + ")已存在,请重新录入!");
                return false;
            } else {
                Common.FinishExe($("#<%= LoginName.ClientID%>"), false, null);
            }

            if (LoginNameValue.length < 6 || LoginNameValue.length > 12) {
                Common.FinishExe($("#<%= LoginName.ClientID%>"), true, "长度必须介于6-12之间!");
                return false;
            } else {
                Common.FinishExe($("#<%= LoginName.ClientID%>"), false, null);
            }

            if (!Common.Validate('<%= Passwd.ClientID%>')) return false;
            var PasswdValue = $("#<%= Passwd.ClientID%>").val();
            if (PasswdValue.length < 6 || PasswdValue.length > 12) {
                Common.FinishExe($("#<%= Passwd.ClientID%>"), true, "长度必须介于6-12之间!");
                return false;
            } else {
                Common.FinishExe($("#<%= Passwd.ClientID%>"), false, null);
            }

            if (!CompanyUserAdd.CheckPassword(PasswdValue).value) {
                Common.FinishExe($("#<%= Passwd.ClientID%>"), true, "必须是数字和字母的组合!");
                return false;
            } else {
                Common.FinishExe($("#<%= Passwd.ClientID%>"), false, null);
            }

            if (!Common.Validate('<%= UserName.ClientID%>')) return false;
            if (!Common.Validate('<%= Mobile.ClientID%>')) return false;

            return Common.mouseClick(obj)
        }
    </script>
</asp:Content>
