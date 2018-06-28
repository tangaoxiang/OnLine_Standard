<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="celltest.aspx.cs" Inherits="DigiPower.Onlinecol.Standard.Web.SystemManage.celltest" Title="无标题页" %>
<HTML>
<HEAD>
<TITLE>单元格控件</TITLE>
<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
<meta name="CODE_LANGUAGE" Content="C#">
<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">

<script language=vbscript>
Sub window_onload
 CellWeb1.InsertSheet 1,1
 CellWeb1.OpenFile "E:\CellTest\aa\jsdemo\file\订单运费表.cll",""
 CellWeb1.MoveToCell 2,2 
 CellWeb1.SetColHidden  0,0
 CellWeb1.SetRowHidden 0,0
End sub
</script>
</HEAD>


<body id=bd topmargin="0">
<OBJECT id=CellWeb1 height=500 width=700 classid=clsid:3F166327-8030-4881-8BD2-EA25350E574A VIEWASTEXT>
	<PARAM NAME="_Version" VALUE="65536">
	<PARAM NAME="_ExtentX" VALUE="14182">
	<PARAM NAME="_ExtentY" VALUE="7197">
	<PARAM NAME="_StockProps" VALUE="0">
</OBJECT>
</body>
</HTML>

