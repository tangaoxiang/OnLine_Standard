<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="WFArchiveList.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.WorkFlow.WFArchiveList" Title="���ڽ���,ҵ����� ����ҳ��" %>

<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc1" %>
<%@ Register Src="../CommonCtrl/ctrlJSCheckInfo.ascx" TagName="ctrlJSCheckInfo" TagPrefix="uc2" %>
<%@ Register Src="../CommonCtrl/ctrlProjectBaseInfo.ascx" TagName="ctrlProjectBaseInfo"
    TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script language="javascript" type="text/javascript">
        //��������
        function GetProjectType() {
            return $('#HidProjectType').val();
        }
        //����ID
        function GetSingleProjectID() {
            return $('#HidSingleProjectID').val();
        }
        //����ID
        function GetWorkFlowID() {
            return $('#HidworkFlowID').val();
        }
        function getNewUrl() {
            var url = window.location.href;
            url = Common.urlreplace(url, 'PageIndex', $('#CurrentPageIndex').text());
            url = Common.urlreplace(url, 'rn', Math.random());
            return url;
        }
        //���
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
                Common.fnLayerOpen("���", "480px", "350px", url, true, "������!");
            } else {
                Common.fnLayerAlert('����ѡ��һ��ſ��Բ���!');
            }
        }
        //�����ϸ
        function btnCheckList() {
            if (Common.isCheckBoxOneChecked()) {
                var keyList = Common.getChkOneKeyToArray();
                var url = "../WorkFlow/ArchiveCheckList.aspx?SingleProjectID=" + GetSingleProjectID() + "&ArchiveID=" + keyList[0] + "&rn=" + Math.random();
                window.top.parent.ParentOpenDiv('�����Ϣ', url, '900px', '80%');
            }
        }
        //�쵼ǩ��
        function btnShqd() {
            var len = WFArchiveList.SingleProjectSubmit(GetSingleProjectID(), GetWorkFlowID()).value;
            if (len) {
                layer.alert("ȷ�ϳɹ�,���̽��ύ����һ����!", { btnAlign: 'c' }, function (index) {
                    layer.close(index);
                    Common.fnParentLayerCloseAndRefresh();
                });
            } else {
                Common.fnLayerAlert("�ύʧ��,���Ժ����ԣ�");
            }
        }
        //�������
        function btnArchiveRK() {
            var len = WFArchiveList.SingleProjectRK(GetSingleProjectID()).value;
            layer.alert("���ɹ�,�����ĵȴ�����,����,�ļ�,�����ļ����ݽ����ύ���ݲ�ϵͳ!", { btnAlign: 'c' }, function (index) {
                layer.close(index);
                Common.fnParentLayerCloseAndRefresh();
            });
        }
        //������Ϣ
        function btnLookSingle() {
            var height = "100%";
            if (screen.height >= 900) height = "680px";
            window.top.parent.ParentOpenDiv('������Ϣ-Ԥ��', '../CompanyManage/CompanyReg3_' +
                Common.getFileTypeForProjectType(GetProjectType()) + 'Edit.aspx?action=' + PageState.View + '&SingleProjectID=' +
                GetSingleProjectID() + '&rn=' + Math.random() + '&ProjectType=' + GetProjectType(), '900px', height);
        }
        //������Ϣ
        function btnLookArchive() {
            if (Common.isCheckBoxOneChecked()) {
                var keyList = Common.getChkOneKeyToArray();
                var url = 'ArchiveAdd.aspx?action=' + PageState.View + '&id=' + keyList[0] + '&rn=' + Math.random();
                Common.fnLayerOpen('������Ϣ', "550px", "470px", url, false, "");
            }
        }
        //�ļ���ϸ
        function btnArchiveToFileList() {
            if (Common.isCheckBoxOneChecked()) {
                var keyList = Common.getChkOneKeyToArray();
                var url = 'ArchiveToFileList.aspx?action=' + PageState.View + '&ArchiveID=' + keyList[0] + '&rn=' + Math.random();
                Common.fnLayerOpen('����-' + keyList[2] + '-' + keyList[1], "100%", "100%", url, false, "");
            }
        }

        //��ӡ����
        function AgainReportExportPDF(title, reportCode, width, height) {
            var existsFlag = WFArchiveList.CheckExistsReportPDF(GetSingleProjectID(), reportCode).value;
            if (existsFlag) {
                layer.confirm('��ӡ�ı����Ѿ�����,�Ƿ����´�ӡ?', { btn: ['��', '��'] }, function (index) { //��
                    opSubmittedInfo(title, width, height, GetSingleProjectID(), reportCode, true);
                    layer.close(index);
                }, function (index) { //��
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
                window.top.parent.ParentOpenDiv('����Ԥ��', url, '80%', '98%');
                $("#hidOpenFlag").val('0');
            } else {
                Common.fnLayerAlert('����PDF��ӡʧ��,����ԭ��:' + pdfFileName);
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
                    <td class="condition">����������</td>
                    <td class="c2 c3">
                        <uc1:ctrlTextBoxEx runat="server" ID="txtTitle" MaxLength="20" width="140" />
                    </td>
                    <td class="condition">������ţ�</td>
                    <td class="c2">
                        <uc1:ctrlTextBoxEx runat="server" ID="txtXH" MaxLength="4" width="140" />
                    </td>
                    <td class="condition">���״̬��</td>
                    <td class="c2">
                        <asp:DropDownList runat="server" ID="ddlChkStatus" Width="145">
                            <asp:ListItem Value="" Text="----��ѡ��----"></asp:ListItem>
                            <asp:ListItem Value="2" Text="δ���"></asp:ListItem>
                            <asp:ListItem Value="0" Text="���δͨ��"></asp:ListItem>
                            <asp:ListItem Value="1" Text="���ͨ��"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="ss">
                        <asp:Button ID="btnSearch" runat="server" Text=" ��ѯ " OnClick="btnSearch_Click" />
                        <input type="button" value="�� ��" id="btnSearchParRet" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="content-box-content">
            <div class="tab-content default-tab" id="tab1">
                <div class="anl" id="anlButtonList">
                    <input type="button" id="MrcBtnLookSingle" value="������Ϣ" onclick="btnLookSingle()" />
                    <input type="button" id="MrcBtnLookArchive" value="������Ϣ" onclick="btnLookArchive()" />
                    <input type="button" id="MrcBtnArchiveToFileList" value="�ļ���ϸ" onclick="btnArchiveToFileList()" />
                    <input type="button" id="MrcBtnRKZ" value="��ӡ�Ͽ������" onclick="AgainReportExportPDF('���蹤�̵����Ͽ������', 'RKZ', '540px', '350px')" />
                    <input type="button" id="MrcBtnCheck" title="��ѡ�������,���Զ�ѡ" value="���" onclick="btnCheck()" />
                    <input type="button" id="MrcBtnLookArchiveList" title="ֻ�ܹ�ѡ���ݰ���鿴" value="�����ϸ" onclick="btnCheckList()" />
                    <input type="button" id="MrcBtnSHQD" title="���ȷ�����ύ���̵���һ����" value="���ȷ��" onclick="btnShqd()" />
                    <input type="button" id="MrcBtnZMS" value="��ӡ�ƽ�֤����" onclick="AgainReportExportPDF('���蹤�̵����ƽ�֤����', 'ZMS', '560px', '400px')" />
                    <input type="button" id="MrcBtnArchiveRK" value="�������" onclick="btnArchiveRK()" />
                    <input type="button" id="MrcBtnBack" title="�����б�ҳ��" value="����" onclick="Common.fnParentLayerCloseAndRefresh()" />
                </div>
                <table>
                    <thead>
                        <tr>
                            <th width="30px" style="cursor: pointer;" onclick="Common.selCheckBoxAll(this)"
                                selall="0">ȫѡ</th>
                            <th>��������</th>
                            <th width="180px">���Ƶ�λ</th>
                            <th width="55px">��������</th>
                            <th width="65px">������</th>
                            <th width="70px">��������</th>
                            <th width="55px">�������</th>
                            <th width="60px">���״̬</th>
                            <th width="60px">�����Ϣ</th>
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
