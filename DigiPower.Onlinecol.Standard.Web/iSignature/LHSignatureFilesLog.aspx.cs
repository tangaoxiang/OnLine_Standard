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
    public partial class LHSignatureFilesLog : PageBase {

        //文件ID
        public string FileID = "";

        /// <summary>
        /// 总记录数
        /// </summary>
        int itemCount = 0;

        /// <summary>
        /// 每页页数
        /// </summary>
        int pageSize = 3000;

        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(LHSignatureFilesLog));
            MyAddInit();
            FileID = Common.DNTRequest.GetQueryString("FileListID");

            if (!IsPostBack) {
                BindGridView(1);
            }
        }

        protected string getOperationTypeName(string OperationType) {
            if (!string.IsNullOrWhiteSpace(OperationType)) {
                if (string.Compare(OperationType, "SignatureSave", true) == 0)
                    return "签章保存";
                else if (string.Compare(OperationType, "SignatureReset", true) == 0)
                    return "签章重置";
                else if (string.Compare(OperationType, "SignatureFinish", true) == 0)
                    return "签章完成";
                else
                    return string.Empty;
            } else
                return string.Empty;
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindGridView(int pageIndex) {
            T_FileList_SignatureLog_BLL logBLL = new T_FileList_SignatureLog_BLL();

            string strWhere = " FileListID = " + FileID + "  ";
            DataTable dt = logBLL.GetListPaging(strWhere, pageSize, pageIndex, out itemCount); ;

            rpData.DataSource = dt;
            rpData.DataBind();
        }
    }
}