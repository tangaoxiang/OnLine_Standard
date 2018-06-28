<%@ Page Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="WFZxyys.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.WorkFlow.WFZxyys" Title="����Ԥ����" %>

<%@ Register Src="../CommonCtrl/ctrlGridEx.ascx" TagName="ctrlGridEx" TagPrefix="uc1" %>
<%@ Register Src="../CommonCtrl/ctrlBtnBack.ascx" TagName="ctrlBtnBack" TagPrefix="uc6" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownCompanyInfo.ascx" TagName="ctrlDropDownCompanyInfo" TagPrefix="uc7" %>
<%--<%@ Register Src="../CommonCtrl/ctrlSiteMap.ascx" TagName="ctrlSiteMap" TagPrefix="uc2" %>--%>
<%@ Register Src="../CommonCtrl/ctrlOptStatus.ascx" TagName="ctrlOptStatus" TagPrefix="uc2" %>
<%@ Register Src="../CommonCtrl/ctrlProjectBaseInfo.ascx" TagName="ctrlProjectBaseInfo"
    TagPrefix="uc3" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownSystemInfo.ascx" TagName="ctrlDropDownSystemInfo"
    TagPrefix="uc4" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownFileList.ascx" TagName="ctrlDropDownFileList"
    TagPrefix="uc5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .regedit_input {
            border-radius: 4px;
            padding: 0px !important;
            font-size: 13px !important;
            border: 1px solid #D5D5D5 !important;
            color: #333 !important;
            height: 17px;
        }

        a {
            cursor: pointer;
        }
    </style>
    <script type="text/javascript">
        var selFlag1 = true;
        var selFlag2 = true;
        function selectALL(flag) {
            if (flag == 1) {
                $("input[type='checkbox'][name='checkOne']").each(function () {
                    if ($(this).attr('disabled') != 'disabled' && Number($(this).attr('IsFolder')) != 1) {
                        $(this).attr('checked', selFlag1);
                    }
                });
                selFlag1 = !selFlag1;
            } else {
                $("input[type='checkbox'][name='checkSubmitflag']").each(function () {
                    if ($(this).attr('disabled') != 'disabled' && Number($(this).attr('IsFolder')) != 1) {
                        $(this).attr('checked', selFlag2);
                    }
                });
                selFlag2 = !selFlag2;
            }
        }
        //����ID
        function GetSingleProjectID() {
            return $('#HidSingleProjectID').val();
        }
        //�鿴�����ļ� 
        function lookPDF(bh, filelistID) {
            if (WFZxyys.RKLookPDFFlag(GetSingleProjectID()).value) {
                var url = "../File/DocumentEdit.aspx?ID=" + filelistID + "&SingleProjectID=" + GetSingleProjectID();
                window.top.Content.CreateTitle('�ļ����[' + bh + ']�鿴�����ļ�', 3, url);
            } else {
                alert("���ڰ�ȫ����,����⹤�̲��ܲ鿴�����ļ�,����鿴,����ϵ����Ա!");
            }
        }
        //����ͨ��
        function yysOK() {
            var checkedLen = $("input[type='checkbox'][name='checkOne']:checked").length;
            if (checkedLen < 1) {
                alert('����ѡ��һ��ſ�������ͨ������!');
                return;
            }
            if (checkedLen > 0) {
                $("input[type='checkbox'][name='checkOne']:checked").each(function () {
                    var remark = $(this).parent().next().next().next().next().next().children().eq(0).val();
                    var mustSubmitFlag = $(this).parent().next().next().next().next().next().next().children().eq(0).attr('checked') == 'checked' ? 1 : 0;
                    WFZxyys.FileAccept($(this).val(), true).value;
                    WFZxyys.UpdateFile($(this).val(), remark, mustSubmitFlag).value;
                });
                alert('�����ɹ�!');
                window.location.href = window.location.href;
            }
        }
        //����δͨ��
        function yysNotPass() {
            var checkedLen = $("input[type='checkbox'][name='checkOne']:checked").length;
            if (checkedLen < 1) {
                alert('����ѡ��һ��ſ������ղ�ͨ������!');
                return;
            }
            if (checkedLen > 0) {
                $("input[type='checkbox'][name='checkOne']:checked").each(function () {
                    var remark = $(this).parent().next().next().next().next().next().children().eq(0).val();
                    var mustSubmitFlag = $(this).parent().next().next().next().next().next().next().children().eq(0).attr('checked') == 'checked' ? 1 : 0;
                    WFZxyys.FileAccept($(this).val(), false).value;
                    WFZxyys.UpdateFile($(this).val(), remark, mustSubmitFlag).value;
                });
                alert('�����ɹ�!');
                window.location.href = window.location.href;
            }
        }
        //����
        function btnSave() {
            var checkedLen = $("input[type='checkbox'][name='checkOne']:checked").length;
            if (checkedLen < 1) {
                alert('����ѡ��һ��ſ��Բ���!');
                return;
            }
            if (checkedLen > 0) {
                $("input[type='checkbox'][name='checkOne']:checked").each(function () {
                    var remark = $(this).parent().next().next().next().next().next().children().eq(0).val();
                    var mustSubmitFlag = $(this).parent().next().next().next().next().next().next().children().eq(0).attr('checked') == 'checked' ? 1 : 0;
                    WFZxyys.UpdateFile($(this).val(), remark, mustSubmitFlag).value;
                });
                alert('�����ɹ�!');
                window.location.href = window.location.href;
            }
        }
        //�ָ�
        function resetStatus() {
            var checkedLen = $("input[type='checkbox'][name='checkOne']:checked").length;
            if (checkedLen < 1) {
                alert('����ѡ��һ��ſ��Բ���!');
                return;
            }
            if (checkedLen > 0) {
                $("input[type='checkbox'][name='checkOne']:checked").each(function () {
                    WFZxyys.ResetStatus($(this).val()).value;
                });
                alert('�����ɹ�!');
                window.location.href = window.location.href;
            }
        }
        //����
        function backHref() {
            if ('<%= workFlowCode.ToUpper()%>' == '<%=DigiPower.Onlinecol.Standard.Web.SystemSet.EumWorkFlowCode.FG_SIGNER.ToString()%>' ||
                '<%= workFlowCode.ToUpper()%>' == '<%=DigiPower.Onlinecol.Standard.Web.SystemSet.EumWorkFlowCode.IMPORT_TO.ToString()%>') {
                window.location.href = 'InsideRemove.aspx?WorkFlowCode=<%= workFlowCode%>&SingleProjectID=<%= singleProjectID%>&WorkFlowID=<%= workFlowID%>';
            } else {
                window.location.href = 'WFArchiveList.aspx?WorkFlowCode=<%= workFlowCode%>&SingleProjectID=<%= singleProjectID%>&WorkFlowID=<%= workFlowID%>';
            }
        }
        //��������
        function addQuestion() {
            var checkedLen = $("input[type='checkbox'][name='checkOne']:checked").length;
            if (checkedLen == 1) {
                $("input[type='checkbox'][name='checkOne']:checked").each(function () {
                    var keyList = ($(this).val() + ',').split(',');
                    var strURL = "addquestion.aspx?ID=" + keyList[0] + "&SingleProjectID=" + GetSingleProjectID();
                    openCommonWindowScroll(strURL, 600, 600);
                });
            } else {
                alert('��������ֻ��ѡ��һ��ſ��Բ���!');
            }
        }
        //�����б�
        function questionList() {
            var strURL = "QuestionList.aspx?strWhere=SingleProjectID=" + GetSingleProjectID();
            openCommonWindowScroll(strURL, 1000, 620);
        }
        //��¼
        function updateFile(filelistID) {
            var strURL = "../File/FileInfoList.aspx?ID=" + filelistID + "&IsView=1&SingleProjectID=" + GetSingleProjectID();
            openCommonWindowScroll(strURL, 880, 710);
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <input type="hidden" id="HidSingleProjectID" value="<%= singleProjectID%>" />
    <input type="hidden" id="Hidworkflowid" value="<%= workFlowID%>" />

    <uc3:ctrlProjectBaseInfo ID="ctrlProjectBaseInfo1" runat="server" />
    <table width="99%" border="0" cellpadding="0" cellspacing="0" style="margin: 4px 4px; border: solid 1px #8db2e3;">
        <tr>
            <td height="25" class="button_area" style="border: 0px; border-bottom: 1px;">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="margin-top: 2px;">
                    <tr>
                        <td width="10px">&nbsp;&nbsp;&nbsp;
                        </td>
                        <td>
                            <div align="left">
                                <asp:Button ID="btnQuestion" runat="server" CssClass="button" OnClientClick="addQuestion();return false;"
                                    Text="��������" />
                                <asp:Button ID="btnQuestionList" runat="server" CssClass="button" OnClientClick="questionList();return false;"
                                    Text="�����б�" />
                            </div>
                        </td>
                        <td>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="right" style="text-align: right;">&nbsp;
                                        <asp:Button ID="btnApprove100" runat="server" CssClass="button"
                                            Visible="false" OnClientClick="btnSave();return false;" Text=" ���� " />
                                        <asp:Button ID="btnApprove101" runat="server" CssClass="button" Text=" �ָ� "
                                            Visible="false" ToolTip="��ʾ�ָ�����һ״̬" OnClientClick="resetStatus();return false;" />
                                        <asp:Button ID="btnApprove004" runat="server"
                                            Visible="false" OnClientClick="yysOK();return false;" CssClass="button" Text="����ͨ��" />
                                        <asp:Button ID="btnApprove005" runat="server"
                                            Visible="false" OnClientClick="yysNotPass();return false;" CssClass="button" Text="���ղ�ͨ��" />
                                        <input type="button" value=" ���� " class="button" onclick="backHref()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="30" align="right">
                            <img src="../Images/01.png" border="0" style="margin-right: 4px;" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td bgcolor="#cbdcec">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="100%" class="STYLE1">
                            <asp:Panel runat="server" ID="tblSearch" Width="100%" border="0" cellspacing="0"
                                cellpadding="0">
                                <table style="text-align: left; width: 100%">
                                    <tr>
                                        <td>
                                            <label>
                                                &nbsp;�ļ����<uc5:ctrlDropDownFileList ID="ctrlDropDownFileList" Width="150" bShowNO="false"
                                                    AutoPostBack="false" runat="server" />
                                                &nbsp;�ļ���</label><asp:TextBox ID="txtTitle" runat="server"
                                                    CssClass="SelectText" Width="80px"></asp:TextBox>
                                            <asp:Button ID="btnSearch" runat="server" class="SelectButton" OnClick="btnSearch_Click"
                                                Text=" ��ѯ " /><uc2:ctrlOptStatus ID="Status" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="text-align: center;">
                <div style="margin-top: 4px; margin-bottom: 4px; border: 0; width: 100%;" id="divgvData">
                    <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvData_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="<a style='cursor:pointer;' onclick='selectALL(1)'>ȫѡ</a>"
                                HeaderStyle-CssClass="tr1" ItemStyle-CssClass="tr1" HeaderStyle-Width="33px" ItemStyle-Width="33px">
                                <ItemTemplate>
                                    <input style="border-bottom-color: blue;" type="checkbox" name="checkOne" <%# SetTextDisabled(Eval("IsFolder"))%>
                                        isfolder='<%# DigiPower.Onlinecol.Standard.Common.ConvertEx.ToInt(Eval("IsFolder"))%>' value='<%# Eval("FileListID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="���" DataField="bh" HeaderStyle-Width="60px" ItemStyle-Width="60px" />
                            <asp:BoundField HeaderText="�ļ�����" DataField="title" />
                            <asp:BoundField HeaderText="ʵ��ҳ��" DataField="ManualCount" HeaderStyle-Width="80px" ItemStyle-Width="80px" />
                            <asp:BoundField HeaderText="�ϴ�ҳ��" DataField="pagescount" HeaderStyle-Width="80px" ItemStyle-Width="80px" />
                            <asp:TemplateField HeaderText="������" HeaderStyle-Width="200px" ItemStyle-Width="200px">
                                <ItemTemplate>
                                    <input type="text" <%# SetTextDisabled(true)%> value="<%# Eval("Remark")%>"
                                        style="width: 200px" class="regedit_input" maxlength="40" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<a style='cursor:pointer;' onclick='selectALL(2)'>��Ҫ�鵵</a>"
                                HeaderStyle-Width="60px" ItemStyle-Width="60px">
                                <ItemTemplate>
                                    <input style="border-bottom-color: blue;" type="checkbox" <%# SetCheckBox(Eval("MustSubmitFlag")) %>
                                        name="checkSubmitflag" value='<%# Eval("FileListID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ԭ��" HeaderStyle-Width="30px" ItemStyle-Width="30px">
                                <ItemTemplate>
                                    <a onclick="lookPDF('<%# Eval("BH")%>',<%# Eval("FileListID")%>)">�鿴</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="��ϸҳ" HeaderStyle-Width="40px" ItemStyle-Width="50px">
                                <ItemTemplate>
                                    <a onclick="updateFile(<%# Eval("FileListID")%>)">��ϸҳ</a>&nbsp;&nbsp;
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
                  CustomInfoHTML="<div style='margin-top:6px'>���� <strong>%RecordCount%</strong> ����¼����ǰ�� <strong>%CurrentPageIndex%</strong> ҳ��ÿҳ<strong> %PageSize%</strong> ������<strong> %PageCount%</strong> ҳ</div>"
                    UrlPaging="false" Width="100%" LayoutType="Table" ShowNavigationToolTip="True"
                    ShowPageIndex="False" HorizontalAlign="Right" PageIndexBoxType="TextBox" ShowPageIndexBox="Always" SubmitButtonText="��ת" TextAfterPageIndexBox="ҳ" TextBeforePageIndexBox="ת��">
                </webdiyer:AspNetPager>
            </td>
        </tr>
    </table>
    <br />
    <br />
</asp:Content>