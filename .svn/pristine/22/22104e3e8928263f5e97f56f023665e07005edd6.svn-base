using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Xml;
using System.Data;
using System.Xml.Linq;
using SevenZip;

namespace DigiPower.Onlinecol.Distribution.Service {
    class Program {
        static void Main(string[] args) {
            while (true) {
                Console.WriteLine(PublicModel.getNowDateString() + "*****程序开始启动");
                LogUtil.Info(typeof(Program), PublicModel.getNowDateString() + "*****程序开始启动");
                try {
                    Dictionary<string, XmlNode> singleDic = PublicModel.getXmlNodeDic("Single.xml");
                    Dictionary<string, XmlNode> archiveDic = PublicModel.getXmlNodeDic("Archive.xml");
                    Dictionary<string, XmlNode> fileDic = PublicModel.getXmlNodeDic("File.xml");
                    Dictionary<string, XmlNode> efileDic = PublicModel.getXmlNodeDic("EFile.xml");
                    Dictionary<string, XmlNode> imgDic = PublicModel.getXmlNodeDic("ImageGroupInfo.xml");
                    Dictionary<string, XmlNode> pointDic = PublicModel.getXmlNodeDic("SinglePoint.xml");

                    //Dictionary<string, XmlNode> reportDic = PublicModel.getXmlNodeDic("Report.xml");

                    DateTime now = DateTime.Now;
                    if (SystemSet.IsAutoRun) {
                        if ((now.Hour >= 8 && now.Hour <= 20) || now.DayOfWeek == DayOfWeek.Saturday || now.DayOfWeek == DayOfWeek.Sunday) {
                            Console.WriteLine("程序自动运行时间未到!");
                            System.Threading.Thread.Sleep(100000);
                            return;
                        }
                    }
                    if (singleDic.ContainsKey("SearchSql")) {
                        DataTable singleDt = PublicModel.getDataTable(singleDic["SearchSql"].InnerText);
                        if (singleDt != null && singleDt.Rows.Count > 0) {
                            foreach (DataRow singleRow in singleDt.Rows) {
                                XDocument xdoc1 = new XDocument(new XElement("information"));
                                XElement engBaseInfo = new XElement("engBaseInfo");
                                xdoc1.Element("information").Add(engBaseInfo);

                                string gcbm = ConvertEx.ToString(singleRow["gcbm"]);                          //工程编号
                                string singleProjectID = ConvertEx.ToString(singleRow["singleProjectid"]);    //工程ID

                                Console.WriteLine(PublicModel.getNowDateString() + "*****打包工程信息*****工程编号:" + gcbm + "*****工程ID:" + singleProjectID);
                                LogUtil.Info(typeof(Program), PublicModel.getNowDateString() + "*****打包工程信息*****工程编号:" + gcbm + "*****工程ID:" + singleProjectID);

                                #region 工程节点相关信息
                                foreach (var dic in singleDic) {
                                    if (singleDt.Columns.Contains(dic.Key)) {
                                        engBaseInfo.Add(new XElement(dic.Key, new XAttribute("value", singleRow[dic.Key])));
                                    }
                                }
                                #endregion

                                #region 工程坐标相关信息
                                if (pointDic.ContainsKey("SearchSql")) {
                                    DataTable pointDt = PublicModel.getDataTable(string.Format(pointDic["SearchSql"].InnerText, " and a.SingleProjectID=" + singleProjectID));
                                    if (pointDt != null && pointDt.Rows.Count > 0) {
                                        foreach (DataRow pointRow in pointDt.Rows) {
                                            XElement pointXe = getSinglePointXE(pointDic, pointRow, pointDt);
                                            if (pointXe != null) {
                                                engBaseInfo.Add(pointXe);
                                            }
                                        }
                                    }
                                }
                                #endregion

                                #region 创建相关目录
                                string tmpPack = Path.Combine(SystemSet.TmpPath, singleProjectID);
                                if (!Directory.Exists(tmpPack))
                                    Directory.CreateDirectory(tmpPack);
                                if (!Directory.Exists(Path.Combine(tmpPack, "efile")))
                                    Directory.CreateDirectory(Path.Combine(tmpPack, "efile"));
                                if (!Directory.Exists(Path.Combine(tmpPack, "yw")))
                                    Directory.CreateDirectory(Path.Combine(tmpPack, "yw"));
                                if (!Directory.Exists(Path.Combine(tmpPack, "eng-outside-view")))
                                    Directory.CreateDirectory(Path.Combine(tmpPack, "eng-outside-view")); //外观图
                                #endregion

                                #region 案卷节点相关信息
                                if (archiveDic.ContainsKey("SearchSql")) {
                                    DataTable archDt = PublicModel.getDataTable(string.Format(archiveDic["SearchSql"].InnerText, " and a.SingleProjectID=" + singleProjectID));
                                    if (archDt != null && archDt.Rows.Count > 0) {
                                        int archiveXH = 1;
                                        foreach (DataRow archRow in archDt.Rows) {
                                            XElement archiveXe = getArchiveXE(archiveXH, efileDic, fileDic, archiveDic, archRow, archDt);
                                            if (archiveXe != null) {
                                                engBaseInfo.Add(archiveXe);
                                            }
                                            archiveXH++;
                                        }
                                    }
                                }
                                #endregion

                                #region 外观图获取
                                if (SystemSet.IsSharpSingleOutSideView) {
                                    GetOutSideView(singleProjectID);
                                }
                                #endregion

                                #region 声像S类
                                if (imgDic.ContainsKey("SearchSql")) {
                                    string imgSearchSql = imgDic["SearchSql"].InnerText;
                                    DataTable imgPDt = PublicModel.getDataTable(string.Format(imgSearchSql,
                                        string.Concat(" and a.IsFolder=1 and a.SingleProjectID=", singleProjectID)));
                                    if (imgPDt != null && imgPDt.Rows.Count > 0) {
                                        foreach (DataRow imgPRow in imgPDt.Rows) {
                                            DataTable imgSDt = PublicModel.getDataTable(string.Format(imgSearchSql,
                                                 string.Concat(" and a.IsFolder=0 and a.pid=", imgPRow["FileListID"].ToString())));
                                            if (imgSDt != null && imgSDt.Rows.Count > 0) {
                                                XElement ImgGroupInfo = new XElement("ERMS_AI_GROUP_INFO");
                                                ImgGroupInfo.Add(new XElement("ENG_SID", new XAttribute("value", singleProjectID)));
                                                ImgGroupInfo.Add(new XElement("GROUP_EVENT", new XAttribute("value", ConvertEx.ToString(imgPRow["Title"]))));                   //照片组名称

                                                foreach (DataRow imgSRow in imgSDt.Rows) {
                                                    XElement ImgPhotoInfo = new XElement("ERMS_AI_PHOTO_INFO");
                                                    foreach (var dic in imgDic) {
                                                        if (imgSDt.Columns.Contains(dic.Key)) {
                                                            ImgPhotoInfo.Add(new XElement(dic.Key, new XAttribute("value", imgSRow[dic.Key])));
                                                        }
                                                    }

                                                    string rootPath = ConvertEx.ToString(imgSRow["RootPath"]);
                                                    string fileListID = ConvertEx.ToString(imgSRow["FileListID"]);
                                                    string wjbt = ConvertEx.ToString(imgSRow["wjbt"]);

                                                    if (!string.IsNullOrWhiteSpace(rootPath)) {
                                                        FileInfo eFile = new FileInfo(Path.Combine(rootPath, wjbt));
                                                        if (eFile.Exists) {
                                                            string xmlPath = Path.Combine(SystemSet.TmpPath, singleProjectID, "yw", fileListID);
                                                            if (!Directory.Exists(xmlPath))
                                                                Directory.CreateDirectory(xmlPath);
                                                            eFile.CopyTo(Path.Combine(xmlPath, wjbt), true);
                                                        }
                                                    }
                                                    ImgGroupInfo.Add(ImgPhotoInfo);
                                                }
                                                engBaseInfo.Add(ImgGroupInfo);
                                            }
                                        }
                                    }
                                }
                                #endregion

                                xdoc1.Save(Path.Combine(tmpPack, gcbm + ".xml"));

                                #region 打包到指定目录,根据配置是否压缩
                                if (SystemSet.IsSharpZip) {
                                    string zipPath = PublicModel.zipPackage(tmpPack, gcbm + ".zip", SystemSet.SubDirectory);
                                    Directory.Delete(tmpPack, true);
                                    if (File.Exists(zipPath) && !Directory.Exists(tmpPack)) {
                                        PublicModel.changeSingleStatus(singleProjectID);
                                    }
                                    Console.WriteLine(string.Concat(PublicModel.getNowDateString(), ",", gcbm, ",zip打包成功!"));
                                    LogUtil.Info(typeof(Program), string.Concat(PublicModel.getNowDateString(), ",", gcbm, ",zip打包成功!"));
                                } else {
                                    PublicModel.moveFolder(tmpPack, Path.Combine(SystemSet.ZipPath, SystemSet.SubDirectory, gcbm + "-n"));
                                    DirectoryInfo di = new DirectoryInfo(Path.Combine(SystemSet.ZipPath, SystemSet.SubDirectory, gcbm + "-n"));
                                    if (Directory.Exists(Path.Combine(SystemSet.ZipPath, SystemSet.SubDirectory, gcbm + "-y"))) {
                                        Directory.Delete(Path.Combine(SystemSet.ZipPath, SystemSet.SubDirectory, gcbm + "-y"), true);
                                    }
                                    di.MoveTo(Path.Combine(SystemSet.ZipPath, SystemSet.SubDirectory, gcbm + "-y"));

                                    Console.WriteLine(string.Concat(PublicModel.getNowDateString(), ",", gcbm, ",无压缩打包成功!"));
                                    LogUtil.Info(typeof(Program), string.Concat(PublicModel.getNowDateString(), ",", gcbm, ",无压缩打包成功!"));
                                }
                                #endregion
                            }
                            for (var i = 200; i > 0; i--) {
                                Console.WriteLine("程序休眠倒计时:" + i.ToString());
                                System.Threading.Thread.Sleep(1000);
                            }
                        } else {
                            Console.WriteLine("未查询到任何数据!");
                        }
                    }
                } catch (Exception ex) {
                    Console.WriteLine(string.Concat(PublicModel.getNowDateString(), ",BUG:", ex.Message));
                    LogUtil.Debug(typeof(Program), "BUG:", ex);
                }
            }
        }

        /// <summary>
        /// 创建工程坐标节点信息
        /// </summary>
        /// <param name="pointDic"></param>
        /// <param name="pointRow"></param>
        /// <param name="pointDt"></param>
        /// <returns></returns>
        static XElement getSinglePointXE(Dictionary<string, XmlNode> pointDic, DataRow pointRow, DataTable pointDt) {
            string pointID = ConvertEx.ToString(pointRow["PointID"]);
            XElement pointInfo = new XElement("pointInfo");
            try {
                foreach (var dic in pointDic) {
                    if (pointDt.Columns.Contains(dic.Key)) {
                        pointInfo.Add(new XElement(dic.Key, new XAttribute("value", pointRow[dic.Key])));
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine(string.Concat(PublicModel.getNowDateString(), ";创建工程坐标节点信息BUG:", ex.Message));
                LogUtil.Debug(typeof(Program), string.Concat("PointID=", pointID, ";创建工程坐标节点信息BUG:"), ex);
            }
            return pointInfo;
        }

        /// <summary>
        /// 创建案卷节点信息
        /// </summary>   
        /// <param name="archiveXH"></param> 
        /// <param name="efileDic"></param>
        /// <param name="fileDic"></param>
        /// <param name="archiveDic"></param>
        /// <param name="archRow"></param>
        /// <param name="archDt"></param>
        /// <returns></returns>
        static XElement getArchiveXE(int archiveXH, Dictionary<string, XmlNode> efileDic, Dictionary<string, XmlNode> fileDic,
            Dictionary<string, XmlNode> archiveDic, DataRow archRow, DataTable archDt) {
            string archiveID = ConvertEx.ToString(archRow["ArchiveID"]);
            XElement archInfo = new XElement("archInfo");
            try {
                foreach (var dic in archiveDic) {
                    if (archDt.Columns.Contains(dic.Key)) {
                        archInfo.Add(new XElement(dic.Key, new XAttribute("value", archRow[dic.Key])));
                    }
                }
                Console.WriteLine(string.Concat(PublicModel.getNowDateString(), ";打包案卷信息;案卷序号:", archRow["xh"], ";案卷ID:",
                    archRow["ArchiveID"], ";", archiveXH, "/", archDt.Rows.Count));

                if (fileDic.ContainsKey("SearchSql")) {
                    DataTable fileDt = PublicModel.getDataTable(string.Format(fileDic["SearchSql"].InnerText, " and a.ArchiveID=" + archiveID));
                    if (fileDt != null && fileDt.Rows.Count > 0) {
                        int fileIndex = 1;
                        foreach (DataRow fileRow in fileDt.Rows) {
                            XElement fileXe = getFileXE(fileIndex, efileDic, fileDic, fileRow, fileDt);
                            if (fileXe != null) {
                                archInfo.Add(fileXe);
                            }
                            fileIndex++;
                        }
                    }
                }

            } catch (Exception ex) {
                Console.WriteLine(string.Concat(PublicModel.getNowDateString(), ";创建案卷节点信息BUG:", ex.Message));
                LogUtil.Debug(typeof(Program), string.Concat("ArchiveID=", archiveID, ";创建案卷节点信息BUG:"), ex);
            }
            return archInfo;
        }

        //<summary>
        //创建文件节点信息
        //</summary>
        //<param name="fileIndex"></param>
        //<param name="fileDic"></param>
        //<param name="fileRow"></param>
        //<param name="fileDt"></param>
        //<returns></returns>
        static XElement getFileXE(int fileIndex, Dictionary<string, XmlNode> efileDic, Dictionary<string, XmlNode> fileDic, DataRow fileRow, DataTable fileDt) {
            string fileListID = fileRow["FileListID"].ToString();
            string singleProjectID = fileRow["SingleProjectID"].ToString();
            XElement fileInfo = new XElement("fileInfo");
            try {
                foreach (var dic in fileDic) {
                    if (fileDt.Columns.Contains(dic.Key)) {
                        fileInfo.Add(new XElement(dic.Key, new XAttribute("value", fileRow[dic.Key])));
                    }
                }
                Console.WriteLine(string.Concat(PublicModel.getNowDateString(), ";打包文件信息;文件序号:", fileRow["OrderIndex"], ";文件ID:",
                    fileRow["FileListID"], ";", fileIndex, "/", fileDt.Rows.Count));

                string pdfPath = string.Empty;
                string pdfFieName = string.Empty;

                FileInfo source = new FileInfo(Path.Combine(fileRow["RootPath"].ToString(), singleProjectID, "MPDF", fileRow["PDFFilePath"].ToString()));
                if (source.Exists) {
                    string ext = Path.GetExtension(source.FullName);
                    string tarPath = Path.Combine(SystemSet.TmpPath, singleProjectID, "efile");

                    Directory.CreateDirectory(tarPath);
                    if (Directory.Exists(tarPath)) {
                        pdfPath = "/efile/";
                        pdfFieName = string.Concat(fileListID, ext);
                        source.CopyTo(Path.Combine(tarPath, pdfFieName), true);
                    }
                }
                fileInfo.Add(new XElement("pdfPath", new XAttribute("value", pdfPath)));                                        //PDF电子文件路径
                fileInfo.Add(new XElement("pdfFilename", new XAttribute("value", pdfFieName)));                                 //电子文件名称
                fileInfo.Add(new XElement("pdfSourcePath", new XAttribute("value", string.Concat("/yw/", fileListID))));        //原文;   

                if (efileDic.ContainsKey("SearchSql")) {
                    DataTable efileDt = PublicModel.getDataTable(string.Format(efileDic["SearchSql"].InnerText, " and a.FileListID=" + fileListID));
                    if (efileDt != null && efileDt.Rows.Count > 0) {
                        int efileXH = 1;
                        foreach (DataRow efileRow in efileDt.Rows) {
                            CopyEFile(efileRow, efileXH, singleProjectID);
                            Console.WriteLine(string.Concat(PublicModel.getNowDateString(), ";copy电子文件;文件序号:", fileRow["OrderIndex"],
                                ";文件ID:", fileListID, ";", efileXH, "/", efileDt.Rows.Count));
                            efileXH++;
                        }
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine(string.Concat(PublicModel.getNowDateString(), ";创建文件节点信息BUG:", ex.Message));
                LogUtil.Debug(typeof(Program), string.Concat("fileListID=", fileListID, ";创建文件节点信息BUG:"), ex);
            }
            return fileInfo;
        }

        /// <summary>
        /// copy电子文件
        /// </summary>
        /// <param name="efileRow"></param>
        /// <param name="efileXH"></param>
        /// <param name="singleProjectID"></param>
        static bool CopyEFile(DataRow efileRow, int efileXH, string singleProjectID) {
            string archiveListCellRptID = ConvertEx.ToString(efileRow["ArchiveListCellRptID"]);
            string rootPath = ConvertEx.ToString(efileRow["RootPath"]);
            string filePath = ConvertEx.ToString(efileRow["FilePath"]);
            string fileListID = ConvertEx.ToString(efileRow["FileListID"]);
            bool rtFlag = false;
            try {
                if (!string.IsNullOrWhiteSpace(rootPath)) {
                    FileInfo eFile = new FileInfo(Path.Combine(rootPath, singleProjectID, "ODOC", filePath));
                    if (eFile.Exists) {
                        string xmlPath = Path.Combine(SystemSet.TmpPath, singleProjectID, "yw", fileListID);
                        if (!Directory.Exists(xmlPath))
                            Directory.CreateDirectory(xmlPath);

                        eFile.CopyTo(Path.Combine(xmlPath, efileXH.ToString("D3") + Path.GetExtension(filePath)), true);
                        rtFlag = true;
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine(string.Concat(PublicModel.getNowDateString(), ";copy电子文件BUG:", ex.Message, ";fileListID=", fileListID,
                    ";archiveListCellRptID=", archiveListCellRptID, ";rootPath=", rootPath, ";filePath=", filePath));
                LogUtil.Debug(typeof(Program), string.Concat("fileListID=", fileListID, ";archiveListCellRptID=",
                    archiveListCellRptID, ";rootPath=", rootPath, ";filePath=", filePath, ";copy电子文件BUG:"), ex);
            }
            return rtFlag;
        }

        /// <summary>
        /// 工程外观图获取
        /// </summary>
        /// <param name="proSID"></param>
        public static void GetOutSideView(string singleProjectID) {
            try {
                DataTable singlePicDt = PublicModel.getDataTable(string.Concat("select * from T_SingleProject_PIC where PROJ_SID=", singleProjectID, " order by ORDER_INDEX"));
                if (singlePicDt != null && singlePicDt.Rows.Count > 0) {
                    FileInfo source; // = new FileInfo(Path.Combine(OnlineGuideRootPath, proSID, "MPDF", obj.PDFFilePath));
                    foreach (DataRow singlePicRow in singlePicDt.Rows) {
                        string picPath = ConvertEx.ToString(singlePicRow["PIC_PATH"]);
                        if (picPath.Length > 0) {
                            source = new FileInfo(Path.Combine(SystemSet.OnlineGuideRootPath, picPath.Remove(0, 1).Replace("/", "\\")));
                            if (source.Exists) {
                                string tarPath = Path.Combine(SystemSet.TmpPath, singleProjectID, "eng-outside-view");
                                Directory.CreateDirectory(tarPath);
                                if (Directory.Exists(tarPath)) {
                                    source.CopyTo(Path.Combine(tarPath, source.Name), true);
                                }
                            }
                        }
                    }
                }
            } catch (Exception ex) {
                LogUtil.Debug(typeof(Program), string.Concat("singleProjectID=", singleProjectID, ";工程外观图获取BUG:"), ex);
            }
        }
    }
}
