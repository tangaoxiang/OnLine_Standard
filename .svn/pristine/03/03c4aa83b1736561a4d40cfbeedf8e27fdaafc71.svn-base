using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DigiPower.Onlinecol.Standard.CBLL;
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.BLL;
using System.Data;

namespace DigiPower.Onlinecol.Standard.Web.WorkFlow
{
    public partial class SubmitToReadyCheck : System.Web.UI.Page
    {
        protected string cellFilePath = null;   //华表模板路径
        protected string CompanyID = "";                //工程对应的公司ID
        protected string SingleProjectID = "";          //工程ID
        protected string ConstructionProjectID = "";    //项目ID
        protected string NewGUID = "123456.CLL";
        protected int FirstFlag = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Ajax.Utility.RegisterTypeForAjax(typeof(SubmitToReadyCheck));
            if (!IsPostBack)
            {
                NewGUID = Guid.NewGuid() + ".cll";
                Session["CellTempGUID"] = NewGUID;
                SingleProjectID = Common.DNTRequest.GetQueryString("SingleProjectID");
                T_SingleProject_MDL SingProMdl = new T_SingleProject_BLL().GetModel(Common.ConvertEx.ToInt(SingleProjectID));
                T_Construction_Project_MDL ConProMdl = new T_Construction_Project_BLL().GetModel(Common.ConvertEx.ToInt(SingProMdl.ConstructionProjectID));
                if (ConProMdl != null)
                {
                    CompanyID = Common.ConvertEx.ToString(ConProMdl.CompanyID);
                    ConstructionProjectID = Common.ConvertEx.ToString(ConProMdl.ConstructionProjectID);
                }

                string Action = Common.DNTRequest.GetString("Action");

                Session["Tmp_Action"] = Action;
                Session["Tmp_SingleProjectID"] = SingleProjectID;
                Session["Tmp_WorkFlowID"] = Common.DNTRequest.GetString("WorkFlowID");


                if (Action == "Add")
                {//申请
                    //弹出申请单，用户填写完成后，保存
                    ClientScript.RegisterStartupScript(this.GetType(), "IsSuccess", "<script type=\"text/javascript\">ShowButton('Button1','Button2');</script>");
                }
                else if (Action == "Recv")
                {//受理
                    //弹出申请单，用户只是查看一下，无需保存
                    ClientScript.RegisterStartupScript(this.GetType(), "IsSuccess", "<script type=\"text/javascript\">ShowButton('Button2','Button1');</script>");
                }

                string CellName = Common.DNTRequest.GetString("CellName");
                cellFilePath = "http://" + Request.Url.Authority + "/Upload/SubmitCell/" + CellName;//华表模板路径

                if (CellName.IndexOf("Model=1") > -1) //表明是第一次
                {
                    FirstFlag = 1;
                }
            }
        }

        /// <summary>
        /// 保存提交
        /// </summary>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public string SaveAndSubmit()
        {
            try
            {
                string Tmp_Action = Common.ConvertEx.ToString(Session["Tmp_Action"]);
                string Tmp_SingleProjectID = Common.ConvertEx.ToString(Session["Tmp_SingleProjectID"]);
                string Tmp_WorkFlowID = Common.ConvertEx.ToString(Session["Tmp_WorkFlowID"]);

                if (Tmp_Action == "Add")
                {
                    //存下华表路径
                    List<T_WorkFlowDefine_MDL> ltDefineMdl = new T_WorkFlowDefine_BLL().GetModelList("SingleProjectID=" + Tmp_SingleProjectID + " AND WorkFlowID=" + Tmp_WorkFlowID + "");
                    if (ltDefineMdl.Count > 0)
                    {
                        T_WorkFlowDefine_MDL Mdl = ltDefineMdl[0];
                        Mdl.SubmitCellPath = "SubmitToReadyCheck.aspx?CellName=" + Session["CellTempGUID"].ToString();
                        Mdl.RecvCellPath = Mdl.SubmitCellPath;

                        //Mdl.SubmitDateTime = DateTime.Now;
                        //Mdl.SubmitUserID = Common.ConvertEx.ToInt(Session["UserID"]);
                        new T_WorkFlowDefine_BLL().Update(Mdl);
                    }

                    //仅处理最后结果
                    WorkFlowManage workflowmanage = new WorkFlowManage();
                    workflowmanage.GoNextProjectWorkFlowSataus(Common.ConvertEx.ToInt(Tmp_SingleProjectID), Common.ConvertEx.ToInt(Tmp_WorkFlowID));
                }
                return "success";//MyTaskList.aspx
            }
            catch
            {
                return "fail";
            }
        }
        /// <summary>
        /// 保存受理
        /// </summary>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public string SaveAndAccept()
        {
            try
            {
                //仅处理最后结果
                string Tmp_SingleProjectID = Common.ConvertEx.ToString(Session["Tmp_SingleProjectID"]);
                string Tmp_WorkFlowID = Common.ConvertEx.ToString(Session["Tmp_WorkFlowID"]);

                //WorkFlowManage workflowmanage = new WorkFlowManage();
                //if (workflowmanage.GoNextProjectWorkFlowSataus(SingleProjectID, WorkFlowID))
                //{
                //    Response.Redirect("~/MyTaskList.aspx");
                //}

                //存下华表路径
                //List<T_WorkFlowDefine_MDL> ltDefineMdl = new T_WorkFlowDefine_BLL().GetModelList("SingleProjectID=" + Tmp_SingleProjectID + " AND WorkFlowID=" + Tmp_WorkFlowID + "");
                //if (ltDefineMdl.Count > 0)
                //{
                //    T_WorkFlowDefine_MDL Mdl = ltDefineMdl[0];
                //    Mdl.RecvCellPath = "SubmitToReadyCheck.aspx?CellName=" + NewGUID;
                //    //Mdl.RecvDateTime = DateTime.Now;
                //    //Mdl.RecvUserID = Common.ConvertEx.ToInt(Session["UserID"]);
                //    new T_WorkFlowDefine_BLL().Update(Mdl);
                //}


                BLL.T_WorkFlowDefine_BLL wkdBLL = new T_WorkFlowDefine_BLL();
                DataSet ds = wkdBLL.GetList("SingleProjectID=" + Tmp_SingleProjectID + " AND WorkFlowID=" + Tmp_WorkFlowID);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    Model.T_WorkFlowDefine_MDL wkdMDL = wkdBLL.GetModel(Common.ConvertEx.ToInt(ds.Tables[0].Rows[0]["WorkFlowDefineID"].ToString()));

                    wkdMDL.SubmitStatus = 2;//受理完成状态
                    wkdMDL.RecvUserID = Common.ConvertEx.ToInt(Session["UserID"]);
                    wkdMDL.RecvDateTime = DateTime.Now;

                    wkdMDL.RecvCellPath = "SubmitToReadyCheck.aspx?CellName=" + Session["CellTempGUID"].ToString();

                    wkdBLL.Update(wkdMDL);

                    return " SingleProjectID=" + Tmp_SingleProjectID + "&WorkFlowID=" + Tmp_WorkFlowID;
                }
                return "success";
            }
            catch
            {
                return "fail";
            }
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    string Action = Common.DNTRequest.GetString("Action");
        //    if (Action == "Add")
        //    {
        //        //存下华表路径

        //        //仅处理最后结果
        //        int SingleProjectID = Common.ConvertEx.ToInt(Common.DNTRequest.GetString("SingleProjectID"));
        //        int WorkFlowID = Common.ConvertEx.ToInt(Common.DNTRequest.GetString("WorkFlowID"));

        //        WorkFlowManage workflowmanage = new WorkFlowManage();
        //        if (workflowmanage.GoNextProjectWorkFlowSataus(SingleProjectID, WorkFlowID))
        //        {
        //            Response.Redirect("~/MyTaskList.aspx");
        //        }
        //    }
        //    else
        //    {
        //    }
        //}

        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    //仅处理最后结果
        //    int SingleProjectID = Common.ConvertEx.ToInt(Common.DNTRequest.GetString("SingleProjectID"));
        //    int WorkFlowID = Common.ConvertEx.ToInt(Common.DNTRequest.GetString("WorkFlowID"));

        //    //WorkFlowManage workflowmanage = new WorkFlowManage();
        //    //if (workflowmanage.GoNextProjectWorkFlowSataus(SingleProjectID, WorkFlowID))
        //    //{
        //    //    Response.Redirect("~/MyTaskList.aspx");
        //    //}

        //    BLL.T_WorkFlowDefine_BLL wkdBLL = new T_WorkFlowDefine_BLL();
        //    DataSet ds = wkdBLL.GetList("SingleProjectID=" + SingleProjectID + " AND WorkFlowID=" + WorkFlowID);
        //    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {
        //        Model.T_WorkFlowDefine_MDL wkdMDL = wkdBLL.GetModel(Common.ConvertEx.ToInt(ds.Tables[0].Rows[0]["WorkFlowDefineID"].ToString()));

        //        wkdMDL.SubmitStatus = 2;//受理完成状态
        //        wkdMDL.RecvUserID = Common.ConvertEx.ToInt(Common.Session.GetSession("UserID"));
        //        wkdMDL.RecvDateTime = DateTime.Now;
        //        wkdBLL.Update(wkdMDL);

        //        //Response.Redirect();
        //        Response.Redirect("~/MyTaskList.aspx?SingleProjectID=" + SingleProjectID + "&WorkFlowID=" + WorkFlowID);
        //    }
        //}
    }
}
