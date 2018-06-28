<%@ Page Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="SignatureProjectList.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SignatureProjectList" Title="�ҵ�����" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function ViewProject(types) {//�鿴������Ϣ
            if (isCheck()) {
                var keyList = getKeyList();
                if (types == 1) {
                    var strURL = "../companymanage/companyreg3_" + keyList[4] + "edit.aspx?action=view&SingleProjectID=" + keyList[0];
                    openCommonWindowScroll(strURL, 960, 710);
                } else if (types == 2) {
                    var strURL = "../WorkFlow/QuestionList.aspx?strWhere=SingleProjectID=" + keyList[0] + "";
                    openCommonWindowScroll(strURL, 960, 580);
                }
            }
        }

        function btnSignature() {//����ǩ��
            if (isCheck()) {
                var keyList = getKeyList();

                var strURL = "SignatureFilesList.aspx?SingleProjectID=" + keyList[0];
                window.location.href = strURL;

            }
        }



    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <input type="hidden" id="HidSingleProjectID" name="HidSingleProjectID" />
    <input type="hidden" id="HidProjectType" name="HidProjectType" />

    <div style="margin: 0px 2px 0px 0px; padding-left: 0px; border: solid 0px; padding-top: 4px;" align="center">
        <table width="99%" border="0" cellpadding="0" cellspacing="0" style="margin: 4px 4px; border: solid 1px #8db2e3;">
            <tr>
                <td height="25" class="button_area" style="border: 0px; border-bottom: 1px;">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="margin-top: 2px;">
                        <tr>
                            <td width="10px">&nbsp;&nbsp;&nbsp;
                            </td>
                            <td>
                                <div align="left">
                                    <asp:Button ID="btnSingleProjectInfo" runat="server" OnClientClick="ViewProject(1);return false;"
                                        CssClass="button" Text="������Ϣ" />
                                    <label style="color: red; margin-left: 10px;">ֻ����ļ��Ǽ������µĹ��̽��е���ǩ��</label>
                                </div>
                            </td>
                            <td></td>
                            <td width="30" align="right">
                                <asp:Button ID="btnSignature" runat="server" CssClass="button" Visible="true"
                                    OnClientClick="btnSignature();return false;" Text="����ǩ��" />
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
                                                    �������ƣ�</label><asp:TextBox ID="gcmc" runat="server" CssClass="SelectText"></asp:TextBox>
                                                <label>
                                                    &nbsp;���̱�ţ�</label><asp:TextBox ID="gcbm" runat="server" CssClass="SelectText"></asp:TextBox>
                                                &nbsp;<asp:Button ID="btnSearch" runat="server" class="SelectButton" OnClick="btnSearch_Click"
                                                    Text=" ��ѯ " />
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
                        <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderStyle-CssClass="tr1" ItemStyle-CssClass="tr1">
                                    <ItemTemplate>
                                        <input type="checkbox" name="checkOne" onclick="selectOne(this)" value='<%# Eval("SingleProjectID")%>,
                                           <%= workFlowID%> ,<%# Eval("SubmitStatus")%>,<%# Eval("WorkFlowDefineID")%>,<%# Eval("ProjectType")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="��Ŀ����" DataField="ProjectTypeName"
                                    ItemStyle-Width="90px" HeaderStyle-Width="90px" />
                                <asp:BoundField HeaderText="��������" DataField="gcmc" />
                                <asp:TemplateField HeaderText="���̱��" ItemStyle-Width="86px"
                                    ItemStyle-HorizontalAlign="Justify" HeaderStyle-Width="86px">
                                    <ItemTemplate>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="���̵�ַ" DataField="gcdd" />
                                <asp:BoundField HeaderText="�滮����֤��" DataField="ghxkzh" />
                                <asp:BoundField HeaderText="ʩ������֤��" DataField="sgxkzh" />
                                <asp:TemplateField HeaderText="����״̬" HeaderStyle-Width="60px">
                                    <ItemTemplate>
                                        <%# DigiPower.Onlinecol.Standard.Web.PublicModel.GetImageforStatus(DigiPower.Onlinecol.Standard.Common.ConvertEx.ToBool(Eval("SubmitStatus")))%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="�������ʱ��" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                        <%# Eval("SubmitStatus").ToString()!="2"?"":DigiPower.Onlinecol.Standard.Common.ConvertEx.ToDate(Eval("RecvDateTime").ToString()).ToString("yyyy-MM-dd")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="״̬" HeaderStyle-Width="40px" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="text-align: center; height: 30px; border: 0px;" class="button_area">
                    <webdiyer:aspnetpager id="AspNetPager" runat="server" pagingbuttonspacing="8px"
                        onpagechanged="AspNetPager_PageChanged" showcustominfosection="left" custominfostyle="text-align:left;"
                        firstpagetext="��ҳ" lastpagetext="βҳ" nextpagetext="��һҳ" prevpagetext="��һҳ" pageindexboxstyle="text-align:right;"
                        custominfohtml="���� <strong>%RecordCount%</strong> ����¼����ǰ�� <strong>%CurrentPageIndex%</strong> ҳ����<strong> %PageCount%</strong> ҳ"
                        urlpaging="false" width="100%" layouttype="Table" shownavigationtooltip="True"
                        showpageindex="False" horizontalalign="Right" pageindexboxtype="TextBox" showpageindexbox="Always" submitbuttontext="��ת" textafterpageindexbox="ҳ" textbeforepageindexbox="ת��">
                    </webdiyer:aspnetpager>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <br />
</asp:Content>