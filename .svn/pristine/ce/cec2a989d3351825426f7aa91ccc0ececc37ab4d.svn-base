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
    public partial class ctrlDropDownCanDefineType : System.Web.UI.UserControl
    {
        public delegate void SelectChanged();

        public event SelectChanged MySelectChanged;

        private string _InfoID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // DataBindEx();
            }
        }

        public string InfoID
        {
            set { _InfoID = value; }
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
  
        public void DataBindEx(string[] TextFile, string[] ValueFile)
        {
            if (TextFile.Length > 0 && ValueFile.Length > 0 && TextFile.Length == ValueFile.Length)
            {
                for (int i = 0; i < TextFile.Length; i++)
                {
                    DropDownList1.Items.Add(new ListItem(TextFile[i], ValueFile[i]));
                }
            }
        }

        public void DataBindEx()
        {
            DigiPower.Onlinecol.Standard.BLL.UserOperate bll = new DigiPower.Onlinecol.Standard.BLL.UserOperate();

            DataSet list1 = bll.GetDepartmentList("select CanDefineTypeID,ShowName from vwDefineType where DefineTypeID = " + _InfoID + "");

            DropDownList1.DataTextField = "ShowName";
            DropDownList1.DataValueField = "CanDefineTypeID";
            DropDownList1.DataSource = list1;
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
