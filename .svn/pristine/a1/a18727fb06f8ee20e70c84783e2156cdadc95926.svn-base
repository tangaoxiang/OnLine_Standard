using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DigiPower.Onlinecol.Standard.Web.iSignature {
    public partial class SignatureReportPdf : System.Web.UI.Page {

        T_FileList_SignatureLog_BLL logBLL = new T_FileList_SignatureLog_BLL();
        T_FileList_BLL fileBLL = new BLL.T_FileList_BLL();
        T_Other_BLL otherBLL = new T_Other_BLL();

        /// <summary>
        /// PDF后台操作页面
        /// </summary>
        public string mServerUrl = string.Empty;

        /// <summary>
        /// 工程ID
        /// </summary>
        public string singleProjectID = string.Empty;

        /// <summary>
        /// 报表文件名
        /// </summary>

        public string pdfFileName = string.Empty;

        /// <summary>
        /// 报表类型
        /// </summary>
        public string reportType = string.Empty;

        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(SignatureReportPdf));
            singleProjectID = Common.DNTRequest.GetQueryString("SingleProjectID");
            pdfFileName = Common.DNTRequest.GetQueryString("pdfFileName");
            reportType = Common.DNTRequest.GetQueryString("ReportType");
            mServerUrl = string.Concat("http://", Request.Url.Authority, "//ReportPDFServer.aspx?SingleProjectID=",
                singleProjectID, "&rn=" + DateTime.Now.ToString("MMddhhmmssf"), "&pdfFileName=" + pdfFileName);
        }


        /// <summary>
        /// 责任书签章日志
        /// </summary>
        /// <param name="SingleProjectID"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public string SignatureFinish(string singleProjectID, string operationType) {
            string msg = string.Empty;
            try {
                T_FileList_SignatureLog_MDL logMDL = new T_FileList_SignatureLog_MDL();
                logMDL.SignatureFinish_DT = DateTime.Now;
                logMDL.SignatureFinish_DT = null;
                logMDL.SignatureFinishFlag = "1";
                logMDL.FileListTmpID = 0;
                logMDL.SingleProjectID = Common.ConvertEx.ToInt(singleProjectID);
                logMDL.Signature_UserID = Common.Session.GetSessionInt("UserID");
                logMDL.Signature_UserRoleCode = Common.Session.GetSession("RoleCode");
                logMDL.OperationType = operationType;

                logBLL.Add(logMDL);
                msg = SystemSet._RETURN_SUCCESS_VALUE;
            } catch (Exception ex) {
                msg = SystemSet._RETURN_FAILURE_VALUE + ex.Message;
            }
            return msg;
        }

        /// <summary>
        ///  将PDF挂到对应归档目录下
        /// </summary>
        /// <param name="singleProjectID"></param>
        /// <param name="tempPdfFileName">签章完成的临时目录下的PDF</param>
        /// <param name="fileListTmpRecIDS">需要挂接的归档目录ID</param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public string MoveFileToFileTmp(string singleProjectID, string tempPdfFileName, string fileListTmpRecIDS) {
            string msg = string.Empty;
            try {
                IList<T_FileList_MDL> fileListMDL = fileBLL.GetZrsMoveFileRecID(singleProjectID, fileListTmpRecIDS);
                if (fileListMDL.Count > 0) {
                    if (!Directory.Exists(string.Concat(Common.Common.EFileStartPath, singleProjectID, "\\MPDF\\"))) {
                        Directory.CreateDirectory(string.Concat(Common.Common.EFileStartPath, singleProjectID, "\\MPDF\\"));
                    }
                    foreach (T_FileList_MDL mdl in fileListMDL) {
                        string pdfNewFileName = Guid.NewGuid().ToString() + ".PDF";
                        string pdfOldFileName = mdl.PDFFilePath;
                        if (System.IO.File.Exists(Server.MapPath("../Upload/TempReport/" + tempPdfFileName))) {
                            System.IO.File.Copy(Server.MapPath("../Upload/TempReport/" + tempPdfFileName),
                                string.Concat(Common.Common.EFileStartPath, singleProjectID, "\\MPDF\\" + pdfNewFileName), true);

                            T_FileList_MDL tfMdl = fileBLL.GetModel(mdl.FileListID);
                            if (tfMdl != null) {
                                tfMdl.CONVERT_DT = DateTime.Now.ToString("yyyy-MM-dd");
                                tfMdl.CONVERT_FLAG = true;
                                tfMdl.RootPath = Common.Common.EFileStartPath;
                                tfMdl.PDFFilePath = pdfNewFileName;
                                tfMdl.PagesCount = 1;
                                tfMdl.ManualCount = 1;
                                fileBLL.Update(tfMdl);
                            }
                            otherBLL.UpdateArchiveStatus(mdl.FileListID.ToString(), 10, "0"); //更新文件状态

                            //原PDF存在则删除
                            if (System.IO.File.Exists(string.Concat(Common.Common.EFileStartPath, singleProjectID, "\\MPDF\\" + pdfOldFileName))) {
                                System.IO.File.Delete(string.Concat(Common.Common.EFileStartPath, singleProjectID, "\\MPDF\\" + pdfOldFileName));
                            }
                        }
                    }
                }
                msg = SystemSet._RETURN_SUCCESS_VALUE;
            } catch (Exception ex) {
                msg = SystemSet._RETURN_FAILURE_VALUE + ex.Message;
            }
            return msg;
        }
    }
}