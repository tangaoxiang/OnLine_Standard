<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlCompanyBaseInfo.ascx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlCompanyBaseInfo" %>
<%@ Register Src="ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc2" %>
<%@ Register Src="ctrlDropDownArea.ascx" TagName="ctrlDropDownArea" TagPrefix="uc3" %>
<%@ Register Src="ctrlDropDownSystemInfo.ascx" TagName="ctrlDropDownSystemInfo" TagPrefix="uc4" %>


<table id="tbl_company" runat="server" class="zpxxxj" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td colspan="4"><strong>单位信息</strong>
        </td>
    </tr>
    <tr>
        <td class="ww">单位类型：
        </td>
        <td colspan="3">
            <uc4:ctrlDropDownSystemInfo ID="CompanyType" runat="server" CurrentType="CompanyType" Width="232px" />
        </td>
    </tr>
    <tr>
        <td class="ww">单位名称(中文)：
        </td>
        <td>
            <uc2:ctrlTextBoxEx ID="CompanyName" CssClass="dd" labelTitle="单位名称(中文)"
                runat="server" canEmpty="false" MaxLength="100" />
            <asp:HiddenField ID="companyid" runat="server" />
            <asp:HiddenField ID="constructionprojectid" runat="server" />
        </td>
        <td class="ww">统一社会信用代码：
        </td>
        <td>
            <uc2:ctrlTextBoxEx ID="CompanyCode" labelTitle="统一社会信用代码" CssClass="dd" runat="server" canEmpty="false" MaxLength="30" />
        </td>
    </tr>
    <tr>
        <td class="ww">单位名称(英文)：
        </td>
        <td colspan="3">
            <uc2:ctrlTextBoxEx ID="CompanyNameEn" CssClass="cd" runat="server" MaxLength="80" />
        </td>
    </tr>
    <tr>
        <td class="ww">所属机构：
        </td>
        <td>
            <uc3:ctrlDropDownArea ID="AREA_CODE" runat="server" Width="232px" />
        </td>
        <td class="ww">邮政编码：
        </td>
        <td>
            <uc2:ctrlTextBoxEx ID="Zipcode" CssClass="dd" runat="server" mode="PostCode" MaxLength="10" />
        </td>
    </tr>
    <tr>
        <td class="ww">单位地址：
        </td>
        <td colspan="3">
            <uc2:ctrlTextBoxEx ID="Addres" CssClass="cd" labelTitle="单位地址" runat="server" canEmpty="false" MaxLength="40" />
        </td>
    </tr>
    <tr>
        <td class="ww">法人姓名：
        </td>
        <td>
            <uc2:ctrlTextBoxEx ID="ChargeUserName" CssClass="dd" runat="server" MaxLength="25" />
        </td>
        <td class="ww">身份证ID：
        </td>
        <td>
            <uc2:ctrlTextBoxEx ID="CharegeID" CssClass="dd" runat="server" MaxLength="20" />
        </td>
    </tr>
    <tr>
        <td class="ww">单位联系人：
        </td>
        <td colspan="3">
            <uc2:ctrlTextBoxEx ID="ContactPerson" labelTitle="单位联系人" CssClass="cd" runat="server" canEmpty="false" MaxLength="10" />
        </td>
    </tr>
    <tr>
        <td class="ww">手机：
        </td>
        <td>
            <uc2:ctrlTextBoxEx ID="Mobile" labelTitle="手机" CssClass="dd" runat="server" canEmpty="false" MaxLength="11" mode="Int" />
        </td>
        <td class="ww">电话：
        </td>
        <td>
            <uc2:ctrlTextBoxEx ID="Tel" CssClass="dd" labelTitle="电话" runat="server" canEmpty="false" MaxLength="15" />
        </td>
    </tr>
    <tr>
        <td class="ww">EMail：
        </td>
        <td>
            <uc2:ctrlTextBoxEx ID="EMail" labelTitle="EMail" CssClass="dd" mode="Email" runat="server" MaxLength="30" />
        </td>
        <td class="ww">传真：
        </td>
        <td>
            <uc2:ctrlTextBoxEx ID="Fax" CssClass="dd" runat="server" MaxLength="15" />
        </td>
    </tr>
    <tr>
        <td class="ww">单位简介：
        </td>
        <td colspan="3">
            <uc2:ctrlTextBoxEx ID="Description" labelTitle="单位简介" MaxLength="100" CssClass="cd" runat="server" />
        </td>
    </tr>
</table>
