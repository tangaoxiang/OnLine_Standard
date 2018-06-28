using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;
using System.Collections;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL {
    /// <summary>
    /// 数据访问类T_SingleProject_DAL。
    /// </summary>
    public class T_SingleProject_DAL {
        public T_SingleProject_DAL() { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId() {
            return DbHelperSQL.GetMaxID("SingleProjectID", "T_SingleProject");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SingleProjectID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_SingleProject");
            strSql.Append(" where SingleProjectID=@SingleProjectID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SingleProjectID", SqlDbType.Int,8)};
            parameters[0].Value = SingleProjectID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_SingleProject_MDL model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_SingleProject(");
            strSql.Append("ConstructionProjectID,ProjectType,gcmc,gcbm,gcdd,kgsj,jgsj,jsdw,lxpzdw,sjdw,kcdw,sgdw,jldw,ghxkzh,sgxkzh,");
            strSql.Append("ysbah,jgcldw,ghysh,dxth,ghpzdw,yddw,bzdw,lxpzwh,zdh,ydghxkzh,ydxkzh,bsbh,Badw,pzdw,pzrq,pzwh,zjfsyr,ydxmmc,");
            strSql.Append("zdwz,zbxmmc,xmdz,zbdw,zongbdw,dljg,sgxkspdw,CompanyUserID,ChargeUserID,AllotUserID,AllotDate,Status,CreateDate,");
            strSql.Append("TDSYZPic,GHXKZPic,SGXKZPic,DX1,DY1,DX2,DY2,DX3,DY3,DX4,DY4,FX1,FY1,FX2,FY2,FX3,FY3,FX4,FY4,AREA_CODE,");
            strSql.Append("WorkFlow_DoStatus,gcqy,rksj)");

            strSql.Append(" values (");
            strSql.Append("@ConstructionProjectID,@ProjectType,@gcmc,@gcbm,@gcdd,@kgsj,@jgsj,@jsdw,@lxpzdw,@sjdw,@kcdw,@sgdw,@jldw,");
            strSql.Append("@ghxkzh,@sgxkzh,@ysbah,@jgcldw,@ghysh,@dxth,@ghpzdw,@yddw,@bzdw,@lxpzwh,@zdh,@ydghxkzh,@ydxkzh,@bsbh,@Badw,");
            strSql.Append("@pzdw,@pzrq,@pzwh,@zjfsyr,@ydxmmc,@zdwz,@zbxmmc,@xmdz,@zbdw,@zongbdw,@dljg,@sgxkspdw,@CompanyUserID,");
            strSql.Append("@ChargeUserID,@AllotUserID,@AllotDate,@Status,@CreateDate,@TDSYZPic,@GHXKZPic,@SGXKZPic,@DX1,@DY1,");
            strSql.Append("@DX2,@DY2,@DX3,@DY3,@DX4,@DY4,@FX1,@FY1,@FX2,@FY2,@FX3,@FY3,@FX4,@FY4,@AREA_CODE,");
            strSql.Append("@WorkFlow_DoStatus,@gcqy,@rksj)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ConstructionProjectID", SqlDbType.Int,8),
					new SqlParameter("@ProjectType", SqlDbType.NVarChar,100),
					new SqlParameter("@gcmc", SqlDbType.NVarChar,210),
					new SqlParameter("@gcbm", SqlDbType.NVarChar,20),
					new SqlParameter("@gcdd", SqlDbType.NVarChar,210),
					new SqlParameter("@kgsj", SqlDbType.NVarChar,10),
					new SqlParameter("@jgsj", SqlDbType.NVarChar,10),
					new SqlParameter("@jsdw", SqlDbType.NVarChar,210),
					new SqlParameter("@lxpzdw", SqlDbType.NVarChar,210),
					new SqlParameter("@sjdw", SqlDbType.NVarChar,210),
					new SqlParameter("@kcdw", SqlDbType.NVarChar,210),
					new SqlParameter("@sgdw", SqlDbType.NVarChar,210),
					new SqlParameter("@jldw", SqlDbType.NVarChar,210),
					new SqlParameter("@ghxkzh", SqlDbType.NVarChar,160),
					new SqlParameter("@sgxkzh", SqlDbType.NVarChar,160),
					new SqlParameter("@ysbah", SqlDbType.NVarChar,160),
					new SqlParameter("@jgcldw", SqlDbType.NVarChar,210),
					new SqlParameter("@ghysh", SqlDbType.NVarChar,20),
					new SqlParameter("@dxth", SqlDbType.NVarChar,20),
					new SqlParameter("@ghpzdw", SqlDbType.NVarChar,210),
					new SqlParameter("@yddw", SqlDbType.NVarChar,210),
					new SqlParameter("@bzdw", SqlDbType.NVarChar,210),
					new SqlParameter("@lxpzwh", SqlDbType.NVarChar,20),
					new SqlParameter("@zdh", SqlDbType.NVarChar,20),
					new SqlParameter("@ydghxkzh", SqlDbType.NVarChar,20),
					new SqlParameter("@ydxkzh", SqlDbType.NVarChar,20),
					new SqlParameter("@bsbh", SqlDbType.NVarChar,20),
					new SqlParameter("@Badw", SqlDbType.NVarChar,100),
					new SqlParameter("@pzdw", SqlDbType.NVarChar,100),
					new SqlParameter("@pzrq", SqlDbType.NVarChar,20),
					new SqlParameter("@pzwh", SqlDbType.NVarChar,20),
					new SqlParameter("@zjfsyr", SqlDbType.NVarChar,20),
					new SqlParameter("@ydxmmc", SqlDbType.NVarChar,210),
					new SqlParameter("@zdwz", SqlDbType.NVarChar,210),
					new SqlParameter("@zbxmmc", SqlDbType.NVarChar,100),
					new SqlParameter("@xmdz", SqlDbType.NVarChar,100),
					new SqlParameter("@zbdw", SqlDbType.NVarChar,100),
					new SqlParameter("@zongbdw", SqlDbType.NVarChar,100),
					new SqlParameter("@dljg", SqlDbType.NVarChar,100),
					new SqlParameter("@sgxkspdw", SqlDbType.NVarChar,100),
					new SqlParameter("@CompanyUserID", SqlDbType.Int,8),
					new SqlParameter("@ChargeUserID", SqlDbType.Int,8),
					new SqlParameter("@AllotUserID", SqlDbType.Int,8),
					new SqlParameter("@AllotDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,8),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@TDSYZPic", SqlDbType.NVarChar,250),
					new SqlParameter("@GHXKZPic", SqlDbType.NVarChar,250),
					new SqlParameter("@SGXKZPic", SqlDbType.NVarChar,250),
                    new SqlParameter("@DX1", SqlDbType.Float ,8),
                    new SqlParameter("@DY1", SqlDbType.Float ,8),
                    new SqlParameter("@DX2", SqlDbType.Float ,8),
                    new SqlParameter("@DY2", SqlDbType.Float ,8),
                    new SqlParameter("@DX3", SqlDbType.Float ,8),
                    new SqlParameter("@DY3", SqlDbType.Float ,8),
                    new SqlParameter("@DX4", SqlDbType.Float ,8),
                    new SqlParameter("@DY4", SqlDbType.Float ,8),
                    new SqlParameter("@FX1", SqlDbType.Float ,8),
                    new SqlParameter("@FY1", SqlDbType.Float ,8),
                    new SqlParameter("@FX2", SqlDbType.Float ,8),
                    new SqlParameter("@FY2", SqlDbType.Float ,8),
                    new SqlParameter("@FX3", SqlDbType.Float ,8),
                    new SqlParameter("@FY3", SqlDbType.Float ,8),
                    new SqlParameter("@FX4", SqlDbType.Float ,8),
                    new SqlParameter("@FY4", SqlDbType.Float ,8),
                    new SqlParameter("@AREA_CODE", SqlDbType.VarChar ,8),
                    new SqlParameter("@WorkFlow_DoStatus", SqlDbType.Int,8),
                    new SqlParameter("@gcqy", SqlDbType.NVarChar,20),
                    new SqlParameter("@rksj", SqlDbType.DateTime)};


            parameters[0].Value = model.ConstructionProjectID;
            parameters[1].Value = model.ProjectType;
            parameters[2].Value = model.gcmc;
            parameters[3].Value = model.gcbm;
            parameters[4].Value = model.gcdd;
            parameters[5].Value = model.kgsj;
            parameters[6].Value = model.jgsj;
            parameters[7].Value = model.jsdw;
            parameters[8].Value = model.lxpzdw;
            parameters[9].Value = model.sjdw;
            parameters[10].Value = model.kcdw;
            parameters[11].Value = model.sgdw;
            parameters[12].Value = model.jldw;
            parameters[13].Value = model.ghxkzh;
            parameters[14].Value = model.sgxkzh;
            parameters[15].Value = model.ysbah;
            parameters[16].Value = model.jgcldw;
            parameters[17].Value = model.ghysh;
            parameters[18].Value = model.dxth;
            parameters[19].Value = model.ghpzdw;
            parameters[20].Value = model.yddw;
            parameters[21].Value = model.bzdw;
            parameters[22].Value = model.lxpzwh;
            parameters[23].Value = model.zdh;
            parameters[24].Value = model.ydghxkzh;
            parameters[25].Value = model.ydxkzh;
            parameters[26].Value = model.bsbh;
            parameters[27].Value = model.Badw;
            parameters[28].Value = model.pzdw;
            parameters[29].Value = model.pzrq;
            parameters[30].Value = model.pzwh;
            parameters[31].Value = model.zjfsyr;
            parameters[32].Value = model.ydxmmc;
            parameters[33].Value = model.zdwz;
            parameters[34].Value = model.zbxmmc;
            parameters[35].Value = model.xmdz;
            parameters[36].Value = model.zbdw;
            parameters[37].Value = model.zongbdw;
            parameters[38].Value = model.dljg;
            parameters[39].Value = model.sgxkspdw;
            parameters[40].Value = model.CompanyUserID;
            parameters[41].Value = model.ChargeUserID;
            parameters[42].Value = model.AllotUserID;
            parameters[43].Value = model.AllotDate;
            parameters[44].Value = model.Status;
            parameters[45].Value = model.CreateDate;
            parameters[46].Value = model.TDSYZPic;
            parameters[47].Value = model.GHXKZPic;
            parameters[48].Value = model.SGXKZPic;
            parameters[49].Value = model.DX1;
            parameters[50].Value = model.DY1;
            parameters[51].Value = model.DX2;
            parameters[52].Value = model.DY2;
            parameters[53].Value = model.DX3;
            parameters[54].Value = model.DY3;
            parameters[55].Value = model.DX4;
            parameters[56].Value = model.DY4;
            parameters[57].Value = model.FX1;
            parameters[58].Value = model.FY1;
            parameters[59].Value = model.FX2;
            parameters[60].Value = model.FY2;
            parameters[61].Value = model.FX3;
            parameters[62].Value = model.FY3;
            parameters[63].Value = model.FX4;
            parameters[64].Value = model.FY4;
            parameters[65].Value = model.AREA_CODE;
            parameters[66].Value = model.WorkFlow_DoStatus;
            parameters[67].Value = model.gcqy;
            parameters[68].Value = model.Rksj;


            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null) {
                return 1;
            } else {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(DigiPower.Onlinecol.Standard.Model.T_SingleProject_MDL model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_SingleProject set ");
            strSql.Append("ConstructionProjectID=@ConstructionProjectID,");
            strSql.Append("ProjectType=@ProjectType,");
            strSql.Append("gcmc=@gcmc,");
            strSql.Append("gcbm=@gcbm,");
            strSql.Append("gcdd=@gcdd,");
            strSql.Append("kgsj=@kgsj,");
            strSql.Append("jgsj=@jgsj,");
            strSql.Append("jsdw=@jsdw,");
            strSql.Append("lxpzdw=@lxpzdw,");
            strSql.Append("sjdw=@sjdw,");
            strSql.Append("kcdw=@kcdw,");
            strSql.Append("sgdw=@sgdw,");
            strSql.Append("jldw=@jldw,");
            strSql.Append("ghxkzh=@ghxkzh,");
            strSql.Append("sgxkzh=@sgxkzh,");
            strSql.Append("ysbah=@ysbah,");
            strSql.Append("jgcldw=@jgcldw,");
            strSql.Append("ghysh=@ghysh,");
            strSql.Append("dxth=@dxth,");
            strSql.Append("ghpzdw=@ghpzdw,");
            strSql.Append("yddw=@yddw,");
            strSql.Append("bzdw=@bzdw,");
            strSql.Append("lxpzwh=@lxpzwh,");
            strSql.Append("zdh=@zdh,");
            strSql.Append("ydghxkzh=@ydghxkzh,");
            strSql.Append("ydxkzh=@ydxkzh,");
            strSql.Append("bsbh=@bsbh,");
            strSql.Append("Badw=@Badw,");
            strSql.Append("pzdw=@pzdw,");
            strSql.Append("pzrq=@pzrq,");
            strSql.Append("pzwh=@pzwh,");
            strSql.Append("zjfsyr=@zjfsyr,");
            strSql.Append("ydxmmc=@ydxmmc,");
            strSql.Append("zdwz=@zdwz,");
            strSql.Append("zbxmmc=@zbxmmc,");
            strSql.Append("xmdz=@xmdz,");
            strSql.Append("zbdw=@zbdw,");
            strSql.Append("zongbdw=@zongbdw,");
            strSql.Append("dljg=@dljg,");
            strSql.Append("sgxkspdw=@sgxkspdw,");
            strSql.Append("CompanyUserID=@CompanyUserID,");
            strSql.Append("ChargeUserID=@ChargeUserID,");
            strSql.Append("AllotUserID=@AllotUserID,");
            strSql.Append("AllotDate=@AllotDate,");
            strSql.Append("Status=@Status,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("TDSYZPic=@TDSYZPic,");
            strSql.Append("GHXKZPic=@GHXKZPic,");
            strSql.Append("SGXKZPic=@SGXKZPic,");
            strSql.Append("DX1=@DX1,");
            strSql.Append("DY1=@DY1,");
            strSql.Append("DX2=@DX2,");
            strSql.Append("DY2=@DY2,");
            strSql.Append("DX3=@DX3,");
            strSql.Append("DY3=@DY3,");
            strSql.Append("DX4=@DX4,");
            strSql.Append("DY4=@DY4,");
            strSql.Append("FX1=@FX1,");
            strSql.Append("FY1=@FY1,");
            strSql.Append("FX2=@FX2,");
            strSql.Append("FY2=@FY2,");
            strSql.Append("FX3=@FX3,");
            strSql.Append("FY3=@FY3,");
            strSql.Append("FX4=@FX4,");
            strSql.Append("wzCount=@wzCount,");
            strSql.Append("tzCount=@tzCount,");
            strSql.Append("zpCount=@zpCount,");
            strSql.Append("FY4=@FY4,");
            strSql.Append("AREA_CODE=@AREA_CODE,");
            strSql.Append("WorkFlow_DoStatus=@WorkFlow_DoStatus,");
            strSql.Append("LastUserTime=@LastUserTime,");
            strSql.Append("gcqy=@gcqy,");
            strSql.Append("rksj=@rksj");


            strSql.Append(" where SingleProjectID=@SingleProjectID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SingleProjectID", SqlDbType.Int,8),
					new SqlParameter("@ConstructionProjectID", SqlDbType.Int,8),
					new SqlParameter("@ProjectType", SqlDbType.NVarChar,100),
					new SqlParameter("@gcmc", SqlDbType.NVarChar,210),
					new SqlParameter("@gcbm", SqlDbType.NVarChar,20),
					new SqlParameter("@gcdd", SqlDbType.NVarChar,210),
					new SqlParameter("@kgsj", SqlDbType.NVarChar,10),
					new SqlParameter("@jgsj", SqlDbType.NVarChar,10),
					new SqlParameter("@jsdw", SqlDbType.NVarChar,210),
					new SqlParameter("@lxpzdw", SqlDbType.NVarChar,210),
					new SqlParameter("@sjdw", SqlDbType.NVarChar,210),
					new SqlParameter("@kcdw", SqlDbType.NVarChar,210),
					new SqlParameter("@sgdw", SqlDbType.NVarChar,210),
					new SqlParameter("@jldw", SqlDbType.NVarChar,210),
					new SqlParameter("@ghxkzh", SqlDbType.NVarChar,160),
					new SqlParameter("@sgxkzh", SqlDbType.NVarChar,160),
					new SqlParameter("@ysbah", SqlDbType.NVarChar,160),
					new SqlParameter("@jgcldw", SqlDbType.NVarChar,210),
					new SqlParameter("@ghysh", SqlDbType.NVarChar,20),
					new SqlParameter("@dxth", SqlDbType.NVarChar,20),
					new SqlParameter("@ghpzdw", SqlDbType.NVarChar,100),
					new SqlParameter("@yddw", SqlDbType.NVarChar,100),
					new SqlParameter("@bzdw", SqlDbType.NVarChar,100),
					new SqlParameter("@lxpzwh", SqlDbType.NVarChar,20),
					new SqlParameter("@zdh", SqlDbType.NVarChar,20),
					new SqlParameter("@ydghxkzh", SqlDbType.NVarChar,20),
					new SqlParameter("@ydxkzh", SqlDbType.NVarChar,20),
					new SqlParameter("@bsbh", SqlDbType.NVarChar,20),
					new SqlParameter("@Badw", SqlDbType.NVarChar,100),
					new SqlParameter("@pzdw", SqlDbType.NVarChar,100),
					new SqlParameter("@pzrq", SqlDbType.NVarChar,20),
					new SqlParameter("@pzwh", SqlDbType.NVarChar,20),
					new SqlParameter("@zjfsyr", SqlDbType.NVarChar,20),
					new SqlParameter("@ydxmmc", SqlDbType.NVarChar,254),
					new SqlParameter("@zdwz", SqlDbType.NVarChar,254),
					new SqlParameter("@zbxmmc", SqlDbType.NVarChar,100),
					new SqlParameter("@xmdz", SqlDbType.NVarChar,100),
					new SqlParameter("@zbdw", SqlDbType.NVarChar,100),
					new SqlParameter("@zongbdw", SqlDbType.NVarChar,100),
					new SqlParameter("@dljg", SqlDbType.NVarChar,100),
					new SqlParameter("@sgxkspdw", SqlDbType.NVarChar,100),
					new SqlParameter("@CompanyUserID", SqlDbType.Int,8),
					new SqlParameter("@ChargeUserID", SqlDbType.Int,8),
					new SqlParameter("@AllotUserID", SqlDbType.Int,8),
					new SqlParameter("@AllotDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,8),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@TDSYZPic", SqlDbType.NVarChar,250),
					new SqlParameter("@GHXKZPic", SqlDbType.NVarChar,250),
					new SqlParameter("@SGXKZPic", SqlDbType.NVarChar,250),
                    new SqlParameter("@DX1", SqlDbType.Float ,8),
                    new SqlParameter("@DY1", SqlDbType.Float ,8),
                    new SqlParameter("@DX2", SqlDbType.Float ,8),
                    new SqlParameter("@DY2", SqlDbType.Float ,8),
                    new SqlParameter("@DX3", SqlDbType.Float ,8),
                    new SqlParameter("@DY3", SqlDbType.Float ,8),
                    new SqlParameter("@DX4", SqlDbType.Float ,8),
                    new SqlParameter("@DY4", SqlDbType.Float ,8),
                    new SqlParameter("@FX1", SqlDbType.Float ,8),
                    new SqlParameter("@FY1", SqlDbType.Float ,8),
                    new SqlParameter("@FX2", SqlDbType.Float ,8),
                    new SqlParameter("@FY2", SqlDbType.Float ,8),
                    new SqlParameter("@FX3", SqlDbType.Float ,8),
                    new SqlParameter("@FY3", SqlDbType.Float ,8),
                    new SqlParameter("@FX4", SqlDbType.Float ,8),                    
                    new SqlParameter("@wzCount", SqlDbType.Int ,4),
                    new SqlParameter("@tzCount", SqlDbType.Int ,4),
                    new SqlParameter("@zpCount", SqlDbType.Int ,4),
                    new SqlParameter("@FY4", SqlDbType.Float ,8),
                    new SqlParameter("@AREA_CODE", SqlDbType.VarChar ,8),                   
                    new SqlParameter("@WorkFlow_DoStatus", SqlDbType.Int,8),
                    new SqlParameter("@LastUserTime", SqlDbType.DateTime),
                    new SqlParameter("@gcqy", SqlDbType.NVarChar,20),
                    new SqlParameter("@rksj", SqlDbType.DateTime) };



            parameters[0].Value = model.SingleProjectID;
            parameters[1].Value = model.ConstructionProjectID;
            parameters[2].Value = model.ProjectType;
            parameters[3].Value = model.gcmc;
            parameters[4].Value = model.gcbm;
            parameters[5].Value = model.gcdd;
            parameters[6].Value = model.kgsj;
            parameters[7].Value = model.jgsj;
            parameters[8].Value = model.jsdw;
            parameters[9].Value = model.lxpzdw;
            parameters[10].Value = model.sjdw;
            parameters[11].Value = model.kcdw;
            parameters[12].Value = model.sgdw;
            parameters[13].Value = model.jldw;
            parameters[14].Value = model.ghxkzh;
            parameters[15].Value = model.sgxkzh;
            parameters[16].Value = model.ysbah;
            parameters[17].Value = model.jgcldw;
            parameters[18].Value = model.ghysh;
            parameters[19].Value = model.dxth;
            parameters[20].Value = model.ghpzdw;
            parameters[21].Value = model.yddw;
            parameters[22].Value = model.bzdw;
            parameters[23].Value = model.lxpzwh;
            parameters[24].Value = model.zdh;
            parameters[25].Value = model.ydghxkzh;
            parameters[26].Value = model.ydxkzh;
            parameters[27].Value = model.bsbh;
            parameters[28].Value = model.Badw;
            parameters[29].Value = model.pzdw;
            parameters[30].Value = model.pzrq;
            parameters[31].Value = model.pzwh;
            parameters[32].Value = model.zjfsyr;
            parameters[33].Value = model.ydxmmc;
            parameters[34].Value = model.zdwz;
            parameters[35].Value = model.zbxmmc;
            parameters[36].Value = model.xmdz;
            parameters[37].Value = model.zbdw;
            parameters[38].Value = model.zongbdw;
            parameters[39].Value = model.dljg;
            parameters[40].Value = model.sgxkspdw;
            parameters[41].Value = model.CompanyUserID;
            parameters[42].Value = model.ChargeUserID;
            parameters[43].Value = model.AllotUserID;
            parameters[44].Value = model.AllotDate;
            parameters[45].Value = model.Status;
            parameters[46].Value = model.CreateDate;
            parameters[47].Value = model.TDSYZPic;
            parameters[48].Value = model.GHXKZPic;
            parameters[49].Value = model.SGXKZPic;
            parameters[50].Value = model.DX1;
            parameters[51].Value = model.DY1;
            parameters[52].Value = model.DX2;
            parameters[53].Value = model.DY2;
            parameters[54].Value = model.DX3;
            parameters[55].Value = model.DY3;
            parameters[56].Value = model.DX4;
            parameters[57].Value = model.DY4;
            parameters[58].Value = model.FX1;
            parameters[59].Value = model.FY1;
            parameters[60].Value = model.FX2;
            parameters[61].Value = model.FY2;
            parameters[62].Value = model.FX3;
            parameters[63].Value = model.FY3;
            parameters[64].Value = model.FX4;
            parameters[65].Value = model.wzCount;
            parameters[66].Value = model.tzCount;
            parameters[67].Value = model.zpCount;
            parameters[68].Value = model.FY4;
            parameters[69].Value = model.AREA_CODE;
            parameters[70].Value = model.WorkFlow_DoStatus;
            parameters[71].Value = model.LastUserTime;
            parameters[72].Value = model.gcqy;
            parameters[73].Value = model.Rksj;


            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int SingleProjectID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_SingleProject ");
            strSql.Append(" where SingleProjectID=@SingleProjectID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SingleProjectID", SqlDbType.Int,8)};
            parameters[0].Value = SingleProjectID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_SingleProject_MDL GetModel(int SingleProjectID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SingleProjectID,AREA_CODE,ConstructionProjectID,ProjectType,gcmc,gcbm,gcdd,kgsj,jgsj,jsdw,");
            strSql.Append("lxpzdw,sjdw,kcdw,sgdw,jldw,ghxkzh,sgxkzh,ysbah,jgcldw,ghysh,dxth,ghpzdw,yddw,bzdw,lxpzwh,zdh,ydghxkzh,");
            strSql.Append("ydxkzh,bsbh,Badw,pzdw,pzrq,pzwh,zjfsyr,ydxmmc,zdwz,zbxmmc,xmdz,zbdw,zongbdw,dljg,sgxkspdw,CompanyUserID,");
            strSql.Append("ChargeUserID,AllotUserID,AllotDate,Status,CreateDate,TDSYZPic,GHXKZPic,SGXKZPic,DX1,DY1,DX2,DY2,DX3,DY3,");
            strSql.Append("DX4,DY4,FX1,FY1,FX2,FY2,FX3,FY3,FX4,FY4,wzCount,tzCount,zpCount,WorkFlow_DoStatus,LastUserTime,gcqy,Rksj ");
            strSql.Append("from T_SingleProject where SingleProjectID=@SingleProjectID ");

            SqlParameter[] parameters = {
					new SqlParameter("@SingleProjectID", SqlDbType.Int,8)};
            parameters[0].Value = SingleProjectID;

            DigiPower.Onlinecol.Standard.Model.T_SingleProject_MDL model = new DigiPower.Onlinecol.Standard.Model.T_SingleProject_MDL();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["SingleProjectID"].ToString() != "") {
                    model.SingleProjectID = int.Parse(ds.Tables[0].Rows[0]["SingleProjectID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ConstructionProjectID"].ToString() != "") {
                    model.ConstructionProjectID = int.Parse(ds.Tables[0].Rows[0]["ConstructionProjectID"].ToString());
                }
                model.ProjectType = ds.Tables[0].Rows[0]["ProjectType"].ToString();
                model.AREA_CODE = ds.Tables[0].Rows[0]["AREA_CODE"].ToString();
                model.gcmc = ds.Tables[0].Rows[0]["gcmc"].ToString();
                model.gcbm = ds.Tables[0].Rows[0]["gcbm"].ToString();
                model.gcdd = ds.Tables[0].Rows[0]["gcdd"].ToString();
                model.kgsj = ds.Tables[0].Rows[0]["kgsj"].ToString();
                model.jgsj = ds.Tables[0].Rows[0]["jgsj"].ToString();
                model.jsdw = ds.Tables[0].Rows[0]["jsdw"].ToString();
                model.lxpzdw = ds.Tables[0].Rows[0]["lxpzdw"].ToString();
                model.sjdw = ds.Tables[0].Rows[0]["sjdw"].ToString();
                model.kcdw = ds.Tables[0].Rows[0]["kcdw"].ToString();
                model.sgdw = ds.Tables[0].Rows[0]["sgdw"].ToString();
                model.jldw = ds.Tables[0].Rows[0]["jldw"].ToString();
                model.ghxkzh = ds.Tables[0].Rows[0]["ghxkzh"].ToString();
                model.sgxkzh = ds.Tables[0].Rows[0]["sgxkzh"].ToString();
                model.ysbah = ds.Tables[0].Rows[0]["ysbah"].ToString();
                model.jgcldw = ds.Tables[0].Rows[0]["jgcldw"].ToString();
                model.ghysh = ds.Tables[0].Rows[0]["ghysh"].ToString();
                model.dxth = ds.Tables[0].Rows[0]["dxth"].ToString();
                model.ghpzdw = ds.Tables[0].Rows[0]["ghpzdw"].ToString();
                model.yddw = ds.Tables[0].Rows[0]["yddw"].ToString();
                model.bzdw = ds.Tables[0].Rows[0]["bzdw"].ToString();
                model.lxpzwh = ds.Tables[0].Rows[0]["lxpzwh"].ToString();
                model.zdh = ds.Tables[0].Rows[0]["zdh"].ToString();
                model.ydghxkzh = ds.Tables[0].Rows[0]["ydghxkzh"].ToString();
                model.ydxkzh = ds.Tables[0].Rows[0]["ydxkzh"].ToString();
                model.bsbh = ds.Tables[0].Rows[0]["bsbh"].ToString();
                model.Badw = ds.Tables[0].Rows[0]["Badw"].ToString();
                model.pzdw = ds.Tables[0].Rows[0]["pzdw"].ToString();
                model.pzrq = ds.Tables[0].Rows[0]["pzrq"].ToString();
                model.pzwh = ds.Tables[0].Rows[0]["pzwh"].ToString();
                model.zjfsyr = ds.Tables[0].Rows[0]["zjfsyr"].ToString();
                model.ydxmmc = ds.Tables[0].Rows[0]["ydxmmc"].ToString();
                model.zdwz = ds.Tables[0].Rows[0]["zdwz"].ToString();
                model.zbxmmc = ds.Tables[0].Rows[0]["zbxmmc"].ToString();
                model.xmdz = ds.Tables[0].Rows[0]["xmdz"].ToString();
                model.zbdw = ds.Tables[0].Rows[0]["zbdw"].ToString();
                model.zongbdw = ds.Tables[0].Rows[0]["zongbdw"].ToString();
                model.dljg = ds.Tables[0].Rows[0]["dljg"].ToString();
                model.sgxkspdw = ds.Tables[0].Rows[0]["sgxkspdw"].ToString();
                if (ds.Tables[0].Rows[0]["CompanyUserID"].ToString() != "") {
                    model.CompanyUserID = int.Parse(ds.Tables[0].Rows[0]["CompanyUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ChargeUserID"].ToString() != "") {
                    model.ChargeUserID = int.Parse(ds.Tables[0].Rows[0]["ChargeUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AllotUserID"].ToString() != "") {
                    model.AllotUserID = int.Parse(ds.Tables[0].Rows[0]["AllotUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AllotDate"].ToString() != "") {
                    model.AllotDate = DateTime.Parse(ds.Tables[0].Rows[0]["AllotDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "") {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateDate"].ToString() != "") {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                model.TDSYZPic = ds.Tables[0].Rows[0]["TDSYZPic"].ToString();
                model.GHXKZPic = ds.Tables[0].Rows[0]["GHXKZPic"].ToString();
                model.SGXKZPic = ds.Tables[0].Rows[0]["SGXKZPic"].ToString();

                if (ds.Tables[0].Rows[0]["DX1"].ToString() != "") {
                    model.DX1 = decimal.Parse(ds.Tables[0].Rows[0]["DX1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DY1"].ToString() != "") {
                    model.DY1 = decimal.Parse(ds.Tables[0].Rows[0]["DY1"].ToString());
                }

                if (ds.Tables[0].Rows[0]["DX2"].ToString() != "") {
                    model.DX2 = decimal.Parse(ds.Tables[0].Rows[0]["DX2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DY2"].ToString() != "") {
                    model.DY2 = decimal.Parse(ds.Tables[0].Rows[0]["DY2"].ToString());
                }

                if (ds.Tables[0].Rows[0]["DX3"].ToString() != "") {
                    model.DX3 = decimal.Parse(ds.Tables[0].Rows[0]["DX3"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DY3"].ToString() != "") {
                    model.DY3 = decimal.Parse(ds.Tables[0].Rows[0]["DY3"].ToString());
                }

                if (ds.Tables[0].Rows[0]["DX4"].ToString() != "") {
                    model.DX4 = decimal.Parse(ds.Tables[0].Rows[0]["DX4"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DY4"].ToString() != "") {
                    model.DY4 = decimal.Parse(ds.Tables[0].Rows[0]["DY4"].ToString());
                }

                if (ds.Tables[0].Rows[0]["FX1"].ToString() != "") {
                    model.FX1 = decimal.Parse(ds.Tables[0].Rows[0]["FX1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FY1"].ToString() != "") {
                    model.FY1 = decimal.Parse(ds.Tables[0].Rows[0]["FY1"].ToString());
                }

                if (ds.Tables[0].Rows[0]["FX2"].ToString() != "") {
                    model.FX2 = decimal.Parse(ds.Tables[0].Rows[0]["FX2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FY2"].ToString() != "") {
                    model.FY2 = decimal.Parse(ds.Tables[0].Rows[0]["FY2"].ToString());
                }

                if (ds.Tables[0].Rows[0]["FX3"].ToString() != "") {
                    model.FX3 = decimal.Parse(ds.Tables[0].Rows[0]["FX3"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FY3"].ToString() != "") {
                    model.FY3 = decimal.Parse(ds.Tables[0].Rows[0]["FY3"].ToString());
                }

                if (ds.Tables[0].Rows[0]["FX4"].ToString() != "") {
                    model.FX4 = decimal.Parse(ds.Tables[0].Rows[0]["FX4"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FY4"].ToString() != "") {
                    model.FY4 = decimal.Parse(ds.Tables[0].Rows[0]["FY4"].ToString());
                }

                if (ds.Tables[0].Rows[0]["wzCount"].ToString() != "") {
                    model.wzCount = int.Parse(ds.Tables[0].Rows[0]["wzCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["tzCount"].ToString() != "") {
                    model.tzCount = int.Parse(ds.Tables[0].Rows[0]["tzCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["zpCount"].ToString() != "") {
                    model.zpCount = int.Parse(ds.Tables[0].Rows[0]["zpCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WorkFlow_DoStatus"].ToString() != "") {
                    model.WorkFlow_DoStatus = int.Parse(ds.Tables[0].Rows[0]["WorkFlow_DoStatus"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastUserTime"].ToString() != "") {
                    model.LastUserTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastUserTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Rksj"].ToString() != "") {
                    model.Rksj = DateTime.Parse(ds.Tables[0].Rows[0]["Rksj"].ToString());
                }


                model.gcqy = ds.Tables[0].Rows[0]["gcqy"].ToString();
                return model;
            } else {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM T_SingleProject where 1=1 ");
            if (strWhere.Trim() != "") {
                strSql.Append(" and " + strWhere);
            }
            strSql.Append(" ORDER BY GCBM");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表 分页
        /// </summary>
        /// <returns></returns>
        public DataTable GetList(string strWhere, int PageSize, int curPage, string PRIMARYKey, string OrderByName, out int recCoun) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT T_SingleProject.*, ");
            strSql.Append("(select SystemInfoName from T_SystemInfo b where b.CurrentType='Archive_Form' and T_SingleProject.projecttype=b.SystemInfoCode)as ProjectTypeName, ");
            strSql.Append("(select UserName from T_UsersInfo b where T_SingleProject.ChargeUserID=b.UserID)as ChargeUserName,");
            strSql.Append("(SELECT f.AttachPath from T_FileAttach f WHERE LOWER(f.Flag)='company_registration' and f.PriKeyValue=SingleProjectID and LOWER(f.AttachCode)='ghxkz')as ghxkz_AttachPath,");
            strSql.Append("(SELECT f.AttachPath from T_FileAttach f WHERE LOWER(f.Flag)='company_registration' and f.PriKeyValue=SingleProjectID and LOWER(f.AttachCode)='sgxkz')as sgxkz_AttachPath ");

            strSql.Append("FROM T_SingleProject where 1=1 ");
            if (strWhere.Trim() != "") {
                strSql.Append(" and " + strWhere);
            }
            return PageCtrl.QueryForDataTableSqlServer(strSql.ToString(), PageSize, curPage, PRIMARYKey, OrderByName, out recCoun).Tables[0];
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0) {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" SingleProjectID,ConstructionProjectID,AREA_CODE,ProjectType,gcmc,gcbm,gcdd,kgsj,jgsj,jsdw,lxpzdw,sjdw,");
            strSql.Append("kcdw,sgdw,jldw,ghxkzh,sgxkzh,ysbah,jgcldw,ghysh,dxth,ghpzdw,yddw,bzdw,lxpzwh,zdh,ydghxkzh,ydxkzh,bsbh,");
            strSql.Append("Badw,pzdw,pzrq,pzwh,zjfsyr,ydxmmc,zdwz,zbxmmc,xmdz,zbdw,zongbdw,dljg,sgxkspdw,CompanyUserID,ChargeUserID,");
            strSql.Append("AllotUserID,AllotDate,Status,CreateDate,TDSYZPic,GHXKZPic,SGXKZPic,DX1,DY1,DX2,DY2,DX3,DY3,DX4,DY4,FX1,FY1,");
            strSql.Append("FX2,FY2,FX3,FY3,FX4,FY4,wzCount,tzCount,zpCount,WorkFlow_DoStatus as DoStatus,gcqy,Rksj ");

            strSql.Append(" FROM T_SingleProject ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法

        public DataSet GetListUnionProjectTypeName(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.*,");
            strSql.Append(" (select SystemInfoName from T_SystemInfo b where CurrentType='Archive_Form' AND SystemInfoCode=a.projecttype) projecttypename ");
            strSql.Append(" from t_singleproject a  ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据单位取工程信息
        /// </summary>
        /// <param name="companyid"></param>
        /// <returns></returns>
        public DataSet GetListByCompanyId(int companyid) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select a.SingleProjectID,a.constructionprojectid,a.projecttype,a.gcmc,a.gcbm,a.gcdd,");
            strSql.Append("    a.ghxkzh,a.sgxkzh,b.SystemInfoName as ProjectTypeName,c.xmmc,c.xmh,d.workflowname from t_singleproject a ");
            strSql.Append("    left join t_construction_project c on a.constructionprojectid=c.constructionprojectid ");
            strSql.Append("    left join T_SystemInfo b on b.CurrentType='Archive_Form' and a.projecttype=b.SystemInfoCode ");
            strSql.Append("    left join View_gcdtgz_gczt d on a.singleprojectid=d.singleprojectid");
            if (companyid > 0) {
                strSql.Append("    where c.companyid=" + companyid);
            }
            strSql.Append(" Order By SingleProjectID Desc");

            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 根据单位取工程信息
        /// </summary>
        /// <param name="companyid"></param>
        /// <returns></returns>
        public DataSet GetListByCompanyId(int companyid, string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select e.UserName,a.SingleProjectID,a.constructionprojectid,a.projecttype,a.gcmc,a.gcbm,a.gcdd,");
            strSql.Append("    a.ghxkzh,a.sgxkzh,b.SystemInfoName as ProjectTypeName,c.xmmc,c.xmh,d.workflowname from t_singleproject a ");
            strSql.Append("    left join t_construction_project c on a.constructionprojectid=c.constructionprojectid ");
            strSql.Append("    left join T_SystemInfo b on b.CurrentType='Archive_Form' and a.projecttype=b.SystemInfoCode ");
            strSql.Append("    left join View_gcdtgz_gczt d on a.singleprojectid=d.singleprojectid left join t_usersinfo e on e.userID=a.ChargeUserID");
            if (companyid > 0) {
                strSql.Append(" where c.companyid=" + companyid);
            }

            if (strWhere.Trim() != "") {
                if (companyid < 1)
                    strSql.Append(" where " + strWhere);
                else
                    strSql.Append(" AND " + strWhere);
            }

            strSql.Append(" Order By SingleProjectID Desc");

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表 分页
        /// </summary>
        /// <returns></returns>
        public DataTable GetListByCompanyId(int companyid, string strWhere, int PageSize, int curPage, string PRIMARYKey, string OrderByName, out int recCoun) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select rcb.zljddw as yRechiveCode,e.UserName as ChargeUserName,a.SingleProjectID,a.constructionprojectid,a.projecttype,a.gcmc,a.gcbm,a.gcdd,");
            strSql.Append(" a.ghxkzh,a.sgxkzh,b.SystemInfoName as ProjectTypeName,c.xmmc,c.xmh,d.workflowname,a.jsdw,a.jgsj,a.ChargeUserID,a.WorkFlow_DoStatus,a.Status, ");
            strSql.Append(" (SELECT f.AttachPath from T_FileAttach f WHERE LOWER(f.Flag)='company_registration' and f.PriKeyValue=a.SingleProjectID and LOWER(f.AttachCode)='ghxkz')as ghxkz_AttachPath,");
            strSql.Append(" (SELECT f.AttachPath from T_FileAttach f WHERE LOWER(f.Flag)='company_registration' and f.PriKeyValue=a.SingleProjectID and LOWER(f.AttachCode)='sgxkz')as sgxkz_AttachPath,");
            strSql.Append(" d.WorkFlowID from t_singleproject a ");
            strSql.Append(" left join t_construction_project c on a.constructionprojectid=c.constructionprojectid ");
            strSql.Append(" left join T_ReadyCheckBook rcb on rcb.SingleProjectID=a.SingleProjectID and rcb.CodeType='3' ");
            strSql.Append(" left join T_SystemInfo b on b.CurrentType='Archive_Form' and a.projecttype=b.SystemInfoCode ");
            strSql.Append(" left join View_gcdtgz_gczt d on a.singleprojectid=d.singleprojectid ");
            strSql.Append(" left join t_usersinfo e on e.userID=a.ChargeUserID ");
            if (companyid > 0) {
                strSql.Append(" where c.companyid=" + companyid);
            }

            if (strWhere.Trim() != "") {
                if (companyid < 1)
                    strSql.Append(" where " + strWhere);
                else
                    strSql.Append(" AND " + strWhere);
            }

            return PageCtrl.QueryForDataTableSqlServer(strSql.ToString(), PageSize, curPage, PRIMARYKey, OrderByName, out recCoun).Tables[0];
        }

        /// <summary>
        /// 获得数据列表 分页
        /// </summary>
        /// <returns></returns>
        public DataTable GetListByCompanyId(Hashtable ht, int PageSize, int curPage, string PRIMARYKey, string OrderByName, out int recCoun) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT B.gcmc,B.SingleProjectID,B.gcdd,B.gcbm,B.sgxkzh,B.ghxkzh, C.CompanyID,C.CompanyName, d.SystemInfoName as CompanyTypeName,");
            strSql.Append(" e.SystemInfoName as ProjectTypeName,b.ProjectType,f.UserId,f.UserName,f.LoginName,a.SingleProjectCompanyID,c.CompanyType ");
            strSql.Append(" FROM T_SingleProjectCompany A ");
            strSql.Append(" INNER JOIN T_SingleProject B  ON A.SingleProjectID=B.SingleProjectID ");
            if (ht.ContainsKey("NotInCompanyType") && Common.ConvertEx.ToString(ht["NotInCompanyType"]).Length > 0) {
                strSql.Append(" INNER JOIN T_Company C ON A.CompanyID=C.CompanyID and c.CompanyType not in(" + Common.ConvertEx.ToString(ht["NotInCompanyType"]) + ") ");
            }
            if (ht.ContainsKey("InCompanyType") && Common.ConvertEx.ToString(ht["InCompanyType"]).Length > 0) {
                strSql.Append(" INNER JOIN T_Company C ON A.CompanyID=C.CompanyID and c.CompanyType in(" + Common.ConvertEx.ToString(ht["InCompanyType"]) + ") ");
            }
            strSql.Append(" INNER JOIN T_UsersInfo f ON f.CompanyID=C.CompanyID ");
            strSql.Append(" INNER JOIN T_SystemInfo d ON C.CompanyType=d.SystemInfoID ");
            strSql.Append(" INNER JOIN T_SystemInfo e on e.CurrentType='Archive_Form' and b.projecttype=e.SystemInfoCode ");

            strSql.Append(" WHERE 1=1 ");

            if (ht.ContainsKey("Area_Code") && Common.ConvertEx.ToString(ht["Area_Code"]).Length > 0) {
                strSql.Append(" and B.Area_Code like '" + Common.ConvertEx.ToString(ht["Area_Code"]) + "%'");
            }
            if (ht.ContainsKey("CompanyId") && Common.ConvertEx.ToString(ht["CompanyId"]).Length > 0) {
                strSql.Append(" AND EXISTS(select distinct SingleProjectID from T_SingleProjectCompany where ");
                strSql.Append("CompanyID=" + Common.ConvertEx.ToString(ht["CompanyId"]) + " AND SingleProjectID=B.SingleProjectID )");
                //strSql.Append(" and B.SingleProjectID in(select distinct SingleProjectID from T_SingleProjectCompany where CompanyID=" + Common.ConvertEx.ToString(ht["CompanyId"]) + ")");
            }
            if (ht.ContainsKey("ProjectType") && Common.ConvertEx.ToString(ht["ProjectType"]).Length > 0) {
                strSql.Append(" and B.ProjectType=(select SystemInfoCode from T_SystemInfo where SystemInfoID=" + Common.ConvertEx.ToString(ht["ProjectType"]) + ")");
            }
            if (ht.ContainsKey("kgsj") && Common.ConvertEx.ToString(ht["kgsj"]).Length > 0) {
                strSql.Append(" and B.kgsj>='" + Common.ConvertEx.ToString(ht["kgsj"]) + " 00:00:00.00' ");
            }
            if (ht.ContainsKey("kgsj2") && Common.ConvertEx.ToString(ht["kgsj2"]).Length > 0) {
                strSql.Append(" and B.kgsj<='" + Common.ConvertEx.ToString(ht["kgsj2"]) + " 23:59:59.99' ");
            }
            if (ht.ContainsKey("jgsj") && Common.ConvertEx.ToString(ht["jgsj"]).Length > 0) {
                strSql.Append(" and B.jgsj>='" + Common.ConvertEx.ToString(ht["jgsj"]) + " 00:00:00.00' ");
            }
            if (ht.ContainsKey("jgsj2") && Common.ConvertEx.ToString(ht["jgsj2"]).Length > 0) {
                strSql.Append(" and B.jgsj<='" + Common.ConvertEx.ToString(ht["jgsj2"]) + " 23:59:59.99' ");
            }
            if (ht.ContainsKey("gcbm") && Common.ConvertEx.ToString(ht["gcbm"]).Length > 0) {
                strSql.Append(" and B.gcbm like '%" + Common.ConvertEx.ToString(ht["gcbm"]) + "%'");
            }
            if (ht.ContainsKey("gcmc") && Common.ConvertEx.ToString(ht["gcmc"]).Length > 0) {
                strSql.Append(" and B.gcmc like '%" + Common.ConvertEx.ToString(ht["gcmc"]) + "%'");
            }
            if (ht.ContainsKey("gcdd") && Common.ConvertEx.ToString(ht["gcdd"]).Length > 0) {
                strSql.Append(" and B.gcdd like '%" + Common.ConvertEx.ToString(ht["gcdd"]) + "%'");
            }
            if (ht.ContainsKey("ghxkzh") && Common.ConvertEx.ToString(ht["ghxkzh"]).Length > 0) {
                strSql.Append(" and B.ghxkzh like '%" + Common.ConvertEx.ToString(ht["ghxkzh"]) + "%'");
            }
            if (ht.ContainsKey("sgxkzh") && Common.ConvertEx.ToString(ht["sgxkzh"]).Length > 0) {
                strSql.Append(" and B.sgxkzh like '%" + Common.ConvertEx.ToString(ht["sgxkzh"]) + "%'");
            }
            if (ht.ContainsKey("ChargeUserID") && Common.ConvertEx.ToString(ht["ChargeUserID"]).Length > 0) {
                strSql.Append(" and B.ChargeUserID=" + Common.ConvertEx.ToString(ht["ChargeUserID"]) + "");
            }
            return PageCtrl.QueryForDataTableSqlServer(strSql.ToString(), PageSize, curPage, PRIMARYKey, OrderByName, out recCoun).Tables[0];
        }

        /// <summary>
        /// 获得数据列表 分页
        /// </summary>
        /// <returns></returns>
        public DataTable GetListByUserId(string strWhere, int PageSize, int curPage, string PRIMARYKey, string OrderByName, out int recCoun) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select DISTINCT a.*,d.SystemInfoName as ProjectTypeName, ");
            strSql.Append(" (select f0.UserName from T_UsersInfo f0 where f0.UserId=a.ChargeUserID) as ChargeUserName ");

            strSql.Append(" FROM T_SingleProject a  ");
            strSql.Append(" INNER JOIN T_SystemInfo d ON d.CurrentType='Archive_Form' and a.projecttype=d.SystemInfoCode ");
            strSql.Append(" INNER JOIN T_SingleProjectUser b ON a.SingleProjectID=b.SingleProjectID ");
            strSql.Append(" INNER JOIN T_UsersInfo c ON b.UserID=c.UserID AND b.UserID>0 ");

            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }

            return PageCtrl.QueryForDataTableSqlServer(strSql.ToString(), PageSize, curPage, PRIMARYKey, OrderByName, out recCoun).Tables[0];
        }

        /// <summary>
        /// 获得单位-项目-工程层级信息
        /// </summary>
        public DataSet GetCompanyPro(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.companyid,a.companyname,b.xmmc,c.* from T_Company a left join t_construction_project b on a.companyid=b.companyid left join t_singleproject c on b.constructionprojectid=c.constructionprojectid");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet Get_gcdtgz(int singleprojectid) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from View_gcdtgzb");
            if (singleprojectid > 0) {
                strSql.Append(" where singleprojectid=" + singleprojectid);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetListEx(int CompanyID, string sqlWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select aa.CompanyID,e.UserName,c.xmmc,a.SingleProjectID,a.constructionprojectid,a.projecttype,");
            strSql.Append("a.gcmc,a.gcbm,a.gcdd,    a.ghxkzh,a.sgxkzh,b.SystemInfoName as ProjectTypeName,c.xmmc,c.xmh,d.workflowname ");
            strSql.Append("from t_singleproject a,T_SingleProjectCompany aa ,t_construction_project c,T_SystemInfo b,View_gcdtgz_gczt d ,");
            strSql.Append("t_usersinfo e where a.SingleProjectID=aa.SingleProjectID and a.constructionprojectid=c.constructionprojectid ");
            strSql.Append("and b.CurrentType='Archive_Form' and a.projecttype=b.SystemInfoCode and a.singleprojectid=d.singleprojectid ");
            strSql.Append("and e.userID=a.ChargeUserID ");
            if (CompanyID > 0) {
                strSql.Append(" and aa.companyid=" + CompanyID);
            }
            if (sqlWhere != "") {
                strSql.Append(sqlWhere);
            }

            strSql.Append(" Order By SingleProjectID Desc");

            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetListEx2(int CompanyID, string sqlWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  select aa.CompanyID,e.UserName,c.xmmc,a.SingleProjectID,a.constructionprojectid,a.projecttype,a.gcmc,a.gcbm,a.gcdd,   ");
            strSql.Append(" a.ghxkzh,a.sgxkzh,b.SystemInfoName as ProjectTypeName,c.xmmc,c.xmh from t_singleproject a,T_SingleProjectCompany aa ,");
            strSql.Append("t_construction_project c,T_SystemInfo b,t_usersinfo e where a.SingleProjectID=aa.SingleProjectID and a.constructionprojectid=");
            strSql.Append("c.constructionprojectid and b.CurrentType='Archive_Form' and a.projecttype=b.SystemInfoCode and e.userID=a.ChargeUserID  ");

            if (CompanyID > 0) {
                strSql.Append(" and aa.companyid=" + CompanyID);
            }
            if (sqlWhere != "") {
                strSql.Append(sqlWhere);
            }

            strSql.Append(" Order By SingleProjectID Desc");

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int DeleteSingleProjectTable(int SingleProjectID, string tname) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + tname);
            strSql.Append(" where SingleProjectID=@SingleProjectID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SingleProjectID", SqlDbType.Int,8)};
            parameters[0].Value = SingleProjectID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public int GetSingleProjectCountByCompany(int companyid) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select COUNT(*) from t_singleproject where ConstructionProjectID in( ");
            strSql.Append(" select ConstructionProjectID from T_Construction_Project where CompanyID=" + companyid + ")");

            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null) {
                return 1;
            } else {
                return Convert.ToInt32(obj);
            }
        }


        /// <summary>
        /// 获得数据列表 分页
        /// </summary>
        /// <returns></returns>
        public DataTable GetListByUserId(int companyid, string strWhere, int PageSize, int curPage, string PRIMARYKey, string OrderByName, out int recCoun) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select rcb.zljddw as yRechiveCode,e.UserName,a.SingleProjectID,a.constructionprojectid,a.projecttype,a.gcmc,a.gcbm,a.gcdd,");
            strSql.Append("    a.ghxkzh,a.sgxkzh,b.SystemInfoName as ProjectTypeName,c.xmmc,c.xmh,d.workflowname,a.jsdw,a.jgsj from t_singleproject a ");
            strSql.Append("    left join t_construction_project c on a.constructionprojectid=c.constructionprojectid ");
            strSql.Append("    left join T_ReadyCheckBook rcb on rcb.SingleProjectID=a.SingleProjectID and rcb.CodeType='3' ");
            strSql.Append("    left join T_SystemInfo b on b.CurrentType='Archive_Form' and a.projecttype=b.SystemInfoCode ");
            strSql.Append("    left join View_gcdtgz_gczt d on a.singleprojectid=d.singleprojectid left join t_usersinfo e on e.userID=a.ChargeUserID");
            if (companyid > 0) {
                strSql.Append(" where c.companyid=" + companyid);
            }

            if (strWhere.Trim() != "") {
                if (companyid < 1)
                    strSql.Append(" where " + strWhere);
                else
                    strSql.Append(" AND " + strWhere);
            }

            return PageCtrl.QueryForDataTableSqlServer(strSql.ToString(), PageSize, curPage, PRIMARYKey, OrderByName, out recCoun).Tables[0];
        }
    }
}