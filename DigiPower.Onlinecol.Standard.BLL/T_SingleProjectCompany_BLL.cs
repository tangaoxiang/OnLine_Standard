using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
namespace DigiPower.Onlinecol.Standard.BLL
{
    /// <summary>
    /// ҵ���߼���T_SingleProjectCompany_BLL ��ժҪ˵����
    /// </summary>
    public class T_SingleProjectCompany_BLL
    {
        private readonly DigiPower.Onlinecol.Standard.DAL.T_SingleProjectCompany_DAL dal = new DigiPower.Onlinecol.Standard.DAL.T_SingleProjectCompany_DAL();
        public T_SingleProjectCompany_BLL()
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
        public bool Exists(int SingleProjectCompanyID)
        {
            return dal.Exists(SingleProjectCompanyID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_SingleProjectCompany_MDL model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(DigiPower.Onlinecol.Standard.Model.T_SingleProjectCompany_MDL model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int SingleProjectCompanyID)
        {

            dal.Delete(SingleProjectCompanyID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_SingleProjectCompany_MDL GetModel(int SingleProjectCompanyID)
        {

            return dal.GetModel(SingleProjectCompanyID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_SingleProjectCompany_MDL GetModelByCache(int SingleProjectCompanyID)
        {

            string CacheKey = "T_SingleProjectCompany_MDLModel-" + SingleProjectCompanyID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(SingleProjectCompanyID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (DigiPower.Onlinecol.Standard.Model.T_SingleProjectCompany_MDL)objModel;
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
        public List<DigiPower.Onlinecol.Standard.Model.T_SingleProjectCompany_MDL> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<DigiPower.Onlinecol.Standard.Model.T_SingleProjectCompany_MDL> DataTableToList(DataTable dt)
        {
            List<DigiPower.Onlinecol.Standard.Model.T_SingleProjectCompany_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.T_SingleProjectCompany_MDL>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DigiPower.Onlinecol.Standard.Model.T_SingleProjectCompany_MDL model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new DigiPower.Onlinecol.Standard.Model.T_SingleProjectCompany_MDL();
                    if (dt.Rows[n]["SingleProjectCompanyID"].ToString() != "")
                    {
                        model.SingleProjectCompanyID = int.Parse(dt.Rows[n]["SingleProjectCompanyID"].ToString());
                    }
                    if (dt.Rows[n]["SingleProjectID"].ToString() != "")
                    {
                        model.SingleProjectID = int.Parse(dt.Rows[n]["SingleProjectID"].ToString());
                    }
                    if (dt.Rows[n]["CompanyID"].ToString() != "")
                    {
                        model.CompanyID = int.Parse(dt.Rows[n]["CompanyID"].ToString());
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
        /// ��ȡ���������û�
        /// </summary>
        /// <param name="SingleProjectID"></param>
        /// <returns></returns>
        public DataSet GetSingleProjectUser(int SingleProjectID)
        {
            return dal.GetSingleProjectUser(SingleProjectID);
        }

        /// <summary>
        /// ��ȡ������ĳ�๫˾
        /// </summary>
        /// <param name="SingleProjectID"></param>
        /// <param name="CompanyType"></param>
        /// <returns></returns>
        public DataTable GetSingleProjectCompany(string SingleProjectID, string CompanyType)
        {
            return dal.GetSingleProjectCompany(SingleProjectID, CompanyType);
        }

        /// <summary>
        /// ɾ�����̹�˾��������ĳһ���͹�˾
        /// </summary>
        public void DeleteSingleProjectCompany(string singleProjectID, string companyType)
        {
            dal.DeleteSingleProjectCompany(singleProjectID, companyType);
        }

        /// <summary>
        /// ɾ�����̹�˾�������еĹ�˾
        /// </summary>
        /// <param name="singleProjectID"></param>
        /// <param name="companyID"></param>
        public void DeleteSingleProjectCompany(string singleProjectID, int companyID)
        {
            dal.DeleteSingleProjectCompany(singleProjectID, companyID);
        }

        /// <summary>
        /// ɾ�����̹�˾�������еĹ���
        /// </summary>
        /// <param name="singleProjectID"></param>
        /// <param name="companyID"></param>
        public void DeleteSingleProjectCompany(string singleProjectID)
        {
            dal.DeleteSingleProjectCompany(singleProjectID);
        }
    }
}
