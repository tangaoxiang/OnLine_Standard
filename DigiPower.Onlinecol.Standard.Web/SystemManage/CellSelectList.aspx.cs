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
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Common;

namespace DigiPower.Onlinecol.Standard.Web.SystemManage
{
    public partial class CellSelectList : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGridView();
            //if (!IsPostBack)
            //{
            //    try
            //    {
            //        HiddenField1.Value = Request.QueryString["fromUrl"];
            //    }
            //    catch { }
            //}
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //Response.Redirect("CellListAdd.aspx?Action=add&ID=0&sqlwhere = " + SqlWhere + "");
            BLL.T_CellTmp_BLL bll1 = new DigiPower.Onlinecol.Standard.BLL.T_CellTmp_BLL();
            //BLL.T_FileListTmp_CellRptTmp_BLL bll2 = new DigiPower.Onlinecol.Standard.BLL.T_FileListTmp_CellRptTmp_BLL();
            List<string> SelectList = ctrlGridEx1.GetSelects();
            //Session["SelectList"] = SelectList;
            string SelectIDList = "";
            foreach (string CellReportID in SelectList)
            {
                Model.T_CellTmp_MDL mdl = bll1.GetModel(Common.ConvertEx.ToInt(CellReportID));
                if (mdl.IsFolder == false)//只能选文件，不能选目录
                {
                    SelectIDList += CellReportID + ",";
                }
            }
            Session["SelectIDList"] = SelectIDList;
            //Response.Redirect(HiddenField1.Value);
            Response.Write("<script>window.opener.location.reload();window.close();</script>");
            //Response.Redirect("ArchiveCellReportList.aspx?ID=" + ID + "&sqlwhere = " + SqlWhere + "");            
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindGridView()
        {
            BLL.T_CellTmp_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_CellTmp_BLL();
            DataSet ds = new DataSet();
            ds = bll.GetList("");
            if (ds.Tables.Count > 0)
            {
                DataTable outDT = ds.Tables[0].Copy();
                outDT.Clear();
                Recursion(ds.Tables[0], 0, 0, ref outDT);
                ds.Tables.Clear();
                ds.Tables.Add(outDT);

                if (ViewState["sqlwhere"] != null && !String.IsNullOrEmpty(ViewState["sqlwhere"].ToString()))
                {
                    if (ds.Tables.Count > 0)
                    {
                        DataView dv = ds.Tables[0].Copy().DefaultView;
                        dv.RowFilter = ViewState["sqlwhere"].ToString();
                        if (dv.Count != ds.Tables[0].Rows.Count)
                        {
                            ds.Tables[0].Clear();
                            ds.Tables.RemoveAt(0);
                            ds.Tables.Add(dv.ToTable());
                        }
                    }
                }

                List<string> l1 = new List<string>();
                l1.Add("Title");
                l1.Add("FilePath");
                //l1.Add("JS");
                //l1.Add("SG");
                //l1.Add("SJ");
                //l1.Add("JL");
                //l1.Add("NeedArchive");
                //l1.Add("IsFolder");
                //l1.Add("archive_form_name");
                //l1.Add("OrderIndex");

                //ctrlGridEx1.PageCount = Common.ConvertEx.ToInt(Common.Session.GetSession("PageCount"));
                ctrlGridEx1.InitGrid("CellID", l1, ds, "~/SystemManage/CellListAdd.aspx?Action=edit");
            }
        }

        public void Recursion(DataTable dt, int PID, int LevelID, ref DataTable outDT)
        {
            DataRow[] dr = dt.Select("PID='" + PID + "'", "OrderIndex");
            foreach (DataRow drr in dr)
            {
                drr["title"] = Comm.AddEmpty(drr["title"].ToString(), LevelID);
                outDT.Rows.Add(drr.ItemArray);

                int NewLevelID = LevelID + 1;
                Recursion(dt, Int32.Parse(drr["CellID"].ToString()), NewLevelID, ref outDT);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Model.T_CellTmp_MDL model = new DigiPower.Onlinecol.Standard.Model.T_CellTmp_MDL();
            Search(this.tblSearch, model);
            this.BindGridView();
        }

        protected void btnAdd002_Click(object sender, EventArgs e)
        {
            string selectList = ctrlGridEx1.GetFirstSelect();
            if (selectList != "")
            {
                T_CellTmp_MDL mdl = new T_CellTmp_BLL().GetModel(Convert.ToInt32(selectList));
                if (mdl.FilePath.Length > 0)
                    //Response.Write("<script>window.open(\"/File/LookCell.aspx?Action=Show&ProNo=10&ID=" + selectList + "\",\"\",\"width=800,height=600,left=150,top=100,menubar=no,toolbar=no,status=no,resizable=yes,scrollbars=yes,location=yes\");</script>");
                    MessageBox.OpenWindow(Page, "/File/LookCell.aspx?Action=Show&ProNo=10&ID=" + selectList + "", "600", "800");
                else
                    MessageBox.Show(Page, "你选的条目没有施工用表!");
            }
        }
    }
}