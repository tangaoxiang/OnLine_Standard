<%@ Page Language="C#" MasterPageFile="~/SiteSon.Master" AutoEventWireup="true" CodeBehind="RoleAdd.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.RoleAdd" Title="��ɫ����" %>

<%@ Register Src="../CommonCtrl/ctrlDropDownCompanyInfo.ascx" TagName="ctrlDropDownCompanyInfo"
    TagPrefix="uc1" %>
<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc2" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownArea.ascx" TagName="ctrlDropDownArea"
    TagPrefix="uc3" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownSystemInfo.ascx" TagName="ctrlDropDownSystemInfo"
    TagPrefix="uc5" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownSystemInfo.ascx" TagName="ctrlDropDownSystemInfo" TagPrefix="uc4" %>
<asp:Content ID="Content3" ContentPlaceHolderID="Head" runat="server">
    <style type="text/css">
        select {
            height: 27px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Main" runat="server">
    <table id="tbl" runat="server" class="xzll" cellpadding="0" border="0">
        <tr>
            <td colspan="2" style="height: 5px;"></td>
        </tr>
        <tr>
            <td class="mc">�������ƣ� 
            </td>
            <td class="sr">
                <uc3:ctrlDropDownArea ID="CTRL_AREA" AutoPostBack="true" runat="server" Width="282" />
            </td>
        </tr>
        <tr>
            <td class="mc">��λ���ƣ� 
            </td>
            <td class="sr">
                <uc1:ctrlDropDownCompanyInfo ID="CompanyID" runat="server" Width="282" />
            </td>
        </tr>
        <tr>
            <td class="mc">��ɫ���ƣ� 
            </td>
            <td class="sr">
                <uc2:ctrlTextBoxEx ID="RoleName" canEmpty="false" MaxLength="50" CssClass="sour "
                    runat="server" labelTitle="��ɫ����" />
            </td>
        </tr>
        <tr>
            <td class="mc">��ɫ��ţ� 
            </td>
            <td class="sr">
                <uc2:ctrlTextBoxEx ID="RoleCode" CssClass="sour " MaxLength="30"
                    runat="server" labelTitle="��ɫ���" />
            </td>
        </tr>
        <tr>
            <td class="mc">��ɫ��� 
            </td>
            <td class="sr">
                <uc4:ctrlDropDownSystemInfo ID="RoleType" runat="server" CurrentType="RoleType" Width="282" />
            </td>
        </tr>
        <tr>
            <td class="mc">��ɫ˵���� 
            </td>
            <td class="sr">
                <uc2:ctrlTextBoxEx ID="Description" CssClass="sour " MaxLength="100"
                    runat="server" labelTitle="��ɫ˵��" />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="ljzc" style="height: 55px;">
                <asp:Button ID="btnSave" runat="server" Text="  ����  "
                    OnClientClick="return saveSubmit(this);" clickflag="ok" class="btn2" OnClick="btnSave_Click" />
                <input type="button" id="btngoBack" value=" ���� " onclick="Common.fnParentLayerClose()" />
            </td>
        </tr>
    </table>
    <script language="javascript" type="text/javascript">
        function saveSubmit(obj) {
            if (!Common.Validate('<%= RoleName.ClientID%>')) return false;
            if (!Common.Validate('<%= RoleCode.ClientID%>')) return false;

            var RoleCode = $("#<%= RoleCode.ClientID%>").val();
            if (RoleAdd.ExistsRoleCode('<%= Action%>', RoleCode, Number(<%= ID%>)).value) {
                Common.FinishExe($("#<%= RoleCode.ClientID%>"), true, "(" + RoleCode + ")�Ѵ���,������¼��!");
                return false;
            } else {
                Common.FinishExe($("#<%= RoleCode.ClientID%>"), false, null);
            }
            return Common.mouseClick(obj)
        }
    </script>
</asp:Content>