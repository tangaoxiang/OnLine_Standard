<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="SmArchiveToFileList.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.WorkFlow.SmArchiveToFileList" Title="案卷-FileList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">

    <script type="text/javascript">
        function getNewUrl() {
            var url = window.location.href;
            url = Common.urlreplace(url, 'PageIndex', $('#CurrentPageIndex').text());
            url = Common.urlreplace(url, 'rn', Math.random());
            return url;
        }
        //查看电子文件 
        function lookPDF(isFolder, bh, filelistID, SingleProjectID) {
            if (Number(isFolder) == 0) {
                if (SmArchiveToFileList.CheckPdfFileExistsForFileListID(Number(filelistID)).value) {
                    var url = "../File/DocumentEdit.aspx?ID=" + filelistID + "&SingleProjectID=" + SingleProjectID + "&rn=" + Math.random();
                    window.top.parent.ParentOpenDiv('文件编号[' + bh + ']电子文件预览', url, '80%', '95%');
                } else {
                    Common.fnLayerAlert("电子文件在磁盘上不存在!");
                }
            } else {
                Common.fnLayerAlert("目录级没有电子文件!");
            }
        }
        //文件信息修改
        function btnEditFile() {
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                var url = "../File/FileInfoList.aspx?action=" + PageState.Edit + "&ID=" +
                    keyList[0] + "&SingleProjectID=" + keyList[1] + '&type=SuppleMent&rn=' + Math.random();
                Common.fnLayerOpen(false, "100%", "100%", url, true, "文件信息修改成功!");
            }
        }
        //电子文件上传
        function btnLoad() {
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                var url = "SmUpLoadEFileList.aspx?FileListID=" + keyList[0] + "&SingleProjectID=" + keyList[1] + '&rn=' + Math.random();
                Common.fnLayerOpen(false, "100%", "100%", url, false, "");
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <input type="hidden" id="hidOpenFlag" />
    <div class="main-content">
        <div class="content-box-content">
            <div class="tab-content default-tab" id="tab1">
                <div class="anl">
                    <input type="button" value="文件信息修改" title="文件信息修改" onclick="btnEditFile()" />
                    <input type="button" value="电子文件上传" title="电子文件上传" onclick="btnLoad();" />
                    <input type="button" title="返回案卷列表页面" onclick="Common.fnParentLayerClose()" value="返回" />
                </div>
                <table>
                    <thead>
                        <tr>
                            <th width="20px"></th>
                            <th width="80px">文件编号</th>
                            <th>文件题名</th>
                            <th width="140px">责任者</th>
                            <th width="80px">文(图)号</th>
                            <th width="70px">形成日期</th>
                            <th width="60px">实体页数</th>
                            <th width="60px" title="合并后的PDF的页数">上传页数</th>
                            <th width="60px">排序编号</th>
                            <th width="30px">原文</th>
                        </tr>
                    </thead>
                    <tbody class="tbody" id="bodyRepeater">
                        <asp:Repeater ID="rpData" runat="server">
                            <ItemTemplate>
                                <tr class='<%#(Container.ItemIndex%2==0)?"bg01":""%>'>
                                    <td>
                                        <input type="radio" name="radio"
                                            value='<%# Eval("FileListID")%>,<%# Eval("SingleProjectID")%>,<%# Eval("ArchiveID")%>,<%# Eval("bh")%>' /></td>
                                    <td><%#Eval("bh")%></td>
                                    <td><%#Eval("title")%></td>
                                    <td><%#Eval("zrr")%></td>
                                    <td><%#Eval("w_t_h")%></td>
                                    <td><%#Eval("StartTime")%></td>
                                    <td><%#Eval("ManualCount")%></td>
                                    <td><%#Eval("pagescount")%></td>
                                    <td>
                                        <%# Eval("OrderIndex")%>
                                    </td>
                                    <td><%# 
                                            DigiPower.Onlinecol.Standard.Web.PublicModel.getEfileImage(Eval("FileListID").ToString(),Eval("SingleProjectID").ToString(),
                                            Eval("bh").ToString(),DigiPower.Onlinecol.Standard.Common.ConvertEx.ToBool(Eval("IsFolder")))
                                    %></td>
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
