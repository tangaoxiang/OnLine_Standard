using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
using System.Collections;
namespace DigiPower.Onlinecol.Standard.BLL {
    /// <summary>
    /// ҵ���߼���T_FileList_BLL ��ժҪ˵����
    /// </summary>
    public class T_FileList_BLL {
        private readonly DigiPower.Onlinecol.Standard.DAL.T_FileList_DAL dal = new DigiPower.Onlinecol.Standard.DAL.T_FileList_DAL();
        public T_FileList_BLL() { }
        #region  ��Ա����

        /// <summary>
        /// �õ����ID
        /// </summary>
        public int GetMaxId() {
            return dal.GetMaxId();
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int FileListID) {
            return dal.Exists(FileListID);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_FileList_MDL model) {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(DigiPower.Onlinecol.Standard.Model.T_FileList_MDL model) {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int FileListID) {

            dal.Delete(FileListID);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int FileListID, string strWhere) {
            dal.Delete(FileListID, strWhere);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_FileList_MDL GetModel(int FileListID) {

            return dal.GetModel(FileListID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_FileList_MDL GetModelByCache(int FileListID) {

            string CacheKey = "T_FileList_MDLModel-" + FileListID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null) {
                try {
                    objModel = dal.GetModel(FileListID);
                    if (objModel != null) {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                } catch { }
            }
            return (DigiPower.Onlinecol.Standard.Model.T_FileList_MDL)objModel;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere, string orderBy = null) {
            return dal.GetList(strWhere, orderBy);
        }


        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere, string orderby, bool orderflag) {
            return dal.GetList(strWhere, orderby, orderflag);
        }

        /// <summary>
        /// ��������б� ��ҳ
        /// </summary>
        /// <returns></returns>
        public DataTable GetListPaging(string strWhere, int PageSize, int curPage, out int recCoun) {
            return dal.GetList(strWhere, PageSize, curPage, "FileListID", "BH asc", out recCoun);
        }

        /// <summary>
        /// ��������б� ��ҳ
        /// </summary>
        /// <returns></returns>
        public DataTable GetListPaging(string strWhere, int PageSize, int curPage, string OrderBy, out int recCoun) {
            return dal.GetList(strWhere, PageSize, curPage, "FileListID", OrderBy, out recCoun);
        }

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder) {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public List<DigiPower.Onlinecol.Standard.Model.T_FileList_MDL> GetModelList(string strWhere) {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// ��������б� ��ҳ
        /// </summary>
        /// <returns></returns>
        public DataTable GetLHSignatureFilesList(string Signature_UserID, string strWhere, int PageSize, int curPage, out int recCoun) {
            return dal.GetLHSignatureFilesList(Signature_UserID, strWhere, PageSize, curPage, "FileListID", "BH asc", out recCoun);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public List<DigiPower.Onlinecol.Standard.Model.T_FileList_MDL> DataTableToList(DataTable dt) {
            List<DigiPower.Onlinecol.Standard.Model.T_FileList_MDL> modelList = new List<DigiPower.Onlinecol.Standard.Model.T_FileList_MDL>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0) {
                DigiPower.Onlinecol.Standard.Model.T_FileList_MDL model;
                for (int n = 0; n < rowsCount; n++) {
                    model = new DigiPower.Onlinecol.Standard.Model.T_FileList_MDL();
                    if (dt.Rows[n]["FileListID"].ToString() != "") {
                        model.FileListID = int.Parse(dt.Rows[n]["FileListID"].ToString());
                    }
                    if (dt.Rows[n]["SingleProjectID"].ToString() != "") {
                        model.SingleProjectID = int.Parse(dt.Rows[n]["SingleProjectID"].ToString());
                    }
                    if (dt.Rows[n]["ArchiveID"].ToString() != "") {
                        model.ArchiveID = int.Parse(dt.Rows[n]["ArchiveID"].ToString());
                    }
                    if (dt.Rows[n]["MyArchiveID"].ToString() != "") {
                        model.MyArchiveID = int.Parse(dt.Rows[n]["MyArchiveID"].ToString());
                    }
                    if (dt.Rows[n]["recID"].ToString() != "") {
                        model.recID = int.Parse(dt.Rows[n]["recID"].ToString());
                    }
                    if (dt.Rows[n]["PID"].ToString() != "") {
                        model.PID = int.Parse(dt.Rows[n]["PID"].ToString());
                    }
                    if (dt.Rows[n]["DefaultCompanyType"].ToString() != "") {
                        model.DefaultCompanyType = int.Parse(dt.Rows[n]["DefaultCompanyType"].ToString());
                    }
                    model.DH = dt.Rows[n]["DH"].ToString();
                    model.MyCode = dt.Rows[n]["MyCode"].ToString();
                    model.BH = dt.Rows[n]["BH"].ToString();
                    model.Title = dt.Rows[n]["Title"].ToString();
                    if (dt.Rows[n]["MustSubmitFlag"].ToString() != "") {
                        if ((dt.Rows[n]["MustSubmitFlag"].ToString() == "1") || (dt.Rows[n]["MustSubmitFlag"].ToString().ToLower() == "true")) {
                            model.MustSubmitFlag = true;
                        } else {
                            model.MustSubmitFlag = false;
                        }
                    }
                    model.OldStatus = dt.Rows[n]["OldStatus"].ToString();
                    model.Status = dt.Rows[n]["Status"].ToString();
                    model.StartTime = dt.Rows[n]["StartTime"].ToString();
                    model.EndTime = dt.Rows[n]["EndTime"].ToString();
                    if (dt.Rows[n]["CompanyID"].ToString() != "") {
                        model.CompanyID = int.Parse(dt.Rows[n]["CompanyID"].ToString());
                    }
                    if (dt.Rows[n]["OperateUserID"].ToString() != "") {
                        model.OperateUserID = int.Parse(dt.Rows[n]["OperateUserID"].ToString());
                    }
                    model.OperateUserName = dt.Rows[n]["OperateUserName"].ToString();
                    if (dt.Rows[n]["OrderIndex"].ToString() != "") {
                        model.OrderIndex = int.Parse(dt.Rows[n]["OrderIndex"].ToString());
                    }
                    if (dt.Rows[n]["ManualCount"].ToString() != "") {
                        model.ManualCount = int.Parse(dt.Rows[n]["ManualCount"].ToString());
                    }
                    if (dt.Rows[n]["PagesCount"].ToString() != "") {
                        model.PagesCount = int.Parse(dt.Rows[n]["PagesCount"].ToString());
                    }
                    if (dt.Rows[n]["WinRecvPagesCount"].ToString() != "") {
                        model.WinRecvPagesCount = int.Parse(dt.Rows[n]["WinRecvPagesCount"].ToString());
                    }
                    model.Remark = dt.Rows[n]["Remark"].ToString();
                    model.PDFFilePath = dt.Rows[n]["PDFFilePath"].ToString();
                    if (dt.Rows[n]["AlonePack"].ToString() != "") {
                        if ((dt.Rows[n]["AlonePack"].ToString() == "1") || (dt.Rows[n]["AlonePack"].ToString().ToLower() == "true")) {
                            model.AlonePack = true;
                        } else {
                            model.AlonePack = false;
                        }
                    }
                    if (dt.Rows[n]["IsFolder"].ToString() != "") {
                        if ((dt.Rows[n]["IsFolder"].ToString() == "1") || (dt.Rows[n]["IsFolder"].ToString().ToLower() == "true")) {
                            model.IsFolder = true;
                        } else {
                            model.IsFolder = false;
                        }
                    }
                    if (dt.Rows[n]["IsSystem"].ToString() != "") {
                        if ((dt.Rows[n]["IsSystem"].ToString() == "1") || (dt.Rows[n]["IsSystem"].ToString().ToLower() == "true")) {
                            model.IsSystem = true;
                        } else {
                            model.IsSystem = false;
                        }
                    }
                    model.FileType = dt.Rows[n]["FileType"].ToString();
                    model.archive_form_no = dt.Rows[n]["archive_form_no"].ToString();
                    model.zajh = dt.Rows[n]["zajh"].ToString();
                    model.w_t_h = dt.Rows[n]["w_t_h"].ToString();
                    model.wjtm = dt.Rows[n]["wjtm"].ToString();
                    model.zrr = dt.Rows[n]["zrr"].ToString();
                    if (dt.Rows[n]["qssj"].ToString() != "") {
                        model.qssj = DateTime.Parse(dt.Rows[n]["qssj"].ToString());
                    }
                    if (dt.Rows[n]["zzsj"].ToString() != "") {
                        model.zzsj = DateTime.Parse(dt.Rows[n]["zzsj"].ToString());
                    }
                    model.yc = dt.Rows[n]["yc"].ToString();
                    model.wb = dt.Rows[n]["wb"].ToString();
                    if (dt.Rows[n]["sl"].ToString() != "") {
                        model.sl = int.Parse(dt.Rows[n]["sl"].ToString());
                    }
                    model.bgqx = dt.Rows[n]["bgqx"].ToString();
                    model.mj = dt.Rows[n]["mj"].ToString();
                    model.dz_k = dt.Rows[n]["dz_k"].ToString();
                    model.dz_l = dt.Rows[n]["dz_l"].ToString();
                    model.dz_g = dt.Rows[n]["dz_g"].ToString();
                    model.dz_c = dt.Rows[n]["dz_c"].ToString();
                    model.dz_x = dt.Rows[n]["dz_x"].ToString();
                    model.ztlx = dt.Rows[n]["ztlx"].ToString();
                    model.dw = dt.Rows[n]["dw"].ToString();
                    model.gg = dt.Rows[n]["gg"].ToString();
                    model.ty = dt.Rows[n]["ty"].ToString();
                    model.ztc = dt.Rows[n]["ztc"].ToString();
                    model.note = dt.Rows[n]["note"].ToString();
                    model.sw = dt.Rows[n]["sw"].ToString();
                    model.dz = dt.Rows[n]["dz"].ToString();
                    model.lrr = dt.Rows[n]["lrr"].ToString();
                    if (dt.Rows[n]["lrsj"].ToString() != "") {
                        model.lrsj = DateTime.Parse(dt.Rows[n]["lrsj"].ToString());
                    }
                    if (dt.Rows[n]["shzt"].ToString() != "") {
                        model.shzt = int.Parse(dt.Rows[n]["shzt"].ToString());
                    }
                    model.shr_1 = dt.Rows[n]["shr_1"].ToString();
                    if (dt.Rows[n]["shsj_1"].ToString() != "") {
                        model.shsj_1 = DateTime.Parse(dt.Rows[n]["shsj_1"].ToString());
                    }
                    model.shr_2 = dt.Rows[n]["shr_2"].ToString();
                    if (dt.Rows[n]["shsj_2"].ToString() != "") {
                        model.shsj_2 = DateTime.Parse(dt.Rows[n]["shsj_2"].ToString());
                    }
                    model.shr_3 = dt.Rows[n]["shr_3"].ToString();
                    if (dt.Rows[n]["shsj_3"].ToString() != "") {
                        model.shsj_3 = DateTime.Parse(dt.Rows[n]["shsj_3"].ToString());
                    }
                    if (dt.Rows[n]["aipdate"].ToString() != "") {
                        model.aipdate = DateTime.Parse(dt.Rows[n]["aipdate"].ToString());
                    }
                    model.aipuser = dt.Rows[n]["aipuser"].ToString();
                    model.ShortDH = dt.Rows[n]["ShortDH"].ToString();
                    model.swgph = dt.Rows[n]["swgph"].ToString();
                    model.cfdz = dt.Rows[n]["cfdz"].ToString();
                    model.wjbt = dt.Rows[n]["wjbt"].ToString();
                    model.zrz = dt.Rows[n]["zrz"].ToString();
                    model.wh = dt.Rows[n]["wh"].ToString();
                    model.wjfwqx = dt.Rows[n]["wjfwqx"].ToString();
                    model.xcsj = dt.Rows[n]["xcsj"].ToString();
                    model.dzwjxx = dt.Rows[n]["dzwjxx"].ToString();
                    model.fz = dt.Rows[n]["fz"].ToString();
                    if (dt.Rows[n]["CreateDate"].ToString() != "") {
                        model.CreateDate = DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
                    }
                    if (dt.Rows[n]["CreateDate2"].ToString() != "") {
                        model.CreateDate2 = DateTime.Parse(dt.Rows[n]["CreateDate2"].ToString());
                    }
                    if (dt.Rows[n]["tzz"].ToString() != "") {
                        model.tzz = int.Parse(dt.Rows[n]["tzz"].ToString());
                    }
                    if (dt.Rows[n]["dtz"].ToString() != "") {
                        model.dtz = int.Parse(dt.Rows[n]["dtz"].ToString());
                    }
                    if (dt.Rows[n]["zpz"].ToString() != "") {
                        model.zpz = int.Parse(dt.Rows[n]["zpz"].ToString());
                    }
                    if (dt.Rows[n]["wzz"].ToString() != "") {
                        model.wzz = int.Parse(dt.Rows[n]["wzz"].ToString());
                    }
                    if (dt.Rows[n]["dpz"].ToString() != "") {
                        model.dpz = int.Parse(dt.Rows[n]["dpz"].ToString());
                    }
                    model.wjgbdm = dt.Rows[n]["wjgbdm"].ToString();
                    model.wjlxdm = dt.Rows[n]["wjlxdm"].ToString();
                    model.wjgs = dt.Rows[n]["wjgs"].ToString();
                    model.wjdx = dt.Rows[n]["wjdx"].ToString();
                    model.psdd = dt.Rows[n]["psdd"].ToString();
                    model.psz = dt.Rows[n]["psz"].ToString();
                    if (dt.Rows[n]["pssj"].ToString() != "") {
                        model.pssj = DateTime.Parse(dt.Rows[n]["pssj"].ToString());
                    }
                    model.sb = dt.Rows[n]["sb"].ToString();
                    model.fbl = dt.Rows[n]["fbl"].ToString();
                    model.xjpp = dt.Rows[n]["xjpp"].ToString();
                    model.xjxh = dt.Rows[n]["xjxh"].ToString();
                    model.bz = dt.Rows[n]["bz"].ToString();


                    model.FROM_SID = Common.ConvertEx.ToString(dt.Rows[n]["FROM_SID"]);
                    model.RootPath = Common.ConvertEx.ToString(dt.Rows[n]["RootPath"]);
                    model.CONVERT_FLAG = Common.ConvertEx.ToBool(dt.Rows[n]["CONVERT_FLAG"]);
                    model.CONVERT_DT = Common.ConvertEx.ToString(dt.Rows[n]["CONVERT_DT"]);
                    model.SIGNATURE_FLAG = Common.ConvertEx.ToBool(dt.Rows[n]["SIGNATURE_FLAG"]);
                    model.SIGNATURE_DT = Common.ConvertEx.ToString(dt.Rows[n]["SIGNATURE_DT"]);

                    if (dt.Rows[n]["OldRecID"].ToString() != "") {
                        model.OldRecID = int.Parse(dt.Rows[n]["OldRecID"].ToString());
                    }
                    if (dt.Rows[n]["MyOrderIndex"].ToString() != "") {
                        model.MyOrderIndex = int.Parse(dt.Rows[n]["MyOrderIndex"].ToString());
                    }
                    model.FileFrom = Common.ConvertEx.ToString(dt.Rows[n]["FileFrom"]);
                    model.IsMerge = Common.ConvertEx.ToString(dt.Rows[n]["IsMerge"]);
                    if (dt.Rows[n]["Version"].ToString() != "") {
                        model.Version = int.Parse(dt.Rows[n]["Version"].ToString());
                    }
                    model.iSignaturePdf = Common.ConvertEx.ToBool(dt.Rows[n]["iSignaturePdf"]);
                    model.iSignatureWorkFlow = Common.ConvertEx.ToBool(dt.Rows[n]["iSignatureWorkFlow"]);
                                
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetAllList() {
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

        //public DataSet GetClientList(string strWhere)
        //{
        //    DataSet fileDS = new DataSet();
        //    dal.GetClientList(fileDS, strWhere);

        //    DataSet outDS = new DataSet();

        //    outDS.Tables.Add(fileDS.Tables[0].Copy());
        //    outDS.Tables[0].Rows.Clear();

        //    dal.GetClientList2(fileDS, outDS);
        //    return outDS;
        //}

        ///<summary>
        ///��ȡ�û��Զ���鵵Ŀ¼��ˮ��
        ///</summary>
        public int GetMaxRecID(string projectid) {
            return dal.GetMaxRecID(projectid);
        }
        public bool IsCanDel(int FileListID) {
            return dal.IsCanDel(FileListID);
        }

        public DataSet GetList(string strWhere, string CompanyType, string orderBy = null) {
            return dal.GetList(strWhere, CompanyType, orderBy);
        }

        public DigiPower.Onlinecol.Standard.Model.T_FileList_MDL GetModel(string sqlWhere) {
            return dal.GetModel(sqlWhere);
        }

        /// <summary>
        /// ���¹��̵Ĺ鵵Ŀ¼�²�ͬ��λ��Ӧ�Ĵ�����
        /// </summary>
        /// <param name="SingleProjectID">����ID</param>
        /// <param name="UserID">�û�ID</param>
        /// <param name="UserName">�û�����</param>
        /// <param name="DefaultCompanyType">��λ����ID</param>
        public void UpdateOperateUser(int SingleProjectID, int CompanyID, int UserID, string UserName, int DefaultCompanyType) {
            dal.UpdateOperateUser(SingleProjectID, CompanyID, UserID, UserName, DefaultCompanyType);
        }

        /// <summary>
        /// ��ȡ���̹鵵Ŀ¼�£���ͬ���Ͷ�Ӧ�ĸ���
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetFileListTypeCount(string strWhere) {
            return dal.GetFileListTypeCount(strWhere);
        }

        //��������˳��ţ�����ϵͳ�������������Grid���һ����������
        public void UpdateXH(int ArchiveID, int OrderIndex, bool UPFlag) {
            dal.UpdateXH(ArchiveID, OrderIndex, UPFlag);
        }

        //��������˳��ţ�����ϵͳ�������������Grid���һ����������
        public void MyUpdateXH(int ArchiveID, int OrderIndex, bool UPFlag) {
            dal.MyUpdateXH(ArchiveID, OrderIndex, UPFlag);
        }

        //��ҳ���ݺ�
        public string GetPageCountByArchiveID(string ArchiveID) {
            return dal.GetPageCountByArchiveID(ArchiveID);
        }
        //��ҳ���ݺ�
        public string GetPageCountByMyArchiveID(string MyArchiveID) {
            return dal.GetPageCountByMyArchiveID(MyArchiveID);
        }

        /// <summary>
        /// �ļ��Ǽ���������Ŀ
        /// mustsubmitflag ���ɵ����ݹ�ѡȷ�ϵ�  ,Ĭ��Ϊfalse
        /// </summary>
        /// <param name="SingleProjectID"></param>
        /// <param name="modelIn"></param>
        /// <returns></returns>
        public int Add(string SingleProjectID, DigiPower.Onlinecol.Standard.Model.T_FileListTmp_MDL modelIn) {
            DigiPower.Onlinecol.Standard.Model.T_FileListTmp_MDL modelNew = modelIn;
            //��Ҫȷ���������
            BLL.T_FileListTmp_BLL tplBLL = new T_FileListTmp_BLL();
            Model.T_FileListTmp_MDL tplMDL = tplBLL.GetModel(modelNew.PID);
            if (tplMDL != null) {
                Add(SingleProjectID, tplMDL);
                //modelNew = tplMDL;//Ҫ�Ӹ�model
            }

            if (modelNew.IsFolder == true) {
                if (!dal.Exists(SingleProjectID, modelNew.recid)) {
                    dal.Add(SingleProjectID, Common.Session.GetSession("CompanyID"), Common.Session.GetSession("UserID"), Common.Session.GetSession("UserName"), modelNew);
                }
            } else {
                //DataSet ds = dal.GetList("SingleProjectID=" + SingleProjectID + " AND (BH='" + modelNew.bh + "' OR BH LIKE '" + modelNew.bh + "-%')")
                //DataSet ds = dal.GetList("SingleProjectID=" + SingleProjectID + " AND BH='" + modelNew.bh + "'");
                DataSet ds = dal.GetList("SingleProjectID=" + SingleProjectID + " AND BH LIKE '" + modelNew.bh + "%' AND CompanyID=" + Common.Session.GetSession("CompanyID") + "");
                bool bAdd = true;
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0) {//���ԭ���Ĵ��ڣ����±�ź��ټ�һ��
                    modelNew.bh = modelNew.bh + "-" + (ds.Tables[0].Rows.Count);
                    if (ds.Tables[0].Rows.Count > 3) {//Leo 2012-12-17 ���ֻ���û���3������ģ������Լӣ������û���ȡʱ�����׳�ʱ
                        bAdd = false;
                    }
                }
                if (bAdd == true) {
                    dal.Add(SingleProjectID, Common.Session.GetSession("CompanyID"), Common.Session.GetSession("UserID"), Common.Session.GetSession("UserName"), modelNew);
                }
            }

            return 0;
        }

        /// <summary>
        /// �����鵵Ŀ¼,���Ǳ����ύ�� ,mustsubmitflag=1 
        /// ����¼������,������Ŀ�õ�
        /// </summary>
        /// <param name="SingleProjectID"></param>
        /// <param name="modelIn"></param>
        /// <param name="SuppleMentFlag"></param>
        /// <returns></returns>
        public int Add(string SingleProjectID, DigiPower.Onlinecol.Standard.Model.T_FileListTmp_MDL modelIn, bool SuppleMentFlag) {
            DigiPower.Onlinecol.Standard.Model.T_FileListTmp_MDL modelNew = modelIn;
            //��Ҫȷ���������
            BLL.T_FileListTmp_BLL tplBLL = new T_FileListTmp_BLL();
            Model.T_FileListTmp_MDL tplMDL = tplBLL.GetModel(modelNew.PID);
            if (tplMDL != null) {
                Add(SingleProjectID, tplMDL, SuppleMentFlag);
                //modelNew = tplMDL;//Ҫ�Ӹ�model
            }

            if (modelNew.IsFolder == true) {
                if (!dal.Exists(SingleProjectID, modelNew.recid)) {
                    dal.Add(SingleProjectID, Common.Session.GetSession("CompanyID"), Common.Session.GetSession("UserID"), Common.Session.GetSession("UserName"), modelNew, SuppleMentFlag);
                }
            } else {
                DataSet ds = dal.GetList("SingleProjectID=" + SingleProjectID + " AND BH LIKE '" + modelNew.bh + "%' AND CompanyID=" + Common.Session.GetSession("CompanyID") + "");
                bool bAdd = true;
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0) {//���ԭ���Ĵ��ڣ����±�ź��ټ�һ��
                    modelNew.bh = modelNew.bh + "-" + (ds.Tables[0].Rows.Count);
                    if (ds.Tables[0].Rows.Count > 200) {//Leo 2012-12-17 ���ֻ���û���3������ģ������Լӣ������û���ȡʱ�����׳�ʱ
                        bAdd = false;
                    }
                }
                if (bAdd == true) {
                    dal.Add(SingleProjectID, Common.Session.GetSession("CompanyID"), Common.Session.GetSession("UserID"), Common.Session.GetSession("UserName"), modelNew, SuppleMentFlag);
                }
            }

            return 0;
        }

        public int GetCountByFileType(int singleprojectid, int fileType) {
            return dal.GetCountByFileType(singleprojectid, fileType);
        }

        public int GetCountBySubmitFlag(int singleprojectid) {
            return dal.GetCountBySubmitFlag(singleprojectid);
        }

        public int GetCount(int singleprojectid) {
            return dal.GetCount(singleprojectid);
        }

        public int GetCount(string strWhere) {
            return dal.GetCount(strWhere);
        }

        public int GetFileCountByOperateUserID(int OperateUserID) {
            return dal.GetFileCountByOperateUserID(OperateUserID);
        }

        /// <summary>
        /// ȡ��������ļ������������ļ��Ĺ�˾��������ɾ��
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetFileCountByCompanyID(string CompanyID) {
            int iCount = 0;
            BLL.T_UsersInfo_BLL compBLL = new T_UsersInfo_BLL();
            List<Model.T_UsersInfo_MDL> userList = compBLL.GetModelList(" CompanyID=" + CompanyID);
            foreach (Model.T_UsersInfo_MDL obj in userList) {
                iCount = GetFileCountByOperateUserID(obj.UserID);
                if (iCount > 0) {
                    break;
                }
            }
            return iCount;
        }

        public int GetManualCountByArchiveID(int ArchiveID) {
            return dal.GetManualCountByArchiveID(ArchiveID);
        }

        public void Reset(string ProjID) {
            dal.Reset(ProjID);
        }

        public int GetFileCountByPID(int PID) {
            return dal.GetFileCountByPID(PID);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public string GetMaxBH(string strWhere) {
            return dal.GetMaxBH(strWhere);
        }


        public int GetFileCountByCompany(string strWhere) {
            return dal.GetFileCountByCompany(strWhere);
        }

        public T_FileList_MDL GetFileByPageIndex(string FileListID, string strWhere, bool UpOrDown) {
            IList<T_FileList_MDL> ltMDL = DataTableToList(dal.GetTopList(FileListID, strWhere, UpOrDown));
            if (ltMDL != null && ltMDL.Count > 0)
                return ltMDL[0];
            else
                return null;
        }

        /// <summary>
        /// �����ⲿϵͳ����ĶԽӵ��ļ�key,�����Լ�ϵͳ�ļ�������ID
        /// </summary>
        /// <param name="FromRecID">�ⲿϵͳ������ļ�key</param>
        /// <param name="FromType">�ⲿϵͳ����:������ҵ��</param>
        /// <returns></returns>
        public object GetPID(string FromRecID, string FromType) {
            return dal.GetPID(FromRecID, FromType);
        }

        /// <summary>
        /// �����ⲿϵͳ����ĶԽӵ��ļ�key,�����Լ�ϵͳ�ļ�����ID
        /// </summary>
        /// <param name="FromRecID">�ⲿϵͳ������ļ�key</param>
        /// <param name="FromType">�ⲿϵͳ����:������ҵ��</param>
        /// <returns></returns>
        public object GetRecID(string FromRecID, string FromType) {
            return dal.GetRecID(FromRecID, FromType);
        }

        public int GetFileOrderIndexByPID(string strWhere) {
            return dal.GetFileOrderIndexByPID(strWhere);
        }

        /// <summary>
        /// ���ݹ�˾ɾ���ļ�����Ϣ
        /// </summary>
        /// <returns></returns>
        public int DeleteFileListByCompanyID(int tCompanyID, int DefaultCompanyType) {
            return dal.DeleteFileListByCompanyID(tCompanyID, DefaultCompanyType);
        }

        /// <summary>
        ///  ��ȡ�ļ��������
        /// </summary>
        /// <returns></returns>
        public int GetFileCount(Hashtable ht) {
            return dal.GetFileCount(ht);
        }

        /// <summary>
        /// ɾ���ļ�����Ϣ
        /// </summary>
        /// <returns></returns>
        public int DeleteFileList(Hashtable ht) {
            return dal.DeleteFileList(ht);
        }

        /// <summary>
        /// ��ȡ�����������ļ����ڲ����,�����ظ���
        /// </summary>
        /// <param name="SingleProjectID"></param>
        /// <param name="CompanyID"></param>
        /// <returns></returns>
        public DataTable GetDistinctMyCode(string SingleProjectID, string CompanyID) {
            return dal.GetDistinctMyCode(SingleProjectID, CompanyID);
        }

        /// <summary>
        /// ���ع����µİ�����ļ� ����: ManualCountС��1
        /// </summary>
        /// <param name="SingleProjectID"></param>
        /// <returns></returns>
        public DataTable GetFileListThanManualCount(string SingleProjectID) {
            return dal.GetFileListThanManualCount(SingleProjectID);
        }

        /// <summary>
        ///  �����ļ���������������ļ����� ����PID=0ͳ��
        /// </summary>
        /// <param name="SingleProjectID"></param>
        /// <returns></returns>
        public DataTable GetFinishFileCountByFileType(string SingleProjectID) {
            return dal.GetFinishFileCountByFileType(SingleProjectID);
        }

        /// <summary>
        /// ��ȡ�������Ӧ�Ĺ鵵Ŀ¼ID
        /// </summary>
        /// <param name="SingleProjectID"></param>
        /// <param name="ZrsToFileListTmpRecIDS"></param>
        /// <returns></returns>
        public IList<T_FileList_MDL> GetZrsMoveFileRecID(string SingleProjectID, string ZrsToFileListTmpRecIDS) {
            return DataTableToList(dal.GetZrsMoveFileRecID(SingleProjectID, ZrsToFileListTmpRecIDS));
        }

        /// <summary>
        /// ��ȡ������ǩ��δ��ɵ��ļ�
        /// </summary>
        /// <param name="SingleProjectID">����ID</param>
        /// <param name="SignatureFinishStatus">ǩ�����״̬ 1:��� 0:δ���</param>
        /// <returns></returns>
        public DataTable GetFileListBySignatureFinishStatus(string SingleProjectID, int SignatureFinishStatus) {
            return dal.GetFileListBySignatureFinishStatus(SingleProjectID, SignatureFinishStatus);
        }
    }
}