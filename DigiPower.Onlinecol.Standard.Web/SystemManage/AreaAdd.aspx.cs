﻿using System;
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
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.DAL;

namespace DigiPower.Onlinecol.Standard.Web.SystemManage {
    public partial class AreaAdd : PageBase {
        T_Area_BLL areaBLL = new T_Area_BLL();

        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(AreaAdd));
            MyAddInit();
            if (!IsPostBack) {
                PID.BindDblArea(false, "", "AreaID");
                if ((CommonEnum.PageState)ViewState["ps"] == CommonEnum.PageState.VIEW)
                    btnSave.Visible = false;

                if ((CommonEnum.PageState)ViewState["ps"] == CommonEnum.PageState.EDIT)
                    area_code.enabled = false;

                BindPage(ID);
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e) {
            Model.T_Area_MDL model = new DigiPower.Onlinecol.Standard.Model.T_Area_MDL();
            if (ViewState["model"] != null)
                model = (Model.T_Area_MDL)ViewState["model"];
            object obj = Comm.GetValueToObject(model, this.tbl);

            if (obj != null) {
                Model.T_Area_MDL Newmodel = (Model.T_Area_MDL)obj;

                switch ((CommonEnum.PageState)ViewState["ps"]) {
                    case CommonEnum.PageState.ADD: {
                            int areaID = areaBLL.Add(Newmodel);
                            PublicModel.writeLog(SystemSet.EumLogType.AddData.ToString(), string.Concat("T_Area;key=", areaID,
                                 ";area_code=", Newmodel.area_code, ";area_name=", Newmodel.area_name));
                            break;
                        }
                    case CommonEnum.PageState.EDIT: {
                            Newmodel.AreaID = Convert.ToInt32(ID);
                            areaBLL.Update(Newmodel);

                            PublicModel.writeLog(SystemSet.EumLogType.UpdData.ToString(), string.Concat("T_Area;key=", Newmodel.AreaID,
                                ";area_code=", Newmodel.area_code, ";area_name=", Newmodel.area_name));
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
            Model.T_Area_MDL model = new DigiPower.Onlinecol.Standard.Model.T_Area_MDL();
            model = areaBLL.GetModel(Convert.ToInt32(ID));

            if (model != null) {
                ViewState["model"] = model;
                DigiPower.Onlinecol.Standard.Web.Comm.SetValueToPage(model, this.tbl);
                PID.SelectValue = model.PID.ToString();
            }
        }

        /// <summary>
        /// 判断机构代码是否存在
        /// </summary>
        /// <param name="Action">编辑模式,新增或删除</param>
        /// <param name="UserID">机构代号</param>
        /// <param name="LoginName">机构ID</param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public bool ExistsAreaCode(string Action, int AreaCode, int AreaID) {
            bool resultCheck = false;
            try {
                if (Action == CommonEnum.PageState.ADD.ToString().ToLower())
                    AreaID = 0;

                if (!String.IsNullOrWhiteSpace(Action)) {
                    if (areaBLL.Exists(AreaCode, AreaID)) {
                        resultCheck = true;
                    }
                }
            } catch (Exception ex) {
                Common.LogUtil.Debug(this, "判断机构代码是否存在失败", ex);
            }
            return resultCheck;
        }
    }
}