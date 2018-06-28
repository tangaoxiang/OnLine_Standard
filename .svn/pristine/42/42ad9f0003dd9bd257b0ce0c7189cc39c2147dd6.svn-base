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
using System.Collections.Generic;
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.CBLL;
using DigiPower.Onlinecol.Standard.Common;
using System.Text;

namespace DigiPower.Onlinecol.Standard.Web.WorkFlow
{
    public partial class ReadCheckBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (DNTRequest.GetQueryString("SingleProjectID") != "")
                {
                    BeginDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");

                    string SingleProjectID = DNTRequest.GetQueryString("SingleProjectID");
                    string CodeType = null;

                    if (DNTRequest.GetQueryString("WorkFlowCode") == SystemSet.WorkFlowStatus.ONLINE_CHECK.ToString()) CodeType = "1"; //在线预验收
                    else if (DNTRequest.GetQueryString("WorkFlowCode") == SystemSet.WorkFlowStatus.WINRECV.ToString()) CodeType = "2";  //业务审核(窗口接收)
                    else if (DNTRequest.GetQueryString("WorkFlowCode") == SystemSet.WorkFlowStatus.SIGNER.ToString()) CodeType = "3";   //科室负责人审核
                    HidCodeType.Value = CodeType;
                    HidSingleProjectID.Value = SingleProjectID;


                    T_SingleProject_MDL singMDL = new T_SingleProject_BLL().GetModel(ConvertEx.ToInt(SingleProjectID));
                    if (singMDL != null)
                    {
                        gcdd.Text = singMDL.gcdd;
                        gcmc.Text = singMDL.gcmc;
                    }


                    List<T_ReadyCheckBook_MDL> ltMdl = new T_ReadyCheckBook_BLL().GetModelList("SingleProjectID=" + SingleProjectID + " AND CodeType='" + CodeType + "'");
                    if (ltMdl.Count > 0)
                    {
                        T_ReadyCheckBook_MDL Mdl = ltMdl[0];
                        ReadyCheckBookCode.Text = Mdl.ReadyCheckBookCode.Trim();
                        //EndDate.Text = ConvertEx.ToDate(Mdl.EndDate).ToString("yyyy-MM-dd");
                        BeginDate.Text = ConvertEx.ToDate(Mdl.BeginDate).ToString("yyyy-MM-dd");
                        zljddw.Text = Mdl.zljddw.Trim();
                        ArchiveUserName.Text = Mdl.ArchiveUserName.Trim();
                        ArchiveUser_Tel.Text = Mdl.ArchiveUser_Tel.Trim();
                        jsdwfzr_Name.Text = Mdl.jsdwfzr_Name.Trim();
                        jsdwfzr_Tel.Text = Mdl.jsdwfzr_Tel.Trim();

                        Label1.Text = "已发";
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string CodeType = HidCodeType.Value;
            string SingleProjectID = HidSingleProjectID.Value;

            //1=ONLINE_CHECK  在线预验收
            //2=WINRECV       窗口接收
            //3=CHECK         业务审核            

            T_ReadyCheckBook_BLL Bll = new T_ReadyCheckBook_BLL();
            T_ReadyCheckBook_MDL Mdl = new T_ReadyCheckBook_MDL();
            Mdl.SingleProjectID = ConvertEx.ToInt(SingleProjectID);
            Mdl.ReadyCheckBookCode = ReadyCheckBookCode.Text;
            Mdl.EndDate = System.DateTime.Now;// ConvertEx.ToDate(EndDate.Text);

            Mdl.zljddw = zljddw.Text.Trim();
            Mdl.ArchiveUser_Tel = ArchiveUser_Tel.Text.Trim();
            Mdl.ArchiveUserName = ArchiveUserName.Text.Trim();
            Mdl.jsdwfzr_Name = jsdwfzr_Name.Text.Trim();
            Mdl.jsdwfzr_Tel = jsdwfzr_Tel.Text.Trim();

            Mdl.BeginDate = ConvertEx.ToDate(BeginDate.Text);
            Mdl.CreateTime = DateTime.Now;
            Mdl.CreateUserID = ConvertEx.ToInt(Session["UserID"]);
            Mdl.CodeType = CodeType;

            List<T_ReadyCheckBook_MDL> ltMdl = Bll.GetModelList("SingleProjectID=" + SingleProjectID + " AND CodeType='" + CodeType + "'");
            if (ltMdl.Count > 0)
            {
                Mdl.ReadyCheckBookID = ltMdl[0].ReadyCheckBookID;
                Bll.Update(Mdl);
            }
            else
            {
                Bll.Add(Mdl);
            }
            //更新案卷审核人
            BLL.T_Archive_BLL archiveBLL = new T_Archive_BLL();
            archiveBLL.UpdateSHR(ConvertEx.ToInt(SingleProjectID), Session["UserName"].ToString());

            if (HidCodeType.Value == "3")  //科室负责人审核 打印预验收核发申请单
            {
                string url = "../ViewReport.aspx?strWhere=SingleProjectID=" + HidSingleProjectID.Value + "&ReportCode=yuyanshou_sqd";
                ClientScript.RegisterStartupScript(Page.GetType(), "open12", "<script type='text/javascript'>window.close();openCommonWindowScroll('" + url + "',800,600);</script>");
            }
            else
            {
                Response.Write("<script>javascript:window.close();</script>");
            }
        }
    }
}
