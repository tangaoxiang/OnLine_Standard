﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using DigiPower.Onlinecol.Standard.BLL;

//用户添加/修改

namespace DigiPower.Onlinecol.Standard.Web.SystemManage {
    public partial class CompanyUserAdd : PageBase {
        T_UsersInfo_BLL userBLL = new T_UsersInfo_BLL();

        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(CompanyUserAdd));
            MyAddInit();
            if (!this.IsPostBack) {
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
            Model.T_UsersInfo_MDL model = new DigiPower.Onlinecol.Standard.Model.T_UsersInfo_MDL();
            if (ViewState["model"] != null)
                model = (Model.T_UsersInfo_MDL)ViewState["model"];

            object obj = Comm.GetValueToObject(model, this.tbl);
            if (obj != null) {
                Model.T_UsersInfo_MDL Newmodel = (Model.T_UsersInfo_MDL)obj;
                Newmodel.Passwd = DESEncrypt.Encrypt(Passwd.Text);                                 //密码加密
                Newmodel.Createdate = System.DateTime.Now;                                         //创建时间或最后修改时间
                Newmodel.Createdby = Common.Session.GetSession("UserName");                        //创建者或最后修改者
                Newmodel.UserType = SystemSet.EumUserType.CompanyUser.ToString();                  //默认为公司用户 

                switch ((CommonEnum.PageState)ViewState["ps"]) {
                    case CommonEnum.PageState.EDIT:
                        Model.T_UsersInfo_MDL tempObj = userBLL.GetModel(Newmodel.UserID);
                        userBLL.Update(Newmodel);

                        PublicModel.writeLog(SystemSet.EumLogType.UpdData.ToString(), string.Concat("T_UsersInfo;key=", tempObj.UserID,
                           ";UserType=", tempObj.UserType, ";CompanyID=", tempObj.CompanyID, ";UserName=", tempObj.UserName, ";LoginName=", tempObj.LoginName, ";UserType=", tempObj.UserType));

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
                Model.T_UsersInfo_MDL model = new DigiPower.Onlinecol.Standard.Model.T_UsersInfo_MDL();
                model = userBLL.GetModel(Convert.ToInt32(ID));
                if (model != null) {
                    ViewState["model"] = model;
                    object obj = DigiPower.Onlinecol.Standard.Web.Comm.SetValueToPage(model, this.tbl);
                    Passwd.Attributes("value", DESEncrypt.Decrypt(model.Passwd));

                    if (model.CompanyID > 0) {
                        Model.T_Company_MDL companyMDL = new T_Company_BLL().GetModel(model.CompanyID);
                        if (companyMDL != null) {
                            txtCompanyName.Text = companyMDL.CompanyName;
                        }
                    }
                    if (model.RoleID > 0) {
                        Model.T_Role_MDL roleMDL = new T_Role_BLL().GetModel(model.RoleID);
                        if (roleMDL != null) {
                            txtRoleName.Text = roleMDL.RoleName;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 判断登陆账号是否存在
        /// </summary>
        /// <param name="Action">编辑模式,新增或删除</param>
        /// <param name="UserID">用户ID</param>
        /// <param name="LoginName">账号ID</param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public bool CheckLoginName(string Action, int UserID, string LoginName) {
            bool resultCheck = false;
            try {
                if (Action == CommonEnum.PageState.ADD.ToString().ToLower())
                    UserID = 0;

                if (!String.IsNullOrWhiteSpace(Action) && !String.IsNullOrWhiteSpace(LoginName)) {
                    if (userBLL.Exists("lower(LoginName)='" + LoginName.Trim().ToLower() + "' and UserID!=" + UserID + " ")) {
                        resultCheck = true;
                    }
                }
            } catch (Exception ex) {
                Common.LogUtil.Debug(this, "判断登陆账号是否存在失败", ex);
            }
            return resultCheck;
        }

        /// <summary>
        /// 判断密码是否合法(字母和数组组成)
        /// </summary>                             
        /// <param name="Pwd">账号ID</param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public bool CheckPassword(string Pwd) {
            return PublicModel.CheckAccountOrPwdValidity(Pwd);
        }

    }
}
