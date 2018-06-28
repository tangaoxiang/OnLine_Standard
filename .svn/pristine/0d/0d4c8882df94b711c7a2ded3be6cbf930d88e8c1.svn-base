using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用
using DigiPower.Onlinecol.Standard.Model;

namespace DigiPower.Onlinecol.Standard.DAL {
    public class UserOperate {
        public UserOperate() { }

        public DataSet GetData(string SqlWhere) {
            return DbHelperSQL.Query(SqlWhere);
        }

        /// <summary>
        /// 从模版表中拷贝生成归档目录,每个单位类型只拷贝一次归档目录  建设单位
        /// </summary>
        /// <param name="CompanyID">单位ID</param>
        /// <param name="userid">建设单位用户ID</param>
        /// <param name="username"></param>
        /// <param name="SingleProjectID">工程ID</param>
        /// <param name="ProjectType">工程类型</param>
        /// <param name="iSignaturePdf">文件是否需要签章</param>
        /// <param name="iSignatureWorkFlow">是否按签章流程签章</param>
        /// <returns></returns>
        public bool CopyFileList(int CompanyID, int userid, string username, int SingleProjectID, string ProjectType,
            string iSignaturePdf = "0", string iSignatureWorkFlow = "0") {
            StringBuilder strSql = new StringBuilder();
            //如果已分配将不可以再分配，否则会产生很多相同的归档目录         //不同的工程类别有不同的归档目录
            if (!DbHelperSQL.Exists("SELECT COUNT(0) FROM T_FileList WHERE SingleProjectID=" + SingleProjectID)) {
                strSql.Append(" insert into T_FileList(recID,bh,title,mustsubmitflag,pid,DefaultCompanyType,status,starttime,endtime,CompanyID,");
                strSql.Append(" operateuserid,operateusername,OrderIndex,pagescount,winrecvpagescount,SingleProjectID,IsFolder,AlonePack,IsSystem,");
                strSql.Append(" FileType,OldRecID,FileFrom,iSignaturePdf,iSignatureWorkFlow)");

                strSql.Append(" select recID,bh,title,mustsubmitflag,pid,DefaultCompanyType,0 status,null starttime,null endtime," + CompanyID + "," + userid + " ");
                strSql.Append(" operateuserid,'" + username + "' operateusername,OrderIndex,0 pagescount,0 winrecvpagescount," + SingleProjectID + " ");
                strSql.Append(" SingleProjectID,IsFolder,AlonePack,1,FileType,recID,FileFrom," + iSignaturePdf + "," + iSignatureWorkFlow + "");
                strSql.Append(" from T_FileListTmp where DefaultCompanyType=13 AND PID >=0 AND isvisible<>0 and archive_form_no=" + ProjectType);
                //只自动生成建设单=13的

                try {
                    int FileListID = DbHelperSQL.ExecuteSql(strSql.ToString());
                    if (FileListID > 0) {
                        //带入模板
                        return true;
                    } else
                        return false;
                } catch { return false; }
            }
            return true;
        }

        /// <summary>
        /// 从模版表中拷贝生成归档目录,每个单位类型只拷贝一次归档目录  监理/施工
        /// </summary>
        /// <param name="CompanyID">单位ID</param>
        /// <param name="userid">单位用户ID</param>
        /// <param name="username"></param>
        /// <param name="SingleProjectID">工程ID</param>
        /// <param name="ProjectType">工程类型</param>
        /// <param name="CompanyType">公司类型</param>
        /// <param name="iSignaturePdf">文件是否需要签章</param>
        /// <param name="iSignatureWorkFlow">是否按签章流程签章</param>
        /// <returns></returns>
        public bool CopyFileList(int CompanyID, int userid, string username, int SingleProjectID, string ProjectType,
            string CompanyType, string iSignaturePdf = "0", string iSignatureWorkFlow = "0") {
            //不同的工程类别有不同的归档目录
            StringBuilder strSql = new StringBuilder();
            //如果已分配将不可以再分配(根据不同的公司类型)，否则会产生很多相同的归档目录
            if (!DbHelperSQL.Exists("SELECT COUNT(0) FROM T_FileList WHERE DefaultCompanyType=" + CompanyType + " And SingleProjectID=" + SingleProjectID)) {
                strSql.Append(" insert into T_FileList(recID,bh,title,mustsubmitflag,pid,DefaultCompanyType,status,starttime,endtime,CompanyID,operateuserid,operateusername,");
                strSql.Append(" OrderIndex,pagescount,winrecvpagescount,SingleProjectID,IsFolder,AlonePack,IsSystem,FileType,OldRecID,FileFrom,iSignaturePdf,iSignatureWorkFlow)");
                strSql.Append(" select recID,bh,title,mustsubmitflag,pid,DefaultCompanyType,0 status,null starttime,null endtime," + CompanyID + "," + userid + " ");
                strSql.Append(" operateuserid,'" + username + "' operateusername,OrderIndex,0 pagescount,0 winrecvpagescount," + SingleProjectID + " ");
                strSql.Append(" SingleProjectID,IsFolder,AlonePack,1,FileType,recID,FileFrom," + iSignaturePdf + "," + iSignatureWorkFlow + " ");
                strSql.Append(" from T_FileListTmp where DefaultCompanyType=" + CompanyType + " AND PID >=0 AND isvisible<>0 and archive_form_no=" + ProjectType + " ");     // (AlonePack=1 or IsFolder=1) 监理或施工的都在创建用户的时候带出来
                try {
                    int FileListID = DbHelperSQL.ExecuteSql(strSql.ToString());
                    if (FileListID > 0) {
                        //带入模板
                        return true;
                    } else
                        return false;
                } catch { return false; }
            }
            return true;
        }



        /// <summary>
        /// 取归档目录归档情况
        /// </summary>
        /// <param name="SingleProjectID">工程id</param>
        /// <returns></returns>
        public DataSet GetArchiveCount(int SingleProjectID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as countlist,");
            strSql.Append("(select count(*) from T_FileList where SingleProjectID=" + SingleProjectID + " and winrecvpagescount>0) as winrecvlist,");
            strSql.Append("sum(pagescount) as pagescount,sum(winrecvpagescount) as winrecvpagescount ");
            strSql.Append("from T_FileList where SingleProjectID=" + SingleProjectID);

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 批量更新用户ID及用户
        /// </summary>
        public void UpdateUser(List<string> FileListID, string userid, string username) {
            List<string> strSql = new List<string>();
            if (FileListID.Count > 0) {
                foreach (string id in FileListID) {
                    strSql.Add("Update T_FileList set OperateUserID='" + userid + "' ,OperateUserName='" + username + "' where FileListID=" + id);
                }
                DbHelperSQL.ExecuteSqlTran(strSql);
            }
        }

        /// <summary>
        /// 获取归档目录操作用户（单项工程）
        ///</summary> 
        public DataSet GetArchiveUser(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct OperateUserID,OperateUserName");
            strSql.Append(" FROM T_FileList ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public void ChangePasswd(string UserID, string NewPasswd) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_UsersInfo set Passwd = '" + NewPasswd + "' WHERE UserID=" + UserID);
            DbHelperSQL.Query(strSql.ToString());
        }


    }
}
