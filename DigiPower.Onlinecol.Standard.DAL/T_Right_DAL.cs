using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL
{
	/// <summary>
	/// 数据访问类T_Right_DAL。
	/// </summary>
	public class T_Right_DAL
	{
		public T_Right_DAL()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("RightID", "T_Right"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int RightID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Right");
			strSql.Append(" where RightID=@RightID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RightID", SqlDbType.Int,8)};
			parameters[0].Value = RightID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DigiPower.Onlinecol.Standard.Model.T_Right_MDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Right(");
			strSql.Append("RightCode,RightName)");
			strSql.Append(" values (");
			strSql.Append("@RightCode,@RightName)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@RightCode", SqlDbType.NVarChar,50),
					new SqlParameter("@RightName", SqlDbType.VarChar,50)};
			parameters[0].Value = model.RightCode;
			parameters[1].Value = model.RightName;

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
		public void Update(DigiPower.Onlinecol.Standard.Model.T_Right_MDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Right set ");
			strSql.Append("RightCode=@RightCode,");
			strSql.Append("RightName=@RightName");
			strSql.Append(" where RightID=@RightID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RightID", SqlDbType.Int,8),
					new SqlParameter("@RightCode", SqlDbType.NVarChar,50),
					new SqlParameter("@RightName", SqlDbType.VarChar,50)};
			parameters[0].Value = model.RightID;
			parameters[1].Value = model.RightCode;
			parameters[2].Value = model.RightName;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int RightID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Right ");
			strSql.Append(" where RightID=@RightID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RightID", SqlDbType.Int,8)};
			parameters[0].Value = RightID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_Right_MDL GetModel(int RightID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 RightID,RightCode,RightName from T_Right ");
			strSql.Append(" where RightID=@RightID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RightID", SqlDbType.Int,8)};
			parameters[0].Value = RightID;

			DigiPower.Onlinecol.Standard.Model.T_Right_MDL model=new DigiPower.Onlinecol.Standard.Model.T_Right_MDL();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["RightID"].ToString()!="")
				{
					model.RightID=int.Parse(ds.Tables[0].Rows[0]["RightID"].ToString());
				}
				model.RightCode=ds.Tables[0].Rows[0]["RightCode"].ToString();
				model.RightName=ds.Tables[0].Rows[0]["RightName"].ToString();
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
			strSql.Append("select RightID,RightCode,RightName ");
			strSql.Append(" FROM T_Right ");
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
			strSql.Append(" RightID,RightCode,RightName ");
			strSql.Append(" FROM T_Right ");
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
			parameters[0].Value = "T_Right";
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

