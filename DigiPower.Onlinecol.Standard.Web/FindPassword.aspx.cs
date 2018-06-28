using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Linq;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.Model;

namespace DigiPower.Onlinecol.Standard.Web {
    public partial class FindPassword : System.Web.UI.Page {
        T_Company_BLL companyBLL = new T_Company_BLL();
        T_UsersInfo_BLL userBLL = new T_UsersInfo_BLL();

        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(FindPassword));
        }

        /// <summary>
        /// 效验验证码输入是否正确
        /// </summary>
        /// <param name="findValidateCode"></param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public bool CheckFindValidateCode(string findValidateCode) {
            if (string.Compare(findValidateCode, Common.Session.GetSession("findValidateCode"), true) == 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 检测用户输入的登录账号和密码是否存在
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public bool ExistsUserDate(string loginName, string email) {
            string strWhere = "lower(LoginName)='" + loginName.ToLower().Trim() + "'";
            if (loginName.Trim().Length > 0 && email.Trim().Length < 1) {
                return userBLL.Exists(strWhere);
            } else if (loginName.Trim().Length > 0 && email.Trim().Length > 0) {
                strWhere = "CompanyID=(select top 1 CompanyID from T_UsersInfo where " + strWhere + ") and lower(email)='" + email.ToLower().Trim() + "'";
                return companyBLL.Exists(strWhere);
            } else {
                return false;
            }
        }

        private void RegisterStartupScriptString(string message) {
            string strJs = "layer.alert('" + message + "', { btnAlign: 'c', time: 10000 }, function (index) { ";
            strJs += "    layer.close(index);                                                   ";
            strJs += "    parent.layer.close(parent.layer.getFrameIndex(window.name));          ";
            strJs += "});                                                                       ";
            MessageBox.RegisterStartupScriptString(this.Page, strJs);
        }

        /// <summary>
        /// 保存,重置密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e) {
            try {
                string defualtPwd = SystemSet._DEFAULTPWD;
                StringBuilder strMsgBody = new StringBuilder();
                strMsgBody.Append("您好,您的<a href=\"" + SystemSet._APPURL + "\" target=\"_parent\">");
                strMsgBody.Append("《" + SystemSet._APPAREA + SystemSet._APPTITLE + "》</a>");
                strMsgBody.Append("的登录密码已经重置为:" + defualtPwd + ",请登录系统后重新修改密码!");
                if (Common.CSendEmail.SendEmail("档案馆", txtEmail.Text.Trim(), "账号密码重置", strMsgBody.ToString(), "")) {
                    T_UsersInfo_MDL userMDL = userBLL.GetModelList("lower(LoginName)='" + txtUserName.Text.ToLower().Trim() + "'").FirstOrDefault();
                    if (userMDL != null) {
                        userMDL.Passwd = DESEncrypt.Encrypt(defualtPwd);
                        userBLL.Update(userMDL);

                        PublicModel.writeLog(SystemSet.EumLogType.UpdData.ToString(), string.Concat("T_UsersInfo;key=", userMDL.UserID,
                             ";UserType=", userMDL.UserType, ";CompanyID=", userMDL.CompanyID, ";UserName=", userMDL.UserName, ";LoginName=", userMDL.LoginName, ";找回密码"));

                        RegisterStartupScriptString("密码已经发送到您的邮箱，请及时修改!");
                    }
                } else {
                    RegisterStartupScriptString("邮件发送失败!");
                }
            } catch (Exception ex) {
                Common.LogUtil.Debug(this, "找回密码失败", ex);
                RegisterStartupScriptString("找回密码失败,请联系管理员!");
            }
        }
    }
}