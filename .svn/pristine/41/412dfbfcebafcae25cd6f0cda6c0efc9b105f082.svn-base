<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="Rwfp.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.WorkFlow.Rwfp" Title="报建确认" %>

<%@ Import Namespace="DigiPower.Onlinecol.Standard.Web" %>
<%@ Import Namespace="DigiPower.Onlinecol.Standard.Common" %>

<%@ Register Src="../CommonCtrl/ctrlDropDownUser.ascx" TagName="ctrlDropDownUser"
    TagPrefix="uc1" %>
<%@ Register Src="../CommonCtrl/ctrlCompanyQucikReg.ascx" TagName="ctrlCompanyQucikReg"
    TagPrefix="uc2" %>
<%@ Register Src="../CommonCtrl/ctrlBtnBack.ascx" TagName="ctrlBtnBack" TagPrefix="uc3" %>
<%@ Register Src="../CommonCtrl/ctrlArchiveTypeDetail.ascx" TagName="ctrlArchiveTypeDetail" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <style type="text/css">
        select {
            height: 27px;
            width: 240px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <input type="hidden" id="HidSingleProjectID" value="<%=singleProjectid %>" />
    <input type="hidden" id="HidworkFlowID" value="<%=workFlowID %>" />
    <input type="hidden" id="hidOpenFlag" />

    <table id="tbl" runat="server" style="height: 80px;" class="zpxxxj" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>业务指导人员：<uc1:ctrlDropDownUser ID="ddlUser" runat="server" />
            </td>
            <td class="lljzc" colspan="3">
                <input type="button" id="btnSave" value=" 确认并分配 "
                    onclick="btnRwfp(this);" clickflag="ok" />
                <input type="button" id="btnDelete" value=" 删除 "
                    onclick="fnDelete(this);" clickflag="ok" />
                <input type="button" id="MrcBtnZRS" title="打印责任书" clickflag="ok"
                    onclick="btnPrint('建设工程档案报送责任书', 'ZRS', '460px', '200px')" value="打印责任书" />

                <input type="button" id="btngoBack" value=" 返回 " onclick="Common.fnParentLayerCloseAndRefresh()" />
            </td>
        </tr>
    </table>
    <fieldset style="width: 99%; border: 1px solid #dddddd;">
        <legend>工程报建信息</legend>
        <uc2:ctrlCompanyQucikReg ID="ctrlCompanyQucikReg" runat="server" />
    </fieldset>

    <script language="javascript" type="text/javascript">
        var singleProjectId = $('#HidSingleProjectID').val();                        //工程ID    
        function fnDelete(obj) {
            if ($(obj).attr("clickflag") == 'ok') {
                layer.confirm('确定要删除工程报建信息?<br/>' + Common.getRedStrongString('注意:建设单位第一次报建则删除所有相关信息!') + '<br/>' + Common.getRedStrongString('工程下的文件没有被著录,审核,组卷等则可以删除工程!'), function () {
                    $(obj).attr("clickflag", "no");
                    var len = Rwfp.DeleteSingleProject(singleProjectId).value;
                    if (len.indexOf(ResultState.Success) > -1) {
                        layer.alert("工程删除成功!", { btnAlign: 'c' }, function (index) {
                            layer.close(index);
                            var index = parent.layer.getFrameIndex(window.name);
                            parent.document.getElementById('hidOpenFlag').value = '1';
                            parent.layer.close(index);
                        });
                    } else {
                        Common.fnLayerAlert(len);
                        return false;
                    }
                });
            }
            else {
                Common.fnLayerAlert("程序正在处理中,请稍后.......");
                return false;
            }
        }

        function btnRwfp(obj) {
            var workFlowID = $('#HidworkFlowID').val();                                //流程ID 
            var chargeUserID = $('#ctl00_Main_ddlUser_ddlUser').val();                 //指导人员
            if (Number(chargeUserID) == 0) {
                Common.fnLayerAlert("请选择业务指导人员!");
                return false;
            }
            if ($(obj).attr("clickflag") == 'ok') {
                $(obj).attr("clickflag", "no");
                var len = Rwfp.AllotSingleProject(singleProjectId, chargeUserID, workFlowID).value;
                if (len.indexOf(ResultState.Failure) < 0) {
                    layer.alert("分配成功,工程编号为:" + Common.getRedStrongString(len) + ",工程已提交到下一流程", { btnAlign: 'c' }, function (index) {
                        layer.close(index);
                        var index = parent.layer.getFrameIndex(window.name);
                        parent.document.getElementById('hidOpenFlag').value = '1';
                        parent.layer.close(index);
                    });
                } else {
                    Common.fnLayerAlert(len);
                    return false;
                }
            }
            else {
                Common.fnLayerAlert("程序正在处理中,请稍后.......");
                return false;
            }
        }

        function btnPrint(title, reportCode, width, height) {
            printPDF(singleProjectId, reportCode, false, title, width, height);
        }
        function printPDF(singleProjectID, reportCode, delOldReportPDF, title, width, height) {
            var existsFlag = Rwfp.CheckExistsReportPDF(singleProjectID, reportCode).value;
            if (existsFlag) {
                layer.confirm('打印的报表已经存在,是否重新打印?', { btn: ['是', '否'] }, function (index) { //确定     
                    opSubmittedInfo(title, width, height, singleProjectID, reportCode, true);
                    layer.close(index);
                }, function (index) { //取消
                    printPDF2(singleProjectID, reportCode, false);
                    layer.close(index);
                });
            } else {
                opSubmittedInfo(title, width, height, singleProjectID, reportCode, false);
            }
        }
        function printPDF2(singleProjectID, reportCode, delOldReportPDF) {
            var pdfFileName = Rwfp.ReportExportPDF(singleProjectID, reportCode, delOldReportPDF).value;
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
</asp:Content>
