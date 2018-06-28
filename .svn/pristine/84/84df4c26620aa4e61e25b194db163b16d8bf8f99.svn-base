<%@ Page Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="UserArchiveAdd.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.WorkFlow.UserArchiveAdd" Title="新增归档目录" %>

<%@ Register Src="../CommonCtrl/ctrlDropDownFileList.ascx" TagName="ctrlDDLArchiveList"
    TagPrefix="uc2" %>
<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc3" %>
<%@ Register Src="../CommonCtrl/ctrlArchiveFormType.ascx" TagName="ctrlArchiveFormType"
    TagPrefix="uc1" %>
<%@ Register Src="../CommonCtrl/ctrlBtnBack.ascx" TagName="ctrlBtnBack" TagPrefix="uc4" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownFileListTmp.ascx" TagName="ctrlDropDownFileListTmp"
    TagPrefix="uc2" %>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .tdCSS
        {
            background-color: #FFFFFF;
            width: 30%;
        }
        .style1
        {
            text-align: left;
            width: 191px;
            background-color: #FFFFFF;
        }
    </style>

    <script language="javascript" type="text/javascript">
    function GetFileList(){
        var SingleProjectID=document.getElementById("ctl00_ContentPlaceHolder1_SingleProjectID").value;
        var txtTitle=document.getElementById("ctl00_ContentPlaceHolder1_txtTitle");
        var ddlDrop=document.getElementById("ctl00_ContentPlaceHolder1_tempPID_DropDownList1");
        if(txtTitle.value!=""){
            var table=UserArchiveAdd.GetFileListTable(txtTitle.value,SingleProjectID).value; 
            if(table!=null && typeof(table)=='object'){ 
                 ddlDrop.length=0;
                 if(table.Rows.length>0){ 
                     document.getElementById("ctl00_ContentPlaceHolder1_tempPID_Label1").innerText=table.Rows[0].BH;                 
                     for(var i=0;i<table.Rows.length;i++){
                       var text=table.Rows[i].Title;
                       var value=table.Rows[i].FileListID;
                       ddlDrop.options.add(new Option(text,value)); 
                    }
                 }                 
            }
        }
    }
    
    function OnchangeBH(){
        var FileListID=document.getElementById("ctl00_ContentPlaceHolder1_tempPID_DropDownList1").value;
        var len=UserArchiveAdd.GetFilelistBH(FileListID).value; 
        if(len!=""){
            document.getElementById("ctl00_ContentPlaceHolder1_tempPID_Label1").innerText=len;
        }
        else{
            document.getElementById("ctl00_ContentPlaceHolder1_tempPID_Label1").innerText="";
        }
    }
    </script>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="1" align="center" style="background-color: #8db2e3"
        runat="server" id="tbl">
        <tr>
            <td valign="top" style="background-color: White; height: 13px;" background="../images/blue_back3.gif">
            </td>
        </tr>
        <tr>
            <td style="background-color: White;">
                <table runat="server" width="99%" border="0" align="center" cellpadding="0" cellspacing="1"
                    style="margin-top: 4px; margin-bottom: 4px; background-color: #c1d4da;">
                    <tr>
                        <td class="style1" align="left">
                            <label>
                                上级分类：</label>
                        </td>
                        <td style="background-color: #FFFFFF" align="left">
                            <uc2:ctrlDDLArchiveList ID="tempPID" runat="server" Width="400" />
                            <%--<asp:TextBox ID="txtTitle" runat="server" CssClass="input" Width="120px"></asp:TextBox>
                            <input type="button" class="SelectButton" value=" 查询 " onclick="GetFileList()" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <label>
                                归档目录编号：</label>
                        </td>
                        <td style="background-color: #FFFFFF" align="left">
                            <uc3:ctrlTextBoxEx ID="bh" runat="server" canEmpty="false" CssClass="input" MaxLength="20" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <label>
                                目录名称：</label>
                        </td>
                        <td style="background-color: #FFFFFF" align="left">
                            <uc3:ctrlTextBoxEx ID="title" canEmpty="false" CssClass="input" MaxLength="200" width="400"
                                runat="server" />
                        </td>
                    </tr>
                    <%--<tr>
                        <td class="style1">
                            <label>
                                顺序号：</label>
                        </td>
                        <td style="background-color: #FFFFFF" align="left">
                            <uc3:ctrlTextBoxEx ID="OrderIndex" canEmpty="false" CssClass="input" MaxLength="30"
                                mode="Int" runat="server" />
                        </td>
                    </tr>--%>
                </table>
            </td>
        </tr>
        <tr>
            <td height="35" align="center" valign="middle" style="text-align: center; background-color: #FFFFFF;">
                <asp:Button ID="btnSave" runat="server" Text=" 保存 " class="SelectButton" OnClick="btnSave_Click"
                    Width="52px" />
                <uc4:ctrlBtnBack ID="ctrlBtnBack1" runat="server" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="SingleProjectID" runat="server" />
    <asp:HiddenField ID="WorkFlowID" runat="server" />
</asp:Content>
