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

namespace DigiPower.Onlinecol.Standard.Web.WorkFlow
{
    public partial class WFZxyys : PageBase
    {
        T_FileList_BLL fileListBLL = new T_FileList_BLL();
        /// <summary>
        /// 工程ID
        /// </summary>
        public string singleProjectID = string.Empty;

        /// <summary>
        /// 流程ID
        /// </summary>
        public string workFlowID = string.Empty;

        /// <summary>
        /// 流程编号
        /// </summary>
        public string workFlowCode = string.Empty;

        /// <summary>
        /// 案卷ID
        /// </summary>
        public string archiveID = string.Empty;

        /// <summary>
        /// 总记录数
        /// </summary>
        int itemCount = 0;

        /// <summary>
        /// 每页页数
        /// </summary>
        int pageSize = SystemSet._PAGESIZE;

        protected void Page_Load(object sender, EventArgs e)
        {
            Ajax.Utility.RegisterTypeForAjax(typeof(WFZxyys));
            singleProjectID = DNTRequest.GetQueryString("SingleProjectID");
            workFlowID = DNTRequest.GetQueryString("WorkFlowID");
            archiveID = DNTRequest.GetQueryString("ID");
            workFlowCode = DNTRequest.GetQueryString("WorkFlowCode");

            //if (workFlowCode.ToUpper() == SystemSet.EumWorkFlowCode.WINRECV.ToString())
            //{
            //    btnApprove100.Visible = true;
            //    btnApprove101.Visible = true;
            //    btnApprove004.Visible = true;
            //    btnApprove005.Visible = true;
            //}

            if (!IsPostBack)
            {
                Status.DataBindEx(true);
                ctrlProjectBaseInfo1.DataBindEx(singleProjectID);
                ctrlDropDownFileList.DataBindEx(Common.ConvertEx.ToInt(singleProjectID), "0", "BH");

                BindGridView(1);
            }
        }

        protected void gvData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                System.Drawing.Color col = System.Drawing.Color.White;
                DataRowView view = e.Row.DataItem as DataRowView;

                CBLL.ColorList colorList = new ColorList();
                col = colorList.GetMyColor(ConvertEx.ToString(view["Status"]));
                e.Row.BackColor = col;
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (!ConvertEx.ToBool(view["IsFolder"]))
                    {
                        e.Row.Cells[i].BackColor = col;
                    }
                }
                if (Common.ConvertEx.ToBool(view["IsFolder"]))
                {
                    for (int i = 1; i < e.Row.Cells.Count; i++)
                    {
                        foreach (Control control in e.Row.Cells[i].Controls)
                        {//禁用文件节点   
                            if (control is HtmlControl)
                            {
                                if (control is HtmlInputText)
                                {
                                    ((HtmlInputText)control).Attributes.Add("style", "border:solid 0px");
                                }

                                ((HtmlControl)control).Disabled = true;
                            }
                            if (control is WebControl)
                            {
                                if (control is TextBox)
                                {
                                    ((TextBox)control).Attributes.Add("style", "border:solid 0px");
                                }

                                ((WebControl)control).Enabled = false;
                            }
                        }
                    }
                }
            }
        }

        protected void btnRollBack_Click(object sender, EventArgs e)
        {
            //回滚工程流程
            //WorkFlowManage workflowmanage = new WorkFlowManage();
            //if (workflowmanage.RollBackProjectWorkFlowStatus(ConvertEx.ToInt(SingleProjectID.Value)))
            //{
            //    Response.Redirect("~/right.aspx");
            //}
            //else
            //    MessageBox.Show(this, "退回失败，请检查数据。");
        }

        //绑定归档目录
        void BindGridView(int pageIndex)
        {
            BLL.T_SingleProject_BLL spBLL = new T_SingleProject_BLL();
            Model.T_SingleProject_MDL spMDL = spBLL.GetModel(Common.ConvertEx.ToInt(singleProjectID));

            string strWhere = " SingleProjectID=" + singleProjectID + "  AND ArchiveID=" + archiveID;

            if (ctrlDropDownFileList.SelectValue != "0")
            {
                strWhere += " AND BH like '" + ctrlDropDownFileList.SelectValue + "%' ";
            }
            if (txtTitle.Text != "")
            {
                strWhere += " AND TITLE LIKE '%" + txtTitle.Text + "%'";
            }
            if (Status.SelectValue != "0" && Status.SelectValue != "")
            {
                strWhere += " AND Status=" + Status.SelectValue;
            }

            DataTable dt = fileListBLL.GetListPaging(strWhere, pageSize, pageIndex, out itemCount); ;

            AspNetPager.AlwaysShow = true;
            AspNetPager.PageSize = pageSize;

            AspNetPager.RecordCount = itemCount;

            gvData.DataSource = dt;
            gvData.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //WorkFlowManage workflowmanage = new WorkFlowManage();
            //if (workflowmanage.GoNextProjectWorkFlowSataus(ConvertEx.ToInt(SingleProjectID.Value), ConvertEx.ToInt(workflowid.Value)))
            //{
            //    Response.Redirect("~/right.aspx");
            //}
            //else
            //    MessageBox.Show(this, "提交预验收失败，请检查数据。");
        }

        protected void btnQuestion_Click(object sender, EventArgs e)
        {
            //string url = "/WorkFlow/addquestion.aspx?SingleProjectID=" + SingleProjectID.Value;
            //List<string> sellist = ctrlGridEx1.GetSelects();
            //if (sellist.Count > 0)
            //{
            //    url = "/WorkFlow/addquestion.aspx?SingleProjectID=" + SingleProjectID.Value + "&archivelistid=" + sellist[0];
            //}
            //ClientScript.RegisterStartupScript(Page.GetType(), "open19", "<script type='text/javascript'>openCommonWindowScroll('" + url + "',600,300);</script>");
        }



        /// <summary>
        /// 预验收/验收意见书/窗口回执
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnApprove001_Click(object sender, EventArgs e)
        {
            //string SingleProjectID = DNTRequest.GetString("SingleProjectID");
            //string ShowFlag = DNTRequest.GetString("ShowFlag");

            //if (ShowFlag == "1")     //预验收
            //{
            //    BLL.T_ReadyCheckBook_BLL readyBLL = new T_ReadyCheckBook_BLL();
            //    DataSet ds1 = readyBLL.GetList("SingleProjectID=" + SingleProjectID + " AND CodeType='1' ");
            //    if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            //    {
            //        string url = "../ViewReport.aspx?strWhere=SingleProjectID=" + SingleProjectID + "&ReportCode=yuyanshou_yjs";
            //        ClientScript.RegisterStartupScript(Page.GetType(), "open20", "<script type='text/javascript'>openCommonWindowScroll('" + url + "',800,600);</script>");
            //    }
            //    else
            //    {
            //        Common.MessageBox.Show(this, "未发放相关证件！");
            //    }
            //}
            //else if (ShowFlag == "4")//验收
            //{
            //    string url = "../ViewReport.aspx?strWhere=SingleProjectID=" + SingleProjectID + "&ReportCode=yuyanshou_ys";
            //    ClientScript.RegisterStartupScript(Page.GetType(), "open21", "<script type='text/javascript'>openCommonWindowScroll('" + url + "',800,600);</script>");
            //}
            //else if (ShowFlag == "3")//窗口回执
            //{
            //    string url = "../ViewReport.aspx?strWhere=SingleProjectID=" + SingleProjectID + "&ReportCode=shengchahuizhi";
            //    ClientScript.RegisterStartupScript(Page.GetType(), "open22", "<script type='text/javascript'>openCommonWindowScroll('" + url + "',800,600);</script>");
            //}
        }

        protected void btnQuestionList_Click(object sender, EventArgs e)
        {
            //Response.Redirect("QuestionList.aspx?SingleProjectID=" + SingleProjectID.Value);
        }

        protected void btnAdd001_Click(object sender, EventArgs e)
        {
            //List<string> sellist = ctrlGridEx1.GetSelects();
            //if (sellist.Count > 0)
            //{
            //    T_Other_BLL otherBLL = new T_Other_BLL();
            //    foreach (string ArchiveListID in sellist)
            //    {
            //        otherBLL.UpdateArchiveStatus(ArchiveListID, 20, "0");
            //    }
            //    btnModify001_Click(sender, e);
            //}
        }

        protected void btnAdd002_Click(object sender, EventArgs e)
        {
            //List<string> sellist = ctrlGridEx1.GetSelects();
            //if (sellist.Count > 0)
            //{
            //    T_Other_BLL otherBLL = new T_Other_BLL();
            //    foreach (string ArchiveListID in sellist)
            //    {
            //        otherBLL.UpdateArchiveStatus(ArchiveListID, 900, "0");
            //    }
            //    btnModify001_Click(sender, e);
            //}
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGridView(1);
        }

        protected void btnFilen1_Click(object sender, EventArgs e)
        {
            //string url = "/WorkFlow/zj.aspx?SingleProjectID=" + SingleProjectID.Value + "&flag=1";
            //ClientScript.RegisterStartupScript(Page.GetType(), "open23", "<script type='text/javascript'>openCommonWindowScroll('" + url + "',650,300);</script>");
        }

        protected void btnFilen2_Click(object sender, EventArgs e)
        {
            //List<string> listSel = ctrlGridEx1.GetSelects();
            //StringBuilder sbSel = new StringBuilder();
            //for (int i = 0; i < listSel.Count; i++)
            //{
            //    sbSel.Append(listSel[i]);
            //    sbSel.Append(",");
            //}

            //string url = "/WorkFlow/zj.aspx?SingleProjectID=" + SingleProjectID.Value + "&flag=2&selId=" + sbSel.ToString().Substring(0, sbSel.ToString().Length - 1);
            //ClientScript.RegisterStartupScript(Page.GetType(), "open24", "<script type='text/javascript'>openCommonWindowScroll('" + url + "',650,300);</script>");
        }

        protected void btnModify001_Click(object sender, EventArgs e)
        {
            //string ShowFlag = DNTRequest.GetString("ShowFlag");
            //if (ShowFlag == "1")
            //{//预验收
            //    List<string> li = ctrlGridEx1.GetSelects();
            //    DigiPower.Onlinecol.Standard.BLL.T_FileList_BLL bll = new T_FileList_BLL();
            //    if (li.Count > 0)
            //    {
            //        List<int> selectRowIndexList = ctrlGridEx1.GetSelectsRowIndexList();
            //        for (int i = 0; i < li.Count; i++)
            //        {
            //            string grID = li[i];

            //            DigiPower.Onlinecol.Standard.Model.T_FileList_MDL model = new T_FileList_MDL();
            //            model = bll.GetModel(Common.ConvertEx.ToInt(grID));
            //            TextBox objRemark = (TextBox)ctrlGridEx1.Rows[selectRowIndexList[i]].FindControl("Remark");//.Cells[6].Controls[0]).Text.Trim();
            //            if (objRemark != null)
            //            {
            //                model.Remark = objRemark.Text;

            //                CheckBox objMustSubmitFlag = (CheckBox)ctrlGridEx1.Rows[selectRowIndexList[i]].FindControl("MustSubmitFlag");
            //                model.MustSubmitFlag = objMustSubmitFlag.Checked;
            //                bll.Update(model);
            //            }
            //        }
            //        BindGridView();
            //    }
            //}
        }

        protected void btnModify002_Click(object sender, EventArgs e)
        {
            //List<string> selectList = ctrlGridEx1.GetSelects();
            //if (selectList.Count > 0)
            //{
            //    //DigiPower.Onlinecol.Standard.BLL.T_FileList_BLL bll = new T_FileList_BLL();
            //BLL.T_Other_BLL otherBLL = new DigiPower.Onlinecol.Standard.BLL.T_Other_BLL();
            //foreach (string KeyID in selectList)
            //{
            //    otherBLL.UpdateArchiveStatus(KeyID, -1, "0");//-1表示退回上一次状态
            //}
            //    BindGridView();
            //}
        }

        protected void btnApprove010_Click(object sender, EventArgs e)
        {//生成证件标志 //WorkFlowCode=ONLINE_CHECK
            //string url = "/WorkFlow/ReadCheckBook.aspx?SingleProjectID=" + SingleProjectID.Value + "&WorkFlowCode=" + HidWorkFlowCode.Value;
            //ClientScript.RegisterStartupScript(Page.GetType(), "open3", "<script type='text/javascript'>openCommonWindowScroll('" + url + "',650,300);</script>");
        }

        /// <summary>
        /// 验收通过
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnApprove004_Click(object sender, EventArgs e)
        {//Status=20 
            //List<string> selectList = ctrlGridEx1.GetSelects();
            //if (selectList.Count > 0)
            //{
            //    //DigiPower.Onlinecol.Standard.BLL.T_FileList_BLL bll = new T_FileList_BLL();
            //    BLL.T_Other_BLL otherBLL = new DigiPower.Onlinecol.Standard.BLL.T_Other_BLL();
            //    foreach (string KeyID in selectList)
            //    {
            //        otherBLL.UpdateArchiveStatus(KeyID, 20, "0");//-1表示退回上一次状态
            //    }
            //    BindGridView();
            //}
        }

        /// <summary>
        /// 验收不通过
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnApprove005_Click(object sender, EventArgs e)
        {//Status=900 
            //List<string> selectList = ctrlGridEx1.GetSelects();
            //if (selectList.Count > 0)
            //{
            //    //DigiPower.Onlinecol.Standard.BLL.T_FileList_BLL bll = new T_FileList_BLL();
            //    BLL.T_Other_BLL otherBLL = new DigiPower.Onlinecol.Standard.BLL.T_Other_BLL();
            //    foreach (string KeyID in selectList)
            //    {
            //        otherBLL.UpdateArchiveStatus(KeyID, 900, "0");//-1表示退回上一次状态
            //    }
            //    BindGridView();
            //}
        }

        /// <summary>
        /// 声像验收
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSXYS_Click(object sender, EventArgs e)
        {
            //string url = "ImageWjdj.aspx?SingleProjectId=" + SingleProjectID.Value + "&Checkflag=" + Server.UrlEncode("ONLINE_CHECK");
            //ClientScript.RegisterStartupScript(Page.GetType(), "open3", "<script type='text/javascript'>openCommonWindowScroll('" + url + "',950,700);</script>");
        }


        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager_PageChanged(object sender, EventArgs e)
        {
            BindGridView(AspNetPager.CurrentPageIndex);
        }

        public string SetTextDisabled(object isFolder)
        {
            if (ConvertEx.ToBool(isFolder))
                return " disabled='disabled' style='border:solid 0px;' ";
            else
                return "";
        }

        public string SetCheckBox(object flag)
        {
            if (ConvertEx.ToBool(flag))
                return " checked='checked' ";
            else
                return "";
        }

        /// <summary>
        /// 验收通过/不通过
        /// </summary>
        /// <param name="fileListID"></param>
        /// <param name="flag">true:验收通过,false:表示验收不通过</param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public void FileAccept(string fileListID, bool flag)
        {
            if (flag)
            { //验收通过 
                T_Other_BLL otherBLL = new T_Other_BLL();
                otherBLL.UpdateArchiveStatus(fileListID, 20, "0");
            }
            else
            { //验收不通过
                T_Other_BLL otherBLL = new T_Other_BLL();
                otherBLL.UpdateArchiveStatus(fileListID, 900, "0");
            }
        }

        /// <summary>
        /// 更新文件预验收备注及需要归档的条目
        /// </summary>
        /// <param name="fileListID"></param>
        /// <param name="remark"></param>
        /// <param name="mustSubmitFlag"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public void UpdateFile(string fileListID, string remark, string mustSubmitFlag)
        {
            T_FileList_MDL fileMDL = fileListBLL.GetModel(ConvertEx.ToInt(fileListID));
            if (fileMDL != null)
            {
                fileMDL.Remark = remark;
                fileMDL.MustSubmitFlag = ConvertEx.ToBool(mustSubmitFlag);
                fileListBLL.Update(fileMDL);
            }
        }

        /// <summary>
        /// 恢复
        /// </summary>
        /// <param name="FileListID"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public void ResetStatus(string FileListID)
        {
            BLL.T_Other_BLL otherBLL = new DigiPower.Onlinecol.Standard.BLL.T_Other_BLL();
            otherBLL.UpdateArchiveStatus(FileListID, -1, "0");//-1表示退回上一次状态
        }

        /// <summary>
        /// 入库能否查看PDF
        /// </summary>
        /// <param name="FileListID"></param>
        [Ajax.AjaxMethod]
        public bool RKLookPDFFlag(string singleProjectID)
        {
            bool flag = true;
            T_SingleProject_BLL singleProjectBLL = new T_SingleProject_BLL();
            T_SingleProject_MDL singleProjectMDL = singleProjectBLL.GetModel(ConvertEx.ToInt(singleProjectID));
            if (singleProjectMDL != null)
            {
                if (ConvertEx.ToInt(singleProjectMDL.Status) >= 3721 && !SystemSet._RKLOOKPDFFLAG
                    && singleProjectMDL.WorkFlow_DoStatus == (int)SystemSet.WorkFlowStatus.IMPORT_TO)
                {
                    flag = false;
                }
            }
            return flag;
        }
    }
}