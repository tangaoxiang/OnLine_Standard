<%@ Page Title="外协单位文件类别选择" Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true" CodeBehind="OutHelpCompanyFileTmpAdd.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.OutHelpCompanyFileTmpAdd" %>

<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <style type="text/css">
        .zpxxxj {
            width: 100% !important;
        }

        #tableList tr td {
            padding: 2px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <table class="zpxxxj" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="lljzc">
                <input type="button" id="btnSave" value=" 选择 " onclick="saveSubmit()" />
                <input type="button" id="btngoBack" value=" 返回 " onclick="Common.fnParentLayerClose()" />
            </td>
        </tr>
    </table>
    <div class="main-content">
        <div class="content-box-content">
            <div class="tab-content default-tab" id="tab1">
                <table id="tableList">
                    <thead>
                        <tr>
                            <th width="30px" style="cursor: pointer;" onclick="Common.selCheckBoxAll(this)" selall="0">全选</th>
                            <th>文件类别</th>
                        </tr>
                    </thead>
                    <tbody class="tbody" id="bodyRepeater">
                        <asp:Repeater ID="gvSignature" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <input type="checkbox" name="checkOne" value="<%# Eval("bh")%>" />
                                    </td>
                                    <td>
                                        <%# Eval("bh")%>-<%# Eval("Title")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>


    <script language="javascript" type="text/javascript">
        function saveSubmit() {
            if (Common.isCheckBoxMoreChecked()) {
                var strBH = Common.getChkMoreKeyListToString(0);
                var index = parent.layer.getFrameIndex(window.name);
                parent.document.getElementById('ctl00_Main_txtFileList_TextBox1').value = strBH;    
                parent.layer.close(index);
            }
        }
    </script>
    <br />
</asp:Content>
