using System;
namespace DigiPower.Onlinecol.Standard.Model {
    /// <summary>
    /// T_EFile_OutSideRelated:实体类
    /// 保存跟签章文件相关的附件文件,这文件关系由外部系统提供.
    /// 本系统根据这关系,查看文件时候,可以查看相关附件
    /// </summary>
    [Serializable]
    public partial class T_EFile_OutSideRelated_MDL {
        public T_EFile_OutSideRelated_MDL() { }
        #region Model
        private int _sid;
        private string _filelistid;
        private string _fromid;
        private string _fromtype;

        /// <summary>
        /// 主键
        /// </summary>
        public int SID {
            set { _sid = value; }
            get { return _sid; }
        }

        /// <summary>
        /// 本地文件ID
        /// </summary>
        public string FileListID {
            set { _filelistid = value; }
            get { return _filelistid; }
        }

        /// <summary>
        ///  对应的外部系统文件ID
        /// </summary>
        public string FromID {
            set { _fromid = value; }
            get { return _fromid; }
        }

        /// <summary>
        ///外部系统类别 比如筑业等 
        /// </summary>
        public string FromType {
            set { _fromtype = value; }
            get { return _fromtype; }
        }
        #endregion Model

    }
}

