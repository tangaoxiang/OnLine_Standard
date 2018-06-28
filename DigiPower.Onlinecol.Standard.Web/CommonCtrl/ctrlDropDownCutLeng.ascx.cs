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

namespace DigiPower.Onlinecol.Standard.Web.CommonCtrl
{
    public partial class ctrlDropDownCutLeng : System.Web.UI.UserControl
    {
        public delegate void SelectChanged();
        public event SelectChanged MySelectChanged;

        private int _StartLocation = 0;

        private int _EndLocation = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              //  DataBindEx();
            }
        }

        public int StartLocation
        {
            set { _StartLocation = value; }
        }

        public int EndLocation
        {
            set { _EndLocation = value; }
        }

        public string SelectValue
        {
            set
            {
                DataBindEx();

                DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByValue(value));
            }
            get { return DropDownList1.SelectedValue; }
        }

        public void DataBindEx()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID");

            dt.Columns.Add("Name");

            for (int i = 1; i <= _EndLocation - _StartLocation; i++)
            {
                DataRow dr = dt.NewRow();

                dr["ID"] = i.ToString();

                dr["Name"] = i.ToString();

                dt.Rows.Add(dr);
            }

            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "ID";
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();
        }

        public bool AutoPostBack
        {
            set { DropDownList1.AutoPostBack = value; }
        }

        protected void ddlArchiveFormType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MySelectChanged != null)
                MySelectChanged();
        }
    }
}