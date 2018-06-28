<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubmitToReadyCheck.aspx.cs"
    Inherits="DigiPower.Onlinecol.Standard.Web.WorkFlow.SubmitToReadyCheck" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/css/default.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="/css/default2.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="/css/table.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="/css/form.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="/css/button.css" media="screen" rel="stylesheet" type="text/css" />

    <script type="text/vbscript" language="vbscript">      
      Sub window_onload        
      
      i12=CellWeb1.Login("芜湖市城建档案管理系统","218.22.66.54","12100101639","6140-1500-0162-3004")
      'msgbox i12      
      CellWeb1.LocalizeControl 2052
      
       ir1=CellWeb1.OpenFile("<%=cellFilePath %>","")
       'msgbox ir1
               
        Set xml=CreateObject("Microsoft.XMLHTTP") 
        dim i1,j1,k1,n2,strNode,URL,returnValue,spStrNode,firstFlag
        URL="../RequestHandler.ashx?FileType=cellFile&keyValue=SingleProjectID=<%= SingleProjectID%>|CompanyID=<%=CompanyID %>|ConstructionProjectID=<%=ConstructionProjectID %>"       
        firstFlag=<%= FirstFlag%>
      
        if firstFlag =1 then      
            for i1=0 to CellWeb1.GetTotalSheets()
                for j1=0 to CellWeb1.GetRows(i1)
                    for k1=0 to CellWeb1.GetCols(i1)
                       strNode = CellWeb1.GetCellNote(k1,j1,i1)
                       if strNode<>"" then
                          xml.Open "GET",URL & "&StrforMat=" & strNode,false
                            xml.Send
                            
                            spStrNode=split(strNode,",")                       
                            returnValue=xml.responseText     
                              
                            if spStrNode(0)=8 then
                                dim imgIndex
                                imgIndex=CellWeb1.AddImage (returnValue)                             
                                if imgIndex <> -1 then                                
                                    CellWeb1.SetCellImage k1,j1,i1,imgIndex,1,0,0
                                else 
                                    CellWeb1.SetCellString k1,j1,i1,""  
                                end if    
                            else 
                                CellWeb1.SetCellString k1,j1,i1,returnValue  
                            end if
                       end if
                    next 
                next 
            next
        end if        
        CellWeb1.CloseFile 
    End sub
      
    Sub SaveCell1()   
      CellWeb1.UploadFile "../File/UpLoadEFile.aspx?url=../Upload/SubmitCell/<%=NewGUID %>"    
      CellWeb1.CloseFile 
     
      dim returnValue
      returnValue=SubmitToReadyCheck.SaveAndSubmit().value    
      if returnValue <> "fail" then
         MsgBox "保存成功!"
         HistroyBack()
      else    
         MsgBox "保存失败!"
      end if
    End sub
    
     Sub SaveCell2()   
      CellWeb1.UploadFile "../File/UpLoadEFile.aspx?url=../Upload/SubmitCell/<%=NewGUID %>"    
      CellWeb1.CloseFile 
     
      dim returnValue
      returnValue=SubmitToReadyCheck.SaveAndAccept().value    
      if returnValue <> "fail" then
         MsgBox "保存成功!"
         HistroyBack()
      else    
         MsgBox "保存失败!"
      end if
    End sub
    </script>

    <script language="javascript" type="text/javascript">
    function ShowButton(btn1,btn2){
        document.getElementById(btn1).style.display='';
        document.getElementById(btn2).style.display='none';
    }
    function HistroyBack(){
        window.history.go(-1);
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
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
                                    <input type="button" id="Button1" onclick="vbscript:SaveCell1()" value=" 保存提交 " class="button" />
                                    &nbsp;
                                    <input type="button" id="Button2" onclick="vbscript:SaveCell2()" value=" 保存受理 " class="button" />
                                    
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
    </div>
    </form>
    <object id="CellWeb1" classid="CLSID:3F166327-8030-4881-8BD2-EA25350E574A" codebase="http://192.168.2.4/File/CellWeb5.3.9.14.CAB#Version=5.3.9.14"
        style="width: 97%; height: 97%; margin: 2px 2px; border: solid 1px #8db2e3; vertical-align: top;">
    </object>
</body>
</html>