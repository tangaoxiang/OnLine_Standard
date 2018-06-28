using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
namespace DigiPower.Onlinecol.Standard.BLL {

    /// <summary>
    /// T_EFile_OutSideRelated
    /// </summary>
    public partial class T_EFile_OutSideRelated_BLL {
        private readonly DigiPower.Onlinecol.Standard.DAL.T_EFile_OutSideRelated_DAL dal = new DigiPower.Onlinecol.Standard.DAL.T_EFile_OutSideRelated_DAL();
        public T_EFile_OutSideRelated_BLL() { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId() {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SID) {
            return dal.Exists(SID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DigiPower.Onlinecol.Standard.Model.T_EFile_OutSideRelated_MDL model) {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DigiPower.Onlinecol.Standard.Model.T_EFile_OutSideRelated_MDL model) {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int SID) {

            return dal.Delete(SID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string SIDlist) {
            return dal.DeleteList(SIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_EFile_OutSideRelated_MDL GetModel(int SID) {

            return dal.GetModel(SID);
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
        public List<DigiPower.Onlinecol.Standard.Model.T_EFile_OutSideRelated_MDL> GetModelList(string strWhere) {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DigiPower.Onlinecol.Standard.Model.T_EFile_OutSideRelated_MDL> DataTableToList(DataTable dt) {
            List<DigiPower.Onlinecol.Standard.Model.T_EFile_OutSideRelated_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.T_EFile_OutSideRelated_MDL>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0) {
                DigiPower.Onlinecol.Standard.Model.T_EFile_OutSideRelated_MDL model;
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

        #endregion  BasicMethod

        /// <summary>
        /// 获得主文件对应的附件相关文件信息
        /// </summary>
        /// <param name="fileListID"></param>
        /// <returns></returns>
        public DataSet GetEFileOutSideRelated(string fileListID) {
            return dal.GetEFileOutSideRelated(fileListID);
        }

        /// <summary>
        /// 删除文件对应的附件信息
        /// </summary>
        public bool DelEfileOutSideRelated(string fileListID, string fromType) {
            return dal.DelEfileOutSideRelated(fileListID, fromType);
        }
    }
}

