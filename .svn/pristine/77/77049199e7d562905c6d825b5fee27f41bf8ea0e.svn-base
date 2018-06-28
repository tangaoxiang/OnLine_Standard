using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL
{
	/// <summary>
	/// 数据访问类T_Report_MainSql_DAL。
	/// </summary>
	public class T_Report_MainSql_DAL
	{
		public T_Report_MainSql_DAL()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ReportMainSqlID", "T_Report_MainSql"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ReportMainSqlID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Report_MainSql");
			strSql.Append(" where ReportMainSqlID=@ReportMainSqlID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ReportMainSqlID", SqlDbType.Int,8)};
			parameters[0].Value = ReportMainSqlID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DigiPower.Onlinecol.Standard.Model.T_Report_MainSql_MDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Report_MainSql(");
			strSql.Append("ReportID,MainSql,OrderId,IsValid,OtherName)");
			strSql.Append(" values (");
			strSql.Append("@ReportID,@MainSql,@OrderId,@IsValid,@OtherName)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ReportID", SqlDbType.Int,8),
					new SqlParameter("@MainSql", SqlDbType.VarChar,500),
					new SqlParameter("@OrderId", SqlDbType.Int,8),
					new SqlParameter("@IsValid", SqlDbType.Bit,1),
					new SqlParameter("@OtherName", SqlDbType.VarChar,20)};
			parameters[0].Value = model.ReportID;
			parameters[1].Value = model.MainSql;
			parameters[2].Value = model.OrderId;
			parameters[3].Value = model.IsValid;
			parameters[4].Value = model.OtherName;

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
		public void Update(DigiPower.Onlinecol.Standard.Model.T_Report_MainSql_MDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Report_MainSql set ");
			strSql.Append("ReportID=@ReportID,");
			strSql.Append("MainSql=@MainSql,");
			strSql.Append("OrderId=@OrderId,");
			strSql.Append("IsValid=@IsValid,");
			strSql.Append("OtherName=@OtherName");
			strSql.Append(" where ReportMainSqlID=@ReportMainSqlID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ReportMainSqlID", SqlDbType.Int,8),
					new SqlParameter("@ReportID", SqlDbType.Int,8),
					new SqlParameter("@MainSql", SqlDbType.VarChar,500),
					new SqlParameter("@OrderId", SqlDbType.Int,8),
					new SqlParameter("@IsValid", SqlDbType.Bit,1),
					new SqlParameter("@OtherName", SqlDbType.VarChar,20)};
			parameters[0].Value = model.ReportMainSqlID;
			parameters[1].Value = model.ReportID;
			parameters[2].Value = model.MainSql;
			parameters[3].Value = model.OrderId;
			parameters[4].Value = model.IsValid;
			parameters[5].Value = model.OtherName;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ReportMainSqlID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Report_MainSql ");
			strSql.Append(" where ReportMainSqlID=@ReportMainSqlID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ReportMainSqlID", SqlDbType.Int,8)};
			parameters[0].Value = ReportMainSqlID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_Report_MainSql_MDL GetModel(int ReportMainSqlID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ReportMainSqlID,ReportID,MainSql,OrderId,IsValid,OtherName from T_Report_MainSql ");
			strSql.Append(" where ReportMainSqlID=@ReportMainSqlID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ReportMainSqlID", SqlDbType.Int,8)};
			parameters[0].Value = ReportMainSqlID;

			DigiPower.Onlinecol.Standard.Model.T_Report_MainSql_MDL model=new DigiPower.Onlinecol.Standard.Model.T_Report_MainSql_MDL();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ReportMainSqlID"].ToString()!="")
				{
					model.ReportMainSqlID=int.Parse(ds.Tables[0].Rows[0]["ReportMainSqlID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ReportID"].ToString()!="")
				{
					model.ReportID=int.Parse(ds.Tables[0].Rows[0]["ReportID"].ToString());
				}
				model.MainSql=ds.Tables[0].Rows[0]["MainSql"].ToString();
				if(ds.Tables[0].Rows[0]["OrderId"].ToString()!="")
				{
					model.OrderId=int.Parse(ds.Tables[0].Rows[0]["OrderId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsValid"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["IsValid"].ToString()=="1")||(ds.Tables[0].Rows[0]["IsValid"].ToString().ToLower()=="true"))
					{
						model.IsValid=true;
					}
					else
					{
						model.IsValid=false;
					}
				}
				model.OtherName=ds.Tables[0].Rows[0]["OtherName"].ToString();
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
			strSql.Append("select ReportMainSqlID,ReportID,MainSql,OrderId,IsValid,OtherName ");
			strSql.Append(" FROM T_Report_MainSql ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
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
			strSql.Append(" ReportMainSqlID,ReportID,MainSql,OrderId,IsValid,OtherName ");
			strSql.Append(" FROM T_Report_MainSql ");
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
			parameters[0].Value = "T_Report_MainSql";
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

