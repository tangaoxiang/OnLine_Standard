using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
namespace DigiPower.Onlinecol.Standard.BLL
{
	/// <summary>
	/// 业务逻辑类a_single_project_BLL 的摘要说明。
	/// </summary>
	public class a_single_project_BLL
	{
		private readonly DigiPower.Onlinecol.Standard.DAL.a_single_project_DAL dal=new DigiPower.Onlinecol.Standard.DAL.a_single_project_DAL();
		public a_single_project_BLL()
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
		public void Add(DigiPower.Onlinecol.Standard.Model.a_single_project_MDL model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(DigiPower.Onlinecol.Standard.Model.a_single_project_MDL model)
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
		public DigiPower.Onlinecol.Standard.Model.a_single_project_MDL GetModel(int SingleProjectID)
		{
			
			return dal.GetModel(SingleProjectID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.a_single_project_MDL GetModelByCache(int SingleProjectID)
		{
			
			string CacheKey = "a_single_project_MDLModel-" + SingleProjectID;
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
			return (DigiPower.Onlinecol.Standard.Model.a_single_project_MDL)objModel;
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
		public List<DigiPower.Onlinecol.Standard.Model.a_single_project_MDL> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DigiPower.Onlinecol.Standard.Model.a_single_project_MDL> DataTableToList(DataTable dt)
		{
			List<DigiPower.Onlinecol.Standard.Model.a_single_project_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.a_single_project_MDL>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DigiPower.Onlinecol.Standard.Model.a_single_project_MDL model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new DigiPower.Onlinecol.Standard.Model.a_single_project_MDL();
					if(dt.Rows[n]["SingleProjectID"].ToString()!="")
					{
						model.SingleProjectID=int.Parse(dt.Rows[n]["SingleProjectID"].ToString());
					}
					if(dt.Rows[n]["jzmj"].ToString()!="")
					{
						model.jzmj=decimal.Parse(dt.Rows[n]["jzmj"].ToString());
					}
					if(dt.Rows[n]["gd"].ToString()!="")
					{
						model.gd=decimal.Parse(dt.Rows[n]["gd"].ToString());
					}
					model.dxcs=dt.Rows[n]["dxcs"].ToString();
					model.dscs=dt.Rows[n]["dscs"].ToString();
					model.jglx=dt.Rows[n]["jglx"].ToString();
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
					if(dt.Rows[n]["swz"].ToString()!="")
					{
						model.swz=int.Parse(dt.Rows[n]["swz"].ToString());
					}
					if(dt.Rows[n]["qt"].ToString()!="")
					{
						model.qt=int.Parse(dt.Rows[n]["qt"].ToString());
					}
					model.mj=dt.Rows[n]["mj"].ToString();
					if(dt.Rows[n]["jgrq"].ToString()!="")
					{
						model.jgrq=DateTime.Parse(dt.Rows[n]["jgrq"].ToString());
					}
					model.yjdw=dt.Rows[n]["yjdw"].ToString();
					model.swh=dt.Rows[n]["swh"].ToString();
					model.cfwz=dt.Rows[n]["cfwz"].ToString();
					model.note=dt.Rows[n]["note"].ToString();
					if(dt.Rows[n]["ds"].ToString()!="")
					{
						model.ds=int.Parse(dt.Rows[n]["ds"].ToString());
					}
					if(dt.Rows[n]["swp"].ToString()!="")
					{
						model.swp=int.Parse(dt.Rows[n]["swp"].ToString());
					}
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
					model.ghxkzh=dt.Rows[n]["ghxkzh"].ToString();
					model.sgxkzh=dt.Rows[n]["sgxkzh"].ToString();
					model.zlaqjddw=dt.Rows[n]["zlaqjddw"].ToString();
					model.zlyj=dt.Rows[n]["zlyj"].ToString();
					model.gc_code=dt.Rows[n]["gc_code"].ToString();
					model.ydxkzh=dt.Rows[n]["ydxkzh"].ToString();
					model.ydghxkzh=dt.Rows[n]["ydghxkzh"].ToString();
					model.HJQK=dt.Rows[n]["HJQK"].ToString();
					if(dt.Rows[n]["ZZMJ"].ToString()!="")
					{
						model.ZZMJ=decimal.Parse(dt.Rows[n]["ZZMJ"].ToString());
					}
					if(dt.Rows[n]["BBYFMJ"].ToString()!="")
					{
						model.BBYFMJ=decimal.Parse(dt.Rows[n]["BBYFMJ"].ToString());
					}
					if(dt.Rows[n]["SYYFMJ"].ToString()!="")
					{
						model.SYYFMJ=decimal.Parse(dt.Rows[n]["SYYFMJ"].ToString());
					}
					if(dt.Rows[n]["CFMJ"].ToString()!="")
					{
						model.CFMJ=decimal.Parse(dt.Rows[n]["CFMJ"].ToString());
					}
					if(dt.Rows[n]["DXSMJ"].ToString()!="")
					{
						model.DXSMJ=decimal.Parse(dt.Rows[n]["DXSMJ"].ToString());
					}
					if(dt.Rows[n]["RFMJ"].ToString()!="")
					{
						model.RFMJ=decimal.Parse(dt.Rows[n]["RFMJ"].ToString());
					}
					if(dt.Rows[n]["QTYFMJ"].ToString()!="")
					{
						model.QTYFMJ=decimal.Parse(dt.Rows[n]["QTYFMJ"].ToString());
					}
					if(dt.Rows[n]["DSGYTS"].ToString()!="")
					{
						model.DSGYTS=int.Parse(dt.Rows[n]["DSGYTS"].ToString());
					}
					if(dt.Rows[n]["TJTS1"].ToString()!="")
					{
						model.TJTS1=int.Parse(dt.Rows[n]["TJTS1"].ToString());
					}
					if(dt.Rows[n]["TJTS2"].ToString()!="")
					{
						model.TJTS2=int.Parse(dt.Rows[n]["TJTS2"].ToString());
					}
					if(dt.Rows[n]["TJTS3"].ToString()!="")
					{
						model.TJTS3=int.Parse(dt.Rows[n]["TJTS3"].ToString());
					}
					if(dt.Rows[n]["TJTS4"].ToString()!="")
					{
						model.TJTS4=int.Parse(dt.Rows[n]["TJTS4"].ToString());
					}
					if(dt.Rows[n]["zts"].ToString()!="")
					{
						model.zts=int.Parse(dt.Rows[n]["zts"].ToString());
					}
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
					model.fhdj=dt.Rows[n]["fhdj"].ToString();
					model.kzdj=dt.Rows[n]["kzdj"].ToString();
					model.sjdw=dt.Rows[n]["sjdw"].ToString();
					model.jldw=dt.Rows[n]["jldw"].ToString();
					if(dt.Rows[n]["wzz"].ToString()!="")
					{
						model.wzz=int.Parse(dt.Rows[n]["wzz"].ToString());
					}
					model.fsts=dt.Rows[n]["fsts"].ToString();
					model.cws=dt.Rows[n]["cws"].ToString();
					model.xmzj=dt.Rows[n]["xmzj"].ToString();
					model.jldwshr=dt.Rows[n]["jldwshr"].ToString();
					model.fz=dt.Rows[n]["fz"].ToString();
					model.gcys=dt.Rows[n]["gcys"].ToString();
					model.bgyfmj=dt.Rows[n]["bgyfmj"].ToString();
					model.gczl=dt.Rows[n]["gczl"].ToString();
					model.xcjl=dt.Rows[n]["xcjl"].ToString();
					model.xmjl=dt.Rows[n]["xmjl"].ToString();
					model.jsdwshr=dt.Rows[n]["jsdwshr"].ToString();
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

