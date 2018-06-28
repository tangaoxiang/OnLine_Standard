using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Reflection;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.DAL;
using DigiPower.Onlinecol.Standard.Model;
using System.Collections.Generic;

namespace DigiPower.Onlinecol.Standard.Web.CompanyManage {
    public partial class ChangeChargeUser : PageBase {
        T_SingleProject_BLL singleProBLL = new T_SingleProject_BLL();

        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(ChangeChargeUser));
            if (!IsPostBack) {
                ddlOldUser.BindDataByCompanyID(Common.Session.GetSession("CompanyId"), SystemSet._ROLECODE_CHARGEUSER);
                ddlOldUser.SelectValue = DNTRequest.GetQueryString("ChargeUserID");
                ddlOldUser.enabled = false;
                ddlNewUser.BindDataByCompanyID(Common.Session.GetSession("CompanyId"), SystemSet._ROLECODE_CHARGEUSER);
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e) {
            try {
                T_SingleProject_MDL singleProMDL = singleProBLL.GetModel(DNTRequest.GetQueryInt("SingleProjectID", 0));
                if (singleProMDL != null) {
                    //将指导人员指导环节的所有 [受理]全部 做,这样,除了管理员和受理人员外,其他人都看不到流程下的工程
                    T_WorkFlowDefine_BLL workFlowDefineBLL = new T_WorkFlowDefine_BLL();
                    IList<T_WorkFlowDefine_MDL> workFlowDefineLT = workFlowDefineBLL.GetModelList(" SingleProjectID=" +
                        singleProMDL.SingleProjectID + " and WorkFlowID in(" + SystemSet._DEFAULT_RECV_WORKFLOWID + ") ");
                    if (workFlowDefineLT != null && workFlowDefineLT.Count > 0) {
                        foreach (T_WorkFlowDefine_MDL wkdMDL in workFlowDefineLT) {
                            wkdMDL.SubmitStatus = 2;//受理完成状态
                            wkdMDL.RecvUserID = Common.ConvertEx.ToInt(ddlNewUser.SelectValue);
                            wkdMDL.RecvDateTime = DateTime.Now;
                            workFlowDefineBLL.Update(wkdMDL);
                        }
                    }
                    singleProMDL.ChargeUserID = Common.ConvertEx.ToInt(ddlNewUser.SelectValue);
                    singleProBLL.Update(singleProMDL);
                    Common.LogUtil.Info(this, "变更业务指导人员:" + singleProMDL.gcbm + "-------" +
                        ddlOldUser.SelectText + "-------" + ddlNewUser.SelectText);

                    PublicModel.writeLog(SystemSet.EumLogType.UpdData.ToString(),
                        string.Concat("T_SingleProject_MDL;keyList=", singleProMDL.SingleProjectID, ";gcbm=", singleProMDL.gcbm,
                        ";gcmc=", singleProMDL.gcmc, ";UserName=", Common.Session.GetSession("UserName"), ";UserID=",
                        Common.Session.GetSession("UserID"), "变更业务指导人员(", ddlOldUser.SelectText, "--->", ddlNewUser.SelectText, ")"));
                }
                Common.MessageBox.CloseLayerOpenWeb(this.Page);
            } catch (Exception ex) {
                Common.LogUtil.Debug(this, "变更业务指导人员", ex);
            }
        }
    }
}