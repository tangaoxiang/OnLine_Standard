<%@ Page Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="ArchiveToUserMod.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.ArchiveManage.ArchiveToUserMod" Title="" %>

<%@ Register Src="../CommonCtrl/ctrlGridEx.ascx" TagName="ctrlGridEx" TagPrefix="uc2" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownCompanyInfo.ascx" TagName="ctrlDropDownCompanyInfo"
    TagPrefix="uc1" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownUser.ascx" TagName="ctrlDropDownUser"
    TagPrefix="uc3" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownSingleProjectUsers.ascx" TagName="ctrlDropDownSingleProjectUsers"
    TagPrefix="uc4" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownSystemInfo.ascx" TagName="ctrlDropDownSystemInfo"
    TagPrefix="uc5" %>
<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc6" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownFileList.ascx" TagName="ctrlDropDownFileList"
    TagPrefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="HidSingleProjectID" runat="server" />
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
                                <asp:Button ID="btnSave" runat="server" Text=" 保存 " class="SelectButton" OnClick="btnSave_Click" />
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
                        <td class="STYLE1">
                            <asp:Panel runat="server" ID="tblSearch" Width="100%" border="0" cellspacing="0"
                                cellpadding="0">
                                <table>
                                    <tr>
                                        <td>
                                            <label>
                                                使用单位：</label><uc5:ctrlDropDownSystemInfo ID="DefaultCompanyType" runat="server" CurrentType="Companytype" />
                                        </td>
                                        <td>
                                            <label>
                                                文件类别：</label>
                                            <uc7:ctrlDropDownFileList ID="ctrlDropDownFileList" Width="150" bShowNO="false" AutoPostBack="false"
                                                runat="server" />
                                        </td>
                                        <td>
                                            <label>
                                                文件：</label><uc6:ctrlTextBoxEx ID="ctrlTextBoxEx1" runat="server" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnSearch" runat="server" Text=" 查询 " class="SelectButton" OnClick="btnSearch_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                        <td style="text-align: right;">
                            操作人：
                            <uc4:ctrlDropDownSingleProjectUsers ID="SingleProjectUsers" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <div style="margin-top: 4px; margin-bottom: 4px; border: 0; width: 100%;">
                    <uc2:ctrlGridEx ID="ctrlGridEx1" runat="server" />
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
