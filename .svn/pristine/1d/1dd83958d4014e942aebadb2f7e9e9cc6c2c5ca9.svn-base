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
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.Model;


namespace DigiPower.Onlinecol.Standard.Web.CommonCtrl
{
   /// <summary>
   /// 用户类型(如系统用户,档案员等)
   /// </summary>
    public partial class ctrlDropDownUserType : System.Web.UI.UserControl
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
        /// 返回下拉框当前选中的Value值
        /// </summary>
        public string SelectedValue
        {
            set { ddlUserType.SelectedIndex = ddlUserType.Items.IndexOf(ddlUserType.Items.FindByValue(value)); }
            get { return ddlUserType.SelectedValue; }
        }

        /// <summary>
        /// 返回下拉框当前选中的Text值
        /// </summary>
        public string SelectedText
        {
            get { return ddlUserType.SelectedItem.Text; }
        }

        /// <summary>
        /// 选中内容时，是否自动产生向服务器的回发
        /// </summary>
        public bool AutoPostBack
        {
            set { ddlUserType.AutoPostBack = value; }
        }

        /// <summary>
        /// 设置下拉框Width
        /// </summary>
        public string Width
        {
            set { ddlUserType.Width = Unit.Parse(value); }
        }

        /// <summary>
        /// 绑定所有的用户类型
        /// </summary>
        /// <param name="bAddSelectAll">是否添加一个 全部 的选项</param>
        public void BindUserType(bool bAddSelectAll)
        {
            ddlUserType.Items.Add(new ListItem("档案员", "ArchiveUser"));             
            ddlUserType.Items.Add(new ListItem("系统用户", "SystemUser"));

            if (bAddSelectAll)
            {
                ddlUserType.Items.Insert(0, new ListItem("全部", ""));
            }
        }
        
        protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MySelectChange != null)
            {
                MySelectChange();
            }
        }


    }
}