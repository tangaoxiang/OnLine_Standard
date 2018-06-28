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
    public partial class ctrlDropDownRole : System.Web.UI.UserControl
    {
        public delegate void RoleChanged();
        public event RoleChanged MyRoleChanged;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 禁用下拉框
        /// </summary>
        public bool enabled
        {
            set { ddlRole.Enabled = value; }
            get
            {
                return ddlRole.Enabled;
            }
        }

        public string Width
        {
            set { ddlRole.Width = new Unit(value); }
        }
        public string SelectValue
        {
            set { ddlRole.SelectedIndex = ddlRole.Items.IndexOf(ddlRole.Items.FindByValue(value)); }
            get { return ddlRole.SelectedValue; }
        }

        public bool AutoPostBack
        {
            set { ddlRole.AutoPostBack = value; }
        }

        public void BindDdlRold()
        {
            BindDdlRold("");
        }

        public void BindDdlRold(string CompanyID)
        {
            BindDdlRold(CompanyID, false);
        }

        public void BindDdlRold(string CompanyID, bool bIncludeAll)
        {
            string strSqlWhere = "";
            List<T_Role_MDL> rolelist = new List<T_Role_MDL>();
            if (CompanyID != "")
            {
                strSqlWhere = "A.CompanyID=" + CompanyID;
            }
            rolelist = (new T_Role_BLL()).GetModelList(strSqlWhere);
            if (bIncludeAll == true)
            {
                T_Role_MDL mdl = new T_Role_MDL();
                mdl.RoleID = 0;
                mdl.RoleName = "全部";
                rolelist.Insert(0, mdl);
            }

            ddlRole.DataTextField = "rolename";
            ddlRole.DataValueField = "roleid";
            ddlRole.DataSource = rolelist;
            ddlRole.DataBind();
        }

        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MyRoleChanged != null)
                MyRoleChanged();
        }
    }
}