﻿<%@ Page Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="TrainRecList.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.TrainRecList" Title="培训记录" %>

<%@ Register src="../CommonCtrl/ctrlGridEx.ascx" tagname="ctrlGridEx" tagprefix="uc1" %>

<%@ Register src="../CommonCtrl/ctrlDropDownUser.ascx" tagname="ctrlDropDownUser" tagprefix="uc2" %>

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
                                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" CssClass="button" Text=" 更改培训结果 " />
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
                                            <label>
                                                档案员：</label>
                                               <uc2:ctrlDropDownUser ID="UserID" runat="server" /> 
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
                    <uc1:ctrlGridEx ID="ctrlGridEx1" runat="server" />
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
