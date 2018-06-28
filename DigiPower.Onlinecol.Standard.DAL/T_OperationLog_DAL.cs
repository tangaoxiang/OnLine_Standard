using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL {
    /// <summary>
    /// 数据访问类T_OperationLog_DAL。
    /// </summary>
    public class T_OperationLog_DAL {
        public T_OperationLog_DAL() { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId() {
            return DbHelperSQL.GetMaxID("LogID", "T_OperationLog");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int LogID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_OperationLog");
            strSql.Append(" where LogID=@LogID ");
            SqlParameter[] parameters = {
					new SqlParameter("@LogID", SqlDbType.Int,8)};
            parameters[0].Value = LogID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_OperationLog_MDL model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_OperationLog(");
            strSql.Append("ClassName,MethodName,SqlString,ErrorMsg,Description,UserID,UserName,CreateIP,CreateDate)");
            strSql.Append(" values (");
            strSql.Append("@ClassName,@MethodName,@SqlString,@ErrorMsg,@Description,@UserID,@UserName,@CreateIP,@CreateDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ClassName", SqlDbType.NVarChar,50),
					new SqlParameter("@MethodName", SqlDbType.NVarChar,50),
					new SqlParameter("@SqlString", SqlDbType.NVarChar,3000),
					new SqlParameter("@ErrorMsg", SqlDbType.NVarChar,3000),
					new SqlParameter("@Description", SqlDbType.NVarChar,500),
					new SqlParameter("@UserID", SqlDbType.Int,8),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateIP", SqlDbType.NVarChar,20),
					new SqlParameter("@CreateDate", SqlDbType.DateTime)};
            parameters[0].Value = model.ClassName;
            parameters[1].Value = model.MethodName;
            parameters[2].Value = model.SqlString;
            parameters[3].Value = model.ErrorMsg;
            parameters[4].Value = model.Description;
            parameters[5].Value = model.UserID;
            parameters[6].Value = model.UserName;
            parameters[7].Value = model.CreateIP;
            parameters[8].Value = model.CreateDate;

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
        public void Update(DigiPower.Onlinecol.Standard.Model.T_OperationLog_MDL model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_OperationLog set ");
            strSql.Append("ClassName=@ClassName,");
            strSql.Append("MethodName=@MethodName,");
            strSql.Append("SqlString=@SqlString,");
            strSql.Append("ErrorMsg=@ErrorMsg,");
            strSql.Append("Description=@Description,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("CreateIP=@CreateIP,");
            strSql.Append("CreateDate=@CreateDate");
            strSql.Append(" where LogID=@LogID ");
            SqlParameter[] parameters = {
					new SqlParameter("@LogID", SqlDbType.Int,8),
					new SqlParameter("@ClassName", SqlDbType.NVarChar,50),
					new SqlParameter("@MethodName", SqlDbType.NVarChar,50),
					new SqlParameter("@SqlString", SqlDbType.NVarChar,3000),
					new SqlParameter("@ErrorMsg", SqlDbType.NVarChar,3000),
					new SqlParameter("@Description", SqlDbType.NVarChar,500),
					new SqlParameter("@UserID", SqlDbType.Int,8),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateIP", SqlDbType.NVarChar,20),
					new SqlParameter("@CreateDate", SqlDbType.DateTime)};
            parameters[0].Value = model.LogID;
            parameters[1].Value = model.ClassName;
            parameters[2].Value = model.MethodName;
            parameters[3].Value = model.SqlString;
            parameters[4].Value = model.ErrorMsg;
            parameters[5].Value = model.Description;
            parameters[6].Value = model.UserID;
            parameters[7].Value = model.UserName;
            parameters[8].Value = model.CreateIP;
            parameters[9].Value = model.CreateDate;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int LogID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_OperationLog ");
            strSql.Append(" where LogID=@LogID ");
            SqlParameter[] parameters = {
					new SqlParameter("@LogID", SqlDbType.Int,8)};
            parameters[0].Value = LogID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_OperationLog_MDL GetModel(int LogID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 LogID,ClassName,MethodName,SqlString,ErrorMsg,Description,UserID,UserName,CreateIP,CreateDate from T_OperationLog ");
            strSql.Append(" where LogID=@LogID ");
            SqlParameter[] parameters = {
					new SqlParameter("@LogID", SqlDbType.Int,8)};
            parameters[0].Value = LogID;

            DigiPower.Onlinecol.Standard.Model.T_OperationLog_MDL model = new DigiPower.Onlinecol.Standard.Model.T_OperationLog_MDL();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["LogID"].ToString() != "") {
                    model.LogID = int.Parse(ds.Tables[0].Rows[0]["LogID"].ToString());
                }
                model.ClassName = ds.Tables[0].Rows[0]["ClassName"].ToString();
                model.MethodName = ds.Tables[0].Rows[0]["MethodName"].ToString();
                model.SqlString = ds.Tables[0].Rows[0]["SqlString"].ToString();
                model.ErrorMsg = ds.Tables[0].Rows[0]["ErrorMsg"].ToString();
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "") {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.CreateIP = ds.Tables[0].Rows[0]["CreateIP"].ToString();
                if (ds.Tables[0].Rows[0]["CreateDate"].ToString() != "") {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
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
            strSql.Append("select LogID,ClassName,MethodName,SqlString,ErrorMsg,Description,UserID,UserName,CreateIP,CreateDate ");
            strSql.Append(" FROM T_OperationLog ");
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
            strSql.Append(" LogID,ClassName,MethodName,SqlString,ErrorMsg,Description,UserID,UserName,CreateIP,CreateDate ");
            strSql.Append(" FROM T_OperationLog ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


        #endregion  成员方法

        /// <summary>
        /// 获得数据列表 分页
        /// </summary>
        /// <returns></returns>
        public DataTable GetListPaging(string strWhere, int PageSize, int curPage, string PRIMARYKey, string OrderByName, out int recCoun) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select T_OperationLog.*,");
            strSql.Append("(select SystemInfoName from T_SystemInfo where CurrentType='OperationType' and lower(SystemInfoCode)=lower(T_OperationLog.Description))as OperationTypeName");
            strSql.Append(" from T_OperationLog ");
            if (strWhere.Trim() != "") {
                strSql.Append("where " + strWhere);
            }

            return PageCtrl.QueryForDataTableSqlServer(strSql.ToString(), PageSize, curPage, PRIMARYKey, OrderByName, out recCoun).Tables[0];
        }

        /// <summary>
        /// 删除多条数据
        /// </summary>
        public void DeleteMore(string LogID) {
            if (!string.IsNullOrWhiteSpace(LogID)) {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from T_OperationLog ");
                strSql.Append(" where LogID in(" + LogID + ") ");

                DbHelperSQL.ExecuteSql(strSql.ToString());
            }
        }
    }
}

