using System;
namespace DigiPower.Onlinecol.Standard.Model
{
	/// <summary>
	/// 实体类T_Report_MDL 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class T_Report_MDL
	{
		public T_Report_MDL()
		{}
		#region Model
		private int _reportid;
		private int? _reporttypeid;
		private string _reportcode;
		private string _reportname;
		private string _reportfilepath;
		private bool _isvalid;
		private int? _orderid;
		/// <summary>
		/// 
		/// </summary>
		public int ReportID
		{
			set{ _reportid=value;}
			get{return _reportid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ReportTypeID
		{
			set{ _reporttypeid=value;}
			get{return _reporttypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReportCode
		{
			set{ _reportcode=value;}
			get{return _reportcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReportName
		{
			set{ _reportname=value;}
			get{return _reportname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReportFilePath
		{
			set{ _reportfilepath=value;}
			get{return _reportfilepath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsValid
		{
			set{ _isvalid=value;}
			get{return _isvalid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OrderId
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		#endregion Model

	}
}

