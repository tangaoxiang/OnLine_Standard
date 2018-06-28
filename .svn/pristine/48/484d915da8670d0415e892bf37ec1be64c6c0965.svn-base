using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
namespace DigiPower.Onlinecol.Standard.BLL
{
    /// <summary>
    /// 业务逻辑类T_SingleProjectUser_BLL 的摘要说明。
    /// </summary>
    public class T_SingleProjectUser_BLL
    {
        private readonly DigiPower.Onlinecol.Standard.DAL.T_SingleProjectUser_DAL dal = new DigiPower.Onlinecol.Standard.DAL.T_SingleProjectUser_DAL();
        public T_SingleProjectUser_BLL()
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
        public bool Exists(int SingleProjectUserID)
        {
            return dal.Exists(SingleProjectUserID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_SingleProjectUser_MDL model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(DigiPower.Onlinecol.Standard.Model.T_SingleProjectUser_MDL model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int SingleProjectUserID)
        {

            dal.Delete(SingleProjectUserID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_SingleProjectUser_MDL GetModel(int SingleProjectUserID)
        {

            return dal.GetModel(SingleProjectUserID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_SingleProjectUser_MDL GetModelByCache(int SingleProjectUserID)
        {

            string CacheKey = "T_SingleProjectUser_MDLModel-" + SingleProjectUserID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(SingleProjectUserID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (DigiPower.Onlinecol.Standard.Model.T_SingleProjectUser_MDL)objModel;
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
        public List<DigiPower.Onlinecol.Standard.Model.T_SingleProjectUser_MDL> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DigiPower.Onlinecol.Standard.Model.T_SingleProjectUser_MDL> DataTableToList(DataTable dt)
        {
            List<DigiPower.Onlinecol.Standard.Model.T_SingleProjectUser_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.T_SingleProjectUser_MDL>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DigiPower.Onlinecol.Standard.Model.T_SingleProjectUser_MDL model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new DigiPower.Onlinecol.Standard.Model.T_SingleProjectUser_MDL();
                    if (dt.Rows[n]["SingleProjectUserID"].ToString() != "")
                    {
                        model.SingleProjectUserID = int.Parse(dt.Rows[n]["SingleProjectUserID"].ToString());
                    }
                    if (dt.Rows[n]["SingleProjectID"].ToString() != "")
                    {
                        model.SingleProjectID = int.Parse(dt.Rows[n]["SingleProjectID"].ToString());
                    }
                    if (dt.Rows[n]["RoleID"].ToString() != "")
                    {
                        model.RoleID = int.Parse(dt.Rows[n]["RoleID"].ToString());
                    }
                    if (dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = int.Parse(dt.Rows[n]["UserID"].ToString());
                    }
                    if (dt.Rows[n]["CreateDate"].ToString() != "")
                    {
                        model.CreateDate = DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
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

        public DataSet GetListByRoleID(string RoleID)
        {
            return dal.GetListByRoleID(RoleID);
        }

        /// <summary>
        /// 取工程所属用户
        /// </summary>
        /// <param name="SingleProjectID"></param>
        /// <returns></returns>
        public DataSet GetProjectUsers(int SingleProjectID)
        {
            return dal.GetProjectUsers(SingleProjectID);
        }

        /// <summary>
        /// 删除工程用户关联表中某一用户
        /// </summary>
        /// <param name="singleProjectID"></param>
        /// <param name="userID"></param>
        public void DeleteSingleProjectUser(string singleProjectID, string userID)
        {
            dal.DeleteSingleProjectUser(singleProjectID, userID);
        }

        /// <summary>
        /// 删除工程用户关联表中工程
        /// </summary>
        /// <param name="singleProjectID"></param>
        /// <param name="userID"></param>
        public void DeleteSingleProjectUser(string singleProjectID)
        {
            dal.DeleteSingleProjectUser(singleProjectID);
        }
    }
}

