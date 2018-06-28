using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL
{
	/// <summary>
	/// 数据访问类T_Report_DAL。
	/// </summary>
	public class T_Report_DAL
	{
		public T_Report_DAL()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ReportID", "T_Report"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ReportID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Report");
			strSql.Append(" where ReportID=@ReportID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ReportID", SqlDbType.Int,8)};
			parameters[0].Value = ReportID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DigiPower.Onlinecol.Standard.Model.T_Report_MDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Report(");
			strSql.Append("ReportTypeID,ReportCode,ReportName,ReportFilePath,IsValid,OrderId)");
			strSql.Append(" values (");
			strSql.Append("@ReportTypeID,@ReportCode,@ReportName,@ReportFilePath,@IsValid,@OrderId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ReportTypeID", SqlDbType.Int,8),
					new SqlParameter("@ReportCode", SqlDbType.VarChar,20),
					new SqlParameter("@ReportName", SqlDbType.VarChar,50),
					new SqlParameter("@ReportFilePath", SqlDbType.VarChar,50),
					new SqlParameter("@IsValid", SqlDbType.Bit,1),
					new SqlParameter("@OrderId", SqlDbType.Int,8)};
			parameters[0].Value = model.ReportTypeID;
			parameters[1].Value = model.ReportCode;
			parameters[2].Value = model.ReportName;
			parameters[3].Value = model.ReportFilePath;
			parameters[4].Value = model.IsValid;
			parameters[5].Value = model.OrderId;

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
		public void Update(DigiPower.Onlinecol.Standard.Model.T_Report_MDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Report set ");
			strSql.Append("ReportTypeID=@ReportTypeID,");
			strSql.Append("ReportCode=@ReportCode,");
			strSql.Append("ReportName=@ReportName,");
			strSql.Append("ReportFilePath=@ReportFilePath,");
			strSql.Append("IsValid=@IsValid,");
			strSql.Append("OrderId=@OrderId");
			strSql.Append(" where ReportID=@ReportID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ReportID", SqlDbType.Int,8),
					new SqlParameter("@ReportTypeID", SqlDbType.Int,8),
					new SqlParameter("@ReportCode", SqlDbType.VarChar,20),
					new SqlParameter("@ReportName", SqlDbType.VarChar,50),
					new SqlParameter("@ReportFilePath", SqlDbType.VarChar,50),
					new SqlParameter("@IsValid", SqlDbType.Bit,1),
					new SqlParameter("@OrderId", SqlDbType.Int,8)};
			parameters[0].Value = model.ReportID;
			parameters[1].Value = model.ReportTypeID;
			parameters[2].Value = model.ReportCode;
			parameters[3].Value = model.ReportName;
			parameters[4].Value = model.ReportFilePath;
			parameters[5].Value = model.IsValid;
			parameters[6].Value = model.OrderId;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ReportID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Report ");
			strSql.Append(" where ReportID=@ReportID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ReportID", SqlDbType.Int,8)};
			parameters[0].Value = ReportID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_Report_MDL GetModel(int ReportID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ReportID,ReportTypeID,ReportCode,ReportName,ReportFilePath,IsValid,OrderId from T_Report ");
			strSql.Append(" where ReportID=@ReportID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ReportID", SqlDbType.Int,8)};
			parameters[0].Value = ReportID;

			DigiPower.Onlinecol.Standard.Model.T_Report_MDL model=new DigiPower.Onlinecol.Standard.Model.T_Report_MDL();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ReportID"].ToString()!="")
				{
					model.ReportID=int.Parse(ds.Tables[0].Rows[0]["ReportID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ReportTypeID"].ToString()!="")
				{
					model.ReportTypeID=int.Parse(ds.Tables[0].Rows[0]["ReportTypeID"].ToString());
				}
				model.ReportCode=ds.Tables[0].Rows[0]["ReportCode"].ToString();
				model.ReportName=ds.Tables[0].Rows[0]["ReportName"].ToString();
				model.ReportFilePath=ds.Tables[0].Rows[0]["ReportFilePath"].ToString();
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
				if(ds.Tables[0].Rows[0]["OrderId"].ToString()!="")
				{
					model.OrderId=int.Parse(ds.Tables[0].Rows[0]["OrderId"].ToString());
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ReportID,ReportTypeID,ReportCode,ReportName,ReportFilePath,IsValid,OrderId ");
			strSql.Append(" FROM T_Report ");
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
			strSql.Append(" ReportID,ReportTypeID,ReportCode,ReportName,ReportFilePath,IsValid,OrderId ");
			strSql.Append(" FROM T_Report ");
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
			parameters[0].Value = "T_Report";
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

