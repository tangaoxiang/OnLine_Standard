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
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.Common;

namespace DigiPower.Onlinecol.Standard.Web.CommonCtrl
{
    public partial class ctrlDropDownSingleProject : System.Web.UI.UserControl
    {
        public delegate void SelectChanged();
        public event SelectChanged MySelectChanged;

        public string SelectValue
        {
            set { DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByValue(value)); }
            get { return DropDownList1.SelectedValue; }
        }

        public bool AutoPostBack
        {
            set { DropDownList1.AutoPostBack = value; }
        }

        public string Width
        {
            set { DropDownList1.Width = new Unit(value); }
        }

        public bool Enabled
        {
            set { DropDownList1.Enabled = value; }
            get { return DropDownList1.Enabled; }
        }

        public void DataBindEx()
        {
            DigiPower.Onlinecol.Standard.BLL.T_SingleProject_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_SingleProject_BLL();
            string strwhere = "";
            if (Common.Session.GetSession("SuperAdmin").ToLower() == "true")
            {
                strwhere = " Area_Code like '" + ConvertEx.ToString(Session["AREA_CODE"]) + "%'";
            }
            else
            {
                strwhere = "SingleProjectID in (select SingleProjectID from t_singleprojectuser where roleid=" + Common.Session.GetSession("RoleId") + ") ";
                strwhere += "And Area_Code like '" + ConvertEx.ToString(Session["AREA_CODE"]) + "%'";
            }
            DataSet list1 = bll.GetList(strwhere);
            DropDownList1.DataTextField = "gcmc";
            DropDownList1.DataValueField = "SingleProjectID";
            DropDownList1.DataSource = list1;
            DropDownList1.DataBind();
        }

        /// <summary>
        /// 获取系统中所有的工程
        /// </summary>
        public void DataBindEx(bool isSelectAll)
        {
            DataBindEx();
            if (isSelectAll)
            {
                DropDownList1.Items.Insert(0, new ListItem("全部", "0"));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MySelectChanged != null)
                MySelectChanged();
        }

        public void DataBindEx(int CompanyID)
        {
            DigiPower.Onlinecol.Standard.BLL.T_SingleProject_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_SingleProject_BLL();
            //string strwhere = "";
            //strwhere = "SingleProjectID in (select SingleProjectID from t_singleprojectuser where roleid=" + Common.Session.GetSession("RoleId") + ")";
            DataSet list1 = bll.GetListEx(CompanyID, "");
            DropDownList1.DataTextField = "gcmc";
            DropDownList1.DataValueField = "SingleProjectID";
            DropDownList1.DataSource = list1;
            DropDownList1.DataBind();
        }

        public void DataBindEx2(int CompanyID)
        {
            DigiPower.Onlinecol.Standard.BLL.T_SingleProject_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_SingleProject_BLL();
            DataSet list1 = bll.GetListEx2(CompanyID, "");
            DropDownList1.DataTextField = "gcmc";
            DropDownList1.DataValueField = "SingleProjectID";
            DropDownList1.DataSource = list1;
            DropDownList1.DataBind();
        }
    }
}