<%@ Page Language="C#" MasterPageFile="~/SiteSon.Master" AutoEventWireup="true" CodeBehind="AreaAdd.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.AreaAdd" Title="机构管理" %>

<%@ Register Src="../CommonCtrl/ctrlDropDownArea.ascx" TagName="ctrlDropDownArea"
    TagPrefix="uc2" %>
<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc3" %>

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
            <td class="mc">上级机构： 
            </td>
            <td class="sr">
                <uc2:ctrlDropDownArea ID="PID" runat="server" Width="282" />
            </td>
        </tr>
        <tr>
            <td class="mc">机构代码： 
            </td>
            <td class="sr">
                <uc3:ctrlTextBoxEx ID="area_code" runat="server" canEmpty="false" CssClass="sour"
                    mode="Int" MaxLength="6" labelTitle="机构代码" />
            </td>
        </tr>
        <tr>
            <td class="mc">机构名称： 
            </td>
            <td class="sr">
                <uc3:ctrlTextBoxEx ID="area_name" canEmpty="false" CssClass="sour" MaxLength="15"
                    runat="server" labelTitle="机构名称" />
            </td>
        </tr>
        <tr>
            <td class="mc">排序编号： 
            </td>
            <td class="sr">
                <uc3:ctrlTextBoxEx ID="OrderIndex" canEmpty="false" CssClass="sour " MaxLength="3"
                    mode="Int" runat="server" labelTitle="排序编号" />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="ljzc" style="height: 55px;">
                <asp:Button ID="btnSave" runat="server" Text="  保存  "
                    OnClientClick="return saveSubmit(this);" clickflag="ok" class="btn2" OnClick="btnSave_Click" />
                <input type="button" id="btngoBack" value=" 返回 " onclick="Common.fnParentLayerClose()" />
            </td>
        </tr>
    </table>
    <script language="javascript" type="text/javascript">
        function saveSubmit(obj) {
            if (!Common.Validate('<%= area_code.ClientID%>')) return false;
            if (!Common.Validate('<%= area_name.ClientID%>')) return false;
            if (!Common.Validate('<%= OrderIndex.ClientID%>')) return false;

            var AreaCode = $("#<%= area_code.ClientID%>").val();
            if (AreaAdd.ExistsAreaCode('<%= Action%>', AreaCode, Number(<%= ID%>)).value) {
                Common.FinishExe($("#<%= area_code.ClientID%>"), true, "(" + AreaCode + ")已存在,请重新录入!");
                return false;
            } else {
                Common.FinishExe($("#<%= area_code.ClientID%>"), false, null);
            }
            return Common.mouseClick(obj)
        }
    </script>
</asp:Content>
