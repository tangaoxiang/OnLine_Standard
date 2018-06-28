<%@ Page Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="FieldList.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.FieldList" Title="字段管理" %>

<%@ Register Src="../CommonCtrl/ctrlGridEx.ascx" TagName="ctrlGridEx" TagPrefix="uc2" %>
<%--<%@ Register Src="../CommonCtrl/ctrlDropDownTable.ascx" TagName="ctrlDropDownTable"
    TagPrefix="uc1" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        //新增
        function btnAdd() {
            var strURL = "FieldAdd.aspx?Action=add&ID=0&sqlwhere =<%= SqlWhere%>";
            window.location.href = strURL;
        }
        //编辑
        function btnEdit(AreaID) {
            var strURL = 'FieldAdd.aspx?action=edit&ID=' + AreaID;
            window.location.href = strURL;
        }
        //删除
        function delFile() {
            var checkedLen = $("input[type='checkbox']:checked").length;
            if (checkedLen == 1) {
                if (confirm('确定要删除选中中英文字段对照?')) {
                    $("input[type='checkbox']:checked").each(function () {
                        FieldList.DeleteField($(this).val()).value
                        alert('删除成功!');
                        window.location.href = window.location.href;
                    });
                }
            } else {
                alert('必须选择一项才可以操作！');
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
                        <td>&nbsp;
                        </td>
                        <td>
                            <div align="right">
                                &nbsp;
                                <asp:Button ID="btnAdd" runat="server" OnClientClick="btnAdd();return false;" CssClass="button" Text=" 新增 " />
                                <asp:Button ID="btnDelete" OnClientClick="delFile();return false;" runat="server"
                                    CssClass="button" Text=" 删除 " />
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
            <td bgcolor="#cbdcec">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="100%" class="STYLE1">
                            <asp:Panel runat="server" ID="tblSearch" Width="100%" border="0" cellspacing="0"
                                cellpadding="0">
                                <table>
                                    <tr>
                                        <%--<td style="padding-top: 2px; padding-bottom: 2px;">
                                            <asp:Label ID="lbl" runat="server" Text="表名："></asp:Label>
                                            <uc1:ctrlDropDownTable ID="table_name" runat="server" AutoPostBack="true" />
                                        </td>--%>
                                        <td style="padding-top: 2px; padding-bottom: 2px;">
                                            <asp:Label ID="Label1" runat="server" Text="字段名："></asp:Label>
                                            <asp:TextBox ID="column_name" runat="server" CssClass="SelectText"></asp:TextBox>

                                            <asp:Label ID="Label2" runat="server" Text="字段中文名："></asp:Label>
                                            <asp:TextBox ID="column_chn_name" runat="server" CssClass="SelectText"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnSearch" runat="server" Text=" 查询 " class="SelectButton" OnClick="btnSearch_Click" />
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
                                    <input type="checkbox" name="checkOne" onclick="selectOne(this)" value='<%# Eval("FieldID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="字段英文" DataField="column_name"/>
                            <asp:BoundField HeaderText="字段中文名" DataField="column_chn_name" HeaderStyle-Width="30%" ItemStyle-Width="30%"/>
                            <asp:BoundField HeaderText="排序编号" DataField="column_order" HeaderStyle-Width="30%" ItemStyle-Width="30%"/>
                            <asp:TemplateField HeaderText="操作" HeaderStyle-Width="30" ItemStyle-Width="30">
                                <ItemTemplate>
                                    <a style="cursor: pointer;" onclick="btnEdit(<%# Eval("FieldID")%>)">编辑</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td style="text-align: center; height: 30px; border: 0px;" class="button_area">
                <webdiyer:aspnetpager id="AspNetPager" runat="server" pagingbuttonspacing="8px"
                    onpagechanged="AspNetPager_PageChanged" showcustominfosection="left" custominfostyle="text-align:left;"
                    firstpagetext="首页" lastpagetext="尾页" nextpagetext="下一页" prevpagetext="上一页" pageindexboxstyle="text-align:right;"
                 CustomInfoHTML="<div style='margin-top:6px'>共有 <strong>%RecordCount%</strong> 条记录，当前第 <strong>%CurrentPageIndex%</strong> 页，每页<strong> %PageSize%</strong> 条，共<strong> %PageCount%</strong> 页</div>"
                    urlpaging="false" width="100%" layouttype="Table" shownavigationtooltip="True"
                    showpageindex="False" horizontalalign="Right" pageindexboxtype="TextBox" showpageindexbox="Always" submitbuttontext="跳转" textafterpageindexbox="页" textbeforepageindexbox="转到">
                </webdiyer:aspnetpager>
            </td>
        </tr>
    </table>
    <br />
    <br />
</asp:Content>
