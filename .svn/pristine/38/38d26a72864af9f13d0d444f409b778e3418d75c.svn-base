<%@ Page Title="" Language="C#" MasterPageFile="~/SiteSon.Master" AutoEventWireup="true" CodeBehind="SingleProjectPointAdd.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.CompanyManage.SingleProjectPointAdd" %>

<%@ Import Namespace="DigiPower.Onlinecol.Standard.Web" %>
<%@ Import Namespace="DigiPower.Onlinecol.Standard.Common" %>

<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link rel="stylesheet" href="/Javascript/Layer/skin/qingxin/skin.css" id="layout-skin" type="text/css" />
    <script type="text/javascript" src="/Javascript/Layer/layer/layer.js"></script>

    <style type="text/css">
        .zpxxxj {
            width: 450px !important;
        }

            .zpxxxj tr td {
                height: 30px !important;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <input type="hidden" id="hidSingleProjectID" value="<%= DNTRequest.GetQueryString("SingleProjectID")%>" />
    <div class="main-content">
        <div class="content-box-content">
            <div class="tab-content default-tab" id="tab1">
                <div class="anl" id="anlButtonList">
                    <table id="rpData_ArrachList">
                        <thead>
                            <tr>
                                <th width="45px">序号</th>
                                <th width="220px">X坐标</th>
                                <th width="210px">Y坐标</th>
                                <th width="45px">操作</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody class="tbody" id="bodyRepeater">
                            <asp:Repeater ID="rpData" runat="server">
                                <ItemTemplate>
                                    <tr id="tr<%# Eval("PointID")%>" class='<%#(Container.ItemIndex%2==0)?"bg01":""%>'>
                                        <td><%# Eval("OrderIndex")%></td>
                                        <td><%# Eval("X")%></td>
                                        <td><%# Eval("Y")%></td>
                                        <td>
                                            <img src="../Javascript/Layer/image/sh.png" style="cursor: pointer;"
                                                onclick="btnUpdate(<%# Eval("PointID")%>,<%# Eval("X")%>,<%# Eval("Y")%>,<%# Eval("OrderIndex")%>)" alt="修改坐标" />
                                            <img src="../Javascript/Layer/image/cross.png" style="cursor: pointer;"
                                                onclick="btnDelFile(<%# Eval("PointID")%>)" alt="删除坐标" /></td>
                                        <td></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>

    <table id="tablemain" class="zpxxxj" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="ww">X坐标：</td>
            <td>
                <uc2:ctrlTextBoxEx ID="txtX" canEmpty="false" labelTitle="X坐标"
                    mode="Float" runat="server" MaxLength="20" CssClass="sour" />
            </td>
        </tr>
        <tr>
            <td class="ww">Y坐标：</td>
            <td>    
                <uc2:ctrlTextBoxEx ID="txtY" canEmpty="false" labelTitle="Y坐标" mode="Float"
                    runat="server" MaxLength="20" CssClass="sour" />
            </td>
        </tr>
        <tr>
            <td class="ww">坐标顺序：</td>
            <td>
                <uc2:ctrlTextBoxEx ID="txtOrderIndex" canEmpty="false" labelTitle="坐标顺序" runat="server"
                    MaxLength="3" mode="Int" CssClass="sour" />
                <input type="hidden" id="HidPointID" value="0" />
                <input type="hidden" id="HidOperationType" />
            </td>
        </tr>
        <tr>
            <td class="lljzc" colspan="2">
                <input type="button" id="btnSave" value=" 新增保存 " onclick="saveSubmit(this);" clickflag="ok" />
                <input type="button" id="btngoBack" value=" 返回 " onclick="Common.fnParentLayerClose()" />
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript">
        $(".zpxxxj").css("margin-top", $("#rpData_ArrachList").height() - 20 + "px");
        //修改
        function btnUpdate(pointID, x, y, orderIndex) {
            $("#HidPointID").val(pointID);
            $("#ctl00_Main_txtX_TextBox1").val(x);
            $("#ctl00_Main_txtY_TextBox1").val(y);
            $("#ctl00_Main_txtOrderIndex_TextBox1").val(orderIndex);
            $("#btnSave").val(" 修改保存 ");
        }
        //删除
        function btnDelFile(pointID) {
            layer.confirm('确定要删除选中工程坐标?', function () {
                var len = SingleProjectPointAdd.DeleteSingleProjectPoint(Number(pointID)).value;
                if (len.indexOf(ResultState.Failure) > -1) {
                    Common.fnLayerAlert(len);
                } else {
                    window.location.href = window.location.href;
                }
            });
        }
        //保存
        function saveSubmit() {
            var flag = true;
            $("input[type='text']").each(function () {
                flag = Common.Validate($(this).attr("id"));
                if (!flag)
                    return;
            });
            if (!flag) {
                return;
            }
            var singleProjectId = $("#hidSingleProjectID").val();
            var orderIndex = $("#ctl00_Main_txtOrderIndex_TextBox1").val();
            var pointID = $("#HidPointID").val();
            var x = $("#ctl00_Main_txtX_TextBox1").val();
            var y = $("#ctl00_Main_txtY_TextBox1").val()

            if (SingleProjectPointAdd.GetRecordCountForOrderIndex(singleProjectId, orderIndex, pointID).value > 0) {
                Common.FinishExe($("#ctl00_Main_txtOrderIndex_TextBox1"), true, Common.getRedStrongString(orderIndex) + "已存在,不能重复!");
                return;
            } else {
                Common.FinishExe($("#ctl00_Main_txtOrderIndex_TextBox1"), false, null);
            }

            var len = SingleProjectPointAdd.SaveSingleProjectPoint(singleProjectId, orderIndex, pointID, x, y).value;
            if (len.indexOf(ResultState.Failure) > -1) {
                Common.fnLayerAlert(len);
            } else {
                layer.alert('工程坐标保存成功!', { btnAlign: 'c', time: 6000 }, function (index) {
                    layer.close(index);
                    window.location.href = window.location.href;
                });
            }
        }
    </script>
    <br />
</asp:Content>
