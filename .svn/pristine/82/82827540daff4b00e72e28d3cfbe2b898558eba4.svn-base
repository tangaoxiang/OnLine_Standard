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
using DigiPower.Onlinecol.Standard.Common;

namespace DigiPower.Onlinecol.Standard.Web.SystemManage
{
    public partial class ArchiveCellReportList : PageBase
    {       
        protected void Page_Load(object sender, EventArgs e)
        {
            MyAddInit();
           
            if (!IsPostBack)
            {
                 this.btnDelete.Attributes.Add("onclick", "javascript:return confirm('你确认要删除吗?')");                 
            }
            SaveSelect();

            BindGridView(ID);

            string url = "CellSelectList.aspx";
            ClientScript.RegisterStartupScript(Page.GetType(), "open009", "<script type='text/javascript'>function OpenNewWin(){openCommonWindowScroll('" + url + "',960,600);return false;}</script>");            
        }

        ///// <summary>
        ///// 保存
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void btnAdd_Click(object sender, EventArgs e)
        //{
        //    //Response.Redirect("ArchiveCellReportAdd.aspx?Action=add&ID=0&recid="+ID+"&sqlwhere = " + SqlWhere + "");
        //    //List<string> sellist = ctrlGridEx1.GetSelects();
        //    //if (sellist.Count > 0)
        //    //{
        //        //T_SingleProject_MDL model = (new T_SingleProject_BLL()).GetModel(ConvertEx.ToInt(sellist[0].ToString()));
                
        //    //}
        //}
        private void SaveSelect()
        {
            //try
            //{
            string SelectIDList = Common.Session.GetSession("SelectIDList");
            if (!String.IsNullOrEmpty(SelectIDList))
            {
                //List<string> SelectList = (List<string>)Session["SelectList"];                    
                BLL.T_CellTmp_BLL bll1 = new DigiPower.Onlinecol.Standard.BLL.T_CellTmp_BLL();
                BLL.T_FileListTmp_CellRptTmp_BLL bll2 = new DigiPower.Onlinecol.Standard.BLL.T_FileListTmp_CellRptTmp_BLL();
                foreach (string CellReportID in SelectIDList.Split(','))
                {
                    if (CellReportID != "" && !bll2.Exists("recID=" + ID + " AND CellFilePath='" + CellReportID + "'"))
                    {
                        Model.T_CellTmp_MDL mdl = bll1.GetModel(Common.ConvertEx.ToInt(CellReportID));
                        if (mdl != null)
                        {
                            Model.T_FileListTmp_CellRptTmp_MDL mdl2 = new DigiPower.Onlinecol.Standard.Model.T_FileListTmp_CellRptTmp_MDL();
                            mdl2.CellFilePath = CellReportID;
                            mdl2.recID = Common.ConvertEx.ToInt(ID);
                            mdl2.Title = mdl.Title;
                            mdl2.OrderIndex = Common.ConvertEx.ToInt(mdl.OrderIndex);                            
                            bll2.Add(mdl2);
                        }
                    }
                }
                Session["SelectIDList"] = null;
            }
            //}
            //catch { Session["SelectIDList"] = null; }
        }

        ///// <summary>
        ///// 编辑
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void btnModify_Click(object sender, EventArgs e)
        //{
        //    if (ctrlGridEx1.GetSelects().Count > 0)
        //    {
        //        Response.Redirect("ArchiveCellReportAdd.aspx?Action=edit&ID=" + ctrlGridEx1.GetSelects()[0] + "&recid=" + ID + "&sqlwhere=" + ViewState["sqlwhere"] + "&PageIndex=" + ctrlGridEx1.PageIndex + "");
        //    }
        //}

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DigiPower.Onlinecol.Standard.BLL.T_FileListTmp_CellRptTmp_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_FileListTmp_CellRptTmp_BLL();
            int iSelectCount = ctrlGridEx1.GetSelects().Count;
            if (iSelectCount > 0)
            {
                for (int i = 0; i < iSelectCount; i++)
                {
                    bll.Delete(Convert.ToInt32(ctrlGridEx1.GetSelects()[i]));
                }
                this.BindGridView(ID);
            }
        }
       
        #region 方法

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindGridView(string id)
        {
            BLL.T_FileListTmp_CellRptTmp_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_FileListTmp_CellRptTmp_BLL();
            DataSet ds = new DataSet();

            //if (ViewState["sqlwhere"] != null && !String.IsNullOrEmpty(ViewState["sqlwhere"].ToString()))
            //{
            //    ds = bll.GetList(ViewState["sqlwhere"].ToString());
            //}
            //else if(!String.IsNullOrEmpty(SqlWhere))
            //{
            //    ds = bll.GetList(SqlWhere);
            //}
            //else
            //{
            //    ds = bll.GetList("1=1");
            //}
            ds = bll.GetList("recid=" + ID);

            List<string> l1 = new List<string>();

            l1.Add("title");            
            //l1.Add("CellFilePath");
            //l1.Add("templatetitle");
            //l1.Add("OrderIndex");

            //ctrlGridEx1.PageCount = Common.ConvertEx.ToInt(Common.Session.GetSession("PageCount"));
            ctrlGridEx1.InitGrid("CellReportID", l1, ds, "~/SystemManage/ArchiveCellReportAdd.aspx?Action=edit&recid=" + id);
        }

        #endregion

        protected void Linkbutton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("FileListTmpList.aspx");
        }
    }
}
