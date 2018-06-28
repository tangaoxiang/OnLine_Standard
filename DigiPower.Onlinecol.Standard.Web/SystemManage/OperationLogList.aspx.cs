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
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Common;
using System.IO;

namespace DigiPower.Onlinecol.Standard.Web.SystemManage {
    public partial class OperationLogList : PageBase {
        T_OperationLog_BLL operLogBLL = new T_OperationLog_BLL();

        /// <summary>
        /// 总记录数
        /// </summary>
        int itemCount = 0;

        /// <summary>
        /// 每页页数
        /// </summary>
        int pageSize = 30;// SystemSet._PAGESIZE;

        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(OperationLogList));
            MyAddInit();
            if (!IsPostBack) {
                DataBindEx();
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("Description")))
                    txtDescription.Text = Server.UrlDecode(DNTRequest.GetQueryString("Description"));
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("ddlOperationType")))
                    ddlOperationType.SelectedValue = Server.UrlDecode(DNTRequest.GetQueryString("ddlOperationType"));

                BindGridView(AspNetPager.CurrentPageIndex);
            }
        }

        /// <summary>
        /// 绑定操作类别
        /// </summary>
        private void DataBindEx() {
            DataTable dt = new T_SystemInfo_BLL().GetList("CurrentType='OperationType'").Tables[0];
            ddlOperationType.DataTextField = "SystemInfoName";
            ddlOperationType.DataValueField = "lower_SystemInfoCode";
            ddlOperationType.DataSource = dt;
            ddlOperationType.DataBind();
            ddlOperationType.Items.Insert(0, new ListItem("全部", "0"));
        }

        /// <summary>
        ///  导出系统操作异常
        /// </summary>
        /// <param name="gcmc"></param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public string ExportOperationLogToExcel() {
            try {
                string allSql = PublicModel.getExportExcelSql("OperationSql");
                if (!string.IsNullOrWhiteSpace(allSql)) {
                    return ExcelHelp.DataTableToExcel(new T_Other_BLL().GetQueryList(string.Format(allSql, Common.Session.GetSession("OperationsqlWhere"))));
                } else {
                    return SystemSet._RETURN_FAILURE_VALUE + "KEY=OperationSql 获取脚本失败";
                }
            } catch (Exception ex) {
                return SystemSet._RETURN_FAILURE_VALUE + ex.Message;
            }
        }

        /// <summary>
        /// 删除电子文件转换错误日志
        /// </summary>
        /// <param name="archiveListCellRptID"></param>
        /// <param name="OrderIndex"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public void DeleteEFileConvertLog(string logID) {
            operLogBLL.DeleteMore(logID);
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        /// <param name="pageIndex">索引页</param>
        private void BindGridView(int pageIndex) {
            string strWhere = " 1=1 ";
            if (!String.IsNullOrWhiteSpace(txtDescription.Text.Trim()))
                strWhere += " AND ErrorMsg like '%" + txtDescription.Text.Trim() + "%' ";
            if (!String.IsNullOrWhiteSpace(ddlOperationType.SelectedValue) && ddlOperationType.SelectedValue != "0")
                strWhere += " AND lower(Description) = '" + ddlOperationType.SelectedValue.ToLower() + "' ";

            Session["OperationsqlWhere"] = strWhere;

            if (ViewState["CurrentPageIndex"] == null && Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex")) > 0) {
                pageIndex = Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex"));
                ViewState["CurrentPageIndex"] = pageIndex;
            } else {
                pageIndex = ConvertEx.ToInt(ViewState["CurrentPageIndex"]);
            }

            DataTable dt = operLogBLL.GetListPaging(strWhere, pageSize, pageIndex, out itemCount);  
            AspNetPager.AlwaysShow = true;
            AspNetPager.PageSize = pageSize;

            AspNetPager.RecordCount = itemCount;
            AspNetPager.CurrentPageIndex = pageIndex;

            rpData.DataSource = dt;
            rpData.DataBind();
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
    }
}
