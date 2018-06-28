<%@ Page Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="ArchiveCellReportAdd.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.ArchiveCellReportAdd" Title="华表模板管理" %>

<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc3" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownFileListTmp.ascx" TagName="ctrlDropDownFileListTmp"
    TagPrefix="uc4" %>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .tdCSS
        {
            background-color: #FFFFFF;
            width: 35%;
            text-align: left;
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
                        <td class="tdCSS">
                            <label>
                               文件名称：</label>
                        </td>
                        <td style="background-color: #FFFFFF" align="left">
                            <uc4:ctrlDropDownFileListTmp ID="recid" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdCSS">
                            施工用表名称：
                        </td>
                       <td style="background-color: #FFFFFF" align="left">
                            <uc3:ctrlTextBoxEx ID="title" runat="server" canEmpty="false" CssClass="input" MaxLength="200" width="240" />
                        </td>
                    </tr>
                    <%--<tr>
                                                                <td class="tdCSS"><label>已上传文件路径：</label></td>
                                                                <td>
                                                                    <uc3:ctrlTextBoxEx ID="CellFilePath" canEmpty="true"  CssClass="input" MaxLength="250" width="200" runat="server" />
                                                                    
                                                                </td>
                                                            </tr>
                                                       <tr>
                                                                <td class="tdCSS"><label></label></td>
                                                                <td>
                                                                    <asp:FileUpload ID="Upfile"  Width="200px" runat="server" />
                                       
                                                                </td>
                                                            </tr>--%>
                    <tr>
                        <td class="tdCSS">
                            <label>
                                顺序号：</label>
                        </td>
                        <td style="background-color: #FFFFFF" align="left">
                            <uc3:ctrlTextBoxEx ID="OrderIndex" canEmpty="false" CssClass="input" MaxLength="30"
                                mode="Int" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="35" align="center" valign="middle" style="background-color: #FFFFFF; text-align:center;">
                <asp:Button ID="btnSave" runat="server" Text=" 保存 " Width="52px" class="SelectButton"
                    OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
