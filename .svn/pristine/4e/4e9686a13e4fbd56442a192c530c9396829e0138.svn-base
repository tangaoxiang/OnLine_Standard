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
using DigiPower.Onlinecol.Standard.Model;
using System.Collections.Generic;

namespace DigiPower.Onlinecol.Standard.Web.WorkFlow
{
    public partial class UserArchiveAdd : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Ajax.Utility.RegisterTypeForAjax(typeof(UserArchiveAdd));
            MyAddInit();
            if (!IsPostBack)
            {
                tempPID.Attributes("onchange", "OnchangeBH()");
                tempPID.AutoPostBack = false;

                if (Request.QueryString["WorkFlowID"] != null)
                {
                    WorkFlowID.Value = Request.QueryString["WorkFlowID"].ToString();
                }
                if (!String.IsNullOrEmpty(ID))
                {
                    SingleProjectID.Value = ID;
                    tempPID.DataBindEx(Common.ConvertEx.ToInt(ID), true);
                }
                string Action = Request.QueryString["Action"].ToString();
                if (Action == "Modify")
                {
                    string FileListID = Request.QueryString["FileListID"].ToString();
                    BLL.T_FileList_BLL archiveListBLL = new DigiPower.Onlinecol.Standard.BLL.T_FileList_BLL();
                    Model.T_FileList_MDL archiveListMDL = archiveListBLL.GetModel(Common.ConvertEx.ToInt(FileListID));

                    Model.T_FileList_MDL parentMDL = archiveListBLL.GetModel("SingleProjectID=" + SingleProjectID.Value + " AND recID=" + archiveListMDL.PID);


                    DigiPower.Onlinecol.Standard.Web.Comm.SetValueToPage(archiveListMDL, this.tbl);

                    tempPID.SelectValue = parentMDL.FileListID.ToString();//父类
                }
            }
        }

        /// <summary>
        /// 获取工程编号
        /// </summary>
        /// <param name="SingleProjectID"></param>
        /// <returns></returns>
        [Ajax.AjaxMethod]
        public string GetFilelistBH(string FileListID)
        {
            string ReturnValue = "";
            try
            {
                ReturnValue = new T_FileList_BLL().GetModel(Common.ConvertEx.ToInt(FileListID)).BH;
            }
            catch
            {
                ReturnValue = "";
            }
            return ReturnValue;
        }

        /// <summary>
        /// 根据主题获取归档目录
        /// </summary>
        /// <param name="Title">Title</param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public DataTable GetFileListTable(string Title, string SingleProjectID)
        {
            try
            {
                T_FileList_BLL bll = new T_FileList_BLL();
                DataSet ds = new DataSet();
                ds = bll.GetList("SingleProjectID=" + SingleProjectID + "");
                if (ds.Tables.Count > 0)
                {
                    DataTable outDT = ds.Tables[0].Copy();
                    outDT.Clear();
                    Recursion(ds.Tables[0], 0, 0, ref outDT);
                    ds.Tables.Clear();
                    ds.Tables.Add(outDT);

                    BLL.T_SingleProject_BLL spBLL = new T_SingleProject_BLL();
                    Model.T_SingleProject_MDL spMDL = spBLL.GetModel(Common.ConvertEx.ToInt(SingleProjectID));
                    string strWhere = "1=1";
                    if (Session["SuperAdmin"].ToString().ToLower() == "true")
                    {//Leo 超级管理员看全部                
                    }
                    else if (spMDL != null && spMDL.CompanyUserID == Common.ConvertEx.ToInt(Session["UserID"]))
                    {//Leo 工程管理员也看全部
                    }
                    else
                    {
                        strWhere += " and OperateUserID=" + Session["UserID"].ToString();
                    }


                    strWhere += " AND Title like '%" + Title + "%'";

                    if (strWhere != "1=1")
                    {
                        if (ds.Tables.Count > 0)
                        {
                            DataView dv = ds.Tables[0].Copy().DefaultView;
                            dv.RowFilter = strWhere;
                            if (dv.Count != ds.Tables[0].Rows.Count)
                            {
                                ds.Tables[0].Clear();
                                ds.Tables.RemoveAt(0);
                                ds.Tables.Add(dv.ToTable());
                            }
                        }
                    }
                }
                return ds.Tables[0];
            }
            catch
            {
                return null;
            }
        }

        public void Recursion(DataTable dt, int PID, int LevelID, ref DataTable outDT)
        {
            DataRow[] dr = dt.Select("PID='" + PID + "'", "BH");
            foreach (DataRow drr in dr)
            {
                drr["title"] = Comm.AddEmpty(drr["title"].ToString(), LevelID);
                outDT.Rows.Add(drr.ItemArray);

                int NewLevelID = LevelID + 1;
                Recursion(dt, Int32.Parse(drr["recid"].ToString()), NewLevelID, ref outDT);
            }
        }
        
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            BLL.T_FileList_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_FileList_BLL();
            Model.T_FileList_MDL model = new DigiPower.Onlinecol.Standard.Model.T_FileList_MDL();
            string Action = Request.QueryString["Action"].ToString();
            if (Action == "Modify")
            {
                string FileListID = Request.QueryString["FileListID"].ToString();
                model = bll.GetModel(Common.ConvertEx.ToInt(FileListID));
                model = (Model.T_FileList_MDL)Comm.GetValueToObject(model, this.tbl);

                Model.T_FileList_MDL parentModel = bll.GetModel(Common.ConvertEx.ToInt(tempPID.SelectValue));
                model.PID = parentModel.recID;//换了父类的话

                bll.Update(model);
            }
            else
            {
                //取父类的的呢东西，
                //model = bll.GetModel("recID=" + Common.ConvertEx.ToInt(PID.SelectValue) + " AND SingleProjectID=" + SingleProjectID.Value);
                Model.T_FileList_MDL parentModel = bll.GetModel(Common.ConvertEx.ToInt(tempPID.SelectValue));

                model = parentModel;
                model = (Model.T_FileList_MDL)Comm.GetValueToObject(model, this.tbl);

                model.SingleProjectID = parentModel.SingleProjectID;
                model.DefaultCompanyType = parentModel.DefaultCompanyType;
                model.PID = parentModel.recID;

                model.recID = bll.GetMaxRecID(SingleProjectID.Value.ToString());
                model.FileListID = 0;//新增的，不可以真用老的
                model.IsFolder = false;
                model.IsSystem = false;//这是自定议的，可以删除                 
                bll.Add(model);
            }
            Response.Redirect("Wjdj.aspx?SingleProjectID=" + SingleProjectID.Value + "&WorkFlowID=" + WorkFlowID.Value + "&PageIndex=" + pPageIndex);
        }
    }
}