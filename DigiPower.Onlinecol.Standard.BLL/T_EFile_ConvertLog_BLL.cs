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
    public class T_EFile_ConvertLog_BLL
    {
        private readonly DigiPower.Onlinecol.Standard.DAL.T_EFile_ConvertLog_DAL dal = new DigiPower.Onlinecol.Standard.DAL.T_EFile_ConvertLog_DAL();
        public T_EFile_ConvertLog_BLL()
        { }

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
        public bool Exists(int LogID)
        {
            return dal.Exists(LogID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Add(DigiPower.Onlinecol.Standard.Model.T_EFile_ConvertLog_MDL model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(DigiPower.Onlinecol.Standard.Model.T_EFile_ConvertLog_MDL model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int LogID)
        {

            return dal.Delete(LogID);
        }

        /// <summary>
        /// ɾ����������
        /// </summary>
        public void DeleteMore(string LogID)
        {
            dal.DeleteMore(LogID);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool DeleteList(string LogIDlist)
        {
            return dal.DeleteList(LogIDlist);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_EFile_ConvertLog_MDL GetModel(int LogID)
        {

            return dal.GetModel(LogID);
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
        public List<DigiPower.Onlinecol.Standard.Model.T_EFile_ConvertLog_MDL> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<DigiPower.Onlinecol.Standard.Model.T_EFile_ConvertLog_MDL> DataTableToList(DataTable dt)
        {
            List<DigiPower.Onlinecol.Standard.Model.T_EFile_ConvertLog_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.T_EFile_ConvertLog_MDL>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DigiPower.Onlinecol.Standard.Model.T_EFile_ConvertLog_MDL model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        if (dt.Rows[n]["LogID"].ToString() != "")
                        {
                            model.LogID = int.Parse(dt.Rows[n]["LogID"].ToString());
                        }
                        if (dt.Rows[n]["SingleProjectID"].ToString() != "")
                        {
                            model.SingleProjectID = int.Parse(dt.Rows[n]["SingleProjectID"].ToString());
                        }
                        if (dt.Rows[n]["FileListID"].ToString() != "")
                        {
                            model.FileListID = int.Parse(dt.Rows[n]["FileListID"].ToString());
                        }
                        if (dt.Rows[n]["EFileID"].ToString() != "")
                        {
                            model.EFileID = int.Parse(dt.Rows[n]["EFileID"].ToString());
                        }

                        model.EFileStartPath = dt.Rows[n]["EFileStartPath"].ToString();
                        model.FileName = dt.Rows[n]["FileName"].ToString();
                        model.Description = dt.Rows[n]["Description"].ToString();
                        if (dt.Rows[n]["CreateDate"].ToString() != "")
                        {
                            model.CreateDate = DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
                        }
                        modelList.Add(model);
                    }
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
        /// ��ҳ��ȡ�����б�
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }


        /// <summary>
        /// ��������б� ��ҳ
        /// </summary>
        /// <returns></returns>
        public DataTable GetListPaging(string strWhere, int PageSize, int curPage, out int recCoun)
        {
            return dal.GetListPaging(strWhere, PageSize, curPage, "LogID", "SingleProjectID,LogID desc", out recCoun);
        }

    }
}

