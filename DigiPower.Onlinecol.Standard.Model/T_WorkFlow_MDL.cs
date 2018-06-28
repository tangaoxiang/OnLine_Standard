using System;
namespace DigiPower.Onlinecol.Standard.Model
{
    /// <summary>
    /// ʵ����T_WorkFlow_MDL ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class T_WorkFlow_MDL
    {
        public T_WorkFlow_MDL()
        { }
        #region Model
        private int _workflowid;
        private string _workflowcode;
        private string _workflowname;
        private int? _orderindex;
        private bool _del;
        private int? _pid;
        private int? _roleid;
        private int? _userid;
        private bool _useforsuperadmin;
        private bool _useforarchive;
        private bool _useforcompanyleader;
        private bool _useforcompany;
        private bool _useforall;
        private string _submiturl;
        private string _doresulturl;
        private string _btncode;
        private int? _companyid;
        private string _descriptiontoarchive;
        private string _descriptiontocompany;
        private string _rightlistid;


        /// <summary>
        /// 
        /// </summary>
        public int WorkFlowID
        {
            set { _workflowid = value; }
            get { return _workflowid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WorkFlowCode
        {
            set { _workflowcode = value; }
            get { return _workflowcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WorkFlowName
        {
            set { _workflowname = value; }
            get { return _workflowname; }
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
        public bool Del
        {
            set { _del = value; }
            get { return _del; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PID
        {
            set { _pid = value; }
            get { return _pid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? RoleID
        {
            set { _roleid = value; }
            get { return _roleid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool UseForSuperAdmin
        {
            set { _useforsuperadmin = value; }
            get { return _useforsuperadmin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool UseForArchive
        {
            set { _useforarchive = value; }
            get { return _useforarchive; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool UseForCompanyLeader
        {
            set { _useforcompanyleader = value; }
            get { return _useforcompanyleader; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool UseForCompany
        {
            set { _useforcompany = value; }
            get { return _useforcompany; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool UseForAll
        {
            set { _useforall = value; }
            get { return _useforall; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SubmitURL
        {
            set { _submiturl = value; }
            get { return _submiturl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DoResultURL
        {
            set { _doresulturl = value; }
            get { return _doresulturl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BtnCode
        {
            set { _btncode = value; }
            get { return _btncode; }
        }


        /// <summary>
        ///  �������������ݹ�˾ID
        /// </summary>
        public int? CompanyID
        {
            set { _companyid = value; }
            get { return _companyid; }
        }
        /// <summary>
        /// ���̽ڵ�˵-��Ե�����
        /// </summary>
        public string DescriptionToArchive
        {
            set { _descriptiontoarchive = value; }
            get { return _descriptiontoarchive; }
        }
        /// <summary>
        /// ���̽ڵ�˵-��Խ��赥λ��
        /// </summary>
        public string DescriptionToCompany
        {
            set { _descriptiontocompany = value; }
            get { return _descriptiontocompany; }
        }
        /// <summary>
        /// Ȩ�ް�ť
        /// </summary>
        public string RightListID
        {
            set { _rightlistid = value; }
            get { return _rightlistid; }
        }

        #endregion Model

    }
}

