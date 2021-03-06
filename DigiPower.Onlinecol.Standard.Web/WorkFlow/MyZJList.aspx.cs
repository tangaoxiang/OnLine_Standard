﻿using System;
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

//单位案卷整理

namespace DigiPower.Onlinecol.Standard.Web.WorkFlow {
    public partial class MyZJList : PageBase {
        T_FileList_BLL fileListBLL = new T_FileList_BLL();
        T_MyArchive_BLL myArchiveBLL = new T_MyArchive_BLL();
        T_SingleProject_BLL singleProjectBLL = new T_SingleProject_BLL();

        protected void Page_Load(object sender, EventArgs e) {
            ddlSingleProject.MySelectChanged += new DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownSingleProject.SelectChanged(ddlSingleProject_MySelectChanged);
            ddlCompany.MySelectChange += new DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownCompanyInfo.SelectChange(ddlCompany_SelectedIndexChanged);

            if (!this.IsPostBack) {
                ddlSingleProject.DataBindEx2(Common.Session.GetSessionInt("CompanyID"));
                ddlSingleProject_MySelectChanged();

                string CompanyID = Common.Session.GetSession("CompanyID");
                if (CompanyID != "") {
                    ddlCompany.SelectValue = CompanyID;
                    DataBindExMyCode(CompanyID);
                }
                //boxType.DataBindEx();
                ajlx.DataBindEx();
                mj.DataBindEx();
                bgqx.DataBindEx();


                btnSearch_Click(null, null);
            }
        }

        /// <summary>
        /// 绑定未组卷归档目录
        /// </summary>
        private void BindFileList(string singleProjectID, string projectName) {
            #region  案卷信息预填充
            lrr.Text = Common.Session.GetSession("Username");
            bzdw.Text = ddlCompany.Text;
            lrsj.Text = DateTime.Now.ToString("yyyy-MM-dd");
            ajtm.Text = projectName;
            xh.Text = (myArchiveBLL.getMaxArchiveXhBySingleProjectID(singleProjectID) + 10).ToString();
            #endregion

            string strWhere = "SingleProjectID=" + singleProjectID;
            DataSet ds = (new T_FileList_BLL()).GetList(strWhere, "bh asc");          //取当前工程的所有归档目录      
            if (ds.Tables.Count > 0) {
                strWhere = string.Empty;

                DataTable outDT = ds.Tables[0].Copy();
                outDT.Clear();
                Recursion(ds.Tables[0], 0, 0, ref outDT);
                ds.Tables.Clear();
                ds.Tables.Add(outDT);

                if (ddlSingleProject.SelectValue != "")
                    strWhere += " AND SingleProjectID=" + ddlSingleProject.SelectValue + "";
                if (ddlCompany.SelectValue != "")
                    strWhere += " AND CompanyID=" + ddlCompany.SelectValue + "";
                if (ddlMyCode.SelectedValue != "")
                    strWhere += " AND MYCODE LIKE '%" + ddlMyCode.SelectedValue + "%'";
                if (txtTitle.Text.Trim().Length > 0)
                    strWhere += " AND TITLE LIKE '%" + txtTitle.Text.Trim() + "%'";


                strWhere = " IsFolder=1 OR (IsFolder=0 AND ISNULL(MyArchiveID,0)=0 AND ManualCount>0 " + strWhere + ")";

                DataView dv = ds.Tables[0].Copy().DefaultView;
                dv.RowFilter = strWhere;
                dv.Sort = "bh asc";
                if (dv.Count != ds.Tables[0].Rows.Count) {
                    ds.Tables[0].Clear();
                    ds.Tables.RemoveAt(0);
                    ds.Tables.Add(dv.ToTable());
                }

                TreeNode tNode1 = new TreeNode();
                tNode1.Text = "未组卷文件列表：" + projectName;
                tNode1.Value = "0";

                DsToTreeNode(ds.Tables[0], 0, tNode1);
                TreeView1.Nodes.Clear();
                TreeView1.Nodes.Add(tNode1);
                TreeView1.ExpandDepth = 1;
            }
        }

        /// <summary>
        /// 绑定已组卷文件
        /// </summary>
        private void BindTreeYZJ(string singleProjectID, string projectName) {
            if (ddlCompany.SelectValue != "") {
                string strSql = "SingleProjectID=" + singleProjectID + " AND CompanyID=" + ddlCompany.SelectValue;//已组卷

                DataSet dsArchive = new DataSet();

                TreeNode tNode2 = new TreeNode();
                tNode2.Text = "已组卷档案列表：" + projectName;
                tNode2.Value = "0";
                dsArchive = myArchiveBLL.GetList(strSql);
                if (dsArchive.Tables[0].Rows.Count > 0) {
                    int iIndex = 1;//显示顺序
                    foreach (DataRow dr in dsArchive.Tables[0].Rows) {
                        string ajFileCount = fileListBLL.GetPageCountByMyArchiveID(dr["ArchiveID"].ToString().Trim());  //实体页数
                        TreeNode tNodeAJ = new TreeNode(iIndex + "、" + dr["ajtm"].ToString().Trim() + "(" + ajFileCount + ")", dr["ArchiveID"].ToString());//添加案卷信息
                        iIndex++;
                        string strArchive = "a.MyArchiveID=" + Common.ConvertEx.ToInt(dr["ArchiveID"].ToString())
                                       + " and b.SingleProjectID=" + singleProjectID;
                        DataSet dsWJinfo = new DataSet();

                        dsWJinfo = fileListBLL.GetList("MyArchiveID=" + dr["ArchiveID"].ToString(), "bh");
                        if (dsWJinfo.Tables[0].Rows.Count > 0) {
                            foreach (DataRow drwj in dsWJinfo.Tables[0].Rows) {
                                TreeNode tNodeWJ = new TreeNode(drwj["bh"].ToString() + "、" + drwj["title"].ToString().Trim() + "(" + drwj["ManualCount"].ToString() + ")", drwj["FileListID"].ToString());
                                tNodeAJ.ChildNodes.Add(tNodeWJ);
                            }
                        }
                        tNode2.ChildNodes.Add(tNodeAJ);
                    }
                }
                TreeView2.Nodes.Clear();
                TreeView2.Nodes.Add(tNode2);
                TreeView2.ExpandDepth = 1;
            }
        }

        private void Recursion(DataTable dt, int PID, int LevelID, ref DataTable outDT) {
            DataRow[] dr = dt.Select("PID='" + PID + "'", "OrderIndex");
            foreach (DataRow drr in dr) {
                drr["title"] = Comm.AddEmpty(drr["bh"].ToString().Trim() + "|" + drr["title"].ToString().Trim(), LevelID);
                outDT.Rows.Add(drr.ItemArray);

                int NewLevelID = LevelID + 1;
                Recursion(dt, Int32.Parse(drr["recid"].ToString()), NewLevelID, ref outDT);
            }
        }

        private void DsToTreeNode(DataTable dt, int PID, TreeNode pNode) {//如果无子项，不要显示出来。
            DataRow[] dr = dt.Select("PID='" + PID + "'");
            foreach (DataRow drr in dr) {
                string NewTitle = drr["title"] + "(" + drr["ManualCount"] + ")";
                if (Common.ConvertEx.ToBool(drr["IsFolder"]) == true) {//求子项总数，drr["ManualCount"]==0的，需要计算
                    int ManualCount = GetPageCountByPID(dt, Common.ConvertEx.ToInt(drr["recID"].ToString()));
                    NewTitle = drr["title"] + "(" + ManualCount + ")";
                }
                TreeNode tNode = new TreeNode(NewTitle.Trim(), drr["FileListID"].ToString());
                DsToTreeNode(dt, Int32.Parse(drr["recid"].ToString()), tNode);
                if (tNode.ChildNodes.Count <= 0 && Common.ConvertEx.ToBool(drr["IsFolder"]) == true) {
                    continue;
                }
                pNode.ChildNodes.Add(tNode);
            }
        }

        /// <summary>
        /// 获取当前节点下所有文件的实体页数    ManualCount
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="PID"></param>
        /// <returns></returns>
        private int GetPageCountByPID(DataTable dt, int PID) {
            int ManualCount = 0;
            DataRow[] dr = dt.Select("PID='" + PID + "'");
            foreach (DataRow drr in dr) {
                if (Common.ConvertEx.ToBool(drr["IsFolder"]) == true) {
                    ManualCount += Common.ConvertEx.ToInt(GetPageCountByPID(dt, Common.ConvertEx.ToInt(drr["recID"].ToString())));
                } else {
                    ManualCount += Common.ConvertEx.ToInt(drr["ManualCount"].ToString());
                }
            }
            return ManualCount;
        }

        /// <summary>
        /// 获取工程下所有文件的内部编号,过滤重复的
        /// </summary>
        /// <param name="CompanyID"></param>
        private void DataBindExMyCode(string CompanyID) {
            if (ddlSingleProject.SelectValue != "") {
                ddlMyCode.DataSource = fileListBLL.GetDistinctMyCode(ddlSingleProject.SelectValue, CompanyID);
                ddlMyCode.DataTextField = "mycode";
                ddlMyCode.DataTextField = "mycode";
                ddlMyCode.DataBind();
                ddlMyCode.Items.Insert(0, new ListItem("---请选择---", ""));
            }
        }

        private string GetTreeViewChecked(TreeNodeCollection pNodeList) {
            string outString = "";
            foreach (TreeNode pNode in pNodeList) {
                if (pNode.Checked == true) {
                    outString += pNode.Value + ",";
                }

                outString += GetTreeViewChecked(pNode.ChildNodes);
            }
            return outString;
        }

        /// <summary>
        /// Flag=2表示按所选节点组卷,1,自动组卷,3加入到指定案卷
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="selId"></param>
        private void DoZJ(string flag, string selId) {
            if (!string.IsNullOrWhiteSpace(ddlSingleProject.SelectValue)) {
                string strWhere = "SingleProjectID=" + ddlSingleProject.SelectValue + " and ISNULL(MyArchiveID,0)=0 ";
                if (flag == "2" || flag == "3")
                    strWhere += " and FileListID in (" + selId + ")";
                DataSet dsFileList = fileListBLL.GetList(strWhere);
                int ArchiveID = 0;
                int ManualCountTotal = 0;
                if (flag == "3") {
                    if (TreeView2.Nodes[0].ChildNodes.Count > 0) {
                        foreach (TreeNode tNode in TreeView2.Nodes[0].ChildNodes) {
                            if (tNode.Checked)//选中案卷
                            {
                                int tArchiveID = Common.ConvertEx.ToInt(tNode.Value.ToString());
                                Model.T_MyArchive_MDL acMDL = myArchiveBLL.GetModel(tArchiveID);
                                if (acMDL != null) {
                                    ArchiveID = acMDL.ArchiveID;
                                    ManualCountTotal = acMDL.sl;
                                }
                            }
                        }
                        if (ArchiveID == 0) {
                            Common.MessageBox.FnLayerAlert(this.Page, "请勾选右边的需加入的案卷!");
                            return;
                        }
                    } else {
                        Common.MessageBox.FnLayerAlert(this.Page, "请勾选右边的需加入的案卷!");
                        return;
                    }
                }

                if (dsFileList.Tables.Count > 0 && dsFileList.Tables[0].Rows.Count > 0) {
                    for (int i = 0; i < dsFileList.Tables[0].Rows.Count; i++) {
                        string bIsFolder = dsFileList.Tables[0].Rows[i]["IsFolder"].ToString();

                        //为目录的数据不处理，跳到下一条
                        if (ConvertEx.ToBool(bIsFolder))
                            continue;
                        else {
                            int ManualCount = ConvertEx.ToInt(dsFileList.Tables[0].Rows[i]["ManualCount"].ToString());
                            int FileListID = ConvertEx.ToInt(dsFileList.Tables[0].Rows[i]["FileListID"].ToString());

                            if (ArchiveID == 0) {//在这里创建案卷
                                ArchiveID = CreateAj(ddlSingleProject.SelectValue);
                            }
                            Model.T_FileList_MDL flMDL = fileListBLL.GetModel(FileListID);
                            flMDL.MyArchiveID = ConvertEx.ToInt(ArchiveID);
                            fileListBLL.Update(flMDL);
                        }
                    }
                    if (ArchiveID > 0) {
                        Model.T_MyArchive_MDL acMDL = myArchiveBLL.GetModel(ArchiveID);
                        acMDL.sl = ManualCountTotal;
                        myArchiveBLL.Update(acMDL);
                    }
                }
            }
        }

        /// <summary>
        /// 组卷
        /// </summary>
        /// <returns></returns>
        private int CreateAj(string singleProjectID) {
            T_MyArchive_MDL model = new T_MyArchive_MDL();

            model.ajtm = ajtm.Text;
            model.bzdw = bzdw.Text;
            model.lrr = lrr.Text;
            model.lrsj = ConvertEx.ToDate(lrsj.Text);
            model.ajlx = ajlx.SelectValue;
            model.qssj = DateTime.Now;
            model.zzsj = DateTime.Now;
            model.SingleProjectID = Common.ConvertEx.ToInt(singleProjectID);
            model.xh = myArchiveBLL.getMaxArchiveXhBySingleProjectID(singleProjectID) + 10; ;
            model.CompanyID = Common.Session.GetSessionInt("CompanyID");

            model.note = note.Text;
            model.bgqx = bgqx.SelectValue;
            model.mj = mj.SelectValue;

            return myArchiveBLL.Add(model);
        }

        /// <summary>
        /// /重新加载页面
        /// </summary>
        private void Redirect() {
            Response.Redirect("MyZJList.aspx?ModuleID=" + DNTRequest.GetQueryString("ModuleID"));
        }

        /// <summary>
        /// 按所选节点组卷
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnZJ_Click(object sender, EventArgs e) {
            string selIDList = GetTreeViewChecked(TreeView1.Nodes);
            if (selIDList.Length > 1) {
                selIDList = selIDList.Remove(selIDList.Length - 1);
                DoZJ("2", selIDList);

                Redirect();
            } else {
                Common.MessageBox.FnLayerAlert(this.Page, "请至少选择一份文件来组卷!");
            }
        }

        /// <summary>
        /// 加入到指定案卷
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnInsertZJ_Click(object sender, EventArgs e) {
            string selIDList = GetTreeViewChecked(TreeView1.Nodes);
            if (selIDList.Length > 1) {
                selIDList = selIDList.Remove(selIDList.Length - 1);
                DoZJ("3", selIDList);

                Redirect(); ;
            } else {
                Common.MessageBox.FnLayerAlert(this.Page, "请至少选择选择一个待加入的文件!");
            }
        }

        /// <summary>
        /// 拆卷
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDel_Click(object sender, EventArgs e) {
            if (TreeView2.Nodes[0].ChildNodes.Count > 0) {
                foreach (TreeNode tNode in TreeView2.Nodes[0].ChildNodes) {
                    int iCount = 0;
                    if (tNode.Checked)//选中案卷
                    {
                        string ArchiveID = tNode.Value.ToString();
                        foreach (TreeNode tNode1 in tNode.ChildNodes) {
                            if (tNode1.Checked) {
                                iCount++;
                                Model.T_FileList_MDL flMDL = fileListBLL.GetModel(Common.ConvertEx.ToInt(tNode1.Value.ToString()));
                                flMDL.MyArchiveID = 0;//拆卷,则将文件对应的案卷设置为0
                                fileListBLL.Update(flMDL);
                            }
                        }
                    }
                    if (tNode.ChildNodes.Count == iCount && iCount > 0)//==0为空卷，直接删掉
                    {
                        myArchiveBLL.Delete(Common.ConvertEx.ToInt(tNode.Value.ToString()));
                    }
                }
                Redirect();
            }
        }

        /// <summary>
        /// 更新卷内文件序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdateFileOrderIndex_Click(object sender, EventArgs e) {
            List<string> ltArchive = new List<string>();

            if (TreeView2.Nodes[0].ChildNodes.Count > 0) {
                foreach (TreeNode tNode in TreeView2.Nodes[0].ChildNodes) {
                    if (tNode.Checked)//选中案卷
                    {
                        ltArchive.Add(tNode.Value);
                    }
                }
            }
            if (ltArchive.Count > 0) {
                btnUpdateFileOrderIndex.Enabled = false;
                foreach (var archiveID in ltArchive) {
                    myArchiveBLL.updateFileOrderIndexByArchiveID(archiveID);
                }
                Common.MessageBox.FnLayerAlert(this.Page, "更新成功!");
                Redirect();
            } else {
                Common.MessageBox.FnLayerAlert(this.Page, "请选择一个案卷!");
            }
        }

        /// <summary>
        /// 获取工程下公司的内部编号
        /// </summary>
        protected void ddlCompany_SelectedIndexChanged() {
            if (ddlCompany.SelectValue != "" && ddlSingleProject.SelectValue != "") {
                DataBindExMyCode(ddlCompany.SelectValue);
            }
        }

        /// <summary>
        /// 绑定工程下所有业务单位
        /// </summary>
        protected void ddlSingleProject_MySelectChanged() {
            if (ddlSingleProject.SelectValue != "") {
                if (PublicModel.isLeader() || !PublicModel.isCompany()) {
                    ddlCompany.DataBindEx(ddlSingleProject.SelectValue, string.Concat(SystemSet._JSCOMPANYINFO, ",",
                         SystemSet._JLCOMPANYINFO, ",", SystemSet._SGCOMPANYINFO));
                } else {
                    ddlCompany.DataBindEx(ddlSingleProject.SelectValue, Common.Session.GetSessionInt("CompanyID"));
                }
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e) {
            T_SingleProject_MDL spMDL = singleProjectBLL.GetModel(Common.ConvertEx.ToInt(ddlSingleProject.SelectValue));
            if (spMDL != null) {
                BindFileList(spMDL.SingleProjectID.ToString(), spMDL.gcmc);
                BindTreeYZJ(spMDL.SingleProjectID.ToString(), spMDL.gcmc);
            }
        }
    }
}