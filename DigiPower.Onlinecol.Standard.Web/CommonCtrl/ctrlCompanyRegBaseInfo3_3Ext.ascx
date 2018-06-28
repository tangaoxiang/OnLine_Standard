<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlCompanyRegBaseInfo3_3Ext.ascx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlCompanyRegBaseInfo3_3Ext" %>
<%@ Register Src="ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc3" %>
<asp:HiddenField ID="HSingleProjectID" runat="server" />


<style type="text/css">
    .ddd {
        width: 200px !important;
    }
</style>

<table id="tabledetail" runat="server" class="zpxxxj" border="0" cellspacing="0" cellpadding="0" >
    <tr>
        <td class="ww">总长度：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="zcd" CssClass="ddd" labelTitle="总长度" MaxLength="8"
                mode="Float" runat="server" />
            (m)
        </td>
        <td class="ww">设计压力：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="sjyl" CssClass="ddd" labelTitle="设计压力" MaxLength="20"
                runat="server" />
        </td>
    </tr>
    <tr>
        <td class="ww">长度：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="cd" CssClass="ddd" labelTitle="长度" MaxLength="8"
                mode="Float" runat="server" />
            (m)
        </td>
        <td class="ww">规格：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="gg" CssClass="ddd" labelTitle="规格" MaxLength="20"
                runat="server" />
        </td>
    </tr>
    <tr>
        <td class="ww">材质：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="cz" CssClass="ddd" labelTitle="材质" MaxLength="20"
                runat="server" />
        </td>
        <td class="ww">荷载：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="hz" CssClass="ddd" labelTitle="荷载" MaxLength="20"
                runat="server" />
        </td>
    </tr>
    <tr>
        <td class="ww">起点：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="qd" CssClass="ddd" labelTitle="起点" MaxLength="20"
                runat="server" />
        </td>
        <td class="ww">止点：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="zd" CssClass="ddd" labelTitle="止点" MaxLength="20"
                runat="server" />
        </td>
    </tr>
    <tr>
        <td class="ww">工程质量：
        </td>
        <td colspan="3">
            <uc3:ctrlTextBoxEx ID="gczl" CssClass="ddd" labelTitle="桥梁长度" MaxLength="20"
                runat="server" />
        </td>
    </tr>
    <tr>
        <td class="ww">工程预算：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="gcys" CssClass="ddd" labelTitle="工程预算" MaxLength="8"
                mode="Float" runat="server" />
            (万元)
        </td>
        <td class="ww">工程决算：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="gcjs" CssClass="ddd" labelTitle="工程决算" MaxLength="8"
                mode="Float" runat="server" />
            (万元)
        </td>
    </tr>
    <tr>
        <td class="ww">起点坐标：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="qdzb" CssClass="ddd" mode="Float" labelTitle="起点坐标" MaxLength="20"
                runat="server" />
        </td>
        <td class="ww">止点坐标：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="zdzb" CssClass="ddd" mode="Float" labelTitle="止点坐标" MaxLength="20"
                runat="server" />
        </td>
    </tr>
    <tr>
        <td class="ww">获奖情况：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="hjqk" CssClass="ddd" labelTitle="获奖情况" runat="server"  MaxLength="30"/>
        </td>
        <td class="ww">其他：
        </td>
        <td>
            <uc3:ctrlTextBoxEx ID="qt" CssClass="ddd" labelTitle="其他" runat="server" MaxLength="100" />
        </td>
    </tr>
</table>
