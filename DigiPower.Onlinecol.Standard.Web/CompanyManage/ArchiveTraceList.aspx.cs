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

//工程状态动态跟踪

namespace DigiPower.Onlinecol.Standard.Web.ArchiveTrace {
    public partial class ArchiveTraceList : PageBase {
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
            Ajax.Utility.RegisterTypeForAjax(typeof(ArchiveTraceList));
            if (!this.IsPostBack) {
                ddl_WorkFlowName.DataBindEx(Common.Session.GetSession("OLD_AREA_CODE"), false);
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
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("ddl_WorkFlowName")))
                    ddl_WorkFlowName.SelectValue = Server.UrlDecode(DNTRequest.GetQueryString("ddl_WorkFlowName"));

                BindGrid(AspNetPager.CurrentPageIndex);
            }
        }

        /// <summary>
        /// 绑定列表数据
        /// </summary>
        /// <param name="pageIndex"></param>
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
            if (ddl_WorkFlowName.SelectValue != "" && ddl_WorkFlowName.SelectValue != "0")
                strWhere.Append(" AND d.WorkFlowID =" + ddl_WorkFlowName.SelectValue + " ");

            if (PublicModel.isSuperAdmin()) {//超级管理员看全部    
                strWhere.Append(" and a.Area_Code like '" + ConvertEx.ToString(Session["AREA_CODE"]) + "%' ");
            } else if (PublicModel.isArchiveUser()) {//档案馆的人看全部部分     
                strWhere.Append("and a.Area_Code = '" + ConvertEx.ToString(Session["OLD_AREA_CODE"]) + "' ");
            } else if (PublicModel.isLeader()) {//工程管理员(建设单位)也看全部
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
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e) {
            BindGrid(1);
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
        /// 判断是否可以打印1书2证
        /// </summary>
        /// <param name="singleProjectID"></param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public bool CheckSingleWorkFlowStatus(string workFlowID, string workFlowCode) {
            if (ConvertEx.ToInt(workFlowID) >= PublicModel.getWorkFlowIdByWorkFlowCode(workFlowCode))
                return true;
            else
                return false;
        }

        /// <summary>
        /// 根据工程ID 将报表导出PDF,注意:报表必须预先在T_Report做出记录
        /// </summary>
        /// <param name="SingleProjectID">工程ID</param>
        /// <param name="ReportCode">报表类型</param>
        /// <param name="DelOldReportPDF">是否删除已生成的PDF</param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public string ReportExportPDF(string singleProjectID, string reportCode, bool delOldReportPDF) {
            return ReportPDF.ReportExportPDF(singleProjectID, reportCode, delOldReportPDF);
        }

        /// <summary>
        /// 判断某个工程的下的报表PDF是否存在
        /// </summary>
        /// <param name="singleProjectID"></param>
        /// <param name="reportCode"></param>
        /// <param name="delOldReportPDF"></param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public bool CheckExistsReportPDF(string singleProjectID, string reportCode) {
            return ReportPDF.CheckExistsReportPDF(singleProjectID, reportCode);
        }
    }
}