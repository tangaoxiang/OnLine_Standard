using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.Common;

namespace DigiPower.Onlinecol.Standard.CBLL
{
    public class WorkFlowManage
    {
        public WorkFlowManage()
        {
        }

        public int Add(DigiPower.Onlinecol.Standard.Model.T_WorkFlow_MDL model)
        {
            int WorkFlowID = 0;
            BLL.T_WorkFlow_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_WorkFlow_BLL();
            if (model.PID == 0)
            {                
                Model.T_WorkFlow_MDL newChildMDL = bll.GetModel("PID=" + model.PID);
                WorkFlowID = bll.Add(model);

                newChildMDL.PID = WorkFlowID;
                bll.Update(newChildMDL);                
            }
            else
            {
                //新 父
                Model.T_WorkFlow_MDL newParentMDL = bll.GetModel("WorkFlowID=" + model.PID);
                //新 子
                Model.T_WorkFlow_MDL newChildMDL = bll.GetModel("PID=" + newParentMDL.WorkFlowID);

                WorkFlowID = bll.Add(model);//更新填的结果

                //更新父子关系
                Model.T_WorkFlow_MDL parentMDL = bll.GetModel("WorkFlowID=" + model.PID);
                if (newParentMDL != null)
                {
                    if (newChildMDL != null)
                    {
                        newChildMDL.PID = WorkFlowID;
                        bll.Update(newChildMDL);
                    }
                }
                WorkFlowID = model.WorkFlowID;
            }
            return WorkFlowID;
        }

        public void DeleteFlag(int WorkFlowDefinID,bool DeleteFlag)
        {
            BLL.T_WorkFlowDefine_BLL bll = new T_WorkFlowDefine_BLL();
            Model.T_WorkFlowDefine_MDL mdl = bll.GetModel(WorkFlowDefinID);
            mdl.Del = DeleteFlag;
            bll.Update(mdl);
        }

        public void Delete(int WorkFlowID)
        {
            BLL.T_WorkFlow_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_WorkFlow_BLL();
            Model.T_WorkFlow_MDL currentMDL = bll.GetModel(WorkFlowID);
            //原 父
            Model.T_WorkFlow_MDL oldParentMDL = bll.GetModel("WorkFlowID=" + currentMDL.PID);
            //原 子
            Model.T_WorkFlow_MDL oldChildMDL = bll.GetModel("PID=" + currentMDL.WorkFlowID);
            if (oldChildMDL != null && oldParentMDL != null)
            {
                oldChildMDL.PID = oldParentMDL.WorkFlowID;
                bll.Update(oldChildMDL);
            }
            else if (oldChildMDL != null)
            {
                oldChildMDL.PID = 0;
                bll.Update(oldChildMDL);
            }
            bll.Delete(WorkFlowID);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(DigiPower.Onlinecol.Standard.Model.T_WorkFlow_MDL model)
        {
            BLL.T_WorkFlow_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_WorkFlow_BLL();

            Model.T_WorkFlow_MDL currentMDL = bll.GetModel(model.WorkFlowID);
            //原 父 ,可空
            Model.T_WorkFlow_MDL oldParentMDL = bll.GetModel("WorkFlowID=" + currentMDL.PID);
            //原 子 ,可空
            Model.T_WorkFlow_MDL oldChildMDL = bll.GetModel("PID=" + currentMDL.WorkFlowID);

            //新 父 ,可空
            Model.T_WorkFlow_MDL newParentMDL = bll.GetModel("WorkFlowID=" + model.PID);
            //新 子 ,新父的子,可空
            Model.T_WorkFlow_MDL newChildMDL = null;
            if (newParentMDL != null)
            {
                newChildMDL = bll.GetModel("PID=" + newParentMDL.WorkFlowID);
            }
            else if (model.PID == 0)
            {
                newChildMDL = bll.GetModel("PID=" + model.PID);
            }

            bll.Update(model);//更新填的结果

            if (oldChildMDL != null)// && newChildMDL.WorkFlowID > 0
            {
                if (oldParentMDL != null)
                {
                    oldChildMDL.PID = oldParentMDL.WorkFlowID;
                }
                else
                {
                    oldChildMDL.PID = 0;
                }
                bll.Update(oldChildMDL);
            }
            if (newChildMDL != null)// && newChildMDL.WorkFlowID > 0
            {
                newChildMDL.PID = model.WorkFlowID;
                bll.Update(newChildMDL);
            }
        }

        #region 工程工作流控制
        /// <summary>
        /// 更新工程工作流流程到下一步
        /// </summary>
        /// <param name="SingleProjectID">工程ID</param>
        /// <param name="workflowid">流程ID</param>
        /// <returns></returns>
        public bool GoNextProjectWorkFlowSataus(int SingleProjectID,int WorkFlowID)
        {
            //更新最后一次的工程，下次它排前面，方便操作些
            BLL.T_SingleProject_BLL spBLL=new T_SingleProject_BLL();
            Model.T_SingleProject_MDL spMDL = spBLL.GetModel(SingleProjectID);
            spMDL.LastUserTime = DateTime.Now;    //提交或退回的时间 jdk 2015.03.14
            spBLL.Update(spMDL);
            //====================

            Model.T_WorkFlowDefine_MDL wkfMDL = new T_WorkFlowDefine_MDL();
            wkfMDL.WorkFlowID = WorkFlowID;
            wkfMDL.IsRollBack = false;//归0
            wkfMDL.SingleProjectID = SingleProjectID;
            wkfMDL.SubmitStatus = 0;//2010-07-13 变0表示未提交和受理 1就选中了
            wkfMDL.SubmitUserID = Common.ConvertEx.ToInt(Common.Session.GetSession("UserID"));
            wkfMDL.SubmitDateTime = DateTime.Now;

            DataSet ds = new DataSet();
            ds = (new T_WorkFlowDefine_BLL()).UpdateProjectWorkFlowStatus(wkfMDL);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["del"].ToString() == "True")
                {
                    return GoNextProjectWorkFlowSataus(SingleProjectID,ConvertEx.ToInt(ds.Tables[0].Rows[0]["workflowid"].ToString()));
                }
                else
                {//往下走了。需要把下一工作流的用户加入到当前工程中来。

                    //BLL.T_WorkFlow_BLL bll = new T_WorkFlow_BLL();
                    //Model.T_WorkFlow_MDL mdl = bll.GetList(" WorkFlowID=" + ds.Tables[0].Rows[0]["WorkFlowID"] + " AND OrderIndex=1");
                    //if (mdl.RoleID > 0)
                    //{
                    //    T_SingleProjectUser_MDL userMDL = new T_SingleProjectUser_MDL();
                    //    userMDL.RoleID = mdl.RoleID;
                    //    userMDL.SingleProjectID = Common.ConvertEx.ToInt(ds.Tables[0].Rows[0]["SingleProjectID"]);
                    //    userMDL.CreateDate = DateTime.Now;

                    //    T_SingleProjectUser_BLL userBLL = new T_SingleProjectUser_BLL();
                    //    userBLL.Add(userMDL);
                    //}

                    return true;
                }
            }
            else
                return false;
        }

        /// <summary>
        /// 回滚工程工作流流程
        /// </summary>
        /// <param name="SingleProjectID">工程ID</param>
        /// <param name="workflowid">流程ID</param>
        /// <returns></returns>
        public bool RollBackProjectWorkFlowStatus(int SingleProjectID)
        //    public bool RollBackProjectWorkFlowStatus(int SingleProjectID, int workflowid)
        {
            //DataSet ds = new DataSet();
            //ds = 
            return (new T_WorkFlowDefine_BLL()).RollBackProjectWorkFlowStatus(SingleProjectID);
            //if (ds != null)
            //{
                
            //    if (ds.Tables[0].Rows[0]["del"].ToString() == "True")
            //    {
            //        return RollBackProjectWorkFlowStatus(SingleProjectID, ConvertEx.ToInt(ds.Tables[0].Rows[0]["workflowid"].ToString()));
            //    }
            //    else
            //        return true;
            //}
            //else
            //    return false;
        }
        #endregion
    }
}
