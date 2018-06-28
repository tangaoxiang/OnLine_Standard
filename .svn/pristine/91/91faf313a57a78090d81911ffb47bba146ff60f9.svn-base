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
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.Model;
using System.Web.UI.MobileControls;
using System.Collections.Generic;
using System.Text;

namespace DigiPower.Onlinecol.Standard.Web.CommonCtrl
{
    public partial class ctrlCompanyQucikReg : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 禁用页面所有的控件
        /// </summary>
        /// <param name="flag"></param>
        public void DisabledControl()
        {
            EnableControls(table_Company, false);
            EnableControls(tablemain, false);
        }

        protected void EnableControls(Control c, bool bEnabled)
        {
            if (c is WebControl)
                ((WebControl)c).Enabled = bEnabled;

            if (c is HtmlControl)
                ((HtmlControl)c).Disabled = !bEnabled;

            foreach (Control cc in c.Controls)
                EnableControls(cc, bEnabled);
        }

        /// <summary>
        /// 将Model值赋给控件
        /// </summary>
        /// <param name="tSingleProjectID">工程ID</param>
        public void DataBindEx(int tSingleProjectID)
        {
            CTRL_AREA.BindDdlArea(true);
            ProjectType.DataBindEx();

            if (tSingleProjectID > 0)
            {
                T_SingleProject_MDL spMdl = new T_SingleProject_BLL().GetModel(tSingleProjectID); //获取工程Model
                Comm.SetValueToPage(spMdl, tablemain);                                              //将Model值赋给控件
                int ConstructionProjectID = Common.ConvertEx.ToInt(spMdl.ConstructionProjectID);    //获取项目ID
                gcdd.Text = spMdl.gcqy + spMdl.gcdd;

                if (ConstructionProjectID > 0)
                {
                    T_Construction_Project_MDL cpMdl = new T_Construction_Project_BLL().GetModel(ConstructionProjectID);
                    if (cpMdl != null)
                    {
                        int CompanyID = Common.ConvertEx.ToInt(cpMdl.CompanyID);                        //通过项目获取单位ID  
                        if (CompanyID > 0)
                        {
                            T_Company_MDL cMdl = new T_Company_BLL().GetModel(CompanyID);
                            Comm.SetValueToPage(cMdl, table_Company);
                        }
                    }

                    StringBuilder ghxkz = new StringBuilder();
                    StringBuilder sgxkz = new StringBuilder();
                    StringBuilder other = new StringBuilder();

                    //获取工程对应的所有上传证件的附件
                    List<T_FileAttach_MDL> lt_ftMdl = new T_FileAttach_BLL().GetModelList("PriKeyValue=" + tSingleProjectID.ToString());
                    foreach (T_FileAttach_MDL ftMdl in lt_ftMdl)
                    {
                        if (ftMdl.AttachCode == "ghxkz")
                        {
                            ghxkz.Append("&nbsp;&nbsp;<a style=\"color:black;\" href=\"" + ftMdl.AttachPath + "\" title='点击查看' target=\"_blank\">" + ftMdl.AttachName + "</a>&nbsp;");
                        }
                        else if (ftMdl.AttachCode == "sgxkz")
                        {
                            sgxkz.Append("&nbsp;&nbsp;<a style=\"color:black;\" href=\"" + ftMdl.AttachPath + "\" title='点击查看' target=\"_blank\">" + ftMdl.AttachName + "</a>&nbsp;");
                        }
                        else if (ftMdl.AttachCode == "other")
                        {
                            other.Append("&nbsp;&nbsp;<a style=\"color:black;\" href=\"" + ftMdl.AttachPath + "\" title='点击查看' target=\"_blank\">" + ftMdl.AttachName + "</a>&nbsp;");
                        }
                    }
                    if (ghxkz.Length > 0)
                        ltghxkz.Text = ghxkz.ToString();
                    if (sgxkz.Length > 0)
                        ltsgxkz.Text = sgxkz.ToString();
                    if (other.Length > 0)
                        ltother.Text = other.ToString();
                }
            }
        }
    }
}