<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BatchSignaturePdf.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.BatchSignaturePdf" %>

<%@ Import Namespace="DigiPower.Onlinecol.Standard.Web" %>
<%@ Import Namespace="DigiPower.Onlinecol.Standard.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>批量签章</title>
    <link href="/Javascript/Layer/css/common.css" media="screen" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JS/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../Javascript/Common/Fn.js"></script>
    <script type="text/javascript" src="JS/json2-min.js"></script>
    <script type="text/javascript" src="../Javascript/Layer/layer/layer.js"></script>
    <script type="text/javascript" src="JS/signature.js"></script>
    <script type="text/javascript" src="JS/hashMap.js"></script>
    <script type="text/javascript">
        var ResultState = new Object();
        ResultState.Success = 'success';
        ResultState.Failure = 'failure';
        var url = '<%=mServerUrl%>';
        var id = '<%=ID%>';
        $(function () {
            for (var i = 0; i < iWebPDF2015.CommandBars.Count; i++) {
                iWebPDF2015.CommandBars.Item(i).Visible = false;
            }
            iWebPDF2015.CommandBars.Item("DigitalSignature").Visible = true;
            iWebPDF2015.Options.TabBarVisible = false;

            WebOpen(id);
            $("#hidSignatureCount").val(iWebPDF2015.Documents.ActiveDocument.Fields.SignatureCount);
        });
    </script>
    <style type="text/css">
        .text {
            width: 140px;
        }

        .button {
            width: 60px;
        }

        .td1 {
            width: 90px;
            text-align: right;
        }
    </style>

    <script type="text/javascript">
        function btnStart() {
            $msg = $("#sploadMsg");
            var $selSignatureType = $("#selSignatureType");
            if ($.trim($selSignatureType.val()) == "0") {
                $selSignatureType.focus();
                $msg.text("请选择签章类型!");
                return;
            }
            var $keyPwd = $("#keyPwd");
            if ($.trim($keyPwd.val()) == "") {
                $keyPwd.focus();
                $msg.text("请输入签章KEY密码!");
                return;
            }
            var SMObj = document.getElementById("SMObj");
            var len = Number(SMObj.VerifyPin($keyPwd.val()));
            if (len != "0") {
                $msg.text("签章KEY密码不正确,请重新输入!");
                return;
            }
            var $chkSignatureAllPagePdf = $("#chkSignatureAllPagePdf");
            var $txtPagen = $("#txtPagen");
            var reg = /^[0-9,]+$/;
            if (!$chkSignatureAllPagePdf.is(":checked")) {
                if ($.trim($txtPagen.val()) == "") {
                    $txtPagen.focus();
                    $msg.text("请输入需要签章的页码!");
                    return;
                }
                if (!reg.test($.trim($txtPagen.val()))) {
                    $txtPagen.focus();
                    $msg.text("页码格式错误,只能是数字,多个页码用,隔开!");
                    return;
                }
            }
            var nowSignatureCount = Number(iWebPDF2015.Documents.ActiveDocument.Fields.SignatureCount);
            var hidSignatureCount = Number($("#hidSignatureCount").val());
            if (nowSignatureCount < 1 || nowSignatureCount <= hidSignatureCount) {
                $msg.text("必须先先盖一个章确定后续文件批量盖章位置!");
                layer.msg(Common.getRedStrongString("温馨提示:本系统优先支持IE11"), { icon: 5, time: 3000 });
                return;
            }

            $msg.text("");
            var fields = iWebPDF2015.Documents.ActiveDocument.Fields;
            var count = fields.SignatureCount;//签名域的数量

            var hashMapX = new hashmap();
            var hashMapY = new hashmap();
            var arDt = new Array();

            for (var i = 0; i < count; i++) {
                var sigfield = fields.SignatureField(i); //获取每个图片域对象   
                var dt = sigfield.Signature.SignatureDate;//获取图片域的签章日期(日期+时间)
                var key = dt.substring(dt.indexOf(":") + 1, dt.indexOf("+"));

                arDt.push(key);
                hashMapX.put(key, (parseInt(sigfield.widget.Left) + parseInt(sigfield.widget.Width / 2)));
                hashMapY.put(key, (parseInt(sigfield.widget.Bottom) + parseInt(sigfield.widget.Height / 2)));
            }

            arDt.sort();//排序签章日期 获取最后一个签章日期.即当前用户预签的章及其位置

            if (arDt.length > 0 && !hashMapX.isEmpty() && !hashMapY.isEmpty()) {
                var chkSignatureDtflag = $("#chkSignatureDt").is(":checked") ? 1 : 0;           //是否签日期
                var chkSignatureAllPagePdfflag = $chkSignatureAllPagePdf.is(":checked") ? 1 : 0;//是否签所有页
                var signaturePagen = $txtPagen.val();                                           //待签章的页码

                calculateHash($selSignatureType.val(), $("#hidfileIDS").val(), $.trim($keyPwd.val()),
                   hashMapX.get(arDt[arDt.length - 1]), hashMapY.get(arDt[arDt.length - 1]),
                   chkSignatureDtflag, chkSignatureAllPagePdfflag, signaturePagen);
            }
        }
        function setDefualtPagen() {
            var $chkSignatureAllPagePdf = $("#chkSignatureAllPagePdf");
            var $txtPagen = $("#txtPagen");
            if (!$chkSignatureAllPagePdf.is(":checked")) {
                $txtPagen.val("1");
            } else {
                $txtPagen.val("");
            }
        }
    </script>

    <style type="text/css">
        .divTree {
            border: 1px solid #e2e2e2;
            border-radius: 2px;
            padding: 0px;
            overflow: auto;
            float: left;
        }

        .td1 {
            width: 100px;
        }

        a {
            color: black;
        }

            a:hover {
                color: black;
            }

        #sploadMsg {
            font-weight: bold;
            font-size: 13px;
            width: 100%;
            color: red;
        }

        select {
            height: 25px;
            font-size: 13px !important;
            border: 1px solid #dddddd !important;
        }
    </style>
</head>
<body>
    <div class="content-box-content" style="float: left; width: 100%">
        <form id="form1" runat="server">
        </form>
        <div style="width: 300px;" id="divLeft" class="divTree">
            <table class="zpxxxj" border="0" cellspacing="0" cellpadding="0" style="width: 98%;">
                <tr>
                    <td style="height: 10px; font-size: 12px; text-align: left;" colspan="2">
                        <fieldset style="font-size: 13px;">
                            <legend>注意事项</legend>
                            <strong>1:必须预签一份PDF确定位置，才能批量签</strong>
                            <br />
                            <strong>2:默认加载第一份PDF</strong>
                        </fieldset>
                        <input type="hidden" id="hidfileIDS" value="<%= DNTRequest.GetQueryString("fileIDS")%>" />
                        <input type="hidden" id="hidSignatureCount" value="0" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <fieldset style="font-size: 13px;">
                            <legend>签章选项</legend>
                            <table style="width: 100%;">
                                <tr>
                                    <td class="td1">签章类型:</td>
                                    <td>
                                        <select id="selSignatureType" style="width: 170px; height: 26px;">
                                            <option selected="selected" value="0">---请选择---</option>
                                            <option value="1">签公章</option>
                                            <option value="2">签私章</option>
                                        </select>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td1">签章Key密码:</td>
                                    <td>
                                        <input type="text" maxlength="20" id="keyPwd" style="width: 170px;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td1">是否签日期:</td>
                                    <td>
                                        <input type="checkbox" id="chkSignatureDt" style="width: 18px; height: 18px;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td1" title="是否对PDF的每页都签章">是否签所有页:</td>
                                    <td>
                                        <input type="checkbox" id="chkSignatureAllPagePdf" onclick="setDefualtPagen()"
                                            style="width: 18px; height: 18px;" checked="checked" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td1" title="签到指定的页数上,当指定的页数大于PDF的实际页数,则签章失败">待签章的页码:</td>
                                    <td>
                                        <input type="text" maxlength="20" id="txtPagen" style="width: 170px;" title="只能是数字,多个用,隔开" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="lljzc">
                                        <input type="button" onclick="btnStart()" value=" 批量签章 " />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 26px;">
                                        <span id="sploadMsg"></span>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: 13px; text-align: center;">
                        <fieldset style="font-size: 13px;">
                            <legend>待批签文件列表</legend>
                            <asp:Literal runat="server" ID="ltHtml" Visible="true"></asp:Literal>
                        </fieldset>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divRight" class="divTree">
            <object id="CryptAPICtrl" classid="clsid:BCE5CCE5-959F-4DC0-BCF3-6C2916D48AA2" codebase="KG_Crypt_COM_API.dll#version=1,0,0,1" style="display: none;"></object>
            <object id="SMObj" width="0" style="display: none;" height="0" classid="clsid:E5C44C76-610A-4C1F-9083-6CE933E3DC1D"></object>

            <object id="iWebPDF2015" style="width: 720px; height: 530px;"
                classid="CLSID:7017318C-BC50-4DAF-9E4A-10AC8364C315">
            </object>
        </div>
    </div>

    <script language="javascript" type="text/javascript">
        function setCss() {
            $("#iWebPDF2015").css("height", document.documentElement.clientHeight - 20 + "px");
            $("#iWebPDF2015").css("width", document.documentElement.clientWidth - 310 + "px");
        }
        window.onresize = function () {
            setCss();
        }
        window.onload = function () {
            setCss();
        }
    </script>
</body>
</html>
