using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Configuration;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Web.CommonCtrl;
using System.Text.RegularExpressions;
using System.Collections;
using System.Xml;

namespace DigiPower.Onlinecol.Standard.Web {

    public static class PublicModel {

        /// <summary>
        /// 获取枚举的属性说明 eg:[System.ComponentModel.Description("签章用户")]
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetEnumDescription(Enum enumValue) {
            string str = enumValue.ToString();
            System.Reflection.FieldInfo field = enumValue.GetType().GetField(str);
            object[] objs = field.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
            if (objs == null || objs.Length == 0) return str;
            System.ComponentModel.DescriptionAttribute da = (System.ComponentModel.DescriptionAttribute)objs[0];
            return da.Description;
        }

        /// <summary>
        /// 获取文件的版本号
        /// </summary>
        /// <param name="singleProjectID">工程ID</param>
        /// <returns></returns>
        public static int getFileVersion(string singleProjectID) {
            var version = 0;
            T_WorkFlowDefine_BLL workFlowBLL = new T_WorkFlowDefine_BLL();
            string strWhere = "SingleProjectID=" + singleProjectID + " AND IsRollBack=1 and DoStatus=1 ";
            IList<T_WorkFlowDefine_MDL> list = workFlowBLL.GetModelList(strWhere);
            if (list != null && list.Count > 0)
                version = ConvertEx.ToInt(list[0].RollBackCount);
            return version;
        }

        /// <summary>
        /// 获取excle导出脚本集合
        /// </summary>
        /// <param name="sqlKey"></param>
        /// <returns></returns>
        public static string getExportExcelSql(string sqlKey) {
            Dictionary<string, string> sqlDic = null;
            if (HttpContext.Current.Session["sqlExcelDic"] == null) {
                sqlDic = new Dictionary<string, string>();
                XmlDocument doc = new XmlDocument();
                doc.Load(HttpContext.Current.Server.MapPath("../Report/ExcelTemplate.xml"));
                XmlNodeList nodeList = doc.SelectSingleNode("SqlList").ChildNodes;
                foreach (XmlNode node in nodeList) {
                    sqlDic.Add(node.Name, node.InnerText);
                }
            } else {
                sqlDic = HttpContext.Current.Session["sqlExcelDic"] as Dictionary<string, string>;
            }

            if (sqlDic.ContainsKey(sqlKey))
                return sqlDic[sqlKey];
            else
                return string.Empty;
        }

        /// <summary>
        /// 系统日志
        /// </summary>
        /// <param name="logType">日志类型</param>
        /// <param name="message">日志具体内容</param>
        public static void writeLog(string logType, string message) {
            BLL.T_OperationLog_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_OperationLog_BLL();
            bll.WriteLog(logType, message);
        }
           
        /// <summary>
        /// 根据数据构造Hashtable
        /// </summary>
        /// <param name="key">key集合</param>
        /// <param name="value">value集合</param>
        /// <returns></returns>
        public static Dictionary<string, string> getDictionary(string[] key, string[] value) {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (key.Length == value.Length) {
                for (var i = 0; i < key.Length; i++) {
                    if (!dic.ContainsKey(key[i]))
                        dic.Add(key[i], value[i]);
                }
            }
            return dic;
        }

        /// <summary>
        /// 根据流程编号返回流程ID
        /// </summary>
        /// <param name="workFlowCode"></param>
        /// <param name="companyID"></param>
        /// <returns></returns>
        public static int getWorkFlowIdByWorkFlowCode(string workFlowCode, int companyID = 0) {
            T_WorkFlow_BLL workFlowBLL = new T_WorkFlow_BLL();
            string strWhere = " lower(WorkFlowCode)='" + workFlowCode.ToLower() + "' ";
            if (companyID > 0)
                strWhere += "and CompanyID=" + companyID;
            T_WorkFlow_MDL workFlowMDL = workFlowBLL.GetModelList(strWhere).ToList().FirstOrDefault();
            return (workFlowMDL == null ? 0 : workFlowMDL.WorkFlowID);
        }

        /// <summary>
        /// 根据工程状态ID 返回工程状态Name
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string getSingleProjectStatusNameByStatus(int status) {
            string formatString = "<a style=\"color: black;\" title=\"{0}\">{1}</a>";
            if (status == 3721)
                formatString = string.Format(formatString, "处于移交入库的环节,等待系统后台自动移交入库", "待入库");
            else if (status == 3722)
                formatString = string.Format(formatString, "工程档案数据已移交到库房(内部档案管理系统)", "已入库");
            else if (status == 1)
                formatString = string.Format(formatString, "正常操作中", "正常");
            else
                formatString = string.Format(formatString, "工程报建待确认中", "待确认");

            return formatString;
        }

        /// <summary>
        ///通过js限制文本域的长度,必须引用 Javascript/Common/fn.js 
        /// </summary>
        /// <param name="coltrol">System.Web.UI.Control控件</param>
        /// <param name="maxLength">字符长度</param>
        /// <returns></returns>
        public static void setTextAreaLength(System.Web.UI.Control control, int maxLength = 0) {
            if (control is WebControl) {
                WebControl webControl = control as WebControl;
                webControl.Attributes.Add("onpropertychange", "Common.isTextAreaCheckLength(this," + maxLength + ")");
                webControl.Attributes.Add("oninput", "Common.isTextAreaCheckLength(this," + maxLength + ")");
                webControl.Attributes.Add("onkeyup", "Common.isTextAreaCheckLength(this," + maxLength + ")");
            }
        }

        /// <summary>
        ///  格式化电子文件图标,文件级
        /// </summary>
        /// <param name="fileListID">文件ID</param>
        /// <param name="singleProjectID">工程ID</param>
        /// <param name="bh">文件编号</param>
        /// <param name="isFolder">是否是目录级</param>
        /// <param name="imgSrc">null:默认pdf图标,其它为其它图标</param>
        /// <returns></returns>
        public static string getEfileImage(string fileListID, string singleProjectID, string bh, bool isFolder = true) {
            string strImage = " <img extFile=\"0\" style=\"cursor:pointer; border:0px;color:white;\" onclick=\"lookPDF(" + ConvertEx.ToInt(isFolder) + ",'" +
                bh + "'," + fileListID + "," + singleProjectID + ")\" src=\"../Javascript/Layer/image/EFILE.png\" alt=\"没有文件PDF\" />";
            if (!isFolder) {
                T_FileList_BLL fileListBLL = new T_FileList_BLL();
                T_FileList_MDL fileListMDL = fileListBLL.GetModel(ConvertEx.ToInt(fileListID));

                string pdfFilePath = Path.Combine(fileListMDL.RootPath, fileListMDL.SingleProjectID.ToString(), "MPDF", fileListMDL.PDFFilePath);
                if (System.IO.File.Exists(pdfFilePath)) {
                    strImage = " <img  extFile=\"1\" style=\"cursor:pointer;border:0px;\" onclick=\"lookPDF(" + ConvertEx.ToInt(isFolder) + ",'" +
                        bh + "'," + fileListID + "," + singleProjectID + ")\" src=\"../Javascript/Layer/image/EFILE_1.png\"  alt=\"点击查看合并后的PDF\"/>";
                }
            }
            return strImage;
        }

        /// <summary>
        /// 格式化电子文件图标,工程施工,规划许可证等
        /// </summary>
        /// <param name="attachPath">文件路径</param>
        /// <param name="zh">证号</param>
        /// <param name="title">说明</param>
        /// <returns></returns>
        public static string getEfileImageToZH(string attachPath, string zh, string title) {
            string cellText = zh;
            if (!string.IsNullOrWhiteSpace(attachPath)) {
                string filePath = System.Web.HttpContext.Current.Server.MapPath("../" + attachPath);
                if (System.IO.File.Exists(filePath)) {
                    cellText += " <img style=\"cursor:pointer; border:0px;color:white;\" src=\"../Javascript/Layer/image/JPG_1.png\" alt=\"点击查看\" "
                     + "onclick=\"Common.lookFileAttachToZH('" + attachPath + "','" + zh + "','" + title + "')\"/>";
                }
            }
            return cellText;
        }

        /// <summary>
        ///  检查文件对应的PDF文件是否存在
        /// </summary>
        /// <param name="fileListID">文件ID</param>       
        /// <returns></returns>
        public static bool CheckPdfFileExistsForFileListID(int fileListID) {
            bool existsFlag = false;
            T_FileList_BLL fileListBLL = new T_FileList_BLL();
            T_FileList_MDL fileListMDL = fileListBLL.GetModel(fileListID);

            string pdfFilePath = Path.Combine(fileListMDL.RootPath, fileListMDL.SingleProjectID.ToString(), "MPDF", fileListMDL.PDFFilePath);
            if (System.IO.File.Exists(pdfFilePath))
                existsFlag = true;

            return existsFlag;
        }

        /// <summary>
        /// 检查登录账号或密码有效性 规则:必须是数字和字母组成
        /// </summary>
        /// <param name="value">待检测字符串</param>
        /// <returns></returns>
        public static bool CheckAccountOrPwdValidity(string value) {
            Regex r1 = new Regex("[A-Za-z].*[0-9]|[0-9].*[A-Za-z]");
            if (!r1.IsMatch(value)) {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 判断是否是档案馆用户
        /// </summary>
        /// <returns></returns>
        public static bool isArchiveUser() {
            return (!Common.Session.GetSessionBool("SuperAdmin") &&
                !Common.Session.GetSessionBool("IsCompany")) ? true : false;
        }

        /// <summary>
        /// 判断是否是建设单位 true:是 false:非
        /// </summary>
        /// <returns></returns>
        public static bool isLeader() {
            return (Common.Session.GetSessionBool("IsCompany") &&
                Common.Session.GetSessionBool("IsLeader")) ? true : false;
        }

        /// <summary>
        /// 判断是否是监理单位
        /// </summary>
        /// <returns></returns>
        public static bool isJlCompany() {
            return (Common.Session.GetSessionBool("IsCompany") &&
           Common.Session.GetSessionInt("CompanyType") == SystemSet._JLCOMPANYINFO) ? true : false;
        }

        /// <summary>
        /// 判断是否是施工单位
        /// </summary>
        /// <returns></returns>

        public static bool isSgCompany() {
            return (Common.Session.GetSessionBool("IsCompany") &&
           Common.Session.GetSessionInt("CompanyType") == SystemSet._SGCOMPANYINFO) ? true : false;
        }

        /// <summary>
        /// 判断是否是签章单位
        /// </summary>
        /// <returns></returns>

        public static bool isSignatureCompany() {
            return (Common.Session.GetSessionBool("IsCompany") &&
           Common.Session.GetSessionInt("CompanyType") == SystemSet._SIGNATURECOMPANYINFO) ? true : false;
        } 

        /// <summary>
        /// 判断是否是公司 true:公司 false:档案馆
        /// </summary>
        /// <returns></returns>
        public static bool isCompany() {
            return Common.Session.GetSessionBool("IsCompany") ? true : false;
        }

        /// <summary>
        /// 判断是否是管理员  true:管理员 false:非管理员
        /// </summary>
        /// <returns></returns>
        public static bool isSuperAdmin() {
            return Common.Session.GetSessionBool("SuperAdmin") ? true : false;
        }

        /// <summary>
        /// 添加工程用户关联信息  存在则不添加
        /// </summary>
        /// <param name="SingleProjectID"></param>
        /// <param name="userMDL"></param>
        public static void AddSingleProjectUser(int SingleProjectID, T_UsersInfo_MDL userMDL) {
            if (userMDL != null) {
                CBLL.SingleProjectUser projectRole = new DigiPower.Onlinecol.Standard.CBLL.SingleProjectUser();
                projectRole.Update(SingleProjectID, userMDL.RoleID, userMDL.UserID);
            }
        }

        /// <summary>
        /// 添加工程用户关联信息  存在则不添加
        /// </summary>
        /// <param name="SingleProjectID"></param>
        /// <param name="RoleID"></param>
        /// <param name="UserID"></param>
        public static void AddSingleProjectUser(int SingleProjectID, int RoleID, int UserID) {
            CBLL.SingleProjectUser projectRole = new DigiPower.Onlinecol.Standard.CBLL.SingleProjectUser();
            projectRole.Update(SingleProjectID, RoleID, UserID);
        }

        /// <summary>
        /// 添加工程公司关联信息  存在则不添加
        /// </summary>
        /// <param name="SingleProjectID"></param>
        /// <param name="CompanyID"></param>
        public static void AddSingleProjectCompany(int SingleProjectID, int CompanyID) {
            CBLL.SingleProjectCompany spcBLL = new CBLL.SingleProjectCompany();
            spcBLL.Update(SingleProjectID, CompanyID);
        }

        /// <summary>
        /// 根据工程类型返回对应的工程著录页面  1:房屋  2,3:市政 4:管线            
        /// </summary>
        /// <param name="projectType">工程类型</param>
        /// <returns></returns>
        public static string GetFileTypeForProjectType(string projectType) {
            int intProjectType = ConvertEx.ToInt(projectType);
            if (intProjectType == 2 || intProjectType == 3)
                return "2";
            else if (intProjectType == 4 || intProjectType == 5)
                return "3";
            else if (intProjectType == 1)
                return "1";
            else
                return "1";
        }

        /// <summary>
        /// 返回工程类型字典ID
        /// </summary>
        /// <param name="projectType">工程类型字典CODE</param>
        /// <returns></returns>
        public static string GetFileTypeForProjectTypeId(string SystemInfoID) {
            T_SystemInfo_BLL sysBLL = new T_SystemInfo_BLL();
            T_SystemInfo_MDL sysMDL = sysBLL.GetModel(ConvertEx.ToInt(SystemInfoID));
            if (sysMDL != null)
                return sysMDL.SystemInfoCode;
            else
                return SystemInfoID;
        }

        /// <summary>
        /// 格式化文件题名
        /// </summary>
        /// <param name="bh"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static string GetTitleForBH(string bh, string title) {
            string newTitle = title;
            if (!String.IsNullOrWhiteSpace(bh) && !String.IsNullOrWhiteSpace(title)) {
                if (bh.Length == 3)
                    newTitle = string.Concat("&nbsp;      &nbsp;", title.Trim());
                else if (bh.Length == 5)
                    newTitle = string.Concat("&nbsp;      &nbsp;      &nbsp;      &nbsp;", title.Trim());
                else if (bh.Length == 7)
                    newTitle = string.Concat("&nbsp;      &nbsp;      &nbsp;      &nbsp;      &nbsp;      &nbsp;", title.Trim());
            }
            return newTitle;
        }


        public static string GetImageforStatus(bool status) {
            if (status)
                return "<img src=\"../ImagesNew/tick.png\" />";
            else
                return "<img src=\"../ImagesNew/bullet_cross.png\" />";
        }

        public static string GetImageforStatus(bool status, bool flag) {
            if (status && flag)
                return "<img src=\"../ImagesNew/tick.png\" />";
            else
                if (!flag) return "<img src=\"../ImagesNew/bullet_cross.png\" />";
                else return "";
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="page">页面对象</param>
        /// <param name="fileload">上传控件</param>
        /// <param name="strPath">路径</param>
        public static void UpLoadFile(System.Web.UI.Page page, System.Web.UI.WebControls.FileUpload fileload, string strPath, string strNewName) {
            string ServerPath = page.Server.MapPath(strPath);
            if (!Directory.Exists(ServerPath)) {
                //若文件目录不存在 则创建
                Directory.CreateDirectory(ServerPath);
            }
            ServerPath += strNewName;
            try {
                fileload.SaveAs(ServerPath);
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static void AlertMsg(System.Web.UI.Page page, string msg) {
            page.ClientScript.RegisterClientScriptBlock(page.GetType(), "kk", "<script>alert('" + msg + "')</script>");
        }


        /// <summary> 
        ///  asp.net上传图片并生成缩略图 
        ///  </summary> 04.  
        ///  <param name="upImage">HtmlInputFile控件</param> 05.  
        ///  <param name="sSavePath">保存的路径,些为相对服务器路径的下的文件夹</param> 06.
        /// <param name="sThumbExtension">缩略图的文件夹名称</param> 07.    
        /// <param name="intThumbWidth">生成缩略图的宽度</param> 08.   
        /// <param name="intThumbHeight">生成缩略图的高度</param> 09.  
        /// <returns>缩略图名称</returns> 10. 
        public static string UpLoadImage(System.Web.UI.WebControls.FileUpload upImage, string sSavePath, string sThumbExtension, int intThumbWidth, int intThumbHeight) {
            string sThumbFile = "";
            string sFilename = "";
            if (upImage.PostedFile != null) {
                HttpPostedFile myFile = upImage.PostedFile;
                int nFileLen = myFile.ContentLength;
                if (nFileLen == 0)
                    return "没有选择上传图片";
                //获取upImage选择文件的扩展名 23.            
                string extendName = System.IO.Path.GetExtension(myFile.FileName).ToLower();
                //判断是否为图片格式 25.           
                if (extendName != ".jpg" && extendName != ".jpge" && extendName != ".gif" && extendName != ".bmp" && extendName != ".png")
                    return "图片格式不正确";

                byte[] myData = new Byte[nFileLen];
                myFile.InputStream.Read(myData, 0, nFileLen);
                //sFilename = System.IO.Path.GetFileName(myFile.FileName);
                sFilename = Guid.NewGuid() + extendName;
                int file_append = 0;
                //检查当前文件夹下是否有同名图片,有则在文件名+1   
                while (System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(sSavePath + sFilename))) {
                    file_append++;
                    sFilename = System.IO.Path.GetFileNameWithoutExtension(myFile.FileName)
                       + file_append.ToString() + extendName;
                }
                System.IO.FileStream newFile
                     = new System.IO.FileStream(System.Web.HttpContext.Current.Server.MapPath(sSavePath + sFilename),
                  System.IO.FileMode.Create, System.IO.FileAccess.Write);
                newFile.Write(myData, 0, myData.Length);
                newFile.Close();
                //以上为上传原图 
                try {
                    //原图加载 
                    using (System.Drawing.Image sourceImage = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath(sSavePath + sFilename))) {
                        //原图宽度和高度 55.                   
                        int width = sourceImage.Width;
                        int height = sourceImage.Height;
                        int smallWidth;
                        int smallHeight;
                        //获取第一张绘制图的大小,(比较 原图的宽/缩略图的宽  和 原图的高/缩略图的高)              
                        if (((decimal)width) / height <= ((decimal)intThumbWidth) / intThumbHeight) {
                            smallWidth = intThumbWidth;
                            smallHeight = intThumbWidth * height / width;
                        } else {
                            smallWidth = intThumbHeight * width / height;
                            smallHeight = intThumbHeight;
                        }
                        //判断缩略图在当前文件夹下是否同名称文件存在 73.               
                        file_append = 0;
                        //sThumbFile = sThumbExtension + System.IO.Path.GetFileNameWithoutExtension(myFile.FileName) + extendName;
                        sThumbFile = sFilename;
                        //while (System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(sSavePath + sThumbFile)))
                        //{
                        //    file_append++;
                        //    sThumbFile = sThumbExtension + System.IO.Path.GetFileNameWithoutExtension(myFile.FileName) +
                        //        file_append.ToString() + extendName;
                        //}
                        //缩略图保存的绝对路径                 
                        string smallImagePath = System.Web.HttpContext.Current.Server.MapPath(sSavePath + sThumbExtension) + sThumbFile;
                        //新建一个图板,以最小等比例压缩大小绘制原图             
                        using (System.Drawing.Image bitmap = new System.Drawing.Bitmap(smallWidth, smallHeight)) {
                            //绘制中间图                        
                            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap)) {
                                //高清,平滑                       
                                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                                g.Clear(Color.Black);
                                g.DrawImage(
                              sourceImage,
                               new System.Drawing.Rectangle(0, 0, smallWidth, smallHeight),
                                new System.Drawing.Rectangle(0, 0, width, height),
                               System.Drawing.GraphicsUnit.Pixel
                                );
                            }
                            //新建一个图板,以缩略图大小绘制中间图                      
                            using (System.Drawing.Image bitmap1 = new System.Drawing.Bitmap(intThumbWidth, intThumbHeight)) {
                                //绘制缩略图                         
                                using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap1)) {
                                    //高清,平滑                           
                                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                                    g.Clear(Color.Black);
                                    int lwidth = (smallWidth - intThumbWidth) / 2;
                                    int bheight = (smallHeight - intThumbHeight) / 2;
                                    g.DrawImage(bitmap, new Rectangle(0, 0, intThumbWidth, intThumbHeight), lwidth, bheight, intThumbWidth, intThumbHeight, GraphicsUnit.Pixel);
                                    g.Dispose();
                                    bitmap1.Save(smallImagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                                }
                            }
                        }
                    }
                } catch {
                    //出错则删除             
                    System.IO.File.Delete(System.Web.HttpContext.Current.Server.MapPath(sSavePath + sFilename));
                    return "图片格式不正确";
                }
                //返回缩略图名称          
                return sThumbFile;
            }
            return "没有选择图片";
        }



        /// <summary> 
        ///  asp.net上传图片并生成缩略图 
        ///  </summary> 04.  
        ///  <param name="upImage">HtmlInputFile控件</param> 05.  
        ///  <param name="sSavePath">保存的路径,些为相对服务器路径的下的文件夹</param> 06.
        /// <param name="sThumbExtension">缩略图的文件夹名称,为空则不生成</param> 07.    
        /// <param name="intThumbWidth">生成缩略图的宽度</param> 08.   
        /// <param name="intThumbHeight">生成缩略图的高度</param> 09.  
        /// <returns>缩略图名称</returns> 10. 
        public static string UpLoadImage1(HttpPostedFile myFile1, string sSavePath, string sThumbExtension, int intThumbWidth, int intThumbHeight) {
            string sThumbFile = "";
            string sFilename = "";
            //if (upImage.PostedFile != null)
            //{
            try {
                HttpPostedFile myFile = myFile1;
                int nFileLen = myFile.ContentLength;
                if (nFileLen == 0)
                    return "没有选择上传图片";
                //获取upImage选择文件的扩展名 23.            
                string extendName = System.IO.Path.GetExtension(myFile.FileName).ToLower();
                //判断是否为图片格式 25.           
                if (extendName != ".jpg" && extendName != ".jpeg" && extendName != ".gif" && extendName != ".bmp" && extendName != ".png")
                    return "图片格式不正确";

                byte[] myData = new Byte[nFileLen];
                myFile.InputStream.Read(myData, 0, nFileLen);
                //sFilename = System.IO.Path.GetFileName(myFile.FileName);
                sFilename = Guid.NewGuid() + extendName;
                int file_append = 0;
                //检查当前文件夹下是否有同名图片,有则在文件名+1   
                //while (System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(sSavePath + sFilename)))
                while (System.IO.File.Exists((sSavePath + sFilename))) {
                    file_append++;
                    sFilename = System.IO.Path.GetFileNameWithoutExtension(myFile.FileName)
                       + file_append.ToString() + extendName;
                }
                //System.IO.FileStream newFile
                //     = new System.IO.FileStream(System.Web.HttpContext.Current.Server.MapPath(sSavePath + sFilename),
                //  System.IO.FileMode.Create, System.IO.FileAccess.Write);

                System.IO.FileStream newFile
                   = new System.IO.FileStream(sSavePath + sFilename,
                System.IO.FileMode.Create, System.IO.FileAccess.Write);


                newFile.Write(myData, 0, myData.Length);
                newFile.Close();
                //以上为上传原图 

                if (!string.IsNullOrEmpty(sThumbExtension) && sThumbExtension.Length > 0) {
                    //原图加载 
                    //using (System.Drawing.Image sourceImage = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath(sSavePath + sFilename)))
                    using (System.Drawing.Image sourceImage = System.Drawing.Image.FromFile(sSavePath + sFilename)) {
                        //原图宽度和高度 55.                   
                        int width = sourceImage.Width;
                        int height = sourceImage.Height;
                        int smallWidth;
                        int smallHeight;
                        //获取第一张绘制图的大小,(比较 原图的宽/缩略图的宽  和 原图的高/缩略图的高)              
                        if (((decimal)width) / height <= ((decimal)intThumbWidth) / intThumbHeight) {
                            smallWidth = intThumbWidth;
                            smallHeight = intThumbWidth * height / width;
                        } else {
                            smallWidth = intThumbHeight * width / height;
                            smallHeight = intThumbHeight;
                        }
                        //判断缩略图在当前文件夹下是否同名称文件存在 73.               
                        file_append = 0;
                        //sThumbFile = sThumbExtension + System.IO.Path.GetFileNameWithoutExtension(myFile.FileName) + extendName;
                        sThumbFile = sFilename;
                        //while (System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(sSavePath + sThumbFile)))
                        //{
                        //    file_append++;
                        //    sThumbFile = sThumbExtension + System.IO.Path.GetFileNameWithoutExtension(myFile.FileName) +
                        //        file_append.ToString() + extendName;
                        //}
                        //缩略图保存的绝对路径                 
                        //string smallImagePath = System.Web.HttpContext.Current.Server.MapPath(sSavePath + sThumbExtension) + sThumbFile;
                        string smallImagePath = sThumbExtension + sThumbFile;
                        //新建一个图板,以最小等比例压缩大小绘制原图             
                        using (System.Drawing.Image bitmap = new System.Drawing.Bitmap(smallWidth, smallHeight)) {
                            //绘制中间图                        
                            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap)) {
                                //高清,平滑                       
                                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                                g.Clear(Color.Black);
                                g.DrawImage(
                              sourceImage,
                               new System.Drawing.Rectangle(0, 0, smallWidth, smallHeight),
                                new System.Drawing.Rectangle(0, 0, width, height),
                               System.Drawing.GraphicsUnit.Pixel
                                );
                            }
                            //新建一个图板,以缩略图大小绘制中间图                      
                            using (System.Drawing.Image bitmap1 = new System.Drawing.Bitmap(intThumbWidth, intThumbHeight)) {
                                //绘制缩略图                         
                                using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap1)) {
                                    //高清,平滑                           
                                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                                    g.Clear(Color.Black);
                                    int lwidth = (smallWidth - intThumbWidth) / 2;
                                    int bheight = (smallHeight - intThumbHeight) / 2;
                                    g.DrawImage(bitmap, new Rectangle(0, 0, intThumbWidth, intThumbHeight), lwidth, bheight, intThumbWidth, intThumbHeight, GraphicsUnit.Pixel);
                                    g.Dispose();
                                    bitmap1.Save(smallImagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                                }
                            }
                        }
                    }
                }
            } catch {
                //出错则删除             
                System.IO.File.Delete(sSavePath + sFilename);
                return "Error图片格式不正确";
            }
            //返回缩略图名称          
            return sThumbFile;
            //}
            //return "没有选择图片";
        }

        /// <summary> 
        ///  asp.net上传图片并生成缩略图 
        ///  </summary> 04.  
        ///  <param name="upImage">HtmlInputFile控件</param> 05.  
        ///  <param name="sSavePath">保存的路径,些为相对服务器路径的下的文件夹</param> 06.
        /// <param name="sThumbExtension">缩略图的文件夹名称,为空则不生成</param> 07.    
        /// <param name="intThumbWidth">生成缩略图的宽度</param> 08.   
        /// <param name="intThumbHeight">生成缩略图的高度</param> 09.  
        /// <returns>缩略图名称</returns> 10. 
        public static string UpLoadImage1(HttpPostedFile myFile1, string sSavePath) {
            string sFilename = "";
            try {
                HttpPostedFile myFile = myFile1;
                int nFileLen = myFile.ContentLength;
                if (nFileLen == 0)
                    return "没有选择上传图片";

                string extendName = System.IO.Path.GetExtension(myFile.FileName).ToLower();
                byte[] myData = new Byte[nFileLen];
                myFile.InputStream.Read(myData, 0, nFileLen);
                sFilename = Guid.NewGuid() + extendName;
                int file_append = 0;

                while (System.IO.File.Exists((sSavePath + sFilename))) {
                    file_append++;
                    sFilename = System.IO.Path.GetFileNameWithoutExtension(myFile.FileName)
                       + file_append.ToString() + extendName;
                }
                //System.IO.FileStream newFile
                //     = new System.IO.FileStream(System.Web.HttpContext.Current.Server.MapPath(sSavePath + sFilename),
                //  System.IO.FileMode.Create, System.IO.FileAccess.Write);

                System.IO.FileStream newFile
                   = new System.IO.FileStream(sSavePath + sFilename,
                System.IO.FileMode.Create, System.IO.FileAccess.Write);

                newFile.Write(myData, 0, myData.Length);
                newFile.Close();

            } catch {
                //出错则删除             
                System.IO.File.Delete(sSavePath + sFilename);
                return "Error图片格式不正确";
            }
            return sFilename;
        }
    }
}