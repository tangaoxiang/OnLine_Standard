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
using System.Text;

namespace DigiPower.Onlinecol.Standard.Web.File
{
    public partial class ImageFileInfoList : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MyAddInit();
            if (!IsPostBack)
            {
                if ((CommonEnum.PageState)ViewState["ps"] == CommonEnum.PageState.VIEW)
                    btnSave.Visible = false;

                if (!String.IsNullOrEmpty(ID))
                {
                    BindPage(ID);
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DigiPower.Onlinecol.Standard.BLL.T_FileList_BLL documentbll = new DigiPower.Onlinecol.Standard.BLL.T_FileList_BLL();
            DigiPower.Onlinecol.Standard.Model.T_FileList_MDL model = documentbll.GetModel(Common.ConvertEx.ToInt(ID));
            model = (Model.T_FileList_MDL)Comm.GetValueToObject(model, tbl);
            if (model != null)
            {
                model.qssj = DateTime.Now;
                model.zzsj = DateTime.Now;
                model.lrsj = DateTime.Now;
                model.shsj_1 = DateTime.Now;
                model.shsj_2 = DateTime.Now;
                model.shsj_3 = DateTime.Now;
                model.aipdate = DateTime.Now;
                //model.pssj = DateTime.Now;
                model.CreateDate = DateTime.Now;
                documentbll.Update(model);

            }
            Common.MessageBox.CloseLayerOpenWeb(this.Page);
        }

        /// <summary>
        /// 绑定页面
        /// </summary>
        /// <param name="ID"></param>
        private void BindPage(string ID)
        {
            Model.T_FileList_MDL model = new DigiPower.Onlinecol.Standard.Model.T_FileList_MDL();
            BLL.T_FileList_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_FileList_BLL();
            model = bll.GetModel(Convert.ToInt32(ID));
            if (model != null)
            {
                DigiPower.Onlinecol.Standard.Web.Comm.SetValueToPage(model, this.tbl);
            }
        }
    }
}

















