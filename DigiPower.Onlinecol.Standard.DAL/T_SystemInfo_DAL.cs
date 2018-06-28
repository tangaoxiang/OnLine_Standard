using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL
{
    /// <summary>
    /// 数据访问类T_SystemInfo_DAL。
    /// </summary>
    public class T_SystemInfo_DAL
    {
        public T_SystemInfo_DAL()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("SystemInfoID", "T_SystemInfo");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SystemInfoID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_SystemInfo");
            strSql.Append(" where SystemInfoID=@SystemInfoID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SystemInfoID", SqlDbType.Int,8)};
            parameters[0].Value = SystemInfoID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_SystemInfo_MDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_SystemInfo(");
            strSql.Append("CurrentType,CurrentTypeCNName,SystemInfoCode,SystemInfoName,SubType,OrderIndex,ParentID,IsShow,IfEdit)");
            strSql.Append(" values (");
            strSql.Append("@CurrentType,@CurrentTypeCNName,@SystemInfoCode,@SystemInfoName,@SubType,@OrderIndex,@ParentID,@IsShow,@IfEdit)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@CurrentType", SqlDbType.NVarChar,50),
					new SqlParameter("@CurrentTypeCNName", SqlDbType.NVarChar,50),
					new SqlParameter("@SystemInfoCode", SqlDbType.NVarChar,50),
					new SqlParameter("@SystemInfoName", SqlDbType.NVarChar,50),
					new SqlParameter("@SubType", SqlDbType.NVarChar,10),
					new SqlParameter("@OrderIndex", SqlDbType.Int,8),
					new SqlParameter("@ParentID", SqlDbType.Int,8),
					new SqlParameter("@IsShow", SqlDbType.Bit,1),
					new SqlParameter("@IfEdit", SqlDbType.Bit,1)};
            parameters[0].Value = model.CurrentType;
            parameters[1].Value = model.CurrentTypeCNName;
            parameters[2].Value = model.SystemInfoCode;
            parameters[3].Value = model.SystemInfoName;
            parameters[4].Value = model.SubType;
            parameters[5].Value = model.OrderIndex;
            parameters[6].Value = model.ParentID;
            parameters[7].Value = model.IsShow;
            parameters[8].Value = model.IfEdit;

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
        public void Update(DigiPower.Onlinecol.Standard.Model.T_SystemInfo_MDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_SystemInfo set ");
            strSql.Append("CurrentType=@CurrentType,");
            strSql.Append("CurrentTypeCNName=@CurrentTypeCNName,");
            strSql.Append("SystemInfoCode=@SystemInfoCode,");
            strSql.Append("SystemInfoName=@SystemInfoName,");
            strSql.Append("SubType=@SubType,");
            strSql.Append("OrderIndex=@OrderIndex,");
            strSql.Append("ParentID=@ParentID,");
            strSql.Append("IsShow=@IsShow,");
            strSql.Append("IfEdit=@IfEdit");
            strSql.Append(" where SystemInfoID=@SystemInfoID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SystemInfoID", SqlDbType.Int,8),
					new SqlParameter("@CurrentType", SqlDbType.NVarChar,50),
					new SqlParameter("@CurrentTypeCNName", SqlDbType.NVarChar,50),
					new SqlParameter("@SystemInfoCode", SqlDbType.NVarChar,50),
					new SqlParameter("@SystemInfoName", SqlDbType.NVarChar,50),
					new SqlParameter("@SubType", SqlDbType.NVarChar,10),
					new SqlParameter("@OrderIndex", SqlDbType.Int,8),
					new SqlParameter("@ParentID", SqlDbType.Int,8),
					new SqlParameter("@IsShow", SqlDbType.Bit,1),
					new SqlParameter("@IfEdit", SqlDbType.Bit,1)};
            parameters[0].Value = model.SystemInfoID;
            parameters[1].Value = model.CurrentType;
            parameters[2].Value = model.CurrentTypeCNName;
            parameters[3].Value = model.SystemInfoCode;
            parameters[4].Value = model.SystemInfoName;
            parameters[5].Value = model.SubType;
            parameters[6].Value = model.OrderIndex;
            parameters[7].Value = model.ParentID;
            parameters[8].Value = model.IsShow;
            parameters[9].Value = model.IfEdit;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int SystemInfoID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_SystemInfo ");
            strSql.Append(" where SystemInfoID=@SystemInfoID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SystemInfoID", SqlDbType.Int,8)};
            parameters[0].Value = SystemInfoID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 删除多条数据
        /// </summary>
        public void DeleteMore(string SystemInfoID)
        {
            if (!string.IsNullOrWhiteSpace(SystemInfoID))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from T_SystemInfo ");
                strSql.Append(" where SystemInfoID in(" + SystemInfoID + ") ");

                DbHelperSQL.ExecuteSql(strSql.ToString());
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_SystemInfo_MDL GetModel(int SystemInfoID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SystemInfoID,CurrentType,CurrentTypeCNName,SystemInfoCode,SystemInfoName,SubType,OrderIndex,ParentID,IsShow,IfEdit from T_SystemInfo ");
            strSql.Append(" where SystemInfoID=@SystemInfoID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SystemInfoID", SqlDbType.Int,8)};
            parameters[0].Value = SystemInfoID;

            DigiPower.Onlinecol.Standard.Model.T_SystemInfo_MDL model = new DigiPower.Onlinecol.Standard.Model.T_SystemInfo_MDL();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SystemInfoID"].ToString() != "")
                {
                    model.SystemInfoID = int.Parse(ds.Tables[0].Rows[0]["SystemInfoID"].ToString());
                }
                model.CurrentType = ds.Tables[0].Rows[0]["CurrentType"].ToString();
                model.CurrentTypeCNName = ds.Tables[0].Rows[0]["CurrentTypeCNName"].ToString();
                model.SystemInfoCode = ds.Tables[0].Rows[0]["SystemInfoCode"].ToString();
                model.SystemInfoName = ds.Tables[0].Rows[0]["SystemInfoName"].ToString();
                model.SubType = ds.Tables[0].Rows[0]["SubType"].ToString();
                if (ds.Tables[0].Rows[0]["OrderIndex"].ToString() != "")
                {
                    model.OrderIndex = int.Parse(ds.Tables[0].Rows[0]["OrderIndex"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsShow"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsShow"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsShow"].ToString().ToLower() == "true"))
                    {
                        model.IsShow = true;
                    }
                    else
                    {
                        model.IsShow = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["IfEdit"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IfEdit"].ToString() == "1") || (ds.Tables[0].Rows[0]["IfEdit"].ToString().ToLower() == "true"))
                    {
                        model.IfEdit = true;
                    }
                    else
                    {
                        model.IfEdit = false;
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *,lower(SystemInfoCode) as lower_SystemInfoCode FROM T_SystemInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by OrderIndex ");
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 获得数据列表 分页
        /// </summary>
        /// <returns></returns>
        public DataTable GetList(string strWhere, int PageSize, int curPage, string PRIMARYKey, string OrderByName, out int recCoun)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM T_SystemInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return PageCtrl.QueryForDataTableSqlServer(strSql.ToString(), PageSize, curPage, PRIMARYKey, OrderByName, out recCoun).Tables[0];
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
            strSql.Append(" SystemInfoID,CurrentType,CurrentTypeCNName,SystemInfoCode,SystemInfoName,SubType,OrderIndex,ParentID,IsShow,IfEdit ");
            strSql.Append(" FROM T_SystemInfo ");
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
            parameters[0].Value = "T_SystemInfo";
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

