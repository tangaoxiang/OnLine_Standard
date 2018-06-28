using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
namespace DigiPower.Onlinecol.Standard.BLL
{
	/// <summary>
	/// 业务逻辑类T_FileList_CellRpt_BLL 的摘要说明。
	/// </summary>
	public class T_FileList_CellRpt_BLL
	{
		private readonly DigiPower.Onlinecol.Standard.DAL.T_FileList_CellRpt_DAL dal=new DigiPower.Onlinecol.Standard.DAL.T_FileList_CellRpt_DAL();
		public T_FileList_CellRpt_BLL()
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
		public bool Exists(int FileList_CellRptID)
		{
			return dal.Exists(FileList_CellRptID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(DigiPower.Onlinecol.Standard.Model.T_FileList_CellRpt_MDL model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(DigiPower.Onlinecol.Standard.Model.T_FileList_CellRpt_MDL model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int FileList_CellRptID)
		{
			
			dal.Delete(FileList_CellRptID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_FileList_CellRpt_MDL GetModel(int FileList_CellRptID)
		{
			
			return dal.GetModel(FileList_CellRptID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_FileList_CellRpt_MDL GetModelByCache(int FileList_CellRptID)
		{
			
			string CacheKey = "T_FileList_CellRpt_MDLModel-" + FileList_CellRptID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(FileList_CellRptID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (DigiPower.Onlinecol.Standard.Model.T_FileList_CellRpt_MDL)objModel;
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
		public List<DigiPower.Onlinecol.Standard.Model.T_FileList_CellRpt_MDL> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DigiPower.Onlinecol.Standard.Model.T_FileList_CellRpt_MDL> DataTableToList(DataTable dt)
		{
			List<DigiPower.Onlinecol.Standard.Model.T_FileList_CellRpt_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.T_FileList_CellRpt_MDL>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DigiPower.Onlinecol.Standard.Model.T_FileList_CellRpt_MDL model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new DigiPower.Onlinecol.Standard.Model.T_FileList_CellRpt_MDL();
					if(dt.Rows[n]["FileList_CellRptID"].ToString()!="")
					{
						model.FileList_CellRptID=int.Parse(dt.Rows[n]["FileList_CellRptID"].ToString());
					}
					if(dt.Rows[n]["FileListID"].ToString()!="")
					{
						model.FileListID=int.Parse(dt.Rows[n]["FileListID"].ToString());
					}
					if(dt.Rows[n]["recID"].ToString()!="")
					{
						model.recID=int.Parse(dt.Rows[n]["recID"].ToString());
					}
					model.Title=dt.Rows[n]["Title"].ToString();
					model.CellFilePath=dt.Rows[n]["CellFilePath"].ToString();
					if(dt.Rows[n]["OrderIndex"].ToString()!="")
					{
						model.OrderIndex=int.Parse(dt.Rows[n]["OrderIndex"].ToString());
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

