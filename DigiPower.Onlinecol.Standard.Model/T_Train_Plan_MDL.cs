using System;
namespace DigiPower.Onlinecol.Standard.Model
{
	/// <summary>
	/// 实体类T_Train_Plan_MDL 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class T_Train_Plan_MDL
	{
		public T_Train_Plan_MDL()
		{}
		#region Model
		private int _trainplanid;
		private string _subject;
		private string _teacher;
		private DateTime? _plandate;
		private DateTime? _finishdate;
		private string _planusername;
		/// <summary>
		/// 
		/// </summary>
		public int TrainPlanID
		{
			set{ _trainplanid=value;}
			get{return _trainplanid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Subject
		{
			set{ _subject=value;}
			get{return _subject;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Teacher
		{
			set{ _teacher=value;}
			get{return _teacher;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? PlanDate
		{
			set{ _plandate=value;}
			get{return _plandate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? FinishDate
		{
			set{ _finishdate=value;}
			get{return _finishdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PlanUserName
		{
			set{ _planusername=value;}
			get{return _planusername;}
		}
		#endregion Model

	}
}

