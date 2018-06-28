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
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.Common;

namespace DigiPower.Onlinecol.Standard.Web.SystemManage {
    public partial class RoleList : PageBase {
        T_Role_BLL roleBLL = new T_Role_BLL();
        /// <summary>
        /// 总记录数
        /// </summary>
        int itemCount = 0;

        /// <summary>
        /// 每页页数
        /// </summary>
        int pageSize = SystemSet._PAGESIZE;

        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(RoleList));
            MyAddInit();
            if (!IsPostBack) {
                ddlCompany.DataBindEx();
                ddlRoleType.DataValueField = "SystemInfoCode";
                ddlRoleType.DataBindEx();

                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("ddlRoleType")))
                    ddlRoleType.SelectValue = Server.UrlDecode(DNTRequest.GetQueryString("ddlRoleType"));
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("ddlCompany")))
                    ddlCompany.SelectValue = Server.UrlDecode(DNTRequest.GetQueryString("ddlCompany"));
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("txtRoleName")))
                    txtRoleName.Text = Server.UrlDecode(DNTRequest.GetQueryString("txtRoleName"));

                BindGridView(AspNetPager.CurrentPageIndex);
            }
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="archiveListCellRptID"></param>
        /// <param name="OrderIndex"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public bool DeleteRole(string RoleID) {
            T_Role_MDL roleMDL = roleBLL.GetModel(ConvertEx.ToInt(RoleID));
            if (roleMDL != null) {
                if (!new T_UsersInfo_BLL().Exists("RoleID=" + RoleID)) {
                    roleBLL.Delete(ConvertEx.ToInt(RoleID));

                    PublicModel.writeLog(SystemSet.EumLogType.DelData.ToString(), string.Concat("T_Role;key=", roleMDL.RoleID,
                        ";RoleCode=", roleMDL.RoleCode, ";RoleName=", roleMDL.RoleName));

                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindGridView(int pageIndex) {
            string sqlWhere = " b.CompanyType=" + SystemSet._ARCHIVE;
            if (PublicModel.isSuperAdmin())
                sqlWhere += " And b.Area_Code like '%" + Common.Session.GetSession("OLD_AREA_CODE") + "%'";
            if (PublicModel.isArchiveUser())
                sqlWhere += " And b.Area_Code like '%" + Common.Session.GetSession("AREA_CODE") + "%'";
            if (!String.IsNullOrWhiteSpace(ddlCompany.SelectValue))
                sqlWhere += " And a.CompanyID=" + ddlCompany.SelectValue + "";
            if (!String.IsNullOrWhiteSpace(txtRoleName.Text.Trim()))
                sqlWhere += " And a.RoleName like '%" + txtRoleName.Text.Trim() + "%'";
            if (!String.IsNullOrWhiteSpace(ddlRoleType.SelectValue))
                sqlWhere += " And lower(a.RoleType)  like '%" + ddlRoleType.SelectValue.ToLower() + "%'";

            if (ViewState["CurrentPageIndex"] == null && Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex")) > 0) {
                pageIndex = Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex"));
                ViewState["CurrentPageIndex"] = pageIndex;
            } else {
                pageIndex = ConvertEx.ToInt(ViewState["CurrentPageIndex"]);
            }

            DataTable dt = roleBLL.GetListPaging(sqlWhere, pageSize, pageIndex, out itemCount);
            AspNetPager.AlwaysShow = true;
            AspNetPager.PageSize = pageSize;

            AspNetPager.RecordCount = itemCount;
            AspNetPager.CurrentPageIndex = pageIndex;

            rpData.DataSource = dt;
            rpData.DataBind();
        }

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e) {
            this.BindGridView(1);
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
    }
}
