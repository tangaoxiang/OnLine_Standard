<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true"
    CodeBehind="BlankPage.aspx.cs" Inherits="DigiPower.Onlinecol.Standard.Web.BlankPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <iframe id="I2" name="I2" height="95%" width="99%" border="0" frameborder="0" runat="server"
        scrolling="auto" style="overflow: auto" src="MyTaskList.aspx"></iframe>
</asp:Content>
