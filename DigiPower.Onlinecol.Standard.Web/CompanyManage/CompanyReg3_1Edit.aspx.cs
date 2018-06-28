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
using DigiPower.Onlinecol.Standard.DAL;
using DigiPower.Onlinecol.Standard.Model;
using System.IO;
using DigiPower.Onlinecol.Standard.CBLL;

//房屋建筑工程 新增/编辑

namespace DigiPower.Onlinecol.Standard.Web.CompanyManage {
    public partial class CompanyReg3_1Edit1 : PageBase {
        /// <summary>
        /// 工程ID
        /// </summary>
        private string SingleProjectID = string.Empty;

        /// <summary>
        /// 工程类型
        /// </summary>
        private string ProjectType = string.Empty;

        T_SingleProject_BLL singleProjectBLL = new T_SingleProject_BLL();
        a_single_project_BLL asingleProjectBLL = new a_single_project_BLL();

        protected void Page_Load(object sender, EventArgs e) {
            SingleProjectID = DNTRequest.GetQueryString("SingleProjectID");
            ProjectType = DNTRequest.GetQueryString("ProjectType");

            Ajax.Utility.RegisterTypeForAjax(typeof(CompanyReg3_1Edit1));
            MyAddInit();
            if (!IsPostBack) {
                AREA_CODE.BindDdlArea(true);//区域
                ctrlCompanyRegBaseInfo3_11.DataBindEx(ConvertEx.ToInt(SingleProjectID));         //工程相关信息
                ctrlCompanyRegBaseInfo3_1Ext1.DataBindEx(ConvertEx.ToInt(SingleProjectID));      //专业记载

                if ((CommonEnum.PageState)ViewState["ps"] == CommonEnum.PageState.ADD) {
                    string js = "document.getElementById('ctl00_Main_ctrlCompanyRegBaseInfo3_11_gcbm').value='自动生成';";
                    ClientScript.RegisterStartupScript(this.GetType(), "IsSuccess", "<script type=\"text/javascript\">" + js + "</script>");

                    ctrlDropDownConstructionProject1.CompanyId = Common.Session.GetSession("CompanyID");//项目信息
                } else {
                    ctrlDropDownConstructionProject1.enable = false;
                }

                ctrlDropDownConstructionProject1.DataBindEx();
                ctrlArchiveFormType1.DataBindEx();
                ctrlArchiveFormType1.SelectValue = ProjectType;
                ctrlArchiveFormType1.Enabled = false;

                if (ConvertEx.ToInt(SingleProjectID) > 0) {
                    T_SingleProject_MDL spMDL = singleProjectBLL.GetModel(ConvertEx.ToInt(SingleProjectID));
                    if (spMDL != null) {
                        ctrlDropDownConstructionProject1.SelectValue = spMDL.ConstructionProjectID.ToString();
                        ctrlArchiveFormType1.SelectValue = spMDL.ProjectType;
                    }
                }

                if (!String.IsNullOrWhiteSpace(DNTRequest.GetString("ConstructionID"))) {
                    ctrlDropDownConstructionProject1.SelectValue = DNTRequest.GetString("ConstructionID");
                }

                if ((CommonEnum.PageState)ViewState["ps"] == CommonEnum.PageState.VIEW) {
                    btnSave.Visible = false;
                }
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e) {
            T_SingleProject_MDL spModel = new T_SingleProject_MDL();
            spModel = ctrlCompanyRegBaseInfo3_11.GetModule(ConvertEx.ToInt(SingleProjectID));

            a_single_project_MDL a_Single_Mdl = new a_single_project_MDL();
            a_Single_Mdl = ctrlCompanyRegBaseInfo3_1Ext1.GetModule(ConvertEx.ToInt(SingleProjectID));
            a_Single_Mdl.fz = spModel.fz;

            if (spModel != null) {
                if (spModel.SingleProjectID <= 0 || (CommonEnum.PageState)ViewState["ps"] == CommonEnum.PageState.ADD) {
                    #region 添加工程信息
                    spModel.ConstructionProjectID = ConvertEx.ToInt(ctrlDropDownConstructionProject1.SelectValue);
                    spModel.ProjectType = ctrlArchiveFormType1.SelectValue;
                    spModel.AREA_CODE = AREA_CODE.SelectValue;
                    spModel.gcbm = "";

                    string UserID = "";
                    if (Common.Session.GetSession("tUserID") != "") {
                        UserID = Common.Session.GetSession("tUserID");
                    } else if (Common.Session.GetSession("UserID") != "") {
                        UserID = Common.Session.GetSession("UserID");
                    }
                    spModel.CompanyUserID = Common.ConvertEx.ToInt(UserID);
                    spModel.CreateDate = DateTime.Now;
                    spModel.Status = 0;
                    int tmpSingleProjectID = singleProjectBLL.Add(spModel);
                    #endregion

                    #region 添加工程流程环节
                    new T_WorkFlowDefine_BLL().AddWorkFlowDefine(tmpSingleProjectID, spModel.AREA_CODE);
                    #endregion

                    #region 更新当前用户为本工程管理员
                    T_UsersInfo_BLL userBll = new T_UsersInfo_BLL();
                    T_UsersInfo_MDL userMdl = userBll.GetModel(Common.ConvertEx.ToInt(UserID));
                    userMdl.IsLeader = true;
                    userBll.Update(userMdl);
                    #endregion

                    #region 把此用户加入到这个工程用户中去
                    SingleProjectUser projectRole = new SingleProjectUser();
                    projectRole.Update(tmpSingleProjectID, userMdl.RoleID, userMdl.UserID);
                    #endregion

                    #region 加入到工程->公司表中去
                    T_SingleProjectCompany_MDL spcMDL = new T_SingleProjectCompany_MDL();
                    spcMDL.SingleProjectID = tmpSingleProjectID;
                    spcMDL.CompanyID = Common.Session.GetSessionInt("CompanyID");
                    T_SingleProjectCompany_BLL spcBLL = new T_SingleProjectCompany_BLL();
                    spcBLL.Add(spcMDL);
                    #endregion

                    #region 房屋专业记载
                    a_Single_Mdl.SingleProjectID = tmpSingleProjectID;
                    if (asingleProjectBLL.Exists(tmpSingleProjectID))
                        asingleProjectBLL.Update(a_Single_Mdl);
                    else
                        asingleProjectBLL.Add(a_Single_Mdl);
                    #endregion

                    #region 日志
                    PublicModel.writeLog(SystemSet.EumLogType.AddData.ToString(), string.Concat("T_SingleProject;key=", tmpSingleProjectID,
                        ";ProjectType=", spModel.ProjectType, ";gcbm=", spModel.gcbm, ";gcmc=", spModel.gcmc));
                    #endregion
                } else {
                    #region 更新工程信息
                    singleProjectBLL.Update(spModel);
                    #endregion

                    #region  判断工程,如果没有专业记载,则新增,否则修改
                    if (ConvertEx.ToInt(a_Single_Mdl.SingleProjectID) > 0) {
                        asingleProjectBLL.Update(a_Single_Mdl);
                    } else {
                        a_Single_Mdl.SingleProjectID = spModel.SingleProjectID;
                        asingleProjectBLL.Add(a_Single_Mdl);
                    }
                    #endregion

                    #region 日志
                    PublicModel.writeLog(SystemSet.EumLogType.UpdData.ToString(), string.Concat("T_SingleProject;key=", spModel.SingleProjectID,
                        ";ProjectType=", spModel.ProjectType, ";gcbm=", spModel.gcbm, ";gcmc=", spModel.gcmc));
                    #endregion
                }
            }
            Common.MessageBox.CloseLayerOpenWeb(this.Page);
        }
    }
}