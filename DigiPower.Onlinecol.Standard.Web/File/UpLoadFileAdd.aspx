<%@ Page Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="UpLoadFileAdd.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.File.UpLoadFileAdd" %>

<%@ Register Src="../CommonCtrl/ctrlBtnBack.ascx" TagName="ctrlBtnBack" TagPrefix="uc1" %>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .tdCSS
        {
            background-color: #FFFFFF;
            width: 35%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="1" align="center" style="background-color: #8db2e3">
        <tr>
            <td valign="top" style="background-color: White; height: 13px;" background="../images/blue_back3.gif">
            </td>
        </tr>
        <tr>
            <td style="background-color: White;">
                <table id="tbl" runat="server" width="99%" border="0" align="center" cellpadding="0"
                    cellspacing="1" style="margin-top: 4px; margin-bottom: 4px; background-color: #c1d4da;">
                    <tr>
                        <td class="tdCSS" align="left">
                            <label>
                                文件标题：</label>
                        </td>
                        <td style="background-color: #FFFFFF" align="left">
                            <asp:TextBox ID="Title" runat="server" CssClass="input"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdCSS">
                            <label>
                                排序编号：</label>
                        </td>
                        <td style="background-color: #FFFFFF" align="left">
                            <asp:TextBox ID="OrderIndex" runat="server" CssClass="input"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="35" align="center" valign="middle" style="text-align: center; background-color: #FFFFFF;">
                <asp:Button ID="btnSave" runat="server" Text=" 保存 " class="SelectButton" Width="52px"
                    OnClick="btnSave_Click" />
                <uc1:ctrlBtnBack ID="ctrlBtnBack1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>