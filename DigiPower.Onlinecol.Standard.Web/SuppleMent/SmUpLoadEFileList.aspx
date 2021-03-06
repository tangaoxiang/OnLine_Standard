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
                Common.fnLayerAlert('只能上传的文件格式为:'+HidFileExt);
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
        //删除
        function delFile() {
            var checkedLen = $("input[type='checkbox']:checked").length;
            if (checkedLen > 0) { 
                layer.confirm('确定要删除选中行数据及其对应的电子文件?', function () {
                    $("input[type='checkbox']:checked").each(function () {
                        var len = SmUpLoadEFileList.DeleteFile($(this).val(),<%= SingleProjectID%>).value;                       
                    });
                    Common.fnLayerAlertAndRefresh("电子文件删除成功!"); 
                });
            } else {
                Common.fnLayerAlert('必须选择一项才可以操作!');
            }
        } 
        //批量保存
        function batchSaveIndex() {
            var checkedLen = $("input[type='checkbox']:checked").length;
            if (checkedLen > 0) {
                $("input[type='checkbox']:checked").each(function () { 
                    var tdAll = $(this).parent().nextAll();
                    SmUpLoadEFileList.UpdateEFileIndex($(this).val(),$(tdAll).eq(4).children(0).val()).value; 
                });
                Common.fnLayerAlertAndRefresh("电子文件序号保存成功!"); 
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
    <asp:HiddenField ID="HidProNo" runat="server" />
    <asp:HiddenField ID="HidFlowid" runat="server" />
    <input type="hidden" id="hidOpenFlag" />
    <div class="main-content">
        <div class="content-box-content">
            <div class="tab-content default-tab" id="tab1">
                <div class="anl">
                    <div class="input-file" style="margin-top: 3px;">
                        <span class="text">选择文件</span>
                        <asp:FileUpload ID="FileUpload1" CssClass="file" onchange="CheckFile(this)" runat="server" />
                    </div>
                    <asp:Button ID="btnUpLoad" runat="server" OnClientClick="return saveSubmit(this);" clickflag="ok"
                        OnClick="btnUpLoad_Click" Text=" 上传 " />
                    <input type="button" title="勾选多个电子文件,保存序号,合并PDF会根据序号来排序"
                        onclick="batchSaveIndex()" value="保存" />
                    <input type="button" title="删除电子文件后,后台程序会自动重新在合并PDF" onclick="delFile()" value="删除" />
                    <input type="button" title="返回到案卷列表页面" onclick="Common.fnParentLayerClose()" value="返回" />
                    <strong id="sgFileName"></strong>
                </div>
                <table>
                    <thead>
                        <tr>
                            <th width="30px" style="cursor: pointer;" onclick="Common.selCheckBoxAll(this)" selall="0">全选</th>
                            <th>文件题名</th>
                            <th width="200px">状态说明</th>
                            <th width="130px">上传时间</th>
                            <th width="130px">PDF转换时间</th>
                            <th width="60px">排序编号</th>
                            <th width="30px">查看</th>
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
                                        <a style="cursor: pointer; border: 0px; color: white;" target="_blank" href="<%# GetEFileURL(Eval          ("RootPath").ToString(),Eval("FilePath").ToString())%>" title="点击下载查看上传的原文">
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
                        FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" PageIndexBoxStyle="text-align:right;"
                        CustomInfoHTML="共有 <strong>%RecordCount%</strong> 条记录，每页 <strong>%PageSize%</strong> 条，当前第 <strong id='CurrentPageIndex'>%CurrentPageIndex%</strong> 页，共<strong> %PageCount%</strong> 页"
                        UrlPaging="false" Width="100%" layouttype="Table" ShowNavigationToolTip="True"
                        ShowPageIndex="False" HorizontalAlign="Right" PageIndexBoxType="TextBox" ShowPageIndexBox="Always" SubmitButtonText="跳转" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" AlwaysShow="True">
                    </webdiyer:AspNetPager>
                </div>
            </div>
        </div>
    </div>

    <script language="javascript" type="text/javascript">
        function saveSubmit(obj) { 
            if($("#ctl00_Main_FileUpload1").val()==""){
                Common.fnLayerAlert("请选择需要上传的电子文件!");
                return false;
            }
            return Common.mouseClick(obj)
        }
    </script>

    <%--  <div class="pagination" style="height: 23px; font-size: 14px;">
        说明:<br />
        1、本系统支传上传电子文件的通用格式包括：<%= DigiPower.Onlinecol.Standard.Web.SystemSet._FILELISTFILEEXT%><br />
        2、保存功能：是指调整上传文件的排列顺序，用户在选择保存后系统将自动按文件顺序将多个文件合并为一个多页PDF文件。             
    </div>--%>
    <input type="hidden" value="<%= DigiPower.Onlinecol.Standard.Web.SystemSet._FILELISTFILEEXT%>" id="HidFileExt" />
</asp:Content>
