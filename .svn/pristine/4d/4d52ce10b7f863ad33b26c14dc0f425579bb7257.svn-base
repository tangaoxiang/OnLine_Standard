<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlWorkFlowList_HTML.ascx.cs" Inherits="DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlWorkFlowList_HTML" %>
<script type="text/javascript">
    function Btn_Click(workFlowName, workFlowID) {
        Navgate(workFlowName, workFlowID, '../MyTaskList.aspx?WorkFlowID=' + workFlowID);
    }
    //点击流程按钮改变其样式为选中  
    $(document).ready(function () {
        $("input[type='button'][name='button']").bind({
            mouseover: function () {
                $(this).attr('class', 'lc_btn2');
            },
            mouseout: function () {
                $(this).attr('class', 'lc_btn');
            }
        });  
        //window.setInterval(function () {
        //    window.location.href = window.location.href;
        //},80000);
    });
</script>
<table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="lc_bg">
    <tr>
        <td valign="top" style="padding: 5px;">
            <table border="0" align="center" cellpadding="2" cellspacing="2" style="width: 80%;">
                <tr>
                    <td align="center">
                        <asp:Panel runat="server" ID="tbl"></asp:Panel>
                </tr>
            </table>
        </td>
    </tr>
</table>
