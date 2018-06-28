<%@ Page Title="" Language="C#" MasterPageFile="~/SiteSon.Master" AutoEventWireup="true" CodeBehind="SingleProjectFileAttachAdd.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.CompanyManage.SingleProjectFileAttachAdd" %>

<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link rel="stylesheet" href="/Javascript/Layer/skin/qingxin/skin.css" id="layout-skin" type="text/css" />
    <script type="text/javascript" src="/Javascript/Layer/layer/layer.js"></script>
    <script type="text/javascript">
        var index = 0;
        var indexID = 10;
        function AddFile() {
            if (index < 2) {
                index++;
                indexID++;
                var tr = document.getElementById('tbFile').insertRow(); //创建行对象
                tr.id = 'tr' + index;

                var strHTML = "<div class=\"input-file\" title=\"只能上传jpeg,jpg格式图片附件！\"> ";
                strHTML += "          <span class=\"text\" title=\"只能上传jpeg,jpg格式图片附件！\">浏览</span> ";
                strHTML += "          <input type=\"file\" title=\"只能上传jpeg,jpg格式图片附件！\" id=\"file" + indexID + "\" name=\"file" + indexID + "\"  class=\"file\" onchange=\"CheckFile(this,'<%=Hid_other.ClientID%>'," + indexID + ")\" /> ";
                strHTML += "</div> ";
                strHTML += "<span class=\"text\" id=\"span" + indexID + "\" style=\"margin-left: 0px; width: 80px;\"></span> ";
                strHTML += "<img id=\"img" + indexID + "\" style=\"display: none;\" src=\"../Javascript/Layer/image/cross.png\" onclick=\"ClearFile(this," + indexID + ")\" alt=\"附件删除\" /> ";
                tr.insertCell().innerHTML = strHTML;
            } else {
                Common.fnLayerAlert('其它证件附件最多只能上传' + Common.getRedStrongString("3") + '个！');
            }
        }

        function ClearFile(obj, index) {
            obj = document.getElementById("file" + index);
            if (!window.addEventListener) {
                obj.outerHTML += '';
            }
            else {
                obj.value = '';
            }
            $("#span" + index).text("");
            $("#img" + index).hide();
            if (index > 10) {
                DelFile(obj);
            }
        }

        function CheckFile(obj, hidden, index) {//检测文件是否合法
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
                $("#span" + index).text(obj.value.substring(obj.value.lastIndexOf('\\') + 1));
                $("#img" + index).show();
            }
            $("#" + hidden).val(index);
        }

        function DelFile(obj) {
            var rowIndex = obj.parentNode.parentNode.parentNode.rowIndex;
            document.getElementById('tbFile').deleteRow(rowIndex);
            index--;
        }

        function btnDelFile(attachID) {
            layer.confirm('确定要删除选中证书附件?', function (index) {
                layer.close(index);
                var len = SingleProjectFileAttachAdd.DeleteFileAttach(attachID).value;
                if (len.indexOf(ResultState.Failure) > -1) {
                    Common.fnLayerAlert(len);
                } else {
                    $("#tr" + attachID).remove();
                    $("#<%= tablemain.ClientID%>").css({ "margin-top": $("#rpData_ArrachList").outerHeight() - 15 + "px" });
                }
            });
        }
        function openImage(AttachPath) {
            var url = '../' + AttachPath;
            window.top.parent.ParentOpenDiv('附件预览', url, '80%', '95%');
        }
    </script>
    <style type="text/css">
        img {
            cursor: pointer;
            margin-top: 2px;
            width: 16px;
            height: 16px;
        }

        .zpxxxj {
            margin-top: 15px;
            width: 450px !important;
        }

            .zpxxxj tr td {
                height: 30px !important;
            }

        input {
            border-bottom: solid 1px;
        }

        .trFile {
            width: 280px !important;
        }

        .input-file {
            cursor: pointer;
            position: relative !important;
            width: 66px !important;
            height: 25px !important;
            line-height: 25px !important;
            border-radius: 0px !important;
            background: url(../Images/file_up.png) left center no-repeat !important;
            border: 1px solid #44B549 !important;
            cursor: pointer !important;
            float: left !important;
            margin: 0px 7px 0 0px !important;
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
    <div class="main-content">
        <div class="content-box-content">
            <div class="tab-content default-tab" id="tab1">
                <div class="anl" id="anlButtonList">
                    <table id="rpData_ArrachList">
                        <thead>
                            <tr>
                                <th width="20px"></th>
                                <th width="110px">文号项类型</th>
                                <th>文号名称</th>
                                <th width="30px">操作</th>
                            </tr>
                        </thead>
                        <tbody class="tbody" id="bodyRepeater">
                            <asp:Repeater ID="rpData" runat="server">
                                <ItemTemplate>
                                    <tr id="tr<%# Eval("AttachID")%>" class='<%#(Container.ItemIndex%2==0)?"bg01":""%>'>
                                        <td>
                                            <%# Container.ItemIndex+1 %> 
                                        </td>
                                        <td>
                                            <%# getAttachCodeName(Eval("AttachCode").ToString().Trim())%>
                                        </td>
                                        <td style="cursor: pointer;" onclick="openImage('<%#Eval("AttachPath")%>')">
                                            <%#Eval("AttachName")%> </td>
                                        <td>
                                            <img src="../Javascript/Layer/image/cross.png"
                                                onclick="btnDelFile(<%# Eval("AttachID")%>)" alt="附件删除" /></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>

                </div>
            </div>
        </div>
    </div>
    <table id="tablemain" runat="server" class="zpxxxj" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="ww">规划许可证号：</td>
            <td>
                <%-- <input type="file" id="file1" name="file0" class="trFile" onchange="CheckFile(this,'<%=Hid_ghxkz.ClientID%>')" />--%>
                <div class="input-file" title="只能上传jpeg,jpg格式图片附件！">
                    <span class="text" title="只能上传jpeg,jpg格式图片附件！">浏览</span>
                    <input type="file" title="只能上传jpeg,jpg格式图片附件！" id="file1" name="file0" class="file" onchange="CheckFile(this,'<%=Hid_ghxkz.ClientID%>',1)" />
                </div>
                <span class="text" id="span1" style="margin-left: 0px; width: 80px;"></span>
                <img id="img1" style="display: none;" src="../Javascript/Layer/image/cross.png" onclick="ClearFile(this,1)" alt="附件删除" />
            </td>
        </tr>
        <tr>
            <td class="ww">施工许可证号：</td>
            <td>
                <%--<input type="file" id="file2" name="file1" class="trFile" onchange="CheckFile(this,'<%=Hid_sgxkz.ClientID%>')" />--%>
                <div class="input-file" title="只能上传jpeg,jpg格式图片附件！">
                    <span class="text" title="只能上传jpeg,jpg格式图片附件！">浏览</span>
                    <input type="file" title="只能上传jpeg,jpg格式图片附件！" id="file2" name="file1" class="file" onchange="CheckFile(this,'<%=Hid_sgxkz.ClientID%>',2)" />
                </div>
                <span class="text" id="span2" style="margin-left: 0px; width: 80px;"></span>
                <img id="img2" style="display: none;" src="../Javascript/Layer/image/cross.png" onclick="ClearFile(this,2)" alt="附件删除" />
            </td>
        </tr>
        <tr>
            <td class="ww">其它证件：
            </td>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" id="tbFile">
                    <tr>
                        <td>
                            <%--<input type="file" id="file0" class="trFile" name="file" onchange="CheckFile(this,'<%=Hid_other.ClientID%>')" />--%>
                            <div class="input-file" title="只能上传jpeg,jpg格式图片附件！">
                                <span class="text" title="只能上传jpeg,jpg格式图片附件！">浏览</span>
                                <input type="file" title="只能上传jpeg,jpg格式图片附件！" id="file10" name="file10" class="file" onchange="CheckFile(this,'<%=Hid_other.ClientID%>',10)" />
                            </div>
                            <span class="text" id="span10" style="margin-left: 0px; width: 80px;"></span>
                            <img id="img10" style="display: none;" src="../Javascript/Layer/image/cross.png" onclick="ClearFile(this,10)" alt="附件删除" />
                            <img src="../Javascript/Layer/image/tj.png" onclick="AddFile()" alt="附件继续上传" />
                        </td>
                    </tr>
                </table>
            </td>
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
        <tr>
            <td>
                <strong style="color: red; font-size: 13px;">说明:单份文件最大<%= DigiPower.Onlinecol.Standard.Web.SystemSet._FILESIZE%>M,文件格式:*.jpg;*.jpeg
                </strong>
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript">
        $("#<%= tablemain.ClientID%>").css({ "margin-top": $("#rpData_ArrachList").outerHeight() - 15 + "px" });
        function saveSubmit(obj) {
            if ($('#<%=Hid_ghxkz.ClientID%>').val() == "" && $('#<%=Hid_sgxkz.ClientID%>').val() == "" && $('#<%=Hid_other.ClientID%>').val() == "") {
                Common.fnLayerAlert('请至少选择一个附件上传!');
                return false;
            }
            return Common.mouseClick(obj)
        }
    </script>
    <br />
</asp:Content>
