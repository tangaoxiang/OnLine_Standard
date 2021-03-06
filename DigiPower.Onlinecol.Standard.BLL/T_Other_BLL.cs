using System;
using System.Data;
using System.Collections.Generic;
using DigiPower.Onlinecol.Standard.Model;
namespace DigiPower.Onlinecol.Standard.BLL
{
    /// <summary>
    /// 业务逻辑类T_ArchiveLend_BLL 的摘要说明。
    /// </summary>
    public class T_Other_BLL
    {
        private readonly DigiPower.Onlinecol.Standard.DAL.T_Other_DAL dal = new DigiPower.Onlinecol.Standard.DAL.T_Other_DAL();
        public T_Other_BLL() { }
        #region  成员方法


        /// <summary>
        /// 返回案卷信息
        /// </summary>
        /// <param name="ReportCode"></param>
        /// <returns></returns>
        public DataSet GetArchiveInfo(string SingleProjectID) {
            return dal.GetArchiveInfo(SingleProjectID);
        }

        /// <summary>
        /// 返回报表的所有查询条件
        /// </summary>
        /// <param name="ReportCode"></param>
        /// <returns></returns>
        public DataSet GetSearchFieldPara(string ReportCode) {
            return dal.GetSearchFieldPara(ReportCode);
        }

        /// <summary>
        /// 返回指定SQL的数据集
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public DataSet GetDataSet(string strSql) {
            return dal.GetDataSet(strSql);
        }

        /// <summary>
        /// 检测SQL语句是否合法
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public bool CheckDefindSql(string strSql) {
            return dal.CheckDefindSql(strSql);
        }
        /// <summary>
        /// 返回数据库中所有表
        /// </summary>
        /// <returns></returns>
        public DataSet GetDataBaseTableList() {
            return dal.GetDataBaseTableList();
        }

        /// <summary>
        /// 返回所有的报表个数
        /// </summary>
        /// <returns></returns>
        public int GetReportListCount() {
            return dal.GetReportListCount();
        }

        /// <summary>
        /// 返回所有报表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public DataSet GetReportList(string strWhere) {
            return dal.GetReportList(strWhere);
        }

        /// <summary>
        /// 返回所有的培训记录
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public DataSet GetTrainRec(string strWhere) {
            return dal.GetTrainRec(strWhere);
        }

        /// <summary>
        /// 判断培训记录中,用户和培训任务是否被重复添加
        /// </summary>
        /// <param name="TrainPlanID">培训任务ID</param>
        /// <param name="UserID">档案员ID</param>
        /// <param name="TrainRecID">档案记录ID</param>
        /// <param name="Action">新增或修改</param>
        /// <returns></returns>
        public bool GetTrainRecExistUserOrPlan(string TrainPlanID, string UserID, string TrainRecID, string Action) {
            return dal.GetTrainRecExistUserOrPlan(TrainPlanID, UserID, TrainRecID, Action);
        }

        /// <summary>
        /// 删除培训计划下所有的档案员
        /// </summary>
        /// <param name="TrainPlanID">培训计划ID</param>
        public void DeleteTrainRecUser(int TrainPlanID) {
            dal.DeleteTrainRecUser(TrainPlanID);
        }

        /// <summary>
        /// 更新培训备注和培训结果
        /// </summary>
        /// <param name="TrainPlanID">培训计划ID</param>
        /// <param name="UserID">档案员ID</param>
        /// <param name="TrainDesc">培训备注</param>
        /// <param name="TrainResult">培训结果</param>
        /// <returns></returns>
        public int SetTrainRecDescAndResult(int TrainPlanID, int UserID, string TrainDesc, string TrainResult) {
            return dal.SetTrainRecDescAndResult(TrainPlanID, UserID, TrainDesc, TrainResult);
        }

        /// <summary>
        /// 返回培训计划下所有档案员
        /// </summary>
        /// <param name="TrainPlanID">培训计划ID</param>
        /// <returns></returns>
        public DataSet GetTrainPlanToArchiveUser(int TrainPlanID) {
            return dal.GetTrainPlanToArchiveUser(TrainPlanID);
        }

        public DataSet GetReadyReturn(string strWhere) {
            return dal.GetReadyReturn(strWhere);
        }
        public void UpdateArchiveStatus(string FileListID, int Status) {
            dal.UpdateArchiveStatus(FileListID, Status);
        }
        public void UpdateArchiveStatus(string FileListID, int Status, string isFolder) {
            dal.UpdateArchiveStatus(FileListID, Status, isFolder);
        }

        public string GetNewProjectID() {
            return dal.GetNewProjectID();
        }

        public string GetNewEngineerID() {
            return dal.GetNewEngineerID();
        }

        public bool GetSingleProjectStart(string SingleProjectID) {
            return dal.GetSingleProjectStart(SingleProjectID);
        }

        public bool GetSingleProjectExistByConstructionID(string ConstructionID) {
            return dal.GetSingleProjectExistByConstructionID(ConstructionID);
        }

        public DataSet GetCompanySignet(int CompanyID, string CompanyTypeName) {
            return dal.GetCompanySignet(CompanyID, CompanyTypeName);
        }

        /// <summary>
        /// 删除案卷
        /// </summary>
        /// <param name="strWhere"></param>
        //public void DeleteFileToArchive(string strWhere)
        //{
        //    dal.DeleteFileToArchive(strWhere);
        //}

        //取工程所有用户列表
        //public DataSet GetUsersBySingleProjectID(int SingleProjectID)
        //{
        //    DataSet dsOut = new DataSet();
        //    BLL.T_SingleProjectUser_BLL spUserBLL = new T_SingleProjectUser_BLL();
        //    DataSet ds1 = new DataSet();
        //    if (SingleProjectID == 0)
        //    {
        //        ds1 = spUserBLL.GetList("");
        //    }
        //    else
        //    {
        //        ds1 = spUserBLL.GetList("SingleProjectID=" + SingleProjectID);
        //    }

        //    if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
        //    {
        //        foreach (DataRow dr1 in ds1.Tables[0].Rows)
        //        {
        //            DataSet ds2 = new DataSet();
        //            if (dr1["UserID"].ToString() == "0")
        //            {
        //                BLL.T_UsersInfo_BLL userBLL = new T_UsersInfo_BLL();
        //                ds2 = userBLL.GetList("RoleID=" + dr1["RoleID"].ToString());
        //            }
        //            else
        //            {
        //                BLL.T_UsersInfo_BLL userBLL = new T_UsersInfo_BLL();
        //                ds2 = userBLL.GetList("UserID=" + dr1["UserID"].ToString());
        //            }

        //            if (dsOut.Tables.Count > 0)
        //            {
        //                for (int i1 = 0; i1 < ds2.Tables[0].Rows.Count; i1++)
        //                {
        //                    dsOut.Tables[0].Rows.Add(ds2.Tables[0].Rows[i1].ItemArray);
        //                }
        //            }
        //            else
        //            {
        //                dsOut.Tables.Add(ds2.Tables[0].Copy());
        //            }
        //        }
        //    }
        //    return dsOut;
        //}

        //public DataSet GetUsersByCompanyID(int SingleProjectID)
        //{
        //    DataSet dsOut = new DataSet();
        //    BLL.T_SingleProjectUser_BLL spUserBLL = new T_SingleProjectUser_BLL();
        //    DataSet ds1 = new DataSet();
        //    if (SingleProjectID == 0)
        //    {
        //        ds1 = spUserBLL.GetList("");
        //    }
        //    else
        //    {
        //        ds1 = spUserBLL.GetList("SingleProjectID=" + SingleProjectID);
        //    }

        //    if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
        //    {
        //        foreach (DataRow dr1 in ds1.Tables[0].Rows)
        //        {
        //            DataSet ds2 = new DataSet();
        //            if (dr1["UserID"].ToString() == "0")
        //            {
        //                BLL.T_UsersInfo_BLL userBLL = new T_UsersInfo_BLL();
        //                ds2 = userBLL.GetList("RoleID=" + dr1["RoleID"].ToString());
        //            }
        //            else
        //            {
        //                BLL.T_UsersInfo_BLL userBLL = new T_UsersInfo_BLL();
        //                ds2 = userBLL.GetList("UserID=" + dr1["UserID"].ToString());
        //            }

        //            if (dsOut.Tables.Count > 0)
        //            {
        //                for (int i1 = 0; i1 < ds2.Tables[0].Rows.Count; i1++)
        //                {
        //                    dsOut.Tables[0].Rows.Add(ds2.Tables[0].Rows[i1].ItemArray);
        //                }
        //            }
        //            else
        //            {
        //                dsOut.Tables.Add(ds2.Tables[0].Copy());
        //            }
        //        }
        //    }
        //    return dsOut;
        //}


        /// <summary>
        /// 判断是否为监理或施工类型
        /// </summary>
        /// <param name="CompanyTypeID">类型ID</param>
        /// <returns></returns>
        //public bool IsCompanyJLOrSG(int CompanyTypeID)
        //{
        //    return dal.IsCompanyJLOrSG(CompanyTypeID);
        //}
        #endregion  成员方法

        public int IntoDB(int SingleProjectID, string DHType) {
            int iOut = 0;

            iOut = dal.IntoDB(SingleProjectID, DHType);

            return iOut;
        }

        public DataSet GetCompany(string SingleProjectID, int CompanyID) {
            return dal.GetCompany(SingleProjectID, CompanyID);
        }

        public DataSet GetCompany(string SingleProjectID, string CompanyType) {
            return dal.GetCompany(SingleProjectID, CompanyType);
        }

        public DataSet GetCompany(int CompanyID) {
            return dal.GetCompany(CompanyID);
        }
        public string GetCompanyNameBySingleProjectID(string SingleProjectID) {
            return dal.GetCompanyNameBySingleProjectID(SingleProjectID);
        }

        /// <summary>
        /// 生成文件编号
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string GetBH(string SingleProjectId, string filelistId) {
            string bh = string.Empty;

            T_FileList_BLL fileBLL = new T_FileList_BLL();
            T_FileList_MDL fileMDL = fileBLL.GetModel(Convert.ToInt32(filelistId));
            if (fileMDL != null) {
                if (fileMDL.IsFolder) {
                    bh = dal.GetBH(fileMDL.BH, SingleProjectId, fileMDL.recID.ToString());
                }
                else {
                    string Maxbh = dal.GetSingle("select MAX(bh) from t_filelist where singleprojectid=" + SingleProjectId + " and bh like '" + fileMDL.BH + "%' ");  //最大编号
                    if (Maxbh == fileMDL.BH) {
                        bh = string.Concat(Maxbh, "-", (1).ToString("D3"));
                    }
                    else {
                        int LastIndex = Common.ConvertEx.ToInt(Maxbh.Substring(Maxbh.LastIndexOf("-") + 1));
                        string MaxIndex = Common.ConvertEx.ToInt(LastIndex + 1).ToString("D3");
                        bh = string.Concat(Maxbh.Substring(0, Maxbh.LastIndexOf("-") + 1), MaxIndex);
                    }
                }
            }
            return bh;
        }

        /// <summary>
        /// 保存权限
        /// </summary>
        /// <param name="ltModelID"></param>
        /// <param name="ltRightID"></param>
        /// <param name="ltEnable"></param>
        /// <param name="RoleID"></param>
        /// <returns></returns>
        public void SetRoleRight(string RightChar, string RoleID, string ModelID, int Enabled, int RoleRightType, string PModelID, string ModelBH) {
            dal.SetRoleRight(RightChar, RoleID, ModelID, Enabled, RoleRightType, PModelID, ModelBH);
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="RoleID"></param>
        /// <param name="RoleRightType"></param>
        public void DelRoleRight(string RoleID, string RoleRightType) {
            dal.DelRoleRight(RoleID, RoleRightType);
        }

        /// <summary>
        ///删除工程和其相关信息
        /// </summary>
        /// <param name="CompanyID"></param>
        /// <returns></returns>
        public bool DeleteCompanyOther(string SingleProjectID, bool delUserFlag = false) {
            return dal.DeleteCompanyOther(SingleProjectID, delUserFlag);
        }

        /// <summary>
        /// 执行全SQL脚本,返回DataTable,无数据返回Null
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public DataTable GetQueryList(string strSql) {
            return dal.GetQueryList(strSql);
        }
    }
}