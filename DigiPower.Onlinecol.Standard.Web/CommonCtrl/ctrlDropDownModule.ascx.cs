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
    public partial class ctrlDropDownModule : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //DataBindEx(2);
            }
        }

        public string SelectValue
        {
            set { ddlModule.SelectedIndex = ddlModule.Items.IndexOf(ddlModule.Items.FindByValue(value)); }
            get { return ddlModule.SelectedValue; }
        }

        public string Width
        {
            set { ddlModule.Width = new Unit(value); }
        }

        public void DataBindEx()
        {
            List<T_Module_MDL> arealist = new List<T_Module_MDL>();
            DataSet ds1 = (new T_Module_BLL()).GetList("");
            //层次重排area_name
            Recursion(ds1.Tables[0], ref arealist, 0, 0);

            T_Module_MDL mdl1 = new T_Module_MDL();
            mdl1.ModuleID = 0;
            mdl1.ModuleName = "无父级";
            arealist.Insert(0, mdl1);

            ddlModule.DataTextField = "ModuleName";
            ddlModule.DataValueField = "ModuleID";
            ddlModule.DataSource = arealist;
            ddlModule.DataBind();
        }

        public void Recursion(DataTable dt, ref List<T_Module_MDL> list1, int PID, int LevelID)
        {
            DataRow[] dr = dt.Select("parentID='" + PID + "'", "OrderIndex");
            foreach (DataRow drr in dr)
            {
                T_Module_MDL mdl1 = new T_Module_MDL();
                mdl1.ModuleID = Common.ConvertEx.ToInt(drr["ModuleID"].ToString());
                mdl1.ModuleName = Comm.AddEmpty(drr["ModuleName"].ToString(), LevelID);
                list1.Add(mdl1);
                int NewLevelID = LevelID + 1;
                Recursion(dt, ref list1, Int32.Parse(drr["moduleid"].ToString()), NewLevelID);
            }
        }
    }
}