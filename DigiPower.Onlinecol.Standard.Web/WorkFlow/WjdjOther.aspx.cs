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
using DigiPower.Onlinecol.Standard.CBLL;
using DigiPower.Onlinecol.Standard.Common;


//文件登记
namespace DigiPower.Onlinecol.Standard.Web.WorkFlow {
    public partial class WjdjOther : PageBase {
        ColorList colorList = new ColorList();
        T_Other_BLL otherBLL = new T_Other_BLL();
        T_FileList_BLL fileListBLL = new T_FileList_BLL();
        T_SingleProject_BLL spBLL = new T_SingleProject_BLL();

        /// <summary>
        /// 工程ID
        /// </summary>
        public string singleProjectID = string.Empty;

        /// <summary>
        /// 工程编号
        /// </summary>
        public string singleProjectNo = string.Empty;

        /// <summary>
        /// 工程类型
        /// </summary>
        public string projecttype = string.Empty;

        /// <summary>
        /// 流程ID
        /// </summary>
        public string workFlowID = string.Empty;

        public bool IsRollBack = false;

        /// <summary>
        /// 总记录数
        /// </summary>
        int itemCount = 0;

        /// <summary>
        /// 每页页数
        /// </summary>
        int pageSize = 50;

        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(WjdjOther));

            singleProjectID = DNTRequest.GetQueryString("SingleProjectID");
            workFlowID = DNTRequest.GetQueryString("WorkFlowID");

            if (!IsPostBack) {
                ctrlProjectBaseInfo1.DataBindEx(singleProjectID);                     //工程信息      
                rdbFileStatus.DataBindEx(true);
                ddlFileType.DataBindEx(Common.ConvertEx.ToInt(singleProjectID), "0", "BH");

                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("ddlFileType")))
                    ddlFileType.SelectValue = Server.UrlDecode(DNTRequest.GetQueryString("ddlFileType")).ToUpper();
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("txtTitle")))
                    txtTitle.Text = Server.UrlDecode(DNTRequest.GetQueryString("txtTitle"));
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("txtMyCode")))
                    txtMyCode.Text = Server.UrlDecode(DNTRequest.GetQueryString("txtMyCode"));
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("fileStatus")))
                    rdbFileStatus.SelectValue = Server.UrlDecode(DNTRequest.GetQueryString("fileStatus"));

                BindGridView(1);
            }
        }

        /// <summary>
        /// 绑定文件
        /// </summary>
        /// <param name="pageIndex"></param>
        private void BindGridView(int pageIndex) {
            T_SingleProject_MDL spMDL = spBLL.GetModel(Common.ConvertEx.ToInt(singleProjectID));
            if (spMDL != null) {
                singleProjectNo = spMDL.gcbm;
                projecttype = spMDL.ProjectType;

                //取当前工程的所有归档目录
                string strWhere = " SingleProjectID=" + singleProjectID;

                //不显示声像节点 //jdk 2014.11.16
                strWhere += " AND BH not like '%S%' ";

                string ownerFileTmp = Common.Session.GetSession("OwnerFileTmp");
                if (ownerFileTmp.Length > 0) {
                    ownerFileTmp += ",";
                    string[] spfileTmp = ownerFileTmp.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (spfileTmp.Length > 0) {
                        string tempStrWhere = string.Empty;
                        foreach (var bh in spfileTmp) {
                            if (tempStrWhere == string.Empty)
                                tempStrWhere = " and (bh like '" + bh + "%'";
                            else
                                tempStrWhere += " or bh like '" + bh + "%'";
                        }
                        tempStrWhere += ")";
                        strWhere += tempStrWhere;
                    }
                }  

                if (!String.IsNullOrWhiteSpace(txtMyCode.Text.Trim()))
                    strWhere += " AND MyCode LIKE '%" + txtMyCode.Text.Trim() + "%'";
                if (!String.IsNullOrWhiteSpace(txtTitle.Text.Trim()))
                    strWhere += " AND TITLE LIKE '%" + txtTitle.Text.Trim() + "%'";
                if (!String.IsNullOrWhiteSpace(rdbFileStatus.SelectValue) && rdbFileStatus.SelectValue != "0")
                    strWhere += " AND Status=" + rdbFileStatus.SelectValue;
                if (!String.IsNullOrWhiteSpace(ddlFileType.SelectValue) && ddlFileType.SelectValue != "0")
                    strWhere += " AND BH like '" + ddlFileType.SelectValue + "%' ";

                if (ViewState["CurrentPageIndex"] == null && Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex")) > 0) {
                    pageIndex = Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex"));
                    ViewState["CurrentPageIndex"] = pageIndex;
                } else {
                    pageIndex = ConvertEx.ToInt(ViewState["CurrentPageIndex"]);
                }

                DataTable dt = fileListBLL.GetListPaging(strWhere, pageSize, pageIndex, out itemCount); ;
                AspNetPager.AlwaysShow = true;
                AspNetPager.PageSize = pageSize;

                AspNetPager.RecordCount = itemCount;
                AspNetPager.CurrentPageIndex = pageIndex;

                rpData.DataSource = dt;
                rpData.DataBind();
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
            BindGridView(1);
        }

        /// <summary>
        /// 根据文件状态返回文件对应的背景色
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public string getTdColorForFileStatus(object status) {
            return " style='background-color:" + colorList.GetMyColorString(ConvertEx.ToString(status)) + ";'";
        }

        /// <summary>
        /// 根据文件 isFolder 显示返回的Input html
        /// </summary>
        /// <param name="isFolder"></param>                                                                             
        /// <param name="value"></param>
        /// <param name="maxlength"></param>
        /// <param name="jsHtml"></param>
        /// <returns></returns>
        public string getInputTextForIsFolder(object isFolder, object value, string maxlength, string jsHtml) {
            if (ConvertEx.ToBool(isFolder))
                return "<input type=\"text\" title=\"" + value.ToString() + "\" value=\"" + value.ToString() + "\" class=\"regedit_input\" disabled=\"disabled\"  />";
            else
                return "<input type=\"text\" title=\"" + value.ToString() + "\" value=\"" + value.ToString() + "\"" +
                        "class=\"regedit_input\" maxlength=\"" + maxlength + "\" " + jsHtml + "/>";
        }

        /// <summary>
        /// 检查文件对应的PDF文件是否存在
        /// </summary>
        /// <param name="fileListID"></param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public bool CheckPdfFileExistsForFileListID(int fileListID) {
            return PublicModel.CheckPdfFileExistsForFileListID(fileListID);
        }
    }
}