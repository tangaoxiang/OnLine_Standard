﻿<%@ Page Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true"
    CodeBehind="SignatureFilesList.aspx.cs" Inherits="DigiPower.Onlinecol.Standard.Web.iSignature.SignatureFilesList"
    Title="电子文件签章" %>

<%@ Register Src="../CommonCtrl/ctrlGridEx.ascx" TagName="ctrlGridEx" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="JS/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="JS/json2-min.js"></script>
    <script type="text/javascript" src="JS/signature.js"></script>
    <style type="text/css">
        .regedit_input {
            /*border-radius: 4px;*/
            padding: 0px !important;
            font-size: 13px !important;
            border: 1px solid #D5D5D5 !important;
            color: #333 !important;
            height: 17px;
        }

        a {
            cursor: pointer;
        }
    </style>
    <script type="text/javascript">
        //工程ID
        function GetSingleProjectID() {
            return $('[id$=SingleProjectID]').val();
        }

        var selFlag = true;
        function selectALL() {
            $("input[type='checkbox']").each(function () {
                if ($(this).attr('disabled') != 'disabled') {
                    $(this).attr('checked', selFlag);
                }
            });
            selFlag = !selFlag;
        }


        //查看电子文件 
        function lookPDF(IsFolder, bh, filelistID) {
            var id = GetSingleProjectID();
            if (IsFolder == 0) {
                if (SignatureFilesList.CheckPdfFileExistsForFileListID(Number(filelistID)).value) {
                    var strURL = "../File/DocumentEdit.aspx?ID=" + filelistID + "&SingleProjectID=" + GetSingleProjectID();
                    window.top.Content.CreateTitle('文件编号[' + bh + ']查看电子文件', 3, strURL);
                } else {
                    alert("电子文件在磁盘上不存在!");
                }
            }
        }

        //签章
        function signaturePDF(IsFolder, bh, filelistID) {
            if (IsFolder == 0) {
                var strURL = "../iSignature/SignaturePdf.aspx?ID=" + filelistID + "&SingleProjectID=" + GetSingleProjectID();
                window.top.Content.CreateTitle('文件编号[' + bh + ']电子文件签章', 3, strURL);
            }

        }

        //重置
        function resetPDF(IsFolder, IsSignature, fileListID) {
            var len = SignatureFilesList.SignatureResetFlag(fileListID).value;
            if (len != 'success')
                alert(len);
            else {
                alert('重置成功！');
                window.location.reload();
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="SingleProjectID" runat="server" />
    <asp:HiddenField ID="companyID" runat="server" />
    <asp:HiddenField ID="projecttype" runat="server" />
    <table width="99%" border="0" cellpadding="0" cellspacing="0" style="margin: 4px 4px; border: solid 1px #8db2e3;">
        <tr>
            <td height="25" class="button_area" style="border: 0px; border-bottom: 1px;">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="margin-top: 2px;">
                    <tr>
                        <td align="right" style="text-align: right;">
                            <asp:Button ID="btnSignature" runat="server" CssClass="button" OnClick="btnSignature_Click"
                                Text="批量签章" />
                            <asp:Button ID="btnReset" runat="server" CssClass="button" OnClick="btnReset_Click"
                                Text="批量重置" />
                        </td>
                        <td width="10px">&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="text-align: center;">
                <div style="margin-top: 4px; margin-bottom: 4px; border: 0; width: 100%;" id="divgvData">
                    <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvData_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="<a style='cursor:pointer;' onclick='selectALL()'>全选</a>"
                                HeaderStyle-CssClass="tr1" ItemStyle-CssClass="tr1" HeaderStyle-Width="33px" ItemStyle-Width="33px">
                                <ItemTemplate>
                                    <input style="border-bottom-color: blue;" type="checkbox"
                                        name="checkOne" value='<%# Eval("FileListID")%>,<%# Eval("IsFolder")%>,<%# Eval("recID")%>,<%# Eval("PID")%>,<%# Eval("DefaultCompanyType")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="编号" DataField="bh" HeaderStyle-Width="60px" ItemStyle-Width="60px" />
                            <asp:BoundField HeaderText="文件题名" DataField="title" />
                            <asp:BoundField HeaderText="责任者" DataField="zrr" HeaderStyle-Width="200px" ItemStyle-Width="200px" />
                            <asp:BoundField HeaderText="文(图)号" DataField="w_t_h" HeaderStyle-Width="60px" ItemStyle-Width="60px" />
                            <asp:TemplateField HeaderText="实体页数" HeaderStyle-Width="50px" ItemStyle-Width="50px" />
                            <asp:TemplateField HeaderText="PDF" HeaderStyle-Width="50px" ItemStyle-Width="50px"
                                ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <%# DigiPower.Onlinecol.Standard.Web.PublicModel.GetImageforStatus(DigiPower.Onlinecol.Standard.Common.ConvertEx.ToBool(Eval("CONVERT_FLAG")),true)%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="转换日期" HeaderStyle-Width="80px">
                                <ItemTemplate>
                                    <%# DigiPower.Onlinecol.Standard.Common.ConvertEx.ToDate(Eval("CONVERT_DT").ToString()).ToString("yyyy-MM-dd")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="已签章" HeaderStyle-Width="50px" ItemStyle-Width="50px">
                                <ItemTemplate>
                                    <%# DigiPower.Onlinecol.Standard.Web.PublicModel.GetImageforStatus(DigiPower.Onlinecol.Standard.Common.ConvertEx.ToBool(Eval("SIGNATURE_FLAG")),true)%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="签章日期" HeaderStyle-Width="80px">
                                <ItemTemplate>
                                    <%# DigiPower.Onlinecol.Standard.Common.ConvertEx.ToDate(Eval("SIGNATURE_DT").ToString()).ToString("yyyy-MM-dd")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作" HeaderStyle-Width="80px" ItemStyle-Width="80px">
                                <ItemTemplate>
                                    <a onclick="lookPDF(<%# DigiPower.Onlinecol.Standard.Common.ConvertEx.ToInt(Eval("IsFolder"))%>,'<%# Eval("bh")%>',<%# Eval("FileListID")%>)"
                                        <%# SetTextDisabled(Eval("IsFolder"))%>>查看</a>
                                    <a onclick="signaturePDF(<%# DigiPower.Onlinecol.Standard.Common.ConvertEx.ToInt(Eval("IsFolder"))%>,'<%# Eval("bh")%>',<%# Eval("FileListID")%>)"
                                        <%# SetTextDisabled(Eval("IsFolder"))%>>签章</a>
                                    <a onclick="resetPDF(<%# DigiPower.Onlinecol.Standard.Common.ConvertEx.ToInt(Eval("IsFolder"))%>,
                                        '<%# DigiPower.Onlinecol.Standard.Common.ConvertEx.ToInt(Eval("SIGNATURE_FLAG"))%>',<%# Eval("FileListID")%>)"
                                        <%# SetTextDisabledSign(Eval("SIGNATURE_FLAG"))%>>重置</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td style="text-align: center; height: 30px; border: 0px;" class="button_area">
                <webdiyer:AspNetPager ID="AspNetPager" runat="server" PagingButtonSpacing="8px"
                    OnPageChanged="AspNetPager_PageChanged" ShowCustomInfoSection="left"
                    CustomInfoStyle="text-align:left;" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页"
                    PrevPageText="上一页" PageIndexBoxStyle="text-align:right;"
                    CustomInfoHTML="共有 <strong>%RecordCount%</strong> 条记录，当前第 <strong>%CurrentPageIndex%</strong> 页，共<strong> %PageCount%</strong> 页"
                    UrlPaging="false" Width="100%" layouttype="Table" ShowNavigationToolTip="True"
                    ShowPageIndex="False" HorizontalAlign="Right" PageIndexBoxType="TextBox"
                    ShowPageIndexBox="Always" SubmitButtonText="跳转" TextAfterPageIndexBox="页"
                    TextBeforePageIndexBox="转到">
                </webdiyer:AspNetPager>
            </td>
        </tr>
    </table>
    <object id="CryptAPICtrl" classid="clsid:BCE5CCE5-959F-4DC0-BCF3-6C2916D48AA2" codebase="KG_Crypt_COM_API.dll#version=1,0,0,1" style="display: none;"></object>
    <object id="SMObj" width="0" style="display: none;" height="0" classid="clsid:E5C44C76-610A-4C1F-9083-6CE933E3DC1D"></object>
</asp:Content>
