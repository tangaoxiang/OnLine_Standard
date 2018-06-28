using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.Model;
using System.Xml;

//工程文件管理,安监,质监,检测等单位用

namespace DigiPower.Onlinecol.Standard.Web.SystemManage {
    public partial class SingleProjectAndFileList : PageBase {
        T_SingleProject_BLL singleProjectBLL = new T_SingleProject_BLL();
        T_SingleProjectCompany_BLL singProComBll = new T_SingleProjectCompany_BLL();
        T_SingleProjectUser_BLL singProUserBll = new T_SingleProjectUser_BLL();
        T_FileList_BLL fileBLL = new T_FileList_BLL();

        /// <summary>
        /// 总记录数
        /// </summary>
        int itemCount = 0;

        /// <summary>
        /// 每页页数
        /// </summary>
        int pageSize = SystemSet._PAGESIZE;

        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(SingleProjectAndFileList));

            if (!IsPostBack) {
                ddlProjectType.DataBindEx(true);
                ddlChargeUserID.BindDataByCompanyID("", true, SystemSet._ROLECODE_CHARGEUSER, Common.Session.GetSession("OLD_AREA_CODE"));
                BindGridView(1);
            }
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        /// <param name="pageIndex"></param>
        private void BindGridView(int pageIndex) {
            StringBuilder strWhere = new StringBuilder();
            strWhere.Append(" 1=1 ");
            if (ddlProjectType.SelectValue != "" && ddlProjectType.SelectValue != "0")
                strWhere.Append(" AND a.ProjectType=(select SystemInfoCode from T_SystemInfo where SystemInfoID=" + ddlProjectType.SelectValue + ") ");
            if (kgsj1.Text.Trim().Length > 0)
                strWhere.Append(" AND a.kgsj>='" + kgsj1.Text.Trim() + " 00:00:00.00 ' ");
            if (kgsj2.Text.Trim().Length > 0)
                strWhere.Append(" AND a.kgsj<='" + kgsj2.Text.Trim() + " 23:59:59.99' ");
            if (jgsj1.Text.Trim().Length > 0)
                strWhere.Append(" AND a.jgsj>='" + jgsj1.Text.Trim() + " 00:00:00.00 ' ");
            if (jgsj2.Text.Trim().Length > 0)
                strWhere.Append(" AND a.jgsj<='" + jgsj2.Text.Trim() + " 23:59:59.99' ");
            if (txtGcbm.Text.Trim().Length > 0)
                strWhere.Append(" AND a.gcbm like '%" + txtGcbm.Text.Trim() + "%' ");
            if (txtGcmc.Text.Trim().Length > 0)
                strWhere.Append(" AND a.gcmc like '%" + txtGcmc.Text.Trim() + "%' ");
            if (txtGcdd.Text.Trim().Length > 0)
                strWhere.Append(" AND a.gcdd like '%" + txtGcdd.Text.Trim() + "%' ");
            if (txtghxkzh.Text.Trim().Length > 0)
                strWhere.Append(" AND a.ghxkzh like '%" + txtghxkzh.Text.Trim() + "%' ");
            if (txtsgxkzh.Text.Trim().Length > 0)
                strWhere.Append(" AND a.sgxkzh like '%" + txtsgxkzh.Text.Trim() + "%' ");
            if (ddlChargeUserID.SelectValue != "" && ddlChargeUserID.SelectValue != "0")
                strWhere.Append(" AND a.ChargeUserID= " + ddlChargeUserID.SelectValue);

            strWhere.Append(" AND EXISTS(select SingleProjectID from T_SingleProjectCompany where ");
            strWhere.Append("CompanyID=" + Common.Session.GetSession("CompanyId") + " AND SingleProjectID=a.SingleProjectID )");

            DataTable dt = singleProjectBLL.GetListPaging(0, strWhere.ToString(), pageSize, pageIndex, out itemCount); ;
            AspNetPager.AlwaysShow = true;
            AspNetPager.PageSize = pageSize;

            AspNetPager.RecordCount = itemCount;
            AspNetPager.CurrentPageIndex = pageIndex;

            rpData.DataSource = dt;
            rpData.DataBind();
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager_PageChanged(object sender, EventArgs e) {
            ViewState["CurrentPageIndex"] = AspNetPager.CurrentPageIndex;
            BindGridView(AspNetPager.CurrentPageIndex);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e) {
            BindGridView(1);
        }
    }
}