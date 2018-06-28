﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;
namespace DigiPower.Onlinecol.Standard.DAL {
    /// <summary>
    /// 数据访问类:T_FileListTmp_OutSideRelated
    /// </summary>
    public partial class T_FileListTmp_OutSideRelated_DAL {
        public T_FileListTmp_OutSideRelated_DAL() { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId() {
            return DbHelperSQL.GetMaxID("SID", "T_FileListTmp_OutSideRelated");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_FileListTmp_OutSideRelated");
            strSql.Append(" where SID=@SID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.Int,8)			};
            parameters[0].Value = SID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DigiPower.Onlinecol.Standard.Model.T_FileListTmp_OutSideRelated_MDL model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_FileListTmp_OutSideRelated(");
            strSql.Append("NativeRecID,FromRecID,FromType)");
            strSql.Append(" values (");
            strSql.Append("@NativeRecID,@FromRecID,@FromType)");
            SqlParameter[] parameters = {
					new SqlParameter("@NativeRecID", SqlDbType.NVarChar,50),
					new SqlParameter("@FromRecID", SqlDbType.NVarChar,50),
					new SqlParameter("@FromType", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.NativeRecID;
            parameters[1].Value = model.FromRecID;
            parameters[2].Value = model.FromType;

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
        public bool Update(DigiPower.Onlinecol.Standard.Model.T_FileListTmp_OutSideRelated_MDL model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_FileListTmp_OutSideRelated set ");
            strSql.Append("NativeRecID=@NativeRecID,");
            strSql.Append("FromRecID=@FromRecID,");
            strSql.Append("FromType=@FromType");
            strSql.Append(" where SID=@SID ");
            SqlParameter[] parameters = {
					new SqlParameter("@NativeRecID", SqlDbType.NVarChar,50),
					new SqlParameter("@FromRecID", SqlDbType.NVarChar,50),
					new SqlParameter("@FromType", SqlDbType.NVarChar,50),
					new SqlParameter("@SID", SqlDbType.Int,8)};
            parameters[0].Value = model.NativeRecID;
            parameters[1].Value = model.FromRecID;
            parameters[2].Value = model.FromType;
            parameters[3].Value = model.SID;

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
        public bool Delete(int SID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_FileListTmp_OutSideRelated ");
            strSql.Append(" where SID=@SID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.Int,8)			};
            parameters[0].Value = SID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0) {
                return true;
            } else {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string SIDlist) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_FileListTmp_OutSideRelated ");
            strSql.Append(" where SID in (" + SIDlist + ")  ");
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
        public DigiPower.Onlinecol.Standard.Model.T_FileListTmp_OutSideRelated_MDL GetModel(int SID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SID,NativeRecID,FromRecID,FromType from T_FileListTmp_OutSideRelated ");
            strSql.Append(" where SID=@SID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.Int,8)			};
            parameters[0].Value = SID;

            DigiPower.Onlinecol.Standard.Model.T_FileListTmp_OutSideRelated_MDL model = new DigiPower.Onlinecol.Standard.Model.T_FileListTmp_OutSideRelated_MDL();
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
        public DigiPower.Onlinecol.Standard.Model.T_FileListTmp_OutSideRelated_MDL DataRowToModel(DataRow row) {
            DigiPower.Onlinecol.Standard.Model.T_FileListTmp_OutSideRelated_MDL model = new DigiPower.Onlinecol.Standard.Model.T_FileListTmp_OutSideRelated_MDL();
            if (row != null) {
                if (row["SID"] != null && row["SID"].ToString() != "") {
                    model.SID = int.Parse(row["SID"].ToString());
                }
                if (row["NativeRecID"] != null) {
                    model.NativeRecID = row["NativeRecID"].ToString();
                }
                if (row["FromRecID"] != null) {
                    model.FromRecID = row["FromRecID"].ToString();
                }
                if (row["FromType"] != null) {
                    model.FromType = row["FromType"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SID,NativeRecID,FromRecID,FromType ");
            strSql.Append(" FROM T_FileListTmp_OutSideRelated ");
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
            strSql.Append(" SID,NativeRecID,FromRecID,FromType ");
            strSql.Append(" FROM T_FileListTmp_OutSideRelated ");
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
            strSql.Append("select count(1) FROM T_FileListTmp_OutSideRelated ");
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
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim())) {
                strSql.Append("order by T." + orderby);
            } else {
                strSql.Append("order by T.SID desc");
            }
            strSql.Append(")AS Row, T.*  from T_FileListTmp_OutSideRelated T ");
            if (!string.IsNullOrEmpty(strWhere.Trim())) {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "T_FileListTmp_OutSideRelated";
            parameters[1].Value = "SID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod

        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

