using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
namespace DigiPower.Onlinecol.Standard.BLL
{
    /// <summary>
    /// ҵ���߼���T_FileAttach_BLL ��ժҪ˵����
    /// </summary>
    public class T_FileAttach_BLL
    {
        private readonly DigiPower.Onlinecol.Standard.DAL.T_FileAttach_DAL dal = new DigiPower.Onlinecol.Standard.DAL.T_FileAttach_DAL();
        public T_FileAttach_BLL() { }
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
        public bool Exists(int AttachID) {
            return dal.Exists(AttachID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_FileAttach_MDL model) {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(DigiPower.Onlinecol.Standard.Model.T_FileAttach_MDL model) {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int AttachID) {

            dal.Delete(AttachID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_FileAttach_MDL GetModel(int AttachID) {

            return dal.GetModel(AttachID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_FileAttach_MDL GetModelByCache(int AttachID) {

            string CacheKey = "T_FileAttach_MDLModel-" + AttachID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null) {
                try {
                    objModel = dal.GetModel(AttachID);
                    if (objModel != null) {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (DigiPower.Onlinecol.Standard.Model.T_FileAttach_MDL)objModel;
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
        public List<DigiPower.Onlinecol.Standard.Model.T_FileAttach_MDL> GetModelList(string strWhere) {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<DigiPower.Onlinecol.Standard.Model.T_FileAttach_MDL> DataTableToList(DataTable dt) {
            List<DigiPower.Onlinecol.Standard.Model.T_FileAttach_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.T_FileAttach_MDL>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0) {
                DigiPower.Onlinecol.Standard.Model.T_FileAttach_MDL model;
                for (int n = 0; n < rowsCount; n++) {
                    model = new DigiPower.Onlinecol.Standard.Model.T_FileAttach_MDL();
                    if (dt.Rows[n]["AttachID"].ToString() != "") {
                        model.AttachID = int.Parse(dt.Rows[n]["AttachID"].ToString());
                    }
                    model.Flag = dt.Rows[n]["Flag"].ToString();
                    if (dt.Rows[n]["PriKeyValue"].ToString() != "") {
                        model.PriKeyValue = int.Parse(dt.Rows[n]["PriKeyValue"].ToString());
                    }
                    model.AttachCode = dt.Rows[n]["AttachCode"].ToString();
                    model.AttachName = dt.Rows[n]["AttachName"].ToString();
                    model.AttachPath = dt.Rows[n]["AttachPath"].ToString();
                    if (dt.Rows[n]["OrderIndex"].ToString() != "") {
                        model.OrderIndex = int.Parse(dt.Rows[n]["OrderIndex"].ToString());
                    }
                    if (dt.Rows[n]["CreateDate"].ToString() != "") {
                        model.CreateDate = DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
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
        /// ɾ��������Ϣ
        /// </summary>
        /// <param name="singleProjectId"></param>
        /// <param name="attachCode"></param>
        /// <param name="flag"></param>
        public void DelFileAttach(string singleProjectId, string attachCode, string flag) {
            dal.DelFileAttach(singleProjectId, attachCode, flag);
        }
    }
}
