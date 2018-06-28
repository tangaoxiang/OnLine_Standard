<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignatureReportPdf.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.iSignature.SignatureReportPdf" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/Javascript/Layer/css/common.css" media="screen" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JS/jquery-1.11.2.min.js"></script>
    <script src="/Javascript/Common/Fn.js" type="text/javascript"></script>
    <script src="/Javascript/Layer/layer/layer.js" type="text/javascript"></script>
    <script type="text/javascript" src="JS/signature.js"></script>
    <script type="text/javascript">
        var ResultState = new Object();
        ResultState.Success = 'success';
        ResultState.Failure = 'failure';

        var url = '<%=mServerUrl%>';
        var id = '<%=singleProjectID%>';
        var pdfFileName = '<%=pdfFileName%>';
        var reportType = '<%=reportType%>';
        $(function () {
            for (var i = 1; i < iWebPDF2015.CommandBars.Count; i++) {
                iWebPDF2015.CommandBars.Item(i).Visible = false;
            }
            iWebPDF2015.CommandBars.Item("DigitalSignature").Visible = true;
            iWebPDF2015.Options.TabBarVisible = false;
            WebOpen(id);
        });

        //保存
        function save() {
            if (typeof (id) != "undefined") {
                var st = saveFile(id);
                if (st.indexOf(ResultState.Success) > -1) {      //暂时未考虑是否签章完成了在移动文件,只要保存成功一次就移动一次. 
                    if (reportType.toLowerCase() == "<%= DigiPower.Onlinecol.Standard.Web.SystemSet.EumReportType.ZRS.ToString().ToLower()%>") {
                        addAndmove('<%=DigiPower.Onlinecol.Standard.Web.SystemSet.EumSignatureOperationType.ZRS_Signature.ToString()%>', '<%=DigiPower.Onlinecol.Standard.Web.SystemSet._ZRS_TOFILELISTTMPRECIDS%>');
                    }
                    else if (reportType.toLowerCase() == "<%= DigiPower.Onlinecol.Standard.Web.SystemSet.EumReportType.RKZ.ToString().ToLower()%>") {
                        addAndmove('<%=DigiPower.Onlinecol.Standard.Web.SystemSet.EumSignatureOperationType.RKZ_Signature.ToString()%>', '<%=DigiPower.Onlinecol.Standard.Web.SystemSet._RKZ_TOFILELISTTMPRECIDS%>');
                    }
                    else if (reportType.toLowerCase() == "<%= DigiPower.Onlinecol.Standard.Web.SystemSet.EumReportType.ZMS.ToString().ToLower()%>") {
                        addAndmove('<%=DigiPower.Onlinecol.Standard.Web.SystemSet.EumSignatureOperationType.ZMS_Signature.ToString()%>', '<%=DigiPower.Onlinecol.Standard.Web.SystemSet._ZMS_TOFILELISTTMPRECIDS%>');
                    }
        }
    }
}
function addAndmove(operationType, fileListTmpRecIDS) {
    var logLen = SignatureReportPdf.SignatureFinish(id, operationType).value;
    if (logLen.indexOf(ResultState.Success) > -1) {
        var fileLen = SignatureReportPdf.MoveFileToFileTmp(id, pdfFileName, fileListTmpRecIDS).value;
        if (fileLen.indexOf(ResultState.Failure) > -1) {
            Common.fnLayerAlert('文件移动操作失败,原因:' + pdfFileName);
        } else {
            $("#iWebPDF2015").css("display", "none");
            layer.alert('签章完成!', { btnAlign: 'c' }, function (index) {
                var pindex = parent.layer.getFrameIndex(window.name);
                parent.layer.close(pindex);
            });
        }
    } else {
        Common.fnLayerAlert('签章日志保存失败,原因:' + pdfFileName);
    }
}

function down() {//下载                   
    if (pdfFileName != "") {
        window.parent.location.href = "../ReportPDFDown.aspx?pdfFileName=" + pdfFileName;
    }
}
    </script>

</head>
<body>
    <form id="form1" runat="server">
    </form>
    <table class="zpxxxj" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="lljzc">
                <input type="button" value=" 签章保存 " onclick="save()" />
                <input type="button" value=" 下载 " onclick="down()" />
                <input type="button" id="btngoBack" value=" 关闭 " onclick="Common.fnParentLayerClose()" />
            </td>
        </tr>
    </table>
    <object id="iWebPDF2015" style="width: 100%; height: 100%;"
        classid="CLSID:7017318C-BC50-4DAF-9E4A-10AC8364C315">
    </object>
    <script language="javascript" type="text/javascript">
        $("#iWebPDF2015").css("height", $(this).height() - 40 + "px");
    </script>
</body>
</html>
