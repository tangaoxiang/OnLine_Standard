<%@ Page Language="C#" MasterPageFile="~/SiteSon.Master" AutoEventWireup="true" CodeBehind="CompanyReg2Edit.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.CompanyReg2Edit" Title="项目管理" %>

<%@ Register Src="../CommonCtrl/ctrlDropDownCompanyInfo.ascx" TagName="ctrlDropDownCompanyInfo"
    TagPrefix="uc1" %>
<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc2" %>

<%@ Register Src="../CommonCtrl/ctrlConstructionBaseInfo.ascx" TagName="ctrlConstructionBaseInfo"
    TagPrefix="uc4" %>
<%@ Register Src="../CommonCtrl/ctrlConstructionExtInfo.ascx" TagName="ctrlConstructionExtInfo"
    TagPrefix="uc5" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Main" runat="server">

    <uc4:ctrlConstructionBaseInfo ID="ctrlConstructionBaseInfo1" runat="server" />

    <table class="xzll" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="ljzc" style="height: 45px;">
                <asp:Button ID="btnSave" runat="server" Text=" 保存 "
                    OnClientClick="return saveSubmit(this);" clickflag="ok" CssClass="btn2" OnClick="btnSave_Click" />
                <input type="button" id="btngoBack" value=" 返回 " onclick="Common.fnParentLayerClose()" />
            </td>
        </tr>
    </table>
    <script language="javascript" type="text/javascript">
        function saveSubmit(obj) {   
            var flag = true;
            $("input[type='text']").each(function () {
                flag = Common.Validate($(this).attr("id"));
                if (!flag)
                    return false;
            });
            if (!flag) {
                return false;
            }
            return Common.mouseClick(obj)
        }
    </script>
</asp:Content>
