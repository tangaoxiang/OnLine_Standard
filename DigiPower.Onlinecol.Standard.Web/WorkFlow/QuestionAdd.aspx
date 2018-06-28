<%@ Page Title="" Language="C#" MasterPageFile="~/SiteSon.Master" AutoEventWireup="true" CodeBehind="QuestionAdd.aspx.cs" Inherits="DigiPower.Onlinecol.Standard.Web.WorkFlow.QuestionAdd" %>


<%@ Register Src="../CommonCtrl/ctrlDropDownSystemInfo.ascx" TagName="ctrlDropDownSystemInfo"
    TagPrefix="uc3" %>
<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link rel="stylesheet" href="../Javascript/Layer/layui/css/layui.css" media="all" />
    <style type="text/css">
        select {
            height: 27px;
        }

        .mc {
            width: 100px !important;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <table id="tbl" runat="server" class="xzll" cellpadding="0" border="0" style="font-size: 12px; width: 650px">
        <tr>
            <td colspan="2" style="height: 5px;"></td>
        </tr>
        <tr>
            <td class="mc">分类名称：
            </td>
            <td class="sr">
                <asp:DropDownList ID="ddlQuestionType" runat="server" Width="501"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="mc">问题主题：
            </td>
            <td class="sr">
                <uc1:ctrlTextBoxEx ID="txtTitle" canEmpty="false" labelTitle="问题主题" runat="server" MaxLength="50" width="500" />
            </td>
        </tr>
        <tr>
            <td class="mc">问题内容：
            </td>
            <td class="sr">
                <textarea id="Description" style="display: none;"></textarea>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="ljzc" style="height: 55px;">
                <asp:Button ID="btnSave" runat="server" Text="  保存  "
                    OnClientClick="return saveSubmit(this);" clickflag="ok" class="btn2" />
                <input type="button" id="btngoBack" value=" 返回 " onclick="Common.fnParentLayerClose()" />
            </td>
        </tr>
    </table>
    <input type="hidden" id="HidAction" value="<%= Action%>" />
    <input type="hidden" id="HidquestionID" value="<%= ID%>" />
    <script src="../Javascript/Layer/layui/layui.js" type="text/javascript" charset="utf-8"></script>
    <script language="javascript" type="text/javascript">
        var index, layedit, $;
        layui.use('layedit', function () {
            layedit = layui.layedit;
            $ = layui.jquery;
            index = layedit.build('Description', {
                tool: [
                         'strong' //加粗
                         , 'italic' //斜体
                         , 'underline' //下划线
                         , 'del' //删除线
                        // , '|' //分割线
                         , 'left' //左对齐
                         , 'center' //居中对齐
                         , 'right' //右对齐
                       //  , 'link' //超链接
                      //   , 'unlink' //清除链接
                      //   , 'face' //表情
                ],
                height: 280
            });
            $("#LAY_layedit_1").load(function () {
                var questionID = $("#HidquestionID").val();
                $.ajax({
                    type: 'get',
                    dataType: 'json',
                    url: '../RequestHandler.ashx',
                    data: { FileType: 'getQuestion', questionID: questionID, rd: Math.random() },
                    success: function (data) { 
                        if (typeof (data) != "undefined") { 
                            $("#<%= ddlQuestionType.ClientID%>").val(data[0].QuestionTypeCode);
                            $("#<%= txtTitle.ClientID%>").val(data[0].Title);
                            var body = $("#LAY_layedit_1")[0].contentWindow.document.body;
                            $(body).html(data[0].DescriptionHtml);
                        }
                    },
                    complete: function (text) {
                    }
                });
            });
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
            if ($(obj).attr("clickflag") == 'ok') {                 
                var action = $("#HidAction").val();
                var questionID = $("#HidquestionID").val();
                var questionType = $("#<%= ddlQuestionType.ClientID%>").val();
                var title = $("#<%= txtTitle.ClientID%>").val();
                var description = layedit.getText(index);
                var descriptionHtml = layedit.getContent(index);

                if (descriptionHtml.length > 4000) {
                    Common.fnLayerAlert("问题内容长度过长,只能4000个字符!");
                    return false;
                }

                $(obj).attr("clickflag", "no");
                var len = QuestionAdd.AddQuestion(action, questionID, questionType, title, description, descriptionHtml).value;
                if (len.indexOf(ResultState.Success) > -1) {
                    var fnIndex = parent.layer.getFrameIndex(window.name);
                    parent.document.getElementById('hidOpenFlag').value = '1';
                    parent.layer.close(fnIndex);
                } else {
                    Common.fnLayerAlert(len);
                    return false;
                }
            } else {
                Common.fnLayerAlert("程序正在处理中,请稍后.......");
                return false;
            }
        }
    </script>
</asp:Content>
