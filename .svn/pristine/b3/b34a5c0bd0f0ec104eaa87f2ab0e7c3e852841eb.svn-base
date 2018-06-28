using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
namespace DigiPower.Onlinecol.Standard.BLL
{
    /// <summary>
    /// 业务逻辑类T_SystemInfo_BLL 的摘要说明。
    /// </summary>
    public class T_SystemInfo_BLL
    {
        private readonly DigiPower.Onlinecol.Standard.DAL.T_SystemInfo_DAL dal = new DigiPower.Onlinecol.Standard.DAL.T_SystemInfo_DAL();
        public T_SystemInfo_BLL()
        { }
        #region  成员方法

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
        public bool Exists(int SystemInfoID)
        {
            return dal.Exists(SystemInfoID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_SystemInfo_MDL model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(DigiPower.Onlinecol.Standard.Model.T_SystemInfo_MDL model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int SystemInfoID)
        {

            dal.Delete(SystemInfoID);
        }

        /// <summary>
        /// 删除多条数据
        /// </summary>
        public void DeleteMore(string SystemInfoID)
        {

            dal.DeleteMore(SystemInfoID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_SystemInfo_MDL GetModel(int SystemInfoID)
        {

            return dal.GetModel(SystemInfoID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_SystemInfo_MDL GetModelByCache(int SystemInfoID)
        {

            string CacheKey = "T_SystemInfo_MDLModel-" + SystemInfoID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(SystemInfoID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (DigiPower.Onlinecol.Standard.Model.T_SystemInfo_MDL)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得数据列表 分页
        /// </summary>
        /// <returns></returns>
        public DataTable GetListPaging(string strWhere, int PageSize, int curPage, out int recCoun)
        {
            return dal.GetList(strWhere, PageSize, curPage, "SystemInfoID", "OrderIndex asc", out recCoun);
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
        public List<DigiPower.Onlinecol.Standard.Model.T_SystemInfo_MDL> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DigiPower.Onlinecol.Standard.Model.T_SystemInfo_MDL> DataTableToList(DataTable dt)
        {
            List<DigiPower.Onlinecol.Standard.Model.T_SystemInfo_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.T_SystemInfo_MDL>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DigiPower.Onlinecol.Standard.Model.T_SystemInfo_MDL model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new DigiPower.Onlinecol.Standard.Model.T_SystemInfo_MDL();
                    if (dt.Rows[n]["SystemInfoID"].ToString() != "")
                    {
                        model.SystemInfoID = int.Parse(dt.Rows[n]["SystemInfoID"].ToString());
                    }
                    model.CurrentType = dt.Rows[n]["CurrentType"].ToString();
                    model.CurrentTypeCNName = dt.Rows[n]["CurrentTypeCNName"].ToString();
                    model.SystemInfoCode = dt.Rows[n]["SystemInfoCode"].ToString();
                    model.SystemInfoName = dt.Rows[n]["SystemInfoName"].ToString();
                    model.SubType = dt.Rows[n]["SubType"].ToString();
                    if (dt.Rows[n]["OrderIndex"].ToString() != "")
                    {
                        model.OrderIndex = int.Parse(dt.Rows[n]["OrderIndex"].ToString());
                    }
                    if (dt.Rows[n]["ParentID"].ToString() != "")
                    {
                        model.ParentID = int.Parse(dt.Rows[n]["ParentID"].ToString());
                    }
                    if (dt.Rows[n]["IsShow"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsShow"].ToString() == "1") || (dt.Rows[n]["IsShow"].ToString().ToLower() == "true"))
                        {
                            model.IsShow = true;
                        }
                        else
                        {
                            model.IsShow = false;
                        }
                    }
                    if (dt.Rows[n]["IfEdit"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IfEdit"].ToString() == "1") || (dt.Rows[n]["IfEdit"].ToString().ToLower() == "true"))
                        {
                            model.IfEdit = true;
                        }
                        else
                        {
                            model.IfEdit = false;
                        }
                    }
                    modelList.Add(model);
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
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  成员方法


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DigiPower.Onlinecol.Standard.Model.T_SystemInfo_MDL> GetModelListForCurrentType(string CurrentType)
        {
            if (!string.IsNullOrWhiteSpace(CurrentType))
            {
                DataSet ds = dal.GetList("LOWER(CurrentType)='" + CurrentType.ToLower() + "'");
                return DataTableToList(ds.Tables[0]);
            }
            return null;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DigiPower.Onlinecol.Standard.Model.T_SystemInfo_MDL> GetModelListForCurrentType(string CurrentType, string SystemInfoCode)
        {
            if (!string.IsNullOrWhiteSpace(CurrentType))
            {
                DataSet ds = dal.GetList("LOWER(CurrentType)='" + CurrentType.ToLower() + "' and SystemInfoCode in(" + SystemInfoCode + ")");
                return DataTableToList(ds.Tables[0]);
            }
            return null;
        }
    }
}

