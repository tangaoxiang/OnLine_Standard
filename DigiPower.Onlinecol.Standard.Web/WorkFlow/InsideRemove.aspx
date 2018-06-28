<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="InsideRemove.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.WorkFlow.InsideRemove" Title=" 案卷级页面" %>

<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc1" %>
<%@ Register Src="../CommonCtrl/ctrlJSCheckInfo.ascx" TagName="ctrlJSCheckInfo" TagPrefix="uc2" %>
<%@ Register Src="../CommonCtrl/ctrlProjectBaseInfo.ascx" TagName="ctrlProjectBaseInfo"
    TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script language="javascript" type="text/javascript">

        //工程ID
        function GetSingleProjectID() {
            return $('#HidSingleProjectID').val();
        }
        //工程类型
        function GetProjectType() {
            return $('#HidProjectType').val();
        }
        function getNewUrl() {
            var url = window.location.href;
            url = Common.urlreplace(url, 'PageIndex', $('#CurrentPageIndex').text());
            url = Common.urlreplace(url, 'rn', Math.random());
            return url;
        }

        //审核明细
        function btnCheckList() {
            if (Common.isCheckBoxOneChecked()) {
                var keyList = Common.getChkOneKeyToArray();
                var url = "../WorkFlow/ArchiveCheckList.aspx?SingleProjectID=" + GetSingleProjectID() + "&ArchiveID=" +
                    keyList[0] + "&rn=" + Math.random();
                window.top.parent.ParentOpenDiv('审核信息', url, '900px', '80%');
            }
        }
        //工程信息
        function btnLookSingle() {
            var height = "100%";
            if (screen.height >= 900) height = "680px";
            window.top.parent.ParentOpenDiv('工程信息-预览', '../CompanyManage/CompanyReg3_' +
                Common.getFileTypeForProjectType(GetProjectType()) + 'Edit.aspx?action=' + PageState.View + '&SingleProjectID=' +
                GetSingleProjectID() + '&rn=' + Math.random() + '&ProjectType=' + GetProjectType(), '900px', height);
        }
        //案卷信息
        function btnLookArchive() {
            if (Common.isCheckBoxOneChecked()) {
                var keyList = Common.getChkOneKeyToArray();
                var url = 'ArchiveAdd.aspx?action=' + PageState.View + '&id=' + keyList[0] + '&rn=' + Math.random();
                Common.fnLayerOpen('案卷信息', "550px", "470px", url, false, "");
            }
        }
        //文件明细
        function btnArchiveToFileList() {
            if (Common.isCheckBoxOneChecked()) {
                var keyList = Common.getChkOneKeyToArray();
                var url = 'ArchiveToFileList.aspx?action=' + PageState.View + '&ArchiveID=' + keyList[0] + '&rn=' + Math.random();
                Common.fnLayerOpen('案卷-' + keyList[2] + '-' + keyList[1], "100%", "100%", url, false, "");
            }
        }
        //返回
        function btnBack() {
            window.location.href = '../CompanyManage/AdvSearch.aspx?Archive_Form=<%= DigiPower.Onlinecol.Standard.Common.DNTRequest.GetQueryString("Archive_Form")%>&rn=' + Math.random();
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <input type="hidden" id="HidSingleProjectID" value="<%= singleProjectID%>" />
    <input type="hidden" id="HidProjectType" value="<%= projectType%>" />

    <input type="hidden" id="hidOpenFlag" />

    <uc3:ctrlProjectBaseInfo ID="ctrlProjectBaseInfo1" runat="server" />
    <div class="main-content">
        <div class="content-box-content">
            <div class="tab-content default-tab" id="tab1">
                <div class="anl">
                    <input type="button" id="MrcBtnLookSingle" value="工程信息" title="工程详细信息" onclick="btnLookSingle()" />
                    <input type="button" id="MrcBtnLookArchive" value="案卷信息" title="案卷详细信息" onclick="btnLookArchive()" />
                    <input type="button" id="MrcBtnArchiveToFileList" value="文件明细" title="文件详细信息" onclick="btnArchiveToFileList()" />
                    <input type="button" title="只能勾选单份案卷查看案卷审核详细信息" value="审核明细" onclick="btnCheckList()" />
                    <input type="button" title="返回列表页面" value="返回" onclick="Common.fnParentLayerClose()" />
                </div>
                <table>
                    <thead>
                        <tr>
                            <th width="30px" style="cursor: pointer;" onclick="Common.selCheckBoxAll(this)"
                                selall="0">全选</th>
                            <th>案卷题名</th>
                            <th width="180px">编制单位</th>
                            <th width="55px">案卷类型</th>
                            <th width="65px">立卷人</th>
                            <th width="70px">编制日期</th>
                            <th width="55px">案卷序号</th>
                        </tr>
                    </thead>
                    <tbody class="tbody" id="bodyRepeater">
                        <asp:Repeater ID="rpData" runat="server">
                            <ItemTemplate>
                                <tr class='<%#(Container.ItemIndex%2==0)?"bg01":""%>' id="r1" runat="server">
                                    <td>
                                        <input type="checkbox" name="checkOne" value='<%# Eval("ArchiveID")%>,<%# Eval("xh")%>,<%# Eval("ajtm")%>' />
                                    </td>
                                    <td><%#Eval("ajtm")%></td>
                                    <td><%#Eval("bzdw")%></td>
                                    <td><%#Eval("ajlxname")%></td>
                                    <td><%#Eval("lrr")%></td>
                                    <td><%# DigiPower.Onlinecol.Standard.Common.ConvertEx.ToDate(Eval("lrsj")).ToString("yyyy-MM-dd")%></td>
                                    <td><%#Eval("xh")%></td>
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
