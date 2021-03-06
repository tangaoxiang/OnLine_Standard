using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;
using System.Collections;
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.Common;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL {
    /// <summary>
    /// 数据访问类T_FileList_DAL。
    /// </summary>
    public class T_FileList_DAL {
        public T_FileList_DAL() { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId() {
            return DbHelperSQL.GetMaxID("FileListID", "T_FileList");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int FileListID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_FileList");
            strSql.Append(" where FileListID=@FileListID ");
            SqlParameter[] parameters = {
					new SqlParameter("@FileListID", SqlDbType.Int,8)};
            parameters[0].Value = FileListID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_FileList_MDL model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_FileList(");
            strSql.Append("SingleProjectID,ArchiveID,MyArchiveID,recID,PID,DefaultCompanyType,DH,MyCode,BH,Title,MustSubmitFlag,OldStatus,Status,StartTime,");
            strSql.Append("EndTime,CompanyID,OperateUserID,OperateUserName,OrderIndex,ManualCount,PagesCount,WinRecvPagesCount,Remark,PDFFilePath,AlonePack,");
            strSql.Append("IsFolder,IsSystem,FileType,archive_form_no,zajh,w_t_h,wjtm,zrr,qssj,zzsj,yc,wb,sl,bgqx,mj,dz_k,dz_l,dz_g,dz_c,dz_x,ztlx,dw,gg,ty,ztc,");
            strSql.Append("note,sw,dz,lrr,lrsj,shzt,shr_1,shsj_1,shr_2,shsj_2,shr_3,shsj_3,aipdate,aipuser,ShortDH,swgph,cfdz,wjbt,zrz,wh,wjfwqx,xcsj,dzwjxx,fz,CreateDate,");
            strSql.Append("CreateDate2,tzz,dtz,zpz,wzz,dpz,wjgbdm,wjlxdm,wjgs,wjdx,psdd,psz,pssj,sb,fbl,xjpp,xjxh,bz,RootPath,");
            strSql.Append("XAXIS_RESOLUTION,YAXIS_RESOLUTION,IMAGE_WIDTH,IMAGE_HEIGHT,DATA_FICAL_LENGTH,DATA_APERTURE,");
            strSql.Append("DATA_APERTURE_XS,FLASH,WHITE_BALANCE,ISO_SPEED_RATINGS,EXPOSURE_PROGRAM,EXPOSURE_MODE,");
            strSql.Append("DATA_EXPOSURE_TIME,QUALITY,CONTRAST,SATURATION,MAX_APERTURE,CONVERT_FLAG,SIGNATURE_FLAG,FROM_SID,OldRecID,");
            strSql.Append("MyOrderIndex,FileFrom,IsMerge,Version,iSignaturePdf,iSignatureWorkFlow)");

            strSql.Append(" values (");
            strSql.Append("@SingleProjectID,@ArchiveID,@MyArchiveID,@recID,@PID,@DefaultCompanyType,@DH,@MyCode,@BH,@Title,@MustSubmitFlag,@OldStatus,@Status,");
            strSql.Append("@StartTime,@EndTime,@CompanyID,@OperateUserID,@OperateUserName,@OrderIndex,@ManualCount,@PagesCount,@WinRecvPagesCount,@Remark,");
            strSql.Append("@PDFFilePath,@AlonePack,@IsFolder,@IsSystem,@FileType,@archive_form_no,@zajh,@w_t_h,@wjtm,@zrr,@qssj,@zzsj,@yc,@wb,@sl,@bgqx,@mj,@dz_k,");
            strSql.Append("@dz_l,@dz_g,@dz_c,@dz_x,@ztlx,@dw,@gg,@ty,@ztc,@note,@sw,@dz,@lrr,@lrsj,@shzt,@shr_1,@shsj_1,@shr_2,@shsj_2,@shr_3,@shsj_3,@aipdate,");
            strSql.Append("@aipuser,@ShortDH,@swgph,@cfdz,@wjbt,@zrz,@wh,@wjfwqx,@xcsj,@dzwjxx,@fz,@CreateDate,@CreateDate2,@tzz,@dtz,@zpz,@wzz,@dpz,@wjgbdm,");
            strSql.Append("@wjlxdm,@wjgs,@wjdx,@psdd,@psz,@pssj,@sb,@fbl,@xjpp,@xjxh,@bz,@RootPath,");
            strSql.Append("@XAXIS_RESOLUTION,@YAXIS_RESOLUTION,@IMAGE_WIDTH,@IMAGE_HEIGHT,@DATA_FICAL_LENGTH,@DATA_APERTURE,");
            strSql.Append("@DATA_APERTURE_XS,@FLASH,@WHITE_BALANCE,@ISO_SPEED_RATINGS,@EXPOSURE_PROGRAM,@EXPOSURE_MODE,");
            strSql.Append("@DATA_EXPOSURE_TIME,@QUALITY,@CONTRAST,@SATURATION,@MAX_APERTURE,@CONVERT_FLAG,@SIGNATURE_FLAG,@FROM_SID,@OldRecID,");
            strSql.Append("@MyOrderIndex,@FileFrom,@IsMerge,@Version,@iSignaturePdf,@iSignatureWorkFlow)");


            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@SingleProjectID", SqlDbType.Int,8),
					new SqlParameter("@ArchiveID", SqlDbType.Int,8),
					new SqlParameter("@MyArchiveID", SqlDbType.Int,8),
					new SqlParameter("@recID", SqlDbType.Int,8),
					new SqlParameter("@PID", SqlDbType.Int,8),
					new SqlParameter("@DefaultCompanyType", SqlDbType.Int,8),
					new SqlParameter("@DH", SqlDbType.NVarChar,30),
					new SqlParameter("@MyCode", SqlDbType.NVarChar,50),
					new SqlParameter("@BH", SqlDbType.NVarChar,20),
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@MustSubmitFlag", SqlDbType.Bit,1),
					new SqlParameter("@OldStatus", SqlDbType.NVarChar,20),
					new SqlParameter("@Status", SqlDbType.NVarChar,20),
					new SqlParameter("@StartTime", SqlDbType.NVarChar,20),
					new SqlParameter("@EndTime", SqlDbType.NVarChar,20),
					new SqlParameter("@CompanyID", SqlDbType.Int,8),
					new SqlParameter("@OperateUserID", SqlDbType.Int,8),
					new SqlParameter("@OperateUserName", SqlDbType.NVarChar,20),
					new SqlParameter("@OrderIndex", SqlDbType.Int,8),
					new SqlParameter("@ManualCount", SqlDbType.Int,8),
					new SqlParameter("@PagesCount", SqlDbType.Int,8),
					new SqlParameter("@WinRecvPagesCount", SqlDbType.Int,8),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@PDFFilePath", SqlDbType.NVarChar,250),
					new SqlParameter("@AlonePack", SqlDbType.Bit,1),
					new SqlParameter("@IsFolder", SqlDbType.Bit,1),
					new SqlParameter("@IsSystem", SqlDbType.Bit,1),
					new SqlParameter("@FileType", SqlDbType.NVarChar,20),
					new SqlParameter("@archive_form_no", SqlDbType.VarChar,20),
					new SqlParameter("@zajh", SqlDbType.VarChar,20),
					new SqlParameter("@w_t_h", SqlDbType.VarChar,100),
					new SqlParameter("@wjtm", SqlDbType.VarChar,250),
					new SqlParameter("@zrr", SqlDbType.VarChar,100),
					new SqlParameter("@qssj", SqlDbType.DateTime),
					new SqlParameter("@zzsj", SqlDbType.DateTime),
					new SqlParameter("@yc", SqlDbType.VarChar,20),
					new SqlParameter("@wb", SqlDbType.VarChar,200),
					new SqlParameter("@sl", SqlDbType.Int,8),
					new SqlParameter("@bgqx", SqlDbType.VarChar,20),
					new SqlParameter("@mj", SqlDbType.VarChar,10),
					new SqlParameter("@dz_k", SqlDbType.VarChar,10),
					new SqlParameter("@dz_l", SqlDbType.VarChar,10),
					new SqlParameter("@dz_g", SqlDbType.VarChar,10),
					new SqlParameter("@dz_c", SqlDbType.VarChar,10),
					new SqlParameter("@dz_x", SqlDbType.VarChar,10),
					new SqlParameter("@ztlx", SqlDbType.VarChar,10),
					new SqlParameter("@dw", SqlDbType.VarChar,10),
					new SqlParameter("@gg", SqlDbType.VarChar,10),
					new SqlParameter("@ty", SqlDbType.VarChar,200),
					new SqlParameter("@ztc", SqlDbType.VarChar,250),
					new SqlParameter("@note", SqlDbType.VarChar,250),
					new SqlParameter("@sw", SqlDbType.VarChar,30),
					new SqlParameter("@dz", SqlDbType.VarChar,200),
					new SqlParameter("@lrr", SqlDbType.VarChar,10),
					new SqlParameter("@lrsj", SqlDbType.DateTime),
					new SqlParameter("@shzt", SqlDbType.SmallInt,2),
					new SqlParameter("@shr_1", SqlDbType.VarChar,20),
					new SqlParameter("@shsj_1", SqlDbType.DateTime),
					new SqlParameter("@shr_2", SqlDbType.VarChar,20),
					new SqlParameter("@shsj_2", SqlDbType.DateTime),
					new SqlParameter("@shr_3", SqlDbType.VarChar,20),
					new SqlParameter("@shsj_3", SqlDbType.DateTime),
					new SqlParameter("@aipdate", SqlDbType.DateTime),
					new SqlParameter("@aipuser", SqlDbType.VarChar,20),
					new SqlParameter("@ShortDH", SqlDbType.VarChar,30),
					new SqlParameter("@swgph", SqlDbType.VarChar,20),
					new SqlParameter("@cfdz", SqlDbType.VarChar,254),
					new SqlParameter("@wjbt", SqlDbType.VarChar,254),
					new SqlParameter("@zrz", SqlDbType.VarChar,20),
					new SqlParameter("@wh", SqlDbType.VarChar,20),
					new SqlParameter("@wjfwqx", SqlDbType.VarChar,20),
					new SqlParameter("@xcsj", SqlDbType.VarChar,10),
					new SqlParameter("@dzwjxx", SqlDbType.Text),
					new SqlParameter("@fz", SqlDbType.Text),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@CreateDate2", SqlDbType.DateTime),
					new SqlParameter("@tzz", SqlDbType.Int,8),
					new SqlParameter("@dtz", SqlDbType.Int,8),
					new SqlParameter("@zpz", SqlDbType.Int,8),
					new SqlParameter("@wzz", SqlDbType.Int,8),
					new SqlParameter("@dpz", SqlDbType.Int,8),
					new SqlParameter("@wjgbdm", SqlDbType.NVarChar,50),
					new SqlParameter("@wjlxdm", SqlDbType.NVarChar,50),
					new SqlParameter("@wjgs", SqlDbType.NVarChar,50),
					new SqlParameter("@wjdx", SqlDbType.NVarChar,50),
					new SqlParameter("@psdd", SqlDbType.NVarChar,50),
					new SqlParameter("@psz", SqlDbType.NVarChar,50),
					new SqlParameter("@pssj", SqlDbType.DateTime),
					new SqlParameter("@sb", SqlDbType.NVarChar,50),
					new SqlParameter("@fbl", SqlDbType.NVarChar,50),
					new SqlParameter("@xjpp", SqlDbType.NVarChar,50),
					new SqlParameter("@xjxh", SqlDbType.NVarChar,50),
					new SqlParameter("@bz", SqlDbType.NVarChar,1000),
                    new SqlParameter("@RootPath", SqlDbType.VarChar,100),

                    new SqlParameter("@XAXIS_RESOLUTION", SqlDbType.VarChar,200),
                    new SqlParameter("@YAXIS_RESOLUTION", SqlDbType.VarChar,200),
                    new SqlParameter("@IMAGE_WIDTH", SqlDbType.VarChar,200),
                    new SqlParameter("@IMAGE_HEIGHT", SqlDbType.VarChar,200),
                    new SqlParameter("@DATA_FICAL_LENGTH", SqlDbType.VarChar,200),
                    new SqlParameter("@DATA_APERTURE", SqlDbType.VarChar,200),
                    new SqlParameter("@DATA_APERTURE_XS", SqlDbType.VarChar,200),
                    new SqlParameter("@FLASH", SqlDbType.VarChar,200),
                    new SqlParameter("@WHITE_BALANCE", SqlDbType.VarChar,200),
                    new SqlParameter("@ISO_SPEED_RATINGS", SqlDbType.VarChar,200),
                    new SqlParameter("@EXPOSURE_PROGRAM", SqlDbType.VarChar,200),
                    new SqlParameter("@EXPOSURE_MODE", SqlDbType.VarChar,200),
                    new SqlParameter("@DATA_EXPOSURE_TIME", SqlDbType.VarChar,200),
                    new SqlParameter("@QUALITY", SqlDbType.VarChar,200),
                    new SqlParameter("@CONTRAST", SqlDbType.VarChar,200),
                    new SqlParameter("@SATURATION", SqlDbType.VarChar,200),
                    new SqlParameter("@MAX_APERTURE", SqlDbType.VarChar,200),
					new SqlParameter("@CONVERT_FLAG", SqlDbType.Bit,1),
                    new SqlParameter("@SIGNATURE_FLAG", SqlDbType.Bit,1),
                    new SqlParameter("@FROM_SID", SqlDbType.VarChar,100),
                    new SqlParameter("@OldRecID", SqlDbType.Int,8),
                    new SqlParameter("@MyOrderIndex", SqlDbType.Int,8),
                    new SqlParameter("@FileFrom", SqlDbType.VarChar,100),
                    new SqlParameter("@IsMerge", SqlDbType.VarChar,2),
                    new SqlParameter("@Version", SqlDbType.Int,8),
                    new SqlParameter("@iSignaturePdf", SqlDbType.Bit,1),
                    new SqlParameter("@iSignatureWorkFlow", SqlDbType.Bit,1)};

            parameters[0].Value = model.SingleProjectID;
            parameters[1].Value = model.ArchiveID;
            parameters[2].Value = model.MyArchiveID;
            parameters[3].Value = model.recID;
            parameters[4].Value = model.PID;
            parameters[5].Value = model.DefaultCompanyType;
            parameters[6].Value = model.DH;
            parameters[7].Value = model.MyCode;
            parameters[8].Value = model.BH;
            parameters[9].Value = model.Title;
            parameters[10].Value = model.MustSubmitFlag;
            parameters[11].Value = model.OldStatus;
            parameters[12].Value = model.Status;
            parameters[13].Value = model.StartTime;
            parameters[14].Value = model.EndTime;
            parameters[15].Value = model.CompanyID;
            parameters[16].Value = model.OperateUserID;
            parameters[17].Value = model.OperateUserName;
            parameters[18].Value = model.OrderIndex;
            parameters[19].Value = model.ManualCount;
            parameters[20].Value = model.PagesCount;
            parameters[21].Value = model.WinRecvPagesCount;
            parameters[22].Value = model.Remark;
            parameters[23].Value = model.PDFFilePath;
            parameters[24].Value = model.AlonePack;
            parameters[25].Value = model.IsFolder;
            parameters[26].Value = model.IsSystem;
            parameters[27].Value = model.FileType;
            parameters[28].Value = model.archive_form_no;
            parameters[29].Value = model.zajh;
            parameters[30].Value = model.w_t_h;
            parameters[31].Value = model.wjtm;
            parameters[32].Value = model.zrr;
            parameters[33].Value = model.qssj;
            parameters[34].Value = model.zzsj;
            parameters[35].Value = model.yc;
            parameters[36].Value = model.wb;
            parameters[37].Value = model.sl;
            parameters[38].Value = model.bgqx;
            parameters[39].Value = model.mj;
            parameters[40].Value = model.dz_k;
            parameters[41].Value = model.dz_l;
            parameters[42].Value = model.dz_g;
            parameters[43].Value = model.dz_c;
            parameters[44].Value = model.dz_x;
            parameters[45].Value = model.ztlx;
            parameters[46].Value = model.dw;
            parameters[47].Value = model.gg;
            parameters[48].Value = model.ty;
            parameters[49].Value = model.ztc;
            parameters[50].Value = model.note;
            parameters[51].Value = model.sw;
            parameters[52].Value = model.dz;
            parameters[53].Value = model.lrr;
            parameters[54].Value = model.lrsj;
            parameters[55].Value = model.shzt;
            parameters[56].Value = model.shr_1;
            parameters[57].Value = model.shsj_1;
            parameters[58].Value = model.shr_2;
            parameters[59].Value = model.shsj_2;
            parameters[60].Value = model.shr_3;
            parameters[61].Value = model.shsj_3;
            parameters[62].Value = model.aipdate;
            parameters[63].Value = model.aipuser;
            parameters[64].Value = model.ShortDH;
            parameters[65].Value = model.swgph;
            parameters[66].Value = model.cfdz;
            parameters[67].Value = model.wjbt;
            parameters[68].Value = model.zrz;
            parameters[69].Value = model.wh;
            parameters[70].Value = model.wjfwqx;
            parameters[71].Value = model.xcsj;
            parameters[72].Value = model.dzwjxx;
            parameters[73].Value = model.fz;
            parameters[74].Value = model.CreateDate;
            parameters[75].Value = model.CreateDate2;
            parameters[76].Value = model.tzz;
            parameters[77].Value = model.dtz;
            parameters[78].Value = model.zpz;
            parameters[79].Value = model.wzz;
            parameters[80].Value = model.dpz;
            parameters[81].Value = model.wjgbdm;
            parameters[82].Value = model.wjlxdm;
            parameters[83].Value = model.wjgs;
            parameters[84].Value = model.wjdx;
            parameters[85].Value = model.psdd;
            parameters[86].Value = model.psz;
            parameters[87].Value = model.pssj;
            parameters[88].Value = model.sb;
            parameters[89].Value = model.fbl;
            parameters[90].Value = model.xjpp;
            parameters[91].Value = model.xjxh;
            parameters[92].Value = model.bz;
            parameters[93].Value = model.RootPath;

            parameters[94].Value = model.XAXIS_RESOLUTION;
            parameters[95].Value = model.YAXIS_RESOLUTION;
            parameters[96].Value = model.IMAGE_WIDTH;
            parameters[97].Value = model.IMAGE_HEIGHT;
            parameters[98].Value = model.DATA_FICAL_LENGTH;
            parameters[99].Value = model.DATA_APERTURE;
            parameters[100].Value = model.DATA_APERTURE_XS;
            parameters[101].Value = model.FLASH;
            parameters[102].Value = model.WHITE_BALANCE;
            parameters[103].Value = model.ISO_SPEED_RATINGS;
            parameters[104].Value = model.EXPOSURE_PROGRAM;
            parameters[105].Value = model.EXPOSURE_MODE;
            parameters[106].Value = model.DATA_EXPOSURE_TIME;
            parameters[107].Value = model.QUALITY;
            parameters[108].Value = model.CONTRAST;
            parameters[109].Value = model.SATURATION;
            parameters[110].Value = model.MAX_APERTURE;
            parameters[111].Value = model.CONVERT_FLAG;
            parameters[112].Value = model.SIGNATURE_FLAG;
            parameters[113].Value = model.FROM_SID;
            parameters[114].Value = model.OldRecID;
            parameters[115].Value = model.MyOrderIndex;
            parameters[116].Value = model.FileFrom;
            parameters[117].Value = model.IsMerge;
            parameters[118].Value = model.Version;
            parameters[119].Value = model.iSignaturePdf;
            parameters[120].Value = model.iSignatureWorkFlow;


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
        public void Update(DigiPower.Onlinecol.Standard.Model.T_FileList_MDL model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_FileList set ");
            strSql.Append("SingleProjectID=@SingleProjectID,");
            strSql.Append("ArchiveID=@ArchiveID,");
            strSql.Append("MyArchiveID=@MyArchiveID,");
            strSql.Append("recID=@recID,");
            strSql.Append("PID=@PID,");
            strSql.Append("DefaultCompanyType=@DefaultCompanyType,");
            strSql.Append("DH=@DH,");
            strSql.Append("MyCode=@MyCode,");
            strSql.Append("BH=@BH,");
            strSql.Append("Title=@Title,");
            strSql.Append("MustSubmitFlag=@MustSubmitFlag,");
            strSql.Append("OldStatus=@OldStatus,");
            strSql.Append("Status=@Status,");
            strSql.Append("StartTime=@StartTime,");
            strSql.Append("EndTime=@EndTime,");
            strSql.Append("CompanyID=@CompanyID,");
            strSql.Append("OperateUserID=@OperateUserID,");
            strSql.Append("OperateUserName=@OperateUserName,");
            strSql.Append("OrderIndex=@OrderIndex,");
            strSql.Append("ManualCount=@ManualCount,");
            strSql.Append("PagesCount=@PagesCount,");
            strSql.Append("WinRecvPagesCount=@WinRecvPagesCount,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("PDFFilePath=@PDFFilePath,");
            strSql.Append("AlonePack=@AlonePack,");
            strSql.Append("IsFolder=@IsFolder,");
            strSql.Append("IsSystem=@IsSystem,");
            strSql.Append("FileType=@FileType,");
            strSql.Append("archive_form_no=@archive_form_no,");
            strSql.Append("zajh=@zajh,");
            strSql.Append("w_t_h=@w_t_h,");
            strSql.Append("wjtm=@wjtm,");
            strSql.Append("zrr=@zrr,");
            strSql.Append("qssj=@qssj,");
            strSql.Append("zzsj=@zzsj,");
            strSql.Append("yc=@yc,");
            strSql.Append("wb=@wb,");
            strSql.Append("sl=@sl,");
            strSql.Append("bgqx=@bgqx,");
            strSql.Append("mj=@mj,");
            strSql.Append("dz_k=@dz_k,");
            strSql.Append("dz_l=@dz_l,");
            strSql.Append("dz_g=@dz_g,");
            strSql.Append("dz_c=@dz_c,");
            strSql.Append("dz_x=@dz_x,");
            strSql.Append("ztlx=@ztlx,");
            strSql.Append("dw=@dw,");
            strSql.Append("gg=@gg,");
            strSql.Append("ty=@ty,");
            strSql.Append("ztc=@ztc,");
            strSql.Append("note=@note,");
            strSql.Append("sw=@sw,");
            strSql.Append("dz=@dz,");
            strSql.Append("lrr=@lrr,");
            strSql.Append("lrsj=@lrsj,");
            strSql.Append("shzt=@shzt,");
            strSql.Append("shr_1=@shr_1,");
            strSql.Append("shsj_1=@shsj_1,");
            strSql.Append("shr_2=@shr_2,");
            strSql.Append("shsj_2=@shsj_2,");
            strSql.Append("shr_3=@shr_3,");
            strSql.Append("shsj_3=@shsj_3,");
            strSql.Append("aipdate=@aipdate,");
            strSql.Append("aipuser=@aipuser,");
            strSql.Append("ShortDH=@ShortDH,");
            strSql.Append("swgph=@swgph,");
            strSql.Append("cfdz=@cfdz,");
            strSql.Append("wjbt=@wjbt,");
            strSql.Append("zrz=@zrz,");
            strSql.Append("wh=@wh,");
            strSql.Append("wjfwqx=@wjfwqx,");
            strSql.Append("xcsj=@xcsj,");
            strSql.Append("dzwjxx=@dzwjxx,");
            strSql.Append("fz=@fz,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("CreateDate2=@CreateDate2,");
            strSql.Append("tzz=@tzz,");
            strSql.Append("dtz=@dtz,");
            strSql.Append("zpz=@zpz,");
            strSql.Append("wzz=@wzz,");
            strSql.Append("dpz=@dpz,");
            strSql.Append("wjgbdm=@wjgbdm,");
            strSql.Append("wjlxdm=@wjlxdm,");
            strSql.Append("wjgs=@wjgs,");
            strSql.Append("wjdx=@wjdx,");
            strSql.Append("psdd=@psdd,");
            strSql.Append("psz=@psz,");
            strSql.Append("pssj=@pssj,");
            strSql.Append("sb=@sb,");
            strSql.Append("fbl=@fbl,");
            strSql.Append("xjpp=@xjpp,");
            strSql.Append("xjxh=@xjxh,");
            strSql.Append("bz=@bz,");
            strSql.Append("CONVERT_FLAG=@CONVERT_FLAG,");
            strSql.Append("CONVERT_DT=@CONVERT_DT,");
            strSql.Append("RootPath=@RootPath,");

            strSql.Append("XAXIS_RESOLUTION=@XAXIS_RESOLUTION,");
            strSql.Append("YAXIS_RESOLUTION=@YAXIS_RESOLUTION,");
            strSql.Append("IMAGE_WIDTH=@IMAGE_WIDTH,");
            strSql.Append("IMAGE_HEIGHT=@IMAGE_HEIGHT,");
            strSql.Append("DATA_FICAL_LENGTH=@DATA_FICAL_LENGTH,");
            strSql.Append("DATA_APERTURE=@DATA_APERTURE,");
            strSql.Append("DATA_APERTURE_XS=@DATA_APERTURE_XS,");
            strSql.Append("FLASH=@FLASH,");
            strSql.Append("WHITE_BALANCE=@WHITE_BALANCE,");
            strSql.Append("ISO_SPEED_RATINGS=@ISO_SPEED_RATINGS,");
            strSql.Append("EXPOSURE_PROGRAM=@EXPOSURE_PROGRAM,");
            strSql.Append("EXPOSURE_MODE=@EXPOSURE_MODE,");
            strSql.Append("DATA_EXPOSURE_TIME=@DATA_EXPOSURE_TIME,");
            strSql.Append("QUALITY=@QUALITY,");
            strSql.Append("CONTRAST=@CONTRAST,");
            strSql.Append("SATURATION=@SATURATION,");
            strSql.Append("MAX_APERTURE=@MAX_APERTURE,");
            strSql.Append("SIGNATURE_FLAG=@SIGNATURE_FLAG,");
            strSql.Append("SIGNATURE_DT=@SIGNATURE_DT,");
            strSql.Append("FROM_SID=@FROM_SID,");
            strSql.Append("OldRecID=@OldRecID,");
            strSql.Append("MyOrderIndex=@MyOrderIndex,");
            strSql.Append("FileFrom=@FileFrom,");
            strSql.Append("IsMerge=@IsMerge,");
            strSql.Append("Version=@Version,");
            strSql.Append("iSignaturePdf=@iSignaturePdf,");
            strSql.Append("iSignatureWorkFlow=@iSignatureWorkFlow");

            strSql.Append(" where FileListID=@FileListID ");
            SqlParameter[] parameters = {
					new SqlParameter("@FileListID", SqlDbType.Int,8),
					new SqlParameter("@SingleProjectID", SqlDbType.Int,8),
					new SqlParameter("@ArchiveID", SqlDbType.Int,8),
					new SqlParameter("@MyArchiveID", SqlDbType.Int,8),
					new SqlParameter("@recID", SqlDbType.Int,8),
					new SqlParameter("@PID", SqlDbType.Int,8),
					new SqlParameter("@DefaultCompanyType", SqlDbType.Int,8),
					new SqlParameter("@DH", SqlDbType.NVarChar,30),
					new SqlParameter("@MyCode", SqlDbType.NVarChar,50),
					new SqlParameter("@BH", SqlDbType.NVarChar,20),
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@MustSubmitFlag", SqlDbType.Bit,1),
					new SqlParameter("@OldStatus", SqlDbType.NVarChar,20),
					new SqlParameter("@Status", SqlDbType.NVarChar,20),
					new SqlParameter("@StartTime", SqlDbType.NVarChar,20),
					new SqlParameter("@EndTime", SqlDbType.NVarChar,20),
					new SqlParameter("@CompanyID", SqlDbType.Int,8),
					new SqlParameter("@OperateUserID", SqlDbType.Int,8),
					new SqlParameter("@OperateUserName", SqlDbType.NVarChar,20),
					new SqlParameter("@OrderIndex", SqlDbType.Int,8),
					new SqlParameter("@ManualCount", SqlDbType.Int,8),
					new SqlParameter("@PagesCount", SqlDbType.Int,8),
					new SqlParameter("@WinRecvPagesCount", SqlDbType.Int,8),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@PDFFilePath", SqlDbType.NVarChar,250),
					new SqlParameter("@AlonePack", SqlDbType.Bit,1),
					new SqlParameter("@IsFolder", SqlDbType.Bit,1),
					new SqlParameter("@IsSystem", SqlDbType.Bit,1),
					new SqlParameter("@FileType", SqlDbType.NVarChar,20),
					new SqlParameter("@archive_form_no", SqlDbType.VarChar,20),
					new SqlParameter("@zajh", SqlDbType.VarChar,20),
					new SqlParameter("@w_t_h", SqlDbType.VarChar,100),
					new SqlParameter("@wjtm", SqlDbType.VarChar,250),
					new SqlParameter("@zrr", SqlDbType.VarChar,100),
					new SqlParameter("@qssj", SqlDbType.DateTime),
					new SqlParameter("@zzsj", SqlDbType.DateTime),
					new SqlParameter("@yc", SqlDbType.VarChar,20),
					new SqlParameter("@wb", SqlDbType.VarChar,200),
					new SqlParameter("@sl", SqlDbType.Int,8),
					new SqlParameter("@bgqx", SqlDbType.VarChar,20),
					new SqlParameter("@mj", SqlDbType.VarChar,10),
					new SqlParameter("@dz_k", SqlDbType.VarChar,10),
					new SqlParameter("@dz_l", SqlDbType.VarChar,10),
					new SqlParameter("@dz_g", SqlDbType.VarChar,10),
					new SqlParameter("@dz_c", SqlDbType.VarChar,10),
					new SqlParameter("@dz_x", SqlDbType.VarChar,10),
					new SqlParameter("@ztlx", SqlDbType.VarChar,10),
					new SqlParameter("@dw", SqlDbType.VarChar,10),
					new SqlParameter("@gg", SqlDbType.VarChar,10),
					new SqlParameter("@ty", SqlDbType.VarChar,200),
					new SqlParameter("@ztc", SqlDbType.VarChar,250),
					new SqlParameter("@note", SqlDbType.VarChar,250),
					new SqlParameter("@sw", SqlDbType.VarChar,30),
					new SqlParameter("@dz", SqlDbType.VarChar,200),
					new SqlParameter("@lrr", SqlDbType.VarChar,10),
					new SqlParameter("@lrsj", SqlDbType.DateTime),
					new SqlParameter("@shzt", SqlDbType.SmallInt,2),
					new SqlParameter("@shr_1", SqlDbType.VarChar,20),
					new SqlParameter("@shsj_1", SqlDbType.DateTime),
					new SqlParameter("@shr_2", SqlDbType.VarChar,20),
					new SqlParameter("@shsj_2", SqlDbType.DateTime),
					new SqlParameter("@shr_3", SqlDbType.VarChar,20),
					new SqlParameter("@shsj_3", SqlDbType.DateTime),
					new SqlParameter("@aipdate", SqlDbType.DateTime),
					new SqlParameter("@aipuser", SqlDbType.VarChar,20),
					new SqlParameter("@ShortDH", SqlDbType.VarChar,30),
					new SqlParameter("@swgph", SqlDbType.VarChar,20),
					new SqlParameter("@cfdz", SqlDbType.VarChar,254),
					new SqlParameter("@wjbt", SqlDbType.VarChar,254),
					new SqlParameter("@zrz", SqlDbType.VarChar,20),
					new SqlParameter("@wh", SqlDbType.VarChar,20),
					new SqlParameter("@wjfwqx", SqlDbType.VarChar,20),
					new SqlParameter("@xcsj", SqlDbType.VarChar,10),
					new SqlParameter("@dzwjxx", SqlDbType.Text),
					new SqlParameter("@fz", SqlDbType.Text),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@CreateDate2", SqlDbType.DateTime),
					new SqlParameter("@tzz", SqlDbType.Int,8),
					new SqlParameter("@dtz", SqlDbType.Int,8),
					new SqlParameter("@zpz", SqlDbType.Int,8),
					new SqlParameter("@wzz", SqlDbType.Int,8),
					new SqlParameter("@dpz", SqlDbType.Int,8),
					new SqlParameter("@wjgbdm", SqlDbType.NVarChar,50),
					new SqlParameter("@wjlxdm", SqlDbType.NVarChar,50),
					new SqlParameter("@wjgs", SqlDbType.NVarChar,50),
					new SqlParameter("@wjdx", SqlDbType.NVarChar,50),
					new SqlParameter("@psdd", SqlDbType.NVarChar,50),
					new SqlParameter("@psz", SqlDbType.NVarChar,50),
					new SqlParameter("@pssj", SqlDbType.DateTime),
					new SqlParameter("@sb", SqlDbType.NVarChar,50),
					new SqlParameter("@fbl", SqlDbType.NVarChar,50),
					new SqlParameter("@xjpp", SqlDbType.NVarChar,50),
					new SqlParameter("@xjxh", SqlDbType.NVarChar,50),
					new SqlParameter("@bz", SqlDbType.NVarChar,1000),
                    new SqlParameter("@CONVERT_FLAG", SqlDbType.Bit,1),
                    new SqlParameter("@CONVERT_DT", SqlDbType.NVarChar,20),
            		new SqlParameter("@RootPath", SqlDbType.VarChar,100), 
                    
                    new SqlParameter("@XAXIS_RESOLUTION", SqlDbType.VarChar,200),
                    new SqlParameter("@YAXIS_RESOLUTION", SqlDbType.VarChar,200),
                    new SqlParameter("@IMAGE_WIDTH", SqlDbType.VarChar,200),
                    new SqlParameter("@IMAGE_HEIGHT", SqlDbType.VarChar,200),
                    new SqlParameter("@DATA_FICAL_LENGTH", SqlDbType.VarChar,200),
                    new SqlParameter("@DATA_APERTURE", SqlDbType.VarChar,200),
                    new SqlParameter("@DATA_APERTURE_XS", SqlDbType.VarChar,200),
                    new SqlParameter("@FLASH", SqlDbType.VarChar,200),
                    new SqlParameter("@WHITE_BALANCE", SqlDbType.VarChar,200),
                    new SqlParameter("@ISO_SPEED_RATINGS", SqlDbType.VarChar,200),
                    new SqlParameter("@EXPOSURE_PROGRAM", SqlDbType.VarChar,200),
                    new SqlParameter("@EXPOSURE_MODE", SqlDbType.VarChar,200),
                    new SqlParameter("@DATA_EXPOSURE_TIME", SqlDbType.VarChar,200),
                    new SqlParameter("@QUALITY", SqlDbType.VarChar,200),
                    new SqlParameter("@CONTRAST", SqlDbType.VarChar,200),
                    new SqlParameter("@SATURATION", SqlDbType.VarChar,200),
                    new SqlParameter("@MAX_APERTURE", SqlDbType.VarChar,200),
					new SqlParameter("@SIGNATURE_FLAG", SqlDbType.Bit,1),
                    new SqlParameter("@SIGNATURE_DT", SqlDbType.NVarChar,20),
                    new SqlParameter("@FROM_SID", SqlDbType.NVarChar,100),
                   	new SqlParameter("@OldRecID", SqlDbType.Int,8),
                    new SqlParameter("@MyOrderIndex", SqlDbType.Int,8),
                    new SqlParameter("@FileFrom", SqlDbType.NVarChar,100),
                    new SqlParameter("@IsMerge", SqlDbType.NVarChar,2),
                    new SqlParameter("@Version", SqlDbType.Int,8),
                    new SqlParameter("@iSignaturePdf", SqlDbType.Bit,1),
                    new SqlParameter("@iSignatureWorkFlow", SqlDbType.Bit,1)};



            parameters[0].Value = model.FileListID;
            parameters[1].Value = model.SingleProjectID;
            parameters[2].Value = model.ArchiveID;
            parameters[3].Value = model.MyArchiveID;
            parameters[4].Value = model.recID;
            parameters[5].Value = model.PID;
            parameters[6].Value = model.DefaultCompanyType;
            parameters[7].Value = model.DH;
            parameters[8].Value = model.MyCode;
            parameters[9].Value = model.BH;
            parameters[10].Value = model.Title;
            parameters[11].Value = model.MustSubmitFlag;
            parameters[12].Value = model.OldStatus;
            parameters[13].Value = model.Status;
            parameters[14].Value = model.StartTime;
            parameters[15].Value = model.EndTime;
            parameters[16].Value = model.CompanyID;
            parameters[17].Value = model.OperateUserID;
            parameters[18].Value = model.OperateUserName;
            parameters[19].Value = model.OrderIndex;
            parameters[20].Value = model.ManualCount;
            parameters[21].Value = model.PagesCount;
            parameters[22].Value = model.WinRecvPagesCount;
            parameters[23].Value = model.Remark;
            parameters[24].Value = model.PDFFilePath;
            parameters[25].Value = model.AlonePack;
            parameters[26].Value = model.IsFolder;
            parameters[27].Value = model.IsSystem;
            parameters[28].Value = model.FileType;
            parameters[29].Value = model.archive_form_no;
            parameters[30].Value = model.zajh;
            parameters[31].Value = model.w_t_h;
            parameters[32].Value = model.wjtm;
            parameters[33].Value = model.zrr;
            parameters[34].Value = model.qssj;
            parameters[35].Value = model.zzsj;
            parameters[36].Value = model.yc;
            parameters[37].Value = model.wb;
            parameters[38].Value = model.sl;
            parameters[39].Value = model.bgqx;
            parameters[40].Value = model.mj;
            parameters[41].Value = model.dz_k;
            parameters[42].Value = model.dz_l;
            parameters[43].Value = model.dz_g;
            parameters[44].Value = model.dz_c;
            parameters[45].Value = model.dz_x;
            parameters[46].Value = model.ztlx;
            parameters[47].Value = model.dw;
            parameters[48].Value = model.gg;
            parameters[49].Value = model.ty;
            parameters[50].Value = model.ztc;
            parameters[51].Value = model.note;
            parameters[52].Value = model.sw;
            parameters[53].Value = model.dz;
            parameters[54].Value = model.lrr;
            parameters[55].Value = model.lrsj;
            parameters[56].Value = model.shzt;
            parameters[57].Value = model.shr_1;
            parameters[58].Value = model.shsj_1;
            parameters[59].Value = model.shr_2;
            parameters[60].Value = model.shsj_2;
            parameters[61].Value = model.shr_3;
            parameters[62].Value = model.shsj_3;
            parameters[63].Value = model.aipdate;
            parameters[64].Value = model.aipuser;
            parameters[65].Value = model.ShortDH;
            parameters[66].Value = model.swgph;
            parameters[67].Value = model.cfdz;
            parameters[68].Value = model.wjbt;
            parameters[69].Value = model.zrz;
            parameters[70].Value = model.wh;
            parameters[71].Value = model.wjfwqx;
            parameters[72].Value = model.xcsj;
            parameters[73].Value = model.dzwjxx;
            parameters[74].Value = model.fz;
            parameters[75].Value = model.CreateDate;
            parameters[76].Value = model.CreateDate2;
            parameters[77].Value = model.tzz;
            parameters[78].Value = model.dtz;
            parameters[79].Value = model.zpz;
            parameters[80].Value = model.wzz;
            parameters[81].Value = model.dpz;
            parameters[82].Value = model.wjgbdm;
            parameters[83].Value = model.wjlxdm;
            parameters[84].Value = model.wjgs;
            parameters[85].Value = model.wjdx;
            parameters[86].Value = model.psdd;
            parameters[87].Value = model.psz;
            parameters[88].Value = model.pssj;
            parameters[89].Value = model.sb;
            parameters[90].Value = model.fbl;
            parameters[91].Value = model.xjpp;
            parameters[92].Value = model.xjxh;
            parameters[93].Value = model.bz;
            parameters[94].Value = model.CONVERT_FLAG;
            parameters[95].Value = model.CONVERT_DT;
            parameters[96].Value = model.RootPath;

            parameters[97].Value = model.XAXIS_RESOLUTION;
            parameters[98].Value = model.YAXIS_RESOLUTION;
            parameters[99].Value = model.IMAGE_WIDTH;
            parameters[100].Value = model.IMAGE_HEIGHT;
            parameters[101].Value = model.DATA_FICAL_LENGTH;
            parameters[102].Value = model.DATA_APERTURE;
            parameters[103].Value = model.DATA_APERTURE_XS;
            parameters[104].Value = model.FLASH;
            parameters[105].Value = model.WHITE_BALANCE;
            parameters[106].Value = model.ISO_SPEED_RATINGS;
            parameters[107].Value = model.EXPOSURE_PROGRAM;
            parameters[108].Value = model.EXPOSURE_MODE;
            parameters[109].Value = model.DATA_EXPOSURE_TIME;
            parameters[110].Value = model.QUALITY;
            parameters[111].Value = model.CONTRAST;
            parameters[112].Value = model.SATURATION;
            parameters[113].Value = model.MAX_APERTURE;
            parameters[114].Value = model.SIGNATURE_FLAG;
            parameters[115].Value = model.SIGNATURE_DT;
            parameters[116].Value = model.FROM_SID;
            parameters[117].Value = model.OldRecID;
            parameters[118].Value = model.MyOrderIndex;
            parameters[119].Value = model.FileFrom;
            parameters[120].Value = model.IsMerge;
            parameters[121].Value = model.Version;
            parameters[122].Value = model.iSignaturePdf;
            parameters[123].Value = model.iSignatureWorkFlow;


            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int FileListID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_FileList ");
            strSql.Append(" where FileListID=@FileListID ");
            SqlParameter[] parameters = {
					new SqlParameter("@FileListID", SqlDbType.Int,8)};
            parameters[0].Value = FileListID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int FileListID, string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_FileList ");
            strSql.Append(" where FileListID=@FileListID ");
            SqlParameter[] parameters = {
					new SqlParameter("@FileListID", SqlDbType.Int,8)};
            parameters[0].Value = FileListID;

            if (strWhere.Trim() != "") {
                strSql.Append(" And " + strWhere);
            }
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_FileList_MDL GetModel(int FileListID) {

            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select  top 1 FileListID,SingleProjectID,ArchiveID,MyArchiveID,recID,PID,DefaultCompanyType,DH,MyCode,BH,Title,MustSubmitFlag,OldStatus,Status,StartTime,EndTime,CompanyID,OperateUserID,OperateUserName,OrderIndex,ManualCount,PagesCount,WinRecvPagesCount,Remark,PDFFilePath,AlonePack,IsFolder,IsSystem,FileType,archive_form_no,zajh,w_t_h,wjtm,zrr,qssj,zzsj,yc,wb,sl,bgqx,mj,dz_k,dz_l,dz_g,dz_c,dz_x,ztlx,dw,gg,ty,ztc,note,sw,dz,lrr,lrsj,shzt,shr_1,shsj_1,shr_2,shsj_2,shr_3,shsj_3,aipdate,aipuser,ShortDH,swgph,cfdz,wjbt,zrz,wh,wjfwqx,xcsj,dzwjxx,fz,CreateDate,CreateDate2,tzz,dtz,zpz,wzz,dpz,wjgbdm,wjlxdm,wjgs,wjdx,psdd,psz,pssj,sb,fbl,xjpp,xjxh,bz,RootPath, ");
            //strSql.Append("XAXIS_RESOLUTION,YAXIS_RESOLUTION,IMAGE_WIDTH,IMAGE_HEIGHT,DATA_FICAL_LENGTH,DATA_APERTURE,");
            //strSql.Append("DATA_APERTURE_XS,FLASH,WHITE_BALANCE,ISO_SPEED_RATINGS,EXPOSURE_PROGRAM,EXPOSURE_MODE,");
            //strSql.Append("DATA_EXPOSURE_TIME,QUALITY,CONTRAST,SATURATION,MAX_APERTURE,FROM_SID from T_FileList ");
            strSql.Append("select  top 1 * from T_FileList ");
            strSql.Append(" where FileListID=@FileListID ");
            SqlParameter[] parameters = {
					new SqlParameter("@FileListID", SqlDbType.Int,8)};
            parameters[0].Value = FileListID;

            DigiPower.Onlinecol.Standard.Model.T_FileList_MDL model = new DigiPower.Onlinecol.Standard.Model.T_FileList_MDL();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["FileListID"].ToString() != "") {
                    model.FileListID = int.Parse(ds.Tables[0].Rows[0]["FileListID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SingleProjectID"].ToString() != "") {
                    model.SingleProjectID = int.Parse(ds.Tables[0].Rows[0]["SingleProjectID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ArchiveID"].ToString() != "") {
                    model.ArchiveID = int.Parse(ds.Tables[0].Rows[0]["ArchiveID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MyArchiveID"].ToString() != "") {
                    model.MyArchiveID = int.Parse(ds.Tables[0].Rows[0]["MyArchiveID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["recID"].ToString() != "") {
                    model.recID = int.Parse(ds.Tables[0].Rows[0]["recID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PID"].ToString() != "") {
                    model.PID = int.Parse(ds.Tables[0].Rows[0]["PID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DefaultCompanyType"].ToString() != "") {
                    model.DefaultCompanyType = int.Parse(ds.Tables[0].Rows[0]["DefaultCompanyType"].ToString());
                }
                model.DH = ds.Tables[0].Rows[0]["DH"].ToString();
                model.MyCode = ds.Tables[0].Rows[0]["MyCode"].ToString();
                model.BH = ds.Tables[0].Rows[0]["BH"].ToString();
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                if (ds.Tables[0].Rows[0]["MustSubmitFlag"].ToString() != "") {
                    if ((ds.Tables[0].Rows[0]["MustSubmitFlag"].ToString() == "1") || (ds.Tables[0].Rows[0]["MustSubmitFlag"].ToString().ToLower() == "true")) {
                        model.MustSubmitFlag = true;
                    } else {
                        model.MustSubmitFlag = false;
                    }
                }
                model.OldStatus = ds.Tables[0].Rows[0]["OldStatus"].ToString();
                model.Status = ds.Tables[0].Rows[0]["Status"].ToString();
                model.StartTime = ds.Tables[0].Rows[0]["StartTime"].ToString();
                model.EndTime = ds.Tables[0].Rows[0]["EndTime"].ToString();
                if (ds.Tables[0].Rows[0]["CompanyID"].ToString() != "") {
                    model.CompanyID = int.Parse(ds.Tables[0].Rows[0]["CompanyID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OperateUserID"].ToString() != "") {
                    model.OperateUserID = int.Parse(ds.Tables[0].Rows[0]["OperateUserID"].ToString());
                }
                model.OperateUserName = ds.Tables[0].Rows[0]["OperateUserName"].ToString();
                if (ds.Tables[0].Rows[0]["OrderIndex"].ToString() != "") {
                    model.OrderIndex = int.Parse(ds.Tables[0].Rows[0]["OrderIndex"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ManualCount"].ToString() != "") {
                    model.ManualCount = int.Parse(ds.Tables[0].Rows[0]["ManualCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PagesCount"].ToString() != "") {
                    model.PagesCount = int.Parse(ds.Tables[0].Rows[0]["PagesCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WinRecvPagesCount"].ToString() != "") {
                    model.WinRecvPagesCount = int.Parse(ds.Tables[0].Rows[0]["WinRecvPagesCount"].ToString());
                }
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                model.PDFFilePath = ds.Tables[0].Rows[0]["PDFFilePath"].ToString();
                if (ds.Tables[0].Rows[0]["AlonePack"].ToString() != "") {
                    if ((ds.Tables[0].Rows[0]["AlonePack"].ToString() == "1") || (ds.Tables[0].Rows[0]["AlonePack"].ToString().ToLower() == "true")) {
                        model.AlonePack = true;
                    } else {
                        model.AlonePack = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["IsFolder"].ToString() != "") {
                    if ((ds.Tables[0].Rows[0]["IsFolder"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsFolder"].ToString().ToLower() == "true")) {
                        model.IsFolder = true;
                    } else {
                        model.IsFolder = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["IsSystem"].ToString() != "") {
                    if ((ds.Tables[0].Rows[0]["IsSystem"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsSystem"].ToString().ToLower() == "true")) {
                        model.IsSystem = true;
                    } else {
                        model.IsSystem = false;
                    }
                }
                model.FileType = ds.Tables[0].Rows[0]["FileType"].ToString();
                model.archive_form_no = ds.Tables[0].Rows[0]["archive_form_no"].ToString();
                model.zajh = ds.Tables[0].Rows[0]["zajh"].ToString();
                model.w_t_h = ds.Tables[0].Rows[0]["w_t_h"].ToString();
                model.wjtm = ds.Tables[0].Rows[0]["wjtm"].ToString();
                model.zrr = ds.Tables[0].Rows[0]["zrr"].ToString();
                if (ds.Tables[0].Rows[0]["qssj"].ToString() != "") {
                    model.qssj = DateTime.Parse(ds.Tables[0].Rows[0]["qssj"].ToString());
                }
                if (ds.Tables[0].Rows[0]["zzsj"].ToString() != "") {
                    model.zzsj = DateTime.Parse(ds.Tables[0].Rows[0]["zzsj"].ToString());
                }
                model.yc = ds.Tables[0].Rows[0]["yc"].ToString();
                model.wb = ds.Tables[0].Rows[0]["wb"].ToString();
                if (ds.Tables[0].Rows[0]["sl"].ToString() != "") {
                    model.sl = int.Parse(ds.Tables[0].Rows[0]["sl"].ToString());
                }
                model.bgqx = ds.Tables[0].Rows[0]["bgqx"].ToString();
                model.mj = ds.Tables[0].Rows[0]["mj"].ToString();
                model.dz_k = ds.Tables[0].Rows[0]["dz_k"].ToString();
                model.dz_l = ds.Tables[0].Rows[0]["dz_l"].ToString();
                model.dz_g = ds.Tables[0].Rows[0]["dz_g"].ToString();
                model.dz_c = ds.Tables[0].Rows[0]["dz_c"].ToString();
                model.dz_x = ds.Tables[0].Rows[0]["dz_x"].ToString();
                model.ztlx = ds.Tables[0].Rows[0]["ztlx"].ToString();
                model.dw = ds.Tables[0].Rows[0]["dw"].ToString();
                model.gg = ds.Tables[0].Rows[0]["gg"].ToString();
                model.ty = ds.Tables[0].Rows[0]["ty"].ToString();
                model.ztc = ds.Tables[0].Rows[0]["ztc"].ToString();
                model.note = ds.Tables[0].Rows[0]["note"].ToString();
                model.sw = ds.Tables[0].Rows[0]["sw"].ToString();
                model.dz = ds.Tables[0].Rows[0]["dz"].ToString();
                model.lrr = ds.Tables[0].Rows[0]["lrr"].ToString();
                if (ds.Tables[0].Rows[0]["lrsj"].ToString() != "") {
                    model.lrsj = DateTime.Parse(ds.Tables[0].Rows[0]["lrsj"].ToString());
                }
                if (ds.Tables[0].Rows[0]["shzt"].ToString() != "") {
                    model.shzt = int.Parse(ds.Tables[0].Rows[0]["shzt"].ToString());
                }
                model.shr_1 = ds.Tables[0].Rows[0]["shr_1"].ToString();
                if (ds.Tables[0].Rows[0]["shsj_1"].ToString() != "") {
                    model.shsj_1 = DateTime.Parse(ds.Tables[0].Rows[0]["shsj_1"].ToString());
                }
                model.shr_2 = ds.Tables[0].Rows[0]["shr_2"].ToString();
                if (ds.Tables[0].Rows[0]["shsj_2"].ToString() != "") {
                    model.shsj_2 = DateTime.Parse(ds.Tables[0].Rows[0]["shsj_2"].ToString());
                }
                model.shr_3 = ds.Tables[0].Rows[0]["shr_3"].ToString();
                if (ds.Tables[0].Rows[0]["shsj_3"].ToString() != "") {
                    model.shsj_3 = DateTime.Parse(ds.Tables[0].Rows[0]["shsj_3"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aipdate"].ToString() != "") {
                    model.aipdate = DateTime.Parse(ds.Tables[0].Rows[0]["aipdate"].ToString());
                }
                model.aipuser = ds.Tables[0].Rows[0]["aipuser"].ToString();
                model.ShortDH = ds.Tables[0].Rows[0]["ShortDH"].ToString();
                model.swgph = ds.Tables[0].Rows[0]["swgph"].ToString();
                model.cfdz = ds.Tables[0].Rows[0]["cfdz"].ToString();
                model.wjbt = ds.Tables[0].Rows[0]["wjbt"].ToString();
                model.zrz = ds.Tables[0].Rows[0]["zrz"].ToString();
                model.wh = ds.Tables[0].Rows[0]["wh"].ToString();
                model.wjfwqx = ds.Tables[0].Rows[0]["wjfwqx"].ToString();
                model.xcsj = ds.Tables[0].Rows[0]["xcsj"].ToString();
                model.dzwjxx = ds.Tables[0].Rows[0]["dzwjxx"].ToString();
                model.fz = ds.Tables[0].Rows[0]["fz"].ToString();
                if (ds.Tables[0].Rows[0]["CreateDate"].ToString() != "") {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateDate2"].ToString() != "") {
                    model.CreateDate2 = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["tzz"].ToString() != "") {
                    model.tzz = int.Parse(ds.Tables[0].Rows[0]["tzz"].ToString());
                }
                if (ds.Tables[0].Rows[0]["dtz"].ToString() != "") {
                    model.dtz = int.Parse(ds.Tables[0].Rows[0]["dtz"].ToString());
                }
                if (ds.Tables[0].Rows[0]["zpz"].ToString() != "") {
                    model.zpz = int.Parse(ds.Tables[0].Rows[0]["zpz"].ToString());
                }
                if (ds.Tables[0].Rows[0]["wzz"].ToString() != "") {
                    model.wzz = int.Parse(ds.Tables[0].Rows[0]["wzz"].ToString());
                }
                if (ds.Tables[0].Rows[0]["dpz"].ToString() != "") {
                    model.dpz = int.Parse(ds.Tables[0].Rows[0]["dpz"].ToString());
                }
                model.wjgbdm = ds.Tables[0].Rows[0]["wjgbdm"].ToString();
                model.wjlxdm = ds.Tables[0].Rows[0]["wjlxdm"].ToString();
                model.wjgs = ds.Tables[0].Rows[0]["wjgs"].ToString();
                model.wjdx = ds.Tables[0].Rows[0]["wjdx"].ToString();
                model.psdd = ds.Tables[0].Rows[0]["psdd"].ToString();
                model.psz = ds.Tables[0].Rows[0]["psz"].ToString();
                if (ds.Tables[0].Rows[0]["pssj"].ToString() != "") {
                    model.pssj = DateTime.Parse(ds.Tables[0].Rows[0]["pssj"].ToString());
                }
                model.sb = ds.Tables[0].Rows[0]["sb"].ToString();
                model.fbl = ds.Tables[0].Rows[0]["fbl"].ToString();
                model.xjpp = ds.Tables[0].Rows[0]["xjpp"].ToString();
                model.xjxh = ds.Tables[0].Rows[0]["xjxh"].ToString();
                model.bz = ds.Tables[0].Rows[0]["bz"].ToString();
                model.RootPath = ds.Tables[0].Rows[0]["RootPath"].ToString();

                model.XAXIS_RESOLUTION = ds.Tables[0].Rows[0]["XAXIS_RESOLUTION"].ToString();
                model.YAXIS_RESOLUTION = ds.Tables[0].Rows[0]["YAXIS_RESOLUTION"].ToString();
                model.IMAGE_WIDTH = ds.Tables[0].Rows[0]["IMAGE_WIDTH"].ToString();
                model.IMAGE_HEIGHT = ds.Tables[0].Rows[0]["IMAGE_HEIGHT"].ToString();
                model.DATA_FICAL_LENGTH = ds.Tables[0].Rows[0]["DATA_FICAL_LENGTH"].ToString();
                model.DATA_APERTURE = ds.Tables[0].Rows[0]["DATA_APERTURE"].ToString();
                model.DATA_APERTURE_XS = ds.Tables[0].Rows[0]["DATA_APERTURE_XS"].ToString();
                model.FLASH = ds.Tables[0].Rows[0]["FLASH"].ToString();
                model.WHITE_BALANCE = ds.Tables[0].Rows[0]["WHITE_BALANCE"].ToString();
                model.ISO_SPEED_RATINGS = ds.Tables[0].Rows[0]["ISO_SPEED_RATINGS"].ToString();
                model.EXPOSURE_PROGRAM = ds.Tables[0].Rows[0]["EXPOSURE_PROGRAM"].ToString();
                model.EXPOSURE_MODE = ds.Tables[0].Rows[0]["EXPOSURE_MODE"].ToString();
                model.DATA_EXPOSURE_TIME = ds.Tables[0].Rows[0]["DATA_EXPOSURE_TIME"].ToString();
                model.QUALITY = ds.Tables[0].Rows[0]["QUALITY"].ToString();
                model.CONTRAST = ds.Tables[0].Rows[0]["CONTRAST"].ToString();
                model.SATURATION = ds.Tables[0].Rows[0]["SATURATION"].ToString();
                model.MAX_APERTURE = ds.Tables[0].Rows[0]["MAX_APERTURE"].ToString();
                model.CONVERT_FLAG = ConvertEx.ToBool(ds.Tables[0].Rows[0]["CONVERT_FLAG"]);
                model.CONVERT_DT = ConvertEx.ToString(ds.Tables[0].Rows[0]["CONVERT_DT"]);
                model.SIGNATURE_FLAG = ConvertEx.ToBool(ds.Tables[0].Rows[0]["SIGNATURE_FLAG"]);
                model.SIGNATURE_DT = ConvertEx.ToString(ds.Tables[0].Rows[0]["SIGNATURE_DT"]);
                model.FROM_SID = ds.Tables[0].Rows[0]["FROM_SID"].ToString();

                if (ds.Tables[0].Rows[0]["OldRecID"].ToString() != "") {
                    model.OldRecID = int.Parse(ds.Tables[0].Rows[0]["OldRecID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MyOrderIndex"].ToString() != "") {
                    model.MyOrderIndex = int.Parse(ds.Tables[0].Rows[0]["MyOrderIndex"].ToString());
                }
                model.FileFrom = ds.Tables[0].Rows[0]["FileFrom"].ToString();
                model.IsMerge = ds.Tables[0].Rows[0]["IsMerge"].ToString();
                if (ds.Tables[0].Rows[0]["Version"].ToString() != "") {
                    model.Version = int.Parse(ds.Tables[0].Rows[0]["Version"].ToString());
                }
                model.iSignaturePdf = ConvertEx.ToBool(ds.Tables[0].Rows[0]["iSignaturePdf"]);
                model.iSignatureWorkFlow = ConvertEx.ToBool(ds.Tables[0].Rows[0]["iSignatureWorkFlow"]);

                return model;
            } else {
                return null;
            }
        }



        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere, string orderBy = null) {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select BH+' '+Title TitleNew,FileListID,SingleProjectID,ArchiveID,MyArchiveID,recID,PID,DefaultCompanyType,DH,MyCode,BH,Title,MustSubmitFlag,OldStatus,Status,StartTime,EndTime,CompanyID,OperateUserID,OperateUserName,OrderIndex,ManualCount,PagesCount,WinRecvPagesCount,Remark,PDFFilePath,AlonePack,IsFolder,IsSystem,FileType,archive_form_no,zajh,w_t_h,wjtm,zrr,qssj,zzsj,yc,wb,sl,bgqx,mj,dz_k,dz_l,dz_g,dz_c,dz_x,ztlx,dw,gg,ty,ztc,note,sw,dz,lrr,lrsj,shzt,shr_1,shsj_1,shr_2,shsj_2,shr_3,shsj_3,aipdate,aipuser,ShortDH,swgph,cfdz,wjbt,zrz,wh,wjfwqx,xcsj,dzwjxx,fz,CreateDate,CreateDate2,tzz,dtz,zpz,wzz,dpz,wjgbdm,wjlxdm,wjgs,wjdx,psdd,psz,pssj,sb,fbl,xjpp,xjxh,bz ");
            //strSql.Append("select BH+' '+Title TitleNew,FileListID,SingleProjectID,MyArchiveID,ArchiveID,recID,PID,DefaultCompanyType,DH,MyCode,BH,Title,MustSubmitFlag,OldStatus,Status,StartTime,EndTime,CompanyID,OperateUserID,OperateUserName,OrderIndex,ManualCount,PagesCount,WinRecvPagesCount,Remark,PDFFilePath,AlonePack,IsFolder,IsSystem,FileType,archive_form_no,zajh,w_t_h,wjtm,zrr,qssj,zzsj,yc,wb,sl,bgqx,mj,dz_k,dz_l,dz_g,dz_c,dz_x,ztlx,dw,gg,ty,ztc,note,sw,dz,lrr,lrsj,shzt,shr_1,shsj_1,shr_2,shsj_2,shr_3,shsj_3,aipdate,aipuser,ShortDH,swgph,cfdz,wjbt,zrz,wh,wjfwqx,xcsj,dzwjxx,fz,CreateDate,CreateDate2,tzz,dtz,zpz,wzz,dpz,wjgbdm,wjlxdm,wjgs,wjdx,psdd,psz,pssj,sb,fbl,xjpp,xjxh,bz,RootPath, ");

            //strSql.Append("XAXIS_RESOLUTION,YAXIS_RESOLUTION,IMAGE_WIDTH,IMAGE_HEIGHT,DATA_FICAL_LENGTH,DATA_APERTURE,");
            //strSql.Append("DATA_APERTURE_XS,FLASH,WHITE_BALANCE,ISO_SPEED_RATINGS,EXPOSURE_PROGRAM,EXPOSURE_MODE,");
            //strSql.Append("DATA_EXPOSURE_TIME,QUALITY,CONTRAST,SATURATION,MAX_APERTURE,FROM_SID ");
            strSql.Append("select BH+' '+Title TitleNew,* ");
            strSql.Append(" FROM T_FileList ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            if (orderBy == null)
                strSql.Append(" ORDER BY OrderIndex");
            else
                strSql.Append(" ORDER BY " + orderBy);

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere, string orderby, bool orderflag) {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select BH+' '+Title TitleNew,FileListID,SingleProjectID,ArchiveID,MyArchiveID,recID,PID,DefaultCompanyType,DH,MyCode,BH,Title,MustSubmitFlag,OldStatus,Status,StartTime,EndTime,CompanyID,OperateUserID,OperateUserName,OrderIndex,ManualCount,PagesCount,WinRecvPagesCount,Remark,PDFFilePath,AlonePack,IsFolder,IsSystem,FileType,archive_form_no,zajh,w_t_h,wjtm,zrr,qssj,zzsj,yc,wb,sl,bgqx,mj,dz_k,dz_l,dz_g,dz_c,dz_x,ztlx,dw,gg,ty,ztc,note,sw,dz,lrr,lrsj,shzt,shr_1,shsj_1,shr_2,shsj_2,shr_3,shsj_3,aipdate,aipuser,ShortDH,swgph,cfdz,wjbt,zrz,wh,wjfwqx,xcsj,dzwjxx,fz,CreateDate,CreateDate2,tzz,dtz,zpz,wzz,dpz,wjgbdm,wjlxdm,wjgs,wjdx,psdd,psz,pssj,sb,fbl,xjpp,xjxh,bz ");
            //strSql.Append("select BH+' '+Title TitleNew,FileListID,SingleProjectID,MyArchiveID,ArchiveID,recID,PID,DefaultCompanyType,DH,MyCode,BH,Title,MustSubmitFlag,OldStatus,Status,StartTime,EndTime,CompanyID,OperateUserID,OperateUserName,OrderIndex,ManualCount,PagesCount,WinRecvPagesCount,Remark,PDFFilePath,AlonePack,IsFolder,IsSystem,FileType,archive_form_no,zajh,w_t_h,wjtm,zrr,qssj,zzsj,yc,wb,sl,bgqx,mj,dz_k,dz_l,dz_g,dz_c,dz_x,ztlx,dw,gg,ty,ztc,note,sw,dz,lrr,lrsj,shzt,shr_1,shsj_1,shr_2,shsj_2,shr_3,shsj_3,aipdate,aipuser,ShortDH,swgph,cfdz,wjbt,zrz,wh,wjfwqx,xcsj,dzwjxx,fz,CreateDate,CreateDate2,tzz,dtz,zpz,wzz,dpz,wjgbdm,wjlxdm,wjgs,wjdx,psdd,psz,pssj,sb,fbl,xjpp,xjxh,bz,RootPath, ");

            //strSql.Append("XAXIS_RESOLUTION,YAXIS_RESOLUTION,IMAGE_WIDTH,IMAGE_HEIGHT,DATA_FICAL_LENGTH,DATA_APERTURE,");
            //strSql.Append("DATA_APERTURE_XS,FLASH,WHITE_BALANCE,ISO_SPEED_RATINGS,EXPOSURE_PROGRAM,EXPOSURE_MODE,");
            //strSql.Append("DATA_EXPOSURE_TIME,QUALITY,CONTRAST,SATURATION,MAX_APERTURE,FROM_SID ");
            strSql.Append("select BH+' '+Title TitleNew,* ");
            strSql.Append(" FROM T_FileList ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            if (orderby.Trim() != "") {
                strSql.Append(" ORDER BY " + orderby);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表 分页
        /// </summary>
        /// <returns></returns>
        public DataTable GetList(string strWhere, int PageSize, int curPage, string PRIMARYKey, string OrderByName, out int recCoun) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BH+' '+Title TitleNew,T_FileList.* ");
            //strSql.Append("(select ProjectType from T_SingleProject f where f.SingleProjectID=T_FileList.SingleProjectID)as ProjectType");
            strSql.Append(" FROM T_FileList ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
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
            //strSql.Append(" FileListID,SingleProjectID,ArchiveID,MyArchiveID,recID,PID,DefaultCompanyType,DH,MyCode,BH,Title,MustSubmitFlag,OldStatus,Status,StartTime,EndTime,CompanyID,OperateUserID,OperateUserName,OrderIndex,ManualCount,PagesCount,WinRecvPagesCount,Remark,PDFFilePath,AlonePack,IsFolder,IsSystem,FileType,archive_form_no,zajh,w_t_h,wjtm,zrr,qssj,zzsj,yc,wb,sl,bgqx,mj,dz_k,dz_l,dz_g,dz_c,dz_x,ztlx,dw,gg,ty,ztc,note,sw,dz,lrr,lrsj,shzt,shr_1,shsj_1,shr_2,shsj_2,shr_3,shsj_3,aipdate,aipuser,ShortDH,swgph,cfdz,wjbt,zrz,wh,wjfwqx,xcsj,dzwjxx,fz,CreateDate,CreateDate2,tzz,dtz,zpz,wzz,dpz,wjgbdm,wjlxdm,wjgs,wjdx,psdd,psz,pssj,sb,fbl,xjpp,xjxh,bz,RootPath ");
            strSql.Append(" * ");
            strSql.Append(" FROM T_FileList ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法

        ///<summary>
        ///获取用户自定义归档目录流水号
        ///</summary>
        public int GetMaxRecID(string projectid) {
            int RecID = 0;
            string strSql = "";
            if (!string.IsNullOrEmpty(projectid)) {
                strSql = "select max(recID) from T_FileList where SingleProjectID='" + projectid + "'";
                RecID = ConvertEx.ToInt(DbHelperSQL.GetSingle(strSql)) + 1;
            }
            return RecID;
        }

        public bool IsCanDel(int FileListID) {
            string strSql1 = "select count(0) from T_FileList where FileListID=" + FileListID + " and  IsSystem=0";
            int iCount = ConvertEx.ToInt(DbHelperSQL.GetSingle(strSql1));//属于用户自定义归档目录
            if (iCount > 0) {
                return true;//可以删除
            }
            return false;
        }

        public DataSet GetList(string strWhere, string CompanyType, string orderBy = null) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT DISTINCT A.*,UserName FROM T_FileList A,T_FileListTmp_CellRptTmp B,T_UsersInfo C WHERE A.recID=B.recID AND B.Enabled=1 AND CompanyType=" + CompanyType + " AND PID>=0 AND A.OperateUserID=C.UserID");
            if (strWhere.Trim() != "") {
                strSql.Append(" AND " + strWhere);
            }
            strSql.Append(" Order by A.recID,PID");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表 分页
        /// </summary>
        /// <returns></returns>
        public DataTable GetLHSignatureFilesList(string Signature_UserID, string strWhere, int PageSize, int curPage, string PRIMARYKey, string OrderByName, out int recCoun) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BH+' '+Title TitleNew,*, ");
            strSql.Append("(SELECT COUNT(1) from T_FileList_SignatureLog b where b.FileListID=T_FileList.FileListID)as SignatureCount,");
            strSql.Append("(SELECT MAX(b.Signature_DT) from T_FileList_SignatureLog b where b.FileListID=T_FileList.FileListID AND b.Signature_UserID=" + Signature_UserID + ")as MAX_Signature_DT, ");
            strSql.Append("(SELECT MAX(b.SignatureFinish_DT) from T_FileList_SignatureLog b where b.SignatureFinishFlag='1' AND b.FileListID=T_FileList.FileListID AND b.Signature_UserID=" + Signature_UserID + ")as MAX_SignatureFinish_DT ");

            strSql.Append(" FROM T_FileList ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            return PageCtrl.QueryForDataTableSqlServer(strSql.ToString(), PageSize, curPage, PRIMARYKey, OrderByName, out recCoun).Tables[0];
        }

        public DigiPower.Onlinecol.Standard.Model.T_FileList_MDL GetModel(string sqlWhere) {
            DigiPower.Onlinecol.Standard.Model.T_FileList_MDL mdl = new DigiPower.Onlinecol.Standard.Model.T_FileList_MDL();
            string strSql = "SELECT FileListID from T_FileList where " + sqlWhere;

            int FileListID = ConvertEx.ToInt(DbHelperSQL.GetSingle(strSql));
            if (FileListID > 0) {
                mdl = GetModel(FileListID);
            }
            return mdl;
        }

        /// <summary>
        /// 获取工程归档目录下，不同类型对应的个数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetFileListTypeCount(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*)as AllCount,PID from T_FileList ");

            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" group by PID order by PID desc");
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 更新工程的归档目录下不同单位对应的处理人
        /// </summary>
        /// <param name="SingleProjectID">工程ID</param>
        /// <param name="UserID">用户ID</param>
        /// <param name="UserName">用户名称</param>
        /// <param name="DefaultCompanyType">单位类型ID</param>
        public void UpdateOperateUser(int SingleProjectID, int CompanyID, int UserID, string UserName, int DefaultCompanyType) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_FileList set CompanyID=@CompanyID,OperateUserID=@OperateUserID,OperateUserName=@OperateUserName ");
            strSql.Append("where SingleProjectID=@SingleProjectID and DefaultCompanyType=@DefaultCompanyType ");

            SqlParameter[] parameters = { 
                    new SqlParameter("@CompanyID",SqlDbType.Int,4),
                    new SqlParameter("@OperateUserID",SqlDbType.Int,4),
                    new SqlParameter("@OperateUserName",SqlDbType.VarChar,20),
                    new SqlParameter("@SingleProjectID",SqlDbType.Int,4),
                    new SqlParameter("@DefaultCompanyType",SqlDbType.Int,4)};

            parameters[0].Value = CompanyID;
            parameters[1].Value = UserID;
            parameters[2].Value = UserName;
            parameters[3].Value = SingleProjectID;
            parameters[4].Value = DefaultCompanyType;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 更新序号
        /// </summary>
        /// <param name="singleproject">工程ID</param>
        /// <param name="oxh">原序号</param>
        /// <param name="txh">目标序号</param>
        public void UpdateXH(int ArchiveID, int OrderIndex, bool UPFlag) {
            //UPFlag==true 上移，false 下移
            string strSql = "";
            if (UPFlag == true) {
                strSql = "SELECT TOP 2 * FROM T_FileList WHERE ArchiveID=" + ArchiveID + " AND OrderIndex<=" + OrderIndex + " ORDER BY OrderIndex DESC";

            } else {
                strSql = "SELECT TOP 2 * FROM T_FileList WHERE ArchiveID=" + ArchiveID + " AND OrderIndex>=" + OrderIndex + " ORDER BY OrderIndex";
            }
            DataSet ds1 = DbHelperSQL.Query(strSql);
            if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count == 2) {
                string FileListID1 = ds1.Tables[0].Rows[0]["FileListID"].ToString();
                string FileListID2 = ds1.Tables[0].Rows[1]["FileListID"].ToString();

                string OrderIndex1 = ds1.Tables[0].Rows[0]["OrderIndex"].ToString();
                string OrderIndex2 = ds1.Tables[0].Rows[1]["OrderIndex"].ToString();
                if (OrderIndex1 == OrderIndex2) {
                    OrderIndex2 = (ConvertEx.ToInt(OrderIndex1) + 1).ToString();
                }
                DbHelperSQL.Query("UPDATE T_FileList SET OrderIndex=" + OrderIndex1 + " WHERE FileListID=" + FileListID2);
                DbHelperSQL.Query("UPDATE T_FileList SET OrderIndex=" + OrderIndex2 + " WHERE FileListID=" + FileListID1);
            }
        }



        /// <summary>
        /// 更新序号
        /// </summary>
        /// <param name="singleproject">工程ID</param>
        /// <param name="oxh">原序号</param>
        /// <param name="txh">目标序号</param>
        public void MyUpdateXH(int ArchiveID, int OrderIndex, bool UPFlag) {
            //UPFlag==true 上移，false 下移
            string strSql = "";
            if (UPFlag == true) {
                strSql = "SELECT TOP 2 * FROM T_FileList WHERE MyArchiveID=" + ArchiveID + " AND OrderIndex<=" + OrderIndex + " ORDER BY OrderIndex DESC";

            } else {
                strSql = "SELECT TOP 2 * FROM T_FileList WHERE MyArchiveID=" + ArchiveID + " AND OrderIndex>=" + OrderIndex + " ORDER BY OrderIndex";
            }
            DataSet ds1 = DbHelperSQL.Query(strSql);
            if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count == 2) {
                string FileListID1 = ds1.Tables[0].Rows[0]["FileListID"].ToString();
                string FileListID2 = ds1.Tables[0].Rows[1]["FileListID"].ToString();

                string OrderIndex1 = ds1.Tables[0].Rows[0]["OrderIndex"].ToString();
                string OrderIndex2 = ds1.Tables[0].Rows[1]["OrderIndex"].ToString();
                if (OrderIndex1 == OrderIndex2) {
                    OrderIndex2 = (ConvertEx.ToInt(OrderIndex1) + 1).ToString();
                }
                DbHelperSQL.Query("UPDATE T_FileList SET OrderIndex=" + OrderIndex1 + " WHERE FileListID=" + FileListID2);
                DbHelperSQL.Query("UPDATE T_FileList SET OrderIndex=" + OrderIndex2 + " WHERE FileListID=" + FileListID1);
            }
        }

        public string GetPageCountByArchiveID(string ArchiveID) {
            string strOut = "0";
            string strSql = "";
            strSql = "select sum(ManualCount) from T_FileList where archiveid=" + ArchiveID;
            DataSet ds1 = DbHelperSQL.Query(strSql);
            if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0) {
                strOut = ds1.Tables[0].Rows[0][0].ToString();
            }
            return strOut;
        }

        public string GetPageCountByMyArchiveID(string MyArchiveID) {
            string strOut = "0";
            string strSql = "";
            strSql = "select sum(ManualCount) from T_FileList where MyArchiveID=" + MyArchiveID;
            DataSet ds1 = DbHelperSQL.Query(strSql);
            if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0) {
                strOut = ds1.Tables[0].Rows[0][0].ToString();
            }
            return strOut;
        }

        /// <summary>
        /// 文件登记中新增条目
        /// mustsubmitflag 是由档案馆勾选确认的 ,默认为false
        /// </summary>
        /// <param name="SingleProjectID"></param>
        /// <param name="CompanyID"></param>
        /// <param name="UserID"></param>
        /// <param name="UserName"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(string SingleProjectID, string CompanyID, string UserID, string UserName, DigiPower.Onlinecol.Standard.Model.T_FileListTmp_MDL model) {//有可能在这里造成大批数据插入
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" insert into T_FileList(recID,bh,title,mustsubmitflag,pid,DefaultCompanyType,status,starttime,endtime,CompanyID,operateuserid,operateusername,OrderIndex,pagescount,winrecvpagescount,SingleProjectID,IsFolder,AlonePack,IsSystem,FileType)");
            strSql.Append(" select recID,'" + model.bh + "',title,mustsubmitflag,pid,DefaultCompanyType,0 status,null starttime,null endtime," + CompanyID + "," + UserID + " operateuserid,'" + UserName + "' operateusername,OrderIndex,0 pagescount,0 winrecvpagescount," + SingleProjectID + " SingleProjectID,IsFolder,AlonePack,1,FileType");
            strSql.Append(" from T_FileListTmp where recid=" + model.recid);

            DbHelperSQL.ExecuteSql(strSql.ToString());
            string strSql2 = " select MAX(FileListID) from T_FileList where recID=" + model.recid + " and SingleProjectID=" + SingleProjectID;

            object FileListID = DbHelperSQL.GetSingle(strSql2);
            if (FileListID != null) {
                string FileListID2 = FileListID.ToString();
                //带入模板
                string tstrSql = "INSERT INTO T_EFile(FileListID,FileType,Title,FilePath,OrderIndex) select " + FileListID2 + ",1,b.Title,b.CellFilePath,b.OrderIndex from T_FileListtmp a,T_FileListTmp_CellRptTmp b where a.recID=b.RecID and b.recID=" + model.recid;
                DbHelperSQL.ExecuteSql(tstrSql);
            }

            return 0;
        }

        /// <summary>
        /// 新增归档目录,都是必须提交的 ,mustsubmitflag=1 
        /// 案卷补录管理中,新增条目用到
        /// </summary>
        /// <param name="SingleProjectID"></param>
        /// <param name="CompanyID"></param>
        /// <param name="UserID"></param>
        /// <param name="UserName"></param>
        /// <param name="model"></param>
        /// <param name="SuppleMentFlag"></param>
        /// <returns></returns>
        public int Add(string SingleProjectID, string CompanyID, string UserID, string UserName, DigiPower.Onlinecol.Standard.Model.T_FileListTmp_MDL model, bool SuppleMentFlag) {//有可能在这里造成大批数据插入
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" insert into T_FileList(recID,bh,title,mustsubmitflag,pid,DefaultCompanyType,status,starttime,endtime,CompanyID,operateuserid,operateusername,OrderIndex,pagescount,winrecvpagescount,SingleProjectID,IsFolder,AlonePack,IsSystem,FileType,ManualCount)");
            strSql.Append(" select recID,'" + model.bh + "',title,1,pid,DefaultCompanyType,0 status,null starttime,null endtime," + CompanyID + "," + UserID + " operateuserid,'" + UserName + "' operateusername,OrderIndex,0 pagescount,0 winrecvpagescount," + SingleProjectID + " SingleProjectID,IsFolder,AlonePack,1,FileType,0");
            strSql.Append(" from T_FileListTmp where recid=" + model.recid);

            DbHelperSQL.ExecuteSql(strSql.ToString());
            string strSql2 = " select MAX(FileListID) from T_FileList where recID=" + model.recid + " and SingleProjectID=" + SingleProjectID;

            object FileListID = DbHelperSQL.GetSingle(strSql2);
            if (FileListID != null) {
                string FileListID2 = FileListID.ToString();
                //带入模板
                string tstrSql = "INSERT INTO T_EFile(FileListID,FileType,Title,FilePath,OrderIndex) select " + FileListID2 + ",1,b.Title,b.CellFilePath,b.OrderIndex from T_FileListtmp a,T_FileListTmp_CellRptTmp b where a.recID=b.RecID and b.recID=" + model.recid;
                DbHelperSQL.ExecuteSql(tstrSql);
            }

            return 0;
        }

        public bool Exists(string SingleProjectID, int recID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_FileList");
            strSql.Append(" where SingleProjectID=@SingleProjectID AND recID=@recID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SingleProjectID", SqlDbType.Int,8),
                    new SqlParameter("@recID", SqlDbType.Int,8)};
            parameters[0].Value = SingleProjectID;
            parameters[1].Value = recID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public int GetCountByFileType(int SingleProject, int fileType) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(0) FROM dbo.T_FileList A WHERE SINGLEPROJECTID=" + SingleProject + " AND A.STATUS<>0 AND A.FILETYPE=" + fileType + "");
            return ConvertEx.ToInt(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        public int GetCountBySubmitFlag(int SingleProject) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(0) FROM dbo.T_FileList A WHERE SINGLEPROJECTID=" + SingleProject + " AND A.STATUS<>0 AND A.MustSubmitFlag=1");
            return ConvertEx.ToInt(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        public int GetCount(int SingleProject) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(0) FROM T_FileList A WHERE SINGLEPROJECTID=" + SingleProject + "");
            return ConvertEx.ToInt(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        public int GetCount(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(0) FROM T_FileList ");
            if (!string.IsNullOrWhiteSpace(strWhere)) {
                strSql.Append(" where " + strWhere);
            }
            return ConvertEx.ToInt(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        public int GetFileCountByOperateUserID(int OperateUserID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(0) FROM dbo.T_FileList A WHERE OperateUserID=" + OperateUserID + "");
            return ConvertEx.ToInt(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        public int GetManualCountByArchiveID(int ArchiveID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT SUM(ManualCount) FROM dbo.T_FileList A WHERE ArchiveID=" + ArchiveID + "");
            return ConvertEx.ToInt(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        public void Reset(string ProjID) {
            string strSql = "";
            strSql = "UPDATE T_FileList SET PID= B.PID FROM T_FileListTmp B WHERE T_FileList.recID=B.recid AND T_FileList.PID<>B.PID AND T_FileList.SingleProjectID=" + ProjID;
            DbHelperSQL.ExecuteSql(strSql.ToString());

            strSql = "UPDATE T_FileList SET CONVERT_FLAG=0 WHERE FileListID IN ( SELECT FileListID FROM T_FileList WHERE PDFFilePath<>'' AND PagesCount=0 AND SingleProjectID=" + ProjID + ")";
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        public int GetFileCountByPID(int PID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(0) FROM dbo.T_FileList A WHERE PID=" + PID + " ");
            return ConvertEx.ToInt(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public string GetMaxBH(string strWhere) {
            string strSql = "select MAX(bh) from T_FileList where 1=1 And " + strWhere;
            return DbHelperSQL.GetSingle(strSql).ToString();
        }

        public int GetFileCountByCompany(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(0) FROM T_FileList where 1=1 And " + strWhere);
            return ConvertEx.ToInt(DbHelperSQL.GetSingle(strSql.ToString()));
        }


        public DataTable GetTopList(string FileListID, string strWhere, bool UpOrDown) {
            DigiPower.Onlinecol.Standard.Model.T_FileList_MDL mdl = new DigiPower.Onlinecol.Standard.Model.T_FileList_MDL();
            string strSql = "select TOP 1 * from (select ROW_NUMBER() OVER(ORDER BY bh)as rowindex,"
              + "* from T_FileList where isfolder=0 and " + strWhere + ")f0 ";

            if (UpOrDown)
                strSql += "WHERE f0.rowindex<"
                   + "(select top 1 f.rowindex FROM (select ROW_NUMBER() OVER(ORDER BY bh)as rowindex,bh,FileListID from T_FileList "
                   + "where isfolder=0 and " + strWhere + ") f WHERE f.FileListID=" + FileListID + ")order by f0.rowindex desc";
            else
                strSql += "WHERE f0.rowindex>"
                   + "(select top 1 f.rowindex FROM (select ROW_NUMBER() OVER(ORDER BY bh)as rowindex,bh,FileListID from T_FileList "
                   + "where isfolder=0 and " + strWhere + ") f WHERE f.FileListID=" + FileListID + ")order by f0.rowindex asc";

            return DbHelperSQL.Query(strSql).Tables[0];
        }
        public int GetFileOrderIndexByPID(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ISNULL(MAX(OrderIndex),0) FROM T_FileList where 1=1 And " + strWhere);
            return ConvertEx.ToInt(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 根据公司删除文件级信息
        /// </summary>
        /// <returns></returns>
        public int DeleteFileListByCompanyID(int tCompanyID, int DefaultCompanyType) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_FileList where IsFolder=0 and CompanyID=" + tCompanyID + " and DefaultCompanyType=" + DefaultCompanyType);
            return ConvertEx.ToInt(DbHelperSQL.ExecuteSql(strSql.ToString()));
        }

        /// <summary>
        /// 获取文件相关数量
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int GetFileCount(Hashtable ht) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(0) FROM T_FileList where 1=1 ");
            if (ht.ContainsKey("ArchiveID") && ConvertEx.ToString(ht["ArchiveID"]).Length > 0) {
                strSql.Append(" and ArchiveID=" + ConvertEx.ToString(ht["ArchiveID"]) + "");
            }
            if (ht.ContainsKey("SingleProjectID") && ConvertEx.ToString(ht["SingleProjectID"]).Length > 0) {
                strSql.Append(" and SingleProjectID=" + ConvertEx.ToString(ht["SingleProjectID"]) + "");
            }
            if (ht.ContainsKey("OperateUserID") && ConvertEx.ToString(ht["OperateUserID"]).Length > 0) {
                strSql.Append(" and OperateUserID=" + ConvertEx.ToString(ht["OperateUserID"]) + "");
            }
            if (ht.ContainsKey("CompanyID") && ConvertEx.ToString(ht["CompanyID"]).Length > 0) {
                strSql.Append(" and CompanyID=" + ConvertEx.ToString(ht["CompanyID"]) + "");
            }
            if (ht.ContainsKey("Unequal_Status") && ConvertEx.ToString(ht["Unequal_Status"]).Length > 0) {
                strSql.Append(" and ISNULL(Status,'0') !='" + ConvertEx.ToString(ht["Unequal_Status"]) + "'");
            }
            if (ht.ContainsKey("iSignaturePdf") && ConvertEx.ToString(ht["iSignaturePdf"]).Length > 0 &&
                ht.ContainsKey("Signature_UserRoleCode") && ConvertEx.ToString(ht["Signature_UserRoleCode"]).Length > 0) {
                strSql.Append(" and iSignaturePdf=1 and IsFolder=0 and BH not like '%S%' and CONVERT_FLAG=1 ");
                strSql.Append(" and (SELECT COUNT(1) from T_FileList_SignatureTmp f1 where f1.FileListID=T_FileList.OldRecID AND lower(f1.SignatureType)='" + ConvertEx.ToString(ht["Signature_UserRoleCode"]).ToLower() + "')>0 ");

                if (ht.ContainsKey("SignatureFinishFlag") && ConvertEx.ToString(ht["SignatureFinishFlag"]) == "0") { //签章未完成
                    strSql.Append(" and (SELECT COUNT(1) from T_FileList_SignatureLog f0 where f0.FileListID=T_FileList.FileListID and f0.SignatureFinishFlag=1 AND lower(f0.Signature_UserRoleCode)='" + ConvertEx.ToString(ht["Signature_UserRoleCode"]).ToLower() + "')<1");
                } if (ht.ContainsKey("SignatureFinishFlag") && ConvertEx.ToString(ht["SignatureFinishFlag"]) == "1") {//签章已完成
                    strSql.Append(" and (SELECT COUNT(1) from T_FileList_SignatureLog f0 where f0.FileListID=T_FileList.FileListID and f0.SignatureFinishFlag=1 AND lower(f0.Signature_UserRoleCode)='" + ConvertEx.ToString(ht["Signature_UserRoleCode"]).ToLower() + "')>0");
                }
            }

            return ConvertEx.ToInt(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 根据公司删除文件级信息
        /// </summary>
        /// <returns></returns>
        public int DeleteFileList(Hashtable ht) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_FileList where 1=1 ");
            if (ht.ContainsKey("ArchiveID") && ConvertEx.ToString(ht["ArchiveID"]).Length > 0) {
                strSql.Append(" and ArchiveID=" + ConvertEx.ToString(ht["ArchiveID"]) + "");
            }
            if (ht.ContainsKey("SingleProjectID") && ConvertEx.ToString(ht["SingleProjectID"]).Length > 0) {
                strSql.Append(" and SingleProjectID=" + ConvertEx.ToString(ht["SingleProjectID"]) + "");
            }
            if (ht.ContainsKey("OperateUserID") && ConvertEx.ToString(ht["OperateUserID"]).Length > 0) {
                strSql.Append(" and OperateUserID=" + ConvertEx.ToString(ht["OperateUserID"]) + "");
            }
            if (ht.ContainsKey("CompanyID") && ConvertEx.ToString(ht["CompanyID"]).Length > 0) {
                strSql.Append(" and CompanyID=" + ConvertEx.ToString(ht["CompanyID"]) + "");
            }
            return ConvertEx.ToInt(DbHelperSQL.ExecuteSql(strSql.ToString()));
        }

        public DataTable GetDistinctMyCode(string SingleProjectID, string CompanyID = null) {
            T_FileList_MDL mdl = new T_FileList_MDL();
            string strSql = "select distinct t.mycode from t_filelist t where t.singleprojectid=" + SingleProjectID;
            if (CompanyID != null) {
                strSql += " and t.companyid=" + CompanyID;
            }
            strSql += " and t.mycode is not null ";

            return DbHelperSQL.Query(strSql).Tables[0];
        }

        /// <summary>
        /// 返回工程下的案卷的文件 条件: ManualCount小于1
        /// </summary>
        /// <param name="SingleProjectID"></param>
        /// <returns></returns>
        public DataTable GetFileListThanManualCount(string SingleProjectID) {
            string strSql = "SELECT f.BH,f.Title,f.OrderIndex,f.ManualCount,f2.xh,f2.ajtm,f2.ArchiveID,f3.gcbm,f3.gcmc,f3.SingleProjectID ";
            strSql += "FROM T_FileList f,T_Archive f2,T_SingleProject f3 where f.ArchiveID=f2.ArchiveID ";
            strSql += "and f.SingleProjectID=f3.SingleProjectID and  f.SingleProjectID=" + SingleProjectID + "	 ";
            strSql += "and ISNULL(f.ManualCount,0) <1 and ISNULL(f.ArchiveID,0)>0 ";

            return DbHelperSQL.Query(strSql).Tables[0];
        }

        /// <summary>
        /// 返回文件各个类型做完的文件数量 根据PID=0统计
        /// </summary>
        /// <param name="SingleProjectID"></param>
        /// <returns></returns>
        public DataTable GetFinishFileCountByFileType(string SingleProjectID) {
            if (!string.IsNullOrWhiteSpace(SingleProjectID)) {
                string strSql = "SELECT a.BH,a.Title,ISNULL(b.doCount,0)doCount,ISNULL(c.allCount,0)allCount FROM ";
                strSql += "(select distinct bh,Title from T_FileList where SingleProjectID=" + SingleProjectID + " AND IsFolder=1 AND PID=0)a ";
                strSql += "LEFT JOIN ";
                strSql += "(select SUBSTRING(f.BH,1,1)BH,COUNT(1)doCount from T_FileList f where f.SingleProjectID=" + SingleProjectID + "  ";
                strSql += "AND f.IsFolder=0 AND ISNULL(f.Status,0)>0 group by SUBSTRING(f.BH,1,1))b ON a.BH=b.BH ";
                strSql += "LEFT JOIN ";
                strSql += "(select SUBSTRING(f.BH,1,1)BH,COUNT(1)allCount from T_FileList f where f.SingleProjectID=" + SingleProjectID + "  ";
                strSql += "AND f.IsFolder=0 group by SUBSTRING(f.BH,1,1))c ON a.BH=c.BH ";
                strSql += "ORDER BY a.BH ";
                return DbHelperSQL.Query(strSql).Tables[0];
            } return null;
        }

        /// <summary>
        /// 根据外部系统传入的对接的文件key,查找自己系统文件所属父ID
        /// </summary>
        /// <param name="FromRecID">外部系统传入的文件key</param>
        /// <param name="FromType">外部系统类型:比如筑业等</param>
        /// <returns></returns>
        public object GetPID(string FromRecID, string FromType) {
            string strSql = " SELECT PID FROM T_FileListTmp where recid in(SELECT NativeRecID FROM T_FileListTmp_OutSideRelated ";
            strSql += "where UPPER(FromRecID)='" + FromRecID.ToUpper() + "' AND  UPPER(FromType)='" + FromType.ToUpper() + "')";

            return DbHelperSQL.GetSingle(strSql);
        }

        /// <summary>
        /// 根据外部系统传入的对接的文件key,查找自己系统文件所属ID
        /// </summary>
        /// <param name="FromRecID">外部系统传入的文件key</param>
        /// <param name="FromType">外部系统类型:比如筑业等</param>
        /// <returns></returns>
        public object GetRecID(string FromRecID, string FromType) {
            string strSql = " SELECT NativeRecID FROM T_FileListTmp_OutSideRelated ";
            strSql += "where UPPER(FromRecID)='" + FromRecID.ToUpper() + "' AND  UPPER(FromType)='" + FromType.ToUpper() + "'";

            return DbHelperSQL.GetSingle(strSql);
        }

        /// <summary>
        /// 获取责任书对应的归档目录ID
        /// </summary>
        /// <param name="SingleProjectID"></param>
        /// <param name="ZrsToFileListTmpRecIDS"></param>
        /// <returns></returns>
        public DataTable GetZrsMoveFileRecID(string SingleProjectID, string ZrsToFileListTmpRecIDS) {
            DataTable dt = null;
            if (!string.IsNullOrWhiteSpace(SingleProjectID) && !string.IsNullOrWhiteSpace(ZrsToFileListTmpRecIDS)) {
                string strSql = "select t.* from T_FileList t ";
                strSql += "where t.SingleProjectID=" + SingleProjectID + " and t.IsFolder=0 and ";
                strSql += "charindex('|'+CONVERT(varchar(20),t.OldRecID)+'|','" + ZrsToFileListTmpRecIDS + "')>0  ";

                dt = DbHelperSQL.Query(strSql).Tables[0];
            }
            return dt;
        }

        /// <summary>
        /// 获取工程下签章未完成的文件
        /// </summary>
        /// <param name="SingleProjectID">工程ID</param>
        /// <param name="SignatureFinishStatus">签章完成状态 1:完成 0:未完成</param>
        /// <returns></returns>
        public DataTable GetFileListBySignatureFinishStatus(string SingleProjectID, int SignatureFinishStatus) {
            string strSql = "SELECT f.*,f1.gcmc,f1.gcbm,";
            strSql += "(SELECT COUNT(1) from T_FileList_SignatureLog f0 where f0.FileListID=f.FileListID and f0.SignatureFinishFlag=1)as FinishSignaturecount,";
            strSql += "(SELECT COUNT(1) from T_FileList_SignatureTmp f1 where f1.FileListID=f.OldRecID)as SignatureTmpCount ";
            strSql += "from T_FileList f,T_SingleProject f1 where f.SingleProjectID=f1.SingleProjectID ";
            strSql += "and f.SingleProjectID=" + SingleProjectID + " and f.iSignaturePdf=1 and f.IsFolder=0 and ";
            strSql += "(SELECT COUNT(1) from T_FileList_SignatureTmp f1 where f1.FileListID=f.OldRecID)>0 ";
            if (SignatureFinishStatus == 1) {
                strSql += "and (SELECT COUNT(1) from T_FileList_SignatureLog f0 where f0.FileListID=f.FileListID and f0.SignatureFinishFlag=1)";
                strSql += ">=(SELECT COUNT(1) from T_FileList_SignatureTmp f1 where f1.FileListID=f.OldRecID) ";
            } else if (SignatureFinishStatus == 0) {
                strSql += "and (SELECT COUNT(1) from T_FileList_SignatureLog f0 where f0.FileListID=f.FileListID and f0.SignatureFinishFlag=1)";
                strSql += "<(SELECT COUNT(1) from T_FileList_SignatureTmp f1 where f1.FileListID=f.OldRecID) ";
            }
            return DbHelperSQL.Query(strSql).Tables[0];
        }
    }
}