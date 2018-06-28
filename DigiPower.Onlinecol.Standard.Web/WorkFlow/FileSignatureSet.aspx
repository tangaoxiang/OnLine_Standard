<%@ Page Title="文件签章流程设置(是否需要签章,是否按签章流程签章)" Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true"
    CodeBehind="FileSignatureSet.aspx.cs" Inherits="DigiPower.Onlinecol.Standard.Web.WorkFlow.FileSignatureSet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <style type="text/css">
        .xzll input {
            width: 27px;
            height: 18px;
            border: 0px;
        }

        .ljzc input {
            height: 28px;
            width: 70px;
        }
    </style>
    <script language="javascript" type="text/javascript">
        function btnSave() {
            var parentOjb = parent.document.getElementById('bodyRepeater');
            $(parentOjb).find('input[type=\'checkbox\'][name=\'checkOne\']:checked').each(function () {
                var keyList = ($(this).val() + ',').split(',');
                if (keyList[1].toLocaleLowerCase() == 'false' || Number(keyList[1]) == 0) {
                    var iSignaturePdf = $("#ctl00_Main_chkiSignaturePdf").is(":checked") ? 1 : 0;
                    var iSignatureWorkFlow = $("#ctl00_Main_chkiSignatureWorkFlow").is(":checked") ? 1 : 0;
                    FileSignatureSet.SetFileListSignatureStatus(keyList[0], iSignaturePdf, iSignatureWorkFlow).value;
                    Common.fnParentLayerCloseAndRefresh();
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <fieldset style="width: 98%; padding: 2px; border: 1px solid #ddd;">
        <table id="tbl" class="xzll" cellpadding="0" border="0" style="width: 340px !important;">
            <tr>
                <td colspan="2" style="height: 15px;"></td>
            </tr>
            <tr>
                <td class="mc">是否需要签章： 
                </td>
                <td class="sr">
                    <asp:CheckBox runat="server" ID="chkiSignaturePdf" />
                </td>
            </tr>
            <tr>
                <td class="mc">是否按流程签章： 
                </td>
                <td class="sr">
                    <asp:CheckBox runat="server" ID="chkiSignatureWorkFlow" />
                </td>
            </tr>
            <tr>
                <td colspan="2" class="ljzc">
                    <input type="button" value="保存" onclick="btnSave()" />
                    <input type="button" id="btngoBack" value=" 返回 " onclick="Common.fnParentLayerClose()" />
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
