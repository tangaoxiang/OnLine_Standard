using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
namespace DigiPower.Onlinecol.Standard.BLL
{
	/// <summary>
	/// 业务逻辑类T_Field_BLL 的摘要说明。
	/// </summary>
	public class T_Field_BLL
	{
		private readonly DigiPower.Onlinecol.Standard.DAL.T_Field_DAL dal=new DigiPower.Onlinecol.Standard.DAL.T_Field_DAL();
		public T_Field_BLL()
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
		public bool Exists(int FieldID)
		{
			return dal.Exists(FieldID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(DigiPower.Onlinecol.Standard.Model.T_Field_MDL model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(DigiPower.Onlinecol.Standard.Model.T_Field_MDL model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int FieldID)
		{
			
			dal.Delete(FieldID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_Field_MDL GetModel(int FieldID)
		{
			
			return dal.GetModel(FieldID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_Field_MDL GetModelByCache(int FieldID)
		{
			
			string CacheKey = "T_Field_MDLModel-" + FieldID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(FieldID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (DigiPower.Onlinecol.Standard.Model.T_Field_MDL)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        /// <summary>
        /// 获得数据列表 分页
        /// </summary>
        /// <returns></returns>
        public DataTable GetListPaging(string strWhere, int PageSize, int curPage, out int recCoun)
        {
            return dal.GetList(strWhere, PageSize, curPage, "FieldID", "FieldID asc", out recCoun);
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
		public List<DigiPower.Onlinecol.Standard.Model.T_Field_MDL> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DigiPower.Onlinecol.Standard.Model.T_Field_MDL> DataTableToList(DataTable dt)
		{
			List<DigiPower.Onlinecol.Standard.Model.T_Field_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.T_Field_MDL>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DigiPower.Onlinecol.Standard.Model.T_Field_MDL model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new DigiPower.Onlinecol.Standard.Model.T_Field_MDL();
					if(dt.Rows[n]["FieldID"].ToString()!="")
					{
						model.FieldID=int.Parse(dt.Rows[n]["FieldID"].ToString());
					}
					model.table_name=dt.Rows[n]["table_name"].ToString();
					model.table_chn_name=dt.Rows[n]["table_chn_name"].ToString();
					model.column_name=dt.Rows[n]["column_name"].ToString();
					model.column_chn_name=dt.Rows[n]["column_chn_name"].ToString();
					if(dt.Rows[n]["column_order"].ToString()!="")
					{
						model.column_order=int.Parse(dt.Rows[n]["column_order"].ToString());
					}
					model.note=dt.Rows[n]["note"].ToString();
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

        public string GetCNFieldNameByFieldName(string TableName, string FieldName)
        {
            string CN = dal.GetCNFieldNameByFieldName(TableName, FieldName);
            if (CN == "")
            {
                CN = FieldName;
            }
            return CN;
        }
	}
}

