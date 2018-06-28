using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用

namespace DigiPower.Onlinecol.Standard.DAL
{
    /// <summary>
    /// 数据访问类a_single_project_DAL。
    /// </summary>
    public class a_single_project_DAL
    {
        public a_single_project_DAL()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("SingleProjectID", "a_single_project");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SingleProjectID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from a_single_project");
            strSql.Append(" where SingleProjectID=@SingleProjectID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SingleProjectID", SqlDbType.Int,8)};
            parameters[0].Value = SingleProjectID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(DigiPower.Onlinecol.Standard.Model.a_single_project_MDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into a_single_project(");
            strSql.Append("SingleProjectID,jzmj,gd,dxcs,dscs,jglx,kgsj,jgsj,gczj,gcjs,ajs,wz,tzj,tzz,dt,zp,dp,ly,lx,gp,cd,cp,swz,qt,mj,jgrq,yjdw,swh,cfwz,note,ds,swp,lrr,lrsj,zrsbh,lxr,lxdh,gisid,ywzd,ghxkzh,sgxkzh,zlaqjddw,zlyj,gc_code,ydxkzh,ydghxkzh,HJQK,ZZMJ,BBYFMJ,SYYFMJ,CFMJ,DXSMJ,RFMJ,QTYFMJ,DSGYTS,TJTS1,TJTS2,TJTS3,TJTS4,zts,SJDW_XMFZR,KCDW,KCDW_XMFZR,JLDW_XMFZR,SGDW_XMJL,ZJLGCS,ZYJLGCS,FBDW,FBDW_XMJL,FBDW_1,FBDW_1_XMJL,ZYGZ,XMZYZLJCY,SGBZZ,TBR,JSDW_SHR,JLDW_SHR,SHRQ,TJLB,FPSJ,FPR,SPR,SPR_DH,FP_BZ,fhdj,kzdj,sjdw,jldw,wzz,fsts,cws,xmzj,jldwshr,fz,gcys,bgyfmj,gczl,xcjl,xmjl,jsdwshr)");
            strSql.Append(" values (");
            strSql.Append("@SingleProjectID,@jzmj,@gd,@dxcs,@dscs,@jglx,@kgsj,@jgsj,@gczj,@gcjs,@ajs,@wz,@tzj,@tzz,@dt,@zp,@dp,@ly,@lx,@gp,@cd,@cp,@swz,@qt,@mj,@jgrq,@yjdw,@swh,@cfwz,@note,@ds,@swp,@lrr,@lrsj,@zrsbh,@lxr,@lxdh,@gisid,@ywzd,@ghxkzh,@sgxkzh,@zlaqjddw,@zlyj,@gc_code,@ydxkzh,@ydghxkzh,@HJQK,@ZZMJ,@BBYFMJ,@SYYFMJ,@CFMJ,@DXSMJ,@RFMJ,@QTYFMJ,@DSGYTS,@TJTS1,@TJTS2,@TJTS3,@TJTS4,@zts,@SJDW_XMFZR,@KCDW,@KCDW_XMFZR,@JLDW_XMFZR,@SGDW_XMJL,@ZJLGCS,@ZYJLGCS,@FBDW,@FBDW_XMJL,@FBDW_1,@FBDW_1_XMJL,@ZYGZ,@XMZYZLJCY,@SGBZZ,@TBR,@JSDW_SHR,@JLDW_SHR,@SHRQ,@TJLB,@FPSJ,@FPR,@SPR,@SPR_DH,@FP_BZ,@fhdj,@kzdj,@sjdw,@jldw,@wzz,@fsts,@cws,@xmzj,@jldwshr,@fz,@gcys,@bgyfmj,@gczl,@xcjl,@xmjl,@jsdwshr)");
            SqlParameter[] parameters = {
					new SqlParameter("@SingleProjectID", SqlDbType.Int,8),
					new SqlParameter("@jzmj", SqlDbType.Decimal,9),
					new SqlParameter("@gd", SqlDbType.Decimal,9),
					new SqlParameter("@dxcs", SqlDbType.VarChar,20),
					new SqlParameter("@dscs", SqlDbType.VarChar,20),
					new SqlParameter("@jglx", SqlDbType.VarChar,40),
					new SqlParameter("@kgsj", SqlDbType.DateTime),
					new SqlParameter("@jgsj", SqlDbType.DateTime),
					new SqlParameter("@gczj", SqlDbType.Decimal,9),
					new SqlParameter("@gcjs", SqlDbType.Decimal,9),
					new SqlParameter("@ajs", SqlDbType.Int,8),
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
					new SqlParameter("@swz", SqlDbType.Int,8),
					new SqlParameter("@qt", SqlDbType.Int,8),
					new SqlParameter("@mj", SqlDbType.VarChar,10),
					new SqlParameter("@jgrq", SqlDbType.DateTime),
					new SqlParameter("@yjdw", SqlDbType.VarChar,80),
					new SqlParameter("@swh", SqlDbType.VarChar,60),
					new SqlParameter("@cfwz", SqlDbType.VarChar,20),
					new SqlParameter("@note", SqlDbType.VarChar,100),
					new SqlParameter("@ds", SqlDbType.Int,8),
					new SqlParameter("@swp", SqlDbType.Int,8),
					new SqlParameter("@lrr", SqlDbType.VarChar,10),
					new SqlParameter("@lrsj", SqlDbType.DateTime),
					new SqlParameter("@zrsbh", SqlDbType.VarChar,20),
					new SqlParameter("@lxr", SqlDbType.VarChar,20),
					new SqlParameter("@lxdh", SqlDbType.VarChar,30),
					new SqlParameter("@gisid", SqlDbType.Int,8),
					new SqlParameter("@ywzd", SqlDbType.Int,8),
					new SqlParameter("@ghxkzh", SqlDbType.VarChar,80),
					new SqlParameter("@sgxkzh", SqlDbType.VarChar,80),
					new SqlParameter("@zlaqjddw", SqlDbType.VarChar,80),
					new SqlParameter("@zlyj", SqlDbType.VarChar,1),
					new SqlParameter("@gc_code", SqlDbType.VarChar,20),
					new SqlParameter("@ydxkzh", SqlDbType.VarChar,80),
					new SqlParameter("@ydghxkzh", SqlDbType.VarChar,80),
					new SqlParameter("@HJQK", SqlDbType.VarChar,60),
					new SqlParameter("@ZZMJ", SqlDbType.Decimal,9),
					new SqlParameter("@BBYFMJ", SqlDbType.Decimal,9),
					new SqlParameter("@SYYFMJ", SqlDbType.Decimal,9),
					new SqlParameter("@CFMJ", SqlDbType.Decimal,9),
					new SqlParameter("@DXSMJ", SqlDbType.Decimal,9),
					new SqlParameter("@RFMJ", SqlDbType.Decimal,9),
					new SqlParameter("@QTYFMJ", SqlDbType.Decimal,9),
					new SqlParameter("@DSGYTS", SqlDbType.Int,8),
					new SqlParameter("@TJTS1", SqlDbType.Int,8),
					new SqlParameter("@TJTS2", SqlDbType.Int,8),
					new SqlParameter("@TJTS3", SqlDbType.Int,8),
					new SqlParameter("@TJTS4", SqlDbType.Int,8),
					new SqlParameter("@zts", SqlDbType.Int,8),
					new SqlParameter("@SJDW_XMFZR", SqlDbType.VarChar,20),
					new SqlParameter("@KCDW", SqlDbType.VarChar,80),
					new SqlParameter("@KCDW_XMFZR", SqlDbType.VarChar,20),
					new SqlParameter("@JLDW_XMFZR", SqlDbType.VarChar,20),
					new SqlParameter("@SGDW_XMJL", SqlDbType.VarChar,20),
					new SqlParameter("@ZJLGCS", SqlDbType.VarChar,20),
					new SqlParameter("@ZYJLGCS", SqlDbType.VarChar,20),
					new SqlParameter("@FBDW", SqlDbType.VarChar,80),
					new SqlParameter("@FBDW_XMJL", SqlDbType.VarChar,20),
					new SqlParameter("@FBDW_1", SqlDbType.VarChar,80),
					new SqlParameter("@FBDW_1_XMJL", SqlDbType.VarChar,20),
					new SqlParameter("@ZYGZ", SqlDbType.VarChar,20),
					new SqlParameter("@XMZYZLJCY", SqlDbType.VarChar,20),
					new SqlParameter("@SGBZZ", SqlDbType.VarChar,20),
					new SqlParameter("@TBR", SqlDbType.VarChar,20),
					new SqlParameter("@JSDW_SHR", SqlDbType.VarChar,20),
					new SqlParameter("@JLDW_SHR", SqlDbType.VarChar,20),
					new SqlParameter("@SHRQ", SqlDbType.DateTime),
					new SqlParameter("@TJLB", SqlDbType.VarChar,60),
					new SqlParameter("@FPSJ", SqlDbType.DateTime),
					new SqlParameter("@FPR", SqlDbType.VarChar,20),
					new SqlParameter("@SPR", SqlDbType.VarChar,20),
					new SqlParameter("@SPR_DH", SqlDbType.VarChar,20),
					new SqlParameter("@FP_BZ", SqlDbType.VarChar,100),
					new SqlParameter("@fhdj", SqlDbType.VarChar,80),
					new SqlParameter("@kzdj", SqlDbType.VarChar,80),
					new SqlParameter("@sjdw", SqlDbType.VarChar,80),
					new SqlParameter("@jldw", SqlDbType.VarChar,80),
					new SqlParameter("@wzz", SqlDbType.Int,8),
					new SqlParameter("@fsts", SqlDbType.VarChar,50),
					new SqlParameter("@cws", SqlDbType.VarChar,50),
					new SqlParameter("@xmzj", SqlDbType.VarChar,50),
					new SqlParameter("@jldwshr", SqlDbType.VarChar,50),
					new SqlParameter("@fz", SqlDbType.VarChar,200),
					new SqlParameter("@gcys", SqlDbType.VarChar,50),
					new SqlParameter("@bgyfmj", SqlDbType.VarChar,50),
					new SqlParameter("@gczl", SqlDbType.VarChar,50),
					new SqlParameter("@xcjl", SqlDbType.VarChar,50),
					new SqlParameter("@xmjl", SqlDbType.VarChar,50),
					new SqlParameter("@jsdwshr", SqlDbType.VarChar,50)};
            parameters[0].Value = model.SingleProjectID;
            parameters[1].Value = model.jzmj;
            parameters[2].Value = model.gd;
            parameters[3].Value = model.dxcs;
            parameters[4].Value = model.dscs;
            parameters[5].Value = model.jglx;
            parameters[6].Value = model.kgsj;
            parameters[7].Value = model.jgsj;
            parameters[8].Value = model.gczj;
            parameters[9].Value = model.gcjs;
            parameters[10].Value = model.ajs;
            parameters[11].Value = model.wz;
            parameters[12].Value = model.tzj;
            parameters[13].Value = model.tzz;
            parameters[14].Value = model.dt;
            parameters[15].Value = model.zp;
            parameters[16].Value = model.dp;
            parameters[17].Value = model.ly;
            parameters[18].Value = model.lx;
            parameters[19].Value = model.gp;
            parameters[20].Value = model.cd;
            parameters[21].Value = model.cp;
            parameters[22].Value = model.swz;
            parameters[23].Value = model.qt;
            parameters[24].Value = model.mj;
            parameters[25].Value = model.jgrq;
            parameters[26].Value = model.yjdw;
            parameters[27].Value = model.swh;
            parameters[28].Value = model.cfwz;
            parameters[29].Value = model.note;
            parameters[30].Value = model.ds;
            parameters[31].Value = model.swp;
            parameters[32].Value = model.lrr;
            parameters[33].Value = model.lrsj;
            parameters[34].Value = model.zrsbh;
            parameters[35].Value = model.lxr;
            parameters[36].Value = model.lxdh;
            parameters[37].Value = model.gisid;
            parameters[38].Value = model.ywzd;
            parameters[39].Value = model.ghxkzh;
            parameters[40].Value = model.sgxkzh;
            parameters[41].Value = model.zlaqjddw;
            parameters[42].Value = model.zlyj;
            parameters[43].Value = model.gc_code;
            parameters[44].Value = model.ydxkzh;
            parameters[45].Value = model.ydghxkzh;
            parameters[46].Value = model.HJQK;
            parameters[47].Value = model.ZZMJ;
            parameters[48].Value = model.BBYFMJ;
            parameters[49].Value = model.SYYFMJ;
            parameters[50].Value = model.CFMJ;
            parameters[51].Value = model.DXSMJ;
            parameters[52].Value = model.RFMJ;
            parameters[53].Value = model.QTYFMJ;
            parameters[54].Value = model.DSGYTS;
            parameters[55].Value = model.TJTS1;
            parameters[56].Value = model.TJTS2;
            parameters[57].Value = model.TJTS3;
            parameters[58].Value = model.TJTS4;
            parameters[59].Value = model.zts;
            parameters[60].Value = model.SJDW_XMFZR;
            parameters[61].Value = model.KCDW;
            parameters[62].Value = model.KCDW_XMFZR;
            parameters[63].Value = model.JLDW_XMFZR;
            parameters[64].Value = model.SGDW_XMJL;
            parameters[65].Value = model.ZJLGCS;
            parameters[66].Value = model.ZYJLGCS;
            parameters[67].Value = model.FBDW;
            parameters[68].Value = model.FBDW_XMJL;
            parameters[69].Value = model.FBDW_1;
            parameters[70].Value = model.FBDW_1_XMJL;
            parameters[71].Value = model.ZYGZ;
            parameters[72].Value = model.XMZYZLJCY;
            parameters[73].Value = model.SGBZZ;
            parameters[74].Value = model.TBR;
            parameters[75].Value = model.JSDW_SHR;
            parameters[76].Value = model.JLDW_SHR;
            parameters[77].Value = model.SHRQ;
            parameters[78].Value = model.TJLB;
            parameters[79].Value = model.FPSJ;
            parameters[80].Value = model.FPR;
            parameters[81].Value = model.SPR;
            parameters[82].Value = model.SPR_DH;
            parameters[83].Value = model.FP_BZ;
            parameters[84].Value = model.fhdj;
            parameters[85].Value = model.kzdj;
            parameters[86].Value = model.sjdw;
            parameters[87].Value = model.jldw;
            parameters[88].Value = model.wzz;
            parameters[89].Value = model.fsts;
            parameters[90].Value = model.cws;
            parameters[91].Value = model.xmzj;
            parameters[92].Value = model.jldwshr;
            parameters[93].Value = model.fz;
            parameters[94].Value = model.gcys;
            parameters[95].Value = model.bgyfmj;
            parameters[96].Value = model.gczl;
            parameters[97].Value = model.xcjl;
            parameters[98].Value = model.xmjl;
            parameters[99].Value = model.jsdwshr;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(DigiPower.Onlinecol.Standard.Model.a_single_project_MDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update a_single_project set ");
            strSql.Append("jzmj=@jzmj,");
            strSql.Append("gd=@gd,");
            strSql.Append("dxcs=@dxcs,");
            strSql.Append("dscs=@dscs,");
            strSql.Append("jglx=@jglx,");
            strSql.Append("kgsj=@kgsj,");
            strSql.Append("jgsj=@jgsj,");
            strSql.Append("gczj=@gczj,");
            strSql.Append("gcjs=@gcjs,");
            strSql.Append("ajs=@ajs,");
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
            strSql.Append("swz=@swz,");
            strSql.Append("qt=@qt,");
            strSql.Append("mj=@mj,");
            strSql.Append("jgrq=@jgrq,");
            strSql.Append("yjdw=@yjdw,");
            strSql.Append("swh=@swh,");
            strSql.Append("cfwz=@cfwz,");
            strSql.Append("note=@note,");
            strSql.Append("ds=@ds,");
            strSql.Append("swp=@swp,");
            strSql.Append("lrr=@lrr,");
            strSql.Append("lrsj=@lrsj,");
            strSql.Append("zrsbh=@zrsbh,");
            strSql.Append("lxr=@lxr,");
            strSql.Append("lxdh=@lxdh,");
            strSql.Append("gisid=@gisid,");
            strSql.Append("ywzd=@ywzd,");
            strSql.Append("ghxkzh=@ghxkzh,");
            strSql.Append("sgxkzh=@sgxkzh,");
            strSql.Append("zlaqjddw=@zlaqjddw,");
            strSql.Append("zlyj=@zlyj,");
            strSql.Append("gc_code=@gc_code,");
            strSql.Append("ydxkzh=@ydxkzh,");
            strSql.Append("ydghxkzh=@ydghxkzh,");
            strSql.Append("HJQK=@HJQK,");
            strSql.Append("ZZMJ=@ZZMJ,");
            strSql.Append("BBYFMJ=@BBYFMJ,");
            strSql.Append("SYYFMJ=@SYYFMJ,");
            strSql.Append("CFMJ=@CFMJ,");
            strSql.Append("DXSMJ=@DXSMJ,");
            strSql.Append("RFMJ=@RFMJ,");
            strSql.Append("QTYFMJ=@QTYFMJ,");
            strSql.Append("DSGYTS=@DSGYTS,");
            strSql.Append("TJTS1=@TJTS1,");
            strSql.Append("TJTS2=@TJTS2,");
            strSql.Append("TJTS3=@TJTS3,");
            strSql.Append("TJTS4=@TJTS4,");
            strSql.Append("zts=@zts,");
            strSql.Append("SJDW_XMFZR=@SJDW_XMFZR,");
            strSql.Append("KCDW=@KCDW,");
            strSql.Append("KCDW_XMFZR=@KCDW_XMFZR,");
            strSql.Append("JLDW_XMFZR=@JLDW_XMFZR,");
            strSql.Append("SGDW_XMJL=@SGDW_XMJL,");
            strSql.Append("ZJLGCS=@ZJLGCS,");
            strSql.Append("ZYJLGCS=@ZYJLGCS,");
            strSql.Append("FBDW=@FBDW,");
            strSql.Append("FBDW_XMJL=@FBDW_XMJL,");
            strSql.Append("FBDW_1=@FBDW_1,");
            strSql.Append("FBDW_1_XMJL=@FBDW_1_XMJL,");
            strSql.Append("ZYGZ=@ZYGZ,");
            strSql.Append("XMZYZLJCY=@XMZYZLJCY,");
            strSql.Append("SGBZZ=@SGBZZ,");
            strSql.Append("TBR=@TBR,");
            strSql.Append("JSDW_SHR=@JSDW_SHR,");
            strSql.Append("JLDW_SHR=@JLDW_SHR,");
            strSql.Append("SHRQ=@SHRQ,");
            strSql.Append("TJLB=@TJLB,");
            strSql.Append("FPSJ=@FPSJ,");
            strSql.Append("FPR=@FPR,");
            strSql.Append("SPR=@SPR,");
            strSql.Append("SPR_DH=@SPR_DH,");
            strSql.Append("FP_BZ=@FP_BZ,");
            strSql.Append("fhdj=@fhdj,");
            strSql.Append("kzdj=@kzdj,");
            strSql.Append("sjdw=@sjdw,");
            strSql.Append("jldw=@jldw,");
            strSql.Append("wzz=@wzz,");
            strSql.Append("fsts=@fsts,");
            strSql.Append("cws=@cws,");
            strSql.Append("xmzj=@xmzj,");
            strSql.Append("jldwshr=@jldwshr,");
            strSql.Append("fz=@fz,");
            strSql.Append("gcys=@gcys,");
            strSql.Append("bgyfmj=@bgyfmj,");
            strSql.Append("gczl=@gczl,");
            strSql.Append("xcjl=@xcjl,");
            strSql.Append("xmjl=@xmjl,");
            strSql.Append("jsdwshr=@jsdwshr");
            strSql.Append(" where SingleProjectID=@SingleProjectID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SingleProjectID", SqlDbType.Int,8),
					new SqlParameter("@jzmj", SqlDbType.Decimal,9),
					new SqlParameter("@gd", SqlDbType.Decimal,9),
					new SqlParameter("@dxcs", SqlDbType.VarChar,20),
					new SqlParameter("@dscs", SqlDbType.VarChar,20),
					new SqlParameter("@jglx", SqlDbType.VarChar,40),
					new SqlParameter("@kgsj", SqlDbType.DateTime),
					new SqlParameter("@jgsj", SqlDbType.DateTime),
					new SqlParameter("@gczj", SqlDbType.Decimal,9),
					new SqlParameter("@gcjs", SqlDbType.Decimal,9),
					new SqlParameter("@ajs", SqlDbType.Int,8),
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
					new SqlParameter("@swz", SqlDbType.Int,8),
					new SqlParameter("@qt", SqlDbType.Int,8),
					new SqlParameter("@mj", SqlDbType.VarChar,10),
					new SqlParameter("@jgrq", SqlDbType.DateTime),
					new SqlParameter("@yjdw", SqlDbType.VarChar,80),
					new SqlParameter("@swh", SqlDbType.VarChar,60),
					new SqlParameter("@cfwz", SqlDbType.VarChar,20),
					new SqlParameter("@note", SqlDbType.VarChar,100),
					new SqlParameter("@ds", SqlDbType.Int,8),
					new SqlParameter("@swp", SqlDbType.Int,8),
					new SqlParameter("@lrr", SqlDbType.VarChar,10),
					new SqlParameter("@lrsj", SqlDbType.DateTime),
					new SqlParameter("@zrsbh", SqlDbType.VarChar,20),
					new SqlParameter("@lxr", SqlDbType.VarChar,20),
					new SqlParameter("@lxdh", SqlDbType.VarChar,30),
					new SqlParameter("@gisid", SqlDbType.Int,8),
					new SqlParameter("@ywzd", SqlDbType.Int,8),
					new SqlParameter("@ghxkzh", SqlDbType.VarChar,80),
					new SqlParameter("@sgxkzh", SqlDbType.VarChar,80),
					new SqlParameter("@zlaqjddw", SqlDbType.VarChar,80),
					new SqlParameter("@zlyj", SqlDbType.VarChar,1),
					new SqlParameter("@gc_code", SqlDbType.VarChar,20),
					new SqlParameter("@ydxkzh", SqlDbType.VarChar,80),
					new SqlParameter("@ydghxkzh", SqlDbType.VarChar,80),
					new SqlParameter("@HJQK", SqlDbType.VarChar,60),
					new SqlParameter("@ZZMJ", SqlDbType.Decimal,9),
					new SqlParameter("@BBYFMJ", SqlDbType.Decimal,9),
					new SqlParameter("@SYYFMJ", SqlDbType.Decimal,9),
					new SqlParameter("@CFMJ", SqlDbType.Decimal,9),
					new SqlParameter("@DXSMJ", SqlDbType.Decimal,9),
					new SqlParameter("@RFMJ", SqlDbType.Decimal,9),
					new SqlParameter("@QTYFMJ", SqlDbType.Decimal,9),
					new SqlParameter("@DSGYTS", SqlDbType.Int,8),
					new SqlParameter("@TJTS1", SqlDbType.Int,8),
					new SqlParameter("@TJTS2", SqlDbType.Int,8),
					new SqlParameter("@TJTS3", SqlDbType.Int,8),
					new SqlParameter("@TJTS4", SqlDbType.Int,8),
					new SqlParameter("@zts", SqlDbType.Int,8),
					new SqlParameter("@SJDW_XMFZR", SqlDbType.VarChar,20),
					new SqlParameter("@KCDW", SqlDbType.VarChar,80),
					new SqlParameter("@KCDW_XMFZR", SqlDbType.VarChar,20),
					new SqlParameter("@JLDW_XMFZR", SqlDbType.VarChar,20),
					new SqlParameter("@SGDW_XMJL", SqlDbType.VarChar,20),
					new SqlParameter("@ZJLGCS", SqlDbType.VarChar,20),
					new SqlParameter("@ZYJLGCS", SqlDbType.VarChar,20),
					new SqlParameter("@FBDW", SqlDbType.VarChar,80),
					new SqlParameter("@FBDW_XMJL", SqlDbType.VarChar,20),
					new SqlParameter("@FBDW_1", SqlDbType.VarChar,80),
					new SqlParameter("@FBDW_1_XMJL", SqlDbType.VarChar,20),
					new SqlParameter("@ZYGZ", SqlDbType.VarChar,20),
					new SqlParameter("@XMZYZLJCY", SqlDbType.VarChar,20),
					new SqlParameter("@SGBZZ", SqlDbType.VarChar,20),
					new SqlParameter("@TBR", SqlDbType.VarChar,20),
					new SqlParameter("@JSDW_SHR", SqlDbType.VarChar,20),
					new SqlParameter("@JLDW_SHR", SqlDbType.VarChar,20),
					new SqlParameter("@SHRQ", SqlDbType.DateTime),
					new SqlParameter("@TJLB", SqlDbType.VarChar,60),
					new SqlParameter("@FPSJ", SqlDbType.DateTime),
					new SqlParameter("@FPR", SqlDbType.VarChar,20),
					new SqlParameter("@SPR", SqlDbType.VarChar,20),
					new SqlParameter("@SPR_DH", SqlDbType.VarChar,20),
					new SqlParameter("@FP_BZ", SqlDbType.VarChar,100),
					new SqlParameter("@fhdj", SqlDbType.VarChar,80),
					new SqlParameter("@kzdj", SqlDbType.VarChar,80),
					new SqlParameter("@sjdw", SqlDbType.VarChar,80),
					new SqlParameter("@jldw", SqlDbType.VarChar,80),
					new SqlParameter("@wzz", SqlDbType.Int,8),
					new SqlParameter("@fsts", SqlDbType.VarChar,50),
					new SqlParameter("@cws", SqlDbType.VarChar,50),
					new SqlParameter("@xmzj", SqlDbType.VarChar,50),
					new SqlParameter("@jldwshr", SqlDbType.VarChar,50),
					new SqlParameter("@fz", SqlDbType.VarChar,200),
					new SqlParameter("@gcys", SqlDbType.VarChar,50),
					new SqlParameter("@bgyfmj", SqlDbType.VarChar,50),
					new SqlParameter("@gczl", SqlDbType.VarChar,50),
					new SqlParameter("@xcjl", SqlDbType.VarChar,50),
					new SqlParameter("@xmjl", SqlDbType.VarChar,50),
					new SqlParameter("@jsdwshr", SqlDbType.VarChar,50)};
            parameters[0].Value = model.SingleProjectID;
            parameters[1].Value = model.jzmj;
            parameters[2].Value = model.gd;
            parameters[3].Value = model.dxcs;
            parameters[4].Value = model.dscs;
            parameters[5].Value = model.jglx;
            parameters[6].Value = model.kgsj;
            parameters[7].Value = model.jgsj;
            parameters[8].Value = model.gczj;
            parameters[9].Value = model.gcjs;
            parameters[10].Value = model.ajs;
            parameters[11].Value = model.wz;
            parameters[12].Value = model.tzj;
            parameters[13].Value = model.tzz;
            parameters[14].Value = model.dt;
            parameters[15].Value = model.zp;
            parameters[16].Value = model.dp;
            parameters[17].Value = model.ly;
            parameters[18].Value = model.lx;
            parameters[19].Value = model.gp;
            parameters[20].Value = model.cd;
            parameters[21].Value = model.cp;
            parameters[22].Value = model.swz;
            parameters[23].Value = model.qt;
            parameters[24].Value = model.mj;
            parameters[25].Value = model.jgrq;
            parameters[26].Value = model.yjdw;
            parameters[27].Value = model.swh;
            parameters[28].Value = model.cfwz;
            parameters[29].Value = model.note;
            parameters[30].Value = model.ds;
            parameters[31].Value = model.swp;
            parameters[32].Value = model.lrr;
            parameters[33].Value = model.lrsj;
            parameters[34].Value = model.zrsbh;
            parameters[35].Value = model.lxr;
            parameters[36].Value = model.lxdh;
            parameters[37].Value = model.gisid;
            parameters[38].Value = model.ywzd;
            parameters[39].Value = model.ghxkzh;
            parameters[40].Value = model.sgxkzh;
            parameters[41].Value = model.zlaqjddw;
            parameters[42].Value = model.zlyj;
            parameters[43].Value = model.gc_code;
            parameters[44].Value = model.ydxkzh;
            parameters[45].Value = model.ydghxkzh;
            parameters[46].Value = model.HJQK;
            parameters[47].Value = model.ZZMJ;
            parameters[48].Value = model.BBYFMJ;
            parameters[49].Value = model.SYYFMJ;
            parameters[50].Value = model.CFMJ;
            parameters[51].Value = model.DXSMJ;
            parameters[52].Value = model.RFMJ;
            parameters[53].Value = model.QTYFMJ;
            parameters[54].Value = model.DSGYTS;
            parameters[55].Value = model.TJTS1;
            parameters[56].Value = model.TJTS2;
            parameters[57].Value = model.TJTS3;
            parameters[58].Value = model.TJTS4;
            parameters[59].Value = model.zts;
            parameters[60].Value = model.SJDW_XMFZR;
            parameters[61].Value = model.KCDW;
            parameters[62].Value = model.KCDW_XMFZR;
            parameters[63].Value = model.JLDW_XMFZR;
            parameters[64].Value = model.SGDW_XMJL;
            parameters[65].Value = model.ZJLGCS;
            parameters[66].Value = model.ZYJLGCS;
            parameters[67].Value = model.FBDW;
            parameters[68].Value = model.FBDW_XMJL;
            parameters[69].Value = model.FBDW_1;
            parameters[70].Value = model.FBDW_1_XMJL;
            parameters[71].Value = model.ZYGZ;
            parameters[72].Value = model.XMZYZLJCY;
            parameters[73].Value = model.SGBZZ;
            parameters[74].Value = model.TBR;
            parameters[75].Value = model.JSDW_SHR;
            parameters[76].Value = model.JLDW_SHR;
            parameters[77].Value = model.SHRQ;
            parameters[78].Value = model.TJLB;
            parameters[79].Value = model.FPSJ;
            parameters[80].Value = model.FPR;
            parameters[81].Value = model.SPR;
            parameters[82].Value = model.SPR_DH;
            parameters[83].Value = model.FP_BZ;
            parameters[84].Value = model.fhdj;
            parameters[85].Value = model.kzdj;
            parameters[86].Value = model.sjdw;
            parameters[87].Value = model.jldw;
            parameters[88].Value = model.wzz;
            parameters[89].Value = model.fsts;
            parameters[90].Value = model.cws;
            parameters[91].Value = model.xmzj;
            parameters[92].Value = model.jldwshr;
            parameters[93].Value = model.fz;
            parameters[94].Value = model.gcys;
            parameters[95].Value = model.bgyfmj;
            parameters[96].Value = model.gczl;
            parameters[97].Value = model.xcjl;
            parameters[98].Value = model.xmjl;
            parameters[99].Value = model.jsdwshr;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int SingleProjectID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from a_single_project ");
            strSql.Append(" where SingleProjectID=@SingleProjectID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SingleProjectID", SqlDbType.Int,8)};
            parameters[0].Value = SingleProjectID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.a_single_project_MDL GetModel(int SingleProjectID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SingleProjectID,jzmj,gd,dxcs,dscs,jglx,kgsj,jgsj,gczj,gcjs,ajs,wz,tzj,tzz,dt,zp,dp,ly,lx,gp,cd,cp,swz,qt,mj,jgrq,yjdw,swh,cfwz,note,ds,swp,lrr,lrsj,zrsbh,lxr,lxdh,gisid,ywzd,ghxkzh,sgxkzh,zlaqjddw,zlyj,gc_code,ydxkzh,ydghxkzh,HJQK,ZZMJ,BBYFMJ,SYYFMJ,CFMJ,DXSMJ,RFMJ,QTYFMJ,DSGYTS,TJTS1,TJTS2,TJTS3,TJTS4,zts,SJDW_XMFZR,KCDW,KCDW_XMFZR,JLDW_XMFZR,SGDW_XMJL,ZJLGCS,ZYJLGCS,FBDW,FBDW_XMJL,FBDW_1,FBDW_1_XMJL,ZYGZ,XMZYZLJCY,SGBZZ,TBR,JSDW_SHR,JLDW_SHR,SHRQ,TJLB,FPSJ,FPR,SPR,SPR_DH,FP_BZ,fhdj,kzdj,sjdw,jldw,wzz,fsts,cws,xmzj,jldwshr,fz,gcys,bgyfmj,gczl,xcjl,xmjl,jsdwshr from a_single_project ");
            strSql.Append(" where SingleProjectID=@SingleProjectID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SingleProjectID", SqlDbType.Int,8)};
            parameters[0].Value = SingleProjectID;

            DigiPower.Onlinecol.Standard.Model.a_single_project_MDL model = new DigiPower.Onlinecol.Standard.Model.a_single_project_MDL();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SingleProjectID"].ToString() != "")
                {
                    model.SingleProjectID = int.Parse(ds.Tables[0].Rows[0]["SingleProjectID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["jzmj"].ToString() != "")
                {
                    model.jzmj = decimal.Parse(ds.Tables[0].Rows[0]["jzmj"].ToString());
                }
                if (ds.Tables[0].Rows[0]["gd"].ToString() != "")
                {
                    model.gd = decimal.Parse(ds.Tables[0].Rows[0]["gd"].ToString());
                }
                model.dxcs = ds.Tables[0].Rows[0]["dxcs"].ToString();
                model.dscs = ds.Tables[0].Rows[0]["dscs"].ToString();
                model.jglx = ds.Tables[0].Rows[0]["jglx"].ToString();
                if (ds.Tables[0].Rows[0]["kgsj"].ToString() != "")
                {
                    model.kgsj = DateTime.Parse(ds.Tables[0].Rows[0]["kgsj"].ToString());
                }
                if (ds.Tables[0].Rows[0]["jgsj"].ToString() != "")
                {
                    model.jgsj = DateTime.Parse(ds.Tables[0].Rows[0]["jgsj"].ToString());
                }
                if (ds.Tables[0].Rows[0]["gczj"].ToString() != "")
                {
                    model.gczj = decimal.Parse(ds.Tables[0].Rows[0]["gczj"].ToString());
                }
                if (ds.Tables[0].Rows[0]["gcjs"].ToString() != "")
                {
                    model.gcjs = decimal.Parse(ds.Tables[0].Rows[0]["gcjs"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ajs"].ToString() != "")
                {
                    model.ajs = int.Parse(ds.Tables[0].Rows[0]["ajs"].ToString());
                }
                if (ds.Tables[0].Rows[0]["wz"].ToString() != "")
                {
                    model.wz = int.Parse(ds.Tables[0].Rows[0]["wz"].ToString());
                }
                if (ds.Tables[0].Rows[0]["tzj"].ToString() != "")
                {
                    model.tzj = int.Parse(ds.Tables[0].Rows[0]["tzj"].ToString());
                }
                if (ds.Tables[0].Rows[0]["tzz"].ToString() != "")
                {
                    model.tzz = int.Parse(ds.Tables[0].Rows[0]["tzz"].ToString());
                }
                if (ds.Tables[0].Rows[0]["dt"].ToString() != "")
                {
                    model.dt = int.Parse(ds.Tables[0].Rows[0]["dt"].ToString());
                }
                if (ds.Tables[0].Rows[0]["zp"].ToString() != "")
                {
                    model.zp = int.Parse(ds.Tables[0].Rows[0]["zp"].ToString());
                }
                if (ds.Tables[0].Rows[0]["dp"].ToString() != "")
                {
                    model.dp = int.Parse(ds.Tables[0].Rows[0]["dp"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ly"].ToString() != "")
                {
                    model.ly = int.Parse(ds.Tables[0].Rows[0]["ly"].ToString());
                }
                if (ds.Tables[0].Rows[0]["lx"].ToString() != "")
                {
                    model.lx = int.Parse(ds.Tables[0].Rows[0]["lx"].ToString());
                }
                if (ds.Tables[0].Rows[0]["gp"].ToString() != "")
                {
                    model.gp = int.Parse(ds.Tables[0].Rows[0]["gp"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cd"].ToString() != "")
                {
                    model.cd = int.Parse(ds.Tables[0].Rows[0]["cd"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cp"].ToString() != "")
                {
                    model.cp = int.Parse(ds.Tables[0].Rows[0]["cp"].ToString());
                }
                if (ds.Tables[0].Rows[0]["swz"].ToString() != "")
                {
                    model.swz = int.Parse(ds.Tables[0].Rows[0]["swz"].ToString());
                }
                if (ds.Tables[0].Rows[0]["qt"].ToString() != "")
                {
                    model.qt = int.Parse(ds.Tables[0].Rows[0]["qt"].ToString());
                }
                model.mj = ds.Tables[0].Rows[0]["mj"].ToString();
                if (ds.Tables[0].Rows[0]["jgrq"].ToString() != "")
                {
                    model.jgrq = DateTime.Parse(ds.Tables[0].Rows[0]["jgrq"].ToString());
                }
                model.yjdw = ds.Tables[0].Rows[0]["yjdw"].ToString();
                model.swh = ds.Tables[0].Rows[0]["swh"].ToString();
                model.cfwz = ds.Tables[0].Rows[0]["cfwz"].ToString();
                model.note = ds.Tables[0].Rows[0]["note"].ToString();
                if (ds.Tables[0].Rows[0]["ds"].ToString() != "")
                {
                    model.ds = int.Parse(ds.Tables[0].Rows[0]["ds"].ToString());
                }
                if (ds.Tables[0].Rows[0]["swp"].ToString() != "")
                {
                    model.swp = int.Parse(ds.Tables[0].Rows[0]["swp"].ToString());
                }
                model.lrr = ds.Tables[0].Rows[0]["lrr"].ToString();
                if (ds.Tables[0].Rows[0]["lrsj"].ToString() != "")
                {
                    model.lrsj = DateTime.Parse(ds.Tables[0].Rows[0]["lrsj"].ToString());
                }
                model.zrsbh = ds.Tables[0].Rows[0]["zrsbh"].ToString();
                model.lxr = ds.Tables[0].Rows[0]["lxr"].ToString();
                model.lxdh = ds.Tables[0].Rows[0]["lxdh"].ToString();
                if (ds.Tables[0].Rows[0]["gisid"].ToString() != "")
                {
                    model.gisid = int.Parse(ds.Tables[0].Rows[0]["gisid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ywzd"].ToString() != "")
                {
                    model.ywzd = int.Parse(ds.Tables[0].Rows[0]["ywzd"].ToString());
                }
                model.ghxkzh = ds.Tables[0].Rows[0]["ghxkzh"].ToString();
                model.sgxkzh = ds.Tables[0].Rows[0]["sgxkzh"].ToString();
                model.zlaqjddw = ds.Tables[0].Rows[0]["zlaqjddw"].ToString();
                model.zlyj = ds.Tables[0].Rows[0]["zlyj"].ToString();
                model.gc_code = ds.Tables[0].Rows[0]["gc_code"].ToString();
                model.ydxkzh = ds.Tables[0].Rows[0]["ydxkzh"].ToString();
                model.ydghxkzh = ds.Tables[0].Rows[0]["ydghxkzh"].ToString();
                model.HJQK = ds.Tables[0].Rows[0]["HJQK"].ToString();
                if (ds.Tables[0].Rows[0]["ZZMJ"].ToString() != "")
                {
                    model.ZZMJ = decimal.Parse(ds.Tables[0].Rows[0]["ZZMJ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BBYFMJ"].ToString() != "")
                {
                    model.BBYFMJ = decimal.Parse(ds.Tables[0].Rows[0]["BBYFMJ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SYYFMJ"].ToString() != "")
                {
                    model.SYYFMJ = decimal.Parse(ds.Tables[0].Rows[0]["SYYFMJ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CFMJ"].ToString() != "")
                {
                    model.CFMJ = decimal.Parse(ds.Tables[0].Rows[0]["CFMJ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DXSMJ"].ToString() != "")
                {
                    model.DXSMJ = decimal.Parse(ds.Tables[0].Rows[0]["DXSMJ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RFMJ"].ToString() != "")
                {
                    model.RFMJ = decimal.Parse(ds.Tables[0].Rows[0]["RFMJ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["QTYFMJ"].ToString() != "")
                {
                    model.QTYFMJ = decimal.Parse(ds.Tables[0].Rows[0]["QTYFMJ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DSGYTS"].ToString() != "")
                {
                    model.DSGYTS = int.Parse(ds.Tables[0].Rows[0]["DSGYTS"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TJTS1"].ToString() != "")
                {
                    model.TJTS1 = int.Parse(ds.Tables[0].Rows[0]["TJTS1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TJTS2"].ToString() != "")
                {
                    model.TJTS2 = int.Parse(ds.Tables[0].Rows[0]["TJTS2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TJTS3"].ToString() != "")
                {
                    model.TJTS3 = int.Parse(ds.Tables[0].Rows[0]["TJTS3"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TJTS4"].ToString() != "")
                {
                    model.TJTS4 = int.Parse(ds.Tables[0].Rows[0]["TJTS4"].ToString());
                }
                if (ds.Tables[0].Rows[0]["zts"].ToString() != "")
                {
                    model.zts = int.Parse(ds.Tables[0].Rows[0]["zts"].ToString());
                }
                model.SJDW_XMFZR = ds.Tables[0].Rows[0]["SJDW_XMFZR"].ToString();
                model.KCDW = ds.Tables[0].Rows[0]["KCDW"].ToString();
                model.KCDW_XMFZR = ds.Tables[0].Rows[0]["KCDW_XMFZR"].ToString();
                model.JLDW_XMFZR = ds.Tables[0].Rows[0]["JLDW_XMFZR"].ToString();
                model.SGDW_XMJL = ds.Tables[0].Rows[0]["SGDW_XMJL"].ToString();
                model.ZJLGCS = ds.Tables[0].Rows[0]["ZJLGCS"].ToString();
                model.ZYJLGCS = ds.Tables[0].Rows[0]["ZYJLGCS"].ToString();
                model.FBDW = ds.Tables[0].Rows[0]["FBDW"].ToString();
                model.FBDW_XMJL = ds.Tables[0].Rows[0]["FBDW_XMJL"].ToString();
                model.FBDW_1 = ds.Tables[0].Rows[0]["FBDW_1"].ToString();
                model.FBDW_1_XMJL = ds.Tables[0].Rows[0]["FBDW_1_XMJL"].ToString();
                model.ZYGZ = ds.Tables[0].Rows[0]["ZYGZ"].ToString();
                model.XMZYZLJCY = ds.Tables[0].Rows[0]["XMZYZLJCY"].ToString();
                model.SGBZZ = ds.Tables[0].Rows[0]["SGBZZ"].ToString();
                model.TBR = ds.Tables[0].Rows[0]["TBR"].ToString();
                model.JSDW_SHR = ds.Tables[0].Rows[0]["JSDW_SHR"].ToString();
                model.JLDW_SHR = ds.Tables[0].Rows[0]["JLDW_SHR"].ToString();
                if (ds.Tables[0].Rows[0]["SHRQ"].ToString() != "")
                {
                    model.SHRQ = DateTime.Parse(ds.Tables[0].Rows[0]["SHRQ"].ToString());
                }
                model.TJLB = ds.Tables[0].Rows[0]["TJLB"].ToString();
                if (ds.Tables[0].Rows[0]["FPSJ"].ToString() != "")
                {
                    model.FPSJ = DateTime.Parse(ds.Tables[0].Rows[0]["FPSJ"].ToString());
                }
                model.FPR = ds.Tables[0].Rows[0]["FPR"].ToString();
                model.SPR = ds.Tables[0].Rows[0]["SPR"].ToString();
                model.SPR_DH = ds.Tables[0].Rows[0]["SPR_DH"].ToString();
                model.FP_BZ = ds.Tables[0].Rows[0]["FP_BZ"].ToString();
                model.fhdj = ds.Tables[0].Rows[0]["fhdj"].ToString();
                model.kzdj = ds.Tables[0].Rows[0]["kzdj"].ToString();
                model.sjdw = ds.Tables[0].Rows[0]["sjdw"].ToString();
                model.jldw = ds.Tables[0].Rows[0]["jldw"].ToString();
                if (ds.Tables[0].Rows[0]["wzz"].ToString() != "")
                {
                    model.wzz = int.Parse(ds.Tables[0].Rows[0]["wzz"].ToString());
                }
                model.fsts = ds.Tables[0].Rows[0]["fsts"].ToString();
                model.cws = ds.Tables[0].Rows[0]["cws"].ToString();
                model.xmzj = ds.Tables[0].Rows[0]["xmzj"].ToString();
                model.jldwshr = ds.Tables[0].Rows[0]["jldwshr"].ToString();
                model.fz = ds.Tables[0].Rows[0]["fz"].ToString();
                model.gcys = ds.Tables[0].Rows[0]["gcys"].ToString();
                model.bgyfmj = ds.Tables[0].Rows[0]["bgyfmj"].ToString();
                model.gczl = ds.Tables[0].Rows[0]["gczl"].ToString();
                model.xcjl = ds.Tables[0].Rows[0]["xcjl"].ToString();
                model.xmjl = ds.Tables[0].Rows[0]["xmjl"].ToString();
                model.jsdwshr = ds.Tables[0].Rows[0]["jsdwshr"].ToString();
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SingleProjectID,jzmj,gd,dxcs,dscs,jglx,kgsj,jgsj,gczj,gcjs,ajs,wz,tzj,tzz,dt,zp,dp,ly,lx,gp,cd,cp,swz,qt,mj,jgrq,yjdw,swh,cfwz,note,ds,swp,lrr,lrsj,zrsbh,lxr,lxdh,gisid,ywzd,ghxkzh,sgxkzh,zlaqjddw,zlyj,gc_code,ydxkzh,ydghxkzh,HJQK,ZZMJ,BBYFMJ,SYYFMJ,CFMJ,DXSMJ,RFMJ,QTYFMJ,DSGYTS,TJTS1,TJTS2,TJTS3,TJTS4,zts,SJDW_XMFZR,KCDW,KCDW_XMFZR,JLDW_XMFZR,SGDW_XMJL,ZJLGCS,ZYJLGCS,FBDW,FBDW_XMJL,FBDW_1,FBDW_1_XMJL,ZYGZ,XMZYZLJCY,SGBZZ,TBR,JSDW_SHR,JLDW_SHR,SHRQ,TJLB,FPSJ,FPR,SPR,SPR_DH,FP_BZ,fhdj,kzdj,sjdw,jldw,wzz,fsts,cws,xmzj,jldwshr,fz,gcys,bgyfmj,gczl,xcjl,xmjl,jsdwshr ");
            strSql.Append(" FROM a_single_project ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" SingleProjectID,jzmj,gd,dxcs,dscs,jglx,kgsj,jgsj,gczj,gcjs,ajs,wz,tzj,tzz,dt,zp,dp,ly,lx,gp,cd,cp,swz,qt,mj,jgrq,yjdw,swh,cfwz,note,ds,swp,lrr,lrsj,zrsbh,lxr,lxdh,gisid,ywzd,ghxkzh,sgxkzh,zlaqjddw,zlyj,gc_code,ydxkzh,ydghxkzh,HJQK,ZZMJ,BBYFMJ,SYYFMJ,CFMJ,DXSMJ,RFMJ,QTYFMJ,DSGYTS,TJTS1,TJTS2,TJTS3,TJTS4,zts,SJDW_XMFZR,KCDW,KCDW_XMFZR,JLDW_XMFZR,SGDW_XMJL,ZJLGCS,ZYJLGCS,FBDW,FBDW_XMJL,FBDW_1,FBDW_1_XMJL,ZYGZ,XMZYZLJCY,SGBZZ,TBR,JSDW_SHR,JLDW_SHR,SHRQ,TJLB,FPSJ,FPR,SPR,SPR_DH,FP_BZ,fhdj,kzdj,sjdw,jldw,wzz,fsts,cws,xmzj,jldwshr,fz,gcys,bgyfmj,gczl,xcjl,xmjl,jsdwshr ");
            strSql.Append(" FROM a_single_project ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            parameters[0].Value = "a_single_project";
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

