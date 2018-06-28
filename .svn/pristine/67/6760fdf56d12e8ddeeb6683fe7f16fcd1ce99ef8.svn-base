using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.Web.iSignature;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DigiPower.Onlinecol.Standard.Web {
    public partial class SignaturePdf : PageBase {
        public string mScriptName;
        public string mServerName;
        public string mHttpUrl;
        public string mServerUrl;
        public string singleProjectID = string.Empty;          //工程ID
        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(SignaturePdf));
            MyAddInit();
            singleProjectID = Common.DNTRequest.GetQueryString("SingleProjectID");
            mServerUrl = string.Concat("http://", Request.Url.Authority, "//PDFServer.aspx?ProNo=",
                singleProjectID, "&rn=", DateTime.Now.ToString("MMddhhmmssf"));
        }

        /// <summary>
        /// 判断当前用户对该份文件是否签章完成
        /// </summary>
        /// <param name="FileListID">文件ID</param>
        /// <param name="FileListTmpID">文件模板ID</param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public bool CheckSignatureFinishCount(string FileListID, string FileListTmpID) {
            LHSignatureFilesList lhSignature = new LHSignatureFilesList();
            return lhSignature.CheckSignatureFinishCount(FileListID, FileListTmpID);
        }


        /// <summary>
        /// 签章日志记录
        /// </summary>
        /// <param name="SignatureType"></param>
        /// <param name="FileListID"></param>
        /// <param name="SingleProjectID"></param>
        /// <param name="FileListTmpID"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public string AddSignatureLog(string SignatureType, string FileListID, string SingleProjectID, string FileListTmpID) {
            string msg = string.Empty;
            try {
                if (SignatureType == "LH")//表示联合签章
                {
                    T_FileList_SignatureLog_BLL logBLL = new T_FileList_SignatureLog_BLL();
                    T_FileList_SignatureLog_MDL logMDL = new T_FileList_SignatureLog_MDL();

                    logMDL.Signature_DT = DateTime.Now;
                    logMDL.SignatureFinish_DT = null;
                    logMDL.SingleProjectID = Common.ConvertEx.ToInt(SingleProjectID);
                    logMDL.FileListID = Common.ConvertEx.ToInt(FileListID);
                    logMDL.FileListTmpID = Common.ConvertEx.ToInt(FileListTmpID);
                    logMDL.Signature_UserID = Common.Session.GetSessionInt("UserID");
                    logMDL.Signature_UserRoleCode = Common.Session.GetSession("RoleCode");
                    logMDL.OperationType = SystemSet.EumSignatureOperationType.SignatureSave.ToString();
                    logMDL.Message = "联合签章-个人签章保存";

                    logBLL.Add(logMDL);
                    msg = SystemSet._RETURN_SUCCESS_VALUE;
                }
            } catch (Exception ex) {
                msg = ex.Message;
            }
            return msg;
        }

        /// <summary>
        /// 签章完成
        /// </summary>
        /// <param name="SignatureType"></param>
        /// <param name="FileListID"></param>
        /// <param name="SingleProjectID"></param>
        /// <param name="FileListTmpID"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public string SignatureFinish(string SignatureType, string FileListID, string SingleProjectID, string FileListTmpID) {
            string msg = string.Empty;
            try {
                if (SignatureType == "LH")//表示联合签章
                {
                    DigiPower.Onlinecol.Standard.BLL.T_FileList_SignatureLog_BLL logBLL = new BLL.T_FileList_SignatureLog_BLL();
                    DigiPower.Onlinecol.Standard.Model.T_FileList_SignatureLog_MDL logMDL = new Model.T_FileList_SignatureLog_MDL();
                    logMDL.SignatureFinish_DT = DateTime.Now;
                    logMDL.Signature_DT = null;
                    logMDL.SignatureFinishFlag = "1";
                    logMDL.SingleProjectID = Common.ConvertEx.ToInt(SingleProjectID);
                    logMDL.FileListID = Common.ConvertEx.ToInt(FileListID);
                    logMDL.FileListTmpID = Common.ConvertEx.ToInt(FileListTmpID);
                    logMDL.Signature_UserID = Common.Session.GetSessionInt("UserID");
                    logMDL.Signature_UserRoleCode = Common.Session.GetSession("RoleCode");
                    logMDL.OperationType = SystemSet.EumSignatureOperationType.SignatureFinish.ToString();
                    logMDL.Message = "联合签章-个人签章完成";

                    logBLL.Add(logMDL);
                    msg = SystemSet._RETURN_SUCCESS_VALUE;
                }
            } catch (Exception ex) {
                msg = ex.Message;
            }
            return msg;
        }
    }
}