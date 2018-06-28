using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
using System.Text;
using DigiPower.Onlinecol.Standard.DAL;
namespace DigiPower.Onlinecol.Standard.BLL
{
    /// <summary>
    /// ҵ���߼���T_WorkFlow_BLL ��ժҪ˵����
    /// </summary>
    public class T_WorkFlow_BLL
    {
        private readonly DigiPower.Onlinecol.Standard.DAL.T_WorkFlow_DAL dal = new DigiPower.Onlinecol.Standard.DAL.T_WorkFlow_DAL();
        public T_WorkFlow_BLL()
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
        public bool Exists(int WorkFlowID)
        {
            return dal.Exists(WorkFlowID);
        }

        /// <summary>
        /// �ж����̱���Ƿ����
        /// </summary>
        /// <param name="WorkFlowCode"></param>
        /// <param name="WorkFlowID"></param>
        /// <returns></returns>
        public bool Exists(string WorkFlowCode, int WorkFlowID, int CompanyID)
        {
            return dal.Exists(WorkFlowCode, WorkFlowID, CompanyID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_WorkFlow_MDL model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(DigiPower.Onlinecol.Standard.Model.T_WorkFlow_MDL model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int WorkFlowID)
        {

            dal.Delete(WorkFlowID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_WorkFlow_MDL GetModel(int WorkFlowID)
        {

            return dal.GetModel(WorkFlowID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_WorkFlow_MDL GetModelByCache(int WorkFlowID)
        {

            string CacheKey = "T_WorkFlow_MDLModel-" + WorkFlowID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(WorkFlowID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (DigiPower.Onlinecol.Standard.Model.T_WorkFlow_MDL)objModel;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// ��������б� ��ҳ
        /// </summary>
        /// <returns></returns>
        public DataTable GetListPaging(string strWhere, int PageSize, int curPage, out int recCoun)
        {
            return dal.GetList(strWhere, PageSize, curPage, "WorkFlowID", "CompanyID,OrderIndex asc", out recCoun);
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
        public List<DigiPower.Onlinecol.Standard.Model.T_WorkFlow_MDL> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<DigiPower.Onlinecol.Standard.Model.T_WorkFlow_MDL> DataTableToList(DataTable dt)
        {
            List<DigiPower.Onlinecol.Standard.Model.T_WorkFlow_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.T_WorkFlow_MDL>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DigiPower.Onlinecol.Standard.Model.T_WorkFlow_MDL model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new DigiPower.Onlinecol.Standard.Model.T_WorkFlow_MDL();
                    if (dt.Rows[n]["WorkFlowID"].ToString() != "")
                    {
                        model.WorkFlowID = int.Parse(dt.Rows[n]["WorkFlowID"].ToString());
                    }
                    model.WorkFlowCode = dt.Rows[n]["WorkFlowCode"].ToString();
                    model.WorkFlowName = dt.Rows[n]["WorkFlowName"].ToString();
                    if (dt.Rows[n]["OrderIndex"].ToString() != "")
                    {
                        model.OrderIndex = int.Parse(dt.Rows[n]["OrderIndex"].ToString());
                    }
                    if (dt.Rows[n]["Del"].ToString() != "")
                    {
                        if ((dt.Rows[n]["Del"].ToString() == "1") || (dt.Rows[n]["Del"].ToString().ToLower() == "true"))
                        {
                            model.Del = true;
                        }
                        else
                        {
                            model.Del = false;
                        }
                    }
                    if (dt.Rows[n]["PID"].ToString() != "")
                    {
                        model.PID = int.Parse(dt.Rows[n]["PID"].ToString());
                    }
                    if (dt.Rows[n]["RoleID"].ToString() != "")
                    {
                        model.RoleID = int.Parse(dt.Rows[n]["RoleID"].ToString());
                    }
                    if (dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = int.Parse(dt.Rows[n]["UserID"].ToString());
                    }
                    if (dt.Rows[n]["UseForSuperAdmin"].ToString() != "")
                    {
                        if ((dt.Rows[n]["UseForSuperAdmin"].ToString() == "1") || (dt.Rows[n]["UseForSuperAdmin"].ToString().ToLower() == "true"))
                        {
                            model.UseForSuperAdmin = true;
                        }
                        else
                        {
                            model.UseForSuperAdmin = false;
                        }
                    }
                    if (dt.Rows[n]["UseForArchive"].ToString() != "")
                    {
                        if ((dt.Rows[n]["UseForArchive"].ToString() == "1") || (dt.Rows[n]["UseForArchive"].ToString().ToLower() == "true"))
                        {
                            model.UseForArchive = true;
                        }
                        else
                        {
                            model.UseForArchive = false;
                        }
                    }
                    if (dt.Rows[n]["UseForCompanyLeader"].ToString() != "")
                    {
                        if ((dt.Rows[n]["UseForCompanyLeader"].ToString() == "1") || (dt.Rows[n]["UseForCompanyLeader"].ToString().ToLower() == "true"))
                        {
                            model.UseForCompanyLeader = true;
                        }
                        else
                        {
                            model.UseForCompanyLeader = false;
                        }
                    }
                    if (dt.Rows[n]["UseForCompany"].ToString() != "")
                    {
                        if ((dt.Rows[n]["UseForCompany"].ToString() == "1") || (dt.Rows[n]["UseForCompany"].ToString().ToLower() == "true"))
                        {
                            model.UseForCompany = true;
                        }
                        else
                        {
                            model.UseForCompany = false;
                        }
                    }
                    if (dt.Rows[n]["UseForAll"].ToString() != "")
                    {
                        if ((dt.Rows[n]["UseForAll"].ToString() == "1") || (dt.Rows[n]["UseForAll"].ToString().ToLower() == "true"))
                        {
                            model.UseForAll = true;
                        }
                        else
                        {
                            model.UseForAll = false;
                        }
                    }
                    model.SubmitURL = dt.Rows[n]["SubmitURL"].ToString();
                    model.DoResultURL = dt.Rows[n]["DoResultURL"].ToString();

                    if (dt.Rows[n]["CompanyID"].ToString() != "")
                    {
                        model.CompanyID = int.Parse(dt.Rows[n]["CompanyID"].ToString());
                    }
                    model.DescriptionToArchive = dt.Rows[n]["DescriptionToArchive"].ToString();
                    model.DescriptionToCompany = dt.Rows[n]["DescriptionToCompany"].ToString();
                    model.RightListID = dt.Rows[n]["RightListID"].ToString();

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

        #endregion  ��Ա����

        public DigiPower.Onlinecol.Standard.Model.T_WorkFlow_MDL GetModel(string whereSql)
        {
            return dal.GetModel(whereSql);
        }
        public DataSet GetWorkFlowList(string RoleID, string UserID, string AreaSID, bool isCompany = false)
        {
            return dal.GetWorkFlowList(RoleID, UserID, AreaSID, isCompany);
        }
    }
}