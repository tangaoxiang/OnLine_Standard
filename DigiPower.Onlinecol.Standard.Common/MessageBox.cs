﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace DigiPower.Onlinecol.Standard.Common
{
    /// <summary>
    /// 显示消息提示对话框。	
    /// </summary>
    public class MessageBox
    {        
        /// <summary>
        /// 后台执行的JS脚本 ,在  ＜/form＞之前执行
        /// </summary>
        /// <param name="page"></param>
        /// <param name="strJavaScript">JS脚本</param>
        public static void RegisterStartupScriptString(System.Web.UI.Page page, string strJavaScript)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "IsSuccess", "<script>" + strJavaScript + "</script>");
        }

        /// <summary>
        /// 后台隐藏前台UI
        /// </summary>
        /// <param name="page"></param>
        /// <param name="uiList">ui ID集合</param>
        public static void DisplayHideUI(System.Web.UI.Page page, params object[] uiList)
        {
            string js = string.Empty;
            foreach (object obj in uiList)
            {
                js += "$(\"#" + obj.ToString() + "\").hide();";
            }
            page.ClientScript.RegisterStartupScript(page.GetType(), "DisplayHideUI", "<script>" + js + "</script>");
        }

        /// <summary>
        /// 后台显示前台UI
        /// </summary>
        /// <param name="page"></param>
        /// <param name="uiList">ui ID集合</param>
        public static void DisplayShowUI(System.Web.UI.Page page, params object[] uiList)
        {
            string js = string.Empty;
            foreach (object obj in uiList)
            {
                js += "$(\"#" + obj.ToString() + "\").show();";
            }
            page.ClientScript.RegisterStartupScript(page.GetType(), "DisplayShowUI", "<script>" + js + "</script>");
        }

        /// <summary>
        /// 后台关闭Layer Open的页面
        /// </summary>
        /// <param name="page"></param>
        public static void CloseLayerOpenWeb(System.Web.UI.Page page)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "CloseLayerOpenWeb",
                "<script>var index = parent.layer.getFrameIndex(window.name);"
                + "parent.document.getElementById('hidOpenFlag').value = '1';"
                + "parent.layer.close(index);</script>");
        }

        /// <summary>
        /// 后台弹出layui消息框
        /// </summary>
        /// <param name="page"></param>
        public static void FnLayerAlert(System.Web.UI.Page page, string Msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "FnLayerAlert",
                "<script>"
                + "     Common.fnLayerAlert('" + Msg + "');"
                + "</script>");
        }

        /// <summary>
        /// 显示消息提示对话框
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void Show(System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript'>alert('" + msg.ToString() + "');</script>");
        }

        /// <summary>
        /// 控件点击 消息确认提示框
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void ShowConfirm(System.Web.UI.WebControls.WebControl Control, string msg)
        {
            //Control.Attributes.Add("onClick","if (!window.confirm('"+msg+"')){return false;}");
            Control.Attributes.Add("onclick", "return confirm('" + msg + "');");
        }

        /// <summary>
        /// 显示消息提示对话框，并进行页面跳转
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        /// <param name="url">跳转的目标URL</param>
        public static void ShowAndRedirect(System.Web.UI.Page page, string msg, string url)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript'>");
            if (msg.Trim().Length > 0)
                Builder.AppendFormat("alert('{0}');", msg);
            Builder.AppendFormat("location.href='{0}';", url);
            Builder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());

        }

        /// <summary>
        /// 打开新页面
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="url">新页面地址</param>
        /// <param name="height">窗体高度</param>
        /// <param name="width">窗体宽度</param>
        public static void OpenWindow(System.Web.UI.Page page, string url, string height, string width)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript'>");

            Builder.Append("var newWin = window.open('" + url + "','','width=" + width + ",height=" + height + ",left=150,top=100,menubar=no,toolbar=no,status=no,resizable=yes,scrollbars=no,location=no');");
            Builder.Append("var centerX = (newWin.opener.screenLeft + newWin.opener.document.documentElement.offsetWidth) / 2;");
            Builder.Append("var centerY = (newWin.opener.screenTop + newWin.opener.document.documentElement.offsetHeight) / 2;");
            Builder.Append("newWin.moveTo(parseInt(centerX - " + width + " / 2), parseInt(centerY - " + height + " / 2));");

            Builder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());

        }





        /// <summary>
        /// 页面跳转
        /// </summary>
        /// <param name="url">跳转的目标URL</param>
        public static void Redirect(string url)
        {
            HttpContext.Current.Response.Redirect(url, false);
        }

        /// <summary>
        /// 输出自定义脚本信息
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="script">输出脚本</param>
        public static void ResponseScript(System.Web.UI.Page page, string script)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>" + script + "</script>");
        }
        #region 关闭本窗口
        /// <summary>
        /// 关闭本窗口
        /// </summary>
        /// <param name="_Page"></param>
        public static void CloseThisWindow(System.Web.UI.Page _Page)
        {
            _Page.ClientScript.RegisterClientScriptBlock(_Page.GetType(), "closewin", "<script language='javascript'>window.close()</script>");
        }
        #endregion
        #region 输出信息并关闭本窗口
        /// <summary>
        /// 输出信息并关闭本窗口
        /// </summary>
        /// <param name="_Page"></param>
        public static void ShowAndCloseWin(System.Web.UI.Page _Page, string Msg)
        {
            _Page.ClientScript.RegisterClientScriptBlock(_Page.GetType(), "closewin", "<script language='javascript'>alert('" + Msg + "');window.close()</script>");
        }
        #endregion
        #region 返回
        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="_Page"></param>
        public static void WinBack(System.Web.UI.Page _Page)
        {
            _Page.ClientScript.RegisterClientScriptBlock(_Page.GetType(), "winback", "<script language='javascript'>history.go(-1);</script>");
        }
        #endregion

        #region Div提示框
        /// <summary>
        /// 提示框
        /// </summary>
        /// <param name="page">页面</param>
        /// <param name="alertStr">提示信息，确定后返回本页</param>
        public static void AlertDiv(System.Web.UI.Page page, string alertStr)
        {
            AlertDivCourse(page, alertStr, 1, string.Empty, string.Empty);
        }
        /// <summary>
        /// 提示框
        /// </summary>
        /// <param name="page">页面</param>
        /// <param name="alertStr">提示信息，按类型执行</param>
        /// <param name="type">类型：1：确定后返回本页
        ///                          2：返回上一页
        ///                          3：返回登录页面
        ///                          4：确定后关闭窗口
        ///                          5：返回管理首页
        ///                          6：确定后刷新父页面，不指定父页面参数，以及刷新当前页</param>
        public static void AlertDiv(System.Web.UI.Page page, string alertStr, int type)
        {
            AlertDivCourse(page, alertStr, type, string.Empty, string.Empty);
        }
        /// <summary>
        /// 提示框
        /// </summary>
        /// <param name="page">页面</param>
        /// <param name="alertStr">提示信息，按类型执行</param>
        /// <param name="type">类型：1：确定后返回本页
        ///                          2：返回上一页
        ///                          3：返回登录页面
        ///                          4：确定后关闭窗口
        ///                          5：返回管理首页
        ///                          6：确定后刷新父页面，不指定父页面参数，以及刷新当前页
        ///                          7：确定后刷新父页面，不指定父页面参数，以及本身打开指定页
        ///                          11：确定后返回指定页面
        ///                          12：确定后刷新父页面，不指定父页面参数，以及关闭当前窗口</param>
        /// <param name="targetUrl">本页定向路径</param>
        public static void AlertDiv(System.Web.UI.Page page, string alertStr, int type, string targetUrl)
        {
            AlertDivCourse(page, alertStr, type, targetUrl, string.Empty);
        }
        /// <summary>
        /// 提示框
        /// </summary>
        /// <param name="page">页面</param>
        /// <param name="alertStr">提示信息，按类型执行</param>
        /// <param name="type">类型：1：确定后返回本页
        ///                          2：返回上一页
        ///                          3：返回登录页面
        ///                          4：确定后关闭窗口
        ///                          5：返回管理首页
        ///                          6：确定后刷新父页面，不指定父页面参数，以及刷新当前页
        ///                          7：确定后刷新父页面，不指定父页面参数，以及本身打开指定页
        ///                          8：确定后刷新父页面，并指定父页面参数，以及刷新当前页
        ///                          9：确定后刷新父页面，并指定父页面参数，以及本身打开指定页
        ///                          10：确定后刷新父页面，并指定父页面参数，以及关闭当前窗口
        ///                          11：确定后返回指定页面
        ///                          12：确定后刷新父页面，不指定父页面参数，以及关闭当前窗口</param>
        /// <param name="targetUrl">本页定向路径</param>
        /// <param name="parentUrlPamas">父页面参数：以&开头</param>
        public static void AlertDiv(System.Web.UI.Page page, string alertStr, int type, string targetUrl, string parentUrlPamas)
        {
            AlertDivCourse(page, alertStr, type, targetUrl, parentUrlPamas);
        }

        /// <summary>
        /// 提示框
        /// </summary>
        /// <param name="page">页面</param>
        /// <param name="alertStr">提示信息，按类型执行</param>
        /// <param name="type">类型：1：确定后返回本页
        ///                          2：返回上一页
        ///                          3：返回登录页面
        ///                          4：确定后关闭窗口
        ///                          5：返回管理首页
        ///                          6：确定后刷新父页面，不指定父页面参数，以及刷新当前页
        ///                          7：确定后刷新父页面，不指定父页面参数，以及本身打开指定页
        ///                          8：确定后刷新父页面，并指定父页面参数，以及刷新当前页
        ///                          9：确定后刷新父页面，并指定父页面参数，以及本身打开指定页
        ///                          10：确定后刷新父页面，并指定父页面参数，以及关闭当前窗口
        ///                          11：确定后返回指定页面
        ///                          12：确定后刷新父页面，不指定父页面参数，以及关闭当前窗口</param>
        /// <param name="targetUrl">本页定向路径</param>
        /// <param name="parentUrlPamas">父页面参数：以&开头</param>
        private static void AlertDivCourse(System.Web.UI.Page page, string alertStr, int type, string targetUrl, string parentUrlPamas)
        {
            if (type == 0) type = 1;
            StringBuilder str = new StringBuilder();

            str.Append("<script type=\"text/javascript\">\n");
            str.Append("function ShowAlertDiv(alertStr){ \n");
            str.Append("document.getElementById(\"AlertBgDiv\").style.display=\"block\"; \n");
            str.Append("document.getElementById(\"AlertBgDiv\").style.width=document.documentElement.offsetWidth; \n");//clientWidth
            str.Append("document.getElementById(\"AlertBgDiv\").style.height=document.documentElement.scrollHeight>document.documentElement.clientHeight?document.documentElement.scrollHeight:document.documentElement.clientHeight; \n");//document.documentElement.clientHeight
            str.Append("document.getElementById(\"AlertDiv\").style.display='block'; \n");
            str.Append("document.documentElement.style.overflow = \"hidden\";\n");
            str.Append("selectObjHidded();\n");
            str.Append("//禁用右键\n");
            str.Append("function document.oncontextmenu() { return false; }");
            str.Append("document.getElementById(\"errText\").innerHTML=alertStr;\n");
            str.Append("} \n");
            str.Append("function AlertDivAction(){ \n");
            str.Append("document.getElementById(\"AlertBgDiv\").style.display='none';\n");
            str.Append("document.getElementById(\"AlertDiv\").style.display='none';\n");
            str.Append("document.documentElement.style.overflow = \"auto\";\n");
            str.Append("selectObjVisible();\n");
            str.Append("//启用右键\n");
            str.Append("function document.oncontextmenu() { return true; }\n");
            switch (type)
            {
                case 2:
                    str.Append("window.history.go(-1);\n");
                    break;
                case 3:
                    str.Append("window.location.href='../UserLogin.aspx';\n");
                    break;
                case 4:
                    str.Append("window.opener=null;window.close();\n");
                    break;
                case 5:
                    str.Append("window.location.href='../Main.aspx';\n");
                    break;
                case 6:
                    str.Append("window.opener.document.location.href=window.opener.document.location;window.location.href=window.location;\n");
                    break;
                case 7:
                    str.Append("window.opener.document.location.href=window.opener.document.location;window.location.href='" + targetUrl + "';\n");
                    break;
                case 8:
                    str.Append("var parentUrl=window.opener.document.location.toString();\n if(!endWith(parentUrl,\".aspx\")) { var tempArr=parentUrl.split(\"?\");parentUrl=tempArr[0];}\n parentUrl+=\"?p=0\"; \n window.opener.document.location.href=parentUrl+\"" + parentUrlPamas + "\";window.location.href=window.location;\n");
                    break;
                case 9:
                    str.Append("var parentUrl=window.opener.document.location.toString();\n if(!endWith(parentUrl,\".aspx\")) { var tempArr=parentUrl.split(\"?\");parentUrl=tempArr[0];}\n parentUrl+=\"?p=0\"; \n window.opener.document.location.href=parentUrl+\"" + parentUrlPamas + "\";window.location.href='" + targetUrl + "';\n");
                    break;
                case 10:
                    str.Append("var parentUrl=window.opener.document.location.toString();\n if(!endWith(parentUrl,\".aspx\")) { var tempArr=parentUrl.split(\"?\");parentUrl=tempArr[0];}\n parentUrl+=\"?p=0\"; \n window.opener.document.location.href=parentUrl+\"" + parentUrlPamas + "\";window.opener=null;window.close();\n");
                    break;
                case 11:
                    str.Append("window.location.href=window.location;\n");
                    break;
                case 12:
                    str.Append("window.opener.document.location.href=window.opener.document.location;window.opener=null;window.close();\n");
                    break;
            }
            str.Append("}\n");
            str.Append("function AlertDivKeyDown()\n");
            str.Append("{\n");
            str.Append("if(event.keyCode==13 || event.keyCode==32) AlertDivAction();\n");
            str.Append("}\n");

            str.Append("//隐藏所有的select\n");
            str.Append("function selectObjHidded(){\n");
            str.Append("var obj;\n");
            str.Append("obj=document.getElementsByTagName(\"SELECT\");\n");
            str.Append("var i;\n");
            str.Append("for(i=0;i<obj.length;i++) obj[i].style.visibility=\"hidden\";\n");
            str.Append("}\n");
            str.Append("//显示所有的select\n");
            str.Append("function selectObjVisible(){\n");
            str.Append("var obj;\n");
            str.Append("obj=document.getElementsByTagName(\"SELECT\");\n");
            str.Append("var i;\n");
            str.Append("for(i=0;i<obj.length;i++) obj[i].style.visibility=\"visible\";\n");
            str.Append("}\n");
            str.Append("</script> \n");

            str.Append("<div id=\"AlertBgDiv\" style=\"position:absolute;top:0px;FILTER: alpha(opacity=60);background-color:#777; z-index:9999; left: 0px;display:none;\"></div> \n");
            str.Append("<!--浮层框架开始-->\n");
            str.Append("<div id=\"AlertDiv\" style=\"position:absolute; z-index:10000; width:440px; height:200px;left:expression((document.body.offsetWidth-440)/2); top: expression((document.documentElement.offsetHeight-200)/2);background-color:#fff; border:1px #99CCFF solid; display:none;\">\n");
            str.Append("<div style=\" text-align:left; background-color:#E2EFFF;color:#000;padding-left:4px;padding-top:8px;font-weight:bold;font-size:14px; height:27px;\">[&nbsp;提&nbsp;示&nbsp;]</div>\n");
            str.Append("<div style=\"width:150px; float:left; text-align:center; padding-top:20px;\">\n");
            str.Append("<img alt=\"\" src=\"../images/Comm/err.gif\" />\n");
            str.Append("</div>\n");
            str.Append("<div style=\"width:260px; float:left; padding-top:40px;font-size:14px;\">\n");
            str.Append("<div style=\" text-align:left;\">\n");
            str.Append("<span id=\"errText\"></span>\n");
            str.Append("</div>\n");
            str.Append("<div style=\"text-align:right; margin-top:20px;\">\n");
            string buttonStr = "确 定";
            switch (type)
            {
                case 1:
                    buttonStr = "确 定";
                    break;
                case 2:
                    buttonStr = "返回上一页";
                    break;
                case 3:
                    buttonStr = "返回登录页面";
                    break;
                case 4:
                    buttonStr = "关闭窗口";
                    break;
                case 5:
                    buttonStr = "返回管理首页";
                    break;
                default:
                    buttonStr = "确 定";
                    break;
            }
            str.Append("<input id=\"btnAlertDiv\" type=\"button\" value=\"" + buttonStr + "\" onclick=\"javascript:AlertDivAction();\" style=\" width:149px; height:27px; background:url(../images/alertDivButtonBg.gif);border:0px; color:#853D0D; cursor:hand;\" />\n");
            str.Append("</div>\n");
            str.Append("</div>\n");
            str.Append("</div>\n");
            str.Append("<!--浮层框架结束-->\n");

            str.Append("<script type=\"text/javascript\">\n");
            str.Append("ShowAlertDiv('" + alertStr + "');\n");
            str.Append("document.onkeydown=AlertDivKeyDown;\n");
            str.Append("</script>\n");

            page.ClientScript.RegisterStartupScript(page.GetType(), "alertDiv", str.ToString());
        }
        #endregion

        #region Div提示框2
        /// <summary>
        /// 提示框
        /// </summary>
        /// <param name="page">页面</param>
        /// <param name="alertStr">提示信息，按类型执行</param>
        /// <param name="type">类型：1：确定后返回本页
        ///                          2：返回上一页
        ///                          3：返回指定页面
        ///                          4：确定后关闭窗口</param>
        /// <param name="targetUrl">本页定向路径</param>
        public static void AlertDiv2(System.Web.UI.Page page, string alertStr, int type, string targetUrl)
        {
            if (type == 0) type = 1;
            StringBuilder str = new StringBuilder();
            str.Append("<script type=\"text/javascript\">\n");
            str.Append("function ShowAlertDiv(alertStr){ \n");
            str.Append("document.getElementById(\"AlertBgDiv\").style.display=\"block\"; \n");
            str.Append("document.getElementById(\"AlertBgDiv\").style.width=document.documentElement.offsetWidth; \n");//clientWidth
            str.Append("document.getElementById(\"AlertBgDiv\").style.height=document.documentElement.scrollHeight>document.documentElement.clientHeight?document.documentElement.scrollHeight:document.documentElement.clientHeight; \n");//document.documentElement.clientHeight
            str.Append("document.getElementById(\"AlertDiv\").style.display='block'; \n");
            str.Append("document.documentElement.style.overflow = \"hidden\";\n");
            str.Append("selectObjHidded();\n");
            str.Append("//禁用右键\n");
            str.Append("document.oncontextmenu=function(e){return false;}\n");
            //str.Append("function document.oncontextmenu() { return false; }\n");
            str.Append("document.getElementById(\"errText\").innerHTML=alertStr;\n");
            str.Append("} \n");
            str.Append("function AlertDivAction(){ \n");
            str.Append("document.getElementById(\"AlertBgDiv\").style.display='none';\n");
            str.Append("document.getElementById(\"AlertDiv\").style.display='none';\n");
            str.Append("document.documentElement.style.overflow = \"auto\";\n");
            str.Append("selectObjVisible();\n");
            str.Append("//启用右键\n");
            str.Append("document.oncontextmenu=function(e){return true;}\n");
            //str.Append("function document.oncontextmenu() { return true; }\n");
            switch (type)
            {
                case 2:
                    str.Append("window.history.go(-1);\n");
                    break;
                case 3:
                    str.Append("window.location.href='" + targetUrl + "';\n");
                    break;
                case 4:
                    str.Append("window.opener=null;window.close();\n");
                    break;
            }
            str.Append("}\n");
            str.Append("function AlertDivKeyDown(e)\n");
            str.Append("{\n");
            str.Append("var ie6 = document.all ? true : false;\n");
            str.Append("if(ie6) e = event;\n");
            str.Append("if(e.keyCode==13 || e.keyCode==32) AlertDivAction();\n");
            str.Append("}\n");

            str.Append("//隐藏所有的select\n");
            str.Append("function selectObjHidded(){\n");
            str.Append("var obj;\n");
            str.Append("obj=document.getElementsByTagName(\"SELECT\");\n");
            str.Append("var i;\n");
            str.Append("for(i=0;i<obj.length;i++) obj[i].style.visibility=\"hidden\";\n");
            str.Append("}\n");
            str.Append("//显示所有的select\n");
            str.Append("function selectObjVisible(){\n");
            str.Append("var obj;\n");
            str.Append("obj=document.getElementsByTagName(\"SELECT\");\n");
            str.Append("var i;\n");
            str.Append("for(i=0;i<obj.length;i++) obj[i].style.visibility=\"visible\";\n");
            str.Append("}\n");
            str.Append("</script> \n");

            str.Append("<div id=\"AlertBgDiv\" style=\"position:absolute;top:0px;background-color:#777; z-index:9999; left: 0px;display:none;-ms-filter: 'progid:DXImageTransform.Microsoft.Alpha(Opacity=30)'; /*IE8*/filter:alpha(opacity=30);  /*IE5、IE5.5、IE6、IE7*/opacity: .3;  /*Opera9.0+、Firefox1.5+、Safari、Chrome*/\"></div> \n");
            str.Append("<!--浮层框架开始-->\n");
            str.Append("<div id=\"AlertDiv\" style=\"position:absolute; z-index:10000; width:440px; height:200px;left:expression((document.body.offsetWidth-440)/2); top: expression((document.documentElement.offsetHeight-200)/2);background-color:#fff; border:1px #FF7400 solid; display:none;\">\n");
            str.Append("<div style=\" text-align:left; background-color:#FEF9F6;color:#000;padding-left:4px;padding-top:8px;font-weight:bold;font-size:14px; height:27px;\">[&nbsp;提&nbsp;示&nbsp;]</div>\n");
            str.Append("<div style=\"width:150px; float:left; text-align:center; padding-top:20px;\">\n");
            str.Append("<img alt=\"\" src=\"../images/err.gif\" />\n");
            str.Append("</div>\n");
            str.Append("<div style=\"width:260px; float:left; padding-top:40px;font-size:14px;\">\n");
            str.Append("<div style=\" text-align:left;\">\n");
            str.Append("<span id=\"errText\"></span>\n");
            str.Append("</div>\n");
            str.Append("<div style=\"text-align:right; margin-top:20px;\">\n");
            string buttonStr = "确 定";
            switch (type)
            {
                case 1:
                    buttonStr = "确 定";
                    break;
                case 2:
                    buttonStr = "返回上一页";
                    break;
                case 3:
                    buttonStr = "确 定";
                    break;
                case 4:
                    buttonStr = "关闭窗口";
                    break;
                default:
                    buttonStr = "确 定";
                    break;
            }
            str.Append("<input id=\"btnAlertDiv\" type=\"button\" value=\"" + buttonStr + "\" onclick=\"javascript:AlertDivAction();\" style=\" width:149px; height:27px; background:url(../images/alertDivButtonBg.gif);border:0px; color:#853D0D; cursor:pointer;\" />\n");
            str.Append("</div>\n");
            str.Append("</div>\n");
            str.Append("</div>\n");
            str.Append("<!--浮层框架结束-->\n");

            str.Append("<script type=\"text/javascript\">\n");
            str.Append("ShowAlertDiv('" + alertStr + "');\n");
            str.Append("document.onkeydown=AlertDivKeyDown;\n");
            str.Append("</script>\n");

            page.ClientScript.RegisterStartupScript(page.GetType(), "alertDiv", str.ToString());
        }
        #endregion
    }
}
