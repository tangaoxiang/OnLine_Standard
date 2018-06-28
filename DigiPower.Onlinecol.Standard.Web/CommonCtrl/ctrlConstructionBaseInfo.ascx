<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlConstructionBaseInfo.ascx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlConstructionBaseInfo" %>
<%@ Register Src="ctrlArchiveFormType.ascx" TagName="ctrlArchiveFormType"
    TagPrefix="uc2" %>
<%@ Register Src="ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc3" %>

<style>
    select {
        height: 27px;
    }
</style>
<table id="table1" runat="server" class="xzll" border="0" cellspacing="0" cellpadding="0">
    <%--    <tr>
        <td colspan="4"><strong>项目信息</strong>     
        </td>
    </tr>--%>
    <tr>
        <td class="mc">工程类别：</td>
        <td class="sr">
            <uc2:ctrlArchiveFormType ID="projecttype" runat="server" Width="150px" />
        </td>
    </tr>
    <tr>
        <td class="mc">项目号：</td>
        <td class="sr">
            <asp:TextBox ID="xmh" runat="server" ReadOnly="true">自动生成</asp:TextBox>
            <asp:HiddenField ID="constructionprojectid" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="mc">项目名称:
        </td>
        <td class="sr">
            <uc3:ctrlTextBoxEx ID="xmmc" canEmpty="false" labelTitle="项目名称" MaxLength="80"
                runat="server" />
        </td>
    </tr>
    <tr>
        <td class="mc">项目地点:
        </td>
        <td class="sr">
            <uc3:ctrlTextBoxEx ID="xmdd" canEmpty="false" labelTitle="项目地点"
                MaxLength="80" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="mc">建设单位：</td>
        <td class="sr">
            <uc3:ctrlTextBoxEx ID="jsdw" MaxLength="100" canEmpty="false"
                labelTitle="建设单位" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="mc">立项批准单位：</td>
        <td class="sr">
            <uc3:ctrlTextBoxEx ID="lxpzdw" labelTitle="立项指令单位"
                MaxLength="100" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="mc">土地使用证号：</td>
        <td class="sr">
            <uc3:ctrlTextBoxEx ID="tdsyzh" labelTitle="土地使用证号"
                MaxLength="80" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="mc">用地规划许可证号：</td>
        <td class="sr">
            <uc3:ctrlTextBoxEx ID="ydghxkzh" labelTitle="用地规划许可证号"
                MaxLength="80" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="mc">立项批准文号：</td>
        <td class="sr">
            <uc3:ctrlTextBoxEx ID="lxpzwh" labelTitle="立项批准文号"
                MaxLength="80" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="mc">土地出让年限：</td>
        <td class="sr">
            <uc3:ctrlTextBoxEx ID="tdcrnx" MaxLength="4" labelTitle="土地出让年限"
                mode="Int" runat="server" />
        </td>
    </tr>
</table>

