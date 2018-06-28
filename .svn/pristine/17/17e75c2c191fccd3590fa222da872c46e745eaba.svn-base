<%@ Page Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="FieldAdd.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.FieldAdd" Title="字段管理" %>

<%@ Register Src="../CommonCtrl/ctrlDropDownCompanyInfo.ascx" TagName="ctrlDropDownCompanyInfo"
    TagPrefix="uc1" %>
<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc2" %>
<%--<%@ Register Src="../CommonCtrl/ctrlDropDownTable.ascx" TagName="ctrlDropDownTable"
    TagPrefix="uc3" %>--%>
<%@ Register Src="../CommonCtrl/ctrlBtnBack.ascx" TagName="ctrlBtnBack" TagPrefix="uc4" %>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/select_file_20140529.css" media="screen" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .promiseLabelExt {
            width: 35%;
        }

        .promiseInputWidthExt {
            width: 280px;
        }
        table {
            background-color: #c9c7c0;
            margin-top: 3px;
        }  
        tr {
            background-color: #fff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="tbl" runat="server" width="99%" border="0" align="center" cellpadding="3" cellspacing="1">
        <tr>
            <td class="left_title_3 promise" colspan="4">&nbsp;
            </td>
        </tr>
        <%--<tr>
                        <td class="tdCSS">
                            <label>
                                所属表：</label>
                        </td>
                        <td style="background-color: White;">
                            <uc3:ctrlDropDownTable ID="table_name" runat="server" />
                        </td>
                    </tr>--%>
        <tr>
            <td class="left_title_1 promiseLabelExt">
                <label>
                    字段名：</label>
            </td>
            <td class="left_title_2">
                <uc2:ctrlTextBoxEx ID="column_name" runat="server" width="300" CssClass="regedit_input promiseInputWidthExt" />
            </td>
        </tr>
        <tr>
            <td class="left_title_1 promiseLabelExt">
                <label>
                    字段中文：</label>
            </td>
            <td class="left_title_2">
                <uc2:ctrlTextBoxEx ID="column_chn_name" runat="server" width="300" CssClass="regedit_input promiseInputWidthExt" />
            </td>
        </tr>
        <%--<tr>
                        <td class="tdCSS">
                            <label>
                                排序号：</label>
                        </td>
                        <td style="background-color: White;">
                            <uc2:ctrlTextBoxEx ID="column_order" runat="server" mode="int" />
                        </td>
                    </tr>--%>
    </table>
    <table id="table1" runat="server" width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td class="left_title_4">
                <asp:Button ID="btnSave" runat="server" Text="  保存  " class="btn2" OnClick="btnSave_Click" />
                &nbsp;<uc4:ctrlBtnBack ID="ctrlBtnBack1" runat="server" SetCssClass="btn2" />
            </td>
        </tr>
    </table>
</asp:Content>
