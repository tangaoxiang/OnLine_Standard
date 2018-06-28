using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL
{
	/// <summary>
	/// 数据访问类s_archive_type_DAL。
	/// </summary>
	public class s_archive_type_DAL
	{
		public s_archive_type_DAL()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string archive_type_no)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from s_archive_type");
			strSql.Append(" where archive_type_no=@archive_type_no ");
			SqlParameter[] parameters = {
					new SqlParameter("@archive_type_no", SqlDbType.VarChar,50)};
			parameters[0].Value = archive_type_no;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(DigiPower.Onlinecol.Standard.Model.s_archive_type_MDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into s_archive_type(");
			strSql.Append("archive_type_no,archive_type_name,description)");
			strSql.Append(" values (");
			strSql.Append("@archive_type_no,@archive_type_name,@description)");
			SqlParameter[] parameters = {
					new SqlParameter("@archive_type_no", SqlDbType.VarChar,20),
					new SqlParameter("@archive_type_name", SqlDbType.VarChar,30),
					new SqlParameter("@description", SqlDbType.VarChar,255)};
			parameters[0].Value = model.archive_type_no;
			parameters[1].Value = model.archive_type_name;
			parameters[2].Value = model.description;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(DigiPower.Onlinecol.Standard.Model.s_archive_type_MDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update s_archive_type set ");
			strSql.Append("archive_type_name=@archive_type_name,");
			strSql.Append("description=@description");
			strSql.Append(" where archive_type_no=@archive_type_no ");
			SqlParameter[] parameters = {
					new SqlParameter("@archive_type_no", SqlDbType.VarChar,20),
					new SqlParameter("@archive_type_name", SqlDbType.VarChar,30),
					new SqlParameter("@description", SqlDbType.VarChar,255)};
			parameters[0].Value = model.archive_type_no;
			parameters[1].Value = model.archive_type_name;
			parameters[2].Value = model.description;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string archive_type_no)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from s_archive_type ");
			strSql.Append(" where archive_type_no=@archive_type_no ");
			SqlParameter[] parameters = {
					new SqlParameter("@archive_type_no", SqlDbType.VarChar,50)};
			parameters[0].Value = archive_type_no;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.s_archive_type_MDL GetModel(string archive_type_no)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 archive_type_no,archive_type_name,description from s_archive_type ");
			strSql.Append(" where archive_type_no=@archive_type_no ");
			SqlParameter[] parameters = {
					new SqlParameter("@archive_type_no", SqlDbType.VarChar,50)};
			parameters[0].Value = archive_type_no;

			DigiPower.Onlinecol.Standard.Model.s_archive_type_MDL model=new DigiPower.Onlinecol.Standard.Model.s_archive_type_MDL();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.archive_type_no=ds.Tables[0].Rows[0]["archive_type_no"].ToString();
				model.archive_type_name=ds.Tables[0].Rows[0]["archive_type_name"].ToString();
				model.description=ds.Tables[0].Rows[0]["description"].ToString();
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
			strSql.Append("select archive_type_no,archive_type_name,description ");
			strSql.Append(" FROM s_archive_type ");
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
			strSql.Append(" archive_type_no,archive_type_name,description ");
			strSql.Append(" FROM s_archive_type ");
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
			parameters[0].Value = "s_archive_type";
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

