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
    public partial class ctrlArchiveTypeDetail : System.Web.UI.UserControl
    {
        public delegate void ArchiveTypeChanged();
        public event ArchiveTypeChanged MyArchiveTypeChanged;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string SelectValue
        {
            set { ddlArchiveFormType.SelectedIndex = ddlArchiveFormType.Items.IndexOf(ddlArchiveFormType.Items.FindByValue(value)); }
            get { return ddlArchiveFormType.SelectedValue; }
        }

        public string SelectText
        {
            get { return ddlArchiveFormType.SelectedItem.Text; }
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
            List<s_archive_type_MDL> archiveformlist = new List<s_archive_type_MDL>();
            archiveformlist = (new s_archive_type_BLL()).GetModelList("SUBSTRING(ARCHIVE_TYPE_NO,2,3)='000'");
            ddlArchiveFormType.DataTextField = "Archive_Type_Name";//archivename
            ddlArchiveFormType.DataValueField = "Archive_Type_No";//archive_form_no   Archive_Type_No,Archive_Type_Name 
            //if (showRegion == "0")
            //{
            //    T_SystemInfo_MDL mdl = new T_SystemInfo_MDL();
            //    mdl.SystemInfoCode = "";
            //    mdl.SystemInfoName = "全部";
            //    archiveformlist.Insert(0, mdl);
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