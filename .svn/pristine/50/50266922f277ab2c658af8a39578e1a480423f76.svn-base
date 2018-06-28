using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using System.Security.Cryptography;
using System.IO;
using System.Web.Script.Serialization;

using System.Configuration;

namespace DigiPower.Onlinecol.Standard.Common
{
    public static class Common
    {
        /// <summary>
        /// 将datatable转换为json  
        /// </summary>
        /// <param name="dtb">Dt</param>
        /// <returns>JSON字符串</returns>
        public static string DataTableToJson(DataTable dtb)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            System.Collections.ArrayList dic = new System.Collections.ArrayList();
            foreach (DataRow dr in dtb.Rows)
            {
                System.Collections.Generic.Dictionary<string, object> drow = new System.Collections.Generic.Dictionary<string, object>();
                foreach (DataColumn dc in dtb.Columns)
                {
                    drow.Add(dc.ColumnName, dr[dc.ColumnName]);
                }
                dic.Add(drow);
            }
            //序列化  
            return jss.Serialize(dic);
        }

        #region 方法 过滤SQL不安全字符
        /// <summary>
        /// 过滤SQL不安全字符
        /// </summary>
        /// <param name="InputString">输入字符串</param>
        /// <returns></returns>
        public static string SqlSafe(string inputString)
        {
            try
            {
                string[] blackWord = new string[] { "'", ";", "exists", "update ", "insert ", "select ", "delete ", "use ", " and", " or", "exec ", "in ", "set ", "alter ", "add ", "drop ", "execute ", "print ", "create " };
                string returnString = string.Empty;
                if (!string.IsNullOrEmpty(inputString))
                {
                    //returnString = inputString.ToLower();
                    for (int i = 0; i < blackWord.Length; i++)
                    {
                        inputString = inputString.Replace(blackWord[i], "");
                    }
                }
                return inputString;
            }
            catch (Exception e)
            {
                return inputString;
            }
        }
        #endregion

        #region 时间后再产生三位随机数
        /// <summary>
        /// 产生20位的随机数
        /// </summary>
        /// <param name="LeftChar">一个表示类型的大写字母</param>
        /// <param name="gv">三位以内的数字，用于生成不同的随机数种子</param>
        public static string RandomKey(string LeftChar, int incrementInt)
        {
            return LeftChar + DateTime.Now.ToString("yMMddhhmmss") + GetRandomID(100, 900, incrementInt);
        }

        public static int GetRandomID(int minValue, int maxValue, int incrementInt)
        {
            Random ri = new Random(unchecked((int)(DateTime.Now.Ticks + incrementInt)));
            int k = ri.Next(minValue, maxValue);
            return k;
        }

        #endregion

        #region 保存文件
        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="saveDir">文件存放的目录，物理路径</param>
        /// <param name="userPostFile">用户上传的文件</param>
        /// <param name="startChart">生成文件名的开头字母</param>
        /// <returns></returns>
        public static string SaveFile(string saveDir, HttpPostedFile userPostFile, string startChart)
        {
            try
            {
                if (userPostFile.ContentLength > 0)
                {
                    //生成文件名
                    string filename = Path.GetExtension(userPostFile.FileName);
                    filename = RandomKey(startChart, 2) + filename;

                    //如果保存目录不存在，则创建
                    if (!Directory.Exists(saveDir))
                        Directory.CreateDirectory(saveDir);

                    string savePath = saveDir + "\\" + filename;

                    userPostFile.SaveAs(savePath);

                    return filename;
                }
                else
                    return "";
            }
            catch
            {
                return "";
            }
        }
        #endregion

        public static string SaveFile(string saveDir, HttpPostedFile userPostFile, string startChart, string FileNameExtFilter)
        {
            string strFileNameExt = "";
            string strNewFileName = "";
            int iPos = userPostFile.FileName.LastIndexOf('.');
            if (iPos > 0)
            {
                strFileNameExt = userPostFile.FileName.Substring(iPos + 1);
            }
            if (FileNameExtFilter.ToLower().Contains(strFileNameExt.ToLower()))
            {
                strNewFileName = SaveFile(saveDir, userPostFile, startChart);
            }

            return strNewFileName;
        }

        public static string EFileStartPath
        {
            get
            {
                return ConfigurationManager.AppSettings["EFileStartPath"];
            }
        }

        public static string CellFilePath
        {
            get
            {
                return ConfigurationManager.AppSettings["CellFilePath"];
            }
        }

        ///// <summary>
        ///// DES加密
        ///// </summary>
        ///// <param name="str"></param>
        ///// <param name="keys"></param>
        ///// <param name="ivs"></param>
        ///// <returns></returns>
        //public static string MyDESCrypto(string str)
        //{
        //    //加密
        //    byte[] strs = Encoding.Unicode.GetBytes(str);

        //    DESCryptoServiceProvider desc = new DESCryptoServiceProvider();
        //    MemoryStream mStream = new MemoryStream();

        //    ICryptoTransform transform = desc.CreateEncryptor(key, iv);//加密对象
        //    CryptoStream cStream = new CryptoStream(mStream, transform, CryptoStreamMode.Write);
        //    cStream.Write(strs, 0, strs.Length);
        //    cStream.FlushFinalBlock();
        //    return Convert.ToBase64String(mStream.ToArray());
        //}

        ///// <summary>
        ///// DES解密
        ///// </summary>
        ///// <param name="str"></param>
        ///// <param name="keys"></param>
        ///// <param name="ivs"></param>
        ///// <returns></returns>
        //public static string MyDESCryptoDe(string str)
        //{
        //    //解密
        //    byte[] strs = Convert.FromBase64String(str);

        //    DESCryptoServiceProvider desc = new DESCryptoServiceProvider();
        //    MemoryStream mStream = new MemoryStream();

        //    ICryptoTransform transform = desc.CreateDecryptor(key, iv);//解密对象

        //    CryptoStream cStream = new CryptoStream(mStream, transform, CryptoStreamMode.Write);
        //    cStream.Write(strs, 0, strs.Length);
        //    cStream.FlushFinalBlock();
        //    return Encoding.Unicode.GetString(mStream.ToArray());
        //}

        /// <summary>
        /// 转成md5编码
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        public static string MD5String(string origin)
        {
            //作为密码方式加密
            string EnPswdStr = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(origin, "MD5");

            return EnPswdStr;
        }

        /// <summary>
        /// 取图片存放路径
        /// </summary>
        /// <returns></returns>
        public static string GetPhotoPath()
        {
            return "~/upload/photo/";
        }

        /// <summary>
        /// 取当前时间到毫秒的字符串
        /// </summary>
        /// <returns></returns>
        public static string GetDateTimeNowString()
        {
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString().Length == 2 ? DateTime.Now.Month.ToString() : "0" + DateTime.Now.Month.ToString();
            string day = DateTime.Now.Day.ToString().Length == 2 ? DateTime.Now.Day.ToString() : "0" + DateTime.Now.Day.ToString();
            string hour = DateTime.Now.Hour.ToString().Length == 2 ? DateTime.Now.Hour.ToString() : "0" + DateTime.Now.Hour.ToString();
            string minute = DateTime.Now.Minute.ToString().Length == 2 ? DateTime.Now.Minute.ToString() : "0" + DateTime.Now.Minute.ToString();
            string second = DateTime.Now.Second.ToString().Length == 2 ? DateTime.Now.Second.ToString() : "0" + DateTime.Now.Second.ToString();
            string millsecond = DateTime.Now.Millisecond.ToString().Length == 2 ? DateTime.Now.Millisecond.ToString() : "0" + DateTime.Now.Millisecond.ToString();

            StringBuilder sbDateTime = new StringBuilder();
            sbDateTime.Append(year);
            sbDateTime.Append(month);
            sbDateTime.Append(day);
            sbDateTime.Append(hour);
            sbDateTime.Append(minute);
            sbDateTime.Append(second);
            sbDateTime.Append(millsecond);

            return sbDateTime.ToString();
        }

        public static bool isDate(string strDate)
        {
            try
            {
                DateTime.Parse(strDate);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static DateTime DateTimeNullValue = new DateTime(9999, 12, 31, 23, 59, 59);

        public static DateTime SqlDateTimeMinValue = new DateTime(1753, 1, 1, 0, 0, 0);

        /// <summary>
        /// 转换所有null值为DBNull
        /// </summary>
        /// <param name="parameters"></param>
        public static void ConvertNullToDBNull(System.Data.SqlClient.SqlParameter[] parameters)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i].Value == null ||
                    ((parameters[i].SqlDbType.Equals(SqlDbType.DateTime) || parameters[i].SqlDbType.Equals(SqlDbType.SmallDateTime))
                    && System.Data.SqlTypes.SqlDateTime.Equals(parameters[i].Value, DateTimeNullValue)))
                    parameters[i].Value = DBNull.Value;
            }
        }
        public static string CloseAndRefresh()
        {
            //string strNew = "<script type=\"text/javascript\">window.opener.location.href=window.opener.location.href.substring(0,window.opener.location.href.length);window.close();</script>";
            StringBuilder sbNew = new StringBuilder();
            sbNew.Append("<script type=\"text/javascript\">");
            sbNew.Append("if(window.opener.location.href.lastIndexOf('#')==window.opener.location.href.length-1)");
            sbNew.Append("{window.opener.location.href=window.opener.location.href.substring(0,window.opener.location.href.length-1);}");
            sbNew.Append("else");
            sbNew.Append("{window.opener.location.href=window.opener.location.href;}");
            sbNew.Append("window.close();");
            sbNew.Append("</script>");
            return sbNew.ToString();
        }

        /// <summary>
        /// 取整理后节点的颜色
        /// </summary>
        /// <param name="archivedNo"></param>
        /// <param name="allNo"></param>
        /// <returns></returns>
        public static string getNodeColor(int archivedNo, int allNo)
        {
            string color = "black";
            if (archivedNo == 0)
            {
                color = "black";
            }
            else if (archivedNo > 0 && archivedNo < allNo)
            {
                color = "blue";
            }
            else if (archivedNo > 0 && archivedNo == allNo)
            {
                color = "red";
            }
            return color;
        }
        public static string SearchBySingleProjectStatus(string Status)
        {//先预留
            return "";
        }

        /// <summary>
        /// 支持上传的照片文件类型
        /// </summary>
        public static string photoFileTypeName = "*.jpg;*.gif;*.tif;";
        /// <summary>
        /// 上传照片文件的类型描述
        /// </summary>
        public static string photoFileTypeDescription = "照片文件";
        /// <summary>
        /// 照片文件同时上传最大数量
        /// </summary>
        public static string photoFileMaxQueue = "1000";
        /// <summary>
        /// 照片文件最大尺寸，单位：兆
        /// </summary>
        public static string photoFileMaxSize = "20";

        //照片色别分类id
        public static string photoColorId = "116";

        //照片类别分类id
        public static string photoTypeId = "117";

        //照片保管期限分类id
        public static string photoSavePeriodId = "05";

        //照片密级分类id
        public static string photoSecretId = "04";

        public static string GetPDFLicenseKey()
        {
            return "7FDD-FE1D-94E8-C288-B306-A087";//6.0
            //return "7FDD-7E1D-94E8-C288-ADB6-B45F"; //6.2
        }
    }
}
