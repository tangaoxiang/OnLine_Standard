<%@ Page Title="" Language="C#" MasterPageFile="~/SiteSon.Master" AutoEventWireup="true" CodeBehind="QuickReg.aspx.cs" Inherits="DigiPower.Onlinecol.Standard.Web.QuickReg" %>

<%@ Register Src="CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc2" %>
<%@ Register Src="CommonCtrl/ctrlDropDownArea.ascx" TagName="ctrlDropDownArea" TagPrefix="uc3" %>
<%@ Register Src="CommonCtrl/ctrlArchiveFormType.ascx" TagName="ctrlArchiveFormType"
    TagPrefix="uc4" %>
<%@ Register Src="CommonCtrl/ctrlDropDownSystemInfo.ascx" TagName="ctrlDropDownSystemInfo" TagPrefix="uc3" %>
<%@ Register Src="CommonCtrl/ctrlArchiveTypeDetail.ascx" TagName="ctrlArchiveTypeDetail"
    TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <%--<script type="text/javascript" src="/Javascript/Common/WebCalendar.js"></script>--%>
    <link rel="stylesheet" href="/Javascript/Layer/skin/qingxin/skin.css" id="layout-skin" type="text/css" />
    <script type="text/javascript" src="/Javascript/Layer/layer/layer.js"></script>
    <script type="text/javascript">
        var index = 0;
        var strIndex = ',0';
        function AddFile() {
            if (index < 2) {
                index++;
                strIndex += ',' + index;
                var tr = document.getElementById('tbFile').insertRow(); //创建行对象
                tr.id = 'tr' + index;
                tr.insertCell().innerHTML = '<input type="file" name="file" id="file' + index + '" class="trFile" onchange="CheckFile(this,\'<%=Hid_other.ClientID%>\')"/>';
                tr.insertCell().innerHTML = '<img src="Javascript/Layer/image/cross.png" onclick="DelFile(this,' + index + ')" alt="附件删除" />';
            } else {
                Common.fnLayerAlert('其它证件附件最多只能上传' + Common.getRedStrongString("3") + '个！');
            }
        }

        function ClearFile(index) {
            obj = document.getElementById("file" + index);
            if (!window.addEventListener) {
                obj.outerHTML += '';
            }
            else {
                obj.value = '';
            }
            $("#span" + index).text("");
            $("#img" + index).hide();
        }

        function CheckFile(obj, hidden, objMsg, objImg, whType) {//检测文件是否合法
            if (whType == "ghxkzh" && $("#ctl00_Main_ghxkzh_TextBox1").val() == "") {
                Common.fnLayerAlert('规划许可证号不能为空才能上传扫描件！');
                return;
            }
            if (whType == "sgxkzh" && $("#ctl00_Main_sgxkzh_TextBox1").val() == "") {
                Common.fnLayerAlert('施工许可证号不能为空才能上传扫描件！');
                return;
            }
            var spCount = obj.value.split('.');
            var fileExt = spCount[spCount.length - 1].toLowerCase();
            if (fileExt != 'jpeg' && fileExt != 'jpg') {
                Common.fnLayerAlert('只能上传jpeg,jpg格式图片附件！');
                if (!window.addEventListener) {
                    obj.outerHTML += '';
                }
                else {
                    obj.value = '';
                }
                return;
            }
            if (obj.value != '') {
                $("#" + objMsg).text(obj.value.substring(obj.value.lastIndexOf('\\') + 1));
                $("#" + objImg).show();

            }
            $("#" + hidden).val(hidden);
        }

        function DelFile(obj, i) {
            var rowIndex = obj.parentNode.parentNode.rowIndex;
            document.getElementById('tbFile').deleteRow(rowIndex);
            strIndex = strIndex.replace(',' + i, '');
            index--;
        }
    </script>
    <style type="text/css">
        select {
            height: 27px;
        }

        img {
            cursor: pointer;
            margin-top: 2px;
            width: 16px;
            height: 16px;
        }

        .dd {
            width: 230px !important;
            height: 26px !important;
        }

        .cd {
            width: 655px !important;
            height: 26px !important;
        }

        .zpxxxj {
            width: 850px !important;
        }

            .zpxxxj td {
                height: 30px;
            }

        .input-file {
            cursor: pointer;
            position: relative !important;
            width: 66px !important;
            height: 25px !important;
            line-height: 25px !important;
            border-radius: 0px !important;
            background: url(Images/file_up.png) left center no-repeat !important;
            border: 1px solid #44B549 !important;
            cursor: pointer !important;
            float: left !important;
            margin: -26px 7px 0 385px !important;
        }

            .input-file .file {
                cursor: pointer;
                display: block !important;
                position: absolute !important;
                top: 0 !important;
                left: 0 !important;
                width: 66px !important;
                height: 25px !important;
                opacity: 0 !important;
                -moz-opacity: 0 !important;
                filter: alpha(opacity=0);
            }

            .input-file .text {
                cursor: pointer;
                font-size: 13px;
                font-family: Arial;
                display: inline-block;
                color: #44B549;
                margin-left: 25px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <asp:HiddenField ID="Hid_ghxkz" runat="server" />
    <asp:HiddenField ID="Hid_sgxkz" runat="server" />
    <asp:HiddenField ID="Hid_other" runat="server" />

    <table id="table_Company" runat="server" class="zpxxxj" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td colspan="4" style="height: 35px;"><strong>建设单位信息</strong></td>
        </tr>
        <tr>
            <td class="ww">单位名称：</td>
            <td>
                <uc2:ctrlTextBoxEx ID="CompanyName" CssClass="dd" runat="server" canEmpty="false"
                    labelTitle="单位名称" MaxLength="100" />
                <asp:HiddenField ID="CompanyType" runat="server" Value="0" />
            </td>
            <td class="ww">社会信用代码：</td>
            <td>
                <uc2:ctrlTextBoxEx ID="CompanyCode" CssClass="dd" MaxLength="30"
                    runat="server" canEmpty="false" labelTitle="社会信用代码" />
            </td>

        </tr>
        <tr>
            <td class="ww">单位地址：</td>
            <td colspan="3">
                <uc2:ctrlTextBoxEx ID="Addres" CssClass="cd" runat="server" canEmpty="False"
                    labelTitle="单位地址" MaxLength="40" />
            </td>
        </tr>
        <tr>
            <td class="ww">单位联系人：</td>
            <td>
                <uc2:ctrlTextBoxEx ID="ContactPerson" CssClass="dd" labelTitle="单位联系人"
                    runat="server" canEmpty="False" MaxLength="10" />
            </td>
            <td class="ww">Email：</td>
            <td>
                <uc2:ctrlTextBoxEx ID="EMail" CssClass="dd" runat="server" canEmpty="false"
                    labelTitle="Email" mode="Email" MaxLength="50" />
            </td>
        </tr>
        <tr>
            <td class="ww">手机：</td>
            <td>
                <uc2:ctrlTextBoxEx ID="Mobile" labelTitle="手机" CssClass="dd" runat="server" canEmpty="False" MaxLength="11" mode="Int" />
            </td>
            <td class="ww">电话：</td>
            <td>
                <uc2:ctrlTextBoxEx ID="Tel" labelTitle="电话" CssClass="dd" runat="server" canEmpty="false" MaxLength="15" />
            </td>
        </tr>
    </table>
    <table id="tablemain" runat="server" class="zpxxxj" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td colspan="4" style="height: 35px;"><strong>工程信息</strong></td>
        </tr>
        <tr>
            <td class="ww">工程类别：</td>
            <td>
                <uc4:ctrlArchiveFormType ID="ProjectType" runat="server" Width="120px" />
            </td>
            <td class="ww">移交机构：</td>
            <td>
                <uc3:ctrlDropDownArea ID="AREA_CODE" runat="server" Width="180px" />
            </td>
        </tr>
        <tr>
            <td class="ww">项目名称：</td>
            <td colspan="3">
                <uc2:ctrlTextBoxEx ID="xmmc" CssClass="cd" runat="server" canEmpty="false"
                    MaxLength="50" labelTitle="项目名称" />
            </td>
        </tr>
        <tr>
            <td class="ww">工程名称：</td>
            <td colspan="3">
                <uc2:ctrlTextBoxEx ID="gcmc" CssClass="cd" runat="server" canEmpty="false"
                    MaxLength="100" labelTitle="工程名称" />
            </td>
        </tr>
        <tr>
            <td class="ww">工程地点：</td>
            <td colspan="3">
                <uc3:ctrlDropDownSystemInfo ID="gcqy" CurrentType="SingleProjectCode" runat="server" Width="120px" />
                <uc2:ctrlTextBoxEx ID="gcdd" runat="server" canEmpty="false"
                    labelTitle="工程地点" width="532px" MaxLength="120" />
            </td>
        </tr>
        <tr>
            <td class="ww">开工时间：</td>
            <td>
                <uc2:ctrlTextBoxEx ID="kgsj" mode="Date" ShowLblDate="false" CssClass="dd" runat="server" canEmpty="false" labelTitle="开工时间" />
            </td>
            <td class="ww">竣工时间：</td>
            <td>
                <uc2:ctrlTextBoxEx ID="jgsj" mode="Date" ShowLblDate="false" CssClass="dd" runat="server" canEmpty="True" labelTitle="竣工时间" />
            </td>
        </tr>
        <tr>
            <td class="ww">规划许可证号：</td>
            <td colspan="3">
                <uc2:ctrlTextBoxEx ID="ghxkzh" runat="server" labelTitle="规划许可证号" MaxLength="80" width="380px" />
                <div class="input-file" title="只能上传jpeg,jpg格式图片附件！">
                    <span class="text" title="只能上传jpeg,jpg格式图片附件！">浏览</span>
                    <input type="file" title="只能上传jpeg,jpg格式图片附件！" id="file1" name="file0" class="file" onchange="CheckFile(this,'<%=Hid_ghxkz.ClientID%>','span1','img1','ghxkzh')" />
                </div>
                <span class="text" id="span1" style="margin-left: 68px; width: 80px;"></span>
                <img id="img1" style="display: none;" src="Javascript/Layer/image/cross.png" onclick="ClearFile(1)" alt="附件删除" />
            </td>
        </tr>
        <tr>
            <td class="ww">施工许可证号：</td>
            <td colspan="3">
                <uc2:ctrlTextBoxEx ID="sgxkzh" runat="server" labelTitle="施工许可证号" MaxLength="80" width="380px" />
                <div class="input-file" title="只能上传jpeg,jpg格式图片附件！">
                    <span class="text" title="只能上传jpeg,jpg格式图片附件！">浏览</span>
                    <input type="file" title="只能上传jpeg,jpg格式图片附件！" id="file2" name="file1" class="file" onchange="CheckFile(this,'<%=Hid_sgxkz.ClientID%>','span2','img2','sgxkzh')" />
                </div>
                <span class="text" id="span2" style="margin-left: 68px; width: 80px;"></span>
                <img id="img2" style="display: none;" src="Javascript/Layer/image/cross.png" onclick="ClearFile(2)" alt="附件删除" />
            </td>
        </tr>
        <%--     <tr>
            <td class="ww">其它证件：
            </td>
            <td colspan="3">
                <table border="0" cellpadding="0" cellspacing="0" id="tbFile">
                    <tr>
                        <td>
                            <div class="input-file" title="只能上传jpeg,jpg格式图片附件！">
                                <span class="text">浏览</span>
                                <input type="file" id="file0" name="file" class="file" onchange="CheckFile(this,'<%=Hid_other.ClientID%>')" />
                            </div>
                        </td>
                        <td>
                            <img src="Javascript/Layer/image/tj.png" onclick="AddFile()" alt="附件继续上传" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>--%>
    </table>
    <table id="tLoginInfo" runat="server" class="zpxxxj" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td colspan="4" style="height: 35px;"><strong>建设单位登录帐号</strong></td>
        </tr>
        <tr>
            <td class="ww">登录账号：</td>
            <td colspan="3">
                <uc2:ctrlTextBoxEx ID="LoginName" labelTitle="登录账号" CssClass="cd" runat="server" canEmpty="false"
                    MaxLength="12" />
            </td>
        </tr>
        <tr>
            <td class="ww">登录密码：</td>
            <td colspan="3">
                <uc2:ctrlTextBoxEx ID="Passwd" labelTitle="登录密码" CssClass="cd" TextMode="Password" runat="server"
                    canEmpty="false" MaxLength="12" />
            </td>
        </tr>
        <tr>
            <td class="ww">密码确认：</td>
            <td colspan="3">
                <uc2:ctrlTextBoxEx ID="Passwd_check" labelTitle="密码确认" CssClass="cd" TextMode="Password"
                    runat="server" canEmpty="false" MaxLength="12" />
            </td>
        </tr>
        <tr>
            <td class="ww">
                <input type="checkbox" id="chkItem" style="width: 16px; height: 16px;" /></td>
            <td colspan="3">
                <strong>同意
                    <a href="#" id="strongItem" style="color: green;">《工程资料在线管理报建协议》</a></strong></td>
        </tr>


    </table>
    <table class="zpxxxj" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="lljzc">
                <asp:Button ID="btnSave" runat="server" Text=" 保存 " OnClick="btnSave_Click"
                    OnClientClick="return saveSubmit(this);" clickflag="ok" />
                <input type="button" id="btngoBack" value=" 返回 " onclick="Common.fnParentLayerClose()" />
            </td>
        </tr>
    </table>
    <br />
    <script src="Javascript/Common/jquery.maskedinput.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        $(function () {
            $("input[type='text'][mode='Date']").mask("9999-99-99");
        });

        $("#strongItem").click(function () {
            Common.fnLayerOpen('工程资料在线管理报建协议', '500px', '440px', 'QuickTermsContent.html', false, '');
        });

        function saveSubmit(obj) {
            var flag = true;
            $("input[type='text'],input[type='password']").each(function () {
                flag = Common.Validate($(this).attr("id"));
                if (!flag)
                    return false;
            });
            if (!flag) {
                return false;
            }
            var dt1 = $("#ctl00_Main_kgsj_TextBox1");
            var dt2 = $("#ctl00_Main_jgsj_TextBox1");
            if (Common.compareDate(dt1.val(), dt2.val()) == 1) {
                Common.FinishExe(dt1, true, "开工时间必须小于竣工时间!");
                return false;
            } else {
                Common.FinishExe(dt1, false, null);
            }

            var CompanyCodeValue = $("#<%= CompanyCode.ClientID%>").val();
            if (QuickReg.CheckCompanyCode(CompanyCodeValue).value) {
                Common.FinishExe($("#<%= CompanyCode.ClientID%>"), true, "(" + CompanyCodeValue + ")已存在,请重新录入!");
                return false;
            } else {
                Common.FinishExe($("#<%= CompanyCode.ClientID%>"), false, null);
            }

            var CompanyEmailValue = $("#<%= EMail.ClientID%>").val();
            if (QuickReg.CheckCompanyEmail(CompanyEmailValue).value) {
                Common.FinishExe($("#<%= EMail.ClientID%>"), true, "(" + CompanyEmailValue + ")已存在,请重新录入!");
                return false;
            } else {
                Common.FinishExe($("#<%= EMail.ClientID%>"), false, null);
            }

            var LoginNameValue = $("#<%= LoginName.ClientID%>").val();
            if (QuickReg.CheckLoginName(LoginNameValue).value) {
                Common.FinishExe($("#<%= LoginName.ClientID%>"), true, "(" + LoginNameValue + ")已存在,请重新录入!");
                return false;
            } else {
                Common.FinishExe($("#<%= LoginName.ClientID%>"), false, null);
            }

            if (LoginNameValue.length < 6 || LoginNameValue.length > 12) {
                Common.FinishExe($("#<%= LoginName.ClientID%>"), true, "长度必须介于6-12之间!");
                return false;
            } else {
                Common.FinishExe($("#<%= LoginName.ClientID%>"), false, null);
            }

            var PasswdValue = $("#<%= Passwd.ClientID%>").val();
            var PasswdValue2 = $("#<%= Passwd_check.ClientID%>").val();
            if (PasswdValue.length < 6 || PasswdValue.length > 12) {
                Common.FinishExe($("#<%= Passwd.ClientID%>"), true, "长度必须介于6-12之间!");
                return false;
            } else {
                Common.FinishExe($("#<%= Passwd.ClientID%>"), false, null);
                Common.FinishExe($("#<%= Passwd_check.ClientID%>"), false, null);
            }
            if (!QuickReg.CheckPassword(PasswdValue).value) {
                Common.FinishExe($("#<%= Passwd.ClientID%>"), true, "必须是数字和字母的组合!");
                return false;
            } else {
                Common.FinishExe($("#<%= Passwd.ClientID%>"), false, null);
            }
            if (PasswdValue != PasswdValue2) {
                Common.FinishExe($("#<%= Passwd.ClientID%>"), true, "两次输入的不一致!");
                return false;
            } else {
                Common.FinishExe($("#<%= Passwd.ClientID%>"), false, null);
                Common.FinishExe($("#<%= Passwd_check.ClientID%>"), false, null);
            }
            if (!$("#chkItem").is(":checked")) {
                Common.fnLayerAlert("必须同意" + Common.getRedStrongString("《工程资料在线管理报建协议》") + "才能继续报建");
                return false;
            }
            return Common.mouseClick(obj)
        }
    </script>

</asp:Content>
