using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
namespace DigiPower.Onlinecol.Standard.BLL
{
	/// <summary>
	/// 业务逻辑类s_archive_type_BLL 的摘要说明。
	/// </summary>
	public class s_archive_type_BLL
	{
		private readonly DigiPower.Onlinecol.Standard.DAL.s_archive_type_DAL dal=new DigiPower.Onlinecol.Standard.DAL.s_archive_type_DAL();
		public s_archive_type_BLL()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string archive_type_no)
		{
			return dal.Exists(archive_type_no);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(DigiPower.Onlinecol.Standard.Model.s_archive_type_MDL model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(DigiPower.Onlinecol.Standard.Model.s_archive_type_MDL model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string archive_type_no)
		{
			
			dal.Delete(archive_type_no);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.s_archive_type_MDL GetModel(string archive_type_no)
		{
			
			return dal.GetModel(archive_type_no);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.s_archive_type_MDL GetModelByCache(string archive_type_no)
		{
			
			string CacheKey = "s_archive_type_MDLModel-" + archive_type_no;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(archive_type_no);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (DigiPower.Onlinecol.Standard.Model.s_archive_type_MDL)objModel;
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
		public List<DigiPower.Onlinecol.Standard.Model.s_archive_type_MDL> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DigiPower.Onlinecol.Standard.Model.s_archive_type_MDL> DataTableToList(DataTable dt)
		{
			List<DigiPower.Onlinecol.Standard.Model.s_archive_type_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.s_archive_type_MDL>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DigiPower.Onlinecol.Standard.Model.s_archive_type_MDL model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new DigiPower.Onlinecol.Standard.Model.s_archive_type_MDL();
					model.archive_type_no=dt.Rows[n]["archive_type_no"].ToString();
					model.archive_type_name=dt.Rows[n]["archive_type_name"].ToString();
					model.description=dt.Rows[n]["description"].ToString();
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

