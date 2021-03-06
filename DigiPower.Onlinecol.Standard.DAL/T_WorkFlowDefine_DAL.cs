using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用
using System.Collections.Generic;
using System.Collections;
namespace DigiPower.Onlinecol.Standard.DAL {
    /// <summary>
    /// 数据访问类T_WorkFlowDefine_DAL。
    /// </summary>
    public class T_WorkFlowDefine_DAL {
        public T_WorkFlowDefine_DAL() { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId() {
            return DbHelperSQL.GetMaxID("WorkFlowDefineID", "T_WorkFlowDefine");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int WorkFlowDefineID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_WorkFlowDefine");
            strSql.Append(" where WorkFlowDefineID=@WorkFlowDefineID ");
            SqlParameter[] parameters = {
					new SqlParameter("@WorkFlowDefineID", SqlDbType.Int,8)};
            parameters[0].Value = WorkFlowDefineID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_WorkFlowDefine_MDL model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_WorkFlowDefine(");
            strSql.Append("SingleProjectID,WorkFlowID,WorkFlowName,Description,OrderIndex,Del,PID,RoleID,UserID,CreateDate,DoStatus,IsRollBack,UseForSuperAdmin,");
            strSql.Append("UseForArchive,UseForCompanyLeader,UseForCompany,UseForAll,SubmitStatus,SubmitUserID,SubmitDateTime,SubmitCellPath,RecvUserID,RecvDateTime,");
            strSql.Append("RecvCellPath,CompanyID,DescriptionToArchive,DescriptionToCompany,RollBackCount)");

            strSql.Append(" values (");
            strSql.Append("@SingleProjectID,@WorkFlowID,@WorkFlowName,@Description,@OrderIndex,@Del,@PID,@RoleID,@UserID,@CreateDate,@DoStatus,@IsRollBack,@UseForSuperAdmin,");
            strSql.Append("@UseForArchive,@UseForCompanyLeader,@UseForCompany,@UseForAll,@SubmitStatus,@SubmitUserID,@SubmitDateTime,@SubmitCellPath,@RecvUserID,");
            strSql.Append("@RecvDateTime,@RecvCellPath,@CompanyID,@DescriptionToArchive,@DescriptionToCompany,@RollBackCount)");

            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@SingleProjectID", SqlDbType.Int,8),
					new SqlParameter("@WorkFlowID", SqlDbType.Int,8),
					new SqlParameter("@WorkFlowName", SqlDbType.NVarChar,50),
					new SqlParameter("@Description", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderIndex", SqlDbType.Int,8),
					new SqlParameter("@Del", SqlDbType.Bit,1),
					new SqlParameter("@PID", SqlDbType.NVarChar,20),
					new SqlParameter("@RoleID", SqlDbType.Int,8),
					new SqlParameter("@UserID", SqlDbType.Int,8),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@DoStatus", SqlDbType.Int,8),
					new SqlParameter("@IsRollBack", SqlDbType.Bit,1),
					new SqlParameter("@UseForSuperAdmin", SqlDbType.Bit,1),
					new SqlParameter("@UseForArchive", SqlDbType.Bit,1),
					new SqlParameter("@UseForCompanyLeader", SqlDbType.Bit,1),
					new SqlParameter("@UseForCompany", SqlDbType.Bit,1),
					new SqlParameter("@UseForAll", SqlDbType.Bit,1),
					new SqlParameter("@SubmitStatus", SqlDbType.Int,8),
					new SqlParameter("@SubmitUserID", SqlDbType.Int,8),
					new SqlParameter("@SubmitDateTime", SqlDbType.DateTime),
					new SqlParameter("@SubmitCellPath", SqlDbType.NVarChar,250),
					new SqlParameter("@RecvUserID", SqlDbType.Int,8),
					new SqlParameter("@RecvDateTime", SqlDbType.DateTime),
					new SqlParameter("@RecvCellPath", SqlDbType.NVarChar,250),
                    new SqlParameter("@CompanyID", SqlDbType.Int,8),
                    new SqlParameter("@DescriptionToArchive", SqlDbType.NVarChar,400),
                    new SqlParameter("@DescriptionToCompany", SqlDbType.NVarChar,400),
                    new SqlParameter("@RollBackCount", SqlDbType.Int,8)};


            parameters[0].Value = model.SingleProjectID;
            parameters[1].Value = model.WorkFlowID;
            parameters[2].Value = model.WorkFlowName;
            parameters[3].Value = model.Description;
            parameters[4].Value = model.OrderIndex;
            parameters[5].Value = model.Del;
            parameters[6].Value = model.PID;
            parameters[7].Value = model.RoleID;
            parameters[8].Value = model.UserID;
            parameters[9].Value = model.CreateDate;
            parameters[10].Value = model.DoStatus;
            parameters[11].Value = model.IsRollBack;
            parameters[12].Value = model.UseForSuperAdmin;
            parameters[13].Value = model.UseForArchive;
            parameters[14].Value = model.UseForCompanyLeader;
            parameters[15].Value = model.UseForCompany;
            parameters[16].Value = model.UseForAll;
            parameters[17].Value = model.SubmitStatus;
            parameters[18].Value = model.SubmitUserID;
            parameters[19].Value = model.SubmitDateTime;
            parameters[20].Value = model.SubmitCellPath;
            parameters[21].Value = model.RecvUserID;
            parameters[22].Value = model.RecvDateTime;
            parameters[23].Value = model.RecvCellPath;
            parameters[24].Value = model.CompanyID;
            parameters[25].Value = model.DescriptionToArchive;
            parameters[26].Value = model.DescriptionToCompany;
            parameters[27].Value = model.RollBackCount;


            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null) {
                return 1;
            } else {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(DigiPower.Onlinecol.Standard.Model.T_WorkFlowDefine_MDL model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_WorkFlowDefine set ");
            strSql.Append("SingleProjectID=@SingleProjectID,");
            strSql.Append("WorkFlowID=@WorkFlowID,");
            strSql.Append("WorkFlowName=@WorkFlowName,");
            strSql.Append("Description=@Description,");
            strSql.Append("OrderIndex=@OrderIndex,");
            strSql.Append("Del=@Del,");
            strSql.Append("PID=@PID,");
            strSql.Append("RoleID=@RoleID,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("DoStatus=@DoStatus,");
            strSql.Append("IsRollBack=@IsRollBack,");
            strSql.Append("UseForSuperAdmin=@UseForSuperAdmin,");
            strSql.Append("UseForArchive=@UseForArchive,");
            strSql.Append("UseForCompanyLeader=@UseForCompanyLeader,");
            strSql.Append("UseForCompany=@UseForCompany,");
            strSql.Append("UseForAll=@UseForAll,");
            strSql.Append("SubmitStatus=@SubmitStatus,");
            strSql.Append("SubmitUserID=@SubmitUserID,");
            strSql.Append("SubmitDateTime=@SubmitDateTime,");
            strSql.Append("SubmitCellPath=@SubmitCellPath,");
            strSql.Append("RecvUserID=@RecvUserID,");
            strSql.Append("RecvDateTime=@RecvDateTime,");
            strSql.Append("RecvCellPath=@RecvCellPath,");
            strSql.Append("CompanyID=@CompanyID,");
            strSql.Append("DescriptionToArchive=@DescriptionToArchive,");
            strSql.Append("DescriptionToCompany=@DescriptionToCompany,");
            strSql.Append("RollBackCount=@RollBackCount");

            strSql.Append(" where WorkFlowDefineID=@WorkFlowDefineID ");
            SqlParameter[] parameters = {
					new SqlParameter("@WorkFlowDefineID", SqlDbType.Int,8),
					new SqlParameter("@SingleProjectID", SqlDbType.Int,8),
					new SqlParameter("@WorkFlowID", SqlDbType.Int,8),
					new SqlParameter("@WorkFlowName", SqlDbType.NVarChar,50),
					new SqlParameter("@Description", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderIndex", SqlDbType.Int,8),
					new SqlParameter("@Del", SqlDbType.Bit,1),
					new SqlParameter("@PID", SqlDbType.NVarChar,20),
					new SqlParameter("@RoleID", SqlDbType.Int,8),
					new SqlParameter("@UserID", SqlDbType.Int,8),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@DoStatus", SqlDbType.Int,8),
					new SqlParameter("@IsRollBack", SqlDbType.Bit,1),
					new SqlParameter("@UseForSuperAdmin", SqlDbType.Bit,1),
					new SqlParameter("@UseForArchive", SqlDbType.Bit,1),
					new SqlParameter("@UseForCompanyLeader", SqlDbType.Bit,1),
					new SqlParameter("@UseForCompany", SqlDbType.Bit,1),
					new SqlParameter("@UseForAll", SqlDbType.Bit,1),
					new SqlParameter("@SubmitStatus", SqlDbType.Int,8),
					new SqlParameter("@SubmitUserID", SqlDbType.Int,8),  
					new SqlParameter("@SubmitDateTime", SqlDbType.DateTime),
					new SqlParameter("@SubmitCellPath", SqlDbType.NVarChar,250),
					new SqlParameter("@RecvUserID", SqlDbType.Int,8),
					new SqlParameter("@RecvDateTime", SqlDbType.DateTime),
					new SqlParameter("@RecvCellPath", SqlDbType.NVarChar,250),
                    new SqlParameter("@CompanyID", SqlDbType.Int,8),
                    new SqlParameter("@DescriptionToArchive", SqlDbType.NVarChar,400),
                    new SqlParameter("@DescriptionToCompany", SqlDbType.NVarChar,400),
                    new SqlParameter("@RollBackCount", SqlDbType.Int,8)};



            parameters[0].Value = model.WorkFlowDefineID;
            parameters[1].Value = model.SingleProjectID;
            parameters[2].Value = model.WorkFlowID;
            parameters[3].Value = model.WorkFlowName;
            parameters[4].Value = model.Description;
            parameters[5].Value = model.OrderIndex;
            parameters[6].Value = model.Del;
            parameters[7].Value = model.PID;
            parameters[8].Value = model.RoleID;
            parameters[9].Value = model.UserID;
            parameters[10].Value = model.CreateDate;
            parameters[11].Value = model.DoStatus;
            parameters[12].Value = model.IsRollBack;
            parameters[13].Value = model.UseForSuperAdmin;
            parameters[14].Value = model.UseForArchive;
            parameters[15].Value = model.UseForCompanyLeader;
            parameters[16].Value = model.UseForCompany;
            parameters[17].Value = model.UseForAll;
            parameters[18].Value = model.SubmitStatus;
            parameters[19].Value = model.SubmitUserID;
            parameters[20].Value = model.SubmitDateTime;
            parameters[21].Value = model.SubmitCellPath;
            parameters[22].Value = model.RecvUserID;
            parameters[23].Value = model.RecvDateTime;
            parameters[24].Value = model.RecvCellPath;
            parameters[25].Value = model.CompanyID;
            parameters[26].Value = model.DescriptionToArchive;
            parameters[27].Value = model.DescriptionToCompany;
            parameters[28].Value = model.RollBackCount;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int WorkFlowDefineID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_WorkFlowDefine ");
            strSql.Append(" where WorkFlowDefineID=@WorkFlowDefineID ");
            SqlParameter[] parameters = {
					new SqlParameter("@WorkFlowDefineID", SqlDbType.Int,8)};
            parameters[0].Value = WorkFlowDefineID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除流程相关信息
        /// </summary>
        /// <returns></returns>
        public int DeleteWorkFlowDefine(Hashtable ht) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_WorkFlowDefine where 1=1 ");
            if (ht.ContainsKey("SingleProjectID") && Common.ConvertEx.ToString(ht["SingleProjectID"]).Length > 0) {
                strSql.Append(" and SingleProjectID=" + Common.ConvertEx.ToString(ht["SingleProjectID"]) + "");
            }
            if (ht.ContainsKey("WorkFlowID") && Common.ConvertEx.ToString(ht["WorkFlowID"]).Length > 0) {
                strSql.Append(" and WorkFlowID=" + Common.ConvertEx.ToString(ht["WorkFlowID"]) + "");
            }

            return DigiPower.Onlinecol.Standard.Common.ConvertEx.ToInt(DbHelperSQL.ExecuteSql(strSql.ToString()));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_WorkFlowDefine_MDL GetModel(int WorkFlowDefineID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 WorkFlowDefineID,SingleProjectID,WorkFlowID,WorkFlowName,Description,OrderIndex,Del,PID,RoleID,UserID,CreateDate,");
            strSql.Append("DoStatus,IsRollBack,UseForSuperAdmin,UseForArchive,UseForCompanyLeader,UseForCompany,UseForAll,SubmitStatus,SubmitUserID,");
            strSql.Append("SubmitDateTime,SubmitCellPath,RecvUserID,RecvDateTime,RecvCellPath,CompanyID,DescriptionToArchive,DescriptionToCompany,RollBackCount ");
            strSql.Append("from T_WorkFlowDefine ");

            strSql.Append(" where WorkFlowDefineID=@WorkFlowDefineID ");
            SqlParameter[] parameters = {
					new SqlParameter("@WorkFlowDefineID", SqlDbType.Int,8)};
            parameters[0].Value = WorkFlowDefineID;

            DigiPower.Onlinecol.Standard.Model.T_WorkFlowDefine_MDL model = new DigiPower.Onlinecol.Standard.Model.T_WorkFlowDefine_MDL();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["WorkFlowDefineID"].ToString() != "") {
                    model.WorkFlowDefineID = int.Parse(ds.Tables[0].Rows[0]["WorkFlowDefineID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SingleProjectID"].ToString() != "") {
                    model.SingleProjectID = int.Parse(ds.Tables[0].Rows[0]["SingleProjectID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WorkFlowID"].ToString() != "") {
                    model.WorkFlowID = int.Parse(ds.Tables[0].Rows[0]["WorkFlowID"].ToString());
                }
                model.WorkFlowName = ds.Tables[0].Rows[0]["WorkFlowName"].ToString();
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                if (ds.Tables[0].Rows[0]["OrderIndex"].ToString() != "") {
                    model.OrderIndex = int.Parse(ds.Tables[0].Rows[0]["OrderIndex"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Del"].ToString() != "") {
                    if ((ds.Tables[0].Rows[0]["Del"].ToString() == "1") || (ds.Tables[0].Rows[0]["Del"].ToString().ToLower() == "true")) {
                        model.Del = true;
                    } else {
                        model.Del = false;
                    }
                }
                model.PID = ds.Tables[0].Rows[0]["PID"].ToString();
                if (ds.Tables[0].Rows[0]["RoleID"].ToString() != "") {
                    model.RoleID = int.Parse(ds.Tables[0].Rows[0]["RoleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "") {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateDate"].ToString() != "") {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DoStatus"].ToString() != "") {
                    model.DoStatus = int.Parse(ds.Tables[0].Rows[0]["DoStatus"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsRollBack"].ToString() != "") {
                    if ((ds.Tables[0].Rows[0]["IsRollBack"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsRollBack"].ToString().ToLower() == "true")) {
                        model.IsRollBack = true;
                    } else {
                        model.IsRollBack = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["UseForSuperAdmin"].ToString() != "") {
                    if ((ds.Tables[0].Rows[0]["UseForSuperAdmin"].ToString() == "1") || (ds.Tables[0].Rows[0]["UseForSuperAdmin"].ToString().ToLower() == "true")) {
                        model.UseForSuperAdmin = true;
                    } else {
                        model.UseForSuperAdmin = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["UseForArchive"].ToString() != "") {
                    if ((ds.Tables[0].Rows[0]["UseForArchive"].ToString() == "1") || (ds.Tables[0].Rows[0]["UseForArchive"].ToString().ToLower() == "true")) {
                        model.UseForArchive = true;
                    } else {
                        model.UseForArchive = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["UseForCompanyLeader"].ToString() != "") {
                    if ((ds.Tables[0].Rows[0]["UseForCompanyLeader"].ToString() == "1") || (ds.Tables[0].Rows[0]["UseForCompanyLeader"].ToString().ToLower() == "true")) {
                        model.UseForCompanyLeader = true;
                    } else {
                        model.UseForCompanyLeader = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["UseForCompany"].ToString() != "") {
                    if ((ds.Tables[0].Rows[0]["UseForCompany"].ToString() == "1") || (ds.Tables[0].Rows[0]["UseForCompany"].ToString().ToLower() == "true")) {
                        model.UseForCompany = true;
                    } else {
                        model.UseForCompany = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["UseForAll"].ToString() != "") {
                    if ((ds.Tables[0].Rows[0]["UseForAll"].ToString() == "1") || (ds.Tables[0].Rows[0]["UseForAll"].ToString().ToLower() == "true")) {
                        model.UseForAll = true;
                    } else {
                        model.UseForAll = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["SubmitStatus"].ToString() != "") {
                    model.SubmitStatus = int.Parse(ds.Tables[0].Rows[0]["SubmitStatus"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SubmitUserID"].ToString() != "") {
                    model.SubmitUserID = int.Parse(ds.Tables[0].Rows[0]["SubmitUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SubmitDateTime"].ToString() != "") {
                    model.SubmitDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["SubmitDateTime"].ToString());
                }
                model.SubmitCellPath = ds.Tables[0].Rows[0]["SubmitCellPath"].ToString();
                if (ds.Tables[0].Rows[0]["RecvUserID"].ToString() != "") {
                    model.RecvUserID = int.Parse(ds.Tables[0].Rows[0]["RecvUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RecvDateTime"].ToString() != "") {
                    model.RecvDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["RecvDateTime"].ToString());
                }
                model.RecvCellPath = ds.Tables[0].Rows[0]["RecvCellPath"].ToString();
                if (ds.Tables[0].Rows[0]["CompanyID"].ToString() != "") {
                    model.CompanyID = int.Parse(ds.Tables[0].Rows[0]["CompanyID"].ToString());
                }
                model.DescriptionToArchive = ds.Tables[0].Rows[0]["DescriptionToArchive"].ToString();
                model.DescriptionToCompany = ds.Tables[0].Rows[0]["DescriptionToCompany"].ToString();
                if (ds.Tables[0].Rows[0]["RollBackCount"].ToString() != "") {
                    model.RollBackCount = int.Parse(ds.Tables[0].Rows[0]["RollBackCount"].ToString());
                }
                return model;
            } else {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select WorkFlowDefineID,SingleProjectID,WorkFlowID,WorkFlowName,Description,OrderIndex,Del,PID,RoleID,UserID,CreateDate,DoStatus,");
            strSql.Append("IsRollBack,UseForSuperAdmin,UseForArchive,UseForCompanyLeader,UseForCompany,UseForAll,SubmitStatus,SubmitUserID,");
            strSql.Append("SubmitDateTime,SubmitCellPath,RecvUserID,RecvDateTime,RecvCellPath,CompanyID,DescriptionToArchive,DescriptionToCompany,RollBackCount ");
            strSql.Append(" FROM T_WorkFlowDefine ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
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
            strSql.Append(" WorkFlowDefineID,SingleProjectID,WorkFlowID,WorkFlowName,Description,OrderIndex,Del,PID,RoleID,UserID,CreateDate,DoStatus,IsRollBack,");
            strSql.Append("UseForSuperAdmin,UseForArchive,UseForCompanyLeader,UseForCompany,UseForAll,SubmitStatus,SubmitUserID,SubmitDateTime,");
            strSql.Append("SubmitCellPath,RecvUserID,RecvDateTime,RecvCellPath,CompanyID,DescriptionToArchive,DescriptionToCompany,RollBackCount ");

            strSql.Append(" FROM T_WorkFlowDefine ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法

        /// <summary>
        /// 修改工程流程状态
        /// </summary>
        /// <param name="WorkFlowID">流程id</param>
        /// <param name="SingleProjectID">工程id</param>
        /// <returns></returns>
        public DataSet UpdateProjectWorkFlowStatus(Model.T_WorkFlowDefine_MDL wkMDL) {
            string strsql1 = "update T_WorkFlowDefine set ";
            strsql1 += "dostatus=0,";
            strsql1 += "IsRollBack='" + wkMDL.IsRollBack + "',";
            strsql1 += "SubmitStatus='" + wkMDL.SubmitStatus + "',";
            strsql1 += "SubmitUserID=" + wkMDL.SubmitUserID + ",";
            strsql1 += "SubmitDateTime='" + wkMDL.SubmitDateTime + "' ";
            strsql1 += "where SingleProjectID=" + wkMDL.SingleProjectID + " and WorkFlowID=" + wkMDL.WorkFlowID;
            //string strsql1 = "update T_WorkFlowDefine set dostatus=0 where SingleProjectID=" + wkMDL.SingleProjectID + " and WorkFlowID=" + wkMDL.WorkFlowID;
            string strsql2 = "update T_WorkFlowDefine set dostatus=1 where SingleProjectID=" + wkMDL.SingleProjectID + " and PID=" + wkMDL.WorkFlowID;

            //jdk 11.18 更新工程表中的 流程ID
            string strsql3 = "update T_SingleProject set WorkFlow_DoStatus=(select top 1 WorkFlowID from T_WorkFlowDefine where SingleProjectID=" + wkMDL.SingleProjectID + " and PID=" + wkMDL.WorkFlowID + ") ";
            strsql3 += " where SingleProjectID=" + wkMDL.SingleProjectID;

            List<string> sqllist = new List<string>();
            sqllist.Add(strsql1);
            sqllist.Add(strsql2);
            sqllist.Add(strsql3);
            try {
                //DbHelperSQL.ExecuteSql(strsql1);
                //DbHelperSQL.ExecuteSql(strsql2);

                DbHelperSQL.ExecuteSqlTran(sqllist);
                string strwhere = " SingleProjectID=" + wkMDL.SingleProjectID + " and pid=" + wkMDL.WorkFlowID;
                return GetList(strwhere);
            } catch {
                return null;
            }
        }

        /// <summary>
        /// 回滚工程流程状态
        /// </summary>
        /// <param name="WorkFlowID"></param>
        /// <param name="SingleProjectID"></param>
        /// <returns></returns>
        public bool RollBackProjectWorkFlowStatus(int SingleProjectID) {
            string strSql = "Select TOP 1 WorkFlowID,PID From T_WorkFlowDefine where SingleProjectID=" + SingleProjectID + " AND DoStatus=1";
            DataSet ds1 = DbHelperSQL.Query(strSql);
            if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0) {
                int WorkFlowID = Common.ConvertEx.ToInt(ds1.Tables[0].Rows[0]["WorkFlowID"]);
                int PID = Common.ConvertEx.ToInt(ds1.Tables[0].Rows[0]["PID"]);
                if (WorkFlowID <= 0) {
                    return false;
                }
                int PrevWorkFlowID = GetPreWorkFlowID(SingleProjectID, PID);
                if (PrevWorkFlowID <= 0) {
                    return false;
                }
                string strsql1 = "update T_WorkFlowDefine set RecvUserID=0,SubmitStatus=0,dostatus=0 where SingleProjectID=" + SingleProjectID + " and WorkFlowID=" + WorkFlowID;
                string strsql2 = "update T_WorkFlowDefine set RecvUserID=0,SubmitStatus=0,dostatus=1,IsRollBack=1,RollBackCount=ISNULL(RollBackCount,0)+1 where SingleProjectID=" + SingleProjectID + " and  WorkFlowID = " + PrevWorkFlowID;

                //jdk 11.18 更新工程表中的 流程ID
                string strsql3 = "update T_SingleProject set WorkFlow_DoStatus=" + PrevWorkFlowID + " where SingleProjectID=" + SingleProjectID + "";

                List<string> sqllist = new List<string>();
                sqllist.Add(strsql1);
                sqllist.Add(strsql2);
                sqllist.Add(strsql3);
                try {
                    DbHelperSQL.ExecuteSqlTran(sqllist);
                    return true;
                    //string strwhere = "SingleProjectID=" + SingleProjectID + " and  WorkFlowID = (select pid from T_WorkFlowDefine where SingleProjectID=" + SingleProjectID + " and WorkFlowID=" + WorkFlowID + ")";
                    //return GetList(strwhere);
                } catch {
                    return false;
                }
            }
            return false;
        }

        private int GetPreWorkFlowID(int SingleProjectID, int PID) {
            int PrevWorkFlowID = 0;
            string strSql = "Select TOP 1 WorkFlowID,PID,DEL From T_WorkFlowDefine where SingleProjectID=" + SingleProjectID + " AND WorkFlowID=" + PID;
            DataSet ds1 = DbHelperSQL.Query(strSql);
            if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0) {
                PrevWorkFlowID = Common.ConvertEx.ToInt(ds1.Tables[0].Rows[0]["WorkFlowID"]);
                int PrevPID = Common.ConvertEx.ToInt(ds1.Tables[0].Rows[0]["PID"]);
                bool DEL = Common.ConvertEx.ToBool(ds1.Tables[0].Rows[0]["DEL"].ToString());
                if (DEL == true) {
                    return GetPreWorkFlowID(SingleProjectID, PrevPID);
                }
                return PrevWorkFlowID;
            }
            return PrevWorkFlowID;
        }

        /// <summary>
        /// 增加工程流程
        /// </summary>
        /// <param name="SingleProjectID">工程id</param>
        public void AddWorkFlowDefine(int SingleProjectID) {
            string strsql = "insert into T_WorkFlowDefine(WorkFlowID,workflowname,OrderIndex,del,pid,roleid,userid,";
            strsql += "createdate,dostatus,SingleProjectID,UseForSuperAdmin,UseForArchive,UseForCompanyLeader,";
            strsql += "UseForCompany,UseForAll,SubmitStatus,SubmitCellPath,RecvCellPath) select WorkFlowID,workflowname,";
            strsql += "OrderIndex,del,pid,roleid,userid,getdate() as createdate,0 as dostatus," + SingleProjectID + " as SingleProjectID,";
            strsql += "UseForSuperAdmin,UseForArchive,UseForCompanyLeader,UseForCompany,UseForAll,0,SubmitURL,DoResultURL from t_workflow WHERE DEL=0";
            strsql += ";update T_WorkFlowDefine set dostatus=1 where pid=0 and SingleProjectID=" + SingleProjectID;
            DbHelperSQL.ExecuteSql(strsql);
        }

        /// <summary>
        /// 增加工程流程
        /// </summary>
        /// <param name="SingleProjectID"></param>
        /// <param name="AreaCode"></param>
        public void AddWorkFlowDefine(int SingleProjectID, string AreaCode) {
            string CompanyID = DbHelperSQL.GetSingle("SELECT CompanyID from T_Company where LOWER(Area_Code)='" + AreaCode.ToLower() + "'").ToString();

            if (!string.IsNullOrWhiteSpace(CompanyID)) {
                string strsql = "insert into T_WorkFlowDefine(WorkFlowID,workflowname,OrderIndex,del,pid,roleid,userid,createdate,dostatus,";
                strsql += "SingleProjectID,UseForSuperAdmin,UseForArchive,UseForCompanyLeader,UseForCompany,UseForAll,SubmitStatus,";
                strsql += "SubmitCellPath,RecvCellPath) select WorkFlowID,workflowname,OrderIndex,del,pid,roleid,userid,getdate() as createdate,";
                strsql += "0 as dostatus," + SingleProjectID + " as SingleProjectID,UseForSuperAdmin,UseForArchive,UseForCompanyLeader,";
                strsql += "UseForCompany,UseForAll,0,SubmitURL,DoResultURL from t_workflow WHERE DEL=0 and CompanyID =" + CompanyID;
                strsql += ";update T_WorkFlowDefine set dostatus=1 where pid=0 and SingleProjectID=" + SingleProjectID;
                DbHelperSQL.ExecuteSql(strsql);
            }
        }

        /// <summary>
        /// 取流程下的工程
        /// </summary>
        /// <param name="WorkFlowID"></param>
        /// <returns></returns>
        public DataSet GetProjectListByWorkFlow(string WorkFlowID, bool IsCompany, string roleid, string UserID, string sqlWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT a.*,b.SystemInfoName as ProjectTypeName,SubmitStatus,c.WorkFlowDefineID,c.RecvDateTime FROM T_SingleProject a,T_SystemInfo b,T_WorkFlowDefine c WHERE b.CurrentType='Archive_Form' and SystemInfoCode=a.projecttype AND a.SingleProjectID=c.SingleProjectID AND WorkFlowID=" + WorkFlowID + " and dostatus=1 and a.Status!=119 ");
            if (sqlWhere != "") {
                strSql.Append(sqlWhere);
            }

            if (IsCompany == true) {
                if (roleid != "")
                    strSql.Append(" and a.SingleProjectID in (select SingleProjectID from t_singleprojectuser where roleid=" + roleid + ")");
                if (UserID != "")
                    strSql.Append(" and a.SingleProjectID in (select SingleProjectID from t_singleprojectuser where UserID=" + UserID + " OR UserID=0)");
            } else {
                if (UserID != "") {//档案馆，自已的+未受理的
                    //strSql.Append(" AND (RecvUserID=" + UserID + " OR IsNULL(RecvUserID,0)=0)");

                    //jdk 9.29
                    //分配给我的+我受理的
                    //strSql.Append(" AND (RecvUserID=" + UserID + " OR ChargeUserID=" + UserID + ")");

                    strSql.Append(" AND (RecvUserID=" + UserID + " OR IsNULL(RecvUserID,0)=0 OR ChargeUserID=" + UserID + ")");
                }
            }
            strSql.Append(" order by a.SingleProjectID DESC");

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 取流程下的工程
        /// </summary>
        /// <param name="WorkFlowID"></param>
        /// <returns></returns>
        public DataSet GetProjectListByWorkFlow(string WorkFlowID, bool IsCompany, string roleid, string UserID,
            string sqlWhere, int PageSize, int curPage, string PRIMARYKey, string OrderByName, out int recCoun, bool isChargeUser = false) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT a.*,b.SystemInfoName as ProjectTypeName,SubmitStatus,c.WorkFlowDefineID,c.RecvDateTime FROM T_SingleProject a,");
            strSql.Append("T_SystemInfo b,T_WorkFlowDefine c WHERE b.CurrentType='Archive_Form' and SystemInfoCode=a.projecttype ");
            strSql.Append("AND a.SingleProjectID=c.SingleProjectID AND WorkFlowID=" + WorkFlowID + " and dostatus=1 and a.Status!=119 ");

            if (sqlWhere != "") {
                strSql.Append(sqlWhere);
            }

            if (IsCompany == true) {
                if (roleid != "")
                    strSql.Append(" and a.SingleProjectID in (select distinct SingleProjectID from t_singleprojectuser where roleid=" + roleid + ")");
                if (UserID != "")
                    strSql.Append(" and a.SingleProjectID in (select distinct SingleProjectID from t_singleprojectuser where UserID=" + UserID + ")");
            } else {
                if (UserID != "") {//档案馆，自已的+未受理的
                    //strSql.Append(" AND (RecvUserID=" + UserID + " OR IsNULL(RecvUserID,0)=0)");

                    //jdk 9.29
                    //分配给我的+我受理的
                    //strSql.Append(" AND (RecvUserID=" + UserID + " OR ChargeUserID=" + UserID + ")");
                    if (isChargeUser)
                        strSql.Append(" AND ChargeUserID=" + UserID + " ");
                    else
                        strSql.Append(" AND (RecvUserID=" + UserID + " OR IsNULL(RecvUserID,0)=0 )");
                }
            }
            //strSql.Append(" order by a.SingleProjectID DESC");

            return PageCtrl.QueryForDataTableSqlServer(strSql.ToString(), PageSize, curPage, PRIMARYKey, OrderByName, out recCoun);
        }

        /// <summary>
        /// 取流程下的工程
        /// </summary>
        /// <param name="WorkFlowID"></param>
        /// <returns></returns>
        public DataSet GetLHSignatureListPaging(string WorkFlowID, bool IsCompany, string roleid, string UserID,
            string sqlWhere, int PageSize, int curPage, string PRIMARYKey, string OrderByName, out int recCoun) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT a.*,b.SystemInfoName as ProjectTypeName,SubmitStatus,c.WorkFlowDefineID,c.RecvDateTime,");  
            strSql.Append("(SELECT f.AttachPath from T_FileAttach f WHERE LOWER(f.Flag)='company_registration' and f.PriKeyValue=a.SingleProjectID and LOWER(f.AttachCode)='ghxkz')as ghxkz_AttachPath,");
            strSql.Append("(SELECT f.AttachPath from T_FileAttach f WHERE LOWER(f.Flag)='company_registration' and f.PriKeyValue=a.SingleProjectID and LOWER(f.AttachCode)='sgxkz')as sgxkz_AttachPath ");
            strSql.Append("FROM T_SingleProject a,T_SystemInfo b,T_WorkFlowDefine c ");
            strSql.Append("WHERE b.CurrentType='Archive_Form' and SystemInfoCode=a.projecttype and a.SingleProjectID=c.SingleProjectID ");
            strSql.Append("AND WorkFlowID=" + WorkFlowID + " and dostatus=1 and a.Status!=119 ");
            if (sqlWhere != "") {
                strSql.Append(sqlWhere);
            }

            if (IsCompany == true) {
                if (roleid != "")
                    strSql.Append(" and a.SingleProjectID in (select SingleProjectID from t_singleprojectuser where roleid=" + roleid + ")");
                if (UserID != "")
                    strSql.Append(" and a.SingleProjectID in (select SingleProjectID from t_singleprojectuser where UserID=" + UserID + ")");
            } else {
                if (UserID != "") {//档案馆，自已的+未受理的
                    //strSql.Append(" AND (RecvUserID=" + UserID + " OR IsNULL(RecvUserID,0)=0)");

                    //jdk 9.29
                    //分配给我的+我受理的
                    //strSql.Append(" AND (RecvUserID=" + UserID + " OR ChargeUserID=" + UserID + ")");

                    strSql.Append(" AND (RecvUserID=" + UserID + " OR IsNULL(RecvUserID,0)=0 OR ChargeUserID=" + UserID + ")");
                }
            }
            //strSql.Append(" order by a.SingleProjectID DESC");

            return PageCtrl.QueryForDataTableSqlServer(strSql.ToString(), PageSize, curPage, PRIMARYKey, OrderByName, out recCoun);
        }

        /// <summary>
        /// 取跟流程相关的用户信息
        /// </summary>
        /// <param name="SingleProjectId"></param>
        /// <returns></returns>
        public DataSet GetProjectListByWorkFlowAndUser(string SingleProjectId) {
            DataSet ds = new DataSet();
            if (SingleProjectId.Trim().Length > 0) {
                string strSql = "select a.*,b.UserName as RecvUserName,c.UserName as SubmitUserName from ";
                strSql += "T_WorkFlowDefine a left join T_UsersInfo b on a.RecvUserID=b.UserID  ";
                strSql += "left join T_UsersInfo c on c.UserID=a.SubmitUserID  ";
                strSql += "where a.SingleprojectId=" + SingleProjectId + "  order by a.WorkFlowID asc";
                ds = DbHelperSQL.Query(strSql);
            }
            return ds;
        }

        /// <summary>
        /// 获取当前流程状态下的审核相关信息  2013-10-23 jdk
        /// <returns></returns>
        public DataSet GetWrokFlowCheckInfo(string SingleProjectId, string WorkFlowCode) {
            StringBuilder strSql = new StringBuilder();


            strSql.Append(" select WorkFlowDefineID,SingleProjectID,WorkFlowID,WorkFlowName,Description,OrderIndex, ");
            strSql.Append("Del,PID,RoleID,UserID,CreateDate,DoStatus,IsRollBack,UseForSuperAdmin,UseForArchive,UseForCompanyLeader,  ");
            strSql.Append("UseForCompany,UseForAll,SubmitStatus,SubmitUserID,SubmitDateTime,SubmitCellPath,RecvUserID,RecvDateTime,RecvCellPath, ");
            strSql.Append("(select t.UserName from T_UsersInfo t,T_WorkFlowDefine t1 where t.UserID=t1.SubmitUserID and t1.WorkFlowID=b.PID and t1.SingleProjectID=" + SingleProjectId + ") as P_SubmitUserName ,   ");
            strSql.Append("(select t1.SubmitDateTime from  T_WorkFlowDefine t1 where t1.WorkFlowID=b.PID and t1.SingleProjectID=" + SingleProjectId + ") as P_SubmitDateTime ,  ");
            strSql.Append("(select t.UserName from T_UsersInfo t where t.UserID=b.RecvUserID) as RecvUserName  ");

            strSql.Append("FROM T_WorkFlowDefine b where b.SingleProjectID=" + SingleProjectId + " and   ");
            strSql.Append("WorkFlowID=(select WorkFlowID from T_WorkFlow where LOWER( WorkFlowCode)='" + WorkFlowCode.ToLower() + "')");


            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}

