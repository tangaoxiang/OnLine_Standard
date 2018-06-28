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
using System.IO;
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.BLL;
using System.Collections.Generic;


namespace DigiPower.Onlinecol.Standard.Web.File
{
    public partial class LookCell : System.Web.UI.Page
    {
        public string cellFilePath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                T_CellTmp_MDL mdl = new T_CellTmp_BLL().GetModel(Convert.ToInt32(Common.DNTRequest.GetQueryString("ID")));
               // cellFilePath = Server.MapPath(mdl.FilePath);

                cellFilePath = "http://" + Request.ServerVariables["HTTP_HOST"] + "/" + mdl.FilePath.Substring(1).Replace(@"\", @"/");
 
            }
        }
    }
}
