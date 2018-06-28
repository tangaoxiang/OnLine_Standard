using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.Model;
using System.Configuration;
using System.Data;
using DigiPower.Onlinecol.Standard.Web.CommonCtrl;

namespace DigiPower.Onlinecol.Standard.Web.SystemManage {
    public partial class OutHelpCompanyFileTmpAdd : System.Web.UI.Page {
        T_FileListTmp_BLL fileListTmpBll = new T_FileListTmp_BLL();

        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(OutHelpCompanyFileTmpAdd));
            if (!this.IsPostBack) {
                DataBindEx();
            }
        }

        /// <summary>
        /// 绑定所有PID=0的归档目录,授权给外协单位
        /// </summary>
        private void DataBindEx() {
            gvSignature.DataSource = fileListTmpBll.getAllFileListTmpBH();
            gvSignature.DataBind();
        }
    }
}