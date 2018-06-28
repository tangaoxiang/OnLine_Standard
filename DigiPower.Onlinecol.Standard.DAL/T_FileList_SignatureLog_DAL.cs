using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;
using System.Collections;
namespace DigiPower.Onlinecol.Standard.DAL {
    /// <summary>
    /// 数据访问类:T_FileList_SignatureLog
    /// </summary>
    public partial class T_FileList_SignatureLog_DAL {
        public T_FileList_SignatureLog_DAL() { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SignatureLogID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_FileList_SignatureLog");
            strSql.Append(" where SignatureLogID=@SignatureLogID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SignatureLogID", SqlDbType.Int,8)			};
            parameters[0].Value = SignatureLogID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DigiPower.Onlinecol.Standard.Model.T_FileList_SignatureLog_MDL model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_FileList_SignatureLog(");
            strSql.Append("FileListID,SingleProjectID,Signature_DT,Signature_UserID,Signature_UserRoleCode,FileListTmpID,Message,OperationType,SignatureFinishFlag,SignatureFinish_DT)");
            strSql.Append(" values (");
            strSql.Append("@FileListID,@SingleProjectID,@Signature_DT,@Signature_UserID,@Signature_UserRoleCode,@FileListTmpID,@Message,@OperationType,@SignatureFinishFlag,@SignatureFinish_DT)");
            SqlParameter[] parameters = {
					new SqlParameter("@FileListID", SqlDbType.Int,8),
					new SqlParameter("@SingleProjectID", SqlDbType.Int,8),
					new SqlParameter("@Signature_DT", SqlDbType.DateTime),
					new SqlParameter("@Signature_UserID", SqlDbType.Int,8),
					new SqlParameter("@Signature_UserRoleCode", SqlDbType.NVarChar,50),
					new SqlParameter("@FileListTmpID", SqlDbType.Int,8),
                    new SqlParameter("@Message", SqlDbType.NVarChar,500),
                    new SqlParameter("@OperationType", SqlDbType.NVarChar,50),
                    new SqlParameter("@SignatureFinishFlag", SqlDbType.NVarChar,1),
                   	new SqlParameter("@SignatureFinish_DT", SqlDbType.DateTime) };

            parameters[0].Value = model.FileListID;
            parameters[1].Value = model.SingleProjectID;
            parameters[2].Value = model.Signature_DT;
            parameters[3].Value = model.Signature_UserID;
            parameters[4].Value = model.Signature_UserRoleCode;
            parameters[5].Value = model.FileListTmpID;
            parameters[6].Value = model.Message;
            parameters[7].Value = model.OperationType;
            parameters[8].Value = model.SignatureFinishFlag;
            parameters[9].Value = model.SignatureFinish_DT;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0) {
                return true;
            } else {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DigiPower.Onlinecol.Standard.Model.T_FileList_SignatureLog_MDL model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_FileList_SignatureLog set ");
            strSql.Append("FileListID=@FileListID,");
            strSql.Append("SingleProjectID=@SingleProjectID,");
            strSql.Append("Signature_DT=@Signature_DT,");
            strSql.Append("Signature_UserID=@Signature_UserID,");
            strSql.Append("Signature_UserRoleCode=@Signature_UserRoleCode,");
            strSql.Append("FileListTmpID=@FileListTmpID,");
            strSql.Append("Message=@Message,");
            strSql.Append("OperationType=@OperationType,");
            strSql.Append("SignatureFinishFlag=@SignatureFinishFlag,");
            strSql.Append("SignatureFinish_DT=@SignatureFinish_DT ");
            strSql.Append(" where SignatureLogID=@SignatureLogID ");


            SqlParameter[] parameters = {
					new SqlParameter("@FileListID", SqlDbType.Int,8),
					new SqlParameter("@SingleProjectID", SqlDbType.Int,8),
					new SqlParameter("@Signature_DT", SqlDbType.DateTime),
					new SqlParameter("@Signature_UserID", SqlDbType.Int,8),
					new SqlParameter("@Signature_UserRoleCode", SqlDbType.NVarChar,50),
					new SqlParameter("@FileListTmpID", SqlDbType.Int,8),
                   	new SqlParameter("@Message", SqlDbType.NVarChar,500),
                	new SqlParameter("@OperationType", SqlDbType.NVarChar,50),
					new SqlParameter("@SignatureLogID", SqlDbType.Int,8),                       
                    new SqlParameter("@SignatureFinishFlag", SqlDbType.NVarChar,1),
                   	new SqlParameter("@SignatureFinish_DT", SqlDbType.DateTime) };

            parameters[0].Value = model.FileListID;
            parameters[1].Value = model.SingleProjectID;
            parameters[2].Value = model.Signature_DT;
            parameters[3].Value = model.Signature_UserID;
            parameters[4].Value = model.Signature_UserRoleCode;
            parameters[5].Value = model.FileListTmpID;
            parameters[6].Value = model.Message;
            parameters[7].Value = model.OperationType;
            parameters[8].Value = model.SignatureLogID;
            parameters[9].Value = model.SignatureFinishFlag;
            parameters[10].Value = model.SignatureFinish_DT;


            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int SignatureLogID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_FileList_SignatureLog ");
            strSql.Append(" where SignatureLogID=@SignatureLogID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SignatureLogID", SqlDbType.Int,8)			};
            parameters[0].Value = SignatureLogID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string SignatureLogIDlist) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_FileList_SignatureLog ");
            strSql.Append(" where SignatureLogID in (" + SignatureLogIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0) {
                return true;
            } else {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_FileList_SignatureLog_MDL GetModel(int SignatureLogID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SignatureLogID,FileListID,SingleProjectID,Signature_DT,Signature_UserID,Signature_UserRoleCode,FileListTmpID,Message,OperationType,SignatureFinishFlag,SignatureFinish_DT from T_FileList_SignatureLog ");
            strSql.Append(" where SignatureLogID=@SignatureLogID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SignatureLogID", SqlDbType.Int,8)			};
            parameters[0].Value = SignatureLogID;

            DigiPower.Onlinecol.Standard.Model.T_FileList_SignatureLog_MDL model = new DigiPower.Onlinecol.Standard.Model.T_FileList_SignatureLog_MDL();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0) {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            } else {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_FileList_SignatureLog_MDL DataRowToModel(DataRow row) {
            DigiPower.Onlinecol.Standard.Model.T_FileList_SignatureLog_MDL model = new DigiPower.Onlinecol.Standard.Model.T_FileList_SignatureLog_MDL();
            if (row != null) {
                if (row["SignatureLogID"] != null && row["SignatureLogID"].ToString() != "") {
                    model.SignatureLogID = int.Parse(row["SignatureLogID"].ToString());
                }
                if (row["FileListID"] != null && row["FileListID"].ToString() != "") {
                    model.FileListID = int.Parse(row["FileListID"].ToString());
                }
                if (row["SingleProjectID"] != null && row["SingleProjectID"].ToString() != "") {
                    model.SingleProjectID = int.Parse(row["SingleProjectID"].ToString());
                }
                if (row["Signature_DT"] != null && row["Signature_DT"].ToString() != "") {
                    model.Signature_DT = DateTime.Parse(row["Signature_DT"].ToString());
                }
                if (row["Signature_UserID"] != null && row["Signature_UserID"].ToString() != "") {
                    model.Signature_UserID = int.Parse(row["Signature_UserID"].ToString());
                }
                if (row["Signature_UserRoleCode"] != null) {
                    model.Signature_UserRoleCode = row["Signature_UserRoleCode"].ToString();
                }
                if (row["FileListTmpID"] != null && row["FileListTmpID"].ToString() != "") {
                    model.FileListTmpID = int.Parse(row["FileListTmpID"].ToString());
                }
                if (row["Message"] != null) {
                    model.Message = row["Message"].ToString();
                }
                if (row["OperationType"] != null) {
                    model.OperationType = row["OperationType"].ToString();
                }
                if (row["SignatureFinishFlag"] != null) {
                    model.SignatureFinishFlag = row["SignatureFinishFlag"].ToString();
                }
                if (row["SignatureFinish_DT"] != null && row["SignatureFinish_DT"].ToString() != "") {
                    model.SignatureFinish_DT = DateTime.Parse(row["SignatureFinish_DT"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SignatureLogID,FileListID,SingleProjectID,Signature_DT,Signature_UserID,Signature_UserRoleCode,FileListTmpID,Message,OperationType,SignatureFinishFlag,SignatureFinish_DT ");
            strSql.Append(" FROM T_FileList_SignatureLog ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
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
            strSql.Append(" SignatureLogID,FileListID,SingleProjectID,Signature_DT,Signature_UserID,Signature_UserRoleCode,FileListTmpID,Message,OperationType,SignatureFinishFlag,SignatureFinish_DT ");
            strSql.Append(" FROM T_FileList_SignatureLog ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM T_FileList_SignatureLog ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null) {
                return 0;
            } else {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim())) {
                strSql.Append("order by T." + orderby);
            } else {
                strSql.Append("order by T.SignatureLogID desc");
            }
            strSql.Append(")AS Row, T.*  from T_FileList_SignatureLog T ");
            if (!string.IsNullOrEmpty(strWhere.Trim())) {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
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
            parameters[0].Value = "T_FileList_SignatureLog";
            parameters[1].Value = "SignatureLogID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod

        #region  ExtensionMethod

        /// <summary>
        /// 获取当前角色下的上个角色的签章次数
        /// </summary>
        /// <param name="SignatureType"></param>
        /// <param name="FileListTmpID"></param>
        /// <param name="FileListID"></param>
        /// <returns></returns>
        public int GetUpSignatureCount(string SignatureType, string FileListTmpID, string FileListID, string SignatureFinishFlag) {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("SELECT COUNT(1) from T_FileList_SignatureLog where FileListID=" + FileListID + " AND SignatureFinishFlag='" + SignatureFinishFlag + "' ");
            strSql.Append("AND Signature_UserRoleCode IN( ");
            strSql.Append("SELECT top 1 SignatureType from(SELECT * from T_FileList_SignatureTmp where FileListID=" + FileListTmpID + " ");
            strSql.Append("AND OrderIndex<(SELECT OrderIndex from T_FileList_SignatureTmp where  FileListID=" + FileListTmpID + "  AND SignatureType='" + SignatureType + "')) t order by t.OrderIndex desc) ");

            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null) {
                return 0;
            } else {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 获取当前角色签章次数
        /// </summary>
        /// <param name="Hashtable"></param>     
        /// <returns></returns>
        public int GetSignatureCount(Hashtable ht) {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("SELECT COUNT(1) from T_FileList_SignatureLog where 1=1 ");
            if (ht.ContainsKey("FileListID") && Common.ConvertEx.ToString(ht["FileListID"]).Length > 0) {
                strSql.Append(" and FileListID=" + Common.ConvertEx.ToString(ht["FileListID"]) + "");
            }
            if (ht.ContainsKey("SingleProjectID") && Common.ConvertEx.ToString(ht["SingleProjectID"]).Length > 0) {
                strSql.Append(" and SingleProjectID=" + Common.ConvertEx.ToString(ht["SingleProjectID"]) + "");
            }
            if (ht.ContainsKey("Signature_UserID") && Common.ConvertEx.ToString(ht["Signature_UserID"]).Length > 0) {
                strSql.Append(" and Signature_UserID=" + Common.ConvertEx.ToString(ht["Signature_UserID"]) + "");
            }
            if (ht.ContainsKey("Signature_UserRoleCode") && Common.ConvertEx.ToString(ht["Signature_UserRoleCode"]).Length > 0) {
                strSql.Append(" and lower(Signature_UserRoleCode)='" + Common.ConvertEx.ToString(ht["Signature_UserRoleCode"]).ToLower() + "'");
            }
            if (ht.ContainsKey("SignatureFinishFlag") && Common.ConvertEx.ToString(ht["SignatureFinishFlag"]).Length > 0) {
                strSql.Append(" and SignatureFinishFlag='" + Common.ConvertEx.ToString(ht["SignatureFinishFlag"]) + "'");
            }
            if (ht.ContainsKey("OperationType") && Common.ConvertEx.ToString(ht["OperationType"]).Length > 0) {
                strSql.Append(" and lower(OperationType)='" + Common.ConvertEx.ToString(ht["OperationType"]).ToLower() + "'");
            }

            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null) {
                return 0;
            } else {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 获得数据列表 分页
        /// </summary>
        /// <returns></returns>
        public DataTable GetListPaging(string strWhere, int PageSize, int curPage, string PRIMARYKey, string OrderByName, out int recCoun) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *,(select UserName from T_UsersInfo where UserID=Signature_UserID)as SignatureUserName, ");
            strSql.Append("(select w.RoleName from T_Role w where w.RoleCode=T_FileList_SignatureLog.Signature_UserRoleCode)as RoleName ");

            strSql.Append(" FROM T_FileList_SignatureLog ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            return PageCtrl.QueryForDataTableSqlServer(strSql.ToString(), PageSize, curPage, PRIMARYKey, OrderByName, out recCoun).Tables[0];
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateSignatureFinishFlag(bool FinishFlag, string Signature_UserID, string Signature_UserRoleCode, string FileListID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_FileList_SignatureLog set SignatureFinishFlag='" + (FinishFlag ? "0" : "1") + "' ");
            strSql.Append("where Signature_UserID=" + Signature_UserID + " ");
            strSql.Append("and lower(Signature_UserRoleCode)='" + Signature_UserRoleCode.ToLower() + "'  ");
            strSql.Append("and FileListID=" + FileListID + " ");
            strSql.Append("and SignatureFinishFlag=" + (FinishFlag ? "1" : "0") + " ");

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0) {
                return true;
            } else {
                return false;
            }
        }
        #endregion  ExtensionMethod
    }
}

