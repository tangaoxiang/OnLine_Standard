using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
using System.Collections;
namespace DigiPower.Onlinecol.Standard.BLL {
    /// <summary>
    /// 业务逻辑类T_ReadyCheckBook_BLL 的摘要说明。
    /// </summary>
    public class T_ReadyCheckBook_BLL {
        private readonly DigiPower.Onlinecol.Standard.DAL.T_ReadyCheckBook_DAL dal = new DigiPower.Onlinecol.Standard.DAL.T_ReadyCheckBook_DAL();
        public T_ReadyCheckBook_BLL() { }
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
        public bool Exists(int ReadyCheckBookID) {
            return dal.Exists(ReadyCheckBookID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_ReadyCheckBook_MDL model) {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(DigiPower.Onlinecol.Standard.Model.T_ReadyCheckBook_MDL model) {
            dal.Update(model);
        }
        public void UpdateQpNote(int SingleProjectID) {
            dal.UpdateQpNote(SingleProjectID);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ReadyCheckBookID) {

            dal.Delete(ReadyCheckBookID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_ReadyCheckBook_MDL GetModel(int ReadyCheckBookID) {

            return dal.GetModel(ReadyCheckBookID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_ReadyCheckBook_MDL GetModelByCache(int ReadyCheckBookID) {

            string CacheKey = "T_ReadyCheckBook_MDLModel-" + ReadyCheckBookID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null) {
                try {
                    objModel = dal.GetModel(ReadyCheckBookID);
                    if (objModel != null) {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                } catch { }
            }
            return (DigiPower.Onlinecol.Standard.Model.T_ReadyCheckBook_MDL)objModel;
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
        public List<DigiPower.Onlinecol.Standard.Model.T_ReadyCheckBook_MDL> GetModelList(string strWhere) {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DigiPower.Onlinecol.Standard.Model.T_ReadyCheckBook_MDL> DataTableToList(DataTable dt) {
            List<DigiPower.Onlinecol.Standard.Model.T_ReadyCheckBook_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.T_ReadyCheckBook_MDL>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0) {
                DigiPower.Onlinecol.Standard.Model.T_ReadyCheckBook_MDL model;
                for (int n = 0; n < rowsCount; n++) {
                    model = new DigiPower.Onlinecol.Standard.Model.T_ReadyCheckBook_MDL();
                    if (dt.Rows[n]["ReadyCheckBookID"].ToString() != "") {
                        model.ReadyCheckBookID = int.Parse(dt.Rows[n]["ReadyCheckBookID"].ToString());
                    }
                    if (dt.Rows[n]["SingleProjectID"].ToString() != "") {
                        model.SingleProjectID = int.Parse(dt.Rows[n]["SingleProjectID"].ToString());
                    }
                    model.CodeType = dt.Rows[n]["CodeType"].ToString();
                    model.ReadyCheckBookCode = dt.Rows[n]["ReadyCheckBookCode"].ToString();
                    if (dt.Rows[n]["BeginDate"].ToString() != "") {
                        model.BeginDate = DateTime.Parse(dt.Rows[n]["BeginDate"].ToString());
                    }
                    if (dt.Rows[n]["EndDate"].ToString() != "") {
                        model.EndDate = DateTime.Parse(dt.Rows[n]["EndDate"].ToString());
                    }
                    if (dt.Rows[n]["CreateUserID"].ToString() != "") {
                        model.CreateUserID = int.Parse(dt.Rows[n]["CreateUserID"].ToString());
                    }
                    if (dt.Rows[n]["CreateTime"].ToString() != "") {
                        model.CreateTime = DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
                    }



                    if (dt.Rows[n]["TOTAL_SCROLL"].ToString() != "") {
                        model.TOTAL_SCROLL = int.Parse(dt.Rows[n]["TOTAL_SCROLL"].ToString());
                    }
                    if (dt.Rows[n]["CHARACTER_SCROLL"].ToString() != "") {
                        model.CHARACTER_SCROLL = int.Parse(dt.Rows[n]["CHARACTER_SCROLL"].ToString());
                    }
                    if (dt.Rows[n]["PIC_SCROLL"].ToString() != "") {
                        model.PIC_SCROLL = int.Parse(dt.Rows[n]["PIC_SCROLL"].ToString());
                    }
                    if (dt.Rows[n]["PIC_PAGE_COUNT"].ToString() != "") {
                        model.PIC_PAGE_COUNT = int.Parse(dt.Rows[n]["PIC_PAGE_COUNT"].ToString());
                    }
                    if (dt.Rows[n]["PHOTO_COUNT"].ToString() != "") {
                        model.PHOTO_COUNT = int.Parse(dt.Rows[n]["PHOTO_COUNT"].ToString());
                    }
                    if (dt.Rows[n]["RADIO_COUNT"].ToString() != "") {
                        model.RADIO_COUNT = int.Parse(dt.Rows[n]["RADIO_COUNT"].ToString());
                    }

                    model.OTHER_MATERIAL = dt.Rows[n]["OTHER_MATERIAL"].ToString();

                    if (dt.Rows[n]["Directory_SCROLL"].ToString() != "") {
                        model.Directory_SCROLL = int.Parse(dt.Rows[n]["Directory_SCROLL"].ToString());
                    }
                    if (dt.Rows[n]["Directory_PAGE_COUNT"].ToString() != "") {
                        model.Directory_PAGE_COUNT = int.Parse(dt.Rows[n]["Directory_PAGE_COUNT"].ToString());
                    }


                    if (dt.Rows[n]["zljddw"].ToString() != "") {
                        model.zljddw = dt.Rows[n]["zljddw"].ToString();
                    }
                    if (dt.Rows[n]["ArchiveUserName"].ToString() != "") {
                        model.ArchiveUserName = dt.Rows[n]["ArchiveUserName"].ToString();
                    }
                    if (dt.Rows[n]["ArchiveUser_Tel"].ToString() != "") {
                        model.ArchiveUser_Tel = dt.Rows[n]["ArchiveUser_Tel"].ToString();
                    }
                    if (dt.Rows[n]["jsdwfzr_Name"].ToString() != "") {
                        model.jsdwfzr_Name = dt.Rows[n]["jsdwfzr_Name"].ToString();
                    }
                    if (dt.Rows[n]["jsdwfzr_Tel"].ToString() != "") {
                        model.jsdwfzr_Tel = dt.Rows[n]["jsdwfzr_Tel"].ToString();
                    }
                    if (dt.Rows[n]["cscd"].ToString() != "") {
                        model.cscd = dt.Rows[n]["cscd"].ToString();
                    }
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

        /// <summary>
        /// 获得数据列表 分页
        /// </summary>
        /// <returns></returns>
        public DataTable GetListPaging(Hashtable ht, int PageSize, int curPage, out int recCoun) {
            return dal.GetListPaging(ht, PageSize, curPage, "keySingleProjectID", "keySingleProjectID desc", out recCoun);
        }

        public string GetListPagingForQueryWhere(Hashtable ht) {
            return dal.GetListPagingForQueryWhere(ht);
        }

        /// <summary>
        /// 获得数据列表 分页
        /// </summary>
        /// <returns></returns>
        public DataTable GetListPaging(string strWhere, params object[] obj) {
            return dal.GetListPaging(strWhere, obj);
        }
    }
}

