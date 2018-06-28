<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="LHSignatureFilesLog.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.LHSignatureFilesLog" Title="签章日志" %>

<%@ Import Namespace="DigiPower.Onlinecol.Standard.Web" %>
<%@ Import Namespace="DigiPower.Onlinecol.Standard.Common" %>

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
                                <th width="35px">序号</th>
                                <th width="100px">签章人</th>
                                <th>签章人角色</th>
                                <th width="70px">签章类型</th>
                                <th width="70px">签章日期</th>
                                <th width="88px">签章完成日期</th>
                            </tr>
                        </thead>
                        <tbody class="tbody" id="bodyRepeater">
                            <asp:Repeater ID="rpData" runat="server">
                                <ItemTemplate>
                                    <tr class='<%#(Container.ItemIndex%2==0)?"bg01":""%>'>
                                        <td><%# Container.ItemIndex+1%></td>
                                        <td><%#Eval("SignatureUserName")%></td>
                                        <td><%#Eval("RoleName")%></td>
                                        <td><%#
                                            PublicModel.GetEnumDescription((SystemSet.EumSignatureOperationType)Enum.Parse(typeof(SystemSet.EumSignatureOperationType), Eval("OperationType").ToString()))%></td>
                                        <td>
                                            <%# Eval("Signature_DT").ToString().Length>0? ConvertEx.ToDate(Eval("Signature_DT").ToString()).ToString("yyyy-MM-dd"):""%></td>
                                        <td><%# Eval("SignatureFinish_DT").ToString().Length>0? ConvertEx.ToDate(Eval("SignatureFinish_DT").ToString()).ToString("yyyy-MM-dd"):""%></td>
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
