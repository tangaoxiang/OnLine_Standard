using System;
namespace DigiPower.Onlinecol.Standard.Model
{
    /// <summary>
    /// 实体类T_QuestionType_MDL 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class T_QuestionType_MDL
    {
        public T_QuestionType_MDL()
        { }
        #region Model
        private int _questiontypeid;
        private string _title;
        private string _touseridlist;
        private string _tousernamelist;
        private bool _onlytomydirectionuser;
        private int? _orderindex;

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
        public int QuestionTypeID
        {
            set { _questiontypeid = value; }
            get { return _questiontypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ToUserIDList
        {
            set { _touseridlist = value; }
            get { return _touseridlist; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ToUserNameList
        {
            set { _tousernamelist = value; }
            get { return _tousernamelist; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool OnlyToMyDirectionUser
        {
            set { _onlytomydirectionuser = value; }
            get { return _onlytomydirectionuser; }
        }
        #endregion Model

    }
}

