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

namespace DigiPower.Onlinecol.Standard.Web.File
{
    public partial class EditFileTitle : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MyAddInit();
            if (!IsPostBack)
            {
                DigiPower.Onlinecol.Standard.BLL.T_EFile_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_EFile_BLL();
                DigiPower.Onlinecol.Standard.Model.T_EFile_MDL model = bll.GetModel(Common.ConvertEx.ToInt(ID));
                txtTitle.Text = model.Title;
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ID))
            {
                DigiPower.Onlinecol.Standard.BLL.T_EFile_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_EFile_BLL();
                DigiPower.Onlinecol.Standard.Model.T_EFile_MDL model = bll.GetModel(Common.ConvertEx.ToInt(ID));
                model.Title = this.txtTitle.Text;
                bll.Update(model);
                ClientScript.RegisterStartupScript(Page.GetType(), "close", "<script type='text/javascript'>reloadopener();</script>");
            }
        }
    }
}