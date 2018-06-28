using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
namespace DigiPower.Onlinecol.Standard.BLL
{
	/// <summary>
	/// ҵ���߼���T_Right_BLL ��ժҪ˵����
	/// </summary>
	public class T_Right_BLL
	{
		private readonly DigiPower.Onlinecol.Standard.DAL.T_Right_DAL dal=new DigiPower.Onlinecol.Standard.DAL.T_Right_DAL();
		public T_Right_BLL()
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
		public bool Exists(int RightID)
		{
			return dal.Exists(RightID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(DigiPower.Onlinecol.Standard.Model.T_Right_MDL model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(DigiPower.Onlinecol.Standard.Model.T_Right_MDL model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int RightID)
		{
			
			dal.Delete(RightID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_Right_MDL GetModel(int RightID)
		{
			
			return dal.GetModel(RightID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_Right_MDL GetModelByCache(int RightID)
		{
			
			string CacheKey = "T_Right_MDLModel-" + RightID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(RightID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (DigiPower.Onlinecol.Standard.Model.T_Right_MDL)objModel;
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
		public List<DigiPower.Onlinecol.Standard.Model.T_Right_MDL> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<DigiPower.Onlinecol.Standard.Model.T_Right_MDL> DataTableToList(DataTable dt)
		{
			List<DigiPower.Onlinecol.Standard.Model.T_Right_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.T_Right_MDL>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DigiPower.Onlinecol.Standard.Model.T_Right_MDL model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new DigiPower.Onlinecol.Standard.Model.T_Right_MDL();
					if(dt.Rows[n]["RightID"].ToString()!="")
					{
						model.RightID=int.Parse(dt.Rows[n]["RightID"].ToString());
					}
					model.RightCode=dt.Rows[n]["RightCode"].ToString();
					model.RightName=dt.Rows[n]["RightName"].ToString();
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

