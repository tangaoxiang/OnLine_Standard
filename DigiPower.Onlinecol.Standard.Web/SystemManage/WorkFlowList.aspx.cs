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
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.Model;
namespace DigiPower.Onlinecol.Standard.Web.SystemManage {
    public partial class WorkFlowList : PageBase {
        T_WorkFlow_BLL workFlowBLL = new T_WorkFlow_BLL();

        /// <summary>
        /// 总记录数
        /// </summary>
        int itemCount = 0;

        /// <summary>
        /// 每页页数
        /// </summary>
        int pageSize = SystemSet._PAGESIZE;

        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(WorkFlowList));
            MyAddInit();
            if (!IsPostBack) {
                ddlCompany.DataBindEx();

                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("ddlCompany")))
                    ddlCompany.SelectValue = Server.UrlDecode(DNTRequest.GetQueryString("ddlCompany"));

                BindGridView(AspNetPager.CurrentPageIndex);
            }
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindGridView(int pageIndex) {
            string sqlWhere = " b.CompanyType=" + SystemSet._ARCHIVE;
            if (PublicModel.isSuperAdmin())
                sqlWhere += " And b.Area_Code like '%" + Common.Session.GetSession("OLD_AREA_CODE") + "%'";
            if (PublicModel.isArchiveUser())
                sqlWhere += " And b.Area_Code like '%" + Common.Session.GetSession("AREA_CODE") + "%'";
            if (!String.IsNullOrWhiteSpace(ddlCompany.SelectValue))
                sqlWhere += " And a.CompanyID=" + ddlCompany.SelectValue + "";

            if (ViewState["CurrentPageIndex"] == null && Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex")) > 0) {
                pageIndex = Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex"));
                ViewState["CurrentPageIndex"] = pageIndex;
            } else {
                pageIndex = ConvertEx.ToInt(ViewState["CurrentPageIndex"]);
            }

            DataTable dt = workFlowBLL.GetListPaging(sqlWhere, pageSize, pageIndex, out itemCount);
            AspNetPager.AlwaysShow = true;
            AspNetPager.PageSize = pageSize;

            AspNetPager.RecordCount = itemCount;
            AspNetPager.CurrentPageIndex = pageIndex;

            rpData.DataSource = dt;
            rpData.DataBind();
        }

        /// <summary>
        /// 删除流程
        /// </summary>
        /// <param name="WorkFlowID"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public bool DelWrokFlow(string WorkFlowID) {
            bool flag = false;
            try {   
                T_WorkFlow_MDL workFlowMDL = workFlowBLL.GetModel(ConvertEx.ToInt(WorkFlowID));
                if (workFlowMDL != null) {
                    PublicModel.writeLog(SystemSet.EumLogType.DelData.ToString(), string.Concat("T_WorkFlow;key=", workFlowMDL.WorkFlowID,
                        ";CompanyID=", workFlowMDL.CompanyID, ";WorkFlowCode=", workFlowMDL.WorkFlowCode, ";WorkFlowName=", workFlowMDL.WorkFlowName));
                }

                CBLL.WorkFlowManage cbll = new DigiPower.Onlinecol.Standard.CBLL.WorkFlowManage();
                cbll.Delete(Common.ConvertEx.ToInt(WorkFlowID));
                flag = true;    
            } catch (Exception ex) {
                Common.LogUtil.Debug(this, "流程删除失败", ex);
            }
            return flag;
        }

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e) {
            this.BindGridView(1);
        }

        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager_PageChanged(object sender, EventArgs e) {
            ViewState["CurrentPageIndex"] = AspNetPager.CurrentPageIndex;
            BindGridView(AspNetPager.CurrentPageIndex);
        }
    }
}
