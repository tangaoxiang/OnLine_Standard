using System;
namespace DigiPower.Onlinecol.Standard.Model
{
	/// <summary>
	/// ʵ����T_SingleProjectCompany_MDL ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class T_SingleProjectCompany_MDL
	{
		public T_SingleProjectCompany_MDL()
		{}
		#region Model
		private int _singleprojectcompanyid;
		private int? _singleprojectid;
		private int? _companyid;
		/// <summary>
		/// 
		/// </summary>
		public int SingleProjectCompanyID
		{
			set{ _singleprojectcompanyid=value;}
			get{return _singleprojectcompanyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SingleProjectID
		{
			set{ _singleprojectid=value;}
			get{return _singleprojectid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CompanyID
		{
			set{ _companyid=value;}
			get{return _companyid;}
		}
		#endregion Model

	}
}

