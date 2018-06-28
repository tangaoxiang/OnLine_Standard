using System;
namespace DigiPower.Onlinecol.Standard.Model {
    /// <summary>
    /// ʵ����T_Role_MDL ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class T_Role_MDL {
        public T_Role_MDL() { }
        #region Model
        private int _roleid;
        private int _companyid;
        private string _rolename;
        private string _description;
        private int? _forcompanytype;
        private bool _del;
        private string _rolecode;
        private string _roletype;

        /// <summary>
        /// 
        /// </summary>
        public int RoleID {
            set { _roleid = value; }
            get { return _roleid; }
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
        public string RoleName {
            set { _rolename = value; }
            get { return _rolename; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Description {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 0����ģ�壬1���赥λ��2ʩ����λ
        /// </summary>
        public int? ForCompanyType {
            set { _forcompanytype = value; }
            get { return _forcompanytype; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Del {
            set { _del = value; }
            get { return _del; }
        }

        /// <summary>
        /// ��ɫ����
        /// </summary>
        public string RoleCode {
            set { _rolecode = value; }
            get { return _rolecode; }
        }

        /// <summary>
        /// ��ɫ����
        /// </summary>
        public string RoleType {
            set { _roletype = value; }
            get { return _roletype; }
        }


        #endregion Model

    }
}
