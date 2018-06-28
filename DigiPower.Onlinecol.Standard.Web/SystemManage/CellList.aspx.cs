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

namespace DigiPower.Onlinecol.Standard.Web.SystemManage
{
    public partial class CellList : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PID.DataBindEx();
                this.btnDelete.Attributes.Add("onclick", "javascript:return confirm('你确认要删除吗?')");
            }
            BindGridView();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("CellListAdd.aspx?Action=add&ID=0&sqlwhere = " + SqlWhere + "");
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DigiPower.Onlinecol.Standard.BLL.T_CellTmp_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_CellTmp_BLL();

            if (ctrlGridEx1.GetSelects().Count > 0)
            {
                for (int i = 0; i < ctrlGridEx1.GetSelects().Count; i++)
                {
                    bll.Delete(Convert.ToInt32(ctrlGridEx1.GetSelects()[i]));
                }
            }
            this.BindGridView();
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
                l1.Add("OrderIndex");
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
    }
}
