<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="ArchiveTraceList.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.ArchiveTrace.ArchiveTraceList" Title="工程状态动态跟踪" %>

<%@ Import Namespace="DigiPower.Onlinecol.Standard.Web" %>
<%@ Import Namespace="DigiPower.Onlinecol.Standard.Common" %>

<%@ Register Src="../CommonCtrl/ctrlDropDownSystemInfo.ascx" TagName="ctrlDropDownSystemInfo"
    TagPrefix="uc1" %>
<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc3" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownUser.ascx" TagName="ctrlDropDownUser" TagPrefix="uc2" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownExportType.ascx" TagName="ctrlDropDownExportType" TagPrefix="uc4" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownWorkFlow.ascx" TagName="ctrlDropDownWorkFlow"
    TagPrefix="uc5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <%--<script src="../Javascript/Common/WebCalendar.js" type="text/javascript"></script>--%>
    <script src="../Javascript/jedate/jedate.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        //工程状态动态跟踪 
        function btnSingleStatusTail() {
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                var url = '../CompanyManage/ProjectDoInfo.aspx?action=' + PageState.View + '&SingleProjectID=' +
                    keyList[0] + '&rn=' + Math.random() + '&ProjectType=' + keyList[1];

                var height = "100%";
                if (screen.height >= 900) height = "95%";
                window.top.parent.ParentOpenDiv('工程[' + keyList[3] + ']状态动态跟踪', url, '900px', height);
            }
        }
        //查看工程信息
        function btnLookSingle() {
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                var url = '../CompanyManage/CompanyReg3_' + Common.getFileTypeForProjectType(keyList[1]) + 'Edit.aspx?action=' +
                    PageState.View + '&SingleProjectID=' + keyList[0] + '&rn=' + Math.random() + '&ProjectType=' + keyList[1];
                var height = "100%";
                if (screen.height >= 900) height = "680px";
                window.top.parent.ParentOpenDiv('工程信息-预览', url, '900px', height);
            }
        }
        function AgainReportExportPDF(title, reportCode, width, height) {
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                if (reportCode == 'ZRS') {
                    var code = '<%=SystemSet.EumWorkFlowCode.SINGLEPROJECTRED.ToString()%>';
                    if (ArchiveTraceList.CheckSingleWorkFlowStatus(keyList[2], code).value) {
                        printPDF(keyList[0], reportCode, title, width, height);
                    } else {
                        Common.fnLayerAlert("工程必须[报建确认]后才能打印责任书!");
                    }
                } else if (reportCode == 'RKZ') {
                    var code = '<%=SystemSet.EumWorkFlowCode.WINRECV.ToString()%>';
                    if (ArchiveTraceList.CheckSingleWorkFlowStatus(keyList[2], code).value) {
                        printPDF(keyList[0], reportCode, title, width, height);
                    } else {
                        Common.fnLayerAlert("工程必须处于[窗口接收]环节之后才能打印认可意见书!");
                    }
                } else if (reportCode == 'ZMS') {
                    var code = '<%=SystemSet.EumWorkFlowCode.IMPORT_TO.ToString()%>';
                        if (ArchiveTraceList.CheckSingleWorkFlowStatus(keyList[2], code).value) {
                            printPDF(keyList[0], reportCode, title, width, height);
                        } else {
                            Common.fnLayerAlert("工程必须处于[审核确定]环节之后才能打印移交证明书!");
                        }
                    }
        }
    }
    function printPDF(singleProjectID, reportCode, title, width, height) {
        var existsFlag = ArchiveTraceList.CheckExistsReportPDF(singleProjectID, reportCode).value;
        if (existsFlag) {
            layer.confirm('打印的报表已经存在,是否重新打印?', { btn: ['是', '否'] }, function (index) { //是     
                opSubmittedInfo(title, width, height, singleProjectID, reportCode, true);
                layer.close(index);
            }, function (index) { //否
                printPDF2(singleProjectID, reportCode, false);
                layer.close(index);
            });
        } else {
            opSubmittedInfo(title, width, height, singleProjectID, reportCode, false);
        }
    }
    function printPDF2(singleProjectID, reportCode, delOldReportPDF) {
        var pdfFileName = ArchiveTraceList.ReportExportPDF(singleProjectID, reportCode, delOldReportPDF).value;
        if (pdfFileName.indexOf(ResultState.Failure) < 0) { 
            if (Number(<%= SystemSet._ISIGNATUREPDF%>) == 1) {
                var strURL = "../iSignature/SignatureReportPdf.aspx?ReportType=" + reportCode + "&SingleProjectID=" + singleProjectID
                    + "&pdfFileName=" + pdfFileName + "&rn=" + Math.random();
                window.top.parent.ParentOpenDiv('报表预览/签章', strURL, '80%', '98%');
            } else {
                var strURL = "ReportPdfView.aspx?pdfFileName=" + pdfFileName + "&rn=" + Math.random();
                window.top.parent.ParentOpenDiv('报表预览', strURL, '80%', '98%');
            }
            $("#hidOpenFlag").val('0');
        } else {
            Common.fnLayerAlert('报表PDF转换失败,错误原因:' + pdfFileName);
        }
    }
    function opSubmittedInfo(title, width, height, singleProjectID, reportCode, delOldReportPDF) {
        var url = "../WorkFlow/SubmittedInfo.aspx?singleProjectID=" + singleProjectID + "&reportType=" + reportCode;
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <input type="hidden" id="hidOpenFlag" />
    <div class="main-content">
        <div class="content-box-search">
            <table id="c1">
                <tr>
                    <td class="condition">流程名称：</td>
                    <td class="c2 c3">
                        <uc5:ctrlDropDownWorkFlow ID="ddl_WorkFlowName" runat="server" Width="160" />

                    </td>
                    <td class="condition">工程类别：</td>
                    <td class="c2">
                        <uc1:ctrlDropDownSystemInfo ID="ddlProjectType" runat="server"
                            CurrentType="Archive_Form" Width="142" />
                    </td>
                    <td class="condition">工程名称：</td>
                    <td class="c2">
                        <uc3:ctrlTextBoxEx runat="server" ID="txtGcmc" MaxLength="20" width="140" />
                    </td>

                    <td class="ss">
                        <asp:Button ID="btnSearch" runat="server" Text=" 查询 " OnClick="btnSearch_Click" />
                        <input type="button" value="重 置" id="btnSearchParRet" />
                    </td>
                    <td>
                        <button style="float: right;" type="button" id="more_button_plus" class="more_button_plus"></button>
                    </td>
                </tr>
            </table>
            <div class="moremore">
                <table id="c1">
                    <tr>
                        <td class="condition">开工时间：</td>
                        <td class="c2 c3">
                            <uc3:ctrlTextBoxEx ID="kgsj1" runat="server" Status="Select" mode="Date" ShowLblDate="false" width="67px" CssClass="SelectText" />
                            &nbsp;~&nbsp;
                             <uc3:ctrlTextBoxEx ID="kgsj2" runat="server" Status="Select" mode="Date" ShowLblDate="false" width="67px" CssClass="SelectText" />
                        </td>
                        <td class="condition">工程地址：</td>
                        <td class="c2">
                            <uc3:ctrlTextBoxEx runat="server" ID="txtGcdd" MaxLength="20" width="140" />
                        </td>
                        <td class="condition">规划许可证号：</td>
                        <td class="c2">
                            <uc3:ctrlTextBoxEx runat="server" ID="txtghxkzh" MaxLength="20" width="140" />
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td class="condition">竣工时间：</td>
                        <td class="c2 c3">
                            <uc3:ctrlTextBoxEx ID="jgsj1" runat="server" Status="Select" mode="Date" ShowLblDate="false" width="67px" CssClass="SelectText" />
                            &nbsp;~&nbsp;
                             <uc3:ctrlTextBoxEx ID="jgsj2" runat="server" Status="Select" mode="Date" ShowLblDate="false" width="67px" CssClass="SelectText" />
                        </td>
                        <td class="condition">业务指导人员：</td>
                        <td class="c2">
                            <uc2:ctrlDropDownUser ID="ddlChargeUserID" runat="server" Width="142" />
                        </td>
                        <td class="condition">施工许可证号：</td>
                        <td class="c2">
                            <uc3:ctrlTextBoxEx runat="server" ID="txtsgxkzh" MaxLength="20" width="140" />
                        </td>
                        <td></td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="ss"></div>
        <div class="content-box-content">
            <div class="tab-content default-tab" id="tab1">
                <div class="anl" id="anlButtonList">
                    <input type="button" id="MrcBtnLookSingle" title="工程详细信息" onclick="btnLookSingle()" value="工程信息" />
                    <input type="button" id="MrcBtnSingleStatusTail" title="工程状态动态跟踪" onclick="btnSingleStatusTail()" value="工程状态动态跟踪" />
                    <input type="button" id="MrcBtnZRS" title="打印责任书" onclick="AgainReportExportPDF('建设工程档案报送责任书', 'ZRS', '460px', '200px')" value="打印责任书" />
                    <input type="button" id="MrcBtnRKZ" title="打印认可意见书" onclick="AgainReportExportPDF('建设工程档案认可意见书', 'RKZ', '540px', '350px')" value="打印认可意见书" />
                    <input type="button" id="MrcBtnZMS" title="打印移交证明书" onclick="AgainReportExportPDF('建设工程档案移交证明书', 'ZMS', '560px', '400px')" value="打印移交证明书" />
                </div>
                <table>
                    <thead>
                        <tr>
                            <th width="20px"></th>
                            <th width="80px">流程名称</th>
                            <th width="90px">项目类型</th>
                            <th width="70px">工程编号</th>
                            <th>工程名称</th>
                            <th width="180px">规划许可证号</th>
                            <th width="180px">施工许可证号</th>
                            <th width="85px">业务指导人员</th>
                            <th width="62px">工程状态</th>
                        </tr>
                    </thead>
                    <tbody class="tbody" id="bodyRepeater">
                        <asp:Repeater ID="rpData" runat="server">
                            <ItemTemplate>
                                <tr class='<%#(Container.ItemIndex%2==0)?"bg01":""%>'>
                                    <td>
                                        <input type="radio" name="radio" value='<%# Eval("SingleProjectID")%>,<%# Eval("ProjectType")%>,<%#Eval("WorkFlowID")%>,<%# Eval("gcbm")%>' />
                                    </td>
                                    <td><%#Eval("workflowname")%></td>
                                    <td><%#Eval("ProjectTypeName")%></td>
                                    <td><%#Eval("gcbm")%></td>
                                    <td><%#Eval("gcmc")%></td>
                                    <td><%# PublicModel.getEfileImageToZH(Eval("ghxkz_AttachPath").ToString(),
                                            Eval("ghxkzh").ToString(),"规划许可证") %></td>
                                    <td><%# PublicModel.getEfileImageToZH(Eval("sgxkz_AttachPath").ToString(),
                                            Eval("sgxkzh").ToString(),"施工许可证") %></td>

                                    <td><%#Eval("ChargeUserName")%></td>
                                    <td><%# PublicModel.getSingleProjectStatusNameByStatus(ConvertEx.ToInt(Eval("Status"))) %>                                              
                                    </td>
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
    <script type="text/javascript">
        jeDate({ dateCell: "#ctl00_Main_kgsj1_TextBox1", format: "YYYY-MM-DD", isTime: false, minDate: "1910-02-01" });
        jeDate({ dateCell: "#ctl00_Main_kgsj2_TextBox1", format: "YYYY-MM-DD", isTime: false, minDate: "1910-02-01" });
        jeDate({ dateCell: "#ctl00_Main_jgsj1_TextBox1", format: "YYYY-MM-DD", isTime: false, minDate: "1910-02-01" });
        jeDate({ dateCell: "#ctl00_Main_jgsj2_TextBox1", format: "YYYY-MM-DD", isTime: false, minDate: "1910-02-01" });
    </script>
</asp:Content>
