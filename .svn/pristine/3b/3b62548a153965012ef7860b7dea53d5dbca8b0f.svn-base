using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;
namespace DigiPower.Onlinecol.Standard.DAL {
    /// <summary>
    /// 数据访问类:T_FileList_SignatureTmp
    /// </summary>
    public partial class T_FileList_SignatureTmp_DAL {
        public T_FileList_SignatureTmp_DAL() { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DigiPower.Onlinecol.Standard.Model.T_FileList_SignatureTmp_MDL model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_FileList_SignatureTmp(");
            strSql.Append("FileListID,SignatureType,OrderIndex,SignatureCount)");
            strSql.Append(" values (");
            strSql.Append("@FileListID,@SignatureType,@OrderIndex,@SignatureCount)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@FileListID", SqlDbType.Int,8),
					new SqlParameter("@SignatureType", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderIndex", SqlDbType.Int,8),
					new SqlParameter("@SignatureCount", SqlDbType.Int,8)};
            parameters[0].Value = model.FileListID;
            parameters[1].Value = model.SignatureType;
            parameters[2].Value = model.OrderIndex;
            parameters[3].Value = model.SignatureCount;

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
        public bool Update(DigiPower.Onlinecol.Standard.Model.T_FileList_SignatureTmp_MDL model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_FileList_SignatureTmp set ");
            strSql.Append("FileListID=@FileListID,");
            strSql.Append("SignatureType=@SignatureType,");
            strSql.Append("OrderIndex=@OrderIndex,");
            strSql.Append("SignatureCount=@SignatureCount");
            strSql.Append(" where SID=@SID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.Int,8),
					new SqlParameter("@FileListID", SqlDbType.Int,8),
					new SqlParameter("@SignatureType", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderIndex", SqlDbType.Int,8),
					new SqlParameter("@SignatureCount", SqlDbType.Int,8)};

            parameters[0].Value = model.SID;
            parameters[1].Value = model.FileListID;
            parameters[2].Value = model.SignatureType;
            parameters[3].Value = model.OrderIndex;
            parameters[4].Value = model.SignatureCount;

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
        public void Delete(int SID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_FileList_SignatureTmp ");
            strSql.Append(" where SID=@SID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.Int,8)};
            parameters[0].Value = SID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteForFileListID(int FileListID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_FileList_SignatureTmp ");
            strSql.Append(" where FileListID=@FileListID ");
            SqlParameter[] parameters = {
					new SqlParameter("@FileListID", SqlDbType.Int,8)};
            parameters[0].Value = FileListID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_FileList_SignatureTmp_MDL GetModel(int SID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SID,FileListID,SignatureType,OrderIndex,SignatureCount from T_FileList_SignatureTmp ");
            strSql.Append(" where SID=@SID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.Int,8)};
            parameters[0].Value = SID;

            DigiPower.Onlinecol.Standard.Model.T_FileList_SignatureTmp_MDL model = new DigiPower.Onlinecol.Standard.Model.T_FileList_SignatureTmp_MDL();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0) {
                DataRow row = ds.Tables[0].Rows[0];
                if (row != null) {
                    if (row["SID"] != null && row["SID"].ToString() != "") {
                        model.SID = int.Parse(row["SID"].ToString());
                    }
                    if (row["FileListID"] != null && row["FileListID"].ToString() != "") {
                        model.FileListID = int.Parse(row["FileListID"].ToString());
                    }
                    if (row["SignatureType"] != null) {
                        model.SignatureType = row["SignatureType"].ToString();
                    }
                    if (row["OrderIndex"] != null && row["OrderIndex"].ToString() != "") {
                        model.OrderIndex = int.Parse(row["OrderIndex"].ToString());
                    }
                    if (row["SignatureCount"] != null && row["SignatureCount"].ToString() != "") {
                        model.SignatureCount = int.Parse(row["SignatureCount"].ToString());
                    }
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SID,FileListID,SignatureType,OrderIndex,SignatureCount,");
            strSql.Append("(SELECT f0.SystemInfoName FROM T_SystemInfo f0 where f0.CurrentType='SignetType' ");
            strSql.Append("AND f0.SystemInfoCode=T_FileList_SignatureTmp.SignatureType)as SignatureTypeName ");

            strSql.Append("FROM T_FileList_SignatureTmp ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by OrderIndex");
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
            strSql.Append(" SID,FileListID,SignatureType,OrderIndex,SignatureCount ");
            strSql.Append(" FROM T_FileList_SignatureTmp ");
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
            strSql.Append("select count(1) FROM T_FileList_SignatureTmp ");
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

        #endregion  BasicMethod

        /// <summary>
        /// 绑定工程下所有文件对应的签章角色
        /// </summary>
        /// <param name="SingleProjectID"></param>
        /// <returns></returns>
        public DataTable GetSingleProjectAllSignatureRole(string SingleProjectID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM T_Role t0 where t0.RoleCode IN(  ");
            strSql.Append("SELECT  DISTINCT SignatureType FROM T_FileList_SignatureTmp t1,(select recID from T_FileList where SingleProjectID=@SingleProjectID ) t2 ");
            strSql.Append("where t1.FileListID=t2.recID) ");

            SqlParameter[] parameters = {
					new SqlParameter("@SingleProjectID", SqlDbType.Int,10)};
            parameters[0].Value = SingleProjectID;

            return DbHelperSQL.Query(strSql.ToString(), parameters).Tables[0];
        }
    }
}

