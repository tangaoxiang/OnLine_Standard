<%@ Page Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="DefinedAdd.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.DefinedAdd" %>

<%@ Register Src="../CommonCtrl/ctrlDropDownCompanyInfo.ascx" TagName="ctrlDropDownCompanyInfo"
    TagPrefix="uc1" %>
<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc2" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownTable.ascx" TagName="ctrlDropDownTable"
    TagPrefix="uc3" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownCanDefineType.ascx" TagName="ctrlDropDownCanDefineType"
    TagPrefix="uc4" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownSplit.ascx" TagName="ctrlDropDownSplit"
    TagPrefix="uc5" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownCutLeng.ascx" TagName="ctrlDropDownCutLeng"
    TagPrefix="uc6" %>
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
    <link rel="stylesheet" type="text/css" href="../CSS/default2.css" />
    <table width="100%" border="0" cellpadding="0" cellspacing="1" align="center" style="background-color: #8db2e3">
        <tr>
            <td valign="top" style="background-color: White; height: 13px;" background="../images/blue_back3.gif">
            </td>
        </tr>
        <tr>
            <td valign="top" style="background-color: White;">
                <table id="tbl" runat="server" width="99%" border="0" align="center" cellpadding="0"
                    cellspacing="1" style="margin-top: 4px; margin-bottom: 4px; background-color: #c1d4da;">
                    <tr>
                        <td class="tdCSS">
                            <label>
                                档案组成项：</label>
                        </td>
                        <td style="background-color: White;">
                            <uc4:ctrlDropDownCanDefineType ID="CanDefineTypeID" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdCSS">
                            <label>
                                分隔符：</label>
                        </td>
                        <td style="background-color: White;">
                            <uc5:ctrlDropDownSplit ID="SplitID" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdCSS">
                            <label>
                                长度：</label>
                        </td>
                        <td style="background-color: White;">
                            <uc6:ctrlDropDownCutLeng ID="CutLength" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="35" align="center" valign="middle" style="background-color: White; text-align:center;">
                <asp:Button ID="btnSave" runat="server" Width="52" Text="  保存  " class="SelectButton" OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
