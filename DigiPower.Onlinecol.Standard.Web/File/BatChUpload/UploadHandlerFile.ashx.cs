﻿using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Text;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.Common;
using System.Web.SessionState;

namespace DigiPower.Onlinecol.Standard.Web.File {
    /// <summary>
    /// UploadHandler 的摘要说明
    /// </summary>
    public class UploadHandlerFile : IHttpHandler, IRequiresSessionState {
        T_FileList_BLL fileListBLL = new T_FileList_BLL();
        T_EFile_BLL efileBLL = new T_EFile_BLL();

        public void ProcessRequest(HttpContext context) {
            context.Response.ContentType = "text/plain";
            context.Request.ContentEncoding = Encoding.GetEncoding("UTF-8");
            context.Response.ContentEncoding = Encoding.GetEncoding("UTF-8");
            context.Response.Charset = "utf-8";
            string fileListID = Common.DNTRequest.GetQueryString("FileID");                 //文件ID     
            string singleProjectID = Common.DNTRequest.GetQueryString("SingleProjectID");   //工程ID

            HttpPostedFile file = context.Request.Files["Filedata"];
            string uploadPath = string.Concat(Common.Common.EFileStartPath, singleProjectID, "\\ODOC\\");

            if (file != null) {
                string fileName = PublicModel.UpLoadImage1(file, uploadPath);
                if (fileName.IndexOf("Error") < 0)//表示文件上传成功
                {
                    UpdateFile(singleProjectID, fileListID, fileName, file.FileName);
                }

                //下面这句代码缺少的话，上传成功后上传队列的显示不会自动消失
                context.Response.Write("1");
            } else {
                context.Response.Write("0");
            }
        }
        private int GetEfileMaxOrderIndex(string filelistID) {
            return ConvertEx.ToInt(efileBLL.GetEfileMaxOrderIndex(filelistID)) + 10;
        }

        private void UpdateFile(string singleProjectID, string fileListID, string newFileName, string oldFileName) {
            T_EFile_MDL model = new T_EFile_MDL();
            model.PageCounts = 0;// PDFcount;   
            model.FileListID = Common.ConvertEx.ToInt(fileListID);

            model.FileType = 1;
            model.OrderIndex = GetEfileMaxOrderIndex(fileListID);

            model.Title = oldFileName.Substring(0, oldFileName.LastIndexOf('.'));
            model.RootPath = Common.Common.EFileStartPath;//记信根目录即可  
            model.FilePath = newFileName;

            model.FileType = 0;
            model.Status_Text = "上传成功,当晚批量计算页数！";
            model.CREATE_DT = System.DateTime.Now.ToShortDateString();
            model.CONVERT_FLAG = false;

            T_EFile_BLL bll = new T_EFile_BLL();
            int archiveListCellRptID = bll.Add(model);

            //更新文件级转换标志，等批量转换晚上转
            T_FileList_MDL fileListMDL = fileListBLL.GetModel(model.FileListID);
            fileListMDL.CONVERT_FLAG = false;
            fileListMDL.RootPath = Common.Common.EFileStartPath;
            fileListMDL.Version = PublicModel.getFileVersion(fileListMDL.SingleProjectID.ToString());
            fileListBLL.Update(fileListMDL);

            BLL.T_Other_BLL otherBLL = new DigiPower.Onlinecol.Standard.BLL.T_Other_BLL();
            otherBLL.UpdateArchiveStatus(model.FileListID.ToString(), 10, "0");

            PublicModel.writeLog(SystemSet.EumLogType.AddData.ToString(), string.Concat("T_EFile;key=", archiveListCellRptID,
                ";SingleProjectID=", singleProjectID, ";FileListID=", model.FileListID, ";Title=", model.Title));

        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}