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
    public partial class Wjdj : PageBase {
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
            Ajax.Utility.RegisterTypeForAjax(typeof(Wjdj));

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
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("ddlFileType")))
                    ddlFileType.SelectValue = Server.UrlDecode(DNTRequest.GetQueryString("ddlFileType")).ToUpper();
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("txtTitle")))
                    txtTitle.Text = Server.UrlDecode(DNTRequest.GetQueryString("txtTitle"));
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("txtMyCode")))
                    txtMyCode.Text = Server.UrlDecode(DNTRequest.GetQueryString("txtMyCode"));
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("fileStatus")))
                    rdbFileStatus.SelectValue = Server.UrlDecode(DNTRequest.GetQueryString("fileStatus"));
                ddliSignaturePdf.SelectedValue = Server.UrlDecode(DNTRequest.GetQueryString("chkiSignaturePdf"));
                ddlSignatureFinishFlag.SelectedValue = Server.UrlDecode(DNTRequest.GetQueryString("ddlSignatureFinishFlag"));

                BindGridView(1);
            }
        }

        //绑定归档目录
        private void BindGridView(int pageIndex) {
            T_SingleProject_MDL spMDL = spBLL.GetModel(Common.ConvertEx.ToInt(singleProjectID));
            if (spMDL != null) {
                singleProjectNo = spMDL.gcbm;
                projecttype = spMDL.ProjectType;

                //取当前工程的所有归档目录
                string strWhere = " SingleProjectID=" + singleProjectID;

                //不显示声像节点 //jdk 2014.11.16
                strWhere += " AND BH not like '%S%' ";

                if (PublicModel.isCompany() && !PublicModel.isLeader()) { //监理或施工只能看到自己的
                    strWhere += " and operateuserid=" + Common.Session.GetSession("UserID");
                }

                if (ConvertEx.ToBool(SystemSet._ISIGNATUREPDF)) {
                    if (!string.IsNullOrWhiteSpace(ddliSignaturePdf.SelectedValue))
                        strWhere += " AND iSignaturePdf=" + ddliSignaturePdf.SelectedValue + "";   //是否需要签章

                    if (!string.IsNullOrWhiteSpace(ddlSignatureFinishFlag.SelectedValue)) {        //签章完成状态
                        string tempStrWhere = " and iSignaturePdf=1 and IsFolder=0 and (SELECT COUNT(1) from T_FileList_SignatureTmp f1 where f1.FileListID=T_FileList.OldRecID)>0 ";
                        int signatureFinishFlag = ConvertEx.ToInt(ddlSignatureFinishFlag.SelectedValue);//签章是否完成标记 那已签章完成的记录跟需要签章的记录比对.
                        if (signatureFinishFlag == 1) {      //签章完成
                            tempStrWhere += "and (SELECT COUNT(1) from T_FileList_SignatureLog f0 where f0.FileListID=T_FileList.FileListID and f0.SignatureFinishFlag=1)";
                            tempStrWhere += ">=(SELECT COUNT(1) from T_FileList_SignatureTmp f1 where f1.FileListID=T_FileList.OldRecID) ";
                            strWhere += tempStrWhere;
                        } else if (signatureFinishFlag == 0) {//签章未完成
                            tempStrWhere += "and (SELECT COUNT(1) from T_FileList_SignatureLog f0 where f0.FileListID=T_FileList.FileListID and f0.SignatureFinishFlag=1)";
                            tempStrWhere += "<(SELECT COUNT(1) from T_FileList_SignatureTmp f1 where f1.FileListID=T_FileList.OldRecID) ";
                            strWhere += tempStrWhere;
                        }
                    }
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

                Session["FileInfostrWhere"] = strWhere;

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
        /// 取归档目录归档情况
        /// </summary>
        /// <param name="SingleProjectID"></param>
        /// <returns>需要归档目录数|已归档目录数|需要归档页数|已归档页数</returns>
        private string GetArchivelist(int SingleProjectID) {
            DataSet ds = (new UserOperate()).GetArchiveCount(SingleProjectID);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0) {
                return ds.Tables[0].Rows[0]["countlist"].ToString() + "|" + ds.Tables[0].Rows[0]["winrecvlist"].ToString() + "|" + ds.Tables[0].Rows[0]["pagescount"].ToString() + "|" + ds.Tables[0].Rows[0]["winrecvpagescount"].ToString();
            } else
                return "";
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
        /// 当前文件下是否包含子目录
        /// </summary>                                  
        /// <param name="fileListID"></param>
        /// <param name="singleProjectID"></param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public bool CheckFileExistsIsFolder(string fileListID, string singleProjectID) {
            if (!String.IsNullOrWhiteSpace(fileListID) && !String.IsNullOrWhiteSpace(singleProjectID)) {
                DataTable dt = fileListBLL.GetList("SingleProjectID=" + singleProjectID + " and IsFolder=1 and PID=" + fileListID).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                    return false;
                else
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 生成新增条目的文件编号
        /// </summary>
        /// <param name="BH"></param>
        /// <param name="singleProjectID"></param>
        /// <param name="fileListID"></param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public string GetBH(string singleProjectID, string fileListID) {
            if (!String.IsNullOrWhiteSpace(fileListID) && !String.IsNullOrWhiteSpace(singleProjectID)) {
                return otherBLL.GetBH(singleProjectID, fileListID);
            } else {
                return string.Empty;
            }
        }

        /// <summary>
        /// 新增或修改文件
        /// </summary>
        /// <param name="strIsFolder"></param>
        /// <param name="strFileListID"></param>
        /// <param name="strSingleProjectId"></param>
        /// <param name="strTitle"></param>
        /// <param name="strZRR"></param>
        /// <param name="strWTH"></param>
        /// <param name="strStartTime"></param>
        /// <param name="strManualCount"></param>
        /// <param name="strBH"></param>
        /// <param name="strPID"></param>
        /// <param name="strDefaultCompanyType"></param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public string ExctFileList(string strIsFolder, string strFileListID, string strSingleProjectId,
            string strTitle, string strZRR, string strWTH, string strStartTime, string strManualCount,
            string strBH, string strPID, string myCode, string DefaultCompanyType, string strOldRecID) {
            string ReturnValue = "0";
            try {
                T_FileList_BLL Bll = new T_FileList_BLL();
                T_FileList_MDL Mdl = new T_FileList_MDL();

                int FileListId = ConvertEx.ToInt(strFileListID);
                string SingleProjectId = strSingleProjectId;

                if (FileListId > 0) {
                    Mdl = Bll.GetModel(FileListId);
                } else {
                    Mdl.PID = ConvertEx.ToInt(strPID);
                    Mdl.DefaultCompanyType = ConvertEx.ToInt(DefaultCompanyType);
                    Mdl.CompanyID = ConvertEx.ToInt(Common.Session.GetSession("CompanyID"));
                    Mdl.OperateUserID = ConvertEx.ToInt(Common.Session.GetSession("UserID"));
                    Mdl.recID = Bll.GetMaxRecID(SingleProjectId);
                    Mdl.IsSystem = false;
                    Mdl.BH = strBH;
                    Mdl.IsFolder = ConvertEx.ToBool(strIsFolder);
                    Mdl.PagesCount = 0;//上传页数默认为0 
                    Mdl.OrderIndex = 0;  //文件序号默认为0,组完卷,根据文件编号自动生成序号
                }

                Mdl.OldRecID = ConvertEx.ToInt(strOldRecID);//归档目录模板ID不能变,以后用户签章,模板ID关联签章流程
                Mdl.shr_3 = "0";
                Mdl.w_t_h = strWTH;
                Mdl.SingleProjectID = ConvertEx.ToInt(SingleProjectId);
                Mdl.zrr = strZRR;
                Mdl.Title = strTitle;
                Mdl.ManualCount = ConvertEx.ToInt(strManualCount);
                Mdl.MyCode = myCode;
                Mdl.CreateDate = DateTime.Now;//文件登记时间
                Mdl.Version = PublicModel.getFileVersion(SingleProjectId);  //获取文件的版本号

                if (strStartTime != null && strStartTime.Trim().Length > 0) {
                    Mdl.StartTime = ConvertEx.ToDate(strStartTime).ToString("yyyy-MM-dd");
                }

                if (FileListId > 0 && !Mdl.IsFolder) {
                    Bll.Update(Mdl);
                    PublicModel.writeLog(SystemSet.EumLogType.UpdData.ToString(), string.Concat("T_FileList;key=", Mdl.FileListID,
                         ";SingleProjectID=", Mdl.SingleProjectID, ";bh=", Mdl.BH, ";Title=", Mdl.Title));

                    //更改已登记状态
                    BLL.T_Other_BLL otherBLL = new BLL.T_Other_BLL();
                    otherBLL.UpdateArchiveStatus(FileListId.ToString(), 10);
                } else {
                    FileListId = Bll.Add(Mdl);
                    PublicModel.writeLog(SystemSet.EumLogType.AddData.ToString(), string.Concat("T_FileList;key=", FileListId,
                        ";SingleProjectID=", Mdl.SingleProjectID, ";bh=", Mdl.BH, ";Title=", Mdl.Title));
                }
                ReturnValue = FileListId.ToString();
            } catch (Exception ex) {
                LogUtil.Debug(this, "文件登记归档目录保存操作", ex);
            }
            return ReturnValue;
        }

        /// <summary>
        /// 删除归档目录,模板目录不能删除
        /// </summary>
        /// <param name="FileListID"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public bool DeleteFileList(string FileListID) {
            bool flag = false;
            T_FileList_BLL Bll = new T_FileList_BLL();
            T_FileList_MDL Mdl = Bll.GetModel(ConvertEx.ToInt(FileListID));
            if (Mdl != null && !Mdl.IsSystem) {
                Bll.Delete(ConvertEx.ToInt(FileListID));
                PublicModel.writeLog(SystemSet.EumLogType.DelData.ToString(), string.Concat("T_FileList;key=", FileListID,
                    ";SingleProjectID=", Mdl.SingleProjectID, ";bh=", Mdl.BH, ";Title=", Mdl.Title));
                flag = true;
            }
            return flag;
        }

        /// <summary>
        ///  重置条目转换标识,文件审核状态 
        /// </summary>
        /// <param name="singleProjectID"></param>
        /// <param name="FileListID"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public void ResetFileStatusAndConvertFlag(string singleProjectID, string FileListID) {
            otherBLL.UpdateArchiveStatus(FileListID, 0, "0");
            fileListBLL.Reset(singleProjectID);
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

        /// <summary>
        /// 根据工程ID 将报表导出PDF,注意:报表必须预先在T_Report做出记录
        /// </summary>
        /// <param name="SingleProjectID">工程ID</param>
        /// <param name="ReportCode">报表类型</param>
        /// <param name="DelOldReportPDF">是否删除已生成的PDF</param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public string ReportExportPDF(string singleProjectID, string reportCode, bool delOldReportPDF) {
            return ReportPDF.ReportExportPDF(singleProjectID, reportCode, delOldReportPDF);
        }
    }
}