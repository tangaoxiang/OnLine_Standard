using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
namespace DigiPower.Onlinecol.Standard.BLL
{
	/// <summary>
	/// ҵ���߼���T_CompanyArchiveUser_BLL ��ժҪ˵����
	/// </summary>
	public class T_CompanyArchiveUser_BLL
	{
		private readonly DigiPower.Onlinecol.Standard.DAL.T_CompanyArchiveUser_DAL dal=new DigiPower.Onlinecol.Standard.DAL.T_CompanyArchiveUser_DAL();
		public T_CompanyArchiveUser_BLL()
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
		public bool Exists(int CompanyArchiveUserID)
		{
			return dal.Exists(CompanyArchiveUserID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(DigiPower.Onlinecol.Standard.Model.T_CompanyArchiveUser_MDL model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(DigiPower.Onlinecol.Standard.Model.T_CompanyArchiveUser_MDL model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int CompanyArchiveUserID)
		{
			
			dal.Delete(CompanyArchiveUserID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_CompanyArchiveUser_MDL GetModel(int CompanyArchiveUserID)
		{
			
			return dal.GetModel(CompanyArchiveUserID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_CompanyArchiveUser_MDL GetModelByCache(int CompanyArchiveUserID)
		{
			
			string CacheKey = "T_CompanyArchiveUser_MDLModel-" + CompanyArchiveUserID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(CompanyArchiveUserID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (DigiPower.Onlinecol.Standard.Model.T_CompanyArchiveUser_MDL)objModel;
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
		public List<DigiPower.Onlinecol.Standard.Model.T_CompanyArchiveUser_MDL> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<DigiPower.Onlinecol.Standard.Model.T_CompanyArchiveUser_MDL> DataTableToList(DataTable dt)
		{
			List<DigiPower.Onlinecol.Standard.Model.T_CompanyArchiveUser_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.T_CompanyArchiveUser_MDL>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DigiPower.Onlinecol.Standard.Model.T_CompanyArchiveUser_MDL model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new DigiPower.Onlinecol.Standard.Model.T_CompanyArchiveUser_MDL();
					if(dt.Rows[n]["CompanyArchiveUserID"].ToString()!="")
					{
						model.CompanyArchiveUserID=int.Parse(dt.Rows[n]["CompanyArchiveUserID"].ToString());
					}
					if(dt.Rows[n]["CompanyID"].ToString()!="")
					{
						model.CompanyID=int.Parse(dt.Rows[n]["CompanyID"].ToString());
					}
					model.ArchiveUserCode=dt.Rows[n]["ArchiveUserCode"].ToString();
					model.UserName=dt.Rows[n]["UserName"].ToString();
					model.Sex=dt.Rows[n]["Sex"].ToString();
					if(dt.Rows[n]["Birthday"].ToString()!="")
					{
						model.Birthday=DateTime.Parse(dt.Rows[n]["Birthday"].ToString());
					}
					model.Educate=dt.Rows[n]["Educate"].ToString();
					model.Tel=dt.Rows[n]["Tel"].ToString();
					model.Email=dt.Rows[n]["Email"].ToString();
					model.QQ=dt.Rows[n]["QQ"].ToString();
					if(dt.Rows[n]["TrainCount"].ToString()!="")
					{
						model.TrainCount=int.Parse(dt.Rows[n]["TrainCount"].ToString());
					}
					if(dt.Rows[n]["RegDate"].ToString()!="")
					{
						model.RegDate=DateTime.Parse(dt.Rows[n]["RegDate"].ToString());
					}
					if(dt.Rows[n]["RegFlag"].ToString()!="")
					{
						if((dt.Rows[n]["RegFlag"].ToString()=="1")||(dt.Rows[n]["RegFlag"].ToString().ToLower()=="true"))
						{
						model.RegFlag=true;
						}
						else
						{
							model.RegFlag=false;
						}
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

