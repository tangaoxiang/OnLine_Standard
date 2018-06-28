<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="SmArchiveList.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.WorkFlow.SmArchiveList" Title="案卷列表" %>

<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script language="javascript" type="text/javascript">
        function getNewUrl() {
            var url = window.location.href;
            url = Common.urlreplace(url, 'txtgcmc', escape($('#ctl00_Main_txtgcmc_TextBox1').val()));
            url = Common.urlreplace(url, 'txtgcbm', escape($('#ctl00_Main_txtgcbm_TextBox1').val()));
            url = Common.urlreplace(url, 'txtajtm', escape($('#ctl00_Main_txtajtm_TextBox1').val()));
            url = Common.urlreplace(url, 'PageIndex', $('#CurrentPageIndex').text());
            url = Common.urlreplace(url, 'rn', Math.random());
            return url;
        }
        //工程信息修改
        function btnEditSingleProject() {
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                var url = '../CompanyManage/CompanyReg3_' + Common.getFileTypeForProjectType(keyList[2]) + 'Edit.aspx?action=' +
                        PageState.Edit + '&SingleProjectID=' + keyList[1] + '&ProjectType=' + keyList[2] + '&rn=' + Math.random();
                Common.fnLayerOpen('工程信息-修改', '100%', '100%', url, true, '工程信息修改成功!');
            }
        }
        //案卷信息修改
        function btnEdit() {
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                var url = '../WorkFlow/ArchiveAdd.aspx?action=' + PageState.Edit + '&id=' + keyList[0] + '&rn=' + Math.random();
                Common.fnLayerOpen('案卷信息-修改', "550px", "470px", url, true, "案卷信息修改成功!");
            }
        }
        //补卷
        function btnArchiveToBJ() {
            window.top.parent.closeMenu();
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                var url = 'SmZJList.aspx?SingleProjectID=' + keyList[1] + '&ProjectType=' + keyList[2] + '&rn=' + Math.random()
                    + "&ModuleID=<%= DigiPower.Onlinecol.Standard.Common.DNTRequest.GetQueryString("ModuleID")%>";
                Common.fnLayerOpen(false, "100%", "100%", url, true, "");
            }
        }
        //文件明细
        function btnArchiveToFileList() {
            window.top.parent.closeMenu();
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                var url = 'SmArchiveToFileList.aspx?action=' + PageState.Edit + '&ArchiveID=' + keyList[0] + '&rn=' + Math.random();
                Common.fnLayerOpen('案卷-' + keyList[3] + '-' + keyList[4], '100%', '100%', url, false, '');
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
                    <td class="condition">工程名称：</td>
                    <td class="c2">
                        <uc1:ctrlTextBoxEx runat="server" ID="txtgcmc" MaxLength="20" />
                    </td>
                    <td class="condition">工程编号：</td>
                    <td class="c2">
                        <uc1:ctrlTextBoxEx runat="server" ID="txtgcbm" MaxLength="10" />
                    </td>
                    <td class="condition">案卷题名：</td>
                    <td class="c2">
                        <uc1:ctrlTextBoxEx runat="server" ID="txtajtm" MaxLength="20" />
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
                <div class="anl" id="anlButtonList">
                    <input type="button" id="MrcBtnArchiveToBJ" value="补卷" onclick="btnArchiveToBJ()" />
                    <input type="button" id="MrcBtnEditSingleProject" value="工程信息修改" title="修改工程详细信息" onclick="btnEditSingleProject()" />
                    <input type="button" id="MrcBtnEdit" value="案卷信息修改" title="修改案卷详细信息" onclick="btnEdit()" />
                    <input type="button" id="MrcBtnArchiveToFileList" value="文件明细" onclick="btnArchiveToFileList()" />
                    <strong style="color: red;">只针对流程节点处于窗口接收和档案移交之间且未入库的工程进行补卷管理</strong>
                </div>
                <table>
                    <thead>
                        <tr>
                            <th width="20px"></th>
                            <th width="70px">工程编号</th>
                            <th width="200px">工程名称</th>
                            <th>案卷题名</th>
                            <th width="150px">编制单位</th>
                            <th width="70px">立卷人</th>
                            <th width="70px">编制日期</th>
                            <th width="65px">案卷序号</th>
                        </tr>
                    </thead>
                    <tbody class="tbody" id="bodyRepeater">
                        <asp:Repeater ID="rpData" runat="server">
                            <ItemTemplate>
                                <tr class='<%#(Container.ItemIndex%2==0)?"bg01":""%>'>
                                    <td>
                                        <input type="radio" name="radio"
                                            value='<%# Eval("ArchiveID")%>,<%# Eval("SingleProjectID")%>,
                                                <%# Eval("ProjectType")%>,<%# Eval("xh")%>,<%# Eval("ajtm")%>' /></td>
                                    <td><%#Eval("gcbm")%></td>
                                    <td><%#Eval("gcmc")%></td>
                                    <td><%#Eval("ajtm")%></td>
                                    <td><%#Eval("bzdw")%></td>
                                    <td><%#Eval("lrr")%></td>
                                    <td><%# DigiPower.Onlinecol.Standard.Common.ConvertEx.ToDate(Eval("lrsj")).ToString("yyyy-MM-dd")%></td>
                                    <td>
                                        <%# Eval("xh")%></td>
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
