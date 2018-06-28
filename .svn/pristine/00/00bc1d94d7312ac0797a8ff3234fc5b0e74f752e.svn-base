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
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.Model;
using System.Collections.Generic;


namespace DigiPower.Onlinecol.Standard.Web.CommonCtrl
{
    /// <summary>
    /// 培训计划列表
    /// </summary>
    public partial class ctrlDropDownTrainPlan : System.Web.UI.UserControl
    {
        public delegate void SelectChange();

        /// <summary>
        /// 重写SelectedIndexChanged事件
        /// </summary>
        public event SelectChange MySelectChange;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 绑定所有的培训计划主题
        /// </summary>
        public void BindTranPlan()
        {
            T_Train_Plan_BLL trBll = new T_Train_Plan_BLL();
            List<T_Train_Plan_MDL> trMdl = trBll.GetModelList("");

            ddlTranPlan.DataTextField = "Subject";
            ddlTranPlan.DataValueField = "TrainPlanID";
            ddlTranPlan.DataSource = trMdl;
            ddlTranPlan.DataBind();
        }

        /// <summary>
        /// 返回下拉框当前选中的Value值
        /// </summary>
        public string SelectedValue
        {
            set { ddlTranPlan.SelectedIndex = ddlTranPlan.Items.IndexOf(ddlTranPlan.Items.FindByValue(value)); }
            get { return ddlTranPlan.SelectedValue; }
        }

        /// <summary>
        /// 返回下拉框当前选中的Text值
        /// </summary>
        public string SelectedText
        {
            get { return ddlTranPlan.SelectedItem.Text; }
        }

        /// <summary>
        /// 设置下拉框Width
        /// </summary>
        public string Width
        {
            set { ddlTranPlan.Width = Unit.Parse(value); }
        }

        /// <summary>
        /// 选中内容时，是否自动产生向服务器的回发
        /// </summary>
        public bool AutoPostBack
        {
            set { ddlTranPlan.AutoPostBack = value; }
        }

        protected void ddlTranPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MySelectChange != null)
            {
                MySelectChange();
            }
        }


    }
}