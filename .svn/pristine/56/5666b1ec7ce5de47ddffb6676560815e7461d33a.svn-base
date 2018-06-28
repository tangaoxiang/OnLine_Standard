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

using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.Model;
using System.Collections.Generic;

namespace DigiPower.Onlinecol.Standard.Web.CommonCtrl {
    public partial class ctrlCompanyRegBaseInfo3_2Ext : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {

        }


        /// <summary>
        /// 禁用页面所有的控件
        /// </summary>
        /// <param name="flag"></param>
        public void DisabledControl() {
            EnableControls(tabledetail, false);
        }

        protected void EnableControls(Control c, bool bEnabled) {
            if (c is WebControl)
                ((WebControl)c).Enabled = bEnabled;

            if (c is HtmlControl)
                ((HtmlControl)c).Disabled = !bEnabled;

            foreach (Control cc in c.Controls)
                EnableControls(cc, bEnabled);
        }

        /// <summary>
        /// 将Model 值赋给控件
        /// </summary>
        /// <param name="tSingleProjectID">工程ID</param>
        public void DataBindEx(int tSingleProjectID) {
            ztjg.DataValueField = "systeminfoname";
            ztjg.DataBindEx();

            if (tSingleProjectID > 0) {
                List<b_single_project_MDL> projectmdl = new b_single_project_BLL().GetModelList("SingleProjectID=" + tSingleProjectID);
                if (projectmdl.Count > 0) {
                    Comm.SetValueToPage(projectmdl[0], tabledetail);
                }
            }
        }


        /// <summary>
        /// 获取房屋专业记载MODEL
        /// </summary>
        /// <param name="tSingleProjectID">工程ID</param>
        /// <returns></returns>
        public b_single_project_MDL GetModule(int tSingleProjectID) {
            b_single_project_BLL bll = new b_single_project_BLL();
            b_single_project_MDL mdl = new b_single_project_MDL();

            if (tSingleProjectID > 0) {
                List<b_single_project_MDL> projectmdl = bll.GetModelList("SingleProjectID=" + tSingleProjectID);
                if (projectmdl.Count > 0) {
                    mdl = bll.GetModel(projectmdl[0].SingleProjectID);
                }
            }
            object obj = Comm.GetValueToObject(mdl, tabledetail);
            return (b_single_project_MDL)obj;
        }
    }
}