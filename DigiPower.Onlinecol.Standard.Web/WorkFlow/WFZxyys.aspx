<%@ Page Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="WFZxyys.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.WorkFlow.WFZxyys" Title="在线预验收" %>

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
        //工程ID
        function GetSingleProjectID() {
            return $('#HidSingleProjectID').val();
        }
        //查看电子文件 
        function lookPDF(bh, filelistID) {
            if (WFZxyys.RKLookPDFFlag(GetSingleProjectID()).value) {
                var url = "../File/DocumentEdit.aspx?ID=" + filelistID + "&SingleProjectID=" + GetSingleProjectID();
                window.top.Content.CreateTitle('文件编号[' + bh + ']查看电子文件', 3, url);
            } else {
                alert("出于安全考虑,已入库工程不能查看电子文件,如需查看,请联系管理员!");
            }
        }
        //验收通过
        function yysOK() {
            var checkedLen = $("input[type='checkbox'][name='checkOne']:checked").length;
            if (checkedLen < 1) {
                alert('必须选择一项才可以验收通过操作!');
                return;
            }
            if (checkedLen > 0) {
                $("input[type='checkbox'][name='checkOne']:checked").each(function () {
                    var remark = $(this).parent().next().next().next().next().next().children().eq(0).val();
                    var mustSubmitFlag = $(this).parent().next().next().next().next().next().next().children().eq(0).attr('checked') == 'checked' ? 1 : 0;
                    WFZxyys.FileAccept($(this).val(), true).value;
                    WFZxyys.UpdateFile($(this).val(), remark, mustSubmitFlag).value;
                });
                alert('操作成功!');
                window.location.href = window.location.href;
            }
        }
        //验收未通过
        function yysNotPass() {
            var checkedLen = $("input[type='checkbox'][name='checkOne']:checked").length;
            if (checkedLen < 1) {
                alert('必须选择一项才可以验收不通过操作!');
                return;
            }
            if (checkedLen > 0) {
                $("input[type='checkbox'][name='checkOne']:checked").each(function () {
                    var remark = $(this).parent().next().next().next().next().next().children().eq(0).val();
                    var mustSubmitFlag = $(this).parent().next().next().next().next().next().next().children().eq(0).attr('checked') == 'checked' ? 1 : 0;
                    WFZxyys.FileAccept($(this).val(), false).value;
                    WFZxyys.UpdateFile($(this).val(), remark, mustSubmitFlag).value;
                });
                alert('操作成功!');
                window.location.href = window.location.href;
            }
        }
        //保存
        function btnSave() {
            var checkedLen = $("input[type='checkbox'][name='checkOne']:checked").length;
            if (checkedLen < 1) {
                alert('必须选择一项才可以操作!');
                return;
            }
            if (checkedLen > 0) {
                $("input[type='checkbox'][name='checkOne']:checked").each(function () {
                    var remark = $(this).parent().next().next().next().next().next().children().eq(0).val();
                    var mustSubmitFlag = $(this).parent().next().next().next().next().next().next().children().eq(0).attr('checked') == 'checked' ? 1 : 0;
                    WFZxyys.UpdateFile($(this).val(), remark, mustSubmitFlag).value;
                });
                alert('操作成功!');
                window.location.href = window.location.href;
            }
        }
        //恢复
        function resetStatus() {
            var checkedLen = $("input[type='checkbox'][name='checkOne']:checked").length;
            if (checkedLen < 1) {
                alert('必须选择一项才可以操作!');
                return;
            }
            if (checkedLen > 0) {
                $("input[type='checkbox'][name='checkOne']:checked").each(function () {
                    WFZxyys.ResetStatus($(this).val()).value;
                });
                alert('操作成功!');
                window.location.href = window.location.href;
            }
        }
        //返回
        function backHref() {
            if ('<%= workFlowCode.ToUpper()%>' == '<%=DigiPower.Onlinecol.Standard.Web.SystemSet.EumWorkFlowCode.FG_SIGNER.ToString()%>' ||
                '<%= workFlowCode.ToUpper()%>' == '<%=DigiPower.Onlinecol.Standard.Web.SystemSet.EumWorkFlowCode.IMPORT_TO.ToString()%>') {
                window.location.href = 'InsideRemove.aspx?WorkFlowCode=<%= workFlowCode%>&SingleProjectID=<%= singleProjectID%>&WorkFlowID=<%= workFlowID%>';
            } else {
                window.location.href = 'WFArchiveList.aspx?WorkFlowCode=<%= workFlowCode%>&SingleProjectID=<%= singleProjectID%>&WorkFlowID=<%= workFlowID%>';
            }
        }
        //在线提问
        function addQuestion() {
            var checkedLen = $("input[type='checkbox'][name='checkOne']:checked").length;
            if (checkedLen == 1) {
                $("input[type='checkbox'][name='checkOne']:checked").each(function () {
                    var keyList = ($(this).val() + ',').split(',');
                    var strURL = "addquestion.aspx?ID=" + keyList[0] + "&SingleProjectID=" + GetSingleProjectID();
                    openCommonWindowScroll(strURL, 600, 600);
                });
            } else {
                alert('必须有且只能选择一项才可以操作!');
            }
        }
        //问题列表
        function questionList() {
            var strURL = "QuestionList.aspx?strWhere=SingleProjectID=" + GetSingleProjectID();
            openCommonWindowScroll(strURL, 1000, 620);
        }
        //著录
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
                                    Text="在线提问" />
                                <asp:Button ID="btnQuestionList" runat="server" CssClass="button" OnClientClick="questionList();return false;"
                                    Text="问题列表" />
                            </div>
                        </td>
                        <td>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="right" style="text-align: right;">&nbsp;
                                        <asp:Button ID="btnApprove100" runat="server" CssClass="button"
                                            Visible="false" OnClientClick="btnSave();return false;" Text=" 保存 " />
                                        <asp:Button ID="btnApprove101" runat="server" CssClass="button" Text=" 恢复 "
                                            Visible="false" ToolTip="表示恢复到上一状态" OnClientClick="resetStatus();return false;" />
                                        <asp:Button ID="btnApprove004" runat="server"
                                            Visible="false" OnClientClick="yysOK();return false;" CssClass="button" Text="验收通过" />
                                        <asp:Button ID="btnApprove005" runat="server"
                                            Visible="false" OnClientClick="yysNotPass();return false;" CssClass="button" Text="验收不通过" />
                                        <input type="button" value=" 返回 " class="button" onclick="backHref()" />
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
                                                &nbsp;文件类别：<uc5:ctrlDropDownFileList ID="ctrlDropDownFileList" Width="150" bShowNO="false"
                                                    AutoPostBack="false" runat="server" />
                                                &nbsp;文件：</label><asp:TextBox ID="txtTitle" runat="server"
                                                    CssClass="SelectText" Width="80px"></asp:TextBox>
                                            <asp:Button ID="btnSearch" runat="server" class="SelectButton" OnClick="btnSearch_Click"
                                                Text=" 查询 " /><uc2:ctrlOptStatus ID="Status" runat="server" />
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
                            <asp:TemplateField HeaderText="<a style='cursor:pointer;' onclick='selectALL(1)'>全选</a>"
                                HeaderStyle-CssClass="tr1" ItemStyle-CssClass="tr1" HeaderStyle-Width="33px" ItemStyle-Width="33px">
                                <ItemTemplate>
                                    <input style="border-bottom-color: blue;" type="checkbox" name="checkOne" <%# SetTextDisabled(Eval("IsFolder"))%>
                                        isfolder='<%# DigiPower.Onlinecol.Standard.Common.ConvertEx.ToInt(Eval("IsFolder"))%>' value='<%# Eval("FileListID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="编号" DataField="bh" HeaderStyle-Width="60px" ItemStyle-Width="60px" />
                            <asp:BoundField HeaderText="文件题名" DataField="title" />
                            <asp:BoundField HeaderText="实体页数" DataField="ManualCount" HeaderStyle-Width="80px" ItemStyle-Width="80px" />
                            <asp:BoundField HeaderText="上传页数" DataField="pagescount" HeaderStyle-Width="80px" ItemStyle-Width="80px" />
                            <asp:TemplateField HeaderText="审核意见" HeaderStyle-Width="200px" ItemStyle-Width="200px">
                                <ItemTemplate>
                                    <input type="text" <%# SetTextDisabled(true)%> value="<%# Eval("Remark")%>"
                                        style="width: 200px" class="regedit_input" maxlength="40" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<a style='cursor:pointer;' onclick='selectALL(2)'>需要归档</a>"
                                HeaderStyle-Width="60px" ItemStyle-Width="60px">
                                <ItemTemplate>
                                    <input style="border-bottom-color: blue;" type="checkbox" <%# SetCheckBox(Eval("MustSubmitFlag")) %>
                                        name="checkSubmitflag" value='<%# Eval("FileListID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="原文" HeaderStyle-Width="30px" ItemStyle-Width="30px">
                                <ItemTemplate>
                                    <a onclick="lookPDF('<%# Eval("BH")%>',<%# Eval("FileListID")%>)">查看</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="详细页" HeaderStyle-Width="40px" ItemStyle-Width="50px">
                                <ItemTemplate>
                                    <a onclick="updateFile(<%# Eval("FileListID")%>)">详细页</a>&nbsp;&nbsp;
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
                    FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" PageIndexBoxStyle="text-align:right;"
                  CustomInfoHTML="<div style='margin-top:6px'>共有 <strong>%RecordCount%</strong> 条记录，当前第 <strong>%CurrentPageIndex%</strong> 页，每页<strong> %PageSize%</strong> 条，共<strong> %PageCount%</strong> 页</div>"
                    UrlPaging="false" Width="100%" LayoutType="Table" ShowNavigationToolTip="True"
                    ShowPageIndex="False" HorizontalAlign="Right" PageIndexBoxType="TextBox" ShowPageIndexBox="Always" SubmitButtonText="跳转" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到">
                </webdiyer:AspNetPager>
            </td>
        </tr>
    </table>
    <br />
    <br />
</asp:Content>
