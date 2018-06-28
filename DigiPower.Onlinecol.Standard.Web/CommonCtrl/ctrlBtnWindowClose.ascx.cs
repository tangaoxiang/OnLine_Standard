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
    public partial class ctrlBtnWindowClose : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 设置其Text内容
        /// </summary>
        public string Text
        {
            set { txtBtn.Value = value; }
        }

        /// <summary>
        /// 设置其是否可见
        /// </summary>
        public bool Visible
        {
            set { txtBtn.Visible = value; }
        }

        /// <summary>
        /// 关闭页面
        /// </summary>
        public string OnClientClickClose
        {
            set
            {
                txtBtn.Attributes.Add("onclick", value);
            }
        }
           
        /// <summary>
        /// 新增个CssClass 
        /// </summary>
        public string SetCssClass
        {
            set { txtBtn.Attributes.Add("class", value); }
        }
    }
}