<%@ Page Language="C#" MasterPageFile="~/SiteSon.Master" AutoEventWireup="true" CodeBehind="FileInfoList.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.File.FileInfoList" %>

<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc3" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownSystemInfo.ascx" TagName="ctrlDropDownSystemInfo" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script language="javascript" type="text/javascript" src="../Javascript/Common/WebCalendar.js"></script>
    <style type="text/css">
        select {
            height: 26px;
            width: 210px;
            font-size: 13px !important;
            border: 1px solid #dddddd !important;
        }

        .cd {
            width: 610px !important;
        }

        .dd {
            width: 210px !important;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <table id="tbl" runat="server" class="zpxxxj" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td style="height: 5px !important;"></td>
        </tr>
        <tr>
            <td class="ww">文件编号:
            </td>
            <td>
                <uc3:ctrlTextBoxEx ID="bh" labelTitle="文件题名" MaxLength="30"
                    CssClass="dd" runat="server" readOnly="true" />
            </td>

            <td class="ww">责任者:
            </td>
            <td>
                <uc3:ctrlTextBoxEx ID="zrr" canEmpty="false" labelTitle="责任者" MaxLength="40"
                    CssClass="dd" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="ww">文件题名:
            </td>
            <td colspan="3">
                <uc3:ctrlTextBoxEx ID="title" canEmpty="false" labelTitle="文件题名" MaxLength="200"
                    CssClass="cd" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="ww">文(图)号:
            </td>
            <td class="left_title_2">
                <uc3:ctrlTextBoxEx ID="w_t_h" canEmpty="false" labelTitle="文(图)号" MaxLength="50"
                    CssClass="dd " runat="server" />
            </td>
            <td class="ww">实体页数:
            </td>
            <td class="left_title_2">
                <uc3:ctrlTextBoxEx ID="ManualCount" labelTitle="实体页数" runat="server" mode="Int" CssClass="dd " MaxLength="4" canEmpty="false" />
            </td>
        </tr>
        <tr>
            <td class="ww">载体类型:  
            </td>
            <td class="left_title_2">
                <div class="select-box ddlWidthExt">
                    <uc1:ctrlDropDownSystemInfo ID="ztlx" runat="server" CurrentType="08" />
                </div>
            </td>
            <td class="ww">规格:
            </td>
            <td class="left_title_2">
                <div class="select-box ddlWidthExt">
                    <uc1:ctrlDropDownSystemInfo ID="gg" runat="server" CurrentType="20" />
                </div>
            </td>
        </tr>
        <tr>
            <td class="ww">文字(页数):
            </td>
            <td class="left_title_2">
                <uc3:ctrlTextBoxEx ID="wzz" runat="server" mode="int" CssClass="dd " MaxLength="6" labelTitle="文字(页数)" />
            </td>
            <td class="ww">图纸(张数):
            </td>
            <td class="left_title_2">
                <uc3:ctrlTextBoxEx ID="tzz" runat="server" mode="int" CssClass="dd " MaxLength="6" labelTitle="图纸(张数)" />
            </td>
        </tr>
        <tr>
            <td class="ww">照片(张数):
            </td>
            <td class="left_title_2">
                <uc3:ctrlTextBoxEx ID="zpz" runat="server" mode="int" CssClass="dd " MaxLength="6" labelTitle="照片(张数)" />
            </td>
            <td class="ww">底片(张数):
            </td>
            <td class="left_title_2">
                <uc3:ctrlTextBoxEx ID="dpz" runat="server" mode="int" CssClass="dd " MaxLength="6" labelTitle="底片(张数)" />
            </td>
        </tr>
        <tr>
            <td class="ww">底图(张数):
            </td>
            <td class="left_title_2">
                <uc3:ctrlTextBoxEx ID="dtz" runat="server" mode="int" CssClass="dd " MaxLength="6" labelTitle="底图(张数)" />
            </td>
            <td class="ww">文本稿本代码:
            </td>
            <td class="left_title_2">
                <div class="select-box ddlWidthExt">
                    <uc1:ctrlDropDownSystemInfo ID="wjgbdm" runat="server" CurrentType="24" />
                </div>
            </td>
        </tr>
        <tr>
            <td class="ww">形成开始时间:
            </td>
            <td class="left_title_2">
                <uc3:ctrlTextBoxEx ID="StartTime" mode="Date" ShowLblDate="false" MaxLength="10" runat="server" CssClass="dd " labelTitle="形成开始时间" />
            </td>
            <td class="ww">形成结束时间:
            </td>
            <td class="left_title_2">
                <uc3:ctrlTextBoxEx ID="ENDTIME" mode="Date" ShowLblDate="false" MaxLength="10" runat="server" CssClass="dd " labelTitle="形成结束时间" />
            </td>
        </tr>
        <tr>
            <td class="ww">附注:
            </td>
            <td colspan="3">
                <uc3:ctrlTextBoxEx ID="bz" runat="server" labelTitle="附注" CssClass="cd" MaxLength="400" />
            </td>
        </tr>
        <tr>
            <td class="ww"><strong>电子文件信息</strong>
            </td>
        </tr>
        <tr>
            <td class="ww">文件类型代码:      
            </td>
            <td colspan="3">
                <div class="select-box ddlWidthExt">
                    <asp:DropDownList runat="server" ID="wjlxdm" CssClass="ddlWidthExt">
                        <asp:ListItem Value="wbwj" Text="文本文件(T)"></asp:ListItem>
                        <asp:ListItem Value="txwj" Text="图象文件(I)"></asp:ListItem>
                        <asp:ListItem Value="txinwj" Text="图形文件(G)"></asp:ListItem>
                        <asp:ListItem Value="yxwj" Text="影像文件(V)"></asp:ListItem>
                        <asp:ListItem Value="sywj" Text="声音文件(A)"></asp:ListItem>
                        <asp:ListItem Value="cxwj" Text="程序文件(P)"></asp:ListItem>
                        <asp:ListItem Value="sjwj" Text="数据文件(D)"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
        <tr>
            <td class="ww">文件格式:
            </td>
            <td class="left_title_2">
                <uc3:ctrlTextBoxEx ID="wjgs" labelTitle="文件格式" runat="server" CssClass="dd " MaxLength="20" />
            </td>
            <td class="ww">文件大小:
            </td>
            <td class="left_title_2">
                <uc3:ctrlTextBoxEx ID="wjdx" labelTitle="文件大小" runat="server" mode="int" CssClass="dd " MaxLength="8" />
            </td>
        </tr>
    </table>


    <table class="zpxxxj" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="lljzc">
                <asp:Button ID="btnUp" runat="server" Text="上一条" Visible="false" OnClick="btnUp_Click" />
                <asp:Button ID="btnSave" runat="server" Text="保存" Visible="false"
                    OnClientClick="return saveSubmit(this);" clickflag="ok" OnClick="btnSave_Click" />
                <asp:Button ID="btnDown" runat="server" Text="下一条" Visible="false" OnClick="btnDown_Click" />

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
