<%@ Page Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="ArchiveToUser.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.ArchiveToUser" Title="归档目录分配 " %>

<%--<%@ Register Src="../CommonCtrl/ctrlSiteMap.ascx" TagName="ctrlSiteMap" TagPrefix="uc1" %>--%>
<%@ Register Src="../CommonCtrl/ctrlGridEx.ascx" TagName="ctrlGridEx" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="99%" border="0" cellpadding="0" cellspacing="0" style="margin: 4px 4px;
        border: solid 1px #8db2e3;">
        <tr>
            <td height="25" class="button_area" style="border: 0px; border-bottom: 1px;">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="margin-top: 2px;">
                    <tr>
                        <td width="10px">
                            &nbsp;&nbsp;&nbsp;
                        </td>
                        <td>
                        </td>
                        <td>
                            <div align="right">
                                &nbsp;
                                <asp:Button ID="btnUpdate" runat="server" OnClick="lbtnUpdate_Click" CssClass="button"
                                    Text=" 归档目录用户划分 " />
                            </div>
                        </td>
                        <td width="30" align="right">
                            <img src="../Images/01.png" border="0" style="margin-right: 4px;" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <div style="margin-top: 4px; margin-bottom: 4px; border: 0; width: 100%;">
                    <uc3:ctrlGridEx ID="GridProject" runat="server" />
                </div>
            </td>
        </tr>
    </table>
    <iframe id="ibUser" name="ibuser" frameborder="0" src="" visible="true" scrolling="auto"
        width="100%" height="550px" runat="server"></iframe>
</asp:Content>
