﻿<%@ Page Language="C#" MasterPageFile="~/SiteSon.Master" AutoEventWireup="true" CodeBehind="ArchiveAdd.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.WorkFlow.ArchiveAdd" Title="案卷管理" %>

<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc1" %>

<%@ Register Src="../CommonCtrl/ctrlDropDownSystemInfo.ascx" TagName="ctrlDropDownSystemInfo"
    TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <style type="text/css">
        select {
            height: 27px;
        }
    </style>
    <script language="javascript" type="text/javascript" src="../Javascript/Common/WebCalendar.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <table id="tbl" runat="server" class="xzll" cellpadding="0" border="0">
        <tr>
            <td colspan="2" style="height: 5px;"></td>
        </tr>
        <tr>
            <td class="mc">案卷题名：
            </td>
            <td class="sr">
                <uc1:ctrlTextBoxEx ID="ajtm" labelTitle="案卷题名" canEmpty="false" MaxLength="100" CssClas="sour"
                    width="290" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="mc">编制单位： 
            </td>
            <td class="sr">
                <uc1:ctrlTextBoxEx ID="bzdw" labelTitle="编制单位" canEmpty="false" CssClas="sour"
                    MaxLength="40" width="290" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="mc">案卷厚度： 
            </td>
            <td class="sr">
                <uc3:ctrlDropDownSystemInfo ID="boxType" CurrentType="boxtype" runat="server" Width="130" />
            </td>
        </tr>
        <tr>
            <td class="mc">立卷人： 
            </td>
            <td class="sr">
                <uc1:ctrlTextBoxEx ID="lrr" runat="server" labelTitle="立卷人" canEmpty="false"
                    width="290" MaxLength="20" CssClas="sour" />
            </td>
        </tr>
        <tr>
            <td class="mc">编制日期： 
            </td>
            <td class="sr">
                <uc1:ctrlTextBoxEx ID="lrsj" mode="Date" ShowLblDate="false" labelTitle="编制日期"
                    runat="server" width="290" canEmpty="false" CssClas="sour" />
            </td>
        </tr>
        <tr>
            <td class="mc">案卷类型： 
            </td>
            <td class="sr">
                <uc3:ctrlDropDownSystemInfo ID="ajlx" runat="server" CurrentType="06" Width="130" />
            </td>
        </tr>
        <tr>
            <td class="mc">保管期限： 
            </td>
            <td class="sr">
                <uc3:ctrlDropDownSystemInfo ID="bgqx" runat="server" CurrentType="05" Width="130" />
            </td>
        </tr>
        <tr>
            <td class="mc">密级： 
            </td>
            <td class="sr">
                <uc3:ctrlDropDownSystemInfo ID="mj" runat="server" CurrentType="04" Width="130" />
            </td>
        </tr>
        <tr>
            <td class="mc">序号：
            </td>
            <td class="sr">
                <uc1:ctrlTextBoxEx ID="xh" labelTitle="序号" CssClas="sour"
                    MaxLength="4" mode="Int" canEmpty="false" runat="server" width="290" />
            </td>
        </tr>
        <tr>
            <td class="mc">卷内备考：
            </td>
            <td class="sr">
                <uc1:ctrlTextBoxEx labelTitle="卷内备考" ID="note" width="290" height="50"
                    runat="server" MaxLength="150" CssClass="sour txtMultiLine" TextMode="MultiLine" Rows="4" />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="ljzc" style="height: 45px;">
                <asp:Button ID="btnSave" runat="server" Text=" 保存 "
                    OnClientClick="return saveSubmit(this);" clickflag="ok" CssClass="btn2" OnClick="btnSave_Click" />
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
