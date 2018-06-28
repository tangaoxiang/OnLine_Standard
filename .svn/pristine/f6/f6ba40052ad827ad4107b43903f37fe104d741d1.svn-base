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

namespace DigiPower.Onlinecol.Standard.Web.WorkFlow
{
    public partial class QuestionList : PageBase
    {
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
            Ajax.Utility.RegisterTypeForAjax(typeof(QuestionList));
            MyAddInit();

            if (!IsPostBack)
            {
                DataBindEx();

                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("ddlQuestionType")))
                    ddlQuestionType.SelectedValue = Server.UrlDecode(DNTRequest.GetQueryString("ddlQuestionType"));
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("txtTitle")))
                    txtTitle.Text = Server.UrlDecode(DNTRequest.GetQueryString("txtTitle"));

                BindGridView(AspNetPager.CurrentPageIndex);
            }
        }

        private void BindGridView(int pageIndex)
        {
            string strWhere = " 1=1 ";
            if (!String.IsNullOrWhiteSpace(txtTitle.Text.Trim()))
                strWhere += " AND title like '%" + txtTitle.Text.Trim() + "%' ";
            if (!String.IsNullOrWhiteSpace(ddlQuestionType.SelectedValue) && ddlQuestionType.SelectedValue != "0")
                strWhere += " AND QuestionTypeCode = '" + ddlQuestionType.SelectedValue + "' ";

            if (ViewState["CurrentPageIndex"] == null && Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex")) > 0)
            {
                pageIndex = Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex"));
                ViewState["CurrentPageIndex"] = pageIndex;
            }
            else
            {
                pageIndex = ConvertEx.ToInt(ViewState["CurrentPageIndex"]);
            }

            DataTable dt = questionBLL.GetListPaging(strWhere, pageSize, pageIndex, out itemCount);
            AspNetPager.AlwaysShow = true;
            AspNetPager.PageSize = pageSize;

            AspNetPager.RecordCount = itemCount;
            AspNetPager.CurrentPageIndex = pageIndex;

            rpData.DataSource = dt;
            rpData.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGridView(1);
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
        /// 绑定问题类别
        /// </summary>
        private void DataBindEx()
        {
            DataTable dt = new T_SystemInfo_BLL().GetList("CurrentType='QuestionType'").Tables[0];
            ddlQuestionType.DataTextField = "SystemInfoName";
            ddlQuestionType.DataValueField = "lower_SystemInfoCode";
            ddlQuestionType.DataSource = dt;
            ddlQuestionType.DataBind();
            ddlQuestionType.Items.Insert(0, new ListItem("全部", "0"));
        }

        /// <summary>
        /// 删除问题
        /// </summary>
        /// <param name="Key"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public void DeleteQuestion(string Key)
        {
            T_Question_BLL bll = new T_Question_BLL();
            bll.Delete(ConvertEx.ToInt(Key));
        }
    }
}