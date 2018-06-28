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
    public partial class ArchiveCellReportAdd : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MyAddInit();

            if (!IsPostBack)
            {
                recid.DataBindEx();
                if (!String.IsNullOrEmpty(Action) && Action.ToLower().Equals("edit"))
                {
                    if (!String.IsNullOrEmpty(ID))
                    {
                        BindPage(ID);
                    }
                }
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Model.T_FileListTmp_CellRptTmp_MDL model = new DigiPower.Onlinecol.Standard.Model.T_FileListTmp_CellRptTmp_MDL();
            BLL.T_FileListTmp_CellRptTmp_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_FileListTmp_CellRptTmp_BLL();

            if (Convert.ToInt32(ID) != 0)
            {
                model = bll.GetModel(Convert.ToInt32(ID));
            }
            model = (Model.T_FileListTmp_CellRptTmp_MDL)Comm.GetValueToObject(model, this.tbl);
            if (Convert.ToInt32(ID) == 0)
            {
                ID = bll.Add(model).ToString();
            }
            else
            {
                bll.Update(model);
            }

            Response.Redirect("ArchiveCellReportList.aspx?sqlwhere=" + SqlWhere + "&PageIndex=" + pPageIndex + "&ID=" + Common.DNTRequest.GetString("recid"));
        }

        /// <summary>
        /// 绑定页面
        /// </summary>
        /// <param name="ID"></param>
        private void BindPage(string ID)
        {
            Model.T_FileListTmp_CellRptTmp_MDL model = new DigiPower.Onlinecol.Standard.Model.T_FileListTmp_CellRptTmp_MDL();
            BLL.T_FileListTmp_CellRptTmp_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_FileListTmp_CellRptTmp_BLL();
            model = bll.GetModel(Convert.ToInt32(ID));
            if (model != null)
            {
                DigiPower.Onlinecol.Standard.Web.Comm.SetValueToPage(model, this.tbl);
            }
        }
    }
}