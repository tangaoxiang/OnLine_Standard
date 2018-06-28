<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignaturePdf.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.SignaturePdf" %>

<%@ Import Namespace="DigiPower.Onlinecol.Standard.Web" %>
<%@ Import Namespace="DigiPower.Onlinecol.Standard.Common" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/Javascript/Layer/css/common.css" media="screen" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JS/jquery-1.11.2.min.js"></script>
    <script src="/Javascript/Common/Fn.js" type="text/javascript"></script>
    <script src="/Javascript/Layer/layer/layer.js" type="text/javascript"></script>
    <script type="text/javascript" src="JS/signature.js"></script>
    <script type="text/javascript">
        var ResultState = new Object();
        ResultState.Success = 'success';
        ResultState.Failure = 'failure';
     
        var url = '<%=mServerUrl%>';
        var id = '<%=ID%>';       
 
        $(function () {
            for (var i = 1; i < iWebPDF2015.CommandBars.Count; i++) {
                iWebPDF2015.CommandBars.Item(i).Visible = false;
            }
            iWebPDF2015.CommandBars.Item("DigitalSignature").Visible = true;
            iWebPDF2015.Options.TabBarVisible = false;
            WebOpen(id);
        });     
        function save() {
            iWebPDF2015Hide();
            if(!SignaturePdf.CheckSignatureFinishCount(<%=ID%>,<%= DNTRequest.GetQueryString("recID")%>).value){
                if (typeof (id) != "undefined") {        
                    var st=saveFile(id);                 
                    if(st.indexOf(ResultState.Success)>-1){
                        Common.fnLayerAlertAndCallBack('签章文档保存成功！',iWebPDF2015Show);
                        var len=SignaturePdf.AddSignatureLog('<%= DNTRequest.GetQueryString("SignatureType")%>',<%=ID%>,<%=singleProjectID%>, <%= DNTRequest.GetQueryString("recID")%>).value;             
                    }else{
                        Common.fnLayerAlertAndCallBack('签章文档保存失败！',iWebPDF2015Show);
                    }       
                }
            }else {
                Common.fnLayerAlertAndCallBack('该份文件已经签章完成,不能再签章!',iWebPDF2015Show);
            }
        }
        function finish(){            
            if(!SignaturePdf.CheckSignatureFinishCount(<%=ID%>,<%= DNTRequest.GetQueryString("recID")%>).value){
                if (typeof (id) != "undefined") {        
                    var st=saveFile(id);                                                                         
                }
            }                                                        
            iWebPDF2015Hide();  
            layer.confirm("确定要设置选中的文件为签章完成状态?<br/>"+Common.getRedStrongString("前提条件:<br/>1:文件没有签章完成<br/>2:完成已签过章"),function() {
                var len=SignaturePdf.SignatureFinish('<%= DNTRequest.GetQueryString("SignatureType")%>',<%=ID%>,<%= singleProjectID%>, <%= DNTRequest.GetQueryString("recID")%>).value;              
                if(len.indexOf(ResultState.Success)>-1) {
                    Common.fnLayerAlertAndCallBack('签章完成!',iWebPDF2015Show);             
                }else{
                    Common.fnLayerAlertAndCallBack('签章完成失败,原因:'+Common.getRedStrongString('您已经对该文件签章完成或您还没有签过章'),iWebPDF2015Show);  
                } 
            });
        }
        function iWebPDF2015Show(){
            $("#iWebPDF2015").show();
        }
        function iWebPDF2015Hide(){   
            $("#iWebPDF2015").hide();
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    </form>
    <table class="zpxxxj" style="width: 99%;" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="lljzc">                  
                <input type="button" value=" 签章保存 " onclick="save()" />
                <input type="button" value=" 签章完成 " onclick="finish()" />
                <input type="button" id="btngoBack" value=" 关闭 " onclick="Common.fnParentLayerClose()" />
            </td>
        </tr>
    </table>
    <object id="iWebPDF2015" style="width: 100%; height: 100%;"
        classid="CLSID:7017318C-BC50-4DAF-9E4A-10AC8364C315">
    </object>
    <script language="javascript" type="text/javascript">
        $("#iWebPDF2015").css("height", $(this).height() - 40 + "px");
    </script>
</body>
</html>
