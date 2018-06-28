using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.Common;

namespace DigiPower.Onlinecol.Standard.Web.File
{
    public partial class FileCellList : PageBase
    {
        #region 属性及构造方法

        //文件ID
        //string FileID = "";

        //工程编号
        public string ProNo = "000000";

        //电子文件存放起始路径
        string StartPath = "";

        //文件路径
        string path = null;

        //文件名
        string NewGUID = Guid.NewGuid().ToString();

        //原始文件路径
        string OPath = null;

        //PDF路径
        string PdfPath = null;

        //合并PDF路径
        string MPdfPath = null;

        //合并PDF临时路径
        //string MTemp = null;

        /// <summary>
        /// 总记录数
        /// </summary>
        int itemCount = 0;

        /// <summary>
        /// 每页页数
        /// </summary>
        int pageSize = SystemSet._PAGESIZE;

        protected void Page_Load(object sender, EventArgs e)
        {
            Ajax.Utility.RegisterTypeForAjax(typeof(FileCellList));
            StartPath = Common.Common.EFileStartPath;

            MyAddInit();

            if (!String.IsNullOrEmpty(Common.DNTRequest.GetQueryString("ProNo")))
            {
                ProNo = Common.DNTRequest.GetQueryString("ProNo");
            }

            //ProNo = StartPath + ProNo;
            StartPath += ProNo;
            //FileID = Common.DNTRequest.GetQueryString("ID");
            OPath = StartPath + "\\ODOC\\" + path;
            //PdfPath = StartPath + "\\PDF\\" + path;
            MPdfPath = StartPath + "\\MPDF\\" + path;

            SaveSelect();
            if (!IsPostBack)
            {
                BindGridView(1);
            }   

            string url = "../SystemManage/CellSelectList.aspx?fromUrl=" + Page.Request.Url;
            ClientScript.RegisterStartupScript(Page.GetType(), "open004", "<script type='text/javascript'>function OpenNewWin(){openCommonWindowScroll('" + url + "',960,600);return false;}</script>");
        }

        private void SaveSelect()
        {
            string SelectIDList = Common.Session.GetSession("SelectIDList");
            if (!String.IsNullOrEmpty(SelectIDList))
            {
                BLL.T_CellTmp_BLL bll1 = new DigiPower.Onlinecol.Standard.BLL.T_CellTmp_BLL();
                //BLL.T_FileListTmp_CellRptTmp_BLL bll2 = new DigiPower.Onlinecol.Standard.BLL.T_FileListTmp_CellRptTmp_BLL();
                BLL.T_EFile_BLL bll2 = new DigiPower.Onlinecol.Standard.BLL.T_EFile_BLL();
                foreach (string CellReportID in SelectIDList.Split(','))
                {
                    //if (CellReportID != "" && !bll2.Exists("FileListID=" + ID + " AND CellFilePath='" + CellReportID + "'"))
                    //{
                    Model.T_CellTmp_MDL mdl = bll1.GetModel(Common.ConvertEx.ToInt(CellReportID));
                    if (mdl != null)
                    {
                        Model.T_EFile_MDL mdl2 = new DigiPower.Onlinecol.Standard.Model.T_EFile_MDL();
                        mdl2.FileType = 1;
                        mdl2.Title = mdl.Title;
                        mdl2.FilePath = Common.ConvertEx.ToString(mdl.CellID);
                        mdl2.Status = 0;
                        mdl2.OrderIndex = Common.ConvertEx.ToInt(mdl.OrderIndex);
                        mdl2.FileListID = Common.ConvertEx.ToInt(ID);
                        mdl2.RootPath = Common.Common.EFileStartPath;
                        bll2.Add(mdl2);
                    }
                    //}
                }
                Session["SelectIDList"] = null;
            }
        }

        #endregion

        #region 事件
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnAdd_Click(object sender, EventArgs e)
        //{
        //    if (ctrlGridEx2.GetSelects().Count > 0)
        //    {
        //        List<string> liSel = ctrlGridEx2.GetSelects();

        //        if (liSel != null && liSel.Count > 0)
        //        {
        //            for (int i = 0; i < liSel.Count; i++)
        //            {
        //                string newGuid = Guid.NewGuid().ToString();

        //                DigiPower.Onlinecol.Standard.BLL.T_EFile_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_EFile_BLL();

        //                DigiPower.Onlinecol.Standard.Model.T_EFile_MDL model = new DigiPower.Onlinecol.Standard.Model.T_EFile_MDL();

        //                model = bll.GetModel(Common.ConvertEx.ToInt(liSel[i]));

        //                //复制数据

        //                //新原始文件路径
        //                string NewFilePath = model.FilePath.Substring(0, model.FilePath.LastIndexOf('\\') + 1);

        //                NewFilePath = NewFilePath + newGuid + ".cll";

        //                //新PDF文件路径
        //                string NewPDFFilePath = model.PDFFilePath.Substring(0, model.PDFFilePath.LastIndexOf('\\') + 1);

        //                NewPDFFilePath = NewPDFFilePath + newGuid + ".pdf";

        //                model.OrderIndex = GetMaxOrder();

        //                //model.OrderIndex + 1;

        //                //复制表格
        //                if (System.IO.File.Exists(OPath + model.FilePath))
        //                {
        //                    System.IO.File.Copy(OPath + model.FilePath, OPath + NewFilePath);
        //                }

        //                //复制PDF
        //                if (System.IO.File.Exists(PdfPath + model.PDFFilePath))
        //                {
        //                    System.IO.File.Copy(PdfPath + model.PDFFilePath, PdfPath + NewPDFFilePath);
        //                }

        //                model.FilePath = newGuid + ".cll";

        //                model.PDFFilePath = newGuid + ".pdf";

        //                bll.Add(model);
        //            }

        //            MergerPdf();

        //            BindGridView();
        //        }
        //    }
        //}

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DigiPower.Onlinecol.Standard.BLL.T_EFile_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_EFile_BLL();

            //if (ctrlGridEx1.GetSelects().Count > 0)
            //{
            //    for (int i = 0; i < ctrlGridEx1.GetSelects().Count; i++)
            //    { 
            //        DigiPower.Onlinecol.Standard.Model.T_EFile_MDL model = new DigiPower.Onlinecol.Standard.Model.T_EFile_MDL();

            //        model = bll.GetModel(Convert.ToInt32(ctrlGridEx1.GetSelects()[0]));

            //        //删除电子文件记录
            //        bll.Delete(Convert.ToInt32(ctrlGridEx1.GetSelects()[0]));

            //        try
            //        {
            //            //删除电子文件
            //            System.IO.File.Delete(PdfPath + model.PDFFilePath);
            //        }
            //        catch { }

            //        //重新合并
            //        MergerPdf();
            //    }

            //    this.BindGridView();
            //}

            //if (ctrlGridEx2.GetSelects().Count > 0)
            //{
            //    for (int i = 0; i < ctrlGridEx2.GetSelects().Count; i++)
            //    {
            //        DigiPower.Onlinecol.Standard.Model.T_EFile_MDL model = new DigiPower.Onlinecol.Standard.Model.T_EFile_MDL();

            //        model = bll.GetModel(Convert.ToInt32(ctrlGridEx2.GetSelects()[i]));

            //        //删除电子文件记录
            //        bll.Delete(Convert.ToInt32(ctrlGridEx2.GetSelects()[i]));

            //        if (System.IO.File.Exists(PdfPath + model.PDFFilePath))
            //        {
            //            //删除电子文件
            //            System.IO.File.Delete(PdfPath + model.PDFFilePath);

            //            //重新合并
            //            MergerPdf();
            //        }
            //    }

            //    this.BindGridView();
            //}
        }
        #endregion

        #region 方法

        /// <summary>
        /// 保存电子文件排序编号
        /// </summary>
        /// <param name="archiveListCellRptID"></param>
        /// <param name="OrderIndex"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public void UpdateEFileIndex(string archiveListCellRptID, string OrderIndex)
        {
            T_EFile_BLL bll = new T_EFile_BLL();
            T_EFile_MDL model = new T_EFile_MDL();

            model = bll.GetModel(Convert.ToInt32(archiveListCellRptID));
            if (model != null)
            {
                model.OrderIndex = ConvertEx.ToInt(OrderIndex);
                bll.Update(model);
            }
        }

        /// <summary>
        /// 删除电子文件
        /// </summary>
        /// <param name="ArchiveListCellRptID"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public void DeleteFile(string archiveListCellRptID, string singleProjectID)
        {
            T_EFile_BLL bll = new T_EFile_BLL();

            T_EFile_MDL model = new T_EFile_MDL();
            model = bll.GetModel(Convert.ToInt32(archiveListCellRptID));
            if (model != null)
            {
                //删除电子文件
                //if (model != null && model.PDFFilePath != "" && System.IO.File.Exists(PdfPath + model.PDFFilePath))
                //{
                //    System.IO.File.Delete(PdfPath + model.PDFFilePath);
                //}
                //string filePath = string.Concat(model.RootPath, singleProjectID, "\\ODOC\\", model.FilePath);

                //if (filePath != "" && System.IO.File.Exists(filePath))
                //{
                //    System.IO.File.Delete(filePath);
                //}
                //删除电子文件记录
                bll.Delete(Convert.ToInt32(archiveListCellRptID));

                //Leo 更新文件夹，晚上重新生产一次
                int FileListID = model.FileListID;
                BLL.T_FileList_BLL fileListBLL = new DigiPower.Onlinecol.Standard.BLL.T_FileList_BLL();
                Model.T_FileList_MDL fileListMDL = fileListBLL.GetModel(FileListID);
                fileListMDL.CONVERT_FLAG = false;
                fileListBLL.Update(fileListMDL);
            }
        }

        private int GetMaxOrder()
        {
            int MaxOrderIndex = 1;

            BLL.T_EFile_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_EFile_BLL();

            DataSet ds = new DataSet();

            ds = bll.GetList("1=1" + " and FileListID = " + ID + " and FileType = 1 order by OrderIndex desc");

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                MaxOrderIndex = Common.ConvertEx.ToInt(ds.Tables[0].Rows[0]["OrderIndex"].ToString()) + 1;
            }

            return MaxOrderIndex;
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindGridView(int pageIndex)
        {
            T_EFile_BLL bll = new T_EFile_BLL();

            string strWhere = " FileListID = " + ID + " and FileType = 1 ";
            DataTable dt = bll.GetListPaging(strWhere, pageSize, pageIndex, out itemCount); ;

            AspNetPager.AlwaysShow = true;
            AspNetPager.PageSize = pageSize;

            AspNetPager.RecordCount = itemCount;

            gvData.DataSource = dt;
            gvData.DataBind();
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager_PageChanged(object sender, EventArgs e)
        {
            BindGridView(AspNetPager.CurrentPageIndex);
        }

        /// <summary>
        /// 合并PDF
        /// </summary>
        private void MergerPdf()
        {
            ArrayList list = new ArrayList();

            BLL.T_EFile_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_EFile_BLL();

            DataSet ds = bll.GetList("FileListID = " + ID + " and FileType = 1 order by OrderIndex");

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    list.Add(PdfPath + ds.Tables[0].Rows[i]["PDFFilePath"].ToString());
                }
            }

            DataSet ds1 = bll.GetList("FileListID = " + ID + " and FileType = 0 order by OrderIndex");

            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    list.Add(PdfPath + ds1.Tables[0].Rows[i]["PDFFilePath"].ToString());
                }
            }

            string[] newMPDF = new string[list.Count];

            if (newMPDF != null && newMPDF.Length > 0)
            {
                for (int i = 0; i < newMPDF.Length; i++)
                {
                    newMPDF[i] = list[i].ToString();
                }
            }

            if (newMPDF != null && newMPDF.Length > 0)
            {
                //if (System.IO.Directory.Exists(MPdfPath))
                //{
                //    System.IO.Directory.Delete(MPdfPath, true);

                //    System.IO.Directory.CreateDirectory(MPdfPath);
                //}
                ////更新目录合并PDF信息
                //DigiPower.Onlinecol.Standard.BLL.T_FileList_BLL tbll = new DigiPower.Onlinecol.Standard.BLL.T_FileList_BLL();
                //DigiPower.Onlinecol.Standard.Model.T_FileList_MDL tmodel = tbll.GetModel(Common.ConvertEx.ToInt(ID));
                //tmodel.PDFFilePath = NewGUID + ".pdf";

                //Common.PrintToPDF pdfTool = new DigiPower.Onlinecol.Standard.Common.PrintToPDF(ProNo);
                //tmodel.PagesCount = pdfTool.GetPDFCount(MPdfPath + "\\" + NewGUID + ".pdf");

                //tbll.Update(tmodel);
            }
        }

        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="path"></param>
        private void CreateDic()
        {
            //创建电子文件存放目录
            if (!System.IO.Directory.Exists(OPath))
            {
                System.IO.Directory.CreateDirectory(OPath);
            }

            if (!System.IO.Directory.Exists(PdfPath))
            {
                System.IO.Directory.CreateDirectory(PdfPath);
            }

            if (!System.IO.Directory.Exists(MPdfPath))
            {
                System.IO.Directory.CreateDirectory(MPdfPath);
            }
        }

        #endregion

        protected void btnModify_Click(object sender, EventArgs e)
        {
            //List<string> sellist = ctrlGridEx2.GetSelects();
            //if (sellist.Count > 0)
            //{
            //    Session.Add("grd", this.ctrlGridEx2);

            //    string url = "EditFileTitle.aspx?ID=" + sellist[0].ToString() + "&ID=" + ID;
            //    ClientScript.RegisterStartupScript(Page.GetType(), "open005", "<script type='text/javascript'>openCommonWindowScroll('" + url + "',500,150);</script>");
            //}
        }
    }
}