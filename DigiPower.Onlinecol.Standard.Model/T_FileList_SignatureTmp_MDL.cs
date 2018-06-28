using System;
namespace DigiPower.Onlinecol.Standard.Model
{
    /// <summary>
    /// T_FileList_SignatureTmp:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class T_FileList_SignatureTmp_MDL
    {
        public T_FileList_SignatureTmp_MDL()
        { }
        #region Model
        private int? _sid;
        private int? _filelistid;
        private string _signaturetype;
        private int? _orderindex;
        private int? _signaturecount;
        /// <summary>
        ///  主键
        /// </summary>
        public int? SID
        {
            set { _sid = value; }
            get { return _sid; }
        }
        /// <summary>
        ///  文件SID
        /// </summary>
        public int? FileListID
        {
            set { _filelistid = value; }
            get { return _filelistid; }
        }
        /// <summary>
        /// 签章类型
        /// </summary>
        public string SignatureType
        {
            set { _signaturetype = value; }
            get { return _signaturetype; }
        }
        /// <summary>
        ///  排列顺序
        /// </summary>
        public int? OrderIndex
        {
            set { _orderindex = value; }
            get { return _orderindex; }
        }
        /// <summary>
        /// 签章次数
        /// </summary>
        public int? SignatureCount
        {
            set { _signaturecount = value; }
            get { return _signaturecount; }
        }
        #endregion Model

    }
}

