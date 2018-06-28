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
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.CBLL;
using DigiPower.Onlinecol.Standard.Common;
using System.Text;

//问题详情预览

namespace DigiPower.Onlinecol.Standard.Web.SystemManage
{
    public partial class OperationLogView : PageBase
    {
        T_OperationLog_BLL operLogBLL = new T_OperationLog_BLL();

        protected void Page_Load(object sender, EventArgs e) {
            MyAddInit();
            if (!IsPostBack) {
                T_OperationLog_MDL operLogMDL = operLogBLL.GetModel(ConvertEx.ToInt(ID));
                if (operLogMDL != null) {
                    ltUserName.Text = operLogMDL.UserName;
                    ltCreateDate.Text = ConvertEx.ToDate(operLogMDL.CreateDate).ToString("yyyy-MM-dd HH:mm:ss");
                    ltCreateIP.Text = operLogMDL.CreateIP;

                    List<DigiPower.Onlinecol.Standard.Model.T_SystemInfo_MDL> list = new T_SystemInfo_BLL().GetModelListForCurrentType("OperationType", string.Concat("'", operLogMDL.Description, "'"));
                    if (list != null && list.Count > 0)
                        ltDescription.Text = list[0].SystemInfoName;
                    ltErrorMsg.Text = operLogMDL.ErrorMsg;
                }
            }
        }
    }
}