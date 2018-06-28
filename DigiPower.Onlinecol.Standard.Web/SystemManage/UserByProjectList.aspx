﻿<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="UserByProjectList.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.UserByProjectList" Title="跟用户相关工程信息" %>

<%@ Register Src="../CommonCtrl/ctrlDropDownCompanyInfo.ascx" TagName="ctrlDropDownCompanyInfo"
    TagPrefix="uc2" %>
<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">

    <style type="text/css">
        select {
            height: 21px;
            width: 175px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <input type="hidden" id="hidOpenFlag" />
    <div class="main-content">
        <div class="content-box-search">
            <%--<button type="button" id="more_button_plus" class="more_button_plus"></button>--%>
            <table id="c1">
                <tr>
                    <td class="condition">工程名称：</td>
                    <td class="c2">
                        <uc1:ctrlTextBoxEx runat="server" ID="txtGcmc" MaxLength="20" />
                    </td>
                    <td class="condition">工程编号：</td>
                    <td class="c2">
                        <uc1:ctrlTextBoxEx runat="server" ID="txtGcbm" MaxLength="10" />
                    </td>
                    <td class="condition">工程地址：</td>
                    <td class="c2">
                        <uc1:ctrlTextBoxEx runat="server" ID="txtGcdd" MaxLength="20" />
                    </td>
                    <td class="ss">
                        <asp:Button ID="btnSearch" runat="server" Text=" 查询 " OnClick="btnSearch_Click" />
                        <input type="button" value="重 置" id="btnSearchParRet" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="ss"></div>
        <div class="content-box-content">
            <div class="tab-content default-tab" id="tab1">
                <table>
                    <thead>
                        <tr>
                            <th width="90px">项目类型</th>
                            <th width="70px">工程编号</th>
                            <th>工程名称</th>
                            <th width="200px">工程地址</th>
                            <th width="140px">规划许可证号</th>
                            <th width="140px">施工许可证号</th>
                            <th width="100px">业务指导人员</th>
                        </tr>
                    </thead>
                    <tbody class="tbody" id="bodyRepeater">
                        <asp:Repeater ID="rpData" runat="server">
                            <ItemTemplate>
                                <tr class='<%#(Container.ItemIndex%2==0)?"bg01":""%>'>
                                    <td><%#Eval("ProjectTypeName")%></td>
                                    <td><%#Eval("gcbm")%></td>
                                    <td><%#Eval("gcmc")%></td>
                                    <td><%#Eval("gcdd")%></td>
                                    <td><%#Eval("ghxkzh")%></td>
                                    <td><%#Eval("sgxkzh")%></td>
                                    <td><%#Eval("ChargeUserName")%></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <div class="pagination" style="height: 23px;">
                    <webdiyer:AspNetPager ID="AspNetPager" runat="server" PagingButtonSpacing="8px"
                        OnPageChanged="AspNetPager_PageChanged" ShowCustomInfoSection="left" CustomInfoStyle="text-align:left;"
                        FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" PageIndexBoxStyle="text-align:right;"
                        CustomInfoHTML="共有 <strong>%RecordCount%</strong> 条记录，每页 <strong>%PageSize%</strong> 条，当前第 <strong id='CurrentPageIndex'>%CurrentPageIndex%</strong> 页，共<strong> %PageCount%</strong> 页"
                        UrlPaging="false" Width="100%" layouttype="Table" ShowNavigationToolTip="True"
                        ShowPageIndex="False" HorizontalAlign="Right" PageIndexBoxType="TextBox" ShowPageIndexBox="Always" SubmitButtonText="跳转" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" AlwaysShow="True">
                    </webdiyer:AspNetPager>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
