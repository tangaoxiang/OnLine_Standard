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
using System.Collections.Generic;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.Web.CommonCtrl;
using System.Xml;

//入库档案查询

namespace DigiPower.Onlinecol.Standard.Web.CompanyManage {
    public partial class AdvSearch : PageBase {
        T_SingleProject_BLL singleProjectBLL = new T_SingleProject_BLL();
        /// <summary>
        /// 总记录数
        /// </summary>
        int itemCount = 0;

        /// <summary>
        /// 每页页数
        /// </summary>
        int pageSize = SystemSet._PAGESIZE;

        /// <summary>
        /// 工程类型
        /// </summary>
        public string ProjectType = string.Empty;

        protected void Page_Load(object sender, EventArgs e) {
            ProjectType = DNTRequest.GetQueryString("Archive_Form");
            if (!IsPostBack) {
                ddlProjectType.DataBindEx(true);
                ddlProjectType.SelectValue = ProjectType;
                ddlProjectType.Enabled = false;
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
                ViewState["workFlowID"] = PublicModel.getWorkFlowIdByWorkFlowCode(SystemSet.EumWorkFlowCode.IMPORT_TO.ToString());

                BindGridView(AspNetPager.CurrentPageIndex);
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e) {
            BindGridView(1);
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        /// <param name="pageIndex"></param>
        private void BindGridView(int pageIndex) {
            StringBuilder strWhere = new StringBuilder();
            strWhere.Append(" 1=1 AND Status>=3721 AND WorkFlow_DoStatus=" + ViewState["workFlowID"].ToString());
            strWhere.Append(" AND ProjectType in (select SystemInfoCode from T_SystemInfo where SystemInfoID in(" + ProjectType + ")) ");

            if (kgsj1.Text.Trim().Length > 0)
                strWhere.Append(" AND kgsj>='" + kgsj1.Text.Trim() + " 00:00:00.00 ' ");
            if (kgsj2.Text.Trim().Length > 0)
                strWhere.Append(" AND kgsj<='" + kgsj2.Text.Trim() + " 23:59:59.99' ");
            if (jgsj1.Text.Trim().Length > 0)
                strWhere.Append(" AND jgsj>='" + jgsj1.Text.Trim() + " 00:00:00.00 ' ");
            if (jgsj2.Text.Trim().Length > 0)
                strWhere.Append(" AND jgsj<='" + jgsj2.Text.Trim() + " 23:59:59.99' ");
            if (txtGcbm.Text.Trim().Length > 0)
                strWhere.Append(" AND gcbm like '%" + txtGcbm.Text.Trim() + "%' ");
            if (txtGcmc.Text.Trim().Length > 0)
                strWhere.Append(" AND gcmc like '%" + txtGcmc.Text.Trim() + "%' ");
            if (txtGcdd.Text.Trim().Length > 0)
                strWhere.Append(" AND gcdd like '%" + txtGcdd.Text.Trim() + "%' ");
            if (txtghxkzh.Text.Trim().Length > 0)
                strWhere.Append(" AND ghxkzh like '%" + txtghxkzh.Text.Trim() + "%' ");
            if (txtsgxkzh.Text.Trim().Length > 0)
                strWhere.Append(" AND sgxkzh like '%" + txtsgxkzh.Text.Trim() + "%' ");
            if (ddlChargeUserID.SelectValue != "" && ddlChargeUserID.SelectValue != "0")
                strWhere.Append(" AND ChargeUserID= " + ddlChargeUserID.SelectValue);

            if (PublicModel.isSuperAdmin()) {//超级管理员
                strWhere.Append(" AND Area_Code like '" + ConvertEx.ToString(Session["AREA_CODE"]) + "%'");
            } else if (PublicModel.isArchiveUser()) {//档案馆用户看自己的
                strWhere.Append(" AND Area_Code like '" + ConvertEx.ToString(Session["OLD_AREA_CODE"]) + "%'");
            } else if (PublicModel.isLeader()) {//工程管理员(建设单位)也看全部
                strWhere.Append(" AND ConstructionProjectID in (select ConstructionProjectID from T_Construction_Project where CompanyID=" + Common.Session.GetSession("CompanyID") + ")");
            }

            if (ViewState["CurrentPageIndex"] == null && Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex")) > 0) {
                pageIndex = Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex"));
                ViewState["CurrentPageIndex"] = pageIndex;
            } else {
                pageIndex = ConvertEx.ToInt(ViewState["CurrentPageIndex"]);
            }
            DataTable dt = singleProjectBLL.GetListPaging(strWhere.ToString(), pageSize, pageIndex, out itemCount); ;

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
    }
}
