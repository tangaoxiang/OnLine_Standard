using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL
{
    /// <summary>
    /// 数据访问类T_RoleRight_DAL。
    /// </summary>
    public class T_RoleRight_DAL
    {
        public T_RoleRight_DAL()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("RoleRightID", "T_RoleRight");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RoleRightID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_RoleRight");
            strSql.Append(" where RoleRightID=@RoleRightID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleRightID", SqlDbType.Int,8)};
            parameters[0].Value = RoleRightID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_RoleRight_MDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_RoleRight(");
            strSql.Append("RoleID,ModelID,RightListID,Enabled,RoleRightType,ModelBH)");
            strSql.Append(" values (");
            strSql.Append("@RoleID,@ModelID,@RightListID,@Enabled,@RoleRightType,@ModelBH)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,8),
					new SqlParameter("@ModelID", SqlDbType.Int,8),
					new SqlParameter("@RightListID", SqlDbType.VarChar,500),                     
					new SqlParameter("@Enabled", SqlDbType.Bit,1),
                    new SqlParameter("@RoleRightType", SqlDbType.Int,2),
                    new SqlParameter("@ModelBH", SqlDbType.VarChar,20) };

            parameters[0].Value = model.RoleID;
            parameters[1].Value = model.ModelID;
            parameters[2].Value = model.RightListID;
            parameters[3].Value = model.Enabled;
            parameters[4].Value = model.RoleRightType;
            parameters[5].Value = model.ModelBH;


            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public void Update(DigiPower.Onlinecol.Standard.Model.T_RoleRight_MDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_RoleRight set ");
            strSql.Append("RoleID=@RoleID,");
            strSql.Append("ModelID=@ModelID,");
            strSql.Append("RightListID=@RightListID,");
            strSql.Append("Enabled=@Enabled,");
            strSql.Append("RoleRightType=@RoleRightType, ");
            strSql.Append("ModelBH=@ModelBH ");
            strSql.Append(" where RoleRightID=@RoleRightID ");


            SqlParameter[] parameters = {
					new SqlParameter("@RoleRightID", SqlDbType.Int,8),
					new SqlParameter("@RoleID", SqlDbType.Int,8),
					new SqlParameter("@ModelID", SqlDbType.Int,8),
					new SqlParameter("@RightListID", SqlDbType.VarChar,500),
					new SqlParameter("@Enabled", SqlDbType.Bit,1),
                    new SqlParameter("@RoleRightType", SqlDbType.Int,2),
                    new SqlParameter("@ModelBH", SqlDbType.VarChar,20) };

            parameters[0].Value = model.RoleRightID;
            parameters[1].Value = model.RoleID;
            parameters[2].Value = model.ModelID;
            parameters[3].Value = model.RightListID;
            parameters[4].Value = model.Enabled;
            parameters[5].Value = model.RoleRightType;
            parameters[6].Value = model.ModelBH;


            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int RoleRightID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_RoleRight ");
            strSql.Append(" where RoleRightID=@RoleRightID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleRightID", SqlDbType.Int,8)};
            parameters[0].Value = RoleRightID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_RoleRight_MDL GetModel(int RoleRightID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 RoleRightID,RoleID,ModelID,RightListID,Enabled,RoleRightType,ModelBH from T_RoleRight ");
            strSql.Append(" where RoleRightID=@RoleRightID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleRightID", SqlDbType.Int,8)};
            parameters[0].Value = RoleRightID;

            DigiPower.Onlinecol.Standard.Model.T_RoleRight_MDL model = new DigiPower.Onlinecol.Standard.Model.T_RoleRight_MDL();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["RoleRightID"].ToString() != "")
                {
                    model.RoleRightID = int.Parse(ds.Tables[0].Rows[0]["RoleRightID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RoleID"].ToString() != "")
                {
                    model.RoleID = int.Parse(ds.Tables[0].Rows[0]["RoleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModelID"].ToString() != "")
                {
                    model.ModelID = int.Parse(ds.Tables[0].Rows[0]["ModelID"].ToString());
                }

                model.RightListID = ds.Tables[0].Rows[0]["RightListID"].ToString();

                if (ds.Tables[0].Rows[0]["Enabled"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Enabled"].ToString() == "1") || (ds.Tables[0].Rows[0]["Enabled"].ToString().ToLower() == "true"))
                    {
                        model.Enabled = true;
                    }
                    else
                    {
                        model.Enabled = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["RoleRightType"].ToString() != "")
                {
                    model.RoleRightType = int.Parse(ds.Tables[0].Rows[0]["RoleRightType"].ToString());
                }
                model.ModelBH = ds.Tables[0].Rows[0]["ModelBH"].ToString();


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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RoleRightID,RoleID,ModelID,RightListID,Enabled,RoleRightType,ModelBH ");
            strSql.Append(" FROM T_RoleRight ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" RoleRightID,RoleID,ModelID,RightListID,Enabled,RoleRightType,ModelBH  ");
            strSql.Append(" FROM T_RoleRight ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法

        public bool Exists(string whereSql)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_RoleRight");
            if (whereSql != "")
            {
                strSql.Append(" WHERE " + whereSql);
            }
            return DbHelperSQL.Exists(strSql.ToString());
        }

        public bool Exists(string RoleID, string ModuleID, string RightName)
        {
            if (ModuleID != null && ModuleID != "")
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select distinct Enabled from T_RoleRight a,T_Right b WHERE a.RightID=b.RightID AND RoleID=" + RoleID + " AND ModelID=" + ModuleID + " AND RightCode='" + RightName + "'");
                DataSet ds = DbHelperSQL.Query(strSql.ToString());
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && Common.ConvertEx.ToBool(ds.Tables[0].Rows[0][0].ToString()) == false)
                {
                    return false;
                }
            }
            return true;
        }

    }
}

