using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
namespace DigiPower.Onlinecol.Standard.BLL
{
	/// <summary>
	/// ҵ���߼���T_DefineReult_BLL ��ժҪ˵����
	/// </summary>
	public class T_DefineReult_BLL
	{
		private readonly DigiPower.Onlinecol.Standard.DAL.T_DefineReult_DAL dal=new DigiPower.Onlinecol.Standard.DAL.T_DefineReult_DAL();
		public T_DefineReult_BLL()
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
		public bool Exists(int DefineResultID)
		{
			return dal.Exists(DefineResultID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(DigiPower.Onlinecol.Standard.Model.T_DefineReult_MDL model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(DigiPower.Onlinecol.Standard.Model.T_DefineReult_MDL model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int DefineResultID)
		{
			
			dal.Delete(DefineResultID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_DefineReult_MDL GetModel(int DefineResultID)
		{
			
			return dal.GetModel(DefineResultID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
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
		public List<DigiPower.Onlinecol.Standard.Model.T_DefineReult_MDL> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
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

