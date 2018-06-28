﻿using System;
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
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Model;

namespace DigiPower.Onlinecol.Standard.Web.CommonCtrl {
    public partial class ctrlDropDownSystemInfo : System.Web.UI.UserControl {
        public delegate void SelectChanged();
        public event SelectChanged MySelectChanged;

        private string _currentType = "";
        public bool AutoPostBack {
            set { ddlSystemInfo.AutoPostBack = value; }
        }

        protected void ddlSystemInfo_SelectedIndexChanged(object sender, EventArgs e) {
            if (MySelectChanged != null)
                MySelectChanged();
        }

        public string CurrentType {
            set { _currentType = value; }
        }

        public string SelectValue {
            get { return ddlSystemInfo.SelectedValue; }
            set {
                //ddlSystemInfo.SelectedIndex = ddlSystemInfo.Items.IndexOf(ddlSystemInfo.Items.FindByValue(value));
                for (var i = 0; i < ddlSystemInfo.Items.Count; i++) {
                    if (ddlSystemInfo.Items[i].Value.ToLower() == value.ToLower()) {
                        ddlSystemInfo.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        public int SelectedIndex {
            set { ddlSystemInfo.SelectedIndex = value; }
        }

        public string Width {
            set { ddlSystemInfo.Width = new Unit(value); }
        }

        public string SelectedText {
            get { return ddlSystemInfo.SelectedItem.Text; }
        }

        public string SystemInfoID {
            set {
                if (value != "") {
                    ddlSystemInfo.SelectedValue = value;
                }
            }
        }

        //public string Text
        //{
        //    set
        //    {
        //        ddlSystemInfo.Text = value;
        //    }
        //    get
        //    {
        //        return ddlSystemInfo.Text;
        //    }
        //}

        public bool Enabled {
            set {
                ddlSystemInfo.Enabled = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e) {

        }

        public void SetAttributes(string key, string value) {
            ddlSystemInfo.Attributes.Add(key, value);
        }

        string _DataValueField = string.Empty;

        /// <summary>
        /// DataValueField 需要绑定的字段,不设置则默认绑定 systeminfoid
        /// </summary>
        public string DataValueField {
            get { return _DataValueField; }
            set { _DataValueField = value; }
        }

        public void DataBindEx() {
            DataBindEx(false);
        }
        public void DataBindEx(bool bIncludeAll) {
            DataBindEx(bIncludeAll, "");
        }
        public void DataBindEx(bool bIncludeAll, string NotIncludeString, bool flag = false) {
            string strwhere = " 1=1 ";
            if (_currentType != "")
                strwhere += " AND currenttype='" + _currentType + "'";
            if (NotIncludeString != "") {
                strwhere += " AND SystemInfoCode not in(" + NotIncludeString + ")";
            }

            List<T_SystemInfo_MDL> systeminfolist = new List<T_SystemInfo_MDL>();
            systeminfolist = (new T_SystemInfo_BLL()).GetModelList(strwhere);
            if (bIncludeAll == true) {
                T_SystemInfo_MDL newMDL = new T_SystemInfo_MDL();
                newMDL.SystemInfoName = "全部";
                newMDL.SystemInfoID = 0;
                systeminfolist.Insert(0, newMDL);
            }
            ddlSystemInfo.DataTextField = "systeminfoname";
            if (DataValueField == string.Empty)
                ddlSystemInfo.DataValueField = "systeminfoid";
            else
                ddlSystemInfo.DataValueField = _DataValueField;

            ddlSystemInfo.DataSource = systeminfolist;
            ddlSystemInfo.DataBind();

            if (flag) {
                ddlSystemInfo.Items.Add(new ListItem("道路和桥梁", "207,208"));
            }
        }

        /// <summary>
        /// 返回字典
        /// </summary>
        /// <param name="bIncludeAll">是否有--全部 选项</param>
        /// <param name="NotIncludeString">KEY= SystemInfoCode </param>
        public void DataBindEx(bool bIncludeAll, List<string> NotIncludeString) {
            string strwhere = " 1=1 ";
            if (_currentType != "")
                strwhere += " AND currenttype='" + _currentType + "'";
            if (NotIncludeString.Count > 0) {
                foreach (string SystemInfoCode in NotIncludeString) {
                    strwhere += " AND SystemInfoCode<>'" + SystemInfoCode + "'";
                }
            }

            List<T_SystemInfo_MDL> systeminfolist = new List<T_SystemInfo_MDL>();
            systeminfolist = (new T_SystemInfo_BLL()).GetModelList(strwhere);
            if (bIncludeAll == true) {
                T_SystemInfo_MDL newMDL = new T_SystemInfo_MDL();
                newMDL.SystemInfoName = "全部";
                newMDL.SystemInfoID = 0;
                systeminfolist.Insert(0, newMDL);
            }
            ddlSystemInfo.DataTextField = "systeminfoname";

            if (DataValueField == string.Empty)
                ddlSystemInfo.DataValueField = "systeminfoid";
            else
                ddlSystemInfo.DataValueField = _DataValueField;

            ddlSystemInfo.DataSource = systeminfolist;
            ddlSystemInfo.DataBind();
        }

        public void DataBindEx(int UnderMyParentID, bool isshowjs = false) {
            DataBindEx(UnderMyParentID, false, isshowjs);
        }

        public void DataBindEx(int UnderMyParentID, bool bIncludeAll, bool isshowjs = false) {
            string strwhere = " 1=1 ";
            if (_currentType != "")
                strwhere += " AND currenttype='" + _currentType + "'";

            //strwhere += " AND ParentID<=" + UnderMyParentID;
            strwhere += " AND ParentID>=" + UnderMyParentID;
            if (isshowjs) {
                strwhere += " AND SystemInfoCode<> 'JSCompanyInfo' ";
            }
            List<T_SystemInfo_MDL> systeminfolist = new List<T_SystemInfo_MDL>();
            systeminfolist = (new T_SystemInfo_BLL()).GetModelList(strwhere);

            if (bIncludeAll == true) {
                T_SystemInfo_MDL newMDL = new T_SystemInfo_MDL();
                newMDL.SystemInfoName = "全部";
                newMDL.SystemInfoID = 0;
                systeminfolist.Insert(0, newMDL);
            }

            ddlSystemInfo.DataTextField = "systeminfoname";

            if (DataValueField == string.Empty)
                ddlSystemInfo.DataValueField = "systeminfoid";
            else
                ddlSystemInfo.DataValueField = _DataValueField;

            ddlSystemInfo.DataSource = systeminfolist;
            ddlSystemInfo.DataBind();
        }

        public void DataBindEx(int UnderMyParentID, bool bIncludeAll, string NotIncludeString) {
            string strwhere = " 1=1 ";
            if (_currentType != "")
                strwhere += " AND currenttype='" + _currentType + "'";

            strwhere += " AND ParentID>=" + UnderMyParentID;
            if (NotIncludeString != "")
                strwhere += " AND SystemInfoID not in(" + NotIncludeString + ")";

            List<T_SystemInfo_MDL> systeminfolist = new List<T_SystemInfo_MDL>();
            systeminfolist = (new T_SystemInfo_BLL()).GetModelList(strwhere);

            if (bIncludeAll == true) {
                T_SystemInfo_MDL newMDL = new T_SystemInfo_MDL();
                newMDL.SystemInfoName = "全部";
                newMDL.SystemInfoID = 0;
                systeminfolist.Insert(0, newMDL);
            }
            ddlSystemInfo.DataTextField = "systeminfoname";

            if (DataValueField == string.Empty)
                ddlSystemInfo.DataValueField = "systeminfoid";
            else
                ddlSystemInfo.DataValueField = _DataValueField;

            ddlSystemInfo.DataSource = systeminfolist;
            ddlSystemInfo.DataBind();
        }
    }
}