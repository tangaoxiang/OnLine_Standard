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

namespace DigiPower.Onlinecol.Standard.Web.SystemManage
{
    public partial class FieldList : PageBase
    {
        #region 属性及构造方法

        T_Field_BLL fieldBLL = new T_Field_BLL();

        /// <summary>
        /// 总记录数
        /// </summary>
        int itemCount = 0;

        /// <summary>
        /// 每页页数
        /// </summary>
        int pageSize = SystemSet._PAGESIZE;

        protected void Page_Load(object sender, EventArgs e)
        {
            Ajax.Utility.RegisterTypeForAjax(typeof(FieldList));
            if (!IsPostBack)
            {
                MyInit(this.tblSearch);
                BindGridView(1);
            }
        }

        #endregion

        #region 事件

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager_PageChanged(object sender, EventArgs e)
        {
            BindGridView(AspNetPager.CurrentPageIndex);
        }

        /// <summary>
        /// 删除数据字典
        /// </summary>
        /// <param name="archiveListCellRptID"></param>
        /// <param name="OrderIndex"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public void DeleteField(string FieldID)
        {
            fieldBLL.Delete(ConvertEx.ToInt(FieldID));
        }

        /// <summary>
        /// 列表选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void drpType_SelectedIndexChanged()
        {
            this.btnSearch_Click(null, null);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Model.T_Field_MDL model = new DigiPower.Onlinecol.Standard.Model.T_Field_MDL();
            Search(this.tblSearch, model);
            this.BindGridView(1);
        }

        #endregion

        #region 方法

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindGridView(int pageIndex)
        {
            DataTable dt = new DataTable();

            if (ViewState["sqlwhere"] != null && !String.IsNullOrEmpty(ViewState["sqlwhere"].ToString()))
            {
                dt = fieldBLL.GetListPaging(ViewState["sqlwhere"].ToString(), pageSize, pageIndex, out itemCount);
            }
            else if (!String.IsNullOrEmpty(SqlWhere))
            {
                dt = fieldBLL.GetListPaging(SqlWhere, pageSize, pageIndex, out itemCount);
            }
            else
            {
                dt = fieldBLL.GetListPaging("", pageSize, pageIndex, out itemCount);
            }

            AspNetPager.AlwaysShow = true;
            AspNetPager.PageSize = pageSize;

            AspNetPager.RecordCount = itemCount;

            gvData.DataSource = dt;
            gvData.DataBind();

        }

        #endregion
    }
}
