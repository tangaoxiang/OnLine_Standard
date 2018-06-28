using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
namespace DigiPower.Onlinecol.Standard.BLL
{
	/// <summary>
	/// ҵ���߼���construction_project_b_BLL ��ժҪ˵����
	/// </summary>
	public class construction_project_b_BLL
	{
		private readonly DigiPower.Onlinecol.Standard.DAL.construction_project_b_DAL dal=new DigiPower.Onlinecol.Standard.DAL.construction_project_b_DAL();
		public construction_project_b_BLL()
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
		public bool Exists(int ConstructionProjectID)
		{
			return dal.Exists(ConstructionProjectID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(DigiPower.Onlinecol.Standard.Model.construction_project_b_MDL model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(DigiPower.Onlinecol.Standard.Model.construction_project_b_MDL model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ConstructionProjectID)
		{
			
			dal.Delete(ConstructionProjectID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.construction_project_b_MDL GetModel(int ConstructionProjectID)
		{
			
			return dal.GetModel(ConstructionProjectID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.construction_project_b_MDL GetModelByCache(int ConstructionProjectID)
		{
			
			string CacheKey = "construction_project_b_MDLModel-" + ConstructionProjectID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ConstructionProjectID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (DigiPower.Onlinecol.Standard.Model.construction_project_b_MDL)objModel;
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
		public List<DigiPower.Onlinecol.Standard.Model.construction_project_b_MDL> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<DigiPower.Onlinecol.Standard.Model.construction_project_b_MDL> DataTableToList(DataTable dt)
		{
			List<DigiPower.Onlinecol.Standard.Model.construction_project_b_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.construction_project_b_MDL>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DigiPower.Onlinecol.Standard.Model.construction_project_b_MDL model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new DigiPower.Onlinecol.Standard.Model.construction_project_b_MDL();
					if(dt.Rows[n]["ConstructionProjectID"].ToString()!="")
					{
						model.ConstructionProjectID=int.Parse(dt.Rows[n]["ConstructionProjectID"].ToString());
					}
					model.area_code=dt.Rows[n]["area_code"].ToString();
					model.dh=dt.Rows[n]["dh"].ToString();
					model.gcmc=dt.Rows[n]["gcmc"].ToString();
					model.gcdd=dt.Rows[n]["gcdd"].ToString();
					model.jsdw=dt.Rows[n]["jsdw"].ToString();
					model.lxpzdw=dt.Rows[n]["lxpzdw"].ToString();
					model.sjdw=dt.Rows[n]["sjdw"].ToString();
					model.kcdw=dt.Rows[n]["kcdw"].ToString();
					model.jldw=dt.Rows[n]["jldw"].ToString();
					model.lxpzwh=dt.Rows[n]["lxpzwh"].ToString();
					model.ghxkzh=dt.Rows[n]["ghxkzh"].ToString();
					model.ydghxkzh=dt.Rows[n]["ydghxkzh"].ToString();
					model.ydxkzh=dt.Rows[n]["ydxkzh"].ToString();
					model.sgxkzh=dt.Rows[n]["sgxkzh"].ToString();
					if(dt.Rows[n]["zydmj"].ToString()!="")
					{
						model.zydmj=decimal.Parse(dt.Rows[n]["zydmj"].ToString());
					}
					if(dt.Rows[n]["zjzmj"].ToString()!="")
					{
						model.zjzmj=decimal.Parse(dt.Rows[n]["zjzmj"].ToString());
					}
					if(dt.Rows[n]["zcd"].ToString()!="")
					{
						model.zcd=decimal.Parse(dt.Rows[n]["zcd"].ToString());
					}
					if(dt.Rows[n]["kgsj"].ToString()!="")
					{
						model.kgsj=DateTime.Parse(dt.Rows[n]["kgsj"].ToString());
					}
					if(dt.Rows[n]["jgsj"].ToString()!="")
					{
						model.jgsj=DateTime.Parse(dt.Rows[n]["jgsj"].ToString());
					}
					if(dt.Rows[n]["gczj"].ToString()!="")
					{
						model.gczj=decimal.Parse(dt.Rows[n]["gczj"].ToString());
					}
					if(dt.Rows[n]["gczj_Bak"].ToString()!="")
					{
						model.gczj_Bak=decimal.Parse(dt.Rows[n]["gczj_Bak"].ToString());
					}
					if(dt.Rows[n]["gcjs"].ToString()!="")
					{
						model.gcjs=decimal.Parse(dt.Rows[n]["gcjs"].ToString());
					}
					if(dt.Rows[n]["zajs"].ToString()!="")
					{
						model.zajs=int.Parse(dt.Rows[n]["zajs"].ToString());
					}
					if(dt.Rows[n]["wz"].ToString()!="")
					{
						model.wz=int.Parse(dt.Rows[n]["wz"].ToString());
					}
					if(dt.Rows[n]["tzj"].ToString()!="")
					{
						model.tzj=int.Parse(dt.Rows[n]["tzj"].ToString());
					}
					if(dt.Rows[n]["tzz"].ToString()!="")
					{
						model.tzz=int.Parse(dt.Rows[n]["tzz"].ToString());
					}
					if(dt.Rows[n]["dt"].ToString()!="")
					{
						model.dt=int.Parse(dt.Rows[n]["dt"].ToString());
					}
					if(dt.Rows[n]["zp"].ToString()!="")
					{
						model.zp=int.Parse(dt.Rows[n]["zp"].ToString());
					}
					if(dt.Rows[n]["dp"].ToString()!="")
					{
						model.dp=int.Parse(dt.Rows[n]["dp"].ToString());
					}
					if(dt.Rows[n]["ly"].ToString()!="")
					{
						model.ly=int.Parse(dt.Rows[n]["ly"].ToString());
					}
					if(dt.Rows[n]["lx"].ToString()!="")
					{
						model.lx=int.Parse(dt.Rows[n]["lx"].ToString());
					}
					if(dt.Rows[n]["gp"].ToString()!="")
					{
						model.gp=int.Parse(dt.Rows[n]["gp"].ToString());
					}
					if(dt.Rows[n]["cd"].ToString()!="")
					{
						model.cd=int.Parse(dt.Rows[n]["cd"].ToString());
					}
					if(dt.Rows[n]["cp"].ToString()!="")
					{
						model.cp=int.Parse(dt.Rows[n]["cp"].ToString());
					}
					if(dt.Rows[n]["swp"].ToString()!="")
					{
						model.swp=int.Parse(dt.Rows[n]["swp"].ToString());
					}
					if(dt.Rows[n]["swz"].ToString()!="")
					{
						model.swz=int.Parse(dt.Rows[n]["swz"].ToString());
					}
					if(dt.Rows[n]["qt"].ToString()!="")
					{
						model.qt=int.Parse(dt.Rows[n]["qt"].ToString());
					}
					model.bgqx=dt.Rows[n]["bgqx"].ToString();
					model.mj=dt.Rows[n]["mj"].ToString();
					if(dt.Rows[n]["jgrq"].ToString()!="")
					{
						model.jgrq=DateTime.Parse(dt.Rows[n]["jgrq"].ToString());
					}
					model.yjdw=dt.Rows[n]["yjdw"].ToString();
					model.swh=dt.Rows[n]["swh"].ToString();
					model.cfwz=dt.Rows[n]["cfwz"].ToString();
					model.note=dt.Rows[n]["note"].ToString();
					model.lrr=dt.Rows[n]["lrr"].ToString();
					if(dt.Rows[n]["lrsj"].ToString()!="")
					{
						model.lrsj=DateTime.Parse(dt.Rows[n]["lrsj"].ToString());
					}
					if(dt.Rows[n]["gisid"].ToString()!="")
					{
						model.gisid=int.Parse(dt.Rows[n]["gisid"].ToString());
					}
					if(dt.Rows[n]["ywzd"].ToString()!="")
					{
						model.ywzd=int.Parse(dt.Rows[n]["ywzd"].ToString());
					}
					model.xmbh=dt.Rows[n]["xmbh"].ToString();
					model.bjlxr=dt.Rows[n]["bjlxr"].ToString();
					model.lxdh=dt.Rows[n]["lxdh"].ToString();
					model.zlyj=dt.Rows[n]["zlyj"].ToString();
					model.gcqy=dt.Rows[n]["gcqy"].ToString();
					model.jsdw_xmfzr=dt.Rows[n]["jsdw_xmfzr"].ToString();
					model.TJLB=dt.Rows[n]["TJLB"].ToString();
					if(dt.Rows[n]["LFL"].ToString()!="")
					{
						model.LFL=decimal.Parse(dt.Rows[n]["LFL"].ToString());
					}
					model.kzdj=dt.Rows[n]["kzdj"].ToString();
					if(dt.Rows[n]["wzz"].ToString()!="")
					{
						model.wzz=int.Parse(dt.Rows[n]["wzz"].ToString());
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

