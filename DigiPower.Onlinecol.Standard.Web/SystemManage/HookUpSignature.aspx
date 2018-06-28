<%@ Page Title="签章流程设置" Language="C#" MasterPageFile="~/SiteWjdj.Master" AutoEventWireup="true" CodeBehind="HookUpSignature.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.HookUpSignature" %>

<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="../Javascript/Common/jquery.maskedinput.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("input[type='text']").mask("99");
        });
    </script>
    <style type="text/css">
        .zpxxxj {
            width: 100% !important;
        }

        #tableList tr td {
            padding: 2px;
        }

        .regedit_input {
            width: 99% !important;
            padding: 0px !important;
            font-size: 13px !important;
            border: 1px solid #D5D5D5 !important;
            color: #333 !important;
            height: 24px !important;
            line-height: 24px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <input type="hidden" id="HidFileListID" value="<%= DigiPower.Onlinecol.Standard.Common.DNTRequest.GetQueryString("FileListID")%>" />
    <table class="zpxxxj" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="lljzc">
                <input type="button" id="btnSave" value=" 保存 " onclick="saveSubmit()" />
                <input type="button" id="btngoBack" value=" 返回 " onclick="Common.fnParentLayerClose()" />
            </td>
        </tr>
    </table>
    <div class="main-content">
        <div class="content-box-content">
            <div class="tab-content default-tab" id="tab1">
                <table id="tableList">
                    <thead>
                        <tr>
                            <th width="35px">序号</th>
                            <th width="230px">签章类型</th>
                            <th>签章顺序(<strong style="color: red;">必须是2位数字</strong>)</th>
                        </tr>
                    </thead>
                    <tbody class="tbody" id="bodyRepeater">
                        <asp:Repeater ID="gvSignature" runat="server" OnItemDataBound="repNewsList_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%# Container.ItemIndex+1%>
                                    </td>
                                    <td id="tdChk">
                                        <asp:CheckBox runat="server" ID="chkSystemInfoCode" /><%# Eval("SystemInfoName")%>
                                    </td>
                                    <td>
                                        <uc2:ctrlTextBoxEx ID="txtOrderIndex" runat="server" mode="Int"
                                            CssClass="regedit_input" MaxLength="2" Text="0" />
                                        <asp:HiddenField ID="txtHidSid" runat="server" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>


    <script language="javascript" type="text/javascript">
        $("#bodyRepeater").find("td[id='tdChk']").bind("click", function () {
            var td0 = $(this).children().eq(0);//点击 td 选中 单选或多选按钮
            if (td0.attr("type") == "checkbox") {
                td0.prop('checked', !td0.is(":checked"));
            }
        });
        function saveSubmit() {
            var fileListID = Number($('#HidFileListID').val());
            var objCheck = $("input[type='checkbox']:checked");
            if (objCheck.length > 0) {
                var arryOrderIndex = [];
                var i = 0;
                objCheck.each(function (index) {
                    var signatureOrderIndex = $(objCheck[index]).parent().next().children().eq(0).val();
                    if (signatureOrderIndex != "") {
                        arryOrderIndex[i] = signatureOrderIndex;
                        i += 1;
                    }
                });
                if (arryOrderIndex.length == objCheck.length) {
                    if (!isRepeat(arryOrderIndex)) {
                        HookUpSignature.Execute(fileListID, '', 0).value;
                        objCheck.each(function (index) {
                            HookUpSignature.Execute(fileListID, $(objCheck[index]).val(), Number($(objCheck[index]).parent().next().children().eq(0).val())).value;
                        });
                        Common.fnParentLayerCloseAndRefresh();
                    } else {
                        Common.fnLayerAlert("签章序号有重复!");
                    }
                } else {
                    Common.fnLayerAlert("请输入勾选<" + Common.getRedStrongString("签章类型") + ">对应的<" + Common.getRedStrongString("签章顺序") + ">");
                }
            } else {
                Common.fnLayerAlert("必须选择一项签章类型!");
            }
        }

        function isRepeat(arr) {
            var hash = {};
            for (var i in arr) {
                if (hash[arr[i]])
                    return true;
                hash[arr[i]] = true;
            }
            return false;
        }
    </script>
    <br />
</asp:Content>
