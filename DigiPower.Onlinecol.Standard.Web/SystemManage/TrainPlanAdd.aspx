<%@ Page Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="TrainPlanAdd.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.TrainPlanAdd" Title="档案培训" %>

<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc3" %>
<%@ Register Src="../CommonCtrl/ctrlArchiveCheckBoxUserList.ascx" TagName="ctrlArchiveCheckBoxUserList"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script language="javascript" type="text/javascript" src="../JS/WebCalendar.js"></script>

    <style type="text/css">
        .tdCSS
        {
            background-color: #FFFFFF;
            width: 35%;
        }
    </style>

    <script language="javascript" type="text/javascript">
        function CheckData(){//检查是否选择了档案员
            var chkCount=0;
            var count=document.aspnetForm.elements.length;            
            for(var i=0;i<count;i++){
                var item=document.aspnetForm.elements[i];
                if(item.type=="checkbox" && item.checked){
                    chkCount+=1;
                }
            }
            
            if(chkCount==0){
                alert("至少要选择一个档案员！");
                return false;
            }
            return true;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="1" align="center" style="background-color: #8db2e3">
        <tr>
            <td valign="top" style="background-color: White; height: 13px;" background="../images/blue_back3.gif">
            </td>
        </tr>
        <tr>
            <td style="background-color: White;">
                <table id="tb_TranPlan" runat="server" width="99%" border="0" align="center" cellpadding="0"
                    cellspacing="1" style="margin-top: 4px; margin-bottom: 4px; background-color: #c1d4da;">
                    <tr>
                        <td class="tdCSS" align="left">
                            <label>
                                培训主题：</label>
                        </td>
                        <td style="background-color: #FFFFFF" align="left">
                            <uc3:ctrlTextBoxEx ID="Subject" canEmpty="false" CssClass="input" MaxLength="200"
                                width="450px" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdCSS" align="left">
                            <label>
                                培训老师：</label>
                        </td>
                        <td style="background-color: #FFFFFF" align="left">
                            <uc3:ctrlTextBoxEx ID="Teacher" canEmpty="false" CssClass="input" MaxLength="50"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdCSS" align="left">
                            <label>
                                档案员：</label>
                        </td>
                        <td style="background-color: #FFFFFF" align="left">
                            <uc1:ctrlArchiveCheckBoxUserList ID="ctrArchiveUserList" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdCSS" align="left">
                            <label>
                                培训计划时间：</label>
                        </td>
                        <td style="background-color: #FFFFFF" align="left">
                            <uc3:ctrlTextBoxEx ID="PlanDate" canEmpty="false" CssClass="input" MaxLength="30"
                                mode="Date" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdCSS" align="left">
                            <label>
                                培训完成时间：</label>
                        </td>
                        <td style="background-color: #FFFFFF" align="left">
                            <uc3:ctrlTextBoxEx ID="FinishDate" canEmpty="false" CssClass="input" MaxLength="30"
                                mode="Date" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdCSS" align="left">
                            <label>
                                培训计划人：</label>
                        </td>
                        <td style="background-color: #FFFFFF" align="left">
                            <uc3:ctrlTextBoxEx ID="PlanUserName" canEmpty="true" CssClass="input" MaxLength="50"
                                runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="35" align="center" valign="middle" style="background-color: White; text-align: center;">
                <asp:Button ID="btnSave000001" runat="server" Text=" 保存 " class="SelectButton" OnClick="btnSave_Click"
                    Width="52px" OnClientClick="return CheckData();" />
                     <asp:HiddenField runat="server" ID="hid_action" Value="" />
            </td>
        </tr>
    </table>
</asp:Content>
