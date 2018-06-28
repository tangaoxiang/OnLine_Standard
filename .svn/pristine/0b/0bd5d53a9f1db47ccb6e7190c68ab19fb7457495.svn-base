<%@ Page Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="CompanySignetList.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.CompanySignetList" Title="单位签章管理" %>

<%@ Register Src="../CommonCtrl/ctrlGridEx.ascx" TagName="ctrlGridEx" TagPrefix="uc1" %>
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
                                支持格式：jpg,gif,bmp
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <div align="right">
                                    &nbsp;
                                    <asp:Button ID="btnAdd001" runat="server" OnClick="lbtnAdd_Click" CssClass="button"
                                        Text=" 保存 " />
                                    <asp:Button ID="btnDelete" runat="server" OnClientClick="return confirm('确定删除吗？')"
                                        OnClick="btnDelete_Click" CssClass="button" Text=" 清除签章 " />
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
                        <td width="100%" class="STYLE1" valign="middle" style="margin-top: 2px;">
                            <%--<asp:Panel runat="server" ID="tblSearch" Width="100%" border="0" cellspacing="0"
                                cellpadding="0">
                                <table>
                                    <tr>
                                        <td>
                                            <label>
                                                单位名称：</label><asp:TextBox runat="server" CssClass="SelectText" ID="CompanyName" Width="100"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnSearch" runat="server" Text=" 查询 " class="SelectButton" OnClick="btnSearch_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>--%>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="text-align: center;">
                <div style="margin-top: 4px; margin-bottom: 4px; border: 0; width: 100%;">
                    <uc1:ctrlGridEx ID="ctrlGridEx1" runat="server" />
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
