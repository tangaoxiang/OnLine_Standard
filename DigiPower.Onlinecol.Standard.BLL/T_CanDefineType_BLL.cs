using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
namespace DigiPower.Onlinecol.Standard.BLL
{
	/// <summary>
	/// 业务逻辑类T_CanDefineType_BLL 的摘要说明。
	/// </summary>
	public class T_CanDefineType_BLL
	{
		private readonly DigiPower.Onlinecol.Standard.DAL.T_CanDefineType_DAL dal=new DigiPower.Onlinecol.Standard.DAL.T_CanDefineType_DAL();
		public T_CanDefineType_BLL()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CanDefineTypeID)
		{
			return dal.Exists(CanDefineTypeID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(DigiPower.Onlinecol.Standard.Model.T_CanDefineType_MDL model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(DigiPower.Onlinecol.Standard.Model.T_CanDefineType_MDL model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int CanDefineTypeID)
		{
			
			dal.Delete(CanDefineTypeID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_CanDefineType_MDL GetModel(int CanDefineTypeID)
		{
			
			return dal.GetModel(CanDefineTypeID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_CanDefineType_MDL GetModelByCache(int CanDefineTypeID)
		{
			
			string CacheKey = "T_CanDefineType_MDLModel-" + CanDefineTypeID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(CanDefineTypeID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (DigiPower.Onlinecol.Standard.Model.T_CanDefineType_MDL)objModel;
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
		public List<DigiPower.Onlinecol.Standard.Model.T_CanDefineType_MDL> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DigiPower.Onlinecol.Standard.Model.T_CanDefineType_MDL> DataTableToList(DataTable dt)
		{
			List<DigiPower.Onlinecol.Standard.Model.T_CanDefineType_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.T_CanDefineType_MDL>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DigiPower.Onlinecol.Standard.Model.T_CanDefineType_MDL model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new DigiPower.Onlinecol.Standard.Model.T_CanDefineType_MDL();
					if(dt.Rows[n]["CanDefineTypeID"].ToString()!="")
					{
						model.CanDefineTypeID=int.Parse(dt.Rows[n]["CanDefineTypeID"].ToString());
					}
					model.Area_Code=dt.Rows[n]["Area_Code"].ToString();
					if(dt.Rows[n]["MediaTypeID"].ToString()!="")
					{
						model.MediaTypeID=int.Parse(dt.Rows[n]["MediaTypeID"].ToString());
					}
					if(dt.Rows[n]["DefineTypeID"].ToString()!="")
					{
						model.DefineTypeID=int.Parse(dt.Rows[n]["DefineTypeID"].ToString());
					}
					if(dt.Rows[n]["FieldDefineID"].ToString()!="")
					{
						model.FieldDefineID=int.Parse(dt.Rows[n]["FieldDefineID"].ToString());
					}
					if(dt.Rows[n]["Enable"].ToString()!="")
					{
						if((dt.Rows[n]["Enable"].ToString()=="1")||(dt.Rows[n]["Enable"].ToString().ToLower()=="true"))
						{
						model.Enable=true;
						}
						else
						{
							model.Enable=false;
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

