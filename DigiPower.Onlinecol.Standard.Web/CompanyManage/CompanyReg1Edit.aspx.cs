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
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.Model;
using System.Collections.Generic;
using DigiPower.Onlinecol.Standard.CBLL;

//公司新增/编辑

namespace DigiPower.Onlinecol.Standard.Web.SystemManage {
    public partial class CompanyReg1Edit : PageBase {
        T_Role_BLL roleBLL = new T_Role_BLL();
        T_UsersInfo_BLL userBLL = new T_UsersInfo_BLL();
        T_Company_BLL companyBLL = new T_Company_BLL();
        int CompanyType = 0;

        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(CompanyReg1Edit));
            MyAddInit();

            CompanyType = DNTRequest.GetQueryInt("CompanyType", 0);

            if (!this.IsPostBack) {
                if ((CommonEnum.PageState)ViewState["ps"] == CommonEnum.PageState.VIEW)
                    btnSave.Visible = false;

                ctrlCompanyBaseInfo1.DataBindEx(ConvertEx.ToInt(ID));
                ctrlCompanyBaseInfo1.SetCompanyTypeEnable(false);
                ctrlCompanyBaseInfo1.CompanyTypeID = CompanyType.ToString();
                ctrlCompanyBaseInfo1.SetAreaCodeEnable(false);

                if ((CommonEnum.PageState)ViewState["ps"] == CommonEnum.PageState.EDIT) {
                    List<T_UsersInfo_MDL> ltUserInfo = new T_UsersInfo_BLL().GetModelList("CompanyID=" + ID);
                    if (ltUserInfo.Count > 0) {
                        HidUserID.Value = ConvertEx.ToString(ltUserInfo[0].UserID);
                        txtLogName.Text = ltUserInfo[0].LoginName;
                        txtLogName.enabled = false;
                        txtPwd.Attributes("value", DESEncrypt.Decrypt(ltUserInfo[0].Passwd));
                        txtPwd2.Attributes("value", DESEncrypt.Decrypt(ltUserInfo[0].Passwd));
                        ViewState["UserID"] = ConvertEx.ToString(ltUserInfo[0].UserID);
                    }
                }
            }
        }

        /// <summary>
        /// 判断统一社会信用代码是否唯一
        /// </summary>
        /// <param name="Action">编辑模式,新增或删除</param>
        /// <param name="CompanyID">公司ID</param>
        /// <param name="CompanyCode">统一社会信用代码</param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public bool CheckCompanyCode(string Action, int CompanyID, string CompanyCode) {
            bool resultCheck = false;
            try {
                if (Action == CommonEnum.PageState.ADD.ToString().ToLower())
                    CompanyID = 0;

                if (!String.IsNullOrWhiteSpace(Action) && !String.IsNullOrWhiteSpace(CompanyCode)) {
                    if (companyBLL.Exists("lower(CompanyCode)='" + CompanyCode.Trim().ToLower() + "' and CompanyID!=" + CompanyID + " ")) {
                        resultCheck = true;
                    }
                }
            } catch (Exception ex) {
                Common.LogUtil.Debug(this, "判断统一社会信用代码是否唯一失败", ex);
            }
            return resultCheck;
        }

        /// <summary>
        /// 判断email是否存在,工程报建确认发邮件通知,登录密码找回用
        /// </summary>
        /// <param name="Action">编辑模式,新增或删除</param>
        /// <param name="CompanyID">公司ID</param>
        /// <param name="EMail">EMail</param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public bool CheckCompanyEmail(string Action, int CompanyID, string EMail) {
            bool resultCheck = false;
            try {
                if (Action == CommonEnum.PageState.ADD.ToString().ToLower())
                    CompanyID = 0;

                if (!String.IsNullOrWhiteSpace(Action) && !String.IsNullOrWhiteSpace(EMail)) {
                    if (companyBLL.Exists("lower(EMail)='" + EMail.Trim().ToLower() + "' and CompanyID!=" + CompanyID + " ")) {
                        resultCheck = true;
                    }
                }
            } catch (Exception ex) {
                Common.LogUtil.Debug(this, "判断email是否存在失败", ex);
            }
            return resultCheck;
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

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e) {
            T_Company_MDL model = new T_Company_MDL();
            if ((CommonEnum.PageState)ViewState["ps"] == CommonEnum.PageState.ADD) {
                model = ctrlCompanyBaseInfo1.GetModule(0);
                if (model != null) {
                    if (ConvertEx.ToInt(ctrlCompanyBaseInfo1.CompanyTypeID) == SystemSet._ARCHIVE)
                        model.IsCompany = false;                                    //这是档案馆，不是建设等单位
                    else
                        model.IsCompany = true;

                    model.CreateDate = System.DateTime.Now;
                    model.CreateIP = DNTRequest.GetIP();
                    model.CreateUserID = Common.Session.GetSessionInt("UserID");//公司创建人

                    int CompanyID = companyBLL.Add(model);                                 //单位ID     

                    T_UsersInfo_MDL uiMdl = new T_UsersInfo_MDL();
                    uiMdl.UserName = txtLogName.Text.Trim();
                    uiMdl.LoginName = txtLogName.Text.Trim();
                    uiMdl.Passwd = DESEncrypt.Encrypt(txtPwd.Text);
                    uiMdl.UserType = SystemSet.EumUserType.CompanyUser.ToString();
                    uiMdl.TrainCount = 0;
                    uiMdl.Createdate = DateTime.Now;
                    uiMdl.Createdby = "由" + Common.Session.GetSession("UserName") + "创建";
                    uiMdl.IsValid = true;                                           //是否有效

                    if (CompanyType == SystemSet._SGCOMPANYINFO)
                        uiMdl.RoleID = roleBLL.GetRoleIdByRoleCode(SystemSet._ROLECODE_SGCOMPANY, model.AREA_CODE);
                    else if (CompanyType == SystemSet._JLCOMPANYINFO)
                        uiMdl.RoleID = roleBLL.GetRoleIdByRoleCode(SystemSet._ROLECODE_JLCOMPANY, model.AREA_CODE);
                    else if (CompanyType == SystemSet._JSCOMPANYINFO)
                        uiMdl.RoleID = roleBLL.GetRoleIdByRoleCode(SystemSet._ROLECODE_JSCOMPANY, model.AREA_CODE);

                    uiMdl.CompanyID = CompanyID;                                    //所属单位
                    userBLL.Add(uiMdl);

                    PublicModel.writeLog(SystemSet.EumLogType.AddData.ToString(), string.Concat("T_Company;key=", model.CompanyID,
                        ";CompanyCode=", model.CompanyCode, ";CompanyType=", model.CompanyType, ";CompanyName=", model.CompanyName));
                    PublicModel.writeLog(SystemSet.EumLogType.AddData.ToString(), string.Concat("T_UsersInfo;key=", uiMdl.UserID,
                        ";CompanyID=", uiMdl.CompanyID, ";UserName=", uiMdl.UserName, ";LoginName=", uiMdl.LoginName));
                }
            }
            if ((CommonEnum.PageState)ViewState["ps"] == CommonEnum.PageState.EDIT) {
                model = ctrlCompanyBaseInfo1.GetModule(ConvertEx.ToInt(ID));

                if (ViewState["UserID"] != null) {
                    T_UsersInfo_MDL User = userBLL.GetModel(ConvertEx.ToInt(ViewState["UserID"]));
                    if (User != null) {
                        User.LoginName = txtLogName.Text.Trim();
                        User.Passwd = DESEncrypt.Encrypt(txtPwd.Text.Trim());
                        userBLL.Update(User);

                        PublicModel.writeLog(SystemSet.EumLogType.UpdData.ToString(), string.Concat("T_UsersInfo;key=", User.UserID,
                            ";CompanyID=", User.CompanyID, ";UserName=", User.UserName, ";LoginName=", User.LoginName));
                    }
                }
                if (model != null) {
                    companyBLL.Update(model);
                    PublicModel.writeLog(SystemSet.EumLogType.UpdData.ToString(), string.Concat("T_Company;key=", model.CompanyID,
                        ";CompanyCode=", model.CompanyCode, ";CompanyType=", model.CompanyType, ";CompanyName=", model.CompanyName));
                }
            }
            Common.MessageBox.CloseLayerOpenWeb(this.Page);
        }
    }
}