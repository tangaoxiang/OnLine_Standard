﻿using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Text;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.Common;
using System.Web.SessionState;

namespace DigiPower.Onlinecol.Standard.Web.WorkFlow {
    /// <summary>
    /// UploadHandler 的摘要说明
    /// </summary>
    public class UploadHandler : IHttpHandler, IRequiresSessionState {
        T_FileList_BLL filelistBLL = new T_FileList_BLL();
        T_EFile_BLL efileBLL = new T_EFile_BLL();

        public void ProcessRequest(HttpContext context) {
            context.Response.ContentType = "text/plain";
            context.Request.ContentEncoding = Encoding.GetEncoding("UTF-8");
            context.Response.ContentEncoding = Encoding.GetEncoding("UTF-8");
            context.Response.Charset = "utf-8";
            string pid = Common.DNTRequest.GetQueryString("ID");//组ID

            string SingleProjectID = string.Empty;
            string BH = string.Empty;

            T_FileList_MDL filelistMDL = filelistBLL.GetModel(ConvertEx.ToInt(pid));
            if (filelistMDL != null) {
                SingleProjectID = filelistMDL.SingleProjectID.ToString();
                BH = filelistMDL.BH;
            }
            HttpPostedFile file = context.Request.Files["Filedata"];

            string uploadPath = string.Concat(Common.Common.EFileStartPath, "\\SXImage\\", SingleProjectID + "\\");
            if (file != null) {
                if (!Directory.Exists(uploadPath)) {
                    Directory.CreateDirectory(uploadPath);
                }

                string thumbFilePath = string.Concat(uploadPath, "\\thumb\\");
                if (!Directory.Exists(thumbFilePath)) {
                    Directory.CreateDirectory(thumbFilePath);
                }

                string fileName = PublicModel.UpLoadImage1(file, uploadPath, thumbFilePath, 200, 140);
                if (fileName.IndexOf("Error") < 0)//表示文件上传成功
                {
                    InSertFile(pid, BH, SingleProjectID, fileName, uploadPath);
                }

                //下面这句代码缺少的话，上传成功后上传队列的显示不会自动消失
                context.Response.Write("1");
            } else {
                context.Response.Write("0");
            }
        }

        private void InSertFile(string pid, string bh, string singleProjectId, string fileName, string filePath) {
            int OrderIndex = 1;
            string MaxBH = filelistBLL.GetMaxBH("SingleProjectID=" + singleProjectId + " and bh like '" + bh + "%'");
            if (MaxBH != null && MaxBH.IndexOf("-") > -1) {
                OrderIndex = ConvertEx.ToInt(MaxBH.Substring(MaxBH.LastIndexOf("-") + 1)) + 10;
            }
            MaxBH = string.Concat(bh, "-", OrderIndex.ToString("D3"));

            T_FileList_MDL filelistMDL = new T_FileList_MDL();
            filelistMDL.SingleProjectID = ConvertEx.ToInt(singleProjectId);       //工程ID
            filelistMDL.BH = MaxBH;                                               //编号
            filelistMDL.PID = ConvertEx.ToInt(pid);                               //父ID
            filelistMDL.Title = "照片" + OrderIndex.ToString();                    //提名
            filelistMDL.RootPath = filePath;                                      //保存路径
            filelistMDL.lrr = Common.Session.GetSession("UserID");                //上传人
            filelistMDL.lrsj = DateTime.Now;                                      //上传时间
            filelistMDL.wjbt = fileName;                                          //文件名称
            filelistMDL.IsFolder = false;
            filelistMDL.OrderIndex = OrderIndex;


            if (System.IO.File.Exists(filePath + fileName)) {
                EXIFMetaData em = new EXIFMetaData();
                EXIFMetaData.Metadata m = em.GetEXIFMetaData(filePath + fileName);

                filelistMDL.xjpp = m.EquipmentMake.DisplayValue;            //相机品牌
                filelistMDL.fbl = m.ImageWidth.DisplayValue + "*" + m.ImageHeight.DisplayValue;       //分辨率
                filelistMDL.xjxh = m.CameraModel.DisplayValue;              //相机型号  
                filelistMDL.XAXIS_RESOLUTION = m.XResolution.DisplayValue;  //X轴分辨率
                filelistMDL.YAXIS_RESOLUTION = m.YResolution.DisplayValue;  //Y轴分辨率
                filelistMDL.IMAGE_WIDTH = m.ImageWidth.DisplayValue;        //宽度
                filelistMDL.IMAGE_HEIGHT = m.ImageHeight.DisplayValue;      //高度
                filelistMDL.DATA_FICAL_LENGTH = m.FocalLength.DisplayValue; //焦距
                filelistMDL.DATA_APERTURE = "";                             //光圈
                filelistMDL.DATA_APERTURE_XS = "";                          //光圈系数
                filelistMDL.FLASH = m.Flash.DisplayValue;                   //闪光灯
                filelistMDL.WHITE_BALANCE = "自动";                         //白平衡

                if (m.ISOSpeed.DisplayValue != null && m.ISOSpeed.DisplayValue.Length > 0)
                    filelistMDL.ISO_SPEED_RATINGS = "ISO-" + m.ISOSpeed.DisplayValue;    //感光度
                filelistMDL.EXPOSURE_PROGRAM = m.ExposureProg.DisplayValue; //曝光程序
                filelistMDL.EXPOSURE_MODE = "";                             //曝光模式
                filelistMDL.DATA_EXPOSURE_TIME = m.ExposureTime.DisplayValue;    //曝光时间
                filelistMDL.QUALITY = "正常";     //清晰度
                filelistMDL.CONTRAST = "正常";    //对比度
                filelistMDL.SATURATION = "正常";  //饱和度
                filelistMDL.MAX_APERTURE = m.MaxAperture.DisplayValue; //最大光圈数
                //if (m.DatePictureTaken.DisplayValue != null && m.DatePictureTaken.DisplayValue.Length > 0)
                //{
                //    string[] spDt = m.DatePictureTaken.DisplayValue.Replace("\0", "").Split(new char[] { ' ' });
                //    if (spDt.Length == 2)
                //    {
                //        filelistMDL.pssj = Convert.ToDateTime(string.Concat(spDt[0].Replace(":", "-"), " ",
                //            spDt[1]));
                //    }
                //}
            }

            int FileListID = filelistBLL.Add(filelistMDL);

            BLL.T_Other_BLL otherBLL = new DigiPower.Onlinecol.Standard.BLL.T_Other_BLL();
            otherBLL.UpdateArchiveStatus(FileListID.ToString(), 10, "0");

            PublicModel.writeLog(SystemSet.EumLogType.AddData.ToString(), string.Concat("T_FileList;key=", FileListID,
                ";SingleProjectID=", singleProjectId, ";FileListID=", FileListID, ";Title=", "照片" + OrderIndex.ToString(), ";工程外观图上传"));
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}