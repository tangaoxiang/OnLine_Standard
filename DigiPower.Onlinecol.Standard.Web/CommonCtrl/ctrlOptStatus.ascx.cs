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
    public partial class ctrlOptStatus : System.Web.UI.UserControl
    {
        public string SelectValue
        {
            get { return this.RadioButtonList1.SelectedValue; }
            set { RadioButtonList1.SelectedIndex = RadioButtonList1.Items.IndexOf(RadioButtonList1.Items.FindByValue(value)); }
        }

        public void DataBindEx()
        {
            DataBindEx(false);
        }
        public void DataBindEx(bool bIncludeAll)
        {
            BLL.T_SystemInfo_BLL sysBLL = new T_SystemInfo_BLL();
            List<T_SystemInfo_MDL> sysList = sysBLL.GetModelList(" CurrentType='118' AND IsShow<>0");
            
            for (int i1 = 0; i1 < sysList.Count; i1++)
            {//颜色显示
                //sysList[i1].SystemInfoName = "<span style=\"background-color:" + sysList[i1].SystemInfoCode + "\">" + sysList[i1].SystemInfoName + "<span>";

                sysList[i1].SystemInfoName = "<span><span style=\"background-color:" + sysList[i1].SystemInfoCode + ";width:20px\">&nbsp;&nbsp;</span>" + sysList[i1].SystemInfoName + "</span>";

                //<div style="width: 8px; background-color: #00FF00; float: left;" />
            }

            if (bIncludeAll == true)
            {
                T_SystemInfo_MDL obj = new T_SystemInfo_MDL();
                obj.SystemInfoID = 0;
                //obj.SystemInfoCode = "";
                obj.SystemInfoName = "全部";
                sysList.Insert(0, obj);
            }

            RadioButtonList1.DataTextField = "SystemInfoName";
            RadioButtonList1.DataValueField = "SubType";
            RadioButtonList1.DataSource = sysList;
            RadioButtonList1.DataBind();
            if (sysList.Count > 0)
            {
                RadioButtonList1.Items[0].Selected = true;
            }           
        }
    }
}