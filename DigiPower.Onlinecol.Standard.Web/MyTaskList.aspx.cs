using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.CBLL;
using System.Data;
using System.IO;

namespace DigiPower.Onlinecol.Standard.Web {
    public partial class MyTaskList : PageBase {
        /// <summary>
        /// 流程ID
        /// </summary>
        public string workFlowID = string.Empty;

        /// <summary>
        /// 流程编号
        /// </summary>
        public string workFlowCode = string.Empty;

        /// <summary>
        /// 总记录数
        /// </summary>
        int itemCount = 0;

        /// <summary>
        /// 每页页数
        /// </summary>
        int pageSize = SystemSet._PAGESIZE;

        T_WorkFlowDefine_BLL flowDefineBLL = new T_WorkFlowDefine_BLL();

        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(MyTaskList));
            workFlowID = Common.DNTRequest.GetString("workflowid");
            if (!IsPostBack) {
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("Main_gcmc")))
                    gcmc.Text = Server.UrlDecode(DNTRequest.GetQueryString("Main_gcmc"));
                if (!String.IsNullOrWhiteSpace(DNTRequest.GetQueryString("Main_gcbm")))
                    gcbm.Text = Server.UrlDecode(DNTRequest.GetQueryString("Main_gcbm"));

                BindGrid(1);
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="pageIndex"></param>
        private void BindGrid(int pageIndex) {
            BLL.T_WorkFlow_BLL wfBLL = new T_WorkFlow_BLL();
            Model.T_WorkFlow_MDL wfMDL = wfBLL.GetModel(ConvertEx.ToInt(workFlowID));
            workFlowCode = wfMDL.WorkFlowCode;

            string sqlWhere = string.Empty;

            if (PublicModel.isSuperAdmin())       //管理员管理员获取所有工程
                sqlWhere = " AND AREA_CODE LIKE '" + Common.Session.GetSession("AREA_CODE") + "%'";
            else if (PublicModel.isArchiveUser()) //档案馆用户看自己的 
                sqlWhere = " AND AREA_CODE LIKE '" + Common.Session.GetSession("OLD_AREA_CODE") + "%'";

            if (!String.IsNullOrEmpty(gcmc.Text))
                sqlWhere += " AND gcmc like '%" + gcmc.Text + "%'";
            if (!String.IsNullOrEmpty(gcbm.Text))
                sqlWhere += " AND gcbm like '%" + gcbm.Text + "%'";

            if (ViewState["CurrentPageIndex"] == null && Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex")) > 0) {
                pageIndex = Common.ConvertEx.ToInt(DNTRequest.GetQueryString("PageIndex"));
                ViewState["CurrentPageIndex"] = pageIndex;
            } else {
                pageIndex = ConvertEx.ToInt(ViewState["CurrentPageIndex"]);
            }

            bool isChargeUser = false;
            if ((SystemSet._DEFAULT_RECV_WORKFLOWID + ",").IndexOf(workFlowID + ",") > -1)
                isChargeUser = true;

            DataTable dt = null;
            if (PublicModel.isSuperAdmin())
                dt = flowDefineBLL.GetListPaging(workFlowID, false, "", "", sqlWhere, pageSize, pageIndex, out itemCount);
            else
                dt = flowDefineBLL.GetListPaging(workFlowID, Common.Session.GetSessionBool("IsCompany"),
                    "", Common.Session.GetSession("UserID"), sqlWhere, pageSize, pageIndex, out itemCount, isChargeUser);

            AspNetPager.AlwaysShow = true;
            AspNetPager.PageSize = pageSize;

            AspNetPager.RecordCount = itemCount;
            AspNetPager.CurrentPageIndex = pageIndex;

            rpData.DataSource = dt;
            rpData.DataBind();
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager_PageChanged(object sender, EventArgs e) {
            ViewState["CurrentPageIndex"] = AspNetPager.CurrentPageIndex;
            BindGrid(AspNetPager.CurrentPageIndex);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e) {
            BindGrid(1);
        }

        /// <summary>
        /// 工程提交
        /// </summary>
        /// <param name="singleProjectID"></param>
        /// <param name="workFlowID"></param>
        /// <param name="workFlowDefineID"></param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public string SubMitProject(string singleProjectID, string workFlowID, string workFlowDefineID) {
            Model.T_SingleProject_MDL spMDL = (new BLL.T_SingleProject_BLL()).GetModel(ConvertEx.ToInt(singleProjectID));
            BLL.T_FileList_BLL flBLL = new T_FileList_BLL();
            DataSet ds2 = flBLL.GetList("SingleProjectID=" + singleProjectID);
            if (!String.IsNullOrEmpty(spMDL.gcbm) && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0) {
                //窗口接收提交的时候,更新该工程所有案卷下的文件序号,根据文件编号排序更新
                if (ConvertEx.ToInt(workFlowID) == PublicModel.getWorkFlowIdByWorkFlowCode(SystemSet.EumWorkFlowCode.WINRECV.ToString()))
                    new T_Archive_BLL().updateFileOrderIndexBySingleProjectID(singleProjectID);

                BLL.T_WorkFlowDefine_BLL wkBLL = new T_WorkFlowDefine_BLL();
                Model.T_WorkFlowDefine_MDL wkMDL = wkBLL.GetModel(ConvertEx.ToInt(workFlowDefineID));

                if (String.IsNullOrEmpty(wkMDL.SubmitCellPath)) {//有些地方不需要填申请单的
                    WorkFlowManage workflowmanage = new WorkFlowManage();
                    if (workflowmanage.GoNextProjectWorkFlowSataus(ConvertEx.ToInt(singleProjectID), ConvertEx.ToInt(workFlowID)))
                        return SystemSet._RETURN_SUCCESS_VALUE;
                    else
                        return SystemSet._RETURN_FAILURE_VALUE;
                } else {  //填申请单的未做
                    return SystemSet._RETURN_SUCCESS_VALUE;
                }

            } else {
                return "请选分配任务!";
            }
        }

        /// <summary>
        /// 工程退回
        /// </summary>
        /// <param name="singleProjectID">工程ID</param>
        /// <param name="workFlowCode">流程编号</param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public string ReturnProject(string singleProjectID, string workFlowCode) {
            //更新最后一次的工程，下次它排前面，方便操作些
            T_SingleProject_BLL spBLL = new T_SingleProject_BLL();
            T_SingleProject_MDL spMDL = spBLL.GetModel(ConvertEx.ToInt(singleProjectID));
            spMDL.LastUserTime = DateTime.Now;   //提交或退回的时间 jdk 2015.03.14

            if (string.Compare(workFlowCode.ToLower(), SystemSet.EumWorkFlowCode.IMPORT_TO.ToString().ToLower(), true) == 0)
                spMDL.Status = 1;   //移交入库环节退回,则更改工程状态为1(正常)   

            spBLL.Update(spMDL);


            WorkFlowManage workflowmanage = new WorkFlowManage();
            if (workflowmanage.RollBackProjectWorkFlowStatus(ConvertEx.ToInt(singleProjectID)))
                return SystemSet._RETURN_SUCCESS_VALUE;
            else
                return SystemSet._RETURN_FAILURE_VALUE;
        }

        /// <summary>
        /// 工程受理
        /// </summary>
        /// <param name="singleProjectID">工程ID</param>
        /// <param name="workFlowDefineID">工程流程ID</param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public string AcceptProject(string singleProjectID, string workFlowDefineID) {
            BLL.T_WorkFlowDefine_BLL wkdBLL = new T_WorkFlowDefine_BLL();
            Model.T_WorkFlowDefine_MDL wkdMDL = wkdBLL.GetModel(ConvertEx.ToInt(workFlowDefineID));

            int strSubmitStatus = wkdMDL.SubmitStatus;
            if (strSubmitStatus == 0 || strSubmitStatus == 1) {//第一个流程strSubmitStatus=0;
                wkdMDL.SubmitStatus = 2;//受理完成状态
                wkdMDL.RecvUserID = ConvertEx.ToInt(Common.Session.GetSession("UserID"));
                wkdMDL.RecvDateTime = DateTime.Now;
                wkdBLL.Update(wkdMDL);

                //=====受理时需要加入权限的。否则看不到的。
                CBLL.SingleProjectUser projectRole = new DigiPower.Onlinecol.Standard.CBLL.SingleProjectUser();
                projectRole.Update(Common.ConvertEx.ToInt(singleProjectID), ConvertEx.ToInt(Session["RoleID"].ToString()),
                    ConvertEx.ToInt(Session["UserID"].ToString()));
                //============================
                return SystemSet._RETURN_SUCCESS_VALUE;
            } else {
                return SystemSet._RETURN_FAILURE_VALUE;
            }
        }

        /// <summary>
        /// 判断工程是否被受理
        /// </summary>
        /// <param name="singleProjectID">工程ID</param>
        /// <param name="workFlowID">流程ID</param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public bool CheckRecvStatus(string singleProjectID, string workFlowID) {
            if (!Common.Session.GetSessionBool("IsCompany")) {
                T_WorkFlowDefine_BLL wfDefine = new T_WorkFlowDefine_BLL();
                DataSet ds = wfDefine.GetList("SingleProjectID=" + singleProjectID + " AND WorkFlowID=" + workFlowID + " AND SubmitStatus<>2");
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0) //未受理
                    return false;
                else
                    return true;
            }
            return true;
        }

        /// <summary>
        /// 检查工程下的文件签章是否完成
        /// </summary>
        /// <param name="singleProjectID"></param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public string FileCheckBySignatureFinish(string singleProjectID) {
            T_FileList_BLL fileListBLL = new T_FileList_BLL();
            List<string> ltResult = new List<string>();
            DataTable dt = fileListBLL.GetFileListBySignatureFinishStatus(singleProjectID, 0);
            if (dt != null) {
                List<string> ltFileResult = new List<string>();
                int SingleProjectID = 0;
                foreach (DataRow row in dt.Rows) {
                    if (SingleProjectID == 0) {    
                        ltResult.Add("*********************签章未完成的文件列表*********************");
                        ltResult.Add(string.Concat("工程编号:", row["gcbm"], ";工程名称:", row["gcmc"]));
                    }
                    ltResult.Add("----------------------------------------------------------------");
                    ltResult.Add(string.Concat("文件编号:", row["BH"], ";文件题名:", row["Title"], ";需签章/已签章", 
                        row["SignatureTmpCount"], "/", row["FinishSignaturecount"]));
                    SingleProjectID = Common.ConvertEx.ToInt(row["SingleProjectID"]);
                }
            }
            if (ltResult.Count > 0) {
                string txtFileName = Guid.NewGuid().ToString() + ".txt";
                FileStream fs1 = new FileStream(Server.MapPath("/Upload/TempReport/" + txtFileName), FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs1);
                foreach (string str in ltResult) {
                    sw.WriteLine(str);
                }
                sw.Close();
                fs1.Close();
                return txtFileName;
            } else {
                return "0";
            }
        }
    }
}