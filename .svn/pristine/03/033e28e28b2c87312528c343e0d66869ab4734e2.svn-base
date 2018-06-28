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

namespace DigiPower.Onlinecol.Standard.Web.ArchiveManage
{
    public partial class ArchiveToUserMod : PageBase
    {
        BLL.T_FileList_BLL bll = new T_FileList_BLL();
        string SingleProjectID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            HidSingleProjectID.Value = Common.DNTRequest.GetQueryString("SingleProjectID");
            if (!IsPostBack)
            {
                SingleProjectID = HidSingleProjectID.Value;
                DefaultCompanyType.DataBindEx(true);
                SingleProjectUsers.DataBindEx(Common.ConvertEx.ToInt(SingleProjectID));
                ctrlDropDownFileList.DataBindEx(Common.ConvertEx.ToInt(SingleProjectID), "0");
            }

            BindGridView();
        }

        /// <summary>
        /// 绑定单位下所有工程
        /// </summary>
        /// <param name="SingleProjectID"></param>
        protected void BindGridView()
        {
            DataSet ds = new DataSet();
            SingleProjectID = HidSingleProjectID.Value;

            string strWhere = "SingleProjectID='" + SingleProjectID + "'";
            ds = bll.GetList(strWhere);

            if (ds.Tables.Count > 0)
            {
                strWhere = "1=1";

                DataTable outDT = ds.Tables[0].Copy();
                outDT.Clear();
                Recursion(ds.Tables[0], 0, 0, ref outDT);
                ds.Tables.Clear();
                ds.Tables.Add(outDT);

                if (ctrlTextBoxEx1.Text != "")
                {
                    strWhere += " AND Title like '%" + ctrlTextBoxEx1.Text + "%'";
                }
                if (DefaultCompanyType.SelectValue != "0")
                {
                    strWhere += " AND DefaultCompanyType=" + DefaultCompanyType.SelectValue + " ";
                }
                if (ctrlDropDownFileList.SelectValue != "0")
                {
                    strWhere += " AND PID=" + ctrlDropDownFileList.SelectValue + "";
                }

                DataSet dsarchive = new DataSet();
                if (strWhere != "1=1")
                {
                    //过滤一些不要的
                    DataView dv = ds.Tables[0].Copy().DefaultView;
                    dv.RowFilter = strWhere;
                    if (dv.Count != ds.Tables[0].Rows.Count)
                    {
                        ds.Tables[0].Clear();
                        ds.Tables.RemoveAt(0);
                        ds.Tables.Add(dv.ToTable());
                    }
                }

                List<string> li = new List<string>();
                li.Add("BH");
                li.Add("title");
                li.Add("OperateUserName");
                li.Add("zrr");
                //ctrlGridEx1.PageCount = Common.ConvertEx.ToInt(Common.Session.GetSession("PageCount")) - 3;
                ctrlGridEx1.InitGrid("FileListID", li, ds, "");
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
                Recursion(dt, Int32.Parse(drr["recid"].ToString()), NewLevelID, ref outDT);
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int OperateUserID = Common.ConvertEx.ToInt(SingleProjectUsers.SelectValue);
            string OperateUserName = SingleProjectUsers.SelectText;
            List<String> ltKey = ctrlGridEx1.GetSelects();

            if (OperateUserID > 0 && ltKey.Count > 0)
            {
                foreach (string Key in ltKey)
                {
                    T_FileList_MDL Mdl = bll.GetModel(Common.ConvertEx.ToInt(Key));
                    if (Mdl != null)
                    {
                        Mdl.OperateUserID = OperateUserID;
                        Mdl.OperateUserName = OperateUserName;
                        bll.Update(Mdl);
                    }
                }
                BindGridView();
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGridView();
        }
    }
}
