<%@ Page Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="ArchiveCellReportList.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.ArchiveCellReportList" Title="华表模板管理" %>

<%@ Register Src="../CommonCtrl/ctrlGridEx.ascx" TagName="ctrlGridEx" TagPrefix="uc2" %>
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
                            <td>
                                &nbsp;&nbsp;&nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <div align="right">
                                    &nbsp;
                                    <input type="button" id="btnAdd001" onclick="return OpenNewWin();return false;" class="button"
                                        value=" 新增 " />
                                    <asp:Button ID="btnDelete" OnClientClick="return ConfirmDelete();" runat="server"
                                        OnClick="btnDelete_Click" CssClass="button" Text=" 删除 " />
                                    <asp:Button ID="Linkbutton1" runat="server" OnClick="Linkbutton1_Click" CssClass="button"
                                        Text=" 返回 " />
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
            <td>
                <div align="center">
                    <uc2:ctrlGridEx ID="ctrlGridEx1" runat="server" />
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
