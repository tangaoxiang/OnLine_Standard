using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.Model;
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

namespace DigiPower.Onlinecol.Standard.Web.iwebpdf {
    public partial class DocumentEdit : PageBase {

        T_EFile_BLL efileBLL = new T_EFile_BLL();
        T_FileList_BLL fileBLL = new T_FileList_BLL();

        public string mEFilePath;
        protected void Page_Load(object sender, EventArgs e) {
            MyAddInit();
            if (!String.IsNullOrEmpty(ID)) {
                if (DNTRequest.GetQueryString("fileType") == "PDF") {//查看单个PDF                                        
                    T_EFile_MDL Emodel = efileBLL.GetModel(ConvertEx.ToInt(ID));
                    if (Emodel != null) {
                        T_FileList_MDL model = fileBLL.GetModel(ConvertEx.ToInt(Emodel.FileListID));
                        if (model != null) {
                            string LastPath = model.RootPath.Substring(0, model.RootPath.Length - 1);
                            int iPos1 = LastPath.LastIndexOf('\\');
                            LastPath = LastPath.Substring(iPos1 + 1);
                            string mHttpUrl = "http://" + Request.ServerVariables["HTTP_HOST"] + "/" + LastPath;
                            mEFilePath = mHttpUrl + "/" + model.SingleProjectID + "/PDF/" + Emodel.PDFFilePath;

                            if (Convert.ToString(Emodel.PDFFilePath).Trim().Length == 0)
                                MessageBox.ShowAndCloseWin(this, "没有文件,无法查看！");
                        }
                    }
                } else {//查看文件所有的PDF
                    T_FileList_MDL model = fileBLL.GetModel(ConvertEx.ToInt(ID));
                    if (model != null) {
                        if (model.RootPath.Length > 0) {
                            mEFilePath = FormatPdfSrc(model.RootPath, model.SingleProjectID.ToString(), model.PDFFilePath);

                            int outSideRelatedDtCount = 0;              //附件PDF数量
                            string outSideRelatedString = string.Empty;
                            LoadEFileOutSideRelated(model.FileListID.ToString(), out outSideRelatedDtCount, out outSideRelatedString);

                            if (outSideRelatedDtCount > 0) {
                                string btnStr = " <input type=\"button\" id=\"btnfirst\" class=\"buttonFileList\" onclick=\"loadPdf(this,'{0}')\" title=\"{1}\" value=\" 主件 \" />";
                                ltBtnHtml.Text += "<div class=\"divTree\">";
                                ltBtnHtml.Text += String.Format(btnStr, FormatPdfSrc(model.RootPath, model.SingleProjectID.ToString(), model.PDFFilePath), model.Title);
                                ltBtnHtml.Text += outSideRelatedString;
                                ltBtnHtml.Text += "</div>";
                            }
                        } else {
                            MessageBox.ShowAndCloseWin(this, "没有文件,无法查看！");
                        }
                    }
                }
            } else {
                MessageBox.ShowAndCloseWin(this, "没有文件,无法查看！");
            }
        }

        /// <summary>
        /// 电子文件对应的附件信息,一般在外部系统关联 ,比如筑业
        /// </summary>
        /// <param name="fileListID"></param>
        /// <param name="outSideRelatedDtCount"></param>
        /// <param name="outSideRelatedString"></param>
        private void LoadEFileOutSideRelated(string fileListID, out int outSideRelatedDtCount, out string outSideRelatedString) {
            DataTable fileDT = new T_EFile_OutSideRelated_BLL().GetEFileOutSideRelated(fileListID).Tables[0];
            outSideRelatedString = string.Empty;
            outSideRelatedDtCount = 0;

            if (fileDT != null && fileDT.Rows.Count > 0) {
                outSideRelatedDtCount = fileDT.Rows.Count;
                var index = 1;
                string btnStr = " <input type=\"button\" class=\"button\" onclick=\"loadPdf(this,'{0}')\" title=\"{1}\" value=\" 附件{2} \" />";
                foreach (DataRow row in fileDT.Rows) {
                    if (!string.IsNullOrWhiteSpace(row["RootPath"].ToString()) && row["RootPath"].ToString().Length > 0) {
                        outSideRelatedString += String.Format(btnStr, FormatPdfSrc(row["RootPath"].ToString(), row["SingleProjectID"].ToString(),
                            row["PDFFilePath"].ToString()), row["Title"].ToString(), index.ToString());
                        index++;
                    }
                }
            }
        }

        /// <summary>
        /// 格式化,返回PDF预览URL
        /// </summary>
        /// <param name="rootPath"></param>
        /// <param name="singleProjectID"></param>
        /// <param name="pdfFilePath"></param>
        /// <returns></returns>
        private string FormatPdfSrc(string rootPath, string singleProjectID, string pdfFilePath) {
            string LastPath = rootPath.Substring(0, rootPath.Length - 1);
            int iPos1 = LastPath.LastIndexOf('\\');
            LastPath = LastPath.Substring(iPos1 + 1);
            string mHttpUrl = "http://" + Request.ServerVariables["HTTP_HOST"] + "/" + LastPath;
            return (mHttpUrl + "/" + singleProjectID + "/MPDF/" + pdfFilePath + "?rn=" + DateTime.Now.ToString("MMddhhmmssfffff"));
        }
    }
}