using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.CBLL;
using System.Data;
using System.Collections;

namespace DigiPower.Onlinecol.Standard.Web {
    public partial class LHSignatureProjectList : PageBase {
        /// <summary>
        /// 流程ID
        /// </summary>
        public int workFlowID = 0;

        /// <summary>
        /// 流程编号
        /// </summary>
        public string workFlowCode = string.Empty;

        /// <summary>
        /// 总记录数
        /// </summary>
        int itemCount = 0;

        /// <summary>
        /// 每页页数
        /// </summary>
        int pageSize = SystemSet._PAGESIZE;
        T_WorkFlowDefine_BLL flowDefineBLL = new T_WorkFlowDefine_BLL();
        T_FileList_BLL fileListBLL = new T_FileList_BLL();

        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(LHSignatureProjectList));
            workFlowID = PublicModel.getWorkFlowIdByWorkFlowCode(SystemSet.EumWorkFlowCode.FILEREG.ToString());
            if (!IsPostBack) {
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("txtGcmc")))
                    txtGcmc.Text = Server.UrlDecode(DNTRequest.GetQueryString("txtGcmc"));
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("txtGcbm")))
                    txtGcbm.Text = Server.UrlDecode(DNTRequest.GetQueryString("txtGcbm"));

                BindGrid(1);
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="WorkFlowID"></param>
        /// <param name="pageInde"></param>
        private void BindGrid(int pageIndex) {
            BLL.T_WorkFlow_BLL wfBLL = new T_WorkFlow_BLL();
            Model.T_WorkFlow_MDL wfMDL = wfBLL.GetModel(workFlowID);
            workFlowCode = wfMDL.WorkFlowCode;

            string sqlWhere = string.Empty;
            if (PublicModel.isSuperAdmin()) {        //管理员管理员获取所有工程
                sqlWhere = " AND AREA_CODE LIKE '" + Common.Session.GetSession("AREA_CODE") + "%'";//加区域了。
            } else if (PublicModel.isArchiveUser()) {//档案馆用户看自己的
                sqlWhere = " AND AREA_CODE LIKE '" + Common.Session.GetSession("OLD_AREA_CODE") + "%'";//加区域了。
            }

            if (!String.IsNullOrEmpty(txtGcmc.Text)) {
                sqlWhere += " AND gcmc like '%" + txtGcmc.Text + "%'";
            }
            if (!String.IsNullOrEmpty(txtGcbm.Text)) {
                sqlWhere += " AND gcbm like '%" + txtGcbm.Text + "%'";
            }
            DataTable dt = null;
            if (ViewState["CurrentPageIndex"] == null && Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex")) > 0) {
                pageIndex = Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex"));
                ViewState["CurrentPageIndex"] = pageIndex;
            } else {
                pageIndex = ConvertEx.ToInt(ViewState["CurrentPageIndex"]);
            }

            if (PublicModel.isSuperAdmin())
                dt = flowDefineBLL.GetLHSignatureListPaging(workFlowID.ToString(), false, "", "", sqlWhere, pageSize, pageIndex, out itemCount);
            else
                dt = flowDefineBLL.GetLHSignatureListPaging(workFlowID.ToString(), Common.Session.GetSessionBool("IsCompany"),
                    Common.Session.GetSession("RoleID"), Common.Session.GetSession("UserID"), sqlWhere, pageSize, pageIndex, out itemCount);

            AspNetPager.AlwaysShow = true;
            AspNetPager.PageSize = pageSize;

            AspNetPager.RecordCount = itemCount;
            AspNetPager.CurrentPageIndex = pageIndex;

            gvData.DataSource = dt;
            gvData.DataBind();
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
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e) {
            BindGrid(1);
        }

        /// <summary>
        /// 根据获取工程下签章未完成的文件数量,格式化td
        /// </summary>
        /// <param name="singleProjectID"></param>        
        /// <returns></returns>
        public string getTdHTML(string singleProjectID) {
            string tdHtml = string.Empty;
            var signatureFinishingCount = getSignatureFinishingCount(singleProjectID);
            if (signatureFinishingCount > 0) {
                tdHtml = "<img src=\"../Javascript/Layer/image/msg01.gif\" alt=\"工程下未签章完成的文件数量\" class=\"tdImgsignature\" />" + signatureFinishingCount + "份";
            }
            return tdHtml;
        }

        /// <summary>
        /// 获取工程下签章未完成的文件数量
        /// </summary>
        /// <param name="singleProjectID"></param>
        /// <returns></returns>
        protected int getSignatureFinishingCount(string singleProjectID) {
            Hashtable ht = new Hashtable();
            ht.Add("iSignaturePdf", "1");
            ht.Add("SingleProjectID", singleProjectID);
            ht.Add("SignatureFinishFlag", "0");
            ht.Add("Signature_UserRoleCode", Common.Session.GetSession("RoleCode"));

            return fileListBLL.GetFileCount(ht);
        }

        /// <summary>
        /// 获取工程下签章完成的文件数量
        /// </summary>
        /// <param name="singleProjectID"></param>
        /// <returns></returns>
        public int getSignatureFinishCount(string singleProjectID) {
            Hashtable ht = new Hashtable();
            ht.Add("iSignaturePdf", "1");
            ht.Add("SignatureFinishFlag", "1");
            ht.Add("SingleProjectID", singleProjectID);
            ht.Add("Signature_UserRoleCode", Common.Session.GetSession("RoleCode"));
            return fileListBLL.GetFileCount(ht);
        }
    }
}