using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL
{
    /// <summary>
    /// 数据访问类T_WorkFlow_DAL。
    /// </summary>
    public class T_WorkFlow_DAL
    {
        public T_WorkFlow_DAL() { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId() {
            return DbHelperSQL.GetMaxID("WorkFlowID", "T_WorkFlow");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int WorkFlowID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_WorkFlow");
            strSql.Append(" where WorkFlowID=@WorkFlowID ");
            SqlParameter[] parameters = {
					new SqlParameter("@WorkFlowID", SqlDbType.Int,8)};
            parameters[0].Value = WorkFlowID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string WorkFlowCode, int WorkFlowID, int CompanyID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_WorkFlow");
            strSql.Append(" where lower(WorkFlowCode)=@WorkFlowCode and WorkFlowID !=@WorkFlowID and CompanyID =@CompanyID");
            SqlParameter[] parameters = {
					new SqlParameter("@WorkFlowCode", SqlDbType.VarChar,20),
                    new SqlParameter("@WorkFlowID", SqlDbType.Int,8),
                    new SqlParameter("@CompanyID", SqlDbType.Int,8)};
            parameters[0].Value = WorkFlowCode;
            parameters[1].Value = WorkFlowID;
            parameters[2].Value = CompanyID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_WorkFlow_MDL model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_WorkFlow(");
            strSql.Append("WorkFlowCode,WorkFlowName,OrderIndex,Del,PID,RoleID,UserID,UseForSuperAdmin,UseForArchive,UseForCompanyLeader,UseForCompany,UseForAll,");
            strSql.Append("SubmitURL,DoResultURL,CompanyID,DescriptionToArchive,DescriptionToCompany,RightListID)");
            strSql.Append(" values (");
            strSql.Append("@WorkFlowCode,@WorkFlowName,@OrderIndex,@Del,@PID,@RoleID,@UserID,@UseForSuperAdmin,@UseForArchive,@UseForCompanyLeader,@UseForCompany,");
            strSql.Append("@UseForAll,@SubmitURL,@DoResultURL,@CompanyID,@DescriptionToArchive,@DescriptionToCompany,@RightListID)");

            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@WorkFlowCode", SqlDbType.NVarChar,20),
					new SqlParameter("@WorkFlowName", SqlDbType.NVarChar,20),
					new SqlParameter("@OrderIndex", SqlDbType.Int,8),
					new SqlParameter("@Del", SqlDbType.Bit,1),
					new SqlParameter("@PID", SqlDbType.Int,8),
					new SqlParameter("@RoleID", SqlDbType.Int,8),
					new SqlParameter("@UserID", SqlDbType.Int,8),
					new SqlParameter("@UseForSuperAdmin", SqlDbType.Bit,1),
					new SqlParameter("@UseForArchive", SqlDbType.Bit,1),
					new SqlParameter("@UseForCompanyLeader", SqlDbType.Bit,1),
					new SqlParameter("@UseForCompany", SqlDbType.Bit,1),
					new SqlParameter("@UseForAll", SqlDbType.Bit,1),
					new SqlParameter("@SubmitURL", SqlDbType.NVarChar,250),
					new SqlParameter("@DoResultURL", SqlDbType.NVarChar,250),
                    new SqlParameter("@CompanyID", SqlDbType.Int,8),
                    new SqlParameter("@DescriptionToArchive", SqlDbType.NVarChar,400),
                    new SqlParameter("@DescriptionToCompany", SqlDbType.NVarChar,400),
                    new SqlParameter("@RightListID", SqlDbType.NVarChar,500)};

            parameters[0].Value = model.WorkFlowCode;
            parameters[1].Value = model.WorkFlowName;
            parameters[2].Value = model.OrderIndex;
            parameters[3].Value = model.Del;
            parameters[4].Value = model.PID;
            parameters[5].Value = model.RoleID;
            parameters[6].Value = model.UserID;
            parameters[7].Value = model.UseForSuperAdmin;
            parameters[8].Value = model.UseForArchive;
            parameters[9].Value = model.UseForCompanyLeader;
            parameters[10].Value = model.UseForCompany;
            parameters[11].Value = model.UseForAll;
            parameters[12].Value = model.SubmitURL;
            parameters[13].Value = model.DoResultURL;
            parameters[14].Value = model.CompanyID;
            parameters[15].Value = model.DescriptionToArchive;
            parameters[16].Value = model.DescriptionToCompany;
            parameters[17].Value = model.RightListID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null) {
                return 1;
            }
            else {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(DigiPower.Onlinecol.Standard.Model.T_WorkFlow_MDL model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_WorkFlow set ");
            strSql.Append("WorkFlowCode=@WorkFlowCode,");
            strSql.Append("WorkFlowName=@WorkFlowName,");
            strSql.Append("OrderIndex=@OrderIndex,");
            strSql.Append("Del=@Del,");
            strSql.Append("PID=@PID,");
            strSql.Append("RoleID=@RoleID,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("UseForSuperAdmin=@UseForSuperAdmin,");
            strSql.Append("UseForArchive=@UseForArchive,");
            strSql.Append("UseForCompanyLeader=@UseForCompanyLeader,");
            strSql.Append("UseForCompany=@UseForCompany,");
            strSql.Append("UseForAll=@UseForAll,");
            strSql.Append("SubmitURL=@SubmitURL,");
            strSql.Append("DoResultURL=@DoResultURL,");
            strSql.Append("CompanyID=@CompanyID,");
            strSql.Append("DescriptionToArchive=@DescriptionToArchive,");
            strSql.Append("DescriptionToCompany=@DescriptionToCompany,");
            strSql.Append("RightListID=@RightListID");


            strSql.Append(" where WorkFlowID=@WorkFlowID ");
            SqlParameter[] parameters = {
					new SqlParameter("@WorkFlowID", SqlDbType.Int,8),
					new SqlParameter("@WorkFlowCode", SqlDbType.NVarChar,20),
					new SqlParameter("@WorkFlowName", SqlDbType.NVarChar,20),
					new SqlParameter("@OrderIndex", SqlDbType.Int,8),
					new SqlParameter("@Del", SqlDbType.Bit,1),
					new SqlParameter("@PID", SqlDbType.Int,8),
					new SqlParameter("@RoleID", SqlDbType.Int,8),
					new SqlParameter("@UserID", SqlDbType.Int,8),
					new SqlParameter("@UseForSuperAdmin", SqlDbType.Bit,1),
					new SqlParameter("@UseForArchive", SqlDbType.Bit,1),
					new SqlParameter("@UseForCompanyLeader", SqlDbType.Bit,1),
					new SqlParameter("@UseForCompany", SqlDbType.Bit,1),
					new SqlParameter("@UseForAll", SqlDbType.Bit,1),
					new SqlParameter("@SubmitURL", SqlDbType.NVarChar,250),
					new SqlParameter("@DoResultURL", SqlDbType.NVarChar,250),
                    new SqlParameter("@CompanyID", SqlDbType.Int,8),
                    new SqlParameter("@DescriptionToArchive", SqlDbType.NVarChar,400),
                    new SqlParameter("@DescriptionToCompany", SqlDbType.NVarChar,400),
                    new SqlParameter("@RightListID", SqlDbType.NVarChar,500)};

            parameters[0].Value = model.WorkFlowID;
            parameters[1].Value = model.WorkFlowCode;
            parameters[2].Value = model.WorkFlowName;
            parameters[3].Value = model.OrderIndex;
            parameters[4].Value = model.Del;
            parameters[5].Value = model.PID;
            parameters[6].Value = model.RoleID;
            parameters[7].Value = model.UserID;
            parameters[8].Value = model.UseForSuperAdmin;
            parameters[9].Value = model.UseForArchive;
            parameters[10].Value = model.UseForCompanyLeader;
            parameters[11].Value = model.UseForCompany;
            parameters[12].Value = model.UseForAll;
            parameters[13].Value = model.SubmitURL;
            parameters[14].Value = model.DoResultURL;
            parameters[15].Value = model.CompanyID;
            parameters[16].Value = model.DescriptionToArchive;
            parameters[17].Value = model.DescriptionToCompany;
            parameters[18].Value = model.RightListID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int WorkFlowID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_WorkFlow ");
            strSql.Append(" where WorkFlowID=@WorkFlowID ");
            SqlParameter[] parameters = {
					new SqlParameter("@WorkFlowID", SqlDbType.Int,8)};
            parameters[0].Value = WorkFlowID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_WorkFlow_MDL GetModel(int WorkFlowID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 WorkFlowID,WorkFlowCode,WorkFlowName,OrderIndex,Del,PID,RoleID,UserID,UseForSuperAdmin,UseForArchive,UseForCompanyLeader,");
            strSql.Append("UseForCompany,UseForAll,SubmitURL,DoResultURL,CompanyID,DescriptionToArchive,DescriptionToCompany,RightListID from T_WorkFlow ");
            strSql.Append(" where WorkFlowID=@WorkFlowID ");
            SqlParameter[] parameters = {
					new SqlParameter("@WorkFlowID", SqlDbType.Int,8)};
            parameters[0].Value = WorkFlowID;

            DigiPower.Onlinecol.Standard.Model.T_WorkFlow_MDL model = new DigiPower.Onlinecol.Standard.Model.T_WorkFlow_MDL();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["WorkFlowID"].ToString() != "") {
                    model.WorkFlowID = int.Parse(ds.Tables[0].Rows[0]["WorkFlowID"].ToString());
                }
                model.WorkFlowCode = ds.Tables[0].Rows[0]["WorkFlowCode"].ToString();
                model.WorkFlowName = ds.Tables[0].Rows[0]["WorkFlowName"].ToString();
                if (ds.Tables[0].Rows[0]["OrderIndex"].ToString() != "") {
                    model.OrderIndex = int.Parse(ds.Tables[0].Rows[0]["OrderIndex"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Del"].ToString() != "") {
                    if ((ds.Tables[0].Rows[0]["Del"].ToString() == "1") || (ds.Tables[0].Rows[0]["Del"].ToString().ToLower() == "true")) {
                        model.Del = true;
                    }
                    else {
                        model.Del = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["PID"].ToString() != "") {
                    model.PID = int.Parse(ds.Tables[0].Rows[0]["PID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RoleID"].ToString() != "") {
                    model.RoleID = int.Parse(ds.Tables[0].Rows[0]["RoleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "") {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UseForSuperAdmin"].ToString() != "") {
                    if ((ds.Tables[0].Rows[0]["UseForSuperAdmin"].ToString() == "1") || (ds.Tables[0].Rows[0]["UseForSuperAdmin"].ToString().ToLower() == "true")) {
                        model.UseForSuperAdmin = true;
                    }
                    else {
                        model.UseForSuperAdmin = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["UseForArchive"].ToString() != "") {
                    if ((ds.Tables[0].Rows[0]["UseForArchive"].ToString() == "1") || (ds.Tables[0].Rows[0]["UseForArchive"].ToString().ToLower() == "true")) {
                        model.UseForArchive = true;
                    }
                    else {
                        model.UseForArchive = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["UseForCompanyLeader"].ToString() != "") {
                    if ((ds.Tables[0].Rows[0]["UseForCompanyLeader"].ToString() == "1") || (ds.Tables[0].Rows[0]["UseForCompanyLeader"].ToString().ToLower() == "true")) {
                        model.UseForCompanyLeader = true;
                    }
                    else {
                        model.UseForCompanyLeader = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["UseForCompany"].ToString() != "") {
                    if ((ds.Tables[0].Rows[0]["UseForCompany"].ToString() == "1") || (ds.Tables[0].Rows[0]["UseForCompany"].ToString().ToLower() == "true")) {
                        model.UseForCompany = true;
                    }
                    else {
                        model.UseForCompany = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["UseForAll"].ToString() != "") {
                    if ((ds.Tables[0].Rows[0]["UseForAll"].ToString() == "1") || (ds.Tables[0].Rows[0]["UseForAll"].ToString().ToLower() == "true")) {
                        model.UseForAll = true;
                    }
                    else {
                        model.UseForAll = false;
                    }
                }
                model.SubmitURL = ds.Tables[0].Rows[0]["SubmitURL"].ToString();
                model.DoResultURL = ds.Tables[0].Rows[0]["DoResultURL"].ToString();
                if (ds.Tables[0].Rows[0]["CompanyID"].ToString() != "") {
                    model.CompanyID = int.Parse(ds.Tables[0].Rows[0]["CompanyID"].ToString());
                }

                model.DescriptionToArchive = ds.Tables[0].Rows[0]["DescriptionToArchive"].ToString();
                model.DescriptionToCompany = ds.Tables[0].Rows[0]["DescriptionToCompany"].ToString();
                model.RightListID = ds.Tables[0].Rows[0]["RightListID"].ToString();

                return model;
            }
            else {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select WorkFlowID,WorkFlowCode,WorkFlowName,OrderIndex,Del,PID,RoleID,UserID,UseForSuperAdmin,UseForArchive,UseForCompanyLeader,");
            strSql.Append("UseForCompany,UseForAll,SubmitURL,DoResultURL,CompanyID,DescriptionToArchive,DescriptionToCompany,RightListID ");
            strSql.Append(" FROM T_WorkFlow ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by OrderIndex ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表 分页
        /// </summary>
        /// <returns></returns>
        public DataTable GetList(string strWhere, int PageSize, int curPage, string PRIMARYKey, string OrderByName, out int recCoun) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select A.*,B.CompanyName,C.SystemInfoName,d.Area_Name,");
            strSql.Append("(select top 1 WorkFlowName FROM T_WorkFlow f where f.WorkFlowID=a.PID)as PWorkFlowName ");
            strSql.Append("FROM T_WorkFlow A ");
            strSql.Append("LEFT JOIN T_Company B on A.CompanyID=B.CompanyID ");
            strSql.Append("LEFT JOIN T_SystemInfo C on B.CompanyType=C.SystemInfoID ");
            strSql.Append("LEFT JOIN T_Area D on b.Area_Code=d.area_code ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            return PageCtrl.QueryForDataTableSqlServer(strSql.ToString(), PageSize, curPage, PRIMARYKey, OrderByName, out recCoun).Tables[0];
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0) {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" WorkFlowID,WorkFlowCode,WorkFlowName,OrderIndex,Del,PID,RoleID,UserID,UseForSuperAdmin,UseForArchive,UseForCompanyLeader,UseForCompany,");
            strSql.Append("UseForAll,SubmitURL,DoResultURL,CompanyID,DescriptionToArchive,DescriptionToCompany,RightListID ");

            strSql.Append(" FROM T_WorkFlow ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法

        public DigiPower.Onlinecol.Standard.Model.T_WorkFlow_MDL GetModel(string whereSql) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" * ");
            strSql.Append(" from T_WorkFlow ");
            if (whereSql != "") {
                strSql.Append(" where " + whereSql + " ");
            }

            DigiPower.Onlinecol.Standard.Model.T_WorkFlow_MDL model = new DigiPower.Onlinecol.Standard.Model.T_WorkFlow_MDL();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["WorkFlowID"].ToString() != "") {
                    model.WorkFlowID = int.Parse(ds.Tables[0].Rows[0]["WorkFlowID"].ToString());
                    model = GetModel(model.WorkFlowID);
                }
            }

            return model;
        }

        /// <summary>
        /// 根据角色，用户取流程
        /// </summary>
        /// <param name="roleid"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public DataSet GetWorkFlowList(string RoleID, string UserID, string AreaCode, bool isCompany = false) {//对第一个流程要特别处理。否则无人能分配
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.*,");

            if (!isCompany) {
                strSql.Append("(select count(distinct b.SingleProjectID) from t_workflowdefine b  where b.WorkFlowID=a.workflowid and dostatus=1 ");
                bool IsSuperAdmin = false; //一般管理员
                if (UserID != "") {
                    Model.T_UsersInfo_MDL userMdl = new T_UsersInfo_DAL().GetModel(Convert.ToInt32(UserID));
                    if (userMdl != null) {
                        if (userMdl.IsSuperAdmin)
                            IsSuperAdmin = true;
                    }
                }
                //如果不是管理员,就只能看到自己受理或未受理的
                if (!IsSuperAdmin) {
                    strSql.Append(" and (b.RecvUserID=" + UserID + " OR ISNULL(b.RecvUserID,0)=0 )");
                }
                strSql.Append(" and b.SingleProjectID in (select SingleProjectID from T_SingleProject dd where dd.status!=119 ");

                //if (RoleID != "")//非管理员只能看到分配给自己的工程
                //{
                //    strSql.Append(" and dd.ChargeUserID=" + UserID + " ");
                //}

                //if (!IsALLSuperAdmin) //如果不是超级管理员,就只能看到自己区域的数据
                //{
                //    strSql.Append(" and AREA_CODE like '" + AreaCode + "%') ) as detailcount  ");//加了区域过滤");
                //}
                strSql.Append(" and AREA_CODE like '" + AreaCode + "%') ) as detailcount  ");//加了区域过滤"); //jdk 2014.0506
            }
            else {

                strSql.Append("(select count(distinct b.SingleProjectID) from t_workflowdefine b,T_SingleProjectUser c,T_SingleProject d ");
                strSql.Append("where a.WorkFlowID=b.WorkFlowID and b.DoStatus=1 and b.SingleProjectID=c.SingleProjectID ");
                strSql.Append("and c.SingleProjectID=d.SingleProjectID and d.Status!=119 ");
                strSql.Append("and c.UserID=" + UserID + " and d.Area_Code LIKE '" + AreaCode + "%')as detailcount ");
            }

            strSql.Append(" from t_workflow a ");
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}