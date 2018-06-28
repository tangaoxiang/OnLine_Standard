﻿<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="DefaultMyTaskList.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.DefaultMyTaskList" Title="" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div style="position: absolute; top: 0; left: 0; width: 100%; height: 100%; z-index: -1; margin: 0; padding: 0; overflow: hidden;">
        <img src="../Javascript/Layer/image/backg.png" style="height: 100%; width: 100%" alt="" />
    </div>
    <div class="container" id="container">
        <ul class="showcase">
            <asp:Literal runat="server" ID="ltWorkFlow"></asp:Literal>
        </ul>
    </div>
    <script type="text/javascript">
        function setCss() {
            $("#container").css("margin-top", ((document.documentElement.clientHeight / 2) - 210) + "px");
        }
        window.onresize = function () {
            setCss();
        }
        window.onload = function () {
            setCss();
        }
    </script>
</asp:Content>
