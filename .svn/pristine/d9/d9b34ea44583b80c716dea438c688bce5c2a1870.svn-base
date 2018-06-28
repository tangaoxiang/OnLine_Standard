<%@ Page Title="" Language="C#" MasterPageFile="~/SiteSon.Master" AutoEventWireup="true"
    CodeBehind="ImageFileInfoList.aspx.cs" Inherits="DigiPower.Onlinecol.Standard.Web.File.ImageFileInfoList" %>

<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <style type="text/css">
        .ddlWidthExt {
            height: 21px;
            width: 210px;
        }

        .cd {
            width: 610px !important;
        }

        .dd {
            width: 210px !important;
        }

        .zpxxxj td {
            height: 32px !important;
        }
    </style>
    <script language="javascript" type="text/javascript" src="../Javascript/Common/WebCalendar.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">

    <table id="tbl" runat="server" class="zpxxxj" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td style="height: 15px !important;"></td>
        </tr>
        <tr>
            <td class="ww ">文件题名:
            </td>
            <td colspan="3">
                <uc3:ctrlTextBoxEx ID="title" canEmpty="false" labelTitle="文件题名" MaxLength="20"
                    CssClass="cd " runat="server" />
            </td>
        </tr>
        <tr>
            <td class="ww ">拍摄地点:
            </td>
            <td colspan="3" align="left">
                <uc3:ctrlTextBoxEx ID="psdd" canEmpty="false" labelTitle="拍摄地点" MaxLength="20" CssClass="cd"
                    runat="server" />
            </td>
        </tr>
        <tr>
            <td class="ww ">拍摄者:
            </td>
            <td colspan="3" align="left">
                <uc3:ctrlTextBoxEx ID="psz" runat="server" CssClass="cd" canEmpty="false" labelTitle="拍摄者" />
            </td>
        </tr>
        <tr>
            <td class="ww ">拍摄时间:
            </td>
            <td colspan="3" align="left">
                <uc3:ctrlTextBoxEx ID="pssj" runat="server" mode="Date" ShowLblDate="false" CssClass="dd " canEmpty="false" labelTitle="拍摄时间" />
            </td>
        </tr>
        <tr>
            <td class="ww ">色别:
            </td>
            <td>
                <asp:DropDownList runat="server" ID="sb" CssClass="ddlWidthExt">
                    <asp:ListItem Value="cs" Text="彩色"></asp:ListItem>
                    <asp:ListItem Value="hb" Text="黑白"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="ww ">分辨率:
            </td>
            <td>
                <uc3:ctrlTextBoxEx ID="fbl" runat="server" CssClass="dd " />
            </td>
        </tr>
        <tr>
            <td class="ww ">相机品牌:
            </td>
            <td>
                <uc3:ctrlTextBoxEx ID="xjpp" runat="server" CssClass="dd " />
            </td>
            <td class="ww ">相机型号:
            </td>
            <td>
                <uc3:ctrlTextBoxEx ID="xjxh" runat="server" CssClass="dd " />
            </td>
        </tr>
        <tr>
            <td class="ww ">X轴分辨率:
            </td>
            <td>
                <uc3:ctrlTextBoxEx ID="XAXIS_RESOLUTION" runat="server" CssClass="dd " />
            </td>
            <td class="ww ">Y轴分辨率:
            </td>
            <td>
                <uc3:ctrlTextBoxEx ID="YAXIS_RESOLUTION" runat="server" CssClass="dd " />
            </td>
        </tr>
        <tr>
            <td class="ww ">图像宽度:
            </td>
            <td>
                <uc3:ctrlTextBoxEx ID="IMAGE_WIDTH" runat="server" CssClass="dd " />
            </td>
            <td class="ww ">图像高度:
            </td>
            <td>
                <uc3:ctrlTextBoxEx ID="IMAGE_HEIGHT" runat="server" CssClass="dd " />
            </td>
        </tr>
        <tr>
            <td class="ww ">焦距:
            </td>
            <td>
                <uc3:ctrlTextBoxEx ID="DATA_FICAL_LENGTH" runat="server" CssClass="dd " />
            </td>
            <td class="ww ">光圈:
            </td>
            <td>
                <uc3:ctrlTextBoxEx ID="DATA_APERTURE" runat="server" CssClass="dd " />
            </td>
        </tr>
        <tr>
            <td class="ww ">光圈系数:
            </td>
            <td>
                <uc3:ctrlTextBoxEx ID="DATA_APERTURE_XS" runat="server" CssClass="dd " />
            </td>
            <td class="ww ">闪光:
            </td>
            <td>
                <uc3:ctrlTextBoxEx ID="FLASH" runat="server" CssClass="dd " />
            </td>
        </tr>
        <tr>
            <td class="ww ">白平衡:
            </td>
            <td>
                <uc3:ctrlTextBoxEx ID="WHITE_BALANCE" runat="server" CssClass="dd " />
            </td>
            <td class="ww ">感光度:
            </td>
            <td>
                <uc3:ctrlTextBoxEx ID="ISO_SPEED_RATINGS" runat="server" CssClass="dd " />
            </td>
        </tr>
        <tr>
            <td class="ww ">曝光程序:
            </td>
            <td>
                <uc3:ctrlTextBoxEx ID="EXPOSURE_PROGRAM" runat="server" CssClass="dd " />
            </td>
            <td class="ww ">曝光模式:
            </td>
            <td>
                <uc3:ctrlTextBoxEx ID="EXPOSURE_MODE" runat="server" CssClass="dd " />
            </td>
        </tr>
        <tr>
            <td class="ww ">曝光时间:
            </td>
            <td>
                <uc3:ctrlTextBoxEx ID="DATA_EXPOSURE_TIME" runat="server" CssClass="dd " />
            </td>
            <td class="ww ">清晰度:
            </td>
            <td>
                <uc3:ctrlTextBoxEx ID="QUALITY" runat="server" CssClass="dd " />
            </td>
        </tr>
        <tr>
            <td class="ww ">对比度:
            </td>
            <td>
                <uc3:ctrlTextBoxEx ID="CONTRAST" runat="server" CssClass="dd " />
            </td>
            <td class="ww ">饱和度:
            </td>
            <td>
                <uc3:ctrlTextBoxEx ID="SATURATION" runat="server" CssClass="dd " />
            </td>
        </tr>
        <tr>
            <td class="ww ">附注:
            </td>
            <td colspan="3">
                <uc3:ctrlTextBoxEx ID="bz" runat="server" CssClass="cd " />
            </td>
        </tr>
    </table>


    <table id="table1" runat="server" class="zpxxxj" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="lljzc">
                <asp:Button ID="btnSave" runat="server" Text="保存"
                    OnClientClick="return saveSubmit(this);" clickflag="ok" OnClick="btnSave_Click" />
                <input type="button" id="btngoBack" value=" 返回 " onclick="Common.fnParentLayerClose()" />
            </td>
        </tr>
    </table>
    <script src="../Javascript/Common/jquery.maskedinput.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        $(function () {
            $("input[type='text'][mode='Date']").mask("9999-99-99");
        });
        function saveSubmit(obj) {
            var flag = true;
            $("input[type='text']").each(function () {
                flag = Common.Validate($(this).attr("id"));
                if (!flag)
                    return false;
            });
            if (!flag) {
                return false;
            }
            return Common.mouseClick(obj)
        }
    </script>
</asp:Content>
