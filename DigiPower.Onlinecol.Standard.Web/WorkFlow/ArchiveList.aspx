<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="ArchiveList.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.WorkFlow.ArchiveList" Title="案卷列表" %>

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
        //查看工程信息
        function btnLookSingle() {
            if (Common.isCheckBoxOneChecked()) {
                var keyList = Common.getChkOneKeyToArray();
                var height = "100%";
                if (screen.height >= 900) height = "680px";
                window.top.parent.ParentOpenDiv('工程信息-预览', '../CompanyManage/CompanyReg3_' +
                    Common.getFileTypeForProjectType(keyList[2]) + 'Edit.aspx?action=' + PageState.View + '&SingleProjectID=' +
                    keyList[1] + '&rn=' + Math.random() + '&ProjectType=' + keyList[2], '900px', height);
            }
        }

        //编辑
        function btnEdit() {
            if (Common.isCheckBoxOneChecked()) {
                var keyList = Common.getChkOneKeyToArray();
                var url = 'ArchiveAdd.aspx?action=' + PageState.Edit + '&id=' + keyList[0] + '&rn=' + Math.random();
                Common.fnLayerOpen('案卷信息-修改', "550px", "470px", url, true, "案卷信息修改成功!");
            }
        }
        //删除
        function btnDel() {
            if (Common.isCheckBoxMoreChecked()) {
                layer.confirm('确定要删除选中案卷信息?', function () {
                    var keyList = Common.getChkMoreKeyListToString(0);
                    ArchiveList.DeleteArchiveMore(keyList).value
                    Common.fnLayerAlertAndRefresh("案卷删除成功");
                });
            }
        }

        //批量保存
        function batchSaveIndex() {
            var checkedLen = $("input[type='checkbox']:checked").length;
            if (checkedLen > 0) {
                $("input[type='checkbox']:checked").each(function () {
                    var keyList = ($(this).val() + ',').split(',');
                    var tdAll = $(this).parent().nextAll();
                    ArchiveList.UpdateArchiveXH(keyList[0], $(tdAll).eq(6).children(0).val()).value;
                });
                Common.fnLayerAlertAndRefresh("案卷序号更新成功!");
            } else {
                Common.fnLayerAlert('必须选择一项才可以操作!');
            }
        }
        function btnPrint2(singleProjectID, reportCode, delOldReportPDF, ids) {
            var pdfFileName = ArchiveList.ReportExportPDF(singleProjectID, reportCode, delOldReportPDF).value;
            if (pdfFileName.indexOf(ResultState.Failure) < 0) {
                var url = "ReportPdfView.aspx?pdfFileName=" + pdfFileName;
                window.top.parent.ParentOpenDiv('报表预览', url, '80%', '98%');
            } else {
                Common.fnLayerAlert('报表PDF转换失败,错误原因:' + pdfFileName);
            }
        }
        //打印
        function btnPrint(types) {
            var checkedLen = $("input[type='checkbox']:checked").length;
            if (checkedLen > 0) {
                var ids = "";
                $("input[type='checkbox']:checked").each(function () {
                    var keyList = ($(this).val() + ',').split(',');
                    if (ids == "") ids = keyList[0];
                    else ids += "," + keyList[0];
                });
                if ((types == 1 || types == 3) && ids.indexOf(",") > -1) {
                    Common.fnLayerAlert('只能选择一项才可以操作!');
                    return;
                }

                if (types == 1) {//打印案卷封皮
                    btnPrint2(ids, "archivefengpi", true)
                } else if (types == 2) {//打印卷内目录
                    btnPrint2(ids, "archivemulu", true)
                } else if (types == 3) {//打印卷内备考表
                    btnPrint2(ids, "juanneibeikao", true)
                }
            } else {
                Common.fnLayerAlert('必须选择一项才可以操作!');
            }
        }
        //文件明细
        function btnArchiveToFileList() {
            window.top.parent.closeMenu();
            if (Common.isCheckBoxOneChecked()) {
                var keyList = Common.getChkOneKeyToArray();
                var url = 'ArchiveToFileList.aspx?action=' + PageState.Edit + '&ArchiveID=' + keyList[0] + '&rn=' + Math.random();
                Common.fnLayerOpen('案卷-' + keyList[3] + '-' + keyList[4], '100%', '100%', url, false, '');
            }
        }
        //更新卷内文件序号
        function btnUpdateFileOrderIndex() {
            var checkedLen = $("input[type='checkbox']:checked").length;
            if (checkedLen > 0) {
                $("input[type='checkbox']:checked").each(function () {
                    var keyList = ($(this).val() + ',').split(',');
                    ArchiveList.updateFileOrderIndexByArchiveID(keyList[0]).value;
                });
                Common.fnLayerAlertAndRefresh("更新卷内文件序号成功!");
            } else {
                Common.fnLayerAlert('必须选择一项才可以操作!');
            }
        }
        //案卷检测
        function btnArchiveCheck() {
            var checkedLen = $("input[type='checkbox']:checked").length;
            if (checkedLen > 0) {
                var singleProjectIDS = "";
                $("input[type='checkbox']:checked").each(function () {
                    var keyList = ($(this).val() + ',').split(',');
                    if (singleProjectIDS == "") {
                        singleProjectIDS = "," + keyList[1] + ",";
                    } else {
                        if (singleProjectIDS.indexOf("," + keyList[1] + ",") < 0)
                            singleProjectIDS += "," + keyList[1] + ",";
                    }
                });
                if (singleProjectIDS != "") {
                    var len = ArchiveList.ArchiveCheckByManualCount(singleProjectIDS).value;
                    if (len == "0") {
                        Common.fnLayerAlert("未查询到不合格文件!");
                    } else {
                        window.parent.location.href = "../ReportPDFDown.aspx?pdfFileName=" + len;
                    }
                }
            } else {
                Common.fnLayerAlert('必须选择一项才可以操作!');
            }
        }
    </script>
    <style type="text/css">
        .regedit_input {
            width: 99% !important;
            font-size: 13px !important;
            border: 1px solid #D5D5D5 !important;
            color: #333 !important;
            height: 23px;
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
                    <input type="button" id="MrcBtnLookSingle" value="工程信息" onclick="btnLookSingle()" />
                    <input type="button" id="MrcBtnArchiveToFileList" value="文件明细" onclick="btnArchiveToFileList()" />
                    <input type="button" id="MrcBtnEdit" value="修改" title="修改案卷信息" onclick="btnEdit()" />
                    <input type="button" id="MrcBtnDel" value="删除" title="删除案卷" onclick="btnDel()" />
                    <input type="button" id="MrcBtnBatchUpdate" title="可多选更新案卷序号" value="更新案卷序号" onclick="batchSaveIndex()" />
                    <input type="button" id="MrcBtnUpdateFileOrderIndex" onclick="btnUpdateFileOrderIndex()"
                        title="按文件编号排序来更新卷内文件序号" value="更新卷内文件序号" />
                    <input type="button" id="MrcBtnArchiveCheck" value="案卷检测"
                        title="检测案卷下的文件的实体页数是否大于0" onclick="btnArchiveCheck()" />
                    <input type="button" id="MrcBtnPrintFP" value="打印案卷封皮" onclick="btnPrint(1)" />
                    <input type="button" id="MrcBtnPrintJLML" value="打印卷内目录" onclick="btnPrint(2)" />
                    <input type="button" id="MrcBtnPrintBKB" value="打印卷内备考表" onclick="btnPrint(3)" />
                </div>
                <table>
                    <thead>
                        <tr>
                            <th width="30px" style="cursor: pointer;" onclick="Common.selCheckBoxAll(this)"
                                selall="0">全选</th>
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
                                        <input type="checkbox" name="checkOne"
                                            value='<%# Eval("ArchiveID")%>,<%# Eval("SingleProjectID")%>,
                                                <%# Eval("ProjectType")%>,<%# Eval("xh")%>,<%# Eval("ajtm")%>' /></td>
                                    <td><%#Eval("gcbm")%></td>
                                    <td><%#Eval("gcmc")%></td>
                                    <td><%#Eval("ajtm")%></td>
                                    <td><%#Eval("bzdw")%></td>
                                    <td><%#Eval("lrr")%></td>
                                    <td><%# DigiPower.Onlinecol.Standard.Common.ConvertEx.ToDate(Eval("lrsj")).ToString("yyyy-MM-dd")%></td>
                                    <td>
                                        <input type="text" value="<%# Eval("xh")%>" style="width: 50px" class="regedit_input"
                                            id="txtXH<%# Eval("ArchiveID")%>" onkeyup="this.value=this.value.replace(/\D/g,'')"
                                            onafterpaste="this.value=this.value.replace(/\D/g,'')" /></td>

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
