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
    public partial class ctrlDropDownSingleProjectUsers : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string SelectValue
        {
            set { DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByValue(value)); }
            get { return DropDownList1.SelectedValue; }
        }

        public string SelectText
        {
            get { return DropDownList1.SelectedItem.Text; }
        }

        public void DataBindEx(int SingleProjectID)
        {
            T_SingleProjectCompany_BLL bll = new T_SingleProjectCompany_BLL();
            DataSet list1 = bll.GetSingleProjectUser(SingleProjectID);

            DropDownList1.DataTextField = "username";
            DropDownList1.DataValueField = "userid";
            DropDownList1.DataSource = list1;
            DropDownList1.DataBind();
        }

        public void DataBindEx(int SingleProjectID, bool isSelectAll)
        {
            DataBindEx(SingleProjectID);
            if (isSelectAll)
            {
                DropDownList1.Items.Insert(0, new ListItem("全部", "0"));
            }
        }

    }
}