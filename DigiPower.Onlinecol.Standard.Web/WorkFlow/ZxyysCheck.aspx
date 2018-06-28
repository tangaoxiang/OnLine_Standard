<%@ Page Title="" Language="C#" MasterPageFile="~/SiteSon.Master" 
    AutoEventWireup="true" CodeBehind="ZxyysCheck.aspx.cs" Inherits="DigiPower.Onlinecol.Standard.Web.WorkFlow.ZxyysCheck" %>

<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <style type="text/css">
        select {
            height: 27px;
        }  
        .txtMultiLine {
            font-size: 13px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <table id="tbl" runat="server" class="xzll" cellpadding="0" border="0">
        <tr>
            <td colspan="2" style="height: 25px;"></td>
        </tr>
        <tr>
            <td class="mc">审核人： 
            </td>
            <td class="sr">
                <uc3:ctrlTextBoxEx ID="txtDoUserName" runat="server" CssClass="sour" readOnly="true" />
            </td>
        </tr>
        <tr>
            <td class="mc">审核时间： 
            </td>
            <td class="sr">
                <uc3:ctrlTextBoxEx ID="txtDoDateTime" runat="server" CssClass="sour" readOnly="true" />
            </td>
        </tr>
        <tr>
            <td class="mc">审核结果： 
            </td>
            <td class="sr">
                <asp:DropDownList runat="server" ID="ddlDoResult" Width="280">
                    <asp:ListItem Value="" Text="----请选择----"></asp:ListItem>
                    <asp:ListItem Value="0" Text="预验收不通过"></asp:ListItem>
                    <asp:ListItem Value="1" Text="预验收通过"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="mc">审核意见： 
            </td>
            <td class="sr">
                <uc3:ctrlTextBoxEx labelTitle="审核意见" ID="DoRemark" width="278" height="90"
                    runat="server" MaxLength="200" CssClass="sour txtMultiLine" TextMode="MultiLine" Rows="4" />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="ljzc" style="height: 75px;">
                <asp:Button ID="btnSave" runat="server" Text="  保存  " OnClick="btnSave_Click"
                    OnClientClick="return saveSubmit(this);" clickflag="ok" class="btn2" />
                <input type="button" id="btngoBack" value=" 返回 " onclick="Common.fnParentLayerClose()" />
            </td>
        </tr>
    </table>
    <script language="javascript" type="text/javascript">
        function saveSubmit(obj) {
            if ($("#ctl00_Main_ddlDoResult").val() == "") {
                Common.fnLayerAlert("请选择审核结果!");
                return false;
            }
            return Common.mouseClick(obj)
        }
    </script>
</asp:Content>
