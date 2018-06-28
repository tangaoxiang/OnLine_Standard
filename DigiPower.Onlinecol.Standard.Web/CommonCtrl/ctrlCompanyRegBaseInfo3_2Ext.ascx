<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlCompanyRegBaseInfo3_2Ext.ascx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlCompanyRegBaseInfo3_2Ext" %>
<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc3" %>
<%@ Register Src="ctrlDropDownSystemInfo.ascx" TagName="ctrlDropDownSystemInfo" TagPrefix="uc3" %>

<style type="text/css">
    .ddd {
        width: 200px !important;
    }
</style>
<table id="tabledetail" runat="server" class="zpxxxj" border="0" cellspacing="0" cellpadding="0">
    <%--    <tr trtitle="road">
        <td colspan="4"><strong>道路</strong>
        </td>
    </tr>--%>
    <tr trtitle="road">
        <td class="ww">道路面积：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="jzmj" CssClass="ddd" labelTitle="道路面积" MaxLength="8"
                mode="Float" runat="server" />
            (㎡)
        </td>
        <td class="ww">道路等级：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="jb" CssClass="ddd" labelTitle="道路等级" MaxLength="20"
                runat="server" />
        </td>
    </tr>
    <tr trtitle="road">
        <td class="ww">道路总长度：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="chd" CssClass="ddd" labelTitle="道路总长度" MaxLength="8"
                mode="Float" runat="server" />
            (m)
        </td>
        <td class="ww">路宽：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="kd" CssClass="ddd" labelTitle="路宽" MaxLength="8"
                runat="server" />
            (m)
        </td>
    </tr>
    <tr trtitle="road">
        <td class="ww">路面种类：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="jglx" CssClass="ddd" labelTitle="路面种类" MaxLength="20"
                runat="server" />
        </td>
        <td class="ww">工程起点：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="kj" CssClass="ddd" mode="Float" labelTitle="工程起点" MaxLength="254"
                runat="server" />
        </td>
    </tr>
    <tr trtitle="road">
        <td class="ww">工程止点：
        </td>
        <td colspan="3">
            <uc3:ctrlTextBoxEx ID="jk" CssClass="ddd" mode="Float" labelTitle="工程止点" MaxLength="254"
                runat="server" />
        </td>
    </tr>
    <%--    <tr trtitle="bridge">
        <td colspan="4">
            <strong>桥梁</strong>
        </td>
    </tr>--%>
    <tr trtitle="bridge">
        <td class="ww">桥梁长度：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="qlcd" CssClass="ddd" labelTitle="桥梁长度" MaxLength="8"
                mode="Float" runat="server" />
            (m)
        </td>
        <td class="ww">桥梁宽度：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="qlkd" CssClass="ddd" labelTitle="桥梁宽度" MaxLength="8"
                mode="Float" runat="server" />
            (m)
        </td>
    </tr>
    <tr trtitle="bridge">
        <td class="ww">荷载标准：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="hzbz" CssClass="ddd" labelTitle="荷载标准" MaxLength="20"
                runat="server" />
        </td>
        <td class="ww">桥梁类别：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="qllb" CssClass="ddd" labelTitle="桥梁类别" MaxLength="20"
                runat="server" />
        </td>
    </tr>
    <tr trtitle="bridge">
        <td class="ww">主体结构：
        </td>
        <td>
            <%--     <uc3:ctrlTextBoxEx ID="ztjg" CssClass="ddd" labelTitle="主体结构" MaxLength="20"
                runat="server" />--%>

            <uc3:ctrlDropDownSystemInfo ID="ztjg" CurrentType="BRIDGE_STRUCTURE_TYPE_CODE" runat="server" Width="202" />
        </td>
        <td class="ww">桥梁跨度：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="qlkd2" CssClass="ddd" labelTitle="桥梁跨度" MaxLength="8"
                mode="Float" runat="server" />
            (m)
        </td>
    </tr>
    <tr trtitle="bridge">
        <td class="ww">抗震等级：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="kzdj" CssClass="ddd" labelTitle="抗震等级" MaxLength="20"
                runat="server" />
        </td>
        <td class="ww">桥梁级别：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="qljb" CssClass="ddd" labelTitle="桥梁级别" MaxLength="20"
                runat="server" />
        </td>
    </tr>
    <tr trtitle="bridge">
        <td class="ww">桥梁净空：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="qljk" CssClass="ddd" labelTitle="桥梁净空" MaxLength="20"
                runat="server" />
        </td>
        <td class="ww">桥梁载荷：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="qlzh" CssClass="ddd" labelTitle="桥梁载荷" MaxLength="20"
                runat="server" />
        </td>
    </tr>
    <tr style="display: none">
        <td colspan="4">
            <strong>照明</strong>
        </td>
    </tr>
    <tr style="display: none">
        <td class="ww">灯型：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="dx" CssClass="ddd" labelTitle="灯型" MaxLength="20"
                runat="server" />
        </td>
        <td class="ww">灯高：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="dg" CssClass="ddd" labelTitle="灯高" MaxLength="8"
                mode="Float" runat="server" />
        </td>
    </tr>
    <tr style="display: none">
        <td class="ww">盏数：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="zs" CssClass="ddd" labelTitle="盏数" MaxLength="4"
                mode="Int" runat="server" />
        </td>
        <td class="ww">间距：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="jj" CssClass="ddd" labelTitle="间距" MaxLength="8"
                mode="Float" runat="server" />
        </td>
    </tr>
    <tr style="display: none">
        <td class="ww">布置形式：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="bzxs" CssClass="ddd" labelTitle="布置形式" MaxLength="20"
                runat="server" />
        </td>
        <td class="ww">高度：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="gd" CssClass="ddd" labelTitle="长度" MaxLength="8"
                mode="Float" runat="server" />
        </td>
    </tr>
    <tr style="display: none">
        <td class="ww">电缆：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="dl" CssClass="ddd" labelTitle="电缆" MaxLength="20"
                runat="server" />
        </td>
        <td class="ww">负荷：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="fh" CssClass="ddd" labelTitle="负荷" MaxLength="20"
                runat="server" />
        </td>
    </tr>
    <tr style="display: none">
        <td class="ww">用电方式：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="ydfs" CssClass="ddd" labelTitle="桥梁净空" MaxLength="20"
                runat="server" />
        </td>
        <td class="ww">线径：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="xj" CssClass="ddd" labelTitle="线径" MaxLength="8"
                mode="Float" runat="server" />
            (mm)
        </td>
    </tr>
    <tr>
        <td class="ww">总预算：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="zys" CssClass="ddd" labelTitle="总预算" MaxLength="8"
                mode="Float" runat="server" />
            (万元)
        </td>
        <td class="ww">总决算：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="zjs" CssClass="ddd" labelTitle="总决算" MaxLength="8"
                mode="Float" runat="server" />
            (万元)
        </td>
    </tr>
    <tr>
        <td class="ww">总长度：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="zcd" CssClass="ddd" labelTitle="总长度" MaxLength="8"
                mode="Float" runat="server" />
            (m)
        </td>
        <td class="ww">获奖情况：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="hjqk" CssClass="ddd" labelTitle="获奖情况" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="ww">工程质量：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="gczl" CssClass="ddd" labelTitle="工程质量" MaxLength="20"
                runat="server" />
        </td>
        <td class="ww">其他：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="qt" CssClass="ddd" labelTitle="其他" runat="server" />
        </td>
    </tr>
</table>
