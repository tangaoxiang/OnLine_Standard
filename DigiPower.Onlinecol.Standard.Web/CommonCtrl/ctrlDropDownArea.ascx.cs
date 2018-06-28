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
    public partial class ctrlDropDownArea : System.Web.UI.UserControl {
        private int par_level = 0;
        private ArrayList area_list = new ArrayList();
        public delegate void SelectChange();
        public event SelectChange MySelectChange;


        public string Width {
            set { ddlArea.Width = new Unit(value); }
        }

        protected void Page_Load(object sender, EventArgs e) {
        }

        public string SelectValue {
            set { ddlArea.SelectedIndex = ddlArea.Items.IndexOf(ddlArea.Items.FindByValue(value)); }
            get { return ddlArea.SelectedValue; }
        }

        public void BindDdlArea() {
            BindDdlArea(false);
        }

        public void BindDdlArea(bool noParent) {
            BindDblArea(noParent, "");
        }

        public void BindDblArea(bool noParent, string filter) {
            List<T_Area_MDL> arealist = new List<T_Area_MDL>();
            arealist = (new T_Area_BLL()).GetModelList("");
            //层次重排area_name
            Recursion(ref arealist, "0");

            if (noParent == false) {
                T_Area_MDL mdl = new T_Area_MDL();
                mdl.AreaID = 0;
                mdl.area_code = "0";
                mdl.area_name = "无父级";
                area_list.Insert(0, mdl);
            }
            ddlArea.DataTextField = "Area_Name";
            ddlArea.DataValueField = "AREA_CODE";
            ddlArea.DataSource = area_list;
            ddlArea.DataBind();
            SelectValue = Common.Session.GetSession("AREA_CODE");
        }

        public void BindDblArea(bool noParent, string filter, string DataValueField) {
            List<T_Area_MDL> arealist = new List<T_Area_MDL>();
            arealist = (new T_Area_BLL()).GetModelList("");
            //层次重排area_name
            Recursion(ref arealist, "0");

            if (noParent == false) {
                T_Area_MDL mdl = new T_Area_MDL();
                mdl.AreaID = 0;
                mdl.area_code = "0";
                mdl.area_name = "无父级";
                area_list.Insert(0, mdl);
            }
            ddlArea.DataTextField = "Area_Name";
            ddlArea.DataValueField = DataValueField;
            ddlArea.DataSource = area_list;
            ddlArea.DataBind();
            SelectValue = Common.Session.GetSession(DataValueField);
        }

        public void Recursion(ref List<T_Area_MDL> list, string fathcode) {
            List<T_Area_MDL> areamdl = list.FindAll(
             delegate(T_Area_MDL p) {
                 return p.PID == Common.ConvertEx.ToInt(fathcode);
             }
            );
            foreach (T_Area_MDL objMDL in areamdl) {
                par_level++;
                T_Area_MDL mdl1 = new T_Area_MDL();
                mdl1.AreaID = objMDL.AreaID;
                mdl1.area_code = objMDL.area_code;
                mdl1.area_name = Comm.AddEmpty(objMDL.area_name, par_level);
                area_list.Add(mdl1);
                Recursion(ref list, objMDL.AreaID.ToString());
                par_level--;
            }
        }

        public bool AutoPostBack {
            set {
                ddlArea.AutoPostBack = value;
            }
        }

        public bool Enabled {
            set {
                ddlArea.Enabled = value;
            }
        }

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e) {
            if (MySelectChange != null) {
                MySelectChange();
            }
        }
    }
}