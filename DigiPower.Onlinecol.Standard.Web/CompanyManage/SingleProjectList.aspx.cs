﻿using System;
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
using System.IO;

namespace DigiPower.Onlinecol.Standard.Web.SystemManage {
    public partial class SingleProjectList : PageBase {
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

        /// <summary>
        /// 工程类型
        /// </summary>
        public string ProjectType = string.Empty;

        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(SingleProjectList));
            ProjectType = DNTRequest.GetQueryString("ProjectType");

            if (!IsPostBack) {
                ddlProjectType.DataBindEx(true);
                ddlProjectType.SelectValue = ProjectType;
                ddlProjectType.Enabled = false;
                ddlChargeUserID.BindDataByCompanyID("", true, SystemSet._ROLECODE_CHARGEUSER, Common.Session.GetSession("OLD_AREA_CODE"));

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

                BindGridView(AspNetPager.CurrentPageIndex);
            }
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        /// <param name="pageIndex"></param>
        private void BindGridView(int pageIndex) {
            StringBuilder strWhere = new StringBuilder();
            strWhere.Append(" 1=1 ");
            string CompanyID = "";

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

            if (PublicModel.isSuperAdmin())  //超级管理员
            {
                CompanyID = "0";
                strWhere.Append(" and a.Area_Code like '" + ConvertEx.ToString(Session["AREA_CODE"]) + "%'");
            } else if (PublicModel.isArchiveUser())  //档案馆用户看自己的
            {
                CompanyID = "0";
                strWhere.Append(" and a.Area_Code like '" + ConvertEx.ToString(Session["OLD_AREA_CODE"]) + "%'");
            } else {
                if (Common.Session.GetSessionInt("CompanyType") == SystemSet._JSCOMPANYINFO)  //其他人只能看自己的   
                {
                    CompanyID = Common.Session.GetSession("CompanyId");
                } else {
                    CompanyID = "0";
                    strWhere.Append(" AND EXISTS(select SingleProjectID from T_SingleProjectCompany where ");
                    strWhere.Append("CompanyID=" + Common.Session.GetSession("CompanyId") + " AND SingleProjectID=a.SingleProjectID )");
                }
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

        /// <summary>
        /// 获取已登记等状态文件相关数量
        /// </summary>
        /// <param name="SingleProjectID"></param>
        /// <param name="CompanyID"></param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public int GetFileCount(int SingleProjectID) {
            Hashtable ht = new Hashtable();
            ht.Add("SingleProjectID", SingleProjectID);
            ht.Add("Unequal_Status", "0");
            return new T_FileList_BLL().GetFileCount(ht);
        }

        /// <summary>
        /// 删除工程
        /// </summary>
        /// <param name="archiveListCellRptID"></param>
        /// <param name="OrderIndex"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public string DeleteSingleProject(string SingleProjectID) {
            string flag = SystemSet._RETURN_SUCCESS_VALUE;
            try {
                T_SingleProject_MDL singleMDL = singleProjectBLL.GetModel(ConvertEx.ToInt(SingleProjectID));
                if (singleMDL != null) {
                    new T_Other_BLL().DeleteCompanyOther(SingleProjectID);

                    PublicModel.writeLog(SystemSet.EumLogType.DelData.ToString(), string.Concat("T_SingleProject;key=", SingleProjectID,
                        ";ProjectType=", singleMDL.ProjectType, ";gcbm=", singleMDL.gcbm, ";gcmc=", singleMDL.gcmc, ";删除工程及其关联表信息"));
                }
            } catch (Exception ex) {
                flag = SystemSet._RETURN_FAILURE_VALUE + ex.Message;
                Common.LogUtil.Debug(this, "删除工程", ex);
            }
            return flag;
        }

        /// <summary>
        /// 工程重新入库
        /// </summary>
        /// <param name="archiveListCellRptID"></param>
        /// <param name="OrderIndex"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public bool UpdateSingleProjectStatus(string SingleProjectID) {
            bool flag = false;
            T_SingleProject_MDL singleMDL = singleProjectBLL.GetModel(ConvertEx.ToInt(SingleProjectID));
            if (singleMDL != null && singleMDL.Status == 3722 && singleMDL.WorkFlow_DoStatus == PublicModel.getWorkFlowIdByWorkFlowCode(SystemSet.EumWorkFlowCode.IMPORT_TO.ToString())) {  //工程已入库,工程流程处于 移交入库
                singleMDL.Status = 3721;
                singleProjectBLL.Update(singleMDL);
                flag = true;

                PublicModel.writeLog(SystemSet.EumLogType.UpdData.ToString(), string.Concat("T_SingleProject;key=", SingleProjectID,
                    ";gcbm=", singleMDL.gcbm, ";gcmc=", singleMDL.gcmc, ";工程重新入库"));
            }
            return flag;
        }
    }
}