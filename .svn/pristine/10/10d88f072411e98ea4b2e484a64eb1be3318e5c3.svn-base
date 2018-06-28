using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;

namespace DigiPower.Onlinecol.Standard.Web.CommonCtrl
{
    public partial class ctrlFoot : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label1.Text = Session["UserName"].ToString();
                Label2.Text = Session["CompanyName"].ToString() + "(" + Session["CompanyTypeName"] + ")";

                BLL.T_Question_BLL questionBLL = new DigiPower.Onlinecol.Standard.BLL.T_Question_BLL();
                DataSet ds1 = questionBLL.GetList("ReadFlag=0 AND ToUserID=" + Common.Session.GetSession("UserID"));
                DataSet ds2 = questionBLL.GetList("ToUserID=" + Common.Session.GetSession("UserID"));
                //Label3.Text = "<a href=aa.aspx>" + ds1.Tables[0].Rows.Count + "/" + ds2.Tables[0].Rows.Count + "</a>";
            }
        }
    }
}