<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="FileListTmpList.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.FileListTmpList" Title="归档目录模板管理" %>

<%@ Register Src="../CommonCtrl/ctrlArchiveFormType.ascx" TagName="ctrlArchiveFormType"
    TagPrefix="uc1" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownFileListTmp.ascx" TagName="ctrlDropDownFileListTmp"
    TagPrefix="uc3" %>
<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc21" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script language="javascript" type="text/javascript">
        function getNewUrl() {
            var url = window.location.href;
            url = Common.urlreplace(url, 'archive_form_no', escape($('#ctl00_Main_archive_form_no_ddlArchiveFormType').val()));
            url = Common.urlreplace(url, 'PID', escape($('#ctl00_Main_PID_ddlModule').val()));
            url = Common.urlreplace(url, 'Title', escape($('#ctl00_Main_txtTitle_TextBox1').val()));
            url = Common.urlreplace(url, 'SignatureType', ($('#ctl00_Main_chkSignature').is(":checked") ? 1 : 0));
            url = Common.urlreplace(url, 'PageIndex', $('#CurrentPageIndex').text());
            url = Common.urlreplace(url, 'rn', Math.random());
            return url;
        }
        //新增
        function btnAdd() {
            var selKey = Common.getRadioKeyToArray();
            var url = 'FileListTmpAdd.aspx?action=' + PageState.Add + '&id=0&rn=' + Math.random();
            if (selKey.length > 0)
                url = 'FileListTmpAdd.aspx?action=' + PageState.Add + '&id=' + selKey[0] + '&rn=' + Math.random();

            Common.fnLayerOpen('归档目录-新增', "600px", "470px", url, true, "归档目录新增成功!");
        }
        //编辑
        function btnEdit() {
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                var url = 'FileListTmpAdd.aspx?action=' + PageState.Edit + '&id=' + keyList[0] + '&rn=' + Math.random()
                Common.fnLayerOpen('归档目录-修改', "600px", "470px", url, true, "归档目录修改成功!");
            }
        }
        //删除
        function btnDel() {
            if (Common.isRadioCheck()) {
                layer.confirm('确定要删除选中归档目录?<br/>' + Common.getRedStrongString("注意:目录下有子目录则不能删除!"), function () {
                    var keyList = Common.getRadioKeyToArray();
                    if (FileListTmpList.DeleteFileListTmp(keyList[0]).value) {
                        Common.fnLayerAlertAndRefresh("归档目录删除成功!");
                    } else {
                        Common.fnLayerAlert("目录下有子目录则不能删除!");
                    }
                });
            }
        }
        //签章流程设置
        function btnSignature() {
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                if (Number(keyList[1]) == 0) {
                    var url = 'HookUpSignature.aspx?FileListID=' + keyList[0] + '&SignatureTypeCount=' + keyList[2] + '&rn=' + Math.random()
                    Common.fnLayerOpen('签章流程设置-' + keyList[3], "600px", "470px", url, true, "文件签章流程设置成功!");
                } else {
                    Common.fnLayerAlert("目录级不用做签章流程设置!");
                }
            }
        }
    </script>
    <style type="text/css">
        select {
            height: 21px;
            width: 155px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <input type="hidden" id="hidOpenFlag" />
    <div class="main-content">
        <div class="content-box-search">
            <table id="c1">
                <tr>
                    <td class="condition">文件类别：</td>
                    <td class="c2">
                        <uc1:ctrlArchiveFormType ID="archive_form_no" runat="server" AutoPostBack="true" />
                    </td>
                    <td class="condition">上级分类：</td>
                    <td class="c2">
                        <uc3:ctrlDropDownFileListTmp ID="PID" runat="server" AutoPostBack="false" />
                    </td>
                    <td class="condition">文件题名：</td>
                    <td class="c2">
                        <uc21:ctrlTextBoxEx ID="txtTitle" runat="server" MaxLength="20" />
                    </td>
                    <td>是否已签章设置：
                        <asp:CheckBox runat="server" ID="chkSignature" />
                    </td>
                    <td class="ss">
                        <asp:Button ID="btnSearch" runat="server" Text=" 查询 " OnClick="btnSearch_Click" />
                        <input type="button" value="重 置" id="btnSearchParRet" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="ss"></div>
        <div class="content-box-content">
            <div class="tab-content default-tab" id="tab1">
                <div class="anl" id="anlButtonList">
                    <input type="button" id="MrcBtnAdd" title="新增" onclick="btnAdd()" value="新增" />
                    <input type="button" id="MrcBtnEdit" title="修改" onclick="btnEdit()" value="修改" />
                    <input type="button" id="MrcBtnDel" title="删除" onclick="btnDel()" value="删除" />
                    <input type="button" id="MrcBtnSignatureSet" title="签章流程设置" onclick="btnSignature()" value="签章流程设置" />
                </div>
                <table>
                    <thead>
                        <tr>
                            <th width="20px"></th>
                            <th width="100px">文件类别</th>
                            <th width="80px">编号</th>
                            <th>文件题名</th>
                            <th width="60px">是否归档</th>
                            <th width="60px">是否目录</th>
                            <th width="60px" title="文件是否签章流程设置">签章设置</th>
                            <th width="60px">归档单位</th>
                            <th width="90px">文件来源</th>
                            <th width="60px">排序位置</th>
                        </tr>
                    </thead>
                    <tbody class="tbody" id="bodyRepeater">
                        <asp:Repeater ID="rpData" runat="server">
                            <ItemTemplate>
                                <tr class='<%#(Container.ItemIndex%2==0)?"bg01":""%>'>
                                    <td>
                                        <input type="radio" name="radio" value='<%# Eval("RECID")%>,
                                                <%# DigiPower.Onlinecol.Standard.Common.ConvertEx.ToInt(Eval("IsFolder"))%>,<%# Eval("SignatureTypeCount")%>,<%# Eval("BH")%>' />
                                    </td>
                                    <td><%#Eval("Archive_FormName")%></td>
                                    <td><%#Eval("BH")%></td>
                                    <td><%# DigiPower.Onlinecol.Standard.Web.PublicModel.GetTitleForBH(Eval("BH").ToString(),
                                            Eval("TITLE").ToString())%></td>
                                    <td><%# DigiPower.Onlinecol.Standard.Web.PublicModel.GetImageforStatus(
                                    DigiPower.Onlinecol.Standard.Common.ConvertEx.ToBool(Eval("MustSubmitFlag")),true)%></td>
                                    <td><%# DigiPower.Onlinecol.Standard.Web.PublicModel.GetImageforStatus(
                                    DigiPower.Onlinecol.Standard.Common.ConvertEx.ToBool(Eval("IsFolder")),true)%></td>
                                    <td>
                                        <%# !DigiPower.Onlinecol.Standard.Common.ConvertEx.ToBool(Eval("IsFolder")) ?
                                    DigiPower.Onlinecol.Standard.Web.PublicModel.GetImageforStatus(DigiPower.Onlinecol.Standard.Common.ConvertEx.ToBool(Eval("SignatureTypeCount")),true):""%>                                        </td>
                                    <td><%#Eval("DefaultCompanyTypeName")%></td>
                                    <td><%#Eval("FileFromName")%></td>
                                    <td><%#Eval("OrderIndex")%></td>
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
