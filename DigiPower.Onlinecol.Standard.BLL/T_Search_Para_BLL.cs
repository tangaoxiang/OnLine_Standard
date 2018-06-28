using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
namespace DigiPower.Onlinecol.Standard.BLL
{
	/// <summary>
	/// ҵ���߼���T_Search_Para_BLL ��ժҪ˵����
	/// </summary>
	public class T_Search_Para_BLL
	{
        private readonly DigiPower.Onlinecol.Standard.DAL.T_Search_Para_DAL dal = new DigiPower.Onlinecol.Standard.DAL.T_Search_Para_DAL();
		public T_Search_Para_BLL()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int Search_Para_ID)
		{
			return dal.Exists(Search_Para_ID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(DigiPower.Onlinecol.Standard.Model.T_Search_Para_MDL model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(DigiPower.Onlinecol.Standard.Model.T_Search_Para_MDL model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int Search_Para_ID)
		{
			
			dal.Delete(Search_Para_ID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_Search_Para_MDL GetModel(int Search_Para_ID)
		{
			
			return dal.GetModel(Search_Para_ID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_Search_Para_MDL GetModelByCache(int Search_Para_ID)
		{
			
			string CacheKey = "T_Search_Para_MDLModel-" + Search_Para_ID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Search_Para_ID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (DigiPower.Onlinecol.Standard.Model.T_Search_Para_MDL)objModel;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<DigiPower.Onlinecol.Standard.Model.T_Search_Para_MDL> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<DigiPower.Onlinecol.Standard.Model.T_Search_Para_MDL> DataTableToList(DataTable dt)
		{
			List<DigiPower.Onlinecol.Standard.Model.T_Search_Para_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.T_Search_Para_MDL>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DigiPower.Onlinecol.Standard.Model.T_Search_Para_MDL model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new DigiPower.Onlinecol.Standard.Model.T_Search_Para_MDL();
					if(dt.Rows[n]["Search_Para_ID"].ToString()!="")
					{
						model.Search_Para_ID=int.Parse(dt.Rows[n]["Search_Para_ID"].ToString());
					}
					if(dt.Rows[n]["Search_Field_ID"].ToString()!="")
					{
						model.Search_Field_ID=int.Parse(dt.Rows[n]["Search_Field_ID"].ToString());
					}
					model.ParaType=dt.Rows[n]["ParaType"].ToString();
					model.ParaTypeCN=dt.Rows[n]["ParaTypeCN"].ToString();
					if(dt.Rows[n]["ControlWidth"].ToString()!="")
					{
						model.ControlWidth=int.Parse(dt.Rows[n]["ControlWidth"].ToString());
					}
					model.CompareType=dt.Rows[n]["CompareType"].ToString();
					model.CompareTypeCN=dt.Rows[n]["CompareTypeCN"].ToString();
					model.DefaultValue=dt.Rows[n]["DefaultValue"].ToString();
					model.SourceSql=dt.Rows[n]["SourceSql"].ToString();
					if(dt.Rows[n]["OrderId"].ToString()!="")
					{
						model.OrderId=int.Parse(dt.Rows[n]["OrderId"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  ��Ա����
	}
}

