using System;
namespace DigiPower.Onlinecol.Standard.Model
{
	/// <summary>
	/// ʵ����T_FileListTmp_CellRptTmp_MDL ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class T_FileListTmp_CellRptTmp_MDL
	{
		public T_FileListTmp_CellRptTmp_MDL()
		{}
		#region Model
		private int _cellreportid;
		private int? _recid;
		private string _title;
		private string _cellfilepath;
		private int? _orderindex;
		/// <summary>
		/// 
		/// </summary>
		public int CellReportID
		{
			set{ _cellreportid=value;}
			get{return _cellreportid;}
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

