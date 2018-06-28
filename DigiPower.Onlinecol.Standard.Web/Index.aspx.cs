using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DigiPower.Onlinecol.Standard.Web
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Abandon();
                Session.Clear();               
                System.Web.Security.FormsAuthentication.SignOut();

                Response.Redirect("UserLoginGather.aspx");                                                                                                         
            }
        }
    }
}