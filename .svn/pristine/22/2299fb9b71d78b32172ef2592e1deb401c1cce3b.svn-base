using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL
{
	/// <summary>
	/// 数据访问类T_FileList_CellRpt_DAL。
	/// </summary>
	public class T_FileList_CellRpt_DAL
	{
		public T_FileList_CellRpt_DAL()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("FileList_CellRptID", "T_FileList_CellRpt"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int FileList_CellRptID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_FileList_CellRpt");
			strSql.Append(" where FileList_CellRptID=@FileList_CellRptID ");
			SqlParameter[] parameters = {
					new SqlParameter("@FileList_CellRptID", SqlDbType.Int,8)};
			parameters[0].Value = FileList_CellRptID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DigiPower.Onlinecol.Standard.Model.T_FileList_CellRpt_MDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_FileList_CellRpt(");
			strSql.Append("FileListID,recID,Title,CellFilePath,OrderIndex)");
			strSql.Append(" values (");
			strSql.Append("@FileListID,@recID,@Title,@CellFilePath,@OrderIndex)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@FileListID", SqlDbType.Int,8),
					new SqlParameter("@recID", SqlDbType.Int,8),
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@CellFilePath", SqlDbType.NVarChar,250),
					new SqlParameter("@OrderIndex", SqlDbType.Int,8)};
			parameters[0].Value = model.FileListID;
			parameters[1].Value = model.recID;
			parameters[2].Value = model.Title;
			parameters[3].Value = model.CellFilePath;
			parameters[4].Value = model.OrderIndex;

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
		public void Update(DigiPower.Onlinecol.Standard.Model.T_FileList_CellRpt_MDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_FileList_CellRpt set ");
			strSql.Append("FileListID=@FileListID,");
			strSql.Append("recID=@recID,");
			strSql.Append("Title=@Title,");
			strSql.Append("CellFilePath=@CellFilePath,");
			strSql.Append("OrderIndex=@OrderIndex");
			strSql.Append(" where FileList_CellRptID=@FileList_CellRptID ");
			SqlParameter[] parameters = {
					new SqlParameter("@FileList_CellRptID", SqlDbType.Int,8),
					new SqlParameter("@FileListID", SqlDbType.Int,8),
					new SqlParameter("@recID", SqlDbType.Int,8),
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@CellFilePath", SqlDbType.NVarChar,250),
					new SqlParameter("@OrderIndex", SqlDbType.Int,8)};
			parameters[0].Value = model.FileList_CellRptID;
			parameters[1].Value = model.FileListID;
			parameters[2].Value = model.recID;
			parameters[3].Value = model.Title;
			parameters[4].Value = model.CellFilePath;
			parameters[5].Value = model.OrderIndex;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int FileList_CellRptID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_FileList_CellRpt ");
			strSql.Append(" where FileList_CellRptID=@FileList_CellRptID ");
			SqlParameter[] parameters = {
					new SqlParameter("@FileList_CellRptID", SqlDbType.Int,8)};
			parameters[0].Value = FileList_CellRptID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_FileList_CellRpt_MDL GetModel(int FileList_CellRptID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FileList_CellRptID,FileListID,recID,Title,CellFilePath,OrderIndex from T_FileList_CellRpt ");
			strSql.Append(" where FileList_CellRptID=@FileList_CellRptID ");
			SqlParameter[] parameters = {
					new SqlParameter("@FileList_CellRptID", SqlDbType.Int,8)};
			parameters[0].Value = FileList_CellRptID;

			DigiPower.Onlinecol.Standard.Model.T_FileList_CellRpt_MDL model=new DigiPower.Onlinecol.Standard.Model.T_FileList_CellRpt_MDL();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["FileList_CellRptID"].ToString()!="")
				{
					model.FileList_CellRptID=int.Parse(ds.Tables[0].Rows[0]["FileList_CellRptID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FileListID"].ToString()!="")
				{
					model.FileListID=int.Parse(ds.Tables[0].Rows[0]["FileListID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["recID"].ToString()!="")
				{
					model.recID=int.Parse(ds.Tables[0].Rows[0]["recID"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.CellFilePath=ds.Tables[0].Rows[0]["CellFilePath"].ToString();
				if(ds.Tables[0].Rows[0]["OrderIndex"].ToString()!="")
				{
					model.OrderIndex=int.Parse(ds.Tables[0].Rows[0]["OrderIndex"].ToString());
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
			strSql.Append("select FileList_CellRptID,FileListID,recID,Title,CellFilePath,OrderIndex ");
			strSql.Append(" FROM T_FileList_CellRpt ");
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
			strSql.Append(" FileList_CellRptID,FileListID,recID,Title,CellFilePath,OrderIndex ");
			strSql.Append(" FROM T_FileList_CellRpt ");
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
			parameters[0].Value = "T_FileList_CellRpt";
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

