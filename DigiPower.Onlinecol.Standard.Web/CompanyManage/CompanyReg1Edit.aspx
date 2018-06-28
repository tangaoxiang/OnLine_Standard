<%@ Page Language="C#" MasterPageFile="~/SiteSon.Master" AutoEventWireup="true" CodeBehind="CompanyReg1Edit.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.CompanyReg1Edit" Title="��λ����" %>

<%@ Register Src="../CommonCtrl/ctrlCompanyBaseInfo.ascx" TagName="ctrlCompanyBaseInfo"
    TagPrefix="uc6" %>
<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc1" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownSingleProject.ascx" TagName="ctrlDropDownSingleProject"
    TagPrefix="uc2" %>
<%@ Register Src="~/CommonCtrl/ctrlDropDownArea.ascx" TagName="ctrlDropDownArea" TagPrefix="uc4" %>
<asp:Content ID="Content3" ContentPlaceHolderID="Head" runat="server">
    <style type="text/css">
        select {
            height: 27px;
            width: 243px;
        }

        .dd {
            width: 232px !important;
        }

        .cd {
            width: 659px !important;
        }

        .zpxxxj {
            width: 850px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Main" runat="server">
    <uc6:ctrlCompanyBaseInfo ID="ctrlCompanyBaseInfo1" runat="server" />
    <table class="zpxxxj" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td colspan="4" style="height: 25px;"><strong>��¼�ʺ���Ϣ</strong></td>
        </tr>
        <tr>
            <td class="ww">��¼�˺ţ�</td>
            <td colspan="3">
                <uc1:ctrlTextBoxEx ID="txtLogName" labelTitle="��¼�˺�" runat="server" canEmpty="false" CssClass="cd" MaxLength="12" />
            </td>
        </tr>
        <tr>
            <td class="ww">��¼���룺</td>
            <td colspan="3">
                <uc1:ctrlTextBoxEx ID="txtPwd" labelTitle="��¼����" runat="server" TextMode="Password" canEmpty="false" MaxLength="12" CssClass="cd" />
            </td>
        </tr>
        <tr>
            <td class="ww">ȷ�����룺</td>
            <td colspan="3">
                <uc1:ctrlTextBoxEx ID="txtPwd2" labelTitle="ȷ������" runat="server" TextMode="Password" canEmpty="false" MaxLength="12" CssClass="cd" />
            </td>
        </tr>

    </table>
    <table class="zpxxxj" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="lljzc">
                <asp:HiddenField ID="HidUserID" runat="server" Value="0" />
                <asp:Button ID="btnSave" runat="server" Text=" ���� "
                    OnClientClick="return saveSubmit(this);" clickflag="ok" OnClick="btnSave_Click" />
                <input type="button" id="btngoBack" value=" ���� " onclick="Common.fnParentLayerClose()" />
            </td>
        </tr>
    </table>
    <br />
    <script language="javascript" type="text/javascript">
        function saveSubmit(obj) {
            var flag = true;
            $("input[type='text'],input[type='password']").each(function () {
                flag = Common.Validate($(this).attr("id"));
                if (!flag)
                    return false;
            });
            if (!flag) {
                return false;
            }

            var $CompanyCode = $("#ctl00_Main_ctrlCompanyBaseInfo1_CompanyCode_TextBox1");
            if (CompanyReg1Edit.CheckCompanyCode('<%= Action%>', Number(<%= ID%>), $CompanyCode.val()).value) {
                Common.FinishExe($CompanyCode, true, "(" + $CompanyCode.val() + ")�Ѵ���,������¼��!");
                return false;
            } else {
                Common.FinishExe($CompanyCode, false, null);
            }
            var $CompanyEmail = $("#ctl00_Main_ctrlCompanyBaseInfo1_EMail_TextBox1");
            if (CompanyReg1Edit.CheckCompanyEmail('<%= Action%>', Number(<%= ID%>), $CompanyEmail.val()).value) {
                Common.FinishExe($CompanyEmail, true, "(" + $CompanyEmail.val() + ")�Ѵ���,������¼��!");
                return false;
            } else {
                Common.FinishExe($CompanyEmail, false, null);
            }

            var LoginNameValue = $("#<%= txtLogName.ClientID%>").val();
            var UserId = $("#<%= HidUserID.ClientID%>").val();
            if (CompanyReg1Edit.CheckLoginName('<%= Action%>', Number(UserId), LoginNameValue).value) {
                Common.FinishExe($("#<%= txtLogName.ClientID%>"), true, "(" + LoginNameValue + ")�Ѵ���,������¼��!");
                return false;
            } else {
                Common.FinishExe($("#<%= txtLogName.ClientID%>"), false, null);
            }

            if (LoginNameValue.length < 6 || LoginNameValue.length > 12) {
                Common.FinishExe($("#<%= txtLogName.ClientID%>"), true, "���ȱ������6-12֮��!");
                return false;
            } else {
                Common.FinishExe($("#<%= txtLogName.ClientID%>"), false, null);
            }

            var PasswdValue = $("#<%= txtPwd.ClientID%>").val();
            var PasswdValue2 = $("#<%= txtPwd2.ClientID%>").val();
            if (PasswdValue.length < 6 || PasswdValue.length > 12) {
                Common.FinishExe($("#<%= txtPwd.ClientID%>"), true, "���ȱ������6-12֮��!");
                return false;
            } else {
                Common.FinishExe($("#<%= txtPwd.ClientID%>"), false, null);
                Common.FinishExe($("#<%= txtPwd2.ClientID%>"), false, null);
            }
            if (!CompanyReg1Edit.CheckPassword(PasswdValue).value) {
                Common.FinishExe($("#<%= txtPwd.ClientID%>"), true, "���������ֺ���ĸ�����!");
                return false;
            } else {
                Common.FinishExe($("#<%= txtPwd.ClientID%>"), false, null);
            }
            if (PasswdValue != PasswdValue2) {
                Common.FinishExe($("#<%= txtPwd.ClientID%>"), true, "��������Ĳ�һ��!");
                return false;
            } else {
                Common.FinishExe($("#<%= txtPwd.ClientID%>"), false, null);
                Common.FinishExe($("#<%= txtPwd2.ClientID%>"), false, null);
            }
            return Common.mouseClick(obj)
        }
    </script>
</asp:Content>
