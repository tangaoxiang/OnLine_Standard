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

namespace DigiPower.Onlinecol.Standard.Web.SystemManage {
    public partial class UserByProjectList : PageBase {
        T_SingleProject_BLL singleBLL = new T_SingleProject_BLL();

        /// <summary>
        /// 总记录数
        /// </summary>
        int itemCount = 0;

        /// <summary>
        /// 每页页数
        /// </summary>
        int pageSize = 15;

        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(UserByProjectList));
            MyAddInit();
            if (!IsPostBack) {
                BindGridView(AspNetPager.CurrentPageIndex);
            }
        }

        /// <summary>
        /// 列表数据绑定
        /// </summary>
        /// <param name="pageIndex"></param>
        private void BindGridView(int pageIndex) {
            string sqlWhere = " b.UserID=" + ID;
            if (!String.IsNullOrWhiteSpace(txtGcmc.Text.Trim()))
                sqlWhere += " And a.gcmc like '%" + txtGcmc.Text.Trim() + "%' ";
            if (!String.IsNullOrWhiteSpace(txtGcdd.Text.Trim()))
                sqlWhere += " And a.gcdd like '%" + txtGcdd.Text.Trim() + "%' ";
            if (!String.IsNullOrWhiteSpace(txtGcbm.Text.Trim()))
                sqlWhere += " And a.gcbm like '%" + txtGcbm.Text.Trim() + "%' ";

            DataTable dt = singleBLL.GetListByUserId(sqlWhere, pageSize, pageIndex, out itemCount);
            AspNetPager.AlwaysShow = true;

            AspNetPager.RecordCount = itemCount;
            AspNetPager.CurrentPageIndex = pageIndex;

            rpData.DataSource = dt;
            rpData.DataBind();
        }

        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager_PageChanged(object sender, EventArgs e) {
            BindGridView(AspNetPager.CurrentPageIndex);
        }

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e) {
            BindGridView(1);
        }
    }
}
