<%@ Page Title="" Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true"
    CodeBehind="OperationLogView.aspx.cs" Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.OperationLogView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <style type="text/css">
        td {
            word-break: break-all;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <input type="hidden" id="hidOpenFlag" />
    <div class="main-content">
        <div class="content-box-content">
            <div class="tab-content default-tab" id="tab1" style="padding: 5px;">
                <table>
                    <tbody class="tbody" id="bodyRepeater">
                        <tr>
                            <td style="width: 33%">操作IP:<strong><asp:Literal runat="server" ID="ltCreateIP"></asp:Literal></strong></td>
                            <td style="width: 33%">操作人:<strong><asp:Literal runat="server" ID="ltUserName"></asp:Literal></strong></td>
                            <td style="width: 34%">发生时间:<strong><asp:Literal runat="server" ID="ltCreateDate"></asp:Literal></strong></td>
                        </tr>
                        <tr>
                            <td colspan="3">操作类型:<strong><asp:Literal runat="server" ID="ltDescription"></asp:Literal></strong></td>
                        </tr>
                        <tr>
                            <td colspan="3">操作说明</td>
                        </tr>
                        <tr>
                            <td colspan="3" style="font-family: Consolas">
                                <asp:Literal runat="server" ID="ltErrorMsg"></asp:Literal>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
