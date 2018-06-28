<%@ Page Language="C#" MasterPageFile="~/SiteSon.Master" AutoEventWireup="true" CodeBehind="ModuleAdd.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.ModuleAdd" Title="ģ�����" %>

<%@ Register Src="../CommonCtrl/ctrlDropDownCompanyInfo.ascx" TagName="ctrlDropDownCompanyInfo"
    TagPrefix="uc1" %>
<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc2" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownModule.ascx" TagName="ctrlDropDownModule"
    TagPrefix="uc3" %>

<%@ Register Src="../CommonCtrl/ctrlCheckBoxList.ascx" TagName="ctrlCheckBoxList" TagPrefix="uc4" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Head" runat="server">
    <style type="text/css">
        select {
            height: 27px;
        }

        .dxan td {
            height: 24px;
        }

        .sour {
            width: 550px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Main" runat="server">
    <table id="tbl" runat="server" class="xzll" cellpadding="0" border="0" style="width: 800PX;">
        <tr>
            <td colspan="2" style="height: 5px;"></td>
        </tr>
        <tr>
            <td class="mc">�ϼ���
            </td>
            <td class="sr">
                <uc3:ctrlDropDownModule ID="ParentID" runat="server" Width="282" CssClass="sour" />
            </td>
        </tr>
        <tr>
            <td class="mc">ģ�����ƣ�
            </td>
            <td class="sr">
                <uc2:ctrlTextBoxEx ID="ModuleName" canEmpty="false" labelTitle="ģ������" runat="server" MaxLength="10" CssClass="sour" />
            </td>
        </tr>
        <tr>
            <td class="mc">ģ���ţ�
            </td>
            <td class="sr">
                <uc2:ctrlTextBoxEx ID="BH" labelTitle="ģ����" runat="server" MaxLength="10" CssClass="sour" />
            </td>
        </tr>

        <tr>
            <td class="mc">�ļ����ƣ�
            </td>
            <td class="sr">
                <uc2:ctrlTextBoxEx ID="FileName" Status="Add" runat="server" MaxLength="100" CssClass="sour" />
            </td>
        </tr>
        <tr>
            <td class="mc">�����ţ�
            </td>
            <td class="sr">
                <uc2:ctrlTextBoxEx ID="OrderIndex" runat="server" MaxLength="3" mode="Int" labelTitle="������" CssClass="sour" />
            </td>
        </tr>
        <tr>
            <td class="mc">�Ƿ�ɼ���
            </td>
            <td class="sr dxan">
                <asp:CheckBox runat="server" ID="IfVisible" Checked="True"></asp:CheckBox>
            </td>
        </tr>
        <tr>
            <td class="mc">�Ƿ���ҳ��
            </td>
            <td class="sr dxan">
                <asp:CheckBox runat="server" ID="IfInsidePage"></asp:CheckBox>
            </td>
        </tr>
        <tr>
            <td class="mc">Ȩ�ް�ť��
            </td>
            <td class="sr dxan">
                <uc4:ctrlCheckBoxList ID="chkMenuRight" runat="server" repeatColumns="5" />
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
            if (!Common.Validate('<%= ModuleName.ClientID%>')) return false;
            if (!Common.Validate('<%= OrderIndex.ClientID%>')) return false;
            return Common.mouseClick(obj)
        }
    </script>
</asp:Content>
