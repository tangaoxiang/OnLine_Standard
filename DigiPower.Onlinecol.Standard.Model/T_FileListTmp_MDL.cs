using System;
namespace DigiPower.Onlinecol.Standard.Model
{
    /// <summary>
    /// 实体类T_FileListTmp_MDL 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class T_FileListTmp_MDL
    {
        public T_FileListTmp_MDL()
        { }
        #region Model
        private int _recid;
        private int _pid;
        private string _archive_form_no;
        private int _defaultcompanytype;
        private string _bh;
        private string _title;
        private int? _orderindex;
        private string _pym;
        private bool _mustsubmitflag;
        private bool _isvisible;
        private bool _alonepack;
        private bool _isfolder;
        private string _js;
        private string _sg;
        private string _sj;
        private string _jl;
        private string _filetype;

        private string _FileFrom;
        private string _ForeignNo;

        /// <summary>
        /// 
        /// </summary>
        public int recid
        {
            set { _recid = value; }
            get { return _recid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PID
        {
            set { _pid = value; }
            get { return _pid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string archive_form_no
        {
            set { _archive_form_no = value; }
            get { return _archive_form_no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int DefaultCompanyType
        {
            set { _defaultcompanytype = value; }
            get { return _defaultcompanytype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bh
        {
            set { _bh = value; }
            get { return _bh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? OrderIndex
        {
            set { _orderindex = value; }
            get { return _orderindex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pym
        {
            set { _pym = value; }
            get { return _pym; }
        }
        /// <summary>
        /// 是否必交
        /// </summary>
        public bool MustSubmitFlag
        {
            set { _mustsubmitflag = value; }
            get { return _mustsubmitflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsVisible
        {
            set { _isvisible = value; }
            get { return _isvisible; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool AlonePack
        {
            set { _alonepack = value; }
            get { return _alonepack; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsFolder
        {
            set { _isfolder = value; }
            get { return _isfolder; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JS
        {
            set { _js = value; }
            get { return _js; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SG
        {
            set { _sg = value; }
            get { return _sg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SJ
        {
            set { _sj = value; }
            get { return _sj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JL
        {
            set { _jl = value; }
            get { return _jl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FileType
        {
            set { _filetype = value; }
            get { return _filetype; }
        }


        /// <summary>
        /// 外部系统跟在线系统归档目录管关联的唯一编号
        /// </summary>
        public string ForeignNo
        {
            set { _ForeignNo = value; }
            get { return _ForeignNo; }
        }

        /// <summary>
        ///   文件来源 比如:建设,规划部门,国土部门等
        /// </summary>
        public string FileFrom
        {
            set { _FileFrom = value; }
            get { return _FileFrom; }
        }

        #endregion Model

    }
}

