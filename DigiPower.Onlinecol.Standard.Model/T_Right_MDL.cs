using System;
namespace DigiPower.Onlinecol.Standard.Model
{
	/// <summary>
	/// ʵ����T_Right_MDL ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class T_Right_MDL
	{
		public T_Right_MDL()
		{}
		#region Model
		private int _rightid;
		private string _rightcode;
		private string _rightname;
		/// <summary>
		/// 
		/// </summary>
		public int RightID
		{
			set{ _rightid=value;}
			get{return _rightid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RightCode
		{
			set{ _rightcode=value;}
			get{return _rightcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RightName
		{
			set{ _rightname=value;}
			get{return _rightname;}
		}
		#endregion Model

	}
}

