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
using System.Collections.Generic;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Model;

namespace DigiPower.Onlinecol.Standard.Web.File {
    public partial class SmUpLoadEFileList : PageBase {
        T_FileList_BLL filelistBLL = new T_FileList_BLL();
        T_EFile_BLL efileBLL = new T_EFile_BLL();

        //文件ID
        public string FileListID = string.Empty;

        //工程ID
        public string SingleProjectID = string.Empty;

        /// <summary>
        /// 总记录数
        /// </summary>
        int itemCount = 0;

        /// <summary>
        /// 每页页数
        /// </summary>
        int pageSize = 20;

        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(SmUpLoadEFileList));
            SingleProjectID = Common.DNTRequest.GetQueryString("SingleProjectID");
            FileListID = Common.DNTRequest.GetQueryString("FileListID");
            if (!IsPostBack) {
                BindGridView(1);
            }
        }

        /// <summary>
        /// 格式化获取原文的查看URL路径
        /// </summary>
        /// <param name="RootPath"></param>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public string GetEFileURL(string RootPath, string FilePath) {
            string LastPath = RootPath.Substring(0, RootPath.Length - 1);
            int iPos1 = LastPath.LastIndexOf('\\');
            LastPath = LastPath.Substring(iPos1 + 1);
            string mHttpUrl = "http://" + Request.ServerVariables["HTTP_HOST"] + "/" + LastPath;
            return mHttpUrl + "/" + SingleProjectID + "/ODOC/" + FilePath;
        }

        /// <summary>
        /// 保存电子文件排序编号
        /// </summary>
        /// <param name="archiveListCellRptID"></param>
        /// <param name="OrderIndex"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public void UpdateEFileIndex(string archiveListCellRptID, string OrderIndex) {
            T_EFile_MDL model = new T_EFile_MDL();

            model = efileBLL.GetModel(ConvertEx.ToInt(archiveListCellRptID));
            if (model != null) {
                model.OrderIndex = ConvertEx.ToInt(OrderIndex);
                efileBLL.Update(model);

                PublicModel.writeLog(SystemSet.EumLogType.UpdData.ToString(), string.Concat("T_EFile;key=", model.ArchiveListCellRptID,
                    ";FileListID=", model.FileListID, ";Title=", model.Title, ";案卷补录-更新电子文件序号"));

                T_FileList_MDL fileListMDL = filelistBLL.GetModel(model.FileListID);
                if (fileListMDL != null) {
                    fileListMDL.CONVERT_FLAG = false;   //重新转换PDF
                    filelistBLL.Update(fileListMDL);
                }
            }
        }

        /// <summary>
        /// 删除电子文件,重置文件转换标识 CONVERT_FLAG=false
        /// </summary>
        /// <param name="archiveListCellRptID">电子文件ID</param>
        /// <param name="singleProjectID">工程id</param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public void DeleteFile(string archiveListCellRptID, string singleProjectID) {
            T_EFile_MDL model = new T_EFile_MDL();
            model = efileBLL.GetModel(Convert.ToInt32(archiveListCellRptID));
            if (model != null) {
                string filePath = string.Concat(model.RootPath, singleProjectID, "\\ODOC\\", model.FilePath);

                if (filePath != "" && System.IO.File.Exists(filePath)) {
                    System.IO.File.Delete(filePath);
                }
                //删除电子文件记录
                efileBLL.Delete(Convert.ToInt32(archiveListCellRptID));

                PublicModel.writeLog(SystemSet.EumLogType.AddData.ToString(), string.Concat("T_EFile;key=", model.ArchiveListCellRptID,
                   ";SingleProjectID=", singleProjectID, ";FileListID=", model.FileListID, ";Title=", model.Title, ";案卷补录"));

                //Leo 更新文件夹，晚上重新生产一次
                int FileListID = model.FileListID;
                Model.T_FileList_MDL fileListMDL = filelistBLL.GetModel(FileListID);
                fileListMDL.CONVERT_FLAG = false;
                filelistBLL.Update(fileListMDL);
            }
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindGridView(int pageIndex) {
            if (ViewState["CurrentPageIndex"] == null && Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex")) > 0) {
                pageIndex = Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex"));
                ViewState["CurrentPageIndex"] = pageIndex;
            } else {
                pageIndex = ConvertEx.ToInt(ViewState["CurrentPageIndex"]);
            }

            string strWhere = " FileListID = " + FileListID + " and FileType = 0 ";
            DataTable dt = efileBLL.GetListPaging(strWhere, pageSize, pageIndex, out itemCount); ;

            AspNetPager.AlwaysShow = true;
            AspNetPager.PageSize = pageSize;

            AspNetPager.RecordCount = itemCount;
            AspNetPager.CurrentPageIndex = pageIndex;

            rpData.DataSource = dt;
            rpData.DataBind();
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager_PageChanged(object sender, EventArgs e) {
            ViewState["CurrentPageIndex"] = AspNetPager.CurrentPageIndex;
            BindGridView(AspNetPager.CurrentPageIndex);
        }

        /// <summary>
        /// 电子文件上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpLoad_Click(object sender, EventArgs e) {
            try {
                if (FileUpload1.HasFile) {
                    string odocFilePath = string.Concat(Common.Common.EFileStartPath, SingleProjectID, "\\ODOC\\");

                    if (!System.IO.Directory.Exists(Common.Common.EFileStartPath))
                        System.IO.Directory.CreateDirectory(Common.Common.EFileStartPath);

                    if (!System.IO.Directory.Exists(odocFilePath))
                        System.IO.Directory.CreateDirectory(odocFilePath);

                    string fileNewName = Guid.NewGuid().ToString() + FileUpload1.FileName.Substring(FileUpload1.FileName.LastIndexOf('.')); ;

                    //电子文件存放全路径
                    string FileFullPath = odocFilePath + fileNewName;
                    FileUpload1.SaveAs(FileFullPath);  //保存原始文件      

                    T_EFile_MDL model = new T_EFile_MDL();

                    model.PageCounts = 0;
                    model.FileListID = Common.ConvertEx.ToInt(FileListID);
                    model.FileType = 1;
                    model.OrderIndex = GetEfileMaxOrderIndex(FileListID);
                    model.Title = FileUpload1.FileName.Substring(0, FileUpload1.FileName.LastIndexOf('.'));
                    model.RootPath = Common.Common.EFileStartPath;
                    model.FilePath = fileNewName;

                    model.FileType = 0;
                    model.Status_Text = "上传成功,当晚批量计算页数！";
                    model.CREATE_DT = System.DateTime.Now.ToShortDateString();
                    model.CONVERT_FLAG = false;
                    int ArchiveListCellRptID = efileBLL.Add(model);

                    //更新文件级转换标志，等批量转换晚上转                         
                    T_FileList_MDL fileListMDL = filelistBLL.GetModel(model.FileListID);
                    fileListMDL.CONVERT_FLAG = false;
                    fileListMDL.RootPath = Common.Common.EFileStartPath;
                    filelistBLL.Update(fileListMDL);
                    BindGridView(AspNetPager.CurrentPageIndex);

                    PublicModel.writeLog(SystemSet.EumLogType.AddData.ToString(), string.Concat("T_EFile;key=", ArchiveListCellRptID,
                        ";SingleProjectID=", fileListMDL.SingleProjectID, ";FileListID=", model.FileListID, ";Title=", model.Title, "'案卷补录"));
                }
            } catch (Exception ex) {
                Common.LogUtil.Debug(this, "补卷-电子文件上传错误", ex);
            }
        }

        /// <summary>
        ///获得文件下电子文件最大序号
        /// </summary>
        /// <param name="filelistID"></param>
        /// <returns></returns>
        private int GetEfileMaxOrderIndex(string filelistID) {
            return ConvertEx.ToInt(efileBLL.GetEfileMaxOrderIndex(filelistID)) + 10;
        }
    }
}