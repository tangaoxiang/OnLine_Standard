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
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.Model;
using System.Text;
using System.IO;

//案卷管理
namespace DigiPower.Onlinecol.Standard.Web.WorkFlow {
    public partial class ArchiveList : PageBase {
        T_Archive_BLL archiveBLL = new T_Archive_BLL();

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
        int pageSize = SystemSet._PAGESIZE;

        protected void Page_Load(object sender, EventArgs e) {
            MyAddInit();
            Ajax.Utility.RegisterTypeForAjax(typeof(ArchiveList));
            if (!IsPostBack) {
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("txtajtm")))
                    txtajtm.Text = Server.UrlDecode(DNTRequest.GetQueryString("txtajtm"));
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("txtgcbm")))
                    txtgcbm.Text = Server.UrlDecode(DNTRequest.GetQueryString("txtgcbm"));
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("txtgcmc")))
                    txtgcmc.Text = Server.UrlDecode(DNTRequest.GetQueryString("txtgcmc"));

                BindGrid(AspNetPager.CurrentPageIndex);
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="pageIndex"></param>
        public void BindGrid(int pageIndex) {
            string strWhere = string.Empty;

            if (PublicModel.isSuperAdmin()) {//管理员管理员获取所有工程
                strWhere += " AND D.AREA_CODE LIKE '" + Common.Session.GetSession("AREA_CODE") + "%'";
            } else if (PublicModel.isArchiveUser()) {//档案馆用户看自己的
                strWhere += " AND D.AREA_CODE LIKE '" + Common.Session.GetSession("OLD_AREA_CODE") + "%'";
            } else {
                if (PublicModel.isLeader())     //建设单位只看到自己
                {
                    strWhere += " AND A.SingleProjectID in (select SingleProjectID from T_SingleProject  A,(select distinct ConstructionProjectID from T_Construction_Project ";
                    strWhere += " where CompanyID=" + Common.Session.GetSession("CompanyID") + ") B where A.ConstructionProjectID=B.ConstructionProjectID)";
                }
            }

            if (txtgcmc.Text.Trim().Length > 0)
                strWhere += " AND D.gcmc LIKE '%" + txtgcmc.Text.Trim() + "%'";
            if (txtgcbm.Text.Trim().Length > 0)
                strWhere += " AND D.gcbm LIKE '%" + txtgcbm.Text + "%'";
            if (txtajtm.Text.Trim().Length > 0)
                strWhere += " AND A.ajtm like '%" + txtajtm.Text.Trim() + "%' ";

            if (ViewState["CurrentPageIndex"] == null && Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex")) > 0) {
                pageIndex = Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex"));
                ViewState["CurrentPageIndex"] = pageIndex;
            } else {
                pageIndex = ConvertEx.ToInt(ViewState["CurrentPageIndex"]);
            }
            DataTable dt = archiveBLL.GetListPaging(strWhere, pageSize, pageIndex, out itemCount); ;

            AspNetPager.AlwaysShow = true;
            AspNetPager.PageSize = pageSize;

            AspNetPager.RecordCount = itemCount;
            AspNetPager.CurrentPageIndex = pageIndex;

            rpData.DataSource = dt;
            rpData.DataBind();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e) {
            BindGrid(1);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager_PageChanged(object sender, EventArgs e) {
            ViewState["CurrentPageIndex"] = AspNetPager.CurrentPageIndex;
            BindGrid(AspNetPager.CurrentPageIndex);
        }

        /// <summary>
        /// 更新案卷序号
        /// </summary>
        /// <param name="archiveID"></param>
        /// <param name="XH"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public void UpdateArchiveXH(string archiveID, string XH) {
            T_Archive_MDL arMDL = archiveBLL.GetModel(ConvertEx.ToInt(archiveID));
            if (arMDL != null) {
                arMDL.xh = ConvertEx.ToInt(XH);
                archiveBLL.Update(arMDL);

                PublicModel.writeLog(SystemSet.EumLogType.UpdData.ToString(), string.Concat("T_Archive;key=", arMDL.ArchiveID,
                    ";SingleProjectID=", arMDL.SingleProjectID, ";ajtm=", arMDL.ajtm, ";xh=", arMDL.xh, ";案卷管理-更新案卷序号"));
            }
        }

        /// <summary>
        /// 更新卷内文件序号
        /// </summary>                                      
        /// <param name="archiveID"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public void updateFileOrderIndexByArchiveID(string archiveID) {
            archiveBLL.updateFileOrderIndexByArchiveID(archiveID);
            PublicModel.writeLog(SystemSet.EumLogType.UpdData.ToString(), string.Concat("T_FileList;ArchiveID=", archiveID, ";案卷管理-更新卷内文件序号"));
        }

        /// <summary>
        /// 删除案卷
        /// </summary>                                     
        /// <param name="ArchiveIdList"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public void DeleteArchiveMore(string ArchiveIdList) {
            archiveBLL.DeleteArchiveMore(ArchiveIdList);
            PublicModel.writeLog(SystemSet.EumLogType.UpdData.ToString(), string.Concat("T_Archive;ArchiveIdList=",
                ArchiveIdList, ";案卷管理-批量删除案卷"));
        }

        /// <summary>
        /// 检测案卷下的文件的实体页数是否>0
        /// </summary>
        /// <param name="singleProjectIDS">工程ID集合</param>   
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public string ArchiveCheckByManualCount(string singleProjectIDS) {
            T_FileList_BLL fileListBLL = new T_FileList_BLL();
            List<string> ltResult = new List<string>();
            string[] SplitSingleProjectID = singleProjectIDS.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string singleProjectID in SplitSingleProjectID) {
                DataTable dt = fileListBLL.GetFileListThanManualCount(singleProjectID);
                if (dt != null) {
                    List<string> ltFileResult = new List<string>();

                    int ArchiveID = 0;
                    int SingleProjectID = 0;
                    foreach (DataRow row in dt.Rows) {
                        if (SingleProjectID == 0 || SingleProjectID != Common.ConvertEx.ToInt(row["SingleProjectID"])) {
                            ltResult.Add("************************************************************");
                            ltResult.Add(string.Concat("工程编号:", row["gcbm"], " 工程名称:", row["gcmc"]));
                        }
                        if (ArchiveID == 0 || ArchiveID != Common.ConvertEx.ToInt(row["ArchiveID"])) {
                            ltResult.Add("-------------------------------------------------------------------------");
                            ltResult.Add(string.Concat("案卷序号:", row["xh"], " 案卷题名-", row["ajtm"]));
                        }

                        ltResult.Add(string.Concat("文件序号:", row["OrderIndex"], "  文件编号:", row["BH"],
                               "  文件题名:", row["Title"], "  实体页数:", row["ManualCount"]));

                        ArchiveID = Common.ConvertEx.ToInt(row["ArchiveID"]);
                        SingleProjectID = Common.ConvertEx.ToInt(row["SingleProjectID"]);
                    }
                }
            }
            if (ltResult.Count > 0) {
                string txtFileName = Guid.NewGuid().ToString() + ".txt";
                FileStream fs1 = new FileStream(Server.MapPath("/Upload/TempReport/" + txtFileName), FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs1);
                foreach (string str in ltResult) {
                    sw.WriteLine(str);
                }
                sw.Close();
                fs1.Close();
                return txtFileName;
            } else {
                return "0";
            }
        }

        /// <summary>
        /// 根据工程ID 将报表导出PDF,注意:报表必须预先在T_Report做出记录
        /// </summary>
        /// <param name="archiveId">案卷ID</param>
        /// <param name="ReportCode">报表类型</param>
        /// <param name="DelOldReportPDF">是否删除已生成的PDF</param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public string ReportExportPDF(string archiveId, string reportCode, bool delOldReportPDF) {
            return ReportPDF.ReportExportPDF(archiveId, reportCode, delOldReportPDF);
        }
    }
}