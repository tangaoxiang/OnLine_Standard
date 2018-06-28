using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.BLL;

namespace DigiPower.Onlinecol.Standard.Web.CommonCtrl
{
    public partial class ctrlArchiveFormType : System.Web.UI.UserControl
    {
        public delegate void ArchiveTypeChanged();
        public event ArchiveTypeChanged MyArchiveTypeChanged;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string Width
        {
            set { ddlArchiveFormType.Width = new Unit(value); }
        }
        public string CssClass
        {
            set { ddlArchiveFormType.CssClass = value; }
        }

        public string SelectValue
        {
            set { ddlArchiveFormType.SelectedIndex = ddlArchiveFormType.Items.IndexOf(ddlArchiveFormType.Items.FindByValue(value)); }
            get { return ddlArchiveFormType.SelectedValue; }
        }

        public void DataBindEx()
        {
            //取表s_archive_form,著录单类别

            //List<S_Archive_Form_MDL> archiveformlist = new List<S_Archive_Form_MDL>();
            //archiveformlist = (new S_Archive_Form_BLL()).GetModelList("AppID=2");
            //ddlArchiveFormType.DataTextField = "archivename";
            //ddlArchiveFormType.DataValueField = "archive_form_no";
            //ddlArchiveFormType.DataSource = archiveformlist;
            //ddlArchiveFormType.DataBindEx();
            DataBindEx("1");
        }
        public bool Enabled
        {
            set
            {
                ddlArchiveFormType.Enabled = value;
            }
        }

        public void DataBindEx(string showRegion)
        {
            //Leo showRegion 1:基本类别，2，扩展类别 0全部
            //取表s_archive_form,著录单类别
            List<T_SystemInfo_MDL> archiveformlist = new List<T_SystemInfo_MDL>();
            archiveformlist = (new T_SystemInfo_BLL()).GetModelList("CurrentType='Archive_Form'");
            ddlArchiveFormType.DataTextField = "SystemInfoName";//archivename
            ddlArchiveFormType.DataValueField = "SystemInfoCode";//archive_form_no
            if (showRegion == "0")
            {
                T_SystemInfo_MDL mdl = new T_SystemInfo_MDL();
                mdl.SystemInfoCode = "";
                mdl.SystemInfoName = "全部";
                archiveformlist.Insert(0, mdl);
            }
            //else if (showRegion=="2")
            //{
            //    T_SystemInfo_MDL mdl = new T_SystemInfo_MDL();
            //    mdl.SystemInfoCode = "4";
            //    mdl.SystemInfoName = "管线类别";
            //    archiveformlist.Insert(archiveformlist.Count, mdl);
            //}

            ddlArchiveFormType.DataSource = archiveformlist;
            ddlArchiveFormType.DataBind();
        }

        public bool AutoPostBack
        {
            set { ddlArchiveFormType.AutoPostBack = value; }
        }

        protected void ddlArchiveFormType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MyArchiveTypeChanged != null)
                MyArchiveTypeChanged();
        }
    }
}