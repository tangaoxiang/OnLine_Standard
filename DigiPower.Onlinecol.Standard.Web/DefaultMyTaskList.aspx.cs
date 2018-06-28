using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.CBLL;
using System.Text;
using System.Data;

namespace DigiPower.Onlinecol.Standard.Web
{
    public partial class DefaultMyTaskList : PageBase
    {
        T_WorkFlow_BLL workFlowBLL = new T_WorkFlow_BLL();
        T_RoleRight_BLL roleRightBLL = new T_RoleRight_BLL();
        protected void Page_Load(object sender, EventArgs e) {
            if (!this.IsPostBack) {
                CreatePage();
            }
        }

        /// <summary>
        /// 判断当前角色是否包含某一个流程节点
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="WorkFlowID"></param>
        /// <returns></returns>
        private bool isIncludeWorkFlow(DataTable dt, int WorkFlowID) {
            bool checkFlag = false;
            if (dt != null && dt.Rows.Count > 0) {
                DataRow[] row = dt.Select("ModelID=" + WorkFlowID + " And RoleRightType=2");
                if (row != null && row.Length > 0) {
                    checkFlag = true;
                }
            }
            return checkFlag;
        }

        /// <summary>
        /// 创建页面控件
        /// </summary>
        private void CreatePage() {
            DataTable roleDt = roleRightBLL.GetList("RoleID=" + Common.Session.GetSession("RoleID")).Tables[0];

            string RoleID = Common.Session.GetSession("RoleID");
            string UserID = Common.Session.GetSession("UserID");
            string Area_Code = string.Empty;

            if (PublicModel.isSuperAdmin())   //超级管理员，可以看全部
            {
                RoleID = "";
                Area_Code = Common.Session.GetSession("Area_Code");
            }
            else {
                Area_Code = Common.Session.GetSession("OLD_AREA_CODE");
            }
            DataSet ds = workFlowBLL.GetWorkFlowList(RoleID, UserID, Area_Code, Common.Session.GetSessionBool("IsCompany"));

            DataTable dt = new DataTable();    //对数据集按照父子关系排序
            dt.Columns.Add("WorkFlowID");
            dt.Columns.Add("WorkFlowName");
            dt.Columns.Add("DetailCount");
            dt.Columns.Add("roleid");
            dt.Columns.Add("userid");
            dt.Columns.Add("UseForCompany");
            dt.Columns.Add("OrderIndex");
            dt.Columns.Add("DescriptionToArchive");
            dt.Columns.Add("DescriptionToCompany");
            OrderDs(dt, ds, "0");

            StringBuilder strBuilder = new StringBuilder();
            int index = 0;
            foreach (DataRow row in dt.Rows) {
                index++;

                string description = string.Empty;    //流程说明
                if (PublicModel.isCompany())
                    description = row["DescriptionToCompany"].ToString();
                else
                    description = row["DescriptionToArchive"].ToString();

                string strClick = string.Empty;
                strBuilder.Append("  <li class=\"thumb1\"><a href=\"#\">");
                bool isShowDetailCount = false;
                if (PublicModel.isSuperAdmin() || isIncludeWorkFlow(roleDt, ConvertEx.ToInt(row["WorkFlowID"]))) {
                    isShowDetailCount = true;
                    strClick = " onclick=\"parent.addCustomIframe('MyTaskList.aspx?WorkFlowID=" +
                        ConvertEx.ToInt(row["WorkFlowID"]) + "','83995083" +
                        ConvertEx.ToInt(row["WorkFlowID"]) + "','" +
                        ConvertEx.ToString(row["WorkFlowName"]) + "')\" ";
                    strBuilder.Append("     <img " + strClick + " src=\"../Javascript/Layer/image/lc" + index.ToString("d3") + ".png\" />");
                }
                else {
                    strBuilder.Append("     <img src=\"../Javascript/Layer/image/hc" + index.ToString("d3") + ".png\" />");
                }
                strBuilder.Append("     <div class=\"title\">");
                if (!PublicModel.isCompany() || isShowDetailCount) {
                    isShowDetailCount = false;
                    strBuilder.Append("         <span>(" + ConvertEx.ToString(row["DetailCount"]) + ")</span><br />");
                }
                strBuilder.Append("         " + ConvertEx.ToString(row["WorkFlowName"]) + "");
                strBuilder.Append("     </div>");
                strBuilder.Append("     <p  " + strClick + " > ");
                strBuilder.Append(description);
                strBuilder.Append("     </p> ");
                strBuilder.Append(" </a>");
                strBuilder.Append("     <div class=\"dd" + index.ToString("d2") + "\"></div>");
                strBuilder.Append(" </li>");
            }
            ltWorkFlow.Text = strBuilder.ToString();
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="ds"></param>
        private void OrderDs(DataTable dt, DataSet ds, string PID) {
            DataRow dtr = dt.NewRow();
            DataRow[] dsr = ds.Tables[0].Select("PID = '" + PID + "'");
            if (dsr != null && dsr.Length > 0) {
                dtr[0] = dsr[0]["WorkFlowID"].ToString();
                dtr[1] = dsr[0]["WorkFlowName"].ToString();
                dtr[2] = dsr[0]["detailcount"].ToString();
                dtr[3] = dsr[0]["roleid"].ToString();
                dtr[4] = dsr[0]["userid"].ToString();
                dtr[5] = dsr[0]["UseForCompany"].ToString();
                dtr[6] = dsr[0]["OrderIndex"].ToString();
                dtr[7] = dsr[0]["DescriptionToArchive"].ToString();
                dtr[8] = dsr[0]["DescriptionToCompany"].ToString();
                dt.Rows.Add(dtr);
                OrderDs(dt, ds, dsr[0][0].ToString());
            }
        }
    }
}