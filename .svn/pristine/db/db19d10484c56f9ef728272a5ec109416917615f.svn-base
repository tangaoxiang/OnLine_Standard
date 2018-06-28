<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="SystemList.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.SystemList" Title="字典维护" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script language="javascript" type="text/javascript">
        function getNewUrl() {
            var url = window.location.href;
            url = Common.urlreplace(url, 'drpType', escape($('#ctl00_Main_drpType').val()));
            url = Common.urlreplace(url, 'PageIndex', $('#CurrentPageIndex').text());
            url = Common.urlreplace(url, 'rn', Math.random());
            return url;
        }
        //新增
        function btnAdd() {
            var selKey = Common.getChkMoreKeyListToArray(0);
            var url = 'SystemAdd.aspx?action=' + PageState.Add + '&id=0&rn=' + Math.random();
            if (selKey.length > 0)
                url = 'SystemAdd.aspx?action=' + PageState.Add + '&id=' + selKey[0] + '&rn=' + Math.random();

            Common.fnLayerOpen('数据字典-新增', "600px", "430px", url, true, "数据新增成功!");
        }
        //编辑
        function btnEdit() {
            if (Common.isCheckBoxOneChecked()) {
                var keyList = Common.getChkOneKeyToArray();
                var url = 'SystemAdd.aspx?action=' + PageState.Edit + '&id=' + keyList[0] + '&rn=' + Math.random()
                Common.fnLayerOpen('数据字典-修改', "600px", "430px", url, true, "数据修改成功!");
            }
        }
        //删除
        function btnDel() {
            if (Common.isCheckBoxMoreChecked()) {
                layer.confirm('确定要删除选中行数据?', function () {
                    var keyList = Common.getChkMoreKeyListToString(0);
                    SystemList.DeleteSystemInfo(keyList).value
                    Common.fnLayerAlertAndRefresh("数据删除成功");
                });
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <input type="hidden" id="hidOpenFlag" />
    <div class="main-content">
        <div class="content-box-search">
            <table id="c1">
                <tr>
                    <td class="condition">类型：</td>
                    <td class="c2">
                        <asp:DropDownList ID="drpType" runat="server" Height="21px" Width="180px"
                            AutoPostBack="True" OnSelectedIndexChanged="drpType_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td class="condition"></td>
                    <td class="c2"></td>
                    <td class="condition"></td>
                    <td class="c2"></td>
                    <td class="ss"></td>
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
                            <th width="30px" style="cursor: pointer;" onclick="Common.selCheckBoxAll(this)" selall="0">全选</th>
                            <th>类型名称</th>
                            <th width="200px">类型</th>
                            <th width="200px">单位类别</th>
                            <th width="200px">值</th>
                            <th width="110px">二级类别</th>
                            <th width="90px">排序编号</th>
                            <th width="60px">Key</th>
                        </tr>
                    </thead>
                    <tbody class="tbody" id="bodyRepeater">
                        <asp:Repeater ID="rpData" runat="server">
                            <ItemTemplate>
                                <tr class='<%#(Container.ItemIndex%2==0)?"bg01":""%>'>
                                    <td>
                                        <input type="checkbox" name="checkOne"
                                            value='<%# Eval("SystemInfoID")%>,<%# Eval("CurrentType")%>' /></td>
                                    <td><%#Eval("CurrentTypeCNName")%></td>
                                    <td><%#Eval("CurrentType")%></td>
                                    <td><%#Eval("SystemInfoName")%></td>
                                    <td><%#Eval("SystemInfoCode")%></td>
                                    <td><%#Eval("SubType")%></td>
                                    <td><%#Eval("OrderIndex")%></td>
                                    <td><%#Eval("SystemInfoID")%></td>
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
