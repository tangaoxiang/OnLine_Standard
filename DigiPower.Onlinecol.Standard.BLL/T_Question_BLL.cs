using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
namespace DigiPower.Onlinecol.Standard.BLL
{
    /// <summary>
    /// 业务逻辑类T_Question_BLL 的摘要说明。
    /// </summary>
    public class T_Question_BLL
    {
        private readonly DigiPower.Onlinecol.Standard.DAL.T_Question_DAL dal = new DigiPower.Onlinecol.Standard.DAL.T_Question_DAL();
        public T_Question_BLL()
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
        public bool Exists(int QuestionID)
        {
            return dal.Exists(QuestionID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_Question_MDL model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(DigiPower.Onlinecol.Standard.Model.T_Question_MDL model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int QuestionID)
        {

            dal.Delete(QuestionID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_Question_MDL GetModel(int QuestionID)
        {

            return dal.GetModel(QuestionID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_Question_MDL GetModelByCache(int QuestionID)
        {

            string CacheKey = "T_Question_MDLModel-" + QuestionID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(QuestionID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (DigiPower.Onlinecol.Standard.Model.T_Question_MDL)objModel;
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
        public List<DigiPower.Onlinecol.Standard.Model.T_Question_MDL> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DigiPower.Onlinecol.Standard.Model.T_Question_MDL> DataTableToList(DataTable dt)
        {
            List<DigiPower.Onlinecol.Standard.Model.T_Question_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.T_Question_MDL>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DigiPower.Onlinecol.Standard.Model.T_Question_MDL model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new DigiPower.Onlinecol.Standard.Model.T_Question_MDL();
                    if (dt.Rows[n]["QuestionID"].ToString() != "")
                    {
                        model.QuestionID = int.Parse(dt.Rows[n]["QuestionID"].ToString());
                    }
                    if (dt.Rows[n]["SingleProjectID"].ToString() != "")
                    {
                        model.SingleProjectID = int.Parse(dt.Rows[n]["SingleProjectID"].ToString());
                    }
             
                    if (dt.Rows[n]["FileListID"].ToString() != "")
                    {
                        model.FileListID = int.Parse(dt.Rows[n]["FileListID"].ToString());
                    }
                    model.QuestionTypeCode = dt.Rows[n]["QuestionTypeCode"].ToString();
                    model.Title = dt.Rows[n]["Title"].ToString();
                    model.Description = dt.Rows[n]["Description"].ToString();
                    if (dt.Rows[n]["CreateUserID"].ToString() != "")
                    {
                        model.CreateUserID = int.Parse(dt.Rows[n]["CreateUserID"].ToString());
                    }
                    model.CreateUserName = dt.Rows[n]["CreateUserName"].ToString();
                    if (dt.Rows[n]["CreateDate"].ToString() != "")
                    {
                        model.CreateDate = DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
                    }
                    if (dt.Rows[n]["AnswerCount"].ToString() != "")
                    {
                        model.AnswerCount = int.Parse(dt.Rows[n]["AnswerCount"].ToString());
                    }
                    if (dt.Rows[n]["ClickCount"].ToString() != "")
                    {
                        model.ClickCount = int.Parse(dt.Rows[n]["ClickCount"].ToString());
                    }
                    model.AttachName = dt.Rows[n]["AttachName"].ToString();
                    model.AttachPath = dt.Rows[n]["AttachPath"].ToString();
                    if (dt.Rows[n]["ReadFlag"].ToString() != "")
                    {
                        if ((dt.Rows[n]["ReadFlag"].ToString() == "1") || (dt.Rows[n]["ReadFlag"].ToString().ToLower() == "true"))
                        {
                            model.ReadFlag = true;
                        }
                        else
                        {
                            model.ReadFlag = false;
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

        #endregion  成员方法

  
        /// <summary>
        /// 获得数据列表 分页
        /// </summary>
        /// <returns></returns>
        public DataTable GetListPaging(string strWhere, int PageSize, int curPage, out int recCoun)
        {
            return dal.GetQuestionList(strWhere, PageSize, curPage, "QuestionID", "QuestionTypeCode,QuestionID asc", out recCoun);
        }
         
    }
}