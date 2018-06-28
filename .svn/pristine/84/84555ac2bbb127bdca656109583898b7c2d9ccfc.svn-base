using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.BLL;

namespace DigiPower.Onlinecol.Standard.Web.CommonCtrl
{
    public partial class ctrlDropDownCompanyInfo : System.Web.UI.UserControl
    {
        public delegate void SelectChange();
        public event SelectChange MySelectChange;

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public string Width
        {
            set { ddlArea.Width = new Unit(value); }
        }
        public string SelectValue
        {
            set
            {
                ddlArea.SelectedIndex = ddlArea.Items.IndexOf(ddlArea.Items.FindByValue(value));
            }
            get { return ddlArea.SelectedValue; }
        }
        public string Text
        {
            get
            {
                string strOut = "";
                if (ddlArea.SelectedItem != null)
                {
                    strOut = ddlArea.SelectedItem.Text;
                }
                return strOut;
            }
        }

        public void DataBindEx()
        {
            DataBindEx("");
        }

        /// <summary>
        /// 绑定所有的公司
        /// </summary>
        public void BindDataWithNoJSDW()
        {
            List<T_Company_MDL> list = new List<T_Company_MDL>();
            list = (new T_Company_BLL()).BindDataWithNoJSDW();
            ddlArea.DataTextField = "CompanyName";
            ddlArea.DataValueField = "CompanyID";
            ddlArea.DataSource = list;
            ddlArea.DataBind();
        }

        /// <summary>
        /// 根据权限/区域显示不同的公司
        /// </summary>
        /// <param name="AreaID"></param>
        public void DataBindEx(string Area_Code)
        {
            string ls_sql = "1=1 ";
            /*
             if (!PublicModel.isSuperAdmin())
             {
                 ls_sql += " AND CompanyID=" + Common.Session.GetSession("CompanyID");
             }
 
             if (Area_Code != "")
             {
                 if (!PublicModel.isSuperAdmin())
                 {
                     ls_sql += " AND Area_Code='" + Area_Code + "'";
                 }
             }*/


            ls_sql += " AND CompanyType=12";//Leo 2012-12-25 只显示档案馆好了。其它的没什么用的
            DataSet ds = (new T_Company_BLL()).GetList(ls_sql);
            ddlArea.DataTextField = "CompanyName";
            ddlArea.DataValueField = "CompanyID";
            ddlArea.DataSource = ds;
            ddlArea.DataBind();
        }

        /// <summary>
        /// 根据权限/区域显示不同的公司
        /// </summary>
        /// <param name="AreaID"></param>
        /// <param name="IsSelectAll">是否显示全部</param>
        public void DataBindEx(string Area_Code, bool IsSelectAll)
        {
            DataBindEx(Area_Code);
            if (IsSelectAll)
            {
                ddlArea.Items.Insert(0, new ListItem("全部", ""));
            }
        }
        /// <summary>
        /// ViewClass查看级别，0=全部，1=自已，2
        /// </summary>
        /// <param name="SingleProjectID"></param>
        /// <param name="ViewClass"></param>
        public void DataBindEx(string SingleProjectID, int CompanyID)
        {
            DataSet ds = (new T_Other_BLL()).GetCompany(SingleProjectID, CompanyID);
            ddlArea.DataTextField = "CompanyName";
            ddlArea.DataValueField = "CompanyID";
            ddlArea.DataSource = ds;
            ddlArea.DataBind();
        }

        /// <summary>
        /// ViewClass查看级别，0=全部，1=自已，2
        /// </summary>
        /// <param name="SingleProjectID"></param>
        /// <param name="ViewClass"></param>
        public void DataBindEx(string SingleProjectID, string CompanyType)
        {
            DataSet ds = (new T_Other_BLL()).GetCompany(SingleProjectID, CompanyType);
            ddlArea.DataTextField = "CompanyName";
            ddlArea.DataValueField = "CompanyID";
            ddlArea.DataSource = ds;
            ddlArea.DataBind();
        }

        public bool AutoPostBack
        {
            set
            {
                ddlArea.AutoPostBack = value;
            }
        }

        /// <summary>
        /// 禁用下拉框
        /// </summary>
        public bool enabled
        {
            set { ddlArea.Enabled = value; }
            get
            {
                return ddlArea.Enabled;
            }
        }

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MySelectChange != null)
            {
                MySelectChange();
            }
        }

        public void DataBindEx(int CompanyID)
        {
            DataSet ds = (new T_Other_BLL()).GetCompany(CompanyID);
            ddlArea.DataTextField = "CompanyName";
            ddlArea.DataValueField = "CompanyID";
            ddlArea.DataSource = ds;
            ddlArea.DataBind();
        }


        /// <summary>
        /// 根据公司类别绑定公司--安监,质监,检测单位
        /// </summary>
        /// <param name="AreaID"></param>
        public void DataBindExForCompanyType(string CompanyType)
        {
            string ls_sql = "1=1 ";
            if (CompanyType != "")
            {
                ls_sql += " AND CompanyType in(select SystemInfoID from t_systeminfo where CurrentType='CompanyType' and SystemInfoCode='" + CompanyType + "')";
            }
            DataSet ds = (new T_Company_BLL()).GetList(ls_sql);
            ddlArea.DataTextField = "CompanyName";
            ddlArea.DataValueField = "CompanyID";
            ddlArea.DataSource = ds;
            ddlArea.DataBind();
        }
    }
}