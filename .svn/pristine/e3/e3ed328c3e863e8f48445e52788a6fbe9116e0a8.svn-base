using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
namespace DigiPower.Onlinecol.Standard.BLL
{
    /// <summary>
    /// 业务逻辑类T_Construction_Project_BLL 的摘要说明。
    /// </summary>
    public class T_Construction_Project_BLL
    {
        private readonly DigiPower.Onlinecol.Standard.DAL.T_Construction_Project_DAL dal = new DigiPower.Onlinecol.Standard.DAL.T_Construction_Project_DAL();
        public T_Construction_Project_BLL()
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
        public bool Exists(int ConstructionProjectID)
        {
            return dal.Exists(ConstructionProjectID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_Construction_Project_MDL model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(DigiPower.Onlinecol.Standard.Model.T_Construction_Project_MDL model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ConstructionProjectID)
        {

            dal.Delete(ConstructionProjectID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_Construction_Project_MDL GetModel(int ConstructionProjectID)
        {

            return dal.GetModel(ConstructionProjectID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_Construction_Project_MDL GetModelByCache(int ConstructionProjectID)
        {

            string CacheKey = "T_Construction_Project_MDLModel-" + ConstructionProjectID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ConstructionProjectID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (DigiPower.Onlinecol.Standard.Model.T_Construction_Project_MDL)objModel;
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
        public List<DigiPower.Onlinecol.Standard.Model.T_Construction_Project_MDL> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DigiPower.Onlinecol.Standard.Model.T_Construction_Project_MDL> DataTableToList(DataTable dt)
        {
            List<DigiPower.Onlinecol.Standard.Model.T_Construction_Project_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.T_Construction_Project_MDL>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DigiPower.Onlinecol.Standard.Model.T_Construction_Project_MDL model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new DigiPower.Onlinecol.Standard.Model.T_Construction_Project_MDL();
                    if (dt.Rows[n]["ConstructionProjectID"].ToString() != "")
                    {
                        model.ConstructionProjectID = int.Parse(dt.Rows[n]["ConstructionProjectID"].ToString());
                    }
                    if (dt.Rows[n]["CompanyID"].ToString() != "")
                    {
                        model.CompanyID = int.Parse(dt.Rows[n]["CompanyID"].ToString());
                    }
                    model.ProjectType = dt.Rows[n]["ProjectType"].ToString();
                    model.xmh = dt.Rows[n]["xmh"].ToString();
                    model.xmmc = dt.Rows[n]["xmmc"].ToString();
                    model.xmdd = dt.Rows[n]["xmdd"].ToString();
                    model.jsdw = dt.Rows[n]["jsdw"].ToString();
                    model.lxpzdw = dt.Rows[n]["lxpzdw"].ToString();
                    model.tdsyzh = dt.Rows[n]["tdsyzh"].ToString();
                    model.ydghxkzh = dt.Rows[n]["ydghxkzh"].ToString();
                    model.lxpzwh = dt.Rows[n]["lxpzwh"].ToString();
                    if (dt.Rows[n]["tdcrnx"].ToString() != "")
                    {
                        model.tdcrnx = int.Parse(dt.Rows[n]["tdcrnx"].ToString());
                    }
                    model.kgxj = dt.Rows[n]["kgxj"].ToString();
                    model.jgsj = dt.Rows[n]["jgsj"].ToString();
                    if (dt.Rows[n]["zydmj"].ToString() != "")
                    {
                        model.zydmj = decimal.Parse(dt.Rows[n]["zydmj"].ToString());
                    }
                    if (dt.Rows[n]["zjzmj"].ToString() != "")
                    {
                        model.zjzmj = decimal.Parse(dt.Rows[n]["zjzmj"].ToString());
                    }
                    if (dt.Rows[n]["ds"].ToString() != "")
                    {
                        model.ds = int.Parse(dt.Rows[n]["ds"].ToString());
                    }
                    if (dt.Rows[n]["gcjs"].ToString() != "")
                    {
                        model.gcjs = decimal.Parse(dt.Rows[n]["gcjs"].ToString());
                    }
                    if (dt.Rows[n]["rjl"].ToString() != "")
                    {
                        model.rjl = decimal.Parse(dt.Rows[n]["rjl"].ToString());
                    }
                    if (dt.Rows[n]["lhl"].ToString() != "")
                    {
                        model.lhl = decimal.Parse(dt.Rows[n]["lhl"].ToString());
                    }
                    if (dt.Rows[n]["cws"].ToString() != "")
                    {
                        model.cws = int.Parse(dt.Rows[n]["cws"].ToString());
                    }
                    if (dt.Rows[n]["jzmd"].ToString() != "")
                    {
                        model.jzmd = decimal.Parse(dt.Rows[n]["jzmd"].ToString());
                    }
                    if (dt.Rows[n]["zcd"].ToString() != "")
                    {
                        model.zcd = decimal.Parse(dt.Rows[n]["zcd"].ToString());
                    }
                    model.zbfl = dt.Rows[n]["zbfl"].ToString();
                    model.zbxs = dt.Rows[n]["zbxs"].ToString();
                    if (dt.Rows[n]["zzj"].ToString() != "")
                    {
                        model.zzj = decimal.Parse(dt.Rows[n]["zzj"].ToString());
                    }
                    if (dt.Rows[n]["cqzhs"].ToString() != "")
                    {
                        model.cqzhs = int.Parse(dt.Rows[n]["cqzhs"].ToString());
                    }
                    if (dt.Rows[n]["zjs"].ToString() != "")
                    {
                        model.zjs = int.Parse(dt.Rows[n]["zjs"].ToString());
                    }
                    if (dt.Rows[n]["wzcl"].ToString() != "")
                    {
                        model.wzcl = int.Parse(dt.Rows[n]["wzcl"].ToString());
                    }
                    if (dt.Rows[n]["tz"].ToString() != "")
                    {
                        model.tz = int.Parse(dt.Rows[n]["tz"].ToString());
                    }
                    if (dt.Rows[n]["dt"].ToString() != "")
                    {
                        model.dt = int.Parse(dt.Rows[n]["dt"].ToString());
                    }
                    if (dt.Rows[n]["zp"].ToString() != "")
                    {
                        model.zp = int.Parse(dt.Rows[n]["zp"].ToString());
                    }
                    if (dt.Rows[n]["dp"].ToString() != "")
                    {
                        model.dp = int.Parse(dt.Rows[n]["dp"].ToString());
                    }
                    if (dt.Rows[n]["lyd"].ToString() != "")
                    {
                        model.lyd = int.Parse(dt.Rows[n]["lyd"].ToString());
                    }
                    if (dt.Rows[n]["lxd"].ToString() != "")
                    {
                        model.lxd = int.Parse(dt.Rows[n]["lxd"].ToString());
                    }
                    if (dt.Rows[n]["gp"].ToString() != "")
                    {
                        model.gp = int.Parse(dt.Rows[n]["gp"].ToString());
                    }
                    if (dt.Rows[n]["cd"].ToString() != "")
                    {
                        model.cd = int.Parse(dt.Rows[n]["cd"].ToString());
                    }
                    if (dt.Rows[n]["cp"].ToString() != "")
                    {
                        model.cp = int.Parse(dt.Rows[n]["cp"].ToString());
                    }
                    if (dt.Rows[n]["swjp"].ToString() != "")
                    {
                        model.swjp = int.Parse(dt.Rows[n]["swjp"].ToString());
                    }
                    model.qt = dt.Rows[n]["qt"].ToString();
                    model.bgqx = dt.Rows[n]["bgqx"].ToString();
                    model.mj = dt.Rows[n]["mj"].ToString();
                    if (dt.Rows[n]["jgrq"].ToString() != "")
                    {
                        model.jgrq = DateTime.Parse(dt.Rows[n]["jgrq"].ToString());
                    }
                    model.yjdw = dt.Rows[n]["yjdw"].ToString();
                    model.dh = dt.Rows[n]["dh"].ToString();
                    model.swh = dt.Rows[n]["swh"].ToString();
                    model.cfwzqsh = dt.Rows[n]["cfwzqsh"].ToString();
                    model.fz = dt.Rows[n]["fz"].ToString();
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

        public DataSet GetConstructionPromiseList(string strWhere)
        {
            return dal.GetConstructionPromiseList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByRight(string CompanyID, string RoleID)
        {
            return dal.GetListByRight(CompanyID, RoleID);
        }

        /// <summary>
        /// 获得数据列表,有权限控制   jdk 10.24
        /// </summary>
        public DataSet GetListByRight(string CompanyID, string RoleID, string Area_Code)
        {
            return dal.GetListByRight(CompanyID, RoleID, Area_Code);
        }

        /// <summary>
        /// 获得数据列表 分页
        /// </summary>
        /// <returns></returns>
        public DataTable GetListPaging(string CompanyID, string RoleID, int PageSize, int curPage, out int recCoun)
        {
            return dal.GetListByRight(CompanyID, RoleID, PageSize, curPage, "ConstructionProjectID", "ConstructionProjectID DESC", out recCoun);
        }
                   
        /// <summary>
        /// 获得数据列表 分页
        /// </summary>
        /// <returns></returns>
        public DataTable GetListPaging(string CompanyID, string RoleID, string Area_Code, int PageSize, int curPage, out int recCoun,string where = "")
        {
            return dal.GetListByRight(CompanyID, RoleID, Area_Code, PageSize, curPage, "ConstructionProjectID", "ConstructionProjectID DESC", out recCoun, where);
        }

        public List<T_Construction_Project_MDL> GetConstructionListByCompanyID(string strWhere)
        {
            DataSet ds = dal.GetConstructionListByCompanyID(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
    }
}

