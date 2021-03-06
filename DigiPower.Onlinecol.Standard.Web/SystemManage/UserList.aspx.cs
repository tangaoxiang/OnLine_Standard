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
using System.Collections.Generic;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Common;

namespace DigiPower.Onlinecol.Standard.Web.SystemManage {
    public partial class UserList : PageBase {
        T_UsersInfo_BLL userBLL = new T_UsersInfo_BLL();

        /// <summary>
        /// 默认登录密码
        /// </summary>
        public string defaultPwd = SystemSet._DEFAULTPWD;

        /// <summary>
        /// 总记录数
        /// </summary>
        int itemCount = 0;

        /// <summary>
        /// 每页页数
        /// </summary>
        int pageSize = SystemSet._PAGESIZE;

        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(UserList));
            MyAddInit();

            if (!IsPostBack) {
                ddlCompany.DataBindEx();

                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("ddlCompany")))
                    ddlCompany.SelectValue = Server.UrlDecode(DNTRequest.GetQueryString("ddlCompany"));
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("txtLoginName")))
                    txtLoginName.Text = Server.UrlDecode(DNTRequest.GetQueryString("txtLoginName"));
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("txtUserName")))
                    txtUserName.Text = Server.UrlDecode(DNTRequest.GetQueryString("txtUserName"));

                BindGridView(AspNetPager.CurrentPageIndex);
            }
        }

        /// <summary>
        /// 删除用户,档案馆用户可以删除,管理员除外
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public bool DeleteUser(int userID) {
            bool flag = false;
            try {
                Model.T_UsersInfo_MDL userMDL = userBLL.GetModel(userID);
                if (userMDL != null && !userMDL.IsSuperAdmin) {
                    userBLL.Delete(userID);

                    PublicModel.writeLog(SystemSet.EumLogType.DelData.ToString(), string.Concat("T_UsersInfo;key=", userMDL.UserID,
                        ";CompanyID=", userMDL.CompanyID, ";UserName=", userMDL.UserName, ";LoginName=", userMDL.LoginName, ";删除档案馆用户"));
                    flag = true;
                }
            } catch (Exception ex) {
                Common.LogUtil.Debug(this, "档案馆用户删除失败", ex);
            }
            return flag;
        }

        /// <summary>
        /// 重置用户密码
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public string ResetPwd(string userID) {
            string rtValue = string.Empty;
            try {
                Model.T_UsersInfo_MDL userMDL = userBLL.GetModel(Convert.ToInt32(userID));
                if (userMDL != null) {
                    userMDL.Passwd = DESEncrypt.Encrypt(SystemSet._DEFAULTPWD);
                    userBLL.Update(userMDL);

                    PublicModel.writeLog(SystemSet.EumLogType.UpdData.ToString(), string.Concat("T_UsersInfo;key=", userMDL.UserID,
                         ";UserType=", userMDL.UserType, ";CompanyID=", userMDL.CompanyID, ";UserName=", userMDL.UserName, ";LoginName=", userMDL.LoginName, ";密码重置"));

                    rtValue = SystemSet._DEFAULTPWD;
                }
            } catch (Exception ex) {
                rtValue = SystemSet._RETURN_FAILURE_VALUE + ex.Message;
                Common.LogUtil.Debug(this, "业务单位用户重置密码失败", ex);
            }
            return rtValue;
        }

        /// <summary>
        /// 列表档案馆用户数据绑定
        /// </summary>
        /// <param name="pageIndex"></param>
        private void BindGridView(int pageIndex) {
            string sqlWhere = " b.CompanyType=" + SystemSet._ARCHIVE;

            if (txtLoginName.Text.Trim().Length > 0)
                sqlWhere += " And a.LoginName like '%" + txtLoginName.Text.Trim() + "%' ";
            if (txtUserName.Text.Trim().Length > 0)
                sqlWhere += " And a.UserName like '%" + txtUserName.Text.Trim() + "%' ";
            if (!String.IsNullOrWhiteSpace(ddlCompany.SelectValue))
                sqlWhere += " And b.CompanyID =" + ddlCompany.SelectValue;

            if (PublicModel.isSuperAdmin())  //超级管理员
            {
                sqlWhere += " And b.Area_Code like '" + Common.Session.GetSession("AREA_CODE") + "%' ";
            } else if (PublicModel.isArchiveUser()) //馆里用户
            {
                sqlWhere += " And b.Area_Code like '" + Common.Session.GetSession("OLD_AREA_CODE") + "%' ";
            }

            if (ViewState["CurrentPageIndex"] == null && Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex")) > 0) {
                pageIndex = Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex"));
                ViewState["CurrentPageIndex"] = pageIndex;
            } else {
                pageIndex = ConvertEx.ToInt(ViewState["CurrentPageIndex"]);
            }

            DataTable dt = userBLL.GetListByCompany(sqlWhere, pageSize, pageIndex, out itemCount);
            AspNetPager.AlwaysShow = true;
            AspNetPager.PageSize = pageSize;

            AspNetPager.RecordCount = itemCount;
            AspNetPager.CurrentPageIndex = pageIndex;

            rpData.DataSource = dt;
            rpData.DataBind();
        }

        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager_PageChanged(object sender, EventArgs e) {
            ViewState["CurrentPageIndex"] = AspNetPager.CurrentPageIndex;
            BindGridView(AspNetPager.CurrentPageIndex);
        }

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e) {
            BindGridView(1);
        }
    }
}
