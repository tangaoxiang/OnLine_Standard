using System;
using System.Web;
using com.kinggrid.pdf;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using Org.KGBouncyCastle.X509;
using Org.KGBouncyCastle.Utilities.Encoders;
using com.kinggrid.pdf.executes;
using com.kinggrid.encrypt;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Model;
using System.Web.SessionState;
using com.kinggrid.img;
using DigiPower.Onlinecol.Standard.Web.iSignature;


namespace DigiPower.Onlinecol.Standard.Web {
    public class KGHandlerEx : IHttpHandler, IRequiresSessionState {
        /// <summary>
        /// 您将需要在您网站的 web.config 文件中配置此处理程序，
        /// 并向 IIS 注册此处理程序，然后才能进行使用。有关详细信息，
        /// 请参见下面的链接: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable {

            get { return true; }
        }

        BLL.T_FileList_BLL fileBLL = new BLL.T_FileList_BLL();

        public void ProcessRequest(HttpContext context) {
            string option = context.Request.Form["option"];
            if (option == null) option = context.Request.QueryString["option"];

            if ("calculateHash".Equals(option)) {
                string cert = context.Request.Form["cert"];
                string imgData = context.Request.Form["imgData"];
                string imgWidth = context.Request.Form["imgWidth"];
                string imgHeight = context.Request.Form["imgHeight"];
                string imgExt = context.Request.Form["imgExt"];
                string fileIDS = context.Request.Form["fileIDS"];
                string xPoint = context.Request.Form["xPoint"];
                string yPoint = context.Request.Form["yPoint"];
                string signatureDtflag = ConvertEx.ToString(context.Request.Form["signatureDtflag"]);

                bool signatureAllPagePdfflag = ConvertEx.ToBool(context.Request.Form["signatureAllPagePdfflag"]);  //是否签所有页
                string signaturePagen = context.Server.UrlDecode(context.Request.Form["signaturePagen"]);          //特定页码集合

                Hashtable pdfList = GetCleanPdfPath(fileIDS);
                if (pdfList.Count > 0) {
                    KGPdfHummer hummer = null;
                    string tagPdf = string.Empty;
                    FileStream files = null;
                    try {
                        if (imgData == null) {
                            throw new Exception("签章获取错误！");
                        } else {
                            JArray objList = new JArray();
                            X509CertificateParser x509CertificateParser;
                            X509Certificate x509Certificate;
                            DigitalSignatureByKey digitalSignatureByKey;
                            PdfSignature pdfSignature;
                            PdfSignature4KG pdfSignature4KG = new PdfSignature4KG(null, 1, null);
                            KGBase64 base64;
                            KGTextInfo kgTextInfo;
                            string base64str, data;
                            int width, height;
                            JObject obj;
                            byte[] imgb;
                            foreach (DictionaryEntry de in pdfList) {
                                string sourcePdf = de.Value.ToString();
                                tagPdf = GetTagertPdf(sourcePdf);

                                files = new FileStream(tagPdf, FileMode.Create);
                                hummer = KGPdfHummer.CreateSignature(sourcePdf, null, true, files, null, true);
                                x509CertificateParser = new X509CertificateParser();
                                // 公钥证书
                                x509Certificate = x509CertificateParser.ReadCertificate(Hex.Decode(cert));

                                digitalSignatureByKey = new DigitalSignatureByKey();
                                hummer.SetCertificate(x509Certificate, digitalSignatureByKey);

                                pdfSignature = hummer.PdfSignature;

                                base64 = new KGBase64();
                                base64str = imgData.Substring(0, 65);
                                data = imgData.Substring(65);

                                base64.SetBase64Table(base64str);
                                imgb = base64.Decode(data);

                                width = (int)(float.Parse(imgWidth) * 7200F / 254F);
                                height = (int)(float.Parse(imgHeight) * 7200F / 254F);
                                pdfSignature.SetImage(imgb, imgExt.Substring(1), width, height);   

                                ArrayList pagenList = new ArrayList();
                                string[] spPagen = (signaturePagen + ",").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                foreach (var vr in spPagen) {
                                    pagenList.Add(ConvertEx.ToInt(vr));
                                }
                                if (pagenList.Count < 1) pagenList.Add(1);
                                if (!signatureAllPagePdfflag)  //不签所有页,则签特定页
                                    pdfSignature.SetPagen((Int32[])pagenList.ToArray(typeof(Int32)));


                                //if (searTxt != "")
                                //{
                                //    pdfSignature.SetText(searTxt, true);
                                //}
                                //else
                                //{
                                //    pdfSignature.SetXY(200F, 200F);
                                //}
                                pdfSignature.SetXY(float.Parse(xPoint), float.Parse(yPoint));
                                hummer.PdfSignature = pdfSignature;

                                if (signatureDtflag == "1") //签章加日期
                                {
                                    pdfSignature4KG.SetImage(imgb, imgExt.Substring(1), width, height);
                                    if (!signatureAllPagePdfflag)//不签所有页,则签特定页
                                        pdfSignature4KG.SetPagen((Int32[])pagenList.ToArray(typeof(Int32)));

                                    pdfSignature4KG.SetXY(float.Parse(xPoint), float.Parse(yPoint));

                                    kgTextInfo = new KGTextInfo(DateTime.Now.ToString("yyyy年MM月dd日"));
                                    kgTextInfo.Font = new System.Drawing.Font("宋体", 12);
                                    kgTextInfo.PosType = TextInfoPosType.OUT_SOUTH_MIDDLE;
                                    pdfSignature4KG.AddImgText(kgTextInfo);
                                    hummer.PdfSignature = pdfSignature4KG;
                                }

                                hummer.DoSignature();

                                obj = new JObject()
                                    {  
                                        new JProperty("fileID",de.Key.ToString()),
                                        new JProperty("file",tagPdf),
                                        new JProperty("hash",digitalSignatureByKey.GetHash()),
                                        new JProperty("contentsPostion",digitalSignatureByKey.GetContentsPostion()),
                                    };
                                objList.Add(obj);
                            }
                            context.Response.Write(objList.ToString());
                        }
                    } catch (Exception ex) {
                        if (ex.Message.Contains("iSignature_PDF_API中间件已过期"))
                            context.Response.Write("系统签章过期");
                        else
                            context.Response.Write("系统签章异常:" + ex.Message.ToString());
                    }
                    finally {
                        try { if (files != null) files.Close(); } catch { }
                        if (hummer != null) hummer.Close();
                    }
                }
            } else if ("rewriteSigned".Equals(option)) {
                string cert = context.Request.Form["cert"];
                JArray objList = (JArray)JsonConvert.DeserializeObject(context.Request.Form["jArray"]);
                if (objList != null && objList.Count > 0) {
                    // 公钥证书
                    X509CertificateParser x509CertificateParser = new X509CertificateParser();
                    X509Certificate x509Certificate = x509CertificateParser.ReadCertificate(Hex.Decode(cert));
                    DigitalSignatureByKey digitalSignatureByKey;
                    foreach (JObject obj in objList) {
                        string fileID = Common.ConvertEx.ToString(obj["fileID"]);
                        string pdfPath = Common.ConvertEx.ToString(obj["file"]);
                        long pos = Common.ConvertEx.ToLong(obj["contentsPostion"]);
                        string contents = Common.ConvertEx.ToString(obj["contents"]);

                        digitalSignatureByKey = new DigitalSignatureByKey();
                        digitalSignatureByKey.RewriteContents(pdfPath, x509Certificate.GetEncoded(), pos, contents);
                        UpdateSignatureStatus(fileID, pdfPath, context);
                    }

                }
                context.Response.Write("完成域数字签名！");
            }
        }

        private void UpdateSignatureStatus(string fileID, string pdfPath, HttpContext context) {
            string fileName = Path.GetFileName(pdfPath);
            if (!string.IsNullOrWhiteSpace(fileID) && !string.IsNullOrWhiteSpace(pdfPath)) {
                T_FileList_MDL fileList = fileBLL.GetModel(Convert.ToInt32(fileID));
                if (fileList != null) {
                    fileList.SIGNATURE_FLAG = true;
                    fileList.SIGNATURE_DT = DateTime.Now.ToShortTimeString();
                    fileBLL.Update(fileList);
                }

                #region 增加个人签章保存
                T_FileList_SignatureLog_BLL logBLL = new BLL.T_FileList_SignatureLog_BLL();
                T_FileList_SignatureLog_MDL logMDL = new Model.T_FileList_SignatureLog_MDL();
                logMDL.Signature_DT = DateTime.Now;
                logMDL.SignatureFinish_DT = null;
                logMDL.SingleProjectID = ConvertEx.ToInt(fileList.SingleProjectID);
                logMDL.FileListID = Common.ConvertEx.ToInt(fileList.FileListID);
                logMDL.FileListTmpID = Common.ConvertEx.ToInt(fileList.OldRecID);
                logMDL.Signature_UserID = Common.Session.GetSessionInt("UserID");
                logMDL.Signature_UserRoleCode = Common.Session.GetSession("RoleCode");
                logMDL.OperationType = SystemSet.EumSignatureOperationType.SignatureSave.ToString();
                logMDL.Message = "联合签章-个人签章保存";
                logBLL.Add(logMDL);
                #endregion
            }
        }

        /// <summary>
        /// 生成签章文件路径
        /// </summary>
        /// <param name="sourcePdf"></param>
        /// <returns></returns>
        private string GetTagertPdf(string sourcePdf) {
            string mPDF = string.Empty;

            if (!string.IsNullOrEmpty(sourcePdf)) {
                mPDF = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(sourcePdf)),
                    "MPDF", Path.GetFileName(sourcePdf));
            }
            return mPDF;
        }

        /// <summary>
        /// 获取未签章pdf集合
        /// </summary>
        private Hashtable GetCleanPdfPath(string fileIDS) {
            Hashtable cleanPdfPath = new Hashtable();
            string strWhere = "FileListID in(" + fileIDS + ")";

            IList<Model.T_FileList_MDL> fileList = fileBLL.GetModelList(strWhere);
            if (fileList.Count > 0) {
                string mPdfPath = string.Empty;
                string oPdfPath = string.Empty;
                string rootPath = string.Empty;
                foreach (Model.T_FileList_MDL file in fileList) {
                    rootPath = Path.Combine(file.RootPath, file.SingleProjectID.ToString(), "OMPDF");
                    if (!Directory.Exists(rootPath))
                        Directory.CreateDirectory(rootPath);

                    mPdfPath = Path.Combine(file.RootPath, file.SingleProjectID.ToString(), "MPDF", file.PDFFilePath);
                    oPdfPath = Path.Combine(rootPath, file.PDFFilePath);
                    if (!System.IO.File.Exists(oPdfPath) && !System.IO.File.Exists(mPdfPath)) {
                        continue;
                    } else if (System.IO.File.Exists(mPdfPath)) {
                        System.IO.File.Copy(mPdfPath, oPdfPath, true);
                    }

                    //cleanPdfPath.Add(file.FileListID, oPdfPath);
                    LHSignatureFilesList lhSignature = new LHSignatureFilesList();
                    if (!lhSignature.CheckSignatureFinishCount(file.FileListID.ToString(), file.OldRecID.ToString())) {//判断当前用户对该份文件是否签章完成 N继续
                        if (lhSignature.CheckSignatureStatus(file.FileListID.ToString(), file.OldRecID.ToString())) { //单张表格的PDF 或上个用户已签章
                            cleanPdfPath.Add(file.FileListID, oPdfPath);
                        }
                    }
                }
            }
            return cleanPdfPath;
        }

        #endregion
    }
}