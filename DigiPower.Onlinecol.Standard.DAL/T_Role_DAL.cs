using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL {
    /// <summary>
    /// 数据访问类T_Role_DAL。
    /// </summary>
    public class T_Role_DAL {
        public T_Role_DAL() { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId() {
            return DbHelperSQL.GetMaxID("RoleID", "T_Role");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RoleID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_Role");
            strSql.Append(" where RoleID=@RoleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,8)};
            parameters[0].Value = RoleID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RoleID, string RoleCode) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_Role");
            strSql.Append(" where RoleID !=@RoleID and LOWER(RoleCode)=@RoleCode and RoleCode!='' ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,8),
                    new SqlParameter("@RoleCode", SqlDbType.VarChar,50)};
            parameters[0].Value = RoleID;
            parameters[1].Value = RoleCode;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_Role_MDL model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Role(");
            strSql.Append("CompanyID,RoleName,Description,ForCompanyType,Del,RoleCode,RoleType)");
            strSql.Append(" values (");
            strSql.Append("@CompanyID,@RoleName,@Description,@ForCompanyType,@Del,@RoleCode,@RoleType)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@CompanyID", SqlDbType.Int,8),
					new SqlParameter("@RoleName", SqlDbType.VarChar,50),
					new SqlParameter("@Description", SqlDbType.VarChar,255),
					new SqlParameter("@ForCompanyType", SqlDbType.Int,8),
					new SqlParameter("@Del", SqlDbType.Bit,1),
                    new SqlParameter("@RoleCode", SqlDbType.VarChar,50),
                    new SqlParameter("@RoleType", SqlDbType.VarChar,50)};
            parameters[0].Value = model.CompanyID;
            parameters[1].Value = model.RoleName;
            parameters[2].Value = model.Description;
            parameters[3].Value = model.ForCompanyType;
            parameters[4].Value = model.Del;
            parameters[5].Value = model.RoleCode;
            parameters[6].Value = model.RoleType;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null) {
                return 1;
            } else {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(DigiPower.Onlinecol.Standard.Model.T_Role_MDL model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Role set ");
            strSql.Append("CompanyID=@CompanyID,");
            strSql.Append("RoleName=@RoleName,");
            strSql.Append("Description=@Description,");
            strSql.Append("ForCompanyType=@ForCompanyType,");
            strSql.Append("Del=@Del,");
            strSql.Append("RoleCode=@RoleCode,");
            strSql.Append("RoleType=@RoleType");
            strSql.Append(" where RoleID=@RoleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,8),
					new SqlParameter("@CompanyID", SqlDbType.Int,8),
					new SqlParameter("@RoleName", SqlDbType.VarChar,50),
					new SqlParameter("@Description", SqlDbType.VarChar,255),
					new SqlParameter("@ForCompanyType", SqlDbType.Int,8),
					new SqlParameter("@Del", SqlDbType.Bit,1),
                    new SqlParameter("@RoleCode", SqlDbType.VarChar,50),
                    new SqlParameter("@RoleType", SqlDbType.VarChar,50)};

            parameters[0].Value = model.RoleID;
            parameters[1].Value = model.CompanyID;
            parameters[2].Value = model.RoleName;
            parameters[3].Value = model.Description;
            parameters[4].Value = model.ForCompanyType;
            parameters[5].Value = model.Del;
            parameters[6].Value = model.RoleCode;
            parameters[7].Value = model.RoleType;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int RoleID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Role ");
            strSql.Append(" where RoleID=@RoleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,8)};
            parameters[0].Value = RoleID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_Role_MDL GetModel(int RoleID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 RoleID,CompanyID,RoleName,Description,ForCompanyType,Del,RoleCode,RoleType from T_Role ");
            strSql.Append(" where RoleID=@RoleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,8)};
            parameters[0].Value = RoleID;

            DigiPower.Onlinecol.Standard.Model.T_Role_MDL model = new DigiPower.Onlinecol.Standard.Model.T_Role_MDL();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["RoleID"].ToString() != "") {
                    model.RoleID = int.Parse(ds.Tables[0].Rows[0]["RoleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CompanyID"].ToString() != "") {
                    model.CompanyID = int.Parse(ds.Tables[0].Rows[0]["CompanyID"].ToString());
                }
                model.RoleName = ds.Tables[0].Rows[0]["RoleName"].ToString();
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                model.RoleCode = ds.Tables[0].Rows[0]["RoleCode"].ToString();
                model.RoleType = ds.Tables[0].Rows[0]["RoleType"].ToString();
                if (ds.Tables[0].Rows[0]["ForCompanyType"].ToString() != "") {
                    model.ForCompanyType = int.Parse(ds.Tables[0].Rows[0]["ForCompanyType"].ToString());
                }
      

                if (ds.Tables[0].Rows[0]["Del"].ToString() != "") {
                    if ((ds.Tables[0].Rows[0]["Del"].ToString() == "1") || (ds.Tables[0].Rows[0]["Del"].ToString().ToLower() == "true")) {
                        model.Del = true;
                    } else {
                        model.Del = false;
                    }
                }
                return model;
            } else {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select RoleID,CompanyID,RoleName,Description,ForCompanyType,Del ");
            //strSql.Append(" FROM T_Role ");
            strSql.Append("select A.*,B.CompanyName,C.SystemInfoName from T_Role A left join T_Company B on A.CompanyID=B.CompanyID ");
            strSql.Append("left join T_SystemInfo C on B.CompanyType=C.SystemInfoID ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 获得数据列表 分页
        /// </summary>
        /// <returns></returns>
        public DataTable GetList(string strWhere, int PageSize, int curPage, string PRIMARYKey, string OrderByName, out int recCoun) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.*,b.CompanyName,c.SystemInfoName,d.area_name,e.SystemInfoName as RoleTypeName from T_Role a ");
            strSql.Append("left join T_Company b on A.CompanyID=B.CompanyID ");
            strSql.Append("left join T_SystemInfo c on B.CompanyType=C.SystemInfoID ");
            strSql.Append("left join T_Area D on b.Area_Code=d.area_code ");
            strSql.Append("left join T_SystemInfo e on lower(e.CurrentType)='roletype' and lower(a.RoleType)=lower(E.SystemInfoCode) ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            return PageCtrl.QueryForDataTableSqlServer(strSql.ToString(), PageSize, curPage, PRIMARYKey, OrderByName, out recCoun).Tables[0];
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
            strSql.Append(" RoleID,CompanyID,RoleName,Description,ForCompanyType,Del,RoleCode,RoleType ");
            strSql.Append(" FROM T_Role ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据通过公司编号
        /// </summary>
        public int DeleteRoleByCompanyID(int CompanyID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Role ");
            strSql.Append(" where CompanyID=@CompanyID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CompanyID", SqlDbType.Int,8)};
            parameters[0].Value = CompanyID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据通过公司编号
        /// </summary>
        public int DeleteRoleRightByCompanyID(int CompanyID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_RoleRight ");
            strSql.Append(" where RoleID in(select RoleID from T_Role where CompanyID=@CompanyID)");
            SqlParameter[] parameters = {
					new SqlParameter("@CompanyID", SqlDbType.Int,8)};
            parameters[0].Value = CompanyID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        #endregion  成员方法

        /// <summary>
        /// 根据角色编号获取角色ID
        /// </summary>
        /// <param name="RoleCode"></param>
        /// <param name="AreaCode">角色所属公司的区域</param>
        /// <returns></returns>
        public int GetRoleIdByRoleCode(string RoleCode, string AreaCode) {
            if (!string.IsNullOrWhiteSpace(RoleCode) && !string.IsNullOrWhiteSpace(AreaCode)) {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select top 1 RoleID from T_Role ");
                strSql.Append(" where LOWER(RoleCode)='" + RoleCode.ToLower() + "' and ");
                strSql.Append("CompanyID IN(SELECT f0.CompanyID from T_Company f0 where f0.Area_Code='" + AreaCode + "' )");

                object obj = DbHelperSQL.GetSingle(strSql.ToString());
                if (obj == null) {
                    return 0;
                } else {
                    return Convert.ToInt32(obj);
                }
            }
            return 0;
        }
    }
}

