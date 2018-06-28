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
    public partial class UpLoadEFileList : PageBase {

        T_EFile_BLL eFileBLL = new T_EFile_BLL();
        T_FileList_BLL fileListBLL = new T_FileList_BLL();
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
            Ajax.Utility.RegisterTypeForAjax(typeof(UpLoadEFileList));
            SingleProjectID = Common.DNTRequest.GetQueryString("SingleProjectID");
            FileListID = Common.DNTRequest.GetQueryString("FileListID");
            if (!IsPostBack) {
                BindGridView(1);
            }
        }

        /// <summary>
        /// 获取原文对应的URL
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
            model = eFileBLL.GetModel(ConvertEx.ToInt(archiveListCellRptID));
            if (model != null) {
                model.OrderIndex = ConvertEx.ToInt(OrderIndex);
                eFileBLL.Update(model);

                PublicModel.writeLog(SystemSet.EumLogType.UpdData.ToString(), string.Concat("T_EFile;key=", model.ArchiveListCellRptID,
                    ";FileListID=", model.FileListID, ";Title=", model.Title, ";电子文件排序编号"));

                T_FileList_MDL fileListMDL = fileListBLL.GetModel(model.FileListID);
                if (fileListMDL != null) {
                    fileListMDL.CONVERT_FLAG = false;     //重新转换PDF,按照新的电子文件顺序
                    fileListMDL.Version = PublicModel.getFileVersion(fileListMDL.SingleProjectID.ToString());
                    fileListBLL.Update(fileListMDL);
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
            model = eFileBLL.GetModel(Convert.ToInt32(archiveListCellRptID));
            if (model != null) {
                string filePath = string.Concat(model.RootPath, singleProjectID, "\\ODOC\\", model.FilePath);

                if (filePath != "" && System.IO.File.Exists(filePath)) {
                    System.IO.File.Delete(filePath);
                }
                //删除电子文件记录
                eFileBLL.Delete(Convert.ToInt32(archiveListCellRptID));
                PublicModel.writeLog(SystemSet.EumLogType.DelData.ToString(), string.Concat("T_EFile;key=", model.ArchiveListCellRptID,
                     ";SingleProjectID=", SingleProjectID, ";FileListID=", model.FileListID, ";Title=", model.Title));

                //Leo 更新文件夹，晚上重新生产一次             
                T_FileList_MDL fileListMDL = fileListBLL.GetModel(model.FileListID);
                if (fileListMDL != null) {
                    fileListMDL.CONVERT_FLAG = false;
                    fileListMDL.Version = PublicModel.getFileVersion(fileListMDL.SingleProjectID.ToString());
                    fileListBLL.Update(fileListMDL);
                }
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
            DataTable dt = eFileBLL.GetListPaging(strWhere, pageSize, pageIndex, out itemCount); ;

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
    }
}