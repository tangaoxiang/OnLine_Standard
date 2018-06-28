using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
namespace DigiPower.Onlinecol.Standard.BLL {

    /// <summary>
    /// ҵ���߼���T_EFile_BLL ��ժҪ˵����
    /// </summary>
    public class T_EFile_BLL {
        private readonly DigiPower.Onlinecol.Standard.DAL.T_EFile_DAL dal = new DigiPower.Onlinecol.Standard.DAL.T_EFile_DAL();
        public T_EFile_BLL() { }
        #region  ��Ա����

        /// <summary>
        /// �õ����ID
        /// </summary>
        public int GetMaxId() {
            return dal.GetMaxId();
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int ArchiveListCellRptID) {
            return dal.Exists(ArchiveListCellRptID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_EFile_MDL model) {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(DigiPower.Onlinecol.Standard.Model.T_EFile_MDL model) {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int ArchiveListCellRptID) {

            dal.Delete(ArchiveListCellRptID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_EFile_MDL GetModel(int ArchiveListCellRptID) {

            return dal.GetModel(ArchiveListCellRptID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_EFile_MDL GetModelByCache(int ArchiveListCellRptID) {

            string CacheKey = "T_EFile_MDLModel-" + ArchiveListCellRptID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null) {
                try {
                    objModel = dal.GetModel(ArchiveListCellRptID);
                    if (objModel != null) {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                } catch { }
            }
            return (DigiPower.Onlinecol.Standard.Model.T_EFile_MDL)objModel;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere) {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder) {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<DigiPower.Onlinecol.Standard.Model.T_EFile_MDL> GetModelList(string strWhere) {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<DigiPower.Onlinecol.Standard.Model.T_EFile_MDL> DataTableToList(DataTable dt) {
            List<DigiPower.Onlinecol.Standard.Model.T_EFile_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.T_EFile_MDL>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0) {
                DigiPower.Onlinecol.Standard.Model.T_EFile_MDL model;
                for (int n = 0; n < rowsCount; n++) {
                    model = new DigiPower.Onlinecol.Standard.Model.T_EFile_MDL();
                    if (dt.Rows[n]["ArchiveListCellRptID"].ToString() != "") {
                        model.ArchiveListCellRptID = int.Parse(dt.Rows[n]["ArchiveListCellRptID"].ToString());
                    }
                    if (dt.Rows[n]["FileListID"].ToString() != "") {
                        model.FileListID = int.Parse(dt.Rows[n]["FileListID"].ToString());
                    }
                    model.DH = dt.Rows[n]["DH"].ToString();
                    if (dt.Rows[n]["FileType"].ToString() != "") {
                        model.FileType = int.Parse(dt.Rows[n]["FileType"].ToString());
                    }
                    if (dt.Rows[n]["Status"].ToString() != "") {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    model.Title = dt.Rows[n]["Title"].ToString();
                    model.FilePath = dt.Rows[n]["FilePath"].ToString();
                    model.PDFFilePath = dt.Rows[n]["PDFFilePath"].ToString();
                    if (dt.Rows[n]["PageCounts"].ToString() != "") {
                        model.PageCounts = int.Parse(dt.Rows[n]["PageCounts"].ToString());
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
        /// ��������б�
        /// </summary>
        public DataSet GetAllList() {
            return GetList("");
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  ��Ա����

        /// <summary>
        /// ��������б� ��ҳ
        /// </summary>
        /// <returns></returns>
        public DataTable GetListPaging(string strWhere, int PageSize, int curPage, out int recCoun) {
            return dal.GetList(strWhere, PageSize, curPage, "ArchiveListCellRptID", "OrderIndex asc", out recCoun);
        }

        /// <summary>
        /// �õ����ID
        /// </summary>
        public object GetEfileMaxOrderIndex(string filelistID) {
            return dal.GetEfileMaxOrderIndex(filelistID);
        }
    }
}
