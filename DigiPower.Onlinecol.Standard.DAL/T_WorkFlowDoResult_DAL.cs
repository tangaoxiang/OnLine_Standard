using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;
using System.Collections;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL
{
    /// <summary>
    /// 数据访问类T_WorkFlowDoResult_DAL。
    /// </summary>
    public class T_WorkFlowDoResult_DAL
    {
        public T_WorkFlowDoResult_DAL()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("WorkFlowDoResultID", "T_WorkFlowDoResult");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int WorkFlowDoResultID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_WorkFlowDoResult");
            strSql.Append(" where WorkFlowDoResultID=@WorkFlowDoResultID ");
            SqlParameter[] parameters = {
					new SqlParameter("@WorkFlowDoResultID", SqlDbType.Int,8)};
            parameters[0].Value = WorkFlowDoResultID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(DigiPower.Onlinecol.Standard.Model.T_WorkFlowDoResult_MDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_WorkFlowDoResult(");
            strSql.Append("WorkFlowDefineID,DoUserID,DoDateTime,DoResult,DoRemark,DoCellPath, WorkFlowID,ArchiveID,SingleProjectID,FileListID)");
            strSql.Append(" values (");
            strSql.Append("@WorkFlowDefineID,@DoUserID,@DoDateTime,@DoResult,@DoRemark,@DoCellPath,@WorkFlowID,@ArchiveID,@SingleProjectID,@FileListID)");
            SqlParameter[] parameters = {
					new SqlParameter("@WorkFlowDefineID", SqlDbType.Int,8),
					new SqlParameter("@DoUserID", SqlDbType.Int,8),
					new SqlParameter("@DoDateTime", SqlDbType.DateTime),
					new SqlParameter("@DoResult", SqlDbType.NVarChar,50),
					new SqlParameter("@DoRemark", SqlDbType.NVarChar,500),
					new SqlParameter("@DoCellPath", SqlDbType.NVarChar,250),
                    new SqlParameter("@WorkFlowID", SqlDbType.Int,8)  ,
                    new SqlParameter("@ArchiveID", SqlDbType.Int,8) ,
                    new SqlParameter("@SingleProjectID", SqlDbType.Int,8)  ,
                    new SqlParameter("@FileListID", SqlDbType.Int,8)};


            parameters[0].Value = model.WorkFlowDefineID;
            parameters[1].Value = model.DoUserID;
            parameters[2].Value = model.DoDateTime;
            parameters[3].Value = model.DoResult;
            parameters[4].Value = model.DoRemark;
            parameters[5].Value = model.DoCellPath;

            parameters[6].Value = model.WorkFlowID;
            parameters[7].Value = model.ArchiveID;
            parameters[8].Value = model.SingleProjectID;
            parameters[9].Value = model.FileListID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(DigiPower.Onlinecol.Standard.Model.T_WorkFlowDoResult_MDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_WorkFlowDoResult set ");
            strSql.Append("WorkFlowDefineID=@WorkFlowDefineID,");
            strSql.Append("DoUserID=@DoUserID,");
            strSql.Append("DoDateTime=@DoDateTime,");
            strSql.Append("DoResult=@DoResult,");
            strSql.Append("DoRemark=@DoRemark,");
            strSql.Append("DoCellPath=@DoCellPath,");

            strSql.Append("WorkFlowID=@WorkFlowID,");
            strSql.Append("ArchiveID=@ArchiveID,");
            strSql.Append("SingleProjectID=@SingleProjectID,");
            strSql.Append("FileListID=@FileListID");


            strSql.Append(" where WorkFlowDoResultID=@WorkFlowDoResultID ");
            SqlParameter[] parameters = {
					new SqlParameter("@WorkFlowDoResultID", SqlDbType.Int,8),
					new SqlParameter("@WorkFlowDefineID", SqlDbType.Int,8),
					new SqlParameter("@DoUserID", SqlDbType.Int,8),
					new SqlParameter("@DoDateTime", SqlDbType.DateTime),
					new SqlParameter("@DoResult", SqlDbType.NVarChar,50),
					new SqlParameter("@DoRemark", SqlDbType.NVarChar,500),
					new SqlParameter("@DoCellPath", SqlDbType.NVarChar,250),

                    new SqlParameter("@WorkFlowID", SqlDbType.Int,8)  ,
                    new SqlParameter("@ArchiveID", SqlDbType.Int,8) ,
                    new SqlParameter("@SingleProjectID", SqlDbType.Int,8)  ,
                    new SqlParameter("@FileListID", SqlDbType.Int,8)};

            parameters[0].Value = model.WorkFlowDoResultID;
            parameters[1].Value = model.WorkFlowDefineID;
            parameters[2].Value = model.DoUserID;
            parameters[3].Value = model.DoDateTime;
            parameters[4].Value = model.DoResult;
            parameters[5].Value = model.DoRemark;
            parameters[6].Value = model.DoCellPath;

            parameters[7].Value = model.WorkFlowID;
            parameters[8].Value = model.ArchiveID;
            parameters[9].Value = model.SingleProjectID;
            parameters[10].Value = model.FileListID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int WorkFlowDoResultID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_WorkFlowDoResult ");
            strSql.Append(" where WorkFlowDoResultID=@WorkFlowDoResultID ");
            SqlParameter[] parameters = {
					new SqlParameter("@WorkFlowDoResultID", SqlDbType.Int,8)};
            parameters[0].Value = WorkFlowDoResultID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_WorkFlowDoResult_MDL GetModel(int WorkFlowDoResultID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 WorkFlowDoResultID,WorkFlowDefineID,DoUserID,DoDateTime,DoResult,DoRemark,DoCellPath,WorkFlowID,ArchiveID,SingleProjectID,FileListID from T_WorkFlowDoResult ");
            strSql.Append(" where WorkFlowDoResultID=@WorkFlowDoResultID ");
            SqlParameter[] parameters = {
					new SqlParameter("@WorkFlowDoResultID", SqlDbType.Int,8)};
            parameters[0].Value = WorkFlowDoResultID;

            DigiPower.Onlinecol.Standard.Model.T_WorkFlowDoResult_MDL model = new DigiPower.Onlinecol.Standard.Model.T_WorkFlowDoResult_MDL();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["WorkFlowDoResultID"].ToString() != "")
                {
                    model.WorkFlowDoResultID = int.Parse(ds.Tables[0].Rows[0]["WorkFlowDoResultID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WorkFlowDefineID"].ToString() != "")
                {
                    model.WorkFlowDefineID = int.Parse(ds.Tables[0].Rows[0]["WorkFlowDefineID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DoUserID"].ToString() != "")
                {
                    model.DoUserID = int.Parse(ds.Tables[0].Rows[0]["DoUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DoDateTime"].ToString() != "")
                {
                    model.DoDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["DoDateTime"].ToString());
                }
                model.DoResult = ds.Tables[0].Rows[0]["DoResult"].ToString();
                model.DoRemark = ds.Tables[0].Rows[0]["DoRemark"].ToString();
                model.DoCellPath = ds.Tables[0].Rows[0]["DoCellPath"].ToString();

                if (ds.Tables[0].Rows[0]["WorkFlowID"].ToString() != "")
                {
                    model.WorkFlowID = int.Parse(ds.Tables[0].Rows[0]["WorkFlowID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ArchiveID"].ToString() != "")
                {
                    model.ArchiveID = int.Parse(ds.Tables[0].Rows[0]["ArchiveID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SingleProjectID"].ToString() != "")
                {
                    model.SingleProjectID = int.Parse(ds.Tables[0].Rows[0]["SingleProjectID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FileListID"].ToString() != "")
                {
                    model.FileListID = int.Parse(ds.Tables[0].Rows[0]["FileListID"].ToString());
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
        public DataSet GetList(string strWhere, string orderByName = null)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select WorkFlowDoResultID,WorkFlowDefineID,DoUserID,DoDateTime,DoResult,DoRemark,DoCellPath,");
            strSql.Append("WorkFlowID,ArchiveID,SingleProjectID,FileListID,");
            strSql.Append("(select WorkFlowName from T_WorkFlow f where f.WorkFlowID=T_WorkFlowDoResult.WorkFlowID)as WorkFlowName,");
            strSql.Append("(select UserName from T_UsersInfo f where f.UserID=T_WorkFlowDoResult.DoUserID)as DoUserName ");

            strSql.Append(" FROM T_WorkFlowDoResult ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (orderByName != null)
            {
                strSql.Append(" order by " + orderByName);
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
            strSql.Append(" WorkFlowDoResultID,WorkFlowDefineID,DoUserID,DoDateTime,DoResult,DoRemark,DoCellPath,WorkFlowID,ArchiveID,SingleProjectID,FileListID ");
            strSql.Append(" FROM T_WorkFlowDoResult ");
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
            parameters[0].Value = "T_WorkFlowDoResult";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法

        /// <summary>
        /// 获取案卷最后审核信息
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public DataSet GetArchiveLastChecResultList(Hashtable ht)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select distinct f1.* from T_WorkFlowDoResult f1,(select MAX( f0.WorkFlowDoResultID)as MAXWorkFlowDoResultID,f0.ArchiveID ");
            strSql.Append("from T_WorkFlowDoResult f0 where f0.SingleProjectID=" + ht["SingleProjectID"] + " AND f0.WorkFlowID=" + ht["WorkFlowID"] + "  ");
            strSql.Append("group by f0.ArchiveID )f3 WHERE f1.WorkFlowDoResultID=f3.MAXWorkFlowDoResultID AND f1. ArchiveID=" + ht["ArchiveID"] + " ");
            strSql.Append("And f1.SingleProjectID=" + ht["SingleProjectID"] + " And f1.WorkFlowID=" + ht["WorkFlowID"] + "  ");
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}

