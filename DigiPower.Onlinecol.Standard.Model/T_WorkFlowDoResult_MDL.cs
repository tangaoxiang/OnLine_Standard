using System;
namespace DigiPower.Onlinecol.Standard.Model
{
    /// <summary>
    /// 实体类T_WorkFlowDoResult_MDL 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class T_WorkFlowDoResult_MDL
    {
        public T_WorkFlowDoResult_MDL()
        { }
        #region Model
        private int _workflowdoresultid;
        private int _workflowdefineid;
        private int? _douserid;
        private DateTime? _dodatetime;
        private string _doresult;
        private string _doremark;
        private string _docellpath;

        private int? _workflowid;
        private int? _archiveid;
        private int? _singleprojectid;
        private int? _filelistid;

        /// <summary>
        /// 
        /// </summary>
        public int WorkFlowDoResultID
        {
            set { _workflowdoresultid = value; }
            get { return _workflowdoresultid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int WorkFlowDefineID
        {
            set { _workflowdefineid = value; }
            get { return _workflowdefineid; }
        }
        /// <summary>
        ///  审核人
        /// </summary>
        public int? DoUserID
        {
            set { _douserid = value; }
            get { return _douserid; }
        }
        /// <summary>
        ///  审核时间
        /// </summary>
        public DateTime? DoDateTime
        {
            set { _dodatetime = value; }
            get { return _dodatetime; }
        }
        /// <summary>
        ///   审核结果 1:审核通过 0:未通过 
        /// </summary>
        public string DoResult
        {
            set { _doresult = value; }
            get { return _doresult; }
        }
        /// <summary>
        ///  审核说明
        /// </summary>
        public string DoRemark
        {
            set { _doremark = value; }
            get { return _doremark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DoCellPath
        {
            set { _docellpath = value; }
            get { return _docellpath; }
        }
        #endregion Model

        /// <summary>
        ///流程ID 
        /// </summary>
        public int? WorkFlowID
        {
            set { _workflowid = value; }
            get { return _workflowid; }
        }
        /// <summary>
        ///  案卷ID
        /// </summary>
        public int? ArchiveID
        {
            set { _archiveid = value; }
            get { return _archiveid; }
        }
        /// <summary>
        ///   工程ID
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
    }
}

