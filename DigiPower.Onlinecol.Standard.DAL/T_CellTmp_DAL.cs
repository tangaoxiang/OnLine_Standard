using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL
{
	/// <summary>
	/// 数据访问类T_CellTmp_DAL。
	/// </summary>
	public class T_CellTmp_DAL
	{
		public T_CellTmp_DAL()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("CellID", "T_CellTmp"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CellID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_CellTmp");
			strSql.Append(" where CellID=@CellID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CellID", SqlDbType.Int,8)};
			parameters[0].Value = CellID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DigiPower.Onlinecol.Standard.Model.T_CellTmp_MDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_CellTmp(");
			strSql.Append("PID,Title,FilePath,OrderIndex,JSDWExpire,SGDWExpire,SJDWExpire,JLDWExpire,NeedArchive,MJ,IsVisible,IsFolder,MyCode,PID1)");
			strSql.Append(" values (");
			strSql.Append("@PID,@Title,@FilePath,@OrderIndex,@JSDWExpire,@SGDWExpire,@SJDWExpire,@JLDWExpire,@NeedArchive,@MJ,@IsVisible,@IsFolder,@MyCode,@PID1)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PID", SqlDbType.Int,8),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@FilePath", SqlDbType.NVarChar,250),
					new SqlParameter("@OrderIndex", SqlDbType.Int,8),
					new SqlParameter("@JSDWExpire", SqlDbType.NVarChar,10),
					new SqlParameter("@SGDWExpire", SqlDbType.NVarChar,50),
					new SqlParameter("@SJDWExpire", SqlDbType.NVarChar,50),
					new SqlParameter("@JLDWExpire", SqlDbType.NVarChar,50),
					new SqlParameter("@NeedArchive", SqlDbType.Bit,1),
					new SqlParameter("@MJ", SqlDbType.NVarChar,50),
					new SqlParameter("@IsVisible", SqlDbType.Bit,1),
					new SqlParameter("@IsFolder", SqlDbType.Bit,1),
					new SqlParameter("@MyCode", SqlDbType.NVarChar,50),
					new SqlParameter("@PID1", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.PID;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.FilePath;
			parameters[3].Value = model.OrderIndex;
			parameters[4].Value = model.JSDWExpire;
			parameters[5].Value = model.SGDWExpire;
			parameters[6].Value = model.SJDWExpire;
			parameters[7].Value = model.JLDWExpire;
			parameters[8].Value = model.NeedArchive;
			parameters[9].Value = model.MJ;
			parameters[10].Value = model.IsVisible;
			parameters[11].Value = model.IsFolder;
			parameters[12].Value = model.MyCode;
			parameters[13].Value = model.PID1;

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
		public void Update(DigiPower.Onlinecol.Standard.Model.T_CellTmp_MDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_CellTmp set ");
			strSql.Append("PID=@PID,");
			strSql.Append("Title=@Title,");
			strSql.Append("FilePath=@FilePath,");
			strSql.Append("OrderIndex=@OrderIndex,");
			strSql.Append("JSDWExpire=@JSDWExpire,");
			strSql.Append("SGDWExpire=@SGDWExpire,");
			strSql.Append("SJDWExpire=@SJDWExpire,");
			strSql.Append("JLDWExpire=@JLDWExpire,");
			strSql.Append("NeedArchive=@NeedArchive,");
			strSql.Append("MJ=@MJ,");
			strSql.Append("IsVisible=@IsVisible,");
			strSql.Append("IsFolder=@IsFolder,");
			strSql.Append("MyCode=@MyCode,");
			strSql.Append("PID1=@PID1");
			strSql.Append(" where CellID=@CellID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CellID", SqlDbType.Int,8),
					new SqlParameter("@PID", SqlDbType.Int,8),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@FilePath", SqlDbType.NVarChar,250),
					new SqlParameter("@OrderIndex", SqlDbType.Int,8),
					new SqlParameter("@JSDWExpire", SqlDbType.NVarChar,10),
					new SqlParameter("@SGDWExpire", SqlDbType.NVarChar,50),
					new SqlParameter("@SJDWExpire", SqlDbType.NVarChar,50),
					new SqlParameter("@JLDWExpire", SqlDbType.NVarChar,50),
					new SqlParameter("@NeedArchive", SqlDbType.Bit,1),
					new SqlParameter("@MJ", SqlDbType.NVarChar,50),
					new SqlParameter("@IsVisible", SqlDbType.Bit,1),
					new SqlParameter("@IsFolder", SqlDbType.Bit,1),
					new SqlParameter("@MyCode", SqlDbType.NVarChar,50),
					new SqlParameter("@PID1", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.CellID;
			parameters[1].Value = model.PID;
			parameters[2].Value = model.Title;
			parameters[3].Value = model.FilePath;
			parameters[4].Value = model.OrderIndex;
			parameters[5].Value = model.JSDWExpire;
			parameters[6].Value = model.SGDWExpire;
			parameters[7].Value = model.SJDWExpire;
			parameters[8].Value = model.JLDWExpire;
			parameters[9].Value = model.NeedArchive;
			parameters[10].Value = model.MJ;
			parameters[11].Value = model.IsVisible;
			parameters[12].Value = model.IsFolder;
			parameters[13].Value = model.MyCode;
			parameters[14].Value = model.PID1;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int CellID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_CellTmp ");
			strSql.Append(" where CellID=@CellID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CellID", SqlDbType.Int,8)};
			parameters[0].Value = CellID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_CellTmp_MDL GetModel(int CellID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CellID,PID,Title,FilePath,OrderIndex,JSDWExpire,SGDWExpire,SJDWExpire,JLDWExpire,NeedArchive,MJ,IsVisible,IsFolder,MyCode,PID1 from T_CellTmp ");
			strSql.Append(" where CellID=@CellID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CellID", SqlDbType.Int,8)};
			parameters[0].Value = CellID;

			DigiPower.Onlinecol.Standard.Model.T_CellTmp_MDL model=new DigiPower.Onlinecol.Standard.Model.T_CellTmp_MDL();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["CellID"].ToString()!="")
				{
					model.CellID=int.Parse(ds.Tables[0].Rows[0]["CellID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PID"].ToString()!="")
				{
					model.PID=int.Parse(ds.Tables[0].Rows[0]["PID"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.FilePath=ds.Tables[0].Rows[0]["FilePath"].ToString();
				if(ds.Tables[0].Rows[0]["OrderIndex"].ToString()!="")
				{
					model.OrderIndex=int.Parse(ds.Tables[0].Rows[0]["OrderIndex"].ToString());
				}
				model.JSDWExpire=ds.Tables[0].Rows[0]["JSDWExpire"].ToString();
				model.SGDWExpire=ds.Tables[0].Rows[0]["SGDWExpire"].ToString();
				model.SJDWExpire=ds.Tables[0].Rows[0]["SJDWExpire"].ToString();
				model.JLDWExpire=ds.Tables[0].Rows[0]["JLDWExpire"].ToString();
				if(ds.Tables[0].Rows[0]["NeedArchive"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["NeedArchive"].ToString()=="1")||(ds.Tables[0].Rows[0]["NeedArchive"].ToString().ToLower()=="true"))
					{
						model.NeedArchive=true;
					}
					else
					{
						model.NeedArchive=false;
					}
				}
				model.MJ=ds.Tables[0].Rows[0]["MJ"].ToString();
				if(ds.Tables[0].Rows[0]["IsVisible"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["IsVisible"].ToString()=="1")||(ds.Tables[0].Rows[0]["IsVisible"].ToString().ToLower()=="true"))
					{
						model.IsVisible=true;
					}
					else
					{
						model.IsVisible=false;
					}
				}
				if(ds.Tables[0].Rows[0]["IsFolder"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["IsFolder"].ToString()=="1")||(ds.Tables[0].Rows[0]["IsFolder"].ToString().ToLower()=="true"))
					{
						model.IsFolder=true;
					}
					else
					{
						model.IsFolder=false;
					}
				}
				model.MyCode=ds.Tables[0].Rows[0]["MyCode"].ToString();
				model.PID1=ds.Tables[0].Rows[0]["PID1"].ToString();
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
			strSql.Append("select CellID,PID,Title,FilePath,OrderIndex,JSDWExpire,SGDWExpire,SJDWExpire,JLDWExpire,NeedArchive,MJ,IsVisible,IsFolder,MyCode,PID1 ");
			strSql.Append(" FROM T_CellTmp ");
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
			strSql.Append(" CellID,PID,Title,FilePath,OrderIndex,JSDWExpire,SGDWExpire,SJDWExpire,JLDWExpire,NeedArchive,MJ,IsVisible,IsFolder,MyCode,PID1 ");
			strSql.Append(" FROM T_CellTmp ");
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
			parameters[0].Value = "T_CellTmp";
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

