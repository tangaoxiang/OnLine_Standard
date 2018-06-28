<%@ Page Title="证书相关信息填写" Language="C#" MasterPageFile="~/SiteParent.Master" AutoEventWireup="true"
    CodeBehind="SubmittedInfo.aspx.cs" Inherits="DigiPower.Onlinecol.Standard.Web.WorkFlow.SubmittedInfo" %>


<%@ Register Src="../CommonCtrl/ctrlTextBoxEx.ascx" TagName="ctrlTextBoxEx" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <style type="text/css">
        .sour {
            width: 230px !important;
        }

        .sour2 {
            width: 210px !important;
        }

        .sour3 {
            font-weight: 700;
        }

        .mc {
            width: 160px !important;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <table id="Table1" runat="server" class="xzll" cellpadding="0" border="0">
        <tr>
            <td colspan="2" style="height: 10px;"></td>
        </tr>

        <tr>
            <td class="mc">
                <asp:Literal ID="ltReadyCheckBookCode" runat="server" Text=""></asp:Literal></td>
            <td class="sr">
                <uc3:ctrlTextBoxEx ID="ReadyCheckBookCode" runat="server"
                    canEmpty="false" CssClass="sour sour3" MaxLength="20" />
            </td>
        </tr>
        <tr>
            <td class="mc">建设单位项目负责人:
            </td>
            <td class="sr">
                <uc3:ctrlTextBoxEx ID="jsdwfzr_Name" runat="server" labelTitle="建设单位项目负责人"
                    canEmpty="false" MaxLength="10" CssClass="sour" />
            </td>
        </tr>
        <tr>
            <td class="mc">项目负责人电话: 
            </td>
            <td class="sr">
                <uc3:ctrlTextBoxEx ID="jsdwfzr_Tel" labelTitle="建设单位项目负责人电话"
                    canEmpty="false" runat="server" CssClass="sour" MaxLength="20" />
            </td>
        </tr>
        <tr>
            <td class="mc">档案员: 
            </td>
            <td class="sr">
                <uc3:ctrlTextBoxEx ID="ArchiveUserName" canEmpty="false" labelTitle="档案员"
                    runat="server" CssClass="sour" MaxLength="20" />
            </td>
        </tr>
        <tr>
            <td class="mc">档案员电话: 
            </td>
            <td class="sr">
                <uc3:ctrlTextBoxEx ID="ArchiveUser_Tel" canEmpty="false" labelTitle="档案员电话"
                    MaxLength="20" runat="server" CssClass="sour" />
            </td>
        </tr>
        <tr>
            <td class="mc">报送单位: 
            </td>
            <td class="sr">
                <uc3:ctrlTextBoxEx ID="jsdw" runat="server" labelTitle="报送单位"
                    CssClass="sour" enabled="false" />
            </td>
        </tr>
        <tr>
            <td class="mc">建设工程档案总数:
            </td>
            <td class="sr">
                <uc3:ctrlTextBoxEx ID="txtTotalScroll" canEmpty="false" labelTitle="建设工程档案总数"
                    CssClass="sour2" MaxLength="5" mode="Int" runat="server" />
                卷(盒)
            </td>
        </tr>
        <tr>
            <td class="mc">文字材料:
            </td>
            <td class="sr">
                <uc3:ctrlTextBoxEx ID="txtCharacterScroll" canEmpty="false" CssClass="sour2" MaxLength="5"
                    mode="Int" runat="server" labelTitle="文字材料卷数" />
                卷                          
            </td>
        </tr>
        <tr>
            <td class="mc">图   纸:
            </td>
            <td class="sr">
                <uc3:ctrlTextBoxEx ID="txtPicScroll" canEmpty="false" CssClass="sour2" MaxLength="5"
                    mode="Int" runat="server" labelTitle="图纸卷数" />
                卷                         
            </td>
        </tr>
        <tr>
            <td class="mc">照   片:</td>
            <td class="sr">
                <uc3:ctrlTextBoxEx ID="txtPhotoPageCount" canEmpty="false" CssClass="sour2" MaxLength="5"
                    mode="Int" runat="server" labelTitle="照片张数" />
                张</td>
        </tr>
        <tr>
            <td class="mc">录像带: 
            </td>
            <td class="sr">
                <uc3:ctrlTextBoxEx ID="txtRadioCount" canEmpty="false" CssClass="sour2" MaxLength="5"
                    mode="Int" runat="server" labelTitle="录像带盒数" />
                盒                             
            </td>
        </tr>
        <tr>
            <td class="mc">其他材料:
            </td>
            <td class="sr">
                <uc3:ctrlTextBoxEx ID="txtOtherMaterial" canEmpty="false" CssClass="sour2" MaxLength="100"
                    runat="server" labelTitle="其他材料" />
            </td>
        </tr>
        <tr>
            <td class="mc">工程档案移交目录: 
            </td>
            <td class="sr">
                <uc3:ctrlTextBoxEx ID="txtDirectoryScroll" canEmpty="false" width="70px" MaxLength="5"
                    mode="Int" runat="server" labelTitle="工程档案移交目录份数" />
                份，共
                <uc3:ctrlTextBoxEx ID="txtDirectoryPage" canEmpty="false" width="76px" MaxLength="5"
                    mode="Int" runat="server" labelTitle="工程档案移交目录张数" />
                张
            </td>
        </tr>
    </table>
    <table class="xzll" cellpadding="0" border="0">
        <tr>
            <td colspan="2" class="ljzc" style="height: 45px;">
                <asp:Button ID="Button1" runat="server" Text=" 保存 "
                    OnClientClick="return saveSubmit(this);" clickflag="ok" CssClass="btn2" OnClick="btnSave_Click" />
                <input type="button" id="btngoBack" value=" 返回 " onclick="Common.fnParentLayerClose()" />
            </td>
        </tr>
    </table>
    <script language="javascript" type="text/javascript">
        function saveSubmit(obj) {
            var flag = true;
            $("input[type='text']").each(function () {
                flag = Common.Validate($(this).attr("id"));
                if (!flag)
                    return false;
            });
            if (!flag) {
                return false;
            }
            return Common.mouseClick(obj)
        }
    </script>
</asp:Content>
