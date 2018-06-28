using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.Common;
using System.Text;

//工程相关信息

namespace DigiPower.Onlinecol.Standard.Web.CompanyManage
{
    public partial class ProjectDoInfo : System.Web.UI.Page
    {
        int SingleProjectID = 0;
        protected void Page_Load(object sender, EventArgs e) {
            if (!Page.IsPostBack) {
                SingleProjectID = Common.ConvertEx.ToInt(Common.DNTRequest.GetString("SingleProjectID"));
                T_SingleProject_BLL spBLL = new T_SingleProject_BLL();
                T_SingleProject_MDL spMDL = spBLL.GetModel(SingleProjectID);

                List<T_Company_MDL> ltCompany = new T_Company_BLL().GetModelList("CompanyID=(select CompanyID from T_Construction_Project where ConstructionProjectID=" + Common.ConvertEx.ToString(spMDL.ConstructionProjectID) + ")");
                Comm.SetValueToPage(spMDL, this.tbl);

                gczt.Text = PublicModel.getSingleProjectStatusNameByStatus(ConvertEx.ToInt(spMDL.Status));//工程状态
                if (ltCompany.Count > 0) {
                    companyName.Text = ltCompany[0].CompanyName;            //单位名称 
                    ChargeUserName.Text = ltCompany[0].ChargeUserName;      //项目负责人
                    ContactPerson_Tel.Text = ltCompany[0].ContactPerson + "(" + ltCompany[0].Tel + ")";        //联系人 ,联系电话
                }
                GetWorkFlowHtml(spMDL);
            }
        }

        protected string GetUserName(int userID) {
            T_UsersInfo_MDL Mdl = new T_UsersInfo_BLL().GetModel(userID);
            if (Mdl != null)
                return Common.ConvertEx.ToString(Mdl.UserName);
            else
                return "";
        }

        protected void GetWorkFlowHtml(T_SingleProject_MDL spMDL) {
            if (spMDL != null) {
                StringBuilder strBuilder = new StringBuilder();

                DateTime createDt = ConvertEx.ToDate(spMDL.CreateDate);
                strBuilder.Append("<h2 class=\"first\"><a href=\"#nogo\">" + createDt.ToString("yyyy") + "年</a></h2> ");
                strBuilder.Append("<li> ");
                strBuilder.Append("    <h3>" + createDt.ToString("MM.dd") + "<span>" + createDt.ToString("yyyy") + "</span></h3> ");
                strBuilder.Append("    <dl> ");
                strBuilder.Append("        <dt>工程开始报建");
                strBuilder.Append("                <span>" + spMDL.jsdw + " </span> ");
                strBuilder.Append("        </dt> ");
                strBuilder.Append("    </dl>");
                strBuilder.Append("</li> ");

                DataSet ds = new T_WorkFlowDefine_BLL().GetProjectListByWorkFlowAndUser(spMDL.SingleProjectID.ToString());
                if (ds.Tables[0].Rows.Count > 0) {
                    DataTable dt = ds.Tables[0].Copy();
                    dt.Clear();
                    Recursion(ds.Tables[0], 0, ref dt);

                    foreach (DataRow row in dt.Rows) {

                        string recvDateTime = String.IsNullOrEmpty(ConvertEx.ToString(row["RecvDateTime"])) ? "" :
                            Convert.ToDateTime(row["RecvDateTime"]).ToString("yyyy-MM-dd HH:mm:ss");
                        string submitDateTime = String.IsNullOrEmpty(ConvertEx.ToString(row["SubmitDateTime"])) ? "" :
                                Convert.ToDateTime(row["SubmitDateTime"]).ToString("yyyy-MM-dd HH:mm:ss");

                        if (ConvertEx.ToInt(row["DoStatus"]) == 1 && ConvertEx.ToInt(spMDL.Status) < 3722)
                            strBuilder.Append("<li class=\"green\">");
                        else
                            strBuilder.Append("<li>");

                        if (recvDateTime.Length > 0)
                            strBuilder.Append("    <h3>" + ConvertEx.ToDate(recvDateTime).ToString("MM.dd") + "<span>" +
                                ConvertEx.ToDate(recvDateTime).ToString("yyyy") + "</span></h3> ");
                        else
                            strBuilder.Append("    <h3>&nbsp;<span>&nbsp;</span></h3> ");

                        strBuilder.Append("    <dl>");
                        strBuilder.Append("        <dt>" + ConvertEx.ToString(row["WorkFlowName"]) + "");
                        strBuilder.Append("                <span>");
                        if (!string.IsNullOrWhiteSpace(row["RecvUserName"].ToString()) && !string.IsNullOrWhiteSpace(recvDateTime)) {
                            strBuilder.Append(String.Concat("受理人:", Convert.ToString(row["RecvUserName"]), "&nbsp;&nbsp;", "受理时间:", recvDateTime));
                        }
                        if (!string.IsNullOrWhiteSpace(row["SubmitUserName"].ToString()) && !string.IsNullOrWhiteSpace(submitDateTime)) {
                            strBuilder.Append(String.Concat("<br/>", "提交人:", Convert.ToString(row["SubmitUserName"]), "&nbsp;&nbsp;", "提交时间:", submitDateTime));
                        }
                        strBuilder.Append("                </span>");
                        strBuilder.Append("        </dt> ");
                        strBuilder.Append("    </dl> ");
                        strBuilder.Append("</li> ");
                    }
                }

                if (ConvertEx.ToInt(spMDL.Status) == 3722 && spMDL.Rksj != null) {
                    strBuilder.Append("<li class=\"green\"> ");
                    strBuilder.Append("    <h3>" + ConvertEx.ToDate(spMDL.Rksj).ToString("MM.dd") + "<span>" + ConvertEx.ToDate(spMDL.Rksj).ToString("yyyy") + "</span></h3> ");
                    strBuilder.Append("    <dl> ");
                    strBuilder.Append("        <dt>工程档案数据已移交到库房");
                    strBuilder.Append("                <span>" + ConvertEx.ToDate(spMDL.Rksj).ToString("yyyy-MM-dd HH:mm:ss") + " </span> ");
                    strBuilder.Append("        </dt> ");
                    strBuilder.Append("    </dl>");
                    strBuilder.Append("</li> ");
                }
                ltWorkFlow.Text = strBuilder.ToString();
            }
        }

        public void Recursion(DataTable dt, int PID, ref DataTable outDT) {
            DataRow[] dr = dt.Select("PID='" + PID + "'");
            foreach (DataRow drr in dr) {
                outDT.Rows.Add(drr.ItemArray);

                Recursion(dt, Int32.Parse(drr["WorkFlowID"].ToString()), ref outDT);
            }
        }
    }
}
