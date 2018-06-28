<%@ Page Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="FileCellList.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.File.FileCellList" %>

<%@ Register Src="../CommonCtrl/ctrlGridEx.ascx" TagName="ctrlGridEx" TagPrefix="uc2" %>
<%@ Register Src="../CommonCtrl/ctrlHead.ascx" TagName="ctrlHead" TagPrefix="uc1" %>
<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc3" %>
<%@ Register Src="../CommonCtrl/ctrlBtnBack.ascx" TagName="ctrlBtnBack" TagPrefix="uc4" %>
<%--<%@ Register Src="../CommonCtrl/ctrlAuxidict.ascx" TagName="ctrlAuxidict" TagPrefix="uc4" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="../JS/WebCalendar.js"></script>
    <script language="javascript" type="text/javascript">
        //ȫѡ
        var selFlag = true;
        function selectALL() {
            $("input[type='checkbox']").each(function () {
                if ($(this).attr('disabled') != 'disabled') {
                    $(this).attr('checked', selFlag);
                }
            });
            selFlag = !selFlag;
        }

        //����ʩ���ñ�
        function addcllFile() {
            var strURL = "../SystemManage/CellSelectList.aspx?tag=" + new Date().getMilliseconds();
            openCommonWindowScroll(strURL, 880, 620);
        }
        //ɾ��
        function delcllFile() {
            var checkedLen = $("input[type='checkbox']:checked").length;
            if (checkedLen > 0) {
                if (confirm('ȷ��Ҫɾ��ѡ�������ݼ����Ӧ�ĵ����ļ�?')) {
                    $("input[type='checkbox']:checked").each(function () {
                        var len = FileCellList.DeleteFile($(this).val(),<%= ProNo%>).value;
                        window.location.href = window.location.href;
                    });
                }
            } else {
                alert('����ѡ��һ��ſ��Բ���!');
            } 
        }
        //����
        function saveIndex(obj,archiveListCellRptID){
            FileCellList.UpdateEFileIndex(archiveListCellRptID,$('#txtOrderIndex'+archiveListCellRptID).val()).value; 
            window.location.href = window.location.href;    
        }
        //��������
        function batchSaveIndex() {
            var checkedLen = $("input[type='checkbox']:checked").length;
            if (checkedLen > 0) {
                $("input[type='checkbox']:checked").each(function () {
                    var index=$(this).parent().next().next().children().eq(0).val();
                    FileCellList.UpdateEFileIndex($(this).val(),index).value;
                });
                alert('����ɹ�!');
                window.location.href = window.location.href;   
            } else {
                alert('����ѡ��һ��ſ��Բ���!');
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="99%" border="0" cellpadding="0" cellspacing="0" style="margin: 4px 4px; border: solid 1px #8db2e3;">
        <tr>
            <td height="25" class="button_area" style="border: 0px; border-bottom: 1px;">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="margin-top: 2px;">
                    <tr>
                        <td width="10px">&nbsp;&nbsp;&nbsp;
                        </td>
                        <td style="text-align: left;">
                            <asp:Panel runat="server" ID="tblSearch" Width="100%" border="0" cellspacing="0"
                                cellpadding="0">
                            </asp:Panel>
                        </td>
                        <td>
                            <div align="right">
                                &nbsp;
                                <input type="button" value="����ʩ���ñ�" class="button" onclick="addcllFile()" />
                                <asp:Button ID="btnSave" runat="server" CssClass="button"
                                    Text=" �������� " OnClientClick="batchSaveIndex();return false;" />
                                <asp:Button ID="btnDelete" runat="server"
                                    OnClientClick="delcllFile();return false;" CssClass="button" Text=" ɾ�� " />
                                <%-- <uc4:ctrlBtnBack ID="ctrlBtnBack1" runat="server"  SetCssClass="button" />--%>
                                <%--<input type="button" onclick="window.location.href='../WorkFlow/wjdj.aspx?SingleProjectID=<%= Common.DNTRequest.GetQueryString("ProNo")%>&WorkFlowID=<%= Common.DNTRequest.GetQueryString("WorkFlowID")%>'" value=" ���� " class="button" />--%>
                            </div>
                        </td>
                        <td width="30" align="right">
                            <img src="../Images/01.png" border="0" style="margin-right: 4px;" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="text-align: center;">
                <div style="margin-top: 4px; margin-bottom: 4px; border: 0; width: 100%;" id="divgvData">
                    <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField HeaderText="<a style='cursor:pointer;' onclick='selectALL()'>ȫѡ</a>"
                                HeaderStyle-CssClass="tr1" ItemStyle-CssClass="tr1" HeaderStyle-Width="33px" ItemStyle-Width="33px">
                                <ItemTemplate>
                                    <input style="border-bottom-color: blue;" type="checkbox"
                                        name="checkOne" value='<%# Eval("ArchiveListCellRptID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="�ļ�����" DataField="Title" />
                            <asp:TemplateField HeaderText="������" HeaderStyle-Width="80px" ItemStyle-Width="80px">
                                <ItemTemplate>
                                    <input type="text" value="<%# Eval("OrderIndex")%>" style="width: 80px" class="regedit_input"
                                        id="txtOrderIndex<%# Eval("ArchiveListCellRptID")%>" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="����" HeaderStyle-Width="60px" ItemStyle-Width="60px">
                                <ItemTemplate>
                                    <a style="cursor: pointer;" onclick="saveIndex(this,<%# Eval("ArchiveListCellRptID")%>)" title="��������ļ�������">����</a>&nbsp;
                                    <a style="cursor: pointer;" href="CellEdit.aspx?Action=Edit&ProNo=<%= ProNo%>&ID=<%# Eval("ArchiveListCellRptID")%>">��¼</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td style="text-align: center; height: 30px; border: 0px;" class="button_area">
                <webdiyer:AspNetPager ID="AspNetPager" runat="server" PagingButtonSpacing="8px"
                    OnPageChanged="AspNetPager_PageChanged" ShowCustomInfoSection="left" CustomInfoStyle="text-align:left;"
                    FirstPageText="��ҳ" LastPageText="βҳ" NextPageText="��һҳ" PrevPageText="��һҳ" PageIndexBoxStyle="text-align:right;"
                  CustomInfoHTML="<div style='margin-top:6px'>���� <strong>%RecordCount%</strong> ����¼��ÿҳ <strong>%PageSize%</strong> ������ǰ�� <strong>%CurrentPageIndex%</strong> ҳ��ÿҳ<strong> %PageSize%</strong> ������<strong> %PageCount%</strong> ҳ</div>"
                    UrlPaging="false" Width="100%" LayoutType="Table" ShowNavigationToolTip="True"
                    ShowPageIndex="False" HorizontalAlign="Right" PageIndexBoxType="TextBox" ShowPageIndexBox="Always" SubmitButtonText="��ת" TextAfterPageIndexBox="ҳ" TextBeforePageIndexBox="ת��">
                </webdiyer:AspNetPager>
            </td>
        </tr>
    </table>
</asp:Content>
