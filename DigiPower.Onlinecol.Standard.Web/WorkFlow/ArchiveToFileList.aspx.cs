﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.Common;

//查看案卷下的所有文件

namespace DigiPower.Onlinecol.Standard.Web.WorkFlow {
    public partial class ArchiveToFileList : PageBase {
        T_FileList_BLL fileListBLL = new T_FileList_BLL();
        public string Store = string.Empty;

        /// <summary>
        /// 工程ID
        /// </summary>
        public string SingleProjectID = string.Empty;

        /// <summary>
        /// 总记录数
        /// </summary>
        int itemCount = 0;

        /// <summary>
        /// 每页页数
        /// </summary>
        int pageSize = 30;

        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(ArchiveToFileList));
            MyAddInit();
            if (!this.IsPostBack) {
                if ((CommonEnum.PageState)ViewState["ps"] == CommonEnum.PageState.VIEW) {
                    Common.MessageBox.DisplayHideUI(this.Page, new object[] { "MrcBtnBatchUpdateXH", "MrcBtnBatchDelete" });
                }
                BindGridView(1);
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
            string strWhere = " ArchiveID=" + DNTRequest.GetQueryString("ArchiveID");
            DataTable dt = fileListBLL.GetListPaging(strWhere, pageSize, pageIndex, "OrderIndex asc", out itemCount); ;

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
        /// 拆卷
        /// </summary>
        /// <param name="archiveListCellRptID"></param>
        /// <param name="OrderIndex"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public void DeleteFile(string fileListID) {
            T_FileList_MDL flMDL = fileListBLL.GetModel(ConvertEx.ToInt(fileListID));
            if (flMDL != null) {
                int tempArchiveID = ConvertEx.ToInt(flMDL.ArchiveID);
                flMDL.ArchiveID = 0;
                fileListBLL.Update(flMDL);

                PublicModel.writeLog(SystemSet.EumLogType.UpdData.ToString(), string.Concat("T_FileList;key=", fileListID,
                   ";SingleProjectID=", flMDL.SingleProjectID, ";ArchiveID=", tempArchiveID, ";BH=", flMDL.BH, ";Title=", flMDL.Title, ";案卷管理-拆文件"));
            }
        }

        /// <summary>
        /// 更新文件序号
        /// </summary>
        /// <param name="archiveListCellRptID"></param>
        /// <param name="OrderIndex"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public void UpdateFileOrderIndex(string fileListID, string OrderIndex) {
            T_FileList_MDL flMDL = fileListBLL.GetModel(ConvertEx.ToInt(fileListID));
            if (flMDL != null) {
                flMDL.OrderIndex = ConvertEx.ToInt(OrderIndex);
                fileListBLL.Update(flMDL);

                PublicModel.writeLog(SystemSet.EumLogType.UpdData.ToString(), string.Concat("T_FileList;key=", fileListID,
                   ";SingleProjectID=", flMDL.SingleProjectID, ";ArchiveID=", flMDL.ArchiveID, ";BH=", flMDL.BH, ";Title=", flMDL.Title, ";案卷管理-更新文件序号"));
            }
        }

        /// <summary>
        /// 入库能否查看PDF
        /// </summary>
        /// <param name="FileListID"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public bool RKLookPDFFlag(string singleProjectID) {
            bool flag = true;
            T_SingleProject_BLL singleProjectBLL = new T_SingleProject_BLL();
            T_SingleProject_MDL singleProjectMDL = singleProjectBLL.GetModel(ConvertEx.ToInt(singleProjectID));
            if (singleProjectMDL != null) {
                if (ConvertEx.ToInt(singleProjectMDL.Status) >= 3721 && !SystemSet._RKLOOKPDFFLAG) {
                    flag = false;
                }
            }
            return flag;
        }

        /// <summary>
        /// 检查文件对应的PDF文件是否存在
        /// </summary>
        /// <param name="fileListID"></param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public bool CheckPdfFileExistsForFileListID(int fileListID) {
            return PublicModel.CheckPdfFileExistsForFileListID(fileListID);
        }

    }
}