using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;
using System.Collections;
using System.Collections.Generic;//������������
namespace DigiPower.Onlinecol.Standard.DAL {
    /// <summary>
    /// ���ݷ�����T_Company_DAL��
    /// </summary>
    public class T_Company_DAL {
        public T_Company_DAL() { }
        #region  ��Ա����

        /// <summary>
        /// �õ����ID
        /// </summary>
        public int GetMaxId() {
            return DbHelperSQL.GetMaxID("CompanyID", "T_Company");
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int CompanyID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_Company");
            strSql.Append(" where CompanyID=@CompanyID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CompanyID", SqlDbType.Int,8)};
            parameters[0].Value = CompanyID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_Company_MDL model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Company(");
            strSql.Append("AREA_CODE,CompanyName,CompanyCode,CompanyNameEn,CompanyType,Addres,ChargeUserName,CharegeID,ContactPerson,Zipcode,Tel,Fax,Mobile,EMail,Description,IsCompany,CreateDate,CreateIP,CreateUserID)");
            strSql.Append(" values (");
            strSql.Append("@AREA_CODE,@CompanyName,@CompanyCode,@CompanyNameEn,@CompanyType,@Addres,@ChargeUserName,@CharegeID,@ContactPerson,@Zipcode,@Tel,@Fax,@Mobile,@EMail,@Description,@IsCompany,@CreateDate,@CreateIP,@CreateUserID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@AREA_CODE", SqlDbType.VarChar,8),
					new SqlParameter("@CompanyName", SqlDbType.NVarChar,200),
					new SqlParameter("@CompanyCode", SqlDbType.NChar,60),
					new SqlParameter("@CompanyNameEn", SqlDbType.NVarChar,200),
					new SqlParameter("@CompanyType", SqlDbType.Int,8),
					new SqlParameter("@Addres", SqlDbType.NVarChar,100),
					new SqlParameter("@ChargeUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@CharegeID", SqlDbType.NVarChar,20),
					new SqlParameter("@ContactPerson", SqlDbType.NVarChar,20),
					new SqlParameter("@Zipcode", SqlDbType.NVarChar,20),
					new SqlParameter("@Tel", SqlDbType.NVarChar,20),
					new SqlParameter("@Fax", SqlDbType.NVarChar,20),
					new SqlParameter("@Mobile", SqlDbType.NVarChar,20),
					new SqlParameter("@EMail", SqlDbType.NVarChar,60),
					new SqlParameter("@Description", SqlDbType.NVarChar),
					new SqlParameter("@IsCompany", SqlDbType.Bit,1),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@CreateIP", SqlDbType.NVarChar,20),
                    new SqlParameter("@CreateUserID", SqlDbType.Int,8) };

            parameters[0].Value = model.AREA_CODE;
            parameters[1].Value = model.CompanyName;
            parameters[2].Value = model.CompanyCode;
            parameters[3].Value = model.CompanyNameEn;
            parameters[4].Value = model.CompanyType;
            parameters[5].Value = model.Addres;
            parameters[6].Value = model.ChargeUserName;
            parameters[7].Value = model.CharegeID;
            parameters[8].Value = model.ContactPerson;
            parameters[9].Value = model.Zipcode;
            parameters[10].Value = model.Tel;
            parameters[11].Value = model.Fax;
            parameters[12].Value = model.Mobile;
            parameters[13].Value = model.EMail;
            parameters[14].Value = model.Description;
            parameters[15].Value = model.IsCompany;
            parameters[16].Value = model.CreateDate;
            parameters[17].Value = model.CreateIP;
            parameters[18].Value = model.CreateUserID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null) {
                return 1;
            } else {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(DigiPower.Onlinecol.Standard.Model.T_Company_MDL model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Company set ");
            strSql.Append("AREA_CODE=@AREA_CODE,");
            strSql.Append("CompanyName=@CompanyName,");
            strSql.Append("CompanyCode=@CompanyCode,");
            strSql.Append("CompanyNameEn=@CompanyNameEn,");
            strSql.Append("CompanyType=@CompanyType,");
            strSql.Append("Addres=@Addres,");
            strSql.Append("ChargeUserName=@ChargeUserName,");
            strSql.Append("CharegeID=@CharegeID,");
            strSql.Append("ContactPerson=@ContactPerson,");
            strSql.Append("Zipcode=@Zipcode,");
            strSql.Append("Tel=@Tel,");
            strSql.Append("Fax=@Fax,");
            strSql.Append("Mobile=@Mobile,");
            strSql.Append("EMail=@EMail,");
            strSql.Append("Description=@Description,");
            strSql.Append("IsCompany=@IsCompany,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("CreateIP=@CreateIP,");
            strSql.Append("CreateUserID=@CreateUserID");

            strSql.Append(" where CompanyID=@CompanyID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CompanyID", SqlDbType.Int,8),
					new SqlParameter("@AREA_CODE", SqlDbType.VarChar,8),
					new SqlParameter("@CompanyName", SqlDbType.NVarChar,200),
					new SqlParameter("@CompanyCode", SqlDbType.NChar,60),
					new SqlParameter("@CompanyNameEn", SqlDbType.NVarChar,200),
					new SqlParameter("@CompanyType", SqlDbType.Int,8),
					new SqlParameter("@Addres", SqlDbType.NVarChar,100),
					new SqlParameter("@ChargeUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@CharegeID", SqlDbType.NVarChar,20),
					new SqlParameter("@ContactPerson", SqlDbType.NVarChar,20),
					new SqlParameter("@Zipcode", SqlDbType.NVarChar,20),
					new SqlParameter("@Tel", SqlDbType.NVarChar,20),
					new SqlParameter("@Fax", SqlDbType.NVarChar,20),
					new SqlParameter("@Mobile", SqlDbType.NVarChar,20),
					new SqlParameter("@EMail", SqlDbType.NVarChar,60),
					new SqlParameter("@Description", SqlDbType.NVarChar),
					new SqlParameter("@IsCompany", SqlDbType.Bit,1),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@CreateIP", SqlDbType.NVarChar,20),
                    new SqlParameter("@CreateUserID", SqlDbType.Int,8) };

            parameters[0].Value = model.CompanyID;
            parameters[1].Value = model.AREA_CODE;
            parameters[2].Value = model.CompanyName;
            parameters[3].Value = model.CompanyCode;
            parameters[4].Value = model.CompanyNameEn;
            parameters[5].Value = model.CompanyType;
            parameters[6].Value = model.Addres;
            parameters[7].Value = model.ChargeUserName;
            parameters[8].Value = model.CharegeID;
            parameters[9].Value = model.ContactPerson;
            parameters[10].Value = model.Zipcode;
            parameters[11].Value = model.Tel;
            parameters[12].Value = model.Fax;
            parameters[13].Value = model.Mobile;
            parameters[14].Value = model.EMail;
            parameters[15].Value = model.Description;
            parameters[16].Value = model.IsCompany;
            parameters[17].Value = model.CreateDate;
            parameters[18].Value = model.CreateIP;
            parameters[19].Value = model.CreateUserID;


            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int CompanyID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Company ");
            strSql.Append(" where CompanyID=@CompanyID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CompanyID", SqlDbType.Int,8)};
            parameters[0].Value = CompanyID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_Company_MDL GetModel(int CompanyID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CompanyID,AREA_CODE,CompanyName,CompanyCode,CompanyNameEn,CompanyType,Addres,ChargeUserName,CharegeID,ContactPerson,Zipcode,Tel,Fax,Mobile,EMail,Description,IsCompany,CreateDate,CreateIP,CreateUserID from T_Company ");
            strSql.Append(" where CompanyID=@CompanyID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CompanyID", SqlDbType.Int,8)};
            parameters[0].Value = CompanyID;

            DigiPower.Onlinecol.Standard.Model.T_Company_MDL model = new DigiPower.Onlinecol.Standard.Model.T_Company_MDL();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["CompanyID"].ToString() != "") {
                    model.CompanyID = int.Parse(ds.Tables[0].Rows[0]["CompanyID"].ToString());
                }
                model.AREA_CODE = ds.Tables[0].Rows[0]["AREA_CODE"].ToString();
                model.CompanyName = ds.Tables[0].Rows[0]["CompanyName"].ToString();
                model.CompanyCode = ds.Tables[0].Rows[0]["CompanyCode"].ToString();
                model.CompanyNameEn = ds.Tables[0].Rows[0]["CompanyNameEn"].ToString();
                if (ds.Tables[0].Rows[0]["CompanyType"].ToString() != "") {
                    model.CompanyType = int.Parse(ds.Tables[0].Rows[0]["CompanyType"].ToString());
                }
                model.Addres = ds.Tables[0].Rows[0]["Addres"].ToString();
                model.ChargeUserName = ds.Tables[0].Rows[0]["ChargeUserName"].ToString();
                model.CharegeID = ds.Tables[0].Rows[0]["CharegeID"].ToString();
                model.ContactPerson = ds.Tables[0].Rows[0]["ContactPerson"].ToString();
                model.Zipcode = ds.Tables[0].Rows[0]["Zipcode"].ToString();
                model.Tel = ds.Tables[0].Rows[0]["Tel"].ToString();
                model.Fax = ds.Tables[0].Rows[0]["Fax"].ToString();
                model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                model.EMail = ds.Tables[0].Rows[0]["EMail"].ToString();
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                if (ds.Tables[0].Rows[0]["IsCompany"].ToString() != "") {
                    if ((ds.Tables[0].Rows[0]["IsCompany"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsCompany"].ToString().ToLower() == "true")) {
                        model.IsCompany = true;
                    } else {
                        model.IsCompany = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["CreateDate"].ToString() != "") {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                model.CreateIP = ds.Tables[0].Rows[0]["CreateIP"].ToString();

                if (ds.Tables[0].Rows[0]["CreateUserID"].ToString() != "") {
                    model.CreateUserID = int.Parse(ds.Tables[0].Rows[0]["CreateUserID"].ToString());
                }


                return model;
            } else {
                return null;
            }
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CompanyID,AREA_CODE,CompanyName,CompanyCode,CompanyNameEn,CompanyType,Addres,ChargeUserName,CharegeID,ContactPerson,Zipcode,Tel,Fax,Mobile,EMail,Description,IsCompany,CreateDate,CreateIP,CreateUserID ");
            strSql.Append(" FROM T_Company ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0) {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" CompanyID,AREA_CODE,CompanyName,CompanyCode,CompanyNameEn,CompanyType,Addres,ChargeUserName,CharegeID,ContactPerson,Zipcode,Tel,Fax,Mobile,EMail,Description,IsCompany,CreateDate,CreateIP,CreateUserID ");
            strSql.Append(" FROM T_Company ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  ��Ա����
        public DataSet BindDataWithNoJSDW() {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select A.* from T_Company A,T_SystemInfo B WHERE A.CompanyType=B.SystemInfoID AND CurrentType='CompanyType' AND SystemInfoCode<>'JSCompanyInfo'");
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// ParentCompanyID,����ȡ�ҹ�˾�����µ����й�˾
        /// MyCompanyID,ֻ��ȡ�ҵĹ�˾��Ϣ
        /// ���ǿձ�ʾȡȫ��
        /// </summary>
        /// <param name="CompanyType"></param>
        /// <param name="CompanyName"></param>
        /// <param name="ParentCompanyID"></param>
        /// <param name="MyCompanyID"></param>
        /// <returns></returns>
        public DataSet GetMyChildCompany(string CompanyType, string CompanyName, string ParentCompanyID, string MyCompanyID) {//�Ƚϸ���
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT DISTINCT A.*,C.* FROM T_Company A,T_SingleProjectCompany B,T_SystemInfo C ");
            strSql.Append(" WHERE A.CompanyType=C.SystemInfoID AND A.CompanyID=B.CompanyID ");
            if (MyCompanyID != "") {
                strSql.Append(" AND A.CompanyID=" + MyCompanyID);
            }

            if (CompanyType != "0" && CompanyType != "") {
                strSql.Append(" AND A.CompanyType=" + CompanyType);
            }
            if (!String.IsNullOrEmpty(CompanyName)) {
                strSql.Append(" AND A.CompanyName LIKE '%" + CompanyName + "%'");
            }

            if (MyCompanyID == "" && ParentCompanyID != "") {
                strSql.Append(" AND B.SingleProjectID IN (SELECT DISTINCT SingleProjectID FROM T_Company A,T_Construction_Project B,T_SingleProject C WHERE A.CompanyID=B.CompanyID AND B.ConstructionProjectID=C.ConstructionProjectID ");
                strSql.Append(" AND A.CompanyID=" + ParentCompanyID);
                strSql.Append(")");
            }

            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// ParentCompanyID,����ȡ�ҹ�˾�����µ����й�˾
        /// MyCompanyID,ֻ��ȡ�ҵĹ�˾��Ϣ
        /// ���ǿձ�ʾȡȫ��
        /// </summary>
        /// <param name="CompanyType"></param>
        /// <param name="CompanyName"></param>
        /// <param name="ParentCompanyID"></param>
        /// <param name="MyCompanyID"></param>
        /// <returns></returns>
        public DataSet GetMyChildCompany(string CompanyType, string CompanyName, string ParentCompanyID, string MyCompanyID, string Area_Code) {//�Ƚϸ���
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT DISTINCT A.*,C.*, ");

            strSql.Append("(select top 1 gcmc from T_SingleProject t where t.SingleProjectID in(");   //jdk 2014.4.11
            strSql.Append("select SingleProjectID from T_SingleProjectCompany t1 where t1.CompanyID=a.CompanyID)) as gcmc ");

            strSql.Append(" FROM T_Company A,T_SingleProjectCompany B,T_SystemInfo C ");
            strSql.Append(" WHERE A.CompanyType=C.SystemInfoID AND A.CompanyID=B.CompanyID ");
            if (Area_Code != "") {
                strSql.Append(" AND A.Area_Code like '" + Area_Code + "%'");
            }

            if (MyCompanyID != "") {
                strSql.Append(" AND A.CompanyID=" + MyCompanyID);
            }

            if (CompanyType != "0" && CompanyType != "") {
                strSql.Append(" AND A.CompanyType=" + CompanyType);
            }
            if (!String.IsNullOrEmpty(CompanyName)) {
                strSql.Append(" AND A.CompanyName LIKE '%" + CompanyName + "%'");
            }

            if (MyCompanyID == "" && ParentCompanyID != "") {
                strSql.Append(" AND B.SingleProjectID IN (SELECT DISTINCT SingleProjectID FROM T_Company A,T_Construction_Project B,T_SingleProject C WHERE A.CompanyID=B.CompanyID AND B.ConstructionProjectID=C.ConstructionProjectID ");
                strSql.Append(" AND A.CompanyID=" + ParentCompanyID);
                strSql.Append(")");
            }

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// ��������б� ��ҳ
        /// </summary>
        /// <returns></returns>
        public DataTable GetMyChildCompany(string Gcmc, string CompanyType, string CompanyName, string ParentCompanyID, string MyCompanyID, string Area_Code,
            int PageSize, int curPage, string PRIMARYKey, string OrderByName, out int recCoun) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT DISTINCT A.*,C.*,D.UserName,D.LoginName,D.UserID,D.RoleID ");

            string sqlGcmc = string.Empty;
            if (Gcmc.Length > 0) {
                sqlGcmc = "And t.gcmc like '%" + Gcmc + "%' ";
            }

            strSql.Append(" FROM T_Company A,T_SingleProjectCompany B,T_SystemInfo C,T_UsersInfo D ");
            strSql.Append(" WHERE A.CompanyType=C.SystemInfoID AND A.CompanyID=B.CompanyID AND A.CompanyID=D.CompanyID ");

            if (Area_Code != "") {
                strSql.Append(" AND A.Area_Code like '" + Area_Code + "%'");
            }

            if (MyCompanyID != "") {
                strSql.Append(" AND A.CompanyID=" + MyCompanyID);
            }

            if (CompanyType != "0" && CompanyType != "") {
                strSql.Append(" AND A.CompanyType=" + CompanyType);
            }
            if (!String.IsNullOrEmpty(CompanyName)) {
                strSql.Append(" AND A.CompanyName LIKE '%" + CompanyName + "%'");
            }

            if (MyCompanyID == "" && ParentCompanyID != "") {
                strSql.Append(" AND B.SingleProjectID IN (SELECT DISTINCT SingleProjectID FROM T_Company A,T_Construction_Project B,T_SingleProject C WHERE A.CompanyID=B.CompanyID AND B.ConstructionProjectID=C.ConstructionProjectID ");
                strSql.Append(" AND A.CompanyID=" + ParentCompanyID);
                strSql.Append(")");
            }
            return PageCtrl.QueryForDataTableSqlServer(strSql.ToString(), PageSize, curPage, PRIMARYKey, OrderByName, out recCoun).Tables[0];
        }

        /// <summary>
        /// ��������б� ��ҳ
        /// </summary>
        /// <returns></returns>
        public DataTable GetMyChildCompany(Hashtable ht, int PageSize, int curPage, string PRIMARYKey, string OrderByName, out int recCoun) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT a.*,c.SystemInfoName as CompanyTypeName,");
            strSql.Append(" b.UserName,b.UserID,b.LoginName,b.RoleID,d.RoleName ");
            strSql.Append(" from T_Company a INNER JOIN T_UsersInfo b ON a.CompanyID=b.CompanyID ");
            strSql.Append(" and a.IsCompany=1 and b.IsValid=1 ");
            strSql.Append(" INNER JOIN T_SystemInfo c ON a.CompanyType=c.SystemInfoID ");
            strSql.Append(" INNER JOIN T_Role d ON b.RoleID=d.RoleID ");
            strSql.Append(" where 1=1 ");

            if (ht.ContainsKey("RoleCode") && Common.ConvertEx.ToString(ht["RoleCode"]).Length > 0 &&
                ht.ContainsKey("RoleType") && Common.ConvertEx.ToString(ht["RoleType"]).Length > 0) {
                strSql.Append(" and lower(d.RoleCode)='" + Common.ConvertEx.ToString(ht["RoleCode"]) + "' ");
                strSql.Append(" and lower(d.RoleType)='" + Common.ConvertEx.ToString(ht["RoleType"]) + "' ");
            }
            if (ht.ContainsKey("Area_Code") && Common.ConvertEx.ToString(ht["Area_Code"]).Length > 0) {
                strSql.Append(" and a.Area_Code LIKE '%" + Common.ConvertEx.ToString(ht["Area_Code"]) + "%'");
            }
            if (ht.ContainsKey("InCompanyType") && Common.ConvertEx.ToString(ht["InCompanyType"]).Length > 0) {
                strSql.Append(" and a.CompanyType in(" + Common.ConvertEx.ToString(ht["InCompanyType"]) + ")");
            }
            if (ht.ContainsKey("CompanyName") && Common.ConvertEx.ToString(ht["CompanyName"]).Length > 0) {
                strSql.Append(" and a.CompanyName LIKE '%" + Common.ConvertEx.ToString(ht["CompanyName"]) + "%'");
            }
            if (ht.ContainsKey("CompanyType") && Common.ConvertEx.ToString(ht["CompanyType"]).Length > 0) {
                strSql.Append(" and a.CompanyType =" + Common.ConvertEx.ToString(ht["CompanyType"]) + "");
            }
            if (ht.ContainsKey("UserName") && Common.ConvertEx.ToString(ht["UserName"]).Length > 0) {
                strSql.Append(" and b.UserName LIKE '%" + Common.ConvertEx.ToString(ht["UserName"]) + "%'");
            }
            if (ht.ContainsKey("CompanyID") && Common.ConvertEx.ToString(ht["CompanyID"]).Length > 0) {
                strSql.Append(" and a.CompanyID=" + Common.ConvertEx.ToString(ht["CompanyID"]) + " ");
            }
            if (ht.ContainsKey("NotINSingleProjectID") && Common.ConvertEx.ToString(ht["NotINSingleProjectID"]).Length > 0) {
                strSql.Append(" and NOT EXISTS (select DISTINCT f.CompanyID from T_SingleProjectCompany f ");
                strSql.Append(" where f.SingleProjectID=" + Common.ConvertEx.ToString(ht["NotINSingleProjectID"]) + " AND a.CompanyID=f.CompanyID)");
            }  

            return PageCtrl.QueryForDataTableSqlServer(strSql.ToString(), PageSize, curPage, PRIMARYKey, OrderByName, out recCoun).Tables[0];
        }

        /// <summary>
        /// ɾ����˾ʱ�����������ϢҲɾ��
        /// Ŀǰֻ����ɾ�� ����/ʩ��
        /// </summary>
        /// <param name="CompanyID"></param>
        /// <returns></returns>
        public bool DeleteCompanyOther(string CompanyID) {
            try {
                if (CompanyID.Trim().Length > 0) {
                    List<string> listSql = new List<string>();
                    listSql.Add("delete from T_COMPANY where COMPANYID=" + CompanyID);                         //ɾ����˾
                    listSql.Add("delete from T_SINGLEPROJECTCOMPANY where COMPANYID=" + CompanyID);            //ɾ�����̹�˾��
                    listSql.Add("delete from T_SingleProjectUser where UserID in(SELECT UserID from T_UsersInfo where CompanyID=" + CompanyID + ")");  //ɾ����˾�û���
                    listSql.Add("delete from T_USERSINFO where COMPANYID=" + CompanyID);                       //ɾ���û���     
                    listSql.Add("delete from T_FileList where COMPANYID=" + CompanyID);                        //ɾ���ļ���
                    DbHelperSQL.ExecuteSqlTran(listSql);
                }
                return true;
            } catch {
                return false;
            }
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(string sqlWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_Company ");
            strSql.Append(" where " + sqlWhere);
            return DbHelperSQL.Exists(strSql.ToString());
        }

    }
}
