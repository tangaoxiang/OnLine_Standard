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
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.CBLL;

//任务分配

namespace DigiPower.Onlinecol.Standard.Web.WorkFlow {
    public partial class Rwfp : System.Web.UI.Page {
        public string singleProjectid = string.Empty;
        public string workFlowID = string.Empty;
        T_SingleProject_BLL singleProjectBLL = new T_SingleProject_BLL();

        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(Rwfp));
            singleProjectid = DNTRequest.GetQueryString("SingleProjectID");
            workFlowID = DNTRequest.GetQueryString("WorkFlowID");

            if (!IsPostBack) {
                ddlUser.BindDataByCompanyID("", true, SystemSet._ROLECODE_CHARGEUSER, Common.Session.GetSession("OLD_AREA_CODE"));
                ctrlCompanyQucikReg.DataBindEx(ConvertEx.ToInt(singleProjectid));
                ctrlCompanyQucikReg.DisabledControl();

                T_SingleProject_MDL singleProjectMDL = singleProjectBLL.GetModel(ConvertEx.ToInt(singleProjectid));
                if (singleProjectMDL != null) {
                    ddlUser.SelectValue = singleProjectMDL.ChargeUserID.ToString();
                }
            }
        }

        /// <summary>
        /// 分配并提交任务
        /// </summary>
        /// <param name="SingleProjectID"></param>
        /// <param name="ChargeUserID"></param>
        /// <param name="workFlowID"></param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public string AllotSingleProject(string SingleProjectID, string ChargeUserID, string WorkFlowID) {
            try {
                //激活工程
                T_SingleProject_MDL singleProjectMDL = singleProjectBLL.GetModel(ConvertEx.ToInt(SingleProjectID));

                singleProjectMDL.Status = 1;
                int CompanyID = 0;

                #region 没有工程编号则生成
                if (String.IsNullOrEmpty(singleProjectMDL.gcbm)) {
                    T_Other_BLL otherBLL = new T_Other_BLL();
                    singleProjectMDL.gcbm = otherBLL.GetNewEngineerID();
                    singleProjectBLL.Update(singleProjectMDL);       //产生工程号   

                    T_Construction_Project_BLL cpBLL = new T_Construction_Project_BLL();
                    Model.T_Construction_Project_MDL cpMDL = cpBLL.GetModel(singleProjectMDL.ConstructionProjectID);
                    if (cpMDL != null) {
                        CompanyID = cpMDL.CompanyID;                  //建设单位ID
                        if (String.IsNullOrEmpty(cpMDL.xmh)) {
                            cpMDL.xmh = otherBLL.GetNewProjectID();
                            cpBLL.Update(cpMDL);                      //更新项目号
                        }
                    }
                }
                #endregion

                #region 激活用户
                T_UsersInfo_BLL userBLL = new T_UsersInfo_BLL();
                T_UsersInfo_MDL userMDL = userBLL.GetModel(singleProjectMDL.CompanyUserID);
                if (userMDL != null) {
                    userMDL.IsValid = true;
                    userBLL.Update(userMDL);
                }
                #endregion

                #region 修改工程分配信息
                if (singleProjectMDL != null) {
                    singleProjectMDL.AllotDate = DateTime.Now;                                                                //分配时间
                    singleProjectMDL.AllotUserID = ConvertEx.ToInt(Common.Session.GetSession("UserId")); //分配人员
                    singleProjectMDL.ChargeUserID = ConvertEx.ToInt(ChargeUserID);                                 //业务指导人员

                    singleProjectBLL.Update(singleProjectMDL);
                }
                #endregion

                #region 添加建设单位归档目录
                string iSignaturePdf = "0";     //文件是否需要签章
                string iSignatureWorkFlow = "0";//是否按签章流程签章
                if (ConvertEx.ToBool(SystemSet._ISIGNATUREPDF)) {
                    iSignaturePdf = "1";
                    iSignatureWorkFlow = "1";
                }
                new UserOperate().CopyFileList(CompanyID, singleProjectMDL.CompanyUserID, "",
                    singleProjectMDL.SingleProjectID, singleProjectMDL.ProjectType, iSignaturePdf, iSignatureWorkFlow);
                #endregion

                #region 把业务指导人员用户加入到这个工程用户中去
                T_UsersInfo_MDL ChargeUserMDL = userBLL.GetModel(Common.ConvertEx.ToInt(ChargeUserID));
                PublicModel.AddSingleProjectUser(singleProjectMDL.SingleProjectID, ChargeUserMDL);
                #endregion

                #region 相关流程的用户也需要加入，否则流程走不下去===现在有了受理，可以达到这个功能，不需要加了。让用户受理下来。受理还没做完呢？
                SingleProjectUser projectRole = new SingleProjectUser();
                BLL.T_WorkFlow_BLL workFlowBLL = new T_WorkFlow_BLL();
                DataSet workFlowDS = workFlowBLL.GetList(" OrderIndex=1 ");
                if (workFlowDS.Tables.Count > 0) {
                    foreach (DataRow row in workFlowDS.Tables[0].Rows) {
                        projectRole.Update(singleProjectMDL.SingleProjectID, Common.ConvertEx.ToInt(row["RoleID"]), Common.ConvertEx.ToInt(row["UserID"]));
                    }
                }
                #endregion

                #region 发送邮件通知客户
                if (SystemSet._ACCEPTSINGLE_SENDEMAILFLAG) {
                    string strMsgBody = "您好！<br />";
                    strMsgBody += "您报建的工程：" + singleProjectMDL.gcmc + "，已确认通过，产生的工程编号是：" +
                        singleProjectMDL.gcbm + "，您现在已经可以通过注册时的账号密码登记系统操作了！";

                    T_UsersInfo_MDL CompanyUserMDL = userBLL.GetModel(singleProjectMDL.CompanyUserID);
                    Common.CSendEmail.SendEmail("档案馆", CompanyUserMDL.EMail, "工程报建确认通知", strMsgBody, "");
                }
                #endregion

                #region  提交到下一个流程
                WorkFlowManage workflowmanage = new WorkFlowManage();
                workflowmanage.GoNextProjectWorkFlowSataus(singleProjectMDL.SingleProjectID, ConvertEx.ToInt(WorkFlowID));
                #endregion

                #region 将指导人员指导环节的所有 [受理]全部 做,这样,除了管理员和受理人员外,其他人都看不到流程下的工程
                T_WorkFlowDefine_BLL workFlowDefineBLL = new T_WorkFlowDefine_BLL();
                IList<T_WorkFlowDefine_MDL> workFlowDefineLT = workFlowDefineBLL.GetModelList(" SingleProjectID=" +
                    singleProjectMDL.SingleProjectID + " and WorkFlowID in(" + SystemSet._DEFAULT_RECV_WORKFLOWID + ") ");
                if (workFlowDefineLT != null && workFlowDefineLT.Count > 0) {
                    foreach (T_WorkFlowDefine_MDL wkdMDL in workFlowDefineLT) {
                        wkdMDL.SubmitStatus = 2;//受理完成状态
                        wkdMDL.RecvUserID = Common.ConvertEx.ToInt(ChargeUserID);
                        wkdMDL.RecvDateTime = DateTime.Now;
                        workFlowDefineBLL.Update(wkdMDL);
                    }
                }
                #endregion

                return singleProjectMDL.gcbm;
            } catch (Exception ex) {
                return SystemSet._RETURN_FAILURE_VALUE + ex.Message;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="SingleProjectID"></param> 
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public string DeleteSingleProject(string SingleProjectID) {
            try {
                T_FileList_BLL fileListBLL = new T_FileList_BLL();
                Hashtable ht = new Hashtable();
                ht.Add("SingleProjectID", SingleProjectID);
                ht.Add("Unequal_Status", "0");
                int fileCount = fileListBLL.GetFileCount(ht);

                if (fileCount < 1) {
                    new T_Other_BLL().DeleteCompanyOther(SingleProjectID, true);
                    return SystemSet._RETURN_SUCCESS_VALUE;
                } else {
                    return "该工程已有<strong style='color:red'>" + fileCount + "</strong>份登记文件,不能删除!";
                }
            } catch (Exception ex) {
                return SystemSet._RETURN_FAILURE_VALUE + ex.Message;
            }
        }

        /// <summary>
        /// 根据工程ID 将报表导出PDF,注意:报表必须预先在T_Report做出记录
        /// </summary>
        /// <param name="SingleProjectID">工程ID</param>
        /// <param name="ReportCode">报表类型</param>
        /// <param name="DelOldReportPDF">是否删除已生成的PDF</param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public string ReportExportPDF(string singleProjectID, string reportCode, bool delOldReportPDF) {
            return ReportPDF.ReportExportPDF(singleProjectID, reportCode, delOldReportPDF);
        }

        /// <summary>
        /// 判断某个工程的下的报表PDF是否存在
        /// </summary>
        /// <param name="singleProjectID"></param>
        /// <param name="reportCode"></param>
        /// <param name="delOldReportPDF"></param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public bool CheckExistsReportPDF(string singleProjectID, string reportCode) {
            return ReportPDF.CheckExistsReportPDF(singleProjectID, reportCode);
        }
    }
}