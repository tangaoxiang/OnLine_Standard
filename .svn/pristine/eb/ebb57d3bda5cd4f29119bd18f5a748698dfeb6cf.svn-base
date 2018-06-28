<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocumentEdit.aspx.cs" Inherits="DigiPower.Onlinecol.Standard.Web.iwebpdf.DocumentEdit" %>

<html>
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html;">
    <title>电子文件预览</title>
    <script type="text/javascript" src="../Javascript/Layer/js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript">
        function loadPdf(obj, valSrc) {
            document.getElementById('pdf1').src = valSrc;
            document.getElementById('pdf1').gotoFirstPage();
            $(".divTree").find("input[type='button']").attr("class", "button");
            $(obj).addClass("buttonFileList");
        }
    </script>
    <style type="text/css">
        .buttonFileList {
            background-color: #3281BA;
            padding-top: 3px;
            line-height: 23px;
            border: 0px;
            color: white;
            font-size: 13px;
        }

        .button {
            padding-top: 3px;
            line-height: 23px;
            border: 0px;
            color: white;
            font-size: 13px;
        }

        .divTree {
            border: 1px solid #e2e2e2;
            border-radius: 2px;
            padding: 2px;
            overflow: auto;
            height: 30px;
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Literal runat="server" ID="ltBtnHtml"></asp:Literal>
        <object classid="clsid:CA8A9780-280D-11CF-A24D-444553540000" id="pdf1" height="100%" width="100%" border="0">
            <param name="src" id="pdf_src" value="<%=mEFilePath%>">
        </object>
        <script type="text/javascript">
            if (document.getElementById('pdf1') != null) {
                document.getElementById('pdf1').setShowToolbar(true);
                document.getElementById('pdf1').setShowScrollbars(true);
                if (!$.support.leadingWhitespace) {
                    if ($(".divTree").length > 0)
                        document.getElementById('pdf1').style.height = document.documentElement.clientHeight - 20 - 45 + "px";
                    else
                        document.getElementById('pdf1').style.height = document.documentElement.clientHeight - 20 - 20 + "px";
                } else {
                    if ($(".divTree").length > 0)
                        document.getElementById('pdf1').style.height = document.documentElement.clientHeight - 45 + "px";
                    else
                        document.getElementById('pdf1').style.height = document.documentElement.clientHeight - 20 + "px";
                }
            }
        </script>

    </form>
</body>
</html>


