using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.Common;

namespace DigiPower.Onlinecol.Standard.Web.CommonCtrl
{
    public partial class ctrlProjectBaseInfo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void DataBindEx(string ProjectID)
        {
            DataSet dspro = (new T_SingleProject_BLL()).GetListUnionProjectTypeName(" SingleProjectID=" + ProjectID);
            if (dspro.Tables.Count > 0 && dspro.Tables[0].Rows.Count > 0)
            {
                gcbm.Text = dspro.Tables[0].Rows[0]["gcbm"].ToString();
                gcmc.Text = dspro.Tables[0].Rows[0]["gcmc"].ToString();
                gcdd.Text = dspro.Tables[0].Rows[0]["gcdd"].ToString();
                ProjectTypeName.Text = dspro.Tables[0].Rows[0]["ProjectTypeName"].ToString();
                ProjectTypeName.Text += "<input type=\"hidden\" id=\"HidProjectType\" value=\"" + dspro.Tables[0].Rows[0]["ProjectType"].ToString() + "\" />";
            }
        }
    }
}