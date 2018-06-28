<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportPdfView.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.ReportPdfView" %>

<html>
<head runat="server">
    <title>报表预览</title>
    <script type="text/javascript" src="Javascript/Layer/js/jquery-1.9.1.min.js"></script>
</head>
<body style="margin: 0px; padding: 0px;">
    <form id="form1" runat="server">
        <object classid="clsid:CA8A9780-280D-11CF-A24D-444553540000" id="pdf1"
            style="margin: 0px; padding: 0px; width: 100%; height: 98%; min-height: 630px">
            <param name="src" id="pdf_src" value="<%=pdfURL%>">
        </object>
    </form>
    <script type="text/javascript">
        document.getElementById('pdf1').setShowToolbar(true);
        document.getElementById('pdf1').setShowScrollbars(true);  

    </script>
</body>
</html>
