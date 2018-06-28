using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
namespace DigiPower.Onlinecol.Standard.BLL
{
	/// <summary>
	/// ҵ���߼���T_QuestionType_BLL ��ժҪ˵����
	/// </summary>
	public class T_QuestionType_BLL
	{
		private readonly DigiPower.Onlinecol.Standard.DAL.T_QuestionType_DAL dal=new DigiPower.Onlinecol.Standard.DAL.T_QuestionType_DAL();
		public T_QuestionType_BLL()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int QuestionTypeID)
		{
			return dal.Exists(QuestionTypeID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(DigiPower.Onlinecol.Standard.Model.T_QuestionType_MDL model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(DigiPower.Onlinecol.Standard.Model.T_QuestionType_MDL model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int QuestionTypeID)
		{
			
			dal.Delete(QuestionTypeID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_QuestionType_MDL GetModel(int QuestionTypeID)
		{
			
			return dal.GetModel(QuestionTypeID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public DigiPower.Onlinecol.Standard.Model.T_QuestionType_MDL GetModelByCache(int QuestionTypeID)
		{
			
			string CacheKey = "T_QuestionType_MDLModel-" + QuestionTypeID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(QuestionTypeID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (DigiPower.Onlinecol.Standard.Model.T_QuestionType_MDL)objModel;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        /// <summary>
        /// ��������б� ��ҳ
        /// </summary>
        /// <returns></returns>
        public DataTable GetListPaging(string strWhere, int PageSize, int curPage, out int recCoun)
        {
            return dal.GetList(strWhere, PageSize, curPage, "QuestionTypeID", "QuestionTypeID asc", out recCoun);
        }  

		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<DigiPower.Onlinecol.Standard.Model.T_QuestionType_MDL> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<DigiPower.Onlinecol.Standard.Model.T_QuestionType_MDL> DataTableToList(DataTable dt)
		{
			List<DigiPower.Onlinecol.Standard.Model.T_QuestionType_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.T_QuestionType_MDL>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DigiPower.Onlinecol.Standard.Model.T_QuestionType_MDL model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new DigiPower.Onlinecol.Standard.Model.T_QuestionType_MDL();
					if(dt.Rows[n]["QuestionTypeID"].ToString()!="")
					{
						model.QuestionTypeID=int.Parse(dt.Rows[n]["QuestionTypeID"].ToString());
					}
					model.Title=dt.Rows[n]["Title"].ToString();
					model.ToUserIDList=dt.Rows[n]["ToUserIDList"].ToString();
					model.ToUserNameList=dt.Rows[n]["ToUserNameList"].ToString();
					if(dt.Rows[n]["OnlyToMyDirectionUser"].ToString()!="")
					{
						if((dt.Rows[n]["OnlyToMyDirectionUser"].ToString()=="1")||(dt.Rows[n]["OnlyToMyDirectionUser"].ToString().ToLower()=="true"))
						{
						model.OnlyToMyDirectionUser=true;
						}
						else
						{
							model.OnlyToMyDirectionUser=false;
						}
					}
                    if (dt.Rows[n]["OrderIndex"].ToString() != "")
                    {
                        model.OrderIndex = int.Parse(dt.Rows[n]["OrderIndex"].ToString());
                    }
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  ��Ա����
	}
}

