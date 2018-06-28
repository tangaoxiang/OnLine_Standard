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

//单位案卷管理

namespace DigiPower.Onlinecol.Standard.Web.WorkFlow
{
    public partial class MyArchiveList : PageBase
    {
        T_MyArchive_BLL myArchiveBLL = new T_MyArchive_BLL();

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

        protected void Page_Load(object sender, EventArgs e)
        {
            MyAddInit();
            Ajax.Utility.RegisterTypeForAjax(typeof(MyArchiveList));
            if (!IsPostBack)
            {
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
        public void BindGrid(int pageIndex)
        {
            string strWhere = string.Empty;
            if (PublicModel.isLeader())     //建设单位只看到自己
            {
                strWhere += " AND A.SingleProjectID in (select SingleProjectID from T_SingleProject  A,(select distinct ConstructionProjectID from T_Construction_Project ";
                strWhere += " where CompanyID=" + Common.Session.GetSession("CompanyID") + ") B where A.ConstructionProjectID=B.ConstructionProjectID)";
            }

            if (txtgcmc.Text.Trim().Length > 0)
                strWhere += " AND D.gcmc LIKE '%" + txtgcmc.Text.Trim() + "%'";
            if (txtgcbm.Text.Trim().Length > 0)
                strWhere += " AND D.gcbm LIKE '%" + txtgcbm.Text + "%'";
            if (txtajtm.Text.Trim().Length > 0)
                strWhere += " AND A.ajtm like '%" + txtajtm.Text.Trim() + "%' ";

            if (ViewState["CurrentPageIndex"] == null && Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex")) > 0)
            {
                pageIndex = Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex"));
                ViewState["CurrentPageIndex"] = pageIndex;
            }
            else
            {
                pageIndex = ConvertEx.ToInt(ViewState["CurrentPageIndex"]);
            }
            DataTable dt = myArchiveBLL.GetListPaging(strWhere, pageSize, pageIndex, out itemCount); ;

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
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid(1);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager_PageChanged(object sender, EventArgs e)
        {
            ViewState["CurrentPageIndex"] = AspNetPager.CurrentPageIndex;
            BindGrid(AspNetPager.CurrentPageIndex);
        }

        /// <summary>
        /// 更新案卷序号
        /// </summary>
        /// <param name="archiveListCellRptID"></param>
        /// <param name="OrderIndex"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public void UpdateArchiveXH(string archiveID, string XH)
        {
            T_MyArchive_MDL arMDL = myArchiveBLL.GetModel(ConvertEx.ToInt(archiveID));
            if (arMDL != null)
            {
                arMDL.xh = ConvertEx.ToInt(XH);
                myArchiveBLL.Update(arMDL);
            }
        }

        /// <summary>
        /// 更新卷内文件序号
        /// </summary>
        /// <param name="archiveListCellRptID"></param>
        /// <param name="OrderIndex"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public void updateFileOrderIndexByArchiveID(string archiveID)
        {
            myArchiveBLL.updateFileOrderIndexByArchiveID(archiveID);
        }

        /// <summary>
        /// 删除案卷
        /// </summary>
        /// <param name="archiveListCellRptID"></param>
        /// <param name="OrderIndex"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public void DeleteArchiveMore(string ArchiveIdList)
        {
            myArchiveBLL.DeleteArchiveMore(ArchiveIdList);
        }
    }
}