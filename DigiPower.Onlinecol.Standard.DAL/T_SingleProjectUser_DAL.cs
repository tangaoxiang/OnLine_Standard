using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL
{
    /// <summary>
    /// 数据访问类T_SingleProjectUser_DAL。
    /// </summary>
    public class T_SingleProjectUser_DAL
    {
        public T_SingleProjectUser_DAL()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("SingleProjectUserID", "T_SingleProjectUser");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SingleProjectUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_SingleProjectUser");
            strSql.Append(" where SingleProjectUserID=@SingleProjectUserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SingleProjectUserID", SqlDbType.Int,8)};
            parameters[0].Value = SingleProjectUserID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_SingleProjectUser_MDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_SingleProjectUser(");
            strSql.Append("SingleProjectID,RoleID,UserID,CreateDate)");
            strSql.Append(" values (");
            strSql.Append("@SingleProjectID,@RoleID,@UserID,@CreateDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@SingleProjectID", SqlDbType.Int,8),
					new SqlParameter("@RoleID", SqlDbType.Int,8),
					new SqlParameter("@UserID", SqlDbType.Int,8),
					new SqlParameter("@CreateDate", SqlDbType.DateTime)};
            parameters[0].Value = model.SingleProjectID;
            parameters[1].Value = model.RoleID;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.CreateDate;

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
        public void Update(DigiPower.Onlinecol.Standard.Model.T_SingleProjectUser_MDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_SingleProjectUser set ");
            strSql.Append("SingleProjectID=@SingleProjectID,");
            strSql.Append("RoleID=@RoleID,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("CreateDate=@CreateDate");
            strSql.Append(" where SingleProjectUserID=@SingleProjectUserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SingleProjectUserID", SqlDbType.Int,8),
					new SqlParameter("@SingleProjectID", SqlDbType.Int,8),
					new SqlParameter("@RoleID", SqlDbType.Int,8),
					new SqlParameter("@UserID", SqlDbType.Int,8),
					new SqlParameter("@CreateDate", SqlDbType.DateTime)};
            parameters[0].Value = model.SingleProjectUserID;
            parameters[1].Value = model.SingleProjectID;
            parameters[2].Value = model.RoleID;
            parameters[3].Value = model.UserID;
            parameters[4].Value = model.CreateDate;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int SingleProjectUserID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_SingleProjectUser ");
            strSql.Append(" where SingleProjectUserID=@SingleProjectUserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SingleProjectUserID", SqlDbType.Int,8)};
            parameters[0].Value = SingleProjectUserID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_SingleProjectUser_MDL GetModel(int SingleProjectUserID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SingleProjectUserID,SingleProjectID,RoleID,UserID,CreateDate from T_SingleProjectUser ");
            strSql.Append(" where SingleProjectUserID=@SingleProjectUserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SingleProjectUserID", SqlDbType.Int,8)};
            parameters[0].Value = SingleProjectUserID;

            DigiPower.Onlinecol.Standard.Model.T_SingleProjectUser_MDL model = new DigiPower.Onlinecol.Standard.Model.T_SingleProjectUser_MDL();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SingleProjectUserID"].ToString() != "")
                {
                    model.SingleProjectUserID = int.Parse(ds.Tables[0].Rows[0]["SingleProjectUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SingleProjectID"].ToString() != "")
                {
                    model.SingleProjectID = int.Parse(ds.Tables[0].Rows[0]["SingleProjectID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RoleID"].ToString() != "")
                {
                    model.RoleID = int.Parse(ds.Tables[0].Rows[0]["RoleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SingleProjectUserID,SingleProjectID,RoleID,UserID,CreateDate ");
            strSql.Append(" FROM T_SingleProjectUser ");
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
            strSql.Append(" SingleProjectUserID,SingleProjectID,RoleID,UserID,CreateDate ");
            strSql.Append(" FROM T_SingleProjectUser ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            parameters[0].Value = "T_SingleProjectUser";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法

        public DataSet GetListByRoleID(string RoleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT b.SingleProjectUserID,a.SingleProjectID,a.gcbm,a.gcmc,c.UserID,c.UserName,c.Mobile,c.QQ,c.Tel,c.Fax,c.EMail,d.CompanyName FROM T_SingleProject a,T_SingleProjectUser b,T_UsersInfo c,T_Company d where a.SingleProjectID=b.SingleProjectID AND b.RoleID=c.RoleID AND C.IsValid='true' And c.CompanyID=d.CompanyID AND b.SingleProjectID in (select SingleProjectID from T_SingleProjectUser WHERE RoleID=" + RoleID + ") ORDER BY a.SingleProjectID,c.UserID");
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetProjectUsers(int SingleProjectID)
        {
            string strSql = "select userid,username from T_UsersInfo where roleid in (select roleid from t_singleprojectuser where SingleProjectID=" + SingleProjectID + ")";
            return DbHelperSQL.Query(strSql);
        }

        /// <summary>
        /// 删除工程用户关联表中某一用户
        /// </summary>
        /// <param name="singleProjectID"></param>
        /// <param name="userID"></param>
        public void DeleteSingleProjectUser(string singleProjectID, string userID)
        {
            if (!string.IsNullOrWhiteSpace(singleProjectID) && !string.IsNullOrWhiteSpace(userID))
            {
                StringBuilder strSql = new StringBuilder();

                strSql.Append("delete from t_singleprojectuser where SingleProjectID=@singleProjectID and ");
                strSql.Append("UserID=@UserID ");
                SqlParameter[] parameters = {
					new SqlParameter("@singleProjectID", SqlDbType.VarChar,20),
                    new SqlParameter("@userID", SqlDbType.Int)};

                parameters[0].Value = singleProjectID;
                parameters[1].Value = userID;

                DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }
        }

        /// <summary>
        /// 删除工程用户关联表中某一用户
        /// </summary>
        /// <param name="singleProjectID"></param>
        public void DeleteSingleProjectUser(string singleProjectID )
        {
            if (!string.IsNullOrWhiteSpace(singleProjectID) )
            {
                StringBuilder strSql = new StringBuilder();    
                strSql.Append("delete from t_singleprojectuser where SingleProjectID=@singleProjectID ");
                SqlParameter[] parameters = {
					new SqlParameter("@singleProjectID", SqlDbType.VarChar,20)};

                parameters[0].Value = singleProjectID;

                DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }
        }
    }
}

