using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
using System.Collections;
namespace DigiPower.Onlinecol.Standard.BLL
{
    /// <summary>
    /// ҵ���߼���T_WorkFlowDoResult_BLL ��ժҪ˵����
    /// </summary>
    public class T_WorkFlowDoResult_BLL
    {
        private readonly DigiPower.Onlinecol.Standard.DAL.T_WorkFlowDoResult_DAL dal = new DigiPower.Onlinecol.Standard.DAL.T_WorkFlowDoResult_DAL();
        public T_WorkFlowDoResult_BLL()
        { }
        #region  ��Ա����

        /// <summary>
        /// �õ����ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int WorkFlowDoResultID)
        {
            return dal.Exists(WorkFlowDoResultID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Add(DigiPower.Onlinecol.Standard.Model.T_WorkFlowDoResult_MDL model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(DigiPower.Onlinecol.Standard.Model.T_WorkFlowDoResult_MDL model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int WorkFlowDoResultID)
        {

            dal.Delete(WorkFlowDoResultID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_WorkFlowDoResult_MDL GetModel(int WorkFlowDoResultID)
        {

            return dal.GetModel(WorkFlowDoResultID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_WorkFlowDoResult_MDL GetModelByCache(int WorkFlowDoResultID)
        {

            string CacheKey = "T_WorkFlowDoResult_MDLModel-" + WorkFlowDoResultID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(WorkFlowDoResultID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (DigiPower.Onlinecol.Standard.Model.T_WorkFlowDoResult_MDL)objModel;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere, string orderByName = null)
        {
            return dal.GetList(strWhere, orderByName);
        }
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<DigiPower.Onlinecol.Standard.Model.T_WorkFlowDoResult_MDL> GetModelList(string strWhere, string orderByName = null)
        {
            DataSet ds = dal.GetList(strWhere, orderByName);
            return DataTableToList(ds.Tables[0]);
        }


        /// <summary>
        /// ��������б�
        /// </summary>
        public List<DigiPower.Onlinecol.Standard.Model.T_WorkFlowDoResult_MDL> DataTableToList(DataTable dt)
        {
            List<DigiPower.Onlinecol.Standard.Model.T_WorkFlowDoResult_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.T_WorkFlowDoResult_MDL>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DigiPower.Onlinecol.Standard.Model.T_WorkFlowDoResult_MDL model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new DigiPower.Onlinecol.Standard.Model.T_WorkFlowDoResult_MDL();
                    if (dt.Rows[n]["WorkFlowDoResultID"].ToString() != "")
                    {
                        model.WorkFlowDoResultID = int.Parse(dt.Rows[n]["WorkFlowDoResultID"].ToString());
                    }
                    if (dt.Rows[n]["WorkFlowDefineID"].ToString() != "")
                    {
                        model.WorkFlowDefineID = int.Parse(dt.Rows[n]["WorkFlowDefineID"].ToString());
                    }
                    if (dt.Rows[n]["DoUserID"].ToString() != "")
                    {
                        model.DoUserID = int.Parse(dt.Rows[n]["DoUserID"].ToString());
                    }
                    if (dt.Rows[n]["DoDateTime"].ToString() != "")
                    {
                        model.DoDateTime = DateTime.Parse(dt.Rows[n]["DoDateTime"].ToString());
                    }
                    model.DoResult = dt.Rows[n]["DoResult"].ToString();
                    model.DoRemark = dt.Rows[n]["DoRemark"].ToString();
                    model.DoCellPath = dt.Rows[n]["DoCellPath"].ToString();


                    if (dt.Rows[n]["WorkFlowID"].ToString() != "")
                    {
                        model.WorkFlowID = int.Parse(dt.Rows[n]["WorkFlowID"].ToString());
                    }
                    if (dt.Rows[n]["ArchiveID"].ToString() != "")
                    {
                        model.ArchiveID = int.Parse(dt.Rows[n]["ArchiveID"].ToString());
                    }
                    if (dt.Rows[n]["SingleProjectID"].ToString() != "")
                    {
                        model.SingleProjectID = int.Parse(dt.Rows[n]["SingleProjectID"].ToString());
                    }
                    if (dt.Rows[n]["FileListID"].ToString() != "")
                    {
                        model.FileListID = int.Parse(dt.Rows[n]["FileListID"].ToString());
                    }

                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetAllList()
        {
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
        /// ��ȡ������������Ϣ
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public List<DigiPower.Onlinecol.Standard.Model.T_WorkFlowDoResult_MDL> GetArchiveLastChecResultList(Hashtable ht)
        {
            DataSet ds = dal.GetArchiveLastChecResultList(ht);
            return DataTableToList(ds.Tables[0]);
        }
    }
}
