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
using DigiPower.Onlinecol.Standard.CBLL;
using DigiPower.Onlinecol.Standard.Model;

//关联施工,监理单位

namespace DigiPower.Onlinecol.Standard.Web.CompanyManage {
    public partial class ProjectRelevanceUser : PageBase {
        T_Company_BLL companyBLL = new T_Company_BLL();
        UserOperate userOper = new UserOperate();
        T_SingleProject_BLL singleBLL = new T_SingleProject_BLL();

        /// <summary>
        /// 总记录数
        /// </summary>
        int itemCount = 0;

        /// <summary>
        /// 每页页数
        /// </summary>
        int pageSize = 10;

        /// <summary>
        /// 工程ID
        /// </summary>
        public string SingleProjectID = string.Empty;

        /// <summary>
        /// 工程类型
        /// </summary>
        public string ProjectType = string.Empty;

        protected void Page_Load(object sender, EventArgs e) {
            SingleProjectID = DNTRequest.GetQueryString("SingleProjectID");
            ProjectType = DNTRequest.GetQueryString("ProjectType");

            Ajax.Utility.RegisterTypeForAjax(typeof(ProjectRelevanceUser));
            MyAddInit();
            if (!IsPostBack) {
                ddlCompanyType.DataBindEx(Common.Session.GetSessionInt("MyParentID"), true, string.Concat(SystemSet._ARCHIVE.ToString(), ",",
                    SystemSet._JSCOMPANYINFO));
                BindGridView(1);
            }
        }

        /// <summary>
        /// 列表数据绑定
        /// </summary>
        /// <param name="pageIndex"></param>
        private void BindGridView(int pageIndex) {
            Hashtable ht = new Hashtable();
            ht.Add("InCompanyType", string.Concat(SystemSet._SGCOMPANYINFO, ",", SystemSet._JLCOMPANYINFO));
            ht.Add("Area_Code", Common.Session.GetSession("OLD_AREA_CODE"));
            ht.Add("NotINSingleProjectID", SingleProjectID);

            if (txtCompanyName.Text.Trim().Length > 0)
                ht.Add("CompanyName", txtCompanyName.Text.Trim());
            if (txtUserName.Text.Trim().Length > 0)
                ht.Add("UserName", txtUserName.Text.Trim());
            if (ddlCompanyType.SelectValue != "" && ddlCompanyType.SelectValue != "0")
                ht.Add("CompanyType", ddlCompanyType.SelectValue);

            DataTable dt = companyBLL.GetListPaging(ht, pageSize, pageIndex, out itemCount);
            AspNetPager.AlwaysShow = true;
            AspNetPager.PageSize = pageSize;

            AspNetPager.RecordCount = itemCount;
            AspNetPager.CurrentPageIndex = pageIndex;

            rpData.DataSource = dt;
            rpData.DataBind();
        }

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e) {
            BindGridView(1);
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
        /// 工程相关表关联(工程用户表,工程公司表)
        /// </summary>
        /// <param name="SingleProjectID"></param>
        /// <param name="UserID"></param>
        /// <param name="RoleID"></param>
        /// <param name="CompanyID"></param>
        /// <param name="ProjectType"></param>
        /// <param name="UserName"></param>
        /// <param name="CompanyType"></param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public string HookUpCompanyAndUser(int SingleProjectID, int UserID, int RoleID,
            int CompanyID, string ProjectType, string UserName, string CompanyType) {
            string flag = SystemSet._RETURN_SUCCESS_VALUE;
            try {
                string iSignaturePdf = "0";     //文件是否需要签章
                string iSignatureWorkFlow = "0";//是否按签章流程签章
                if (ConvertEx.ToBool(SystemSet._ISIGNATUREPDF)) {
                    iSignaturePdf = "1";
                    iSignatureWorkFlow = "1";
                }

                PublicModel.AddSingleProjectUser(SingleProjectID, RoleID, UserID);                                             //加入到工程用户表中去
                PublicModel.AddSingleProjectCompany(SingleProjectID, CompanyID);                                               //加入到工程公司表中去
                userOper.CopyFileList(CompanyID, UserID, UserName, SingleProjectID, ProjectType, CompanyType, iSignaturePdf, iSignatureWorkFlow);  //用户添加归档目录

                #region 关联更新工程表的 施工,监理单位信息
                T_SingleProject_MDL singleMDL = singleBLL.GetModel(SingleProjectID);
                T_Company_MDL companyMDL = companyBLL.GetModel(CompanyID);
                if (singleMDL != null && companyMDL != null) {
                    if (ConvertEx.ToInt(CompanyType) == SystemSet._SGCOMPANYINFO)
                        singleMDL.sgdw = companyMDL.CompanyName;
                    else if (ConvertEx.ToInt(CompanyType) == SystemSet._JLCOMPANYINFO)
                        singleMDL.jldw = companyMDL.CompanyName;
                    singleBLL.Update(singleMDL);
                }
                #endregion
            } catch (Exception ex) {
                flag = SystemSet._RETURN_FAILURE_VALUE + ex.Message;
                Common.LogUtil.Debug(this, "工程相关表关联(工程用户表,工程公司表)", ex);
            }
            return flag;
        }
    }
}