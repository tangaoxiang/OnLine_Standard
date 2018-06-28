using System;
namespace DigiPower.Onlinecol.Standard.Model
{
	/// <summary>
	/// 实体类T_FieldDefine_MDL 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class T_FieldDefine_MDL
	{
		public T_FieldDefine_MDL()
		{}
		#region Model
		private int _fielddefineid;
		private string _tablename;
		private string _fieldname;
		private string _showname;
		private int? _startlocation;
		private int? _endlocation;
		private bool _isserial;
		/// <summary>
		/// 
		/// </summary>
		public int FieldDefineID
		{
			set{ _fielddefineid=value;}
			get{return _fielddefineid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TableName
		{
			set{ _tablename=value;}
			get{return _tablename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FieldName
		{
			set{ _fieldname=value;}
			get{return _fieldname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ShowName
		{
			set{ _showname=value;}
			get{return _showname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? StartLocation
		{
			set{ _startlocation=value;}
			get{return _startlocation;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? EndLocation
		{
			set{ _endlocation=value;}
			get{return _endlocation;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsSerial
		{
			set{ _isserial=value;}
			get{return _isserial;}
		}
		#endregion Model

	}
}

