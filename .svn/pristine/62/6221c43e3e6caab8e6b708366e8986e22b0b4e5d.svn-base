<%@ Page Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="TrainRecAdd.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.TrainRecAdd" Title="无标题页" %>

<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc1" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownUser.ascx" TagName="ctrlDropDownUser"
    TagPrefix="uc2" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownTrainPlan.ascx" TagName="ctrlDropDownTrainPlan"
    TagPrefix="uc3" %>
<%@ Register src="../CommonCtrl/ctrlCheckBoxUserList.ascx" tagname="ctrlCheckBoxUserList" tagprefix="uc4" %>
<%@ Register src="../CommonCtrl/ctrlArchiveCheckBoxUserList.ascx" tagname="ctrlArchiveCheckBoxUserList" tagprefix="uc5" %>
<%@ Register src="../CommonCtrl/ctrlBtnBack.ascx" tagname="ctrlBtnBack" tagprefix="uc6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .tdCSS
        {
            background-color: #FFFFFF;
            width: 30%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="1" align="center" style="background-color: #8db2e3">
        <tr>
            <td valign="top" style="background-color: White; height: 13px;" background="../images/blue_back3.gif">
            </td>
        </tr>
        <tr>
            <td style="background-color: White;">
                <table id="tb_TranRec" runat="server" width="99%" border="0" align="center" cellpadding="0"
                    cellspacing="1" style="margin-top: 4px; margin-bottom: 4px; background-color: #c1d4da;">
                    <tr>
                        <td class="tdCSS" align="left">
                            <label>
                                培训主题：</label>
                        </td>
                        <td style="background-color: #FFFFFF" align="left">
                            <uc3:ctrlDropDownTrainPlan ID="ddlTrainPlanID" runat="server" Width="300" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdCSS" align="left">
                            <label>
                                档案员：</label>
                        </td>
                        <td style="background-color: #FFFFFF" align="left">
                         
                        
                            <uc5:ctrlArchiveCheckBoxUserList ID="chkArchiveUerList" 
                                runat="server" />
                         
                        
                        </td>
                    </tr>
                    <tr>
                        <td class="tdCSS" align="left">
                            <label>
                                培训备注：</label>
                        </td>
                        <td style="background-color: #FFFFFF" align="left">
                            <uc1:ctrlTextBoxEx ID="txtTrainDesc" runat="server" TextMode="MultiLine" CssClass=""
                                height="77" Rows="4" width="450" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdCSS" align="left">
                            <label>
                                培训结果：</label>
                        </td>
                        <td style="background-color: #FFFFFF" align="left">
                            <uc1:ctrlTextBoxEx ID="txtTrainResult" runat="server" TextMode="SingleLine" CssClass="input"
                                width="450" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="35" align="center" valign="middle" style="background-color: White; text-align: center;">
                <asp:Button ID="btnSave" runat="server" Text=" 保存 " class="SelectButton" OnClick="btnSave_Click"
                    Width="52px"   />
            &nbsp;<uc6:ctrlBtnBack ID="ctrlBtnBack1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
