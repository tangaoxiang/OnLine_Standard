<%@ Page Language="C#" MasterPageFile="~/SiteSon.Master" AutoEventWireup="true" CodeBehind="WorkFlowAdd.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.WorkFlowAdd" Title="流程管理" %>

<%@ Register Src="../CommonCtrl/ctrlDropDownCompanyInfo.ascx" TagName="ctrlDropDownCompanyInfo"
    TagPrefix="uc1" %>
<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc2" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownWorkFlow.ascx" TagName="ctrlDropDownWorkFlow"
    TagPrefix="uc4" %>

<%@ Register Src="../CommonCtrl/ctrlCheckBoxList.ascx" TagName="ctrlCheckBoxList" TagPrefix="uc3" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Head" runat="server">
    <style type="text/css">
        select {
            height: 27px;
        }

        .dxan td {
            height: 24px;
            width: 500px !important;
        }
           
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Main" runat="server">
    <table id="tbl" runat="server" class="xzll" cellpadding="0" border="0" style="font-size: 12px; width: 610px">
        <tr>
            <td colspan="2" style="height: 5px;"></td>
        </tr>
        <tr>
            <td class="mc">所属单位：
            </td>
            <td class="sr">
                <uc1:ctrlDropDownCompanyInfo ID="CompanyID" AutoPostBack="true" runat="server" Width="280" CssClass="sour" />
            </td>
        </tr>
        <tr>
            <td class="mc">上级：
            </td>
            <td class="sr">
                <uc4:ctrlDropDownWorkFlow ID="PID" runat="server" Width="280" />
            </td>
        </tr>
        <tr>
            <td class="mc">流程名称：
            </td>
            <td class="sr">
                <uc2:ctrlTextBoxEx labelTitle="流程名称" ID="WorkFlowName" canEmpty="false" runat="server" MaxLength="20" CssClass="sour" />
            </td>
        </tr>
        <tr>
            <td class="mc">流程代号：
            </td>
            <td class="sr">
                <uc2:ctrlTextBoxEx labelTitle="流程代号" ID="WorkFlowCode" canEmpty="false" runat="server" MaxLength="20" CssClass="sour" />
            </td>
        </tr>
        <tr>
            <td class="mc">排序位置：
            </td>
            <td class="sr">
                <uc2:ctrlTextBoxEx labelTitle="排序位置" ID="OrderIndex" canEmpty="false" runat="server" MaxLength="2" CssClass="sour" />
            </td>
        </tr>
        <tr>
            <td class="mc">建设单位可用：
            </td>
            <td class="sr dxan">
                <asp:CheckBox runat="server" ID="UseForCompany"></asp:CheckBox>
            </td>
        </tr>
        <tr>
            <td class="mc">针对业务单位说明：
            </td>
            <td class="sr">
                <uc2:ctrlTextBoxEx labelTitle="流程节点说-针对业务单位" ID="DescriptionToCompany" width="380" height="50"
                    runat="server" MaxLength="150" CssClass="sour" TextMode="MultiLine" Rows="4" />
            </td>
        </tr>
        <tr>
            <td class="mc">针对档案馆说明：
            </td>
            <td class="sr">
                <uc2:ctrlTextBoxEx labelTitle="流程节点说-针对档案馆" ID="DescriptionToArchive" width="380" height="50"
                    runat="server" MaxLength="150" CssClass="sour" TextMode="MultiLine" Rows="4" />
            </td>
        </tr>
        <tr>
            <td class="mc">权限按钮：
            </td>
            <td class="sr dxan">
                <uc3:ctrlCheckBoxList ID="chkMenuRight" runat="server" repeatColumns="4" width="465" />
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
            var Pid = Number(<%= ID%>);
            var NowPid = Number($('#ctl00_Main_PID_ddlWorkFlow').val());
            if (Pid == NowPid && Pid != 0) {
                Common.fnLayerAlert("不可以选自已当上级!");
                return false;
            }
            if (!Common.Validate('<%= WorkFlowName.ClientID%>')) return false;
            if (!Common.Validate('<%= WorkFlowCode.ClientID%>')) return false;

            var WorkFlowCodeValue = $("#<%= WorkFlowCode.ClientID%>").val();
            if (WorkFlowAdd.ExistsWorkFlowCode('<%= Action%>', WorkFlowCodeValue, Number(<%= ID%>), Number($("#<%= CompanyID.ClientID%>_ddlArea").val())).value) {
                Common.FinishExe($("#<%= WorkFlowCode.ClientID%>"), true, "(" + WorkFlowCodeValue + ")已存在,请重新录入!");
                return false;
            } else {
                Common.FinishExe($("#<%= WorkFlowCode.ClientID%>"), false, null);
            }
            return Common.mouseClick(obj)
        }
    </script>
</asp:Content>
