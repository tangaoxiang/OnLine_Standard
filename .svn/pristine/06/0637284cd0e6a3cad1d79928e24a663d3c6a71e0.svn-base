<%@ Page Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="MyTaskList.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.MyTaskList" %>

<%@ Register Src="~/CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc1" %>

<%@ Import Namespace="DigiPower.Onlinecol.Standard.Web" %>
<%@ Import Namespace="DigiPower.Onlinecol.Standard.Common" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script language="javascript" type="text/javascript">
        function getNewUrl() {
            var url = window.location.href;
            url = Common.urlreplace(url, 'Main_gcmc', escape($('#ctl00_Main_gcmc_TextBox1').val()));
            url = Common.urlreplace(url, 'Main_gcbm', escape($('#ctl00_Main_gcbm_TextBox1').val()));
            url = Common.urlreplace(url, 'PageIndex', $('#CurrentPageIndex').text());
            url = Common.urlreplace(url, 'rn', Math.random());
            return url;
        }

        //查看工程信息
        function btnLookSingle() {
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                var height = "100%";
                if (screen.height >= 900) height = "680px";
                window.top.parent.ParentOpenDiv('工程[' + keyList[5] + ']信息-预览', '../CompanyManage/CompanyReg3_' +
                    Common.getFileTypeForProjectType(keyList[4]) + 'Edit.aspx?action=' + PageState.View + '&SingleProjectID=' +
                    keyList[0] + '&rn=' + Math.random() + '&ProjectType=' + keyList[4], '900px', height);
            }
        }
        function BtnSubmit() {//提交
            if (Common.isRadioCheck()) {
                layer.confirm('确定提交工程到下一环节吗？', function () {
                    var keyList = Common.getRadioKeyToArray();
                    var recv = MyTaskList.CheckRecvStatus(keyList[0], keyList[1]).value;
                    if (!recv) {
                        Common.fnLayerAlert("请先进行业务操作后才能提交工程!");
                    } else {
                        var iSignaturePdf = Number(<%= SystemSet._ISIGNATUREPDF%>);
                        var nowWorkFlowID = $("#HidworkFlowID").val();
                        var fileregWorkFlowID = <%=PublicModel.getWorkFlowIdByWorkFlowCode(SystemSet.EumWorkFlowCode.FILEREG.ToString())%>;
                        if(iSignaturePdf==1 && nowWorkFlowID==fileregWorkFlowID){
                            var len=MyTaskList.FileCheckBySignatureFinish(keyList[0]).value; 
                            if(len!="0"){//全部签章未完成                                 
                                layer.confirm(Common.getRedStrongString('有文件签章未完成,确定提交工程到下一环节吗？'), function () {
                                    window.parent.location.href = "../ReportPDFDown.aspx?pdfFileName=" + len;
                                    SubMitProject(keyList[0], keyList[1], keyList[3]);
                                });
                            }else{
                                SubMitProject(keyList[0], keyList[1], keyList[3]); 
                            }
                        }else{
                            SubMitProject(keyList[0], keyList[1], keyList[3]);
                        }
                    }
                });
            }
        }

        function SubMitProject(singleProjectID, workFlowID, workFlowDefineID){
            var len = MyTaskList.SubMitProject(singleProjectID, workFlowID, workFlowDefineID).value;
            if (len == ResultState.Success) {
                layer.alert("已提交到下一流程!", { btnAlign: 'c' }, function (index) {
                    layer.close(index);
                    window.location.href = getNewUrl();
                });
            } else {
                alert(len);
            }
        }

        //默认受理,第一次受理后,第二次就不受理了
        function defaultAccept(key0, key1, key3) {
            if (!MyTaskList.CheckRecvStatus(key0, key1).value) {
                MyTaskList.AcceptProject(key0, key3).value;
            }
        }
        function BtnRollBack() {//退回
            if (Common.isRadioCheck()) {
                layer.confirm('确定将工程退回到上一环节吗？', function () {
                    var keyList = Common.getRadioKeyToArray();
                    defaultAccept(keyList[0], keyList[1], keyList[3]);
                    var len = MyTaskList.ReturnProject(keyList[0], keyList[6]).value;
                    if (len == ResultState.Success) {
                        window.location.href = getNewUrl();
                    } else {
                        Common.fnLayerAlert("退回失败，请检查数据！");
                    }
                });
            }
        }
        //报建确认
        function BtnRwfp() {
            if (Common.isRadioCheck()) {
                var keyList = Common.getRadioKeyToArray();
                defaultAccept(keyList[0], keyList[1], keyList[3]);
                var url = "../WorkFlow/rwfp.aspx?SingleProjectID=" + keyList[0]
                        + "&WorkFlowID=" + keyList[1] + "&rn=" + Math.random();
                Common.fnLayerOpen('工程报建确认', '100%', '100%', url, true, "");
            }
        }
        //文件登记
        function BtnWjdj() {
            if (Common.isRadioCheck()) {
                window.top.parent.closeMenu();
                var keyList = Common.getRadioKeyToArray();
                defaultAccept(keyList[0], keyList[1], keyList[3]);
                var url = "../WorkFlow/wjdj.aspx?SingleProjectID=" + keyList[0] + "&WorkFlowID=" +
                    keyList[1] + "&ModelBH=<%=workFlowCode%>&rn=" + Math.random();
                Common.fnLayerOpen(false, "100%", "100%", url, true, "");
            }
        }
        //在线预验收
        function BtnZxyys() {
            if (Common.isRadioCheck()) {
                window.top.parent.closeMenu();
                var keyList = Common.getRadioKeyToArray();
                defaultAccept(keyList[0], keyList[1], keyList[3]);
                var url = "../WorkFlow/zxyys.aspx?SingleProjectID=" + keyList[0] + "&WorkFlowID=" +
                    keyList[1] + "&ModelBH=<%=workFlowCode%>&rn=" + Math.random();
                Common.fnLayerOpen(false, "100%", "100%", url, true, "");
            }
        }
        //接收整理
        function BtnJszl() {
            if (Common.isRadioCheck()) {
                window.top.parent.closeMenu();
                var keyList = Common.getRadioKeyToArray();
                defaultAccept(keyList[0], keyList[1], keyList[3]);
                var url = "../WorkFlow/ZJList.aspx?SingleProjectID=" + keyList[0] + "&WorkFlowID=" +
                    keyList[1] + "&ModelBH=<%=workFlowCode%>&ProjectType=" + keyList[4] + "&rn=" + Math.random();
                Common.fnLayerOpen(false, "100%", "100%", url, true, "");
            }
        }
        //窗口接收-移交入库
        function BtnIsArchiveUserClick() {
            if (Common.isRadioCheck()) {
                window.top.parent.closeMenu();
                var keyList = Common.getRadioKeyToArray();
                defaultAccept(keyList[0], keyList[1], keyList[3]);
                var url = "../WorkFlow/WFArchiveList.aspx?SingleProjectID=" + keyList[0] + "&WorkFlowID=" +
                            keyList[1] + "&WorkFlowCode=" + keyList[6] + "&ModelBH=<%=workFlowCode%>&rn=" + Math.random();
                Common.fnLayerOpen(false, "100%", "100%", url, true, "");
            }
        }
        //工程外观图管理
        function BtnImageManage() {
            if (Common.isRadioCheck()) {
                window.top.parent.closeMenu();
                var keyList = Common.getRadioKeyToArray();
                defaultAccept(keyList[0], keyList[1], keyList[3]);
                var url = "../WorkFlow/ImageWjdj.aspx?SingleProjectID=" + keyList[0] + "&action=" + PageState.Add + "&rn=" + Math.random();
                Common.fnLayerOpen(false, "100%", "100%", url, true, "");
            }
        }
        //工程外观图预览
        function BtnImageView() {
            if (Common.isRadioCheck()) {
                window.top.parent.closeMenu();
                var keyList = Common.getRadioKeyToArray();
                var url = "../WorkFlow/ImageWjdj.aspx?SingleProjectID=" + keyList[0] + "&action=" + PageState.View + "&rn=" + Math.random();
                Common.fnLayerOpen(false, "100%", "100%", url, true, "");
            }
        }
        //工程外观图审核
        function BtnImageCheck() {
            if (Common.isRadioCheck()) {
                window.top.parent.closeMenu();
                var keyList = Common.getRadioKeyToArray();
                defaultAccept(keyList[0], keyList[1], keyList[3]);
                var url = "../WorkFlow/ImageWjdj.aspx?SingleProjectID=" + keyList[0] + "&action=" + PageState.Check + "&rn=" + Math.random();
                Common.fnLayerOpen(false, "100%", "100%", url, true, "");
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <input type="hidden" id="hidOpenFlag" />
    <input type="hidden" id="HidworkFlowID" value="<%=workFlowID %>" />
    <input type="hidden" id="HidworkFlowCode" value="<%=workFlowCode %>" />

    <div class="main-content">
        <div class="content-box-search">
            <table id="c1">
                <tr>
                    <td class="condition">工程名称：</td>
                    <td class="c2">
                        <uc1:ctrlTextBoxEx runat="server" ID="gcmc" MaxLength="20" />
                    </td>
                    <td class="condition">工程编号：</td>
                    <td class="c2">
                        <uc1:ctrlTextBoxEx runat="server" ID="gcbm" MaxLength="20" />
                    </td>
                    <td class="ss" style="text-align: left; width: 170px">
                        <asp:Button ID="btnSearch" runat="server" Text=" 查询 " OnClick="btnSearch_Click" />
                        <input type="button" value="重 置" id="btnSearchParRet" />
                    </td>

                    <td class="c2"></td>
                    <td class="ss"></td>
                </tr>
            </table>
        </div>
        <div class="ss"></div>
        <div class="content-box-content">
            <div class="tab-content default-tab" id="tab1">
                <div class="anl" id="anlButtonList">
                    <input type="button" id="MrcBtnLookSingle" title="工程详细信息" onclick="btnLookSingle()" value="工程信息" />
                    <input type="button" id="MrcBtnSubmit" title=" 提交 " onclick="BtnSubmit()" value="提交" />
                    <input type="button" id="MrcBtnAccept" title="受理" onclick=" BtnAccept()" value="受理" />
                    <input type="button" id="MrcBtnRollBack" title="退回" onclick=" BtnRollBack()" value="退回" />

                    <input type="button" id="MrcBtnRwfp" title="报建确认" onclick=" BtnRwfp()" value="报建确认" />
                    <input type="button" id="MrcBtnWjdj" title="文件登记" onclick="BtnWjdj()" value="文件登记" />
                    <input type="button" id="MrcBtnImageManage" title="工程外观图管理" onclick="BtnImageManage()" value="工程外观图管理" />

                    <input type="button" id="MrcBtnZxyys" title="在线预验收" onclick="BtnZxyys()" value="在线预验收" />
                    <input type="button" id="MrcBtnJszl" title="接收整理" onclick="BtnJszl()" value="接收整理" />
                    <input type="button" id="MrcBtnCkjs" title="窗口接收" onclick="BtnIsArchiveUserClick()" value="窗口接收" />
                    <input type="button" id="MrcBtnYwsh" title="业务审核" onclick="BtnIsArchiveUserClick()" value="业务审核" />
                    <input type="button" id="MrcBtnShqd" title="审核确定" onclick="BtnIsArchiveUserClick()" value="审核确定" />
                    <input type="button" id="MrcBtnYjrk" title="归档移交" onclick="BtnIsArchiveUserClick()" value="归档移交" />
                    <input type="button" id="MrcBtnImageView" title="工程外观图预览" onclick="BtnImageView()" value="工程外观图预览" />
                    <input type="button" id="MrcBtnImageCheck" title="工程外观图审核" onclick="BtnImageCheck()" value="工程外观图审核" />

                </div>
                <table>
                    <thead>
                        <tr>
                            <th width="20px"></th>
                            <th width="90px">项目类型</th>
                            <th width="70px">工程编号</th>
                            <th>工程名称</th>
                            <th width="150px">规划许可证号</th>
                            <th width="150px">施工许可证号</th>
                            <th width="60px">处理状态</th>
                            <th width="70px">处理时间</th>
                            <%=String.Compare(workFlowCode,
                                DigiPower.Onlinecol.Standard.Web.SystemSet.EumWorkFlowCode.IMPORT_TO.ToString())==0?"<th width=\"55px\">工程状态</th>":""%>
                        </tr>
                    </thead>
                    <tbody class="tbody" id="bodyRepeater">
                        <asp:Repeater ID="rpData" runat="server">
                            <ItemTemplate>
                                <tr class='<%#(Container.ItemIndex%2==0)?"bg01":""%>'>
                                    <td>
                                        <input type="radio" name="radio" value='<%# Eval("SingleProjectID")%>,<%= workFlowID.Trim()%>,<%# Eval("SubmitStatus")%>,<%#Eval("WorkFlowDefineID")%>,<%# Eval("ProjectType")%>,<%# Eval("gcbm")%>,<%= workFlowCode.Trim()%>' />
                                    </td>
                                    <td><%#Eval("ProjectTypeName")%></td>
                                    <td><%#Eval("gcbm")%></td>
                                    <td><%#Eval("gcmc")%></td>
                                    <td><%#Eval("ghxkzh")%></td>
                                    <td><%#Eval("sgxkzh")%></td>
                                    <td><%# DigiPower.Onlinecol.Standard.Web.PublicModel.GetImageforStatus(DigiPower.Onlinecol.Standard.Common.ConvertEx.ToBool(Eval("SubmitStatus")))%></td>
                                    <td><%# Eval("SubmitStatus").ToString()!="2"?"":DigiPower.Onlinecol.Standard.Common.ConvertEx.ToDate(Eval("RecvDateTime").ToString()).ToString("yyyy-MM-dd")%></td>

                                    <%#String.Compare(workFlowCode,
                                            DigiPower.Onlinecol.Standard.Web.SystemSet.EumWorkFlowCode.IMPORT_TO.ToString())==0? 
                                            "<td>"+DigiPower.Onlinecol.Standard.Web.PublicModel.getSingleProjectStatusNameByStatus(
                                            DigiPower.Onlinecol.Standard.Common.ConvertEx.ToInt(Eval("Status")))+"</td>":""%>
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
