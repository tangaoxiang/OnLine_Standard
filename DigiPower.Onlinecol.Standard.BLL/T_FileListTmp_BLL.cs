using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
namespace DigiPower.Onlinecol.Standard.BLL {
    /// <summary>
    /// 业务逻辑类T_FileListTmp_BLL 的摘要说明。
    /// </summary>
    public class T_FileListTmp_BLL {
        private readonly DigiPower.Onlinecol.Standard.DAL.T_FileListTmp_DAL dal = new DigiPower.Onlinecol.Standard.DAL.T_FileListTmp_DAL();
        public T_FileListTmp_BLL() { }
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
        public bool Exists(int recid) {
            return dal.Exists(recid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_FileListTmp_MDL model) {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(DigiPower.Onlinecol.Standard.Model.T_FileListTmp_MDL model) {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int recid) {

            dal.Delete(recid);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_FileListTmp_MDL GetModel(int recid) {

            return dal.GetModel(recid);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_FileListTmp_MDL GetModelByCache(int recid) {

            string CacheKey = "T_FileListTmp_MDLModel-" + recid;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null) {
                try {
                    objModel = dal.GetModel(recid);
                    if (objModel != null) {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                } catch { }
            }
            return (DigiPower.Onlinecol.Standard.Model.T_FileListTmp_MDL)objModel;
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
        public List<DigiPower.Onlinecol.Standard.Model.T_FileListTmp_MDL> GetModelList(string strWhere) {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DigiPower.Onlinecol.Standard.Model.T_FileListTmp_MDL> DataTableToList(DataTable dt) {
            List<DigiPower.Onlinecol.Standard.Model.T_FileListTmp_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.T_FileListTmp_MDL>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0) {
                DigiPower.Onlinecol.Standard.Model.T_FileListTmp_MDL model;
                for (int n = 0; n < rowsCount; n++) {
                    model = new DigiPower.Onlinecol.Standard.Model.T_FileListTmp_MDL();
                    if (dt.Rows[n]["recid"].ToString() != "") {
                        model.recid = int.Parse(dt.Rows[n]["recid"].ToString());
                    }
                    if (dt.Rows[n]["PID"].ToString() != "") {
                        model.PID = int.Parse(dt.Rows[n]["PID"].ToString());
                    }
                    model.archive_form_no = dt.Rows[n]["archive_form_no"].ToString();
                    if (dt.Rows[n]["DefaultCompanyType"].ToString() != "") {
                        model.DefaultCompanyType = int.Parse(dt.Rows[n]["DefaultCompanyType"].ToString());
                    }
                    model.bh = dt.Rows[n]["bh"].ToString();
                    model.title = dt.Rows[n]["title"].ToString();
                    if (dt.Rows[n]["OrderIndex"].ToString() != "") {
                        model.OrderIndex = int.Parse(dt.Rows[n]["OrderIndex"].ToString());
                    }
                    model.pym = dt.Rows[n]["pym"].ToString();
                    if (dt.Rows[n]["MustSubmitFlag"].ToString() != "") {
                        if ((dt.Rows[n]["MustSubmitFlag"].ToString() == "1") || (dt.Rows[n]["MustSubmitFlag"].ToString().ToLower() == "true")) {
                            model.MustSubmitFlag = true;
                        } else {
                            model.MustSubmitFlag = false;
                        }
                    }
                    if (dt.Rows[n]["IsVisible"].ToString() != "") {
                        if ((dt.Rows[n]["IsVisible"].ToString() == "1") || (dt.Rows[n]["IsVisible"].ToString().ToLower() == "true")) {
                            model.IsVisible = true;
                        } else {
                            model.IsVisible = false;
                        }
                    }
                    if (dt.Rows[n]["AlonePack"].ToString() != "") {
                        if ((dt.Rows[n]["AlonePack"].ToString() == "1") || (dt.Rows[n]["AlonePack"].ToString().ToLower() == "true")) {
                            model.AlonePack = true;
                        } else {
                            model.AlonePack = false;
                        }
                    }
                    if (dt.Rows[n]["IsFolder"].ToString() != "") {
                        if ((dt.Rows[n]["IsFolder"].ToString() == "1") || (dt.Rows[n]["IsFolder"].ToString().ToLower() == "true")) {
                            model.IsFolder = true;
                        } else {
                            model.IsFolder = false;
                        }
                    }
                    model.JS = dt.Rows[n]["JS"].ToString();
                    model.SG = dt.Rows[n]["SG"].ToString();
                    model.SJ = dt.Rows[n]["SJ"].ToString();
                    model.JL = dt.Rows[n]["JL"].ToString();
                    model.FileType = dt.Rows[n]["FileType"].ToString();
                    model.ForeignNo = dt.Rows[n]["ForeignNo"].ToString();
                    model.FileFrom = dt.Rows[n]["FileFrom"].ToString();

                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList() {
            return GetList("");
        }

        #endregion  成员方法

        public int GetCountByFileType(int fileType) {
            return dal.GetCountByFileType(fileType);
        }

        public int GetCount(string strWhere) {
            return dal.GetCount(strWhere);
        }

        /// <summary>
        /// 获得数据列表 分页
        /// </summary>
        /// <returns></returns>
        public DataTable GetListPaging(string strWhere, int PageSize, int curPage, out int recCoun) {
            return dal.GetList(strWhere, PageSize, curPage, "RECID", "BH ASC", out recCoun);
        }

        /// <summary>
        /// 获取归档目录模板下所有PID=0 的文件,过滤重复的
        /// </summary>
        /// <returns></returns>
        public DataTable getAllFileListTmpBH() {
            return dal.getAllFileListTmpBH();
        }
    }
}

