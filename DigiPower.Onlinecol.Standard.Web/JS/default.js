var  highlightcolor='#c1ebff';
//此处clickcolor只能用win系统颜色代码才能成功,如果用#xxxxxx的代码就不行,还没搞清楚为什么:(
var  clickcolor='#51b2f6';
function  changeto()
{
source=event.srcElement; 
if(source==null)
return ;
if  (source.tagName=="TR"||source.tagName=="TABLE")
return;
while(source.tagName!="TD")
source=source.parentElement;
source=source.parentElement;
cs  =  source.children;
//alert(cs.length);
    //debugger;
    if(cs[1]!=null)
    {
        if  (cs[1].style.backgroundColor!=highlightcolor&&source.id!="nc"&&cs[1].style.backgroundColor!=clickcolor)
        for(i=0;i<cs.length;i++){
	        cs[i].style.backgroundColor=highlightcolor;
        }
    }
}

function changeback()
{
source=event.srcElement; 
if(source==null)
return ;
if  (source.tagName=="TR"||source.tagName=="TABLE")
return;
while(source.tagName!="TD")
source=source.parentElement;
source=source.parentElement;
cs  =  source.children;

if  (event.fromElement.contains(event.toElement)||source.contains(event.toElement)||source.id=="nc")
return

if(cs.length>1 && cs[1]!=null)
    {
        if  (event.toElement!=source&&cs[1].style.backgroundColor!=clickcolor)
        //source.style.backgroundColor=originalcolor
        for(i=0;i<cs.length;i++){
	        cs[i].style.backgroundColor="";
        }
}
}

function  clickto(){
source=event.srcElement;
if  (source.tagName=="TR"||source.tagName=="TABLE")
return;
while(source.tagName!="TD")
source=source.parentElement;
source=source.parentElement;
cs  =  source.children;
//alert(cs.length);
if  (cs[1].style.backgroundColor!=clickcolor&&source.id!="nc")
for(i=0;i<cs.length;i++){
	cs[i].style.backgroundColor=clickcolor;
}
else
for(i=0;i<cs.length;i++){
	cs[i].style.backgroundColor="";
}
}

function ConfirmDelete()
{
    if(confirm("确认删除吗?")==true)
    {
        return true;
    }
    else
    {
        return false;
    }
}

function Confirm() {
    if (confirm("确认当前操作吗?") == true) {
        return true;
    }
    else {
        return false;
    }
}

function SetSelectBox()
{   
    source=event.srcElement;
    if  (source.tagName=="TR"||source.tagName=="TABLE" || source.tagName=="INPUT")
        return;

    while(source.tagName!="TD")
        source=source.parentElement;
    source=source.parentElement;
    cs  =  source.children;
    if(cs.length>0)
    {   
        if(cs[0].childNodes.length>1)
        {
            cs[0].childNodes[1].checked = !cs[0].childNodes[1].checked;
        }        
    }
}

//gridview中radio列单选
function SelRadioButton(RowId)
{
    var SelRadId = RowId+"_box2";
    
    var radiolistobj = document.getElementsByTagName("input");
    for(var i=0;i<radiolistobj.length;i++)
    {
        if(radiolistobj[i].type == "radio")
        {
            if(radiolistobj[i].id == SelRadId)
                radiolistobj[i].checked = true;
            else
                radiolistobj[i].checked = false;
        }
    }
}