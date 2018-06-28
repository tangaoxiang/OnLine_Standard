<%@ Page Language="C#" MasterPageFile="~/SiteSon.Master" AutoEventWireup="true" CodeBehind="ArchiveListProView.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.CompanyManage.ArchiveListProView" Title="档案跟踪-图表" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Head" runat="server">
    <link href="../Javascript/Layer/layui/css/layui.css" media="all" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Main" runat="server">
    <asp:Literal ID="ltHTML" runat="server"></asp:Literal>  
    <script src="../Javascript/Layer/layui/layui.js" type="text/javascript" charset="utf-8"></script>
    <script type="text/javascript">
        layui.use('element', function () {
            var $ = layui.jquery
            , element = layui.element(); //Tab的切换功能，切换事件监听等，需要依赖element模块          
            var active = {     //触发事件
                setPercent: function () {
                    //设置50%进度
                    element.progress('demo', '50%')
                }
              , loading: function (othis) {
                  var DISABLED = 'layui-btn-disabled';
                  if (othis.hasClass(DISABLED)) return;

                  //模拟loading
                  var n = 0, timer = setInterval(function () {
                      n = n + Math.random() * 10 | 0;
                      if (n > 100) {
                          n = 100;
                          clearInterval(timer);
                          othis.removeClass(DISABLED);
                      }
                      layui.element().progress('demo', n + '%');
                  }, 300 + Math.random() * 1000);

                  othis.addClass(DISABLED);
              }
            };
        });
    </script>
</asp:Content>
