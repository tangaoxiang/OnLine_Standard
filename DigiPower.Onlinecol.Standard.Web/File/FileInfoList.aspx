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
            <td class="ww">�ļ����:
            </td>
            <td>
                <uc3:ctrlTextBoxEx ID="bh" labelTitle="�ļ�����" MaxLength="30"
                    CssClass="dd" runat="server" readOnly="true" />
            </td>

            <td class="ww">������:
            </td>
            <td>
                <uc3:ctrlTextBoxEx ID="zrr" canEmpty="false" labelTitle="������" MaxLength="40"
                    CssClass="dd" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="ww">�ļ�����:
            </td>
            <td colspan="3">
                <uc3:ctrlTextBoxEx ID="title" canEmpty="false" labelTitle="�ļ�����" MaxLength="200"
                    CssClass="cd" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="ww">��(ͼ)��:
            </td>
            <td class="left_title_2">
                <uc3:ctrlTextBoxEx ID="w_t_h" canEmpty="false" labelTitle="��(ͼ)��" MaxLength="50"
                    CssClass="dd " runat="server" />
            </td>
            <td class="ww">ʵ��ҳ��:
            </td>
            <td class="left_title_2">
                <uc3:ctrlTextBoxEx ID="ManualCount" labelTitle="ʵ��ҳ��" runat="server" mode="Int" CssClass="dd " MaxLength="4" canEmpty="false" />
            </td>
        </tr>
        <tr>
            <td class="ww">��������:  
            </td>
            <td class="left_title_2">
                <div class="select-box ddlWidthExt">
                    <uc1:ctrlDropDownSystemInfo ID="ztlx" runat="server" CurrentType="08" />
                </div>
            </td>
            <td class="ww">���:
            </td>
            <td class="left_title_2">
                <div class="select-box ddlWidthExt">
                    <uc1:ctrlDropDownSystemInfo ID="gg" runat="server" CurrentType="20" />
                </div>
            </td>
        </tr>
        <tr>
            <td class="ww">����(ҳ��):
            </td>
            <td class="left_title_2">
                <uc3:ctrlTextBoxEx ID="wzz" runat="server" mode="int" CssClass="dd " MaxLength="6" labelTitle="����(ҳ��)" />
            </td>
            <td class="ww">ͼֽ(����):
            </td>
            <td class="left_title_2">
                <uc3:ctrlTextBoxEx ID="tzz" runat="server" mode="int" CssClass="dd " MaxLength="6" labelTitle="ͼֽ(����)" />
            </td>
        </tr>
        <tr>
            <td class="ww">��Ƭ(����):
            </td>
            <td class="left_title_2">
                <uc3:ctrlTextBoxEx ID="zpz" runat="server" mode="int" CssClass="dd " MaxLength="6" labelTitle="��Ƭ(����)" />
            </td>
            <td class="ww">��Ƭ(����):
            </td>
            <td class="left_title_2">
                <uc3:ctrlTextBoxEx ID="dpz" runat="server" mode="int" CssClass="dd " MaxLength="6" labelTitle="��Ƭ(����)" />
            </td>
        </tr>
        <tr>
            <td class="ww">��ͼ(����):
            </td>
            <td class="left_title_2">
                <uc3:ctrlTextBoxEx ID="dtz" runat="server" mode="int" CssClass="dd " MaxLength="6" labelTitle="��ͼ(����)" />
            </td>
            <td class="ww">�ı��屾����:
            </td>
            <td class="left_title_2">
                <div class="select-box ddlWidthExt">
                    <uc1:ctrlDropDownSystemInfo ID="wjgbdm" runat="server" CurrentType="24" />
                </div>
            </td>
        </tr>
        <tr>
            <td class="ww">�γɿ�ʼʱ��:
            </td>
            <td class="left_title_2">
                <uc3:ctrlTextBoxEx ID="StartTime" mode="Date" ShowLblDate="false" MaxLength="10" runat="server" CssClass="dd " labelTitle="�γɿ�ʼʱ��" />
            </td>
            <td class="ww">�γɽ���ʱ��:
            </td>
            <td class="left_title_2">
                <uc3:ctrlTextBoxEx ID="ENDTIME" mode="Date" ShowLblDate="false" MaxLength="10" runat="server" CssClass="dd " labelTitle="�γɽ���ʱ��" />
            </td>
        </tr>
        <tr>
            <td class="ww">��ע:
            </td>
            <td colspan="3">
                <uc3:ctrlTextBoxEx ID="bz" runat="server" labelTitle="��ע" CssClass="cd" MaxLength="400" />
            </td>
        </tr>
        <tr>
            <td class="ww"><strong>�����ļ���Ϣ</strong>
            </td>
        </tr>
        <tr>
            <td class="ww">�ļ����ʹ���:      
            </td>
            <td colspan="3">
                <div class="select-box ddlWidthExt">
                    <asp:DropDownList runat="server" ID="wjlxdm" CssClass="ddlWidthExt">
                        <asp:ListItem Value="wbwj" Text="�ı��ļ�(T)"></asp:ListItem>
                        <asp:ListItem Value="txwj" Text="ͼ���ļ�(I)"></asp:ListItem>
                        <asp:ListItem Value="txinwj" Text="ͼ���ļ�(G)"></asp:ListItem>
                        <asp:ListItem Value="yxwj" Text="Ӱ���ļ�(V)"></asp:ListItem>
                        <asp:ListItem Value="sywj" Text="�����ļ�(A)"></asp:ListItem>
                        <asp:ListItem Value="cxwj" Text="�����ļ�(P)"></asp:ListItem>
                        <asp:ListItem Value="sjwj" Text="�����ļ�(D)"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
        <tr>
            <td class="ww">�ļ���ʽ:
            </td>
            <td class="left_title_2">
                <uc3:ctrlTextBoxEx ID="wjgs" labelTitle="�ļ���ʽ" runat="server" CssClass="dd " MaxLength="20" />
            </td>
            <td class="ww">�ļ���С:
            </td>
            <td class="left_title_2">
                <uc3:ctrlTextBoxEx ID="wjdx" labelTitle="�ļ���С" runat="server" mode="int" CssClass="dd " MaxLength="8" />
            </td>
        </tr>
    </table>


    <table class="zpxxxj" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="lljzc">
                <asp:Button ID="btnUp" runat="server" Text="��һ��" Visible="false" OnClick="btnUp_Click" />
                <asp:Button ID="btnSave" runat="server" Text="����" Visible="false"
                    OnClientClick="return saveSubmit(this);" clickflag="ok" OnClick="btnSave_Click" />
                <asp:Button ID="btnDown" runat="server" Text="��һ��" Visible="false" OnClick="btnDown_Click" />

                <input type="button" id="btngoBack" value=" ���� " onclick="Common.fnParentLayerClose()" />
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
