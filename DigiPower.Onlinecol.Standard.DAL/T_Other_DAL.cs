using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;
using System.Collections;
using System.Collections.Generic;//请先添加引用

namespace DigiPower.Onlinecol.Standard.DAL {
    /// <summary>
    /// 数据访问类T_ArchiveLend_DAL。
    /// </summary>
    public class T_Other_DAL {
        public T_Other_DAL() { }
        #region  成员方法

        /// <summary>
        /// 返回案卷信息
        /// </summary>
        /// <param name="SingleProjectID">SingleProjectID</param>
        /// <returns>count(*)as archiveCount,sum(wz)as wz ,sum(zp)as zp,sum(tzz)as tzz ,sum(hh)as hh(混合卷) </returns>
        public DataSet GetArchiveInfo(string SingleProjectID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(*)as archiveCount,sum(CAST(isnull(list.wz,0) as int))as wz,sum(CAST(isnull(list.zp,0) as int))as zp, ");
            strSql.Append("sum(CAST(isnull(list.tzz,0) as int))as tzz,sum(CAST(isnull(list.hh,0) as int))as hh from( select ");
            strSql.Append("(select COUNT(1) from T_SystemInfo ts where ts.SystemInfoID=ta.ajlx and ts.CurrentType='06' and ts.SystemInfoCode='1')as wz , ");
            strSql.Append("(select COUNT(1) from T_SystemInfo ts where ts.SystemInfoID=ta.ajlx and ts.CurrentType='06' and ts.SystemInfoCode='2')as tzz, ");
            strSql.Append("(select COUNT(1) from T_SystemInfo ts where ts.SystemInfoID=ta.ajlx and ts.CurrentType='06' and ts.SystemInfoCode='3')as zp, ");
            strSql.Append("(select COUNT(1) from T_SystemInfo ts where ts.SystemInfoID=ta.ajlx and ts.CurrentType='06' and ts.SystemInfoCode='4')as hh ");
            strSql.Append("from T_Archive ta where ta.SingleProjectID=@SingleProjectID)list ");
            SqlParameter[] parameters = {
					new SqlParameter("@SingleProjectID", SqlDbType.Int,8)};
            parameters[0].Value = SingleProjectID;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 返回报表的所有查询条件
        /// </summary>
        /// <param name="ReportCode"></param>
        /// <returns></returns>
        public DataSet GetSearchFieldPara(string ReportCode) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT tf.Search_Field_ID,tf.ReportCode,tf.TableName,tf.TableNameCN,tf.LabelName,tf.FieldName, ");
            strSql.Append("tf.Line,tf.OrderId as tf_OrderId,tp.Search_Para_ID,tp.ParaType,tp.ParaTypeCN, ");
            strSql.Append("tp.ControlWidth,tp.CompareType,tp.CompareTypeCN,tp.DefaultValue,tp.SourceSql,tp.OrderId as tp_OrderId ");
            strSql.Append("FROM T_Search_Field as tf,T_Search_Para as tp WHERE tf.Search_Field_ID=tp.Search_Field_ID ");
            strSql.Append("AND tf.ReportCode=@ReportCode ORDER BY tf.OrderId,tp.OrderId asc ");

            SqlParameter[] parameters = {
					new SqlParameter("@ReportCode", SqlDbType.VarChar,50)};
            parameters[0].Value = ReportCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 检测SQL语句是否合法
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public bool CheckDefindSql(string strSql) {
            try {
                DataSet ds = DbHelperSQL.Query(strSql);
                return true;
            } catch {
                return false;
            }
        }

        /// <summary>
        /// 返回指定SQL的数据集
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public DataSet GetDataSet(string strSql) {
            return DbHelperSQL.Query(strSql);
        }

        /// <summary>
        /// 返回数据库中所有表
        /// </summary>
        /// <returns></returns>
        public DataSet GetDataBaseTableList() {
            return DbHelperSQL.Query("select name from sysobjects where type='U' order by name ");
        }

        /// <summary>
        /// 返回所有的报表个数
        /// </summary>
        /// <returns></returns>
        public int GetReportListCount() {
            return Common.ConvertEx.ToInt(DbHelperSQL.GetSingle("select count(*) from T_Report"));
        }

        /// <summary>
        /// 返回所有报表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public DataSet GetReportList(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select T_Report_Type.*,T_Report.* from T_Report_Type,T_Report ");
            strSql.Append("where T_Report.ReportTypeID=T_Report_Type.ReportTypeID AND T_Report_Type.IsValid=1 ");
            strSql.Append("AND T_Report.IsValid=1 ");

            if (!String.IsNullOrEmpty(strWhere) && strWhere.Trim().Length > 0) {
                strSql.Append("AND " + strWhere + " ");
            }
            strSql.Append("ORDER BY T_Report_Type.ReportTypeID,T_Report.ReportID DESC");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 返回所有的培训记录
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public DataSet GetTrainRec(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TP.Subject,UI.UserName,CP.CompanyName,TP.PlanDate,TP.FinishDate,Rec.TrainRecID ");
            strSql.Append("FROM T_Train_Rec as Rec,T_Train_Plan as TP,T_UsersInfo as UI ,T_Company as CP ");
            strSql.Append("WHERE Rec.UserID=UI.UserID AND Rec.TrainPlanID=TP.TrainPlanID ");
            strSql.Append("AND UI.CompanyID=CP.CompanyID ");

            if (!String.IsNullOrEmpty(strWhere) && strWhere.Trim().Length > 0) {
                strSql.Append("AND " + strWhere);
            }
            strSql.Append(" ORDER BY Rec.TrainPlanID,Rec.TrainRecID DESC");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 判断培训记录中,用户和培训任务是否被重复添加
        /// </summary>
        /// <param name="TrainPlanID">培训任务ID</param>
        /// <param name="UserID">档案员ID</param>
        /// <param name="TrainRecID">档案记录ID</param>
        /// <param name="Action">新增(add)或修改(edit)</param>
        /// <returns></returns>
        public bool GetTrainRecExistUserOrPlan(string TrainPlanID, string UserID, string TrainRecID, string Action) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) from T_Train_Rec where TrainPlanID=" + TrainPlanID + " And UserID=" + UserID + " ");
            if (Action == "edit") {
                strSql.Append(" AND TrainRecID !=" + TrainRecID + "");
            }

            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 删除培训计划下所有的档案员
        /// </summary>
        /// <param name="TrainPlanID">培训计划ID</param>
        public void DeleteTrainRecUser(int TrainPlanID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Train_Rec ");
            strSql.Append(" where TrainPlanID=@TrainPlanID ");
            SqlParameter[] parameters = {
					new SqlParameter("@TrainPlanID", SqlDbType.Int,8)};
            parameters[0].Value = TrainPlanID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 返回培训计划下所有档案员
        /// </summary>
        /// <param name="TrainPlanID">培训计划ID</param>
        /// <returns></returns>
        public DataSet GetTrainPlanToArchiveUser(int TrainPlanID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select T_UsersInfo.UserName,T_UsersInfo.UserID from T_UsersInfo,T_Train_Rec where ");
            strSql.Append("T_Train_Rec.UserID=T_UsersInfo.UserID and T_Train_Rec.TrainPlanID=@TrainPlanID ");
            strSql.Append("order by T_UsersInfo.UserID desc ");
            SqlParameter[] parameters = { 
                   new SqlParameter("@TrainPlanID",SqlDbType.Int,4)};
            parameters[0].Value = TrainPlanID;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新培训备注和培训结果
        /// </summary>
        /// <param name="TrainPlanID">培训计划ID</param>
        /// <param name="UserID">档案员ID</param>
        /// <param name="TrainDesc">培训备注</param>
        /// <param name="TrainResult">培训结果</param>
        /// <returns></returns>
        public int SetTrainRecDescAndResult(int TrainPlanID, int UserID, string TrainDesc, string TrainResult) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Train_Rec set TrainDesc=@TrainDesc,TrainResult=@TrainResult ");
            strSql.Append("where TrainPlanID=@TrainPlanID and UserID=@UserID");

            SqlParameter[] parameters = { 
                   new SqlParameter("@TrainDesc",SqlDbType.VarChar,500),
                   new SqlParameter("@TrainResult",SqlDbType.VarChar,20),
                   new SqlParameter("@TrainPlanID",SqlDbType.Int,4),
                   new SqlParameter("@UserID",SqlDbType.Int,4)};
            parameters[0].Value = TrainDesc;
            parameters[1].Value = TrainResult;
            parameters[2].Value = TrainPlanID;
            parameters[3].Value = UserID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public DataSet GetReadyReturn(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT distinct UserName,OutTime,d.FilenID,d.DH,d.ajtm,a.ReadyReturnTime FROM T_ArchiveLend a,T_UsersInfo b,T_ArchiveLendDHList c,FILEN d where a.ReqUserID=b.UserID and a.ArchiveLendID=c.ArchiveLendID and c.DH=d.FilenID AND a.ReadyReturnTime<='" + DateTime.Now + "'");
            if (strWhere.Trim() != "") {
                strSql.Append(" AND " + strWhere);
            }
            strSql.Append(" Order By a.ReadyReturnTime DESC");
            return DbHelperSQL.Query(strSql.ToString());
        }

        public void UpdateArchiveStatus(string FileListID, int Status) {//需要选判下原来是什么状态，如果是二次提交需要具分
            if (Status < 0) {//表示退回
                string strSql = "UPDATE T_FileList SET Status=OldStatus WHERE FileListID=" + FileListID;//不必提交
                DbHelperSQL.Query(strSql);
            } else {
                string strSql = "SELECT Status FROM T_FileList WHERE FileListID=" + FileListID;
                int OldStatus = Common.ConvertEx.ToInt(Common.ConvertEx.ToString(DbHelperSQL.GetSingle(strSql)));
                if (OldStatus == 900 && Status == 10) {
                    Status = 800;
                }

                if (OldStatus != Status) {
                    //记最上次的状态，以便恢复,只有状态变了才更新，否则没有最后有效状态。好好体会一下！
                    strSql = "UPDATE T_FileList SET OldStatus=Status WHERE FileListID=" + FileListID;
                    DbHelperSQL.Query(strSql);

                    strSql = "UPDATE T_FileList SET Status='" + Status + "' WHERE FileListID=" + FileListID;
                    DbHelperSQL.Query(strSql);
                }
            }
            //通过以下替归，更新所有上级目录，否则无法显示出来
            //UpdateArchiveParentStatus(FileListID, Status);
        }

        public void UpdateArchiveStatus(string FileListID, int Status, string isFolder) {//需要选判下原来是什么状态，如果是二次提交需要具分
            if (Status < 0) {//表示退回
                string strSql = "UPDATE T_FileList SET Status=OldStatus WHERE IsFolder=" + isFolder + " and FileListID=" + FileListID;//不必提交
                DbHelperSQL.Query(strSql);
            } else {
                string strSql = "SELECT Status FROM T_FileList WHERE  IsFolder=" + isFolder + " and FileListID=" + FileListID;
                int OldStatus = Common.ConvertEx.ToInt(Common.ConvertEx.ToString(DbHelperSQL.GetSingle(strSql)));
                if (OldStatus == 900 && Status == 10) {
                    Status = 800;
                }

                if (OldStatus != Status) {
                    //记最上次的状态，以便恢复,只有状态变了才更新，否则没有最后有效状态。好好体会一下！
                    strSql = "UPDATE T_FileList SET OldStatus=Status WHERE  IsFolder=" + isFolder + " and FileListID=" + FileListID;
                    DbHelperSQL.Query(strSql);

                    strSql = "UPDATE T_FileList SET Status='" + Status + "' WHERE  IsFolder=" + isFolder + " and FileListID=" + FileListID;
                    DbHelperSQL.Query(strSql);
                }
            }
            //通过以下替归，更新所有上级目录，否则无法显示出来
            //UpdateArchiveParentStatus(FileListID, Status);
        }

        //生成下一个项目ID
        public string GetNewProjectID() {
            //string strSql = "select top 1 xmh from T_Construction_Project order by ConstructionProjectID desc";
            string strSql = "select max(xmh) from T_Construction_Project";
            string xmh = DbHelperSQL.GetSingle(strSql).ToString();

            return NextNew(xmh);
        }

        private string NextNew(string maxXMH) {//采用年度+流水的编码方式 2010-002或2010002
            //加多1位 2011-0001 可支持1万个项目每年
            if (maxXMH == "")
                maxXMH = System.DateTime.Now.Year.ToString("YYYY") + "-0001";

            string NewID = "";
            string Y = maxXMH.Substring(0, 4);
            if (Common.ConvertEx.ToInt(Y) != System.DateTime.Now.Year) {
                NewID = System.DateTime.Now.Year.ToString() + maxXMH.Substring(4, maxXMH.Length - 8) + "0001";
            } else {
                int LSH = Common.ConvertEx.ToInt(maxXMH.Substring(maxXMH.Length - 4)) + 1;
                NewID = Y + "-" + LSH.ToString("0000");
            }
            return NewID;
        }

        //生成下一个工程ID
        public string GetNewEngineerID() {
            string xmh = "";
            string strSql = "select top 1 gcbm from T_SingleProject order by gcbm desc";
            object oXMH = DbHelperSQL.GetSingle(strSql);
            if (oXMH == null) {
                xmh = System.DateTime.Now.Year.ToString("YYYY") + "-0001";
            } else {
                xmh = oXMH.ToString();
            }

            return NextNew(xmh);
        }

        //项目是否已经启动
        public bool GetSingleProjectStart(string SingleProjectID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_WorkFlowDefine where SingleProjectID=" + SingleProjectID + " and PID<>0 and DoStatus=1");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        //项目下是否有工程
        public bool GetSingleProjectExistByConstructionID(string ConstructionID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_SingleProject where ConstructionProjectID=" + ConstructionID);
            return DbHelperSQL.Exists(strSql.ToString());
        }

        //签章信息
        public DataSet GetCompanySignet(int CompanyID, string CompanyTypeName) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT T_SystemInfo.*,T_FileAttach.AttachID,T_FileAttach.AttachPath FROM T_SystemInfo LEFT OUTER JOIN T_FileAttach ON T_SystemInfo.SystemInfoCode = T_FileAttach.AttachCode and PriKeyValue=" + CompanyID + " WHERE (T_SystemInfo.CurrentType = 'SignetType' AND T_SystemInfo.SubType='" + CompanyTypeName + "')");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 删除案卷
        /// </summary>
        /// <param name="strWhere"></param>
        //public void DeleteFileToArchive(string strWhere)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("delete from T_FileToArchive ");
        //    if (strWhere.Trim().Length > 0)
        //    {
        //        strSql.Append("where " + strWhere);
        //    }

        //    DbHelperSQL.ExecuteSql(strSql.ToString());
        //}

        //取某工程所有用户列表
        //public DataSet GetUsersBySingleProjectID(string SingleProjectID)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("SELECT T_SystemInfo.*,T_FileAttach.AttachID,T_FileAttach.AttachPath FROM T_SystemInfo LEFT OUTER JOIN T_FileAttach ON T_SystemInfo.SystemInfoCode = T_FileAttach.AttachCode and PriKeyValue=" + CompanyID + " WHERE (T_SystemInfo.CurrentType = 'SignetType')");
        //    return DbHelperSQL.Query(strSql.ToString());
        //}


        /// <summary>
        /// 判断是否为监理或施工类型
        /// </summary>
        /// <param name="CompanyTypeID">类型ID</param>
        /// <returns></returns>
        //public bool IsCompanyJLOrSG(int CompanyTypeID)
        //{
        //    string strSql = "select SystemInfoCode from T_SystemInfo where SystemInfoID=" + CompanyTypeID.ToString();
        //    string CompanyType = Common.ConvertEx.ToString(DbHelperSQL.GetSingle(strSql)).ToLower(); //当前单位类型

        //    if (CompanyType != "" && (CompanyType.Equals("jlcompanyinfo") || CompanyType.Equals("sgcompany")))
        //        return true;
        //    else
        //        return false;
        //}
        #endregion  成员方法

        public int IntoDB(int SingleProjectID, string DHType) {
            int iOut = 0;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("execute SP_DARK @SingleProjectID,@DHType,@retval ");
            SqlParameter[] parameters = { 
                   new SqlParameter("@SingleProjectID",SqlDbType.Int,4),
                   new SqlParameter("@DHType",SqlDbType.VarChar,30),
                   new SqlParameter("@retval",SqlDbType.Int,0)};
            parameters[0].Value = SingleProjectID;
            parameters[1].Value = DHType;
            parameters[2].Value = iOut;

            iOut = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

            return iOut;
        }

        public DataSet GetCompany(string SingleProjectID, int CompanyID) {
            string strSqlWhere = " SingleProjectID=" + SingleProjectID;
            if (CompanyID > 0) {
                strSqlWhere += " AND B.CompanyID=" + CompanyID;
            }

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT DISTINCT B.COMPANYID,B.COMPANYNAME FROM T_SingleProjectCompany A,dbo.T_Company B WHERE A.CompanyID=B.CompanyID AND " + strSqlWhere);

            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetCompany(string SingleProjectID, string CompanyType) {
            string strSqlWhere = " SingleProjectID=" + SingleProjectID;
            if (!string.IsNullOrWhiteSpace(CompanyType)) {
                strSqlWhere += " AND B.CompanyType in(" + CompanyType + ")";
            }

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT DISTINCT B.COMPANYID,B.COMPANYNAME FROM T_SingleProjectCompany A,dbo.T_Company B WHERE A.CompanyID=B.CompanyID AND " + strSqlWhere);

            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetCompany(int CompanyID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT DISTINCT B.COMPANYID,B.COMPANYNAME FROM T_SingleProjectCompany A,dbo.T_Company B WHERE A.CompanyID=B.CompanyID AND B.CompanyID=" + CompanyID);

            return DbHelperSQL.Query(strSql.ToString());
        }

        public string GetCompanyNameBySingleProjectID(string SingleProjectID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CompanyName from T_SingleProjectCompany,T_Company where T_SingleProjectCompany.CompanyID=T_Company.CompanyID and T_Company.CompanyType=13 AND SingleProjectID=" + SingleProjectID);

            return DbHelperSQL.GetSingle(strSql.ToString()).ToString();
        }

        /// <summary>
        /// 生成文件编号
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string GetBH(string BH, string SingleProjectId, string RecID) {
            string code = string.Empty;
            string strSql = "select MAX(bh) from t_filelist where singleprojectid=" + SingleProjectId + " and PID=" + RecID + " ";
            string Maxbh = Common.ConvertEx.ToString(DbHelperSQL.GetSingle(strSql));  //最大编号
            if (Maxbh == "") {
                code = BH.Substring(0, 1) + (1).ToString("D3");
            } else {
                string MaxIndex = (Common.ConvertEx.ToInt(Maxbh.Substring(1)) + 1).ToString("D" + (Maxbh.Length - 1).ToString() + "");
                code = BH.Substring(0, 1) + MaxIndex;
            }
            return code;
        }

        public string GetSingle(string strsql) {
            return Common.ConvertEx.ToString(DbHelperSQL.GetSingle(strsql));
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="RoleID"></param>
        /// <param name="RoleRightType"></param>
        public void DelRoleRight(string RoleID, string RoleRightType) {
            string strSql = "delete from T_RoleRight where ROLEID=" + RoleID + " and RoleRightType=" + RoleRightType + " ";
            DbHelperSQL.ExecuteSql(strSql);
        }

        /// <summary>
        /// 保存权限
        /// </summary>
        /// <param name="ltModelID"></param>
        /// <param name="ltRightID"></param>
        /// <param name="ltEnable"></param>
        /// <param name="RoleID"></param>
        /// <returns></returns>
        public void SetRoleRight(string RightChar, string RoleID, string ModelID, int Enabled, int RoleRightType, string PModelID, string ModelBH) {
            List<String> SQLStringList = new List<string>();

            StringBuilder strSql = new StringBuilder();
            if (RoleRightType == 1) //表示菜单权限
            {
                if (!DbHelperSQL.Exists("select count(1) from T_RoleRight where MODELID=" + PModelID + " and ROLEID=" + RoleID + " and RoleRightType=" + RoleRightType + "")) {
                    strSql.Append("INSERT INTO T_RoleRight(");
                    strSql.Append("ROLEID,MODELID,ENABLED,ROLERIGHTTYPE)");
                    strSql.Append("values (");
                    strSql.Append("" + RoleID + "," + PModelID + "," + Enabled + "," + RoleRightType + ")");
                    DbHelperSQL.ExecuteSql(strSql.ToString());
                }
            }

            if (RoleRightType == 3) {
                strSql = new StringBuilder();
                strSql.Append("INSERT INTO T_RoleRight(");
                strSql.Append("ROLEID,MODELID,RIGHTLISTID,ENABLED,ROLERIGHTTYPE,MODELBH)");
                strSql.Append(" values (");
                strSql.Append("" + RoleID + "," + ModelID + ",'" + RightChar + "'," + Enabled + "," + RoleRightType + ",'" + ModelBH + "')");
                SQLStringList.Add(strSql.ToString());
            } else {
                strSql = new StringBuilder();
                strSql.Append("INSERT INTO T_RoleRight(");
                strSql.Append("ROLEID,MODELID,RIGHTLISTID,ENABLED,ROLERIGHTTYPE)");
                strSql.Append(" values (");
                strSql.Append("" + RoleID + "," + ModelID + ",'" + RightChar + "'," + Enabled + "," + RoleRightType + ")");
                SQLStringList.Add(strSql.ToString());
            }
            DbHelperSQL.ExecuteSqlTran(SQLStringList);
        }

        /// <summary>
        ///删除工程和其相关信息
        /// </summary>
        /// <param name="CompanyID"></param>
        /// <returns></returns>
        public bool DeleteCompanyOther(string SingleProjectID, bool delUserFlag = false) {
            try {
                if (SingleProjectID.Trim().Length > 0) {
                    List<string> listSql = new List<string>();
                    if (delUserFlag) {
                        listSql.Add("delete from T_UsersInfo  WHERE CompanyID=(SELECT top 1 f2.CompanyID from T_SingleProject f0,T_Construction_Project f2  "
                          + "where f0.ConstructionProjectID=f2.ConstructionProjectID AND f0.SingleProjectID=" + SingleProjectID + ")");

                        listSql.Add("delete from T_Company WHERE CompanyID=(SELECT top 1 f2.CompanyID from T_SingleProject f0,T_Construction_Project f2  "
                        + "where f0.ConstructionProjectID=f2.ConstructionProjectID AND f0.SingleProjectID=" + SingleProjectID + ")");
                    }
                    listSql.Add("delete f from T_EFile f where EXISTS(SELECT 1 from T_FileList u where u.SingleProjectID=" + SingleProjectID + " AND f.FileListID=u.FileListID)"); //删除电子文件
                    listSql.Add("delete from T_FileList where SingleProjectID=" + SingleProjectID);                    //删文件    
                    listSql.Add("delete from T_SingleProjectCompany where SingleProjectID=" + SingleProjectID);        //删除工程公司表       
                    listSql.Add("delete from T_SingleProjectUser where SingleProjectID=" + SingleProjectID);           //删除用户关联表                                                         
                    listSql.Add("delete from T_SingleProject where SingleProjectID=" + SingleProjectID);               //删工程     
                    listSql.Add("delete from T_WorkFlowDefine where SingleProjectID=" + SingleProjectID);              //删工程流程
                    listSql.Add("delete from T_FileAttach where PriKeyValue=" + SingleProjectID);                      //删工程附件
                    DbHelperSQL.ExecuteSqlTran(listSql);
                }
                return true;
            } catch {
                return false;
            }
        }

        /// <summary>
        /// 执行全SQL脚本
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public DataTable GetQueryList(string strSql) {
            if (!string.IsNullOrWhiteSpace(strSql))
                return DbHelperSQL.Query(strSql).Tables[0];
            else
                return null;
        }
    }
}