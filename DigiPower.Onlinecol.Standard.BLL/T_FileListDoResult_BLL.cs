using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
namespace DigiPower.Onlinecol.Standard.BLL
{
	/// <summary>
	/// ҵ���߼���T_FileListDoResult_BLL ��ժҪ˵����
	/// </summary>
	public class T_FileListDoResult_BLL
	{
        //private readonly DigiPower.Onlinecol.Standard.DAL.T_FileListDoResult_DAL dal=new DigiPower.Onlinecol.Standard.DAL.T_FileListDoResult_DAL();
        //public T_FileListDoResult_BLL()
        //{}
        //#region  ��Ա����

        ///// <summary>
        ///// �õ����ID
        ///// </summary>
        //public int GetMaxId()
        //{
        //    return dal.GetMaxId();
        //}

        ///// <summary>
        ///// �Ƿ���ڸü�¼
        ///// </summary>
        //public bool Exists(int FileListDoResult)
        //{
        //    return dal.Exists(FileListDoResult);
        //}

        ///// <summary>
        ///// ����һ������
        ///// </summary>
        //public int  Add(DigiPower.Onlinecol.Standard.Model.T_FileListDoResult_MDL model)
        //{
        //    return dal.Add(model);
        //}

        ///// <summary>
        ///// ����һ������
        ///// </summary>
        //public void Update(DigiPower.Onlinecol.Standard.Model.T_FileListDoResult_MDL model)
        //{
        //    dal.Update(model);
        //}

        ///// <summary>
        ///// ɾ��һ������
        ///// </summary>
        //public void Delete(int FileListDoResult)
        //{
			
        //    dal.Delete(FileListDoResult);
        //}

        ///// <summary>
        ///// �õ�һ������ʵ��
        ///// </summary>
        //public DigiPower.Onlinecol.Standard.Model.T_FileListDoResult_MDL GetModel(int FileListDoResult)
        //{
			
        //    return dal.GetModel(FileListDoResult);
        //}

        ///// <summary>
        ///// �õ�һ������ʵ�壬�ӻ����С�
        ///// </summary>
        //public DigiPower.Onlinecol.Standard.Model.T_FileListDoResult_MDL GetModelByCache(int FileListDoResult)
        //{
			
        //    string CacheKey = "T_FileListDoResult_MDLModel-" + FileListDoResult;
        //    object objModel = LTP.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(FileListDoResult);
        //            if (objModel != null)
        //            {
        //                int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (DigiPower.Onlinecol.Standard.Model.T_FileListDoResult_MDL)objModel;
        //}

        ///// <summary>
        ///// ��������б�
        ///// </summary>
        //public DataSet GetList(string strWhere)
        //{
        //    return dal.GetList(strWhere);
        //}
        ///// <summary>
        ///// ���ǰ��������
        ///// </summary>
        //public DataSet GetList(int Top,string strWhere,string filedOrder)
        //{
        //    return dal.GetList(Top,strWhere,filedOrder);
        //}
        ///// <summary>
        ///// ��������б�
        ///// </summary>
        //public List<DigiPower.Onlinecol.Standard.Model.T_FileListDoResult_MDL> GetModelList(string strWhere)
        //{
        //    DataSet ds = dal.GetList(strWhere);
        //    return DataTableToList(ds.Tables[0]);
        //}
        ///// <summary>
        ///// ��������б�
        ///// </summary>
        //public List<DigiPower.Onlinecol.Standard.Model.T_FileListDoResult_MDL> DataTableToList(DataTable dt)
        //{
        //    List<DigiPower.Onlinecol.Standard.Model.T_FileListDoResult_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.T_FileListDoResult_MDL>();
        //    int rowsCount = dt.Rows.Count;
        //    if (rowsCount > 0)
        //    {
        //        DigiPower.Onlinecol.Standard.Model.T_FileListDoResult_MDL model;
        //        for (int n = 0; n < rowsCount; n++)
        //        {
        //            model = new DigiPower.Onlinecol.Standard.Model.T_FileListDoResult_MDL();
        //            if(dt.Rows[n]["FileListDoResult"].ToString()!="")
        //            {
        //                model.FileListDoResult=int.Parse(dt.Rows[n]["FileListDoResult"].ToString());
        //            }
        //            if(dt.Rows[n]["SingleProjectID"].ToString()!="")
        //            {
        //                model.SingleProjectID=int.Parse(dt.Rows[n]["SingleProjectID"].ToString());
        //            }
        //            if(dt.Rows[n]["FileListID"].ToString()!="")
        //            {
        //                model.FileListID=int.Parse(dt.Rows[n]["FileListID"].ToString());
        //            }
        //            if(dt.Rows[n]["WorkFlowID"].ToString()!="")
        //            {
        //                model.WorkFlowID=int.Parse(dt.Rows[n]["WorkFlowID"].ToString());
        //            }
        //            if(dt.Rows[n]["DoUserID"].ToString()!="")
        //            {
        //                model.DoUserID=int.Parse(dt.Rows[n]["DoUserID"].ToString());
        //            }
        //            if(dt.Rows[n]["DoDateTime"].ToString()!="")
        //            {
        //                model.DoDateTime=DateTime.Parse(dt.Rows[n]["DoDateTime"].ToString());
        //            }
        //            if(dt.Rows[n]["DoResultID"].ToString()!="")
        //            {
        //                model.DoResultID=int.Parse(dt.Rows[n]["DoResultID"].ToString());
        //            }
        //            model.DoResult=dt.Rows[n]["DoResult"].ToString();
        //            modelList.Add(model);
        //        }
        //    }
        //    return modelList;
        //}

        ///// <summary>
        ///// ��������б�
        ///// </summary>
        //public DataSet GetAllList()
        //{
        //    return GetList("");
        //}

        ///// <summary>
        ///// ��������б�
        ///// </summary>
        ////public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        ////{
        //    //return dal.GetList(PageSize,PageIndex,strWhere);
        ////}

        //#endregion  ��Ա����
	}
}

