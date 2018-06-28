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
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.Model;
using System.Collections.Generic;

namespace DigiPower.Onlinecol.Standard.Web.CommonCtrl
{
    public partial class ctrlCompanyBaseInfo : System.Web.UI.UserControl
    {
        private string _arecode = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void DataBindEx(int tCompanyID)
        {
            AREA_CODE.BindDdlArea(true);
            if (Common.Session.GetSession("IsCompany") == "true")
            {
                CompanyType.DataBindEx(false, "'ARCHIVE'");
            }
            else
            {
                CompanyType.DataBindEx(false, "");
            }

            if (tCompanyID > 0)
            {
                T_Company_MDL projectmdl = (new T_Company_BLL()).GetModel(tCompanyID);
                Comm.SetValueToPage(projectmdl, tbl_company);
                CompanyCode.Text = projectmdl.CompanyCode.Trim();
                _arecode = projectmdl.AREA_CODE;
            }
        }

        public T_Company_MDL GetModule(int tCompanyID)
        {
            T_Company_MDL mdl = new T_Company_MDL();
            if (tCompanyID > 0)
            {
                BLL.T_Company_BLL bll = new T_Company_BLL();
                mdl = bll.GetModel(tCompanyID);
            }
            object obj = Comm.GetValueToObject(mdl, tbl_company);
            return (T_Company_MDL)obj;
        }

        public string MyArea_Code
        {
            get
            {
                return _arecode;
            }
            set
            {
                _arecode = value;
            }
        }

        public void SetCompanyType(bool MyChild)
        {
            if (MyChild == true)
            {
                List<string> noInclude = new List<string>();
                noInclude.Add("ARCHIVE");
                noInclude.Add("JSCompanyInfo");

                CompanyType.DataBindEx(false, noInclude);
            }
        }
        public void SetCompanyType(int UnderMyParentID)
        {
            CompanyType.DataBindEx(UnderMyParentID);
        }
        public void SetCompanyType(int UnderMyParentID, int CompanyId, bool isshowjs = false)
        {
            CompanyType.DataBindEx(UnderMyParentID, isshowjs);
            T_Company_MDL mdl = new T_Company_MDL();
            if (CompanyId > 0)
            {
                BLL.T_Company_BLL bll = new T_Company_BLL();
                mdl = bll.GetModel(CompanyId);
                CompanyType.SystemInfoID = mdl.CompanyType.ToString();
            }
        }

        public void SetCompanyTypeEnable(bool b1)
        {
            CompanyType.Enabled = b1;
        }

        /// <summary>
        /// 使用禁用区域
        /// </summary>
        /// <param name="b1"></param>
        public void SetAreaCodeEnable(bool b1)
        {
            AREA_CODE.Enabled = b1;
        }

        public string MyCompanyName
        {
            get
            {
                return CompanyName.Text;
            }
        }
        public string CompanyTypeID
        {
            get
            {
                return CompanyType.SelectValue;
            }
            set
            {
                CompanyType.SelectValue = value;
            }
        }
    }
}