<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="LHSignatureFileTmp.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.LHSignatureFileTmp" Title="文件签章流程模板" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <input type="hidden" id="hidOpenFlag" />
    <div class="main-content">
        <div class="content-box-search">
            <div class="content-box-content">
                <div class="tab-content default-tab" id="tab1">
                    <table>
                        <thead>
                            <tr>
                                <th width="60px">签章顺序</th>
                                <th>签章角色</th>
                            </tr>
                        </thead>
                        <tbody class="tbody" id="bodyRepeater">
                            <asp:Repeater ID="rpData" runat="server">
                                <ItemTemplate>
                                    <tr class='<%#(Container.ItemIndex%2==0)?"bg01":""%>'>
                                        <td><%# Container.ItemIndex+1%></td>
                                        <td><%#Eval("SignatureTypeName")%></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
