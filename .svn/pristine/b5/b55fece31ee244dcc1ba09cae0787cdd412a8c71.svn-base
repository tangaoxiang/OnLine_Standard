using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//窗口接收,业务审核,领导签字审核意见,针对案卷

namespace DigiPower.Onlinecol.Standard.Web.WorkFlow
{
    public partial class ArchiveCheck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {  
            if (!this.IsPostBack)
            {
                txtDoUserName.Text = Common.Session.GetSession("UserName");
                txtDoDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            T_WorkFlowDoResult_BLL doResultBLL = new T_WorkFlowDoResult_BLL();
            string[] ArchiveIDS = DNTRequest.GetQueryString("ArchiveIDS").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string ArchiveID in ArchiveIDS)
            {
                T_WorkFlowDoResult_MDL doResultMDL = new T_WorkFlowDoResult_MDL();
                doResultMDL.ArchiveID = ConvertEx.ToInt(ArchiveID);
                doResultMDL.SingleProjectID = DNTRequest.GetQueryInt("SingleProjectID", 0);
                doResultMDL.WorkFlowID = DNTRequest.GetQueryInt("workFlowID", 0);
                doResultMDL.DoUserID = Common.ConvertEx.ToInt(Common.Session.GetSessionInt("UserID"));
                doResultMDL.DoDateTime = System.DateTime.Now;
                doResultMDL.DoResult = ddlDoResult.SelectedValue;
                doResultMDL.DoRemark = DoRemark.Text.Trim();
                doResultBLL.Add(doResultMDL);
            }
            Common.MessageBox.CloseLayerOpenWeb(this.Page);
        }
    }
}