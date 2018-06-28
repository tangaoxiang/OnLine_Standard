using System;
namespace DigiPower.Onlinecol.Standard.Model
{
	/// <summary>
	/// 实体类T_CellTmp_MDL 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class T_CellTmp_MDL
	{
		public T_CellTmp_MDL()
		{}
		#region Model
		private int _cellid;
		private int? _pid;
		private string _title;
		private string _filepath;
		private int? _orderindex;
		private string _jsdwexpire;
		private string _sgdwexpire;
		private string _sjdwexpire;
		private string _jldwexpire;
		private bool _needarchive;
		private string _mj;
		private bool _isvisible;
		private bool _isfolder;
		private string _mycode;
		private string _pid1;
		/// <summary>
		/// 
		/// </summary>
		public int CellID
		{
			set{ _cellid=value;}
			get{return _cellid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PID
		{
			set{ _pid=value;}
			get{return _pid;}
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
		public string FilePath
		{
			set{ _filepath=value;}
			get{return _filepath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OrderIndex
		{
			set{ _orderindex=value;}
			get{return _orderindex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JSDWExpire
		{
			set{ _jsdwexpire=value;}
			get{return _jsdwexpire;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SGDWExpire
		{
			set{ _sgdwexpire=value;}
			get{return _sgdwexpire;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SJDWExpire
		{
			set{ _sjdwexpire=value;}
			get{return _sjdwexpire;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JLDWExpire
		{
			set{ _jldwexpire=value;}
			get{return _jldwexpire;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool NeedArchive
		{
			set{ _needarchive=value;}
			get{return _needarchive;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MJ
		{
			set{ _mj=value;}
			get{return _mj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsVisible
		{
			set{ _isvisible=value;}
			get{return _isvisible;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsFolder
		{
			set{ _isfolder=value;}
			get{return _isfolder;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MyCode
		{
			set{ _mycode=value;}
			get{return _mycode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PID1
		{
			set{ _pid1=value;}
			get{return _pid1;}
		}
		#endregion Model

	}
}

