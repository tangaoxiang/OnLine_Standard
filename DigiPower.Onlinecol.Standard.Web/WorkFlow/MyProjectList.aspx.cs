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

namespace DigiPower.Onlinecol.Standard.Web
{
    public partial class MyProjectList : PageBase
    {
        public string _SingleProjectID = "";
        public string _WorkFlowID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            ctrlGridEx1.SelCheckType = DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlGridEx.SelType.Radio;

            if (!IsPostBack)
            {
                BindGrid();
            }            
        }

        void BindGrid()
        {
            string sqlWhere = "";
            if (!String.IsNullOrEmpty(gcmc.Text))
            {
                sqlWhere += " AND gcmc like '%" + gcmc.Text + "%'";
            }
            if (!String.IsNullOrEmpty(gcbm.Text))
            {
                sqlWhere += " AND gcbm like '%" + gcbm.Text + "%'";
            }

            BLL.T_SingleProject_BLL projBLL = new T_SingleProject_BLL();
            DataSet ds1 = projBLL.GetListEx(Common.Session.GetSessionInt("CompanyID"), sqlWhere);

            List<GridExPara> l1 = new List<GridExPara>();

            GridExPara p1 = new GridExPara();
            p1.FieldName = "ProjectTypeName";
            l1.Add(p1);

            GridExPara p2 = new GridExPara();
            p2.FieldName = "gcmc";
            l1.Add(p2);

            GridExPara p3 = new GridExPara();
            p3.FieldName = "gcbm";
            l1.Add(p3);

            GridExPara p4 = new GridExPara();
            p4.FieldName = "gcdd";
            l1.Add(p4);

            GridExPara p5 = new GridExPara();
            p5.FieldName = "ghxkzh";
            l1.Add(p5);

            GridExPara p6 = new GridExPara();
            p6.FieldName = "sgxkzh";
            l1.Add(p6);

            ctrlGridEx1.InitGrid("SingleProjectID", l1, ds1, "", true, false, "");
            tablebtn.Visible = true;
        }
        
        /// <summary>
        /// 窗口验收
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCkys_Click(object sender, EventArgs e)
        {//2222
                List<string> sellist = ctrlGridEx1.GetSelects();
                if (sellist.Count > 0)
                {
                    string url = "/WorkFlow/ArchiveList.aspx?WorkFlowCode=WINRECV&MyTaskList=1&ShowFlag=3&SingleProjectID=" + sellist[0].ToString() + "&WorkFlowID=" ;
                    Response.Redirect(url);
                }
        }

        protected void btnDHZJ_Click(object sender, EventArgs e)
        {//11
            List<string> sellist = ctrlGridEx1.GetSelects();
            if (sellist.Count > 0)
            {
                string url = "MyZJList.aspx?SingleProjectID=" + sellist[0].ToString();
                Response.Redirect(url);
            }
        }


        protected void btnSingleProjectInfo_Click(object sender, EventArgs e)
        {//11
            List<string> sellist = ctrlGridEx1.GetSelects();
            if (sellist.Count > 0)
            {
                T_SingleProject_MDL model = (new T_SingleProject_BLL()).GetModel(ConvertEx.ToInt(sellist[0].ToString()));
                string url = "/companymanage/companyreg3_" +
                    PublicModel.GetFileTypeForProjectType(model.ProjectType) + "edit.aspx?action=view&ProjectType=" +
                    model.ProjectType + "&id=" + sellist[0].ToString();
                ClientScript.RegisterStartupScript(Page.GetType(), "open15", "<script type='text/javascript'>openCommonWindowScroll('" + url + "',950,600);</script>");
                //string url = "/companymanage/companyreg3_" + model.ProjectType + "edit.aspx?action=view&id=" + sellist[0].ToString();
                //ClientScript.RegisterStartupScript(Page.GetType(), "open15", "<script type='text/javascript'>openCommonWindowScroll('" + url + "',950,600);</script>");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}