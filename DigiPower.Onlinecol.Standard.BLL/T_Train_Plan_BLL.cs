using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
namespace DigiPower.Onlinecol.Standard.BLL
{
	/// <summary>
	/// 业务逻辑类T_Train_Plan_BLL 的摘要说明。
	/// </summary>
	public class T_Train_Plan_BLL
	{
		private readonly DigiPower.Onlinecol.Standard.DAL.T_Train_Plan_DAL dal=new DigiPower.Onlinecol.Standard.DAL.T_Train_Plan_DAL();
		public T_Train_Plan_BLL()
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
		public bool Exists(int TrainPlanID)
		{
			return dal.Exists(TrainPlanID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(DigiPower.Onlinecol.Standard.Model.T_Train_Plan_MDL model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(DigiPower.Onlinecol.Standard.Model.T_Train_Plan_MDL model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int TrainPlanID)
		{
			
			dal.Delete(TrainPlanID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_Train_Plan_MDL GetModel(int TrainPlanID)
		{
			
			return dal.GetModel(TrainPlanID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_Train_Plan_MDL GetModelByCache(int TrainPlanID)
		{
			
			string CacheKey = "T_Train_Plan_MDLModel-" + TrainPlanID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(TrainPlanID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (DigiPower.Onlinecol.Standard.Model.T_Train_Plan_MDL)objModel;
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
		public List<DigiPower.Onlinecol.Standard.Model.T_Train_Plan_MDL> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DigiPower.Onlinecol.Standard.Model.T_Train_Plan_MDL> DataTableToList(DataTable dt)
		{
			List<DigiPower.Onlinecol.Standard.Model.T_Train_Plan_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.T_Train_Plan_MDL>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DigiPower.Onlinecol.Standard.Model.T_Train_Plan_MDL model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new DigiPower.Onlinecol.Standard.Model.T_Train_Plan_MDL();
					if(dt.Rows[n]["TrainPlanID"].ToString()!="")
					{
						model.TrainPlanID=int.Parse(dt.Rows[n]["TrainPlanID"].ToString());
					}
					model.Subject=dt.Rows[n]["Subject"].ToString();
					model.Teacher=dt.Rows[n]["Teacher"].ToString();
					if(dt.Rows[n]["PlanDate"].ToString()!="")
					{
						model.PlanDate=DateTime.Parse(dt.Rows[n]["PlanDate"].ToString());
					}
					if(dt.Rows[n]["FinishDate"].ToString()!="")
					{
						model.FinishDate=DateTime.Parse(dt.Rows[n]["FinishDate"].ToString());
					}
					model.PlanUserName=dt.Rows[n]["PlanUserName"].ToString();
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

