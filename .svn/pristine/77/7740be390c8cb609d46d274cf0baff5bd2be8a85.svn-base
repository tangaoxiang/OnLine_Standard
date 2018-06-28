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
using DigiPower.Onlinecol.Standard.Model;

namespace DigiPower.Onlinecol.Standard.Web.CommonCtrl
{
    public partial class ctrlDropDownUser : System.Web.UI.UserControl
    {
        public delegate void SelectChange();
        public event SelectChange MySelectChange;
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        public bool enabled
        {
            set { ddlUser.Enabled = value; }
        }

        public string Width
        {
            set { ddlUser.Width = new Unit(value); }
        }

        public string SelectValue
        {
            set { ddlUser.SelectedIndex = ddlUser.Items.IndexOf(ddlUser.Items.FindByValue(value)); }
            get { return ddlUser.SelectedValue; }
        }
        public string SelectText
        {
            get { return ddlUser.SelectedItem.Text; }
        }

        public void BindDataByCompanyID(string CompanyID)
        {
            BindDataByCompanyID(CompanyID, false, 0);
        }

        public void BindDataByCompanyID(string CompanyID, int RoleID)
        {
            BindDataByCompanyID(CompanyID, false, RoleID);
        }
        public void BindDataByCompanyID(string CompanyID, string RoleCode)
        {
            BindDataByCompanyID(CompanyID, false, RoleCode);
        }

        public void BindDataByCompanyID(string CompanyID, bool bAddSelectAll, string RoleCode)
        {
            string strwhere = " CompanyID=" + CompanyID;
            if (!String.IsNullOrWhiteSpace(RoleCode) && !String.IsNullOrWhiteSpace(CompanyID))
            {
                strwhere += " AND RoleID IN(SELECT RoleID from T_Role where LOWER(RoleCode)='" +
                    RoleCode.ToLower() + "' AND CompanyID =" + CompanyID + ")";
            }

            BindUser(strwhere, bAddSelectAll);
        }

        public void BindDataByCompanyID(string CompanyID, bool bAddSelectAll, string RoleCode, string AreaCode)
        {
            string strwhere = " 1=1 ";
            if (!String.IsNullOrWhiteSpace(CompanyID))
            {
                strwhere += " and CompanyID=" + CompanyID;
            }
            if (!String.IsNullOrWhiteSpace(RoleCode) && !String.IsNullOrWhiteSpace(AreaCode))
            {
                strwhere += " and RoleID in(SELECT a1.RoleID from T_Role a1 INNER JOIN T_Company b1 ";
                strwhere += " ON a1.CompanyID=b1.CompanyID AND b1.Area_Code='" + AreaCode + "' ";
                strwhere += " and LOWER(a1.RoleCode)='" + RoleCode.ToLower() + "')";
            }

            List<T_UsersInfo_MDL> userlist = new List<T_UsersInfo_MDL>();
            T_UsersInfo_BLL userBLL = new T_UsersInfo_BLL();

            userlist = userBLL.DataTableToList(userBLL.GetList(0, strwhere, "userid").Tables[0]);
            if (bAddSelectAll == true)
            {
                T_UsersInfo_MDL mdl = new T_UsersInfo_MDL();
                mdl.UserID = 0;
                mdl.UserName = "全部";
                userlist.Insert(0, mdl);
            }
            ddlUser.DataTextField = "username";
            ddlUser.DataValueField = "userid";
            ddlUser.DataSource = userlist;
            ddlUser.DataBind();
        }

        public void BindDataByCompanyID(string CompanyID, bool bAddSelectAll, int RoleID)
        {
            string strwhere = " CompanyID=" + CompanyID;
            if (RoleID > 0)
            {
                strwhere += " AND RoleID=" + RoleID;
            }

            BindUser(strwhere, bAddSelectAll);
        }

        public bool AutoPostBack
        {
            set
            {
                ddlUser.AutoPostBack = value;
            }
        }

        public void BindUser(string strwhere)
        {
            BindUser(strwhere, false);
        }

        public void BindUser(string strwhere, bool bAddSelectAll)
        {
            List<T_UsersInfo_MDL> userlist = new List<T_UsersInfo_MDL>();
            userlist = (new T_UsersInfo_BLL()).GetModelList(strwhere);
            if (bAddSelectAll == true)
            {
                T_UsersInfo_MDL mdl = new T_UsersInfo_MDL();
                mdl.UserID = 0;
                mdl.UserName = "全部";
                userlist.Insert(0, mdl);
            }
            ddlUser.DataTextField = "username";
            ddlUser.DataValueField = "userid";
            ddlUser.DataSource = userlist;
            ddlUser.DataBind();
        }

        protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MySelectChange != null)
            {
                MySelectChange();
            }
        }
    }
}