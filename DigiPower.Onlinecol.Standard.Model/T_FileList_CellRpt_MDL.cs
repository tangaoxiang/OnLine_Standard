using System;
namespace DigiPower.Onlinecol.Standard.Model
{
	/// <summary>
	/// 实体类T_FileList_CellRpt_MDL 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class T_FileList_CellRpt_MDL
	{
		public T_FileList_CellRpt_MDL()
		{}
		#region Model
		private int _filelist_cellrptid;
		private int? _filelistid;
		private int? _recid;
		private string _title;
		private string _cellfilepath;
		private int? _orderindex;
		/// <summary>
		/// 
		/// </summary>
		public int FileList_CellRptID
		{
			set{ _filelist_cellrptid=value;}
			get{return _filelist_cellrptid;}
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
		public int? recID
		{
			set{ _recid=value;}
			get{return _recid;}
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
		public string CellFilePath
		{
			set{ _cellfilepath=value;}
			get{return _cellfilepath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OrderIndex
		{
			set{ _orderindex=value;}
			get{return _orderindex;}
		}
		#endregion Model

	}
}

