<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LookCell.aspx.cs" Inherits="DigiPower.Onlinecol.Standard.Web.File.LookCell" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>浏览施工用表</title>
    <script language="javascript" type="text/javascript">
//    window.onload=function(){
//        var CellWeb1=document.getElementById('CellWeb1');
//        CellWeb1.Login("中信报表", "", "13040409", "5160-0447-0112-5004");
//        CellWeb1.LocalizeControl(2052);      
//        var len=CellWeb1.OpenFile("<%=cellFilePath %>",""); 
//    }

    window.onresize=function(){
        var CellWeb1=document.getElementById('CellWeb1');
        CellWeb1.style.height=document.documentElement.offsetHeight+"px"; 
      //  CellWeb1.style.whith=document.documentElement.offsetWidth+"px";
    }
    </script>

    <script type="text/vbscript" language="vbscript">      
        Sub window_onload                
            CellWeb1.Login "中信报表", "", "13040409", "5160-0447-0112-5004"
            'i12=CellWeb1.Login("芜湖市城建档案管理系统","218.22.66.54","12100101639","6140-1500-0162-3004")
            'msgbox i12
            CellWeb1.LocalizeControl 2052
          
            CellWeb1.OpenFile "<%=cellFilePath %>",""
        End Sub
    </script>

</head>
<body>
    <form id="form1" runat="server">
    </form>
    <object id="CellWeb1" classid="CLSID:3F166327-8030-4881-8BD2-EA25350E574A" codebase="/File/CellWeb5.CAB#Version=5.3.9.14"
        style="width: 97%; height: 600px; margin: 2px 2px; border: solid 1px #8db2e3;
        vertical-align: top;">
    </object>
</body>
</html>
