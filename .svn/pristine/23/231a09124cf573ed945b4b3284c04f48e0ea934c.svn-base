using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
using System.Collections;
namespace DigiPower.Onlinecol.Standard.BLL
{
    /// <summary>
    /// 业务逻辑类T_SingleProject_BLL 的摘要说明。
    /// </summary>
    public class T_SingleProject_BLL
    {
        private readonly DigiPower.Onlinecol.Standard.DAL.T_SingleProject_DAL dal = new DigiPower.Onlinecol.Standard.DAL.T_SingleProject_DAL();
        public T_SingleProject_BLL() { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId() {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SingleProjectID) {
            return dal.Exists(SingleProjectID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_SingleProject_MDL model) {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(DigiPower.Onlinecol.Standard.Model.T_SingleProject_MDL model) {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int SingleProjectID) {

            dal.Delete(SingleProjectID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_SingleProject_MDL GetModel(int SingleProjectID) {
            return dal.GetModel(SingleProjectID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_SingleProject_MDL GetModelByCache(int SingleProjectID) {

            string CacheKey = "T_SingleProject_MDLModel-" + SingleProjectID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null) {
                try {
                    objModel = dal.GetModel(SingleProjectID);
                    if (objModel != null) {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (DigiPower.Onlinecol.Standard.Model.T_SingleProject_MDL)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere) {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder) {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DigiPower.Onlinecol.Standard.Model.T_SingleProject_MDL> GetModelList(string strWhere) {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DigiPower.Onlinecol.Standard.Model.T_SingleProject_MDL> DataTableToList(DataTable dt) {
            List<DigiPower.Onlinecol.Standard.Model.T_SingleProject_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.T_SingleProject_MDL>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0) {
                DigiPower.Onlinecol.Standard.Model.T_SingleProject_MDL model;
                for (int n = 0; n < rowsCount; n++) {
                    model = new DigiPower.Onlinecol.Standard.Model.T_SingleProject_MDL();
                    model.AREA_CODE = dt.Rows[n]["AREA_CODE"].ToString();
                    if (dt.Rows[n]["SingleProjectID"].ToString() != "") {
                        model.SingleProjectID = int.Parse(dt.Rows[n]["SingleProjectID"].ToString());
                    }
                    if (dt.Rows[n]["ConstructionProjectID"].ToString() != "") {
                        model.ConstructionProjectID = int.Parse(dt.Rows[n]["ConstructionProjectID"].ToString());
                    }
                    model.ProjectType = dt.Rows[n]["ProjectType"].ToString();
                    model.gcmc = dt.Rows[n]["gcmc"].ToString();
                    model.gcbm = dt.Rows[n]["gcbm"].ToString();
                    model.gcdd = dt.Rows[n]["gcdd"].ToString();
                    model.kgsj = dt.Rows[n]["kgsj"].ToString();
                    model.jgsj = dt.Rows[n]["jgsj"].ToString();
                    model.jsdw = dt.Rows[n]["jsdw"].ToString();
                    model.lxpzdw = dt.Rows[n]["lxpzdw"].ToString();
                    model.sjdw = dt.Rows[n]["sjdw"].ToString();
                    model.kcdw = dt.Rows[n]["kcdw"].ToString();
                    model.sgdw = dt.Rows[n]["sgdw"].ToString();
                    model.jldw = dt.Rows[n]["jldw"].ToString();
                    model.ghxkzh = dt.Rows[n]["ghxkzh"].ToString();
                    model.sgxkzh = dt.Rows[n]["sgxkzh"].ToString();
                    model.ysbah = dt.Rows[n]["ysbah"].ToString();
                    model.jgcldw = dt.Rows[n]["jgcldw"].ToString();
                    model.ghysh = dt.Rows[n]["ghysh"].ToString();
                    model.dxth = dt.Rows[n]["dxth"].ToString();
                    model.ghpzdw = dt.Rows[n]["ghpzdw"].ToString();
                    model.yddw = dt.Rows[n]["yddw"].ToString();
                    model.bzdw = dt.Rows[n]["bzdw"].ToString();
                    model.lxpzwh = dt.Rows[n]["lxpzwh"].ToString();
                    model.zdh = dt.Rows[n]["zdh"].ToString();
                    model.ydghxkzh = dt.Rows[n]["ydghxkzh"].ToString();
                    model.ydxkzh = dt.Rows[n]["ydxkzh"].ToString();
                    model.bsbh = dt.Rows[n]["bsbh"].ToString();
                    model.Badw = dt.Rows[n]["Badw"].ToString();
                    model.pzdw = dt.Rows[n]["pzdw"].ToString();
                    model.pzrq = dt.Rows[n]["pzrq"].ToString();
                    model.pzwh = dt.Rows[n]["pzwh"].ToString();
                    model.zjfsyr = dt.Rows[n]["zjfsyr"].ToString();
                    model.ydxmmc = dt.Rows[n]["ydxmmc"].ToString();
                    model.zdwz = dt.Rows[n]["zdwz"].ToString();
                    model.zbxmmc = dt.Rows[n]["zbxmmc"].ToString();
                    model.xmdz = dt.Rows[n]["xmdz"].ToString();
                    model.zbdw = dt.Rows[n]["zbdw"].ToString();
                    model.zongbdw = dt.Rows[n]["zongbdw"].ToString();
                    model.dljg = dt.Rows[n]["dljg"].ToString();
                    model.sgxkspdw = dt.Rows[n]["sgxkspdw"].ToString();


                    if (dt.Rows[n]["CompanyUserID"].ToString() != "") {
                        model.CompanyUserID = int.Parse(dt.Rows[n]["CompanyUserID"].ToString());
                    }
                    if (dt.Rows[n]["ChargeUserID"].ToString() != "") {
                        model.ChargeUserID = int.Parse(dt.Rows[n]["ChargeUserID"].ToString());
                    }
                    if (dt.Rows[n]["AllotUserID"].ToString() != "") {
                        model.AllotUserID = int.Parse(dt.Rows[n]["AllotUserID"].ToString());
                    }
                    if (dt.Rows[n]["AllotDate"].ToString() != "") {
                        model.AllotDate = DateTime.Parse(dt.Rows[n]["AllotDate"].ToString());
                    }
                    if (dt.Rows[n]["Status"].ToString() != "") {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    if (dt.Rows[n]["CreateDate"].ToString() != "") {
                        model.CreateDate = DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
                    }
                    model.TDSYZPic = dt.Rows[n]["TDSYZPic"].ToString();
                    model.GHXKZPic = dt.Rows[n]["GHXKZPic"].ToString();
                    model.SGXKZPic = dt.Rows[n]["SGXKZPic"].ToString();
                    model.gcqy = dt.Rows[n]["gcqy"].ToString();

                    if (dt.Rows[n]["Rksj"].ToString() != "") {
                        model.Rksj = DateTime.Parse(dt.Rows[n]["Rksj"].ToString());
                    }

                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList(string strWhere) {
            return GetList(strWhere);
        }

        #endregion  成员方法
        public DataSet GetListUnionProjectTypeName(string strWhere) {
            return dal.GetListUnionProjectTypeName(strWhere);
        }

        /// <summary>
        /// 根据单位取工程
        /// </summary>
        /// <param name="companyid"></param>
        /// <returns></returns>
        public DataSet GetListByCompanyId(int companyid) {
            return dal.GetListByCompanyId(companyid);
        }

        /// <summary>
        /// 根据单位取工程
        /// </summary>
        /// <param name="companyid"></param>
        /// <returns></returns>
        public DataSet GetListByCompanyId(int companyid, string strWhere) {
            return dal.GetListByCompanyId(companyid, strWhere);
        }

        /// <summary>
        /// 获得数据列表 分页
        /// </summary>
        /// <returns></returns>
        public DataTable GetListPaging(int companyid, string strWhere, int PageSize, int curPage, out int recCoun) {
            return dal.GetListByCompanyId(companyid, strWhere, PageSize, curPage, "SingleProjectID", "SingleProjectID desc", out recCoun);
        }

        /// <summary>
        /// 获得数据列表 分页
        /// </summary>
        /// <returns></returns>
        public DataTable GetListPaging(Hashtable ht, int PageSize, int curPage, out int recCoun) {
            return dal.GetListByCompanyId(ht, PageSize, curPage, "SingleProjectCompanyID", "SingleProjectID desc", out recCoun);
        }

        /// <summary>
        ///根据用户ID,获取用户相关工程信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetListByUserId(string strWhere, int PageSize, int curPage, out int recCoun) {
            return dal.GetListByUserId(strWhere, PageSize, curPage, "SingleProjectID", "SingleProjectID desc", out recCoun);
        }

        /// <summary>
        /// 获得数据列表 分页
        /// </summary>
        /// <returns></returns>
        public DataTable GetListPaging(string strWhere, int PageSize, int curPage, out int recCoun) {
            return dal.GetList(strWhere, PageSize, curPage, "SingleProjectID", "GCBM desc", out recCoun);
        }

        /// <summary>
        ///获得单位-项目-工程层级信息 
        /// </summary>
        public DataSet GetCompanyPro(string strWhere) {
            return dal.GetCompanyPro(strWhere);
        }

        public DataSet Get_gcdtgz(int singleprojectid) {
            return dal.Get_gcdtgz(singleprojectid);
        }

        public DataSet GetListEx(int CompanyID, string sqlWhere) {
            return dal.GetListEx(CompanyID, sqlWhere);
        }

        public DataSet GetListEx2(int CompanyID, string sqlWhere) {
            return dal.GetListEx2(CompanyID, sqlWhere);
        }
        public int DeleteSingleProjectTable(int SingleProjectID, string tname) {
            return dal.DeleteSingleProjectTable(SingleProjectID, tname);

        }
        public int GetSingleProjectCountByCompany(int CompanyID) {
            return dal.GetSingleProjectCountByCompany(CompanyID);
        }

    }
}