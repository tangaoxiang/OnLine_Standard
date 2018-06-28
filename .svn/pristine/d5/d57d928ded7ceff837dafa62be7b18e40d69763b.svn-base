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

namespace DigiPower.Onlinecol.Standard.Web.File
{
    public partial class UpLoadFileAdd : PageBase
    {
        #region 属性及构造函数

        string FileListID = null;

        string ProNo = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            MyAddInit();
            FileListID = Request.QueryString["FileListID"];
            ProNo = Request.QueryString["ProNo"];
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(ID))
                {
                    BindPage(ID);
                }
            }
        }

        #endregion

        #region 事件

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            BLL.T_EFile_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_EFile_BLL();
            Model.T_EFile_MDL model = bll.GetModel(Common.ConvertEx.ToInt(ID));

            model = (Model.T_EFile_MDL)Comm.GetValueToObject(model, this.tbl);

            if (model != null && !String.IsNullOrEmpty(ID))
            {
                model.ArchiveListCellRptID = Convert.ToInt32(ID);
                model.FileListID = Common.ConvertEx.ToInt(FileListID);
                bll.Update(model);

                if (Common.DNTRequest.GetQueryString("SuppleMent") == "")
                {
                    //更新状态
                    BLL.T_Other_BLL otherBLL = new DigiPower.Onlinecol.Standard.BLL.T_Other_BLL();
                    otherBLL.UpdateArchiveStatus(model.FileListID.ToString(), 10, "0");
                }
            }

            if (Common.DNTRequest.GetQueryString("SuppleMent") == "SuppleMent")  //表明是由案卷补录管理 页面过来
                Response.Redirect("../SuppleMent/SmUpLoadEFileList.aspx?ID=" + FileListID + "&SuppleMent=SuppleMent");
            else
                Response.Redirect("UpLoadEFileList.aspx?sqlwhere=" + SqlWhere + "&PageIndex=" + pPageIndex + "&ID=" + FileListID + "&ProNo=" + ProNo + "");

        }

        #endregion

        #region 方法

        /// <summary>
        /// 绑定页面
        /// </summary>
        /// <param name="ID"></param>
        private void BindPage(string ID)
        {
            Model.T_EFile_MDL model = new DigiPower.Onlinecol.Standard.Model.T_EFile_MDL();

            BLL.T_EFile_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_EFile_BLL();

            model = bll.GetModel(Convert.ToInt32(ID));

            if (model != null)
            {
                DigiPower.Onlinecol.Standard.Web.Comm.SetValueToPage(model, this.tbl);
            }
        }

        #endregion
    }
}
