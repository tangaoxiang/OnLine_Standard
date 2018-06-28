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
using System.IO;


namespace DigiPower.Onlinecol.Standard.Web.iSignature {
    /// <summary>
    /// 联合签章
    /// </summary>
    public partial class LHSignatureFilesList : PageBase {
        T_SingleProject_BLL spBLL = new BLL.T_SingleProject_BLL();
        T_FileList_BLL fileBLL = new BLL.T_FileList_BLL();
        T_WorkFlowDefine_BLL wkfBLL = new BLL.T_WorkFlowDefine_BLL();
        T_Company_BLL comBLL = new BLL.T_Company_BLL();
        T_FileList_SignatureLog_BLL signatureLogBLL = new T_FileList_SignatureLog_BLL();

        /// <summary>
        /// 总记录数
        /// </summary>
        int itemCount = 0;

        /// <summary>
        /// 每页页数
        /// </summary>
        int pageSize = 20;

        public string tdBgColor = string.Empty;

        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(LHSignatureFilesList));
            hid_SingleProjectID.Value = DNTRequest.GetQueryString("SingleProjectID");
            hid_ProjectType.Value = DNTRequest.GetQueryString("ProjectType");
            hid_CompanyID.Value = Common.Session.GetSession("CompanyID");

            MyAddInit();
            if (!IsPostBack) {
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("txtTitle")))
                    txtTitle.Text = Server.UrlDecode(DNTRequest.GetQueryString("txtTitle"));
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("txtWth")))
                    txtWth.Text = Server.UrlDecode(DNTRequest.GetQueryString("txtWth"));

                BindGridView(AspNetPager.CurrentPageIndex);
            }
        }

        /// <summary>
        /// 
        /// 只显示已转换PDF的文件+文件登记的工程 
        /// </summary>
        /// <param name="pageIndex"></param>   
        private void BindGridView(int pageIndex) {
            string strWhere = " SingleProjectID=" + hid_SingleProjectID.Value + " AND BH not like '%S%' ";
            strWhere += " AND iSignaturePdf=1 ";//需要签章
            strWhere += " AND CONVERT_FLAG=1 AND exists (SELECT SingleProjectID FROM T_SingleProject where T_FileList.SingleProjectID=T_SingleProject.SingleProjectID and ";
            strWhere += " WorkFlow_DoStatus=" + DNTRequest.GetQueryString("WorkFlow_DoStatus") + ")";

            if (PublicModel.isSignatureCompany()) {
                strWhere += "AND (IsFolder=0  AND OldRecID IN( ";
                strWhere += "SELECT b1.FileListID FROM T_FileList_SignatureTmp b1,(	";
                strWhere += "SELECT RoleCode from T_Role where RoleID=" + Common.Session.GetSession("RoleID") + " ) b2 WHERE b1.SignatureType=b2.RoleCode ))  ";
            }
            if (txtTitle.Text.Trim().Length > 0)
                strWhere += " and Title like '%" + txtTitle.Text.Trim() + "%'";
            if (txtWth.Text.Trim().Length > 0)
                strWhere += " and w_t_h like '%" + txtWth.Text.Trim() + "%'";

            if (ViewState["CurrentPageIndex"] == null && Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex")) > 0) {
                pageIndex = Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex"));
                ViewState["CurrentPageIndex"] = pageIndex;
            } else {
                pageIndex = ConvertEx.ToInt(ViewState["CurrentPageIndex"]);
            }

            DataTable dt = fileBLL.GetLHSignatureFilesList(Common.Session.GetSession("UserID"), strWhere, pageSize, pageIndex, out itemCount);

            AspNetPager.AlwaysShow = true;
            AspNetPager.PageSize = pageSize;

            AspNetPager.RecordCount = itemCount;
            AspNetPager.CurrentPageIndex = pageIndex;

            gvData.DataSource = dt;
            gvData.DataBind();
        }

        /// <summary>
        /// 重新加载
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

        /// <summary>
        /// 更改需要签章的文件行背景色
        /// </summary>
        /// <param name="filelistID"></param>
        /// <param name="oldRecID"></param>
        /// <returns></returns>
        public string setTDBgColor(string filelistID, string oldRecID) {
            string tdColor = string.Empty;
            if (!CheckSignatureFinishCount(filelistID, oldRecID)) {
                if (CheckSignatureStatus(filelistID, oldRecID)) {
                    tdColor = " style=\"background-color: green;\"";
                }
            }
            return tdColor;
        }

        /// <summary>
        /// 判断选择文件是否轮到当前用户来签章
        /// </summary>
        /// <param name="FileListID">文件ID</param>
        /// <param name="FileListTmpID">文件模板ID</param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public bool CheckSignatureStatus(string FileListID, string FileListTmpID) {
            bool flag = false;
            T_FileList_MDL fileListMDL = fileBLL.GetModel(ConvertEx.ToInt(FileListID));
            if (fileListMDL != null && fileListMDL.iSignaturePdf && !fileListMDL.iSignatureWorkFlow) {
                return true;
            }
            if (signatureLogBLL.GetRecordCount("FileListID=" + FileListID + "") < 1) {   //如果一个章都没签,则判断文件模板中第一个章的角色是否是当前用户角色
                DataTable dt = new T_FileList_SignatureTmp_BLL().GetList(1000, "FileListID=" + FileListTmpID + "", "OrderIndex asc ").Tables[0];
                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["SignatureType"].ToString().ToLower() == Common.Session.GetSession("RoleCode", true))
                    flag = true;
            } else {
                if (signatureLogBLL.GetUpSignatureCount(Common.Session.GetSession("RoleCode"), FileListTmpID, FileListID, "1") > 0 ||
                    signatureLogBLL.GetRecordCount("FileListID=" + FileListID + " And Signature_UserRoleCode='" + Common.Session.GetSession("RoleCode", false) + "'") > 0)
                    flag = true;    //当前用户角色的上个角色已签章完成 或当前用户角色已签过章
            }

            return flag;
        }

        /// <summary>
        /// 判断选择文件是否轮到当前用户来签章
        /// </summary>
        /// <param name="FileListID">文件ID</param>
        /// <param name="FileListTmpID">文件模板ID</param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public int GetSignatureCount(string FileListID) {
            Hashtable ht = new Hashtable();
            ht.Add("FileListID", FileListID);
            ht.Add("Signature_UserRoleCode", Common.Session.GetSession("RoleCode"));
            ht.Add("OperationType", SystemSet.EumSignatureOperationType.SignatureSave.ToString());

            return signatureLogBLL.GetSignatureCount(ht);
        }

        /// <summary>  
        /// 判断当前用户对该份文件是否签章完成
        /// </summary>
        /// <param name="FileListID">文件ID</param>
        /// <param name="FileListTmpID">文件模板ID</param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public bool CheckSignatureFinishCount(string FileListID, string FileListTmpID) {
            bool flag = false;
            if (signatureLogBLL.GetRecordCount("SignatureFinishFlag='1' And FileListID=" +
                FileListID + " And Signature_UserRoleCode='" + Common.Session.GetSession("RoleCode", false) + "'") > 0)
                flag = true;

            return flag;
        }

        /// <summary>
        /// 签章完成(前提自己签章未完成,有过签章)
        /// </summary>
        /// <param name="FileListID">文件IDS</param>
        /// <param name="FileListTmpIDS">文件模板IDS</param>
        /// <param name="SingleProjectID">工程ID</param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public string SignatureFinish(string FileListIDS, string FileListTmpIDS, string SingleProjectID) {
            string msg = string.Empty;
            try {
                string[] strFileArray = FileListIDS.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                string[] strFileTmpArray = FileListTmpIDS.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                for (var i = 0; i < strFileArray.Length; i++) {
                    var fileID = strFileArray[i];
                    var fileTmpID = strFileTmpArray[i];

                    string strWhere = " FileListID=" + fileID + " And Signature_UserRoleCode='" + Common.Session.GetSession("RoleCode", false) + "'";
                    if (signatureLogBLL.GetRecordCount("SignatureFinishFlag='1' And " + strWhere) < 1 &&
                        signatureLogBLL.GetRecordCount(strWhere) > 0) {
                        T_FileList_SignatureLog_MDL signatureLogMDL = new T_FileList_SignatureLog_MDL();
                        signatureLogMDL.SignatureFinish_DT = DateTime.Now;
                        signatureLogMDL.SignatureFinishFlag = "1";
                        signatureLogMDL.Signature_DT = null;

                        signatureLogMDL.SingleProjectID = Common.ConvertEx.ToInt(SingleProjectID);
                        signatureLogMDL.FileListID = Common.ConvertEx.ToInt(fileID);
                        signatureLogMDL.FileListTmpID = Common.ConvertEx.ToInt(fileTmpID);
                        signatureLogMDL.Signature_UserID = Common.Session.GetSessionInt("UserID");
                        signatureLogMDL.Signature_UserRoleCode = Common.Session.GetSession("RoleCode");
                        signatureLogMDL.OperationType = SystemSet.EumSignatureOperationType.SignatureFinish.ToString();
                        signatureLogMDL.Message = "联合签章-个人签章完成";

                        signatureLogBLL.Add(signatureLogMDL);
                    }
                }
                msg = SystemSet._RETURN_SUCCESS_VALUE;
            } catch (Exception ex) {
                msg = SystemSet._RETURN_FAILURE_VALUE + ex.Message;
            }
            return msg;
        }

        /// <summary>
        /// 签章重置
        /// </summary>
        /// <param name="fileListID"></param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public string SignatureResetFlag(string fileListID) {
            string strMsg = string.Empty;
            if (!string.IsNullOrWhiteSpace(fileListID)) {
                T_FileList_MDL model = fileBLL.GetModel(Common.ConvertEx.ToInt(fileListID));
                if (model != null) {
                    if (!string.IsNullOrEmpty(model.RootPath) && !string.IsNullOrEmpty(model.PDFFilePath)) {
                        ResetFile(model);
                        signatureLogBLL.UpdateSignatureFinishFlag(true, Common.Session.GetSession("UserID"),
                            Common.Session.GetSession("RoleCode"), model.FileListID.ToString());

                        #region 联合签章-个人签章重置
                        T_FileList_SignatureLog_MDL signatureLogMDL = new T_FileList_SignatureLog_MDL();
                        signatureLogMDL.Signature_DT = DateTime.Now;
                        signatureLogMDL.SignatureFinish_DT = null;
                        signatureLogMDL.SingleProjectID = ConvertEx.ToInt(model.SingleProjectID);
                        signatureLogMDL.FileListID = Common.ConvertEx.ToInt(model.FileListID);
                        signatureLogMDL.FileListTmpID = Common.ConvertEx.ToInt(model.OldRecID);
                        signatureLogMDL.Signature_UserID = Common.Session.GetSessionInt("UserID");
                        signatureLogMDL.Signature_UserRoleCode = Common.Session.GetSession("RoleCode");
                        signatureLogMDL.OperationType = SystemSet.EumSignatureOperationType.SignatureReset.ToString();
                        signatureLogMDL.Message = "联合签章-个人签章重置";
                        signatureLogBLL.Add(signatureLogMDL);
                        #endregion

                        strMsg = SystemSet._RETURN_SUCCESS_VALUE;
                    } else
                        strMsg = "获取文件路径有误，请刷新页面后重试！";
                } else
                    strMsg = "获取文件信息失败，请刷新页面后重试！";

            }
            return strMsg;
        }


        /// <summary>
        /// 重置签章状态以及替换文件
        /// </summary>
        /// <param name="model"></param>
        public void ResetFile(Model.T_FileList_MDL model) {
            string mEFilePath = string.Empty, oMDPdir = string.Empty, mOrgEFilePath = string.Empty;

            oMDPdir = string.Concat(model.RootPath, model.SingleProjectID, "\\OMPDF\\");

            mEFilePath = string.Concat(model.RootPath, model.SingleProjectID, "\\MPDF\\",
                model.PDFFilePath.Replace("/", @"\"));
            mOrgEFilePath = string.Concat(oMDPdir, model.PDFFilePath.Replace("/", @"\"));
            if (!Directory.Exists(oMDPdir)) {
                Directory.CreateDirectory(oMDPdir);
                if (System.IO.File.Exists(mEFilePath))
                    System.IO.File.Copy(mEFilePath, mOrgEFilePath, true);
            } else {
                if (System.IO.File.Exists(mEFilePath))
                    System.IO.File.Copy(mOrgEFilePath, mEFilePath, true);
            }

            model.SIGNATURE_FLAG = false;
            model.SIGNATURE_DT = "";
            fileBLL.Update(model);
        }

        /// <summary>
        /// 检查文件对应的PDF文件是否存在
        /// </summary>
        /// <param name="fileListID"></param>
        /// <returns></returns>
        [Ajax.AjaxMethod]
        public bool CheckPdfFileExistsForFileListID(int fileListID) {
            return PublicModel.CheckPdfFileExistsForFileListID(fileListID);
        }
    }
}