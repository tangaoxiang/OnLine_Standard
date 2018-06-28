using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL
{
    /// <summary>
    /// 数据访问类T_Search_Field_DAL。
    /// </summary>
    public class T_Search_Field_DAL
    {
        public T_Search_Field_DAL()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Search_Field_ID", "T_Search_Field");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Search_Field_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_Search_Field");
            strSql.Append(" where Search_Field_ID=@Search_Field_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Search_Field_ID", SqlDbType.Int,8)};
            parameters[0].Value = Search_Field_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_Search_Field_MDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Search_Field(");
            strSql.Append("ReportCode,TableName,TableNameCN,LabelName,FieldName,Line,OrderId,IsDictionary)");
            strSql.Append(" values (");
            strSql.Append("@ReportCode,@TableName,@TableNameCN,@LabelName,@FieldName,@Line,@OrderId,@IsDictionary)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ReportCode", SqlDbType.VarChar,50),
					new SqlParameter("@TableName", SqlDbType.VarChar,50),
					new SqlParameter("@TableNameCN", SqlDbType.VarChar,50),
					new SqlParameter("@LabelName", SqlDbType.VarChar,50),
					new SqlParameter("@FieldName", SqlDbType.VarChar,50),
					new SqlParameter("@Line", SqlDbType.Int,8),
					new SqlParameter("@OrderId", SqlDbType.Int,8),
					new SqlParameter("@IsDictionary", SqlDbType.Int,8)};
            parameters[0].Value = model.ReportCode;
            parameters[1].Value = model.TableName;
            parameters[2].Value = model.TableNameCN;
            parameters[3].Value = model.LabelName;
            parameters[4].Value = model.FieldName;
            parameters[5].Value = model.Line;
            parameters[6].Value = model.OrderId;
            parameters[7].Value = model.IsDictionary;

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
        public void Update(DigiPower.Onlinecol.Standard.Model.T_Search_Field_MDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Search_Field set ");
            strSql.Append("ReportCode=@ReportCode,");
            strSql.Append("TableName=@TableName,");
            strSql.Append("TableNameCN=@TableNameCN,");
            strSql.Append("LabelName=@LabelName,");
            strSql.Append("FieldName=@FieldName,");
            strSql.Append("Line=@Line,");
            strSql.Append("OrderId=@OrderId,");
            strSql.Append("IsDictionary=@IsDictionary");
            strSql.Append(" where Search_Field_ID=@Search_Field_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Search_Field_ID", SqlDbType.Int,8),
					new SqlParameter("@ReportCode", SqlDbType.VarChar,50),
					new SqlParameter("@TableName", SqlDbType.VarChar,50),
					new SqlParameter("@TableNameCN", SqlDbType.VarChar,50),
					new SqlParameter("@LabelName", SqlDbType.VarChar,50),
					new SqlParameter("@FieldName", SqlDbType.VarChar,50),
					new SqlParameter("@Line", SqlDbType.Int,8),
					new SqlParameter("@OrderId", SqlDbType.Int,8),
					new SqlParameter("@IsDictionary", SqlDbType.Int,8)};
            parameters[0].Value = model.Search_Field_ID;
            parameters[1].Value = model.ReportCode;
            parameters[2].Value = model.TableName;
            parameters[3].Value = model.TableNameCN;
            parameters[4].Value = model.LabelName;
            parameters[5].Value = model.FieldName;
            parameters[6].Value = model.Line;
            parameters[7].Value = model.OrderId;
            parameters[8].Value = model.IsDictionary;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Search_Field_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Search_Field ");
            strSql.Append(" where Search_Field_ID=@Search_Field_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Search_Field_ID", SqlDbType.Int,8)};
            parameters[0].Value = Search_Field_ID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_Search_Field_MDL GetModel(int Search_Field_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Search_Field_ID,ReportCode,TableName,TableNameCN,LabelName,FieldName,Line,OrderId,IsDictionary from T_Search_Field ");
            strSql.Append(" where Search_Field_ID=@Search_Field_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Search_Field_ID", SqlDbType.Int,8)};
            parameters[0].Value = Search_Field_ID;

            DigiPower.Onlinecol.Standard.Model.T_Search_Field_MDL model = new DigiPower.Onlinecol.Standard.Model.T_Search_Field_MDL();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Search_Field_ID"].ToString() != "")
                {
                    model.Search_Field_ID = int.Parse(ds.Tables[0].Rows[0]["Search_Field_ID"].ToString());
                }
                model.ReportCode = ds.Tables[0].Rows[0]["ReportCode"].ToString();
                model.TableName = ds.Tables[0].Rows[0]["TableName"].ToString();
                model.TableNameCN = ds.Tables[0].Rows[0]["TableNameCN"].ToString();
                model.LabelName = ds.Tables[0].Rows[0]["LabelName"].ToString();
                model.FieldName = ds.Tables[0].Rows[0]["FieldName"].ToString();
                if (ds.Tables[0].Rows[0]["Line"].ToString() != "")
                {
                    model.Line = int.Parse(ds.Tables[0].Rows[0]["Line"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderId"].ToString() != "")
                {
                    model.OrderId = int.Parse(ds.Tables[0].Rows[0]["OrderId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsDictionary"].ToString() != "")
                {
                    model.IsDictionary = int.Parse(ds.Tables[0].Rows[0]["IsDictionary"].ToString());
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
            strSql.Append("select Search_Field_ID,ReportCode,TableName,TableNameCN,LabelName,FieldName,Line,OrderId,IsDictionary ");
            strSql.Append(" FROM T_Search_Field ");
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
            strSql.Append(" Search_Field_ID,ReportCode,TableName,TableNameCN,LabelName,FieldName,Line,OrderId,IsDictionary ");
            strSql.Append(" FROM T_Search_Field ");
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
            parameters[0].Value = "T_Search_Field";
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

