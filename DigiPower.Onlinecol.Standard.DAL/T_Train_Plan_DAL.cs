using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL
{
	/// <summary>
	/// 数据访问类T_Train_Plan_DAL。
	/// </summary>
	public class T_Train_Plan_DAL
	{
		public T_Train_Plan_DAL()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("TrainPlanID", "T_Train_Plan"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int TrainPlanID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Train_Plan");
			strSql.Append(" where TrainPlanID=@TrainPlanID ");
			SqlParameter[] parameters = {
					new SqlParameter("@TrainPlanID", SqlDbType.Int,8)};
			parameters[0].Value = TrainPlanID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DigiPower.Onlinecol.Standard.Model.T_Train_Plan_MDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Train_Plan(");
			strSql.Append("Subject,Teacher,PlanDate,FinishDate,PlanUserName)");
			strSql.Append(" values (");
			strSql.Append("@Subject,@Teacher,@PlanDate,@FinishDate,@PlanUserName)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Subject", SqlDbType.NVarChar,200),
					new SqlParameter("@Teacher", SqlDbType.NVarChar,50),
					new SqlParameter("@PlanDate", SqlDbType.DateTime),
					new SqlParameter("@FinishDate", SqlDbType.DateTime),
					new SqlParameter("@PlanUserName", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.Subject;
			parameters[1].Value = model.Teacher;
			parameters[2].Value = model.PlanDate;
			parameters[3].Value = model.FinishDate;
			parameters[4].Value = model.PlanUserName;

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
		public void Update(DigiPower.Onlinecol.Standard.Model.T_Train_Plan_MDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Train_Plan set ");
			strSql.Append("Subject=@Subject,");
			strSql.Append("Teacher=@Teacher,");
			strSql.Append("PlanDate=@PlanDate,");
			strSql.Append("FinishDate=@FinishDate,");
			strSql.Append("PlanUserName=@PlanUserName");
			strSql.Append(" where TrainPlanID=@TrainPlanID ");
			SqlParameter[] parameters = {
					new SqlParameter("@TrainPlanID", SqlDbType.Int,8),
					new SqlParameter("@Subject", SqlDbType.NVarChar,200),
					new SqlParameter("@Teacher", SqlDbType.NVarChar,50),
					new SqlParameter("@PlanDate", SqlDbType.DateTime),
					new SqlParameter("@FinishDate", SqlDbType.DateTime),
					new SqlParameter("@PlanUserName", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.TrainPlanID;
			parameters[1].Value = model.Subject;
			parameters[2].Value = model.Teacher;
			parameters[3].Value = model.PlanDate;
			parameters[4].Value = model.FinishDate;
			parameters[5].Value = model.PlanUserName;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int TrainPlanID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Train_Plan ");
			strSql.Append(" where TrainPlanID=@TrainPlanID ");
			SqlParameter[] parameters = {
					new SqlParameter("@TrainPlanID", SqlDbType.Int,8)};
			parameters[0].Value = TrainPlanID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_Train_Plan_MDL GetModel(int TrainPlanID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 TrainPlanID,Subject,Teacher,PlanDate,FinishDate,PlanUserName from T_Train_Plan ");
			strSql.Append(" where TrainPlanID=@TrainPlanID ");
			SqlParameter[] parameters = {
					new SqlParameter("@TrainPlanID", SqlDbType.Int,8)};
			parameters[0].Value = TrainPlanID;

			DigiPower.Onlinecol.Standard.Model.T_Train_Plan_MDL model=new DigiPower.Onlinecol.Standard.Model.T_Train_Plan_MDL();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["TrainPlanID"].ToString()!="")
				{
					model.TrainPlanID=int.Parse(ds.Tables[0].Rows[0]["TrainPlanID"].ToString());
				}
				model.Subject=ds.Tables[0].Rows[0]["Subject"].ToString();
				model.Teacher=ds.Tables[0].Rows[0]["Teacher"].ToString();
				if(ds.Tables[0].Rows[0]["PlanDate"].ToString()!="")
				{
					model.PlanDate=DateTime.Parse(ds.Tables[0].Rows[0]["PlanDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FinishDate"].ToString()!="")
				{
					model.FinishDate=DateTime.Parse(ds.Tables[0].Rows[0]["FinishDate"].ToString());
				}
				model.PlanUserName=ds.Tables[0].Rows[0]["PlanUserName"].ToString();
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
			strSql.Append("select TrainPlanID,Subject,Teacher,PlanDate,FinishDate,PlanUserName ");
			strSql.Append(" FROM T_Train_Plan ");
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
			strSql.Append(" TrainPlanID,Subject,Teacher,PlanDate,FinishDate,PlanUserName ");
			strSql.Append(" FROM T_Train_Plan ");
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
			parameters[0].Value = "T_Train_Plan";
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

