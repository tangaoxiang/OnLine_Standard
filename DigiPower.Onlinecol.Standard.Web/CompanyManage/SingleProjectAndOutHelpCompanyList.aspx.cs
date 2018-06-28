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
using System.IO;

//工程关联施工,监理单位

namespace DigiPower.Onlinecol.Standard.Web.SystemManage {
    public partial class SingleProjectAndOutHelpCompanyList : PageBase {
        T_SingleProject_BLL singleProjectBLL = new T_SingleProject_BLL();
        T_SingleProjectCompany_BLL singProComBll = new T_SingleProjectCompany_BLL();
        T_SingleProjectUser_BLL singProUserBll = new T_SingleProjectUser_BLL();
        T_FileList_BLL fileBLL = new T_FileList_BLL();
        T_FileList_SignatureLog_BLL fileSignatureBLL = new T_FileList_SignatureLog_BLL();

        /// <summary>
        /// 总记录数
        /// </summary>
        int itemCount = 0;

        /// <summary>
        /// 每页页数
        /// </summary>
        int pageSize = SystemSet._PAGESIZE;

        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(SingleProjectAndOutHelpCompanyList));
            if (!IsPostBack) {
                ddlProjectType.DataBindEx(true);
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
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("txtghxkzh")))
                    txtghxkzh.Text = Server.UrlDecode(DNTRequest.GetQueryString("txtghxkzh"));
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("txtsgxkzh")))
                    txtsgxkzh.Text = Server.UrlDecode(DNTRequest.GetQueryString("txtsgxkzh"));

                BindGridView(AspNetPager.CurrentPageIndex);
            }
        }

        /// <summary>
        /// 绑定签章单位相关信息
        /// </summary>
        /// <param name="pageIndex"></param>
        private void BindGridView(int pageIndex) {
            Hashtable ht = new Hashtable();

            if (ddlProjectType.SelectValue != "" && ddlProjectType.SelectValue != "0")
                ht.Add("ProjectType", ddlProjectType.SelectValue);
            if (kgsj1.Text.Trim().Length > 0)
                ht.Add("kgsj", kgsj1.Text.Trim());
            if (kgsj2.Text.Trim().Length > 0)
                ht.Add("kgsj2", kgsj2.Text.Trim());
            if (jgsj1.Text.Trim().Length > 0)
                ht.Add("jgsj", jgsj1.Text.Trim());
            if (jgsj2.Text.Trim().Length > 0)
                ht.Add("jgsj2", jgsj2.Text.Trim());
            if (txtGcbm.Text.Trim().Length > 0)
                ht.Add("gcbm", txtGcbm.Text.Trim());
            if (txtGcmc.Text.Trim().Length > 0)
                ht.Add("gcmc", txtGcmc.Text.Trim());
            if (txtGcdd.Text.Trim().Length > 0)
                ht.Add("gcdd", txtGcdd.Text.Trim());
            if (txtghxkzh.Text.Trim().Length > 0)
                ht.Add("ghxkzh", txtghxkzh.Text.Trim());
            if (txtsgxkzh.Text.Trim().Length > 0)
                ht.Add("sgxkzh", txtsgxkzh.Text.Trim());
            if (ddlChargeUserID.SelectValue != "" && ddlChargeUserID.SelectValue != "0")
                ht.Add("ChargeUserID", ddlChargeUserID.SelectValue);

            if (PublicModel.isSuperAdmin())        //超级管理员    Area_Code
            {
                //ht.Add("NotInCompanyType", SystemSet._ARCHIVE);
                ht.Add("InCompanyType", string.Concat(Common.Session.GetSession("CompanyType"), ",", SystemSet._OUTHELPCOMPANYINFO, ",", SystemSet._JSCOMPANYINFO));
                ht.Add("Area_Code", Common.Session.GetSession("AREA_CODE"));
            } else if (PublicModel.isArchiveUser())  //档案馆用户看自己的
            {
                //ht.Add("NotInCompanyType", SystemSet._ARCHIVE);
                ht.Add("InCompanyType", string.Concat(Common.Session.GetSession("CompanyType"), ",", SystemSet._OUTHELPCOMPANYINFO, ",", SystemSet._JSCOMPANYINFO));
                ht.Add("Area_Code", Common.Session.GetSession("OLD_AREA_CODE"));
            } else                                  //建设单位看自己相关的,监理,施工无权限
            {
                ht.Add("CompanyId", Common.Session.GetSession("CompanyId"));
                if (PublicModel.isLeader() || PublicModel.isSgCompany() || PublicModel.isJlCompany()) {
                    ht.Add("InCompanyType", string.Concat(Common.Session.GetSession("CompanyType"), ",", SystemSet._OUTHELPCOMPANYINFO));
                }
            }

            if (ViewState["CurrentPageIndex"] == null && Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex")) > 0) {
                pageIndex = Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex"));
                ViewState["CurrentPageIndex"] = pageIndex;
            } else {
                pageIndex = ConvertEx.ToInt(ViewState["CurrentPageIndex"]);
            }

            DataTable dt = singleProjectBLL.GetListPaging(ht, pageSize, pageIndex, out itemCount); ;
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
        /// 取消外协单位关联. 暂时取消关联没有做任何限制
        /// </summary>
        /// <param name="SingleProjectID"></param>
        /// <param name="UserID"></param>
        /// <param name="CompanyID"></param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public string CancelHookUpCompanyAndUser(string SingleProjectID, int UserID, int CompanyID) {
            string flag = SystemSet._RETURN_SUCCESS_VALUE;
            try {
                singProComBll.DeleteSingleProjectCompany(SingleProjectID, CompanyID);
                singProUserBll.DeleteSingleProjectUser(SingleProjectID, UserID.ToString());
            } catch (Exception ex) {
                flag = SystemSet._RETURN_FAILURE_VALUE + ex.Message;
                Common.LogUtil.Debug(this, "签章单位取消关联", ex);
            }
            return flag;
        }
    }
}