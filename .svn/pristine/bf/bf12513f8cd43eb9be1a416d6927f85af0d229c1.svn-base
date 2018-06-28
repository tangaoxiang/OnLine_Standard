using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL
{
    /// <summary>
    /// 数据访问类T_Search_ParaDAL。
    /// </summary>
    public class T_Search_Para_DAL
    {
        public T_Search_Para_DAL()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Search_Para_ID", "T_Search_Para");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Search_Para_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_Search_Para");
            strSql.Append(" where Search_Para_ID=@Search_Para_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Search_Para_ID", SqlDbType.Int,8)};
            parameters[0].Value = Search_Para_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_Search_Para_MDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Search_Para(");
            strSql.Append("Search_Field_ID,ParaType,ParaTypeCN,ControlWidth,CompareType,CompareTypeCN,DefaultValue,SourceSql,OrderId)");
            strSql.Append(" values (");
            strSql.Append("@Search_Field_ID,@ParaType,@ParaTypeCN,@ControlWidth,@CompareType,@CompareTypeCN,@DefaultValue,@SourceSql,@OrderId)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Search_Field_ID", SqlDbType.Int,8),
					new SqlParameter("@ParaType", SqlDbType.VarChar,10),
					new SqlParameter("@ParaTypeCN", SqlDbType.VarChar,10),
					new SqlParameter("@ControlWidth", SqlDbType.Int,8),
					new SqlParameter("@CompareType", SqlDbType.VarChar,10),
					new SqlParameter("@CompareTypeCN", SqlDbType.VarChar,10),
					new SqlParameter("@DefaultValue", SqlDbType.VarChar,50),
					new SqlParameter("@SourceSql", SqlDbType.VarChar,200),
					new SqlParameter("@OrderId", SqlDbType.Int,8)};
            parameters[0].Value = model.Search_Field_ID;
            parameters[1].Value = model.ParaType;
            parameters[2].Value = model.ParaTypeCN;
            parameters[3].Value = model.ControlWidth;
            parameters[4].Value = model.CompareType;
            parameters[5].Value = model.CompareTypeCN;
            parameters[6].Value = model.DefaultValue;
            parameters[7].Value = model.SourceSql;
            parameters[8].Value = model.OrderId;

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
        public void Update(DigiPower.Onlinecol.Standard.Model.T_Search_Para_MDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Search_Para set ");
            strSql.Append("Search_Field_ID=@Search_Field_ID,");
            strSql.Append("ParaType=@ParaType,");
            strSql.Append("ParaTypeCN=@ParaTypeCN,");
            strSql.Append("ControlWidth=@ControlWidth,");
            strSql.Append("CompareType=@CompareType,");
            strSql.Append("CompareTypeCN=@CompareTypeCN,");
            strSql.Append("DefaultValue=@DefaultValue,");
            strSql.Append("SourceSql=@SourceSql,");
            strSql.Append("OrderId=@OrderId");
            strSql.Append(" where Search_Para_ID=@Search_Para_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Search_Para_ID", SqlDbType.Int,8),
					new SqlParameter("@Search_Field_ID", SqlDbType.Int,8),
					new SqlParameter("@ParaType", SqlDbType.VarChar,10),
					new SqlParameter("@ParaTypeCN", SqlDbType.VarChar,10),
					new SqlParameter("@ControlWidth", SqlDbType.Int,8),
					new SqlParameter("@CompareType", SqlDbType.VarChar,10),
					new SqlParameter("@CompareTypeCN", SqlDbType.VarChar,10),
					new SqlParameter("@DefaultValue", SqlDbType.VarChar,50),
					new SqlParameter("@SourceSql", SqlDbType.VarChar,200),
					new SqlParameter("@OrderId", SqlDbType.Int,8)};
            parameters[0].Value = model.Search_Para_ID;
            parameters[1].Value = model.Search_Field_ID;
            parameters[2].Value = model.ParaType;
            parameters[3].Value = model.ParaTypeCN;
            parameters[4].Value = model.ControlWidth;
            parameters[5].Value = model.CompareType;
            parameters[6].Value = model.CompareTypeCN;
            parameters[7].Value = model.DefaultValue;
            parameters[8].Value = model.SourceSql;
            parameters[9].Value = model.OrderId;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Search_Para_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Search_Para ");
            strSql.Append(" where Search_Para_ID=@Search_Para_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Search_Para_ID", SqlDbType.Int,8)};
            parameters[0].Value = Search_Para_ID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_Search_Para_MDL GetModel(int Search_Para_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Search_Para_ID,Search_Field_ID,ParaType,ParaTypeCN,ControlWidth,CompareType,CompareTypeCN,DefaultValue,SourceSql,OrderId from T_Search_Para ");
            strSql.Append(" where Search_Para_ID=@Search_Para_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Search_Para_ID", SqlDbType.Int,8)};
            parameters[0].Value = Search_Para_ID;

            DigiPower.Onlinecol.Standard.Model.T_Search_Para_MDL model = new DigiPower.Onlinecol.Standard.Model.T_Search_Para_MDL();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Search_Para_ID"].ToString() != "")
                {
                    model.Search_Para_ID = int.Parse(ds.Tables[0].Rows[0]["Search_Para_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Search_Field_ID"].ToString() != "")
                {
                    model.Search_Field_ID = int.Parse(ds.Tables[0].Rows[0]["Search_Field_ID"].ToString());
                }
                model.ParaType = ds.Tables[0].Rows[0]["ParaType"].ToString();
                model.ParaTypeCN = ds.Tables[0].Rows[0]["ParaTypeCN"].ToString();
                if (ds.Tables[0].Rows[0]["ControlWidth"].ToString() != "")
                {
                    model.ControlWidth = int.Parse(ds.Tables[0].Rows[0]["ControlWidth"].ToString());
                }
                model.CompareType = ds.Tables[0].Rows[0]["CompareType"].ToString();
                model.CompareTypeCN = ds.Tables[0].Rows[0]["CompareTypeCN"].ToString();
                model.DefaultValue = ds.Tables[0].Rows[0]["DefaultValue"].ToString();
                model.SourceSql = ds.Tables[0].Rows[0]["SourceSql"].ToString();
                if (ds.Tables[0].Rows[0]["OrderId"].ToString() != "")
                {
                    model.OrderId = int.Parse(ds.Tables[0].Rows[0]["OrderId"].ToString());
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
            strSql.Append("select Search_Para_ID,Search_Field_ID,ParaType,ParaTypeCN,ControlWidth,CompareType,CompareTypeCN,DefaultValue,SourceSql,OrderId ");
            strSql.Append(" FROM T_Search_Para ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
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
            strSql.Append(" Search_Para_ID,Search_Field_ID,ParaType,ParaTypeCN,ControlWidth,CompareType,CompareTypeCN,DefaultValue,SourceSql,OrderId ");
            strSql.Append(" FROM T_Search_Para ");
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
            parameters[0].Value = "T_Search_Para";
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

