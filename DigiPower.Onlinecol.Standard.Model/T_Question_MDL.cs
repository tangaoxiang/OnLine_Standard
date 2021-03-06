using System;
namespace DigiPower.Onlinecol.Standard.Model
{
	/// <summary>
	/// 实体类T_Question_MDL 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class T_Question_MDL
	{
		public T_Question_MDL()
		{}
		#region Model
		private int _questionid;
		private int _singleprojectid;
        private string _questiontypecode;
		private int _filelistid;
		private string _title;
		private string _description;
		private int? _createuserid;
		private string _createusername;
		private DateTime? _createdate;
		private int? _answercount;
		private int? _clickcount;
		private string _attachname;
		private string _attachpath;
		private bool _readflag;
        private string _descriptionhtml;
        

		/// <summary>
		/// 
		/// </summary>
		public int QuestionID
		{
			set{ _questionid=value;}
			get{return _questionid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SingleProjectID
		{
			set{ _singleprojectid=value;}
			get{return _singleprojectid;}
		}
		/// <summary>
		/// 
		/// </summary>
        public string QuestionTypeCode
		{
            set { _questiontypecode = value; }
            get { return _questiontypecode; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int FileListID
		{
			set{ _filelistid=value;}
			get{return _filelistid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string DescriptionHtml
        {
            set { _descriptionhtml = value; }
            get { return _descriptionhtml; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int? CreateUserID
		{
			set{ _createuserid=value;}
			get{return _createuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CreateUserName
		{
			set{ _createusername=value;}
			get{return _createusername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AnswerCount
		{
			set{ _answercount=value;}
			get{return _answercount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ClickCount
		{
			set{ _clickcount=value;}
			get{return _clickcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AttachName
		{
			set{ _attachname=value;}
			get{return _attachname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AttachPath
		{
			set{ _attachpath=value;}
			get{return _attachpath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool ReadFlag
		{
			set{ _readflag=value;}
			get{return _readflag;}
		}
		#endregion Model

	}
}

