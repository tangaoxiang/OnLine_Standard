using System;
namespace DigiPower.Onlinecol.Standard.Model
{
    /// <summary>
    /// 实体类T_Archive_MDL 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class T_Archive_MDL
    {
        public T_Archive_MDL()
        { }
        #region Model
        private int _archiveid;
        private int? _singleprojectid;
        private string _area_code;
        private string _dh;
        private string _dhnew;
        private int _xh;
        private string _archive_form_no;
        private string _dz_k;
        private string _dz_l;
        private string _dz_g;
        private string _dz_c;
        private string _dz_x;
        private string _ajtm;
        private string _bzdw;
        private string _ztlx;
        private int _sl;
        private string _dw;
        private string _gg;
        private DateTime? _qssj;
        private DateTime? _zzsj;
        private string _bgqx;
        private string _mj;
        private string _ztc;
        private string _note;
        private string _lrr;
        private DateTime? _lrsj;
        private int? _wz;
        private int? _tzz;
        private int? _dt;
        private int? _zp;
        private int? _dp;
        private int? _ly;
        private int? _lx;
        private int? _gp;
        private int? _cd;
        private int? _cp;
        private int? _sw0;
        private int? _sw1;
        private int? _qt;
        private int? _jk;
        private string _jdh;
        private string _zlr;
        private DateTime? _zlrq;
        private string _shyj;
        private string _shr;
        private DateTime? _shsj;
        private string _yjqk;
        private string _yjr;
        private DateTime? _yjsj;
        private string _rksh_jsqk;
        private DateTime? _rksh_jssj;
        private DateTime? _jgrq;
        private string _jsr;
        private string _ajlx;
        private string _zajh;
        private string _jsdw;
        private string _sgdw;
        private string _sjdw;
        private string _gcmc;
        private string _gcdd;
        private string _kcdw;
        private string _jldw;
        private int? _zjs;
        private int? _zajs;
        private int? _djj;
        private string _dkbh;
        private string _xmbh;
        private string _tfh;
        private string _sjdwfzr;
        private string _pzwh;
        private string _jzmd;
        private string _rjl;
        private decimal? _jzmj;
        private decimal? _ydmj;
        private decimal? _lhl;
        private string _ghxz;
        private string _wz_dz;
        private string _wz_xz;
        private string _wz_nz;
        private string _wz_bz;
        private int? _pz_zn;
        private int? _pz_zy;
        private string _hh;
        private string _ydghxkzh;
        private string _ydghxkzh_fzjg;
        private DateTime? _ydghxkzh_fzrq;
        private string _ghxkzh;
        private string _ghxkzh_fzjg;
        private DateTime? _ghxkzh_fzrq;
        private string _tdyt;
        private string _ydxz;
        private string _kcqy;
        private string _blz;
        private string _tfck;
        private string _cffs;
        private string _zbxt;
        private string _gcxt;
        private decimal? _tzje;
        private string _yddw;
        private string _yjdw;
        private string _fdcqzh;
        private string _fdcqzh_fzjg;
        private DateTime? _fdcqzh_pzrq;
        private string _sgxkzh;
        private string _sgxkzh_fzjg;
        private DateTime? _sgxkzh_pzrq;
        private string _ydm;
        private string _ydxzh;
        private string _sw;
        private string _shortdh;
        private string _xzyjsh;
        private DateTime? _xzyjsh_pzrq;
        private string _jzjg;
        private string _qy;
        private int? _jzcs;
        private decimal? _jzgd;
        private decimal? _tccmj;
        private decimal? _ztz;
        private string _zdjh;
        private string _cfdz;
        private string _swh;
        private string _jnwjqssj;
        private string _jnwjzzsj;
        private string _ydh;
        private string _fz;
        private bool _rkflag;
        private string _boxType;
        /// <summary>
        /// 
        /// </summary>
        public int ArchiveID
        {
            set { _archiveid = value; }
            get { return _archiveid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SingleProjectID
        {
            set { _singleprojectid = value; }
            get { return _singleprojectid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string area_code
        {
            set { _area_code = value; }
            get { return _area_code; }
        }
        /// <summary>
        /// 档号
        /// </summary>
        public string dh
        {
            set { _dh = value; }
            get { return _dh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int xh
        {
            set { _xh = value; }
            get { return _xh; }
        }
        /// <summary>
        /// 管理类：01,02,03,04  工程类：05,06,07,09,010
        /// </summary>
        public string archive_form_no
        {
            set { _archive_form_no = value; }
            get { return _archive_form_no; }
        }
        /// <summary>
        /// 库
        /// </summary>
        public string dz_k
        {
            set { _dz_k = value; }
            get { return _dz_k; }
        }
        /// <summary>
        /// 列
        /// </summary>
        public string dz_l
        {
            set { _dz_l = value; }
            get { return _dz_l; }
        }
        /// <summary>
        /// 节(柜)
        /// </summary>
        public string dz_g
        {
            set { _dz_g = value; }
            get { return _dz_g; }
        }
        /// <summary>
        /// 层
        /// </summary>
        public string dz_c
        {
            set { _dz_c = value; }
            get { return _dz_c; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dz_x
        {
            set { _dz_x = value; }
            get { return _dz_x; }
        }
        /// <summary>
        /// 案卷题名
        /// </summary>
        public string ajtm
        {
            set { _ajtm = value; }
            get { return _ajtm; }
        }
        /// <summary>
        /// 编制单位
        /// </summary>
        public string bzdw
        {
            set { _bzdw = value; }
            get { return _bzdw; }
        }
        /// <summary>
        /// 载体类型
        /// </summary>
        public string ztlx
        {
            set { _ztlx = value; }
            get { return _ztlx; }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public int sl
        {
            set { _sl = value; }
            get { return _sl; }
        }
        /// <summary>
        /// 单位
        /// </summary>
        public string dw
        {
            set { _dw = value; }
            get { return _dw; }
        }
        /// <summary>
        /// 规格
        /// </summary>
        public string gg
        {
            set { _gg = value; }
            get { return _gg; }
        }
        /// <summary>
        /// 卷内文件起始时间
        /// </summary>
        public DateTime? qssj
        {
            set { _qssj = value; }
            get { return _qssj; }
        }
        /// <summary>
        /// 卷内文件终止时间
        /// </summary>
        public DateTime? zzsj
        {
            set { _zzsj = value; }
            get { return _zzsj; }
        }
        /// <summary>
        /// 保管期限
        /// </summary>
        public string bgqx
        {
            set { _bgqx = value; }
            get { return _bgqx; }
        }
        /// <summary>
        /// 密级
        /// </summary>
        public string mj
        {
            set { _mj = value; }
            get { return _mj; }
        }
        /// <summary>
        /// 主题词
        /// </summary>
        public string ztc
        {
            set { _ztc = value; }
            get { return _ztc; }
        }
        /// <summary>
        /// 附注
        /// </summary>
        public string note
        {
            set { _note = value; }
            get { return _note; }
        }
        /// <summary>
        /// 录入人
        /// </summary>
        public string lrr
        {
            set { _lrr = value; }
            get { return _lrr; }
        }
        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime? lrsj
        {
            set { _lrsj = value; }
            get { return _lrsj; }
        }
        /// <summary>
        /// 文字(卷)
        /// </summary>
        public int? wz
        {
            set { _wz = value; }
            get { return _wz; }
        }
        /// <summary>
        /// 图纸(张)
        /// </summary>
        public int? tzz
        {
            set { _tzz = value; }
            get { return _tzz; }
        }
        /// <summary>
        /// 底图(张)
        /// </summary>
        public int? dt
        {
            set { _dt = value; }
            get { return _dt; }
        }
        /// <summary>
        /// 照片(张)
        /// </summary>
        public int? zp
        {
            set { _zp = value; }
            get { return _zp; }
        }
        /// <summary>
        /// 底片(张)
        /// </summary>
        public int? dp
        {
            set { _dp = value; }
            get { return _dp; }
        }
        /// <summary>
        /// 录音带(盒)
        /// </summary>
        public int? ly
        {
            set { _ly = value; }
            get { return _ly; }
        }
        /// <summary>
        /// 录像带(盒)
        /// </summary>
        public int? lx
        {
            set { _lx = value; }
            get { return _lx; }
        }
        /// <summary>
        /// 光盘(张)
        /// </summary>
        public int? gp
        {
            set { _gp = value; }
            get { return _gp; }
        }
        /// <summary>
        /// 磁带(盒)
        /// </summary>
        public int? cd
        {
            set { _cd = value; }
            get { return _cd; }
        }
        /// <summary>
        /// 磁盘(张)
        /// </summary>
        public int? cp
        {
            set { _cp = value; }
            get { return _cp; }
        }
        /// <summary>
        /// 缩微片(盘)
        /// </summary>
        public int? sw0
        {
            set { _sw0 = value; }
            get { return _sw0; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? sw1
        {
            set { _sw1 = value; }
            get { return _sw1; }
        }
        /// <summary>
        /// 其他
        /// </summary>
        public int? qt
        {
            set { _qt = value; }
            get { return _qt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? jk
        {
            set { _jk = value; }
            get { return _jk; }
        }
        /// <summary>
        /// 原档号
        /// </summary>
        public string jdh
        {
            set { _jdh = value; }
            get { return _jdh; }
        }
        /// <summary>
        /// 案卷整理人
        /// </summary>
        public string zlr
        {
            set { _zlr = value; }
            get { return _zlr; }
        }
        /// <summary>
        /// 案卷整理日期
        /// </summary>
        public DateTime? zlrq
        {
            set { _zlrq = value; }
            get { return _zlrq; }
        }
        /// <summary>
        /// 审核意见
        /// </summary>
        public string shyj
        {
            set { _shyj = value; }
            get { return _shyj; }
        }
        /// <summary>
        /// 审核人
        /// </summary>
        public string shr
        {
            set { _shr = value; }
            get { return _shr; }
        }
        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime? shsj
        {
            set { _shsj = value; }
            get { return _shsj; }
        }
        /// <summary>
        /// 移交情况
        /// </summary>
        public string yjqk
        {
            set { _yjqk = value; }
            get { return _yjqk; }
        }
        /// <summary>
        /// 移交人
        /// </summary>
        public string yjr
        {
            set { _yjr = value; }
            get { return _yjr; }
        }
        /// <summary>
        /// 移交时间
        /// </summary>
        public DateTime? yjsj
        {
            set { _yjsj = value; }
            get { return _yjsj; }
        }
        /// <summary>
        /// 接收情况
        /// </summary>
        public string rksh_jsqk
        {
            set { _rksh_jsqk = value; }
            get { return _rksh_jsqk; }
        }
        /// <summary>
        /// 接收时间
        /// </summary>
        public DateTime? rksh_jssj
        {
            set { _rksh_jssj = value; }
            get { return _rksh_jssj; }
        }
        /// <summary>
        /// 上架时间
        /// </summary>
        public DateTime? jgrq
        {
            set { _jgrq = value; }
            get { return _jgrq; }
        }
        /// <summary>
        /// 接收人
        /// </summary>
        public string jsr
        {
            set { _jsr = value; }
            get { return _jsr; }
        }
        /// <summary>
        /// 案卷类型
        /// </summary>
        public string ajlx
        {
            set { _ajlx = value; }
            get { return _ajlx; }
        }
        /// <summary>
        /// 总登记号
        /// </summary>
        public string zajh
        {
            set { _zajh = value; }
            get { return _zajh; }
        }
        /// <summary>
        /// 建设单位
        /// </summary>
        public string jsdw
        {
            set { _jsdw = value; }
            get { return _jsdw; }
        }
        /// <summary>
        /// 施工单位
        /// </summary>
        public string sgdw
        {
            set { _sgdw = value; }
            get { return _sgdw; }
        }
        /// <summary>
        /// 设计单位
        /// </summary>
        public string sjdw
        {
            set { _sjdw = value; }
            get { return _sjdw; }
        }
        /// <summary>
        /// 项目名称 B
        /// </summary>
        public string gcmc
        {
            set { _gcmc = value; }
            get { return _gcmc; }
        }
        /// <summary>
        /// 项目地址 C
        /// </summary>
        public string gcdd
        {
            set { _gcdd = value; }
            get { return _gcdd; }
        }
        /// <summary>
        /// 勘察单位
        /// </summary>
        public string kcdw
        {
            set { _kcdw = value; }
            get { return _kcdw; }
        }
        /// <summary>
        /// 监理单位
        /// </summary>
        public string jldw
        {
            set { _jldw = value; }
            get { return _jldw; }
        }
        /// <summary>
        /// 总件数
        /// </summary>
        public int? zjs
        {
            set { _zjs = value; }
            get { return _zjs; }
        }
        /// <summary>
        /// 总卷数
        /// </summary>
        public int? zajs
        {
            set { _zajs = value; }
            get { return _zajs; }
        }
        /// <summary>
        /// 第几卷
        /// </summary>
        public int? djj
        {
            set { _djj = value; }
            get { return _djj; }
        }
        /// <summary>
        /// 地块编号
        /// </summary>
        public string dkbh
        {
            set { _dkbh = value; }
            get { return _dkbh; }
        }
        /// <summary>
        /// 项目总编号
        /// </summary>
        public string xmbh
        {
            set { _xmbh = value; }
            get { return _xmbh; }
        }
        /// <summary>
        /// 地形图号
        /// </summary>
        public string tfh
        {
            set { _tfh = value; }
            get { return _tfh; }
        }
        /// <summary>
        /// 设计负责人
        /// </summary>
        public string sjdwfzr
        {
            set { _sjdwfzr = value; }
            get { return _sjdwfzr; }
        }
        /// <summary>
        /// 批准文号
        /// </summary>
        public string pzwh
        {
            set { _pzwh = value; }
            get { return _pzwh; }
        }
        /// <summary>
        /// 建筑密度%
        /// </summary>
        public string jzmd
        {
            set { _jzmd = value; }
            get { return _jzmd; }
        }
        /// <summary>
        /// 容积率
        /// </summary>
        public string rjl
        {
            set { _rjl = value; }
            get { return _rjl; }
        }
        /// <summary>
        /// 建筑面积
        /// </summary>
        public decimal? jzmj
        {
            set { _jzmj = value; }
            get { return _jzmj; }
        }
        /// <summary>
        /// 用地面积
        /// </summary>
        public decimal? ydmj
        {
            set { _ydmj = value; }
            get { return _ydmj; }
        }
        /// <summary>
        /// 绿地率%
        /// </summary>
        public decimal? lhl
        {
            set { _lhl = value; }
            get { return _lhl; }
        }
        /// <summary>
        /// 规划性质
        /// </summary>
        public string ghxz
        {
            set { _ghxz = value; }
            get { return _ghxz; }
        }
        /// <summary>
        ///  东至
        /// </summary>
        public string wz_dz
        {
            set { _wz_dz = value; }
            get { return _wz_dz; }
        }
        /// <summary>
        /// 西至
        /// </summary>
        public string wz_xz
        {
            set { _wz_xz = value; }
            get { return _wz_xz; }
        }
        /// <summary>
        ///  南至
        /// </summary>
        public string wz_nz
        {
            set { _wz_nz = value; }
            get { return _wz_nz; }
        }
        /// <summary>
        /// 北至
        /// </summary>
        public string wz_bz
        {
            set { _wz_bz = value; }
            get { return _wz_bz; }
        }
        /// <summary>
        /// 批准自年
        /// </summary>
        public int? pz_zn
        {
            set { _pz_zn = value; }
            get { return _pz_zn; }
        }
        /// <summary>
        /// 批准自月
        /// </summary>
        public int? pz_zy
        {
            set { _pz_zy = value; }
            get { return _pz_zy; }
        }
        /// <summary>
        /// 盒号
        /// </summary>
        public string hh
        {
            set { _hh = value; }
            get { return _hh; }
        }
        /// <summary>
        /// 用地规划许可证号
        /// </summary>
        public string ydghxkzh
        {
            set { _ydghxkzh = value; }
            get { return _ydghxkzh; }
        }
        /// <summary>
        /// 用地规划许可证号 发证机关
        /// </summary>
        public string ydghxkzh_fzjg
        {
            set { _ydghxkzh_fzjg = value; }
            get { return _ydghxkzh_fzjg; }
        }
        /// <summary>
        /// 用地规划许可证号 批准日期
        /// </summary>
        public DateTime? ydghxkzh_fzrq
        {
            set { _ydghxkzh_fzrq = value; }
            get { return _ydghxkzh_fzrq; }
        }
        /// <summary>
        /// 工程规划许可证号
        /// </summary>
        public string ghxkzh
        {
            set { _ghxkzh = value; }
            get { return _ghxkzh; }
        }
        /// <summary>
        /// 工程规划许可证号 发证机关
        /// </summary>
        public string ghxkzh_fzjg
        {
            set { _ghxkzh_fzjg = value; }
            get { return _ghxkzh_fzjg; }
        }
        /// <summary>
        /// 工程规划许可证号 批准日期
        /// </summary>
        public DateTime? ghxkzh_fzrq
        {
            set { _ghxkzh_fzrq = value; }
            get { return _ghxkzh_fzrq; }
        }
        /// <summary>
        /// 土地用途
        /// </summary>
        public string tdyt
        {
            set { _tdyt = value; }
            get { return _tdyt; }
        }
        /// <summary>
        /// 土地性质
        /// </summary>
        public string ydxz
        {
            set { _ydxz = value; }
            get { return _ydxz; }
        }
        /// <summary>
        /// 勘察区域
        /// </summary>
        public string kcqy
        {
            set { _kcqy = value; }
            get { return _kcqy; }
        }
        /// <summary>
        /// 比例尺
        /// </summary>
        public string blz
        {
            set { _blz = value; }
            get { return _blz; }
        }
        /// <summary>
        /// 图幅长X宽
        /// </summary>
        public string tfck
        {
            set { _tfck = value; }
            get { return _tfck; }
        }
        /// <summary>
        /// 存放方式
        /// </summary>
        public string cffs
        {
            set { _cffs = value; }
            get { return _cffs; }
        }
        /// <summary>
        /// 坐标系统
        /// </summary>
        public string zbxt
        {
            set { _zbxt = value; }
            get { return _zbxt; }
        }
        /// <summary>
        /// 高程系统
        /// </summary>
        public string gcxt
        {
            set { _gcxt = value; }
            get { return _gcxt; }
        }
        /// <summary>
        /// 投资金额（万元）
        /// </summary>
        public decimal? tzje
        {
            set { _tzje = value; }
            get { return _tzje; }
        }
        /// <summary>
        /// 用地单位
        /// </summary>
        public string yddw
        {
            set { _yddw = value; }
            get { return _yddw; }
        }
        /// <summary>
        /// 移交单位 A
        /// </summary>
        public string yjdw
        {
            set { _yjdw = value; }
            get { return _yjdw; }
        }
        /// <summary>
        /// 房地产权证号
        /// </summary>
        public string fdcqzh
        {
            set { _fdcqzh = value; }
            get { return _fdcqzh; }
        }
        /// <summary>
        /// 房地产权证号 发证机关
        /// </summary>
        public string fdcqzh_fzjg
        {
            set { _fdcqzh_fzjg = value; }
            get { return _fdcqzh_fzjg; }
        }
        /// <summary>
        /// 房地产权证号 批准日期
        /// </summary>
        public DateTime? fdcqzh_pzrq
        {
            set { _fdcqzh_pzrq = value; }
            get { return _fdcqzh_pzrq; }
        }
        /// <summary>
        /// 施工许可证号
        /// </summary>
        public string sgxkzh
        {
            set { _sgxkzh = value; }
            get { return _sgxkzh; }
        }
        /// <summary>
        /// 施工许可证号 发证机关
        /// </summary>
        public string sgxkzh_fzjg
        {
            set { _sgxkzh_fzjg = value; }
            get { return _sgxkzh_fzjg; }
        }
        /// <summary>
        /// 施工许可证号 批准日期
        /// </summary>
        public DateTime? sgxkzh_pzrq
        {
            set { _sgxkzh_pzrq = value; }
            get { return _sgxkzh_pzrq; }
        }
        /// <summary>
        /// 原地名
        /// </summary>
        public string ydm
        {
            set { _ydm = value; }
            get { return _ydm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ydxzh
        {
            set { _ydxzh = value; }
            get { return _ydxzh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sw
        {
            set { _sw = value; }
            get { return _sw; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ShortDH
        {
            set { _shortdh = value; }
            get { return _shortdh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string xzyjsh
        {
            set { _xzyjsh = value; }
            get { return _xzyjsh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? xzyjsh_pzrq
        {
            set { _xzyjsh_pzrq = value; }
            get { return _xzyjsh_pzrq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string jzjg
        {
            set { _jzjg = value; }
            get { return _jzjg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string qy
        {
            set { _qy = value; }
            get { return _qy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? jzcs
        {
            set { _jzcs = value; }
            get { return _jzcs; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? jzgd
        {
            set { _jzgd = value; }
            get { return _jzgd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? tccmj
        {
            set { _tccmj = value; }
            get { return _tccmj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ztz
        {
            set { _ztz = value; }
            get { return _ztz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string zdjh
        {
            set { _zdjh = value; }
            get { return _zdjh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cfdz
        {
            set { _cfdz = value; }
            get { return _cfdz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string swh
        {
            set { _swh = value; }
            get { return _swh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string jnwjqssj
        {
            set { _jnwjqssj = value; }
            get { return _jnwjqssj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string jnwjzzsj
        {
            set { _jnwjzzsj = value; }
            get { return _jnwjzzsj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ydh
        {
            set { _ydh = value; }
            get { return _ydh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fz
        {
            set { _fz = value; }
            get { return _fz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool rkflag
        {
            set { _rkflag = value; }
            get { return _rkflag; }
        }
        public string BoxType
        {
            set { _boxType = value; }
            get { return _boxType; }
        }

        public int wzCount
        {
            set;
            get;
        }
        public int tzCount
        {
            set;
            get;
        }
        public int zpCount
        {
            set;
            get;
        }
        public string dhNew
        {
            set { _dhnew = value; }
            get { return _dhnew; }
        }
        #endregion Model

    }
}

