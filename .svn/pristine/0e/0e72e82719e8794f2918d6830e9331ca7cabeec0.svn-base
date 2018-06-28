using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用

namespace DigiPower.Onlinecol.Standard.DAL {
    /// <summary>
    /// 数据访问类:T_SingleProject_Point
    /// </summary>
    public partial class T_SingleProject_Point_DAL {
        public T_SingleProject_Point_DAL() { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId() {
            return DbHelperSQL.GetMaxID("PointID", "T_SingleProject_Point");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int PointID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_SingleProject_Point");
            strSql.Append(" where PointID=@PointID");
            SqlParameter[] parameters = {
					new SqlParameter("@PointID", SqlDbType.Int,4)
			};
            parameters[0].Value = PointID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_SingleProject_Point_MDL model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_SingleProject_Point(");
            strSql.Append("SingleProjectID,X,Y,OrderIndex)");
            strSql.Append(" values (");
            strSql.Append("@SingleProjectID,@X,@Y,@OrderIndex)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@SingleProjectID", SqlDbType.Int,4),
					new SqlParameter("@X", SqlDbType.VarChar,50),
					new SqlParameter("@Y", SqlDbType.VarChar,50),
					new SqlParameter("@OrderIndex", SqlDbType.Int,4)};
            parameters[0].Value = model.SingleProjectID;
            parameters[1].Value = model.X;
            parameters[2].Value = model.Y;
            parameters[3].Value = model.OrderIndex;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null) {
                return 0;
            } else {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DigiPower.Onlinecol.Standard.Model.T_SingleProject_Point_MDL model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_SingleProject_Point set ");
            strSql.Append("SingleProjectID=@SingleProjectID,");
            strSql.Append("X=@X,");
            strSql.Append("Y=@Y,");
            strSql.Append("OrderIndex=@OrderIndex");
            strSql.Append(" where PointID=@PointID");
            SqlParameter[] parameters = {
					new SqlParameter("@SingleProjectID", SqlDbType.Int,4),
					new SqlParameter("@X", SqlDbType.VarChar,50),
					new SqlParameter("@Y", SqlDbType.VarChar,50),
					new SqlParameter("@OrderIndex", SqlDbType.Int,4),
					new SqlParameter("@PointID", SqlDbType.Int,4)};
            parameters[0].Value = model.SingleProjectID;
            parameters[1].Value = model.X;
            parameters[2].Value = model.Y;
            parameters[3].Value = model.OrderIndex;
            parameters[4].Value = model.PointID;

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
        public bool Delete(int PointID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_SingleProject_Point ");
            strSql.Append(" where PointID=@PointID");
            SqlParameter[] parameters = {
					new SqlParameter("@PointID", SqlDbType.Int,4)
			};
            parameters[0].Value = PointID;

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
        public bool DeleteList(string PointIDlist) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_SingleProject_Point ");
            strSql.Append(" where PointID in (" + PointIDlist + ")  ");
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
        public DigiPower.Onlinecol.Standard.Model.T_SingleProject_Point_MDL GetModel(int PointID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PointID,SingleProjectID,X,Y,OrderIndex from T_SingleProject_Point ");
            strSql.Append(" where PointID=@PointID");
            SqlParameter[] parameters = {
					new SqlParameter("@PointID", SqlDbType.Int,4)
			};
            parameters[0].Value = PointID;

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
        public DigiPower.Onlinecol.Standard.Model.T_SingleProject_Point_MDL DataRowToModel(DataRow row) {
            DigiPower.Onlinecol.Standard.Model.T_SingleProject_Point_MDL model = new DigiPower.Onlinecol.Standard.Model.T_SingleProject_Point_MDL();
            if (row != null) {
                if (row["PointID"] != null && row["PointID"].ToString() != "") {
                    model.PointID = int.Parse(row["PointID"].ToString());
                }
                if (row["SingleProjectID"] != null && row["SingleProjectID"].ToString() != "") {
                    model.SingleProjectID = int.Parse(row["SingleProjectID"].ToString());
                }
                if (row["X"] != null) {
                    model.X = row["X"].ToString();
                }
                if (row["Y"] != null) {
                    model.Y = row["Y"].ToString();
                }
                if (row["OrderIndex"] != null && row["OrderIndex"].ToString() != "") {
                    model.OrderIndex = int.Parse(row["OrderIndex"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PointID,SingleProjectID,X,Y,OrderIndex ");
            strSql.Append(" FROM T_SingleProject_Point ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by OrderIndex ");
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
            strSql.Append(" PointID,SingleProjectID,X,Y,OrderIndex ");
            strSql.Append(" FROM T_SingleProject_Point ");
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
            strSql.Append("select count(1) FROM T_SingleProject_Point ");
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
                strSql.Append("order by T.PointID desc");
            }
            strSql.Append(")AS Row, T.*  from T_SingleProject_Point T ");
            if (!string.IsNullOrEmpty(strWhere.Trim())) {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }



        #endregion  BasicMethod

        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

