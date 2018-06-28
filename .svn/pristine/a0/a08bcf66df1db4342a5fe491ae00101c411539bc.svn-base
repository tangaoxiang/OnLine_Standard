using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.BLL;
using System.Collections.Generic;

//培训计划新增/修改

namespace DigiPower.Onlinecol.Standard.Web.SystemManage
{
    public partial class TrainPlanAdd : PageBase
    {
        #region 属性及其构造方法
        protected void Page_Load(object sender, EventArgs e)
        {
            MyAddInit();

            if (!this.IsPostBack)
            {
                if (!String.IsNullOrEmpty(Action))
                {
                    ctrArchiveUserList.DataBindEx(true);
                    hid_action.Value = Action;

                    if (Action.ToLower().Equals("edit"))
                    {
                        BindPage(ID);
                        ViewState["PageState"] = CommonEnum.PageState.EDIT;
                    }

                    if (Action.ToLower().Equals("add"))
                    {
                        ViewState["PageState"] = CommonEnum.PageState.ADD;
                    }
                }
            }
        }
        #endregion

        #region 事件
        protected void btnSave_Click(object sender, EventArgs e)
        {
            T_Train_Plan_BLL tpBll = new T_Train_Plan_BLL();
            T_Train_Plan_MDL tpMdl = new T_Train_Plan_MDL();

            if (ViewState["model"] != null)
                tpMdl = ViewState["model"] as T_Train_Plan_MDL;

            object obj = Comm.GetValueToObject(tpMdl, tb_TranPlan);//将窗体控件值赋给Model对象
            if (obj != null)
            {
                T_Train_Plan_MDL new_tpMdl = obj as T_Train_Plan_MDL;
                switch ((CommonEnum.PageState)ViewState["PageState"])
                {
                    case CommonEnum.PageState.ADD:
                        int TrainPlanID = tpBll.Add(new_tpMdl);
                        SetTrainRec(Action, TrainPlanID, ctrArchiveUserList.GetSelectList());
                        break;

                    case CommonEnum.PageState.EDIT:
                        tpBll.Update(new_tpMdl);
                        SetTrainRec(Action, new_tpMdl.TrainPlanID, ctrArchiveUserList.GetSelectList());
                        break;
                }
            }
            Response.Redirect("TrainPlanList.aspx?sqlwhere=" + SqlWhere + "&PageIndex=" + pPageIndex + "");
        }
        #endregion

        #region 方法

        /// <summary>
        ///  新增培训记录
        /// </summary>
        /// <param name="TrainPlanID"></param>
        /// <param name="ltUserID"></param>
        protected void AddTrainRec(int TrainPlanID, List<string> ltUserID)
        {
            if (ltUserID.Count > 0)
            {
                foreach (string UserID in ltUserID)
                {
                    if (Common.ConvertEx.ToInt(UserID) > 0)
                    {
                        T_Train_Rec_MDL trMDL = new T_Train_Rec_MDL();
                        trMDL.UserID = Common.ConvertEx.ToInt(UserID);
                        trMDL.TrainPlanID = TrainPlanID;
                        new T_Train_Rec_BLL().Add(trMDL);


                        //更改用户的培训记录
                        T_UsersInfo_BLL uiBll = new T_UsersInfo_BLL();
                        T_UsersInfo_MDL uiMdl = uiBll.GetModel(Common.ConvertEx.ToInt(UserID));

                        int TrainCount = Common.ConvertEx.ToInt(uiMdl.TrainCount);//得到档案员的当前培训次数
                        uiMdl.TrainCount = TrainCount + 1;

                        uiBll.Update(uiMdl);
                    }
                }
            }
        }

        protected void SetTrainRec(string Action, int TrainPlanID, List<string> ltUserID)
        {
            if (Action == "add")       //直接添加培训记录  
            {
                AddTrainRec(TrainPlanID, ltUserID);
            }
            else if (Action == "edit") //先是删除培训计划下的所有档案员，然后重新添加
            {
                new T_Other_BLL().DeleteTrainRecUser(TrainPlanID);
                AddTrainRec(TrainPlanID, ltUserID);
            }
        }

        private void BindPage(string ID)
        {
            if (!String.IsNullOrEmpty(ID))
            {
                T_Train_Plan_BLL tpBll = new T_Train_Plan_BLL();
                T_Train_Plan_MDL tpMdl = tpBll.GetModel(Common.ConvertEx.ToInt(ID));//根据传入ID获得Model对象

                ViewState["model"] = tpMdl;
                if (tpMdl != null)
                {
                    Comm.SetValueToPage(tpMdl, tb_TranPlan);//将Model值赋给控件

                    List<T_Train_Rec_MDL> ltTrMdl = new T_Train_Rec_BLL().GetModelList("TrainPlanID=" + ID);
                    if (ltTrMdl.Count > 0)
                    {
                        List<string> ltKey = new List<string>();
                        foreach (T_Train_Rec_MDL trMdl in ltTrMdl)
                        {
                            ltKey.Add(trMdl.UserID.ToString());
                        }

                        ctrArchiveUserList.SetItemSelected(ltKey);
                    }
                }
            }
        }
        #endregion
    }
}
