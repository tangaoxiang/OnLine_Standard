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
    public partial class ctrlDropDownQuestionType : System.Web.UI.UserControl
    {
        public delegate void SelectChange();
        //public event SelectChange MySelectChange;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public string SelectValue
        {
            set { DropDown1.SelectedIndex = DropDown1.Items.IndexOf(DropDown1.Items.FindByValue(value)); }
            get { return DropDown1.SelectedValue; }
        }

        public void DataBindEx()
        {
            DataSet ds = (new T_QuestionType_BLL()).GetList("");
            DropDown1.DataTextField = "Title";
            DropDown1.DataValueField = "QuestionTypeID";
            DropDown1.DataSource = ds;
            DropDown1.DataBind();
        }

        public bool AutoPostBack
        {
            set
            {
                DropDown1.AutoPostBack = value;
            }
        }

        protected void My_SelectedIndexChanged(object sender, EventArgs e)
        {
            T_QuestionType_MDL questioinMDL = (new T_QuestionType_BLL()).GetModel(Common.ConvertEx.ToInt(DropDown1.SelectedValue));
            if (questioinMDL != null)
            {
                Label1.Text = questioinMDL.ToUserNameList;
            }

            //if (MySelectChange != null)
            //{
            //    MySelectChange();
            //}
        }
    }
}