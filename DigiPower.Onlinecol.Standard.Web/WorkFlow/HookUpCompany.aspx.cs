using DigiPower.Onlinecol.Standard.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Model;
using System.Data;

namespace DigiPower.Onlinecol.Standard.Web.WorkFlow
{
    public partial class HookUpCompany : System.Web.UI.Page
    {
        T_SingleProjectCompany_BLL singComBll = new T_SingleProjectCompany_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            Ajax.Utility.RegisterTypeForAjax(typeof(HookUpCompany));
            if (!this.IsPostBack)
            {
                string SingleProjectID = Common.DNTRequest.GetQueryString("SingleProjectID");
                HidSingleProjectID.Value = SingleProjectID;

                if (Common.Session.GetSessionInt("CompanyType") == SystemSet._JSCOMPANYINFO)
                {
                    ctrlAjdw.DataBindExForCompanyType("AJCompanyInfo");
                    ctrlZjdw.DataBindExForCompanyType("ZJCompanyInfo");

                    Selected(ctrlAjdw, SingleProjectID, "AJCompanyInfo");
                    Selected(ctrlZjdw, SingleProjectID, "ZJCompanyInfo");

                    ctrlAjdw.Visible = true;
                    ctrlZjdw.Visible = true;

                    divAj.Visible = true;
                    divZj.Visible = true;
                }
                if (Common.Session.GetSessionInt("CompanyType") == SystemSet._SGCOMPANYINFO)
                {
                    ctrlJcdw.DataBindExForCompanyType("JCCompanyInfo");
                    Selected(ctrlJcdw, SingleProjectID, "JCCompanyInfo");

                    ctrlJcdw.Visible = true;
                    divJc.Visible = true;
                }
            }
        }

        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public void Execute(string singleProjectID, string companyID, string companyID2, bool flagType)
        {
            if (flagType)
            {
                DeleteSingleProjectCompany(singleProjectID, "AJCompanyInfo");
                DeleteSingleProjectCompany(singleProjectID, "ZJCompanyInfo");

                PublicModel.AddSingleProjectCompany(ConvertEx.ToInt(singleProjectID), ConvertEx.ToInt(companyID));  //安监单位
                PublicModel.AddSingleProjectCompany(ConvertEx.ToInt(singleProjectID), ConvertEx.ToInt(companyID2)); //质监单位

                PublicModel.AddSingleProjectUser(ConvertEx.ToInt(singleProjectID), GetUserInfoMdl(companyID));
                PublicModel.AddSingleProjectUser(ConvertEx.ToInt(singleProjectID), GetUserInfoMdl(companyID2));
            }
            else
            {
                DeleteSingleProjectCompany(singleProjectID, "JCCompanyInfo");
                PublicModel.AddSingleProjectCompany(ConvertEx.ToInt(singleProjectID), ConvertEx.ToInt(companyID)); //检测单位

                PublicModel.AddSingleProjectUser(ConvertEx.ToInt(singleProjectID), GetUserInfoMdl(companyID));
            }
        }

        /// <summary>
        /// 根据公司ID获取公司用户,一个公司对应一个账号
        /// </summary>
        /// <param name="companyID"></param>
        /// <returns></returns>
        T_UsersInfo_MDL GetUserInfoMdl(string companyID)
        {
            T_UsersInfo_MDL userMdl = null;
            T_UsersInfo_BLL userBLL = new T_UsersInfo_BLL();

            IList<T_UsersInfo_MDL> ltAjMdl = userBLL.GetModelList("CompanyID=" + companyID + "");
            if (ltAjMdl != null && ltAjMdl.Count > 0)
            {
                userMdl = ltAjMdl[0];
            }
            return userMdl;
        }

        /// <summary>
        /// 选中下拉框某一项
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="companyType"></param>
        /// <param name="singleProjectID"></param>
        void Selected(CommonCtrl.ctrlDropDownCompanyInfo ctrl, string singleProjectID, string companyType)
        {
            DataTable dt = singComBll.GetSingleProjectCompany(singleProjectID, companyType);
            if (dt != null && dt.Rows.Count > 0) ctrl.SelectValue = ConvertEx.ToString(dt.Rows[0]["CompanyID"]);
        }

        void DeleteSingleProjectCompany(string singleProjectID, string companyType)
        {
            singComBll.DeleteSingleProjectCompany(singleProjectID, companyType);
        }
    }
}