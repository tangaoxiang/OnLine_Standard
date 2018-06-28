using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DigiPower.Onlinecol.Standard.Web.CompanyManage
{
    public partial class ViewWaiGuanTu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BLL.T_SingleProject_PIC_BLL bll = new BLL.T_SingleProject_PIC_BLL();
                DataSet ds = bll.GetListBysId(Common.DNTRequest.GetInt("ID", 0));
                if (ds != null && ds.Tables.Count > 0)
                {
                    Image1.ImageUrl = ds.Tables[0].Rows[0]["PIC_PATH"].ToString();
                }
            }
        }
    }
}