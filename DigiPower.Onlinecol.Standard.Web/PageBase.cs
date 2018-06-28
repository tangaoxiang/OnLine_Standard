using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.MobileControls;
using System.Collections.Generic;

namespace DigiPower.Onlinecol.Standard.Web
{
    public class PageBase : System.Web.UI.Page
    {
        /// <summary>
        /// 当前页索引
        /// </summary>
        public string pPageIndex = "0";

        /// <summary>
        /// 查询条件
        /// </summary>
        public string SqlWhere = "";

        /// <summary>
        /// 模块ID
        /// </summary>
        public string ModuleID = null;

        /// <summary>
        /// 模块BH
        /// </summary>
        public string ModelBH = null;

        /// <summary>
        /// 流程ID
        /// </summary>
        public string WorkFlowID = null;

        /// <summary>
        /// 页面编辑状态，全部转小写
        /// </summary>
        public string Action = string.Empty;

        protected override void OnLoad(EventArgs e)
        {
            if (Common.Session.GetSession("RoleID") == "")
            {
                Response.Write("window.parent.location.href='../UserLoginGather.aspx';</script>");
            }
            base.OnLoad(e);
        }

        /// <summary>
        ///页面加载完成事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoadComplete(EventArgs e)
        {
            try
            {
                ModuleID = Common.DNTRequest.GetQueryString("ModuleID");
                WorkFlowID = Common.DNTRequest.GetQueryString("WorkFlowID");
                ModelBH = Common.DNTRequest.GetQueryString("ModelBH");

                if (!String.IsNullOrEmpty(ModuleID))  //菜单
                {
                    ValidateRight("1", ModuleID);
                }
                if (!String.IsNullOrEmpty(WorkFlowID) && String.IsNullOrEmpty(ModelBH))//流程
                {
                    ValidateRight("2", WorkFlowID);
                }
                if (!String.IsNullOrEmpty(WorkFlowID) && !String.IsNullOrEmpty(ModelBH))//内页
                {
                    ValidateRight("3", ModelBH);
                }
            }
            catch { }
            base.OnLoadComplete(e);
        }

        /// <summary>
        /// 校验用户权限
        /// </summary>
        private void ValidateRight(string RoleRightType, string Id)
        {
            BLL.T_RoleRight_BLL roleRightBLL = new DigiPower.Onlinecol.Standard.BLL.T_RoleRight_BLL();
            string strWhere = string.Empty;
            if (RoleRightType == "3")//内页
                strWhere = " RoleID=" + Common.Session.GetSession("RoleID") + " and LOWER(ModelBH)='" + Id.ToLower() + "' and RoleRightType=" + RoleRightType;
            else
                strWhere = " RoleID=" + Common.Session.GetSession("RoleID") + " and ModelID=" + Id + " and RoleRightType=" + RoleRightType;

            List<Model.T_RoleRight_MDL> list = roleRightBLL.GetModelList(strWhere);

            string strJs = string.Empty;
            if (list != null && list.Count > 0)
            {
                //strJs += " $(\"#anlButtonList\").children().each(function(index,element){ ";
                //strJs += " $(element).hide();	 ";
                //strJs += " });";

                string[] RightListIDS = (list[0].RightListID + ",").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string RightListID in RightListIDS)
                {
                    strJs += "$(\"#" + RightListID + "\").show();  ";
                }
            }
            Common.MessageBox.RegisterStartupScriptString(this.Page, strJs);
        }

        /// <summary>
        /// 编辑窗体属性赋值
        /// 主要是通过Request.QueryString给 Action，ID，SqlWhere，PageIndex 赋值
        /// </summary>
        public void MyAddInit()
        {
            Action = Common.DNTRequest.GetQueryString("Action").ToLower();

            ID = Common.DNTRequest.GetQueryString("ID");

            if (Action.Equals("add"))
            {
                ViewState["ps"] = CommonEnum.PageState.ADD;
            }
            if (Action.Equals("edit"))
            {
                ViewState["ps"] = CommonEnum.PageState.EDIT;
            }
            if (Action.Equals("view"))
            {
                ViewState["ps"] = CommonEnum.PageState.VIEW;
            }
        }
        public void Search(Control Contr1, object model)
        {
        }
        public void MyInit(Control col)
        {

        }
    }
}