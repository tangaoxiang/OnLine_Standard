<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CellEdit.aspx.cs" Inherits="DigiPower.Onlinecol.Standard.Web.File.CellEdit" %>

<%@ Register src="../CommonCtrl/ctrlBtnBack.ascx" tagname="ctrlBtnBack" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>施工用表</title>
    <link href="/css/default.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="/css/default2.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="/css/table.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="/css/form.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="/css/button.css" media="screen" rel="stylesheet" type="text/css" />

    <script type="text/vbscript" language="vbscript">
      
        Sub window_onload        
        
        CellWeb1.Login "中信报表", "", "13040409", "5160-0447-0112-5004"
        'i12=CellWeb1.Login("芜湖市城建档案管理系统","218.22.66.54","12100101639","6140-1500-0162-3004")
        'msgbox i12
        CellWeb1.LocalizeControl 2052
      
        CellWeb1.OpenFile "<%=cellFilePath %>",""
        
        'CellWeb1.OpenFile "E:\Web_WuHuProjNew2\DigiPower.Onlinecol.Standard.Web\Upload\CellTmp\t1.cll",""
                       
        Set xml=CreateObject("Microsoft.XMLHTTP") 
        dim i1,j1,k1,n2,strNode,URL,returnValue,spStrNode
        URL="../RequestHandler.ashx?FileType=cellFile&keyValue=SingleProjectID=<%= SingleProjectID%>|CompanyID=<%=CompanyID %>|ConstructionProjectID=<%=ConstructionProjectID %>"       
        
        for i1=0 to CellWeb1.GetTotalSheets()
            for j1=0 to CellWeb1.GetRows(i1)
                for k1=0 to CellWeb1.GetCols(i1)
                   strNode = CellWeb1.GetCellNote(k1,j1,i1)
                   if strNode<>"" then
                      xml.Open "GET",URL & "&StrforMat=" & strNode,false
                   '      xml.Open "GET",URL & "&StrforMat=5,5" ,false
                        xml.Send
                        
                  '      MsgBox URL & "&StrforMat=" & strNode
                        spStrNode=split(strNode,",")                       
                        returnValue=xml.responseText     
                          
                        if spStrNode(0)=8 then
                        'MsgBox spStrNode(0)
                        'MsgBox returnValue
                            dim imgIndex
                            imgIndex=CellWeb1.AddImage (returnValue)                             
                            if imgIndex <> -1 then                                
                                CellWeb1.SetCellImage k1,j1,i1,imgIndex,1,0,0
                            else 
                                CellWeb1.SetCellString k1,j1,i1,""  
                                '获取签章错误
                            end if    
                           ' elseif spStrNode(0)=1 then  
                           '     CellWeb1.SetCellString k1,j1,i1,returnValue  
                            else 
                                if len(returnValue)>0 then
                                    CellWeb1.SetCellString k1,j1,i1,returnValue  
                                end if    
                            end if                             
                        CellWeb1.SetCellNote  k1,j1,i1,""                            
                   end if
                next 
            next 
        next
        CellWeb1.CloseFile 
    End sub
      
      Sub SaveCell()          
         CellWeb1.UploadFile "UpLoadEFile.aspx?url=<%=NewCellFullFilePath %>"
         
'         document.all.CellWeb1.SetPrinter "Digipower PDF Printer"
'	     document.all.CellWeb1.PrintPara 1,1,0,0
'	     dim TittleName
'	     For j = 0 To document.all.CellWeb1.GetTotalSheets
'            TittleName = document.all.CellWeb1.GetSheetLabel(j)
'            TittleName = Instr(TittleName,"descriptive") 
'            if TittleName = 0 then
'                document.all.CellWeb1.PrintSheet 0,j
'            end if
'         Next
     
'        CellWeb1.CloseFile 
        
        dim returnValue,URL
        Set xml=CreateObject("Microsoft.XMLHTTP")
        URL="../RequestHandler.ashx?FileType=MergerPDF&FileListID=<%=FileListID%>&ArchiveListCellRptID=<%= ArchiveListCellRptID%>&NewCellFilePath=<%=NewCellFilePath%>"       
        xml.Open "POST",URL,false
        xml.Send        
        
        returnValue=xml.responseText
        
        if returnValue= "success" then
            MsgBox "保存成功!"
            window.history.go(-1)
        else    
            MsgBox "保存失败!"
           'MsgBox returnValue
        end if

    End sub
    
    Sub PrintCell()  
         document.all.CellWeb1.SetPrinter "Digipower PDF Printer"
	     document.all.CellWeb1.PrintPara 1,1,0,0
	     dim TittleName
	     For j = 0 To document.all.CellWeb1.GetTotalSheets
            TittleName = document.all.CellWeb1.GetSheetLabel(j)
            TittleName = Instr(TittleName,"descriptive") 
            if TittleName = 0 then
                document.all.CellWeb1.PrintSheet 1,j
            end if
         Next
      End sub
    </script>

</head>
<body id="bd">
    <form id="form1" runat="server">
    <table width="99%" border="0" cellpadding="0" cellspacing="0" style="margin: 2px 2px;
        border: solid 1px #8db2e3;">
        <tr>
            <td height="25" class="button_area" style="border: 0px; border-bottom: 1px;">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="margin-top: 2px;">
                    <tr>
                        <td width="10px">
                            &nbsp;&nbsp;&nbsp;
                        </td>
                        <td>
                        </td>
                        <td>
                            <div align="right">
                                &nbsp;
                                <input type="button" onclick="vbscript:SaveCell()" value=" 保存 " class="button" />
                                <input type="button" onclick="vbscript:PrintCell()" value=" 打印 " class="button" />
                                <uc1:ctrlBtnBack ID="ctrlBtnBack1" runat="server" SetCssClass="button" />
                            </div>
                        </td>
                        <td width="30" align="right">
                            
                            <img src="../Images/01.png" border="0" style="margin-right: 4px;" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
    <object id="CellWeb1" classid="CLSID:3F166327-8030-4881-8BD2-EA25350E574A" codebase="/File/CellWeb5.CAB#Version=5.3.9.14"
        style="width: 97%; height: 600px; margin: 2px 2px; border: solid 1px #8db2e3; vertical-align: top;">
    </object>
</body>
</html>
