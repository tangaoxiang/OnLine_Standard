using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.CBLL;
using System.Data;

namespace DigiPower.Onlinecol.Standard.Web {
    public partial class SignatureProjectList : PageBase {
        /// <summary>
        /// 流程ID
        /// </summary>
        public int workFlowID = 0;

        /// <summary>
        /// 流程编号
        /// </summary>
        public string workFlowCode = string.Empty;

        /// <summary>
        /// 总记录数
        /// </summary>
        int itemCount = 0;

        /// <summary>
        /// 每页页数
        /// </summary>
        int pageSize = SystemSet._PAGESIZE;

        T_WorkFlowDefine_BLL flowDefineBLL = new T_WorkFlowDefine_BLL();

        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(MyTaskList));
            if (!IsPostBack) {
                workFlowID = PublicModel.getWorkFlowIdByWorkFlowCode(SystemSet.EumWorkFlowCode.FILEREG.ToString());
                BindGrid(1);
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="WorkFlowID"></param>
        /// <param name="pageInde"></param>
        private void BindGrid(int pageIndex) {
            T_WorkFlow_BLL wfBLL = new T_WorkFlow_BLL();
            T_WorkFlow_MDL wfMDL = wfBLL.GetModel(workFlowID);
            workFlowCode = wfMDL.WorkFlowCode;

            string sqlWhere = string.Empty;

            if (Common.ConvertEx.ToBool(Common.Session.GetSession("SuperAdmin")) == true) {//管理员管理员获取所有工程
                sqlWhere = " AND AREA_CODE LIKE '" + Session["AREA_CODE"].ToString() + "%'";//加区域了。
            } else if (Common.ConvertEx.ToBool(Common.Session.GetSession("SuperAdmin")) == false && Common.Session.GetSession("IsCompany") == false.ToString().ToLower()) {//档案馆用户看自己的
                sqlWhere = " AND AREA_CODE LIKE '" + Session["OLD_AREA_CODE"].ToString() + "%'";//加区域了。
            }

            if (!String.IsNullOrEmpty(gcmc.Text)) {
                sqlWhere += " AND gcmc like '%" + gcmc.Text + "%'";
            }
            if (!String.IsNullOrEmpty(gcbm.Text)) {
                sqlWhere += " AND gcbm like '%" + gcbm.Text + "%'";
            }

            DataTable dt = null;
            if (Common.Session.GetSession("SuperAdmin").ToLower() == "true")
                dt = flowDefineBLL.GetListPaging(workFlowID.ToString(), false, "", "", sqlWhere, pageSize, pageIndex, out itemCount);
            else
                dt = flowDefineBLL.GetListPaging(workFlowID.ToString(), Common.Session.GetSessionBool("IsCompany"),
                    Common.Session.GetSession("RoleID"), Common.Session.GetSession("UserID"), sqlWhere, pageSize, pageIndex, out itemCount);

            AspNetPager.AlwaysShow = true;
            AspNetPager.PageSize = pageSize;

            AspNetPager.RecordCount = itemCount;

            gvData.DataSource = dt;
            gvData.DataBind();
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager_PageChanged(object sender, EventArgs e) {
            BindGrid(AspNetPager.CurrentPageIndex);
        }
    }
}