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
    public partial class MyWorkFlowAdd : PageBase
    {
        #region 属性及构造函数

        private CommonEnum.PageState ps;
        //string ID = null;
        //string Action = null;
        //string sqlwhere = null;
        //bool IsChange= false;

        protected void Page_Load(object sender, EventArgs e)
        {
            
                Action = Request.QueryString["Action"];
                ID = Request.QueryString["ID"];
                //sqlwhere = Request.QueryString["sqlwhere"];
                if (!String.IsNullOrEmpty(Action))
                {
                    //给当前页面操作状态赋值
                    if (Action.ToLower().Equals("add"))
                    {
                        ps = CommonEnum.PageState.ADD;
                    }
                    if (Action.ToLower().Equals("edit"))
                    {
                        ps = CommonEnum.PageState.EDIT;
                    }
                }
                if (!IsPostBack)
                {
                    DigiPower.Onlinecol.Standard.CBLL.WorkFlowManage cbll = new DigiPower.Onlinecol.Standard.CBLL.WorkFlowManage();
                    //UserID.DataBindEx(Common.Session.GetSession("CompanyID"), true);
                    PID.DataBindEx();
                    if (ps == CommonEnum.PageState.EDIT)
                    {
                        if (!String.IsNullOrEmpty(ID))
                        {
                            if (!this.IsPostBack)
                            {
                                //绑定页面
                                BindPage(ID);
                            }
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
            switch (ps)
            {
                case CommonEnum.PageState.ADD:
                    //添加
                    Add();
                    break;
                case CommonEnum.PageState.EDIT:
                    {
                        //更新
                        if (!String.IsNullOrEmpty(ID))
                        {
                            if (PID.SelectValue == ID)
                            {
                                Common.MessageBox.Show(this, "父级不可以是自已，请重新选择！");
                                return;
                            }
                            else
                            {
                                Update(Convert.ToInt32(ID));
                            }
                        }
                    }
                    break;
            }
            Response.Redirect("WorkFlowList.aspx");
        }

        #endregion

        #region 方法


        /// <summary>
        /// 添加
        /// </summary>
        private void Add()
        {
            BLL.T_WorkFlow_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_WorkFlow_BLL();
            Model.T_WorkFlow_MDL Newmodel = new DigiPower.Onlinecol.Standard.Model.T_WorkFlow_MDL();
            Newmodel = (Model.T_WorkFlow_MDL)Comm.GetValueToObject(Newmodel, this.tbl);
            CBLL.WorkFlowManage cbll = new DigiPower.Onlinecol.Standard.CBLL.WorkFlowManage();
            cbll.Add(Newmodel);

            //CBLL.WorkFlowManage cbll = new DigiPower.Onlinecol.Standard.CBLL.WorkFlowManage();

            //Model.T_WorkFlow_MDL model = new DigiPower.Onlinecol.Standard.Model.T_WorkFlow_MDL();

            //BLL.T_WorkFlow_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_WorkFlow_BLL();

            //object obj = Comm.GetValueToObject(model, this.tbl);

            //Model.T_WorkFlow_MDL Newmodel = (Model.T_WorkFlow_MDL)obj;

            //int FlowNo = bll.Add(Newmodel);

            ////子流程
            //DataSet ds = bll.GetList("PID = '" + Newmodel.PID + "'");

            //DigiPower.Onlinecol.Standard.Model.T_WorkFlow_MDL ChildMode = new DigiPower.Onlinecol.Standard.Model.T_WorkFlow_MDL();

            //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //{
            //    ChildMode = bll.GetModel(Convert.ToInt32(ds.Tables[0].Rows[0]["WorkFlowID"].ToString()));

            //    //不是最后结点。自已不能指到自已
            //    if (ChildMode.WorkFlowID != FlowNo)
            //    {
            //        //更新子节点
            //        ChildMode.PID = FlowNo;

            //        bll.Update(ChildMode);
            //    }
            //}
        }

        /// <summary>
        /// 更新
        /// </summary>
        private void Update(int FlowWorkID)
        {            
            BLL.T_WorkFlow_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_WorkFlow_BLL();
            Model.T_WorkFlow_MDL Newmodel = bll.GetModel(Common.ConvertEx.ToInt(ID));
            Newmodel = (Model.T_WorkFlow_MDL)Comm.GetValueToObject(Newmodel, this.tbl);            
            CBLL.WorkFlowManage cbll = new DigiPower.Onlinecol.Standard.CBLL.WorkFlowManage();
            cbll.Update(Newmodel);            
        }

        /// <summary>
        /// 绑定页面
        /// </summary>
        /// <param name="ID"></param>
        private void BindPage(string ID)
        {
            BLL.T_WorkFlow_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_WorkFlow_BLL();
            Model.T_WorkFlow_MDL model = bll.GetModel(Convert.ToInt32(ID));
            if (model != null)
            {
                DigiPower.Onlinecol.Standard.Web.Comm.SetValueToPage(model, this.tbl);
            }
        }
        #endregion
    }
}
