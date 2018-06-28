<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="RightManage.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.RightManage" Title="权限设定" %>

<%@ Register Src="../CommonCtrl/ctrlDropDownRole.ascx" TagName="ctrlDropDownRole"
    TagPrefix="uc1" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownCompanyInfo.ascx" TagName="ctrlDropDownCompanyInfo"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script language="javascript" type="text/javascript">
        function btnSave() {
            var lenMenu = $("input[type='checkbox'][allChk='1']:checked").length;
            var lenInsideMenu = $("input[type='checkbox'][allChk='3']:checked").length;
            var lenWorkFlow = $("input[type='checkbox'][allChk='2']:checked").length;

            if (lenMenu < 1) {
                Common.fnLayerAlert('请至少选中一个菜单权限按钮再进行操作!');
                return;
            }
            if (lenWorkFlow < 1) {
                Common.fnLayerAlert('请至少选中一个流程权限按钮再进行操作!');
                return;
            }
            var roleID = $("#ctl00_Main_ddlRole_ddlRole").val();

            var ModuleID = 0, WorkFlowID = 0, PModelID = 0;
            var MenuRightChar = "", WorkFlowRightChar = "", ModelBH = "";
            var index = 0;

            RightManage.DelRoleRight(roleID, "1").value;
            $("input[type='checkbox'][allChk='1']:checked").each(function () {
                index++;
                if (ModuleID != 0 && ModuleID != Number($(this).attr("sonMenu"))) {
                    RightManage.SaveRoleRight(MenuRightChar, roleID, ModuleID, 1, PModelID, '').value;
                    MenuRightChar = "";
                }
                MenuRightChar += $(this).val() + ",";
                ModuleID = Number($(this).attr("sonMenu"));
                PModelID = $(this).attr("parentMenu");

                if (index == lenMenu) {
                    RightManage.SaveRoleRight(MenuRightChar, roleID, ModuleID, 1, PModelID, '').value;
                }
            });
            index = 0;
            RightManage.DelRoleRight(roleID, "2").value;
            $("input[type='checkbox'][allChk='2']:checked").each(function () {
                index++;
                if (WorkFlowID != 0 && WorkFlowID != Number($(this).attr("parentWorkFlow"))) {
                    RightManage.SaveRoleRight(WorkFlowRightChar, roleID, WorkFlowID, 2, "", '').value;
                    WorkFlowRightChar = "";
                }
                WorkFlowRightChar += $(this).val() + ",";
                WorkFlowID = Number($(this).attr("parentWorkFlow"));

                if (index == lenWorkFlow) {
                    RightManage.SaveRoleRight(WorkFlowRightChar, roleID, WorkFlowID, 2, "", '').value
                }
            });
            index = 0;
            MenuRightChar = ""
            RightManage.DelRoleRight(roleID, "3").value;
            $("input[type='checkbox'][allChk='3']:checked").each(function () {
                index++;
                if (ModelBH != "" && ModelBH != $(this).attr("ModelBH")) {
                    RightManage.SaveRoleRight(MenuRightChar, roleID, 0, 3, "", ModelBH).value;
                    MenuRightChar = "";
                }
                MenuRightChar += $(this).val() + ",";
                ModelBH = $(this).attr("ModelBH");

                if (index == lenInsideMenu) {
                    RightManage.SaveRoleRight(MenuRightChar, roleID, 0, 3, "", ModelBH).value
                }
            });
            Common.fnLayerAlert('操作完成,重新登录系统权限才会生效!');
        }
        function selAll(allType, id, obj) {
            var selFlag = false;
            if ($(obj).is(":checked")) selFlag = true;
            if (allType == 0) {
                $("input[type='checkbox'][allChk='1']").each(function () {
                    $(this).prop('checked', selFlag);
                });
            } else if (allType == 1) {
                $("input[type='checkbox'][parentMenu='" + id + "']").each(function () {
                    $(this).prop('checked', selFlag);
                });
            } else if (allType == 2) {
                $("input[type='checkbox'][sonMenu='" + id + "']").each(function () {
                    $(this).prop('checked', selFlag);
                });
            } else if (allType == 3) {
                $("input[type='checkbox'][allChk='2']").each(function () {
                    $(this).prop('checked', selFlag);
                });
            } else if (allType == 4) {
                $("input[type='checkbox'][parentWorkFlow='" + id + "']").each(function () {
                    $(this).prop('checked', selFlag);
                });
            } else if (allType == 5) {
                $("input[type='checkbox'][allChk='3']").each(function () {
                    $(this).prop('checked', selFlag);
                });
            } else if (allType == 6) {
                $("input[type='checkbox'][ModelBH=" + id + "]").each(function () {
                    $(this).prop('checked', selFlag);
                });
            }
        }
    </script>
    <style type="text/css">
        select {
            height: 21px;
            width: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">
    <input type="hidden" id="hidOpenFlag" />
    <div class="main-content">
        <div class="content-box-search">
            <table id="c1">
                <tr>
                    <td class="condition">单位：</td>
                    <td class="c2">
                        <uc2:ctrlDropDownCompanyInfo ID="ddlCompany" runat="server" AutoPostBack="true" />
                    </td>
                    <td class="condition">角色名：</td>
                    <td class="c2">
                        <uc1:ctrlDropDownRole ID="ddlRole" AutoPostBack="true" runat="server" />
                    </td>
                    <td class="condition"></td>
                    <td class="c2"></td>
                    <td class="ss"></td>
                </tr>
            </table>
        </div>
        <div class="ss"></div>
        <div class="content-box-content">
            <div class="tab-content default-tab" id="tab1">
                <div class="anl" id="anlButtonList">
                    <input type="button" id="MrcBtnSave" title="保存" onclick="btnSave()" value="保存" />
                </div>
                <asp:Literal runat="server" ID="ltMenuHtml"></asp:Literal>
                <div class="pagination" style="height: 5px; border: 0px;">
                </div>

                <asp:Literal runat="server" ID="ltInsidePageHtml"></asp:Literal>
                <div class="pagination" style="height: 5px; border: 0px;">
                </div>

                <asp:Literal runat="server" ID="ltWorkFlowHtml"></asp:Literal>
                <div class="pagination" style="height: 10px; border: 0px;">
                </div>
            </div>
        </div>
    </div>
</asp:Content>

