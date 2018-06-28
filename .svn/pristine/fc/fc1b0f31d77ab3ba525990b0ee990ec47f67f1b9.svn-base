using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
namespace DigiPower.Onlinecol.Standard.BLL
{
    /// <summary>
    /// 业务逻辑类T_OperationLog_BLL 的摘要说明。
    /// </summary>
    public class T_OperationLog_BLL
    {
        private readonly DigiPower.Onlinecol.Standard.DAL.T_OperationLog_DAL dal = new DigiPower.Onlinecol.Standard.DAL.T_OperationLog_DAL();
        public T_OperationLog_BLL() { }
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
        public bool Exists(int LogID) {
            return dal.Exists(LogID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_OperationLog_MDL model) {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(DigiPower.Onlinecol.Standard.Model.T_OperationLog_MDL model) {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int LogID) {

            dal.Delete(LogID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_OperationLog_MDL GetModel(int LogID) {

            return dal.GetModel(LogID);
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
        public List<DigiPower.Onlinecol.Standard.Model.T_OperationLog_MDL> GetModelList(string strWhere) {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DigiPower.Onlinecol.Standard.Model.T_OperationLog_MDL> DataTableToList(DataTable dt) {
            List<DigiPower.Onlinecol.Standard.Model.T_OperationLog_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.T_OperationLog_MDL>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0) {
                DigiPower.Onlinecol.Standard.Model.T_OperationLog_MDL model;
                for (int n = 0; n < rowsCount; n++) {
                    model = new DigiPower.Onlinecol.Standard.Model.T_OperationLog_MDL();
                    if (dt.Rows[n]["LogID"].ToString() != "") {
                        model.LogID = int.Parse(dt.Rows[n]["LogID"].ToString());
                    }
                    model.ClassName = dt.Rows[n]["ClassName"].ToString();
                    model.MethodName = dt.Rows[n]["MethodName"].ToString();
                    model.SqlString = dt.Rows[n]["SqlString"].ToString();
                    model.ErrorMsg = dt.Rows[n]["ErrorMsg"].ToString();
                    model.Description = dt.Rows[n]["Description"].ToString();
                    if (dt.Rows[n]["UserID"].ToString() != "") {
                        model.UserID = int.Parse(dt.Rows[n]["UserID"].ToString());
                    }
                    model.UserName = dt.Rows[n]["UserName"].ToString();
                    model.CreateIP = dt.Rows[n]["CreateIP"].ToString();
                    if (dt.Rows[n]["CreateDate"].ToString() != "") {
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
        public DataSet GetAllList() {
            return GetList("");
        }


        #endregion  成员方法

        /// <summary>
        /// 获得数据列表 分页
        /// </summary>
        /// <returns></returns>
        public DataTable GetListPaging(string strWhere, int PageSize, int curPage, out int recCoun) {
            return dal.GetListPaging(strWhere, PageSize, curPage, "LogID", "LogID desc", out recCoun);
        }

        /// <summary>
        /// 删除多条数据
        /// </summary>
        public void DeleteMore(string LogID) {
            dal.DeleteMore(LogID);
        }

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="Description"></param>
        /// <param name="Message"></param>
        public void WriteLog(string title, string message) {
            T_OperationLog_MDL logmdl = new T_OperationLog_MDL();
            logmdl.CreateDate = DateTime.Now;
            logmdl.CreateIP = System.Web.HttpContext.Current.Request.UserHostAddress;
            logmdl.ErrorMsg = message;
            logmdl.Description = title;
            logmdl.UserID = Common.Session.GetSessionInt("UserID");
            logmdl.UserName = Common.Session.GetSession("UserName");
            dal.Add(logmdl);
        }
    }
}

