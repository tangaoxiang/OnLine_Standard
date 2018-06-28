using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Reflection;
using DigiPower.Onlinecol.Standard.Common;

namespace DigiPower.Onlinecol.Standard.Web.SystemManage
{
    public partial class CellListAdd : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MyAddInit();
            if (!IsPostBack)
            {
                InitComboxParent();
                if (!String.IsNullOrEmpty(Action) && Action.ToLower().Equals("edit"))
                {
                    if (!String.IsNullOrEmpty(ID))
                    {
                        BindPage(ID);
                    }
                }
            }
        }

        private void InitComboxParent()
        {
            BLL.T_CellTmp_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_CellTmp_BLL();
            DataSet ds = new DataSet();
            ds = bll.GetList("");
            if (ds.Tables.Count > 0)
            {
                DataTable outDT = ds.Tables[0].Copy();
                outDT.Clear();
                Recursion(ds.Tables[0], 0, 0, ref outDT);

                DataRow newRow = outDT.NewRow();
                newRow["CellID"] = "0";
                newRow["Title"] = "无父类";
                outDT.Rows.InsertAt(newRow, 0);

                PID.DataTextField = "Title";
                PID.DataValueField = "CellID";
                PID.DataSource = outDT;
                PID.DataBind();
            }
        }

        public void Recursion(DataTable dt, int PID, int LevelID, ref DataTable outDT)
        {
            DataRow[] dr = dt.Select("PID='" + PID + "'");
            foreach (DataRow drr in dr)
            {
                drr["title"] = Comm.AddEmpty(drr["title"].ToString(), LevelID);
                outDT.Rows.Add(drr.ItemArray);

                int NewLevelID = LevelID + 1;
                Recursion(dt, Int32.Parse(drr["CellID"].ToString()), NewLevelID, ref outDT);
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Model.T_CellTmp_MDL model = new DigiPower.Onlinecol.Standard.Model.T_CellTmp_MDL();
            BLL.T_CellTmp_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_CellTmp_BLL();

            if (Convert.ToInt32(ID) != 0)
            {
                model = bll.GetModel(Convert.ToInt32(ID));
            }
            model = (Model.T_CellTmp_MDL)Comm.GetValueToObject(model, this.tbl);

            string UploadFileNameResult = UploadCellFile();
            if (UploadFileNameResult != "")
            {
                model.FilePath = UploadFileNameResult;
            }

            if (Convert.ToInt32(ID) == 0)
            {
                ID = bll.Add(model).ToString();
            }
            else
            {
                bll.Update(model);
            }
            Response.Redirect("CellList.aspx?sqlwhere=" + SqlWhere + "&PageIndex=" + pPageIndex + "");
        }

        private string UploadCellFile()
        {
            if (UploadFile.FileName != "")
            {
                //string saveDir = @"\CellTmp\";
                string saveDir = @"\Upload\CellTmp\";
                string appPath = Request.PhysicalApplicationPath;
                string savepath = appPath + saveDir + UploadFile.FileName;
                try
                {
                    UploadFile.SaveAs(savepath);
                    return saveDir + UploadFile.FileName; ;
                }
                catch
                {
                    return "";
                }
            }
            return "";
        }

        /// <summary>
        /// 绑定页面
        /// </summary>
        /// <param name="ID"></param>
        private void BindPage(string ID)
        {
            Model.T_CellTmp_MDL model = new DigiPower.Onlinecol.Standard.Model.T_CellTmp_MDL();

            BLL.T_CellTmp_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_CellTmp_BLL();

            model = bll.GetModel(Convert.ToInt32(ID));
            DigiPower.Onlinecol.Standard.Web.Comm.SetValueToPage(model, this.tbl);
            if (model != null)
            {
                FilePath.Text = model.FilePath;
            }
        }

        protected void PID_SelectedIndexChanged(object sender, EventArgs e)
        {
            BLL.T_CellTmp_BLL docBLL = new DigiPower.Onlinecol.Standard.BLL.T_CellTmp_BLL();
            Model.T_CellTmp_MDL docMDL = docBLL.GetModel(Common.ConvertEx.ToInt(PID.SelectedValue));
            if (docMDL != null)
            {
                PID_Show.Text = docMDL.MyCode;
            }
        }
    }
}