using System;
namespace DigiPower.Onlinecol.Standard.Model
{
	/// <summary>
	/// 实体类T_CanDefineType_MDL 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class T_CanDefineType_MDL
	{
		public T_CanDefineType_MDL()
		{}
		#region Model
		private int _candefinetypeid;
		private string _area_code;
		private int _mediatypeid;
		private int _definetypeid;
		private int _fielddefineid;
		private bool _enable;
		/// <summary>
		/// 
		/// </summary>
		public int CanDefineTypeID
		{
			set{ _candefinetypeid=value;}
			get{return _candefinetypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Area_Code
		{
			set{ _area_code=value;}
			get{return _area_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int MediaTypeID
		{
			set{ _mediatypeid=value;}
			get{return _mediatypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int DefineTypeID
		{
			set{ _definetypeid=value;}
			get{return _definetypeid;}
		}
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
		public bool Enable
		{
			set{ _enable=value;}
			get{return _enable;}
		}
		#endregion Model

	}
}

