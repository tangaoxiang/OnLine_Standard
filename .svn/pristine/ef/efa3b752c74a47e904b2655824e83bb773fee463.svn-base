using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL
{
	/// <summary>
	/// 数据访问类construction_project_a_DAL。
	/// </summary>
	public class construction_project_a_DAL
	{
		public construction_project_a_DAL()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ConstructionProjectID", "construction_project_a"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ConstructionProjectID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from construction_project_a");
			strSql.Append(" where ConstructionProjectID=@ConstructionProjectID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ConstructionProjectID", SqlDbType.Int,8)};
			parameters[0].Value = ConstructionProjectID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(DigiPower.Onlinecol.Standard.Model.construction_project_a_MDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into construction_project_a(");
			strSql.Append("ConstructionProjectID,area_code,dh,gcmc,gcdd,jsdw,lxpzdw,sjdw,kcdw,jldw,lxpzwh,ghxkzh,ydxkzh,ydghxkzh,sgxkzh,zydmj,zjzmj,ds,gczj,gczj_Bak,gcjs,zajs,wz,tzj,tzz,dt,zp,dp,ly,lx,gp,cd,cp,swp,swz,qt,bgqx,mj,jgrq,yjdw,swh,cfwz,note,lrr,lrsj,gisid,ywzd,xmbh,bjlxr,lxdh,zlyj,rjl,LFL,jzmd,TJLB,jsdw_xmfzr,gcqy,zdj,wzz)");
			strSql.Append(" values (");
			strSql.Append("@ConstructionProjectID,@area_code,@dh,@gcmc,@gcdd,@jsdw,@lxpzdw,@sjdw,@kcdw,@jldw,@lxpzwh,@ghxkzh,@ydxkzh,@ydghxkzh,@sgxkzh,@zydmj,@zjzmj,@ds,@gczj,@gczj_Bak,@gcjs,@zajs,@wz,@tzj,@tzz,@dt,@zp,@dp,@ly,@lx,@gp,@cd,@cp,@swp,@swz,@qt,@bgqx,@mj,@jgrq,@yjdw,@swh,@cfwz,@note,@lrr,@lrsj,@gisid,@ywzd,@xmbh,@bjlxr,@lxdh,@zlyj,@rjl,@LFL,@jzmd,@TJLB,@jsdw_xmfzr,@gcqy,@zdj,@wzz)");
			SqlParameter[] parameters = {
					new SqlParameter("@ConstructionProjectID", SqlDbType.Int,8),
					new SqlParameter("@area_code", SqlDbType.VarChar,20),
					new SqlParameter("@dh", SqlDbType.VarChar,30),
					new SqlParameter("@gcmc", SqlDbType.VarChar,80),
					new SqlParameter("@gcdd", SqlDbType.VarChar,80),
					new SqlParameter("@jsdw", SqlDbType.VarChar,80),
					new SqlParameter("@lxpzdw", SqlDbType.VarChar,80),
					new SqlParameter("@sjdw", SqlDbType.VarChar,80),
					new SqlParameter("@kcdw", SqlDbType.VarChar,80),
					new SqlParameter("@jldw", SqlDbType.VarChar,80),
					new SqlParameter("@lxpzwh", SqlDbType.VarChar,80),
					new SqlParameter("@ghxkzh", SqlDbType.VarChar,80),
					new SqlParameter("@ydxkzh", SqlDbType.VarChar,80),
					new SqlParameter("@ydghxkzh", SqlDbType.VarChar,80),
					new SqlParameter("@sgxkzh", SqlDbType.VarChar,80),
					new SqlParameter("@zydmj", SqlDbType.Decimal,9),
					new SqlParameter("@zjzmj", SqlDbType.Decimal,9),
					new SqlParameter("@ds", SqlDbType.Int,8),
					new SqlParameter("@gczj", SqlDbType.Decimal,9),
					new SqlParameter("@gczj_Bak", SqlDbType.Decimal,9),
					new SqlParameter("@gcjs", SqlDbType.Decimal,9),
					new SqlParameter("@zajs", SqlDbType.Int,8),
					new SqlParameter("@wz", SqlDbType.Int,8),
					new SqlParameter("@tzj", SqlDbType.Int,8),
					new SqlParameter("@tzz", SqlDbType.Int,8),
					new SqlParameter("@dt", SqlDbType.Int,8),
					new SqlParameter("@zp", SqlDbType.Int,8),
					new SqlParameter("@dp", SqlDbType.Int,8),
					new SqlParameter("@ly", SqlDbType.Int,8),
					new SqlParameter("@lx", SqlDbType.Int,8),
					new SqlParameter("@gp", SqlDbType.Int,8),
					new SqlParameter("@cd", SqlDbType.Int,8),
					new SqlParameter("@cp", SqlDbType.Int,8),
					new SqlParameter("@swp", SqlDbType.Int,8),
					new SqlParameter("@swz", SqlDbType.Int,8),
					new SqlParameter("@qt", SqlDbType.Int,8),
					new SqlParameter("@bgqx", SqlDbType.VarChar,10),
					new SqlParameter("@mj", SqlDbType.VarChar,10),
					new SqlParameter("@jgrq", SqlDbType.DateTime),
					new SqlParameter("@yjdw", SqlDbType.VarChar,80),
					new SqlParameter("@swh", SqlDbType.VarChar,60),
					new SqlParameter("@cfwz", SqlDbType.VarChar,20),
					new SqlParameter("@note", SqlDbType.VarChar,100),
					new SqlParameter("@lrr", SqlDbType.VarChar,10),
					new SqlParameter("@lrsj", SqlDbType.DateTime),
					new SqlParameter("@gisid", SqlDbType.Int,8),
					new SqlParameter("@ywzd", SqlDbType.Int,8),
					new SqlParameter("@xmbh", SqlDbType.VarChar,30),
					new SqlParameter("@bjlxr", SqlDbType.VarChar,40),
					new SqlParameter("@lxdh", SqlDbType.VarChar,40),
					new SqlParameter("@zlyj", SqlDbType.VarChar,1),
					new SqlParameter("@rjl", SqlDbType.Decimal,9),
					new SqlParameter("@LFL", SqlDbType.Decimal,9),
					new SqlParameter("@jzmd", SqlDbType.Decimal,9),
					new SqlParameter("@TJLB", SqlDbType.VarChar,60),
					new SqlParameter("@jsdw_xmfzr", SqlDbType.VarChar,60),
					new SqlParameter("@gcqy", SqlDbType.VarChar,60),
					new SqlParameter("@zdj", SqlDbType.Decimal,9),
					new SqlParameter("@wzz", SqlDbType.Int,8)};
			parameters[0].Value = model.ConstructionProjectID;
			parameters[1].Value = model.area_code;
			parameters[2].Value = model.dh;
			parameters[3].Value = model.gcmc;
			parameters[4].Value = model.gcdd;
			parameters[5].Value = model.jsdw;
			parameters[6].Value = model.lxpzdw;
			parameters[7].Value = model.sjdw;
			parameters[8].Value = model.kcdw;
			parameters[9].Value = model.jldw;
			parameters[10].Value = model.lxpzwh;
			parameters[11].Value = model.ghxkzh;
			parameters[12].Value = model.ydxkzh;
			parameters[13].Value = model.ydghxkzh;
			parameters[14].Value = model.sgxkzh;
			parameters[15].Value = model.zydmj;
			parameters[16].Value = model.zjzmj;
			parameters[17].Value = model.ds;
			parameters[18].Value = model.gczj;
			parameters[19].Value = model.gczj_Bak;
			parameters[20].Value = model.gcjs;
			parameters[21].Value = model.zajs;
			parameters[22].Value = model.wz;
			parameters[23].Value = model.tzj;
			parameters[24].Value = model.tzz;
			parameters[25].Value = model.dt;
			parameters[26].Value = model.zp;
			parameters[27].Value = model.dp;
			parameters[28].Value = model.ly;
			parameters[29].Value = model.lx;
			parameters[30].Value = model.gp;
			parameters[31].Value = model.cd;
			parameters[32].Value = model.cp;
			parameters[33].Value = model.swp;
			parameters[34].Value = model.swz;
			parameters[35].Value = model.qt;
			parameters[36].Value = model.bgqx;
			parameters[37].Value = model.mj;
			parameters[38].Value = model.jgrq;
			parameters[39].Value = model.yjdw;
			parameters[40].Value = model.swh;
			parameters[41].Value = model.cfwz;
			parameters[42].Value = model.note;
			parameters[43].Value = model.lrr;
			parameters[44].Value = model.lrsj;
			parameters[45].Value = model.gisid;
			parameters[46].Value = model.ywzd;
			parameters[47].Value = model.xmbh;
			parameters[48].Value = model.bjlxr;
			parameters[49].Value = model.lxdh;
			parameters[50].Value = model.zlyj;
			parameters[51].Value = model.rjl;
			parameters[52].Value = model.LFL;
			parameters[53].Value = model.jzmd;
			parameters[54].Value = model.TJLB;
			parameters[55].Value = model.jsdw_xmfzr;
			parameters[56].Value = model.gcqy;
			parameters[57].Value = model.zdj;
			parameters[58].Value = model.wzz;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(DigiPower.Onlinecol.Standard.Model.construction_project_a_MDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update construction_project_a set ");
			strSql.Append("area_code=@area_code,");
			strSql.Append("dh=@dh,");
			strSql.Append("gcmc=@gcmc,");
			strSql.Append("gcdd=@gcdd,");
			strSql.Append("jsdw=@jsdw,");
			strSql.Append("lxpzdw=@lxpzdw,");
			strSql.Append("sjdw=@sjdw,");
			strSql.Append("kcdw=@kcdw,");
			strSql.Append("jldw=@jldw,");
			strSql.Append("lxpzwh=@lxpzwh,");
			strSql.Append("ghxkzh=@ghxkzh,");
			strSql.Append("ydxkzh=@ydxkzh,");
			strSql.Append("ydghxkzh=@ydghxkzh,");
			strSql.Append("sgxkzh=@sgxkzh,");
			strSql.Append("zydmj=@zydmj,");
			strSql.Append("zjzmj=@zjzmj,");
			strSql.Append("ds=@ds,");
			strSql.Append("gczj=@gczj,");
			strSql.Append("gczj_Bak=@gczj_Bak,");
			strSql.Append("gcjs=@gcjs,");
			strSql.Append("zajs=@zajs,");
			strSql.Append("wz=@wz,");
			strSql.Append("tzj=@tzj,");
			strSql.Append("tzz=@tzz,");
			strSql.Append("dt=@dt,");
			strSql.Append("zp=@zp,");
			strSql.Append("dp=@dp,");
			strSql.Append("ly=@ly,");
			strSql.Append("lx=@lx,");
			strSql.Append("gp=@gp,");
			strSql.Append("cd=@cd,");
			strSql.Append("cp=@cp,");
			strSql.Append("swp=@swp,");
			strSql.Append("swz=@swz,");
			strSql.Append("qt=@qt,");
			strSql.Append("bgqx=@bgqx,");
			strSql.Append("mj=@mj,");
			strSql.Append("jgrq=@jgrq,");
			strSql.Append("yjdw=@yjdw,");
			strSql.Append("swh=@swh,");
			strSql.Append("cfwz=@cfwz,");
			strSql.Append("note=@note,");
			strSql.Append("lrr=@lrr,");
			strSql.Append("lrsj=@lrsj,");
			strSql.Append("gisid=@gisid,");
			strSql.Append("ywzd=@ywzd,");
			strSql.Append("xmbh=@xmbh,");
			strSql.Append("bjlxr=@bjlxr,");
			strSql.Append("lxdh=@lxdh,");
			strSql.Append("zlyj=@zlyj,");
			strSql.Append("rjl=@rjl,");
			strSql.Append("LFL=@LFL,");
			strSql.Append("jzmd=@jzmd,");
			strSql.Append("TJLB=@TJLB,");
			strSql.Append("jsdw_xmfzr=@jsdw_xmfzr,");
			strSql.Append("gcqy=@gcqy,");
			strSql.Append("zdj=@zdj,");
			strSql.Append("wzz=@wzz");
			strSql.Append(" where ConstructionProjectID=@ConstructionProjectID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ConstructionProjectID", SqlDbType.Int,8),
					new SqlParameter("@area_code", SqlDbType.VarChar,20),
					new SqlParameter("@dh", SqlDbType.VarChar,30),
					new SqlParameter("@gcmc", SqlDbType.VarChar,80),
					new SqlParameter("@gcdd", SqlDbType.VarChar,80),
					new SqlParameter("@jsdw", SqlDbType.VarChar,80),
					new SqlParameter("@lxpzdw", SqlDbType.VarChar,80),
					new SqlParameter("@sjdw", SqlDbType.VarChar,80),
					new SqlParameter("@kcdw", SqlDbType.VarChar,80),
					new SqlParameter("@jldw", SqlDbType.VarChar,80),
					new SqlParameter("@lxpzwh", SqlDbType.VarChar,80),
					new SqlParameter("@ghxkzh", SqlDbType.VarChar,80),
					new SqlParameter("@ydxkzh", SqlDbType.VarChar,80),
					new SqlParameter("@ydghxkzh", SqlDbType.VarChar,80),
					new SqlParameter("@sgxkzh", SqlDbType.VarChar,80),
					new SqlParameter("@zydmj", SqlDbType.Decimal,9),
					new SqlParameter("@zjzmj", SqlDbType.Decimal,9),
					new SqlParameter("@ds", SqlDbType.Int,8),
					new SqlParameter("@gczj", SqlDbType.Decimal,9),
					new SqlParameter("@gczj_Bak", SqlDbType.Decimal,9),
					new SqlParameter("@gcjs", SqlDbType.Decimal,9),
					new SqlParameter("@zajs", SqlDbType.Int,8),
					new SqlParameter("@wz", SqlDbType.Int,8),
					new SqlParameter("@tzj", SqlDbType.Int,8),
					new SqlParameter("@tzz", SqlDbType.Int,8),
					new SqlParameter("@dt", SqlDbType.Int,8),
					new SqlParameter("@zp", SqlDbType.Int,8),
					new SqlParameter("@dp", SqlDbType.Int,8),
					new SqlParameter("@ly", SqlDbType.Int,8),
					new SqlParameter("@lx", SqlDbType.Int,8),
					new SqlParameter("@gp", SqlDbType.Int,8),
					new SqlParameter("@cd", SqlDbType.Int,8),
					new SqlParameter("@cp", SqlDbType.Int,8),
					new SqlParameter("@swp", SqlDbType.Int,8),
					new SqlParameter("@swz", SqlDbType.Int,8),
					new SqlParameter("@qt", SqlDbType.Int,8),
					new SqlParameter("@bgqx", SqlDbType.VarChar,10),
					new SqlParameter("@mj", SqlDbType.VarChar,10),
					new SqlParameter("@jgrq", SqlDbType.DateTime),
					new SqlParameter("@yjdw", SqlDbType.VarChar,80),
					new SqlParameter("@swh", SqlDbType.VarChar,60),
					new SqlParameter("@cfwz", SqlDbType.VarChar,20),
					new SqlParameter("@note", SqlDbType.VarChar,100),
					new SqlParameter("@lrr", SqlDbType.VarChar,10),
					new SqlParameter("@lrsj", SqlDbType.DateTime),
					new SqlParameter("@gisid", SqlDbType.Int,8),
					new SqlParameter("@ywzd", SqlDbType.Int,8),
					new SqlParameter("@xmbh", SqlDbType.VarChar,30),
					new SqlParameter("@bjlxr", SqlDbType.VarChar,40),
					new SqlParameter("@lxdh", SqlDbType.VarChar,40),
					new SqlParameter("@zlyj", SqlDbType.VarChar,1),
					new SqlParameter("@rjl", SqlDbType.Decimal,9),
					new SqlParameter("@LFL", SqlDbType.Decimal,9),
					new SqlParameter("@jzmd", SqlDbType.Decimal,9),
					new SqlParameter("@TJLB", SqlDbType.VarChar,60),
					new SqlParameter("@jsdw_xmfzr", SqlDbType.VarChar,60),
					new SqlParameter("@gcqy", SqlDbType.VarChar,60),
					new SqlParameter("@zdj", SqlDbType.Decimal,9),
					new SqlParameter("@wzz", SqlDbType.Int,8)};
			parameters[0].Value = model.ConstructionProjectID;
			parameters[1].Value = model.area_code;
			parameters[2].Value = model.dh;
			parameters[3].Value = model.gcmc;
			parameters[4].Value = model.gcdd;
			parameters[5].Value = model.jsdw;
			parameters[6].Value = model.lxpzdw;
			parameters[7].Value = model.sjdw;
			parameters[8].Value = model.kcdw;
			parameters[9].Value = model.jldw;
			parameters[10].Value = model.lxpzwh;
			parameters[11].Value = model.ghxkzh;
			parameters[12].Value = model.ydxkzh;
			parameters[13].Value = model.ydghxkzh;
			parameters[14].Value = model.sgxkzh;
			parameters[15].Value = model.zydmj;
			parameters[16].Value = model.zjzmj;
			parameters[17].Value = model.ds;
			parameters[18].Value = model.gczj;
			parameters[19].Value = model.gczj_Bak;
			parameters[20].Value = model.gcjs;
			parameters[21].Value = model.zajs;
			parameters[22].Value = model.wz;
			parameters[23].Value = model.tzj;
			parameters[24].Value = model.tzz;
			parameters[25].Value = model.dt;
			parameters[26].Value = model.zp;
			parameters[27].Value = model.dp;
			parameters[28].Value = model.ly;
			parameters[29].Value = model.lx;
			parameters[30].Value = model.gp;
			parameters[31].Value = model.cd;
			parameters[32].Value = model.cp;
			parameters[33].Value = model.swp;
			parameters[34].Value = model.swz;
			parameters[35].Value = model.qt;
			parameters[36].Value = model.bgqx;
			parameters[37].Value = model.mj;
			parameters[38].Value = model.jgrq;
			parameters[39].Value = model.yjdw;
			parameters[40].Value = model.swh;
			parameters[41].Value = model.cfwz;
			parameters[42].Value = model.note;
			parameters[43].Value = model.lrr;
			parameters[44].Value = model.lrsj;
			parameters[45].Value = model.gisid;
			parameters[46].Value = model.ywzd;
			parameters[47].Value = model.xmbh;
			parameters[48].Value = model.bjlxr;
			parameters[49].Value = model.lxdh;
			parameters[50].Value = model.zlyj;
			parameters[51].Value = model.rjl;
			parameters[52].Value = model.LFL;
			parameters[53].Value = model.jzmd;
			parameters[54].Value = model.TJLB;
			parameters[55].Value = model.jsdw_xmfzr;
			parameters[56].Value = model.gcqy;
			parameters[57].Value = model.zdj;
			parameters[58].Value = model.wzz;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ConstructionProjectID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from construction_project_a ");
			strSql.Append(" where ConstructionProjectID=@ConstructionProjectID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ConstructionProjectID", SqlDbType.Int,8)};
			parameters[0].Value = ConstructionProjectID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.construction_project_a_MDL GetModel(int ConstructionProjectID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ConstructionProjectID,area_code,dh,gcmc,gcdd,jsdw,lxpzdw,sjdw,kcdw,jldw,lxpzwh,ghxkzh,ydxkzh,ydghxkzh,sgxkzh,zydmj,zjzmj,ds,gczj,gczj_Bak,gcjs,zajs,wz,tzj,tzz,dt,zp,dp,ly,lx,gp,cd,cp,swp,swz,qt,bgqx,mj,jgrq,yjdw,swh,cfwz,note,lrr,lrsj,gisid,ywzd,xmbh,bjlxr,lxdh,zlyj,rjl,LFL,jzmd,TJLB,jsdw_xmfzr,gcqy,zdj,wzz from construction_project_a ");
			strSql.Append(" where ConstructionProjectID=@ConstructionProjectID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ConstructionProjectID", SqlDbType.Int,8)};
			parameters[0].Value = ConstructionProjectID;

			DigiPower.Onlinecol.Standard.Model.construction_project_a_MDL model=new DigiPower.Onlinecol.Standard.Model.construction_project_a_MDL();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ConstructionProjectID"].ToString()!="")
				{
					model.ConstructionProjectID=int.Parse(ds.Tables[0].Rows[0]["ConstructionProjectID"].ToString());
				}
				model.area_code=ds.Tables[0].Rows[0]["area_code"].ToString();
				model.dh=ds.Tables[0].Rows[0]["dh"].ToString();
				model.gcmc=ds.Tables[0].Rows[0]["gcmc"].ToString();
				model.gcdd=ds.Tables[0].Rows[0]["gcdd"].ToString();
				model.jsdw=ds.Tables[0].Rows[0]["jsdw"].ToString();
				model.lxpzdw=ds.Tables[0].Rows[0]["lxpzdw"].ToString();
				model.sjdw=ds.Tables[0].Rows[0]["sjdw"].ToString();
				model.kcdw=ds.Tables[0].Rows[0]["kcdw"].ToString();
				model.jldw=ds.Tables[0].Rows[0]["jldw"].ToString();
				model.lxpzwh=ds.Tables[0].Rows[0]["lxpzwh"].ToString();
				model.ghxkzh=ds.Tables[0].Rows[0]["ghxkzh"].ToString();
				model.ydxkzh=ds.Tables[0].Rows[0]["ydxkzh"].ToString();
				model.ydghxkzh=ds.Tables[0].Rows[0]["ydghxkzh"].ToString();
				model.sgxkzh=ds.Tables[0].Rows[0]["sgxkzh"].ToString();
				if(ds.Tables[0].Rows[0]["zydmj"].ToString()!="")
				{
					model.zydmj=decimal.Parse(ds.Tables[0].Rows[0]["zydmj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["zjzmj"].ToString()!="")
				{
					model.zjzmj=decimal.Parse(ds.Tables[0].Rows[0]["zjzmj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ds"].ToString()!="")
				{
					model.ds=int.Parse(ds.Tables[0].Rows[0]["ds"].ToString());
				}
				if(ds.Tables[0].Rows[0]["gczj"].ToString()!="")
				{
					model.gczj=decimal.Parse(ds.Tables[0].Rows[0]["gczj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["gczj_Bak"].ToString()!="")
				{
					model.gczj_Bak=decimal.Parse(ds.Tables[0].Rows[0]["gczj_Bak"].ToString());
				}
				if(ds.Tables[0].Rows[0]["gcjs"].ToString()!="")
				{
					model.gcjs=decimal.Parse(ds.Tables[0].Rows[0]["gcjs"].ToString());
				}
				if(ds.Tables[0].Rows[0]["zajs"].ToString()!="")
				{
					model.zajs=int.Parse(ds.Tables[0].Rows[0]["zajs"].ToString());
				}
				if(ds.Tables[0].Rows[0]["wz"].ToString()!="")
				{
					model.wz=int.Parse(ds.Tables[0].Rows[0]["wz"].ToString());
				}
				if(ds.Tables[0].Rows[0]["tzj"].ToString()!="")
				{
					model.tzj=int.Parse(ds.Tables[0].Rows[0]["tzj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["tzz"].ToString()!="")
				{
					model.tzz=int.Parse(ds.Tables[0].Rows[0]["tzz"].ToString());
				}
				if(ds.Tables[0].Rows[0]["dt"].ToString()!="")
				{
					model.dt=int.Parse(ds.Tables[0].Rows[0]["dt"].ToString());
				}
				if(ds.Tables[0].Rows[0]["zp"].ToString()!="")
				{
					model.zp=int.Parse(ds.Tables[0].Rows[0]["zp"].ToString());
				}
				if(ds.Tables[0].Rows[0]["dp"].ToString()!="")
				{
					model.dp=int.Parse(ds.Tables[0].Rows[0]["dp"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ly"].ToString()!="")
				{
					model.ly=int.Parse(ds.Tables[0].Rows[0]["ly"].ToString());
				}
				if(ds.Tables[0].Rows[0]["lx"].ToString()!="")
				{
					model.lx=int.Parse(ds.Tables[0].Rows[0]["lx"].ToString());
				}
				if(ds.Tables[0].Rows[0]["gp"].ToString()!="")
				{
					model.gp=int.Parse(ds.Tables[0].Rows[0]["gp"].ToString());
				}
				if(ds.Tables[0].Rows[0]["cd"].ToString()!="")
				{
					model.cd=int.Parse(ds.Tables[0].Rows[0]["cd"].ToString());
				}
				if(ds.Tables[0].Rows[0]["cp"].ToString()!="")
				{
					model.cp=int.Parse(ds.Tables[0].Rows[0]["cp"].ToString());
				}
				if(ds.Tables[0].Rows[0]["swp"].ToString()!="")
				{
					model.swp=int.Parse(ds.Tables[0].Rows[0]["swp"].ToString());
				}
				if(ds.Tables[0].Rows[0]["swz"].ToString()!="")
				{
					model.swz=int.Parse(ds.Tables[0].Rows[0]["swz"].ToString());
				}
				if(ds.Tables[0].Rows[0]["qt"].ToString()!="")
				{
					model.qt=int.Parse(ds.Tables[0].Rows[0]["qt"].ToString());
				}
				model.bgqx=ds.Tables[0].Rows[0]["bgqx"].ToString();
				model.mj=ds.Tables[0].Rows[0]["mj"].ToString();
				if(ds.Tables[0].Rows[0]["jgrq"].ToString()!="")
				{
					model.jgrq=DateTime.Parse(ds.Tables[0].Rows[0]["jgrq"].ToString());
				}
				model.yjdw=ds.Tables[0].Rows[0]["yjdw"].ToString();
				model.swh=ds.Tables[0].Rows[0]["swh"].ToString();
				model.cfwz=ds.Tables[0].Rows[0]["cfwz"].ToString();
				model.note=ds.Tables[0].Rows[0]["note"].ToString();
				model.lrr=ds.Tables[0].Rows[0]["lrr"].ToString();
				if(ds.Tables[0].Rows[0]["lrsj"].ToString()!="")
				{
					model.lrsj=DateTime.Parse(ds.Tables[0].Rows[0]["lrsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["gisid"].ToString()!="")
				{
					model.gisid=int.Parse(ds.Tables[0].Rows[0]["gisid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ywzd"].ToString()!="")
				{
					model.ywzd=int.Parse(ds.Tables[0].Rows[0]["ywzd"].ToString());
				}
				model.xmbh=ds.Tables[0].Rows[0]["xmbh"].ToString();
				model.bjlxr=ds.Tables[0].Rows[0]["bjlxr"].ToString();
				model.lxdh=ds.Tables[0].Rows[0]["lxdh"].ToString();
				model.zlyj=ds.Tables[0].Rows[0]["zlyj"].ToString();
				if(ds.Tables[0].Rows[0]["rjl"].ToString()!="")
				{
					model.rjl=decimal.Parse(ds.Tables[0].Rows[0]["rjl"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LFL"].ToString()!="")
				{
					model.LFL=decimal.Parse(ds.Tables[0].Rows[0]["LFL"].ToString());
				}
				if(ds.Tables[0].Rows[0]["jzmd"].ToString()!="")
				{
					model.jzmd=decimal.Parse(ds.Tables[0].Rows[0]["jzmd"].ToString());
				}
				model.TJLB=ds.Tables[0].Rows[0]["TJLB"].ToString();
				model.jsdw_xmfzr=ds.Tables[0].Rows[0]["jsdw_xmfzr"].ToString();
				model.gcqy=ds.Tables[0].Rows[0]["gcqy"].ToString();
				if(ds.Tables[0].Rows[0]["zdj"].ToString()!="")
				{
					model.zdj=decimal.Parse(ds.Tables[0].Rows[0]["zdj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["wzz"].ToString()!="")
				{
					model.wzz=int.Parse(ds.Tables[0].Rows[0]["wzz"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ConstructionProjectID,area_code,dh,gcmc,gcdd,jsdw,lxpzdw,sjdw,kcdw,jldw,lxpzwh,ghxkzh,ydxkzh,ydghxkzh,sgxkzh,zydmj,zjzmj,ds,gczj,gczj_Bak,gcjs,zajs,wz,tzj,tzz,dt,zp,dp,ly,lx,gp,cd,cp,swp,swz,qt,bgqx,mj,jgrq,yjdw,swh,cfwz,note,lrr,lrsj,gisid,ywzd,xmbh,bjlxr,lxdh,zlyj,rjl,LFL,jzmd,TJLB,jsdw_xmfzr,gcqy,zdj,wzz ");
			strSql.Append(" FROM construction_project_a ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ConstructionProjectID,area_code,dh,gcmc,gcdd,jsdw,lxpzdw,sjdw,kcdw,jldw,lxpzwh,ghxkzh,ydxkzh,ydghxkzh,sgxkzh,zydmj,zjzmj,ds,gczj,gczj_Bak,gcjs,zajs,wz,tzj,tzz,dt,zp,dp,ly,lx,gp,cd,cp,swp,swz,qt,bgqx,mj,jgrq,yjdw,swh,cfwz,note,lrr,lrsj,gisid,ywzd,xmbh,bjlxr,lxdh,zlyj,rjl,LFL,jzmd,TJLB,jsdw_xmfzr,gcqy,zdj,wzz ");
			strSql.Append(" FROM construction_project_a ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "construction_project_a";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法
	}
}

