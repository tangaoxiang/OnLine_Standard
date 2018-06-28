using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL
{
	/// <summary>
	/// 数据访问类T_FileListTmp_CellRptTmp_DAL。
	/// </summary>
	public class T_FileListTmp_CellRptTmp_DAL
	{
		public T_FileListTmp_CellRptTmp_DAL()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("CellReportID", "T_FileListTmp_CellRptTmp"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CellReportID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_FileListTmp_CellRptTmp");
			strSql.Append(" where CellReportID=@CellReportID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CellReportID", SqlDbType.Int,8)};
			parameters[0].Value = CellReportID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DigiPower.Onlinecol.Standard.Model.T_FileListTmp_CellRptTmp_MDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_FileListTmp_CellRptTmp(");
			strSql.Append("recID,Title,CellFilePath,OrderIndex)");
			strSql.Append(" values (");
			strSql.Append("@recID,@Title,@CellFilePath,@OrderIndex)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@recID", SqlDbType.Int,8),
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@CellFilePath", SqlDbType.NVarChar,250),
					new SqlParameter("@OrderIndex", SqlDbType.Int,8)};
			parameters[0].Value = model.recID;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.CellFilePath;
			parameters[3].Value = model.OrderIndex;

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
		public void Update(DigiPower.Onlinecol.Standard.Model.T_FileListTmp_CellRptTmp_MDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_FileListTmp_CellRptTmp set ");
			strSql.Append("recID=@recID,");
			strSql.Append("Title=@Title,");
			strSql.Append("CellFilePath=@CellFilePath,");
			strSql.Append("OrderIndex=@OrderIndex");
			strSql.Append(" where CellReportID=@CellReportID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CellReportID", SqlDbType.Int,8),
					new SqlParameter("@recID", SqlDbType.Int,8),
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@CellFilePath", SqlDbType.NVarChar,250),
					new SqlParameter("@OrderIndex", SqlDbType.Int,8)};
			parameters[0].Value = model.CellReportID;
			parameters[1].Value = model.recID;
			parameters[2].Value = model.Title;
			parameters[3].Value = model.CellFilePath;
			parameters[4].Value = model.OrderIndex;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int CellReportID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_FileListTmp_CellRptTmp ");
			strSql.Append(" where CellReportID=@CellReportID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CellReportID", SqlDbType.Int,8)};
			parameters[0].Value = CellReportID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_FileListTmp_CellRptTmp_MDL GetModel(int CellReportID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CellReportID,recID,Title,CellFilePath,OrderIndex from T_FileListTmp_CellRptTmp ");
			strSql.Append(" where CellReportID=@CellReportID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CellReportID", SqlDbType.Int,8)};
			parameters[0].Value = CellReportID;

			DigiPower.Onlinecol.Standard.Model.T_FileListTmp_CellRptTmp_MDL model=new DigiPower.Onlinecol.Standard.Model.T_FileListTmp_CellRptTmp_MDL();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["CellReportID"].ToString()!="")
				{
					model.CellReportID=int.Parse(ds.Tables[0].Rows[0]["CellReportID"].ToString());
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
			strSql.Append("select CellReportID,recID,Title,CellFilePath,OrderIndex ");
			strSql.Append(" FROM T_FileListTmp_CellRptTmp ");
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
			strSql.Append(" CellReportID,recID,Title,CellFilePath,OrderIndex ");
			strSql.Append(" FROM T_FileListTmp_CellRptTmp ");
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
			parameters[0].Value = "T_FileListTmp_CellRptTmp";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法

        public bool Exists(string sqlWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_FileListTmp_CellRptTmp");
            strSql.Append(" where " + sqlWhere + " ");
            return DbHelperSQL.Exists(strSql.ToString());
        }
	}
}

