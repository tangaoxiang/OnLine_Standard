using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL
{
	/// <summary>
	/// 数据访问类T_FieldDefine_DAL。
	/// </summary>
	public class T_FieldDefine_DAL
	{
		public T_FieldDefine_DAL()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("FieldDefineID", "T_FieldDefine"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int FieldDefineID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_FieldDefine");
			strSql.Append(" where FieldDefineID=@FieldDefineID ");
			SqlParameter[] parameters = {
					new SqlParameter("@FieldDefineID", SqlDbType.Int,8)};
			parameters[0].Value = FieldDefineID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DigiPower.Onlinecol.Standard.Model.T_FieldDefine_MDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_FieldDefine(");
			strSql.Append("TableName,FieldName,ShowName,StartLocation,EndLocation,IsSerial)");
			strSql.Append(" values (");
			strSql.Append("@TableName,@FieldName,@ShowName,@StartLocation,@EndLocation,@IsSerial)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@TableName", SqlDbType.NVarChar,50),
					new SqlParameter("@FieldName", SqlDbType.NVarChar,50),
					new SqlParameter("@ShowName", SqlDbType.NVarChar,50),
					new SqlParameter("@StartLocation", SqlDbType.Int,8),
					new SqlParameter("@EndLocation", SqlDbType.Int,8),
					new SqlParameter("@IsSerial", SqlDbType.Bit,1)};
			parameters[0].Value = model.TableName;
			parameters[1].Value = model.FieldName;
			parameters[2].Value = model.ShowName;
			parameters[3].Value = model.StartLocation;
			parameters[4].Value = model.EndLocation;
			parameters[5].Value = model.IsSerial;

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
		public void Update(DigiPower.Onlinecol.Standard.Model.T_FieldDefine_MDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_FieldDefine set ");
			strSql.Append("TableName=@TableName,");
			strSql.Append("FieldName=@FieldName,");
			strSql.Append("ShowName=@ShowName,");
			strSql.Append("StartLocation=@StartLocation,");
			strSql.Append("EndLocation=@EndLocation,");
			strSql.Append("IsSerial=@IsSerial");
			strSql.Append(" where FieldDefineID=@FieldDefineID ");
			SqlParameter[] parameters = {
					new SqlParameter("@FieldDefineID", SqlDbType.Int,8),
					new SqlParameter("@TableName", SqlDbType.NVarChar,50),
					new SqlParameter("@FieldName", SqlDbType.NVarChar,50),
					new SqlParameter("@ShowName", SqlDbType.NVarChar,50),
					new SqlParameter("@StartLocation", SqlDbType.Int,8),
					new SqlParameter("@EndLocation", SqlDbType.Int,8),
					new SqlParameter("@IsSerial", SqlDbType.Bit,1)};
			parameters[0].Value = model.FieldDefineID;
			parameters[1].Value = model.TableName;
			parameters[2].Value = model.FieldName;
			parameters[3].Value = model.ShowName;
			parameters[4].Value = model.StartLocation;
			parameters[5].Value = model.EndLocation;
			parameters[6].Value = model.IsSerial;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int FieldDefineID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_FieldDefine ");
			strSql.Append(" where FieldDefineID=@FieldDefineID ");
			SqlParameter[] parameters = {
					new SqlParameter("@FieldDefineID", SqlDbType.Int,8)};
			parameters[0].Value = FieldDefineID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_FieldDefine_MDL GetModel(int FieldDefineID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FieldDefineID,TableName,FieldName,ShowName,StartLocation,EndLocation,IsSerial from T_FieldDefine ");
			strSql.Append(" where FieldDefineID=@FieldDefineID ");
			SqlParameter[] parameters = {
					new SqlParameter("@FieldDefineID", SqlDbType.Int,8)};
			parameters[0].Value = FieldDefineID;

			DigiPower.Onlinecol.Standard.Model.T_FieldDefine_MDL model=new DigiPower.Onlinecol.Standard.Model.T_FieldDefine_MDL();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["FieldDefineID"].ToString()!="")
				{
					model.FieldDefineID=int.Parse(ds.Tables[0].Rows[0]["FieldDefineID"].ToString());
				}
				model.TableName=ds.Tables[0].Rows[0]["TableName"].ToString();
				model.FieldName=ds.Tables[0].Rows[0]["FieldName"].ToString();
				model.ShowName=ds.Tables[0].Rows[0]["ShowName"].ToString();
				if(ds.Tables[0].Rows[0]["StartLocation"].ToString()!="")
				{
					model.StartLocation=int.Parse(ds.Tables[0].Rows[0]["StartLocation"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EndLocation"].ToString()!="")
				{
					model.EndLocation=int.Parse(ds.Tables[0].Rows[0]["EndLocation"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsSerial"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["IsSerial"].ToString()=="1")||(ds.Tables[0].Rows[0]["IsSerial"].ToString().ToLower()=="true"))
					{
						model.IsSerial=true;
					}
					else
					{
						model.IsSerial=false;
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
			strSql.Append("select FieldDefineID,TableName,FieldName,ShowName,StartLocation,EndLocation,IsSerial ");
			strSql.Append(" FROM T_FieldDefine ");
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
			strSql.Append(" FieldDefineID,TableName,FieldName,ShowName,StartLocation,EndLocation,IsSerial ");
			strSql.Append(" FROM T_FieldDefine ");
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
			parameters[0].Value = "T_FieldDefine";
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

