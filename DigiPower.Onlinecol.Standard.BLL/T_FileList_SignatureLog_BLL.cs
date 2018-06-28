using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
using System.Collections;
namespace DigiPower.Onlinecol.Standard.BLL {
    /// <summary>
    /// T_FileList_SignatureLog
    /// </summary>
    public partial class T_FileList_SignatureLog_BLL {
        private readonly DigiPower.Onlinecol.Standard.DAL.T_FileList_SignatureLog_DAL dal = new DigiPower.Onlinecol.Standard.DAL.T_FileList_SignatureLog_DAL();
        public T_FileList_SignatureLog_BLL() { }
        #region  BasicMethod


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SignatureLogID) {
            return dal.Exists(SignatureLogID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DigiPower.Onlinecol.Standard.Model.T_FileList_SignatureLog_MDL model) {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DigiPower.Onlinecol.Standard.Model.T_FileList_SignatureLog_MDL model) {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int SignatureLogID) {

            return dal.Delete(SignatureLogID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string SignatureLogIDlist) {
            return dal.DeleteList(SignatureLogIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_FileList_SignatureLog_MDL GetModel(int SignatureLogID) {

            return dal.GetModel(SignatureLogID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere) {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder) {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DigiPower.Onlinecol.Standard.Model.T_FileList_SignatureLog_MDL> GetModelList(string strWhere) {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DigiPower.Onlinecol.Standard.Model.T_FileList_SignatureLog_MDL> DataTableToList(DataTable dt) {
            List<DigiPower.Onlinecol.Standard.Model.T_FileList_SignatureLog_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.T_FileList_SignatureLog_MDL>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0) {
                DigiPower.Onlinecol.Standard.Model.T_FileList_SignatureLog_MDL model;
                for (int n = 0; n < rowsCount; n++) {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null) {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList() {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere) {
            return dal.GetRecordCount(strWhere);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex) {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

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
            return dal.GetUpSignatureCount(SignatureType, FileListTmpID, FileListID, SignatureFinishFlag);
        }

        /// <summary>
        /// 获取当前用户的签章次数
        /// </summary>
        /// <param name="Hashtable"></param>       
        /// <returns></returns>
        public int GetSignatureCount(Hashtable ht) {
            return dal.GetSignatureCount(ht);
        }

        /// <summary>
        /// 获得数据列表 分页
        /// </summary>
        /// <returns></returns>
        public DataTable GetListPaging(string strWhere, int PageSize, int curPage, out int recCoun) {
            return dal.GetListPaging(strWhere, PageSize, curPage, "SignatureLogID", "SignatureLogID asc", out recCoun);
        }

        /// <summary>
        /// 更新完成状态
        /// </summary>
        public bool UpdateSignatureFinishFlag(bool FinishFlag, string Signature_UserID, string Signature_UserRoleCode, string FileListID) {
            return dal.UpdateSignatureFinishFlag(FinishFlag, Signature_UserID, Signature_UserRoleCode, FileListID);
        }
        #endregion  ExtensionMethod
    }
}

