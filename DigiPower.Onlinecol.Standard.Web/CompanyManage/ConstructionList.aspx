﻿<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="ConstructionList.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.ConstructionList" Title="项目管理" %>

<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script language="javascript" type="text/javascript">
        function getNewUrl() {
            var url = window.location.href;
            url = Common.urlreplace(url, 'txtxmmc', escape($('#ctl00_Main_txtXMMC_TextBox1').val()));
            url = Common.urlreplace(url, 'PageIndex', $('#CurrentPageIndex').text());
            url = Common.urlreplace(url, 'rn', Math.random());
            return url;
        }
        //新增
        function btnAdd() {
            var selKey = Common.getRadioKeyToArray();
            var url = 'CompanyReg2Edit.aspx?action=' + PageState.Add + '&id=0&rn=' + Math.random();
            if (selKey.length > 0)
                url = 'CompanyReg2Edit.aspx?action=' + PageState.Add + '&id=' + selKey[0] + '&rn=' + Math.random();
            Common.fnLayerOpen('项目信息-修改', "550px", "440px", url, true, "项目信息新增成功!");
        }
        //编辑
        function btnEdit() {
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                var url = 'CompanyReg2Edit.aspx?action=' + PageState.Edit + '&id=' + keyList[0] + '&rn=' + Math.random();
                Common.fnLayerOpen('项目信息-修改', "550px", "440px", url, true, "项目信息修改成功!");
            }
        }
        //删除
        function btnDel() {
            if (Common.isRadioCheck()) {
                layer.confirm('确定要删除选中项目信息?<br/>' + Common.getRedStrongString("注意:项目下有工程则不能删除!"), function () {
                    var keyList = Common.getRadioKeyToArray();
                    if (ConstructionList.DeleteConstruction(keyList[0]).value) {
                        Common.fnLayerAlertAndRefresh("项目删除成功!");
                    } else {
                        Common.fnLayerAlert("该项目包含有工程,不能删除!");
                    }
                });
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <input type="hidden" id="hidOpenFlag" />
    <div class="main-content">
        <div class="content-box-search">
            <table id="c1">
                <tr>
                    <td class="condition">项目名称：</td>
                    <td class="c2">
                        <uc3:ctrlTextBoxEx runat="server" ID="txtXMMC" MaxLength="20" width="140" />
                    </td>
                    <td class="ss">
                        <asp:Button ID="btnSearch" runat="server" Text=" 查询 " OnClick="btnSearch_Click" />
                        <input type="button" value="重 置" id="btnSearchParRet" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="ss"></div>
        <div class="content-box-content">
            <div class="tab-content default-tab" id="tab1">
                <div class="anl" id="anlButtonList">
                    <input type="button" id="MrcBtnAdd" title="新增" onclick="btnAdd()" value="新增" />
                    <input type="button" id="MrcBtnEdit" title="修改" onclick="btnEdit()" value="修改" />
                    <input type="button" id="MrcBtnDel" title="删除" onclick="btnDel()" value="删除" />
                    <%--       <input type="button" id="MrcBtnLookSingle" title="查看工程" value="查看工程" onclick="btnLookSingle()" />
                    <input type="button" id="MrcBtnAddSingle" title="新增工程" value="新增工程" onclick="btnAddSingle()" />--%>
                </div>
                <table>
                    <thead>
                        <tr>
                            <th width="20px"></th>
                            <th width="70px">项目编号</th>
                            <th>项目名称</th>
                            <th width="240px">项目地点</th>
                            <th width="180px">建设单位</th>
                            <th width="140px">立项批准文号</th>
                        </tr>
                    </thead>
                    <tbody class="tbody" id="bodyRepeater">
                        <asp:Repeater ID="rpData" runat="server">
                            <ItemTemplate>
                                <tr class='<%#(Container.ItemIndex%2==0)?"bg01":""%>'>
                                    <td>
                                        <input type="radio" name="radio" value='<%# Eval("ConstructionProjectID")%>' />
                                    </td>
                                    <td><%#Eval("XMH")%></td>
                                    <td><%#Eval("XMMC")%></td>
                                    <td><%#Eval("XMDD")%></td>
                                    <td><%#Eval("JSDW")%></td>
                                    <td><%#Eval("lxpzwh")%></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <div class="pagination" style="height: 23px;">
                    <webdiyer:AspNetPager ID="AspNetPager" runat="server" PagingButtonSpacing="8px"
                        OnPageChanged="AspNetPager_PageChanged" ShowCustomInfoSection="left" CustomInfoStyle="text-align:left;"
                        FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" PageIndexBoxStyle="text-align:right;"
                        CustomInfoHTML="共有 <strong>%RecordCount%</strong> 条记录，每页 <strong>%PageSize%</strong> 条，当前第 <strong id='CurrentPageIndex'>%CurrentPageIndex%</strong> 页，共<strong> %PageCount%</strong> 页"
                        UrlPaging="false" Width="100%" layouttype="Table" ShowNavigationToolTip="True"
                        ShowPageIndex="False" HorizontalAlign="Right" PageIndexBoxType="TextBox" ShowPageIndexBox="Always" SubmitButtonText="跳转" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" AlwaysShow="True">
                    </webdiyer:AspNetPager>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
