<%@ Page Title="案卷各流程审核信息-从窗口接收开始" Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="ArchiveCheckList.aspx.cs" Inherits="DigiPower.Onlinecol.Standard.Web.WorkFlow.ArchiveCheckList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <style type="text/css">
        td {
            word-break: break-all;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="main-content">
        <div class="content-box-content">
            <div class="tab-content default-tab" id="tab1">
                <table>
                    <thead>
                        <tr>
                            <th width="30px">序号</th>
                            <th width="85px">流程节点</th>
                            <th width="70px">审核人</th>
                            <th width="70px">审核时间</th>
                            <th width="70px">审核结果</th>
                            <th>审核意见</th>
                        </tr>
                    </thead>
                    <tbody class="tbody" id="bodyRepeater">
                        <asp:Repeater ID="rpData" runat="server">
                            <ItemTemplate>
                                <tr class='<%#(Container.ItemIndex%2==0)?"bg01":""%>'>
                                    <td>
                                        <%#Container.ItemIndex+1%>
                                    </td>
                                    <td><%#Eval("WorkFlowName")%></td>
                                    <td><%#Eval("DoUserName")%></td>
                                    <td><%# Convert.ToDateTime( Eval("DoDateTime")).ToString("yyyy-MM-dd")%></td>
                                    <td><%#Eval("DoResult").ToString()=="1"?"审核通过":"审核未通过"%></td>
                                    <td><%#Eval("DoRemark")%></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
