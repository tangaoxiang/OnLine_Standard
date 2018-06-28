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
    public partial class EfileConvertLogList : PageBase {
        T_EFile_ConvertLog_BLL efileLogBLL = new T_EFile_ConvertLog_BLL();

        /// <summary>
        /// 总记录数
        /// </summary>
        int itemCount = 0;

        /// <summary>
        /// 每页页数
        /// </summary>
        int pageSize = SystemSet._PAGESIZE;

        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(EfileConvertLogList));
            MyAddInit();
            if (!IsPostBack) {
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("gcmc")))
                    txtGcmc.Text = Server.UrlDecode(DNTRequest.GetQueryString("gcmc"));

                BindGridView(AspNetPager.CurrentPageIndex);
            }
        }

        /// <summary>
        ///  导出电子文件转换日志
        /// </summary>
        /// <param name="gcmc"></param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public string ExportEfileConvertLogToExcel() {
            try {
                string allSql = PublicModel.getExportExcelSql("EfileConvertSql");
                if (!string.IsNullOrWhiteSpace(allSql)) {
                    return ExcelHelp.DataTableToExcel(new T_Other_BLL().GetQueryList(string.Format(allSql, Common.Session.GetSession("EfileConvertsqlWhere"))));
                } else {
                    return SystemSet._RETURN_FAILURE_VALUE + "KEY=EfileConvertSql 获取脚本失败";
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
            efileLogBLL.DeleteMore(logID);
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        /// <param name="pageIndex">索引页</param>
        private void BindGridView(int pageIndex) {
            string strWhere = " 1=1 ";
            if (!String.IsNullOrWhiteSpace(txtGcmc.Text.Trim()))
                strWhere += " AND f1.gcmc like '%" + txtGcmc.Text.Trim() + "%' ";
            Session["EfileConvertsqlWhere"] = strWhere;

            if (ViewState["CurrentPageIndex"] == null && Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex")) > 0) {
                pageIndex = Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex"));
                ViewState["CurrentPageIndex"] = pageIndex;
            } else {
                pageIndex = ConvertEx.ToInt(ViewState["CurrentPageIndex"]);
            }

            DataTable dt = efileLogBLL.GetListPaging(strWhere, pageSize, pageIndex, out itemCount); ;
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

        /// <summary>
        /// 获取电子文件下载URL
        /// </summary>
        /// <param name="RootPath"></param>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public string GetEFileURL(string RootPath, string FilePath, string SingleProjectID) {
            if (System.IO.File.Exists(Path.Combine(RootPath, SingleProjectID, "ODOC", FilePath))) {
                string LastPath = RootPath.Substring(0, RootPath.Length - 1);
                int iPos1 = LastPath.LastIndexOf('\\');
                LastPath = LastPath.Substring(iPos1 + 1);
                string mHttpUrl = "http://" + Request.ServerVariables["HTTP_HOST"] + "/" + LastPath;

                string strFormat = "<a style=\"cursor: pointer;border:0px;color:white;\" target=\"_blank\" href=\"" + (
                    mHttpUrl + "/" + SingleProjectID + "/ODOC/" + FilePath) + "\" title=\"点击下载查看转换失败的原文\">";
                strFormat += "<img src=\"../Javascript/Layer/image/EFILE.png\" alt=\"\" /></a>";
                return strFormat;
            } else
                return string.Empty;
        }
    }
}
