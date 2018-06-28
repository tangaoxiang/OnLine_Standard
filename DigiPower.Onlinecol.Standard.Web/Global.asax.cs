using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;


namespace DigiPower.Onlinecol.Standard.Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e) {

        }

        protected void Session_Start(object sender, EventArgs e) {

        }

        protected void Application_BeginRequest(object sender, EventArgs e) {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e) {

        }

        protected void Application_Error(object sender, EventArgs e) {
            //记录系统出现的异常 数据库和log4net      
            Exception LastError = Server.GetLastError();
            String ErrMessage = LastError.ToString();
            String Message = "Url " + Request.Path + " Error: " + ErrMessage;                            

            PublicModel.writeLog(SystemSet.EumLogType.ErrorBug.ToString(), Message); 
            Common.LogUtil.Error(this, Message);
        }

        protected void Session_End(object sender, EventArgs e) {

        }

        protected void Application_End(object sender, EventArgs e) {

        }
    }
}