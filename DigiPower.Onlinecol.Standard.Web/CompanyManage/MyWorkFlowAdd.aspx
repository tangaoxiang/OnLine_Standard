<%@ Page Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="MyWorkFlowAdd.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.MyWorkFlowAdd" Title="流程管理" %>

<%@ Register Src="../CommonCtrl/ctrlDropDownCompanyInfo.ascx" TagName="ctrlDropDownCompanyInfo"
    TagPrefix="uc1" %>
<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc2" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownUser.ascx" TagName="ctrlDropDownUser"
    TagPrefix="uc3" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownWorkFlow.ascx" TagName="ctrlDropDownWorkFlow"
    TagPrefix="uc4" %>
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
                                上级：</label>
                        </td>
                        <td style="background-color: #FFFFFF" align="left">
                            <%--<asp:dropdownlist runat="server" ID="PID" 
                                                                        onselectedindexchanged="PID_SelectedIndexChanged"></asp:dropdownlist>
                                                                    --%>
                            <uc4:ctrlDropDownWorkFlow ID="PID" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <label>
                                流程名称：</label>
                        </td>
                        <td style="background-color: #FFFFFF" align="left">
                            <uc4:ctrlDropDownWorkFlow ID="PID0" runat="server" />
                        </td>
                    </tr>
                    <%-- <tr>
                                                                <td class="tdCSS"><label>序号：</label></td>
                                                                <td><asp:TextBox runat="server" ID="OrderIndex"></asp:TextBox></td>
                                                            </tr>
                                                             <tr>
                                                                <td class="tdCSS">指<label>定角色：</label></td>
                                                                <td><asp:dropdownlist runat="server" ID="RoleID"></asp:dropdownlist></td>
                                                            </tr>--%>
                </table>
            </td>
        </tr>
        <tr>
            <td height="35" align="center" valign="middle" style="background-color: White; text-align: center;">
                <asp:Button ID="btnSave" runat="server" Text=" 保存 " class="SelectButton" OnClick="btnSave_Click"
                    Width="52px" />
            </td>
        </tr>
    </table>
</asp:Content>
