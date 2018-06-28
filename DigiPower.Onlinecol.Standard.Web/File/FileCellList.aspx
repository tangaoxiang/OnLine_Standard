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
        //全选
        var selFlag = true;
        function selectALL() {
            $("input[type='checkbox']").each(function () {
                if ($(this).attr('disabled') != 'disabled') {
                    $(this).attr('checked', selFlag);
                }
            });
            selFlag = !selFlag;
        }

        //新增施工用表
        function addcllFile() {
            var strURL = "../SystemManage/CellSelectList.aspx?tag=" + new Date().getMilliseconds();
            openCommonWindowScroll(strURL, 880, 620);
        }
        //删除
        function delcllFile() {
            var checkedLen = $("input[type='checkbox']:checked").length;
            if (checkedLen > 0) {
                if (confirm('确定要删除选中行数据及其对应的电子文件?')) {
                    $("input[type='checkbox']:checked").each(function () {
                        var len = FileCellList.DeleteFile($(this).val(),<%= ProNo%>).value;
                        window.location.href = window.location.href;
                    });
                }
            } else {
                alert('必须选择一项才可以操作!');
            } 
        }
        //保存
        function saveIndex(obj,archiveListCellRptID){
            FileCellList.UpdateEFileIndex(archiveListCellRptID,$('#txtOrderIndex'+archiveListCellRptID).val()).value; 
            window.location.href = window.location.href;    
        }
        //批量保存
        function batchSaveIndex() {
            var checkedLen = $("input[type='checkbox']:checked").length;
            if (checkedLen > 0) {
                $("input[type='checkbox']:checked").each(function () {
                    var index=$(this).parent().next().next().children().eq(0).val();
                    FileCellList.UpdateEFileIndex($(this).val(),index).value;
                });
                alert('保存成功!');
                window.location.href = window.location.href;   
            } else {
                alert('必须选择一项才可以操作!');
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
                                <input type="button" value="新增施工用表" class="button" onclick="addcllFile()" />
                                <asp:Button ID="btnSave" runat="server" CssClass="button"
                                    Text=" 批量保存 " OnClientClick="batchSaveIndex();return false;" />
                                <asp:Button ID="btnDelete" runat="server"
                                    OnClientClick="delcllFile();return false;" CssClass="button" Text=" 删除 " />
                                <%-- <uc4:ctrlBtnBack ID="ctrlBtnBack1" runat="server"  SetCssClass="button" />--%>
                                <%--<input type="button" onclick="window.location.href='../WorkFlow/wjdj.aspx?SingleProjectID=<%= Common.DNTRequest.GetQueryString("ProNo")%>&WorkFlowID=<%= Common.DNTRequest.GetQueryString("WorkFlowID")%>'" value=" 返回 " class="button" />--%>
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
                            <asp:TemplateField HeaderText="<a style='cursor:pointer;' onclick='selectALL()'>全选</a>"
                                HeaderStyle-CssClass="tr1" ItemStyle-CssClass="tr1" HeaderStyle-Width="33px" ItemStyle-Width="33px">
                                <ItemTemplate>
                                    <input style="border-bottom-color: blue;" type="checkbox"
                                        name="checkOne" value='<%# Eval("ArchiveListCellRptID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="文件题名" DataField="Title" />
                            <asp:TemplateField HeaderText="排序编号" HeaderStyle-Width="80px" ItemStyle-Width="80px">
                                <ItemTemplate>
                                    <input type="text" value="<%# Eval("OrderIndex")%>" style="width: 80px" class="regedit_input"
                                        id="txtOrderIndex<%# Eval("ArchiveListCellRptID")%>" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作" HeaderStyle-Width="60px" ItemStyle-Width="60px">
                                <ItemTemplate>
                                    <a style="cursor: pointer;" onclick="saveIndex(this,<%# Eval("ArchiveListCellRptID")%>)" title="保存电子文件排序编号">保存</a>&nbsp;
                                    <a style="cursor: pointer;" href="CellEdit.aspx?Action=Edit&ProNo=<%= ProNo%>&ID=<%# Eval("ArchiveListCellRptID")%>">著录</a>
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
                  CustomInfoHTML="<div style='margin-top:6px'>共有 <strong>%RecordCount%</strong> 条记录，每页 <strong>%PageSize%</strong> 条，当前第 <strong>%CurrentPageIndex%</strong> 页，每页<strong> %PageSize%</strong> 条，共<strong> %PageCount%</strong> 页</div>"
                    UrlPaging="false" Width="100%" LayoutType="Table" ShowNavigationToolTip="True"
                    ShowPageIndex="False" HorizontalAlign="Right" PageIndexBoxType="TextBox" ShowPageIndexBox="Always" SubmitButtonText="跳转" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到">
                </webdiyer:AspNetPager>
            </td>
        </tr>
    </table>
</asp:Content>
