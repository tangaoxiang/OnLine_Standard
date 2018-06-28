using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DigiPower.Onlinecol.Standard.Web.WorkFlow
{
    public partial class ArchiveCheckList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                T_WorkFlowDoResult_BLL doResultBLL = new T_WorkFlowDoResult_BLL();

                string strWhere = "SingleProjectID=" + DNTRequest.GetQueryString("SingleProjectID");
                strWhere += "and ArchiveID=" + DNTRequest.GetQueryString("ArchiveID");
                DataTable dt = doResultBLL.GetList(strWhere, "WorkFlowDoResultID asc").Tables[0];

                rpData.DataSource = dt;
                rpData.DataBind();
            }
        }
    }
}