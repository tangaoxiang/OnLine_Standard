using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL {
    /// <summary>
    /// 数据访问类T_EFile_ConvertLog_DAL。
    /// </summary>
    public class T_EFile_ConvertLog_DAL {
        public T_EFile_ConvertLog_DAL() { }
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId() {
            return DbHelperSQL.GetMaxID("LogID", "T_EFile_ConvertLog");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int LogID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_EFile_ConvertLog");
            strSql.Append(" where LogID=@LogID ");
            SqlParameter[] parameters = {
					new SqlParameter("@LogID", SqlDbType.Int,8)			};
            parameters[0].Value = LogID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DigiPower.Onlinecol.Standard.Model.T_EFile_ConvertLog_MDL model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_EFile_ConvertLog(");
            strSql.Append("SingleProjectID,FileListID,EFileID,EFileStartPath,FileName,Description,CreateDate)");
            strSql.Append(" values (");
            strSql.Append("@SingleProjectID,@FileListID,@EFileID,@EFileStartPath,@FileName,@Description,@CreateDate)");
            SqlParameter[] parameters = {
					new SqlParameter("@SingleProjectID", SqlDbType.Int,8),
					new SqlParameter("@FileListID", SqlDbType.Int,8),
					new SqlParameter("@EFileID", SqlDbType.Int,8),
					new SqlParameter("@EFileStartPath", SqlDbType.NVarChar,100),
					new SqlParameter("@FileName", SqlDbType.NVarChar,50),
					new SqlParameter("@Description", SqlDbType.NVarChar,300),
					new SqlParameter("@CreateDate", SqlDbType.DateTime)};
            parameters[0].Value = model.SingleProjectID;
            parameters[1].Value = model.FileListID;
            parameters[2].Value = model.EFileID;
            parameters[3].Value = model.EFileStartPath;
            parameters[4].Value = model.FileName;
            parameters[5].Value = model.Description;
            parameters[6].Value = model.CreateDate;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0) {
                return true;
            } else {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DigiPower.Onlinecol.Standard.Model.T_EFile_ConvertLog_MDL model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_EFile_ConvertLog set ");
            strSql.Append("SingleProjectID=@SingleProjectID,");
            strSql.Append("FileListID=@FileListID,");
            strSql.Append("EFileID=@EFileID,");
            strSql.Append("EFileStartPath=@EFileStartPath,");
            strSql.Append("FileName=@FileName,");
            strSql.Append("Description=@Description,");
            strSql.Append("CreateDate=@CreateDate");
            strSql.Append(" where LogID=@LogID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SingleProjectID", SqlDbType.Int,8),
					new SqlParameter("@FileListID", SqlDbType.Int,8),
					new SqlParameter("@EFileID", SqlDbType.Int,8),
					new SqlParameter("@EFileStartPath", SqlDbType.NVarChar,100),
					new SqlParameter("@FileName", SqlDbType.NVarChar,50),
					new SqlParameter("@Description", SqlDbType.NVarChar,300),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@LogID", SqlDbType.Int,8)};
            parameters[0].Value = model.SingleProjectID;
            parameters[1].Value = model.FileListID;
            parameters[2].Value = model.EFileID;
            parameters[3].Value = model.EFileStartPath;
            parameters[4].Value = model.FileName;
            parameters[5].Value = model.Description;
            parameters[6].Value = model.CreateDate;
            parameters[7].Value = model.LogID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int LogID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_EFile_ConvertLog ");
            strSql.Append(" where LogID=@LogID ");
            SqlParameter[] parameters = {
					new SqlParameter("@LogID", SqlDbType.Int,8)			};
            parameters[0].Value = LogID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// 删除多条数据
        /// </summary>
        public void DeleteMore(string LogID) {
            if (!string.IsNullOrWhiteSpace(LogID)) {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from T_EFile_ConvertLog ");
                strSql.Append(" where LogID in(" + LogID + ") ");

                DbHelperSQL.ExecuteSql(strSql.ToString());
            }
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string LogIDlist) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_EFile_ConvertLog ");
            strSql.Append(" where LogID in (" + LogIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0) {
                return true;
            } else {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_EFile_ConvertLog_MDL GetModel(int LogID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 LogID,SingleProjectID,FileListID,EFileID,EFileStartPath,FileName,Description,CreateDate from T_EFile_ConvertLog ");
            strSql.Append(" where LogID=@LogID ");
            SqlParameter[] parameters = {
					new SqlParameter("@LogID", SqlDbType.Int,4)			};
            parameters[0].Value = LogID;

            DigiPower.Onlinecol.Standard.Model.T_EFile_ConvertLog_MDL model = new DigiPower.Onlinecol.Standard.Model.T_EFile_ConvertLog_MDL();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0) {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            } else {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_EFile_ConvertLog_MDL DataRowToModel(DataRow row) {
            DigiPower.Onlinecol.Standard.Model.T_EFile_ConvertLog_MDL model = new DigiPower.Onlinecol.Standard.Model.T_EFile_ConvertLog_MDL();
            if (row != null) {
                if (row["LogID"] != null && row["LogID"].ToString() != "") {
                    model.LogID = int.Parse(row["LogID"].ToString());
                }
                if (row["SingleProjectID"] != null && row["SingleProjectID"].ToString() != "") {
                    model.SingleProjectID = int.Parse(row["SingleProjectID"].ToString());
                }
                if (row["FileListID"] != null && row["FileListID"].ToString() != "") {
                    model.FileListID = int.Parse(row["FileListID"].ToString());
                }
                if (row["EFileID"] != null && row["EFileID"].ToString() != "") {
                    model.EFileID = int.Parse(row["EFileID"].ToString());
                }
                if (row["EFileStartPath"] != null) {
                    model.EFileStartPath = row["EFileStartPath"].ToString();
                }
                if (row["FileName"] != null) {
                    model.FileName = row["FileName"].ToString();
                }
                if (row["Description"] != null) {
                    model.Description = row["Description"].ToString();
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "") {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select f1.gcmc,f1.gcdd,f1.gcbm,f0.* ");
            strSql.Append("from T_EFile_ConvertLog f0 INNER JOIN T_SingleProject f1 ON f0.SingleProjectID=f1.SingleProjectID ");
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
            strSql.Append(" LogID,SingleProjectID,FileListID,EFileID,EFileStartPath,FileName,Description,CreateDate ");
            strSql.Append(" FROM T_EFile_ConvertLog ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM T_EFile_ConvertLog ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null) {
                return 0;
            } else {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 获得数据列表 分页
        /// </summary>
        /// <returns></returns>
        public DataTable GetListPaging(string strWhere, int PageSize, int curPage, string PRIMARYKey, string OrderByName, out int recCoun) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select f0.*,f1.gcmc,f1.gcdd,f1.gcbm ");
            strSql.Append("from T_EFile_ConvertLog f0 INNER JOIN T_SingleProject f1 ON f0.SingleProjectID=f1.SingleProjectID ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }

            return PageCtrl.QueryForDataTableSqlServer(strSql.ToString(), PageSize, curPage, PRIMARYKey, OrderByName, out recCoun).Tables[0];
        }
    }
}

