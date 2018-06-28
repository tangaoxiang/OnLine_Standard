<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlHead.ascx.cs" Inherits="DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlHead" %>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td width="21%" height="62" valign="top" background="../images/top_bg.jpg"><img src="../images/top_logo.jpg" width="354" height="60" /></td>
    <td width="79%" valign="top" background="../images/top_bg.jpg">
      <table width="100%" border="0" align="right" cellpadding="0" cellspacing="0">
        <tr>
          <td width="100%" height="35" align="right" valign="middle" style="padding-right:30px;">当前日期：<%=DateTime.Now.Year %>年<%=DateTime.Now.Month %>月<%=DateTime.Now.Day %>日&nbsp; &nbsp;<a href="/Right.aspx" target="I2">管理中心</a>&nbsp; <img src="../images/main_jg.jpg" width="1" height="16" align="absmiddle" /> &nbsp;<a href="/SystemManage/ChangePassword.aspx"" target="I2">修改密码</a>&nbsp; <img src="../images/main_jg.jpg" width="1" height="16" align="absmiddle" /> &nbsp; <a href="/UserLogin.aspx" target="_top">退出系统/重新登录</a></td>
        </tr>
        <tr>
          <td>
              &nbsp;</td>
        </tr>
      </table>
    </td>
  </tr>
</table>