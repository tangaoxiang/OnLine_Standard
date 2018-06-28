<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="EfileConvertLogList.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.EfileConvertLogList" Title="电子文件转换日志" %>

<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc21" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script language="javascript" type="text/javascript">
        function getNewUrl() {
            var url = window.location.href;
            url = Common.urlreplace(url, 'Title', escape($('#ctl00_Main_txtTitle_TextBox1').val()));
            url = Common.urlreplace(url, 'PageIndex', $('#CurrentPageIndex').text());
            url = Common.urlreplace(url, 'rn', Math.random());
            return url;
        }
        //删除
        function btnDel() {
            if (Common.isCheckBoxMoreChecked()) {
                layer.confirm('确定要删除选中行数据?', function () {
                    var keyList = Common.getChkMoreKeyListToString(0);
                    EfileConvertLogList.DeleteEFileConvertLog(keyList).value
                    Common.fnLayerAlertAndRefresh("数据删除成功");
                });
            }
        }
        //导出excel
        function btnExportExcel(obj) {
            if ($(obj).attr("clickflag") == 'ok') {
                if ($("input[type='checkbox'][name='checkOne']").length < 1) {
                    Common.fnLayerAlert('没有数据库可导!');
                    return;
                }
                $(obj).attr("clickflag", "no");
                var exlName = EfileConvertLogList.ExportEfileConvertLogToExcel().value;
                if (exlName.indexOf(ResultState.Failure) > -1) {
                    Common.fnLayerAlert(exlName);
                } else {
                    $(obj).attr("clickflag", "ok");
                    window.parent.location.href = "../ReportPDFDown.aspx?pdfFileName=" + exlName;
                }
            } else {
                layer.alert("程序正在处理中,请稍后.......");
                return;
            }
        }
        //预览
        function clickbtnView(id, gcbm) {
            var url = '../SystemManage/EfileConvertLogView.aspx?id=' + id + '&gcbm=' + gcbm + '&rn=' + Math.random();
            window.top.parent.ParentOpenDiv('电子文件转换日志异常预览', url, '900px', '90%');
        }

    </script>
    <style type="text/css">
        select {
            height: 21px;
            width: 175px;
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
                        <uc21:ctrlTextBoxEx ID="txtGcmc" runat="server" MaxLength="30" />
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
                    <input type="button" id="MrcBtnDel" title="删除" onclick="btnDel()" value="删除" />
                    <input type="button" id="MrcBtnExportExcel" title="导出Excel"
                        clickflag="ok" onclick="btnExportExcel(this)" value="导出" />
                </div>
                <table>
                    <thead>
                        <tr>
                            <th width="30px" style="cursor: pointer;" onclick="Common.selCheckBoxAll(this)" selall="0">全选</th>
                            <th width="70px">工程编号</th>
                            <th width="60px">工程Key</th>
                            <th width="60px">文件Key</th>
                            <th width="60px">Efile Key</th>
                            <th width="150px">文件名称</th>
                            <th width="70px">发生时间</th>
                            <th width="30px" title="下载上传的电子文件">原文</th>
                            <th>转换错误日志</th>
                        </tr>
                    </thead>
                    <tbody class="tbody" id="bodyRepeater">
                        <asp:Repeater ID="rpData" runat="server">
                            <ItemTemplate>
                                <tr class='<%#(Container.ItemIndex%2==0)?"bg01":""%>'
                                    onclick="clickbtnView(<%# Eval("LogID")%>,'<%#Eval("gcbm")%>')">
                                    <td>
                                        <input type="checkbox" name="checkOne" value='<%# Eval("LogID")%>' />
                                    </td>
                                    <td><%#Eval("gcbm")%></td>
                                    <td><%#Eval("SingleProjectID")%></td>
                                    <td><%#Eval("FileListID")%></td>
                                    <td><%#Eval("EFileID")%></td>
                                    <td><%#Eval("FileName")%></td>
                                    <td><%# DigiPower.Onlinecol.Standard.Common.ConvertEx.ToDate(Eval("CreateDate")).ToString("yyyy-MM-dd")%></td>
                                    <td>
                                        <%# GetEFileURL(Eval("EFileStartPath").ToString(),Eval("FileName").ToString(),
                                                Eval("SingleProjectID").ToString())%>
                                    </td>
                                    <td style="word-break: break-all;"><%#Eval("Description")%></td>
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
