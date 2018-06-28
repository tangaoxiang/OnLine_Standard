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

namespace DigiPower.Onlinecol.Standard.Web.CommonCtrl {
    public partial class ctrlDropDownFileTmpSignatureUserRole : System.Web.UI.UserControl {
        public delegate void SelectChange();
        public event SelectChange MySelectChange;

        public string Width {
            set { ddlUserRole.Width = new Unit(value); }
        }

        protected void Page_Load(object sender, EventArgs e) {
        }

        public string SelectValue {
            set { ddlUserRole.SelectedIndex = ddlUserRole.Items.IndexOf(ddlUserRole.Items.FindByValue(value)); }
            get { return ddlUserRole.SelectedValue; }
        }

        /// <summary>
        /// 绑定工程下所有文件对应的签章角色
        /// </summary>
        /// <param name="SingleProjectID"></param>
        public void DataBindEx(string SingleProjectID) {
            DataTable dt = new T_FileList_SignatureTmp_BLL().GetSingleProjectAllSignatureRole(SingleProjectID);

            ddlUserRole.DataTextField = "RoleName";
            ddlUserRole.DataValueField = "RoleID";
            ddlUserRole.DataSource = dt;
            ddlUserRole.DataBind();
        }

        /// <summary>
        ///绑定签章角色(1:可根据工程类型绑定工程下的文件对应的所有签章角色 2:直接绑定签章角色)
        /// </summary>
        /// <param name="SingleProjectID"></param>
        public void DataBindEx(string SingleProjectID, string RoleType, bool isAllflag = false, string dataValueField = null) {
            DataTable dt = new DataTable();
            if (!string.IsNullOrWhiteSpace(SingleProjectID))
                dt = new T_FileList_SignatureTmp_BLL().GetSingleProjectAllSignatureRole(SingleProjectID);
            if (!string.IsNullOrWhiteSpace(RoleType))
                dt = new T_Role_BLL().GetList("lower(RoleType)='" + RoleType.ToLower() + "'").Tables[0];

            if (!string.IsNullOrWhiteSpace(dataValueField))
                ddlUserRole.DataValueField = dataValueField;
            else
                ddlUserRole.DataValueField = "RoleID";

            ddlUserRole.DataTextField = "RoleName";
            ddlUserRole.DataSource = dt;
            ddlUserRole.DataBind();

            if (isAllflag)
                ddlUserRole.Items.Insert(0, new ListItem("--请选择--", "0"));
        }

        public bool AutoPostBack {
            set {
                ddlUserRole.AutoPostBack = value;
            }
        }

        public bool Enabled {
            set {
                ddlUserRole.Enabled = value;
            }
        }

        protected void ddlUserRole_SelectedIndexChanged(object sender, EventArgs e) {
            if (MySelectChange != null) {
                MySelectChange();
            }
        }
    }
}