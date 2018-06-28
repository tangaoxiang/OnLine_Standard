using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Model;
using System.Data;
using DigiPower.Onlinecol.Standard.Common;
using System.IO;
using System.Net;

namespace DigiPower.Onlinecol.Standard.Web {

    #region WebService登录类
    /// <summary>
    /// WebService登录类
    /// </summary>
    public class SipHeaderLogin : System.Web.Services.Protocols.SoapHeader {
        /// <summary>
        /// 登录用户名
        /// </summary>
        public string UserName = string.Empty;
        /// <summary>
        /// 登录密码
        /// </summary>
        public string PassWord = string.Empty;

        public bool ValideUser(string _userName, string _passWord) {
            if (_userName != "admin" || _passWord != "digipower_2015") {
                return false;
            } else {
                return true;
            }
        }
    }

    #endregion

    /// <summary>
    /// ImportDataWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class ImportDataWebService : System.Web.Services.WebService {
        T_FileList_BLL fileBLL = new T_FileList_BLL();
        public SipHeaderLogin myHeader;

        private string InsertFileList(XmlNode xmlNode) {
            string rtMsg = string.Empty;
            try {
                #region 新增文件信息
                T_FileList_MDL fileMDL = new T_FileList_MDL();
                string singleProjectID = xmlNode["SINGLEPROJECTID"].InnerText;                   //工程ID
                string operateUserID = xmlNode["OPERATEUSERID"].InnerText;                       //当前用户ID
                string pid = xmlNode["PID"].InnerText;                                           //文件所属类别ID      

                pid = GetFilePID(pid, xmlNode["FROMRECID"].InnerText, xmlNode["FROMTYPE"].InnerText);
                if (ConvertEx.ToInt(pid) < 1) {
                    rtMsg = "传入的PID匹配失败!";
                    return rtMsg;
                }

                T_UsersInfo_MDL userMDL = new T_UsersInfo_BLL().GetModel(ConvertEx.ToInt(operateUserID));
                if (userMDL != null) {
                    fileMDL.OperateUserID = userMDL.UserID;
                    fileMDL.CompanyID = userMDL.CompanyID;
                    T_Company_MDL companyMDL = new T_Company_BLL().GetModel(userMDL.CompanyID);
                    if (companyMDL != null) {
                        fileMDL.DefaultCompanyType = companyMDL.CompanyType;
                    }
                }

                //记录文件在模板中对应的recid
                fileMDL.OldRecID = ConvertEx.ToInt(fileBLL.GetRecID(xmlNode["FROMRECID"].InnerText, xmlNode["FROMTYPE"].InnerText));
                fileMDL.recID = fileBLL.GetMaxRecID(singleProjectID);
                fileMDL.PID = ConvertEx.ToInt(pid);
                fileMDL.IsFolder = false;

                IList<T_FileList_MDL> ltMDL = fileBLL.GetModelList("SingleProjectID=" + singleProjectID + " and recid=" + pid + "");
                if (ltMDL != null && ltMDL.Count > 0) {
                    fileMDL.BH = new T_Other_BLL().GetBH(singleProjectID, ltMDL[0].FileListID.ToString());
                }

                fileMDL.PagesCount = ConvertEx.ToInt(xmlNode["PDFCOUNT"].InnerText);                        //PDF页数
                fileMDL.ManualCount = ConvertEx.ToInt(xmlNode["PDFCOUNT"].InnerText);                       //实体页数

                fileMDL.shr_3 = "0";
                fileMDL.w_t_h = xmlNode["FILEID"].InnerText;
                fileMDL.SingleProjectID = ConvertEx.ToInt(xmlNode["SINGLEPROJECTID"].InnerText);
                fileMDL.zrr = xmlNode["ZRR"].InnerText;
                fileMDL.Title = xmlNode["TITLE"].InnerText;
                fileMDL.CreateDate = DateTime.Now;                                                       //文件登记时间
                fileMDL.StartTime = xmlNode["START_DATE"].InnerText;
                fileMDL.CONVERT_DT = DateTime.Now.ToString("yyyy-MM-dd");                                // xmlNode["START_DATE"].InnerText;
                fileMDL.CONVERT_FLAG = true;
                fileMDL.PDFFilePath = xmlNode["PDFFILEPATH"].InnerText;                                  //合并的PDF文件名称
                fileMDL.RootPath = Common.Common.EFileStartPath;                                         //PDF存放路径
                fileMDL.FROM_SID = xmlNode["SID"].InnerText;                                             //筑业过来的文件SID,二次导入时据此判断
                fileMDL.IsMerge = xmlNode["IsMerge"].InnerText;                                          //合并后的PDF,还是单张表格的PDF
                fileMDL.Status = "10";                                                                   //已登记
                fileMDL.OldStatus = "10";
                fileMDL.SIGNATURE_FLAG = false;                                                         //导入不能为已签章@tyy20160326  
                int fileListID = fileBLL.Add(fileMDL);
                #endregion

                #region 关联文件对应的附件信息,先删除后添加
                T_EFile_OutSideRelated_BLL efileOutSideRelatedBLL = new T_EFile_OutSideRelated_BLL();
                efileOutSideRelatedBLL.DelEfileOutSideRelated(fileListID.ToString(), xmlNode["FROMTYPE"].InnerText);
                if (!string.IsNullOrWhiteSpace(xmlNode["EFILE_OUTSIDERELATED"].InnerText)) {
                    string[] spEfileOutSideRelated = (xmlNode["EFILE_OUTSIDERELATED"].InnerText + ",").Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var fromID in spEfileOutSideRelated) {
                        T_EFile_OutSideRelated_MDL efileOutSideRelatedMDL = new T_EFile_OutSideRelated_MDL();
                        efileOutSideRelatedMDL.FileListID = fileListID.ToString();
                        efileOutSideRelatedMDL.FromID = fromID;
                        efileOutSideRelatedMDL.FromType = xmlNode["FROMTYPE"].InnerText;
                        efileOutSideRelatedBLL.Add(efileOutSideRelatedMDL);
                    }
                }
                #endregion

                rtMsg = SystemSet._RETURN_SUCCESS_VALUE;
            } catch (Exception ex) {
                rtMsg = "failure:" + ex.Message;
            }
            return rtMsg;
        }

        [WebMethod(Description = "接收文件相关信息,返回文件对应上传路径;strXml:文件信息XML")]
        [SoapHeader("myHeader")]
        public string InsertFileData(string strXml) {
            string rtMsg = string.Empty;
            if (!myHeader.ValideUser(myHeader.UserName, myHeader.PassWord)) {
                rtMsg = "无权访问WebService,凭证错误!";
                return rtMsg;
            }
            try {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(strXml);
                XmlNode xmlNode = doc.SelectSingleNode("FILELIST");

                T_SingleProject_MDL singleProjectMDL = new T_SingleProject_BLL().GetModel(
                    ConvertEx.ToInt(xmlNode["SINGLEPROJECTID"].InnerText));
                if (singleProjectMDL != null && singleProjectMDL.WorkFlow_DoStatus != PublicModel.getWorkFlowIdByWorkFlowCode(SystemSet.EumWorkFlowCode.FILEREG.ToString())) {
                    rtMsg = "failure:在线工程必须处在[文件登记]环节才可以导入筑业信息包";
                    return rtMsg;
                }

                DataTable dt = fileBLL.GetList("FROM_SID='" + xmlNode["SID"].InnerText + "'").Tables[0];
                if (dt != null && dt.Rows.Count > 0) {
                    fileBLL.Delete(ConvertEx.ToInt(dt.Rows[0]["FileListID"]));
                    string oldPdfPath = String.Concat(ConvertEx.ToString(dt.Rows[0]["RootPath"]), "\\", xmlNode["SINGLEPROJECTID"].InnerText,
                        "\\", "MPDF", "\\", ConvertEx.ToString(dt.Rows[0]["PDFFilePath"]));
                    if (System.IO.File.Exists(oldPdfPath))
                        System.IO.File.Delete(oldPdfPath);
                }
                rtMsg = InsertFileList(xmlNode);
            } catch (Exception ex) {
                rtMsg = "failure:" + ex.Message;
            }
            return rtMsg;
        }

        [WebMethod(Description = "文件上传 buffer:上传文件字节;fileName:PDF文件名;singleProjectID:工程ID;上传成功返回success;失败返回failure+错误信息")]
        [SoapHeader("myHeader")]
        public string UploadFile(byte[] buffer, string fileName, string singleProjectID) {
            string rtMsg = string.Empty;
            if (!myHeader.ValideUser(myHeader.UserName, myHeader.PassWord)) {
                rtMsg = "无权访问WebService!";
                return rtMsg;
            }

            try {
                string filePath = String.Concat(Common.Common.EFileStartPath, "\\", singleProjectID, "\\", "MPDF");
                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);

                FileStream fs = new FileStream(String.Concat(filePath, "\\", fileName),
                    FileMode.Create, FileAccess.Write);

                //int count = 0;
                //while ((count = stream.Read(buffer, 0, buffer.Length)) > 0)
                //{
                //    fs.Write(buffer, 0, count);
                //}  

                fs.Write(buffer, 0, buffer.Length);

                fs.Flush(); //清空缓冲区   
                fs.Close();  //关闭流
                rtMsg = "success";
            } catch (Exception ex) {
                rtMsg = "failure:" + ex.Message;
            }
            return rtMsg;
        }

        /// <summary>
        /// 获取文件所属 PID
        /// </summary>
        /// <param name="fromPID"></param>
        /// <param name="fromFileKey"></param>
        /// <param name="fromType"></param>
        /// <returns></returns>
        private string GetFilePID(string fromPID, string FromRecID, string fromType) {
            if (ConvertEx.ToInt(fromPID) < 1) //如果外部系统没有传入PID,则根据他们传入的关联文件KEY,在关联表中查找
                return ConvertEx.ToString(fileBLL.GetPID(FromRecID, fromType));
            else                                             //如果外部系统传入PID,则用他们传入的
                return fromPID;
        }

        /* 筑业返回XML 格式
         <?xml version="1.0" encoding="UTF-8"?>
         <FILELIST>
               <SID>127</SID>
               <PID>125</PID>             
               <FROMRECID>125</FROMRECID>
                <FROMTYPE>zhuye</FROMTYPE>                
               <SINGLEPROJECTID>5622</SINGLEPROJECTID>
               <FILEID>1001</FILEID>
               <ZRR/>
               <TITLE>010102 土方回填工程检验批质量验收记录表</TITLE>
               <OPERATEUSERID>11609</OPERATEUSERID>
               <PDFCOUNT>2</PDFCOUNT>
               <BRANCH/>
               <SUBBRANCH/>
               <SUBPROJCET/>
               <PDFFILEPATH>{706D5031-B27D-4540-BA93-D4554700E99B}.pdf</PDFFILEPATH>
               <START_DATE>2015-12-12</START_DATE>
               <IsMerge>1</IsMerge>
               <EFILE_OUTSIDERELATED>{706D5031-B27D-4540-BA93-D4554700E99B}.pdf,{706D5031-B27D-4540-BA93-D4554700E99B}.pdf</EFILE_OUTSIDERELATED>  文件附件
         </FILELIST>
        */
    }
}