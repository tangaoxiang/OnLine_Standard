using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL
{
	/// <summary>
	/// 数据访问类T_CanDefineType_DAL。
	/// </summary>
	public class T_CanDefineType_DAL
	{
		public T_CanDefineType_DAL()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CanDefineTypeID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_CanDefineType");
			strSql.Append(" where CanDefineTypeID=@CanDefineTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CanDefineTypeID", SqlDbType.Int,8)};
			parameters[0].Value = CanDefineTypeID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DigiPower.Onlinecol.Standard.Model.T_CanDefineType_MDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_CanDefineType(");
			strSql.Append("Area_Code,MediaTypeID,DefineTypeID,FieldDefineID,Enable)");
			strSql.Append(" values (");
			strSql.Append("@Area_Code,@MediaTypeID,@DefineTypeID,@FieldDefineID,@Enable)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Area_Code", SqlDbType.NVarChar,50),
					new SqlParameter("@MediaTypeID", SqlDbType.Int,8),
					new SqlParameter("@DefineTypeID", SqlDbType.Int,8),
					new SqlParameter("@FieldDefineID", SqlDbType.Int,8),
					new SqlParameter("@Enable", SqlDbType.Bit,1)};
			parameters[0].Value = model.Area_Code;
			parameters[1].Value = model.MediaTypeID;
			parameters[2].Value = model.DefineTypeID;
			parameters[3].Value = model.FieldDefineID;
			parameters[4].Value = model.Enable;

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
		public void Update(DigiPower.Onlinecol.Standard.Model.T_CanDefineType_MDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_CanDefineType set ");
			strSql.Append("Area_Code=@Area_Code,");
			strSql.Append("MediaTypeID=@MediaTypeID,");
			strSql.Append("DefineTypeID=@DefineTypeID,");
			strSql.Append("FieldDefineID=@FieldDefineID,");
			strSql.Append("Enable=@Enable");
			strSql.Append(" where CanDefineTypeID=@CanDefineTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CanDefineTypeID", SqlDbType.Int,8),
					new SqlParameter("@Area_Code", SqlDbType.NVarChar,50),
					new SqlParameter("@MediaTypeID", SqlDbType.Int,8),
					new SqlParameter("@DefineTypeID", SqlDbType.Int,8),
					new SqlParameter("@FieldDefineID", SqlDbType.Int,8),
					new SqlParameter("@Enable", SqlDbType.Bit,1)};
			parameters[0].Value = model.CanDefineTypeID;
			parameters[1].Value = model.Area_Code;
			parameters[2].Value = model.MediaTypeID;
			parameters[3].Value = model.DefineTypeID;
			parameters[4].Value = model.FieldDefineID;
			parameters[5].Value = model.Enable;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int CanDefineTypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_CanDefineType ");
			strSql.Append(" where CanDefineTypeID=@CanDefineTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CanDefineTypeID", SqlDbType.Int,8)};
			parameters[0].Value = CanDefineTypeID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_CanDefineType_MDL GetModel(int CanDefineTypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CanDefineTypeID,Area_Code,MediaTypeID,DefineTypeID,FieldDefineID,Enable from T_CanDefineType ");
			strSql.Append(" where CanDefineTypeID=@CanDefineTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CanDefineTypeID", SqlDbType.Int,8)};
			parameters[0].Value = CanDefineTypeID;

			DigiPower.Onlinecol.Standard.Model.T_CanDefineType_MDL model=new DigiPower.Onlinecol.Standard.Model.T_CanDefineType_MDL();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["CanDefineTypeID"].ToString()!="")
				{
					model.CanDefineTypeID=int.Parse(ds.Tables[0].Rows[0]["CanDefineTypeID"].ToString());
				}
				model.Area_Code=ds.Tables[0].Rows[0]["Area_Code"].ToString();
				if(ds.Tables[0].Rows[0]["MediaTypeID"].ToString()!="")
				{
					model.MediaTypeID=int.Parse(ds.Tables[0].Rows[0]["MediaTypeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DefineTypeID"].ToString()!="")
				{
					model.DefineTypeID=int.Parse(ds.Tables[0].Rows[0]["DefineTypeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FieldDefineID"].ToString()!="")
				{
					model.FieldDefineID=int.Parse(ds.Tables[0].Rows[0]["FieldDefineID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Enable"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Enable"].ToString()=="1")||(ds.Tables[0].Rows[0]["Enable"].ToString().ToLower()=="true"))
					{
						model.Enable=true;
					}
					else
					{
						model.Enable=false;
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
			strSql.Append("select CanDefineTypeID,Area_Code,MediaTypeID,DefineTypeID,FieldDefineID,Enable ");
			strSql.Append(" FROM T_CanDefineType ");
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
			strSql.Append(" CanDefineTypeID,Area_Code,MediaTypeID,DefineTypeID,FieldDefineID,Enable ");
			strSql.Append(" FROM T_CanDefineType ");
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
			parameters[0].Value = "T_CanDefineType";
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

