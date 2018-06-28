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


namespace DigiPower.Onlinecol.Standard.Web.SystemManage {
    public partial class SignatureCompanyList : PageBase {
        T_FileList_BLL fileListBLL = new T_FileList_BLL();
        T_FileList_SignatureLog_BLL fileSignatureBLL = new T_FileList_SignatureLog_BLL();
        T_Company_BLL compBLL = new T_Company_BLL();
        T_Company_MDL companymdl = new T_Company_MDL();

        /// <summary>
        /// 总记录数
        /// </summary>
        int itemCount = 0;

        /// <summary>
        /// 每页页数
        /// </summary>
        int pageSize = SystemSet._PAGESIZE;

        /// <summary>
        /// 公司类型
        /// </summary>
        public string CompanyType = string.Empty;

        protected void Page_Load(object sender, EventArgs e) {
            CompanyType = DNTRequest.GetQueryString("CompanyType");
            Ajax.Utility.RegisterTypeForAjax(typeof(SignatureCompanyList));
            MyAddInit();

            if (!IsPostBack) {
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("txtCompanyName")))
                    txtCompanyName.Text = Server.UrlDecode(DNTRequest.GetQueryString("txtCompanyName"));

                BindGrid(AspNetPager.CurrentPageIndex);
            }
        }

        /// <summary>
        /// 绑定签章单位
        /// </summary>
        /// <param name="pageIndex"></param>
        protected void BindGrid(int pageIndex) {
            if (ViewState["CurrentPageIndex"] == null && Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex")) > 0) {
                pageIndex = Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex"));
                ViewState["CurrentPageIndex"] = pageIndex;
            } else {
                pageIndex = ConvertEx.ToInt(ViewState["CurrentPageIndex"]);
            }

            Hashtable ht = new Hashtable();
            ht.Add("CompanyType", SystemSet._SIGNATURECOMPANYINFO);
            if (txtCompanyName.Text.Trim().Length > 0)
                ht.Add("CompanyName", txtCompanyName.Text.Trim());

            if (PublicModel.isSuperAdmin()) {       //超级管理员
                ht.Add("Area_Code", Common.Session.GetSession("AREA_CODE"));
            } else {
                ht.Add("Area_Code", Common.Session.GetSession("OLD_AREA_CODE"));
                if (Common.Session.GetSessionInt("CompanyType") == SystemSet._SIGNATURECOMPANYINFO) {
                    ht.Add("CompanyID", Common.Session.GetSession("CompanyID"));
                }
            }

            DataTable dt = compBLL.GetListPaging(ht, pageSize, pageIndex, out itemCount);
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

        /// <summary>
        /// 获取已签章的文件相关数量,根据签章记录
        /// </summary>
        /// <param name="Signature_UserID"></param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public int GetSignatureCount(int Signature_UserID) {
            Hashtable ht = new Hashtable();
            ht.Add("Signature_UserID", Signature_UserID);
            return fileSignatureBLL.GetSignatureCount(ht);
        }

        /// <summary>
        /// 删除签章单位
        /// </summary>
        /// <param name="CompanyID"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public string DeleteCompany(string CompanyID) {
            string flag = SystemSet._RETURN_SUCCESS_VALUE;
            try {
                T_Company_MDL companyMDL = compBLL.GetModel(ConvertEx.ToInt(CompanyID));
                if (companyMDL != null) {
                    T_SystemInfo_BLL systemInfoBLL = new T_SystemInfo_BLL();
                    if (companyMDL != null && companymdl.CompanyType == SystemSet._SIGNATURECOMPANYINFO) {//只删除签章单位
                        compBLL.DeleteCompanyOther(CompanyID);

                        PublicModel.writeLog(SystemSet.EumLogType.DelData.ToString(), string.Concat("T_Company;key=", companyMDL.CompanyID,
                            ";CompanyCode=", companyMDL.CompanyCode, ";CompanyType=", companyMDL.CompanyType,
                            ";CompanyName=", companyMDL.CompanyName, ";删除签章单位及其关联表信息"));
                    } else {
                        flag = SystemSet._RETURN_FAILURE_VALUE + ":只删除签章单位!";
                    }
                }
            } catch (Exception ex) {
                flag = SystemSet._RETURN_FAILURE_VALUE + ex.Message;
                Common.LogUtil.Debug(this, "删除签章单位", ex);
            }
            return flag;
        }
    }
}