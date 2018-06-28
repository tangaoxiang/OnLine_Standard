using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL
{
    /// <summary>
    /// 数据访问类T_FileAttach_DAL。
    /// </summary>
    public class T_FileAttach_DAL
    {
        public T_FileAttach_DAL() { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId() {
            return DbHelperSQL.GetMaxID("AttachID", "T_FileAttach");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int AttachID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_FileAttach");
            strSql.Append(" where AttachID=@AttachID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AttachID", SqlDbType.Int,8)};
            parameters[0].Value = AttachID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_FileAttach_MDL model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_FileAttach(");
            strSql.Append("Flag,PriKeyValue,AttachCode,AttachName,AttachPath,OrderIndex,CreateDate)");
            strSql.Append(" values (");
            strSql.Append("@Flag,@PriKeyValue,@AttachCode,@AttachName,@AttachPath,@OrderIndex,@CreateDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Flag", SqlDbType.NVarChar,50),
					new SqlParameter("@PriKeyValue", SqlDbType.Int,8),
					new SqlParameter("@AttachCode", SqlDbType.NVarChar,50),
					new SqlParameter("@AttachName", SqlDbType.NVarChar,200),
					new SqlParameter("@AttachPath", SqlDbType.NVarChar,250),
					new SqlParameter("@OrderIndex", SqlDbType.Int,8),
					new SqlParameter("@CreateDate", SqlDbType.DateTime)};
            parameters[0].Value = model.Flag;
            parameters[1].Value = model.PriKeyValue;
            parameters[2].Value = model.AttachCode;
            parameters[3].Value = model.AttachName;
            parameters[4].Value = model.AttachPath;
            parameters[5].Value = model.OrderIndex;
            parameters[6].Value = model.CreateDate;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null) {
                return 1;
            }
            else {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(DigiPower.Onlinecol.Standard.Model.T_FileAttach_MDL model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_FileAttach set ");
            strSql.Append("Flag=@Flag,");
            strSql.Append("PriKeyValue=@PriKeyValue,");
            strSql.Append("AttachCode=@AttachCode,");
            strSql.Append("AttachName=@AttachName,");
            strSql.Append("AttachPath=@AttachPath,");
            strSql.Append("OrderIndex=@OrderIndex,");
            strSql.Append("CreateDate=@CreateDate");
            strSql.Append(" where AttachID=@AttachID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AttachID", SqlDbType.Int,8),
					new SqlParameter("@Flag", SqlDbType.NVarChar,50),
					new SqlParameter("@PriKeyValue", SqlDbType.Int,8),
					new SqlParameter("@AttachCode", SqlDbType.NVarChar,50),
					new SqlParameter("@AttachName", SqlDbType.NVarChar,200),
					new SqlParameter("@AttachPath", SqlDbType.NVarChar,250),
					new SqlParameter("@OrderIndex", SqlDbType.Int,8),
					new SqlParameter("@CreateDate", SqlDbType.DateTime)};
            parameters[0].Value = model.AttachID;
            parameters[1].Value = model.Flag;
            parameters[2].Value = model.PriKeyValue;
            parameters[3].Value = model.AttachCode;
            parameters[4].Value = model.AttachName;
            parameters[5].Value = model.AttachPath;
            parameters[6].Value = model.OrderIndex;
            parameters[7].Value = model.CreateDate;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int AttachID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_FileAttach ");
            strSql.Append(" where AttachID=@AttachID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AttachID", SqlDbType.Int,8)};
            parameters[0].Value = AttachID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_FileAttach_MDL GetModel(int AttachID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 AttachID,Flag,PriKeyValue,AttachCode,AttachName,AttachPath,OrderIndex,CreateDate from T_FileAttach ");
            strSql.Append(" where AttachID=@AttachID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AttachID", SqlDbType.Int,8)};
            parameters[0].Value = AttachID;

            DigiPower.Onlinecol.Standard.Model.T_FileAttach_MDL model = new DigiPower.Onlinecol.Standard.Model.T_FileAttach_MDL();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["AttachID"].ToString() != "") {
                    model.AttachID = int.Parse(ds.Tables[0].Rows[0]["AttachID"].ToString());
                }
                model.Flag = ds.Tables[0].Rows[0]["Flag"].ToString();
                if (ds.Tables[0].Rows[0]["PriKeyValue"].ToString() != "") {
                    model.PriKeyValue = int.Parse(ds.Tables[0].Rows[0]["PriKeyValue"].ToString());
                }
                model.AttachCode = ds.Tables[0].Rows[0]["AttachCode"].ToString();
                model.AttachName = ds.Tables[0].Rows[0]["AttachName"].ToString();
                model.AttachPath = ds.Tables[0].Rows[0]["AttachPath"].ToString();
                if (ds.Tables[0].Rows[0]["OrderIndex"].ToString() != "") {
                    model.OrderIndex = int.Parse(ds.Tables[0].Rows[0]["OrderIndex"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateDate"].ToString() != "") {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                return model;
            }
            else {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AttachID,Flag,PriKeyValue,AttachCode,AttachName,AttachPath,OrderIndex,CreateDate ");
            strSql.Append(" FROM T_FileAttach ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by AttachCode ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0) {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" AttachID,Flag,PriKeyValue,AttachCode,AttachName,AttachPath,OrderIndex,CreateDate ");
            strSql.Append(" FROM T_FileAttach ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


        #endregion  成员方法

        /// <summary>
        /// 删除附件信息
        /// </summary>
        /// <param name="singleProjectId"></param>
        /// <param name="attachCode"></param>
        /// <param name="flag"></param>
        public void DelFileAttach(string singleProjectId, string attachCode, string flag) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_FileAttach ");
            strSql.Append(" where PriKeyValue=@PriKeyValue and LOWER(AttachCode)=@AttachCode and LOWER(Flag)=@Flag ");
            SqlParameter[] parameters = {
					new SqlParameter("@PriKeyValue", SqlDbType.Int,10),
                    new SqlParameter("@AttachCode", SqlDbType.VarChar,50),
                    new SqlParameter("@Flag", SqlDbType.VarChar,50)};
            parameters[0].Value = singleProjectId;
            parameters[1].Value = attachCode.ToLower();
            parameters[2].Value = flag.ToLower();

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
    }
}

