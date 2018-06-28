using System;
namespace DigiPower.Onlinecol.Standard.Model {
    /// <summary>
    /// ʵ����T_FileList_MDL ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class T_FileList_MDL {
        public T_FileList_MDL() { }
        #region Model
        private int _filelistid;
        private int _singleprojectid;
        private int? _archiveid;
        private int? _myarchiveid;
        private int? _recid;
        private int? _pid;
        private int? _defaultcompanytype;
        private string _dh;
        private string _mycode;
        private string _bh;
        private string _title;
        private bool _mustsubmitflag;
        private string _oldstatus;
        private string _status;
        private string _starttime;
        private string _endtime;
        private int _companyid;
        private int _operateuserid;
        private string _operateusername;
        private int _orderindex;
        private int? _manualcount;
        private int? _pagescount;
        private int? _winrecvpagescount;
        private string _remark;
        private string _pdffilepath;
        private bool _alonepack;
        private bool _isfolder;
        private bool _issystem;
        private string _filetype;
        private string _archive_form_no;
        private string _zajh;
        private string _w_t_h;
        private string _wjtm;
        private string _zrr;
        private DateTime? _qssj;
        private DateTime? _zzsj;
        private string _yc;
        private string _wb;
        private int? _sl;
        private string _bgqx;
        private string _mj;
        private string _dz_k;
        private string _dz_l;
        private string _dz_g;
        private string _dz_c;
        private string _dz_x;
        private string _ztlx;
        private string _dw;
        private string _gg;
        private string _ty;
        private string _ztc;
        private string _note;
        private string _sw;
        private string _dz;
        private string _lrr;
        private DateTime? _lrsj;
        private int? _shzt;
        private string _shr_1;
        private DateTime? _shsj_1;
        private string _shr_2;
        private DateTime? _shsj_2;
        private string _shr_3;
        private DateTime? _shsj_3;
        private DateTime? _aipdate;
        private string _aipuser;
        private string _shortdh;
        private string _swgph;
        private string _cfdz;
        private string _wjbt;
        private string _zrz;
        private string _wh;
        private string _wjfwqx;
        private string _xcsj;
        private string _dzwjxx;
        private string _fz;
        private DateTime? _createdate;
        private DateTime? _createdate2;
        private int? _tzz;
        private int? _dtz;
        private int? _zpz;
        private int? _wzz;
        private int? _dpz;
        private string _wjgbdm;
        private string _wjlxdm;
        private string _wjgs;
        private string _wjdx;
        private string _psdd;
        private string _psz;
        private DateTime? _pssj;
        private string _sb;
        private string _fbl;
        private string _xjpp;
        private string _xjxh;
        private string _bz;

        private int? _lockflag;
        private string _dousername;
        private DateTime? _dodate;
        private string _doip;

        private bool _convert_flag;
        private string _convert_dt;

        private string _root_path;

        private string _from_sid;
        private int? _oldrecid;
        private int? _myorderindex;
        private string _filefrom;
        private string _isMerge;
        private int? _version;
        private bool _isignaturepdf;
        private bool _isignatureworkflow;


        /// <summary>
        /// �ļ��޸ĵİ汾��,������������Ԥ�����˻ص��ļ��ǼǴ�����һ��
        /// ������������Ԥ����,���Բ鿴�˻غ�Ĺ������ļ��Ǽǻ���,��Щ�ļ����޸Ĺ�,���ڹ�����Ա���
        /// </summary>
        public int? Version {
            set { _version = value; }
            get { return _version; }
        }

        /// <summary>
        /// �ļ���Դ(����,�ʼ�,���,����ί�ȵ�λ)
        /// </summary>
        public string FileFrom {
            set { _filefrom = value; }
            get { return _filefrom; }
        }

        /// <summary>
        /// �ⲿϵͳ������ļ��ǵ��ű���PDF,���Ƕ��ű��ϲ���PDF
        /// </summary>
        public string IsMerge {
            set { _isMerge = value; }
            get { return _isMerge; }
        }

        /// <summary>
        /// ��λ������ļ����
        /// </summary>
        public int? MyOrderIndex {
            set { _myorderindex = value; }
            get { return _myorderindex; }
        }

        /// <summary>
        /// �鵵Ŀ¼�ļ�ԭʼID
        /// </summary>
        public int? OldRecID {
            set { _oldrecid = value; }
            get { return _oldrecid; }
        }

        /// <summary>
        /// �ļ�ID
        /// </summary>
        public int FileListID {
            set { _filelistid = value; }
            get { return _filelistid; }
        }

        /// <summary>
        /// ����ID
        /// </summary>
        public int SingleProjectID {
            set { _singleprojectid = value; }
            get { return _singleprojectid; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int? ArchiveID {
            set { _archiveid = value; }
            get { return _archiveid; }
        }

        /// <summary>
        /// ��˾����ID
        /// </summary>
        public int? MyArchiveID {
            set { _myarchiveid = value; }
            get { return _myarchiveid; }
        }

        /// <summary>
        /// �鵵Ŀ¼ID,�����ļ�recid���
        /// </summary>
        public int? recID {
            set { _recid = value; }
            get { return _recid; }
        }

        /// <summary>
        /// �ļ���ID
        /// </summary>
        public int? PID {
            set { _pid = value; }
            get { return _pid; }
        }

        /// <summary>
        ///  �ļ�Ĭ��������λ����
        /// </summary>
        public int? DefaultCompanyType {
            set { _defaultcompanytype = value; }
            get { return _defaultcompanytype; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string DH {
            set { _dh = value; }
            get { return _dh; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string MyCode {
            set { _mycode = value; }
            get { return _mycode; }
        }

        /// <summary>
        /// �ļ����
        /// </summary>
        public string BH {
            set { _bh = value; }
            get { return _bh; }
        }

        /// <summary>
        /// �ļ�����
        /// </summary>
        public string Title {
            set { _title = value; }
            get { return _title; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool MustSubmitFlag {
            set { _mustsubmitflag = value; }
            get { return _mustsubmitflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OldStatus {
            set { _oldstatus = value; }
            get { return _oldstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Status {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StartTime {
            set { _starttime = value; }
            get { return _starttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EndTime {
            set { _endtime = value; }
            get { return _endtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int CompanyID {
            set { _companyid = value; }
            get { return _companyid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int OperateUserID {
            set { _operateuserid = value; }
            get { return _operateuserid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OperateUserName {
            set { _operateusername = value; }
            get { return _operateusername; }
        }
        /// <summary>
        /// ҵ�񰸾���ļ����
        /// </summary>
        public int OrderIndex {
            set { _orderindex = value; }
            get { return _orderindex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ManualCount {
            set { _manualcount = value; }
            get { return _manualcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PagesCount {
            set { _pagescount = value; }
            get { return _pagescount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? WinRecvPagesCount {
            set { _winrecvpagescount = value; }
            get { return _winrecvpagescount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PDFFilePath {
            set { _pdffilepath = value; }
            get { return _pdffilepath; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool AlonePack {
            set { _alonepack = value; }
            get { return _alonepack; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsFolder {
            set { _isfolder = value; }
            get { return _isfolder; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsSystem {
            set { _issystem = value; }
            get { return _issystem; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FileType {
            set { _filetype = value; }
            get { return _filetype; }
        }
        /// <summary>
        /// �����ࣺ01,02,03,04  �����ࣺ05,06,07,09,010
        /// </summary>
        public string archive_form_no {
            set { _archive_form_no = value; }
            get { return _archive_form_no; }
        }
        /// <summary>
        /// �ܵǼǺ�
        /// </summary>
        public string zajh {
            set { _zajh = value; }
            get { return _zajh; }
        }
        /// <summary>
        /// ��(ͼ)��
        /// </summary>
        public string w_t_h {
            set { _w_t_h = value; }
            get { return _w_t_h; }
        }
        /// <summary>
        /// �ļ�����
        /// </summary>
        public string wjtm {
            set { _wjtm = value; }
            get { return _wjtm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string zrr {
            set { _zrr = value; }
            get { return _zrr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? qssj {
            set { _qssj = value; }
            get { return _qssj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? zzsj {
            set { _zzsj = value; }
            get { return _zzsj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string yc {
            set { _yc = value; }
            get { return _yc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string wb {
            set { _wb = value; }
            get { return _wb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? sl {
            set { _sl = value; }
            get { return _sl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bgqx {
            set { _bgqx = value; }
            get { return _bgqx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mj {
            set { _mj = value; }
            get { return _mj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dz_k {
            set { _dz_k = value; }
            get { return _dz_k; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dz_l {
            set { _dz_l = value; }
            get { return _dz_l; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dz_g {
            set { _dz_g = value; }
            get { return _dz_g; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dz_c {
            set { _dz_c = value; }
            get { return _dz_c; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dz_x {
            set { _dz_x = value; }
            get { return _dz_x; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ztlx {
            set { _ztlx = value; }
            get { return _ztlx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dw {
            set { _dw = value; }
            get { return _dw; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gg {
            set { _gg = value; }
            get { return _gg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ty {
            set { _ty = value; }
            get { return _ty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ztc {
            set { _ztc = value; }
            get { return _ztc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string note {
            set { _note = value; }
            get { return _note; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sw {
            set { _sw = value; }
            get { return _sw; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dz {
            set { _dz = value; }
            get { return _dz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string lrr {
            set { _lrr = value; }
            get { return _lrr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? lrsj {
            set { _lrsj = value; }
            get { return _lrsj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? shzt {
            set { _shzt = value; }
            get { return _shzt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string shr_1 {
            set { _shr_1 = value; }
            get { return _shr_1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? shsj_1 {
            set { _shsj_1 = value; }
            get { return _shsj_1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string shr_2 {
            set { _shr_2 = value; }
            get { return _shr_2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? shsj_2 {
            set { _shsj_2 = value; }
            get { return _shsj_2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string shr_3 {
            set { _shr_3 = value; }
            get { return _shr_3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? shsj_3 {
            set { _shsj_3 = value; }
            get { return _shsj_3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? aipdate {
            set { _aipdate = value; }
            get { return _aipdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string aipuser {
            set { _aipuser = value; }
            get { return _aipuser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ShortDH {
            set { _shortdh = value; }
            get { return _shortdh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string swgph {
            set { _swgph = value; }
            get { return _swgph; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cfdz {
            set { _cfdz = value; }
            get { return _cfdz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string wjbt {
            set { _wjbt = value; }
            get { return _wjbt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string zrz {
            set { _zrz = value; }
            get { return _zrz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string wh {
            set { _wh = value; }
            get { return _wh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string wjfwqx {
            set { _wjfwqx = value; }
            get { return _wjfwqx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string xcsj {
            set { _xcsj = value; }
            get { return _xcsj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dzwjxx {
            set { _dzwjxx = value; }
            get { return _dzwjxx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fz {
            set { _fz = value; }
            get { return _fz; }
        }
        /// <summary>
        /// �γ�ʱ��1
        /// </summary>
        public DateTime? CreateDate {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// �γ�ʱ��2
        /// </summary>
        public DateTime? CreateDate2 {
            set { _createdate2 = value; }
            get { return _createdate2; }
        }
        /// <summary>
        /// ͼֽ��
        /// </summary>
        public int? tzz {
            set { _tzz = value; }
            get { return _tzz; }
        }
        /// <summary>
        /// ��ͼ��
        /// </summary>
        public int? dtz {
            set { _dtz = value; }
            get { return _dtz; }
        }
        /// <summary>
        /// ��Ƭ��
        /// </summary>
        public int? zpz {
            set { _zpz = value; }
            get { return _zpz; }
        }
        /// <summary>
        /// ��Ƭ�������ţ�
        /// </summary>
        public int? wzz {
            set { _wzz = value; }
            get { return _wzz; }
        }
        /// <summary>
        /// ��Ƭ���ţ�
        /// </summary>
        public int? dpz {
            set { _dpz = value; }
            get { return _dpz; }
        }
        /// <summary>
        /// �ı��屾����
        /// </summary>
        public string wjgbdm {
            set { _wjgbdm = value; }
            get { return _wjgbdm; }
        }
        /// <summary>
        /// �ļ����ʹ���
        /// </summary>
        public string wjlxdm {
            set { _wjlxdm = value; }
            get { return _wjlxdm; }
        }
        /// <summary>
        /// �ļ���ʽ
        /// </summary>
        public string wjgs {
            set { _wjgs = value; }
            get { return _wjgs; }
        }
        /// <summary>
        /// �ļ���С
        /// </summary>
        public string wjdx {
            set { _wjdx = value; }
            get { return _wjdx; }
        }
        /// <summary>
        /// ����ص�
        /// </summary>
        public string psdd {
            set { _psdd = value; }
            get { return _psdd; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public string psz {
            set { _psz = value; }
            get { return _psz; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime? pssj {
            set { _pssj = value; }
            get { return _pssj; }
        }
        /// <summary>
        /// ɫ��
        /// </summary>
        public string sb {
            set { _sb = value; }
            get { return _sb; }
        }
        /// <summary>
        /// �ֱ���
        /// </summary>
        public string fbl {
            set { _fbl = value; }
            get { return _fbl; }
        }
        /// <summary>
        /// ���Ʒ��
        /// </summary>
        public string xjpp {
            set { _xjpp = value; }
            get { return _xjpp; }
        }
        /// <summary>
        /// ����ͺ�
        /// </summary>
        public string xjxh {
            set { _xjxh = value; }
            get { return _xjxh; }
        }
        /// <summary>
        /// ��ע
        /// </summary>
        public string bz {
            set { _bz = value; }
            get { return _bz; }
        }
        #endregion Model

        /// <summary>
        /// �������� �������
        /// </summary>
        public int? LockFlag {
            set { _lockflag = value; }
            get { return _lockflag; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public string DoUserName {
            set { _dousername = value; }
            get { return _dousername; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime? DoDate {
            set { _dodate = value; }
            get { return _dodate; }
        }
        /// <summary>
        /// �������IP
        /// </summary>
        public string DoIP {
            set { _doip = value; }
            get { return _doip; }
        }

        /// <summary>
        /// PDFת��ʱ��
        /// </summary>
        public string CONVERT_DT {
            set { _convert_dt = value; }
            get { return _convert_dt; }
        }

        /// <summary>
        /// PDF�Ƿ�ת���ɹ�
        /// </summary>
        public bool CONVERT_FLAG {
            set { _convert_flag = value; }
            get { return _convert_flag; }
        }

        /// <summary>
        /// PDF���·�� ��:d:\efilepath
        /// </summary>
        public string RootPath {
            set { _root_path = value; }
            get { return _root_path; }
        }

        private string _XAXIS_RESOLUTION;
        /// <summary>
        /// X��ֱ���
        /// </summary>
        public string XAXIS_RESOLUTION {
            set { _XAXIS_RESOLUTION = value; }
            get { return _XAXIS_RESOLUTION; }
        }

        private string _YAXIS_RESOLUTION;
        /// <summary>
        /// Y��ֱ���
        /// </summary>
        public string YAXIS_RESOLUTION {
            set { _YAXIS_RESOLUTION = value; }
            get { return _YAXIS_RESOLUTION; }
        }

        private string _IMAGE_WIDTH;
        /// <summary>
        /// ��Ƭ���
        /// </summary>
        public string IMAGE_WIDTH {
            set { _IMAGE_WIDTH = value; }
            get { return _IMAGE_WIDTH; }
        }

        private string _IMAGE_HEIGHT;
        /// <summary>
        /// ��Ƭ�߶�
        /// </summary>
        public string IMAGE_HEIGHT {
            set { _IMAGE_HEIGHT = value; }
            get { return _IMAGE_HEIGHT; }
        }

        private string _DATA_FICAL_LENGTH;
        /// <summary>
        /// ����
        /// </summary>
        public string DATA_FICAL_LENGTH {
            set { _DATA_FICAL_LENGTH = value; }
            get { return _DATA_FICAL_LENGTH; }
        }

        private string _DATA_APERTURE;
        /// <summary>
        /// ��Ȧ
        /// </summary>
        public string DATA_APERTURE {
            set { _DATA_APERTURE = value; }
            get { return _DATA_APERTURE; }
        }

        private string _DATA_APERTURE_XS;
        /// <summary>
        /// ��Ȧϵ��
        /// </summary>
        public string DATA_APERTURE_XS {
            set { _DATA_APERTURE_XS = value; }
            get { return _DATA_APERTURE_XS; }
        }

        private string _FLASH;
        /// <summary>
        /// �����
        /// </summary>
        public string FLASH {
            set { _FLASH = value; }
            get { return _FLASH; }
        }

        private string _WHITE_BALANCE;
        /// <summary>
        /// ��ƽ��
        /// </summary>
        public string WHITE_BALANCE {
            set { _WHITE_BALANCE = value; }
            get { return _WHITE_BALANCE; }
        }

        private string _ISO_SPEED_RATINGS;
        /// <summary>
        /// �й��
        /// </summary>
        public string ISO_SPEED_RATINGS {
            set { _ISO_SPEED_RATINGS = value; }
            get { return _ISO_SPEED_RATINGS; }
        }

        private string _EXPOSURE_PROGRAM;
        /// <summary>
        /// �ع����
        /// </summary>
        public string EXPOSURE_PROGRAM {
            set { _EXPOSURE_PROGRAM = value; }
            get { return _EXPOSURE_PROGRAM; }
        }

        private string _EXPOSURE_MODE;
        /// <summary>
        /// �ع�ģʽ
        /// </summary>
        public string EXPOSURE_MODE {
            set { _EXPOSURE_MODE = value; }
            get { return _EXPOSURE_MODE; }
        }

        private string _DATA_EXPOSURE_TIME;
        /// <summary>
        /// �ع�ʱ��
        /// </summary>
        public string DATA_EXPOSURE_TIME {
            set { _DATA_EXPOSURE_TIME = value; }
            get { return _DATA_EXPOSURE_TIME; }
        }

        private string _QUALITY;
        /// <summary>
        /// ������
        /// </summary>
        public string QUALITY {
            set { _QUALITY = value; }
            get { return _QUALITY; }
        }

        private string _CONTRAST;
        /// <summary>
        /// �Աȶ�
        /// </summary>
        public string CONTRAST {
            set { _CONTRAST = value; }
            get { return _CONTRAST; }
        }

        private string _SATURATION;
        /// <summary>
        /// ���Ͷ�
        /// </summary>
        public string SATURATION {
            set { _SATURATION = value; }
            get { return _SATURATION; }
        }

        private string _MAX_APERTURE;
        /// <summary>
        /// ����Ȧ
        /// </summary>
        public string MAX_APERTURE {
            set { _MAX_APERTURE = value; }
            get { return _MAX_APERTURE; }
        }

        /// <summary>
        /// ��ҵ�ļ�SID
        /// </summary>
        public string FROM_SID {
            set { _from_sid = value; }
            get { return _from_sid; }
        }


        public bool SIGNATURE_FLAG { set; get; }

        /// <summary>
        /// �ļ����һ��ǩ��ʱ��
        /// </summary>
        public string SIGNATURE_DT { set; get; }

        /// <summary>
        /// �ļ��Ƿ���Ҫǩ�� 1:��Ҫ0:����Ҫ  Ĭ��Ϊ1
        /// </summary>
        public bool iSignaturePdf {
            set { _isignaturepdf = value; }
            get { return _isignaturepdf; }
        }

        /// <summary>
        ///�Ƿ�ǩ������ǩ�� 1:��0:��
        /// </summary>
        public bool iSignatureWorkFlow {
            set { _isignatureworkflow = value; }
            get { return _isignatureworkflow; }
        }

    }
}

