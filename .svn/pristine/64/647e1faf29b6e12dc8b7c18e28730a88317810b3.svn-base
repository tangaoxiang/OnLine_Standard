using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.Model;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DigiPower.Onlinecol.Standard.Web.MySpace {
    public partial class ChangePassword : PageBase {
        T_UsersInfo_BLL userinfoBLL = new T_UsersInfo_BLL();
        T_Company_BLL companyBLL = new T_Company_BLL();

        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(ChangePassword));
            if (Common.Session.GetSession("UserID") == "") {
                Response.Redirect("/UserLoginGather.aspx");
            }
            if (!this.IsPostBack) {
                T_UsersInfo_MDL userMDL = userinfoBLL.GetModel(ConvertEx.ToInt(Common.Session.GetSession("UserID")));
                if (userMDL != null) {
                    UserName.Text = userMDL.UserName;
                    Mobile.Text = userMDL.Mobile;
                    Fax.Text = userMDL.Fax;
                    Tel.Text = userMDL.Tel;
                    LoginName.Text = userMDL.LoginName;

                    if (!PublicModel.isSuperAdmin())
                        CompanyName.readOnly = true;

                    T_Company_MDL companyMDL = new T_Company_BLL().GetModel(userMDL.CompanyID);
                    if (companyMDL != null) {
                        ViewState["companyMDL"] = companyMDL;
                        CompanyName.Text = companyMDL.CompanyName;
                    }

                    ViewState["userMDL"] = userMDL;
                }
            }
        }

        /// <summary>
        /// 判断原始密码是否正确
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public bool CheckOldPassword(string pwd) {
            bool flag = false;
            string LoginString = "UserID='" + Common.Session.GetSession("UserID") + "'";
            if (pwd.Trim() != "") {
                LoginString += " and passwd='" + DESEncrypt.Encrypt(pwd.Trim()) + "'";
                List<T_UsersInfo_MDL> userinfomdl = userinfoBLL.GetModelList(LoginString);
                if (userinfomdl.Count > 0)
                    flag = true;
            }
            return flag;
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
        /// 更新密码
        /// </summary>
        /// <param name="pwd"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public void UpdatePwd(string pwd) {
            new UserOperate().ChangePasswd(Common.Session.GetSession("UserID"), DESEncrypt.Encrypt(pwd));
        }

        protected void btnSave_Click(object sender, EventArgs e) {
            if (ViewState["userMDL"] != null) {
                T_UsersInfo_MDL userMDL = ViewState["userMDL"] as T_UsersInfo_MDL;

                userMDL.UserName = UserName.Text;
                userMDL.Mobile = Mobile.Text;
                userMDL.Fax = Fax.Text;
                userMDL.Tel = Tel.Text;
                userMDL.Passwd = DESEncrypt.Encrypt(newPasswd2.Text);
                userinfoBLL.Update(userMDL);

                PublicModel.writeLog(SystemSet.EumLogType.UpdData.ToString(), string.Concat(" T_UsersInfo;key=", userMDL.UserID,
                    ";UserName=", userMDL.UserName, ";LoginName=", userMDL.LoginName, ";ChangePassword.aspx密码重置"));


                if (ViewState["companyMDL"] != null) {
                    T_Company_MDL companyMDL = ViewState["companyMDL"] as T_Company_MDL;
                    companyMDL.CompanyName = CompanyName.Text.Trim();
                    companyBLL.Update(companyMDL);

                    PublicModel.writeLog(SystemSet.EumLogType.UpdData.ToString(), string.Concat(" T_Company_MDL;key=", companyMDL.CompanyID,
                        ";CompanyName=", companyMDL.CompanyName, ";ChangePassword.aspx管理员更新档案馆名称"));
                }
                Common.MessageBox.FnLayerAlert(this.Page, "保存成功,新密码重新登录才有效!");
            }
        }
    }
}
