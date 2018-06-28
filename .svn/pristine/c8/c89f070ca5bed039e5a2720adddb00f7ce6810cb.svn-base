<%@ Page Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="CellListAdd.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.CellListAdd" Title="施工用表管理" %>

<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc3" %>
<%@ Register Src="../CommonCtrl/ctrlBtnBack.ascx" TagName="ctrlBtnBack" TagPrefix="uc1" %>
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
                       <td class="left_title_1 promiseLabelExt">
                            <label>
                                归档目录类别：</label>
                        </td>
                      <td class="left_title_2">
                            <uc1:ctrlArchiveFormType ID="archive_form_no" runat="server" />
                        </td>
                    </tr>--%>
        <tr>
            <td class="left_title_1 promiseLabelExt">
                <label>
                    父级：</label>
            </td>
            <td class="left_title_2">
                <asp:DropDownList ID="PID" runat="server" AutoPostBack="True"
                    OnSelectedIndexChanged="PID_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Label ID="PID_Show" runat="server" Text=""></asp:Label><br />
            </td>
        </tr>
        <tr>
            <td class="left_title_1 promiseLabelExt">
                <label>
                    编号：</label>
            </td>
            <td class="left_title_2">
                <uc3:ctrlTextBoxEx ID="MyCode" runat="server" canEmpty="false" CssClass="regedit_input promiseInputWidthExt" MaxLength="20" />
            </td>
        </tr>
        <tr>
            <td class="left_title_1 promiseLabelExt">
                <label>
                    名称：</label>
            </td>
            <td class="left_title_2">
                <uc3:ctrlTextBoxEx ID="title" canEmpty="false" CssClass="regedit_input promiseInputWidthExt" MaxLength="200" width="400"
                    runat="server" />
            </td>
        </tr>
        <%--<tr>
                                                               <td class="left_title_1 promiseLabelExt"><label>到期天数：</label></td>
                                                                <td>
                                                                    <uc3:ctrlTextBoxEx ID="ExpireDate" canEmpty="false" CssClass="input" MaxLength="10"   runat="server" mode="Int"/>
                                                                </td>
                                                            </tr>    --%>
        <%--<tr>
                                                               <td class="left_title_1 promiseLabelExt">是否单独组卷：</td>
                                                                <td>
                                                                     <asp:CheckBox ID="AlonePack" runat="server" />
                                                                </td>
                                                            </tr>--%>
        <tr>
            <td class="left_title_1 promiseLabelExt">文件路径：</td>
            <td class="left_title_2">
                <asp:FileUpload ID="UploadFile" Width="200px" runat="server" CssClass="trFile" />
                <asp:Label ID="FilePath" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="left_title_1 promiseLabelExt">是否目录：
            </td>
            <td class="left_title_2">
                <asp:CheckBox ID="IsFolder" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="left_title_1 promiseLabelExt">是否有效：
            </td>
            <td class="left_title_2">
                <asp:CheckBox ID="IsVisible" runat="server" Checked="true" />
            </td>
        </tr>
        <%--<tr>
                                                               <td class="left_title_1 promiseLabelExt"><label>是否必须提交：</label></td>
                                                                <td>
                                                                     <asp:CheckBox ID="MustSubmitFlag" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                               <td class="left_title_1 promiseLabelExt"><label>是否可见：</label></td>
                                                                <td>
                                                                   <asp:CheckBox ID="IsVisible" runat="server" />
                                                                </td>
                                                            </tr>--%>
    </table>
    <table id="table1" runat="server" width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td class="left_title_4">
                <asp:Button ID="btnSave" runat="server" Text=" 保存 " Width="52px" class="btn2"
                    OnClick="btnSave_Click" />
                &nbsp;<uc1:ctrlBtnBack ID="ctrlBtnBack1" runat="server" SetCssClass="btn2" />
            </td>
        </tr>
    </table>
</asp:Content>
