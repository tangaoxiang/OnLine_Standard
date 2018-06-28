<%@ Page Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true"
    CodeBehind="MyProjectList.aspx.cs" Inherits="DigiPower.Onlinecol.Standard.Web.MyProjectList" Title="我的任务" %>

<%@ Register Src="../CommonCtrl/ctrlWorkFlowList.ascx" TagName="ctrlWorkFlowList" TagPrefix="uc2" %>
<%@ Register Src="../CommonCtrl/ctrlGridEx.ascx" TagName="ctrlGridEx" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin: 0px 0px 0px 0px; border: solid 0px;" align="center">
        <table width="99%" border="0" cellpadding="0" cellspacing="0" style="margin: 4px 4px;
            border: solid 1px #8db2e3;" id="tablebtn" runat="server" visible="false">
            <tr>
                <td height="25" class="button_area" style="border: 0px; border-bottom: 1px;">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="margin-top: 2px;">
                        <tr>
                            <td width="10px">
                                &nbsp;&nbsp;&nbsp;
                            </td>
                            <td>
                                <div align="left">
                                    <asp:Button ID="btnSingleProjectInfo" runat="server" OnClick="btnSingleProjectInfo_Click"
                                        CssClass="button" Text="工程信息" />
                                </div>
                            </td>
                            <td>
                                <table width="100%" border="0" cellpadding="0" cellspacing="0" id="btnList" runat="server">
                                    <tr>
                                        <td align="right" style="text-align:right">
                                            <asp:Button ID="btnView001" runat="server" OnClick="btnDHZJ_Click" CssClass="button" Text="整理" />
                                            <asp:Button ID="btnView002" runat="server" OnClick="btnCkys_Click" CssClass="button" Text="案卷情况" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="30" align="right">
                                <img src="../Images/01.png" border="0" style="margin-right: 4px;" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            
        <tr>
            <td bgcolor="#cbdcec">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="100%" class="STYLE1">
                            <asp:Panel runat="server" ID="tblSearch" Width="100%" border="0" cellspacing="0"
                                cellpadding="0">
                                <table style="text-align: left; width: 100%">
                                    <tr>
                                        <td>
                                            <label>
                                                工程名称：</label><asp:TextBox ID="gcmc" runat="server" CssClass="SelectText"></asp:TextBox>
                                            <label>                                                
                                                &nbsp;工程编号：</label><asp:TextBox ID="gcbm" runat="server" CssClass="SelectText"></asp:TextBox>
                                            &nbsp;<asp:Button ID="btnSearch" runat="server" class="SelectButton" OnClick="btnSearch_Click" Text=" 查询 " />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
        
            <tr>
                <td align="center">
                    <div style="text-align:center;margin-top: 4px; margin-bottom: 4px; border: 0; width: 100%;">
                        <uc3:ctrlGridEx ID="ctrlGridEx1" runat="server" />
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>