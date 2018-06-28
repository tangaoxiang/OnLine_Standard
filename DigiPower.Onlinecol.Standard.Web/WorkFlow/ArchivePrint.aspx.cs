using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
using Stimulsoft.Report.Web;
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.CBLL;
using DigiPower.Onlinecol.Standard.Common;

namespace DigiPower.Onlinecol.Standard.Web.WorkFlow
{
    public partial class ArchivePrint : System.Web.UI.Page
    {
        private string _singleprojectid = "";



        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
                this._singleprojectid = Request.QueryString["ID"].ToString();
            if (!string.IsNullOrEmpty(_singleprojectid))
            {
                this.bindReport(_singleprojectid);
            }
        }


        private void bindReport(string singleprojectid)
        {           
            BLL.T_SingleProject_BLL spBLL = new T_SingleProject_BLL();
            Model.T_SingleProject_MDL spMDL = spBLL.GetModel(Common.ConvertEx.ToInt(singleprojectid));

            string strWhere = "SingleProjectID=" + singleprojectid;
            if (Common.Session.GetSession("SuperAdmin").ToLower() == "true" || Common.Session.GetSession("IsCompany") == false.ToString().ToLower())
            {//Leo 超级管理员看全部                
            }
            else if (spMDL != null && spMDL.CompanyUserID == Common.ConvertEx.ToInt(Common.Session.GetSession("UserID")))
            {//Leo 工程管理员也看全部,档案馆的人也可以看全部
            }
            else
            {
                strWhere += " and operateuserid=" + Common.Session.GetSession("UserID");
            }
            
            DataSet dsarchive = new DataSet();

            //Leo 要改
            //dsarchive = (new T_FileList_BLL()).GetClientList(strWhere);
            dsarchive = (new T_FileList_BLL()).GetList(strWhere);
            Recursion(dsarchive.Tables[0], 0, 0);
            string str_gcmc = "归档目录";
            BLL.T_SingleProject_BLL singproject = new T_SingleProject_BLL();
            DataSet dssingleproject=singproject.GetList("singleprojectid=" + singleprojectid);
            if (dssingleproject.Tables[0].Rows.Count > 0)
            {
                str_gcmc = dssingleproject.Tables[0].Rows[0]["gcmc"].ToString()+"归档目录列表";
             }
            

        //    //取报表文件和打印数据
        //    DigiPower.Onlinecol.Standard.BLL.Record record = new DigiPower.Onlinecol.Standard.BLL.Record();
        //    DataSet ds = new DataSet();
            string strReport=Server.MapPath(@"../ReportTemplate/20100409001.mrt");

            StiReport report = new StiReport();
            report.Load(strReport);

            report.RegData("报表", dsarchive);
            
            //获取工程
            StiText sti_gcmc = (StiText)report.GetComponentByName("txtGCMC");
            if (sti_gcmc != null) sti_gcmc.Text = str_gcmc;//动态设置制表单位  
        //    if (_printType == "1" || _printType == "2" || _printType == "5")
        //        StiReportResponse.ResponseAsPdf(this, report, false);
        //    else
            report.Compile();
            report.Render(false);
              StiWebViewer1.Report = report;
       }

        public void Recursion(DataTable dt, int PID, int LevelID)
        {
            DataRow[] dr = dt.Select("PID='" + PID + "'");
            foreach (DataRow drr in dr)
            {
                drr["title"] = Comm.AddEmpty(drr["title"].ToString(), LevelID);
                int NewLevelID = LevelID + 1;
                Recursion(dt, Int32.Parse(drr["recid"].ToString()), NewLevelID);
            }
        }
    }
}
