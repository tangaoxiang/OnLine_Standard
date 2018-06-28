using System;
namespace DigiPower.Onlinecol.Standard.Model {
    /// <summary>
    /// 实体类T_WorkFlowDefine_MDL 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class T_WorkFlowDefine_MDL {
        public T_WorkFlowDefine_MDL() { }
        #region Model
        private int _workflowdefineid;
        private int _singleprojectid;
        private int _workflowid;
        private string _workflowname;
        private string _description;
        private int? _orderindex;
        private bool _del;
        private string _pid;
        private int? _roleid;
        private int? _userid;
        private DateTime? _createdate;
        private int? _dostatus;
        private bool _isrollback;
        private bool _useforsuperadmin;
        private bool _useforarchive;
        private bool _useforcompanyleader;
        private bool _useforcompany;
        private bool _useforall;
        private int _submitstatus;
        private int? _submituserid;
        private DateTime? _submitdatetime;
        private string _submitcellpath;
        private int? _recvuserid;
        private DateTime? _recvdatetime;
        private string _recvcellpath;
        private int? _companyid;
        private string _descriptiontoarchive;
        private string _descriptiontocompany;
        private int? _rollbackcount;

        /// <summary>
        /// 
        /// </summary>
        public int WorkFlowDefineID {
            set { _workflowdefineid = value; }
            get { return _workflowdefineid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SingleProjectID {
            set { _singleprojectid = value; }
            get { return _singleprojectid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int WorkFlowID {
            set { _workflowid = value; }
            get { return _workflowid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WorkFlowName {
            set { _workflowname = value; }
            get { return _workflowname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Description {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? OrderIndex {
            set { _orderindex = value; }
            get { return _orderindex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Del {
            set { _del = value; }
            get { return _del; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PID {
            set { _pid = value; }
            get { return _pid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? RoleID {
            set { _roleid = value; }
            get { return _roleid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? UserID {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateDate {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 0：未开始，1：进行中，9：已完成
        /// </summary>
        public int? DoStatus {
            set { _dostatus = value; }
            get { return _dostatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsRollBack {
            set { _isrollback = value; }
            get { return _isrollback; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool UseForSuperAdmin {
            set { _useforsuperadmin = value; }
            get { return _useforsuperadmin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool UseForArchive {
            set { _useforarchive = value; }
            get { return _useforarchive; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool UseForCompanyLeader {
            set { _useforcompanyleader = value; }
            get { return _useforcompanyleader; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool UseForCompany {
            set { _useforcompany = value; }
            get { return _useforcompany; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool UseForAll {
            set { _useforall = value; }
            get { return _useforall; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SubmitStatus {
            set { _submitstatus = value; }
            get { return _submitstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SubmitUserID {
            set { _submituserid = value; }
            get { return _submituserid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SubmitDateTime {
            set { _submitdatetime = value; }
            get { return _submitdatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SubmitCellPath {
            set { _submitcellpath = value; }
            get { return _submitcellpath; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? RecvUserID {
            set { _recvuserid = value; }
            get { return _recvuserid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? RecvDateTime {
            set { _recvdatetime = value; }
            get { return _recvdatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RecvCellPath {
            set { _recvcellpath = value; }
            get { return _recvcellpath; }
        }
        /// <summary>
        ///  流程所属档案馆公司ID
        /// </summary>
        public int? CompanyID {
            set { _companyid = value; }
            get { return _companyid; }
        }
        /// <summary>
        /// 流程节点说-针对档案馆
        /// </summary>
        public string DescriptionToArchive {
            set { _descriptiontoarchive = value; }
            get { return _descriptiontoarchive; }
        }
        /// <summary>
        /// 流程节点说-针对建设单位等
        /// </summary>
        public string DescriptionToCompany {
            set { _descriptiontocompany = value; }
            get { return _descriptiontocompany; }
        }

        /// <summary>
        /// 工程在某个节点退回的次数
        /// </summary>
        public int? RollBackCount {
            set { _rollbackcount = value; }
            get { return _rollbackcount; }
        }
        #endregion Model

    }
}

