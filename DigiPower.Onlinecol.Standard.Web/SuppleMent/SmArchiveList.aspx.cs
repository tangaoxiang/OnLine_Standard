﻿using System;
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

//案卷管理
namespace DigiPower.Onlinecol.Standard.Web.WorkFlow {
    public partial class SmArchiveList : PageBase {
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
            Ajax.Utility.RegisterTypeForAjax(typeof(SmArchiveList));
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
            //工程状态必须走到了 整理接收 且没有入库 !=3722 才可以做补卷管理 
            string strWhere = " AND D.WorkFlow_DoStatus >=(select WorkFlowID from T_WorkFlow where LOWER(WorkFlowCode)='" +
                SystemSet.EumWorkFlowCode.WINRECV.ToString().ToLower() + "') and  d.Status!=3722 ";

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
    }
}