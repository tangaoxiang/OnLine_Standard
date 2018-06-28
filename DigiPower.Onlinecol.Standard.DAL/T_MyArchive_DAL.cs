using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;
using System.Collections.Generic;
using System.Collections;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL
{
    /// <summary>
    /// 数据访问类T_MyArchive_DAL。
    /// </summary>
    public class T_MyArchive_DAL
    {
        public T_MyArchive_DAL()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ArchiveID", "T_MyArchive");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ArchiveID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_MyArchive");
            strSql.Append(" where ArchiveID=@ArchiveID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ArchiveID", SqlDbType.Int,8)};
            parameters[0].Value = ArchiveID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_MyArchive_MDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_MyArchive(");
            strSql.Append("SingleProjectID,CompanyID,area_code,dh,xh,archive_form_no,dz_k,dz_l,dz_g,dz_c,dz_x,ajtm,bzdw,ztlx,sl,dw,gg,qssj,zzsj,bgqx,mj,ztc,note,lrr,lrsj,wz,tzz,dt,zp,dp,ly,lx,gp,cd,cp,sw0,sw1,qt,jk,jdh,zlr,zlrq,shyj,shr,shsj,yjqk,yjr,yjsj,rksh_jsqk,rksh_jssj,jgrq,jsr,ajlx,zajh,jsdw,sgdw,sjdw,gcmc,gcdd,kcdw,jldw,zjs,zajs,djj,dkbh,xmbh,tfh,sjdwfzr,pzwh,jzmd,rjl,jzmj,ydmj,lhl,ghxz,wz_dz,wz_xz,wz_nz,wz_bz,pz_zn,pz_zy,hh,ydghxkzh,ydghxkzh_fzjg,ydghxkzh_fzrq,ghxkzh,ghxkzh_fzjg,ghxkzh_fzrq,tdyt,ydxz,kcqy,blz,tfck,cffs,zbxt,gcxt,tzje,yddw,yjdw,fdcqzh,fdcqzh_fzjg,fdcqzh_pzrq,sgxkzh,sgxkzh_fzjg,sgxkzh_pzrq,ydm,ydxzh,sw,ShortDH,xzyjsh,xzyjsh_pzrq,jzjg,qy,jzcs,jzgd,tccmj,ztz,zdjh,cfdz,swh,jnwjqssj,jnwjzzsj,ydh,fz,rkflag)");
            strSql.Append(" values (");
            strSql.Append("@SingleProjectID,@CompanyID,@area_code,@dh,@xh,@archive_form_no,@dz_k,@dz_l,@dz_g,@dz_c,@dz_x,@ajtm,@bzdw,@ztlx,@sl,@dw,@gg,@qssj,@zzsj,@bgqx,@mj,@ztc,@note,@lrr,@lrsj,@wz,@tzz,@dt,@zp,@dp,@ly,@lx,@gp,@cd,@cp,@sw0,@sw1,@qt,@jk,@jdh,@zlr,@zlrq,@shyj,@shr,@shsj,@yjqk,@yjr,@yjsj,@rksh_jsqk,@rksh_jssj,@jgrq,@jsr,@ajlx,@zajh,@jsdw,@sgdw,@sjdw,@gcmc,@gcdd,@kcdw,@jldw,@zjs,@zajs,@djj,@dkbh,@xmbh,@tfh,@sjdwfzr,@pzwh,@jzmd,@rjl,@jzmj,@ydmj,@lhl,@ghxz,@wz_dz,@wz_xz,@wz_nz,@wz_bz,@pz_zn,@pz_zy,@hh,@ydghxkzh,@ydghxkzh_fzjg,@ydghxkzh_fzrq,@ghxkzh,@ghxkzh_fzjg,@ghxkzh_fzrq,@tdyt,@ydxz,@kcqy,@blz,@tfck,@cffs,@zbxt,@gcxt,@tzje,@yddw,@yjdw,@fdcqzh,@fdcqzh_fzjg,@fdcqzh_pzrq,@sgxkzh,@sgxkzh_fzjg,@sgxkzh_pzrq,@ydm,@ydxzh,@sw,@ShortDH,@xzyjsh,@xzyjsh_pzrq,@jzjg,@qy,@jzcs,@jzgd,@tccmj,@ztz,@zdjh,@cfdz,@swh,@jnwjqssj,@jnwjzzsj,@ydh,@fz,@rkflag)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@SingleProjectID", SqlDbType.Int,8),
					new SqlParameter("@CompanyID", SqlDbType.Int,8),
					new SqlParameter("@area_code", SqlDbType.VarChar,20),
					new SqlParameter("@dh", SqlDbType.VarChar,30),
					new SqlParameter("@xh", SqlDbType.Int,8),
					new SqlParameter("@archive_form_no", SqlDbType.VarChar,20),
					new SqlParameter("@dz_k", SqlDbType.VarChar,10),
					new SqlParameter("@dz_l", SqlDbType.VarChar,10),
					new SqlParameter("@dz_g", SqlDbType.VarChar,10),
					new SqlParameter("@dz_c", SqlDbType.VarChar,10),
					new SqlParameter("@dz_x", SqlDbType.VarChar,3),
					new SqlParameter("@ajtm", SqlDbType.VarChar,255),
					new SqlParameter("@bzdw", SqlDbType.VarChar,80),
					new SqlParameter("@ztlx", SqlDbType.VarChar,20),
					new SqlParameter("@sl", SqlDbType.Int,8),
					new SqlParameter("@dw", SqlDbType.VarChar,10),
					new SqlParameter("@gg", SqlDbType.VarChar,40),
					new SqlParameter("@qssj", SqlDbType.DateTime),
					new SqlParameter("@zzsj", SqlDbType.DateTime),
					new SqlParameter("@bgqx", SqlDbType.VarChar,20),
					new SqlParameter("@mj", SqlDbType.VarChar,10),
					new SqlParameter("@ztc", SqlDbType.VarChar,255),
					new SqlParameter("@note", SqlDbType.VarChar,200),
					new SqlParameter("@lrr", SqlDbType.VarChar,50),
					new SqlParameter("@lrsj", SqlDbType.DateTime),
					new SqlParameter("@wz", SqlDbType.Int,8),
					new SqlParameter("@tzz", SqlDbType.Int,8),
					new SqlParameter("@dt", SqlDbType.Int,8),
					new SqlParameter("@zp", SqlDbType.Int,8),
					new SqlParameter("@dp", SqlDbType.Int,8),
					new SqlParameter("@ly", SqlDbType.Int,8),
					new SqlParameter("@lx", SqlDbType.Int,8),
					new SqlParameter("@gp", SqlDbType.Int,8),
					new SqlParameter("@cd", SqlDbType.Int,8),
					new SqlParameter("@cp", SqlDbType.Int,8),
					new SqlParameter("@sw0", SqlDbType.Int,8),
					new SqlParameter("@sw1", SqlDbType.Int,8),
					new SqlParameter("@qt", SqlDbType.Int,8),
					new SqlParameter("@jk", SqlDbType.Int,8),
					new SqlParameter("@jdh", SqlDbType.VarChar,30),
					new SqlParameter("@zlr", SqlDbType.VarChar,20),
					new SqlParameter("@zlrq", SqlDbType.DateTime),
					new SqlParameter("@shyj", SqlDbType.Text),
					new SqlParameter("@shr", SqlDbType.VarChar,20),
					new SqlParameter("@shsj", SqlDbType.DateTime),
					new SqlParameter("@yjqk", SqlDbType.VarChar,200),
					new SqlParameter("@yjr", SqlDbType.VarChar,20),
					new SqlParameter("@yjsj", SqlDbType.DateTime),
					new SqlParameter("@rksh_jsqk", SqlDbType.VarChar,200),
					new SqlParameter("@rksh_jssj", SqlDbType.DateTime),
					new SqlParameter("@jgrq", SqlDbType.DateTime),
					new SqlParameter("@jsr", SqlDbType.VarChar,20),
					new SqlParameter("@ajlx", SqlDbType.VarChar,10),
					new SqlParameter("@zajh", SqlDbType.VarChar,20),
					new SqlParameter("@jsdw", SqlDbType.VarChar,100),
					new SqlParameter("@sgdw", SqlDbType.VarChar,100),
					new SqlParameter("@sjdw", SqlDbType.VarChar,100),
					new SqlParameter("@gcmc", SqlDbType.VarChar,100),
					new SqlParameter("@gcdd", SqlDbType.VarChar,100),
					new SqlParameter("@kcdw", SqlDbType.VarChar,100),
					new SqlParameter("@jldw", SqlDbType.VarChar,100),
					new SqlParameter("@zjs", SqlDbType.Int,8),
					new SqlParameter("@zajs", SqlDbType.Int,8),
					new SqlParameter("@djj", SqlDbType.Int,8),
					new SqlParameter("@dkbh", SqlDbType.VarChar,30),
					new SqlParameter("@xmbh", SqlDbType.VarChar,30),
					new SqlParameter("@tfh", SqlDbType.VarChar,30),
					new SqlParameter("@sjdwfzr", SqlDbType.VarChar,30),
					new SqlParameter("@pzwh", SqlDbType.VarChar,30),
					new SqlParameter("@jzmd", SqlDbType.VarChar,20),
					new SqlParameter("@rjl", SqlDbType.VarChar,20),
					new SqlParameter("@jzmj", SqlDbType.Decimal,9),
					new SqlParameter("@ydmj", SqlDbType.Decimal,9),
					new SqlParameter("@lhl", SqlDbType.Decimal,5),
					new SqlParameter("@ghxz", SqlDbType.VarChar,30),
					new SqlParameter("@wz_dz", SqlDbType.VarChar,100),
					new SqlParameter("@wz_xz", SqlDbType.VarChar,100),
					new SqlParameter("@wz_nz", SqlDbType.VarChar,100),
					new SqlParameter("@wz_bz", SqlDbType.VarChar,100),
					new SqlParameter("@pz_zn", SqlDbType.Int,8),
					new SqlParameter("@pz_zy", SqlDbType.Int,8),
					new SqlParameter("@hh", SqlDbType.VarChar,30),
					new SqlParameter("@ydghxkzh", SqlDbType.VarChar,40),
					new SqlParameter("@ydghxkzh_fzjg", SqlDbType.VarChar,100),
					new SqlParameter("@ydghxkzh_fzrq", SqlDbType.DateTime),
					new SqlParameter("@ghxkzh", SqlDbType.VarChar,40),
					new SqlParameter("@ghxkzh_fzjg", SqlDbType.VarChar,100),
					new SqlParameter("@ghxkzh_fzrq", SqlDbType.DateTime),
					new SqlParameter("@tdyt", SqlDbType.VarChar,40),
					new SqlParameter("@ydxz", SqlDbType.VarChar,40),
					new SqlParameter("@kcqy", SqlDbType.VarChar,30),
					new SqlParameter("@blz", SqlDbType.VarChar,30),
					new SqlParameter("@tfck", SqlDbType.VarChar,30),
					new SqlParameter("@cffs", SqlDbType.VarChar,20),
					new SqlParameter("@zbxt", SqlDbType.VarChar,30),
					new SqlParameter("@gcxt", SqlDbType.VarChar,30),
					new SqlParameter("@tzje", SqlDbType.Decimal,9),
					new SqlParameter("@yddw", SqlDbType.VarChar,80),
					new SqlParameter("@yjdw", SqlDbType.VarChar,100),
					new SqlParameter("@fdcqzh", SqlDbType.VarChar,60),
					new SqlParameter("@fdcqzh_fzjg", SqlDbType.VarChar,100),
					new SqlParameter("@fdcqzh_pzrq", SqlDbType.DateTime),
					new SqlParameter("@sgxkzh", SqlDbType.VarChar,60),
					new SqlParameter("@sgxkzh_fzjg", SqlDbType.VarChar,100),
					new SqlParameter("@sgxkzh_pzrq", SqlDbType.DateTime),
					new SqlParameter("@ydm", SqlDbType.VarChar,100),
					new SqlParameter("@ydxzh", SqlDbType.VarChar,60),
					new SqlParameter("@sw", SqlDbType.VarChar,30),
					new SqlParameter("@ShortDH", SqlDbType.VarChar,30),
					new SqlParameter("@xzyjsh", SqlDbType.VarChar,255),
					new SqlParameter("@xzyjsh_pzrq", SqlDbType.DateTime),
					new SqlParameter("@jzjg", SqlDbType.VarChar,255),
					new SqlParameter("@qy", SqlDbType.VarChar,255),
					new SqlParameter("@jzcs", SqlDbType.Int,8),
					new SqlParameter("@jzgd", SqlDbType.Decimal,9),
					new SqlParameter("@tccmj", SqlDbType.Decimal,9),
					new SqlParameter("@ztz", SqlDbType.Money,8),
					new SqlParameter("@zdjh", SqlDbType.VarChar,20),
					new SqlParameter("@cfdz", SqlDbType.VarChar,100),
					new SqlParameter("@swh", SqlDbType.VarChar,20),
					new SqlParameter("@jnwjqssj", SqlDbType.VarChar,10),
					new SqlParameter("@jnwjzzsj", SqlDbType.VarChar,50),
					new SqlParameter("@ydh", SqlDbType.VarChar,20),
					new SqlParameter("@fz", SqlDbType.Text),
					new SqlParameter("@rkflag", SqlDbType.Bit,1)};
            parameters[0].Value = model.SingleProjectID;
            parameters[1].Value = model.CompanyID;
            parameters[2].Value = model.area_code;
            parameters[3].Value = model.dh;
            parameters[4].Value = model.xh;
            parameters[5].Value = model.archive_form_no;
            parameters[6].Value = model.dz_k;
            parameters[7].Value = model.dz_l;
            parameters[8].Value = model.dz_g;
            parameters[9].Value = model.dz_c;
            parameters[10].Value = model.dz_x;
            parameters[11].Value = model.ajtm;
            parameters[12].Value = model.bzdw;
            parameters[13].Value = model.ztlx;
            parameters[14].Value = model.sl;
            parameters[15].Value = model.dw;
            parameters[16].Value = model.gg;
            parameters[17].Value = model.qssj;
            parameters[18].Value = model.zzsj;
            parameters[19].Value = model.bgqx;
            parameters[20].Value = model.mj;
            parameters[21].Value = model.ztc;
            parameters[22].Value = model.note;
            parameters[23].Value = model.lrr;
            parameters[24].Value = model.lrsj;
            parameters[25].Value = model.wz;
            parameters[26].Value = model.tzz;
            parameters[27].Value = model.dt;
            parameters[28].Value = model.zp;
            parameters[29].Value = model.dp;
            parameters[30].Value = model.ly;
            parameters[31].Value = model.lx;
            parameters[32].Value = model.gp;
            parameters[33].Value = model.cd;
            parameters[34].Value = model.cp;
            parameters[35].Value = model.sw0;
            parameters[36].Value = model.sw1;
            parameters[37].Value = model.qt;
            parameters[38].Value = model.jk;
            parameters[39].Value = model.jdh;
            parameters[40].Value = model.zlr;
            parameters[41].Value = model.zlrq;
            parameters[42].Value = model.shyj;
            parameters[43].Value = model.shr;
            parameters[44].Value = model.shsj;
            parameters[45].Value = model.yjqk;
            parameters[46].Value = model.yjr;
            parameters[47].Value = model.yjsj;
            parameters[48].Value = model.rksh_jsqk;
            parameters[49].Value = model.rksh_jssj;
            parameters[50].Value = model.jgrq;
            parameters[51].Value = model.jsr;
            parameters[52].Value = model.ajlx;
            parameters[53].Value = model.zajh;
            parameters[54].Value = model.jsdw;
            parameters[55].Value = model.sgdw;
            parameters[56].Value = model.sjdw;
            parameters[57].Value = model.gcmc;
            parameters[58].Value = model.gcdd;
            parameters[59].Value = model.kcdw;
            parameters[60].Value = model.jldw;
            parameters[61].Value = model.zjs;
            parameters[62].Value = model.zajs;
            parameters[63].Value = model.djj;
            parameters[64].Value = model.dkbh;
            parameters[65].Value = model.xmbh;
            parameters[66].Value = model.tfh;
            parameters[67].Value = model.sjdwfzr;
            parameters[68].Value = model.pzwh;
            parameters[69].Value = model.jzmd;
            parameters[70].Value = model.rjl;
            parameters[71].Value = model.jzmj;
            parameters[72].Value = model.ydmj;
            parameters[73].Value = model.lhl;
            parameters[74].Value = model.ghxz;
            parameters[75].Value = model.wz_dz;
            parameters[76].Value = model.wz_xz;
            parameters[77].Value = model.wz_nz;
            parameters[78].Value = model.wz_bz;
            parameters[79].Value = model.pz_zn;
            parameters[80].Value = model.pz_zy;
            parameters[81].Value = model.hh;
            parameters[82].Value = model.ydghxkzh;
            parameters[83].Value = model.ydghxkzh_fzjg;
            parameters[84].Value = model.ydghxkzh_fzrq;
            parameters[85].Value = model.ghxkzh;
            parameters[86].Value = model.ghxkzh_fzjg;
            parameters[87].Value = model.ghxkzh_fzrq;
            parameters[88].Value = model.tdyt;
            parameters[89].Value = model.ydxz;
            parameters[90].Value = model.kcqy;
            parameters[91].Value = model.blz;
            parameters[92].Value = model.tfck;
            parameters[93].Value = model.cffs;
            parameters[94].Value = model.zbxt;
            parameters[95].Value = model.gcxt;
            parameters[96].Value = model.tzje;
            parameters[97].Value = model.yddw;
            parameters[98].Value = model.yjdw;
            parameters[99].Value = model.fdcqzh;
            parameters[100].Value = model.fdcqzh_fzjg;
            parameters[101].Value = model.fdcqzh_pzrq;
            parameters[102].Value = model.sgxkzh;
            parameters[103].Value = model.sgxkzh_fzjg;
            parameters[104].Value = model.sgxkzh_pzrq;
            parameters[105].Value = model.ydm;
            parameters[106].Value = model.ydxzh;
            parameters[107].Value = model.sw;
            parameters[108].Value = model.ShortDH;
            parameters[109].Value = model.xzyjsh;
            parameters[110].Value = model.xzyjsh_pzrq;
            parameters[111].Value = model.jzjg;
            parameters[112].Value = model.qy;
            parameters[113].Value = model.jzcs;
            parameters[114].Value = model.jzgd;
            parameters[115].Value = model.tccmj;
            parameters[116].Value = model.ztz;
            parameters[117].Value = model.zdjh;
            parameters[118].Value = model.cfdz;
            parameters[119].Value = model.swh;
            parameters[120].Value = model.jnwjqssj;
            parameters[121].Value = model.jnwjzzsj;
            parameters[122].Value = model.ydh;
            parameters[123].Value = model.fz;
            parameters[124].Value = model.rkflag;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(DigiPower.Onlinecol.Standard.Model.T_MyArchive_MDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_MyArchive set ");
            strSql.Append("SingleProjectID=@SingleProjectID,");
            strSql.Append("CompanyID=@CompanyID,");
            strSql.Append("area_code=@area_code,");
            strSql.Append("dh=@dh,");
            strSql.Append("xh=@xh,");
            strSql.Append("archive_form_no=@archive_form_no,");
            strSql.Append("dz_k=@dz_k,");
            strSql.Append("dz_l=@dz_l,");
            strSql.Append("dz_g=@dz_g,");
            strSql.Append("dz_c=@dz_c,");
            strSql.Append("dz_x=@dz_x,");
            strSql.Append("ajtm=@ajtm,");
            strSql.Append("bzdw=@bzdw,");
            strSql.Append("ztlx=@ztlx,");
            strSql.Append("sl=@sl,");
            strSql.Append("dw=@dw,");
            strSql.Append("gg=@gg,");
            strSql.Append("qssj=@qssj,");
            strSql.Append("zzsj=@zzsj,");
            strSql.Append("bgqx=@bgqx,");
            strSql.Append("mj=@mj,");
            strSql.Append("ztc=@ztc,");
            strSql.Append("note=@note,");
            strSql.Append("lrr=@lrr,");
            strSql.Append("lrsj=@lrsj,");
            strSql.Append("wz=@wz,");
            strSql.Append("tzz=@tzz,");
            strSql.Append("dt=@dt,");
            strSql.Append("zp=@zp,");
            strSql.Append("dp=@dp,");
            strSql.Append("ly=@ly,");
            strSql.Append("lx=@lx,");
            strSql.Append("gp=@gp,");
            strSql.Append("cd=@cd,");
            strSql.Append("cp=@cp,");
            strSql.Append("sw0=@sw0,");
            strSql.Append("sw1=@sw1,");
            strSql.Append("qt=@qt,");
            strSql.Append("jk=@jk,");
            strSql.Append("jdh=@jdh,");
            strSql.Append("zlr=@zlr,");
            strSql.Append("zlrq=@zlrq,");
            strSql.Append("shyj=@shyj,");
            strSql.Append("shr=@shr,");
            strSql.Append("shsj=@shsj,");
            strSql.Append("yjqk=@yjqk,");
            strSql.Append("yjr=@yjr,");
            strSql.Append("yjsj=@yjsj,");
            strSql.Append("rksh_jsqk=@rksh_jsqk,");
            strSql.Append("rksh_jssj=@rksh_jssj,");
            strSql.Append("jgrq=@jgrq,");
            strSql.Append("jsr=@jsr,");
            strSql.Append("ajlx=@ajlx,");
            strSql.Append("zajh=@zajh,");
            strSql.Append("jsdw=@jsdw,");
            strSql.Append("sgdw=@sgdw,");
            strSql.Append("sjdw=@sjdw,");
            strSql.Append("gcmc=@gcmc,");
            strSql.Append("gcdd=@gcdd,");
            strSql.Append("kcdw=@kcdw,");
            strSql.Append("jldw=@jldw,");
            strSql.Append("zjs=@zjs,");
            strSql.Append("zajs=@zajs,");
            strSql.Append("djj=@djj,");
            strSql.Append("dkbh=@dkbh,");
            strSql.Append("xmbh=@xmbh,");
            strSql.Append("tfh=@tfh,");
            strSql.Append("sjdwfzr=@sjdwfzr,");
            strSql.Append("pzwh=@pzwh,");
            strSql.Append("jzmd=@jzmd,");
            strSql.Append("rjl=@rjl,");
            strSql.Append("jzmj=@jzmj,");
            strSql.Append("ydmj=@ydmj,");
            strSql.Append("lhl=@lhl,");
            strSql.Append("ghxz=@ghxz,");
            strSql.Append("wz_dz=@wz_dz,");
            strSql.Append("wz_xz=@wz_xz,");
            strSql.Append("wz_nz=@wz_nz,");
            strSql.Append("wz_bz=@wz_bz,");
            strSql.Append("pz_zn=@pz_zn,");
            strSql.Append("pz_zy=@pz_zy,");
            strSql.Append("hh=@hh,");
            strSql.Append("ydghxkzh=@ydghxkzh,");
            strSql.Append("ydghxkzh_fzjg=@ydghxkzh_fzjg,");
            strSql.Append("ydghxkzh_fzrq=@ydghxkzh_fzrq,");
            strSql.Append("ghxkzh=@ghxkzh,");
            strSql.Append("ghxkzh_fzjg=@ghxkzh_fzjg,");
            strSql.Append("ghxkzh_fzrq=@ghxkzh_fzrq,");
            strSql.Append("tdyt=@tdyt,");
            strSql.Append("ydxz=@ydxz,");
            strSql.Append("kcqy=@kcqy,");
            strSql.Append("blz=@blz,");
            strSql.Append("tfck=@tfck,");
            strSql.Append("cffs=@cffs,");
            strSql.Append("zbxt=@zbxt,");
            strSql.Append("gcxt=@gcxt,");
            strSql.Append("tzje=@tzje,");
            strSql.Append("yddw=@yddw,");
            strSql.Append("yjdw=@yjdw,");
            strSql.Append("fdcqzh=@fdcqzh,");
            strSql.Append("fdcqzh_fzjg=@fdcqzh_fzjg,");
            strSql.Append("fdcqzh_pzrq=@fdcqzh_pzrq,");
            strSql.Append("sgxkzh=@sgxkzh,");
            strSql.Append("sgxkzh_fzjg=@sgxkzh_fzjg,");
            strSql.Append("sgxkzh_pzrq=@sgxkzh_pzrq,");
            strSql.Append("ydm=@ydm,");
            strSql.Append("ydxzh=@ydxzh,");
            strSql.Append("sw=@sw,");
            strSql.Append("ShortDH=@ShortDH,");
            strSql.Append("xzyjsh=@xzyjsh,");
            strSql.Append("xzyjsh_pzrq=@xzyjsh_pzrq,");
            strSql.Append("jzjg=@jzjg,");
            strSql.Append("qy=@qy,");
            strSql.Append("jzcs=@jzcs,");
            strSql.Append("jzgd=@jzgd,");
            strSql.Append("tccmj=@tccmj,");
            strSql.Append("ztz=@ztz,");
            strSql.Append("zdjh=@zdjh,");
            strSql.Append("cfdz=@cfdz,");
            strSql.Append("swh=@swh,");
            strSql.Append("jnwjqssj=@jnwjqssj,");
            strSql.Append("jnwjzzsj=@jnwjzzsj,");
            strSql.Append("ydh=@ydh,");
            strSql.Append("fz=@fz,");
            strSql.Append("rkflag=@rkflag");
            strSql.Append(" where ArchiveID=@ArchiveID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ArchiveID", SqlDbType.Int,8),
					new SqlParameter("@SingleProjectID", SqlDbType.Int,8),
					new SqlParameter("@CompanyID", SqlDbType.Int,8),
					new SqlParameter("@area_code", SqlDbType.VarChar,20),
					new SqlParameter("@dh", SqlDbType.VarChar,30),
					new SqlParameter("@xh", SqlDbType.Int,8),
					new SqlParameter("@archive_form_no", SqlDbType.VarChar,20),
					new SqlParameter("@dz_k", SqlDbType.VarChar,10),
					new SqlParameter("@dz_l", SqlDbType.VarChar,10),
					new SqlParameter("@dz_g", SqlDbType.VarChar,10),
					new SqlParameter("@dz_c", SqlDbType.VarChar,10),
					new SqlParameter("@dz_x", SqlDbType.VarChar,3),
					new SqlParameter("@ajtm", SqlDbType.VarChar,255),
					new SqlParameter("@bzdw", SqlDbType.VarChar,80),
					new SqlParameter("@ztlx", SqlDbType.VarChar,20),
					new SqlParameter("@sl", SqlDbType.Int,8),
					new SqlParameter("@dw", SqlDbType.VarChar,10),
					new SqlParameter("@gg", SqlDbType.VarChar,40),
					new SqlParameter("@qssj", SqlDbType.DateTime),
					new SqlParameter("@zzsj", SqlDbType.DateTime),
					new SqlParameter("@bgqx", SqlDbType.VarChar,20),
					new SqlParameter("@mj", SqlDbType.VarChar,10),
					new SqlParameter("@ztc", SqlDbType.VarChar,255),
					new SqlParameter("@note", SqlDbType.VarChar,200),
					new SqlParameter("@lrr", SqlDbType.VarChar,50),
					new SqlParameter("@lrsj", SqlDbType.DateTime),
					new SqlParameter("@wz", SqlDbType.Int,8),
					new SqlParameter("@tzz", SqlDbType.Int,8),
					new SqlParameter("@dt", SqlDbType.Int,8),
					new SqlParameter("@zp", SqlDbType.Int,8),
					new SqlParameter("@dp", SqlDbType.Int,8),
					new SqlParameter("@ly", SqlDbType.Int,8),
					new SqlParameter("@lx", SqlDbType.Int,8),
					new SqlParameter("@gp", SqlDbType.Int,8),
					new SqlParameter("@cd", SqlDbType.Int,8),
					new SqlParameter("@cp", SqlDbType.Int,8),
					new SqlParameter("@sw0", SqlDbType.Int,8),
					new SqlParameter("@sw1", SqlDbType.Int,8),
					new SqlParameter("@qt", SqlDbType.Int,8),
					new SqlParameter("@jk", SqlDbType.Int,8),
					new SqlParameter("@jdh", SqlDbType.VarChar,30),
					new SqlParameter("@zlr", SqlDbType.VarChar,20),
					new SqlParameter("@zlrq", SqlDbType.DateTime),
					new SqlParameter("@shyj", SqlDbType.Text),
					new SqlParameter("@shr", SqlDbType.VarChar,20),
					new SqlParameter("@shsj", SqlDbType.DateTime),
					new SqlParameter("@yjqk", SqlDbType.VarChar,200),
					new SqlParameter("@yjr", SqlDbType.VarChar,20),
					new SqlParameter("@yjsj", SqlDbType.DateTime),
					new SqlParameter("@rksh_jsqk", SqlDbType.VarChar,200),
					new SqlParameter("@rksh_jssj", SqlDbType.DateTime),
					new SqlParameter("@jgrq", SqlDbType.DateTime),
					new SqlParameter("@jsr", SqlDbType.VarChar,20),
					new SqlParameter("@ajlx", SqlDbType.VarChar,10),
					new SqlParameter("@zajh", SqlDbType.VarChar,20),
					new SqlParameter("@jsdw", SqlDbType.VarChar,100),
					new SqlParameter("@sgdw", SqlDbType.VarChar,100),
					new SqlParameter("@sjdw", SqlDbType.VarChar,100),
					new SqlParameter("@gcmc", SqlDbType.VarChar,100),
					new SqlParameter("@gcdd", SqlDbType.VarChar,100),
					new SqlParameter("@kcdw", SqlDbType.VarChar,100),
					new SqlParameter("@jldw", SqlDbType.VarChar,100),
					new SqlParameter("@zjs", SqlDbType.Int,8),
					new SqlParameter("@zajs", SqlDbType.Int,8),
					new SqlParameter("@djj", SqlDbType.Int,8),
					new SqlParameter("@dkbh", SqlDbType.VarChar,30),
					new SqlParameter("@xmbh", SqlDbType.VarChar,30),
					new SqlParameter("@tfh", SqlDbType.VarChar,30),
					new SqlParameter("@sjdwfzr", SqlDbType.VarChar,30),
					new SqlParameter("@pzwh", SqlDbType.VarChar,30),
					new SqlParameter("@jzmd", SqlDbType.VarChar,20),
					new SqlParameter("@rjl", SqlDbType.VarChar,20),
					new SqlParameter("@jzmj", SqlDbType.Decimal,9),
					new SqlParameter("@ydmj", SqlDbType.Decimal,9),
					new SqlParameter("@lhl", SqlDbType.Decimal,5),
					new SqlParameter("@ghxz", SqlDbType.VarChar,30),
					new SqlParameter("@wz_dz", SqlDbType.VarChar,100),
					new SqlParameter("@wz_xz", SqlDbType.VarChar,100),
					new SqlParameter("@wz_nz", SqlDbType.VarChar,100),
					new SqlParameter("@wz_bz", SqlDbType.VarChar,100),
					new SqlParameter("@pz_zn", SqlDbType.Int,8),
					new SqlParameter("@pz_zy", SqlDbType.Int,8),
					new SqlParameter("@hh", SqlDbType.VarChar,30),
					new SqlParameter("@ydghxkzh", SqlDbType.VarChar,40),
					new SqlParameter("@ydghxkzh_fzjg", SqlDbType.VarChar,100),
					new SqlParameter("@ydghxkzh_fzrq", SqlDbType.DateTime),
					new SqlParameter("@ghxkzh", SqlDbType.VarChar,40),
					new SqlParameter("@ghxkzh_fzjg", SqlDbType.VarChar,100),
					new SqlParameter("@ghxkzh_fzrq", SqlDbType.DateTime),
					new SqlParameter("@tdyt", SqlDbType.VarChar,40),
					new SqlParameter("@ydxz", SqlDbType.VarChar,40),
					new SqlParameter("@kcqy", SqlDbType.VarChar,30),
					new SqlParameter("@blz", SqlDbType.VarChar,30),
					new SqlParameter("@tfck", SqlDbType.VarChar,30),
					new SqlParameter("@cffs", SqlDbType.VarChar,20),
					new SqlParameter("@zbxt", SqlDbType.VarChar,30),
					new SqlParameter("@gcxt", SqlDbType.VarChar,30),
					new SqlParameter("@tzje", SqlDbType.Decimal,9),
					new SqlParameter("@yddw", SqlDbType.VarChar,80),
					new SqlParameter("@yjdw", SqlDbType.VarChar,100),
					new SqlParameter("@fdcqzh", SqlDbType.VarChar,60),
					new SqlParameter("@fdcqzh_fzjg", SqlDbType.VarChar,100),
					new SqlParameter("@fdcqzh_pzrq", SqlDbType.DateTime),
					new SqlParameter("@sgxkzh", SqlDbType.VarChar,60),
					new SqlParameter("@sgxkzh_fzjg", SqlDbType.VarChar,100),
					new SqlParameter("@sgxkzh_pzrq", SqlDbType.DateTime),
					new SqlParameter("@ydm", SqlDbType.VarChar,100),
					new SqlParameter("@ydxzh", SqlDbType.VarChar,60),
					new SqlParameter("@sw", SqlDbType.VarChar,30),
					new SqlParameter("@ShortDH", SqlDbType.VarChar,30),
					new SqlParameter("@xzyjsh", SqlDbType.VarChar,255),
					new SqlParameter("@xzyjsh_pzrq", SqlDbType.DateTime),
					new SqlParameter("@jzjg", SqlDbType.VarChar,255),
					new SqlParameter("@qy", SqlDbType.VarChar,255),
					new SqlParameter("@jzcs", SqlDbType.Int,8),
					new SqlParameter("@jzgd", SqlDbType.Decimal,9),
					new SqlParameter("@tccmj", SqlDbType.Decimal,9),
					new SqlParameter("@ztz", SqlDbType.Money,8),
					new SqlParameter("@zdjh", SqlDbType.VarChar,20),
					new SqlParameter("@cfdz", SqlDbType.VarChar,100),
					new SqlParameter("@swh", SqlDbType.VarChar,20),
					new SqlParameter("@jnwjqssj", SqlDbType.VarChar,10),
					new SqlParameter("@jnwjzzsj", SqlDbType.VarChar,50),
					new SqlParameter("@ydh", SqlDbType.VarChar,20),
					new SqlParameter("@fz", SqlDbType.Text),
					new SqlParameter("@rkflag", SqlDbType.Bit,1)};
            parameters[0].Value = model.ArchiveID;
            parameters[1].Value = model.SingleProjectID;
            parameters[2].Value = model.CompanyID;
            parameters[3].Value = model.area_code;
            parameters[4].Value = model.dh;
            parameters[5].Value = model.xh;
            parameters[6].Value = model.archive_form_no;
            parameters[7].Value = model.dz_k;
            parameters[8].Value = model.dz_l;
            parameters[9].Value = model.dz_g;
            parameters[10].Value = model.dz_c;
            parameters[11].Value = model.dz_x;
            parameters[12].Value = model.ajtm;
            parameters[13].Value = model.bzdw;
            parameters[14].Value = model.ztlx;
            parameters[15].Value = model.sl;
            parameters[16].Value = model.dw;
            parameters[17].Value = model.gg;
            parameters[18].Value = model.qssj;
            parameters[19].Value = model.zzsj;
            parameters[20].Value = model.bgqx;
            parameters[21].Value = model.mj;
            parameters[22].Value = model.ztc;
            parameters[23].Value = model.note;
            parameters[24].Value = model.lrr;
            parameters[25].Value = model.lrsj;
            parameters[26].Value = model.wz;
            parameters[27].Value = model.tzz;
            parameters[28].Value = model.dt;
            parameters[29].Value = model.zp;
            parameters[30].Value = model.dp;
            parameters[31].Value = model.ly;
            parameters[32].Value = model.lx;
            parameters[33].Value = model.gp;
            parameters[34].Value = model.cd;
            parameters[35].Value = model.cp;
            parameters[36].Value = model.sw0;
            parameters[37].Value = model.sw1;
            parameters[38].Value = model.qt;
            parameters[39].Value = model.jk;
            parameters[40].Value = model.jdh;
            parameters[41].Value = model.zlr;
            parameters[42].Value = model.zlrq;
            parameters[43].Value = model.shyj;
            parameters[44].Value = model.shr;
            parameters[45].Value = model.shsj;
            parameters[46].Value = model.yjqk;
            parameters[47].Value = model.yjr;
            parameters[48].Value = model.yjsj;
            parameters[49].Value = model.rksh_jsqk;
            parameters[50].Value = model.rksh_jssj;
            parameters[51].Value = model.jgrq;
            parameters[52].Value = model.jsr;
            parameters[53].Value = model.ajlx;
            parameters[54].Value = model.zajh;
            parameters[55].Value = model.jsdw;
            parameters[56].Value = model.sgdw;
            parameters[57].Value = model.sjdw;
            parameters[58].Value = model.gcmc;
            parameters[59].Value = model.gcdd;
            parameters[60].Value = model.kcdw;
            parameters[61].Value = model.jldw;
            parameters[62].Value = model.zjs;
            parameters[63].Value = model.zajs;
            parameters[64].Value = model.djj;
            parameters[65].Value = model.dkbh;
            parameters[66].Value = model.xmbh;
            parameters[67].Value = model.tfh;
            parameters[68].Value = model.sjdwfzr;
            parameters[69].Value = model.pzwh;
            parameters[70].Value = model.jzmd;
            parameters[71].Value = model.rjl;
            parameters[72].Value = model.jzmj;
            parameters[73].Value = model.ydmj;
            parameters[74].Value = model.lhl;
            parameters[75].Value = model.ghxz;
            parameters[76].Value = model.wz_dz;
            parameters[77].Value = model.wz_xz;
            parameters[78].Value = model.wz_nz;
            parameters[79].Value = model.wz_bz;
            parameters[80].Value = model.pz_zn;
            parameters[81].Value = model.pz_zy;
            parameters[82].Value = model.hh;
            parameters[83].Value = model.ydghxkzh;
            parameters[84].Value = model.ydghxkzh_fzjg;
            parameters[85].Value = model.ydghxkzh_fzrq;
            parameters[86].Value = model.ghxkzh;
            parameters[87].Value = model.ghxkzh_fzjg;
            parameters[88].Value = model.ghxkzh_fzrq;
            parameters[89].Value = model.tdyt;
            parameters[90].Value = model.ydxz;
            parameters[91].Value = model.kcqy;
            parameters[92].Value = model.blz;
            parameters[93].Value = model.tfck;
            parameters[94].Value = model.cffs;
            parameters[95].Value = model.zbxt;
            parameters[96].Value = model.gcxt;
            parameters[97].Value = model.tzje;
            parameters[98].Value = model.yddw;
            parameters[99].Value = model.yjdw;
            parameters[100].Value = model.fdcqzh;
            parameters[101].Value = model.fdcqzh_fzjg;
            parameters[102].Value = model.fdcqzh_pzrq;
            parameters[103].Value = model.sgxkzh;
            parameters[104].Value = model.sgxkzh_fzjg;
            parameters[105].Value = model.sgxkzh_pzrq;
            parameters[106].Value = model.ydm;
            parameters[107].Value = model.ydxzh;
            parameters[108].Value = model.sw;
            parameters[109].Value = model.ShortDH;
            parameters[110].Value = model.xzyjsh;
            parameters[111].Value = model.xzyjsh_pzrq;
            parameters[112].Value = model.jzjg;
            parameters[113].Value = model.qy;
            parameters[114].Value = model.jzcs;
            parameters[115].Value = model.jzgd;
            parameters[116].Value = model.tccmj;
            parameters[117].Value = model.ztz;
            parameters[118].Value = model.zdjh;
            parameters[119].Value = model.cfdz;
            parameters[120].Value = model.swh;
            parameters[121].Value = model.jnwjqssj;
            parameters[122].Value = model.jnwjzzsj;
            parameters[123].Value = model.ydh;
            parameters[124].Value = model.fz;
            parameters[125].Value = model.rkflag;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ArchiveID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_MyArchive ");
            strSql.Append(" where ArchiveID=@ArchiveID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ArchiveID", SqlDbType.Int,8)};
            parameters[0].Value = ArchiveID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_MyArchive_MDL GetModel(int ArchiveID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ArchiveID,SingleProjectID,CompanyID,area_code,dh,xh,archive_form_no,dz_k,dz_l,dz_g,dz_c,dz_x,ajtm,bzdw,ztlx,sl,dw,gg,qssj,zzsj,bgqx,mj,ztc,note,lrr,lrsj,wz,tzz,dt,zp,dp,ly,lx,gp,cd,cp,sw0,sw1,qt,jk,jdh,zlr,zlrq,shyj,shr,shsj,yjqk,yjr,yjsj,rksh_jsqk,rksh_jssj,jgrq,jsr,ajlx,zajh,jsdw,sgdw,sjdw,gcmc,gcdd,kcdw,jldw,zjs,zajs,djj,dkbh,xmbh,tfh,sjdwfzr,pzwh,jzmd,rjl,jzmj,ydmj,lhl,ghxz,wz_dz,wz_xz,wz_nz,wz_bz,pz_zn,pz_zy,hh,ydghxkzh,ydghxkzh_fzjg,ydghxkzh_fzrq,ghxkzh,ghxkzh_fzjg,ghxkzh_fzrq,tdyt,ydxz,kcqy,blz,tfck,cffs,zbxt,gcxt,tzje,yddw,yjdw,fdcqzh,fdcqzh_fzjg,fdcqzh_pzrq,sgxkzh,sgxkzh_fzjg,sgxkzh_pzrq,ydm,ydxzh,sw,ShortDH,xzyjsh,xzyjsh_pzrq,jzjg,qy,jzcs,jzgd,tccmj,ztz,zdjh,cfdz,swh,jnwjqssj,jnwjzzsj,ydh,fz,rkflag from T_MyArchive ");
            strSql.Append(" where ArchiveID=@ArchiveID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ArchiveID", SqlDbType.Int,8)};
            parameters[0].Value = ArchiveID;

            DigiPower.Onlinecol.Standard.Model.T_MyArchive_MDL model = new DigiPower.Onlinecol.Standard.Model.T_MyArchive_MDL();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ArchiveID"].ToString() != "")
                {
                    model.ArchiveID = int.Parse(ds.Tables[0].Rows[0]["ArchiveID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SingleProjectID"].ToString() != "")
                {
                    model.SingleProjectID = int.Parse(ds.Tables[0].Rows[0]["SingleProjectID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CompanyID"].ToString() != "")
                {
                    model.CompanyID = int.Parse(ds.Tables[0].Rows[0]["CompanyID"].ToString());
                }
                model.area_code = ds.Tables[0].Rows[0]["area_code"].ToString();
                model.dh = ds.Tables[0].Rows[0]["dh"].ToString();
                if (ds.Tables[0].Rows[0]["xh"].ToString() != "")
                {
                    model.xh = int.Parse(ds.Tables[0].Rows[0]["xh"].ToString());
                }
                model.archive_form_no = ds.Tables[0].Rows[0]["archive_form_no"].ToString();
                model.dz_k = ds.Tables[0].Rows[0]["dz_k"].ToString();
                model.dz_l = ds.Tables[0].Rows[0]["dz_l"].ToString();
                model.dz_g = ds.Tables[0].Rows[0]["dz_g"].ToString();
                model.dz_c = ds.Tables[0].Rows[0]["dz_c"].ToString();
                model.dz_x = ds.Tables[0].Rows[0]["dz_x"].ToString();
                model.ajtm = ds.Tables[0].Rows[0]["ajtm"].ToString();
                model.bzdw = ds.Tables[0].Rows[0]["bzdw"].ToString();
                model.ztlx = ds.Tables[0].Rows[0]["ztlx"].ToString();
                if (ds.Tables[0].Rows[0]["sl"].ToString() != "")
                {
                    model.sl = int.Parse(ds.Tables[0].Rows[0]["sl"].ToString());
                }
                model.dw = ds.Tables[0].Rows[0]["dw"].ToString();
                model.gg = ds.Tables[0].Rows[0]["gg"].ToString();
                if (ds.Tables[0].Rows[0]["qssj"].ToString() != "")
                {
                    model.qssj = DateTime.Parse(ds.Tables[0].Rows[0]["qssj"].ToString());
                }
                if (ds.Tables[0].Rows[0]["zzsj"].ToString() != "")
                {
                    model.zzsj = DateTime.Parse(ds.Tables[0].Rows[0]["zzsj"].ToString());
                }
                model.bgqx = ds.Tables[0].Rows[0]["bgqx"].ToString();
                model.mj = ds.Tables[0].Rows[0]["mj"].ToString();
                model.ztc = ds.Tables[0].Rows[0]["ztc"].ToString();
                model.note = ds.Tables[0].Rows[0]["note"].ToString();
                model.lrr = ds.Tables[0].Rows[0]["lrr"].ToString();
                if (ds.Tables[0].Rows[0]["lrsj"].ToString() != "")
                {
                    model.lrsj = DateTime.Parse(ds.Tables[0].Rows[0]["lrsj"].ToString());
                }
                if (ds.Tables[0].Rows[0]["wz"].ToString() != "")
                {
                    model.wz = int.Parse(ds.Tables[0].Rows[0]["wz"].ToString());
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
                if (ds.Tables[0].Rows[0]["sw0"].ToString() != "")
                {
                    model.sw0 = int.Parse(ds.Tables[0].Rows[0]["sw0"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sw1"].ToString() != "")
                {
                    model.sw1 = int.Parse(ds.Tables[0].Rows[0]["sw1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["qt"].ToString() != "")
                {
                    model.qt = int.Parse(ds.Tables[0].Rows[0]["qt"].ToString());
                }
                if (ds.Tables[0].Rows[0]["jk"].ToString() != "")
                {
                    model.jk = int.Parse(ds.Tables[0].Rows[0]["jk"].ToString());
                }
                model.jdh = ds.Tables[0].Rows[0]["jdh"].ToString();
                model.zlr = ds.Tables[0].Rows[0]["zlr"].ToString();
                if (ds.Tables[0].Rows[0]["zlrq"].ToString() != "")
                {
                    model.zlrq = DateTime.Parse(ds.Tables[0].Rows[0]["zlrq"].ToString());
                }
                model.shyj = ds.Tables[0].Rows[0]["shyj"].ToString();
                model.shr = ds.Tables[0].Rows[0]["shr"].ToString();
                if (ds.Tables[0].Rows[0]["shsj"].ToString() != "")
                {
                    model.shsj = DateTime.Parse(ds.Tables[0].Rows[0]["shsj"].ToString());
                }
                model.yjqk = ds.Tables[0].Rows[0]["yjqk"].ToString();
                model.yjr = ds.Tables[0].Rows[0]["yjr"].ToString();
                if (ds.Tables[0].Rows[0]["yjsj"].ToString() != "")
                {
                    model.yjsj = DateTime.Parse(ds.Tables[0].Rows[0]["yjsj"].ToString());
                }
                model.rksh_jsqk = ds.Tables[0].Rows[0]["rksh_jsqk"].ToString();
                if (ds.Tables[0].Rows[0]["rksh_jssj"].ToString() != "")
                {
                    model.rksh_jssj = DateTime.Parse(ds.Tables[0].Rows[0]["rksh_jssj"].ToString());
                }
                if (ds.Tables[0].Rows[0]["jgrq"].ToString() != "")
                {
                    model.jgrq = DateTime.Parse(ds.Tables[0].Rows[0]["jgrq"].ToString());
                }
                model.jsr = ds.Tables[0].Rows[0]["jsr"].ToString();
                model.ajlx = ds.Tables[0].Rows[0]["ajlx"].ToString();
                model.zajh = ds.Tables[0].Rows[0]["zajh"].ToString();
                model.jsdw = ds.Tables[0].Rows[0]["jsdw"].ToString();
                model.sgdw = ds.Tables[0].Rows[0]["sgdw"].ToString();
                model.sjdw = ds.Tables[0].Rows[0]["sjdw"].ToString();
                model.gcmc = ds.Tables[0].Rows[0]["gcmc"].ToString();
                model.gcdd = ds.Tables[0].Rows[0]["gcdd"].ToString();
                model.kcdw = ds.Tables[0].Rows[0]["kcdw"].ToString();
                model.jldw = ds.Tables[0].Rows[0]["jldw"].ToString();
                if (ds.Tables[0].Rows[0]["zjs"].ToString() != "")
                {
                    model.zjs = int.Parse(ds.Tables[0].Rows[0]["zjs"].ToString());
                }
                if (ds.Tables[0].Rows[0]["zajs"].ToString() != "")
                {
                    model.zajs = int.Parse(ds.Tables[0].Rows[0]["zajs"].ToString());
                }
                if (ds.Tables[0].Rows[0]["djj"].ToString() != "")
                {
                    model.djj = int.Parse(ds.Tables[0].Rows[0]["djj"].ToString());
                }
                model.dkbh = ds.Tables[0].Rows[0]["dkbh"].ToString();
                model.xmbh = ds.Tables[0].Rows[0]["xmbh"].ToString();
                model.tfh = ds.Tables[0].Rows[0]["tfh"].ToString();
                model.sjdwfzr = ds.Tables[0].Rows[0]["sjdwfzr"].ToString();
                model.pzwh = ds.Tables[0].Rows[0]["pzwh"].ToString();
                model.jzmd = ds.Tables[0].Rows[0]["jzmd"].ToString();
                model.rjl = ds.Tables[0].Rows[0]["rjl"].ToString();
                if (ds.Tables[0].Rows[0]["jzmj"].ToString() != "")
                {
                    model.jzmj = decimal.Parse(ds.Tables[0].Rows[0]["jzmj"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ydmj"].ToString() != "")
                {
                    model.ydmj = decimal.Parse(ds.Tables[0].Rows[0]["ydmj"].ToString());
                }
                if (ds.Tables[0].Rows[0]["lhl"].ToString() != "")
                {
                    model.lhl = decimal.Parse(ds.Tables[0].Rows[0]["lhl"].ToString());
                }
                model.ghxz = ds.Tables[0].Rows[0]["ghxz"].ToString();
                model.wz_dz = ds.Tables[0].Rows[0]["wz_dz"].ToString();
                model.wz_xz = ds.Tables[0].Rows[0]["wz_xz"].ToString();
                model.wz_nz = ds.Tables[0].Rows[0]["wz_nz"].ToString();
                model.wz_bz = ds.Tables[0].Rows[0]["wz_bz"].ToString();
                if (ds.Tables[0].Rows[0]["pz_zn"].ToString() != "")
                {
                    model.pz_zn = int.Parse(ds.Tables[0].Rows[0]["pz_zn"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pz_zy"].ToString() != "")
                {
                    model.pz_zy = int.Parse(ds.Tables[0].Rows[0]["pz_zy"].ToString());
                }
                model.hh = ds.Tables[0].Rows[0]["hh"].ToString();
                model.ydghxkzh = ds.Tables[0].Rows[0]["ydghxkzh"].ToString();
                model.ydghxkzh_fzjg = ds.Tables[0].Rows[0]["ydghxkzh_fzjg"].ToString();
                if (ds.Tables[0].Rows[0]["ydghxkzh_fzrq"].ToString() != "")
                {
                    model.ydghxkzh_fzrq = DateTime.Parse(ds.Tables[0].Rows[0]["ydghxkzh_fzrq"].ToString());
                }
                model.ghxkzh = ds.Tables[0].Rows[0]["ghxkzh"].ToString();
                model.ghxkzh_fzjg = ds.Tables[0].Rows[0]["ghxkzh_fzjg"].ToString();
                if (ds.Tables[0].Rows[0]["ghxkzh_fzrq"].ToString() != "")
                {
                    model.ghxkzh_fzrq = DateTime.Parse(ds.Tables[0].Rows[0]["ghxkzh_fzrq"].ToString());
                }
                model.tdyt = ds.Tables[0].Rows[0]["tdyt"].ToString();
                model.ydxz = ds.Tables[0].Rows[0]["ydxz"].ToString();
                model.kcqy = ds.Tables[0].Rows[0]["kcqy"].ToString();
                model.blz = ds.Tables[0].Rows[0]["blz"].ToString();
                model.tfck = ds.Tables[0].Rows[0]["tfck"].ToString();
                model.cffs = ds.Tables[0].Rows[0]["cffs"].ToString();
                model.zbxt = ds.Tables[0].Rows[0]["zbxt"].ToString();
                model.gcxt = ds.Tables[0].Rows[0]["gcxt"].ToString();
                if (ds.Tables[0].Rows[0]["tzje"].ToString() != "")
                {
                    model.tzje = decimal.Parse(ds.Tables[0].Rows[0]["tzje"].ToString());
                }
                model.yddw = ds.Tables[0].Rows[0]["yddw"].ToString();
                model.yjdw = ds.Tables[0].Rows[0]["yjdw"].ToString();
                model.fdcqzh = ds.Tables[0].Rows[0]["fdcqzh"].ToString();
                model.fdcqzh_fzjg = ds.Tables[0].Rows[0]["fdcqzh_fzjg"].ToString();
                if (ds.Tables[0].Rows[0]["fdcqzh_pzrq"].ToString() != "")
                {
                    model.fdcqzh_pzrq = DateTime.Parse(ds.Tables[0].Rows[0]["fdcqzh_pzrq"].ToString());
                }
                model.sgxkzh = ds.Tables[0].Rows[0]["sgxkzh"].ToString();
                model.sgxkzh_fzjg = ds.Tables[0].Rows[0]["sgxkzh_fzjg"].ToString();
                if (ds.Tables[0].Rows[0]["sgxkzh_pzrq"].ToString() != "")
                {
                    model.sgxkzh_pzrq = DateTime.Parse(ds.Tables[0].Rows[0]["sgxkzh_pzrq"].ToString());
                }
                model.ydm = ds.Tables[0].Rows[0]["ydm"].ToString();
                model.ydxzh = ds.Tables[0].Rows[0]["ydxzh"].ToString();
                model.sw = ds.Tables[0].Rows[0]["sw"].ToString();
                model.ShortDH = ds.Tables[0].Rows[0]["ShortDH"].ToString();
                model.xzyjsh = ds.Tables[0].Rows[0]["xzyjsh"].ToString();
                if (ds.Tables[0].Rows[0]["xzyjsh_pzrq"].ToString() != "")
                {
                    model.xzyjsh_pzrq = DateTime.Parse(ds.Tables[0].Rows[0]["xzyjsh_pzrq"].ToString());
                }
                model.jzjg = ds.Tables[0].Rows[0]["jzjg"].ToString();
                model.qy = ds.Tables[0].Rows[0]["qy"].ToString();
                if (ds.Tables[0].Rows[0]["jzcs"].ToString() != "")
                {
                    model.jzcs = int.Parse(ds.Tables[0].Rows[0]["jzcs"].ToString());
                }
                if (ds.Tables[0].Rows[0]["jzgd"].ToString() != "")
                {
                    model.jzgd = decimal.Parse(ds.Tables[0].Rows[0]["jzgd"].ToString());
                }
                if (ds.Tables[0].Rows[0]["tccmj"].ToString() != "")
                {
                    model.tccmj = decimal.Parse(ds.Tables[0].Rows[0]["tccmj"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ztz"].ToString() != "")
                {
                    model.ztz = decimal.Parse(ds.Tables[0].Rows[0]["ztz"].ToString());
                }
                model.zdjh = ds.Tables[0].Rows[0]["zdjh"].ToString();
                model.cfdz = ds.Tables[0].Rows[0]["cfdz"].ToString();
                model.swh = ds.Tables[0].Rows[0]["swh"].ToString();
                model.jnwjqssj = ds.Tables[0].Rows[0]["jnwjqssj"].ToString();
                model.jnwjzzsj = ds.Tables[0].Rows[0]["jnwjzzsj"].ToString();
                model.ydh = ds.Tables[0].Rows[0]["ydh"].ToString();
                model.fz = ds.Tables[0].Rows[0]["fz"].ToString();
                if (ds.Tables[0].Rows[0]["rkflag"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["rkflag"].ToString() == "1") || (ds.Tables[0].Rows[0]["rkflag"].ToString().ToLower() == "true"))
                    {
                        model.rkflag = true;
                    }
                    else
                    {
                        model.rkflag = false;
                    }
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ArchiveID,SingleProjectID,CompanyID,area_code,dh,xh,archive_form_no,dz_k,dz_l,dz_g,dz_c,dz_x,ajtm,bzdw,ztlx,sl,dw,gg,qssj,zzsj,bgqx,mj,ztc,note,lrr,lrsj,wz,tzz,dt,zp,dp,ly,lx,gp,cd,cp,sw0,sw1,qt,jk,jdh,zlr,zlrq,shyj,shr,shsj,yjqk,yjr,yjsj,rksh_jsqk,rksh_jssj,jgrq,jsr,ajlx,zajh,jsdw,sgdw,sjdw,gcmc,gcdd,kcdw,jldw,zjs,zajs,djj,dkbh,xmbh,tfh,sjdwfzr,pzwh,jzmd,rjl,jzmj,ydmj,lhl,ghxz,wz_dz,wz_xz,wz_nz,wz_bz,pz_zn,pz_zy,hh,ydghxkzh,ydghxkzh_fzjg,ydghxkzh_fzrq,ghxkzh,ghxkzh_fzjg,ghxkzh_fzrq,tdyt,ydxz,kcqy,blz,tfck,cffs,zbxt,gcxt,tzje,yddw,yjdw,fdcqzh,fdcqzh_fzjg,fdcqzh_pzrq,sgxkzh,sgxkzh_fzjg,sgxkzh_pzrq,ydm,ydxzh,sw,ShortDH,xzyjsh,xzyjsh_pzrq,jzjg,qy,jzcs,jzgd,tccmj,ztz,zdjh,cfdz,swh,jnwjqssj,jnwjzzsj,ydh,fz,rkflag ");
            strSql.Append(" FROM T_MyArchive ");
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
            strSql.Append(" ArchiveID,SingleProjectID,CompanyID,area_code,dh,xh,archive_form_no,dz_k,dz_l,dz_g,dz_c,dz_x,ajtm,bzdw,ztlx,sl,dw,gg,qssj,zzsj,bgqx,mj,ztc,note,lrr,lrsj,wz,tzz,dt,zp,dp,ly,lx,gp,cd,cp,sw0,sw1,qt,jk,jdh,zlr,zlrq,shyj,shr,shsj,yjqk,yjr,yjsj,rksh_jsqk,rksh_jssj,jgrq,jsr,ajlx,zajh,jsdw,sgdw,sjdw,gcmc,gcdd,kcdw,jldw,zjs,zajs,djj,dkbh,xmbh,tfh,sjdwfzr,pzwh,jzmd,rjl,jzmj,ydmj,lhl,ghxz,wz_dz,wz_xz,wz_nz,wz_bz,pz_zn,pz_zy,hh,ydghxkzh,ydghxkzh_fzjg,ydghxkzh_fzrq,ghxkzh,ghxkzh_fzjg,ghxkzh_fzrq,tdyt,ydxz,kcqy,blz,tfck,cffs,zbxt,gcxt,tzje,yddw,yjdw,fdcqzh,fdcqzh_fzjg,fdcqzh_pzrq,sgxkzh,sgxkzh_fzjg,sgxkzh_pzrq,ydm,ydxzh,sw,ShortDH,xzyjsh,xzyjsh_pzrq,jzjg,qy,jzcs,jzgd,tccmj,ztz,zdjh,cfdz,swh,jnwjqssj,jnwjzzsj,ydh,fz,rkflag ");
            strSql.Append(" FROM T_MyArchive ");
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
            parameters[0].Value = "T_MyArchive";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法



        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere, bool isForeign)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select ArchiveID,ajtm,bzdw,B.SystemInfoName as bgqx,C.SystemInfoName as mj,lrr,lrsj,ajlx,xh,SingleProjectID ");
            strSql.Append("from T_MyArchive as A left join T_SystemInfo as B  on A.bgqx=B.SystemInfoID ");
            strSql.Append("left join  T_SystemInfo as C on A.mj=C.SystemInfoID ");
            strSql.Append("where 1=1 ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }

            strSql.Append("order by A.xh asc ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        ///获取工程下最大案卷序号
        /// </summary>
        /// <param name="SingleProjectID"></param>
        /// <returns></returns>
        public int getMaxArchiveXhBySingleProjectID(string SingleProjectID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select Max(XH) from T_MyArchive where SingleProjectID=" + SingleProjectID);
            object obj = DbHelperSQL.GetSingle(sb.ToString());
            if (obj == null || obj.ToString() == "")
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 更新案卷下的文件序号,以文件编号来默认排序
        /// </summary>
        /// <param name="MyArchiveID">案卷ID</param>
        /// <param name="OrderBy">排序字段,默认  bh asc</param>
        /// <returns></returns>
        public void updateFileOrderIndexByArchiveID(string MyArchiveID, string OrderBy = " bh asc")
        {
            if (!string.IsNullOrWhiteSpace(MyArchiveID))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("update T_FileList SET MyOrderIndex=b.rOrderindex FROM  T_FileList,  ");
                sb.Append("(SELECT FileListID , ROW_NUMBER() over (ORDER BY " + OrderBy + ")*10 rOrderindex   ");
                sb.Append("from T_FileList where MyArchiveID=" + MyArchiveID + ")b WHERE T_FileList.FileListID=b.FileListID AND T_FileList.MyArchiveID=" + MyArchiveID + "  ");
                DbHelperSQL.ExecuteSql(sb.ToString());
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteArchiveMore(string MyArchiveID)
        {
            if (!string.IsNullOrWhiteSpace(MyArchiveID))
            {
                List<string> list = new List<string>();
                list.Add("UPDATE T_FileList SET MyArchiveID=0 where MyArchiveID IN (" + MyArchiveID + ")");
                list.Add("DELETE FROM T_MyArchive WHERE ArchiveID IN (" + MyArchiveID + ")");
                DbHelperSQL.ExecuteSqlTran(list);
            }
        }

        /// <summary>
        /// 获得数据列表 分页
        /// </summary>
        /// <returns></returns>
        public DataTable GetList(string strWhere, int PageSize, int curPage, string PRIMARYKey, string OrderByName, out int recCoun)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select d.gcbm,D.gcmc,A.ArchiveID,A.ShortDH,A.ajtm,A.bzdw,B.SystemInfoName as bgqx,D.ProjectType,");
            strSql.Append("C.SystemInfoName as mj,lrr,lrsj,ajlx,A.xh,A.SingleProjectID,E.SystemInfoName as ajlxname from T_MyArchive as A left join T_SystemInfo as B  ");
            strSql.Append("on A.bgqx=B.SystemInfoID left join T_SystemInfo as E on A.ajlx=E.SystemInfoID left join  T_SystemInfo as C on A.mj=C.SystemInfoID ");
            strSql.Append(" ,T_SingleProject D ");

            strSql.Append("where A.SINGLEPROJECTID=D.SINGLEPROJECTID ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            return PageCtrl.QueryForDataTableSqlServer(strSql.ToString(), PageSize, curPage, PRIMARYKey, OrderByName, out recCoun).Tables[0];
        }
    }
}

