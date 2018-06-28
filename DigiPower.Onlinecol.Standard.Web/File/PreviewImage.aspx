<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PreviewImage.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.File.PreviewImage" EnableViewState="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>照片预览</title>
    <link href="PreviewImage/css/list.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">

        <div class="dWrap">
            <div class="dPicList">

                <div id="dPicListBody" class="dBigList">
                    <span id="sLeftBtnA" class="sLeftBtnABan"></span>
                    <span id="sRightBtnA" class="sRightBtnA"></span>
                    <ul class="ulBigPic">
                        <asp:Literal runat="server" ID="ltImagBig"></asp:Literal>
                    </ul>
                    <div class="dSmallPicBox">
                        <div class="dSmallPic">
                            <ul class="ulSmallPic" style="width: 2646px; left: 0px" rel="stop">
                                <asp:Literal runat="server" ID="ltImageSmall"></asp:Literal>
                            </ul>
                        </div>
                        <span id="sLeftBtnB" class="sLeftBtnBBan"></span>
                        <span id="sRightBtnB" class="sRightBtnB"></span>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>

<script type="text/javascript" src="PreviewImage/js/jquery-1.6.2.min.js"></script>
<script type="text/javascript" src="PreviewImage/js/list.js"></script>
</html>
