<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="QuestionTypeList.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.QuestionTypeList" Title="归档目录模板管理" %>

 
<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc21" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script language="javascript" type="text/javascript">
        function getNewUrl() {
            var url = window.location.href;
            if ($('#ctl00_Main_txtTitle_TextBox1').val() != "") {
                url = Common.urlreplace(url, 'txtTitle', $('#ctl00_Main_txtTitle_TextBox1').val());
            }
            if ($('#CurrentPageIndex').text() != "") {
                url = Common.urlreplace(url, 'PageIndex', $('#CurrentPageIndex').text());
            }
            url = Common.urlreplace(url, 'rn', Math.random());
            return url;
        }
        //新增
        function btnAdd() {
            var selKey = Common.getRadioKeyToArray();
            var url = 'QuestionTypeAdd.aspx?action=' + PageState.Add + '&id=0&rn=' + Math.random();
            if (selKey.length > 0)
                url = 'QuestionTypeAdd.aspx?action=' + PageState.Add + '&id=' + selKey[0] + '&rn=' + Math.random();

            Common.fnLayerOpen('系统问题分类-新增', "450px", "250px", url, true, "系统问题分类新增成功!");
        }
        //编辑
        function btnEdit() {
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                var url = 'QuestionTypeAdd.aspx?action=' + PageState.Edit + '&id=' + keyList[0] + '&rn=' + Math.random()
                Common.fnLayerOpen('系统问题分类-修改', "450px", "250px", url, true, "系统问题分类修改成功!");
            }
        }
        //删除
        function btnDel() {
            if (Common.isRadioCheck()) {
                layer.confirm('确定要删除选中系统问题分类?<br/>注意:系统问题分类下问题详情则不能删除!', function () {
                    var keyList = Common.getRadioKeyToArray();
                    if (QuestionTypeList.DeleteQuestionTypep(keyList[0]).value) {
                        Common.fnLayerAlertAndRefresh("系统问题分类删除成功!");
                    }
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
                    <td class="condition">分类名称：</td>
                    <td class="c2">
                        <uc21:ctrlTextBoxEx ID="txtTitle" runat="server" MaxLength="20" />
                    </td>
                    <td class="ss">
                        <asp:Button ID="btnSearch" runat="server" Text=" 查询 " OnClick="btnSearch_Click" />
                        <input type="reset" value="重 置" />
                    </td>
                </tr>
            </table>
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
                                <th>分类名称</th>
                                <th width="60px">排序位置</th>
                            </tr>
                        </thead>
                        <tbody class="tbody" id="bodyRepeater">
                            <asp:Repeater ID="rpData" runat="server">
                                <ItemTemplate>
                                    <tr class='<%#(Container.ItemIndex%2==0)?"bg01":""%>'>
                                        <td>
                                            <input type="radio" name="radio" value='<%# Eval("QuestionTypeID")%>' />
                                        </td>
                                        <td><%#Eval("Title")%></td>
                                        <td><%#Eval("OrderIndex")%></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <div class="pagination" style="height: 23px;">
                        <webdiyer:AspNetPager ID="AspNetPager" runat="server" PagingButtonSpacing="8px"
                            OnPageChanged="AspNetPager_PageChanged" ShowCustomInfoSection="left" CustomInfoStyle="text-align:left;"
                            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" PageIndexBoxStyle="text-align:right;"
                            CustomInfoHTML="共有 <strong>%RecordCount%</strong> 条记录，当前第 <strong id='CurrentPageIndex'>%CurrentPageIndex%</strong> 页，共<strong> %PageCount%</strong> 页"
                            UrlPaging="false" Width="100%" layouttype="Table" ShowNavigationToolTip="True"
                            ShowPageIndex="False" HorizontalAlign="Right" PageIndexBoxType="TextBox" ShowPageIndexBox="Always" SubmitButtonText="跳转" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" AlwaysShow="True">
                        </webdiyer:AspNetPager>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
