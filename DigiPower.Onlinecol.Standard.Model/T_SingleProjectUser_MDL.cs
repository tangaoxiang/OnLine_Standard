using System;
namespace DigiPower.Onlinecol.Standard.Model
{
	/// <summary>
	/// ʵ����T_SingleProjectUser_MDL ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class T_SingleProjectUser_MDL
	{
		public T_SingleProjectUser_MDL()
		{}
		#region Model
		private int _singleprojectuserid;
		private int _singleprojectid;
		private int? _roleid;
		private int? _userid;
		private DateTime _createdate;
		/// <summary>
		/// 
		/// </summary>
		public int SingleProjectUserID
		{
			set{ _singleprojectuserid=value;}
			get{return _singleprojectuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SingleProjectID
		{
			set{ _singleprojectid=value;}
			get{return _singleprojectid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RoleID
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

	}
}

