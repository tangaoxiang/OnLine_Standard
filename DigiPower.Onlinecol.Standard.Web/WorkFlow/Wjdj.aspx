<%@ Page Language="C#" MasterPageFile="~/SiteWjdj.Master" AutoEventWireup="true" CodeBehind="Wjdj.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.WorkFlow.Wjdj" Title="�ļ��Ǽ�/�ռ�/����" %>

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
        //����ID
        function GetSingleProjectID() {
            return $('#HidSingleProjectID').val();
        }
        //����ID
        function GetWorkFlowID() {
            return $('#Hidworkflowid').val();
        }
        //��������
        function GetSingleProjectType() {
            return $('#Hidprojecttype').val();
        }
        //����
        function btnAdd() {
            var checkedLen = $("input[type='checkbox']:checked").length;
            if (checkedLen == 1) {
                $("input[type='checkbox']:checked").each(function () {
                    var singleProjectID = GetSingleProjectID();                      //����ID
                    var keyList = ($(this).val() + ',').split(',');                  //���ݼ���   
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
                        Common.fnLayerAlert("���ܹ�ѡ���ļ��������ļ�,�ļ�����Ѵ����ֵ!");
                        return;
                    }
                    if (!Wjdj.CheckFileExistsIsFolder(strPID, singleProjectID).value) {
                        Common.fnLayerAlert("��ѡ���Ӽ�Ŀ¼���ļ����������ļ�!");
                        return;
                    }

                    var bh = Wjdj.GetBH(singleProjectID, keyList[0]).value;      //�ļ��±��  
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
                        jsstr += "  <img style=\"cursor:pointer;border:0px; color:white;\" onclick=\"lookPDF(0,'" + bh + "'," + len + "," + GetSingleProjectID() + ")\" src=\"../Javascript/Layer/image/EFILE.png\" alt=\"û���ļ�\" />";
                        jsstr += '</td>';
                        jsstr += '</tr>';

                        var currentRowIndex = $(this).parent().parent().index() + 1;//��ǰ������
                        $('#bodyRepeater tr:eq(' + currentRowIndex + ')').before(jsstr);
                        $(function () {
                            $("input[type='text'][name='startTime']").mask("9999-99-99");
                            $("#bodyRepeater").find("tr").unbind('dblclick');//���Ƴ������°�
                            $("#bodyRepeater").find("tr").bind("dblclick", function () {
                                var td0 = $(this).children().children().eq(0);//��� tr ѡ�� ��ѡ���ѡ��ť                  
                                if ((td0.attr("type") == "radio" && td0.attr("name") == "radio") ||
                                    (td0.attr("type") == "checkbox" && td0.attr("name") == "checkOne")) {
                                    td0.prop('checked', !td0.is(":checked"));
                                }
                            });
                        });
                    } else {
                        Common.fnLayerAlert('����ʧ��,����ϵ����Ա��');
                    }
                });
            } else if (checkedLen == 0) {
                Common.fnLayerAlert('��������ѡ��һ�б�ʾ�����λ�ã�');
            } else {
                Common.fnLayerAlert('ÿ��ֻ��ѡ��һ����������');
            }
        }

        //��¼
        function btnZL() {
            if (Common.isCheckBoxOneChecked()) {
                var keyList = Common.getChkOneKeyToArray();
                if (keyList[1].toLocaleLowerCase() == 'false' || keyList[1] == '0') {
                    var height = "520px";
                    if (screen.height < 768)
                        height = "100%";
                    var url = "../File/FileInfoList.aspx?action=" + PageState.Edit + "&ID=" +
                            keyList[0] + "&SingleProjectID=" + GetSingleProjectID() + '&rn=' + Math.random();
                    Common.fnLayerOpen("�ļ����[" + keyList[5] + "]��Ϣ��¼", "820px", height, url, true, "��¼�ɹ�!");
                } else {
                    Common.fnLayerAlert("�빴ѡ�ļ������ļ���ϸ��¼!");
                }
            }
        }

        //��Ƭ����
        function addSingleProjectImage() {
            var strURL = "../WorkFlow/ImageWjdj.aspx?SingleProjectId=" + GetSingleProjectID() + "&WorkFlowID=" + GetWorkFlowID();
            window.top.Content.CreateTitle('���̱��[' + $('#HidsingleProjectNo').val() + ']��Ƭ�ռ�', 5, strURL);
        }

        //�ϴ�
        function btnUpload() {
            if (Common.isCheckBoxOneChecked()) {
                var keyList = Common.getChkOneKeyToArray();
                if (keyList[1].toLocaleLowerCase() == 'false' || keyList[1] == '0') {
                    var url = "../File/UpLoadEFileList.aspx?FileListID=" + keyList[0] + "&SingleProjectID=" +
                        GetSingleProjectID() + "&WorkFlowID=" + GetWorkFlowID() + '&rn=' + Math.random();
                    layer.open({
                        type: 2,
                        title: "�ļ����[" + keyList[5] + "]�����ļ��ϴ�",
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
                    Common.fnLayerAlert("�빴ѡ�ļ������ϴ��ļ�!");
                }
            }
        }

        //�鿴�����ļ� 
        function lookPDF(isFolder, bh, filelistID, SingleProjectID) {
            if (Number(isFolder) == 0) {
                if (Wjdj.CheckPdfFileExistsForFileListID(Number(filelistID)).value) {
                    var url = "../File/DocumentEdit.aspx?ID=" + filelistID + "&SingleProjectID=" + SingleProjectID + "&rn=" + Math.random();
                    window.top.parent.ParentOpenDiv('�ļ����[' + bh + ']�����ļ�Ԥ��', url, '80%', '95%');
                } else {
                    Common.fnLayerAlert("�����ļ��ڴ����ϲ�����!");
                }
            } else {
                Common.fnLayerAlert("Ŀ¼��û�е����ļ�!");
            }
        }

        //ɾ��
        function btnDel() {
            var checkedLen = $("input[type='checkbox']:checked").length;
            if (checkedLen > 0) {
                layer.confirm('ȷ��Ҫɾ��ѡ���ļ�?<br/>' + Common.getRedStrongString("ע��:ֻ��ɾ�������ļ�,ģ���ļ�����ɾ��!"), function () {
                    $("input[type='checkbox']:checked").each(function () {
                        var keyList = ($(this).val() + ',').split(',');
                        var len = Wjdj.DeleteFileList(Number(keyList[0])).value;
                    });
                    Common.fnLayerAlertAndRefresh("�ļ�ɾ���ɹ�!");
                });
            } else {
                Common.fnLayerAlert('����ѡ��һ��ſ��Բ���!');
            }
        }

        //����
        function btnSave() {
            var checkedLen = $("input[type='checkbox']:checked").length;
            if (checkedLen > 0) {
                $("input[type='checkbox']:checked").each(function () {
                    var singleProjectID = GetSingleProjectID();                      //����ID
                    var keyList = ($(this).val() + ',').split(',');                  //���ݼ���

                    if (keyList[1].toLocaleLowerCase() == 'false' || keyList[1] == '0') { //ֻ����ǽڵ�����       

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
                Common.fnLayerAlertAndRefresh("�ļ�����ɹ�!");
            } else {
                Common.fnLayerAlert('����ѡ��һ��ſ��Բ���!');
            }
        }
        //�ָ���Ŀ״̬
        function btnResetStatus() {
            var checkedLen = $("input[type='checkbox']:checked").length;
            if (checkedLen > 0) {
                $("input[type='checkbox']:checked").each(function () {
                    var keyList = ($(this).val() + ',').split(',');                  //���ݼ���

                    if (keyList[1].toLocaleLowerCase() == 'false' || keyList[1] == '0') { //ֻ����ǽڵ�����                     
                        var len = Wjdj.ResetFileStatusAndConvertFlag(GetSingleProjectID(), keyList[0]).value;
                    }
                });
                Common.fnLayerAlertAndRefresh("�ļ�״̬�ָ��ɹ�!");
            } else {
                Common.fnLayerAlert('����ѡ��һ��ſ��Բ���!');
            }
        }
        //������¼
        function btnQuickZL() {
            var checkedLen = $("input[type='checkbox']:checked").length;
            if (checkedLen > 0) {
                Common.fnLayerOpen('�ļ���¼ģ������', '460px', '350px', 'QuickWjdj.aspx?rn=' + Math.random(), false, '');
            } else {
                Common.fnLayerAlert('����ѡ��һ��ſ��Բ���!');
            }
        }
        //ǩ������ �Ƿ���Ҫǩ��,�Ƿ�ǩ������ǩ��
        function btnSignatureSet() {
            var checkedLen = $("input[type='checkbox']:checked").length;
            if (checkedLen > 0) {
                Common.fnLayerOpen('�ļ�ǩ���޸�', '360px', '183px', 'FileSignatureSet.aspx?rn=' + +Math.random(), true, '���óɹ�!');
            } else {
                Common.fnLayerAlert('����ѡ��һ��ſ��Բ���!');
            }
        }
        //��ӡ
        function btnPrint(singleProjectID, reportCode, delOldReportPDF) {
            var pdfFileName = Wjdj.ReportExportPDF(GetSingleProjectID(), 'printArchive', true).value;
            if (pdfFileName.indexOf(ResultState.Failure) < 0) {
                var url = "../ReportPdfView.aspx?pdfFileName=" + pdfFileName;
                window.top.parent.ParentOpenDiv('����Ԥ��', url, '80%', '98%');
            } else {
                Common.fnLayerAlert('����PDFת��ʧ��,����ԭ��:' + pdfFileName);
            }
        }
        //�鿴������Ϣ
        function btnLookSingle() {
            var height = "100%";
            if (screen.height >= 900) height = "680px";
            window.top.parent.ParentOpenDiv('������Ϣ-Ԥ��', '../CompanyManage/CompanyReg3_' +
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
                    <td class="condition">ҵ��λ��</td>
                    <td class="c2">
                        <uc6:ctrlDropDownCompanyInfo ID="ddlCompany" runat="server" Width="165" />
                    </td>
                    <td class="condition">�ļ����</td>
                    <td class="c2">
                        <uc5:ctrlDropDownFileList ID="ddlFileType" Width="150" bShowNO="false"
                            AutoPostBack="false" runat="server" />
                    </td>
                    <td class="condition">�ļ����ƣ�</td>
                    <td class="c2">
                        <uc1:ctrlTextBoxEx runat="server" ID="txtTitle" MaxLength="20" />
                    </td>

                    <td class="ss">
                        <asp:Button ID="btnSearch" runat="server" Text=" ��ѯ " OnClick="btnSearch_Click" />
                        <input type="button" value="�� ��" id="btnSearchParRet" />
                    </td>
                    <%--   <td>
                      <button style="float: right;" type="button" id="more_button_plus" class="more_button_plus"></button>
                    </td>--%>
                </tr>
            </table>
            <div class="moremore" style="display: block;">
                <table id="c1">
                    <tr>
                        <td class="condition">�ڲ���ţ�</td>
                        <td class="c2">
                            <uc1:ctrlTextBoxEx runat="server" ID="txtMyCode" MaxLength="20" width="162" />
                        </td>
                        <td class="condition">�ļ�״̬��</td>
                        <td colspan="4">
                            <uc2:ctrlOptStatus ID="rdbFileStatus" runat="server" />
                        </td>
                    </tr>
                    <tr id="trSignatureFinishFlag">
                        <td class="condition">�Ƿ���ǩ�£�</td>
                        <td class="c2">
                            <asp:DropDownList runat="server" ID="ddliSignaturePdf" Width="165px">
                                <asp:ListItem Text="---��ѡ��---" Value=""></asp:ListItem>
                                <asp:ListItem Text="��Ҫǩ��" Value="1"></asp:ListItem>
                                <asp:ListItem Text="����ǩ��" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="condition">ǩ���Ƿ���ɣ�</td>
                        <td class="c2">
                            <asp:DropDownList runat="server" ID="ddlSignatureFinishFlag" Width="150px">
                                <asp:ListItem Text="---��ѡ��---" Value=""></asp:ListItem>
                                <asp:ListItem Text="�����" Value="1"></asp:ListItem>
                                <asp:ListItem Text="δ���" Value="0"></asp:ListItem>
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
                    <input type="button" id="MrcBtnLookSingle" title="������ϸ��Ϣ" onclick="btnLookSingle()" value="������Ϣ" />
                    <input type="button" id="MrcBtnAdd" title="����" onclick="btnAdd()" value="����" />
                    <input type="button" id="MrcBtnSave" title="����,����ļ�����¼�����Ϣ����(�����ļ�����,������,��ͼ�ŵ�)" onclick="btnSave()" value="����" />
                    <input type="button" id="MrcBtnResetStatus" title="״̬�ָ�,����ļ���,������Ŀת����ʶ,�ļ����״̬ "
                        onclick="btnResetStatus()" value="״̬�ָ�" />
                    <input type="button" id="MrcUpload" title="����ļ�,�ϴ������ļ�" onclick="btnUpload()" value="�ϴ�" />
                    <input type="button" id="MrcBtnZL" title="��¼,����ļ���������ϸ��¼" onclick="btnZL()" value="��¼" />
                    <input type="button" id="MrcBtnQuickZL" title="�����޸�,��Թ�ѡ���ļ���,���Զ�ѡ,����ļ�����,������,��ͼ��,�γ�����,ʵ��ҳ��"
                        onclick="btnQuickZL()" value="�����޸�" />
                    <input type="button" id="MrcBtnDel" title="ɾ��,����Լ��������ļ�" onclick="btnDel()" value="ɾ��" />
                    <input type="button" id="MrcBtnSignatureSet" title="ǩ�������޸�,����ļ���" onclick="btnSignatureSet()" value="ǩ�������޸�" />
                    <input type="button" id="MrcBtnPrint" title="��ӡ�Լ�������������ļ�" onclick="btnPrint()" value="��ӡ" />
                    <input type="button" id="MrcBtnBack" title="�����б�ҳ��" onclick="Common.fnParentLayerCloseAndRefresh()" value="����" />
                </div>
                <table id="tableList">
                    <thead>
                        <tr>
                            <th width="30px" style="cursor: pointer;" onclick="Common.selCheckBoxAll(this)"
                                selall="0">ȫѡ</th>
                            <th width="60px">���</th>
                            <th width="60px">�ڲ����</th>
                            <th>�ļ�����</th>
                            <th width="120px">������</th>
                            <th width="80px">��(ͼ)��</th>
                            <th width="70px">�γ�����</th>
                            <th width="60px">ʵ��ҳ��</th>
                            <th width="60px">�ϴ�ҳ��</th>
                            <th width="60px">��Ҫ�鵵</th>
                            <th width="60px">�����Ϣ</th>
                            <th width="30px">ԭ��</th>
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
                        FirstPageText="��ҳ" LastPageText="βҳ" NextPageText="��һҳ" PrevPageText="��һҳ" PageIndexBoxStyle="text-align:right;"
                        CustomInfoHTML="���� <strong>%RecordCount%</strong> ����¼��ÿҳ <strong>%PageSize%</strong> ������ǰ�� <strong id='CurrentPageIndex'>%CurrentPageIndex%</strong> ҳ����<strong> %PageCount%</strong> ҳ"
                        UrlPaging="false" Width="100%" layouttype="Table" ShowNavigationToolTip="True"
                        ShowPageIndex="False" HorizontalAlign="Right" PageIndexBoxType="TextBox" ShowPageIndexBox="Always" SubmitButtonText="��ת" TextAfterPageIndexBox="ҳ" TextBeforePageIndexBox="ת��" AlwaysShow="True">
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
