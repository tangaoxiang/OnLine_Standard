using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL
{
    /// <summary>
    /// 数据访问类T_Area_DAL。
    /// </summary>
    public class T_Area_DAL
    {
        public T_Area_DAL()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("AreaID", "T_Area");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int AreaID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_Area");
            strSql.Append(" where AreaID=@AreaID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AreaID", SqlDbType.Int,8)};
            parameters[0].Value = AreaID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int AreaCode, int AreaID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_Area");
            strSql.Append(" where area_code=@area_code and AreaID !=@AreaID");
            SqlParameter[] parameters = {
					new SqlParameter("@area_code", SqlDbType.Int,8),
                    new SqlParameter("@AreaID", SqlDbType.Int,8)};
            parameters[0].Value = AreaCode;
            parameters[1].Value = AreaID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
           
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_Area_MDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Area(");
            strSql.Append("area_code,area_name,PID,OrderIndex)");
            strSql.Append(" values (");
            strSql.Append("@area_code,@area_name,@PID,@OrderIndex)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@area_code", SqlDbType.NVarChar,20),
					new SqlParameter("@area_name", SqlDbType.VarChar,30),
					new SqlParameter("@PID", SqlDbType.Int,8),
					new SqlParameter("@OrderIndex", SqlDbType.Int,8)};
            parameters[0].Value = model.area_code;
            parameters[1].Value = model.area_name;
            parameters[2].Value = model.PID;
            parameters[3].Value = model.OrderIndex;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(DigiPower.Onlinecol.Standard.Model.T_Area_MDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Area set ");
            strSql.Append("area_code=@area_code,");
            strSql.Append("area_name=@area_name,");
            strSql.Append("PID=@PID,");
            strSql.Append("OrderIndex=@OrderIndex");
            strSql.Append(" where AreaID=@AreaID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AreaID", SqlDbType.Int,8),
					new SqlParameter("@area_code", SqlDbType.NVarChar,20),
					new SqlParameter("@area_name", SqlDbType.VarChar,30),
					new SqlParameter("@PID", SqlDbType.Int,8),
					new SqlParameter("@OrderIndex", SqlDbType.Int,8)};
            parameters[0].Value = model.AreaID;
            parameters[1].Value = model.area_code;
            parameters[2].Value = model.area_name;
            parameters[3].Value = model.PID;
            parameters[4].Value = model.OrderIndex;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int AreaID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Area ");
            strSql.Append(" where AreaID=@AreaID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AreaID", SqlDbType.Int,8)};
            parameters[0].Value = AreaID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_Area_MDL GetModel(int AreaID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 AreaID,area_code,area_name,PID,OrderIndex from T_Area ");
            strSql.Append(" where AreaID=@AreaID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AreaID", SqlDbType.Int,8)};
            parameters[0].Value = AreaID;

            DigiPower.Onlinecol.Standard.Model.T_Area_MDL model = new DigiPower.Onlinecol.Standard.Model.T_Area_MDL();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["AreaID"].ToString() != "")
                {
                    model.AreaID = int.Parse(ds.Tables[0].Rows[0]["AreaID"].ToString());
                }
                model.area_code = ds.Tables[0].Rows[0]["area_code"].ToString();
                model.area_name = ds.Tables[0].Rows[0]["area_name"].ToString();
                if (ds.Tables[0].Rows[0]["PID"].ToString() != "")
                {
                    model.PID = int.Parse(ds.Tables[0].Rows[0]["PID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderIndex"].ToString() != "")
                {
                    model.OrderIndex = int.Parse(ds.Tables[0].Rows[0]["OrderIndex"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AreaID,area_code,area_name,PID,OrderIndex ");
            strSql.Append(" FROM T_Area ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by OrderIndex");
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 获得数据列表 分页
        /// </summary>
        /// <returns></returns>
        public DataTable GetList(string strWhere, int PageSize, int curPage, string PRIMARYKey, string OrderByName, out int recCoun)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AreaID,area_code,area_name,PID,OrderIndex ");
            strSql.Append(" FROM T_Area ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return PageCtrl.QueryForDataTableSqlServer(strSql.ToString(), PageSize, curPage, PRIMARYKey, OrderByName, out recCoun).Tables[0];
        }


        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" AreaID,area_code,area_name,PID,OrderIndex ");
            strSql.Append(" FROM T_Area ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
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
            parameters[0].Value = "T_Area";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法
    }
}

