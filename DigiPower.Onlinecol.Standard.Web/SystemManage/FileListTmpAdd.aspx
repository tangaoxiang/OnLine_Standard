<%@ Page Language="C#" MasterPageFile="~/SiteSon.Master" AutoEventWireup="true" CodeBehind="FileListTmpAdd.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.FileListTmpAdd" Title="归档目录管理" %>

<%@ Register Src="../CommonCtrl/ctrlDropDownFileListTmp.ascx" TagName="ctrlDropDownFileListTmp"
    TagPrefix="uc2" %>
<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc3" %>
<%@ Register Src="../CommonCtrl/ctrlArchiveFormType.ascx" TagName="ctrlArchiveFormType"
    TagPrefix="uc1" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownSystemInfo.ascx" TagName="ctrlDropDownSystemInfo" TagPrefix="uc4" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Head" runat="server">
    <style type="text/css">
        select {
            height: 27px;
            width: 283px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Main" runat="server">
    <table id="tbl" runat="server" class="xzll" cellpadding="0" border="0">
        <tr>
            <td colspan="2" style="height: 5px;"></td>
        </tr>
        <tr>
            <td class="mc">文件类别： 
            </td>
            <td class="sr">
                <uc1:ctrlArchiveFormType ID="archive_form_no" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="mc">上级分类： 
            </td>
            <td class="sr">
                <uc2:ctrlDropDownFileListTmp ID="PID" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="mc">文件编号： 
            </td>
            <td class="sr">
                <uc3:ctrlTextBoxEx ID="bh" labelTitle="文件编号" runat="server" canEmpty="false" CssClass="sour" MaxLength="20" />
            </td>
        </tr>
        <tr>
            <td class="mc">目录名称： 
            </td>
            <td class="sr">
                <uc3:ctrlTextBoxEx ID="title" labelTitle="目录名称" canEmpty="false" CssClass="sour" MaxLength="100"
                    runat="server" />
            </td>
        </tr>
        <tr>
            <td class="mc">顺序号： 
            </td>
            <td class="sr">
                <uc3:ctrlTextBoxEx ID="OrderIndex" labelTitle="顺序号" canEmpty="false" CssClass="sour" MaxLength="5" mode="Int"
                    runat="server" />
            </td>
        </tr>
        <tr>
            <td class="mc">是否目录：
            </td>
            <td class="sr dxan">
                <asp:CheckBox ID="IsFolder" runat="server" />
                (选中：表明该文件是目录节点，否则是实体文件)
            </td>
        </tr>
        <tr>
            <td class="mc">是否需要归档： </td>
            <td class="sr dxan">
                <asp:CheckBox ID="MustSubmitFlag" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="mc">归档目录类别：</td>
            <td class="sr">
                <uc4:ctrlDropDownSystemInfo ID="FileType" runat="server" CurrentType="FileListTmpType" />
            </td>
        </tr>
        <tr>
            <td class="mc">归档单位：
            </td>
            <td class="sr">
                <uc4:ctrlDropDownSystemInfo ID="DefaultCompanyType" runat="server" CurrentType="CompanyType" />
            </td>
        </tr>
        <tr>
            <td class="mc">文件来源：
            </td>
            <td class="sr">
                <uc4:ctrlDropDownSystemInfo ID="FileFrom" runat="server" CurrentType="FileFrom_CompanyType" />
            </td>
        </tr>
        <tr>
  <td colspan="2" class="ljzc" style="height:55px;">
                <asp:Button ID="btnSave" runat="server" Text="  保存  "
                    OnClientClick="return saveSubmit(this);" clickflag="ok" class="btn2" OnClick="btnSave_Click" />
                 <input type="button" id="btngoBack" value=" 返回 " onclick="Common.fnParentLayerClose()" />
            </td>
        </tr>
    </table>
    <script language="javascript" type="text/javascript">
        function saveSubmit(obj) {
            if (!Common.Validate('<%= bh.ClientID%>')) return false;
            if (!Common.Validate('<%= title.ClientID%>')) return false;
            if (!Common.Validate('<%= OrderIndex.ClientID%>')) return false;

            return Common.mouseClick(obj)
        }
    </script>

</asp:Content>
