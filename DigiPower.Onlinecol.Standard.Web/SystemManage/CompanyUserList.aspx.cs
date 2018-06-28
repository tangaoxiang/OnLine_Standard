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
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Common;

namespace DigiPower.Onlinecol.Standard.Web.SystemManage {
    public partial class CompanyUserList : PageBase {
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
            Ajax.Utility.RegisterTypeForAjax(typeof(CompanyUserList));

            if (!IsPostBack) {
                DataBindExUserType();

                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("txtCompanyName")))
                    txtCompanyName.Text = Server.UrlDecode(DNTRequest.GetQueryString("txtCompanyName"));
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("txtLoginName")))
                    txtLoginName.Text = Server.UrlDecode(DNTRequest.GetQueryString("txtLoginName"));
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("txtUserName")))
                    txtUserName.Text = Server.UrlDecode(DNTRequest.GetQueryString("txtUserName"));
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("txtGcmc")))
                    txtGcmc.Text = Server.UrlDecode(DNTRequest.GetQueryString("txtGcmc"));
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("ddlUserType")))
                    ddlUserType.SelectedValue = Server.UrlDecode(DNTRequest.GetQueryString("ddlUserType"));
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("txtGcdd")))
                    txtGcdd.Text = Server.UrlDecode(DNTRequest.GetQueryString("txtGcdd"));

                BindGridView(AspNetPager.CurrentPageIndex);
            }
        }

        /// <summary>
        /// 绑定用户类型
        /// </summary>
        private void DataBindExUserType() {
            foreach (var dic in Enum.GetNames(typeof(SystemSet.EumUserType))) {
                ddlUserType.Items.Insert(0, new ListItem(PublicModel.GetEnumDescription((SystemSet.EumUserType)Enum.Parse(typeof(SystemSet.EumUserType), dic)), dic.ToLower()));
            }
            ddlUserType.Items.Insert(0, new ListItem("--请选择--", "0"));
            ddlUserType.SelectedValue = DNTRequest.GetQueryString("UserType").ToLower();
            ddlUserType.Enabled = false;
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
                           ";UserType=", userMDL.UserType, ";CompanyID=", userMDL.CompanyID, ";UserName=", userMDL.UserName, ";LoginName=", userMDL.LoginName, ";重置密码"));

                    rtValue = SystemSet._DEFAULTPWD;
                }
            } catch (Exception ex) {
                rtValue = SystemSet._RETURN_FAILURE_VALUE + ex.Message;
                Common.LogUtil.Debug(this, "业务单位用户重置密码失败", ex);
            }
            return rtValue;
        }

        /// <summary>
        /// 列表数据绑定
        /// </summary>
        /// <param name="pageIndex"></param>
        private void BindGridView(int pageIndex) {
            string sqlWhere = " b.CompanyType !=" + SystemSet._ARCHIVE;
            if (!String.IsNullOrWhiteSpace(txtLoginName.Text.Trim()))
                sqlWhere += " And a.LoginName like '%" + txtLoginName.Text.Trim() + "%' ";
            if (!String.IsNullOrWhiteSpace(txtUserName.Text.Trim()))
                sqlWhere += " And a.UserName like '%" + txtUserName.Text.Trim() + "%' ";
            if (!String.IsNullOrWhiteSpace(txtCompanyName.Text.Trim()))
                sqlWhere += " And b.CompanyName like '%" + txtCompanyName.Text.Trim() + "%' ";  
            if (!String.IsNullOrWhiteSpace(txtGcmc.Text.Trim()))
                sqlWhere += " And d.gcmc like '%" + txtGcmc.Text.Trim() + "%' ";
            if (!String.IsNullOrWhiteSpace(txtGcdd.Text.Trim()))
                sqlWhere += " And d.gcdd like '%" + txtGcdd.Text.Trim() + "%' ";
            if (ddlUserType.SelectedValue != "0")
                sqlWhere += " And lower(a.UserType)='" + ddlUserType.SelectedValue.Trim().ToLower() + "' ";

            if (PublicModel.isSuperAdmin())  //超级管理员
            {
                sqlWhere += " And b.Area_Code like '" + Common.Session.GetSession("OLD_AREA_CODE") + "%' ";
            } else if (PublicModel.isArchiveUser()) //馆里用户          
            {
                sqlWhere += " And b.Area_Code like '" + Common.Session.GetSession("AREA_CODE") + "%' ";
            }

            if (ViewState["CurrentPageIndex"] == null && Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex")) > 0) {
                pageIndex = Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex"));
                ViewState["CurrentPageIndex"] = pageIndex;
            } else {
                pageIndex = ConvertEx.ToInt(ViewState["CurrentPageIndex"]);
            }

            DataTable dt = userBLL.GetCompanyUserList(sqlWhere, pageSize, pageIndex, out itemCount);
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
