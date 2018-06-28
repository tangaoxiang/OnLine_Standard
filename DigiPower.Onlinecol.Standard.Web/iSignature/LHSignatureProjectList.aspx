<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="LHSignatureProjectList.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.LHSignatureProjectList" Title="电子签章工程列表" %>

<%@ Register Src="../CommonCtrl/ctrlDropDownSystemInfo.ascx" TagName="ctrlDropDownSystemInfo" TagPrefix="uc1" %>
<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc3" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownUser.ascx" TagName="ctrlDropDownUser" TagPrefix="uc2" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownExportType.ascx" TagName="ctrlDropDownExportType" TagPrefix="uc4" %>

<%@ Import Namespace="DigiPower.Onlinecol.Standard.Web" %>
<%@ Import Namespace="DigiPower.Onlinecol.Standard.Common" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="../Javascript/Common/WebCalendar.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function getNewUrl() {
            var url = window.location.href;
            url = Common.urlreplace(url, 'txtGcmc', escape($('#ctl00_Main_txtGcmc_TextBox1').val()));
            url = Common.urlreplace(url, 'txtGcbm', escape($('#ctl00_Main_txtGcbm_TextBox1').val()));
            url = Common.urlreplace(url, 'PageIndex', $('#CurrentPageIndex').text());
            url = Common.urlreplace(url, 'rn', Math.random());
            return url;
        }
        //查看工程信息
        function btnLookSingle() {
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                var height = "100%";
                if (screen.height >= 900) height = "680px";
                window.top.parent.ParentOpenDiv('工程信息-预览', '../CompanyManage/CompanyReg3_' +
                    Common.getFileTypeForProjectType(keyList[1]) + 'Edit.aspx?action=' + PageState.View + '&SingleProjectID=' +
                    keyList[0] + '&rn=' + Math.random() + '&ProjectType=' + keyList[1], '900px', height);
            }
        }
        //电子签章
        function btnSignature() {
            window.top.parent.closeMenu();
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                var strURL = "LHSignatureFilesList.aspx?SingleProjectID=" + keyList[0] + "&WorkFlow_DoStatus=" +
                    keyList[3] + "&ProjectType=" + keyList[1] + "&rn=" + Math.random();
                Common.fnLayerOpen(false, '100%', '100%', strURL, true, '');
            }
        }
    </script>
    <style type="text/css">
        select {
            height: 21px;
        }

        .c3 {
            width: 260px !important;
        }

        .condition {
            width: 100px !important;
        }

        .tdImgsignature {
            width: 14px;
            height: 14px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <input type="hidden" id="hidOpenFlag" />
    <div class="main-content">
        <div class="content-box-search">
            <table id="c1">
                <tr>
                    <td class="condition">工程名称：</td>
                    <td class="c2">
                        <uc3:ctrlTextBoxEx runat="server" ID="txtGcmc" MaxLength="20" width="140" />
                    </td>
                    <td class="condition">工程编号：</td>
                    <td class="c2">
                        <uc3:ctrlTextBoxEx runat="server" ID="txtGcbm" MaxLength="10" width="140" />
                    </td>
                    <td class="ss">
                        <asp:Button ID="btnSearch" runat="server" Text=" 查询 " OnClick="btnSearch_Click" />
                        <input type="button" value="重 置" id="btnSearchParRet" />
                    </td>
                   <%-- <td>
                        <button style="float: right;" type="button" id="more_button_plus" class="more_button_plus"></button>
                    </td>--%>
                </tr>
            </table>
        </div>
        <div class="ss"></div>
        <div class="content-box-content">
            <div class="tab-content default-tab" id="tab1">
                <div class="anl" id="anlButtonList">
                    <input type="button" id="MrcBtnLookSingle" title="工程信息预览" onclick="btnLookSingle()" value="工程信息" />
                    <input type="button" id="MrcBtnSignature" title="电子签章(单签或批量签)" onclick="btnSignature()" value="电子签章" />
                    <strong style="color: red;">只针对文件登记流程下的工程进行电子签章</strong>
                </div>
                <table>
                    <thead>
                        <tr>
                            <th width="20px"></th>
                            <th width="90px">项目类型</th>
                            <th width="70px">工程编号</th>
                            <th>工程名称</th>
                            <th width="180px">工程地点</th>
                            <th width="180px">规划许可证号</th>
                            <th width="180px">施工许可证号</th>
                            <th width="60px" title="针对当前角色用户">待签文件</th>
                            <th width="60px" title="针对当前角色用户">已签文件</th>
                        </tr>
                    </thead>
                    <tbody class="tbody" id="bodyRepeater">
                        <asp:Repeater ID="gvData" runat="server">
                            <ItemTemplate>
                                <tr class='<%#(Container.ItemIndex%2==0)?"bg01":""%>'>
                                    <td>
                                        <input type="radio" name="radio" value='<%# Eval("SingleProjectID")%>,<%# Eval("ProjectType")%>,<%# Eval("ChargeUserID")%>,<%# Eval("WorkFlow_DoStatus")%>' />
                                    </td>
                                    <td><%#Eval("ProjectTypeName")%></td>
                                    <td><%#Eval("gcbm")%></td>
                                    <td><%#Eval("gcmc")%></td>
                                    <td><%#Eval("gcdd")%></td>
                                    <td><%# PublicModel.getEfileImageToZH(Eval("ghxkz_AttachPath").ToString(), Eval("ghxkzh").ToString(),"规划许可证") %></td>   
                                    <td><%# PublicModel.getEfileImageToZH(Eval("sgxkz_AttachPath").ToString(), Eval("sgxkzh").ToString(),"施工许可证") %></td>
                                    <td><%# getTdHTML(Eval("SingleProjectID").ToString())%></td>
                                    <td><%# getSignatureFinishCount(Eval("SingleProjectID").ToString())%>份</td>
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
