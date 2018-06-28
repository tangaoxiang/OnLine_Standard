<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="OperationLogList.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.OperationLogList" Title="ϵͳ�����쳣" %>

<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc21" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script language="javascript" type="text/javascript">
        function getNewUrl() {
            var url = window.location.href;
            url = Common.urlreplace(url, 'Description', escape($('#ctl00_Main_txtDescription_TextBox1').val()));
            url = Common.urlreplace(url, 'ddlOperationType', escape($('#ctl00_Main_ddlOperationType').val()));
            url = Common.urlreplace(url, 'PageIndex', $('#CurrentPageIndex').text());
            url = Common.urlreplace(url, 'rn', Math.random());
            return url;
        }
        //ɾ��
        function btnDel() {
            if (Common.isCheckBoxMoreChecked()) {
                layer.confirm('ȷ��Ҫɾ��ѡ��������?', function () {
                    var keyList = Common.getChkMoreKeyListToString(0);
                    OperationLogList.DeleteEFileConvertLog(keyList).value
                    Common.fnLayerAlertAndRefresh("����ɾ���ɹ�");
                });
            }
        }
        //����excel
        function btnExportExcel(obj) {
            if ($(obj).attr("clickflag") == 'ok') {
                if ($("input[type='checkbox'][name='checkOne']").length < 1) {
                    Common.fnLayerAlert('û�����ݿ�ɵ�!');
                    return;
                }
                $(obj).attr("clickflag", "no");
                var exlName = OperationLogList.ExportOperationLogToExcel().value;
                if (exlName.indexOf(ResultState.Failure) > -1) {
                    Common.fnLayerAlert(exlName);
                } else {
                    $(obj).attr("clickflag", "ok");
                    window.parent.location.href = "../ReportPDFDown.aspx?pdfFileName=" + exlName;
                }
            } else {
                layer.alert("�������ڴ�����,���Ժ�.......");
                return;
            }
        }
        //Ԥ��
        function clickbtnView(id) {
            var url = '../SystemManage/OperationLogView.aspx?id=' + id + '&rn=' + Math.random();
            window.top.parent.ParentOpenDiv('ϵͳ������־', url, '900px', '90%');
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
                    <td class="condition">�������ͣ�</td>
                    <td class="c2">
                        <asp:DropDownList ID="ddlOperationType" runat="server" Width="180"></asp:DropDownList>
                    </td>
                    <td class="condition">����˵����</td>
                    <td class="c2">
                        <uc21:ctrlTextBoxEx ID="txtDescription" runat="server" MaxLength="30" />
                    </td>
                    <td class="ss">
                        <asp:Button ID="btnSearch" runat="server" Text=" ��ѯ " OnClick="btnSearch_Click" />
                        <input type="button" value="�� ��" id="btnSearchParRet" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="ss"></div>
        <div class="content-box-content">
            <div class="tab-content default-tab" id="tab1">
                <div class="anl" id="anlButtonList">
                    <input type="button" id="MrcBtnDel" title="ɾ��" onclick="btnDel()" value="ɾ��" />
                    <input type="button" id="MrcBtnExportExcel" title="����Excel" clickflag="ok"
                        onclick="btnExportExcel(this)" value="����" />
                </div>
                <table>
                    <thead>
                        <tr>
                            <th width="30px" style="cursor: pointer;" onclick="Common.selCheckBoxAll(this)" selall="0">ȫѡ</th>
                            <th width="105px">����ʱ��</th>
                            <th width="70px">������</th>
                            <th width="80px">IP</th>
                            <th width="80px">��������</th>
                            <th>����˵��</th>
                        </tr>
                    </thead>
                    <tbody class="tbody" id="bodyRepeater">
                        <asp:Repeater ID="rpData" runat="server">
                            <ItemTemplate>
                                <tr class='<%#(Container.ItemIndex%2==0)?"bg01":""%>' onclick="clickbtnView(<%# Eval("LogID")%>)">
                                    <td>
                                        <input type="checkbox" name="checkOne" value='<%# Eval("LogID")%>' />
                                    </td>
                                    <td><%# DigiPower.Onlinecol.Standard.Common.ConvertEx.ToDate(Eval("CreateDate")).ToString("yyyy-MM-dd HH:mm")%></td>
                                    <td><%#Eval("UserName")%></td>
                                    <td><%#Eval("CreateIP")%></td>
                                    <td style="word-break: break-all;"><%#Eval("OperationTypeName")%></td>
                                    <td style="word-break: break-all;"><%#Eval("ErrorMsg")%></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <div class="pagination" style="height: 23px;">
                    <webdiyer:AspNetPager ID="AspNetPager" runat="server" PagingButtonSpacing="8px"
                        OnPageChanged="AspNetPager_PageChanged" ShowCustomInfoSection="left" CustomInfoStyle="text-align:left;"
                        FirstPageText="��ҳ" LastPageText="βҳ" NextPageText="��һҳ" PrevPageText="��һҳ" PageIndexBoxStyle="text-align:right;"
                        CustomInfoHTML="���� <strong>%RecordCount%</strong> ����¼��ÿҳ <strong>%PageSize%</strong> ������ǰ�� <strong id='CurrentPageIndex'>%CurrentPageIndex%</strong> ҳ����<strong> %PageCount%</strong> ҳ"
                        UrlPaging="false" Width="100%" layouttype="Table" ShowNavigationToolTip="True"
                        ShowPageIndex="False" HorizontalAlign="Right" PageIndexBoxType="TextBox" ShowPageIndexBox="Always" SubmitButtonText="��ת" TextAfterPageIndexBox="ҳ" TextBeforePageIndexBox="ת��" AlwaysShow="True">
                    </webdiyer:AspNetPager>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
