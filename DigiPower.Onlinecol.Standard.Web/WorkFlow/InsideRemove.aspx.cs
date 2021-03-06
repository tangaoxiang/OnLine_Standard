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
using DigiPower.Onlinecol.Standard.CBLL;


namespace DigiPower.Onlinecol.Standard.Web.WorkFlow
{
    public partial class InsideRemove : PageBase
    {
        T_Archive_BLL trBll = new T_Archive_BLL();
        T_WorkFlowDoResult_BLL doResultBLL = new T_WorkFlowDoResult_BLL();

        /// <summary>
        /// 工程ID
        /// </summary>
        public string singleProjectID = string.Empty;

        /// <summary>
        /// 工程类型
        /// </summary>
        public string projectType = string.Empty;

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
            Ajax.Utility.RegisterTypeForAjax(typeof(InsideRemove));
            singleProjectID = DNTRequest.GetQueryString("SingleProjectID");
            projectType = DNTRequest.GetQueryString("ProjectType");
            MyAddInit();

            if (!this.IsPostBack)
            {
                ctrlProjectBaseInfo1.DataBindEx(singleProjectID);                     //工程信息       
                BindGrid(AspNetPager.CurrentPageIndex);
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="pageIndex"></param>
        public void BindGrid(int pageIndex)
        {
            //从窗口接收开始,都是馆里人员操作,不用考虑建设单位等身份
            string strWhere = " AND A.SingleProjectID=" + Common.DNTRequest.GetQueryString("SingleProjectID");

            if (PublicModel.isSuperAdmin())
            {//管理员管理员获取所有工程
                strWhere += " AND D.AREA_CODE LIKE '" + Common.Session.GetSession("AREA_CODE") + "%'";
            }
            else if (PublicModel.isArchiveUser())
            {//档案馆用户看自己的
                strWhere += " AND D.AREA_CODE LIKE '" + Common.Session.GetSession("OLD_AREA_CODE") + "%'";
            }

            if (ViewState["CurrentPageIndex"] == null && Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex")) > 0)
            {
                pageIndex = Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex"));
                ViewState["CurrentPageIndex"] = pageIndex;
            }
            else
            {
                pageIndex = ConvertEx.ToInt(ViewState["CurrentPageIndex"]);
            }

            DataTable dt = trBll.GetListPaging(strWhere, pageSize, pageIndex, out itemCount, null); ;
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
    }
}