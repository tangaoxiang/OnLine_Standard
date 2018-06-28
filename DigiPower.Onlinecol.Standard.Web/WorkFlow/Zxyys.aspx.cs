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
using System.Text;

namespace DigiPower.Onlinecol.Standard.Web.WorkFlow {
    public partial class Zxyys : PageBase {
        ColorList colorList = new ColorList();
        T_FileList_BLL fileListBLL = new T_FileList_BLL();
        T_SingleProject_BLL spBLL = new T_SingleProject_BLL();

        /// <summary>
        /// 工程ID
        /// </summary>
        public string singleProjectID = string.Empty;

        /// <summary>
        /// 流程ID
        /// </summary>
        public string workFlowID = string.Empty;

        /// <summary>
        /// 工程类型
        /// </summary>
        public string projectType = string.Empty;

        /// <summary>
        /// 总记录数
        /// </summary>
        int itemCount = 0;

        /// <summary>
        /// 每页页数
        /// </summary>
        int pageSize = 50;//SystemSet._PAGESIZE;

        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(Zxyys));
            singleProjectID = DNTRequest.GetQueryString("SingleProjectID");
            workFlowID = DNTRequest.GetQueryString("WorkFlowID");

            if (!IsPostBack) {
                if (!PublicModel.isCompany() || PublicModel.isLeader()) {
                    ddlCompany.DataBindEx(singleProjectID, string.Concat(SystemSet._JSCOMPANYINFO, ",",
                        SystemSet._JLCOMPANYINFO, ",", SystemSet._SGCOMPANYINFO));
                } else {
                    ddlCompany.DataBindEx(singleProjectID, Common.Session.GetSessionInt("CompanyID"));
                }
                ctrlProjectBaseInfo1.DataBindEx(singleProjectID);                     //工程信息       
                rdbFileStatus.DataBindEx(true);
                ddlFileType.DataBindEx(Common.ConvertEx.ToInt(singleProjectID), "0", "BH");

                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("ddlCompany")))
                    ddlCompany.SelectValue = Server.UrlDecode(DNTRequest.GetQueryString("ddlCompany"));
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("ddlChangeFile")))
                    ddlChangeFile.SelectedValue = Server.UrlDecode(DNTRequest.GetQueryString("ddlChangeFile"));
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
        /// 根据文件状态返回文件对应的背景色
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public string getTdColorForFileStatus(object status) {
            return " style='background-color:" + colorList.GetMyColorString(ConvertEx.ToString(status)) + ";'";
        }

        /// <summary>
        /// 绑定归档目录
        /// </summary>
        /// <param name="pageIndex"></param>
        private void BindGridView(int pageIndex) {
            T_SingleProject_MDL spMDL = spBLL.GetModel(Common.ConvertEx.ToInt(singleProjectID));
            if (spMDL != null) {
                projectType = spMDL.ProjectType;

                string strWhere = " SingleProjectID=" + singleProjectID;
                strWhere += " AND BH not like '%S%' ";      //不显示声像节点 

                if (PublicModel.isSuperAdmin() || !PublicModel.isCompany()) {//Leo 超级管理员看全部                
                } else if (spMDL != null && spMDL.CompanyUserID == Common.ConvertEx.ToInt(Common.Session.GetSession("UserID"))) {//Leo 工程管理员也看全部,档案馆的人也可以看全部
                } else {
                    strWhere += " AND operateuserid=" + Common.Session.GetSession("UserID");
                }

                if (!String.IsNullOrWhiteSpace(txtMyCode.Text.Trim()))
                    strWhere += " AND MyCode LIKE '%" + txtMyCode.Text.Trim() + "%'";
                if (!String.IsNullOrWhiteSpace(txtTitle.Text.Trim()))
                    strWhere += " AND TITLE LIKE '%" + txtTitle.Text.Trim() + "%'";
                if (!String.IsNullOrWhiteSpace(rdbFileStatus.SelectValue) && rdbFileStatus.SelectValue != "0")
                    strWhere += " AND Status=" + rdbFileStatus.SelectValue;
                if (!String.IsNullOrWhiteSpace(ddlCompany.SelectValue) && ddlCompany.SelectValue != "0") {
                    T_Company_BLL compBLL = new T_Company_BLL();
                    T_Company_MDL compMDL = compBLL.GetModel(ConvertEx.ToInt(ddlCompany.SelectValue));
                    if (compMDL != null)
                        strWhere += " AND DefaultCompanyType=" + compMDL.CompanyType + "";
                }
                if (!String.IsNullOrWhiteSpace(ddlFileType.SelectValue) && ddlFileType.SelectValue != "0")
                    strWhere += " AND BH like '" + ddlFileType.SelectValue + "%' ";
                if (!String.IsNullOrWhiteSpace(ddlChangeFile.SelectedValue)) {
                    var changeFile = ddlChangeFile.SelectedValue;
                    if (changeFile == "1") {//有变更 
                        strWhere += " AND ISNULL(version,0)=(SELECT TOP 1 ISNULL(f.RollBackCount,0)from T_WorkFlowDefine f where f.SingleProjectID=" + singleProjectID + " ";
                        strWhere += "AND f.WorkFlowID=" + PublicModel.getWorkFlowIdByWorkFlowCode(SystemSet.EumWorkFlowCode.FILEREG.ToString()) + ") ";
                    }
                    if (changeFile == "0") {//无变更
                        strWhere += " AND ISNULL(version,0) !=(SELECT TOP 1 ISNULL(f.RollBackCount,0)from T_WorkFlowDefine f where f.SingleProjectID=" + singleProjectID + " ";
                        strWhere += "AND f.WorkFlowID=" + PublicModel.getWorkFlowIdByWorkFlowCode(SystemSet.EumWorkFlowCode.FILEREG.ToString()) + ") ";
                    }
                }

                if (ViewState["CurrentPageIndex"] == null && Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex")) > 0) {
                    pageIndex = Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex"));
                    ViewState["CurrentPageIndex"] = pageIndex;
                } else {
                    pageIndex = ConvertEx.ToInt(ViewState["CurrentPageIndex"]);
                }
                DataTable dt = fileListBLL.GetListPaging(strWhere, pageSize, pageIndex, out itemCount);

                AspNetPager.AlwaysShow = true;
                AspNetPager.PageSize = pageSize;

                AspNetPager.RecordCount = itemCount;
                AspNetPager.CurrentPageIndex = pageIndex;

                rpData.DataSource = dt;
                rpData.DataBind();
            }
        }

        /// <summary>
        ///查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e) {
            BindGridView(1);
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

        public string getShowText(object isFolder, string html) {
            if (!ConvertEx.ToBool(isFolder))
                return html;
            else
                return "";
        }

        public string SetTextDisabled(object isFolder) {
            if (ConvertEx.ToBool(isFolder))
                return " disabled='disabled' ";
            else
                return "";
        }

        public string SetCheckBox(object flag) {
            if (ConvertEx.ToBool(flag))
                return " checked='checked' ";
            else
                return "";
        }

        /// <summary>
        /// 预验收通过/不通过
        /// </summary>
        /// <param name="fileListID"></param>
        /// <param name="flag">true:验收通过,false:表示验收不通过</param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public void FileAccept(string fileListID, bool flag) {
            if (flag) { //验收通过 
                T_Other_BLL otherBLL = new T_Other_BLL();
                otherBLL.UpdateArchiveStatus(fileListID, 20, "0");
            } else { //验收不通过
                T_Other_BLL otherBLL = new T_Other_BLL();
                otherBLL.UpdateArchiveStatus(fileListID, 900, "0");
            }
        }

        /// <summary>
        /// 更新文件预验收备注及需要归档的条目
        /// </summary>
        /// <param name="fileListID"></param>
        /// <param name="remark"></param>
        /// <param name="mustSubmitFlag"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public void UpdateFile(string fileListID, string remark, string mustSubmitFlag) {
            T_FileList_MDL fileMDL = fileListBLL.GetModel(ConvertEx.ToInt(fileListID));
            if (fileMDL != null && !fileMDL.IsFolder) {
                fileMDL.Remark = remark;
                fileMDL.MustSubmitFlag = ConvertEx.ToBool(mustSubmitFlag);
                fileListBLL.Update(fileMDL);
            }
        }

        /// <summary>
        /// 恢复
        /// </summary>
        /// <param name="FileListID"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public void ResetStatus(string FileListID) {
            BLL.T_Other_BLL otherBLL = new DigiPower.Onlinecol.Standard.BLL.T_Other_BLL();
            otherBLL.UpdateArchiveStatus(FileListID, -1, "0");//-1表示退回上一次状态
        }

        /// <summary>
        /// 入库能否查看PDF
        /// </summary>
        /// <param name="FileListID"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public bool RKLookPDFFlag(string singleProjectID) {
            bool flag = true;
            T_SingleProject_BLL singleProjectBLL = new T_SingleProject_BLL();
            T_SingleProject_MDL singleProjectMDL = singleProjectBLL.GetModel(ConvertEx.ToInt(singleProjectID));
            if (singleProjectMDL != null) {
                if (ConvertEx.ToInt(singleProjectMDL.Status) >= 3721 && !SystemSet._RKLOOKPDFFLAG) {
                    flag = false;
                }
            }
            return flag;
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