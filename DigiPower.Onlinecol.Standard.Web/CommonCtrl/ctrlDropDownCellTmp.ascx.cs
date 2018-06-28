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
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.BLL;


namespace DigiPower.Onlinecol.Standard.Web.CommonCtrl
{
    public partial class ctrDropDownCellTmp : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool AutoPostBack
        {
            set { ddlCellTmp.AutoPostBack = value; }
        }

        /// <summary>
        /// 设置下拉框Width
        /// </summary>
        public int Width
        {
            set
            {
                ddlCellTmp.Width = value;
            }
        }

        /// <summary>
        /// 获取下拉框VALUE 值
        /// </summary>
        public string SelectValue
        {
            set { ddlCellTmp.SelectedIndex = ddlCellTmp.Items.IndexOf(ddlCellTmp.Items.FindByValue(value)); }
            get { return ddlCellTmp.SelectedValue; }
        }

        /// <summary>
        /// 绑定PDI=0的施工用表
        /// </summary>
        public void DataBindEx()
        {
            T_CellTmp_BLL bll = new T_CellTmp_BLL();
            DataSet ds = new DataSet();

            ds = bll.GetList(" PID=0 ");

            if (ds.Tables.Count > 0)
            {
                ddlCellTmp.DataTextField = "Title";
                ddlCellTmp.DataValueField = "CellID";
                ddlCellTmp.DataSource = ds;
                ddlCellTmp.DataBind();
            }

            ddlCellTmp.Items.Insert(0, new ListItem("无", "0"));
        }
    }
}