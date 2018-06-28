using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL
{
	/// <summary>
	/// 数据访问类T_Field_DAL。
	/// </summary>
	public class T_Field_DAL
	{
		public T_Field_DAL()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("FieldID", "T_Field"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int FieldID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Field");
			strSql.Append(" where FieldID=@FieldID ");
			SqlParameter[] parameters = {
					new SqlParameter("@FieldID", SqlDbType.Int,8)};
			parameters[0].Value = FieldID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DigiPower.Onlinecol.Standard.Model.T_Field_MDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Field(");
			strSql.Append("table_name,table_chn_name,column_name,column_chn_name,column_order,note)");
			strSql.Append(" values (");
			strSql.Append("@table_name,@table_chn_name,@column_name,@column_chn_name,@column_order,@note)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@table_name", SqlDbType.VarChar,50),
					new SqlParameter("@table_chn_name", SqlDbType.VarChar,50),
					new SqlParameter("@column_name", SqlDbType.VarChar,50),
					new SqlParameter("@column_chn_name", SqlDbType.VarChar,50),
					new SqlParameter("@column_order", SqlDbType.Int,8),
					new SqlParameter("@note", SqlDbType.VarChar,255)};
			parameters[0].Value = model.table_name;
			parameters[1].Value = model.table_chn_name;
			parameters[2].Value = model.column_name;
			parameters[3].Value = model.column_chn_name;
			parameters[4].Value = model.column_order;
			parameters[5].Value = model.note;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public void Update(DigiPower.Onlinecol.Standard.Model.T_Field_MDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Field set ");
			strSql.Append("table_name=@table_name,");
			strSql.Append("table_chn_name=@table_chn_name,");
			strSql.Append("column_name=@column_name,");
			strSql.Append("column_chn_name=@column_chn_name,");
			strSql.Append("column_order=@column_order,");
			strSql.Append("note=@note");
			strSql.Append(" where FieldID=@FieldID ");
			SqlParameter[] parameters = {
					new SqlParameter("@FieldID", SqlDbType.Int,8),
					new SqlParameter("@table_name", SqlDbType.VarChar,50),
					new SqlParameter("@table_chn_name", SqlDbType.VarChar,50),
					new SqlParameter("@column_name", SqlDbType.VarChar,50),
					new SqlParameter("@column_chn_name", SqlDbType.VarChar,50),
					new SqlParameter("@column_order", SqlDbType.Int,8),
					new SqlParameter("@note", SqlDbType.VarChar,255)};
			parameters[0].Value = model.FieldID;
			parameters[1].Value = model.table_name;
			parameters[2].Value = model.table_chn_name;
			parameters[3].Value = model.column_name;
			parameters[4].Value = model.column_chn_name;
			parameters[5].Value = model.column_order;
			parameters[6].Value = model.note;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int FieldID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Field ");
			strSql.Append(" where FieldID=@FieldID ");
			SqlParameter[] parameters = {
					new SqlParameter("@FieldID", SqlDbType.Int,8)};
			parameters[0].Value = FieldID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_Field_MDL GetModel(int FieldID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FieldID,table_name,table_chn_name,column_name,column_chn_name,column_order,note from T_Field ");
			strSql.Append(" where FieldID=@FieldID ");
			SqlParameter[] parameters = {
					new SqlParameter("@FieldID", SqlDbType.Int,8)};
			parameters[0].Value = FieldID;

			DigiPower.Onlinecol.Standard.Model.T_Field_MDL model=new DigiPower.Onlinecol.Standard.Model.T_Field_MDL();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["FieldID"].ToString()!="")
				{
					model.FieldID=int.Parse(ds.Tables[0].Rows[0]["FieldID"].ToString());
				}
				model.table_name=ds.Tables[0].Rows[0]["table_name"].ToString();
				model.table_chn_name=ds.Tables[0].Rows[0]["table_chn_name"].ToString();
				model.column_name=ds.Tables[0].Rows[0]["column_name"].ToString();
				model.column_chn_name=ds.Tables[0].Rows[0]["column_chn_name"].ToString();
				if(ds.Tables[0].Rows[0]["column_order"].ToString()!="")
				{
					model.column_order=int.Parse(ds.Tables[0].Rows[0]["column_order"].ToString());
				}
				model.note=ds.Tables[0].Rows[0]["note"].ToString();
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select FieldID,table_name,table_chn_name,column_name,column_chn_name,column_order,note ");
			strSql.Append(" FROM T_Field ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得数据列表 分页
        /// </summary>
        /// <returns></returns>
        public DataTable GetList(string strWhere, int PageSize, int curPage, string PRIMARYKey, string OrderByName, out int recCoun)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select FieldID,table_name,table_chn_name,column_name,column_chn_name,column_order,note ");
            strSql.Append(" FROM T_Field ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return PageCtrl.QueryForDataTableSqlServer(strSql.ToString(), PageSize, curPage, PRIMARYKey, OrderByName, out recCoun).Tables[0];
        }


		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" FieldID,table_name,table_chn_name,column_name,column_chn_name,column_order,note ");
			strSql.Append(" FROM T_Field ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			parameters[0].Value = "T_Field";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法

        public string GetCNFieldNameByFieldName(string table_name, string column_Name)
        {
            //string strSql = "SELECT column_chn_name from Table_Struct_Description where table_name='" + table_name + "' and column_Name='" + column_Name + "'";
            string strSql = "SELECT top 1 column_chn_name from T_Field where column_Name='" + column_Name + "'";
            return Common.ConvertEx.ToString(DbHelperSQL.GetSingle(strSql));
        }
	}
}

