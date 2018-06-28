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

namespace DigiPower.Onlinecol.Standard.Web.SystemManage {
    public partial class SystemAdd : PageBase {
        protected void Page_Load(object sender, EventArgs e) {
            MyAddInit();
            if (!this.IsPostBack) {
                if ((CommonEnum.PageState)ViewState["ps"] == CommonEnum.PageState.VIEW)
                    btnSave.Visible = false;

                BindPage(ID);
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e) {
            Model.T_SystemInfo_MDL model = new DigiPower.Onlinecol.Standard.Model.T_SystemInfo_MDL();
            if (ViewState["model"] != null)
                model = (Model.T_SystemInfo_MDL)ViewState["model"];

            BLL.T_SystemInfo_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_SystemInfo_BLL();

            object obj = Comm.GetValueToObject(model, this.tbl);

            if (obj != null) {
                Model.T_SystemInfo_MDL Newmodel = (Model.T_SystemInfo_MDL)obj;

                switch ((CommonEnum.PageState)ViewState["ps"]) {
                    case CommonEnum.PageState.ADD:
                        int systemInfoID = bll.Add(Newmodel);

                        PublicModel.writeLog(SystemSet.EumLogType.AddData.ToString(), string.Concat("T_SystemInfo;key=", systemInfoID,
                            ";CurrentType=", Newmodel.CurrentType, ";SystemInfoCode=", Newmodel.SystemInfoCode, ";SystemInfoName=", Newmodel.SystemInfoName));
                        break;
                    case CommonEnum.PageState.EDIT: {
                            bll.Update(Newmodel);

                            PublicModel.writeLog(SystemSet.EumLogType.UpdData.ToString(), string.Concat("T_SystemInfo;key=", Newmodel.SystemInfoID,
                              ";CurrentType=", Newmodel.CurrentType, ";SystemInfoCode=", Newmodel.SystemInfoCode, ";SystemInfoName=", Newmodel.SystemInfoName));
                        }
                        break;
                }
            }

            Common.MessageBox.CloseLayerOpenWeb(this.Page);
        }

        /// <summary>
        /// 绑定页面
        /// </summary>
        /// <param name="ID"></param>
        private void BindPage(string ID) {
            if (!String.IsNullOrWhiteSpace(ID)) {
                Model.T_SystemInfo_MDL model = new DigiPower.Onlinecol.Standard.Model.T_SystemInfo_MDL();
                BLL.T_SystemInfo_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_SystemInfo_BLL();
                model = bll.GetModel(Convert.ToInt32(ID));

                if (model != null) {
                    ViewState["model"] = model;
                    Comm.SetValueToPage(model, this.tbl);
                }
            }
        }
    }
}
