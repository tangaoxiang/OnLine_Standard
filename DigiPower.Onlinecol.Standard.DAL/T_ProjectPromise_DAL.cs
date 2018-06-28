using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL
{
	/// <summary>
	/// 数据访问类T_ProjectPromise_DAL。
	/// </summary>
	public class T_ProjectPromise_DAL
	{
		public T_ProjectPromise_DAL()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "T_ProjectPromise"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_ProjectPromise");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,8)};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DigiPower.Onlinecol.Standard.Model.T_ProjectPromise_MDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_ProjectPromise(");
			strSql.Append("ProjectID,ContactPerson,Tel,Mobile,InContactPerson,InTel,InMobile,CreateDate,ExpireDate,PromiseNO)");
			strSql.Append(" values (");
			strSql.Append("@ProjectID,@ContactPerson,@Tel,@Mobile,@InContactPerson,@InTel,@InMobile,@CreateDate,@ExpireDate,@PromiseNO)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ProjectID", SqlDbType.Int,8),
					new SqlParameter("@ContactPerson", SqlDbType.NVarChar,20),
					new SqlParameter("@Tel", SqlDbType.NVarChar,20),
					new SqlParameter("@Mobile", SqlDbType.NVarChar,20),
					new SqlParameter("@InContactPerson", SqlDbType.NVarChar,20),
					new SqlParameter("@InTel", SqlDbType.NVarChar,20),
					new SqlParameter("@InMobile", SqlDbType.NVarChar,20),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@ExpireDate", SqlDbType.DateTime),
					new SqlParameter("@PromiseNO", SqlDbType.NVarChar,20)};
			parameters[0].Value = model.ProjectID;
			parameters[1].Value = model.ContactPerson;
			parameters[2].Value = model.Tel;
			parameters[3].Value = model.Mobile;
			parameters[4].Value = model.InContactPerson;
			parameters[5].Value = model.InTel;
			parameters[6].Value = model.InMobile;
			parameters[7].Value = model.CreateDate;
			parameters[8].Value = model.ExpireDate;
			parameters[9].Value = model.PromiseNO;

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
		public void Update(DigiPower.Onlinecol.Standard.Model.T_ProjectPromise_MDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_ProjectPromise set ");
			strSql.Append("ProjectID=@ProjectID,");
			strSql.Append("ContactPerson=@ContactPerson,");
			strSql.Append("Tel=@Tel,");
			strSql.Append("Mobile=@Mobile,");
			strSql.Append("InContactPerson=@InContactPerson,");
			strSql.Append("InTel=@InTel,");
			strSql.Append("InMobile=@InMobile,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("ExpireDate=@ExpireDate,");
			strSql.Append("PromiseNO=@PromiseNO");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,8),
					new SqlParameter("@ProjectID", SqlDbType.Int,8),
					new SqlParameter("@ContactPerson", SqlDbType.NVarChar,20),
					new SqlParameter("@Tel", SqlDbType.NVarChar,20),
					new SqlParameter("@Mobile", SqlDbType.NVarChar,20),
					new SqlParameter("@InContactPerson", SqlDbType.NVarChar,20),
					new SqlParameter("@InTel", SqlDbType.NVarChar,20),
					new SqlParameter("@InMobile", SqlDbType.NVarChar,20),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@ExpireDate", SqlDbType.DateTime),
					new SqlParameter("@PromiseNO", SqlDbType.NVarChar,20)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.ProjectID;
			parameters[2].Value = model.ContactPerson;
			parameters[3].Value = model.Tel;
			parameters[4].Value = model.Mobile;
			parameters[5].Value = model.InContactPerson;
			parameters[6].Value = model.InTel;
			parameters[7].Value = model.InMobile;
			parameters[8].Value = model.CreateDate;
			parameters[9].Value = model.ExpireDate;
			parameters[10].Value = model.PromiseNO;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_ProjectPromise ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,8)};
			parameters[0].Value = ID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_ProjectPromise_MDL GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,ProjectID,ContactPerson,Tel,Mobile,InContactPerson,InTel,InMobile,CreateDate,ExpireDate,PromiseNO from T_ProjectPromise ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,8)};
			parameters[0].Value = ID;

			DigiPower.Onlinecol.Standard.Model.T_ProjectPromise_MDL model=new DigiPower.Onlinecol.Standard.Model.T_ProjectPromise_MDL();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProjectID"].ToString()!="")
				{
					model.ProjectID=int.Parse(ds.Tables[0].Rows[0]["ProjectID"].ToString());
				}
				model.ContactPerson=ds.Tables[0].Rows[0]["ContactPerson"].ToString();
				model.Tel=ds.Tables[0].Rows[0]["Tel"].ToString();
				model.Mobile=ds.Tables[0].Rows[0]["Mobile"].ToString();
				model.InContactPerson=ds.Tables[0].Rows[0]["InContactPerson"].ToString();
				model.InTel=ds.Tables[0].Rows[0]["InTel"].ToString();
				model.InMobile=ds.Tables[0].Rows[0]["InMobile"].ToString();
				if(ds.Tables[0].Rows[0]["CreateDate"].ToString()!="")
				{
					model.CreateDate=DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ExpireDate"].ToString()!="")
				{
					model.ExpireDate=DateTime.Parse(ds.Tables[0].Rows[0]["ExpireDate"].ToString());
				}
				model.PromiseNO=ds.Tables[0].Rows[0]["PromiseNO"].ToString();
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
			strSql.Append("select ID,ProjectID,ContactPerson,Tel,Mobile,InContactPerson,InTel,InMobile,CreateDate,ExpireDate,PromiseNO ");
			strSql.Append(" FROM T_ProjectPromise ");
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
			strSql.Append(" ID,ProjectID,ContactPerson,Tel,Mobile,InContactPerson,InTel,InMobile,CreateDate,ExpireDate,PromiseNO ");
			strSql.Append(" FROM T_ProjectPromise ");
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
			parameters[0].Value = "T_ProjectPromise";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法

        public bool ExistsNO(string PromiseNO)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_ProjectPromise");
            strSql.Append(" where PromiseNO='" + PromiseNO + "'");
            return DbHelperSQL.Exists(strSql.ToString());
        }
	}
}

