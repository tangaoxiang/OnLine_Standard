<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="WjdjOther.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.WorkFlow.WjdjOther" Title="文件登记/外协单位用" %>

<%@ Import Namespace="DigiPower.Onlinecol.Standard.Web" %>
<%@ Import Namespace="DigiPower.Onlinecol.Standard.Common" %>

<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc1" %>
<%@ Register Src="../CommonCtrl/ctrlOptStatus.ascx" TagName="ctrlOptStatus" TagPrefix="uc2" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownSystemInfo.ascx" TagName="ctrlDropDownSystemInfo"
    TagPrefix="uc4" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownFileList.ascx" TagName="ctrlDropDownFileList"
    TagPrefix="uc5" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownCompanyInfo.ascx" TagName="ctrlDropDownCompanyInfo"
    TagPrefix="uc6" %>
<%@ Register Src="../CommonCtrl/ctrlProjectBaseInfo.ascx" TagName="ctrlProjectBaseInfo"
    TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <style type="text/css">
        #tableList td {
            padding: 2px 4px 2px 2px !important;
        }

        .regedit_input {
            width: 100% !important;
            padding: 0px !important;
            font-size: 13px !important;
            border: 1px solid #D5D5D5 !important;
            color: #333 !important;
            height: 28px;
            line-height: 28px;
        }

        a {
            cursor: pointer;
        }

        #divscrollTop {
            width: 50px;
            height: 50px;
            background: url('../Javascript/Layer/image/lanren_top.jpg');
            background-size: cover;
            position: fixed;
            right: 50px;
            bottom: 50px;
            border-radius: 3px;
            z-index: 1000;
            display: none;
            cursor: pointer;
        }
    </style>

    <script type="text/javascript">
        function getFileStatus() {
            var status = '';
            $("#ctl00_Main_rdbFileStatus_RadioButtonList1 input[type='radio']").each(function () {
                if ($(this).is(":checked"))
                    status = $(this).val();
                return;
            });
            return status;
        }
        function getNewUrl() {
            var url = window.location.href;
            url = Common.urlreplace(url, 'ddlFileType', escape($('#ctl00_Main_ddlFileType_DropDownList1').val()));
            url = Common.urlreplace(url, 'txtTitle', escape($('#ctl00_Main_txtTitle_TextBox1').val()));
            url = Common.urlreplace(url, 'txtMyCode', escape($('#ctl00_Main_txtMyCode_TextBox1').val()));
            url = Common.urlreplace(url, 'fileStatus', escape(getFileStatus()));
            url = Common.urlreplace(url, 'PageIndex', $('#CurrentPageIndex').text());
            url = Common.urlreplace(url, 'rn', Math.random());
            return url;
        }
        //工程ID
        function GetSingleProjectID() {
            return $('#HidSingleProjectID').val();
        }
        //著录
        function btnZL() {
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                if (keyList[1].toLocaleLowerCase() == 'false' || keyList[1] == '0') {
                    var height = "520px";
                    if (screen.height < 768)
                        height = "100%";
                    var url = "../File/FileInfoList.aspx?action=" + PageState.View + "&ID=" +
                            keyList[0] + "&SingleProjectID=" + GetSingleProjectID() + '&rn=' + Math.random();
                    Common.fnLayerOpen("文件编号[" + keyList[5] + "]信息", "820px", height, url, false, "");
                } else {
                    Common.fnLayerAlert("请勾选文件级来查看文件详细信息!");
                }
            }
        }

        //上传
        function btnUpload() {
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                if (keyList[1].toLocaleLowerCase() == 'false' || keyList[1] == '0') {
                    var url = "../File/UpLoadEFileList.aspx?FileListID=" + keyList[0] + "&SingleProjectID=" +
                        GetSingleProjectID() + "&WorkFlowID=0&rn=" + Math.random();
                    layer.open({
                        type: 2,
                        title: "文件编号[" + keyList[5] + "]电子文件上传",
                        maxmin: false,
                        resize: false,
                        shadeClose: false,
                        area: ['100%', '100%'],
                        content: url,
                        end: function () {
                            window.location.href = getNewUrl();
                        }
                    });
                } else {
                    Common.fnLayerAlert("请勾选文件级来上传文件!");
                }
            }
        }

        //查看电子文件 
        function lookPDF(isFolder, bh, filelistID, SingleProjectID) {
            if (Number(isFolder) == 0) {
                if (WjdjOther.CheckPdfFileExistsForFileListID(Number(filelistID)).value) {
                    var url = "../File/DocumentEdit.aspx?ID=" + filelistID + "&SingleProjectID=" + SingleProjectID + "&rn=" + Math.random();
                    window.top.parent.ParentOpenDiv('文件编号[' + bh + ']电子文件预览', url, '80%', '95%');
                } else {
                    Common.fnLayerAlert("电子文件在磁盘上不存在!");
                }
            } else {
                Common.fnLayerAlert("目录级没有电子文件!");
            }
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <input type="hidden" id="HidSingleProjectID" value="<%= singleProjectID%>" />
    <input type="hidden" id="hidOpenFlag" />

    <uc3:ctrlProjectBaseInfo ID="ctrlProjectBaseInfo1" runat="server" />
    <div class="main-content">
        <div class="content-box-search">
            <%--<button type="button" id="more_button_plus" class="more_button_plus1"></button>--%>
            <table id="c1">
                <tr>
                    <td class="condition">文件类别：</td>
                    <td class="c2">
                        <uc5:ctrlDropDownFileList ID="ddlFileType" Width="150" bShowNO="false"
                            AutoPostBack="false" runat="server" />
                    </td>
                    <td class="condition">文件名称：</td>
                    <td class="c2">
                        <uc1:ctrlTextBoxEx runat="server" ID="txtTitle" MaxLength="20" />
                    </td>

                    <td class="ss">
                        <asp:Button ID="btnSearch" runat="server" Text=" 查询 " OnClick="btnSearch_Click" />
                        <input type="button" value="重 置" id="btnSearchParRet" />
                    </td>
                    <td>
                        <button style="float: right;" type="button" id="more_button_plus" class="more_button_plus"></button>
                    </td>
                </tr>
            </table>
            <div class="moremore">
                <table id="c1">
                    <tr>
                        <td class="condition">内部编号：</td>
                        <td class="c2">
                            <uc1:ctrlTextBoxEx runat="server" ID="txtMyCode" MaxLength="20" width="162" />
                        </td>
                        <td class="condition">文件状态：</td>
                        <td colspan="4">
                            <uc2:ctrlOptStatus ID="rdbFileStatus" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="ss"></div>
        <div class="content-box-content">
            <div class="tab-content default-tab" id="tab1">
                <div class="anl" id="anlButtonList">
                    <input type="button" id="MrcUpload" title="针对文件,上传电子文件" onclick="btnUpload()" value="上传" />
                    <input type="button" id="MrcBtnZL" title="查看文件详细信息" onclick="btnZL()" value="文件信息" />
                    <input type="button" id="MrcBtnBack" title="返回列表页面" onclick="Common.fnParentLayerCloseAndRefresh()" value="返回" />
                </div>
                <table id="tableList">
                    <thead>
                        <tr>
                            <th width="20px"></th>
                            <th width="60px">编号</th>
                            <th width="60px">内部编号</th>
                            <th>文件题名</th>
                            <th width="120px">责任者</th>
                            <th width="80px">文(图)号</th>
                            <th width="70px">形成日期</th>
                            <th width="60px">实体页数</th>
                            <th width="60px">上传页数</th>
                            <th width="30px">原文</th>
                        </tr>
                    </thead>
                    <tbody class="tbody" id="bodyRepeater">
                        <asp:Repeater ID="rpData" runat="server">
                            <ItemTemplate>
                                <tr class='<%#(Container.ItemIndex%2==0)?"bg01":""%>'>
                                    <td>
                                        <input type="radio" name="radio"
                                            value='<%# Eval("FileListID")%>,<%# Eval("IsFolder")%>,<%# Eval("recID")%>,<%# Eval("PID")%>,<%# Eval("DefaultCompanyType")%>,<%# Eval("BH")%>,<%# Eval("OldRecID")%>' />
                                    </td>
                                    <td <%# getTdColorForFileStatus(Eval("Status"))%>>
                                        <%# getInputTextForIsFolder(Eval("IsFolder"),Eval("bh"),"30","disabled=\"disabled\" ")%>
                                    </td>
                                    <td <%# getTdColorForFileStatus(Eval("Status"))%>>
                                        <%# getInputTextForIsFolder(Eval("IsFolder"),Eval("MyCode"),"20",null)%>
                                    </td>
                                    <td <%# getTdColorForFileStatus(Eval("Status"))%>>
                                        <%# getInputTextForIsFolder(Eval("IsFolder"),Eval("title"),"100",null)%> </td>
                                    <td <%# getTdColorForFileStatus(Eval("Status"))%>>
                                        <%# getInputTextForIsFolder(Eval("IsFolder"),  (ConvertEx.ToInt(Eval("IsFolder"))<1 &&
                                    ConvertEx.ToInt(Eval("Status"))<1 && 
                                    String.IsNullOrWhiteSpace(Eval("zrr").ToString()))?DigiPower.Onlinecol.Standard.Common.Session.GetSession("CompanyName") : Eval("zrr"),"40",null)%>                                              
                                    </td>
                                    <td <%# getTdColorForFileStatus(Eval("Status"))%>>
                                        <%# getInputTextForIsFolder(Eval("IsFolder"),Eval("w_t_h"),"50",null)%>
                                    </td>
                                    <td <%# getTdColorForFileStatus(Eval("Status"))%>>
                                        <%# getInputTextForIsFolder(Eval("IsFolder"),Eval("StartTime"),"10","name=\"startTime\" onblur=\"return Jvalidator(this);\"")%> 
                                    </td>
                                    <td <%# getTdColorForFileStatus(Eval("Status"))%>>
                                        <%# getInputTextForIsFolder(Eval("IsFolder"),Eval("ManualCount"),"3"," name=\"ManualCount\" onkeyup=\"this.value=this.value.replace(/\\D/g,'')\" onafterpaste=\"this.value=this.value.replace(/\\D/g,'')\" ")%> 
                                    </td>
                                    <td><%# Eval("pagescount")%></td>
                                    <td>
                                        <%# PublicModel.getEfileImage(Eval("FileListID").ToString(),Eval("SingleProjectID").ToString(),
                                            Eval("bh").ToString(),DigiPower.Onlinecol.Standard.Common.ConvertEx.ToBool(Eval("IsFolder")))
                                        %>
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
    <script type="text/javascript" src="../Javascript/Common/scrollTop.js"></script>
    <div id='divscrollTop'></div>
</asp:Content>

