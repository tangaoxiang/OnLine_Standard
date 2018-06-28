<%@ Page Title="" Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="QuickWjdj.aspx.cs" Inherits="DigiPower.Onlinecol.Standard.Web.WorkFlow.QuickWjdj" %>

<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <style type="text/css">
        .regedit_input {
            height: 21px;
            width: 250px;
        }

        select {
            height: 25px !important;
            line-height: 24px !important;
            width: 100px !important;
            font-size: 13px !important;
            border: 1px solid #dddddd !important;
        }

        .zpxxxj {
            width: 440px !important;
        }

        .dd {
            width: 180px !important;
        }

        .ww {
            width: 140px !important;
        }
    </style>
    <script src="../Javascript/Common/jquery.maskedinput.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        $(function () {
            $("#ctl00_Main_StartTime_TextBox1").mask("9999-99-99");
        });
        function btnInsert(obj) {
            var flag = true;
            $("input[type='text']").each(function () {
                flag = Common.Validate($(this).attr("id"));
                if (!flag)
                    return;
            });
            var parentOjb = parent.document.getElementById('bodyRepeater');
            $(parentOjb).find('input[type=\'checkbox\'][name=\'checkOne\']:checked').each(function () {
                var keyList = ($(this).val() + ',').split(',');
                if (keyList[1].toLocaleLowerCase() == 'false' || Number(keyList[1]) == 0) {
                    var tdAll = $(this).parent().nextAll();
                    replaceValue($(tdAll).eq(1).children().eq(0), $("#ctl00_Main_MyCode_TextBox1").val(), Number($('#sel_MyCode').val()));
                    replaceValue($(tdAll).eq(2).children().eq(0), $("#ctl00_Main_title_TextBox1").val(), Number($('#sel_Title').val()));
                    replaceValue($(tdAll).eq(3).children().eq(0), $("#ctl00_Main_zrr_TextBox1").val(), Number($('#sel_Zrr').val()));
                    replaceValue($(tdAll).eq(4).children().eq(0), $("#ctl00_Main_w_t_h_TextBox1").val(), Number($('#sel_w_t_h').val()));
                    replaceValue($(tdAll).eq(5).children().eq(0), $("#ctl00_Main_StartTime_TextBox1").val(), Number($('#sel_StartTime').val()));
                    replaceValue($(tdAll).eq(6).children().eq(0), $("#ctl00_Main_ManualCount_TextBox1").val(), Number($('#sel_ManualCount').val()));
                }
            });
        }
        function replaceValue(obj, value, sel) {
            if (sel == 1) {//原内容前
                $(obj).val(value + $(obj).val());
            } else if (sel == 2) {//原内容后
                $(obj).val($(obj).val() + value);
            } else if (sel == 3) {//覆盖原内容
                $(obj).val(value);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <fieldset style="width: 98%; padding: 2px; border: 1px solid #ddd;">
        <table class="zpxxxj" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td colspan="4" style="height: 16px;"></td>
            </tr>
            <tr>
                <td class="ww">内部编号:</td>
                <td>
                    <uc1:ctrlTextBoxEx ID="MyCode" CssClass="dd" runat="server" MaxLength="20" />
                </td>
                <td class="ww">插入位置:</td>
                <td>
                    <select id="sel_MyCode">
                        <option value="999">请选择</option>
                        <option value="1">原内容前</option>
                        <option value="2">原内容后</option>
                        <option value="3">覆盖原内容</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td class="ww">文件题名:</td>
                <td>
                    <uc1:ctrlTextBoxEx ID="title" CssClass="dd" runat="server" MaxLength="100" />
                </td>
                <td class="ww">插入位置:</td>
                <td>
                    <select id="sel_Title">
                        <option value="999">请选择</option>
                        <option value="1">原内容前</option>
                        <option value="2">原内容后</option>
                        <option value="3">覆盖原内容</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td class="ww">责任者:</td>
                <td>
                    <uc1:ctrlTextBoxEx ID="zrr" CssClass="dd" runat="server" MaxLength="40" />
                </td>
                <td class="ww">插入位置:</td>
                <td>
                    <select id="sel_Zrr">
                        <option value="999">请选择</option>
                        <option value="1">原内容前</option>
                        <option value="2">原内容后</option>
                        <option value="3">覆盖原内容</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td class="ww">文(图)号:</td>
                <td>
                    <uc1:ctrlTextBoxEx ID="w_t_h" CssClass="dd" runat="server" MaxLength="50" />
                </td>
                <td class="ww">插入位置:</td>
                <td>
                    <select id="sel_w_t_h">
                        <option value="999">请选择</option>
                        <option value="1">原内容前</option>
                        <option value="2">原内容后</option>
                        <option value="3">覆盖原内容</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td class="ww">形成日期:</td>
                <td>
                    <uc1:ctrlTextBoxEx ID="StartTime" mode="Date" ShowLblDate="false" CssClass="dd"
                        runat="server" MaxLength="10" labelTitle="编制日期" />
                </td>
                <td class="ww">插入位置:</td>
                <td>
                    <select id="sel_StartTime">
                        <option value="999">请选择</option>
                        <option value="3">覆盖原内容</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td class="ww">实体页数:</td>
                <td>
                    <uc1:ctrlTextBoxEx ID="ManualCount" CssClass="dd"
                        labelTitle="实体页数" runat="server" MaxLength="4" mode="Int" />
                </td>
                <td class="ww">插入位置:</td>
                <td>
                    <select id="sel_ManualCount">
                        <option value="999">请选择</option>
                        <option value="1">原内容前</option>
                        <option value="2">原内容后</option>
                        <option value="3">覆盖原内容</option>
                    </select>
                </td>
            </tr>
        </table>
        <table class="zpxxxj" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="lljzc">
                    <input type="button" value="保存" onclick="btnInsert(this)" />
                    <input type="button" id="btngoBack" value=" 返回 " onclick="Common.fnParentLayerClose()" />
                </td>
            </tr>
        </table>
    </fieldset>
    <span style="color: red">&nbsp;针对勾选的文件的文件题名,责任者,文图号,形成日期,实体页数进来快速著录</span>
</asp:Content>
