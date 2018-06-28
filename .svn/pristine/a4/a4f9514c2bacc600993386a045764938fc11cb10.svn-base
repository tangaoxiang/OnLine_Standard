using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.DAL;

namespace DigiPower.Onlinecol.Standard.BLL {
    public class UserOperate {
        public UserOperate() { }

        public DataSet GetDepartmentList(string SqlWhere) {
            DigiPower.Onlinecol.Standard.DAL.UserOperate dal = new DigiPower.Onlinecol.Standard.DAL.UserOperate();

            return dal.GetData(SqlWhere);
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
            DigiPower.Onlinecol.Standard.DAL.UserOperate dal = new DigiPower.Onlinecol.Standard.DAL.UserOperate();
            return dal.CopyFileList(CompanyID, userid, username, SingleProjectID, ProjectType, iSignaturePdf, iSignatureWorkFlow);
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
        public bool CopyFileList(int CompanyID, int userid, string username, int SingleProjectID, string ProjectType, string CompanyType,
            string iSignaturePdf = "0", string iSignatureWorkFlow = "0") {
            DigiPower.Onlinecol.Standard.DAL.UserOperate dal = new DigiPower.Onlinecol.Standard.DAL.UserOperate();
            return dal.CopyFileList(CompanyID, userid, username, SingleProjectID, ProjectType, CompanyType, iSignaturePdf, iSignatureWorkFlow);
        }

        /// <summary>
        /// 取归档目录归档情况
        /// </summary>
        /// <param name="SingleProjectID"></param>
        /// <returns></returns>
        public DataSet GetArchiveCount(int SingleProjectID) {
            DigiPower.Onlinecol.Standard.DAL.UserOperate dal = new DigiPower.Onlinecol.Standard.DAL.UserOperate();

            return dal.GetArchiveCount(SingleProjectID);
        }

        /// <summary>
        /// 更新归档目录状态
        /// </summary>
        /// <param name="FileListID"></param>
        /// <param name="status"></param>
        //public void UpdateArchiveListStatus(int FileListID, int status)
        //{
        //    DigiPower.Onlinecol.Standard.DAL.UserOperate dal = new DigiPower.Onlinecol.Standard.DAL.UserOperate();

        //    dal.UpdateArchiveListStatus(FileListID, status);
        //}

        ///<summary>
        ///
        ///</summary>
        public DataSet GetArchiveUser(string strWhere) {
            DigiPower.Onlinecol.Standard.DAL.UserOperate dal = new DigiPower.Onlinecol.Standard.DAL.UserOperate();

            return dal.GetArchiveUser(strWhere);
        }

        public void UpdateUser(List<string> FileListID, string userid, string username) {
            DigiPower.Onlinecol.Standard.DAL.UserOperate dal = new DigiPower.Onlinecol.Standard.DAL.UserOperate();
            dal.UpdateUser(FileListID, userid, username);
        }
        public void ChangePasswd(string UserID, string NewPasswd) {
            DigiPower.Onlinecol.Standard.DAL.UserOperate dal = new DigiPower.Onlinecol.Standard.DAL.UserOperate();
            dal.ChangePasswd(UserID, NewPasswd);
        }
    }
}