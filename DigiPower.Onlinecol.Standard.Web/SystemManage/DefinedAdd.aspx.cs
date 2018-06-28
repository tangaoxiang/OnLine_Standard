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
    public partial class DefinedAdd : PageBase
    {
        #region 属性及构造函数

        protected void Page_Load(object sender, EventArgs e)
        {
            MyAddInit();

            if (!this.IsPostBack)
            {
                DigiPower.Onlinecol.Standard.BLL.UserOperate ubll = new DigiPower.Onlinecol.Standard.BLL.UserOperate();

                if (Action.ToLower().Equals("edit"))
                {
                    DataSet ds = new DataSet();

                    ds = ubll.GetDepartmentList("select * from vwDefine where DefineResultID = " + ID + "");

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        CanDefineTypeID.InfoID = ds.Tables[0].Rows[0]["SystemInfoID"].ToString();

                        CanDefineTypeID.DataBindEx();

                        CutLength.StartLocation = Common.ConvertEx.ToInt(ds.Tables[0].Rows[0]["StartLocation"].ToString());

                        CutLength.EndLocation = Common.ConvertEx.ToInt(ds.Tables[0].Rows[0]["EndLocation"].ToString());

                        CutLength.DataBindEx();
                    }
                }

                if (Action.ToLower().Equals("add"))
                {
                    CanDefineTypeID.InfoID = ID;

                    CanDefineTypeID.DataBindEx();

                    CutLength.StartLocation = 0;

                    CutLength.EndLocation = 10;

                    CutLength.DataBindEx();
                }

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
            Model.T_DefineReult_MDL model = new DigiPower.Onlinecol.Standard.Model.T_DefineReult_MDL();

            BLL.T_DefineReult_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_DefineReult_BLL();
            if (ViewState["model"] != null)
                model = (Model.T_DefineReult_MDL)ViewState["model"];
            object obj = Comm.GetValueToObject(model, this.tbl);

            if (obj != null)
            {
                Model.T_DefineReult_MDL Newmodel = (Model.T_DefineReult_MDL)obj;

                switch ((CommonEnum.PageState)ViewState["ps"])
                {
                    case CommonEnum.PageState.ADD:

                        Newmodel.CanDefineTypeID = DigiPower.Onlinecol.Standard.Common.ConvertEx.ToInt(this.CanDefineTypeID.SelectValue);

                        Newmodel.SplitID = DigiPower.Onlinecol.Standard.Common.ConvertEx.ToInt(this.SplitID.SelectValue);

                        bll.Add(Newmodel);

                        break;

                    case CommonEnum.PageState.EDIT:
                        {
                            Newmodel.DefineResultID = DigiPower.Onlinecol.Standard.Common.ConvertEx.ToInt(ID);

                            bll.Update(Newmodel);
                        }

                        break;
                }
            }

            Response.Redirect("DefinedList.aspx?sqlwhere=" + SqlWhere + "&PageIndex=" + pPageIndex + "");
        }

        #endregion

        #region 方法

        /// <summary>
        /// 绑定页面
        /// </summary>
        /// <param name="ID"></param>
        private void BindPage(string ID)
        {
            Model.T_DefineReult_MDL model = new DigiPower.Onlinecol.Standard.Model.T_DefineReult_MDL();

            BLL.T_DefineReult_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_DefineReult_BLL();

            model = bll.GetModel(DigiPower.Onlinecol.Standard.Common.ConvertEx.ToInt(ID));

            if (model != null)
            {
                DigiPower.Onlinecol.Standard.Web.Comm.SetValueToPage(model, this.tbl);
                ViewState["model"] = model;
              //  this.CanDefineTypeID.SelectValue = model.CanDefineTypeID.ToString();
            }
        }

        #endregion
    }
}
