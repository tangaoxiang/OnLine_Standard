<%@ Page Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="ReadCheckBook.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.WorkFlow.ReadCheckBook" Title="发放预验收认可证" %>

<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../CSS/select_file_20140529.css" media="screen" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .promiseLabelExt {
            width: 30%;
        }

        .promiseInputWidthExt {
            width: 380px;
        }
        table {
            background-color: #c9c7c0;
            margin-top: 3px;
        }  
        tr {
            background-color: #fff;
        }
    </style>
    <script language="javascript" type="text/javascript" src="../JS/WebCalendar.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table id="Table1" runat="server" width="99%" border="0" align="center" cellpadding="3" cellspacing="1">
        <tr>
            <td class="left_title_3 promise" colspan="4">阜阳市建设工程档案验收申请书
            </td>
        </tr>
        <tr>
            <td class="left_title_1 promiseLabelExt">
                <label>
                    工程名称：</label>
            </td>
            <td class="left_title_2">
                <uc1:ctrlTextBoxEx ID="gcmc" runat="server" CssClass="regedit_input promiseInputWidthExt "
                    enabled="false" />
            </td>
        </tr>
        <tr>
            <td class="left_title_1 promiseLabelExt">
                <label>
                    工程地点：</label>
            </td>
            <td class="left_title_2">
                <uc1:ctrlTextBoxEx ID="gcdd" runat="server" CssClass="regedit_input promiseInputWidthExt "
                    enabled="false" />
            </td>
        </tr>
        <tr>
            <td class="left_title_1 promiseLabelExt">
                <label>
                    质量监督单位：</label>
            </td>
            <td class="left_title_2">
                <uc1:ctrlTextBoxEx ID="zljddw" runat="server" canEmpty="true" CssClass="regedit_input promiseInputWidthExt "
                    MaxLength="50" />
            </td>
        </tr>
        <tr>
            <td class="left_title_1 promiseLabelExt">发放状态：</td>
            <td class="left_title_2">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red"
                    Text="未发"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="left_title_1 promiseLabelExt">
                <label>
                    证件编号：</label>
            </td>
            <td class="left_title_2">
                <uc1:ctrlTextBoxEx ID="ReadyCheckBookCode" runat="server" CssClass="regedit_input promiseInputWidthExt " />
                阜阳档验()号</td>
        </tr>
        <tr>
            <td class="left_title_1 promiseLabelExt">
                <label>
                    建设单位负责人：</label>
            </td>
            <td class="left_title_2">
                <uc1:ctrlTextBoxEx ID="jsdwfzr_Name" runat="server" canEmpty="true" CssClass="regedit_input promiseInputWidthExt " MaxLength="20" />
            </td>
        </tr>
        <tr>
            <td class="left_title_1 promiseLabelExt">
                <label>
                    联系电话：</label>
            </td>
            <td class="left_title_2">
                <uc1:ctrlTextBoxEx ID="jsdwfzr_Tel" runat="server" canEmpty="true" CssClass="regedit_input promiseInputWidthExt " MaxLength="20" />
                建设单位负责人电话
            </td>
        </tr>
        <tr>
            <td class="left_title_1 promiseLabelExt">
                <label>  
                    档案联系人：</label>
            </td>
            <td class="left_title_2">
                <uc1:ctrlTextBoxEx ID="ArchiveUserName" runat="server" canEmpty="true" CssClass="regedit_input promiseInputWidthExt " MaxLength="20" />
            </td>
        </tr>
        <tr>
            <td class="left_title_1 promiseLabelExt">
                <label>
                    联系电话：</label>
            </td>
            <td class="left_title_2">
                <uc1:ctrlTextBoxEx ID="ArchiveUser_Tel" runat="server" canEmpty="true" CssClass="regedit_input promiseInputWidthExt " MaxLength="20" />
                档案联系人电话
            </td>
        </tr>

        <tr>
            <td class="left_title_1 promiseLabelExt">
                <label>
                    发放时间：</label>
            </td>
            <td class="left_title_2">
                <uc1:ctrlTextBoxEx ID="BeginDate" runat="server" mode="Date" CssClass="regedit_input promiseInputWidthExt " />
            </td>
        </tr>
    </table>

    <table id="table2" runat="server" width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td class="left_title_4">
                <asp:Button ID="btnSave000001" runat="server" Text=" 保存 " class="SelectButton" OnClick="btnSave_Click"
                    Width="52px" />
            </td>
        </tr>
    </table>

    <asp:HiddenField ID="HidCodeType" runat="server" />
    <asp:HiddenField ID="HidSingleProjectID" runat="server" />
</asp:Content>
