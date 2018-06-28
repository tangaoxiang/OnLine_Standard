<%@ Control Language="C#" AutoEventWireup="true" EnableTheming="true" CodeBehind="ctrlGridEx.ascx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlGridEx" %>
<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td width="100%">
            <yyc:SmartGridView ID="SmartGridView1" runat='server' SkinID="smartGridviewSkin"
                AutoGenerateColumns="False" OnRowDataBound="SmartGridView1_RowDataBound" Width="100%"
                AllowSorting="True" OnSorting="SmartGridView1_Sorting" AllowPaging="True" OnPageIndexChanging="SmartGridView1_PageIndexChanging"
                OnPreRender="SmartGridView1_PreRender">
                <%--<columns>
        <asp:templatefield>
            <headertemplate>            
                <asp:checkbox id="CheckBox1" runat="server"/>&nbsp;&nbsp;&nbsp;&nbsp;
            </headertemplate>
            <itemtemplate>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:checkbox id="CheckBox2" runat="server" />
                &nbsp;&nbsp;&nbsp;&nbsp;
            </itemtemplate>
        </asp:templatefield>                
        <asp:templatefield>
            <headertemplate>
                操作
            </headertemplate>
            <itemtemplate>                
                <asp:hyperlink id="btnModify" runat="server">编辑</asp:hyperlink>        
            </itemtemplate>
        </asp:templatefield>
        <asp:TemplateField HeaderText="temText">
            <ItemTemplate>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
    </columns>--%>
                <CascadeCheckboxes>
                    <yyc:CascadeCheckbox ParentCheckboxID="box1" ChildCheckboxID="box2" />
                </CascadeCheckboxes>
                <PagerSettings Visible="False" />
                <AlternatingRowStyle BackColor="White" />
                <RowStyle Height="25px" BackColor="#FAFAFA" />
            </yyc:SmartGridView>
        </td>
    </tr>
    <tr>
        <td height="32" valign="bottom" id="tbpage" runat="server" visible="false" class="button_area">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="43%" height="32">
                        &nbsp;&nbsp;&nbsp;&nbsp;共有<strong>
                            <asp:Label ID="lbRecordCount" runat="server" Text="1"></asp:Label>
                        </strong>&nbsp;条记录，当前第<strong>
                            <asp:Label ID="lbCurPage" runat="server" Text="1"></asp:Label></strong> 页，共
                        <strong>
                            <asp:Label ID="lbPageCount" runat="server" Text="1"></asp:Label></strong> 页
                    </td>
                    <td width="57%">
                        <table border="0" align="right" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="40">
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../images/first.gif"
                                        Width="37" Height="15" OnClick="ImageButton1_Click" />
                                </td>
                                <td width="45">
                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="../images/back.gif" Width="43"
                                        Height="15" OnClick="ImageButton2_Click" />
                                </td>
                                <td width="45">
                                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="../images/next.gif" Width="43"
                                        Height="15" OnClick="ImageButton3_Click" />
                                </td>
                                <td width="40">
                                    <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="../images/last.gif" Width="37"
                                        Height="15" OnClick="ImageButton4_Click" />
                                </td>
                                <td width="100">
                                    <div align="center">
                                        <span class="STYLE1">转到第
                                            <asp:TextBox ID="TextBox1" size="4" Style="height: 12px; width: 20px; border: 1px solid #999999;"
                                                EnableViewState="false" runat="server"></asp:TextBox>
                                            页 </span>
                                    </div>
                                </td>
                                <td width="40">
                                    <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="../images/go.gif" Width="37"
                                        Height="15" OnClick="ImageButton5_Click" />
                                </td>
                                <td width="40">
                                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                        <%--<asp:ListItem Selected="True" Value="5">显示5条</asp:ListItem>--%>
                                        <asp:ListItem Selected="True" Value="10">显示10条</asp:ListItem>
                                        <asp:ListItem Value="20">显示20条</asp:ListItem>
                                        <asp:ListItem Value="30">显示30条</asp:ListItem>
                                        <asp:ListItem Value="40">显示40条</asp:ListItem>
                                        <asp:ListItem Value="50">显示50条</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
