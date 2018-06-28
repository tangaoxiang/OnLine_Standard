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
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Model;

namespace DigiPower.Onlinecol.Standard.Web {
    public partial class LHSignatureFileTmp : PageBase {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                BindSignatureTmp();
            }
        }

        /// <summary>
        /// 绑定文件签章流程模板
        /// </summary>
        private void BindSignatureTmp() {
            T_FileList_SignatureTmp_BLL tmpBLL = new T_FileList_SignatureTmp_BLL();   
            string strWhere = " FileListID = " + Common.DNTRequest.GetQueryString("OldRecID") + "  ";
            DataTable dt = tmpBLL.GetList(strWhere).Tables[0];

            rpData.DataSource = dt;
            rpData.DataBind();
        }
    }
}