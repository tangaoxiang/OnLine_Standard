<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="getRsaPrivateKey.aspx.cs" Inherits="DigiPower.Onlinecol.Standard.Web.RsaKey.getRsaPrivateKey" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <fieldset>
            <legend>RSA私匙</legend>
            <asp:TextBox runat="server" ID="txtRsaPrivateKey"
                Style="border: 0px solid; width: 100%; height: 300px; font-size: 13px;"
                TextMode="MultiLine" Rows="10"></asp:TextBox>
        </fieldset>
    </form>
</body>
</html>
