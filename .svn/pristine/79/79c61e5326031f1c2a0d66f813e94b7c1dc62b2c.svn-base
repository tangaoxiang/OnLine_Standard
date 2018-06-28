using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
using System.Collections;
namespace DigiPower.Onlinecol.Standard.BLL {
    /// <summary>
    /// 业务逻辑类T_WorkFlowDefine_BLL 的摘要说明。
    /// </summary>
    public class T_WorkFlowDefine_BLL {
        private readonly DigiPower.Onlinecol.Standard.DAL.T_WorkFlowDefine_DAL dal = new DigiPower.Onlinecol.Standard.DAL.T_WorkFlowDefine_DAL();
        public T_WorkFlowDefine_BLL() { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId() {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int WorkFlowDefineID) {
            return dal.Exists(WorkFlowDefineID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_WorkFlowDefine_MDL model) {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(DigiPower.Onlinecol.Standard.Model.T_WorkFlowDefine_MDL model) {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int WorkFlowDefineID) {

            dal.Delete(WorkFlowDefineID);
        }

        /// <summary>
        /// 删除流程相关信息
        /// </summary>
        /// <returns></returns>
        public int DeleteWorkFlowDefine(Hashtable ht) {
            return dal.DeleteWorkFlowDefine(ht);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_WorkFlowDefine_MDL GetModel(int WorkFlowDefineID) {

            return dal.GetModel(WorkFlowDefineID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_WorkFlowDefine_MDL GetModelByCache(int WorkFlowDefineID) {

            string CacheKey = "T_WorkFlowDefine_MDLModel-" + WorkFlowDefineID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null) {
                try {
                    objModel = dal.GetModel(WorkFlowDefineID);
                    if (objModel != null) {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                } catch { }
            }
            return (DigiPower.Onlinecol.Standard.Model.T_WorkFlowDefine_MDL)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere) {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder) {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DigiPower.Onlinecol.Standard.Model.T_WorkFlowDefine_MDL> GetModelList(string strWhere) {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DigiPower.Onlinecol.Standard.Model.T_WorkFlowDefine_MDL> DataTableToList(DataTable dt) {
            List<DigiPower.Onlinecol.Standard.Model.T_WorkFlowDefine_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.T_WorkFlowDefine_MDL>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0) {
                DigiPower.Onlinecol.Standard.Model.T_WorkFlowDefine_MDL model;
                for (int n = 0; n < rowsCount; n++) {
                    model = new DigiPower.Onlinecol.Standard.Model.T_WorkFlowDefine_MDL();
                    if (dt.Rows[n]["WorkFlowDefineID"].ToString() != "") {
                        model.WorkFlowDefineID = int.Parse(dt.Rows[n]["WorkFlowDefineID"].ToString());
                    }
                    if (dt.Rows[n]["SingleProjectID"].ToString() != "") {
                        model.SingleProjectID = int.Parse(dt.Rows[n]["SingleProjectID"].ToString());
                    }
                    if (dt.Rows[n]["WorkFlowID"].ToString() != "") {
                        model.WorkFlowID = int.Parse(dt.Rows[n]["WorkFlowID"].ToString());
                    }
                    model.WorkFlowName = dt.Rows[n]["WorkFlowName"].ToString();
                    model.Description = dt.Rows[n]["Description"].ToString();
                    if (dt.Rows[n]["OrderIndex"].ToString() != "") {
                        model.OrderIndex = int.Parse(dt.Rows[n]["OrderIndex"].ToString());
                    }
                    if (dt.Rows[n]["Del"].ToString() != "") {
                        if ((dt.Rows[n]["Del"].ToString() == "1") || (dt.Rows[n]["Del"].ToString().ToLower() == "true")) {
                            model.Del = true;
                        } else {
                            model.Del = false;
                        }
                    }
                    model.PID = dt.Rows[n]["PID"].ToString();
                    if (dt.Rows[n]["RoleID"].ToString() != "") {
                        model.RoleID = int.Parse(dt.Rows[n]["RoleID"].ToString());
                    }
                    if (dt.Rows[n]["UserID"].ToString() != "") {
                        model.UserID = int.Parse(dt.Rows[n]["UserID"].ToString());
                    }
                    if (dt.Rows[n]["CreateDate"].ToString() != "") {
                        model.CreateDate = DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
                    }
                    if (dt.Rows[n]["DoStatus"].ToString() != "") {
                        model.DoStatus = int.Parse(dt.Rows[n]["DoStatus"].ToString());
                    }
                    if (dt.Rows[n]["IsRollBack"].ToString() != "") {
                        if ((dt.Rows[n]["IsRollBack"].ToString() == "1") || (dt.Rows[n]["IsRollBack"].ToString().ToLower() == "true")) {
                            model.IsRollBack = true;
                        } else {
                            model.IsRollBack = false;
                        }
                    }
                    if (dt.Rows[n]["UseForSuperAdmin"].ToString() != "") {
                        if ((dt.Rows[n]["UseForSuperAdmin"].ToString() == "1") || (dt.Rows[n]["UseForSuperAdmin"].ToString().ToLower() == "true")) {
                            model.UseForSuperAdmin = true;
                        } else {
                            model.UseForSuperAdmin = false;
                        }
                    }
                    if (dt.Rows[n]["UseForArchive"].ToString() != "") {
                        if ((dt.Rows[n]["UseForArchive"].ToString() == "1") || (dt.Rows[n]["UseForArchive"].ToString().ToLower() == "true")) {
                            model.UseForArchive = true;
                        } else {
                            model.UseForArchive = false;
                        }
                    }
                    if (dt.Rows[n]["UseForCompanyLeader"].ToString() != "") {
                        if ((dt.Rows[n]["UseForCompanyLeader"].ToString() == "1") || (dt.Rows[n]["UseForCompanyLeader"].ToString().ToLower() == "true")) {
                            model.UseForCompanyLeader = true;
                        } else {
                            model.UseForCompanyLeader = false;
                        }
                    }
                    if (dt.Rows[n]["UseForCompany"].ToString() != "") {
                        if ((dt.Rows[n]["UseForCompany"].ToString() == "1") || (dt.Rows[n]["UseForCompany"].ToString().ToLower() == "true")) {
                            model.UseForCompany = true;
                        } else {
                            model.UseForCompany = false;
                        }
                    }
                    if (dt.Rows[n]["UseForAll"].ToString() != "") {
                        if ((dt.Rows[n]["UseForAll"].ToString() == "1") || (dt.Rows[n]["UseForAll"].ToString().ToLower() == "true")) {
                            model.UseForAll = true;
                        } else {
                            model.UseForAll = false;
                        }
                    }
                    if (dt.Rows[n]["SubmitStatus"].ToString() != "") {
                        model.SubmitStatus = int.Parse(dt.Rows[n]["SubmitStatus"].ToString());
                    }
                    if (dt.Rows[n]["SubmitUserID"].ToString() != "") {
                        model.SubmitUserID = int.Parse(dt.Rows[n]["SubmitUserID"].ToString());
                    }
                    if (dt.Rows[n]["SubmitDateTime"].ToString() != "") {
                        model.SubmitDateTime = DateTime.Parse(dt.Rows[n]["SubmitDateTime"].ToString());
                    }
                    model.SubmitCellPath = dt.Rows[n]["SubmitCellPath"].ToString();
                    if (dt.Rows[n]["RecvUserID"].ToString() != "") {
                        model.RecvUserID = int.Parse(dt.Rows[n]["RecvUserID"].ToString());
                    }
                    if (dt.Rows[n]["RecvDateTime"].ToString() != "") {
                        model.RecvDateTime = DateTime.Parse(dt.Rows[n]["RecvDateTime"].ToString());
                    }
                    model.RecvCellPath = dt.Rows[n]["RecvCellPath"].ToString();
                    if (dt.Rows[n]["CompanyID"].ToString() != "") {
                        model.CompanyID = int.Parse(dt.Rows[n]["CompanyID"].ToString());
                    }
                    model.DescriptionToArchive = dt.Rows[n]["DescriptionToArchive"].ToString();
                    model.DescriptionToCompany = dt.Rows[n]["DescriptionToCompany"].ToString();
                    if (dt.Rows[n]["RollBackCount"].ToString() != "") {
                        model.RollBackCount = int.Parse(dt.Rows[n]["RollBackCount"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList() {
            return GetList("");
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  成员方法

        /// <summary>
        /// 修改工程流程状态
        /// </summary>
        /// <param name="workflowid">流程ID</param>
        /// <param name="SingleProjectID">工程ID</param>
        /// <returns></returns>
        public DataSet UpdateProjectWorkFlowStatus(Model.T_WorkFlowDefine_MDL wkMDL) {
            return dal.UpdateProjectWorkFlowStatus(wkMDL);
        }

        /// <summary>
        /// 回滚工程流程状态
        /// </summary>
        /// <param name="workflowid"></param>
        /// <param name="SingleProjectID"></param>
        /// <returns></returns>
        public bool RollBackProjectWorkFlowStatus(int SingleProjectID) {
            return dal.RollBackProjectWorkFlowStatus(SingleProjectID);
        }

        /// <summary>
        /// 增加工程流程
        /// </summary>
        /// <param name="SingleProjectID">工程id</param>
        public void AddWorkFlowDefine(int SingleProjectID) {
            dal.AddWorkFlowDefine(SingleProjectID);
        }

        /// <summary>
        /// 增加工程流程
        /// </summary>
        /// <param name="SingleProjectID">工程id</param>
        /// <param name="AreaCode">所属区域</param>
        public void AddWorkFlowDefine(int SingleProjectID, string AreaCode) {
            dal.AddWorkFlowDefine(SingleProjectID, AreaCode);
        }

        /// <summary>
        /// 取流程下的工程
        /// </summary>
        /// <param name="workflowid"></param>
        /// <returns></returns>
        public DataSet GetProjectListByWorkFlow(string workflowid, bool IsCompany, string roleid, string UserID, string sqlWhere) {
            return dal.GetProjectListByWorkFlow(workflowid, IsCompany, roleid, UserID, sqlWhere);
        }

        /// <summary>
        /// 取流程下的工程 分页
        /// </summary>
        /// <returns></returns>
        public DataTable GetListPaging(string workflowid, bool IsCompany, string roleid, string UserID, string sqlWhere,
            int PageSize, int curPage, out int recCoun, bool isChargeUser = false) {
            return dal.GetProjectListByWorkFlow(workflowid, IsCompany, roleid, UserID, sqlWhere, PageSize,
                curPage, "SingleProjectID", "SingleProjectID desc", out recCoun, isChargeUser).Tables[0];
        }

        /// <summary>
        /// 取流程下的工程 分页
        /// </summary>
        /// <returns></returns>
        public DataTable GetLHSignatureListPaging(string workflowid, bool IsCompany, string roleid, string UserID, string sqlWhere,
            int PageSize, int curPage, out int recCoun) {
            return dal.GetLHSignatureListPaging(workflowid, IsCompany, roleid, UserID, sqlWhere, PageSize,
                curPage, "SingleProjectID", "gcbm desc", out recCoun).Tables[0];
        }

        /// <summary>
        /// 取跟流程相关的用户信息
        /// </summary>
        /// <param name="SingleProjectId"></param>
        /// <returns></returns>
        public DataSet GetProjectListByWorkFlowAndUser(string SingleProjectId) {
            return dal.GetProjectListByWorkFlowAndUser(SingleProjectId);
        }

        /// <summary>
        /// 获取当前流程状态下的审核相关信息  2013-10-23 jdk
        /// <returns></returns>
        public DataSet GetWrokFlowCheckInfo(string SingleProjectId, string WorkFlowCode) {
            return dal.GetWrokFlowCheckInfo(SingleProjectId, WorkFlowCode);
        }
    }
}

