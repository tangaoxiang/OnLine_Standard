<%@ Page Title="" Language="C#" MasterPageFile="~/SiteSon.Master" AutoEventWireup="true" CodeBehind="CompanyReg3_1Edit.aspx.cs" Inherits="DigiPower.Onlinecol.Standard.Web.CompanyManage.CompanyReg3_1Edit1" %>

<%@ Register Src="../CommonCtrl/ctrlDropDownConstructionProject.ascx" TagName="ctrlDropDownConstructionProject"
    TagPrefix="uc3" %>
<%@ Register Src="../CommonCtrl/ctrlArchiveFormType.ascx" TagName="ctrlArchiveFormType"
    TagPrefix="uc4" %>
<%@ Register Src="../CommonCtrl/ctrlCompanyRegBaseInfo3_1.ascx" TagName="ctrlCompanyRegBaseInfo3_1"
    TagPrefix="uc1" %>
<%@ Register Src="../CommonCtrl/ctrlCompanyRegBaseInfo3_1Ext.ascx" TagName="ctrlCompanyRegBaseInfo3_1Ext"
    TagPrefix="uc2" %>
<%@ Register Src="~/CommonCtrl/ctrlDropDownArea.ascx" TagName="ctrlDropDownArea"
    TagPrefix="uc6" %>
<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <style type="text/css">
        select {
            height: 27px;
            width: 243px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <table class="zpxxxj" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td colspan="4"><strong>工程所属项目</strong></td>
        </tr>
        <tr>
            <td class="ww">所属项目：</td>
            <td colspan="3">
                <uc3:ctrlDropDownConstructionProject width="640"
                    ID="ctrlDropDownConstructionProject1" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="ww">工程类别：</td>
            <td>
                <uc4:ctrlArchiveFormType ID="ctrlArchiveFormType1" runat="server" Width="150" />
            </td>
            <td class="ww">归档移交机构：</td>
            <td>
                <uc6:ctrlDropDownArea ID="AREA_CODE" runat="server" Width="200" />
            </td>
        </tr>
    </table>
    <uc1:ctrlCompanyRegBaseInfo3_1 ID="ctrlCompanyRegBaseInfo3_11" runat="server" />
    <table class="zpxxxj" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td colspan="4"><strong id="tbzyjz" style="cursor: pointer;" title="展开/关闭">房屋建筑专业记载 
                <%--<img src="../Javascript/Layer/image/t.png" id="tbzyjzimg" alt="" />--%>
            </strong></td>
        </tr>
    </table>
    <uc2:ctrlCompanyRegBaseInfo3_1Ext ID="ctrlCompanyRegBaseInfo3_1Ext1" runat="server" />
    <table class="zpxxxj" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td></td>
            <td class="lljzc" style="height: 30px;">
                <asp:Button ID="btnSave" runat="server" Text=" 保存 "
                    OnClientClick="return saveSubmit(this);" clickflag="ok" OnClick="btnSave_Click" />
                <input type="button" id="btngoBack" value=" 返回 " onclick="Common.fnParentLayerClose()" />
            </td>
        </tr>
    </table>
    <br />
    <script src="../Javascript/Common/jquery.maskedinput.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        $(function () {
            $("input[type='text'][mode='Date']").mask("9999-99-99");
        });

        $("#tbzyjz").click(function () {
            var obj = $("#ctl00_Main_ctrlCompanyRegBaseInfo3_1Ext1_tabledetail");
            //var img = $("#tbzyjzimg");
            if (obj.is(":hidden")) {
                //img.attr("src", "../Javascript/Layer/image/b.png");
                obj.show();
            } else {
                //img.attr("src", "../Javascript/Layer/image/t.png");
                obj.hide();
            }
        });

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

            var dt1 = $("#ctl00_Main_ctrlCompanyRegBaseInfo3_11_kgsj_TextBox1");
            var dt2 = $("#ctl00_Main_ctrlCompanyRegBaseInfo3_11_jgsj_TextBox1");
            if (Common.compareDate(dt1.val(), dt2.val()) == 1) {
                Common.FinishExe(dt1, true, "开工时间必须小于竣工时间!");
                return false;
            } else {
                Common.FinishExe(dt1, false, null);
            }

            return Common.mouseClick(obj)
        }
    </script>

</asp:Content>
