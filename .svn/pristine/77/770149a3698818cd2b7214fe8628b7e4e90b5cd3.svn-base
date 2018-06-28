<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="Zxyys.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.WorkFlow.Zxyys" Title="在线预验收" %>

<%@ Register Src="../CommonCtrl/ctrlDropDownCompanyInfo.ascx" TagName="ctrlDropDownCompanyInfo"
    TagPrefix="uc6" %>
<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc1" %>
<%@ Register Src="../CommonCtrl/ctrlOptStatus.ascx" TagName="ctrlOptStatus" TagPrefix="uc2" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownFileList.ascx" TagName="ctrlDropDownFileList"
    TagPrefix="uc5" %>
<%@ Register Src="../CommonCtrl/ctrlProjectBaseInfo.ascx" TagName="ctrlProjectBaseInfo"
    TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #tableList td {
            padding: 2px 4px 2px 2px !important;
        }

        .regedit_input {
            padding: 0px !important;
            font-size: 13px !important;
            border: 1px solid #D5D5D5 !important;
            color: #333 !important;
            height: 35px;
            width: 100%;
            line-height: 35px;
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
            url = Common.urlreplace(url, 'ddlCompany', escape($('#ctl00_Main_ddlCompany_ddlArea').val()));
            url = Common.urlreplace(url, 'ddlFileType', escape($('#ctl00_Main_ddlFileType_DropDownList1').val()));
            url = Common.urlreplace(url, 'ddlChangeFile', escape($('#ctl00_Main_ddlChangeFile').val()));
            url = Common.urlreplace(url, 'txtTitle', escape($('#ctl00_Main_txtTitle_TextBox1').val()));
            url = Common.urlreplace(url, 'txtMyCode', escape($('#ctl00_Main_txtMyCode_TextBox1').val()));
            url = Common.urlreplace(url, 'PageIndex', $('#CurrentPageIndex').text());
            url = Common.urlreplace(url, 'fileStatus', escape(getFileStatus()));
            url = Common.urlreplace(url, 'rn', Math.random());
            return url;
        }

        //工程类型
        function GetSingleProjectType() {
            return $('#HidPrpjectType').val();
        }
        //工程ID
        function GetSingleProjectID() {
            return $('#HidSingleProjectID').val();
        }
        //文件信息
        function btnZL() {
            if (Common.isCheckBoxOneChecked()) {
                var keyList = Common.getChkOneKeyToArray();
                var height = "520px";
                if (screen.height < 768) height = "100%";

                var url = "../File/FileInfoList.aspx?action=" + PageState.View + "&ID=" +
                        keyList[0] + "&SingleProjectID=" + GetSingleProjectID() + '&rn=' + Math.random();
                Common.fnLayerOpen("文件编号[" + keyList[2] + "]详细信息", '820px', height, url, false, '');
            }
        }
        //查看工程信息
        function btnLookSingle() {
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                var height = "100%";
                if (screen.height >= 900) height = "680px";
                window.top.parent.ParentOpenDiv('工程信息-预览', '../CompanyManage/CompanyReg3_' +
                    Common.getFileTypeForProjectType(GetSingleProjectType()) + 'Edit.aspx?action=' +
                    PageState.View + '&SingleProjectID=' + GetSingleProjectID() + '&rn=' + Math.random() + '&ProjectType=' +
                    GetSingleProjectType(), '900px', height);
            }
        }
        function selCheckBoxAll2(obj) {
            var selFlag = false;
            if ($(obj).attr("selall") == "0")
                selFlag = true;

            $("input[type='checkbox'][name='checkSubmitflag']").each(function () {
                if ($(this).prop('disabled') != 'disabled') {
                    $(this).prop('checked', selFlag);
                }
            });
            $(obj).attr("selall", (selFlag ? "1" : "0"))
        }
        //1:预验收通过,2:预验收不通过
        function btnAccpt(checkTypeFlag) {
            var checkedLen = $("input[type='checkbox'][name='checkOne']:checked").length;
            if (checkedLen > 0) {
                var ids = "";
                var mustSubmitFlags = "";
                $("input[type='checkbox'][name='checkOne']:checked").each(function () {
                    var keyList = ($(this).val() + ',').split(',');
                    if (keyList[1].toLocaleLowerCase() == 'false' || keyList[1] == '0') {
                        var tdAll = $(this).parent().nextAll();

                        ids += keyList[0] + ",";
                        mustSubmitFlags += (($(tdAll).eq(5).children().eq(0).is(':checked')) ? 1 : 0) + ",";
                    }
                });
                var url = "ZxyysCheck.aspx?SingleProjectID=" + GetSingleProjectID() + "&FileListIDS=" + ids + "&checkTypeFlag=" + checkTypeFlag
                    + "&MustSubmitFlags=" + mustSubmitFlags + "&workFlowID=" + $('#Hidworkflowid').val() + "&rn=" + Math.random();
                Common.fnLayerOpen("预验收", "480px", "350px", url, true, "保存成功!");
            } else {
                Common.fnLayerAlert('必须选择一项才可以操作!');
            }
        }
        //3:保存,4:恢复
        function btnSave(index) {
            var checkedLen = $("input[type='checkbox'][name='checkOne']:checked").length;
            if (checkedLen > 0) {
                $("input[type='checkbox'][name='checkOne']:checked").each(function () {
                    var keyList = ($(this).val() + ',').split(',');
                    if (keyList[1].toLocaleLowerCase() == 'false' || keyList[1] == '0') {
                        var tdAll = $(this).parent().nextAll();
                        var remark = $(tdAll).eq(4).children().eq(0).val();
                        var mustSubmitFlag = ($(tdAll).eq(5).children().eq(0).is(':checked')) ? 1 : 0;
                        if (index == 3) {
                            Zxyys.UpdateFile(keyList[0], remark, mustSubmitFlag).value;
                        } else if (index == 4) {
                            Zxyys.ResetStatus(keyList[0]).value;
                        }
                    }
                });
                Common.fnLayerAlertAndRefresh("保存成功!");
            } else {
                Common.fnLayerAlert('必须选择一项才可以操作!');
            }
        }
        //查看电子文件 
        function lookPDF(isFolder, bh, filelistID, SingleProjectID) {
            if (Number(isFolder) == 0) {
                if (Zxyys.RKLookPDFFlag(SingleProjectID).value) {
                    if (Zxyys.CheckPdfFileExistsForFileListID(Number(filelistID)).value) {
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
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <input type="hidden" id="HidSingleProjectID" value="<%= singleProjectID%>" />
    <input type="hidden" id="Hidworkflowid" value="<%= workFlowID%>" />
    <input type="hidden" id="HidPrpjectType" value="<%=projectType%>" />
    <input type="hidden" id="hidOpenFlag" />
    <uc3:ctrlProjectBaseInfo ID="ctrlProjectBaseInfo1" runat="server" />
    <div class="main-content">
        <div class="content-box-search">
            <table id="c1">
                <tr>
                    <td class="condition">业务单位：</td>
                    <td class="c2">
                        <uc6:ctrlDropDownCompanyInfo ID="ddlCompany" runat="server" Width="150" />
                    </td>

                    <td class="condition">文件状态：</td>
                    <td colspan="2">
                        <uc2:ctrlOptStatus ID="rdbFileStatus" runat="server" />
                    </td>
                    <td class="condition">变更的文件：   
                    </td>
                    <td class="c2">
                        <asp:DropDownList runat="server" ID="ddlChangeFile">
                            <asp:ListItem Value="" Text="----请选择----"></asp:ListItem>
                            <asp:ListItem Value="1" Text="有变更"></asp:ListItem>
                            <asp:ListItem Value="0" Text="无变更"></asp:ListItem>
                        </asp:DropDownList>
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
                            <uc1:ctrlTextBoxEx runat="server" ID="txtMyCode" MaxLength="20" />
                        </td>
                        <td class="condition">文件类别：</td>
                        <td class="c2">
                            <uc5:ctrlDropDownFileList ID="ddlFileType" Width="150" bShowNO="false"
                                AutoPostBack="false" runat="server" />
                        </td>
                        <td class="condition">文件名称：</td>
                        <td class="c2">
                            <uc1:ctrlTextBoxEx runat="server" ID="txtTitle" MaxLength="20" />
                        </td>
                        <td colspan="3"></td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="ss"></div>
        <div class="content-box-content">
            <div class="tab-content default-tab" id="tab1">
                <div class="anl">
                    <input type="button" title="工程详细信息" onclick="btnLookSingle()" value="工程信息" />
                    <input type="button" title="文件信息" onclick="btnZL()" value="文件信息" />
                    <input type="button" title="保存审核反馈及需要归档的条目" onclick="btnSave(3)" value="保存" />
                    <input type="button" title="恢复文件状态到验收状态之前的状态" onclick="btnSave(4)" value="恢复" />
                    <%--<input type="button" title="声像验收" onclick="btnAcceptSX()" value="声像验收" />--%>
                    <input type="button" title="预验收通过" onclick="btnAccpt(1)" value="预验收通过" />
                    <input type="button" title="预验收不通过" onclick="btnAccpt(0)" value="预验收不通过" />
                    <input type="button" id="MrcBtnBack" title="返回列表页面" onclick="Common.fnParentLayerCloseAndRefresh()" value="返回" />
                </div>
                <table id="tableList">
                    <thead>
                        <tr>
                            <th width="30px" style="cursor: pointer;" onclick="Common.selCheckBoxAll(this)"
                                selall="0">全选</th>
                            <th width="80px">编号</th>
                            <th>文件题名</th>
                            <th width="60px">实体页数</th>
                            <th width="60px">上传页数</th>
                            <th width="200px" title="馆里人员审核后,退回到文件登记,业务单位可以看到该审核信息,据此来修改">审核反馈</th>
                            <th width="60px" style="cursor: pointer;" selall="0"
                                onclick="selCheckBoxAll2(this)">需要归档</th>
                            <th width="30px">原文</th>
                        </tr>
                    </thead>
                    <tbody class="tbody" id="bodyRepeater">
                        <asp:Repeater ID="rpData" runat="server">
                            <ItemTemplate>
                                <tr class='<%#(Container.ItemIndex%2==0)?"bg01":""%>'>
                                    <td <%# getTdColorForFileStatus(Eval("Status"))%>>
                                        <input type="checkbox" name="checkOne"
                                            value='<%# Eval("FileListID")%>,<%# Eval("IsFolder")%>,<%# Eval("BH")%>' />
                                    </td>
                                    <td <%# getTdColorForFileStatus(Eval("Status"))%>><%# Eval("bh")%></td>
                                    <td <%# getTdColorForFileStatus(Eval("Status"))%>><%# Eval("title")%></td>
                                    <td <%# getTdColorForFileStatus(Eval("Status"))%>>
                                        <%# 
                                                 getShowText(Eval("IsFolder"),Eval("ManualCount").ToString())
                                        %></td>
                                    <td <%# getTdColorForFileStatus(Eval("Status"))%>>
                                        <%# 
                                                 getShowText(Eval("IsFolder"),Eval("pagescount").ToString())
                                        %> </td>
                                    <td <%# getTdColorForFileStatus(Eval("Status"))%>>
                                        <textarea onpropertychange="Common.isTextAreaCheckLength(this,200)" oninput="Common.isTextAreaCheckLength(this,200)" onkeyup="Common.isTextAreaCheckLength(this,200)" class="regedit_input" rows="4" cols="20" <%# SetTextDisabled(Eval("IsFolder"))%> title="<%# Eval("Remark")%>"><%# Eval("Remark")%></textarea>
                                    </td>
                                    <td <%# getTdColorForFileStatus(Eval("Status"))%>>
                                        <input type="checkbox" <%# SetTextDisabled(Eval("IsFolder"))%> <%# SetCheckBox(Eval("MustSubmitFlag")) %>
                                            name="checkSubmitflag" isfolder='<%# DigiPower.Onlinecol.Standard.Common.ConvertEx.ToInt(Eval("IsFolder"))%>' value='<%# Eval("FileListID")%>' />
                                    </td>
                                    <td <%# getTdColorForFileStatus(Eval("Status"))%>><%# 
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
    <script type="text/javascript" src="../Javascript/Common/scrollTop.js"></script>
    <div id='divscrollTop'></div>
</asp:Content>
