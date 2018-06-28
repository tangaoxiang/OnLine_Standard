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

namespace DigiPower.Onlinecol.Standard.Web.CommonCtrl {
    public partial class ctrlCheckBoxList : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {
        }

        public string getSelectValue {
            get {
                string SystemInfoCode = string.Empty;
                foreach (ListItem item in CheckBoxList1.Items) {
                    if (item.Selected) {
                        if (SystemInfoCode == string.Empty)
                            SystemInfoCode = item.Value;
                        else
                            SystemInfoCode += "," + item.Value;
                    }
                }
                return SystemInfoCode;
            }
        }

        public string setSelectValue {
            set {
                foreach (ListItem item in CheckBoxList1.Items) {
                    if ((value.ToLower() + ",").IndexOf(item.Value.ToLower() + ",") > -1) {
                        item.Selected = true;
                    }
                }
            }
        }

        public int repeatColumns {
            set { CheckBoxList1.RepeatColumns = value; }
        }

        public int width {
            set { CheckBoxList1.Width = value; }
        }

        public void DataBindEx(string CurrentType) {
            BLL.T_SystemInfo_BLL sysBLL = new BLL.T_SystemInfo_BLL();
            List<Model.T_SystemInfo_MDL> list = sysBLL.GetModelListForCurrentType(CurrentType);

            CheckBoxList1.DataTextField = "SystemInfoName";
            CheckBoxList1.DataValueField = "SystemInfoCode";
            CheckBoxList1.DataSource = list;
            CheckBoxList1.DataBind();
        }

        public void DataBindEx(DataTable dt, string dataTextField, string dataValueField, string cssClass = null) {
            CheckBoxList1.DataTextField = dataTextField;
            CheckBoxList1.DataValueField = dataValueField;
            CheckBoxList1.DataSource = dt;
            CheckBoxList1.DataBind();

            if (!string.IsNullOrWhiteSpace(cssClass)) {
                for (var i = 0; i < CheckBoxList1.Items.Count; i++) {
                    CheckBoxList1.Items[i].Attributes.Add("class", cssClass);
                }
            }
        }
    }
}