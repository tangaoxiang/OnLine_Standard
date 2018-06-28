using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace DigiPower.Onlinecol.Standard.Web.SystemManage
{
    public partial class MyWorkFlowList : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string SingleProjectID = "";
                if (Request["SingleProjectID"] != null)
                {
                    Session["SingleProjectID"] = Request["SingleProjectID"].ToString();
                }
                SingleProjectID = Session["SingleProjectID"].ToString();
                ctrlMyWorkFlowList1.CreatePage(SingleProjectID);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyWorkFlowAdd.aspx?Action=add&ID=0&sqlwhere = " + SqlWhere + "");
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.ctrlMyWorkFlowList1.MyID))
            {
                Response.Redirect("MyWorkFlowAdd.aspx?Action=edit&ID=" + this.ctrlMyWorkFlowList1.MyID + "&sqlwhere = " + SqlWhere + "");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.ctrlMyWorkFlowList1.MyID))
            {
                int MinWorkFlowID = 0;
                BLL.T_WorkFlowDefine_BLL defineBLL = new DigiPower.Onlinecol.Standard.BLL.T_WorkFlowDefine_BLL();
                DataSet ds = defineBLL.GetList("DoStatus=1");
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    MinWorkFlowID = Common.ConvertEx.ToInt(ds.Tables[0].Rows[0]["WorkFlowDefineID"].ToString());
                }
                if (Common.ConvertEx.ToInt(this.ctrlMyWorkFlowList1.MyID) > MinWorkFlowID)
                {
                    CBLL.WorkFlowManage cbll = new DigiPower.Onlinecol.Standard.CBLL.WorkFlowManage();
                    cbll.DeleteFlag(Common.ConvertEx.ToInt(this.ctrlMyWorkFlowList1.MyID), true);
                    Response.Redirect("MyWorkFlowList.aspx");
                }
            }
        }

        protected void Linkbutton1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.ctrlMyWorkFlowList1.MyID))
            {
                CBLL.WorkFlowManage cbll = new DigiPower.Onlinecol.Standard.CBLL.WorkFlowManage();
                cbll.DeleteFlag(Common.ConvertEx.ToInt(this.ctrlMyWorkFlowList1.MyID),false);
                Response.Redirect("MyWorkFlowList.aspx");
            }
        }
    }
}
