using System;
namespace DigiPower.Onlinecol.Standard.Model
{
	/// <summary>
	/// 实体类T_FileListDoResult_MDL 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class T_FileListDoResult_MDL
	{
		public T_FileListDoResult_MDL()
		{}
		#region Model
		private int _filelistdoresult;
		private int? _singleprojectid;
		private int? _filelistid;
		private int? _workflowid;
		private int? _douserid;
		private DateTime? _dodatetime;
		private int? _doresultid;
		private string _doresult;
		/// <summary>
		/// 
		/// </summary>
		public int FileListDoResult
		{
			set{ _filelistdoresult=value;}
			get{return _filelistdoresult;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SingleProjectID
		{
			set{ _singleprojectid=value;}
			get{return _singleprojectid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? FileListID
		{
			set{ _filelistid=value;}
			get{return _filelistid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? WorkFlowID
		{
			set{ _workflowid=value;}
			get{return _workflowid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DoUserID
		{
			set{ _douserid=value;}
			get{return _douserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DoDateTime
		{
			set{ _dodatetime=value;}
			get{return _dodatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DoResultID
		{
			set{ _doresultid=value;}
			get{return _doresultid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DoResult
		{
			set{ _doresult=value;}
			get{return _doresult;}
		}
		#endregion Model

	}
}

