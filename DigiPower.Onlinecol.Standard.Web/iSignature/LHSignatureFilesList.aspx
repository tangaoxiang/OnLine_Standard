<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true"
    CodeBehind="LHSignatureFilesList.aspx.cs" Inherits="DigiPower.Onlinecol.Standard.Web.iSignature.LHSignatureFilesList"
    Title="电子文件签章" %>

<%@ Import Namespace="DigiPower.Onlinecol.Standard.Web" %>
<%@ Import Namespace="DigiPower.Onlinecol.Standard.Common" %>

<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script type="text/javascript" src="JS/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="JS/json2-min.js"></script>
    <script type="text/javascript" src="JS/signature.js"></script>

    <script type="text/javascript">
        function getNewUrl() {
            var url = window.location.href;
            url = Common.urlreplace(url, 'txtTitle', escape($('#ctl00_Main_txtTitle_TextBox1').val()));
            url = Common.urlreplace(url, 'txtWth', escape($('#ctl00_Main_txtWth_TextBox1').val()));
            url = Common.urlreplace(url, 'PageIndex', $('#CurrentPageIndex').text());
            url = Common.urlreplace(url, 'rn', Math.random());
            return url;
        }
        function GetSingleProjectID() {
            return $('[id$=hid_SingleProjectID]').val();
        }
        function GetProjectType() {
            return $('[id$=hid_ProjectType]').val();
        }
        //查看工程信息
        function btnLookSingle() {
            var height = "100%";
            if (screen.height >= 900) height = "680px";
            window.top.parent.ParentOpenDiv('工程信息-预览', '../CompanyManage/CompanyReg3_' +
                Common.getFileTypeForProjectType(GetProjectType()) + 'Edit.aspx?action=' + PageState.View + '&SingleProjectID=' +
                GetSingleProjectID() + '&rn=' + Math.random() + '&ProjectType=' + GetProjectType(), '900px', height);
        }
        //查看电子文件 
        function lookPDF(isFolder, bh, filelistID, SingleProjectID) {
            if (Number(isFolder) == 0) {
                if (LHSignatureFilesList.CheckPdfFileExistsForFileListID(Number(filelistID)).value) {
                    var url = "../File/DocumentEdit.aspx?ID=" + filelistID + "&SingleProjectID=" +
                        SingleProjectID + "&rn=" + Math.random();
                    window.top.parent.ParentOpenDiv('文件编号[' + bh + ']电子文件预览', url, '80%', '95%');
                } else {
                    Common.fnLayerAlert("电子文件在磁盘上不存在!");
                }
            } else {
                Common.fnLayerAlert("目录级没有电子文件!");
            }
        }
        //单签
        function btnSignature() {
            if (Common.isCheckBoxOneChecked()) {
                var keyList = Common.getChkOneKeyToArray();
                var recID = keyList[6];
                var filelistID = keyList[0];
                if (Number(keyList[1]) == 0 && Number(keyList[7]) == 1) {
                    if (!LHSignatureFilesList.CheckSignatureFinishCount(filelistID, recID).value) {
                        if (!LHSignatureFilesList.CheckSignatureStatus(filelistID, recID).value) {
                            Common.fnLayerAlert('您无权对该份文件签章或还没轮到您签章!');
                        } else {
                            var strURL = "../iSignature/SignaturePdf.aspx?SignatureType=LH&recID=" + recID + "&ID=" + filelistID + "&SingleProjectID=" + GetSingleProjectID();
                            window.top.parent.ParentOpenDiv('文件编号[' + keyList[5] + ']电子文件签章-' + Common.getRedStrongString("单签"), strURL, '80%', '95%');
                        }
                    } else {
                        Common.fnLayerAlert('当前用户对该份文件已经签章完成,不能再签章!');
                    }
                } else {
                    Common.fnLayerAlert("文件还没有转换PDF,不能签章!");
                }
            }
        }
        //批签 
        function btnBatchSignature() {
            var fileIDS = "", fileID = "";
            var checkedLen = $("input[type='checkbox']:checked").length;
            if (checkedLen > 0 && checkedLen <= 10) {
                $("input[type='checkbox'][name='checkOne']:checked").each(function () {
                    var keyList = ($(this).val() + ',').split(',');
                    if (!LHSignatureFilesList.CheckSignatureFinishCount(keyList[0], keyList[6]).value) {
                        if (LHSignatureFilesList.CheckSignatureStatus(keyList[0], keyList[6]).value) {
                            if (fileIDS == "") {
                                fileIDS = keyList[0];
                                fileID = keyList[0];
                            }
                            else
                                fileIDS += "," + keyList[0];
                        }
                    }
                });
            } else {
                Common.fnLayerAlert("请选择待批签的文件,每次最多只能选择" + Common.getRedStrongString("1-10") + "份文件!");
                return;
            }
            if (fileIDS != "" && fileID != "") {
                var strURL = "../iSignature/BatchSignaturePdf.aspx?ID=" + fileID + "&SingleProjectID=" + GetSingleProjectID() + "&fileIDS=" + fileIDS;
                window.top.parent.ParentOpenDiv('电子文件' + Common.getRedStrongString("批量签章"), strURL, '90%', '95%');
            } else {
                Common.fnLayerAlert('请选择轮到您签章的文件');
            }
        }

        //签章完成
        function btnSignatureFinish() {
            var fileIDS = "", fileTmpIDS = "";
            var checkedLen = $("input[type='checkbox']:checked").length;
            if (checkedLen > 0 && checkedLen <= 10) {
                layer.confirm('确定要设置选中的文件为签章完成状态?' +
                    Common.getRedStrongString('<br/>提示:如果当前文件已签章完成或未签过章则不能设置为签章完成'), function () {
                        $("input[type='checkbox'][name='checkOne']:checked").each(function () {
                            var keyList = ($(this).val() + ',').split(',');
                            fileIDS += "," + keyList[0];
                            fileTmpIDS += "," + keyList[6];
                        });
                        var len = LHSignatureFilesList.SignatureFinish(fileIDS, fileTmpIDS, GetSingleProjectID()).value;
                        if (len.indexOf(ResultState.Success) > -1) {
                            Common.fnLayerAlertAndRefresh("操作完成!");    
                        } else {
                            Common.fnLayerAlert("签章完成操作失败:" + len);
                        }
                    });
            } else {
                Common.fnLayerAlert("请选择签章完成的文件,每次最多只能选择" + Common.getRedStrongString("1-10") + "份文件!");
                return;
            }
        }
        //重置 
        function btnresetPDF() {
            if (Common.isCheckBoxOneChecked()) {
                var keyList = Common.getChkOneKeyToArray();
                if (keyList[1] == 0 && keyList[7] == 1) {
                    if (!LHSignatureFilesList.CheckSignatureFinishCount(keyList[0], keyList[6]).value) {
                        if (LHSignatureFilesList.GetSignatureCount(keyList[0]).value < 1) {
                            Common.fnLayerAlert('您无权对该份文件重置,原因:' + Common.getRedStrongString("您没有对该文件签过章!"));
                            return;
                        }
                        var len = LHSignatureFilesList.SignatureResetFlag(keyList[0]).value;
                        if (len.indexOf(ResultState.Success) > -1) {
                            Common.fnLayerAlertAndRefresh("文件重置成功!");
                        } else {
                            Common.fnLayerAlert(len);
                        }
                    } else {
                        Common.fnLayerAlert('当前用户对该份文件已经签章完成,不能再重置!');
                    }
                }
                else {
                    Common.fnLayerAlert('文件还没有转换PDF,不能重置!');
                }
            }
        }
        //电子签章日志
        function btnSignatureLog() {
            if (Common.isCheckBoxOneChecked()) {
                var keyList = Common.getChkOneKeyToArray();
                if (Number(keyList[1]) == 0) {
                    var height = "520px";
                    if (screen.height < 768)
                        height = "100%";
                    var url = "LHSignatureFilesLog.aspx?FileListID=" + keyList[0] + '&rn=' + Math.random();
                    Common.fnLayerOpen("编号[" + keyList[5] + "]签章日志", "740px", height, url, false, "");
                } else {
                    Common.fnLayerAlert("请勾选文件级来查看电子签章日志!");
                }
            }
        }
        //查看文件签章流程 
        function btnSignatureTmp() {
            if (Common.isCheckBoxOneChecked()) {
                var keyList = Common.getChkOneKeyToArray();
                if (Number(keyList[1]) == 0) {
                    var height = "520px";
                    if (screen.height < 768)
                        height = "100%";
                    var url = "LHSignatureFileTmp.aspx?OldRecID=" + keyList[6] + '&rn=' + Math.random();
                    Common.fnLayerOpen("编号[" + keyList[5] + "]文件签章流程", "480px", height, url, false, "");
                } else {
                    Common.fnLayerAlert("请勾选文件级来查看电子签章流程!");
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <input type="hidden" id="hidOpenFlag" />
    <asp:HiddenField ID="hid_SingleProjectID" runat="server" />
    <asp:HiddenField ID="hid_CompanyID" runat="server" />
    <asp:HiddenField ID="hid_ProjectType" runat="server" />
    <div class="main-content">
        <div class="content-box-search">
            <table id="c1">
                <tr>
                    <td class="condition">文件题名：</td>
                    <td class="c2">
                        <uc3:ctrlTextBoxEx runat="server" ID="txtTitle" MaxLength="50" width="140" />
                    </td>
                    <td class="condition">文(图)号：</td>
                    <td class="c2">
                        <uc3:ctrlTextBoxEx runat="server" ID="txtWth" MaxLength="50" width="140" />
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
                <div class="anl">
                    <input type="button" id="MrcBtnLookSingle" title="工程信息预览" onclick="btnLookSingle()" value="工程信息" />
                    <input type="button" id="MrcBtnSignature" title="只会对轮到自己签章的PDF进行,电子签章(单签)"
                        onclick="btnSignature()" value="单签" />
                    <input type="button" onclick="btnBatchSignature();"
                        title="只会对轮到自己签章的PDF进行,电子签章(批签)" value="批签" />
                    <input type="button" onclick="btnSignatureFinish();"
                        title="只有当前角色用户签章完成,后续用户才能继续签章" value="签章完成" />
                    <input type="button" onclick="btnresetPDF();"
                        title="恢复到最后一次签章签的文件,每次只能选择一份文件重置" value="文件重置" />
                    <input type="button" onclick="btnSignatureLog();"
                        title="每次只能选择一份PDF来查看签章日志" value="签章日志" />
                    <input type="button" onclick="btnSignatureTmp();"
                        title="每次只能选择一份PDF来查看该文件对应的签章流程,预先设置好" value="文件签章流程" />

                    <input type="button" title="返回工程列表页面" onclick="Common.fnParentLayerCloseAndRefresh()" value="返回" />
                    <strong style="color: red;">背景色为绿色,表示是需要当前用户签章的文件</strong>
                </div>
                <table>
                    <thead>
                        <tr>
                            <th width="30px" style="cursor: pointer;" onclick="Common.selCheckBoxAll(this)" selall="0">全选</th>
                            <th width="70px">编号</th>
                            <th>文件题名</th>
                            <th width="150px">责任者</th>
                            <th width="100px">文(图)号</th>
                            <th width="65px">实体页数</th>
                            <th width="85px">是否转换PDF</th>
                            <th width="70px">转换日期</th>
                            <th width="50px" title="针对当前用户">已签章</th>
                            <th width="65px" title="针对当前用户">签章完成</th>
                            <th width="90px" title="针对当前用户">签章完成日期</th>
                        </tr>
                    </thead>
                    <tbody class="tbody" id="bodyRepeater">
                        <asp:Repeater ID="gvData" runat="server">
                            <ItemTemplate>
                                <tr class='<%#(Container.ItemIndex%2==0)?"bg01":""%>'
                                    <%# tdBgColor=setTDBgColor(Eval("FileListID").ToString(),Eval("OldRecID").ToString())%>>
                                    <td <%# tdBgColor%>>
                                        <input type="checkbox" name="checkOne" value='<%# Eval("FileListID")%>,<%# ConvertEx.ToInt(Eval("IsFolder"))%>,<%# Eval("recID")%>,<%# Eval("PID")%>,<%# Eval("DefaultCompanyType")%>,<%# Eval("bh")%>,<%# Eval("OldRecID")%>,<%# ConvertEx.ToInt(Eval("CONVERT_FLAG"))%>,<%# ConvertEx.ToInt(Eval("iSignatureWorkFlow"))%>' />
                                    </td>
                                    <td <%# tdBgColor%>><%#Eval("bh")%></td>
                                    <td <%# tdBgColor%>><%#Eval("title")%></td>
                                    <td <%# tdBgColor%>><%#Eval("zrr")%></td>
                                    <td <%# tdBgColor%>><%#Eval("w_t_h")%></td>
                                    <td <%# tdBgColor%>><%#Eval("ManualCount")%></td>
                                    <td <%# tdBgColor%>>
                                        <%# PublicModel.getEfileImage(Eval("FileListID").ToString(),Eval("SingleProjectID").ToString(),
                                            Eval("bh").ToString(),ConvertEx.ToBool(Eval("IsFolder")))
                                        %>     
                                    </td>
                                    <td <%# tdBgColor%>><%# ConvertEx.ToDate(Eval("CONVERT_DT").ToString()).ToString("yyyy-MM-dd")%></td>
                                    <td <%# tdBgColor%>><%# PublicModel.GetImageforStatus((Eval("MAX_Signature_DT").ToString().Length>0?true:false),true)%></td>
                                    <td <%# tdBgColor%>><%# PublicModel.GetImageforStatus((Eval("MAX_SignatureFinish_DT").ToString().Length>0?true:false),true)%></td>
                                    <td <%# tdBgColor%>><%# Eval("MAX_SignatureFinish_DT").ToString().Length>0?ConvertEx.ToDate(
                                                Eval("MAX_SignatureFinish_DT").ToString()).ToString("yyyy-MM-dd"):""%></td>
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
    <br />
    <br />
    <br />
    <object id="CryptAPICtrl" classid="clsid:BCE5CCE5-959F-4DC0-BCF3-6C2916D48AA2" codebase="KG_Crypt_COM_API.dll#version=1,0,0,1" style="display: none;"></object>
    <object id="SMObj" width="0" style="display: none;" height="0" classid="clsid:E5C44C76-610A-4C1F-9083-6CE933E3DC1D"></object>
</asp:Content>
