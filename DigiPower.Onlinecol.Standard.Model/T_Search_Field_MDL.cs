using System;
namespace DigiPower.Onlinecol.Standard.Model
{
    /// <summary>
    /// 实体类T_Search_Field_MDL 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class T_Search_Field_MDL
    {
        public T_Search_Field_MDL()
        { }
        #region Model
        private int _search_field_id;
        private string _reportcode;
        private string _tablename;
        private string _tablenamecn;
        private string _labelname;
        private string _fieldname;
        private int? _line;
        private int? _orderid;
        private int? _isdictionary;
        /// <summary>
        /// 
        /// </summary>
        public int Search_Field_ID
        {
            set { _search_field_id = value; }
            get { return _search_field_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ReportCode
        {
            set { _reportcode = value; }
            get { return _reportcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TableName
        {
            set { _tablename = value; }
            get { return _tablename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TableNameCN
        {
            set { _tablenamecn = value; }
            get { return _tablenamecn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LabelName
        {
            set { _labelname = value; }
            get { return _labelname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FieldName
        {
            set { _fieldname = value; }
            get { return _fieldname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Line
        {
            set { _line = value; }
            get { return _line; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? OrderId
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsDictionary
        {
            set { _isdictionary = value; }
            get { return _isdictionary; }
        }
        #endregion Model

    }
}

