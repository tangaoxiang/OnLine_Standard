using System;
namespace DigiPower.Onlinecol.Standard.Model
{
    /// <summary>
    /// ʵ����T_ReadyCheckBook_MDL ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class T_ReadyCheckBook_MDL
    {
        public T_ReadyCheckBook_MDL()
        { }
        #region Model
        private int _readycheckbookid;
        private int? _singleprojectid;
        private string _codetype;
        private string _readycheckbookcode;
        private DateTime? _begindate;
        private DateTime? _enddate;
        private int? _createuserid;
        private DateTime? _createtime;
        private int? _TOTAL_SCROLL;
        private int? _CHARACTER_SCROLL;
        private int? _PIC_SCROLL;
        private int? _PIC_PAGE_COUNT;
        private int? _PHOTO_COUNT;
        private int? _RADIO_COUNT;
        private string _OTHER_MATERIAL;
        private int? _Directory_SCROLL;
        private int? _Directory_PAGE_COUNT;


        private string _zljddw;
        private string _ArchiveUserName;
        private string _ArchiveUser_Tel;
        private string _jsdwfzr_Name;
        private string _jsdwfzr_Tel;
        private string _cscd;

        

        /// <summary>
        /// 
        /// </summary>
        public int ReadyCheckBookID
        {
            set { _readycheckbookid = value; }
            get { return _readycheckbookid; }
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
        public string CodeType
        {
            set { _codetype = value; }
            get { return _codetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ReadyCheckBookCode
        {
            set { _readycheckbookcode = value; }
            get { return _readycheckbookcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? BeginDate
        {
            set { _begindate = value; }
            get { return _begindate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? EndDate
        {
            set { _enddate = value; }
            get { return _enddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CreateUserID
        {
            set { _createuserid = value; }
            get { return _createuserid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }

        /// <summary>
        /// �ܾ���
        /// </summary>
        public int? TOTAL_SCROLL
        {
            get { return this._TOTAL_SCROLL; }
            set { this._TOTAL_SCROLL = value; }
        }

        /// <summary>
        /// ���־���
        /// </summary>
        public int? CHARACTER_SCROLL
        {
            get { return this._CHARACTER_SCROLL; }
            set { this._CHARACTER_SCROLL = value; }
        }
        /// <summary>
        /// ͼֽ����
        /// </summary>
        public int? PIC_SCROLL
        {
            get { return this._PIC_SCROLL; }
            set { this._PIC_SCROLL = value; }
        }
        /// <summary>
        /// ͼֽҳ��
        /// </summary>
        public int? PIC_PAGE_COUNT
        {
            get { return this._PIC_PAGE_COUNT; }
            set { this._PIC_PAGE_COUNT = value; }
        }
        /// <summary>
        /// ��Ƭ����
        /// </summary>
        public int? PHOTO_COUNT
        {
            get { return this._PHOTO_COUNT; }
            set { this._PHOTO_COUNT = value; }
        }
        /// <summary>
        /// ¼�������
        /// </summary>
        public int? RADIO_COUNT
        {
            get { return this._RADIO_COUNT; }
            set { this._RADIO_COUNT = value; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string OTHER_MATERIAL
        {
            get { return this._OTHER_MATERIAL; }
            set { this._OTHER_MATERIAL = value; }
        }
        /// <summary>
        /// ����Ŀ¼����
        /// </summary>
        public int? Directory_SCROLL
        {
            get { return this._Directory_SCROLL; }
            set { this._Directory_SCROLL = value; }
        }
        /// <summary>
        /// ����Ŀ¼ҳ��
        /// </summary>
        public int? Directory_PAGE_COUNT
        {
            get { return this._Directory_PAGE_COUNT; }
            set { this._Directory_PAGE_COUNT = value; }
        }
        /// <summary>
        /// �����ල��λ
        /// </summary>
        public string zljddw
        {
            get { return this._zljddw; }
            set { this._zljddw = value; }
        }
        /// <summary>
        /// ������ϵ��
        /// </summary>
        public string ArchiveUserName
        {
            get { return this._ArchiveUserName; }
            set { this._ArchiveUserName = value; }
        }
        /// <summary>
        /// ������ϵ�˵绰
        /// </summary>
        public string ArchiveUser_Tel
        {
            get { return this._ArchiveUser_Tel; }
            set { this._ArchiveUser_Tel = value; }
        }
        /// <summary>
        /// ���赥λ������
        /// </summary>
        public string jsdwfzr_Name
        {
            get { return this._jsdwfzr_Name; }
            set { this._jsdwfzr_Name = value; }
        }
        /// <summary>
        /// ���赥λ�����˵绰
        /// </summary>
        public string jsdwfzr_Tel
        {
            get { return this._jsdwfzr_Tel; }
            set { this._jsdwfzr_Tel = value; }
        }
        public string cscd
        {
            get { return this._cscd; }
            set { this._cscd = value; }
        }
        #endregion Model

    }
}

