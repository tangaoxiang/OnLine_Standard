<%@ Page Language="C#" MasterPageFile="~/SiteSon.Master" AutoEventWireup="true" CodeBehind="WorkFlowAdd.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.WorkFlowAdd" Title="���̹���" %>

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
            <td class="mc">������λ��
            </td>
            <td class="sr">
                <uc1:ctrlDropDownCompanyInfo ID="CompanyID" AutoPostBack="true" runat="server" Width="280" CssClass="sour" />
            </td>
        </tr>
        <tr>
            <td class="mc">�ϼ���
            </td>
            <td class="sr">
                <uc4:ctrlDropDownWorkFlow ID="PID" runat="server" Width="280" />
            </td>
        </tr>
        <tr>
            <td class="mc">�������ƣ�
            </td>
            <td class="sr">
                <uc2:ctrlTextBoxEx labelTitle="��������" ID="WorkFlowName" canEmpty="false" runat="server" MaxLength="20" CssClass="sour" />
            </td>
        </tr>
        <tr>
            <td class="mc">���̴��ţ�
            </td>
            <td class="sr">
                <uc2:ctrlTextBoxEx labelTitle="���̴���" ID="WorkFlowCode" canEmpty="false" runat="server" MaxLength="20" CssClass="sour" />
            </td>
        </tr>
        <tr>
            <td class="mc">����λ�ã�
            </td>
            <td class="sr">
                <uc2:ctrlTextBoxEx labelTitle="����λ��" ID="OrderIndex" canEmpty="false" runat="server" MaxLength="2" CssClass="sour" />
            </td>
        </tr>
        <tr>
            <td class="mc">���赥λ���ã�
            </td>
            <td class="sr dxan">
                <asp:CheckBox runat="server" ID="UseForCompany"></asp:CheckBox>
            </td>
        </tr>
        <tr>
            <td class="mc">���ҵ��λ˵����
            </td>
            <td class="sr">
                <uc2:ctrlTextBoxEx labelTitle="���̽ڵ�˵-���ҵ��λ" ID="DescriptionToCompany" width="380" height="50"
                    runat="server" MaxLength="150" CssClass="sour" TextMode="MultiLine" Rows="4" />
            </td>
        </tr>
        <tr>
            <td class="mc">��Ե�����˵����
            </td>
            <td class="sr">
                <uc2:ctrlTextBoxEx labelTitle="���̽ڵ�˵-��Ե�����" ID="DescriptionToArchive" width="380" height="50"
                    runat="server" MaxLength="150" CssClass="sour" TextMode="MultiLine" Rows="4" />
            </td>
        </tr>
        <tr>
            <td class="mc">Ȩ�ް�ť��
            </td>
            <td class="sr dxan">
                <uc3:ctrlCheckBoxList ID="chkMenuRight" runat="server" repeatColumns="4" width="465" />
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
            var Pid = Number(<%= ID%>);
            var NowPid = Number($('#ctl00_Main_PID_ddlWorkFlow').val());
            if (Pid == NowPid && Pid != 0) {
                Common.fnLayerAlert("������ѡ���ѵ��ϼ�!");
                return false;
            }
            if (!Common.Validate('<%= WorkFlowName.ClientID%>')) return false;
            if (!Common.Validate('<%= WorkFlowCode.ClientID%>')) return false;

            var WorkFlowCodeValue = $("#<%= WorkFlowCode.ClientID%>").val();
            if (WorkFlowAdd.ExistsWorkFlowCode('<%= Action%>', WorkFlowCodeValue, Number(<%= ID%>), Number($("#<%= CompanyID.ClientID%>_ddlArea").val())).value) {
                Common.FinishExe($("#<%= WorkFlowCode.ClientID%>"), true, "(" + WorkFlowCodeValue + ")�Ѵ���,������¼��!");
                return false;
            } else {
                Common.FinishExe($("#<%= WorkFlowCode.ClientID%>"), false, null);
            }
            return Common.mouseClick(obj)
        }
    </script>
</asp:Content>
