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
using DigiPower.Onlinecol.Standard.CBLL;
using DigiPower.Onlinecol.Standard.Common;
using System.Text;

//系统问题

namespace DigiPower.Onlinecol.Standard.Web.WorkFlow
{
    public partial class QuestionAdd : PageBase
    {
        T_Question_BLL questionBLL = new T_Question_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            MyAddInit();
            Ajax.Utility.RegisterTypeForAjax(typeof(QuestionAdd));
            if (!this.IsPostBack)
            {
                DataBindEx();
            }
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
        }

        /// <summary>
        /// 问题保存
        /// </summary>
        /// <param name="action"></param>
        /// <param name="questionID"></param>
        /// <param name="questionType"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="descriptionHtml"></param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public string AddQuestion(string action, int questionID, string questionType, string title, string description, string descriptionHtml)
        {
            try
            {
                if (action == CommonEnum.PageState.ADD.ToString().ToLower())
                {
                    T_Question_MDL questionMDL = new T_Question_MDL();
                    questionMDL.Title = title;
                    questionMDL.QuestionTypeCode = questionType;
                    questionMDL.Description = description;
                    questionMDL.DescriptionHtml = descriptionHtml;
                    questionMDL.CreateDate = DateTime.Now;
                    questionMDL.CreateUserName = Common.Session.GetSession("UserName");
                    questionMDL.CreateUserID = Common.Session.GetSessionInt("UserID");
                    questionMDL.ClickCount = 0;
                    questionBLL.Add(questionMDL);
                }
                else if (action == CommonEnum.PageState.EDIT.ToString().ToLower())
                {
                    T_Question_MDL questionMDL = questionBLL.GetModel(questionID);
                    if (questionMDL != null)
                    {
                        questionMDL.Title = title;
                        questionMDL.QuestionTypeCode = questionType;
                        questionMDL.Description = description;
                        questionMDL.DescriptionHtml = descriptionHtml;
                        questionBLL.Update(questionMDL);
                    }
                }
                return SystemSet._RETURN_SUCCESS_VALUE;
            }
            catch (Exception ex)
            {
                return SystemSet._RETURN_FAILURE_VALUE + ex.Message;
            }
        }

        /// <summary>
        ///返回问题JSON
        /// </summary>
        /// <param name="questionID"></param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public string GetQuestionString(string questionID)
        {
            string strString = string.Empty;

            var tb = questionBLL.GetList(" QuestionID=" + questionID).Tables[0];
            if (tb != null && tb.Rows.Count > 0)
                strString = Common.Common.DataTableToJson(tb);

            return strString;
        }
    }
}