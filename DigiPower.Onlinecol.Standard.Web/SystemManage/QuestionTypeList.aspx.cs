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
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Common;

namespace DigiPower.Onlinecol.Standard.Web.SystemManage
{
    public partial class QuestionTypeList : PageBase
    {
        T_QuestionType_BLL questionTypeBLL = new T_QuestionType_BLL();
        T_Question_BLL questionBLL = new T_Question_BLL();

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
            Ajax.Utility.RegisterTypeForAjax(typeof(QuestionTypeList));
            MyAddInit();

            if (!IsPostBack)
            {
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("txtTitle")))
                    txtTitle.Text = DNTRequest.GetQueryString("txtTitle");

                BindGridView(AspNetPager.CurrentPageIndex);
            }
        }

        /// <summary>
        /// 删除问题分类
        /// </summary> 
        /// <param name="questionTypeID"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public bool DeleteQuestionTypep(string questionTypeID)
        {
            bool flag = false;
            if (questionBLL.GetCount(questionTypeID) < 1)
            {
                flag = true;
                questionTypeBLL.Delete(ConvertEx.ToInt(questionTypeID));
            }
            return flag;
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        /// <param name="pageIndex">索引页</param>
        private void BindGridView(int pageIndex)
        {
            string strWhere = " 1=1 ";
            if (!String.IsNullOrWhiteSpace(txtTitle.Text.Trim()))
                strWhere += " AND title like '%" + txtTitle.Text.Trim() + "%' ";

            if (ViewState["CurrentPageIndex"] == null && Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex")) > 0)
            {
                pageIndex = Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex"));
                ViewState["CurrentPageIndex"] = pageIndex;
            }
            else
            {
                pageIndex = ConvertEx.ToInt(ViewState["CurrentPageIndex"]);
            }

            DataTable dt = questionTypeBLL.GetListPaging(strWhere, pageSize, pageIndex, out itemCount); ;
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
        protected void AspNetPager_PageChanged(object sender, EventArgs e)
        {
            ViewState["CurrentPageIndex"] = AspNetPager.CurrentPageIndex;
            BindGridView(AspNetPager.CurrentPageIndex);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGridView(1);
        }
    }
}
