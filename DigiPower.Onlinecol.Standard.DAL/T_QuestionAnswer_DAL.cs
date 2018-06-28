using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL
{
	/// <summary>
	/// 数据访问类T_QuestionAnswer_DAL。
	/// </summary>
	public class T_QuestionAnswer_DAL
	{
		public T_QuestionAnswer_DAL()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("AnswerID", "T_QuestionAnswer"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AnswerID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_QuestionAnswer");
			strSql.Append(" where AnswerID=@AnswerID ");
			SqlParameter[] parameters = {
					new SqlParameter("@AnswerID", SqlDbType.Int,8)};
			parameters[0].Value = AnswerID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DigiPower.Onlinecol.Standard.Model.T_QuestionAnswer_MDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_QuestionAnswer(");
			strSql.Append("QuestionID,Description,AnswerUserID,AnswerUserName,AnswerTime,AttachName,AttachPath,ReadFlag)");
			strSql.Append(" values (");
			strSql.Append("@QuestionID,@Description,@AnswerUserID,@AnswerUserName,@AnswerTime,@AttachName,@AttachPath,@ReadFlag)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@QuestionID", SqlDbType.Int,8),
					new SqlParameter("@Description", SqlDbType.NVarChar,4000),
					new SqlParameter("@AnswerUserID", SqlDbType.Int,8),
					new SqlParameter("@AnswerUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@AnswerTime", SqlDbType.DateTime),
					new SqlParameter("@AttachName", SqlDbType.NVarChar,250),
					new SqlParameter("@AttachPath", SqlDbType.NVarChar,250),
					new SqlParameter("@ReadFlag", SqlDbType.Bit,1)};
			parameters[0].Value = model.QuestionID;
			parameters[1].Value = model.Description;
			parameters[2].Value = model.AnswerUserID;
			parameters[3].Value = model.AnswerUserName;
			parameters[4].Value = model.AnswerTime;
			parameters[5].Value = model.AttachName;
			parameters[6].Value = model.AttachPath;
			parameters[7].Value = model.ReadFlag;

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
		public void Update(DigiPower.Onlinecol.Standard.Model.T_QuestionAnswer_MDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_QuestionAnswer set ");
			strSql.Append("QuestionID=@QuestionID,");
			strSql.Append("Description=@Description,");
			strSql.Append("AnswerUserID=@AnswerUserID,");
			strSql.Append("AnswerUserName=@AnswerUserName,");
			strSql.Append("AnswerTime=@AnswerTime,");
			strSql.Append("AttachName=@AttachName,");
			strSql.Append("AttachPath=@AttachPath,");
			strSql.Append("ReadFlag=@ReadFlag");
			strSql.Append(" where AnswerID=@AnswerID ");
			SqlParameter[] parameters = {
					new SqlParameter("@AnswerID", SqlDbType.Int,8),
					new SqlParameter("@QuestionID", SqlDbType.Int,8),
					new SqlParameter("@Description", SqlDbType.NVarChar,4000),
					new SqlParameter("@AnswerUserID", SqlDbType.Int,8),
					new SqlParameter("@AnswerUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@AnswerTime", SqlDbType.DateTime),
					new SqlParameter("@AttachName", SqlDbType.NVarChar,250),
					new SqlParameter("@AttachPath", SqlDbType.NVarChar,250),
					new SqlParameter("@ReadFlag", SqlDbType.Bit,1)};
			parameters[0].Value = model.AnswerID;
			parameters[1].Value = model.QuestionID;
			parameters[2].Value = model.Description;
			parameters[3].Value = model.AnswerUserID;
			parameters[4].Value = model.AnswerUserName;
			parameters[5].Value = model.AnswerTime;
			parameters[6].Value = model.AttachName;
			parameters[7].Value = model.AttachPath;
			parameters[8].Value = model.ReadFlag;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int AnswerID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_QuestionAnswer ");
			strSql.Append(" where AnswerID=@AnswerID ");
			SqlParameter[] parameters = {
					new SqlParameter("@AnswerID", SqlDbType.Int,8)};
			parameters[0].Value = AnswerID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_QuestionAnswer_MDL GetModel(int AnswerID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 AnswerID,QuestionID,Description,AnswerUserID,AnswerUserName,AnswerTime,AttachName,AttachPath,ReadFlag from T_QuestionAnswer ");
			strSql.Append(" where AnswerID=@AnswerID ");
			SqlParameter[] parameters = {
					new SqlParameter("@AnswerID", SqlDbType.Int,8)};
			parameters[0].Value = AnswerID;

			DigiPower.Onlinecol.Standard.Model.T_QuestionAnswer_MDL model=new DigiPower.Onlinecol.Standard.Model.T_QuestionAnswer_MDL();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["AnswerID"].ToString()!="")
				{
					model.AnswerID=int.Parse(ds.Tables[0].Rows[0]["AnswerID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["QuestionID"].ToString()!="")
				{
					model.QuestionID=int.Parse(ds.Tables[0].Rows[0]["QuestionID"].ToString());
				}
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				if(ds.Tables[0].Rows[0]["AnswerUserID"].ToString()!="")
				{
					model.AnswerUserID=int.Parse(ds.Tables[0].Rows[0]["AnswerUserID"].ToString());
				}
				model.AnswerUserName=ds.Tables[0].Rows[0]["AnswerUserName"].ToString();
				if(ds.Tables[0].Rows[0]["AnswerTime"].ToString()!="")
				{
					model.AnswerTime=DateTime.Parse(ds.Tables[0].Rows[0]["AnswerTime"].ToString());
				}
				model.AttachName=ds.Tables[0].Rows[0]["AttachName"].ToString();
				model.AttachPath=ds.Tables[0].Rows[0]["AttachPath"].ToString();
				if(ds.Tables[0].Rows[0]["ReadFlag"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["ReadFlag"].ToString()=="1")||(ds.Tables[0].Rows[0]["ReadFlag"].ToString().ToLower()=="true"))
					{
						model.ReadFlag=true;
					}
					else
					{
						model.ReadFlag=false;
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
			strSql.Append("select AnswerID,QuestionID,Description,AnswerUserID,AnswerUserName,AnswerTime,AttachName,AttachPath,ReadFlag ");
			strSql.Append(" FROM T_QuestionAnswer ");
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
			strSql.Append(" AnswerID,QuestionID,Description,AnswerUserID,AnswerUserName,AnswerTime,AttachName,AttachPath,ReadFlag ");
			strSql.Append(" FROM T_QuestionAnswer ");
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
			parameters[0].Value = "T_QuestionAnswer";
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

