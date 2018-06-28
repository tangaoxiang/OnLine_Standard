using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
namespace DigiPower.Onlinecol.Standard.BLL
{
	/// <summary>
	/// 业务逻辑类b_single_project_BLL 的摘要说明。
	/// </summary>
	public class b_single_project_BLL
	{
		private readonly DigiPower.Onlinecol.Standard.DAL.b_single_project_DAL dal=new DigiPower.Onlinecol.Standard.DAL.b_single_project_DAL();
		public b_single_project_BLL()
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
		public bool Exists(int SingleProjectID)
		{
			return dal.Exists(SingleProjectID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(DigiPower.Onlinecol.Standard.Model.b_single_project_MDL model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(DigiPower.Onlinecol.Standard.Model.b_single_project_MDL model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int SingleProjectID)
		{
			
			dal.Delete(SingleProjectID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.b_single_project_MDL GetModel(int SingleProjectID)
		{
			
			return dal.GetModel(SingleProjectID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.b_single_project_MDL GetModelByCache(int SingleProjectID)
		{
			
			string CacheKey = "b_single_project_MDLModel-" + SingleProjectID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(SingleProjectID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (DigiPower.Onlinecol.Standard.Model.b_single_project_MDL)objModel;
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
		public List<DigiPower.Onlinecol.Standard.Model.b_single_project_MDL> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DigiPower.Onlinecol.Standard.Model.b_single_project_MDL> DataTableToList(DataTable dt)
		{
			List<DigiPower.Onlinecol.Standard.Model.b_single_project_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.b_single_project_MDL>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DigiPower.Onlinecol.Standard.Model.b_single_project_MDL model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new DigiPower.Onlinecol.Standard.Model.b_single_project_MDL();
					if(dt.Rows[n]["SingleProjectID"].ToString()!="")
					{
						model.SingleProjectID=int.Parse(dt.Rows[n]["SingleProjectID"].ToString());
					}
					model.dxgcmc=dt.Rows[n]["dxgcmc"].ToString();
					model.sgdw=dt.Rows[n]["sgdw"].ToString();
					model.zlaqjddw=dt.Rows[n]["zlaqjddw"].ToString();
					model.ghxkzh=dt.Rows[n]["ghxkzh"].ToString();
					model.sgxkzh=dt.Rows[n]["sgxkzh"].ToString();
					model.jglx=dt.Rows[n]["jglx"].ToString();
					if(dt.Rows[n]["jzmj"].ToString()!="")
					{
						model.jzmj=decimal.Parse(dt.Rows[n]["jzmj"].ToString());
					}
					if(dt.Rows[n]["kd"].ToString()!="")
					{
						model.kd=decimal.Parse(dt.Rows[n]["kd"].ToString());
					}
					if(dt.Rows[n]["gd"].ToString()!="")
					{
						model.gd=decimal.Parse(dt.Rows[n]["gd"].ToString());
					}
					if(dt.Rows[n]["kj"].ToString()!="")
					{
						model.kj=decimal.Parse(dt.Rows[n]["kj"].ToString());
					}
					if(dt.Rows[n]["ks"].ToString()!="")
					{
						model.ks=int.Parse(dt.Rows[n]["ks"].ToString());
					}
					model.jb=dt.Rows[n]["jb"].ToString();
					model.hz=dt.Rows[n]["hz"].ToString();
					if(dt.Rows[n]["jk"].ToString()!="")
					{
						model.jk=decimal.Parse(dt.Rows[n]["jk"].ToString());
					}
					if(dt.Rows[n]["chd"].ToString()!="")
					{
						model.chd=decimal.Parse(dt.Rows[n]["chd"].ToString());
					}
					if(dt.Rows[n]["jgsj"].ToString()!="")
					{
						model.jgsj=DateTime.Parse(dt.Rows[n]["jgsj"].ToString());
					}
					if(dt.Rows[n]["kgsj"].ToString()!="")
					{
						model.kgsj=DateTime.Parse(dt.Rows[n]["kgsj"].ToString());
					}
					if(dt.Rows[n]["gczj"].ToString()!="")
					{
						model.gczj=decimal.Parse(dt.Rows[n]["gczj"].ToString());
					}
					if(dt.Rows[n]["gcjs"].ToString()!="")
					{
						model.gcjs=decimal.Parse(dt.Rows[n]["gcjs"].ToString());
					}
					if(dt.Rows[n]["ajs"].ToString()!="")
					{
						model.ajs=int.Parse(dt.Rows[n]["ajs"].ToString());
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
					model.zrsbh=dt.Rows[n]["zrsbh"].ToString();
					model.lxr=dt.Rows[n]["lxr"].ToString();
					model.lxdh=dt.Rows[n]["lxdh"].ToString();
					if(dt.Rows[n]["gisid"].ToString()!="")
					{
						model.gisid=int.Parse(dt.Rows[n]["gisid"].ToString());
					}
					if(dt.Rows[n]["ywzd"].ToString()!="")
					{
						model.ywzd=int.Parse(dt.Rows[n]["ywzd"].ToString());
					}
					model.zlyj=dt.Rows[n]["zlyj"].ToString();
					model.gc_code=dt.Rows[n]["gc_code"].ToString();
					model.YDXKZH=dt.Rows[n]["YDXKZH"].ToString();
					model.ydghxkzh=dt.Rows[n]["ydghxkzh"].ToString();
					model.HJQK=dt.Rows[n]["HJQK"].ToString();
					model.SJDW_XMFZR=dt.Rows[n]["SJDW_XMFZR"].ToString();
					model.KCDW=dt.Rows[n]["KCDW"].ToString();
					model.KCDW_XMFZR=dt.Rows[n]["KCDW_XMFZR"].ToString();
					model.JLDW_XMFZR=dt.Rows[n]["JLDW_XMFZR"].ToString();
					model.SGDW_XMJL=dt.Rows[n]["SGDW_XMJL"].ToString();
					model.ZJLGCS=dt.Rows[n]["ZJLGCS"].ToString();
					model.ZYJLGCS=dt.Rows[n]["ZYJLGCS"].ToString();
					model.FBDW=dt.Rows[n]["FBDW"].ToString();
					model.FBDW_XMJL=dt.Rows[n]["FBDW_XMJL"].ToString();
					model.FBDW_1=dt.Rows[n]["FBDW_1"].ToString();
					model.FBDW_1_XMJL=dt.Rows[n]["FBDW_1_XMJL"].ToString();
					model.ZYGZ=dt.Rows[n]["ZYGZ"].ToString();
					model.XMZYZLJCY=dt.Rows[n]["XMZYZLJCY"].ToString();
					model.SGBZZ=dt.Rows[n]["SGBZZ"].ToString();
					model.TBR=dt.Rows[n]["TBR"].ToString();
					model.JSDW_SHR=dt.Rows[n]["JSDW_SHR"].ToString();
					model.JLDW_SHR=dt.Rows[n]["JLDW_SHR"].ToString();
					if(dt.Rows[n]["SHRQ"].ToString()!="")
					{
						model.SHRQ=DateTime.Parse(dt.Rows[n]["SHRQ"].ToString());
					}
					model.TJLB=dt.Rows[n]["TJLB"].ToString();
					if(dt.Rows[n]["FPSJ"].ToString()!="")
					{
						model.FPSJ=DateTime.Parse(dt.Rows[n]["FPSJ"].ToString());
					}
					model.FPR=dt.Rows[n]["FPR"].ToString();
					model.SPR=dt.Rows[n]["SPR"].ToString();
					model.SPR_DH=dt.Rows[n]["SPR_DH"].ToString();
					model.FP_BZ=dt.Rows[n]["FP_BZ"].ToString();
					if(dt.Rows[n]["mtdw"].ToString()!="")
					{
						model.mtdw=decimal.Parse(dt.Rows[n]["mtdw"].ToString());
					}
					if(dt.Rows[n]["mtss"].ToString()!="")
					{
						model.mtss=decimal.Parse(dt.Rows[n]["mtss"].ToString());
					}
					model.sjdw=dt.Rows[n]["sjdw"].ToString();
					model.jldw=dt.Rows[n]["jldw"].ToString();
					model.kzdj=dt.Rows[n]["kzdj"].ToString();
					if(dt.Rows[n]["wzz"].ToString()!="")
					{
						model.wzz=int.Parse(dt.Rows[n]["wzz"].ToString());
					}
					model.qlcd=dt.Rows[n]["qlcd"].ToString();
					model.hzbz=dt.Rows[n]["hzbz"].ToString();
					model.ztjg=dt.Rows[n]["ztjg"].ToString();
					model.qljk=dt.Rows[n]["qljk"].ToString();
					model.dx=dt.Rows[n]["dx"].ToString();
					model.zs=dt.Rows[n]["zs"].ToString();
					model.bzxs=dt.Rows[n]["bzxs"].ToString();
					model.dl=dt.Rows[n]["dl"].ToString();
					model.ydfs=dt.Rows[n]["ydfs"].ToString();
					model.zys=dt.Rows[n]["zys"].ToString();
					model.zcd=dt.Rows[n]["zcd"].ToString();
					model.gczl=dt.Rows[n]["gczl"].ToString();
					model.qlkd=dt.Rows[n]["qlkd"].ToString();
					model.qllb=dt.Rows[n]["qllb"].ToString();
					model.qlkd2=dt.Rows[n]["qlkd2"].ToString();
					model.qljb=dt.Rows[n]["qljb"].ToString();
					model.qlzh=dt.Rows[n]["qlzh"].ToString();
					model.dg=dt.Rows[n]["dg"].ToString();
					model.jj=dt.Rows[n]["jj"].ToString();
					model.fh=dt.Rows[n]["fh"].ToString();
					model.xj=dt.Rows[n]["xj"].ToString();
					model.zjs=dt.Rows[n]["zjs"].ToString();
                    model.fz = dt.Rows[n]["fz"].ToString();
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

