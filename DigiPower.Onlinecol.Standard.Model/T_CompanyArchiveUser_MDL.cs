using System;
namespace DigiPower.Onlinecol.Standard.Model
{
	/// <summary>
	/// 实体类T_CompanyArchiveUser_MDL 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class T_CompanyArchiveUser_MDL
	{
		public T_CompanyArchiveUser_MDL()
		{}
		#region Model
		private int _companyarchiveuserid;
		private int? _companyid;
		private string _archiveusercode;
		private string _username;
		private string _sex;
		private DateTime? _birthday;
		private string _educate;
		private string _tel;
		private string _email;
		private string _qq;
		private int? _traincount;
		private DateTime? _regdate;
		private bool _regflag;
		/// <summary>
		/// 
		/// </summary>
		public int CompanyArchiveUserID
		{
			set{ _companyarchiveuserid=value;}
			get{return _companyarchiveuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CompanyID
		{
			set{ _companyid=value;}
			get{return _companyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ArchiveUserCode
		{
			set{ _archiveusercode=value;}
			get{return _archiveusercode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Birthday
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Educate
		{
			set{ _educate=value;}
			get{return _educate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string QQ
		{
			set{ _qq=value;}
			get{return _qq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TrainCount
		{
			set{ _traincount=value;}
			get{return _traincount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? RegDate
		{
			set{ _regdate=value;}
			get{return _regdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool RegFlag
		{
			set{ _regflag=value;}
			get{return _regflag;}
		}
		#endregion Model

	}
}

