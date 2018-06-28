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

namespace DigiPower.Onlinecol.Standard.Web.SystemManage
{
    public partial class FieldAdd : PageBase
    {
        #region 属性及构造函数

        protected void Page_Load(object sender, EventArgs e)
        {
            MyAddInit();

            if (!this.IsPostBack)
            {
                if (!String.IsNullOrEmpty(Action))
                {
                    //给当前页面操作状态赋值
                    if (Action.ToLower().Equals("add"))
                    {
                       ViewState["ps"] = CommonEnum.PageState.ADD;
                    }
                    if (Action.ToLower().Equals("edit"))
                    {
                       ViewState["ps"] = CommonEnum.PageState.EDIT;                       
                    }
                }

                if ((CommonEnum.PageState)ViewState["ps"] == CommonEnum.PageState.EDIT)
                {
                    if (!String.IsNullOrEmpty(ID))
                    {
                        BindPage(ID);
                    }
                }
            }
        }

        #endregion

        #region 事件

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Model.T_Field_MDL model = new DigiPower.Onlinecol.Standard.Model.T_Field_MDL();

            BLL.T_Field_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_Field_BLL();
            if (ViewState["model"] != null)
                model = (Model.T_Field_MDL)ViewState["model"];
            object obj = Comm.GetValueToObject(model, this.tbl);

            if (obj != null)
            {
                Model.T_Field_MDL Newmodel = (Model.T_Field_MDL)obj;

                switch ((CommonEnum.PageState)ViewState["ps"])
                {
                    case CommonEnum.PageState.ADD:

                        bll.Add(Newmodel);

                        break;

                    case CommonEnum.PageState.EDIT:
                        {
                            Newmodel.FieldID = Convert.ToInt32(ID);

                            bll.Update(Newmodel);
                        }

                        break;
                }
            }

            Response.Redirect("FieldList.aspx?sqlwhere=" + SqlWhere + "&PageIndex=" + pPageIndex + "");
        }

        #endregion

        #region 方法

        /// <summary>
        /// 绑定页面
        /// </summary>
        /// <param name="ID"></param>
        private void BindPage(string ID)
        {
            Model.T_Field_MDL model = new DigiPower.Onlinecol.Standard.Model.T_Field_MDL();

            BLL.T_Field_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_Field_BLL();

            model = bll.GetModel(Convert.ToInt32(ID));

            if (model != null)
            {
                ViewState["model"] = model;
                DigiPower.Onlinecol.Standard.Web.Comm.SetValueToPage(model, this.tbl);
            }
        }

        #endregion
    }
}
