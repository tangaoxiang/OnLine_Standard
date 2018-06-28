using System;
namespace DigiPower.Onlinecol.Standard.Model
{
	/// <summary>
	/// ʵ����T_Area_MDL ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class T_Area_MDL
	{
		public T_Area_MDL()
		{}
		#region Model
		private int _areaid;
		private string _area_code;
		private string _area_name;
		private int _pid;
		private int? _orderindex;
		/// <summary>
		/// 
		/// </summary>
		public int AreaID
		{
			set{ _areaid=value;}
			get{return _areaid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string area_code
		{
			set{ _area_code=value;}
			get{return _area_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string area_name
		{
			set{ _area_name=value;}
			get{return _area_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int PID
		{
			set{ _pid=value;}
			get{return _pid;}
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

