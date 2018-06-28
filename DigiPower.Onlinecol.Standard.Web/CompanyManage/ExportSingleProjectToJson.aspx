<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true"
    CodeBehind="ExportSingleProjectToJson.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.ExportSingleProjectToJson" %>

<%@ Register Src="../CommonCtrl/ctrlDropDownSystemInfo.ascx" TagName="ctrlDropDownSystemInfo"
    TagPrefix="uc1" %>
<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc3" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownUser.ascx" TagName="ctrlDropDownUser" TagPrefix="uc2" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownExportType.ascx" TagName="ctrlDropDownExportType" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="../Javascript/jedate/jedate.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function getNewUrl() {
            var url = window.location.href;
            url = Common.urlreplace(url, 'ddlChargeUserID', escape($('#ctl00_Main_ddlChargeUserID_ddlUser').val()));
            url = Common.urlreplace(url, 'ddlProjectType', escape($('#ctl00_Main_ddlProjectType_ddlSystemInfo').val()));
            url = Common.urlreplace(url, 'kgsj1', escape($('#ctl00_Main_kgsj1_TextBox').val()));
            url = Common.urlreplace(url, 'kgsj2', escape($('#ctl00_Main_kgsj2_TextBox1').val()));
            url = Common.urlreplace(url, 'jgsj1', escape($('#ctl00_Main_jgsj1_TextBox1').val()));
            url = Common.urlreplace(url, 'jgsj2', escape($('#ctl00_Main_jgsj2_TextBox1').val()));
            url = Common.urlreplace(url, 'txtGcmc', escape($('#ctl00_Main_txtGcmc_TextBox1').val()));
            url = Common.urlreplace(url, 'txtGcbm', escape($('#ctl00_Main_txtGcbm_TextBox1').val()));
            url = Common.urlreplace(url, 'txtghxkzh', escape($('#ctl00_Main_txtghxkzh_TextBox1').val()));
            url = Common.urlreplace(url, 'txtsgxkzh', escape($('#ctl00_Main_txtsgxkzh_TextBox1').val()));
            url = Common.urlreplace(url, 'txtGcdd', escape($('#ctl00_Main_txtGcdd_TextBox1').val()));
            url = Common.urlreplace(url, 'PageIndex', $('#CurrentPageIndex').text());
            url = Common.urlreplace(url, 'rn', Math.random());
            return url;
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
        //导出包
        function btnExport(obj) {
            if ($(obj).attr("clickflag") == 'ok') {
                if (Common.isRadioCheck()) {
                    $(obj).attr("clickflag", "no");
                    var keyList = Common.getRadioKeyToArray();
                    var exlName = ExportSingleProjectToJson.ExportToJson(Number(keyList[0])).value;
                    if (exlName == ResultState.Failure) {
                        Common.fnLayerAlert("工程必须处在[文件登记]环节才可以导出信息包!");
                    } else if (exlName.indexOf(ResultState.Success) > -1) {
                        $(obj).attr("clickflag", "ok");
                        window.parent.location.href = "../ReportPDFDown.aspx?pdfFileName=" + exlName;
                    } else {
                        common.fnLayerAlert(exlName);
                    }
                }
            } else {
                layer.alert("程序正在处理中,请稍后.......");
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <input type="hidden" id="hidOpenFlag" />
    <div class="main-content">
        <div class="content-box-search">
            <table id="c1">
                <tr>
                    <td class="condition">工程类别：</td>
                    <td class="c2 c3">
                        <uc1:ctrlDropDownSystemInfo ID="ddlProjectType" runat="server"
                            CurrentType="Archive_Form" Width="186" />
                    </td>
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
                            <uc3:ctrlTextBoxEx ID="kgsj1" runat="server" Status="Select" mode="Date" ShowLblDate="false" width="80px" CssClass="SelectText" />
                            &nbsp;~&nbsp;
                             <uc3:ctrlTextBoxEx ID="kgsj2" runat="server" Status="Select" mode="Date" ShowLblDate="false" width="80px" CssClass="SelectText" />
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
                            <uc3:ctrlTextBoxEx ID="jgsj1" runat="server" Status="Select" mode="Date" ShowLblDate="false" width="80px" CssClass="SelectText" />
                            &nbsp;~&nbsp;
                             <uc3:ctrlTextBoxEx ID="jgsj2" runat="server" Status="Select" mode="Date" ShowLblDate="false" width="80px" CssClass="SelectText" />
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
                    <input type="button" id="MrcBtnExportExcel" title="导出包,用于外部系统(比如筑业系统),工程必须处于文件登记环节才能导出"
                        clickflag="ok" onclick="btnExport(this)" value="导出包" />
                </div>
                <table>
                    <thead>
                        <tr>
                            <th width="20px"></th>
                            <th width="90px">项目类型</th>
                            <th width="200px">项目名称</th>
                            <th width="70px">工程编号</th>
                            <th>工程名称</th>
                            <th width="180px">规划许可证号</th>
                            <th width="180px">施工许可证号</th>
                            <th width="90px">工程所处环节</th>
                        </tr>
                    </thead>
                    <tbody class="tbody" id="bodyRepeater">
                        <asp:Repeater ID="rpData" runat="server">
                            <ItemTemplate>
                                <tr class='<%#(Container.ItemIndex%2==0)?"bg01":""%>'>
                                    <td>
                                        <input type="radio" name="radio" value='<%# Eval("SingleProjectID")%>,<%# Eval("ProjectType")%>,<%# Eval("ChargeUserID")%>,<%# Eval("WorkFlow_DoStatus")%>' />
                                    </td>
                                    <td><%#Eval("ProjectTypeName")%></td>
                                    <td><%#Eval("xmmc")%></td>
                                    <td><%#Eval("gcbm")%></td>
                                    <td><%#Eval("gcmc")%></td>
                                    <td><%#Eval("ghxkzh")%></td>
                                    <td><%#Eval("sgxkzh")%></td>
                                    <td><%#Eval("workflowname")%></td>
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
