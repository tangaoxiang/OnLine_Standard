using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
namespace DigiPower.Onlinecol.Standard.BLL
{
	/// <summary>
	/// 业务逻辑类T_QuestionAnswer_BLL 的摘要说明。
	/// </summary>
	public class T_QuestionAnswer_BLL
	{
		private readonly DigiPower.Onlinecol.Standard.DAL.T_QuestionAnswer_DAL dal=new DigiPower.Onlinecol.Standard.DAL.T_QuestionAnswer_DAL();
		public T_QuestionAnswer_BLL()
		{}
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
		public bool Exists(int AnswerID)
		{
			return dal.Exists(AnswerID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(DigiPower.Onlinecol.Standard.Model.T_QuestionAnswer_MDL model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(DigiPower.Onlinecol.Standard.Model.T_QuestionAnswer_MDL model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int AnswerID)
		{
			
			dal.Delete(AnswerID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_QuestionAnswer_MDL GetModel(int AnswerID)
		{
			
			return dal.GetModel(AnswerID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_QuestionAnswer_MDL GetModelByCache(int AnswerID)
		{
			
			string CacheKey = "T_QuestionAnswer_MDLModel-" + AnswerID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(AnswerID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (DigiPower.Onlinecol.Standard.Model.T_QuestionAnswer_MDL)objModel;
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DigiPower.Onlinecol.Standard.Model.T_QuestionAnswer_MDL> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DigiPower.Onlinecol.Standard.Model.T_QuestionAnswer_MDL> DataTableToList(DataTable dt)
		{
			List<DigiPower.Onlinecol.Standard.Model.T_QuestionAnswer_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.T_QuestionAnswer_MDL>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DigiPower.Onlinecol.Standard.Model.T_QuestionAnswer_MDL model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new DigiPower.Onlinecol.Standard.Model.T_QuestionAnswer_MDL();
					if(dt.Rows[n]["AnswerID"].ToString()!="")
					{
						model.AnswerID=int.Parse(dt.Rows[n]["AnswerID"].ToString());
					}
					if(dt.Rows[n]["QuestionID"].ToString()!="")
					{
						model.QuestionID=int.Parse(dt.Rows[n]["QuestionID"].ToString());
					}
					model.Description=dt.Rows[n]["Description"].ToString();
					if(dt.Rows[n]["AnswerUserID"].ToString()!="")
					{
						model.AnswerUserID=int.Parse(dt.Rows[n]["AnswerUserID"].ToString());
					}
					model.AnswerUserName=dt.Rows[n]["AnswerUserName"].ToString();
					if(dt.Rows[n]["AnswerTime"].ToString()!="")
					{
						model.AnswerTime=DateTime.Parse(dt.Rows[n]["AnswerTime"].ToString());
					}
					model.AttachName=dt.Rows[n]["AttachName"].ToString();
					model.AttachPath=dt.Rows[n]["AttachPath"].ToString();
					if(dt.Rows[n]["ReadFlag"].ToString()!="")
					{
						if((dt.Rows[n]["ReadFlag"].ToString()=="1")||(dt.Rows[n]["ReadFlag"].ToString().ToLower()=="true"))
						{
						model.ReadFlag=true;
						}
						else
						{
							model.ReadFlag=false;
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
	}
}

