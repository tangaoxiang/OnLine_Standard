using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
namespace DigiPower.Onlinecol.Standard.BLL
{
	/// <summary>
	/// 业务逻辑类T_DefineReult_BLL 的摘要说明。
	/// </summary>
	public class T_DefineReult_BLL
	{
		private readonly DigiPower.Onlinecol.Standard.DAL.T_DefineReult_DAL dal=new DigiPower.Onlinecol.Standard.DAL.T_DefineReult_DAL();
		public T_DefineReult_BLL()
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
		public bool Exists(int DefineResultID)
		{
			return dal.Exists(DefineResultID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(DigiPower.Onlinecol.Standard.Model.T_DefineReult_MDL model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(DigiPower.Onlinecol.Standard.Model.T_DefineReult_MDL model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int DefineResultID)
		{
			
			dal.Delete(DefineResultID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_DefineReult_MDL GetModel(int DefineResultID)
		{
			
			return dal.GetModel(DefineResultID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_DefineReult_MDL GetModelByCache(int DefineResultID)
		{
			
			string CacheKey = "T_DefineReult_MDLModel-" + DefineResultID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(DefineResultID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (DigiPower.Onlinecol.Standard.Model.T_DefineReult_MDL)objModel;
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
		public List<DigiPower.Onlinecol.Standard.Model.T_DefineReult_MDL> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DigiPower.Onlinecol.Standard.Model.T_DefineReult_MDL> DataTableToList(DataTable dt)
		{
			List<DigiPower.Onlinecol.Standard.Model.T_DefineReult_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.T_DefineReult_MDL>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DigiPower.Onlinecol.Standard.Model.T_DefineReult_MDL model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new DigiPower.Onlinecol.Standard.Model.T_DefineReult_MDL();
					if(dt.Rows[n]["DefineResultID"].ToString()!="")
					{
						model.DefineResultID=int.Parse(dt.Rows[n]["DefineResultID"].ToString());
					}
					if(dt.Rows[n]["CanDefineTypeID"].ToString()!="")
					{
						model.CanDefineTypeID=int.Parse(dt.Rows[n]["CanDefineTypeID"].ToString());
					}
					if(dt.Rows[n]["OrderIndex"].ToString()!="")
					{
						model.OrderIndex=int.Parse(dt.Rows[n]["OrderIndex"].ToString());
					}
					if(dt.Rows[n]["SplitID"].ToString()!="")
					{
						model.SplitID=int.Parse(dt.Rows[n]["SplitID"].ToString());
					}
					model.FileType_DEL=dt.Rows[n]["FileType_DEL"].ToString();
					if(dt.Rows[n]["CutLength"].ToString()!="")
					{
						model.CutLength=int.Parse(dt.Rows[n]["CutLength"].ToString());
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

