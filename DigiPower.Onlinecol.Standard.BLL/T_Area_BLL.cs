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
    public class T_Area_BLL
    {
        private readonly DigiPower.Onlinecol.Standard.DAL.T_Area_DAL dal = new DigiPower.Onlinecol.Standard.DAL.T_Area_DAL();
        public T_Area_BLL()
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
        public bool Exists(int AreaID)
        {
            return dal.Exists(AreaID);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int AreaCode, int AreaID)
        {
            return dal.Exists(AreaCode, AreaID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_Area_MDL model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(DigiPower.Onlinecol.Standard.Model.T_Area_MDL model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int AreaID)
        {

            dal.Delete(AreaID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_Area_MDL GetModel(int AreaID)
        {

            return dal.GetModel(AreaID);
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
            return dal.GetList(strWhere, PageSize, curPage, "AreaID", "OrderIndex asc", out recCoun);
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
        public List<DigiPower.Onlinecol.Standard.Model.T_Area_MDL> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
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
    }
}

