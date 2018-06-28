using System;
namespace DigiPower.Onlinecol.Standard.Model
{
    /// <summary>
    /// 实体类T_EFile_ConvertLog_MDL 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class T_EFile_ConvertLog_MDL
    {
        public T_EFile_ConvertLog_MDL()
        { }
        #region Model
        private int _logid;
        private int? _singleprojectid;
        private int? _filelistid;
        private int? _efileid;
        private string _efilestartpath;
        private string _filename;
        private string _description;
        private DateTime? _createdate;
        /// <summary>
        /// 
        /// </summary>
        public int LogID
        {
            set { _logid = value; }
            get { return _logid; }
        }
        /// <summary>
        /// 工程ID
        /// </summary>
        public int? SingleProjectID
        {
            set { _singleprojectid = value; }
            get { return _singleprojectid; }
        }
        /// <summary>
        /// 文件ID
        /// </summary>
        public int? FileListID
        {
            set { _filelistid = value; }
            get { return _filelistid; }
        }
        /// <summary>
        ///  电子文件ID
        /// </summary>
        public int? EFileID
        {
            set { _efileid = value; }
            get { return _efileid; }
        }
        /// <summary>
        /// 电子文件路径
        /// </summary>
        public string EFileStartPath
        {
            set { _efilestartpath = value; }
            get { return _efilestartpath; }
        }
        /// <summary>
        /// 电子文件名称
        /// </summary>
        public string FileName
        {
            set { _filename = value; }
            get { return _filename; }
        }
        /// <summary>
        /// 说明
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 出错日期
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        #endregion Model

    }
}

