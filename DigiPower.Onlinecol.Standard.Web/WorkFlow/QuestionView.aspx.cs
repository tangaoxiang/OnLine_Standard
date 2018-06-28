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

//问题详情预览

namespace DigiPower.Onlinecol.Standard.Web.WorkFlow
{
    public partial class QuestionView : PageBase
    {
        T_Question_BLL questionBLL = new T_Question_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            MyAddInit();
            if (!IsPostBack)
            {
                T_Question_MDL questionMDL = questionBLL.GetModel(ConvertEx.ToInt(ID));
                if (questionMDL != null)
                {
                    ltCreateUserName.Text = questionMDL.CreateUserName;
                    ltCreateDate.Text = ConvertEx.ToDate(questionMDL.CreateDate).ToString("yyyy-MM-dd");
                    ltTitle.Text = questionMDL.Title;
                    ltDescriptionHtml.Text = questionMDL.DescriptionHtml;
                    ltClickCount.Text = questionMDL.ClickCount.ToString();

                    List<T_SystemInfo_MDL> ltSysMDL = new T_SystemInfo_BLL().GetModelListForCurrentType("QuestionType", "'" + questionMDL.QuestionTypeCode + "'");

                    if (ltSysMDL != null && ltSysMDL.Count > 0)
                        ltQuestionTypeTitle.Text = ltSysMDL[0].SystemInfoName;

                    questionMDL.ClickCount += 1;
                    questionBLL.Update(questionMDL);
                }
            }
        }
    }
}