<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BatchUpload.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.WorkFlow.BatChUpload" %>

<%@ Import Namespace="DigiPower.Onlinecol.Standard.Web" %>
<%@ Import Namespace="DigiPower.Onlinecol.Standard.Common" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>批量上传</title>
    <link href="CSS/Style.css" rel="stylesheet" type="text/css" />
    <link href="CSS/uploadify.css" rel="stylesheet" type="text/css" />
    <script src="JS/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="JS/swfobject.js" type="text/javascript"></script>
    <script src="JS/jquery.uploadify.v2.1.0.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#uploadify").uploadify({
                'uploader': 'JS/uploadify.swf',
                'script': 'UploadHandler.ashx',
                'scriptData': { 'ID': '<%= pid%>' },
                'method': 'get',
                'cancelImg': 'JS/cancel.png',
                'fileExt': '*.jpg;*.jpeg',
                'fileDesc': '请选择 *.jpg;*.jpeg 格式文件',
                'folder': '',
                'queueID': 'fileQueue',
                'auto': false,
                'multi': true,
                'buttonText': ' ',
                'buttonImg': 'JS/xzwj.png',
                'sizeLimit': <%= ConvertEx.ToInt(SystemSet._FILESIZE)*1000000%>,
                'onSelectOnce': function (event, data) {
                    //if(data>10)
                }
            });
        });
    </script>
    <style type="text/css">
        a {
            font-weight: bold;
        }

        .uploadifyQueueItem {
            border: 1px solid #dddddd;
            margin: 4px;
            width: auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 100%;">
            <div class="box" style="padding-bottom: 2px;">
                <div class="box2" style="height: 350px;">
                    <div style="width: 400px; height: 31px; padding-left: 13px;">
                        <div style="width: 110px; height: 31px; float: left;">
                            <input type="file" name="uploadify" id="uploadify" />
                        </div>
                        <div style="width: 110px; height: 31px; line-height: 31px; float: right;">
                            <a href='javascript:$("#uploadify").uploadifyUpload()'>上传</a>&nbsp;|&nbsp; <a href="javascript:$('#uploadify').uploadifyClearQueue()">取消上传</a>
                        </div>
                    </div>
                    <div id="fileQueue" style="height: 310px; width: 480px;">
                    </div>
                </div>
            </div>
        </div>
        <strong style="color: red; font-size: 13px;">说明:单份文件最大<%= DigiPower.Onlinecol.Standard.Web.SystemSet._FILESIZE%>M,文件格式:*.jpg;*.jpeg
        </strong>
    </form>
</body>
</html>
