<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="SmUpLoadEFileList.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.File.SmUpLoadEFileList" %>

<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script language="javascript" type="text/javascript">      
        function getNewUrl() {
            var url = window.location.href; 
            url = Common.urlreplace(url, 'PageIndex', $('#CurrentPageIndex').text());
            url = Common.urlreplace(url, 'rn', Math.random());
            return url;
        }
        function CheckFile(obj) {
            var HidFileExt=$("#HidFileExt").val().toLocaleLowerCase();
            var spCount = obj.value.split('.');
            var fileExt = spCount[spCount.length - 1].toLowerCase();
            if (HidFileExt.indexOf(fileExt)<0) {
                Common.fnLayerAlert('ֻ���ϴ����ļ���ʽΪ:'+HidFileExt);
                if (!window.addEventListener) {
                    obj.outerHTML += '';
                }
                else {
                    obj.value = '';
                }
                $("#sgFileName").text("")
                return;
            } else{
                $("#sgFileName").text(obj.value) ;
            }
        } 
        //ɾ��
        function delFile() {
            var checkedLen = $("input[type='checkbox']:checked").length;
            if (checkedLen > 0) { 
                layer.confirm('ȷ��Ҫɾ��ѡ�������ݼ����Ӧ�ĵ����ļ�?', function () {
                    $("input[type='checkbox']:checked").each(function () {
                        var len = SmUpLoadEFileList.DeleteFile($(this).val(),<%= SingleProjectID%>).value;                       
                    });
                    Common.fnLayerAlertAndRefresh("�����ļ�ɾ���ɹ�!"); 
                });
            } else {
                Common.fnLayerAlert('����ѡ��һ��ſ��Բ���!');
            }
        } 
        //��������
        function batchSaveIndex() {
            var checkedLen = $("input[type='checkbox']:checked").length;
            if (checkedLen > 0) {
                $("input[type='checkbox']:checked").each(function () { 
                    var tdAll = $(this).parent().nextAll();
                    SmUpLoadEFileList.UpdateEFileIndex($(this).val(),$(tdAll).eq(4).children(0).val()).value; 
                });
                Common.fnLayerAlertAndRefresh("�����ļ���ű���ɹ�!"); 
            } else {
                Common.fnLayerAlert('����ѡ��һ��ſ��Բ���!');
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
    <asp:HiddenField ID="HidProNo" runat="server" />
    <asp:HiddenField ID="HidFlowid" runat="server" />
    <input type="hidden" id="hidOpenFlag" />
    <div class="main-content">
        <div class="content-box-content">
            <div class="tab-content default-tab" id="tab1">
                <div class="anl">
                    <div class="input-file" style="margin-top: 3px;">
                        <span class="text">ѡ���ļ�</span>
                        <asp:FileUpload ID="FileUpload1" CssClass="file" onchange="CheckFile(this)" runat="server" />
                    </div>
                    <asp:Button ID="btnUpLoad" runat="server" OnClientClick="return saveSubmit(this);" clickflag="ok"
                        OnClick="btnUpLoad_Click" Text=" �ϴ� " />
                    <input type="button" title="��ѡ��������ļ�,�������,�ϲ�PDF��������������"
                        onclick="batchSaveIndex()" value="����" />
                    <input type="button" title="ɾ�������ļ���,��̨������Զ������ںϲ�PDF" onclick="delFile()" value="ɾ��" />
                    <input type="button" title="���ص������б�ҳ��" onclick="Common.fnParentLayerClose()" value="����" />
                    <strong id="sgFileName"></strong>
                </div>
                <table>
                    <thead>
                        <tr>
                            <th width="30px" style="cursor: pointer;" onclick="Common.selCheckBoxAll(this)" selall="0">ȫѡ</th>
                            <th>�ļ�����</th>
                            <th width="200px">״̬˵��</th>
                            <th width="130px">�ϴ�ʱ��</th>
                            <th width="130px">PDFת��ʱ��</th>
                            <th width="60px">������</th>
                            <th width="30px">�鿴</th>
                        </tr>
                    </thead>
                    <tbody class="tbody" id="bodyRepeater">
                        <asp:Repeater ID="rpData" runat="server">
                            <ItemTemplate>
                                <tr class='<%#(Container.ItemIndex%2==0)?"bg01":""%>'>
                                    <td>
                                        <input type="checkbox" name="checkOne" value='<%# Eval("ArchiveListCellRptID")%>' />
                                    </td>
                                    <td><%#Eval("Title")%></td>
                                    <td><%#Eval("status_text")%></td>
                                    <td><%#Eval("Create_dt")%></td>
                                    <td><%#Eval("convert_dt")%></td>
                                    <td>
                                        <input type="text" value="<%# Eval("OrderIndex")%>" name="OrderIndex" class="regedit_input" maxlength="4" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" />
                                    </td>
                                    <td>
                                        <a style="cursor: pointer; border: 0px; color: white;" target="_blank" href="<%# GetEFileURL(Eval          ("RootPath").ToString(),Eval("FilePath").ToString())%>" title="������ز鿴�ϴ���ԭ��">
                                            <img src="../Javascript/Layer/image/EFILE.png" alt="" />
                                        </a>
                                    </td>
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

    <script language="javascript" type="text/javascript">
        function saveSubmit(obj) { 
            if($("#ctl00_Main_FileUpload1").val()==""){
                Common.fnLayerAlert("��ѡ����Ҫ�ϴ��ĵ����ļ�!");
                return false;
            }
            return Common.mouseClick(obj)
        }
    </script>

    <%--  <div class="pagination" style="height: 23px; font-size: 14px;">
        ˵��:<br />
        1����ϵͳ֧���ϴ������ļ���ͨ�ø�ʽ������<%= DigiPower.Onlinecol.Standard.Web.SystemSet._FILELISTFILEEXT%><br />
        2�����湦�ܣ���ָ�����ϴ��ļ�������˳���û���ѡ�񱣴��ϵͳ���Զ����ļ�˳�򽫶���ļ��ϲ�Ϊһ����ҳPDF�ļ���             
    </div>--%>
    <input type="hidden" value="<%= DigiPower.Onlinecol.Standard.Web.SystemSet._FILELISTFILEEXT%>" id="HidFileExt" />
</asp:Content>