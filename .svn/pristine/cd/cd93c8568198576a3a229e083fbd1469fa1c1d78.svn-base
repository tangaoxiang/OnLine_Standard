<%@ Page Language="C#" MasterPageFile="~/SiteWjdj.Master" AutoEventWireup="true" CodeBehind="Wjdj.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.WorkFlow.Wjdj" Title="文件登记/收集/汇总" %>

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

        .condition {
            width: 100px !important;
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
    <script src="../Javascript/Common/jquery.maskedinput.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        $(function () {
            $("input[type='text'][name='startTime']").mask("9999-99-99");
        });
        function Jvalidator(obj) {
            if (obj.value != "" && obj.value != "____-__-__") {
                if (Common.isDate2("", obj) == false) {
                    obj.select();
                    obj.value = "";
                    return false;
                } else {
                    return true;
                }
            }
        }
    </script>
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
            url = Common.urlreplace(url, 'txtTitle', escape($('#ctl00_Main_txtTitle_TextBox1').val()));
            url = Common.urlreplace(url, 'txtMyCode', escape($('#ctl00_Main_txtMyCode_TextBox1').val()));
            url = Common.urlreplace(url, 'fileStatus', escape(getFileStatus()));
            url = Common.urlreplace(url, 'PageIndex', $('#CurrentPageIndex').text());
            url = Common.urlreplace(url, 'ddliSignaturePdf', escape($('#ctl00_Main_ddliSignaturePdf').val()));
            url = Common.urlreplace(url, 'ddlSignatureFinishFlag', escape($('#ctl00_Main_ddlSignatureFinishFlag').val()));
            url = Common.urlreplace(url, 'rn', Math.random());
            return url;
        }
        //工程ID
        function GetSingleProjectID() {
            return $('#HidSingleProjectID').val();
        }
        //流程ID
        function GetWorkFlowID() {
            return $('#Hidworkflowid').val();
        }
        //工程类型
        function GetSingleProjectType() {
            return $('#Hidprojecttype').val();
        }
        //新增
        function btnAdd() {
            var checkedLen = $("input[type='checkbox']:checked").length;
            if (checkedLen == 1) {
                $("input[type='checkbox']:checked").each(function () {
                    var singleProjectID = GetSingleProjectID();                      //工程ID
                    var keyList = ($(this).val() + ',').split(',');                  //数据集合   
                    var tdAll = $(this).parent().nextAll();

                    var oldMycode = $(tdAll).eq(1).children(0).val();
                    var oldWjtm = $(tdAll).eq(2).children(0).val();
                    var oldZrz = $(tdAll).eq(3).children(0).val();
                    var oldWth = $(tdAll).eq(4).children(0).val();
                    var oldStartTime = $(tdAll).eq(5).children(0).val();
                    var oldManualCount = $(tdAll).eq(6).children(0).val();

                    var strPID = 0;
                    if (keyList[1].toLocaleLowerCase() == 'true' || keyList[1] == '1')
                        strPID = keyList[2];
                    else
                        strPID = keyList[3];

                    if (keyList[5].split('-').length > 3) {
                        Common.fnLayerAlert("不能勾选该文件来新增文件,文件编号已达最大值!");
                        return;
                    }
                    if (!Wjdj.CheckFileExistsIsFolder(strPID, singleProjectID).value) {
                        Common.fnLayerAlert("请选择子集目录或文件级来新增文件!");
                        return;
                    }

                    var bh = Wjdj.GetBH(singleProjectID, keyList[0]).value;      //文件新编号  
                    var DefaultCompanyType = keyList[4];
                    var IsFolder = "0";
                    var oldRecID = keyList[6];

                    var len = Wjdj.ExctFileList(IsFolder, 0, singleProjectID, "", "", "", "", "", bh, strPID, "", DefaultCompanyType, oldRecID).value;

                    if (len != 0) {
                        var jsstr = '<tr id=\'tr' + len + '\' class=\'bg01\'>';
                        jsstr += '<td>';
                        jsstr += '  <input id=\'chk' + len + '\' type=\"checkbox\" name=\"checkOne\" value=\'' + len + ',0,0,' + strPID + ',' + DefaultCompanyType + ',' + bh + ',' + oldRecID + '\' />';
                        jsstr += '</td>';
                        jsstr += '<td>';
                        jsstr += "  <input type=\"text\" title=\"" + bh + "\" value='" + bh + "' class=\"regedit_input\" maxlength=\"30\" disabled=\"disabled\" />";
                        jsstr += "</td>";

                        jsstr += "<td>";
                        jsstr += '  <input type=\"text\" value="' + oldMycode + '" class=\"regedit_input\" maxlength=\"20\"/>';
                        jsstr += '</td>';

                        jsstr += '<td>';
                        jsstr += '  <input type=\"text\" class=\"regedit_input\" value="' + oldWjtm + '" maxlength=\"100\"/>';
                        jsstr += '</td>';

                        jsstr += '<td>';
                        jsstr += '  <input type=\"text\" value="' + oldZrz + '" class=\"regedit_input\" maxlength=\"40\" />';
                        jsstr += '</td>';

                        jsstr += '<td>';
                        jsstr += '  <input type=\"text\" value="' + oldWth + '" class=\"regedit_input\" maxlength=\"50\" /> ';
                        jsstr += '</td> ';

                        jsstr += '<td> ';
                        jsstr += '  <input type=\"text\" value="' + oldStartTime + '" class=\"regedit_input\" onblur = \"return Jvalidator(this);\" name="startTime" maxlength=\"10\" /> ';
                        jsstr += '</td>';
                        jsstr += '<td> ';
                        jsstr += '  <input type=\"text\" value="' + oldManualCount + '" maxlength=\"4\"  class=\"regedit_input\" name="ManualCount" onkeyup=\"this.value=this.value.replace(/\D/g,\'\')\" onafterpaste=\"this.value=this.value.replace(/\D\g,\'\')\" />';
                        jsstr += '</td>';
                        jsstr += '<td>0<\/td>';
                        jsstr += '<td><\/td>';
                        jsstr += '<td><\/td>';

                        jsstr += '<td>';
                        jsstr += "  <img style=\"cursor:pointer;border:0px; color:white;\" onclick=\"lookPDF(0,'" + bh + "'," + len + "," + GetSingleProjectID() + ")\" src=\"../Javascript/Layer/image/EFILE.png\" alt=\"没有文件\" />";
                        jsstr += '</td>';
                        jsstr += '</tr>';

                        var currentRowIndex = $(this).parent().parent().index() + 1;//当前行索引
                        $('#bodyRepeater tr:eq(' + currentRowIndex + ')').before(jsstr);
                        $(function () {
                            $("input[type='text'][name='startTime']").mask("9999-99-99");
                            $("#bodyRepeater").find("tr").unbind('dblclick');//先移除再重新绑定
                            $("#bodyRepeater").find("tr").bind("dblclick", function () {
                                var td0 = $(this).children().children().eq(0);//点击 tr 选中 单选或多选按钮                  
                                if ((td0.attr("type") == "radio" && td0.attr("name") == "radio") ||
                                    (td0.attr("type") == "checkbox" && td0.attr("name") == "checkOne")) {
                                    td0.prop('checked', !td0.is(":checked"));
                                }
                            });
                        });
                    } else {
                        Common.fnLayerAlert('操作失败,请联系管理员！');
                    }
                });
            } else if (checkedLen == 0) {
                Common.fnLayerAlert('您必须先选中一行表示插入的位置！');
            } else {
                Common.fnLayerAlert('每次只能选中一行来操作！');
            }
        }

        //著录
        function btnZL() {
            if (Common.isCheckBoxOneChecked()) {
                var keyList = Common.getChkOneKeyToArray();
                if (keyList[1].toLocaleLowerCase() == 'false' || keyList[1] == '0') {
                    var height = "520px";
                    if (screen.height < 768)
                        height = "100%";
                    var url = "../File/FileInfoList.aspx?action=" + PageState.Edit + "&ID=" +
                            keyList[0] + "&SingleProjectID=" + GetSingleProjectID() + '&rn=' + Math.random();
                    Common.fnLayerOpen("文件编号[" + keyList[5] + "]信息著录", "820px", height, url, true, "著录成功!");
                } else {
                    Common.fnLayerAlert("请勾选文件级来文件详细著录!");
                }
            }
        }

        //照片管理
        function addSingleProjectImage() {
            var strURL = "../WorkFlow/ImageWjdj.aspx?SingleProjectId=" + GetSingleProjectID() + "&WorkFlowID=" + GetWorkFlowID();
            window.top.Content.CreateTitle('工程编号[' + $('#HidsingleProjectNo').val() + ']照片收集', 5, strURL);
        }

        //上传
        function btnUpload() {
            if (Common.isCheckBoxOneChecked()) {
                var keyList = Common.getChkOneKeyToArray();
                if (keyList[1].toLocaleLowerCase() == 'false' || keyList[1] == '0') {
                    var url = "../File/UpLoadEFileList.aspx?FileListID=" + keyList[0] + "&SingleProjectID=" +
                        GetSingleProjectID() + "&WorkFlowID=" + GetWorkFlowID() + '&rn=' + Math.random();
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
                if (Wjdj.CheckPdfFileExistsForFileListID(Number(filelistID)).value) {
                    var url = "../File/DocumentEdit.aspx?ID=" + filelistID + "&SingleProjectID=" + SingleProjectID + "&rn=" + Math.random();
                    window.top.parent.ParentOpenDiv('文件编号[' + bh + ']电子文件预览', url, '80%', '95%');
                } else {
                    Common.fnLayerAlert("电子文件在磁盘上不存在!");
                }
            } else {
                Common.fnLayerAlert("目录级没有电子文件!");
            }
        }

        //删除
        function btnDel() {
            var checkedLen = $("input[type='checkbox']:checked").length;
            if (checkedLen > 0) {
                layer.confirm('确定要删除选中文件?<br/>' + Common.getRedStrongString("注意:只能删新增的文件,模板文件不能删除!"), function () {
                    $("input[type='checkbox']:checked").each(function () {
                        var keyList = ($(this).val() + ',').split(',');
                        var len = Wjdj.DeleteFileList(Number(keyList[0])).value;
                    });
                    Common.fnLayerAlertAndRefresh("文件删除成功!");
                });
            } else {
                Common.fnLayerAlert('必须选择一项才可以操作!');
            }
        }

        //保存
        function btnSave() {
            var checkedLen = $("input[type='checkbox']:checked").length;
            if (checkedLen > 0) {
                $("input[type='checkbox']:checked").each(function () {
                    var singleProjectID = GetSingleProjectID();                      //工程ID
                    var keyList = ($(this).val() + ',').split(',');                  //数据集合

                    if (keyList[1].toLocaleLowerCase() == 'false' || keyList[1] == '0') { //只保存非节点数据       

                        var tdAll = $(this).parent().nextAll();

                        var oldMycode = $(tdAll).eq(1).children(0).val();
                        var oldWjtm = $(tdAll).eq(2).children(0).val();
                        var oldZrz = $(tdAll).eq(3).children(0).val();
                        var oldWth = $(tdAll).eq(4).children(0).val();
                        var oldStartTime = $(tdAll).eq(5).children(0).val();
                        var oldManualCount = $(tdAll).eq(6).children(0).val();
                        var oldRecID = keyList[6];

                        var len = Wjdj.ExctFileList(0, keyList[0], singleProjectID, oldWjtm, oldZrz, oldWth, oldStartTime, oldManualCount, '', '', oldMycode, '', oldRecID).value;
                    }
                });
                Common.fnLayerAlertAndRefresh("文件保存成功!");
            } else {
                Common.fnLayerAlert('必须选择一项才可以操作!');
            }
        }
        //恢复条目状态
        function btnResetStatus() {
            var checkedLen = $("input[type='checkbox']:checked").length;
            if (checkedLen > 0) {
                $("input[type='checkbox']:checked").each(function () {
                    var keyList = ($(this).val() + ',').split(',');                  //数据集合

                    if (keyList[1].toLocaleLowerCase() == 'false' || keyList[1] == '0') { //只保存非节点数据                     
                        var len = Wjdj.ResetFileStatusAndConvertFlag(GetSingleProjectID(), keyList[0]).value;
                    }
                });
                Common.fnLayerAlertAndRefresh("文件状态恢复成功!");
            } else {
                Common.fnLayerAlert('必须选择一项才可以操作!');
            }
        }
        //快速著录
        function btnQuickZL() {
            var checkedLen = $("input[type='checkbox']:checked").length;
            if (checkedLen > 0) {
                Common.fnLayerOpen('文件著录模板引用', '460px', '350px', 'QuickWjdj.aspx?rn=' + Math.random(), false, '');
            } else {
                Common.fnLayerAlert('必须选择一项才可以操作!');
            }
        }
        //签章设置 是否需要签章,是否按签章流程签章
        function btnSignatureSet() {
            var checkedLen = $("input[type='checkbox']:checked").length;
            if (checkedLen > 0) {
                Common.fnLayerOpen('文件签章修改', '360px', '183px', 'FileSignatureSet.aspx?rn=' + +Math.random(), true, '设置成功!');
            } else {
                Common.fnLayerAlert('必须选择一项才可以操作!');
            }
        }
        //打印
        function btnPrint(singleProjectID, reportCode, delOldReportPDF) {
            var pdfFileName = Wjdj.ReportExportPDF(GetSingleProjectID(), 'printArchive', true).value;
            if (pdfFileName.indexOf(ResultState.Failure) < 0) {
                var url = "../ReportPdfView.aspx?pdfFileName=" + pdfFileName;
                window.top.parent.ParentOpenDiv('报表预览', url, '80%', '98%');
            } else {
                Common.fnLayerAlert('报表PDF转换失败,错误原因:' + pdfFileName);
            }
        }
        //查看工程信息
        function btnLookSingle() {
            var height = "100%";
            if (screen.height >= 900) height = "680px";
            window.top.parent.ParentOpenDiv('工程信息-预览', '../CompanyManage/CompanyReg3_' +
                Common.getFileTypeForProjectType(GetSingleProjectType()) + 'Edit.aspx?action=' + PageState.View + '&SingleProjectID=' +
                GetSingleProjectID() + '&rn=' + Math.random() + '&ProjectType=' + GetSingleProjectType(), '900px', height);
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <input type="hidden" id="HidSingleProjectID" value="<%= singleProjectID%>" />
    <input type="hidden" id="Hidworkflowid" value="<%= workFlowID%>" />
    <input type="hidden" id="Hidprojecttype" value="<%= projecttype%>" />
    <input type="hidden" id="HidsingleProjectNo" value="<%= singleProjectNo%>" />
    <input type="hidden" id="HidDefaultCompanyType" value="<%= DigiPower.Onlinecol.Standard.Common.Session.GetSession("CompanyType") %>" />
    <input type="hidden" id="hidOpenFlag" />

    <uc3:ctrlProjectBaseInfo ID="ctrlProjectBaseInfo1" runat="server" />
    <div class="main-content">
        <div class="content-box-search">
            <%--<button type="button" id="more_button_plus" class="more_button_plus1"></button>--%>
            <table id="c1">
                <tr>
                    <td class="condition">业务单位：</td>
                    <td class="c2">
                        <uc6:ctrlDropDownCompanyInfo ID="ddlCompany" runat="server" Width="165" />
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

                    <td class="ss">
                        <asp:Button ID="btnSearch" runat="server" Text=" 查询 " OnClick="btnSearch_Click" />
                        <input type="button" value="重 置" id="btnSearchParRet" />
                    </td>
                    <%--   <td>
                      <button style="float: right;" type="button" id="more_button_plus" class="more_button_plus"></button>
                    </td>--%>
                </tr>
            </table>
            <div class="moremore" style="display: block;">
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
                    <tr id="trSignatureFinishFlag">
                        <td class="condition">是否需签章：</td>
                        <td class="c2">
                            <asp:DropDownList runat="server" ID="ddliSignaturePdf" Width="165px">
                                <asp:ListItem Text="---请选择---" Value=""></asp:ListItem>
                                <asp:ListItem Text="需要签章" Value="1"></asp:ListItem>
                                <asp:ListItem Text="无需签章" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="condition">签章是否完成：</td>
                        <td class="c2">
                            <asp:DropDownList runat="server" ID="ddlSignatureFinishFlag" Width="150px">
                                <asp:ListItem Text="---请选择---" Value=""></asp:ListItem>
                                <asp:ListItem Text="已完成" Value="1"></asp:ListItem>
                                <asp:ListItem Text="未完成" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td colspan="4"></td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="ss"></div>
        <div class="content-box-content">
            <div class="tab-content default-tab" id="tab1">
                <div class="anl" id="anlButtonList">
                    <input type="button" id="MrcBtnLookSingle" title="工程详细信息" onclick="btnLookSingle()" value="工程信息" />
                    <input type="button" id="MrcBtnAdd" title="新增" onclick="btnAdd()" value="新增" />
                    <input type="button" id="MrcBtnSave" title="保存,针对文件级著录项的信息保存(比如文件题名,责任者,文图号等)" onclick="btnSave()" value="保存" />
                    <input type="button" id="MrcBtnResetStatus" title="状态恢复,针对文件级,重置条目转换标识,文件审核状态 "
                        onclick="btnResetStatus()" value="状态恢复" />
                    <input type="button" id="MrcUpload" title="针对文件,上传电子文件" onclick="btnUpload()" value="上传" />
                    <input type="button" id="MrcBtnZL" title="著录,针对文件级进行详细著录" onclick="btnZL()" value="著录" />
                    <input type="button" id="MrcBtnQuickZL" title="批量修改,针对勾选的文件级,可以多选,针对文件题名,责任者,文图号,形成日期,实体页数"
                        onclick="btnQuickZL()" value="批量修改" />
                    <input type="button" id="MrcBtnDel" title="删除,针对自己新增的文件" onclick="btnDel()" value="删除" />
                    <input type="button" id="MrcBtnSignatureSet" title="签章流程修改,针对文件级" onclick="btnSignatureSet()" value="签章流程修改" />
                    <input type="button" id="MrcBtnPrint" title="打印自己保存和新增的文件" onclick="btnPrint()" value="打印" />
                    <input type="button" id="MrcBtnBack" title="返回列表页面" onclick="Common.fnParentLayerCloseAndRefresh()" value="返回" />
                </div>
                <table id="tableList">
                    <thead>
                        <tr>
                            <th width="30px" style="cursor: pointer;" onclick="Common.selCheckBoxAll(this)"
                                selall="0">全选</th>
                            <th width="60px">编号</th>
                            <th width="60px">内部编号</th>
                            <th>文件题名</th>
                            <th width="120px">责任者</th>
                            <th width="80px">文(图)号</th>
                            <th width="70px">形成日期</th>
                            <th width="60px">实体页数</th>
                            <th width="60px">上传页数</th>
                            <th width="60px">需要归档</th>
                            <th width="60px">审核信息</th>
                            <th width="30px">原文</th>
                        </tr>
                    </thead>
                    <tbody class="tbody" id="bodyRepeater">
                        <asp:Repeater ID="rpData" runat="server">
                            <ItemTemplate>
                                <tr class='<%#(Container.ItemIndex%2==0)?"bg01":""%>'>
                                    <td <%# getTdColorForFileStatus(Eval("Status"))%>>
                                        <input type="checkbox" name="checkOne"
                                            value='<%# Eval("FileListID")%>,<%# Eval("IsFolder")%>,       
                                                <%# Eval("recID")%>,<%# Eval("PID")%>,<%# Eval("DefaultCompanyType")%>,<%# Eval("BH")%>,<%# Eval("OldRecID")%>' />
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
                                    <td <%# getTdColorForFileStatus(Eval("Status"))%>>
                                        <%# ConvertEx.ToInt(Eval("pagescount")) %>
                                    </td>
                                    <td <%# getTdColorForFileStatus(Eval("Status"))%>>
                                        <%# PublicModel.GetImageforStatus(ConvertEx.ToBool(Eval("mustsubmitflag")),true)%></td>
                                    <td <%# getTdColorForFileStatus(Eval("Status"))%>>
                                        <a style="color: black;" onclick="Common.fnLayerTips('<%#Eval("Remark")%>',this)">
                                            <%#
                                               (Eval("Remark").ToString().Length>7)?Eval("Remark").ToString().Substring(0,7)+"...":Eval("Remark").ToString()
                                            %>
                                        </a>
                                    </td>
                                    <td <%# getTdColorForFileStatus(Eval("Status"))%>>
                                        <%# 
                                                     PublicModel.getEfileImage(Eval("FileListID").ToString(),Eval("SingleProjectID").ToString(),
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
    <script type="text/javascript">
        Number(<%= SystemSet._ISIGNATUREPDF%>) ? $("#trSignatureFinishFlag").show() : $("#trSignatureFinishFlag").hide();
    </script>
    <script type="text/javascript" src="../Javascript/Common/scrollTop.js"></script>
    <div id='divscrollTop'></div>
</asp:Content>
