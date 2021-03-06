using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL
{
	/// <summary>
	/// 数据访问类T_CompanyArchiveUser_DAL。
	/// </summary>
	public class T_CompanyArchiveUser_DAL
	{
		public T_CompanyArchiveUser_DAL()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("CompanyArchiveUserID", "T_CompanyArchiveUser"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CompanyArchiveUserID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_CompanyArchiveUser");
			strSql.Append(" where CompanyArchiveUserID=@CompanyArchiveUserID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CompanyArchiveUserID", SqlDbType.Int,8)};
			parameters[0].Value = CompanyArchiveUserID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DigiPower.Onlinecol.Standard.Model.T_CompanyArchiveUser_MDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_CompanyArchiveUser(");
			strSql.Append("CompanyID,ArchiveUserCode,UserName,Sex,Birthday,Educate,Tel,Email,QQ,TrainCount,RegDate,RegFlag)");
			strSql.Append(" values (");
			strSql.Append("@CompanyID,@ArchiveUserCode,@UserName,@Sex,@Birthday,@Educate,@Tel,@Email,@QQ,@TrainCount,@RegDate,@RegFlag)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CompanyID", SqlDbType.Int,8),
					new SqlParameter("@ArchiveUserCode", SqlDbType.NVarChar,20),
					new SqlParameter("@UserName", SqlDbType.NVarChar,20),
					new SqlParameter("@Sex", SqlDbType.NVarChar,2),
					new SqlParameter("@Birthday", SqlDbType.DateTime),
					new SqlParameter("@Educate", SqlDbType.NVarChar,10),
					new SqlParameter("@Tel", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@QQ", SqlDbType.NVarChar,20),
					new SqlParameter("@TrainCount", SqlDbType.Int,8),
					new SqlParameter("@RegDate", SqlDbType.DateTime),
					new SqlParameter("@RegFlag", SqlDbType.Bit,1)};
			parameters[0].Value = model.CompanyID;
			parameters[1].Value = model.ArchiveUserCode;
			parameters[2].Value = model.UserName;
			parameters[3].Value = model.Sex;
			parameters[4].Value = model.Birthday;
			parameters[5].Value = model.Educate;
			parameters[6].Value = model.Tel;
			parameters[7].Value = model.Email;
			parameters[8].Value = model.QQ;
			parameters[9].Value = model.TrainCount;
			parameters[10].Value = model.RegDate;
			parameters[11].Value = model.RegFlag;

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
		public void Update(DigiPower.Onlinecol.Standard.Model.T_CompanyArchiveUser_MDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_CompanyArchiveUser set ");
			strSql.Append("CompanyID=@CompanyID,");
			strSql.Append("ArchiveUserCode=@ArchiveUserCode,");
			strSql.Append("UserName=@UserName,");
			strSql.Append("Sex=@Sex,");
			strSql.Append("Birthday=@Birthday,");
			strSql.Append("Educate=@Educate,");
			strSql.Append("Tel=@Tel,");
			strSql.Append("Email=@Email,");
			strSql.Append("QQ=@QQ,");
			strSql.Append("TrainCount=@TrainCount,");
			strSql.Append("RegDate=@RegDate,");
			strSql.Append("RegFlag=@RegFlag");
			strSql.Append(" where CompanyArchiveUserID=@CompanyArchiveUserID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CompanyArchiveUserID", SqlDbType.Int,8),
					new SqlParameter("@CompanyID", SqlDbType.Int,8),
					new SqlParameter("@ArchiveUserCode", SqlDbType.NVarChar,20),
					new SqlParameter("@UserName", SqlDbType.NVarChar,20),
					new SqlParameter("@Sex", SqlDbType.NVarChar,2),
					new SqlParameter("@Birthday", SqlDbType.DateTime),
					new SqlParameter("@Educate", SqlDbType.NVarChar,10),
					new SqlParameter("@Tel", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@QQ", SqlDbType.NVarChar,20),
					new SqlParameter("@TrainCount", SqlDbType.Int,8),
					new SqlParameter("@RegDate", SqlDbType.DateTime),
					new SqlParameter("@RegFlag", SqlDbType.Bit,1)};
			parameters[0].Value = model.CompanyArchiveUserID;
			parameters[1].Value = model.CompanyID;
			parameters[2].Value = model.ArchiveUserCode;
			parameters[3].Value = model.UserName;
			parameters[4].Value = model.Sex;
			parameters[5].Value = model.Birthday;
			parameters[6].Value = model.Educate;
			parameters[7].Value = model.Tel;
			parameters[8].Value = model.Email;
			parameters[9].Value = model.QQ;
			parameters[10].Value = model.TrainCount;
			parameters[11].Value = model.RegDate;
			parameters[12].Value = model.RegFlag;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int CompanyArchiveUserID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_CompanyArchiveUser ");
			strSql.Append(" where CompanyArchiveUserID=@CompanyArchiveUserID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CompanyArchiveUserID", SqlDbType.Int,8)};
			parameters[0].Value = CompanyArchiveUserID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_CompanyArchiveUser_MDL GetModel(int CompanyArchiveUserID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CompanyArchiveUserID,CompanyID,ArchiveUserCode,UserName,Sex,Birthday,Educate,Tel,Email,QQ,TrainCount,RegDate,RegFlag from T_CompanyArchiveUser ");
			strSql.Append(" where CompanyArchiveUserID=@CompanyArchiveUserID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CompanyArchiveUserID", SqlDbType.Int,8)};
			parameters[0].Value = CompanyArchiveUserID;

			DigiPower.Onlinecol.Standard.Model.T_CompanyArchiveUser_MDL model=new DigiPower.Onlinecol.Standard.Model.T_CompanyArchiveUser_MDL();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["CompanyArchiveUserID"].ToString()!="")
				{
					model.CompanyArchiveUserID=int.Parse(ds.Tables[0].Rows[0]["CompanyArchiveUserID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CompanyID"].ToString()!="")
				{
					model.CompanyID=int.Parse(ds.Tables[0].Rows[0]["CompanyID"].ToString());
				}
				model.ArchiveUserCode=ds.Tables[0].Rows[0]["ArchiveUserCode"].ToString();
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				model.Sex=ds.Tables[0].Rows[0]["Sex"].ToString();
				if(ds.Tables[0].Rows[0]["Birthday"].ToString()!="")
				{
					model.Birthday=DateTime.Parse(ds.Tables[0].Rows[0]["Birthday"].ToString());
				}
				model.Educate=ds.Tables[0].Rows[0]["Educate"].ToString();
				model.Tel=ds.Tables[0].Rows[0]["Tel"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				model.QQ=ds.Tables[0].Rows[0]["QQ"].ToString();
				if(ds.Tables[0].Rows[0]["TrainCount"].ToString()!="")
				{
					model.TrainCount=int.Parse(ds.Tables[0].Rows[0]["TrainCount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["RegDate"].ToString()!="")
				{
					model.RegDate=DateTime.Parse(ds.Tables[0].Rows[0]["RegDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["RegFlag"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["RegFlag"].ToString()=="1")||(ds.Tables[0].Rows[0]["RegFlag"].ToString().ToLower()=="true"))
					{
						model.RegFlag=true;
					}
					else
					{
						model.RegFlag=false;
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
			strSql.Append("select CompanyArchiveUserID,CompanyID,ArchiveUserCode,UserName,Sex,Birthday,Educate,Tel,Email,QQ,TrainCount,RegDate,RegFlag ");
			strSql.Append(" FROM T_CompanyArchiveUser ");
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
			strSql.Append(" CompanyArchiveUserID,CompanyID,ArchiveUserCode,UserName,Sex,Birthday,Educate,Tel,Email,QQ,TrainCount,RegDate,RegFlag ");
			strSql.Append(" FROM T_CompanyArchiveUser ");
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
			parameters[0].Value = "T_CompanyArchiveUser";
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

