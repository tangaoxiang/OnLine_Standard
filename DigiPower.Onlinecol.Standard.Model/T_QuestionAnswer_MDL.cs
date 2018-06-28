using System;
namespace DigiPower.Onlinecol.Standard.Model
{
	/// <summary>
	/// 实体类T_QuestionAnswer_MDL 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class T_QuestionAnswer_MDL
	{
		public T_QuestionAnswer_MDL()
		{}
		#region Model
		private int _answerid;
		private int _questionid;
		private string _description;
		private int? _answeruserid;
		private string _answerusername;
		private DateTime? _answertime;
		private string _attachname;
		private string _attachpath;
		private bool _readflag;
		/// <summary>
		/// 
		/// </summary>
		public int AnswerID
		{
			set{ _answerid=value;}
			get{return _answerid;}
		}
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
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AnswerUserID
		{
			set{ _answeruserid=value;}
			get{return _answeruserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AnswerUserName
		{
			set{ _answerusername=value;}
			get{return _answerusername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? AnswerTime
		{
			set{ _answertime=value;}
			get{return _answertime;}
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

