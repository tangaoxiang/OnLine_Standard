using System;
namespace DigiPower.Onlinecol.Standard.Model
{
	/// <summary>
	/// 实体类T_Field_MDL 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class T_Field_MDL
	{
		public T_Field_MDL()
		{}
		#region Model
		private int _fieldid;
		private string _table_name;
		private string _table_chn_name;
		private string _column_name;
		private string _column_chn_name;
		private int? _column_order;
		private string _note;
		/// <summary>
		/// 
		/// </summary>
		public int FieldID
		{
			set{ _fieldid=value;}
			get{return _fieldid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string table_name
		{
			set{ _table_name=value;}
			get{return _table_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string table_chn_name
		{
			set{ _table_chn_name=value;}
			get{return _table_chn_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string column_name
		{
			set{ _column_name=value;}
			get{return _column_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string column_chn_name
		{
			set{ _column_chn_name=value;}
			get{return _column_chn_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? column_order
		{
			set{ _column_order=value;}
			get{return _column_order;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string note
		{
			set{ _note=value;}
			get{return _note;}
		}
		#endregion Model

	}
}

