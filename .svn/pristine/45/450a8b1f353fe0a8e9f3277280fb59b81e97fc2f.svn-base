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

namespace DigiPower.Onlinecol.Standard.Web.SystemManage {
    public partial class AreaList : PageBase {
        T_Area_BLL areaBLL = new T_Area_BLL();
        /// <summary>
        /// 总记录数
        /// </summary>
        int itemCount = 0;

        /// <summary>
        /// 每页页数
        /// </summary>
        int pageSize = SystemSet._PAGESIZE;

        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(AreaList));
            if (!IsPostBack) {
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("txtArea_code")))
                    txtArea_code.Text = Server.UrlDecode(DNTRequest.GetQueryString("txtArea_code"));
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("txtArea_name")))
                    txtArea_name.Text = Server.UrlDecode(DNTRequest.GetQueryString("txtArea_name"));

                BindGridView(1);
            }
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager_PageChanged(object sender, EventArgs e) {
            ViewState["CurrentPageIndex"] = AspNetPager.CurrentPageIndex;
            BindGridView(AspNetPager.CurrentPageIndex);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e) {
            this.BindGridView(1);
        }

        /// <summary>
        /// 删除机构
        /// </summary>
        /// <param name="archiveListCellRptID"></param>
        /// <param name="OrderIndex"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public bool DeleteArea(string AreaID) {
            bool result = false;
            try {
                T_Area_MDL areaMDL = areaBLL.GetModel(ConvertEx.ToInt(AreaID));
                if (areaMDL != null) {
                    areaBLL.Delete(areaMDL.AreaID);

                    PublicModel.writeLog(SystemSet.EumLogType.DelData.ToString(), string.Concat("T_Area;key=", areaMDL.AreaID,
                        ";area_code=", areaMDL.area_code, ";area_name=", areaMDL.area_name));
                }
                result = true;
            } catch (Exception ex) {
                Common.LogUtil.Debug(this, "删除机构失败", ex);
            }
            return result;
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindGridView(int pageIndex) {
            string sqlWhere = " 1=1 ";

            if (!String.IsNullOrWhiteSpace(txtArea_code.Text.Trim()))
                sqlWhere += " And area_code like '%" + txtArea_code.Text.Trim() + "%'";
            if (!String.IsNullOrWhiteSpace(txtArea_name.Text.Trim()))
                sqlWhere += " And area_name like '%" + txtArea_name.Text.Trim() + "%'";

            if (ViewState["CurrentPageIndex"] == null && Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex")) > 0) {
                pageIndex = Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex"));
                ViewState["CurrentPageIndex"] = pageIndex;
            } else {
                pageIndex = ConvertEx.ToInt(ViewState["CurrentPageIndex"]);
            }
            DataTable dt = areaBLL.GetListPaging(sqlWhere, pageSize, pageIndex, out itemCount);
            AspNetPager.AlwaysShow = true;
            AspNetPager.PageSize = pageSize;

            AspNetPager.RecordCount = itemCount;
            AspNetPager.CurrentPageIndex = pageIndex;

            rpData.DataSource = dt;
            rpData.DataBind();
        }
    }
}
