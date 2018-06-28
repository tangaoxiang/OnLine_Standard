<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="WorkFlowList.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.WorkFlowList" Title="流程管理" %>

<%@ Register Src="../CommonCtrl/ctrlDropDownCompanyInfo.ascx" TagName="ctrlDropDownCompanyInfo"
    TagPrefix="uc2" %>
<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc1" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownSystemInfo.ascx" TagName="ctrlDropDownSystemInfo"
    TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script language="javascript" type="text/javascript">
        function getNewUrl() {
            var url = window.location.href;
            url = Common.urlreplace(url, 'ddlCompany', escape($('#ctl00_Main_ddlCompany_ddlArea').val()));
            url = Common.urlreplace(url, 'PageIndex', $('#CurrentPageIndex').text());
            url = Common.urlreplace(url, 'rn', Math.random());
            return url;
        }
        //新增
        function btnAdd() {
            var selKey = Common.getRadioKeyToArray();
            var url = 'WorkFlowAdd.aspx?action=' + PageState.Add + '&id=0&rn=' + Math.random();
            if (selKey.length > 0)
                url = 'WorkFlowAdd.aspx?action=' + PageState.Add + '&id=' + selKey[0] + '&rn=' + Math.random();

            var height = "590px";
            if (screen.height < 900) height = "100%";
            Common.fnLayerOpen('流程页面-新增', "700px", height, url, true, "流程新增成功!");
        }
        //编辑
        function btnEdit() {
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                var url = 'WorkFlowAdd.aspx?action=' + PageState.Edit + '&id=' + keyList[0] + '&rn=' + Math.random();
                var height = "590px";
                if (screen.height < 900) height = "100%";
                Common.fnLayerOpen('流程页面-修改', "700px", height, url, true, "流程修改成功!");
            }
        }
        //删除
        function btnDel() {
            if (Common.isRadioCheck()) {
                layer.confirm('确定要删除选中流程节点?<br/>' + Common.getRedStrongString("注意:删除流程节点后,可能会影响到后续的工作!"), function () {
                    var keyList = Common.getRadioKeyToArray();
                    var len = WorkFlowList.DelWrokFlow(keyList[0]).value;
                    if (len) {
                        Common.fnLayerAlertAndRefresh("流程删除成功!");
                    }
                });
            }
        }

    </script>
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
            <table id="c1">
                <tr>
                    <td class="condition">单位名称：</td>
                    <td class="c2">
                        <uc2:ctrlDropDownCompanyInfo ID="ddlCompany" runat="server" />
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
                <div class="anl" id="anlButtonList">
                    <input type="button" id="MrcBtnAdd" title="新增" onclick="btnAdd()" value="新增" />
                    <input type="button" id="MrcBtnEdit" title="修改" onclick="btnEdit()" value="修改" />
                    <input type="button" id="MrcBtnDel" title="删除" onclick="btnDel()" value="删除" />
                </div>
                <table>
                    <thead>
                        <tr>
                            <th width="20px"></th>
                            <th width="110px">机构名称</th>
                            <th>单位名称</th>
                            <th width="160px">流程名称</th>
                            <th width="160px">流程代号</th>
                            <th width="160px">上级</th>
                            <th width="100px">排序位置</th>
                            <th width="100px">建设单位可用</th>
                            <th width="40px">Key</th>
                        </tr>
                    </thead>
                    <tbody class="tbody" id="bodyRepeater">
                        <asp:Repeater ID="rpData" runat="server">
                            <ItemTemplate>
                                <tr class='<%#(Container.ItemIndex%2==0)?"bg01":""%>'>
                                    <td>
                                        <input type="radio" name="radio" value='<%# Eval("WorkFlowID")%>' />
                                    </td>
                                    <td><%#Eval("Area_Name")%></td>
                                    <td><%#Eval("CompanyName")%></td>
                                    <td><%#Eval("WorkFlowName")%></td>
                                    <td><%#Eval("WorkFlowCode")%></td>
                                    <td><%#Eval("PWorkFlowName")%></td>
                                    <td><%#Eval("OrderIndex")%></td>
                                    <td><%# DigiPower.Onlinecol.Standard.Web.PublicModel.GetImageforStatus(Convert.ToBoolean(Eval("UseForCompany")))%></td>
                                    <td><%#Eval("WorkFlowID")%></td>
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
