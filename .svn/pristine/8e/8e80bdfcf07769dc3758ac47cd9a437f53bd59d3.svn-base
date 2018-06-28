<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="SignatureCompanyList.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.SignatureCompanyList" Title="签章单位管理" %>

<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script language="javascript" type="text/javascript">
        function getNewUrl() {
            var url = window.location.href;
            url = Common.urlreplace(url, 'txtCompanyName', escape($('#ctl00_Main_txtCompanyName_TextBox1').val()));
            url = Common.urlreplace(url, 'PageIndex', $('#CurrentPageIndex').text());
            url = Common.urlreplace(url, 'rn', Math.random());
            return url;
        }
        //新增
        function btnAdd() {
            var selKey = Common.getRadioKeyToArray();
            var url = '../SystemManage/SignatureCompanyAdd.aspx?action=' + PageState.Add + '&id=0&rn=' + Math.random();
            if (selKey.length > 0)
                url = '../SystemManage/SignatureCompanyAdd.aspx?action=' + PageState.Add + '&id=' + selKey[0] + '&rn=' +
                    Math.random();

            Common.fnLayerOpen('签章单位信息-新增', "100%", "100%", url, true, "签章单位信息新增成功!");
        }
        //编辑
        function btnEdit() {
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                var url = '../SystemManage/SignatureCompanyAdd.aspx?action=' + PageState.Edit + '&id=' +
                    keyList[0] + '&rn=' + Math.random();
                Common.fnLayerOpen('签章单位信息-修改', "100%", "100%", url, true, "签章单位信息修改成功!");
            }
        }
        //删除
        function btnDel() {
            if (Common.isRadioCheck()) {
                layer.confirm('确定要删除选中签章公司?<br/>' + Common.getRedStrongString("注意<br/>1:建设单位不能删除<br/>2:该公司的用户没有签任何文件!"), function () {
                    var keyList = Common.getRadioKeyToArray();
                    if (Number(keyList[2]) == Number(<%= DigiPower.Onlinecol.Standard.Web.SystemSet._JSCOMPANYINFO%>)) {
                        Common.fnLayerAlert("建设单位不能删除!");
                        return;
                    }
                    var fileCount = SignatureCompanyList.GetSignatureCount(Number(keyList[1])).value;
                    if (fileCount > 0) {
                        Common.fnLayerAlert("该签章单位已有签章记录" + Common.getRedStrongString(fileCount) + "条,不能删除!");
                    } else {
                        var len = SignatureCompanyList.DeleteCompany(keyList[0]).value;
                        if (len.indexOf(ResultState.Failure) > -1) {
                            Common.fnLayerAlert(len);
                        } else {
                            layer.alert('单位删除成功!', { btnAlign: 'c' }, function (index) {
                                window.location.href = getNewUrl();
                                layer.close(index);
                            });
                        }
                    }
                });
            }
        }
        //用户相关工程
        function BtnBtnUserbyPro() {
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                var url = '../SystemManage/UserByProjectList.aspx?action=' + PageState.View + '&id=' + keyList[1] + '&rn=' + Math.random();
                window.top.parent.ParentOpenDiv('用户(' + keyList[3] + '-' + keyList[4] + ')相关工程', url, '90%', '90%');
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
                    <td class="condition">单位名称：</td>
                    <td class="c2">
                        <uc1:ctrlTextBoxEx runat="server" ID="txtCompanyName" MaxLength="20" />
                    </td>
                    <td class="ss">
                        <asp:Button ID="btnSearch" runat="server" Text=" 查询 " OnClick="btnSearch_Click" />
                        <input type="button" value="重 置" id="btnSearchParRet" /></td>
                    <td></td>
                    <td></td>
                    <td></td>
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
                    <input type="button" id="MrcBtnUserbyPro" title="用户相关工程" onclick="BtnBtnUserbyPro()" value="用户相关工程" />
                </div>
                <table>
                    <thead>
                        <tr>
                            <th width="20px"></th>
                            <th width="70px">单位类别</th>
                            <th width="120px">角色名称</th>
                            <th>单位名称</th>
                            <th width="140px">组织机构代码</th>
                            <th width="100px">联系人</th>
                            <th width="120px">手机</th>
                            <th width="120px">用户名称</th>
                            <th width="100px">登录账号</th>
                        </tr>
                    </thead>
                    <tbody class="tbody" id="bodyRepeater">
                        <asp:Repeater ID="rpData" runat="server">
                            <ItemTemplate>
                                <tr class='<%#(Container.ItemIndex%2==0)?"bg01":""%>'>
                                    <td>
                                        <input type="radio" name="radio" value='<%# Eval("CompanyID")%>,<%# Eval("UserID")%>,<%# Eval("CompanyType")%>,<%# Eval("companyname")%>,<%# Eval("UserName")%>' />
                                    </td>
                                    <td><%#Eval("CompanyTypeName")%></td>
                                    <td><%#Eval("RoleName")%></td>
                                    <td><%#Eval("companyname")%></td>
                                    <td><%#Eval("CompanyCode")%></td>
                                    <td><%#Eval("contactperson")%></td>
                                    <td><%#Eval("mobile")%></td>
                                    <td><%#Eval("UserName")%></td>
                                    <td><%#Eval("LoginName")%></td>
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
