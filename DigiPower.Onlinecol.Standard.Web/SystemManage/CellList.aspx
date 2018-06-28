<%@ Page Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="CellList.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.CellList" Title="施工用表管理" %>

<%@ Register Src="../CommonCtrl/ctrlGridEx.ascx" TagName="ctrlGridEx" TagPrefix="uc2" %>
<%@ Register Src="../CommonCtrl/ctrlArchiveFormType.ascx" TagName="ctrlArchiveFormType"
    TagPrefix="uc1" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownCellTmp.ascx" TagName="ctrlDropDownCellTmp"
    TagPrefix="uc3" %>
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
                                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" CssClass="button" Text=" 新增 " />
                                <asp:Button ID="btnDelete" OnClientClick="return ConfirmDelete();" runat="server"
                                    OnClick="btnDelete_Click" CssClass="button" Text=" 删除 " />
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
            <td bgcolor="#cbdcec">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="100%" class="STYLE1">
                            <asp:Panel runat="server" ID="tblSearch" Width="100%" border="0" cellspacing="0"
                                cellpadding="0">
                                <table>
                                    <tr>
                                        <td>
                                            <label>文件类别：</label>
                                            <uc3:ctrlDropDownCellTmp ID="PID" runat="server" Width="150" />
                                            <label>
                                                文件：</label><asp:TextBox runat="server" ID="title" CssClass="SelectText" Width="100"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnSearch" runat="server" Text=" 查询 " class="SelectButton" OnClick="btnSearch_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="text-align: center;">
                <div style="margin-top: 4px; margin-bottom: 4px; border: 0; width: 100%;">
                    <uc2:ctrlGridEx ID="ctrlGridEx1" runat="server" />
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
