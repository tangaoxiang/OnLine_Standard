using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DigiPower.Onlinecol.Standard.Web.CommonCtrl
{
    public partial class ctrlCheckBoxUserList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void DataBindEx(int SingleProjectID, bool bIncludeAll)
        {
            //BLL.T_Other_BLL otherBLL = new DigiPower.Onlinecol.Standard.BLL.T_Other_BLL();
            //DataSet ds = otherBLL.getget(SingleProjectID);
            //CheckBoxList1.DataValueField = "UserID";
            //CheckBoxList1.DataTextField = "UserName";
            //CheckBoxList1.DataSource = ds;
            //CheckBoxList1.DataBind();
            //if (bIncludeAll == true)
            //{
            //    ListItem l1 = new ListItem();
            //    l1.Text = "工程全体人员";
            //    l1.Value = "0";
            //    CheckBoxList1.Items.Insert(0, l1);
            //}
        }

        public void DataBindEx2(int CompanyID, bool bIncludeAll)
        {
            BLL.T_UsersInfo_BLL otherBLL = new DigiPower.Onlinecol.Standard.BLL.T_UsersInfo_BLL();
            DataSet ds = otherBLL.GetListByCompany("CompanyID=" + CompanyID);
            CheckBoxList1.DataValueField = "UserID";
            CheckBoxList1.DataTextField = "UserName";
            CheckBoxList1.DataSource = ds;
            CheckBoxList1.DataBind();
            if (bIncludeAll == true)
            {
                ListItem l1 = new ListItem();
                l1.Text = "工程全体人员";
                l1.Value = "0";
                CheckBoxList1.Items.Insert(0, l1);
            }
        }

        public List<string> GetSelectList()
        {
            List<string> list1 = new List<string>();
            foreach (ListItem l1 in CheckBoxList1.Items)
            {
                if (l1.Selected == true)
                {
                    list1.Add(l1.Value);
                }
            }
            return list1;
        }

        public string GetSelectValue()
        {
            string list1 = "";
            foreach (ListItem l1 in CheckBoxList1.Items)
            {
                if (l1.Selected == true)
                {
                    list1 += l1.Value + ",";
                }
            }
            return list1;
        }

        public string GetSelectValue(bool FormatStr)
        {
            string list1 = "";
            foreach (ListItem l1 in CheckBoxList1.Items)
            {
                if (l1.Selected == true)
                {
                    if (list1 == "") list1 = l1.Value;
                    else list1 += "," + l1.Value;
                }
            }
            return list1;
        }

        public string GetSelectString()
        {
            string list1 = "";
            foreach (ListItem l1 in CheckBoxList1.Items)
            {
                if (l1.Selected == true)
                {
                    list1 += l1.Text + ",";
                }
            }
            return list1;
        }

        public string GetSelectString(bool FormatStr)
        {
            string list1 = "";
            foreach (ListItem l1 in CheckBoxList1.Items)
            {
                if (l1.Selected == true)
                {    
                    if (list1 == "") list1 = l1.Text;
                    else list1 += "," + l1.Text;
                }
            }
            return list1;
        }

        public void SetSelectValue(string CurrentValue)
        {
            string[] list1 = CurrentValue.Split(',');
            foreach (string str1 in list1)
            {
                foreach (ListItem l1 in CheckBoxList1.Items)
                {
                    if (l1.Value == str1)
                    {
                        l1.Selected = true;
                    }
                }
            }
        }
    }
}