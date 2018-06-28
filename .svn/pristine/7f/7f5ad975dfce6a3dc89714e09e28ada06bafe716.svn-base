<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="WFArchiveList.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.WorkFlow.WFArchiveList" Title="窗口接收,业务审核 案卷级页面" %>

<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc1" %>
<%@ Register Src="../CommonCtrl/ctrlJSCheckInfo.ascx" TagName="ctrlJSCheckInfo" TagPrefix="uc2" %>
<%@ Register Src="../CommonCtrl/ctrlProjectBaseInfo.ascx" TagName="ctrlProjectBaseInfo"
    TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script language="javascript" type="text/javascript">
        //工程类型
        function GetProjectType() {
            return $('#HidProjectType').val();
        }
        //工程ID
        function GetSingleProjectID() {
            return $('#HidSingleProjectID').val();
        }
        //流程ID
        function GetWorkFlowID() {
            return $('#HidworkFlowID').val();
        }
        function getNewUrl() {
            var url = window.location.href;
            url = Common.urlreplace(url, 'PageIndex', $('#CurrentPageIndex').text());
            url = Common.urlreplace(url, 'rn', Math.random());
            return url;
        }
        //审核
        function btnCheck() {
            var checkedLen = $("input[type='checkbox']:checked").length;
            if (checkedLen > 0) {
                var keyList = "";
                $("input[type='checkbox']:checked").each(function () {
                    var ids = ($(this).val() + ',').split(',');
                    keyList += ids[0] + ",";
                });
                var url = "ArchiveCheck.aspx?SingleProjectID=" + GetSingleProjectID() + "&ArchiveIDS=" + keyList
                    + "&workFlowID=" + GetWorkFlowID() + "&rn=" + Math.random();
                Common.fnLayerOpen("审核", "480px", "350px", url, true, "审核完成!");
            } else {
                Common.fnLayerAlert('必须选择一项才可以操作!');
            }
        }
        //审核明细
        function btnCheckList() {
            if (Common.isCheckBoxOneChecked()) {
                var keyList = Common.getChkOneKeyToArray();
                var url = "../WorkFlow/ArchiveCheckList.aspx?SingleProjectID=" + GetSingleProjectID() + "&ArchiveID=" + keyList[0] + "&rn=" + Math.random();
                window.top.parent.ParentOpenDiv('审核信息', url, '900px', '80%');
            }
        }
        //领导签字
        function btnShqd() {
            var len = WFArchiveList.SingleProjectSubmit(GetSingleProjectID(), GetWorkFlowID()).value;
            if (len) {
                layer.alert("确认成功,工程将提交到下一环节!", { btnAlign: 'c' }, function (index) {
                    layer.close(index);
                    Common.fnParentLayerCloseAndRefresh();
                });
            } else {
                Common.fnLayerAlert("提交失败,请稍后再试！");
            }
        }
        //档案入库
        function btnArchiveRK() {
            var len = WFArchiveList.SingleProjectRK(GetSingleProjectID()).value;
            layer.alert("入库成功,请耐心等待工程,案卷,文件,电子文件数据将被提交到馆藏系统!", { btnAlign: 'c' }, function (index) {
                layer.close(index);
                Common.fnParentLayerCloseAndRefresh();
            });
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

        //打印报表
        function AgainReportExportPDF(title, reportCode, width, height) {
            var existsFlag = WFArchiveList.CheckExistsReportPDF(GetSingleProjectID(), reportCode).value;
            if (existsFlag) {
                layer.confirm('打印的报表已经存在,是否重新打印?', { btn: ['是', '否'] }, function (index) { //是
                    opSubmittedInfo(title, width, height, GetSingleProjectID(), reportCode, true);
                    layer.close(index);
                }, function (index) { //否
                    printPDF2(GetSingleProjectID(), reportCode, false);
                    layer.close(index);
                });
            } else {
                opSubmittedInfo(title, width, height, GetSingleProjectID(), reportCode, false);
            }
        }
        function printPDF2(singleProjectID, reportCode, delOldReportPDF) {
            var pdfFileName = WFArchiveList.ReportExportPDF(singleProjectID, reportCode, delOldReportPDF).value;
            if (pdfFileName.indexOf(ResultState.Failure) < 0) {
                var url = "ReportPdfView.aspx?pdfFileName=" + pdfFileName;
                window.top.parent.ParentOpenDiv('报表预览', url, '80%', '98%');
                $("#hidOpenFlag").val('0');
            } else {
                Common.fnLayerAlert('报表PDF打印失败,错误原因:' + pdfFileName);
            }
        }
        function opSubmittedInfo(title, width, height, singleProjectID, reportCode, delOldReportPDF) {
            var url = "SubmittedInfo.aspx?singleProjectID=" + singleProjectID + "&reportType=" + reportCode;
            layer.open({
                type: 2,
                title: title,
                maxmin: false,
                resize: false,
                shadeClose: false,
                area: [width, height],
                content: url,
                end: function () {
                    if ($("#hidOpenFlag").val() == "1") {
                        printPDF2(singleProjectID, reportCode, delOldReportPDF);
                    }
                }
            });
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <input type="hidden" id="HidSingleProjectID" value="<%= singleProjectID%>" />
    <input type="hidden" id="HidworkFlowID" value="<%=workFlowID %>" />
    <input type="hidden" id="HidworkFlowCode" value="<%=workFlowCode %>" />
    <input type="hidden" id="hidOpenFlag" />

    <uc3:ctrlProjectBaseInfo ID="ctrlProjectBaseInfo1" runat="server" />
    <uc2:ctrlJSCheckInfo ID="ctrlJSCheckInfo1" runat="server" />
    <div class="main-content">
        <div class="content-box-search">
            <table id="c1">
                <tr>
                    <td class="condition">案卷题名：</td>
                    <td class="c2 c3">
                        <uc1:ctrlTextBoxEx runat="server" ID="txtTitle" MaxLength="20" width="140" />
                    </td>
                    <td class="condition">案卷序号：</td>
                    <td class="c2">
                        <uc1:ctrlTextBoxEx runat="server" ID="txtXH" MaxLength="4" width="140" />
                    </td>
                    <td class="condition">审核状态：</td>
                    <td class="c2">
                        <asp:DropDownList runat="server" ID="ddlChkStatus" Width="145">
                            <asp:ListItem Value="" Text="----请选择----"></asp:ListItem>
                            <asp:ListItem Value="2" Text="未审核"></asp:ListItem>
                            <asp:ListItem Value="0" Text="审核未通过"></asp:ListItem>
                            <asp:ListItem Value="1" Text="审核通过"></asp:ListItem>
                        </asp:DropDownList>
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
                    <input type="button" id="MrcBtnLookSingle" value="工程信息" onclick="btnLookSingle()" />
                    <input type="button" id="MrcBtnLookArchive" value="案卷信息" onclick="btnLookArchive()" />
                    <input type="button" id="MrcBtnArchiveToFileList" value="文件明细" onclick="btnArchiveToFileList()" />
                    <input type="button" id="MrcBtnRKZ" value="打印认可意见书" onclick="AgainReportExportPDF('建设工程档案认可意见书', 'RKZ', '540px', '350px')" />
                    <input type="button" id="MrcBtnCheck" title="勾选案卷审核,可以多选" value="审核" onclick="btnCheck()" />
                    <input type="button" id="MrcBtnLookArchiveList" title="只能勾选单份案卷查看" value="审核明细" onclick="btnCheckList()" />
                    <input type="button" id="MrcBtnSHQD" title="审核确定即提交工程到下一环节" value="审核确定" onclick="btnShqd()" />
                    <input type="button" id="MrcBtnZMS" value="打印移交证明书" onclick="AgainReportExportPDF('建设工程档案移交证明书', 'ZMS', '560px', '400px')" />
                    <input type="button" id="MrcBtnArchiveRK" value="档案入库" onclick="btnArchiveRK()" />
                    <input type="button" id="MrcBtnBack" title="返回列表页面" value="返回" onclick="Common.fnParentLayerCloseAndRefresh()" />
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
                            <th width="60px">审核状态</th>
                            <th width="60px">审核信息</th>
                        </tr>
                    </thead>
                    <tbody class="tbody" id="bodyRepeater">
                        <asp:Repeater ID="rpData" runat="server" OnItemDataBound="rpData_ItemDataBound">
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
                                    <td>
                                        <asp:Literal runat="server" ID="ltCheckStatus"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Literal runat="server" ID="ltRemark"></asp:Literal></td>
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
