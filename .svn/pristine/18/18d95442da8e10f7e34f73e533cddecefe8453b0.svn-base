<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="SelectFileListTpl.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.WorkFlow.SelectFileListTpl" Title="选择文件" %>

<%@ Register Src="../CommonCtrl/ctrlArchiveFormType.ascx" TagName="ctrlArchiveFormType"
    TagPrefix="uc1" %>
<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <style type="text/css">
        select {
            height: 21px;
        }
    </style>
    <script type="text/javascript">
        function btnSelect() {//选择
            if (Common.isCheckBoxMoreChecked()) {
                var keyList = Common.getChkMoreKeyListToString(0) + ",";
                var len = SelectFileListTpl.AddFile(keyList, $("#HidSingleProjectID").val()).value;
                if (len.indexOf(ResultState.Success) > -1) {
                    var index = parent.layer.getFrameIndex(window.name);
                    parent.document.getElementById('hidOpenFlag').value = "1";
                    parent.layer.close(index);
                }
                else {
                    Common.fnLayerAlert(len);
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <input type="hidden" id="HidSingleProjectID" value="<%=DigiPower.Onlinecol.Standard.Common.
     DNTRequest.GetQueryString("SingleProjectID") %>" />
    <input type="hidden" id="hidOpenFlag" />
    <div class="main-content">
        <div class="content-box-search">
            <table id="c1">
                <tr>
                    <td class="condition" style="width: 100px;">文件类别：</td>
                    <td class="c2">
                        <asp:DropDownList ID="ddlFileType" runat="server" Width="155px">
                        </asp:DropDownList>
                    </td>
                    <td class="condition" style="width: 100px;">文件题名：</td>
                    <td class="c2">
                        <uc1:ctrlTextBoxEx runat="server" ID="txtTitle" MaxLength="20" />
                    </td>
                    <td class="ss">
                        <asp:Button ID="btnSearch" runat="server" Text=" 查询 " OnClick="btnSearch_Click" />
                        <input type="button" value="重 置" id="btnSearchParRet" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="content-box-content">
            <div class="tab-content default-tab" id="tab1">
                <div class="anl">
                    <input type="button" id="MrcBtnSelect" value="选择" onclick="btnSelect()" />
                </div>
                <table id="selTbList">
                    <thead>
                        <tr>
                            <th width="30px" style="cursor: pointer;" onclick="Common.selCheckBoxAll(this)"
                                selall="0">全选</th>
                            <th width="80px">编号</th>
                            <th>文件题名</th>
                        </tr>
                    </thead>
                    <tbody class="tbody" id="bodyRepeater">
                        <asp:Repeater ID="rpData" runat="server">
                            <ItemTemplate>
                                <tr class='<%#(Container.ItemIndex%2==0)?"bg01":""%>'>
                                    <td>
                                        <input type="checkbox" name="checkOne"
                                            value='<%# Eval("recid")%>,<%# Eval("PID")%>,<%# Eval("IsFolder")%>' /></td>
                                    <td><%#Eval("bh")%></td>
                                    <td><%#Eval("title")%></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <div class="pagination" style="height: 23px;">
                    <webdiyer:AspNetPager ID="AspNetPager" runat="server" PagingButtonSpacing="8px"
                        OnPageChanged="AspNetPager_PageChanged" ShowCustomInfoSection="left" CustomInfoStyle="text-align:left;"
                        FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" PageIndexBoxStyle="text-align:right;"
                        CustomInfoHTML="共有 <strong>%RecordCount%</strong> 条记录，每页 <strong>%PageSize%</strong> 条，当前第 <strong id='CurrentPageIndex'>%CurrentPageIndex%</strong> 页，共<strong> %PageCount%</strong> 页"
                        UrlPaging="false" Width="100%" layouttype="Table" ShowNavigationToolTip="True"
                        ShowPageIndex="False" HorizontalAlign="Right" PageIndexBoxType="TextBox" ShowPageIndexBox="Always" SubmitButtonText="跳转" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" AlwaysShow="True">
                    </webdiyer:AspNetPager>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
