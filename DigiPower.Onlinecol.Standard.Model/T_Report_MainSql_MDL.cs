using System;
namespace DigiPower.Onlinecol.Standard.Model
{
	/// <summary>
	/// 实体类T_Report_MainSql_MDL 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class T_Report_MainSql_MDL
	{
		public T_Report_MainSql_MDL()
		{}
		#region Model
		private int _reportmainsqlid;
		private int? _reportid;
		private string _mainsql;
		private int? _orderid;
		private bool _isvalid;
		private string _othername;
		/// <summary>
		/// 
		/// </summary>
		public int ReportMainSqlID
		{
			set{ _reportmainsqlid=value;}
			get{return _reportmainsqlid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ReportID
		{
			set{ _reportid=value;}
			get{return _reportid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MainSql
		{
			set{ _mainsql=value;}
			get{return _mainsql;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OrderId
		{
			set{ _orderid=value;}
			get{return _orderid;}
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
		public string OtherName
		{
			set{ _othername=value;}
			get{return _othername;}
		}
		#endregion Model

	}
}

