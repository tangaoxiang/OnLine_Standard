<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="SmArchiveList.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.WorkFlow.SmArchiveList" Title="�����б�" %>

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
        //������Ϣ�޸�
        function btnEditSingleProject() {
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                var url = '../CompanyManage/CompanyReg3_' + Common.getFileTypeForProjectType(keyList[2]) + 'Edit.aspx?action=' +
                        PageState.Edit + '&SingleProjectID=' + keyList[1] + '&ProjectType=' + keyList[2] + '&rn=' + Math.random();
                Common.fnLayerOpen('������Ϣ-�޸�', '100%', '100%', url, true, '������Ϣ�޸ĳɹ�!');
            }
        }
        //������Ϣ�޸�
        function btnEdit() {
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                var url = '../WorkFlow/ArchiveAdd.aspx?action=' + PageState.Edit + '&id=' + keyList[0] + '&rn=' + Math.random();
                Common.fnLayerOpen('������Ϣ-�޸�', "550px", "470px", url, true, "������Ϣ�޸ĳɹ�!");
            }
        }
        //����
        function btnArchiveToBJ() {
            window.top.parent.closeMenu();
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                var url = 'SmZJList.aspx?SingleProjectID=' + keyList[1] + '&ProjectType=' + keyList[2] + '&rn=' + Math.random()
                    + "&ModuleID=<%= DigiPower.Onlinecol.Standard.Common.DNTRequest.GetQueryString("ModuleID")%>";
                Common.fnLayerOpen(false, "100%", "100%", url, true, "");
            }
        }
        //�ļ���ϸ
        function btnArchiveToFileList() {
            window.top.parent.closeMenu();
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                var url = 'SmArchiveToFileList.aspx?action=' + PageState.Edit + '&ArchiveID=' + keyList[0] + '&rn=' + Math.random();
                Common.fnLayerOpen('����-' + keyList[3] + '-' + keyList[4], '100%', '100%', url, false, '');
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <input type="hidden" id="hidOpenFlag" />
    <div class="main-content">
        <div class="content-box-search">
            <table id="c1">
                <tr>
                    <td class="condition">�������ƣ�</td>
                    <td class="c2">
                        <uc1:ctrlTextBoxEx runat="server" ID="txtgcmc" MaxLength="20" />
                    </td>
                    <td class="condition">���̱�ţ�</td>
                    <td class="c2">
                        <uc1:ctrlTextBoxEx runat="server" ID="txtgcbm" MaxLength="10" />
                    </td>
                    <td class="condition">����������</td>
                    <td class="c2">
                        <uc1:ctrlTextBoxEx runat="server" ID="txtajtm" MaxLength="20" />
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
                    <input type="button" id="MrcBtnArchiveToBJ" value="����" onclick="btnArchiveToBJ()" />
                    <input type="button" id="MrcBtnEditSingleProject" value="������Ϣ�޸�" title="�޸Ĺ�����ϸ��Ϣ" onclick="btnEditSingleProject()" />
                    <input type="button" id="MrcBtnEdit" value="������Ϣ�޸�" title="�޸İ�����ϸ��Ϣ" onclick="btnEdit()" />
                    <input type="button" id="MrcBtnArchiveToFileList" value="�ļ���ϸ" onclick="btnArchiveToFileList()" />
                    <strong style="color: red;">ֻ������̽ڵ㴦�ڴ��ڽ��պ͵����ƽ�֮����δ���Ĺ��̽��в������</strong>
                </div>
                <table>
                    <thead>
                        <tr>
                            <th width="20px"></th>
                            <th width="70px">���̱��</th>
                            <th width="200px">��������</th>
                            <th>��������</th>
                            <th width="150px">���Ƶ�λ</th>
                            <th width="70px">������</th>
                            <th width="70px">��������</th>
                            <th width="65px">�������</th>
                        </tr>
                    </thead>
                    <tbody class="tbody" id="bodyRepeater">
                        <asp:Repeater ID="rpData" runat="server">
                            <ItemTemplate>
                                <tr class='<%#(Container.ItemIndex%2==0)?"bg01":""%>'>
                                    <td>
                                        <input type="radio" name="radio"
                                            value='<%# Eval("ArchiveID")%>,<%# Eval("SingleProjectID")%>,
                                                <%# Eval("ProjectType")%>,<%# Eval("xh")%>,<%# Eval("ajtm")%>' /></td>
                                    <td><%#Eval("gcbm")%></td>
                                    <td><%#Eval("gcmc")%></td>
                                    <td><%#Eval("ajtm")%></td>
                                    <td><%#Eval("bzdw")%></td>
                                    <td><%#Eval("lrr")%></td>
                                    <td><%# DigiPower.Onlinecol.Standard.Common.ConvertEx.ToDate(Eval("lrsj")).ToString("yyyy-MM-dd")%></td>
                                    <td>
                                        <%# Eval("xh")%></td>
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
