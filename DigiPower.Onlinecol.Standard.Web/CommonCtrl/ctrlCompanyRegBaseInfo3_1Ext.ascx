<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlCompanyRegBaseInfo3_1Ext.ascx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlCompanyRegBaseInfo3_1Ext" %>
<%@ Register Src="ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc3" %>
<%@ Register Src="ctrlDropDownSystemInfo.ascx" TagName="ctrlDropDownSystemInfo" TagPrefix="uc3" %>

<style type="text/css">
    .ddd {
        width: 200px !important;
    }
</style>
<table id="tabledetail" runat="server" class="zpxxxj" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td class="ww">建筑面积：</td>
        <td>
            <uc3:ctrlTextBoxEx ID="jzmj" CssClass="ddd" labelTitle="建筑面积" MaxLength="10"
                mode="Float" runat="server" />
            (m<sup>2</sup>)
        </td>
        <td class="ww">高度：</td>
        <td>
            <uc3:ctrlTextBoxEx ID="gd" CssClass="ddd" labelTitle="高度" MaxLength="8"
                mode="Float" runat="server" />
            (m)
        </td>
    </tr>
    <tr>
        <td class="ww">地上层数：</td>
        <td>
            <uc3:ctrlTextBoxEx ID="dxcs" CssClass="ddd" labelTitle="地上层数" MaxLength="4"
                mode="Int" runat="server" />
        </td>
        <td class="ww">地下层数：</td>
        <td>
            <uc3:ctrlTextBoxEx ID="dscs" CssClass="ddd" labelTitle="地下层数" MaxLength="4"
                mode="Int" runat="server" />
        </td>
    </tr>

    <tr>
        <td class="ww">结构类型：
        </td>
        <td>
            <uc3:ctrlDropDownSystemInfo ID="jglx" CurrentType="HOUSE_STRUCTURE_TYPE_CODE" runat="server" Width="202" />
            <%--      <uc3:ctrlTextBoxEx ID="jglx" labelTitle="结构类型" CssClass="ddd" MaxLength="20"
                runat="server" />--%>
        </td>
        <td class="ww">工程预算：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="gcys" CssClass="ddd" MaxLength="8" labelTitle="工程预算"
                mode="Float" runat="server" />
            (万元)
        </td>
    </tr>
    <tr>
        <td class="ww">工程决算：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="gcjs" CssClass="ddd" labelTitle="工程决算" MaxLength="8"
                mode="Float" runat="server" />
            (万元)
        </td>
        <td class="ww">抗震等级：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="kzdj" CssClass="ddd" labelTitle="抗震等级" MaxLength="20"
                runat="server" />
        </td>
    </tr>
    <tr style="display: none">
        <td class="ww">住宅面积：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="zzmj" CssClass="ddd" labelTitle="住宅面积" MaxLength="8"
                mode="Float" runat="server" />
            (m<sup>2</sup>)
        </td>
        <td class="ww">办公用房面积：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="bgyfmj" CssClass="ddd" labelTitle="办公用房面积" MaxLength="8"
                mode="Float" runat="server" />
            (m<sup>2</sup>)
        </td>
    </tr>
    <tr style="display: none">
        <td class="ww">商业用房面积：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="syyfmj" CssClass="ddd" labelTitle="商业用房面积" MaxLength="8"
                runat="server" mode="Float" />
            (m<sup>2</sup>)
        </td>
        <td class="ww">厂房面积：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="cfmj" CssClass="ddd" labelTitle="厂房面积" MaxLength="8"
                runat="server" mode="Float" />
            (m<sup>2</sup>)
        </td>
    </tr>
    <tr style="display: none">
        <td class="ww">地下室面积：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="dxsmj" CssClass="ddd" labelTitle="地下室面积" MaxLength="8"
                mode="Float" runat="server" />
            (m<sup>2</sup>)
        </td>
        <td class="ww">其他用房面积：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="qtyfmj" CssClass="ddd" labelTitle="其他用房面积" MaxLength="8"
                mode="Float" runat="server" />
            (m<sup>2</sup>)
        </td>
    </tr>
    <tr>
        <td class="ww">人防面积：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="rfmj" CssClass="ddd" labelTitle="人防面积" MaxLength="8"
                mode="Float" runat="server" />
            (m<sup>2</sup>)
        </td>
        <td class="ww">防火等级：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="fhdj" CssClass="ddd" labelTitle="防火等级" MaxLength="20"
                runat="server" />
        </td>
    </tr>
    <tr style="display: none">

        <td class="ww">单身公寓套数：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="dsgyts" CssClass="ddd" labelTitle="单身公寓套数" MaxLength="4"
                mode="Int" runat="server" />
        </td>
    </tr>
    <tr style="display: none">
        <td class="ww">复式套数：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="fsts" CssClass="ddd" labelTitle="复式套数" MaxLength="4"
                mode="Int" runat="server" />
        </td>
        <td class="ww">总套数：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="zts" CssClass="ddd" labelTitle="总套数" MaxLength="4"
                mode="Int" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="ww">车位数：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="cws" CssClass="ddd" labelTitle="车位数" MaxLength="4"
                mode="Int" runat="server" />
        </td>
        <td class="ww">工程质量：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="gczl" CssClass="ddd" labelTitle="工程质量" MaxLength="20"
                runat="server" />
        </td>
    </tr>
    <tr>
        <td class="ww">获奖情况：
        </td>
        <td colspan="3">
            <uc3:ctrlTextBoxEx ID="hjqk" CssClass="ddd" labelTitle="获奖情况" runat="server" MaxLength="30" />
        </td>
    </tr>
    <tr>
        <td class="ww">项目总监：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="xmzj" CssClass="ddd" labelTitle="项目总监" MaxLength="20"
                runat="server" />
        </td>
        <td class="ww">现场监理：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="xcjl" CssClass="ddd" labelTitle="现场监理" MaxLength="50"
                runat="server" />
        </td>
    </tr>
    <tr>
        <td class="ww">分包单位：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="fbdw" CssClass="ddd" labelTitle="分包单位" MaxLength="50"
                runat="server" />
        </td>
        <td class="ww">项目经理：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="xmjl" CssClass="ddd" labelTitle="项目经理" MaxLength="10"
                runat="server" />
        </td>
    </tr>
    <tr>
        <td class="ww">监理单位审核人：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="jldwshr" CssClass="ddd" labelTitle="监理单位审核人" MaxLength="20"
                runat="server" />
        </td>
        <td class="ww">建设单位审核人：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="jsdwshr" CssClass="ddd" labelTitle="建设单位审核人" MaxLength="20"
                runat="server" />
        </td>
    </tr>
    <%--<tr>
        <td class="ww">附注：
        </td>
        <td colspan="3">
            <uc3:ctrlTextBoxEx ID="fz" CssClass="ddd" labelTitle="附注" width="400px"
                runat="server" />
        </td>
    </tr>--%>
</table>
