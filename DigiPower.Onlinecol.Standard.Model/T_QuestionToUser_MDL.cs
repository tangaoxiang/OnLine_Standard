using System;
namespace DigiPower.Onlinecol.Standard.Model
{
	/// <summary>
	/// ʵ����T_QuestionToUser_MDL ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class T_QuestionToUser_MDL
	{
		public T_QuestionToUser_MDL()
		{}
		#region Model
		private int _questiontouserid;
		private int? _questionid;
		private int? _touserid;
		/// <summary>
		/// 
		/// </summary>
		public int QuestionToUserID
		{
			set{ _questiontouserid=value;}
			get{return _questiontouserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? QuestionID
		{
			set{ _questionid=value;}
			get{return _questionid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ToUserID
		{
			set{ _touserid=value;}
			get{return _touserid;}
		}
		#endregion Model

	}
}

