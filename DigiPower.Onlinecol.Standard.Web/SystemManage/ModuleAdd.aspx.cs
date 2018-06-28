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

//模块新增/修改

namespace DigiPower.Onlinecol.Standard.Web.SystemManage {
    public partial class ModuleAdd : PageBase {
        protected void Page_Load(object sender, EventArgs e) {
            MyAddInit();
            if (!this.IsPostBack) {
                chkMenuRight.DataBindEx(SystemSet._MENURIGHTCHAR);
                ParentID.DataBindEx();
                if ((CommonEnum.PageState)ViewState["ps"] == CommonEnum.PageState.VIEW) {
                    btnSave.Visible = false;
                }
                BindPage(ID);
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e) {
            BLL.T_Module_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_Module_BLL();
            Model.T_Module_MDL Newmodel = bll.GetModel(Common.ConvertEx.ToInt(ID));
            if (Newmodel == null)
                Newmodel = new DigiPower.Onlinecol.Standard.Model.T_Module_MDL();
            Newmodel = (Model.T_Module_MDL)Comm.GetValueToObject(Newmodel, this.tbl);
            Newmodel.RightListID = chkMenuRight.getSelectValue;
            if (Newmodel != null) {
                switch ((CommonEnum.PageState)ViewState["ps"]) {
                    case CommonEnum.PageState.ADD:
                        int moduleID = bll.Add(Newmodel);
                        PublicModel.writeLog(SystemSet.EumLogType.AddData.ToString(), string.Concat("T_Module;key=", moduleID,
                            ";ModuleName=", Newmodel.ModuleName, ";BH=", Newmodel.BH));
                        break;
                    case CommonEnum.PageState.EDIT:
                        bll.Update(Newmodel);
                        PublicModel.writeLog(SystemSet.EumLogType.UpdData.ToString(), string.Concat("T_Module;key=", Newmodel.ModuleID,
                            ";ModuleName=", Newmodel.ModuleName, ";BH=", Newmodel.BH));
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
            Model.T_Module_MDL model = new DigiPower.Onlinecol.Standard.Model.T_Module_MDL();
            BLL.T_Module_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_Module_BLL();
            model = bll.GetModel(Convert.ToInt32(ID));
            if (model != null) {
                DigiPower.Onlinecol.Standard.Web.Comm.SetValueToPage(model, this.tbl);
                chkMenuRight.setSelectValue = model.RightListID;
            }
        }
    }
}
