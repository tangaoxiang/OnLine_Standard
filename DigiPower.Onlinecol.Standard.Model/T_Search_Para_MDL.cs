using System;
namespace DigiPower.Onlinecol.Standard.Model
{
	/// <summary>
	/// 实体类T_Search_Para_MDL 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class T_Search_Para_MDL
	{
		public T_Search_Para_MDL()
		{}
		#region Model
		private int _search_para_id;
		private int? _search_field_id;
		private string _paratype;
		private string _paratypecn;
		private int? _controlwidth;
		private string _comparetype;
		private string _comparetypecn;
		private string _defaultvalue;
		private string _sourcesql;
		private int? _orderid;
		/// <summary>
		/// 
		/// </summary>
		public int Search_Para_ID
		{
			set{ _search_para_id=value;}
			get{return _search_para_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Search_Field_ID
		{
			set{ _search_field_id=value;}
			get{return _search_field_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ParaType
		{
			set{ _paratype=value;}
			get{return _paratype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ParaTypeCN
		{
			set{ _paratypecn=value;}
			get{return _paratypecn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ControlWidth
		{
			set{ _controlwidth=value;}
			get{return _controlwidth;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CompareType
		{
			set{ _comparetype=value;}
			get{return _comparetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CompareTypeCN
		{
			set{ _comparetypecn=value;}
			get{return _comparetypecn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DefaultValue
		{
			set{ _defaultvalue=value;}
			get{return _defaultvalue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SourceSql
		{
			set{ _sourcesql=value;}
			get{return _sourcesql;}
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

