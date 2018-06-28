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

namespace DigiPower.Onlinecol.Standard.Web.Report {
    public partial class ZmsCertificateList : PageBase {
        T_ReadyCheckBook_BLL readBLL = new T_ReadyCheckBook_BLL();

        /// <summary>
        /// 总记录数
        /// </summary>
        int itemCount = 0;

        /// <summary>
        /// 每页页数
        /// </summary>
        int pageSize = SystemSet._PAGESIZE;

        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(ZmsCertificateList));
            if (!IsPostBack) {
                ddlProjectType.DataBindEx(true);
                BindGridView(1);
            }
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager_PageChanged(object sender, EventArgs e) {
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
        ///  导出excel
        /// </summary>
        /// <param name="gcmc"></param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public string ExportExcel() {
            try {
                string allSql = new ZrsCertificateList().getAllSql(SystemSet.EumReportType.ZMS.ToString(), (Hashtable)Session["ZMS_HtStrWhere"]);
                if (!string.IsNullOrWhiteSpace(allSql)) {
                    return ExcelHelp.DataTableToExcel(new T_Other_BLL().GetQueryList(allSql));
                } else {
                    return SystemSet._RETURN_FAILURE_VALUE + "KEY=ZmsCertificateSql 获取脚本失败";
                }
            } catch (Exception ex) {
                return SystemSet._RETURN_FAILURE_VALUE + ex.Message;
            }
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindGridView(int pageIndex) {     
            Hashtable ht = new Hashtable();
            ht.Add("CodeType", SystemSet.EumReportType.ZMS.ToString());
            if (PublicModel.isSuperAdmin())  //超级管理员
                ht.Add("AREA_CODE", Common.Session.GetSession("AREA_CODE"));
            if (PublicModel.isArchiveUser()) //档案馆用户看自己的
                ht.Add("OLD_AREA_CODE", Common.Session.GetSession("OLD_AREA_CODE"));
            if (!String.IsNullOrWhiteSpace(txtReadyCheckBookCode.Text.Trim()))
                ht.Add("ReadyCheckBookCode", txtReadyCheckBookCode.Text.Trim());
            if (!String.IsNullOrWhiteSpace(txtGcmc.Text.Trim()))
                ht.Add("gcmc", txtGcmc.Text.Trim());
            if (!String.IsNullOrWhiteSpace(txtGcbm.Text.Trim()))
                ht.Add("gcbm", txtGcbm.Text.Trim());
            if (ddlProjectType.SelectValue != "" && ddlProjectType.SelectValue != "0")
                ht.Add("ProjectType", ddlProjectType.SelectValue);
            if (ddlReadyCheckBookType.SelectedValue == "1")
                ht.Add("ReadyCheckBookTypeFlag", 1);
            if (ddlReadyCheckBookType.SelectedValue == "0") {
                ht.Add("ReadyCheckBookTypeFlag", 0);
            }
            Session["ZMS_HtStrWhere"] = ht;
            DataTable dt = readBLL.GetListPaging(ht, pageSize, pageIndex, out itemCount);
            AspNetPager.AlwaysShow = true;
            AspNetPager.PageSize = pageSize;

            AspNetPager.RecordCount = itemCount;
            AspNetPager.CurrentPageIndex = pageIndex;

            rpData.DataSource = dt;
            rpData.DataBind();
        }
    }
}
