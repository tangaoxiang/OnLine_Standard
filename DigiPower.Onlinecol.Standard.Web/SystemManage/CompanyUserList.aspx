<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="CompanyUserList.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.CompanyUserList" Title="业务单位用户管理" %>

<%@ Register Src="../CommonCtrl/ctrlDropDownCompanyInfo.ascx" TagName="ctrlDropDownCompanyInfo"
    TagPrefix="uc2" %>
<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc1" %>
<%@ Import Namespace="DigiPower.Onlinecol.Standard.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script language="javascript" type="text/javascript">
        function getNewUrl() {
            var url = window.location.href;
            url = Common.urlreplace(url, 'txtCompanyName', escape($('#ctl00_Main_txtCompanyName_TextBox1').val()));
            url = Common.urlreplace(url, 'txtUserName', escape($('#ctl00_Main_txtUserName_TextBox1').val()));
            url = Common.urlreplace(url, 'txtLoginName', escape($('#ctl00_Main_txtLoginName_TextBox1').val()));
            url = Common.urlreplace(url, 'txtGcmc', escape($('#ctl00_Main_txtGcmc_TextBox1').val()));
            url = Common.urlreplace(url, 'ddlUserType', escape($('#ctl00_Main_ddlUserType').val()));
            url = Common.urlreplace(url, 'txtGcdd', escape($('#ctl00_Main_txtGcdd_TextBox1').val()));
            url = Common.urlreplace(url, 'PageIndex', $('#CurrentPageIndex').text());
            url = Common.urlreplace(url, 'rn', Math.random());
            return url;
        }
        //编辑
        function btnEdit() {
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                var url = 'CompanyUserAdd.aspx?action=' + PageState.Edit + '&id=' + keyList[0] + '&rn=' + Math.random();
                Common.fnLayerOpen('业务单位用户-修改', "600px", "490px", url, true, "用户信息修改成功!");
            }
        }
        //密码重置
        function BtnPwdReset() {
            if (Common.isRadioCheck()) {
                layer.confirm('确定要初始化登录密码?', function () {
                    var keyList = Common.getRadioKeyToArray();
                    var len = CompanyUserList.ResetPwd(keyList[0]).value;
                    if (len.indexOf(ResultState.Failure) < 0) {
                        Common.fnLayerAlert("密码重置成功,新密码为" + len);
                    } else {
                        Common.fnLayerAlert(len);
                    }
                });
            }
        }
        //用户相关工程
        function BtnBtnUserbyPro() {
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                var url = '../SystemManage/UserByProjectList.aspx?action=' + PageState.View + '&id=' + keyList[0] + '&rn=' + Math.random();
                window.top.parent.ParentOpenDiv('用户(' + keyList[2] + '-' + keyList[1] + ')相关工程', url, '90%', '90%');
            }
        }
    </script>
    <style type="text/css">
        select {
            height: 21px;
            width: 165px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <input type="hidden" id="hidOpenFlag" />
    <div class="main-content">
        <div class="content-box-search">
            <%--<button type="button" id="more_button_plus" class="more_button_plus"></button>--%>
            <table id="c1">
                <tr>
                    <td class="condition">单位名称：</td>
                    <td class="c2">
                        <uc1:ctrlTextBoxEx runat="server" ID="txtCompanyName" MaxLength="20" />
                    </td>
                    <td class="condition">用户名称：</td>
                    <td class="c2">
                        <uc1:ctrlTextBoxEx runat="server" ID="txtUserName" MaxLength="20" />
                    </td>
                    <td class="condition">登录账号：</td>
                    <td class="c2">
                        <uc1:ctrlTextBoxEx runat="server" ID="txtLoginName" MaxLength="20" />
                    </td>
                    <td class="ss">
                        <asp:Button ID="btnSearch" runat="server" Text=" 查询 " OnClick="btnSearch_Click" />
                        <input type="button" value="重 置" id="btnSearchParRet" />
                    </td>
                    <td>
                        <button style="float: right;" type="button" id="more_button_plus" class="more_button_plus"></button>
                    </td>
                </tr>
            </table>
            <div class="moremore">
                <table id="c1">
                    <tr>
                        <td class="condition">用户类别：</td>
                        <td class="c2">
                            <asp:DropDownList runat="server" ID="ddlUserType"></asp:DropDownList>
                        </td>
                        <td class="condition">工程名称：</td>
                        <td class="c2">
                            <uc1:ctrlTextBoxEx runat="server" ID="txtGcmc" MaxLength="20" />
                        </td>
                        <td class="condition">工程地址：</td>
                        <td class="c2">
                            <uc1:ctrlTextBoxEx runat="server" ID="txtGcdd" MaxLength="20" />
                        </td>
                        <td></td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="ss"></div>
        <div class="content-box-content">
            <div class="tab-content default-tab" id="tab1">
                <div class="anl" id="anlButtonList">
                    <input type="button" id="MrcBtnEdit" title="修改" onclick="btnEdit()" value="修改" />
                    <input type="button" id="MrcBtnPwdReset" title="密码重置" onclick="BtnPwdReset()" value="密码重置" />
                    <input type="button" id="MrcBtnUserbyPro" title="用户相关工程" onclick="BtnBtnUserbyPro()" value="用户相关工程" />

                </div>
                <table>
                    <thead>
                        <tr>
                            <th width="20px"></th>
                            <th width="70px">单位类别</th>
                            <th>单位名称</th>
                            <th width="140px">组织机构代码</th>
                            <th width="80px">用户类别</th>
                            <th width="100px">登录账号</th>
                            <th width="80px">用户名称</th>
                            <th width="100px">个人电话</th>
                            <th width="90px">个人手机</th>
                            <th width="70px">是否有效</th>
                        </tr>
                    </thead>
                    <tbody class="tbody" id="bodyRepeater">
                        <asp:Repeater ID="rpData" runat="server">
                            <ItemTemplate>
                                <tr class='<%#(Container.ItemIndex%2==0)?"bg01":""%>'>
                                    <td>
                                        <input type="radio" name="radio" value='<%# Eval("UserID")%>,<%#Eval("UserName") %>,<%#Eval("CompanyName") %>' />
                                    </td>
                                    <td><%#Eval("CompanyTypeName")%></td>
                                    <td><%#Eval("CompanyName")%></td>
                                    <td><%#Eval("CompanyCode")%></td>
                                    <td><%#PublicModel.GetEnumDescription((SystemSet.EumUserType)Enum.Parse(typeof(SystemSet.EumUserType),Eval("UserType").ToString()))%></td>
                                    <td><%#Eval("LoginName")%></td>
                                    <td><%#Eval("UserName")%></td>
                                    <td><%#Eval("Tel")%></td>
                                    <td><%#Eval("Mobile")%></td>
                                    <td><%#PublicModel.GetImageforStatus(Convert.ToBoolean(Eval("IsValid")))%></td>
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
</asp:Content>
