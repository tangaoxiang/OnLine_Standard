using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL
{
	/// <summary>
	/// 数据访问类T_DefineReult_DAL。
	/// </summary>
	public class T_DefineReult_DAL
	{
		public T_DefineReult_DAL()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("DefineResultID", "T_DefineReult"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int DefineResultID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_DefineReult");
			strSql.Append(" where DefineResultID=@DefineResultID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DefineResultID", SqlDbType.Int,8)};
			parameters[0].Value = DefineResultID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DigiPower.Onlinecol.Standard.Model.T_DefineReult_MDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_DefineReult(");
			strSql.Append("CanDefineTypeID,OrderIndex,SplitID,FileType_DEL,CutLength)");
			strSql.Append(" values (");
			strSql.Append("@CanDefineTypeID,@OrderIndex,@SplitID,@FileType_DEL,@CutLength)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CanDefineTypeID", SqlDbType.Int,8),
					new SqlParameter("@OrderIndex", SqlDbType.Int,8),
					new SqlParameter("@SplitID", SqlDbType.Int,8),
					new SqlParameter("@FileType_DEL", SqlDbType.NVarChar,50),
					new SqlParameter("@CutLength", SqlDbType.Int,8)};
			parameters[0].Value = model.CanDefineTypeID;
			parameters[1].Value = model.OrderIndex;
			parameters[2].Value = model.SplitID;
			parameters[3].Value = model.FileType_DEL;
			parameters[4].Value = model.CutLength;

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
		public void Update(DigiPower.Onlinecol.Standard.Model.T_DefineReult_MDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_DefineReult set ");
			strSql.Append("CanDefineTypeID=@CanDefineTypeID,");
			strSql.Append("OrderIndex=@OrderIndex,");
			strSql.Append("SplitID=@SplitID,");
			strSql.Append("FileType_DEL=@FileType_DEL,");
			strSql.Append("CutLength=@CutLength");
			strSql.Append(" where DefineResultID=@DefineResultID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DefineResultID", SqlDbType.Int,8),
					new SqlParameter("@CanDefineTypeID", SqlDbType.Int,8),
					new SqlParameter("@OrderIndex", SqlDbType.Int,8),
					new SqlParameter("@SplitID", SqlDbType.Int,8),
					new SqlParameter("@FileType_DEL", SqlDbType.NVarChar,50),
					new SqlParameter("@CutLength", SqlDbType.Int,8)};
			parameters[0].Value = model.DefineResultID;
			parameters[1].Value = model.CanDefineTypeID;
			parameters[2].Value = model.OrderIndex;
			parameters[3].Value = model.SplitID;
			parameters[4].Value = model.FileType_DEL;
			parameters[5].Value = model.CutLength;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int DefineResultID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_DefineReult ");
			strSql.Append(" where DefineResultID=@DefineResultID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DefineResultID", SqlDbType.Int,8)};
			parameters[0].Value = DefineResultID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_DefineReult_MDL GetModel(int DefineResultID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 DefineResultID,CanDefineTypeID,OrderIndex,SplitID,FileType_DEL,CutLength from T_DefineReult ");
			strSql.Append(" where DefineResultID=@DefineResultID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DefineResultID", SqlDbType.Int,8)};
			parameters[0].Value = DefineResultID;

			DigiPower.Onlinecol.Standard.Model.T_DefineReult_MDL model=new DigiPower.Onlinecol.Standard.Model.T_DefineReult_MDL();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["DefineResultID"].ToString()!="")
				{
					model.DefineResultID=int.Parse(ds.Tables[0].Rows[0]["DefineResultID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CanDefineTypeID"].ToString()!="")
				{
					model.CanDefineTypeID=int.Parse(ds.Tables[0].Rows[0]["CanDefineTypeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OrderIndex"].ToString()!="")
				{
					model.OrderIndex=int.Parse(ds.Tables[0].Rows[0]["OrderIndex"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SplitID"].ToString()!="")
				{
					model.SplitID=int.Parse(ds.Tables[0].Rows[0]["SplitID"].ToString());
				}
				model.FileType_DEL=ds.Tables[0].Rows[0]["FileType_DEL"].ToString();
				if(ds.Tables[0].Rows[0]["CutLength"].ToString()!="")
				{
					model.CutLength=int.Parse(ds.Tables[0].Rows[0]["CutLength"].ToString());
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
			strSql.Append("select DefineResultID,CanDefineTypeID,OrderIndex,SplitID,FileType_DEL,CutLength ");
			strSql.Append(" FROM T_DefineReult ");
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
			strSql.Append(" DefineResultID,CanDefineTypeID,OrderIndex,SplitID,FileType_DEL,CutLength ");
			strSql.Append(" FROM T_DefineReult ");
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
			parameters[0].Value = "T_DefineReult";
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

