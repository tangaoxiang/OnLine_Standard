<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="SingleProjectList.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.SingleProjectList" %>

<%@ Import Namespace="DigiPower.Onlinecol.Standard.Web" %>
<%@ Import Namespace="DigiPower.Onlinecol.Standard.Common" %>

<%@ Register Src="../CommonCtrl/ctrlDropDownSystemInfo.ascx" TagName="ctrlDropDownSystemInfo"
    TagPrefix="uc1" %>
<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc3" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownUser.ascx" TagName="ctrlDropDownUser" TagPrefix="uc2" %>
<%@ Register Src="../CommonCtrl/ctrlDropDownExportType.ascx" TagName="ctrlDropDownExportType" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="../Javascript/jedate/jedate.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function getNewUrl() {
            var url = window.location.href;
            url = Common.urlreplace(url, 'ddlChargeUserID', escape($('#ctl00_Main_ddlChargeUserID_ddlUser').val()));
            url = Common.urlreplace(url, 'ddlProjectType', escape($('#ctl00_Main_ddlProjectType_ddlSystemInfo').val()));
            url = Common.urlreplace(url, 'kgsj1', escape($('#ctl00_Main_kgsj1_TextBox').val()));
            url = Common.urlreplace(url, 'kgsj2', escape($('#ctl00_Main_kgsj2_TextBox1').val()));
            url = Common.urlreplace(url, 'jgsj1', escape($('#ctl00_Main_jgsj1_TextBox1').val()));
            url = Common.urlreplace(url, 'jgsj2', escape($('#ctl00_Main_jgsj2_TextBox1').val()));
            url = Common.urlreplace(url, 'txtGcmc', escape($('#ctl00_Main_txtGcmc_TextBox1').val()));
            url = Common.urlreplace(url, 'txtGcbm', escape($('#ctl00_Main_txtGcbm_TextBox1').val()));
            url = Common.urlreplace(url, 'txtghxkzh', escape($('#ctl00_Main_txtghxkzh_TextBox1').val()));
            url = Common.urlreplace(url, 'txtsgxkzh', escape($('#ctl00_Main_txtsgxkzh_TextBox1').val()));
            url = Common.urlreplace(url, 'txtGcdd', escape($('#ctl00_Main_txtGcdd_TextBox1').val()));
            url = Common.urlreplace(url, 'PageIndex', $('#CurrentPageIndex').text());
            url = Common.urlreplace(url, 'rn', Math.random());
            return url;
        }
        function getProjectTypeeUrl() {
            return "&ProjectType=" + '<%= PublicModel.GetFileTypeForProjectTypeId(ProjectType)%>';
        }
        //新增
        function btnAdd() {
            var selKey = Common.getRadioKeyToArray();
            var url = 'CompanyReg3_<%= PublicModel.GetFileTypeForProjectType( PublicModel.GetFileTypeForProjectTypeId(ProjectType))%>Edit.aspx?action=' +
                PageState.Add + '&SingleProjectID=0&rn=' + Math.random() + getProjectTypeeUrl();
            if (selKey.length > 0)
                url = 'CompanyReg3_' + Common.getFileTypeForProjectType(selKey[1]) + 'Edit.aspx?action=' +
                    PageState.Add + '&SingleProjectID=' + selKey[0] + '&rn=' + Math.random() + getProjectTypeeUrl();

            Common.fnLayerOpen('工程信息-新增', '100%', '100%', url, true, '工程信息新增成功!');
        }
        //编辑
        function btnEdit() {
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                var url = 'CompanyReg3_' + Common.getFileTypeForProjectType(keyList[1]) + 'Edit.aspx?action=' +
                    PageState.Edit + '&SingleProjectID=' + keyList[0] + '&rn=' + Math.random() + getProjectTypeeUrl();
                Common.fnLayerOpen('工程信息-修改', '100%', '100%', url, true, '工程信息修改成功!');
            }
        }
        //删除
        function btnDel() {
            if (Common.isRadioCheck()) {
                layer.confirm('确定要删除选中工程?<br/>' + Common.getRedStrongString("注意:工程下没有登记任何文件则可以删除工程!"), function () {
                    var keyList = Common.getRadioKeyToArray();
                    var fileCount = SingleProjectList.GetFileCount(Number(keyList[0])).value;
                    if (fileCount > 0) {
                        Common.fnLayerAlert("该工程已有" + Common.getRedStrongString(fileCount) + "份登记文件,不能删除!");
                    } else {
                        var len = SingleProjectList.DeleteSingleProject(keyList[0]).value;
                        if (len.indexOf(ResultState.Failure) > -1) {
                            Common.fnLayerAlert(len);
                        } else {
                            Common.fnLayerAlertAndRefresh("工程信息删除成功");
                        }
                    }
                });
            }
        }
        //变更业务指导人员
        function btnChangeUser() {
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                if (Number(keyList[3]) > 0) {
                    var url = 'ChangeChargeUser.aspx?action=' + PageState.Edit + '&SingleProjectID=' +
                            keyList[0] + '&ChargeUserID=' + keyList[2] + '&rn=' + Math.random();
                    Common.fnLayerOpen('变更业务指导人员', '400px', '290px', url, true, '业务指导人员变更成功!');
                } else {
                    Common.fnLayerAlert("工程未确认通过,不能变更业务指导人员!");
                }
            }
        }
        //工程重新入库
        function btnRestartImportTo() {
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                if (SingleProjectList.UpdateSingleProjectStatus(keyList[0]).value) {
                    Common.fnLayerAlertAndRefresh("重新入库成功!");
                } else {
                    Common.fnLayerAlert('工程还未入库,不用重新入库！');
                }
            }
        }
        //证书上传
        function btnUpload() {
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                var url = 'SingleProjectFileAttachAdd.aspx?SingleProjectID=' + keyList[0] + '&rn=' + Math.random();
                Common.fnLayerOpen('证书上传-工程编号:' + Common.getRedStrongString(keyList[4]), '550px', '515px', url, true, '证书附件上传成功!');
            }
        }
        //坐标设置
        function btnPoint() {
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                var url = 'SingleProjectPointAdd.aspx?SingleProjectID=' + keyList[0] + '&rn=' + Math.random();
                Common.fnLayerOpen('坐标设置-工程编号:' + Common.getRedStrongString(keyList[4]), '550px', '515px', url, false, '');
            }
        }
    </script>
    <style type="text/css">
        select {
            height: 21px;
        }

        .c3 {
            width: 260px !important;
        }

        .condition {
            width: 100px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <input type="hidden" id="hidOpenFlag" />
    <div class="main-content">
        <div class="content-box-search">
            <table id="c1">
                <tr>
                    <td class="condition">工程类别：</td>
                    <td class="c2 c3">
                        <uc1:ctrlDropDownSystemInfo ID="ddlProjectType" runat="server"
                            CurrentType="Archive_Form" Width="186" />
                    </td>
                    <td class="condition">工程名称：</td>
                    <td class="c2">
                        <uc3:ctrlTextBoxEx runat="server" ID="txtGcmc" MaxLength="20" width="140" />
                    </td>
                    <td class="condition">工程编号：</td>
                    <td class="c2">
                        <uc3:ctrlTextBoxEx runat="server" ID="txtGcbm" MaxLength="10" width="140" />
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
                        <td class="condition">开工时间：</td>
                        <td class="c2 c3">
                            <uc3:ctrlTextBoxEx ID="kgsj1" runat="server" Status="Select" mode="Date" ShowLblDate="false" width="80px" CssClass="SelectText" />
                            &nbsp;~&nbsp;
                             <uc3:ctrlTextBoxEx ID="kgsj2" runat="server" Status="Select" mode="Date" ShowLblDate="false" width="80px" CssClass="SelectText" />
                        </td>
                        <td class="condition">工程地址：</td>
                        <td class="c2">
                            <uc3:ctrlTextBoxEx runat="server" ID="txtGcdd" MaxLength="20" width="140" />
                        </td>
                        <td class="condition">规划许可证号：</td>
                        <td class="c2">
                            <uc3:ctrlTextBoxEx runat="server" ID="txtghxkzh" MaxLength="20" width="140" />
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td class="condition">竣工时间：</td>
                        <td class="c2 c3">
                            <uc3:ctrlTextBoxEx ID="jgsj1" runat="server" Status="Select" mode="Date" ShowLblDate="false" width="80px" CssClass="SelectText" />
                            &nbsp;~&nbsp;
                             <uc3:ctrlTextBoxEx ID="jgsj2" runat="server" Status="Select" mode="Date" ShowLblDate="false" width="80px" CssClass="SelectText" />
                        </td>
                        <td class="condition">业务指导人员：</td>
                        <td class="c2">
                            <uc2:ctrlDropDownUser ID="ddlChargeUserID" runat="server" Width="142" />
                        </td>
                        <td class="condition">施工许可证号：</td>
                        <td class="c2">
                            <uc3:ctrlTextBoxEx runat="server" ID="txtsgxkzh" MaxLength="20" width="140" />
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
                    <input type="button" id="MrcBtnAdd" title="新增" onclick="btnAdd()" value="新增" />
                    <input type="button" id="MrcBtnEdit" title="修改" onclick="btnEdit()" value="修改" />
                    <input type="button" id="MrcBtnDel" title="删除" onclick="btnDel()" value="删除" />
                    <input type="button" id="MrcUpload" title="规划许可证,施工许可证等证书上传" onclick="btnUpload()" value="证书上传" />
                    <input type="button" id="MrcPoint" title="工程单点或多点坐标设置" onclick="btnPoint()" value="坐标设置" />
                    <input type="button" id="MrcBtnChangeUser" title="变更业务指导人员" onclick="btnChangeUser()" value="变更业务指导人员" />
                    <input type="button" id="MrcBtnRestartImportTo" title="工程重新入库,便于打包工具重新打包,只有已入库的工程才能重新入库" onclick="btnRestartImportTo()" value="工程重新入库" />
                </div>
                <table>
                    <thead>
                        <tr>
                            <th width="20px"></th>
                            <th width="90px">项目类型</th>
                            <th width="200px">项目名称</th>
                            <th width="70px">工程编号</th>
                            <th>工程名称</th>
                            <th width="180px">规划许可证号</th>
                            <th width="180px">施工许可证号</th>
                            <th width="85px">业务指导人员</th>
                            <th width="62px">工程状态</th>
                        </tr>
                    </thead>
                    <tbody class="tbody" id="bodyRepeater">
                        <asp:Repeater ID="rpData" runat="server">
                            <ItemTemplate>
                                <tr class='<%#(Container.ItemIndex%2==0)?"bg01":""%>'>
                                    <td>
                                        <input type="radio" name="radio" value='<%# Eval("SingleProjectID")%>,<%# Eval("ProjectType")%>,<%# Eval("ChargeUserID")%>,<%# Eval("WorkFlow_DoStatus")%>,<%#Eval("gcbm")%>' />
                                    </td>
                                    <td><%#Eval("ProjectTypeName")%></td>
                                    <td><%#Eval("xmmc")%></td>
                                    <td><%#Eval("gcbm")%></td>
                                    <td><%#Eval("gcmc")%> 
                                    </td>
                                    <td><%# PublicModel.getEfileImageToZH(Eval("ghxkz_AttachPath").ToString(),
                                            Eval("ghxkzh").ToString(),"规划许可证") %></td>
                                    <td><%# PublicModel.getEfileImageToZH(Eval("sgxkz_AttachPath").ToString(),
                                            Eval("sgxkzh").ToString(),"施工许可证") %></td>
                                    <td><%#Eval("ChargeUserName")%></td>
                                    <td><%#  PublicModel.getSingleProjectStatusNameByStatus(ConvertEx.ToInt(Eval("Status"))) %>                                              
                                    </td>
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
    <script type="text/javascript">
        jeDate({ dateCell: "#ctl00_Main_kgsj1_TextBox1", format: "YYYY-MM-DD", isTime: false, minDate: "1910-02-01" });
        jeDate({ dateCell: "#ctl00_Main_kgsj2_TextBox1", format: "YYYY-MM-DD", isTime: false, minDate: "1910-02-01" });
        jeDate({ dateCell: "#ctl00_Main_jgsj1_TextBox1", format: "YYYY-MM-DD", isTime: false, minDate: "1910-02-01" });
        jeDate({ dateCell: "#ctl00_Main_jgsj2_TextBox1", format: "YYYY-MM-DD", isTime: false, minDate: "1910-02-01" });
    </script>
</asp:Content>
