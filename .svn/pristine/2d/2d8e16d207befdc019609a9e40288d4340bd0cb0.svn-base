using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
namespace DigiPower.Onlinecol.Standard.BLL
{
    /// <summary>
    /// 业务逻辑类T_Area_BLL 的摘要说明。
    /// </summary>
    public class T_EFile_ConvertLog_BLL
    {
        private readonly DigiPower.Onlinecol.Standard.DAL.T_EFile_ConvertLog_DAL dal = new DigiPower.Onlinecol.Standard.DAL.T_EFile_ConvertLog_DAL();
        public T_EFile_ConvertLog_BLL()
        { }

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int LogID)
        {
            return dal.Exists(LogID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DigiPower.Onlinecol.Standard.Model.T_EFile_ConvertLog_MDL model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DigiPower.Onlinecol.Standard.Model.T_EFile_ConvertLog_MDL model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int LogID)
        {

            return dal.Delete(LogID);
        }

        /// <summary>
        /// 删除多条数据
        /// </summary>
        public void DeleteMore(string LogID)
        {
            dal.DeleteMore(LogID);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string LogIDlist)
        {
            return dal.DeleteList(LogIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_EFile_ConvertLog_MDL GetModel(int LogID)
        {

            return dal.GetModel(LogID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DigiPower.Onlinecol.Standard.Model.T_EFile_ConvertLog_MDL> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }


        /// <summary>
        /// 获得数据列表 分页
        /// </summary>
        /// <returns></returns>
        public DataTable GetListPaging(string strWhere, int PageSize, int curPage, out int recCoun)
        {
            return dal.GetListPaging(strWhere, PageSize, curPage, "LogID", "SingleProjectID,LogID desc", out recCoun);
        }

    }
}

