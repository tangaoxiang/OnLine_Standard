<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlCell.ascx.cs" Inherits="DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlCell" %>
<script language=vbscript>
Sub window_onload
 CellWeb2.InsertSheet 1,1
 CellWeb2.OpenFile "E:\CellTest\aa\jsdemo\file\订单运费表.cll",""
 CellWeb2.MoveToCell 2,2 
 CellWeb2.SetColHidden  0,0
 CellWeb2.SetRowHidden 0,0
End sub

Sub Save()
CellWeb2.SaveAsFile "E:\CellTest\aa\jsdemo\file\订单运费表1.cll",true
End sub
</script>

<table>
    <tr>
        <td>
            <object id="CellWeb2" height="280" width="700" classid="clsid:3F166327-8030-4881-8BD2-EA25350E574A">
	        <param name="_Version" value="65536"/>
	        <param name="_ExtentX" value="18521"/>
	        <param name="_ExtentY" value="7408"/>
	        <param name="_StockProps" value="0"/>
            </object>
        </td>
    </tr>
</table>
