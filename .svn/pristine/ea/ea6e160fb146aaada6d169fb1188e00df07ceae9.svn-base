using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL
{
    /// <summary>
    /// 数据访问类T_Train_Rec_DAL。
    /// </summary>
    public class T_Train_Rec_DAL
    {
        public T_Train_Rec_DAL()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("TrainRecID", "T_Train_Rec");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int TrainRecID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_Train_Rec");
            strSql.Append(" where TrainRecID=@TrainRecID ");
            SqlParameter[] parameters = {
					new SqlParameter("@TrainRecID", SqlDbType.Int,8)};
            parameters[0].Value = TrainRecID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_Train_Rec_MDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Train_Rec(");
            strSql.Append("UserID,TrainPlanID,TrainDesc,TrainResult)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@TrainPlanID,@TrainDesc,@TrainResult)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,8),
					new SqlParameter("@TrainPlanID", SqlDbType.Int,8),
					new SqlParameter("@TrainDesc", SqlDbType.NVarChar,500),
					new SqlParameter("@TrainResult", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.TrainPlanID;
            parameters[2].Value = model.TrainDesc;
            parameters[3].Value = model.TrainResult;

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
        public void Update(DigiPower.Onlinecol.Standard.Model.T_Train_Rec_MDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Train_Rec set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("TrainPlanID=@TrainPlanID,");
            strSql.Append("TrainDesc=@TrainDesc,");
            strSql.Append("TrainResult=@TrainResult");
            strSql.Append(" where TrainRecID=@TrainRecID ");
            SqlParameter[] parameters = {
					new SqlParameter("@TrainRecID", SqlDbType.Int,8),
					new SqlParameter("@UserID", SqlDbType.Int,8),
					new SqlParameter("@TrainPlanID", SqlDbType.Int,8),
					new SqlParameter("@TrainDesc", SqlDbType.NVarChar,500),
					new SqlParameter("@TrainResult", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.TrainRecID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.TrainPlanID;
            parameters[3].Value = model.TrainDesc;
            parameters[4].Value = model.TrainResult;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int TrainRecID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Train_Rec ");
            strSql.Append(" where TrainRecID=@TrainRecID ");
            SqlParameter[] parameters = {
					new SqlParameter("@TrainRecID", SqlDbType.Int,8)};
            parameters[0].Value = TrainRecID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_Train_Rec_MDL GetModel(int TrainRecID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 TrainRecID,UserID,TrainPlanID,TrainDesc,TrainResult from T_Train_Rec ");
            strSql.Append(" where TrainRecID=@TrainRecID ");
            SqlParameter[] parameters = {
					new SqlParameter("@TrainRecID", SqlDbType.Int,8)};
            parameters[0].Value = TrainRecID;

            DigiPower.Onlinecol.Standard.Model.T_Train_Rec_MDL model = new DigiPower.Onlinecol.Standard.Model.T_Train_Rec_MDL();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["TrainRecID"].ToString() != "")
                {
                    model.TrainRecID = int.Parse(ds.Tables[0].Rows[0]["TrainRecID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TrainPlanID"].ToString() != "")
                {
                    model.TrainPlanID = int.Parse(ds.Tables[0].Rows[0]["TrainPlanID"].ToString());
                }
                model.TrainDesc = ds.Tables[0].Rows[0]["TrainDesc"].ToString();
                model.TrainResult = ds.Tables[0].Rows[0]["TrainResult"].ToString();
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
            strSql.Append("select TrainRecID,UserID,TrainPlanID,TrainDesc,TrainResult ");
            strSql.Append(" FROM T_Train_Rec ");
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
            strSql.Append(" TrainRecID,UserID,TrainPlanID,TrainDesc,TrainResult ");
            strSql.Append(" FROM T_Train_Rec ");
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
            parameters[0].Value = "T_Train_Rec";
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

