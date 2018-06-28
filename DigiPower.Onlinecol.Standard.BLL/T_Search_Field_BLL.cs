using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
namespace DigiPower.Onlinecol.Standard.BLL
{
    /// <summary>
    /// ҵ���߼���T_Search_Field_BLL ��ժҪ˵����
    /// </summary>
    public class T_Search_Field_BLL
    {
        private readonly DigiPower.Onlinecol.Standard.DAL.T_Search_Field_DAL dal = new DigiPower.Onlinecol.Standard.DAL.T_Search_Field_DAL();
        public T_Search_Field_BLL()
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
        public bool Exists(int Search_Field_ID)
        {
            return dal.Exists(Search_Field_ID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_Search_Field_MDL model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(DigiPower.Onlinecol.Standard.Model.T_Search_Field_MDL model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int Search_Field_ID)
        {

            dal.Delete(Search_Field_ID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_Search_Field_MDL GetModel(int Search_Field_ID)
        {

            return dal.GetModel(Search_Field_ID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_Search_Field_MDL GetModelByCache(int Search_Field_ID)
        {

            string CacheKey = "T_Search_Field_MDLModel-" + Search_Field_ID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(Search_Field_ID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (DigiPower.Onlinecol.Standard.Model.T_Search_Field_MDL)objModel;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
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
        public List<DigiPower.Onlinecol.Standard.Model.T_Search_Field_MDL> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<DigiPower.Onlinecol.Standard.Model.T_Search_Field_MDL> DataTableToList(DataTable dt)
        {
            List<DigiPower.Onlinecol.Standard.Model.T_Search_Field_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.T_Search_Field_MDL>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DigiPower.Onlinecol.Standard.Model.T_Search_Field_MDL model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new DigiPower.Onlinecol.Standard.Model.T_Search_Field_MDL();
                    if (dt.Rows[n]["Search_Field_ID"].ToString() != "")
                    {
                        model.Search_Field_ID = int.Parse(dt.Rows[n]["Search_Field_ID"].ToString());
                    }
                    model.ReportCode = dt.Rows[n]["ReportCode"].ToString();
                    model.TableName = dt.Rows[n]["TableName"].ToString();
                    model.TableNameCN = dt.Rows[n]["TableNameCN"].ToString();
                    model.LabelName = dt.Rows[n]["LabelName"].ToString();
                    model.FieldName = dt.Rows[n]["FieldName"].ToString();
                    if (dt.Rows[n]["Line"].ToString() != "")
                    {
                        model.Line = int.Parse(dt.Rows[n]["Line"].ToString());
                    }
                    if (dt.Rows[n]["OrderId"].ToString() != "")
                    {
                        model.OrderId = int.Parse(dt.Rows[n]["OrderId"].ToString());
                    }
                    if (dt.Rows[n]["IsDictionary"].ToString() != "")
                    {
                        model.IsDictionary = int.Parse(dt.Rows[n]["IsDictionary"].ToString());
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
    }
}

