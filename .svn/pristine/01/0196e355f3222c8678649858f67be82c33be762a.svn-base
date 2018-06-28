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

//报表类型

namespace DigiPower.Onlinecol.Standard.Web.CommonCtrl
{
    public partial class ctrlDropDownReportType : System.Web.UI.UserControl
    {

        /// <summary>
        /// 添加属性
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetAttributes(string key, string value)
        {
            ddl_Report_Type.Attributes.Add(key, value);
        }

        /// <summary>
        /// 设置下拉框的宽度
        /// </summary>
        public string SetWidth
        {
            set { ddl_Report_Type.Width = Unit.Parse(value); }
        }

        /// <summary>
        /// get 返回选中的Value值
        /// set 通过传入Value选中某项
        /// </summary>
        public string SelectValue
        {
            get
            {
                if (ddl_Report_Type.Items.Count > 0)
                    return ddl_Report_Type.SelectedItem.Value;
                else
                    return "0";
            }
            set { ddl_Report_Type.SelectedValue = value; }
        }

        /// <summary>
        ///   get  返回选中的Text值
        /// </summary>
        public string SelectText
        {
            get { return ddl_Report_Type.SelectedItem.Text; }
        }

        /// <summary>
        /// 绑定报表所有类型
        /// </summary>
        public void DataBindEx()
        {
            DataBindEx(false);
        }

        /// <summary>
        /// 绑定所有报表类型
        /// </summary>
        /// <param name="IsSelectAll">是否显示 无父类 选项</param>
        public void DataBindEx(bool IsSelectAll)
        {
            List<T_Report_Type_MDL> list = new T_Report_Type_BLL().GetModelList("");

            ddl_Report_Type.DataSource = list;
            ddl_Report_Type.DataTextField = "ReportTypeName";
            ddl_Report_Type.DataValueField = "ReportTypeID";
            ddl_Report_Type.DataBind();

            if (IsSelectAll)
            {
                ListItem item = new ListItem("无父类", "0");
                ddl_Report_Type.Items.Insert(0, item);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}