<%@ Page Title="密码找回" Language="C#" MasterPageFile="~/SiteSon.Master" AutoEventWireup="true"
    CodeBehind="FindPassword.aspx.cs" Inherits="DigiPower.Onlinecol.Standard.Web.FindPassword" %>

<%@ Register Src="~/CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <style type="text/css">
        .sour {
            width: 240px !important;
        }

        .sour2 {
            width: 82px !important;
        }

        td {
            height: 33px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <table id="tbl" runat="server" class="xzll" cellpadding="0" border="0" style="margin-top: 20px;">
        <tr>
            <td class="mc">登录账号： 
            </td>
            <td class="sr">
                <uc3:ctrlTextBoxEx ID="txtUserName" runat="server" canEmpty="false" CssClass="sour"
                    MaxLength="12" labelTitle="登录账号" />
            </td>
        </tr>
        <tr>
            <td class="mc">注册邮箱： 
            </td>
            <td class="sr">
                <uc3:ctrlTextBoxEx ID="txtEmail" canEmpty="false" CssClass="sour" MaxLength="50"
                    mode="Email" runat="server" labelTitle="注册邮箱" />
            </td>
        </tr>
        <tr>
            <td class="mc">验证码： 
            </td>
            <td class="sr">
                <img src="ValidateCode.aspx" alt="看不清,点击更换" onclick=" this.src = this.src + '?'; " />
                <uc3:ctrlTextBoxEx ID="txtValidateCode" canEmpty="false" CssClass="sour2" MaxLength="5"
                    runat="server" labelTitle="验证码" />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="ljzc" style="height: 55px;">
                <asp:Button ID="btnSave" runat="server" Text="  保存  "
                    OnClientClick="return saveSubmit(this);" clickflag="ok" class="btn2" OnClick="btnSave_Click" />
                <input type="button" id="btngoBack" value=" 返回 " onclick="Common.fnParentLayerClose()" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 30px; color: red; text-align: center; line-height: 30px;">
                <strong>输入正确的用户名和匹配的邮箱后,登录密码会自动发送到您的邮箱</strong>
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
            var $userName = $("#ctl00_Main_txtUserName_TextBox1");
            var $email = $("#ctl00_Main_txtEmail_TextBox1");
            var $validateCode = $("#ctl00_Main_txtValidateCode_TextBox1");

            if (!FindPassword.ExistsUserDate($userName.val(), "").value) {
                Common.FinishExe($userName, true, "不存在!");
                return false;
            } else {
                Common.FinishExe($userName, false, null);
            }
            if (!FindPassword.ExistsUserDate($userName.val(), $email.val()).value) {
                Common.FinishExe($email, true, "和登录账号不匹配!");
                return false;
            } else {
                Common.FinishExe($email, false, null);
            }
            if (!FindPassword.CheckFindValidateCode($validateCode.val()).value) {
                Common.FinishExe($validateCode, true, "验证码输入错误!");
                return false;
            } else {
                Common.FinishExe($validateCode, false, null);
            }
            return Common.mouseClick(obj)
        }
    </script>
</asp:Content>
