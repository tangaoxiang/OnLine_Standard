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
    public partial class ctrlBtnBack : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 设置其Text内容
        /// </summary>
        public string Text
        {
            set { ToBackBtn.Text = value; }
        }

        /// <summary>
        /// 设置其是否可见
        /// </summary>
        public bool Visible
        {
            set { ToBackBtn.Visible = value; }
        }

        /// <summary>
        /// 关闭页面
        /// </summary>
        public string OnClientClickClose
        {
            set
            {    
                ToBackBtn.OnClientClick = "window.close();";
            }
        }

        protected void ToBackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect(PrevURLList.GetListestURLAndBack());
            //Response.Write("<script>history.go(-2);</script>");
        }

        /// <summary>
        /// 新增个CssClass 
        /// </summary>
        public string SetCssClass
        {
            set { ToBackBtn.CssClass = value; }
        }
    }
}