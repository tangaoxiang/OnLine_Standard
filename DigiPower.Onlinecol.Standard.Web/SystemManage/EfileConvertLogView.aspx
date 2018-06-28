<%@ Page Title="" Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true"
    CodeBehind="EfileConvertLogView.aspx.cs" Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.EfileConvertLogView" %>

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
                            <td style="width: 25%">工程编号:<strong><asp:Literal runat="server" ID="ltgcbm"></asp:Literal></strong></td>
                            <td style="width: 25%">工程Key:<strong><asp:Literal runat="server" ID="ltSingleProjectID"></asp:Literal></strong></td>
                            <td style="width: 25%">文件Key:<strong><asp:Literal runat="server" ID="ltFileListID"></asp:Literal></strong></td>
                            <td style="width: 25%">Efile Key:<strong><asp:Literal runat="server" ID="ltEFileID"></asp:Literal></strong></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="width: 50%">文件名称:<strong><asp:Literal runat="server" ID="ltFileName"></asp:Literal></strong></td>
                            <td colspan="2" style="width: 50%">转换失败时间:<strong><asp:Literal runat="server" ID="ltCreateDate"></asp:Literal></strong></td>
                        </tr>
                        <tr>
                            <td colspan="4">异常详情
                                  <strong>
                                      <asp:Literal runat="server" ID="ltDownUrl"></asp:Literal></strong>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="font-family: Consolas">
                                <asp:Literal runat="server" ID="ltDescription"></asp:Literal>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
