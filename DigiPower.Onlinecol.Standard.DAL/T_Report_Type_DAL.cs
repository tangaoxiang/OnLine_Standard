using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL
{
	/// <summary>
	/// 数据访问类T_Report_Type_DAL。
	/// </summary>
	public class T_Report_Type_DAL
	{
		public T_Report_Type_DAL()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ReportTypeID", "T_Report_Type"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ReportTypeID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Report_Type");
			strSql.Append(" where ReportTypeID=@ReportTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ReportTypeID", SqlDbType.Int,8)};
			parameters[0].Value = ReportTypeID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DigiPower.Onlinecol.Standard.Model.T_Report_Type_MDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Report_Type(");
			strSql.Append("PID,ReportTypeName,IsValid)");
			strSql.Append(" values (");
			strSql.Append("@PID,@ReportTypeName,@IsValid)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PID", SqlDbType.Int,8),
					new SqlParameter("@ReportTypeName", SqlDbType.VarChar,50),
					new SqlParameter("@IsValid", SqlDbType.Bit,1)};
			parameters[0].Value = model.PID;
			parameters[1].Value = model.ReportTypeName;
			parameters[2].Value = model.IsValid;

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
		public void Update(DigiPower.Onlinecol.Standard.Model.T_Report_Type_MDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Report_Type set ");
			strSql.Append("PID=@PID,");
			strSql.Append("ReportTypeName=@ReportTypeName,");
			strSql.Append("IsValid=@IsValid");
			strSql.Append(" where ReportTypeID=@ReportTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ReportTypeID", SqlDbType.Int,8),
					new SqlParameter("@PID", SqlDbType.Int,8),
					new SqlParameter("@ReportTypeName", SqlDbType.VarChar,50),
					new SqlParameter("@IsValid", SqlDbType.Bit,1)};
			parameters[0].Value = model.ReportTypeID;
			parameters[1].Value = model.PID;
			parameters[2].Value = model.ReportTypeName;
			parameters[3].Value = model.IsValid;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ReportTypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Report_Type ");
			strSql.Append(" where ReportTypeID=@ReportTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ReportTypeID", SqlDbType.Int,8)};
			parameters[0].Value = ReportTypeID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_Report_Type_MDL GetModel(int ReportTypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ReportTypeID,PID,ReportTypeName,IsValid from T_Report_Type ");
			strSql.Append(" where ReportTypeID=@ReportTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ReportTypeID", SqlDbType.Int,8)};
			parameters[0].Value = ReportTypeID;

			DigiPower.Onlinecol.Standard.Model.T_Report_Type_MDL model=new DigiPower.Onlinecol.Standard.Model.T_Report_Type_MDL();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ReportTypeID"].ToString()!="")
				{
					model.ReportTypeID=int.Parse(ds.Tables[0].Rows[0]["ReportTypeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PID"].ToString()!="")
				{
					model.PID=int.Parse(ds.Tables[0].Rows[0]["PID"].ToString());
				}
				model.ReportTypeName=ds.Tables[0].Rows[0]["ReportTypeName"].ToString();
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
			strSql.Append("select ReportTypeID,PID,ReportTypeName,IsValid ");
			strSql.Append(" FROM T_Report_Type ");
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
			strSql.Append(" ReportTypeID,PID,ReportTypeName,IsValid ");
			strSql.Append(" FROM T_Report_Type ");
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
			parameters[0].Value = "T_Report_Type";
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

