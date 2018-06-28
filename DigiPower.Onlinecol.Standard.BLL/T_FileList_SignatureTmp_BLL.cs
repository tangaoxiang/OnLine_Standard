using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
namespace DigiPower.Onlinecol.Standard.BLL {
    /// <summary>
    /// T_FileList_SignatureTmp
    /// </summary>
    public partial class T_FileList_SignatureTmp_BLL {
        private readonly DigiPower.Onlinecol.Standard.DAL.T_FileList_SignatureTmp_DAL dal = new DigiPower.Onlinecol.Standard.DAL.T_FileList_SignatureTmp_DAL();
        public T_FileList_SignatureTmp_BLL() { }

        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DigiPower.Onlinecol.Standard.Model.T_FileList_SignatureTmp_MDL model) {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DigiPower.Onlinecol.Standard.Model.T_FileList_SignatureTmp_MDL model) {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int SID) {
            dal.Delete(SID);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteForFileListID(int FileListID) {
            dal.DeleteForFileListID(FileListID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_FileList_SignatureTmp_MDL GetModel(int SID) {
            //该表无主键信息，请自定义主键/条件字段
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
        public List<DigiPower.Onlinecol.Standard.Model.T_FileList_SignatureTmp_MDL> GetModelList(string strWhere) {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DigiPower.Onlinecol.Standard.Model.T_FileList_SignatureTmp_MDL> DataTableToList(DataTable dt) {
            List<DigiPower.Onlinecol.Standard.Model.T_FileList_SignatureTmp_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.T_FileList_SignatureTmp_MDL>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0) {
                DigiPower.Onlinecol.Standard.Model.T_FileList_SignatureTmp_MDL model;
                for (int n = 0; n < rowsCount; n++) {
                    model = new DigiPower.Onlinecol.Standard.Model.T_FileList_SignatureTmp_MDL();
                    if (dt.Rows[n]["SID"].ToString() != "") {
                        model.SID = int.Parse(dt.Rows[n]["SID"].ToString());
                    }
                    model.SignatureType = dt.Rows[n]["SignatureType"].ToString();
                    if (dt.Rows[n]["FileListID"].ToString() != "") {
                        model.FileListID = int.Parse(dt.Rows[n]["FileListID"].ToString());
                    }
                    if (dt.Rows[n]["SignatureCount"].ToString() != "") {
                        model.SignatureCount = int.Parse(dt.Rows[n]["SignatureCount"].ToString());
                    }
                    if (dt.Rows[n]["OrderIndex"].ToString() != "") {
                        model.OrderIndex = int.Parse(dt.Rows[n]["OrderIndex"].ToString());
                    }
                    modelList.Add(model);
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

        #endregion  BasicMethod

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere) {
            return dal.GetRecordCount(strWhere);
        }
        
        /// <summary>
        /// 获取工程下所有文件对应的签章角色,方便创建签章用户
        /// </summary>
        /// <param name="singleProjectID"></param>
        /// <returns></returns>
        public DataTable GetSingleProjectAllSignatureRole(string SingleProjectID) {
            return dal.GetSingleProjectAllSignatureRole(SingleProjectID);
        }
    }
}

