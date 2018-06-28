<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HookUpCompany.aspx.cs" Inherits="DigiPower.Onlinecol.Standard.Web.WorkFlow.HookUpCompany" %>

<%@ Register Src="../CommonCtrl/ctrlDropDownCompanyInfo.ascx" TagName="ctrlDropDownCompanyInfo" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>关联安监,质监,检测单位</title>
    <link href="/css/button.css" media="screen" rel="stylesheet" type="text/css" />

    <style type="text/css">
        html body {
            margin: 0px;
            padding: 0px;
            font-size: 12px;
        }
    </style>
    <script type="text/javascript" src="../JSNew/20140618/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" src="../JSNew/20140618/jquery.artDialog.source.js?skin=blue"></script>
    <script type="text/javascript" src="../JSNew/20140618/iframeTools.source.js"></script>

    <script type="text/javascript">
        function setRemark() {
            var singleProjectID = $('#HidSingleProjectID').val();
            if ($('#divAj').is(':visible')) {
                HookUpCompany.Execute(singleProjectID, $('#ctrlAjdw_ddlArea').val(), $('#ctrlZjdw_ddlArea').val(), true).value;
                alert('工程关联安监,质监单位成功!');
            } else {
                HookUpCompany.Execute(singleProjectID, $('#ctrlJcdw_ddlArea').val(), 0, false).value;
                alert('工程关联检测单位成功!');
            }
            art.dialog.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="HidSingleProjectID" />
        <fieldset>
            <legend>关联单位</legend>
            <div style="text-align: center; height: 35px;" id="divAj" runat="server" visible="false">
                安监地址:
            <uc1:ctrlDropDownCompanyInfo ID="ctrlAjdw" runat="server" Width="200" Visible="false" />
            </div>
            <div style="text-align: center; height: 35px" id="divZj" runat="server" visible="false">
                质监单位:
            <uc1:ctrlDropDownCompanyInfo ID="ctrlZjdw" runat="server" Width="200" Visible="false" />
            </div>
            <div style="text-align: center; height: 35px" id="divJc" runat="server" visible="false">
                检测单位:
            <uc1:ctrlDropDownCompanyInfo ID="ctrlJcdw" runat="server" Width="200" Visible="false" />
            </div>
            <div style="text-align: center; height: 35px">
                <input type="button" value=" 选择 " class="btn2" onclick="setRemark()" />
            </div>
        </fieldset>
    </form>
</body>
</html>
