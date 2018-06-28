<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="ArchiveToFileList.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.WorkFlow.ArchiveToFileList" Title="案卷-FileList" %>

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
                if (ArchiveToFileList.RKLookPDFFlag(SingleProjectID).value) {
                    if (ArchiveToFileList.CheckPdfFileExistsForFileListID(Number(filelistID)).value) {
                        var url = "../File/DocumentEdit.aspx?ID=" + filelistID + "&SingleProjectID=" + SingleProjectID + "&rn=" + Math.random();
                        window.top.parent.ParentOpenDiv('文件编号[' + bh + ']电子文件预览', url, '80%', '95%');
                    } else {
                        Common.fnLayerAlert("电子文件在磁盘上不存在!");
                    }
                } else {
                    Common.fnLayerAlert("出于安全考虑,已入库工程不能查看电子文件,如需查看,请联系管理员!");
                }
            } else {
                Common.fnLayerAlert("目录级没有电子文件!");
            }
        }
        //批量更新
        function batchUpdateXH() {
            var checkedLen = $("input[type='checkbox']:checked").length;
            if (checkedLen > 0) {
                $("input[type='checkbox']:checked").each(function () {
                    var tdAll = $(this).parent().nextAll();
                    var keyList = ($(this).val() + ',').split(',');
                    ArchiveToFileList.UpdateFileOrderIndex(keyList[0], $(tdAll).eq(7).children(0).val()).value;
                });
                Common.fnLayerAlertAndRefresh("文件序号更新成功!");
            } else {
                Common.fnLayerAlert('必须选择一项才可以操作!');
            }
        }
        //文件信息
        function btnZL() {
            if (Common.isCheckBoxOneChecked()) {
                var keyList = Common.getChkOneKeyToArray();
                var height = "520px";
                if (screen.height < 768) height = "100%";
                window.top.parent.ParentOpenDiv("文件编号[" + keyList[3] + "]详细信息", "../File/FileInfoList.aspx?action=" + PageState.View + "&ID=" +
                    keyList[0] + "&SingleProjectID=" + keyList[1] + '&rn=' + Math.random(), '820px', height);
            }
        }
        //拆文件
        function batchDelete() {
            var checkedLen = $("input[type='checkbox']:checked").length;
            if (checkedLen > 0) {
                $("input[type='checkbox']:checked").each(function () {
                    var tdAll = $(this).parent().nextAll();
                    var keyList = ($(this).val() + ',').split(',');
                    ArchiveToFileList.DeleteFile(keyList[0]).value;
                });
                Common.fnLayerAlertAndRefresh("操作成功!");
            } else {
                Common.fnLayerAlert('必须选择一项才可以操作!');
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
    <input type="hidden" id="hidOpenFlag" />
    <div class="main-content">
        <div class="content-box-search">
            <div class="content-box-content">
                <div class="tab-content default-tab" id="tab1">
                    <div class="anl">
                        <input type="button" value="文件信息" title="文件详细信息" onclick="btnZL()" />
                        <input type="button" id="MrcBtnBatchUpdateXH" onclick="batchUpdateXH();"
                            title="可多选更新文件序号" value="批量更新" />
                        <input type="button" id="MrcBtnBatchDelete" onclick="batchDelete();"
                            title="拆卷,解除文件和案卷的关系" value="删除" />
                        <input type="button" title="返回案卷列表页面" onclick="Common.fnParentLayerClose()" value="返回" />
                    </div>
                    <table>
                        <thead>
                            <tr>
                                <th width="30px" style="cursor: pointer;" onclick="Common.selCheckBoxAll(this)"
                                    selall="0">全选</th>
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
                                            <input type="checkbox" name="checkOne"
                                                value='<%# Eval("FileListID")%>,<%# Eval("SingleProjectID")%>,<%# Eval("ArchiveID")%>,<%# Eval("bh")%>' /></td>
                                        <td><%#Eval("bh")%></td>
                                        <td><%#Eval("title")%></td>
                                        <td><%#Eval("zrr")%></td>
                                        <td><%#Eval("w_t_h")%></td>
                                        <td><%#Eval("StartTime")%></td>
                                        <td><%#Eval("ManualCount")%></td>
                                        <td><%#Eval("pagescount")%></td>
                                        <td>
                                            <input type="text" value="<%# Eval("OrderIndex")%>" name="OrderIndex" class="regedit_input" maxlength="4" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" />
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
    </div>
</asp:Content>
