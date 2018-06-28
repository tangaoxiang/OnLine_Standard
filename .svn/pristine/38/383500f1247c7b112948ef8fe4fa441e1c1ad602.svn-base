<%@ Page Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="MyWorkFlowList.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.MyWorkFlowList" Title="无标题页" %>

<%@ Register Src="../CommonCtrl/ctrlMyWorkFlowList.ascx" TagName="ctrlWorkFlowList"
    TagPrefix="uc1" %>
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
                                <asp:Button ID="Linkbutton1" runat="server" OnClick="Linkbutton1_Click" CssClass="button"
                                    Text=" 恢复 " />
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
            <td style="text-align: center;">
                <div style="margin-top: 4px; margin-bottom: 4px; border: 0; width: 100%;">
                    <uc1:ctrlWorkFlowList ID="ctrlMyWorkFlowList1" runat="server" />
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
