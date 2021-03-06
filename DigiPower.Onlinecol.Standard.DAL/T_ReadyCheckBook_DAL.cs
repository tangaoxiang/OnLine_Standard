using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;
using System.Collections;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL {
    /// <summary>
    /// 数据访问类T_ReadyCheckBook_DAL。
    /// </summary>
    public class T_ReadyCheckBook_DAL {
        public T_ReadyCheckBook_DAL() { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId() {
            return DbHelperSQL.GetMaxID("ReadyCheckBookID", "T_ReadyCheckBook");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ReadyCheckBookID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_ReadyCheckBook");
            strSql.Append(" where ReadyCheckBookID=@ReadyCheckBookID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ReadyCheckBookID", SqlDbType.Int,8)};
            parameters[0].Value = ReadyCheckBookID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_ReadyCheckBook_MDL model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_ReadyCheckBook(");
            strSql.Append("SingleProjectID,CodeType,ReadyCheckBookCode,BeginDate,EndDate,CreateUserID,CreateTime,");
            strSql.Append("TOTAL_SCROLL,CHARACTER_SCROLL,PIC_SCROLL,PIC_PAGE_COUNT,PHOTO_COUNT,RADIO_COUNT,OTHER_MATERIAL,Directory_SCROLL,Directory_PAGE_COUNT,");
            strSql.Append("zljddw,ArchiveUserName,ArchiveUser_Tel,jsdwfzr_Name,jsdwfzr_Tel,cscd) ");
            strSql.Append(" values (");
            strSql.Append("@SingleProjectID,@CodeType,@ReadyCheckBookCode,@BeginDate,@EndDate,@CreateUserID,@CreateTime,");
            strSql.Append("@TOTAL_SCROLL,@CHARACTER_SCROLL,@PIC_SCROLL,@PIC_PAGE_COUNT,@PHOTO_COUNT,@RADIO_COUNT,@OTHER_MATERIAL,@Directory_SCROLL,@Directory_PAGE_COUNT,");
            strSql.Append("@zljddw,@ArchiveUserName,@ArchiveUser_Tel,@jsdwfzr_Name,@jsdwfzr_Tel,@cscd)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@SingleProjectID", SqlDbType.Int,8),
					new SqlParameter("@CodeType", SqlDbType.NVarChar,20),
					new SqlParameter("@ReadyCheckBookCode", SqlDbType.NVarChar,50),
					new SqlParameter("@BeginDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@CreateUserID", SqlDbType.Int,8),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@TOTAL_SCROLL",SqlDbType.Int,4),
                    new SqlParameter("@CHARACTER_SCROLL",SqlDbType.Int,4),
                    new SqlParameter("@PIC_SCROLL",SqlDbType.Int,4),
                    new SqlParameter("@PIC_PAGE_COUNT",SqlDbType.Int,4),
                    new SqlParameter("@PHOTO_COUNT",SqlDbType.Int,4),
                    new SqlParameter("@RADIO_COUNT",SqlDbType.Int,4),
                    new SqlParameter("@OTHER_MATERIAL",SqlDbType.NVarChar,200),
                    new SqlParameter("@Directory_SCROLL",SqlDbType.Int,4),
                    new SqlParameter("@Directory_PAGE_COUNT",SqlDbType.Int,4),


                    new SqlParameter("@zljddw",SqlDbType.NVarChar,100),  
                    new SqlParameter("@ArchiveUserName",SqlDbType.NVarChar,50),
                    new SqlParameter("@ArchiveUser_Tel",SqlDbType.NVarChar,20),
                    new SqlParameter("@jsdwfzr_Name",SqlDbType.NVarChar,50),
                    new SqlParameter("@jsdwfzr_Tel",SqlDbType.NVarChar,20),
                    new SqlParameter("@cscd",SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value = model.SingleProjectID;
            parameters[1].Value = model.CodeType;
            parameters[2].Value = model.ReadyCheckBookCode;
            parameters[3].Value = model.BeginDate;
            parameters[4].Value = model.EndDate;
            parameters[5].Value = model.CreateUserID;
            parameters[6].Value = model.CreateTime;
            parameters[7].Value = model.TOTAL_SCROLL;
            parameters[8].Value = model.CHARACTER_SCROLL;
            parameters[9].Value = model.PIC_SCROLL;
            parameters[10].Value = model.PIC_PAGE_COUNT;
            parameters[11].Value = model.PHOTO_COUNT;
            parameters[12].Value = model.RADIO_COUNT;
            parameters[13].Value = model.OTHER_MATERIAL;
            parameters[14].Value = model.Directory_SCROLL;
            parameters[15].Value = model.Directory_PAGE_COUNT;

            parameters[16].Value = model.zljddw;
            parameters[17].Value = model.ArchiveUserName;
            parameters[18].Value = model.ArchiveUser_Tel;
            parameters[19].Value = model.jsdwfzr_Name;
            parameters[20].Value = model.jsdwfzr_Tel;
            parameters[21].Value = model.cscd;
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
        public void Update(DigiPower.Onlinecol.Standard.Model.T_ReadyCheckBook_MDL model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_ReadyCheckBook set ");
            strSql.Append("SingleProjectID=@SingleProjectID,");
            strSql.Append("CodeType=@CodeType,");
            strSql.Append("ReadyCheckBookCode=@ReadyCheckBookCode,");
            strSql.Append("BeginDate=@BeginDate,");
            strSql.Append("EndDate=@EndDate,");
            strSql.Append("CreateUserID=@CreateUserID,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("TOTAL_SCROLL=@TOTAL_SCROLL,");
            strSql.Append("CHARACTER_SCROLL=@CHARACTER_SCROLL,");
            strSql.Append("PIC_SCROLL=@PIC_SCROLL,");
            strSql.Append("PIC_PAGE_COUNT=@PIC_PAGE_COUNT,");
            strSql.Append("PHOTO_COUNT=@PHOTO_COUNT,");
            strSql.Append("RADIO_COUNT=@RADIO_COUNT,");
            strSql.Append("OTHER_MATERIAL=@OTHER_MATERIAL,");
            strSql.Append("Directory_SCROLL=@Directory_SCROLL,");
            strSql.Append("Directory_PAGE_COUNT=@Directory_PAGE_COUNT,");

            strSql.Append("zljddw=@zljddw,");
            strSql.Append("ArchiveUserName=@ArchiveUserName,");
            strSql.Append("ArchiveUser_Tel=@ArchiveUser_Tel,");
            strSql.Append("jsdwfzr_Name=@jsdwfzr_Name,");
            strSql.Append("jsdwfzr_Tel=@jsdwfzr_Tel,");
            strSql.Append("cscd = @cscd");
            strSql.Append(" where ReadyCheckBookID=@ReadyCheckBookID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ReadyCheckBookID", SqlDbType.Int,8),
					new SqlParameter("@SingleProjectID", SqlDbType.Int,8),
					new SqlParameter("@CodeType", SqlDbType.NVarChar,20),
					new SqlParameter("@ReadyCheckBookCode", SqlDbType.NVarChar,50),
					new SqlParameter("@BeginDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@CreateUserID", SqlDbType.Int,8),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@TOTAL_SCROLL",SqlDbType.Int,4),
                    new SqlParameter("@CHARACTER_SCROLL",SqlDbType.Int,4),
                    new SqlParameter("@PIC_SCROLL",SqlDbType.Int,4),
                    new SqlParameter("@PIC_PAGE_COUNT",SqlDbType.Int,4),
                    new SqlParameter("@PHOTO_COUNT",SqlDbType.Int,4),
                    new SqlParameter("@RADIO_COUNT",SqlDbType.Int,4),
                    new SqlParameter("@OTHER_MATERIAL",SqlDbType.NVarChar,200),
                    new SqlParameter("@Directory_SCROLL",SqlDbType.Int,4),
                    new SqlParameter("@Directory_PAGE_COUNT",SqlDbType.Int,4),


                    new SqlParameter("@zljddw",SqlDbType.NVarChar,100),
                    new SqlParameter("@ArchiveUserName",SqlDbType.NVarChar,50),
                    new SqlParameter("@ArchiveUser_Tel",SqlDbType.NVarChar,20),
                    new SqlParameter("@jsdwfzr_Name",SqlDbType.NVarChar,50),
                    new SqlParameter("@jsdwfzr_Tel",SqlDbType.NVarChar,20),
                    new SqlParameter("@cscd",SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value = model.ReadyCheckBookID;
            parameters[1].Value = model.SingleProjectID;
            parameters[2].Value = model.CodeType;
            parameters[3].Value = model.ReadyCheckBookCode;
            parameters[4].Value = model.BeginDate;
            parameters[5].Value = model.EndDate;
            parameters[6].Value = model.CreateUserID;
            parameters[7].Value = model.CreateTime;
            parameters[8].Value = model.TOTAL_SCROLL;
            parameters[9].Value = model.CHARACTER_SCROLL;
            parameters[10].Value = model.PIC_SCROLL;
            parameters[11].Value = model.PIC_PAGE_COUNT;
            parameters[12].Value = model.PHOTO_COUNT;
            parameters[13].Value = model.RADIO_COUNT;
            parameters[14].Value = model.OTHER_MATERIAL;
            parameters[15].Value = model.Directory_SCROLL;
            parameters[16].Value = model.Directory_PAGE_COUNT;


            parameters[17].Value = model.zljddw;
            parameters[18].Value = model.ArchiveUserName;
            parameters[19].Value = model.ArchiveUser_Tel;
            parameters[20].Value = model.jsdwfzr_Name;
            parameters[21].Value = model.jsdwfzr_Tel;
            parameters[22].Value = model.cscd;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        public void UpdateQpNote(int SingleProjectID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_ReadyCheckBook set OTHER_MATERIAL='' ");
            strSql.Append("where SingleProjectID in(select ArchiveID from T_Archive where SingleProjectID=@SingleProjectID) and (CodeType='qianpi' or CodeType='ywsh') ");
            SqlParameter[] parameters = {
					new SqlParameter("@SingleProjectID", SqlDbType.Int,8)};
            parameters[0].Value = SingleProjectID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ReadyCheckBookID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_ReadyCheckBook ");
            strSql.Append(" where ReadyCheckBookID=@ReadyCheckBookID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ReadyCheckBookID", SqlDbType.Int,8)};
            parameters[0].Value = ReadyCheckBookID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_ReadyCheckBook_MDL GetModel(int ReadyCheckBookID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ReadyCheckBookID,SingleProjectID,CodeType,ReadyCheckBookCode,BeginDate,EndDate,CreateUserID,CreateTime, ");
            strSql.Append("TOTAL_SCROLL,CHARACTER_SCROLL,PIC_SCROLL,PIC_PAGE_COUNT,PHOTO_COUNT,RADIO_COUNT,OTHER_MATERIAL,Directory_SCROLL,Directory_PAGE_COUNT, ");
            strSql.Append("zljddw,ArchiveUserName,ArchiveUser_Tel,jsdwfzr_Name,jsdwfzr_Tel,cscd from T_ReadyCheckBook ");
            strSql.Append(" where ReadyCheckBookID=@ReadyCheckBookID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ReadyCheckBookID", SqlDbType.Int,8)};
            parameters[0].Value = ReadyCheckBookID;

            DigiPower.Onlinecol.Standard.Model.T_ReadyCheckBook_MDL model = new DigiPower.Onlinecol.Standard.Model.T_ReadyCheckBook_MDL();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["ReadyCheckBookID"].ToString() != "") {
                    model.ReadyCheckBookID = int.Parse(ds.Tables[0].Rows[0]["ReadyCheckBookID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SingleProjectID"].ToString() != "") {
                    model.SingleProjectID = int.Parse(ds.Tables[0].Rows[0]["SingleProjectID"].ToString());
                }
                model.CodeType = ds.Tables[0].Rows[0]["CodeType"].ToString();
                model.ReadyCheckBookCode = ds.Tables[0].Rows[0]["ReadyCheckBookCode"].ToString();
                if (ds.Tables[0].Rows[0]["BeginDate"].ToString() != "") {
                    model.BeginDate = DateTime.Parse(ds.Tables[0].Rows[0]["BeginDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EndDate"].ToString() != "") {
                    model.EndDate = DateTime.Parse(ds.Tables[0].Rows[0]["EndDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateUserID"].ToString() != "") {
                    model.CreateUserID = int.Parse(ds.Tables[0].Rows[0]["CreateUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "") {
                    model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TOTAL_SCROLL"].ToString() != "") {
                    model.TOTAL_SCROLL = int.Parse(ds.Tables[0].Rows[0]["TOTAL_SCROLL"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CHARACTER_SCROLL"].ToString() != "") {
                    model.CHARACTER_SCROLL = int.Parse(ds.Tables[0].Rows[0]["CHARACTER_SCROLL"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PIC_SCROLL"].ToString() != "") {
                    model.PIC_SCROLL = int.Parse(ds.Tables[0].Rows[0]["PIC_SCROLL"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PIC_PAGE_COUNT"].ToString() != "") {
                    model.PIC_PAGE_COUNT = int.Parse(ds.Tables[0].Rows[0]["PIC_PAGE_COUNT"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PHOTO_COUNT"].ToString() != "") {
                    model.PHOTO_COUNT = int.Parse(ds.Tables[0].Rows[0]["PHOTO_COUNT"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RADIO_COUNT"].ToString() != "") {
                    model.RADIO_COUNT = int.Parse(ds.Tables[0].Rows[0]["RADIO_COUNT"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OTHER_MATERIAL"].ToString() != "") {
                    model.OTHER_MATERIAL = ds.Tables[0].Rows[0]["OTHER_MATERIAL"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Directory_SCROLL"].ToString() != "") {
                    model.Directory_SCROLL = int.Parse(ds.Tables[0].Rows[0]["Directory_SCROLL"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Directory_PAGE_COUNT"].ToString() != "") {
                    model.Directory_PAGE_COUNT = int.Parse(ds.Tables[0].Rows[0]["Directory_PAGE_COUNT"].ToString());
                }


                if (ds.Tables[0].Rows[0]["zljddw"].ToString() != "") {
                    model.zljddw = ds.Tables[0].Rows[0]["zljddw"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ArchiveUserName"].ToString() != "") {
                    model.ArchiveUserName = ds.Tables[0].Rows[0]["ArchiveUserName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ArchiveUser_Tel"].ToString() != "") {
                    model.ArchiveUser_Tel = ds.Tables[0].Rows[0]["ArchiveUser_Tel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["jsdwfzr_Name"].ToString() != "") {
                    model.jsdwfzr_Name = ds.Tables[0].Rows[0]["jsdwfzr_Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["jsdwfzr_Tel"].ToString() != "") {
                    model.jsdwfzr_Tel = ds.Tables[0].Rows[0]["jsdwfzr_Tel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cscd"].ToString() != "") {
                    model.cscd = ds.Tables[0].Rows[0]["cscd"].ToString();
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
            strSql.Append("select ReadyCheckBookID,SingleProjectID,CodeType,ReadyCheckBookCode,BeginDate,EndDate,CreateUserID,CreateTime, ");
            strSql.Append("TOTAL_SCROLL,CHARACTER_SCROLL,PIC_SCROLL,PIC_PAGE_COUNT,PHOTO_COUNT,RADIO_COUNT,OTHER_MATERIAL,Directory_SCROLL,Directory_PAGE_COUNT, ");
            strSql.Append("zljddw,ArchiveUserName,ArchiveUser_Tel,jsdwfzr_Name,jsdwfzr_Tel,cscd FROM T_ReadyCheckBook ");
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
            strSql.Append(" ReadyCheckBookID,SingleProjectID,CodeType,ReadyCheckBookCode,BeginDate,EndDate,CreateUserID,CreateTime, ");
            strSql.Append("TOTAL_SCROLL,CHARACTER_SCROLL,PIC_SCROLL,PIC_PAGE_COUNT,PHOTO_COUNT,RADIO_COUNT,OTHER_MATERIAL,Directory_SCROLL,Directory_PAGE_COUNT, ");
            strSql.Append("zljddw,ArchiveUserName,ArchiveUser_Tel,jsdwfzr_Name,jsdwfzr_Tel,cscd FROM T_ReadyCheckBook ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


        #endregion  成员方法

        /// <summary>
        /// 获得数据列表 分页
        /// </summary>
        /// <returns></returns>
        public DataTable GetListPaging(Hashtable ht, int PageSize, int curPage, string PRIMARYKey, string OrderByName, out int recCoun) {
            StringBuilder strSql = new StringBuilder();
            if (ht.ContainsKey("ReadyCheckBookTypeFlag") && Common.ConvertEx.ToInt(ht["ReadyCheckBookTypeFlag"]) == 1) {//已发放   
                strSql.Append("SELECT f1.SingleProjectID keySingleProjectID, f0.*,len(ISNULL(f0.ReadyCheckBookCode,''))as lenReadyCheckBookCode,f1.gcmc,f1.gcbm,f1.ProjectType,");
                strSql.Append("(SELECT ff.UserName FROM T_UsersInfo ff where ff.UserID=f0.CreateUserID)as CreateUserName ");
                strSql.Append("from T_SingleProject f1 left JOIN T_ReadyCheckBook f0 ON f0.SingleProjectID=f1.SingleProjectID where 1=1 ");
            }
            if (ht.ContainsKey("ReadyCheckBookTypeFlag") && Common.ConvertEx.ToInt(ht["ReadyCheckBookTypeFlag"]) == 0) {//未发放  
                strSql.Append("SELECT f1.SingleProjectID keySingleProjectID,f1.gcmc,f1.gcbm,f1.ProjectType,");
                strSql.Append("'0'as lenReadyCheckBookCode,''as CreateUserName,''as CreateTime,0 as ReadyCheckBookID,''as ReadyCheckBookCode ");
                strSql.Append("from T_SingleProject f1 where 1=1 ");
            }
            return PageCtrl.QueryForDataTableSqlServer(strSql.ToString() + GetListPagingForQueryWhere(ht), PageSize, curPage, PRIMARYKey, OrderByName, out recCoun).Tables[0];
        }

        public string GetListPagingForQueryWhere(Hashtable ht) {
            StringBuilder strSql = new StringBuilder();
            if (ht.ContainsKey("AREA_CODE") && Common.ConvertEx.ToString(ht["AREA_CODE"]).Length > 0)
                strSql.Append(" And f1.Area_Code like '" + ht["AREA_CODE"].ToString() + "%'");
            if (ht.ContainsKey("OLD_AREA_CODE") && Common.ConvertEx.ToString(ht["OLD_AREA_CODE"]).Length > 0)
                strSql.Append(" And f1.Area_Code like '" + ht["OLD_AREA_CODE"].ToString() + "%'");
            if (ht.ContainsKey("ReadyCheckBookCode") && Common.ConvertEx.ToString(ht["ReadyCheckBookCode"]).Length > 0 &&
                ht.ContainsKey("ReadyCheckBookTypeFlag") && Common.ConvertEx.ToInt(ht["ReadyCheckBookTypeFlag"]) == 1)
                strSql.Append(" And f0.ReadyCheckBookCode like '%" + ht["ReadyCheckBookCode"].ToString() + "%'");
            if (ht.ContainsKey("gcmc") && Common.ConvertEx.ToString(ht["gcmc"]).Length > 0)
                strSql.Append(" And f1.gcmc like '%" + ht["gcmc"].ToString() + "%'");
            if (ht.ContainsKey("gcbm") && Common.ConvertEx.ToString(ht["gcbm"]).Length > 0)
                strSql.Append(" And f1.gcbm like '%" + ht["gcbm"].ToString() + "%'");
            if (ht.ContainsKey("ProjectType") && Common.ConvertEx.ToString(ht["ProjectType"]).Length > 0)
                strSql.Append(" And f1.ProjectType=(select SystemInfoCode from T_SystemInfo where SystemInfoID=" + ht["ProjectType"].ToString() + ")");
            if (ht.ContainsKey("ReadyCheckBookTypeFlag") && Common.ConvertEx.ToInt(ht["ReadyCheckBookTypeFlag"]) == 1) {//已发放  
                strSql.Append(" And LOWER(f0.CodeType)='" + ht["CodeType"].ToString().ToLower() + "' And len(ISNULL(f0.ReadyCheckBookCode,''))>0");
            }
            if (ht.ContainsKey("ReadyCheckBookTypeFlag") && Common.ConvertEx.ToInt(ht["ReadyCheckBookTypeFlag"]) == 0) {//未发放  
                strSql.Append(" And NOT EXISTS(select f2.* FROM T_ReadyCheckBook f2 where LOWER(f2.CodeType)='" + ht["CodeType"].ToString().ToLower() + "' ");
                strSql.Append(" And len(ISNULL(f2.ReadyCheckBookCode,''))>0 AND f1.SingleProjectID=f2.SingleProjectID)");
            }
            return strSql.ToString();
        }

        /// <summary>
        /// 获得数据列表 分页
        /// </summary>
        /// <returns></returns>
        public DataTable GetListPaging(string strWhere, params object[] obj) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT f1.SingleProjectID keySingleProjectID, f0.*,len(ISNULL(f0.ReadyCheckBookCode,''))as lenReadyCheckBookCode,f1.gcmc,f1.gcbm,f1.ProjectType,");
            strSql.Append("(SELECT ff.UserName FROM T_UsersInfo ff where ff.UserID=f0.CreateUserID)as CreateUserName, ");
            strSql.Append("(case len(ISNULL(f0.ReadyCheckBookCode,'')) when 0 then '未发放'   else '已发放' end)as StatusName,");
            strSql.Append("('" + obj[0] + "')as ReadyCheckBookCodeTypeName ");

            strSql.Append("from T_SingleProject f1 left JOIN T_ReadyCheckBook f0 ON f0.SingleProjectID=f1.SingleProjectID where 1=1 ");
            if (strWhere.Trim() != "") {
                strSql.Append(" AND " + strWhere);
            }
            strSql.Append(" order by f0.ReadyCheckBookCode,f0.ReadyCheckBookID desc ");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
    }
}

