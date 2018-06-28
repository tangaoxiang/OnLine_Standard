using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.BLL;

//归档目录分配

namespace DigiPower.Onlinecol.Standard.Web
{
    public partial class ArchiveToUser : PageBase
    {
        # region 事件
        protected void Page_Load(object sender, EventArgs e)
        {
            GridProject.SelCheckType = DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlGridEx.SelType.Radio;
            //GridProject.PageCount = 5;

            if (Session["CompanyID"] != null)
            {
                BindGridProject(Session["CompanyID"].ToString());
            }

            if (!IsPostBack)
            {
                List<string> li = new List<string>();
                li = GridProject.GetSelects();
                if (li.Count > 0)
                {
                    SetFrameUrl("qxfp", li[0]);
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            List<string> li = new List<string>();
            li = GridProject.GetSelects();
            if (li.Count > 0)
            {
                SetFrameUrl("yhck", li[0]);
            }
        }

        protected void lbtnUpdate_Click(object sender, EventArgs e)
        {
            List<string> li = new List<string>();
            li = GridProject.GetSelects();
            if (li.Count > 0)
            {
                SetFrameUrl("qxfp", li[0]);
            }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 绑定单位对应的所有工程
        /// </summary>
        /// <param name="companyid">当前用户对应的单位ID</param>
        protected void BindGridProject(string companyid)
        {
            BLL.T_SingleProject_BLL bll = new T_SingleProject_BLL();
            DataSet ds = bll.GetCompanyPro("a.companyid='" + companyid + "' and c.SingleProjectID is not null");
            List<string> li = new List<string>();
            li.Add("companyname");
            li.Add("gcmc");
            li.Add("gcdd");
            GridProject.InitGrid("SingleProjectID", li, ds, "");
        }


        protected void SetFrameUrl(string type, string SingleProjectID)
        {
            string url = "";
            if (type == "yhck")//用户查看
            {
                url = "ProjectUserList.aspx?SingleProjectID=" + SingleProjectID;
            }
            else if (type == "qxfp") //权限分配
            {
                url = "ArchiveToUserMod.aspx?SingleProjectID=" + SingleProjectID;
            }
            ibUser.Attributes.Add("src", url);
        }

        #endregion
    }
}