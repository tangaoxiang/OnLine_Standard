using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DigiPower.Onlinecol.Standard.Web.CommonCtrl
{
    public partial class ctrlDropDownExportType : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string SelectValue
        {
            set
            {
                ddlExportType.SelectedIndex = ddlExportType.Items.IndexOf(ddlExportType.Items.FindByValue(value));
            }
            get
            {
                return ddlExportType.SelectedValue;
            }
        }

        public string Width
        {
            set { ddlExportType.Width = new Unit(value); }
        }

        public void DataBindEx()
        {
            ListItem li = new ListItem("所有", "0");
            ddlExportType.Items.Add(li);
            ListItem li1 = new ListItem("报建确认包", "1");
            ddlExportType.Items.Add(li1);
            ListItem li2 = new ListItem("预验收包", "23");
            ddlExportType.Items.Add(li2);
            ddlExportType.DataBind();
            ddlExportType.SelectedValue = "0";

        }
    }
}