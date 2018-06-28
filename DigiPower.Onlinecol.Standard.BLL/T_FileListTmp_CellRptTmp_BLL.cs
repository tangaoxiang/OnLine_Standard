using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
namespace DigiPower.Onlinecol.Standard.BLL
{
	/// <summary>
	/// ҵ���߼���T_FileListTmp_CellRptTmp_BLL ��ժҪ˵����
	/// </summary>
	public class T_FileListTmp_CellRptTmp_BLL
	{
		private readonly DigiPower.Onlinecol.Standard.DAL.T_FileListTmp_CellRptTmp_DAL dal=new DigiPower.Onlinecol.Standard.DAL.T_FileListTmp_CellRptTmp_DAL();
		public T_FileListTmp_CellRptTmp_BLL()
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
		public bool Exists(int CellReportID)
		{
			return dal.Exists(CellReportID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(DigiPower.Onlinecol.Standard.Model.T_FileListTmp_CellRptTmp_MDL model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(DigiPower.Onlinecol.Standard.Model.T_FileListTmp_CellRptTmp_MDL model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int CellReportID)
		{
			
			dal.Delete(CellReportID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_FileListTmp_CellRptTmp_MDL GetModel(int CellReportID)
		{
			
			return dal.GetModel(CellReportID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_FileListTmp_CellRptTmp_MDL GetModelByCache(int CellReportID)
		{
			
			string CacheKey = "T_FileListTmp_CellRptTmp_MDLModel-" + CellReportID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(CellReportID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (DigiPower.Onlinecol.Standard.Model.T_FileListTmp_CellRptTmp_MDL)objModel;
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
		public List<DigiPower.Onlinecol.Standard.Model.T_FileListTmp_CellRptTmp_MDL> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<DigiPower.Onlinecol.Standard.Model.T_FileListTmp_CellRptTmp_MDL> DataTableToList(DataTable dt)
		{
			List<DigiPower.Onlinecol.Standard.Model.T_FileListTmp_CellRptTmp_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.T_FileListTmp_CellRptTmp_MDL>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DigiPower.Onlinecol.Standard.Model.T_FileListTmp_CellRptTmp_MDL model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new DigiPower.Onlinecol.Standard.Model.T_FileListTmp_CellRptTmp_MDL();
					if(dt.Rows[n]["CellReportID"].ToString()!="")
					{
						model.CellReportID=int.Parse(dt.Rows[n]["CellReportID"].ToString());
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

        public bool Exists(string sqlWhere)
        {
            return dal.Exists(sqlWhere);
        }
	}
}

