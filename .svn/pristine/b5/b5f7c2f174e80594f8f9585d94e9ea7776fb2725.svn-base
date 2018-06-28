<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="QuestionList.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.WorkFlow.QuestionList" Title="系统问题列表" %>

<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc21" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script language="javascript" type="text/javascript">
        function getNewUrl() {
            var url = window.location.href;
            url = Common.urlreplace(url, 'ddlQuestionType', escape($('#ctl00_Main_ddlQuestionType').val()));
            url = Common.urlreplace(url, 'txtTitle', escape($('#ctl00_Main_txtTitle_TextBox1').val()));
            url = Common.urlreplace(url, 'PageIndex', $('#CurrentPageIndex').text());
            url = Common.urlreplace(url, 'rn', Math.random());
            return url;
        }
        //新增
        function btnAdd() {
            var selKey = Common.getRadioKeyToArray();
            var url = 'QuestionAdd.aspx?action=' + PageState.Add + '&id=0&rn=' + Math.random();
            if (selKey.length > 0)
                url = 'QuestionAdd.aspx?action=' + PageState.Add + '&id=' + selKey[0] + '&rn=' + Math.random();

            Common.fnLayerOpen('系统问题-新增', "720px", "500px", url, true, "系统问题新增成功!");
        }
        //编辑
        function btnEdit() {
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                var url = 'QuestionAdd.aspx?action=' + PageState.Edit + '&id=' + keyList[0] + '&rn=' + Math.random()
                Common.fnLayerOpen('系统问题-修改', "720px", "500px", url, true, "系统问题修改成功!");
            }
        }
        //删除
        function btnDel() {
            if (Common.isRadioCheck()) {
                layer.confirm('确定要删除选中问题?', function () {
                    var keyList = Common.getRadioKeyToArray();
                    QuestionList.DeleteQuestion(keyList[0]).value;
                    Common.fnLayerAlertAndRefresh("系统问题删除成功!");
                });
            }
        }
        //预览
        function btnView() {
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                var url = '../WorkFlow/QuestionView.aspx?id=' + keyList[0] + '&rn=' + Math.random();
                window.top.parent.ParentOpenDiv('问题详情预览', url, '900px', '90%');
            }
        }
        //预览
        function clickbtnView(id) {
            var url = '../WorkFlow/QuestionView.aspx?id=' + id + '&rn=' + Math.random();
            window.top.parent.ParentOpenDiv('问题详情预览', url, '900px', '90%');
        }
    </script>
    <style type="text/css">
        select {
            height: 21px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <input type="hidden" id="hidOpenFlag" />
    <div class="main-content">
        <div class="content-box-search">
            <table id="c1">
                <tr>
                    <td class="condition">问题类别：</td>
                    <td class="c2">
                        <asp:DropDownList ID="ddlQuestionType" runat="server" Width="180"></asp:DropDownList>
                    </td>
                    <td class="condition">问题主题：</td>
                    <td class="c2">
                        <uc21:ctrlTextBoxEx ID="txtTitle" runat="server" MaxLength="20" />
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
                    <input type="button" id="MrcBtnView" title="预览" onclick="btnView()" value="预览" />
                </div>
                <table>
                    <thead>
                        <tr>
                            <th width="20px"></th>
                            <th width="150px">问题类别</th>
                            <th>问题主题</th>
                            <th width="100px">创建人</th>
                            <th width="70px">创建时间</th>
                            <th width="70px">浏览次数</th>
                        </tr>
                    </thead>
                    <tbody class="tbody" id="bodyRepeater">
                        <asp:Repeater ID="rpData" runat="server">
                            <ItemTemplate>
                                <tr class='<%#(Container.ItemIndex%2==0)?"bg01":""%>' onclick="clickbtnView(<%# Eval("QuestionID")%>)">
                                    <td>
                                        <input type="radio" name="radio" value='<%# Eval("QuestionID")%>' />
                                    </td>
                                    <td><%#Eval("QuestionTypeTitle")%></td>
                                    <td><%#Eval("Title")%></td>
                                    <td><%#Eval("CreateUserName")%></td>
                                    <td><%#Convert.ToDateTime(Eval("CreateDate")).ToString("yyyy-MM-dd")%></td>
                                    <td><%#Eval("ClickCount")%></td>
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
