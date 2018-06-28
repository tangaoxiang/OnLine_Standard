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
using System.Text;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.Model;
using System.Collections.Generic;

//档案进度

namespace DigiPower.Onlinecol.Standard.Web.CompanyManage {
    public partial class ArchiveListPro : PageBase {
        T_SingleProject_BLL singleProjectBLL = new T_SingleProject_BLL();
        /// <summary>
        /// 总记录数
        /// </summary>
        int itemCount = 0;

        /// <summary>
        /// 每页页数
        /// </summary>
        int pageSize = SystemSet._PAGESIZE;

        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(ArchiveListPro));
            if (!this.IsPostBack) {
                ddlProjectType.DataBindEx(true);
                ddlChargeUserID.BindDataByCompanyID("", true, SystemSet._ROLECODE_CHARGEUSER,
                    Common.Session.GetSession("OLD_AREA_CODE"));

                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("ddlProjectType")))
                    ddlProjectType.SelectValue = Server.UrlDecode(DNTRequest.GetQueryString("ddlProjectType"));
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("kgsj1")))
                    kgsj1.Text = Server.UrlDecode(DNTRequest.GetQueryString("kgsj1"));
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("kgsj2")))
                    kgsj2.Text = Server.UrlDecode(DNTRequest.GetQueryString("kgsj2"));
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("jgsj1")))
                    jgsj1.Text = Server.UrlDecode(DNTRequest.GetQueryString("jgsj1"));
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("jgsj2")))
                    jgsj2.Text = Server.UrlDecode(DNTRequest.GetQueryString("jgsj2"));
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("txtGcbm")))
                    txtGcbm.Text = Server.UrlDecode(DNTRequest.GetQueryString("txtGcbm"));
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("txtGcmc")))
                    txtGcmc.Text = Server.UrlDecode(DNTRequest.GetQueryString("txtGcmc"));
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("txtGcdd")))
                    txtGcdd.Text = Server.UrlDecode(DNTRequest.GetQueryString("txtGcdd"));
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("ddlChargeUserID")))
                    ddlChargeUserID.SelectValue = Server.UrlDecode(DNTRequest.GetQueryString("ddlChargeUserID"));
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("txtghxkzh")))
                    txtghxkzh.Text = Server.UrlDecode(DNTRequest.GetQueryString("txtghxkzh"));
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("txtsgxkzh")))
                    txtsgxkzh.Text = Server.UrlDecode(DNTRequest.GetQueryString("txtsgxkzh"));

                BindGrid(AspNetPager.CurrentPageIndex);
            }
        }

        /// <summary>
        /// 根据不同身份获取工程
        /// </summary>
        private void BindGrid(int pageIndex) {
            StringBuilder strWhere = new StringBuilder();
            strWhere.Append(" 1=1 ");
            string CompanyID = "0";

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
            if (ddlProjectType.SelectValue != "" && ddlProjectType.SelectValue != "0")
                strWhere.Append(" AND a.ProjectType=(select SystemInfoCode from T_SystemInfo where SystemInfoID=" + ddlProjectType.SelectValue + ") ");

            if (PublicModel.isSuperAdmin()) {//管理员获取所有工程
                strWhere.Append(" and a.Area_Code like '" + ConvertEx.ToString(Session["AREA_CODE"]) + "%' ");
            } else if (PublicModel.isArchiveUser()) {//档案馆用户看自己的
                strWhere.Append(" and a.Area_Code = '" + ConvertEx.ToString(Session["OLD_AREA_CODE"]) + "' ");
            } else if (PublicModel.isLeader()) {//建设单位获取自己单位的
                CompanyID = Common.Session.GetSession("CompanyId");
            } else {
                CompanyID = "0";
                strWhere.Append(" AND EXISTS(select distinct SingleProjectID from T_SingleProjectCompany where ");
                strWhere.Append("CompanyID=" + Common.Session.GetSession("CompanyId") + " AND SingleProjectID=a.SingleProjectID )");
            }
            if (ViewState["CurrentPageIndex"] == null && Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex")) > 0) {
                pageIndex = Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex"));
                ViewState["CurrentPageIndex"] = pageIndex;
            } else {
                pageIndex = ConvertEx.ToInt(ViewState["CurrentPageIndex"]);
            }
            DataTable dt = singleProjectBLL.GetListPaging(ConvertEx.ToInt(CompanyID), strWhere.ToString(), pageSize, pageIndex, out itemCount); ;

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
            BindGrid(AspNetPager.CurrentPageIndex);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e) {
            BindGrid(1);
        }
    }
}