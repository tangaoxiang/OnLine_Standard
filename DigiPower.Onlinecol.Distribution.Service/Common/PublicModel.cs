using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Xml;
using System.Data;
using SevenZip;

namespace DigiPower.Onlinecol.Distribution.Service {
    public static class PublicModel {
        /// <summary>  
        /// 移动文件夹中的所有文件夹与文件到另一个文件夹
        /// </summary>  
        /// <param name="sourcePath">源文件夹</param>  
        /// <param name="destPath">目标文件夹</param>  
        public static void moveFolder(string sourcePath, string destPath) {
            if (Directory.Exists(sourcePath)) {
                if (!Directory.Exists(destPath)) {  //目标目录不存在则创建
                    try {
                        Directory.CreateDirectory(destPath);
                    } catch (Exception ex) {
                        throw new Exception("创建目标目录失败：" + ex.Message);
                    }
                }
                List<string> files = new List<string>(Directory.GetFiles(sourcePath));  //获得源文件下所有文件  
                files.ForEach(c => {
                    string destFile = Path.Combine(new string[] { destPath, Path.GetFileName(c) });   //覆盖模式                   
                    if (File.Exists(destFile)) {
                        File.Delete(destFile);
                    }
                    File.Move(c, destFile);
                });

                List<string> folders = new List<string>(Directory.GetDirectories(sourcePath));   //获得源文件下所有目录文件  
                folders.ForEach(c => {
                    string destDir = Path.Combine(new string[] { destPath, Path.GetFileName(c) });
                    //Directory.Move必须要在同一个根目录下移动才有效，不能在不同卷中移动。  
                    //Directory.Move(c, destDir);  

                    //采用递归的方法实现  
                    moveFolder(c, destDir);
                });
            } else {
                throw new DirectoryNotFoundException("源目录不存在！");
            }
        }

        /// <summary>
        /// 更新工程入库后的状态    Status   rksj
        /// </summary>
        /// <param name="singleProjectID"></param>
        public static void changeSingleStatus(string singleProjectID) {
            if (!string.IsNullOrWhiteSpace(singleProjectID)) {
                if (SystemSet.DBType == 0) {
                    string strSql = "update T_SingleProject set Status=3722,rksj='" + getNowDateString() + "' where SingleProjectID=" + singleProjectID;
                    DbHelperSql.ExecuteSql(strSql);
                } else {
                    string strSql = "update T_SingleProject set Status=3722,rksj=to_date('" + getNowDateString() + "','yyyy-mm-dd hh24:mi:ss') where SingleProjectID=" + singleProjectID;
                    DbHelperOra.ExecuteSql(strSql);
                }
            }
        }

        /// <summary>
        /// 压缩包
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="zipFileName"></param>
        public static string zipPackage(string sourcePath, string zipFileName, string areaCode) {
            try {
                SevenZipCompressor.SetLibraryPath(System.Environment.CurrentDirectory + "\\7z.dll");
                SevenZipCompressor zipCom = new SevenZipCompressor();
                zipCom.ArchiveFormat = OutArchiveFormat.Zip;
                string destPath = Path.Combine(SystemSet.ZipPath, areaCode, zipFileName);
                if (!Directory.Exists(Path.Combine(SystemSet.ZipPath, areaCode)))
                    Directory.CreateDirectory(Path.Combine(SystemSet.ZipPath, areaCode));

                zipCom.CompressDirectory(sourcePath, destPath);
                return destPath;
            } catch {
                throw;
            }
        }

        /// <summary>
        ///  copy 文件夹到指定目录
        /// </summary>
        /// <param name="fromDirectory"></param>
        /// <param name="toDirectory"></param>
        /// <returns></returns>
        //public static string copyFileToNewDirectory(string fromDirectory, string toDirectory) {
        //    if (Directory.Exists(toDirectory)) {
        //        Directory.Delete(toDirectory, true);
        //        Directory.CreateDirectory(toDirectory);
        //    }
        //    foreach (var file in Directory.GetFiles(fromDirectory)) {

        //    }
        //}

        /// <summary>
        /// 获取系统当前日期字符串  yyyy-MM-dd HH:mm:ss格式
        /// </summary>
        /// <returns></returns>
        public static string getNowDateString() {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 根据xmlName返回xml集合
        /// </summary>
        /// <param name="xmlName"></param>
        /// <returns></returns>
        public static Dictionary<string, XmlNode> getXmlNodeDic(string xmlName) {
            Dictionary<string, XmlNode> sqlDic = new Dictionary<string, XmlNode>();
            try {
                XmlDocument doc = new XmlDocument();
                doc.Load(Path.Combine(System.Environment.CurrentDirectory, "dbXml", xmlName));
                XmlNodeList nodeList = doc.SelectSingleNode("SqlList").ChildNodes;
                foreach (XmlNode node in nodeList) {
                    if (String.Compare(node.Name, "SearchSql") == 0) {
                        sqlDic.Add(node.Name, node);
                    } else {
                        foreach (XmlNode snode in node.ChildNodes) {
                            sqlDic.Add(snode.Name, snode);
                        }
                    }
                }
                return sqlDic;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static DataTable getDataTable(string strSql) {
            DataTable dtable = null;
            if (!string.IsNullOrWhiteSpace(strSql)) {
                dtable = new DataTable();
                if (SystemSet.DBType == 0)
                    dtable = DbHelperSql.Query(strSql).Tables[0];
                else
                    dtable = DbHelperOra.Query(strSql).Tables[0];
                return dtable;
            }
            return dtable;
        }
    }
}
