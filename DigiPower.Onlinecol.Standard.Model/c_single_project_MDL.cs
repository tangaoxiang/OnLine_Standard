using System;
namespace DigiPower.Onlinecol.Standard.Model
{
    /// <summary>
    /// 实体类c_single_project_MDL 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class c_single_project_MDL
    {
        public c_single_project_MDL()
        { }
        #region Model
        private int _singleprojectid;
        private string _dxgcmc;
        private string _sgdw;
        private string _dxth;
        private string _qd;
        private string _zd;
        private decimal? _chd;
        private string _gg;
        private string _cz;
        private string _hz;
        private DateTime? _kgsj;
        private DateTime? _jgsj;
        private decimal? _gczj;
        private decimal? _gcjs;
        private int? _ajs;
        private int? _wz;
        private int? _tzj;
        private int? _tzz;
        private int? _dt;
        private int? _zp;
        private int? _dp;
        private int? _ly;
        private int? _lx;
        private int? _gp;
        private int? _cd;
        private int? _cp;
        private int? _swz;
        private string _qt;
        private string _bgqx;
        private string _mj;
        private DateTime? _jgrq;
        private string _yjdw;
        private string _swh;
        private string _cfwz;
        private string _note;
        private int? _swp;
        private string _lrr;
        private DateTime? _lrsj;
        private string _zrsbh;
        private string _lxr;
        private string _lxdh;
        private int? _gisid;
        private int? _ywzd;
        private string _ghxkzh;
        private string _sgxkzh;
        private string _zlaqjddw;
        private string _zlyj;
        private string _gc_code;
        private string _ydxkzh;
        private string _ydghxkzh;
        private string _hjqk;
        private string _sjdw_xmfzr;
        private string _kcdw;
        private string _kcdw_xmfzr;
        private string _jldw_xmfzr;
        private string _sgdw_xmjl;
        private string _zjlgcs;
        private string _zyjlgcs;
        private string _fbdw;
        private string _fbdw_xmjl;
        private string _fbdw_1;
        private string _fbdw_1_xmjl;
        private string _zygz;
        private string _xmzyzljcy;
        private string _sgbzz;
        private string _tbr;
        private string _jsdw_shr;
        private string _jldw_shr;
        private DateTime? _shrq;
        private string _tjlb;
        private DateTime? _fpsj;
        private string _fpr;
        private string _spr;
        private string _spr_dh;
        private string _fp_bz;
        private string _sjyl;
        private string _bg;
        private string _ms;
        private string _ll;
        private string _sjdw;
        private string _jldw;
        private string _kzdj;
        private int? _wzz;
        private string _zcd;
        private string _gczl;
        private string _gcys;
        private string _qdzb;
        private string _zdzb;
        private string _fz;
        /// <summary>
        /// 
        /// </summary>
        public int SingleProjectID
        {
            set { _singleprojectid = value; }
            get { return _singleprojectid; }
        }
        /// <summary>
        /// 单位工程名称
        /// </summary>
        public string dxgcmc
        {
            set { _dxgcmc = value; }
            get { return _dxgcmc; }
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
        /// 地形图号
        /// </summary>
        public string dxth
        {
            set { _dxth = value; }
            get { return _dxth; }
        }
        /// <summary>
        /// 起点
        /// </summary>
        public string qd
        {
            set { _qd = value; }
            get { return _qd; }
        }
        /// <summary>
        /// 止点
        /// </summary>
        public string zd
        {
            set { _zd = value; }
            get { return _zd; }
        }
        /// <summary>
        /// 长度(m)
        /// </summary>
        public decimal? chd
        {
            set { _chd = value; }
            get { return _chd; }
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
        /// 材质
        /// </summary>
        public string cz
        {
            set { _cz = value; }
            get { return _cz; }
        }
        /// <summary>
        /// 荷载
        /// </summary>
        public string hz
        {
            set { _hz = value; }
            get { return _hz; }
        }
        /// <summary>
        /// 开工时间
        /// </summary>
        public DateTime? kgsj
        {
            set { _kgsj = value; }
            get { return _kgsj; }
        }
        /// <summary>
        /// 竣工时间
        /// </summary>
        public DateTime? jgsj
        {
            set { _jgsj = value; }
            get { return _jgsj; }
        }
        /// <summary>
        /// 工程预算(万元)
        /// </summary>
        public decimal? gczj
        {
            set { _gczj = value; }
            get { return _gczj; }
        }
        /// <summary>
        /// 工程决算(万元)
        /// </summary>
        public decimal? gcjs
        {
            set { _gcjs = value; }
            get { return _gcjs; }
        }
        /// <summary>
        /// 案卷数
        /// </summary>
        public int? ajs
        {
            set { _ajs = value; }
            get { return _ajs; }
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
        /// 图纸(卷)
        /// </summary>
        public int? tzj
        {
            set { _tzj = value; }
            get { return _tzj; }
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
        /// 缩微片(张)
        /// </summary>
        public int? swz
        {
            set { _swz = value; }
            get { return _swz; }
        }
        /// <summary>
        /// 其他
        /// </summary>
        public string qt
        {
            set { _qt = value; }
            get { return _qt; }
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
        /// 进馆日期
        /// </summary>
        public DateTime? jgrq
        {
            set { _jgrq = value; }
            get { return _jgrq; }
        }
        /// <summary>
        /// 移交单位
        /// </summary>
        public string yjdw
        {
            set { _yjdw = value; }
            get { return _yjdw; }
        }
        /// <summary>
        /// 缩微号
        /// </summary>
        public string swh
        {
            set { _swh = value; }
            get { return _swh; }
        }
        /// <summary>
        /// 存放位置起始号
        /// </summary>
        public string cfwz
        {
            set { _cfwz = value; }
            get { return _cfwz; }
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
        /// 缩微片(盘)
        /// </summary>
        public int? swp
        {
            set { _swp = value; }
            get { return _swp; }
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
        /// 档案责任书编号
        /// </summary>
        public string zrsbh
        {
            set { _zrsbh = value; }
            get { return _zrsbh; }
        }
        /// <summary>
        /// 档案负责人 联系电话
        /// </summary>
        public string lxr
        {
            set { _lxr = value; }
            get { return _lxr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string lxdh
        {
            set { _lxdh = value; }
            get { return _lxdh; }
        }
        /// <summary>
        /// 空间标识
        /// </summary>
        public int? gisid
        {
            set { _gisid = value; }
            get { return _gisid; }
        }
        /// <summary>
        /// 业务指导标志
        /// </summary>
        public int? ywzd
        {
            set { _ywzd = value; }
            get { return _ywzd; }
        }
        /// <summary>
        /// 规划许可证号
        /// </summary>
        public string ghxkzh
        {
            set { _ghxkzh = value; }
            get { return _ghxkzh; }
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
        /// 质量安全监督单位
        /// </summary>
        public string zlaqjddw
        {
            set { _zlaqjddw = value; }
            get { return _zlaqjddw; }
        }
        /// <summary>
        /// 整理移交标志
        /// </summary>
        public string zlyj
        {
            set { _zlyj = value; }
            get { return _zlyj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gc_code
        {
            set { _gc_code = value; }
            get { return _gc_code; }
        }
        /// <summary>
        /// 用地许可证号
        /// </summary>
        public string YDXKZH
        {
            set { _ydxkzh = value; }
            get { return _ydxkzh; }
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
        /// 获奖情况

        /// </summary>
        public string HJQK
        {
            set { _hjqk = value; }
            get { return _hjqk; }
        }
        /// <summary>
        /// 设计单位项目负责人
        /// </summary>
        public string SJDW_XMFZR
        {
            set { _sjdw_xmfzr = value; }
            get { return _sjdw_xmfzr; }
        }
        /// <summary>
        /// 勘察单位

        /// </summary>
        public string KCDW
        {
            set { _kcdw = value; }
            get { return _kcdw; }
        }
        /// <summary>
        /// 勘察单位项目负责人

        /// </summary>
        public string KCDW_XMFZR
        {
            set { _kcdw_xmfzr = value; }
            get { return _kcdw_xmfzr; }
        }
        /// <summary>
        /// 监理单位项目负责人

        /// </summary>
        public string JLDW_XMFZR
        {
            set { _jldw_xmfzr = value; }
            get { return _jldw_xmfzr; }
        }
        /// <summary>
        /// 施工单位项目负责人

        /// </summary>
        public string SGDW_XMJL
        {
            set { _sgdw_xmjl = value; }
            get { return _sgdw_xmjl; }
        }
        /// <summary>
        /// 项目总监

        /// </summary>
        public string ZJLGCS
        {
            set { _zjlgcs = value; }
            get { return _zjlgcs; }
        }
        /// <summary>
        /// 现场监理

        /// </summary>
        public string ZYJLGCS
        {
            set { _zyjlgcs = value; }
            get { return _zyjlgcs; }
        }
        /// <summary>
        /// 分包单位
        /// </summary>
        public string FBDW
        {
            set { _fbdw = value; }
            get { return _fbdw; }
        }
        /// <summary>
        /// 分包单位项目经理
        /// </summary>
        public string FBDW_XMJL
        {
            set { _fbdw_xmjl = value; }
            get { return _fbdw_xmjl; }
        }
        /// <summary>
        /// 分包单位2
        /// </summary>
        public string FBDW_1
        {
            set { _fbdw_1 = value; }
            get { return _fbdw_1; }
        }
        /// <summary>
        /// 分包单位项目经理2

        /// </summary>
        public string FBDW_1_XMJL
        {
            set { _fbdw_1_xmjl = value; }
            get { return _fbdw_1_xmjl; }
        }
        /// <summary>
        /// 专业工长
        /// </summary>
        public string ZYGZ
        {
            set { _zygz = value; }
            get { return _zygz; }
        }
        /// <summary>
        /// 项目专业质量检查员
        /// </summary>
        public string XMZYZLJCY
        {
            set { _xmzyzljcy = value; }
            get { return _xmzyzljcy; }
        }
        /// <summary>
        /// 施工班组长
        /// </summary>
        public string SGBZZ
        {
            set { _sgbzz = value; }
            get { return _sgbzz; }
        }
        /// <summary>
        /// 填表人

        /// </summary>
        public string TBR
        {
            set { _tbr = value; }
            get { return _tbr; }
        }
        /// <summary>
        /// 建设单位审核人

        /// </summary>
        public string JSDW_SHR
        {
            set { _jsdw_shr = value; }
            get { return _jsdw_shr; }
        }
        /// <summary>
        /// 监理单位审核人
        /// </summary>
        public string JLDW_SHR
        {
            set { _jldw_shr = value; }
            get { return _jldw_shr; }
        }
        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime? SHRQ
        {
            set { _shrq = value; }
            get { return _shrq; }
        }
        /// <summary>
        /// 建筑性质
        /// </summary>
        public string TJLB
        {
            set { _tjlb = value; }
            get { return _tjlb; }
        }
        /// <summary>
        /// 发盘时间
        /// </summary>
        public DateTime? FPSJ
        {
            set { _fpsj = value; }
            get { return _fpsj; }
        }
        /// <summary>
        /// 发盘人
        /// </summary>
        public string FPR
        {
            set { _fpr = value; }
            get { return _fpr; }
        }
        /// <summary>
        /// 收盘人
        /// </summary>
        public string SPR
        {
            set { _spr = value; }
            get { return _spr; }
        }
        /// <summary>
        /// 收盘人电    话
        /// </summary>
        public string SPR_DH
        {
            set { _spr_dh = value; }
            get { return _spr_dh; }
        }
        /// <summary>
        /// 发盘信息备注
        /// </summary>
        public string FP_BZ
        {
            set { _fp_bz = value; }
            get { return _fp_bz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sjyl
        {
            set { _sjyl = value; }
            get { return _sjyl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bg
        {
            set { _bg = value; }
            get { return _bg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ms
        {
            set { _ms = value; }
            get { return _ms; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ll
        {
            set { _ll = value; }
            get { return _ll; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sjdw
        {
            set { _sjdw = value; }
            get { return _sjdw; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string jldw
        {
            set { _jldw = value; }
            get { return _jldw; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string kzdj
        {
            set { _kzdj = value; }
            get { return _kzdj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? wzz
        {
            set { _wzz = value; }
            get { return _wzz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string zcd
        {
            set { _zcd = value; }
            get { return _zcd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gczl
        {
            set { _gczl = value; }
            get { return _gczl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gcys
        {
            set { _gcys = value; }
            get { return _gcys; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string qdzb
        {
            set { _qdzb = value; }
            get { return _qdzb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string zdzb
        {
            set { _zdzb = value; }
            get { return _zdzb; }
        }
        public string fz
        {
            set { _fz = value; }
            get { return _fz; }
        }
        #endregion Model

    }
}

