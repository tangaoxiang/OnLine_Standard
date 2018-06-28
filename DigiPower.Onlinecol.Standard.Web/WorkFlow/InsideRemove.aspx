<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="InsideRemove.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.WorkFlow.InsideRemove" Title=" ������ҳ��" %>

<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc1" %>
<%@ Register Src="../CommonCtrl/ctrlJSCheckInfo.ascx" TagName="ctrlJSCheckInfo" TagPrefix="uc2" %>
<%@ Register Src="../CommonCtrl/ctrlProjectBaseInfo.ascx" TagName="ctrlProjectBaseInfo"
    TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script language="javascript" type="text/javascript">

        //����ID
        function GetSingleProjectID() {
            return $('#HidSingleProjectID').val();
        }
        //��������
        function GetProjectType() {
            return $('#HidProjectType').val();
        }
        function getNewUrl() {
            var url = window.location.href;
            url = Common.urlreplace(url, 'PageIndex', $('#CurrentPageIndex').text());
            url = Common.urlreplace(url, 'rn', Math.random());
            return url;
        }

        //�����ϸ
        function btnCheckList() {
            if (Common.isCheckBoxOneChecked()) {
                var keyList = Common.getChkOneKeyToArray();
                var url = "../WorkFlow/ArchiveCheckList.aspx?SingleProjectID=" + GetSingleProjectID() + "&ArchiveID=" +
                    keyList[0] + "&rn=" + Math.random();
                window.top.parent.ParentOpenDiv('�����Ϣ', url, '900px', '80%');
            }
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
        //����
        function btnBack() {
            window.location.href = '../CompanyManage/AdvSearch.aspx?Archive_Form=<%= DigiPower.Onlinecol.Standard.Common.DNTRequest.GetQueryString("Archive_Form")%>&rn=' + Math.random();
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <input type="hidden" id="HidSingleProjectID" value="<%= singleProjectID%>" />
    <input type="hidden" id="HidProjectType" value="<%= projectType%>" />

    <input type="hidden" id="hidOpenFlag" />

    <uc3:ctrlProjectBaseInfo ID="ctrlProjectBaseInfo1" runat="server" />
    <div class="main-content">
        <div class="content-box-content">
            <div class="tab-content default-tab" id="tab1">
                <div class="anl">
                    <input type="button" id="MrcBtnLookSingle" value="������Ϣ" title="������ϸ��Ϣ" onclick="btnLookSingle()" />
                    <input type="button" id="MrcBtnLookArchive" value="������Ϣ" title="������ϸ��Ϣ" onclick="btnLookArchive()" />
                    <input type="button" id="MrcBtnArchiveToFileList" value="�ļ���ϸ" title="�ļ���ϸ��Ϣ" onclick="btnArchiveToFileList()" />
                    <input type="button" title="ֻ�ܹ�ѡ���ݰ����鿴���������ϸ��Ϣ" value="�����ϸ" onclick="btnCheckList()" />
                    <input type="button" title="�����б�ҳ��" value="����" onclick="Common.fnParentLayerClose()" />
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
                        </tr>
                    </thead>
                    <tbody class="tbody" id="bodyRepeater">
                        <asp:Repeater ID="rpData" runat="server">
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