using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
namespace DigiPower.Onlinecol.Standard.BLL
{
	/// <summary>
	/// 业务逻辑类T_CellTmp_BLL 的摘要说明。
	/// </summary>
	public class T_CellTmp_BLL
	{
		private readonly DigiPower.Onlinecol.Standard.DAL.T_CellTmp_DAL dal=new DigiPower.Onlinecol.Standard.DAL.T_CellTmp_DAL();
		public T_CellTmp_BLL()
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
		public bool Exists(int CellID)
		{
			return dal.Exists(CellID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(DigiPower.Onlinecol.Standard.Model.T_CellTmp_MDL model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(DigiPower.Onlinecol.Standard.Model.T_CellTmp_MDL model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int CellID)
		{
			
			dal.Delete(CellID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_CellTmp_MDL GetModel(int CellID)
		{
			
			return dal.GetModel(CellID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_CellTmp_MDL GetModelByCache(int CellID)
		{
			
			string CacheKey = "T_CellTmp_MDLModel-" + CellID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(CellID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (DigiPower.Onlinecol.Standard.Model.T_CellTmp_MDL)objModel;
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
		public List<DigiPower.Onlinecol.Standard.Model.T_CellTmp_MDL> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DigiPower.Onlinecol.Standard.Model.T_CellTmp_MDL> DataTableToList(DataTable dt)
		{
			List<DigiPower.Onlinecol.Standard.Model.T_CellTmp_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.T_CellTmp_MDL>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DigiPower.Onlinecol.Standard.Model.T_CellTmp_MDL model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new DigiPower.Onlinecol.Standard.Model.T_CellTmp_MDL();
					if(dt.Rows[n]["CellID"].ToString()!="")
					{
						model.CellID=int.Parse(dt.Rows[n]["CellID"].ToString());
					}
					if(dt.Rows[n]["PID"].ToString()!="")
					{
						model.PID=int.Parse(dt.Rows[n]["PID"].ToString());
					}
					model.Title=dt.Rows[n]["Title"].ToString();
					model.FilePath=dt.Rows[n]["FilePath"].ToString();
					if(dt.Rows[n]["OrderIndex"].ToString()!="")
					{
						model.OrderIndex=int.Parse(dt.Rows[n]["OrderIndex"].ToString());
					}
					model.JSDWExpire=dt.Rows[n]["JSDWExpire"].ToString();
					model.SGDWExpire=dt.Rows[n]["SGDWExpire"].ToString();
					model.SJDWExpire=dt.Rows[n]["SJDWExpire"].ToString();
					model.JLDWExpire=dt.Rows[n]["JLDWExpire"].ToString();
					if(dt.Rows[n]["NeedArchive"].ToString()!="")
					{
						if((dt.Rows[n]["NeedArchive"].ToString()=="1")||(dt.Rows[n]["NeedArchive"].ToString().ToLower()=="true"))
						{
						model.NeedArchive=true;
						}
						else
						{
							model.NeedArchive=false;
						}
					}
					model.MJ=dt.Rows[n]["MJ"].ToString();
					if(dt.Rows[n]["IsVisible"].ToString()!="")
					{
						if((dt.Rows[n]["IsVisible"].ToString()=="1")||(dt.Rows[n]["IsVisible"].ToString().ToLower()=="true"))
						{
						model.IsVisible=true;
						}
						else
						{
							model.IsVisible=false;
						}
					}
					if(dt.Rows[n]["IsFolder"].ToString()!="")
					{
						if((dt.Rows[n]["IsFolder"].ToString()=="1")||(dt.Rows[n]["IsFolder"].ToString().ToLower()=="true"))
						{
						model.IsFolder=true;
						}
						else
						{
							model.IsFolder=false;
						}
					}
					model.MyCode=dt.Rows[n]["MyCode"].ToString();
					model.PID1=dt.Rows[n]["PID1"].ToString();
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

