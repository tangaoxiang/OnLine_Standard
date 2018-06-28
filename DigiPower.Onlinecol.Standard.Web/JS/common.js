//弹出窗口关闭并刷新父页
function reloadopener()
        {
            window.opener.location.href = window.opener.location.href;
            window.close();
        }

function openNewModelessWindow(url)
{
    return openCommonWindow(url,600,200);
}

//打开非模态新窗口
function openCommonWindow(url,width,height)
{
    var newWin = window.open(url,"","width="+width+",height="+height+",left=150,top=100,menubar=no,toolbar=no,status=no,resizable=no,scrollbars=no,location=no");
    var centerX=(newWin.opener.screenLeft+newWin.opener.document.documentElement.offsetWidth)/2;
    var centerY=(newWin.opener.screenTop+newWin.opener.document.documentElement.offsetHeight)/2;
    newWin.moveTo(parseInt(centerX-width/2),parseInt(centerY-height/2));
    newWin.focus();
    return false;
}
//打开非模态新窗口，窗口可滚动
function openCommonWindowScroll(url,width,height)
{
    var newWin = window.open(url, "", "width=" + width + ",height=" + height + ",left=150,top=100,menubar=no,toolbar=no,status=no,resizable=yes,scrollbars=yes,location=no");
    if (newWin != null) {
        var centerX = (newWin.opener.screenLeft + newWin.opener.document.documentElement.offsetWidth) / 2;
        var centerY = (newWin.opener.screenTop + newWin.opener.document.documentElement.offsetHeight) / 2;
        newWin.moveTo(parseInt(centerX - width / 2), parseInt(centerY - height / 2));
        newWin.focus();
    }
    return false;  
}
//打开模态窗口

function openDialogWindow(url,width,height)
{
    try
    {
        window.showModalDialog( url, "","dialogWidth:"+ width +";dialogHeight:"+ height +";dialogTop:100;dialogLeft:200;status:no;");        
    }
    catch(e)
    {
        openCommonWindow(url,width,height);
    }
}

//确认后转向指定的网址

function confirmUrl(content,url)
{
    if(confirm(content))
        {
            location.href = url;
        }
}

//打开非模态窗口，满屏显示
function openFullWindow(url)
{
    var newWin = window.open(url,"","menubar=no,toolbar=no,status=no,resizable=no,scrollbars=no,location=no");
    newWin.moveTo(0,0);
    newWin.resizeTo(window.screen.availWidth,window.screen.availHeight);
    newWin.focus();
}

function createXMLHttpRequest()
{
    var xmlHttp;
    if(window.ActiveXObject)
    {
        xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
    }
    else if (window.XMLHttpRequest)
    {
        xmlHttp = new XMLHttpRequest();
    }
    return xmlHttp;
}

//新增一个cookie
//objname cookie名称
//objvalue 控件id
//objHours 过期时间（单位：小时，0为100年）
function addCookie(objname,objvalue,objHours)
{
    var value = "";
    var str = "";
    if( objHours == 0)
        objHours = 876000;
    if(document.getElementById(objvalue))
    {
        value = document.getElementById(objvalue).value;
    }
    
    str = objname+"="+escape(value);
    if(objHours>0)
    {
        var date = new Date();
        var ms = objHours*3600*1000;
        date.setTime(date.getTime()+ms);
        str+="; expires="+date.toGMTString();
        document.cookie = str;
    }
   
    
}

//获取一个cookie
//objName cookie名称
//controlId 控件id
//controlType 控件类型 (text文本框，drop下拉框)
function getCookie(objName,controlId,controlType)
{
    if(document.getElementById(controlId))
    {
        var arrStr = document.cookie.split("; ");
        var value = "";
        for(var i=0;i<arrStr.length;i++)
        {
            var temp = arrStr[i].split("=");
            if(temp[0]==objName)
            {
                if(!temp[1])
                {
                    value = "";
                }
                else
                {
                    value = unescape(temp[1]);
                }
                //根据控件类型设置值
                switch(controlType)
                {
                    case "text":
                        if(document.getElementById(controlId))
                        {
                            document.getElementById(controlId).value = value;
                        }
                        break;
                    case "drop":
                        if(document.getElementById(controlId))
                        {
                            var objDrop = document.getElementById(controlId);
                            for(var i1=0;i1<objDrop.options.length;i1++)
                            {
                                if(objDrop.options[i1].value == value)
                                {
                                    objDrop.options[i1].selected = true;
                                    return;
                                }
                            }
                        }
                    default :
                        break;
                }
            }
        }
    }
}

// JScript 文件
//公用方法

/*=================================================================
   一、仿真VBScript函数
=================================================================*/
function left(strString,length)
{
	return strString.substr(0,length);
}

function mid(strString,start,length)
{
	var from=(start<1)?0:start-1;
	return strString.substring(from,from+length);
}

function right(strString,length)
{
	var strlen=strString.length;
	return mid(strString,strlen-length+1,length);
}

function ltrim(strString)
{
	for(var i=0;i<strString.length;i++)
		if(strString.charAt(i)!=' ' && strString.charAt(i)!='　')
			break;
	return mid(strString,i+1,strString.length);
}

function rtrim(strString)
{
	for(var i=strString.length-1;i>0;i--)
		if(strString.charAt(i)!=' ' && strString.charAt(i)!='　')
			break;
	return left(strString,i+1);
}
 
function trim(strString)
{
	return rtrim(ltrim(strString));
}

function replaceString(strToConvert,strIn,strOut) 
{
  var strConvertedString = strToConvert.split(strIn);
  strConvertedString = strConvertedString.join(strOut);
  return strConvertedString;
}
// 另， VBScript 的 vbcrlf ，即 Chr(10) & Chr(13) 和 "\r\n" 对应

/*=================================================================
  End Of VBScript 仿真函数
=================================================================*/

//顶级复选框选中自己选中下级所有复选框
function SelAllCheckBox(spanChk)
{
   if (confirm("确定要全选吗？此功能较花时间，请耐心等待"))
   {
       var oItem = spanChk.children;
       var theBox= (spanChk.type=="checkbox") ? 
            spanChk : spanChk.children.item[0];
       xState=theBox.checked;
       var elm=theBox.form.elements;
       var topid = theBox.id;//顶级复选框id id为cbheader1
       var arrtopid = topid.split('_');
       var temptopid = arrtopid[arrtopid.length-1];
       var temptopidend = temptopid.substring(6,temptopid.length);//取顶级复选框ID中的标识,前6位为cbheader

       for(var i=0;i<elm.length;i++)
       {
         
         if(elm[i]!=null && elm[i].type=="checkbox" && elm[i].id!=topid)
         {
           var bodyid = elm[i].id; //行内复选框id id为cbbody1|1|1
           var arrbodyid = bodyid.split('_');
           var tempbodyid = arrbodyid[arrbodyid.length-1];
           var tempbodyidend = tempbodyid.substring(6,tempbodyid.length);//取行内复选框id中的标识前6位为cbbody
           tempbodyidend = tempbodyidend.split('|')[0];
           
           if(tempbodyidend == temptopidend && elm[i].checked!=xState)//只有本列下的复选框才响应
           {
                
             elm[i].click();
           }
           //elm[i].checked=xState;
         }
       }
   }

}

//选中下级复选框中选中顶级
function SelHeadCheckBox(spanChk)
{
if(spanChk==null)
return false;
    //var oItem = spanChk.children;
    //alert(spanChk.type);
    var theBox= (spanChk.type=="checkbox") ? spanChk : spanChk.children.item[0];
    //var theBox = spanChk;
    xState = theBox.checked;
    elm = theBox.form.elements;
    //alert(xState);
    
        
    //选中复选框
    var theid = theBox.id;
    var thearrbodyid = theid.split('_');
    var thetempbodyid = thearrbodyid[thearrbodyid.length-1];
    var thetempbodyidend = thetempbodyid.substring(6,thetempbodyid.length);//取行内复选框id中的标识前6位为cbbody
    var thearrtag = thetempbodyidend.split('|');
    var therightid = thearrtag[0];
    var themodelid = thearrtag[1];
    var theparentid = thearrtag[2];
    
    for(i=0;i<elm.length;i++)
    {
        if(elm[i].type == "checkbox" && elm[i].id != theid)
        {
            var bodyid = elm[i].id; //行内复选框id id为cbbody1|1|1
            var arrbodyid = bodyid.split('_');
            var tempbodyid = arrbodyid[arrbodyid.length-1];
            var tempbodyidend = tempbodyid.substring(6,tempbodyid.length);//取行内复选框id中的标识前6位为cbbody
            
            var arrtag = tempbodyidend.split('|');
            var rightid = arrtag[0];
            var modelid = arrtag[1];
            var parentid = arrtag[2];
            
            if(xState == true)//选中下级模块要把他的父级模块也选中
            {
                if(theparentid==modelid && therightid==rightid && elm[i].checked != xState )
                {
                    elm[i].click();
                    if(theparentid != 0)
                        SelHeadCheckBox(elm[i]);
                }
            }
            else //取消选中把他的下级模块都取消选中
                UnSelChild(spanChk);
        }
    }
}

//取消选中把他的下级模块都取消选中
function UnSelChild(spanChk)
{
    if(spanChk==null)
return false;
    //var oItem = spanChk.children;
    //alert(spanChk.type);
    var theBox= (spanChk.type=="checkbox") ? spanChk : spanChk.children.item[0];
    //var theBox = spanChk;
    xState = theBox.checked;
    elm = theBox.form.elements;
    //alert(xState);
    
        
    //选中复选框
    var theid = theBox.id;
    
    var thearrbodyid = theid.split('_');
    var thetempbodyid = thearrbodyid[thearrbodyid.length-1];
    var thetempbodyidend = thetempbodyid.substring(6,thetempbodyid.length);//取行内复选框id中的标识前6位为cbbody
    var thearrtag = thetempbodyidend.split('|');
    var therightid = thearrtag[0];
    var themodelid = thearrtag[1];
    var theparentid = thearrtag[2];
    
    for(i=0;i<elm.length;i++)
    {
        if(elm[i].type == "checkbox" && elm[i].id != theid)
        {
            var bodyid = elm[i].id; //行内复选框id id为cbbody1|1|1
            var arrbodyid = bodyid.split('_');
            var tempbodyid = arrbodyid[arrbodyid.length-1];
            var tempbodyidend = tempbodyid.substring(6,tempbodyid.length);//取行内复选框id中的标识前6位为cbbody
            
            var arrtag = tempbodyidend.split('|');
            var rightid = arrtag[0];
            var modelid = arrtag[1];
            var parentid = arrtag[2];
            
            if(xState == false)//取消选中把他的下级模块都取消选中
            {
                if(themodelid==parentid && therightid==rightid && elm[i].checked != xState )
                {
                    elm[i].click();
                    if(theparentid != 0)
                        UnSelChild(elm[i]);
                }
            }
            
        }
    }
}

//展开,隐藏顶部查询条
function showHidHead(sender,target)
{
    if(target.style.display == "block")
    {
        target.style.display = "none";
        sender.src = "../images/comm/downhigh.gif";
        sender.alt = "展开";
    }
    else
    {
        target.style.display = "block";
        sender.src = "../images/comm/uphigh.gif";
        sender.alt="隐藏";
    }
}

function checkTxtValue(txtBoxIn,messtr)
{
//检查文本框是否有非法字符
	var strX = new Array('&','%','$','#','@','!','~','`','^','.',
	'\'', '*','\/','\\','\"',',','?','<','>','[',']','+', ';');	 
	var i;
	
	
	try
	{
		for(i=0;i<strX.length; i++)
		{
			if(txtBoxIn.value.indexOf(strX[i])>= 0)
			{	
				if(messtr=="") alert('输入框中包含非法字符，请重新输入！');
				else alert(messtr);
				if(!txtBoxIn.disabled)
				{
					txtBoxIn.select();
					txtBoxIn.focus();
				}
				return false;
			}
		}
		return true;
	}
	catch(e) {return false;}
}

function onMouseOverImgBtn(oImgBtn){
	if( ! oImgBtn.disabled )
		oImgBtn.className = "imgbuttonhover";
}

function onMouseOutImgBtn(oImgBtn){
	if( ! oImgBtn.disabled )
		oImgBtn.className = "imgbutton";
}

//显示/隐藏主从表中从表数据
function showHiddenGridDetail(sid,ev)
  {
    ev = ev || window.event;
    var target = ev.target || ev.srcElement;
    var oDiv = document.getElementById("div" + sid);
    oDiv.style.display = oDiv.style.display == "none"?"block":"none";
    target.src = oDiv.style.display == "none"?"../images/handlerightlast.gif":"../images/handledownlast.gif";
    target.alt = oDiv.style.diaplay == "none"?"显示":"隐藏"
  }

/*******************************************************/
//以下的代码用于在  List 页面 PostBack 时，将上次所选择的行重新选择
/*******************************************************/
function onLoadInitListTbl( oTbl , iRowIndexListTbl ){
	if( typeof(iRowIndexListTbl) != "undefined" ){
		if( iRowIndexListTbl < oTbl.rows.length ){
			oTRMouseOverListTbl = oTbl.rows[iRowIndexListTbl];
			oTRMouseOverListTbl.focus();
			onClickListTbl( true ); 
		}
	}	
}

/*******************************************************/
//以下的代码用于通用的 Table 鼠标跟随高亮显示的配置用
// 配置该 Table 之中，不用于高亮显示的表头有多少行，默认为 1
/*******************************************************/
var igbListTblHighlightRowIndexFrom = 1 ;
function setListTblHighlightRowIndexFrom( iValue ){
	igbListTblHighlightRowIndexFrom = (iValue >= 0) ? iValue : 1 ;
}
function getListTblHighlightRowIndexFrom( ){
	return igbListTblHighlightRowIndexFrom ;
}


/*******************************************************/
//以下的代码用于通用的 Table 鼠标跟随高亮显示
/*******************************************************/
var oTRMouseOverListTbl , oTRClickListTbl;
function onMouseOverListTbl(){
	//用于当页面被销毁之前的 onMouseOver 事件
	if( ! event.srcElement )	return;
	event.cancelBubble=true;
	var oTR ;
	with(event.srcElement){
		if(tagName == "TD")
			oTR = parentElement ;
		else{
			//当 在TR中出现输入框时，如果将鼠标从输入框中拖动，方向为Table外，
			//则有可能出现 event.srcElement.tagName ==  "BODY" 或 "HTML" （当该 Table 被另一个Table包含时）
			if( tagName == "TABLE" ||  tagName == "BODY" || tagName == "HTML" )
				oTR = null ;
			else
				oTR = offsetParent.parentElement ;	
		}	
	}
	if(oTR)
		if(oTR != oTRMouseOverListTbl && oTR.rowIndex >= getListTblHighlightRowIndexFrom() ){
			if(oTRClickListTbl == oTRMouseOverListTbl) 
				formatListTbl (oTR , null , "MouseOver")	;
			else{	
				if(oTR == oTRClickListTbl)
					formatListTbl (null , oTRMouseOverListTbl , "MouseOver")	;
				else
					formatListTbl (oTR , oTRMouseOverListTbl , "MouseOver")	;
			}	
			oTRMouseOverListTbl = oTR ;
		}	

}
function onMouseOutListTbl(){
	//用于当页面被销毁之前的 onMouseOut 事件
	if( ! event.srcElement )	return;
	event.cancelBubble=true;
	if( oTRMouseOverListTbl != null && oTRClickListTbl != null )
		if(oTRMouseOverListTbl != oTRClickListTbl){
			formatListTbl (null , oTRMouseOverListTbl , "MouseOver")	;
			oTRMouseOverListTbl = null ;
		}	
}
function onClickListTbl( bSkipEvent ){
	if(!bSkipEvent){
		//用于当页面被销毁之前的 onClick 事件
		if( ! event.srcElement )	return;
		event.cancelBubble=true;
	}	
	if(oTRMouseOverListTbl && oTRMouseOverListTbl.rowIndex  >= getListTblHighlightRowIndexFrom() )
		if(oTRMouseOverListTbl != oTRClickListTbl){
			formatListTbl (oTRMouseOverListTbl ,oTRClickListTbl , "Click")	;
			oTRClickListTbl = oTRMouseOverListTbl ;
			setCurrRowIndexListTbl( oTRMouseOverListTbl.rowIndex );
		}	

}

function formatListTbl (oCurrTR , oOrignalTR , sFormatType ){
	switch(sFormatType){
		case "MouseOver" :
			if(oCurrTR) {
				if( oCurrTR.className == "")
					oCurrTR.className = "mouseoveritem" ;
			}		
			if(oOrignalTR) 
				if(oOrignalTR.className == "mouseoveritem") 
					oOrignalTR.className = "" ;
			break ;	
		case "Click" :
			if( oCurrTR.className == "" || oCurrTR.className == "mouseoveritem")
				oCurrTR.className = "mouseclickitem" ;
			if(oOrignalTR) 
				if( oOrignalTR.className == "mouseoveritem" || oOrignalTR.className == "mouseclickitem" ) 
					oOrignalTR.className = "" ;
			break ;	
	}
}
function setCurrRowIndexListTbl( iRowIndexListTbl ){
	if(typeof(document.all.CurrRowIndexListTbl) != "undefined" )
		document.all.CurrRowIndexListTbl.value = iRowIndexListTbl ;
}


/*******************************************************/
//在页面中title提示"双击页面隐藏/显示框架！"
//双击页页隐藏左和上框架
/*******************************************************/
    var sIniCols,sIniRows,sNoCols,sNoRows;
    var oParentFrame, oTopFrame, flag;
    function docLoad(){
	    try{
		    oParentFrame = window.frameElement.parentNode;
		    oTopFrame = oParentFrame.parentNode;
		    //只实现主框架的控制
		    if( oParentFrame.name == "fset" ){
			    //这种方式有问题
			    //sNoCols = sIniCols = oParentFrame.cols;
			    //sNoRows = sIniRows = oTopFrame.rows;
			    sNoCols = sIniCols = "150,9,*";
			    sNoRows = sIniRows = "64,*";
			    if( ( pos = sIniCols.indexOf(",") )!=-1)
				    sNoCols = "0" + sNoCols.substring(pos);
			    if( ( pos = sNoRows.indexOf(",") )!=-1)
				    sNoRows = "0" + sNoRows.substring(pos);
			    flag = false;
			    if(typeof(oParentFrame)!="undefined")
				    window.document.body.title = "双击页面隐藏/显示框架！";
		    }
	    }catch(e)
	    {
		    ;	
	    }
    }
    function pframeControl(){
	    try{
		    //只实现主框架的控制
		    if( oParentFrame.name == "fset" ){
			    //部分元素不执行
			    var sActiveElementType = document.activeElement.type;
			    if(sActiveElementType == "text" || sActiveElementType == "textarea"){
				    return false;
			    }
			    flag = !flag;
			    //top.mid.shift_status();
			    oParentFrame.cols = flag ? sNoCols : sIniCols;
			    oTopFrame.rows = flag ? sNoRows : sIniRows;
		    }
	    }catch(e)
	    {
		    ;
	    }
    }
    //window.attachEvent("onload",docLoad);
    //window.document.attachEvent("ondblclick",pframeControl);
/*=================================================================
 窗口函数 Window  函数  及 Window 功能函数
=================================================================*/

// 定义一个全局变量，用来取得页面上的所有子页面的文件句柄
// 通过这个文件句柄集合，可以一次性的把子页面全部关闭 
var childrenWindowCollenction = new Array() ;

function openWin(strURL,strName,iWidth,iHeight,boolResizable,boolScroll,boolStatus) {
	var strFeature , strWindowName ;
	//指定窗口的名称
	//如果指定窗口的名称，在window.open()时会变慢！
	if(typeof(strName)!="undefined")
		strWindowName = strName ;
	else
		strWindowName = "" ;
	if(trim(strURL)==""){
		return false;
	}
	//指定 window.open的参数，宽度、高度比例采用黄金分割
	var iwid = 580 , ihei = parseInt(iwid*0.618) , bres = "yes" , bscr ="yes" , bsta = "no" ;
	if(typeof(iWidth)!="undefined" && typeof(iHeight)!="undefined"){
		iwid = iWidth    ;
		ihei = iHeight	 ;
	}
	if(typeof(boolResizable)!="undefined")
		bres = boolResizable ;
	if(typeof(boolScroll)!="undefined")
		bscr = boolScroll ;
	if(typeof(boolStatus)!="undefined")
		bsta = boolStatus ;

	var ileft = (screen.availWidth/2) - iwid/2;
	var itop = (screen.availHeight - ihei)/2 ;
	if( bsta ) itop -= 20 ;
	if( itop < 0 ) itop = 0 ;
	strFeature = "left="+ ileft +",top="+ itop +",width=" + iwid +",height=" + ihei + "," + 
			"scrollbars="+ bscr +",resizable="+ bres +",status="+ bsta + "," +
			"toolbar=no,location=no,directories=no,menubar=no" ;
	
	// 新开窗口，取得文件句柄
	childrenWindowCollenction[childrenWindowCollenction.length] 
		= window.open(strURL,strWindowName,strFeature);
	if( childrenWindowCollenction[childrenWindowCollenction.length-1] != null )
		childrenWindowCollenction[childrenWindowCollenction.length-1].focus();
	else
		alert("新开窗口失败！\n\n请关闭上网助手等软件对本网站的（广告）窗口拦截功能");
}

//*****************************************************************  
//函数名: SetTextEmpty
//输  入: 无
//输  出: 无
//功  能: 清空所有的Text表单,包括普通文本与密码框内容
//****************************************************************
function SetTextEmpty()
{
   var mm=document.getElementsByTagName("input").length;
   var tt=document.getElementsByTagName("textarea").length; 
   if(mm>0)
   {
      for(var i=0;i<mm;i++)
      {
         var dd=document.getElementsByTagName("input").item(i);
         if(dd.type=="text"||dd.type=="password")
         {
            dd.value="";
         }
      }
   }
   if(tt>0)
   {
      for(var i1=0;i1<tt;i1++)
      {
         var dd2=document.getElementsByTagName("textarea").item(i1);
         dd2.value="";
      }
   }
}
//*****************************************************************  
//函数名: SetInputDisable
//输  入: 无
//输  出: 无
//功  能: 设置输入框为不可用
//****************************************************************
function SetInputDisable()
{
   var mm=document.getElementsByTagName("input").length;
   var tt=document.getElementsByTagName("textarea").length;
   var ss=document.getElements
   if(mm>0)
   {
      for(var i=0;i<mm;i++)
      {
         var dd=document.getElementsByTagName("input").item(i);
         if(!(dd.type=="button"&&dd.type=="image"))
         {
            dd.disabled="disabled";
         }
      }
   }
   if(tt>0)
   {
      for(var i1=0;i1<tt;i1++)
      {
         var dd2=document.getElementsByTagName("textarea").item(i1);
         dd2.disabled="disabled";
      }
   }
}

 //return if s1 ends with s2 
 function endWith(s1,s2)   
  {
      if(s1.length<s2.length)
        return false;   
      if(s1==s2)
        return true; 
      else
        {
          var s11=String(s1);
          var s3=s11.substr(s11.length-s2.length, s2.length);
          if(s3==s2)
              return true;
        }  
  }
  
//*****************************************************************  
//函数名: SetValueFromChildPage
//输  入: childPage：子窗口路径 paraName：子窗口传递参数名 paraValue：子窗口传递参数值
//输  出: 无
//功  能: 通过打开子窗口选取指定值赋值给父窗口，赋值由子窗口执行
//****************************************************************
function SetValueFromChildPage(childPage,paraName,paraValue)
{
    openWin(childPage+ "?" + paraName + "=" + paraValue, "setWindow" , 500 , 400 , 1 , 1 , 0) ;
}

