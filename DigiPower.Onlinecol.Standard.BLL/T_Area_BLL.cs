using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
namespace DigiPower.Onlinecol.Standard.BLL
{
    /// <summary>
    /// ҵ���߼���T_Area_BLL ��ժҪ˵����
    /// </summary>
    public class T_Area_BLL
    {
        private readonly DigiPower.Onlinecol.Standard.DAL.T_Area_DAL dal = new DigiPower.Onlinecol.Standard.DAL.T_Area_DAL();
        public T_Area_BLL()
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
        public bool Exists(int AreaID)
        {
            return dal.Exists(AreaID);
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int AreaCode, int AreaID)
        {
            return dal.Exists(AreaCode, AreaID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_Area_MDL model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(DigiPower.Onlinecol.Standard.Model.T_Area_MDL model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int AreaID)
        {

            dal.Delete(AreaID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_Area_MDL GetModel(int AreaID)
        {

            return dal.GetModel(AreaID);
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
            return dal.GetList(strWhere, PageSize, curPage, "AreaID", "OrderIndex asc", out recCoun);
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
        public List<DigiPower.Onlinecol.Standard.Model.T_Area_MDL> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<DigiPower.Onlinecol.Standard.Model.T_Area_MDL> DataTableToList(DataTable dt)
        {
            List<DigiPower.Onlinecol.Standard.Model.T_Area_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.T_Area_MDL>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DigiPower.Onlinecol.Standard.Model.T_Area_MDL model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new DigiPower.Onlinecol.Standard.Model.T_Area_MDL();
                    if (dt.Rows[n]["AreaID"].ToString() != "")
                    {
                        model.AreaID = int.Parse(dt.Rows[n]["AreaID"].ToString());
                    }
                    model.area_code = dt.Rows[n]["area_code"].ToString();
                    model.area_name = dt.Rows[n]["area_name"].ToString();
                    if (dt.Rows[n]["PID"].ToString() != "")
                    {
                        model.PID = int.Parse(dt.Rows[n]["PID"].ToString());
                    }
                    if (dt.Rows[n]["OrderIndex"].ToString() != "")
                    {
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
