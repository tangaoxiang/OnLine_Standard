<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlWorkFlowList.ascx.cs" Inherits="DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlWorkFlowList" %>
<script type="text/javascript">
    function Btn_Click(obj) {
        document.getElementById("<%=hdId.ClientID %>").value = obj.id;
        document.getElementById("<%=btn.ClientID %>").focus();
        document.getElementById("<%=btn.ClientID %>").click();
    }    
    //点击流程按钮改变其样式为选中
    window.onload = function ChangeBtnCss() {
        var WorkFlowID = document.getElementById("<%=hdId.ClientID %>").value;
        if (WorkFlowID != "" && WorkFlowID != null)
            document.getElementById(WorkFlowID).className = "lc_btn2";
    }
</script>
<table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="lc_bg">
  <tr>
    <td valign="top" style="padding:5px;">

         <table border="0" align="center" cellpadding="2" cellspacing="2" style="width:100%;">
              <tr>
                  <td align="center">
                    <asp:panel runat="server" id="tbl"></asp:panel>
                    <asp:HiddenField runat="server" ID="hdId" />

                        <asp:Button ID="btn" runat="server" onclick="btn_Click" Width="0" Height="0" />
                        
                  </td>
              </tr>
          </table>        
    </td>
  </tr>
</table>
