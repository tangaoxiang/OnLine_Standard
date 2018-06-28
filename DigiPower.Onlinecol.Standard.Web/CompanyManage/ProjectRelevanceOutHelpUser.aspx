<%@ Page Title="外协单位关联" Language="C#" MasterPageFile="~/SiteParent.Master"
    AutoEventWireup="true" CodeBehind="ProjectRelevanceOutHelpUser.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.CompanyManage.ProjectRelevanceOutHelpUser" %>

<%@ Register Src="../CommonCtrl/ctrlDropDownSystemInfo.ascx" TagName="ctrlDropDownSystemInfo"
    TagPrefix="uc2" %>
<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc1" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownFileTmpSignatureUserRole.ascx"
    TagName="ctrlDropDownFileTmpSignatureUserRole" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script language="javascript" type="text/javascript">
        function btnAddRelevanceUser() { //单位关联
            if (Common.isCheckBoxMoreChecked()) {
                var SingleProjectID = '<%=SingleProjectID%>';
                var ProjectType = '<%=ProjectType%>';

                var coloseFlag = true;
                $("input[type='checkbox'][name='checkOne']:checked").each(function () {
                    var strKey = ($(this).val() + ',').split(',');
                    var len = ProjectRelevanceOutHelpUser.HookUpCompanyAndUser(Number(SingleProjectID), Number(strKey[0]),
                        Number(strKey[1]), Number(strKey[2]), ProjectType, strKey[4], strKey[3]).value;
                    if (len.indexOf(ResultState.Failure) > -1) {
                        coloseFlag = false;
                        Common.fnLayerAlert(len);
                        return;
                    }
                });
                if (coloseFlag) {
                    var index = parent.layer.getFrameIndex(window.name);
                    parent.document.getElementById('hidOpenFlag').value = '1';
                    parent.layer.close(index);
                }
            }
        }
        function btnAddLookCompany() {//单位信息
            if (Common.isCheckBoxOneChecked()) {
                var keyList = Common.getChkOneKeyToArray();
                var url = '../SystemManage/OutHelpCompanyAdd.aspx?action=' +
                    PageState.View + '&id=' + keyList[2] + '&rn=' + Math.random() + '&CompanyType=' + keyList[3];
                var height = "100%";
                if (screen.height >= 900) height = "650px";
                window.top.parent.ParentOpenDiv('外协单位信息-预览', url, '900px', height);
            }
        }
    </script>
    <style type="text/css">
        .condition {
            width: 110px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <input type="hidden" id="hidOpenFlag" />
    <div class="main-content">
        <div class="content-box-search">
            <table id="c1">
                <tr>
                    <td class="condition">外协单位角色：</td>
                    <td class="c2">
                        <uc4:ctrlDropDownFileTmpSignatureUserRole ID="ctrlOutHelpRole" runat="server" Width="165" />
                    </td>
                    <td class="condition">单位名称：</td>
                    <td class="c2">
                        <uc1:ctrlTextBoxEx runat="server" ID="txtCompanyName" MaxLength="20" width="160" />
                    </td>
                    <td class="condition">用户名称：</td>
                    <td class="c2">
                        <uc1:ctrlTextBoxEx runat="server" ID="txtUserName" MaxLength="10" width="160" />
                    </td>
                    <td class="ss">
                        <asp:Button ID="btnSearch" runat="server" Text=" 查询 " OnClick="btnSearch_Click" />
                        <input type="button" value="重 置" id="btnSearchParRet" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="content-box-content">
            <div class="tab-content default-tab" id="tab1">
                <div class="anl">
                    <input type="button" id="MrcBtnLookCompany" value="外协单位信息" title="点击预览外协单位详细信息" onclick="btnAddLookCompany()" />
                    <input type="button" id="MrcBtnAddRelevanceUser" value="外协单位关联" title="外协单位关联" onclick="btnAddRelevanceUser()" />
                    <input type="button" id="btngoBack" value=" 返回 " title="返回列表页面" onclick="Common.fnParentLayerClose()" />
                </div>
                <table>
                    <thead>
                        <tr>
                            <th width="30px" style="cursor: pointer;" onclick="Common.selCheckBoxAll(this)"
                                selall="0">全选</th>
                            <th width="80px">公司类型</th>
                            <th>公司名称</th>
                            <th width="120px">统一社会信用代码</th>
                            <th width="120px">外协单位角色</th>
                            <th width="90px">用户名称</th>
                            <th width="90px">登录账号</th>
                        </tr>
                    </thead>
                    <tbody class="tbody" id="bodyRepeater">
                        <asp:Repeater ID="rpData" runat="server">
                            <ItemTemplate>
                                <tr class='<%#(Container.ItemIndex%2==0)?"bg01":""%>'>
                                    <td width="20">
                                        <input type="checkbox" name="checkOne"
                                            value='<%# Eval("UserID")%>,<%# Eval("RoleID")%>
                                                ,<%# Eval("CompanyID")%>,<%# Eval("CompanyType")%>
                                                ,<%# Eval("UserName")%>' /></td>
                                    <td><%#Eval("CompanyTypeName")%></td>
                                    <td><%#Eval("CompanyName")%></td>
                                    <td><%#Eval("CompanyCode")%></td>
                                    <td><%#Eval("RoleName")%></td>
                                    <td><%#Eval("UserName")%></td>
                                    <td><%#Eval("LoginName")%></td>
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
