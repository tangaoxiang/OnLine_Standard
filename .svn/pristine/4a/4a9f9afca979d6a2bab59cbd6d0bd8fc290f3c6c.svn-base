<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="RkzCertificateList.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.Report.RkzCertificateList" Title="机构管理" %>

<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc1" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownSystemInfo.ascx" TagName="ctrlDropDownSystemInfo"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script language="javascript" type="text/javascript">
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
        //导出excel
        function btnExportExcel(obj) {
            if ($(obj).attr("clickflag") == 'ok') {
                if ($("input[type='checkbox'][name='checkOne']").length < 1) {
                    Common.fnLayerAlert('没有数据库可导!');
                    return;
                }
                $(obj).attr("clickflag", "no");
                var r1 = escape($('#ctl00_Main_txtReadyCheckBookCode_TextBox1').val());
                var r2 = escape($('#ctl00_Main_txtGcbm_TextBox1').val());
                var r3 = escape($('#ctl00_Main_txtGcmc_TextBox1').val());

                var exlName = RkzCertificateList.ExportExcel(r1, r2, r3).value;
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
    </script>
    <style type="text/css">
        select {
            height: 21px;
        }

        .c3 {
            width: 190px !important;
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
                            CurrentType="Archive_Form" Width="173" />
                    </td>
                    <td class="condition">证书编号：</td>
                    <td class="c2 c3">
                        <uc1:ctrlTextBoxEx runat="server" ID="txtReadyCheckBookCode" MaxLength="20" />
                    </td>
                    <td class="condition">证书发放情况：</td>
                    <td class="c2 c3">
                        <asp:DropDownList runat="server" ID="ddlReadyCheckBookType" Width="186">
                            <%--<asp:ListItem Text="请选择" Value=""></asp:ListItem>--%>
                            <asp:ListItem Text="已发放" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="未发放" Value="0"></asp:ListItem>
                        </asp:DropDownList>
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
                        <td class="condition">工程编号：</td>
                        <td class="c2 c3">
                            <uc1:ctrlTextBoxEx runat="server" ID="txtGcbm" MaxLength="20" width="170" />
                        </td>
                        <td class="condition">工程名称：</td>
                        <td class="c2 c3">
                            <uc1:ctrlTextBoxEx runat="server" ID="txtGcmc" MaxLength="20" />
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
                    <input type="button" id="MrcBtnLookSingle" value="工程信息" onclick="btnLookSingle()" />
                    <input type="button" id="MrcBtnExportExcel" title="导出Excel"
                        clickflag="ok" onclick="btnExportExcel(this)" value="导出" />
                </div>
                <table>
                    <thead>
                        <tr>
                            <th width="30px" style="cursor: pointer;" onclick="Common.selCheckBoxAll(this)"
                                selall="0">全选</th>
                            <th width="80px">证书类型</th>
                            <th width="100px">证书编号</th>
                            <th width="70px">工程编号</th>
                            <th>工程名称</th>
                            <th width="110px">证书发放情况</th>
                            <th width="80px">发放人</th>
                            <th width="80px">发放时间</th>
                        </tr>
                    </thead>
                    <tbody class="tbody" id="bodyRepeater">
                        <asp:Repeater ID="rpData" runat="server">
                            <ItemTemplate>
                                <tr class='<%#(Container.ItemIndex%2==0)?"bg01":""%>'>
                                    <td>
                                        <input type="checkbox" name="checkOne"
                                            value='<%# Eval("ReadyCheckBookID")%>,<%# Eval("keySingleProjectID")%>,<%# Eval("ProjectType")%>' />
                                    </td>
                                    <td>认可证</td>
                                    <td><%#Eval("ReadyCheckBookCode")%></td>
                                    <td><%#Eval("gcbm")%></td>
                                    <td><%#Eval("gcmc")%></td>
                                    <td><%#Convert.ToInt16(Eval("lenReadyCheckBookCode"))>0?"已发放":"未发放"%></td>
                                    <td><%#Convert.ToInt16(Eval("lenReadyCheckBookCode"))>0? Eval("CreateUserName"):""%></td>
                                    <td><%#Convert.ToInt16(Eval("lenReadyCheckBookCode"))>0? Convert.ToDateTime(Eval("CreateTime")).ToString("yyyy-MM-dd"):""%></td>
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
