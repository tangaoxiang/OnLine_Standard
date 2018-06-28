using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;
using ICSharpCode.SharpZipLib.Checksums;

namespace DigiPower.Onlinecol.Standard.Web
{
    #region ZipClass

    /// <summary>
    /// 压缩类
    /// </summary>
    public class ZipClass
    {
        private const int BUFFER_SIZE = 4096;
        private const int ZIP_LEVEL = 6;

        #region ZipFileDictory

        /// <summary>
        /// 递归压缩文件夹方法
        /// </summary>
        /// <param name="FolderToZip"></param>
        /// <param name="s"></param>
        /// <param name="ParentFolderName"></param>
        public static bool ZipFileDictory(string FolderToZip, ZipOutputStream s, string ParentFolderName)
        {
            bool res = true;
            string[] folders, filenames;
            try
            {
                //创建当前文件夹
                string foldername = string.IsNullOrEmpty(ParentFolderName) ? Path.GetFileName(FolderToZip) : Path.Combine(ParentFolderName, Path.GetFileName(FolderToZip));
                foldername = foldername.Replace('\\', '/');
                ZipEntry entry = new ZipEntry(string.Concat(foldername, "/"));  //加上 “/” 才会当成是文件夹创建
                s.PutNextEntry(entry);
                s.Flush();
                //先压缩文件，再递归压缩文件夹 
                filenames = Directory.GetFiles(FolderToZip);
                foreach (string file in filenames)
                {
                    //打开并压缩文件
                    appendZippedFile(s, foldername, file);
                }
            }
            catch (Exception e)
            {
                res = false;
            }
            folders = Directory.GetDirectories(FolderToZip);
            foreach (string folder in folders)
            {
                string folderName = folder.Replace('\\', '/');
                if (!ZipFileDictory(folderName, s, Path.Combine(ParentFolderName, Path.GetFileName(FolderToZip))))
                    return false;
            }
            return res;
        }

        private static void appendZippedFile(ZipOutputStream s, string foldername, string file)
        {
            FileStream fs = System.IO.File.OpenRead(file);
            ZipEntry entry = new ZipEntry(string.Concat(foldername, "/", Path.GetFileName(file)));
            entry.DateTime = DateTime.Now;
            entry.Size = fs.Length;
            s.PutNextEntry(entry);

            if (fs.Length > 0)
            {
                byte[] buffer = new byte[BUFFER_SIZE];
                Crc32 crc = new Crc32();
                int cnt = 0;
                while ((cnt = fs.Read(buffer, 0, BUFFER_SIZE)) > 0)
                {
                    crc.Update(buffer, 0, cnt);
                    s.Write(buffer, 0, cnt);
                }
                entry.Crc = crc.Value;
            }

            s.Flush();
            fs.Close();
        }

        #endregion

        #region ZipFileDictory

        /// <summary>
        /// 压缩目录
        /// </summary>
        /// <param name="FolderToZip">待压缩的文件夹，全路径格式</param>
        /// <param name="ZipedFile">压缩后的文件名，全路径格式</param>
        /// <returns></returns>
        public static bool ZipFileDictory(string FolderToZip, string ZipedFile, string Password)
        {
            bool res;
            if (!Directory.Exists(FolderToZip))
                return false;
            ZipOutputStream s = new ZipOutputStream(System.IO.File.Create(ZipedFile));
            s.SetLevel(ZIP_LEVEL);
            if (!string.IsNullOrEmpty(Password.Trim()))
                s.Password = Password.Trim();
            res = ZipFileDictory(FolderToZip, s, Password);
            s.Finish();
            s.Close();
            return res;
        }

        #endregion

        #region ZipFile

        /// <summary>
        /// 压缩文件
        /// </summary>
        /// <param name="FileToZip">要进行压缩的文件名</param>
        /// <param name="ZipedFile">压缩后生成的压缩文件名</param>
        /// <returns></returns>
        public static bool ZipFile(string FileToZip, string ZipedFile, string Password)
        {
            //如果文件没有找到，则报错
            if (!System.IO.File.Exists(FileToZip))
                throw new System.IO.FileNotFoundException("指定要压缩的文件: " + FileToZip + " 不存在!");
            //FileStream fs = null;
            FileStream ZipFile = null;
            ZipOutputStream ZipStream = null;
            bool res = true;
            try
            {
                ZipFile = System.IO.File.Create(ZipedFile);
                ZipStream = new ZipOutputStream(ZipFile);
                ZipStream.SetLevel(ZIP_LEVEL);
                if (!string.IsNullOrEmpty(Password.Trim()))
                    ZipStream.Password = Password.Trim();
                appendZippedFile(ZipStream, "", FileToZip);
                ZipStream.Finish();
                ZipStream.Close();
                ZipFile.Close();
            }
            catch
            {
                res = false;
            }

            return res;
        }

        #endregion

        #region Zip

        /// <summary>
        /// 压缩文件 和 文件夹
        /// </summary>
        /// <param name="FileToZip">待压缩的文件或文件夹，全路径格式</param>
        /// <param name="ZipedFile">压缩后生成的压缩文件名，全路径格式</param>
        /// <param name="Password">压缩密码</param>
        /// <returns></returns>
        public static bool Zip(string FileToZip, string ZipedFile, string Password)
        {
            if (Directory.Exists(FileToZip))
            {
                return ZipFileDictory(FileToZip, ZipedFile, Password);
            }
            else if (System.IO.File.Exists(FileToZip))
            {
                return ZipFile(FileToZip, ZipedFile, Password);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 压缩文件 和 文件夹
        /// </summary>
        /// <param name="FileToZip">待压缩的文件或文件夹，全路径格式</param>
        /// <param name="ZipedFile">压缩后生成的压缩文件名，全路径格式</param>
        /// <returns></returns>
        public static bool Zip(string FileToZip, string ZipedFile)
        {

            return Zip(FileToZip, ZipedFile, "");
        }
        #endregion
    }

    #endregion

}
