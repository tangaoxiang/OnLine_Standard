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
using DigiPower.Onlinecol.Standard.Common;

namespace DigiPower.Onlinecol.Standard.Web.CommonCtrl
{
    public partial class ctrlDropDownFileListTmp : System.Web.UI.UserControl
    {
        private List<T_FileListTmp_MDL> arealist = new List<T_FileListTmp_MDL>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //DataBindEx(2);
            }
        }

        /// <summary>
        /// 设置下拉框Width
        /// </summary>
        public int Width
        {
            set
            {
                ddlModule.Width = value;
            }
        }

        /// <summary>
        /// 设置属性 AutoPostBack
        /// </summary>
        public bool AutoPostBack
        {
            set { ddlModule.AutoPostBack = value; }
        }

        /// <summary>
        /// 获取下拉框VALUE 值
        /// </summary>
        public string SelectValue
        {
            set { ddlModule.SelectedIndex = ddlModule.Items.IndexOf(ddlModule.Items.FindByValue(value)); }
            get { return ddlModule.SelectedValue; }
        }

        /// <summary>
        /// 返回PID=0的归档目录模板
        /// </summary>
        /// <param name="PID">PID=0</param>
        public void DataBindEx(int PID)
        {
            DataSet ds1 = new T_FileListTmp_BLL().GetList("PID=0");

            if (ds1 != null && ds1.Tables.Count > 0)
            {
                ddlModule.DataTextField = "Title";
                ddlModule.DataValueField = "recid";
                ddlModule.DataSource = ds1;
                ddlModule.DataBind();
            }

            ddlModule.Items.Insert(0, new ListItem("无", "0"));
        }

        public void DataBindEx()
        {
            DataBindEx("");
        }

        /// <summary>
        /// 返回PID=0的归档目录模板
        /// </summary>
        /// <param name="PID">PID=0</param>
        /// <param name="DataValueField">DataValueField绑定的字段</param>
        public void DataBindEx(int PID, string DataValueField)
        {
            DataSet ds1 = new T_FileListTmp_BLL().GetList("PID=" + PID + "");

            if (ds1 != null && ds1.Tables.Count > 0)
            {
                ddlModule.DataTextField = "Title";
                ddlModule.DataValueField = DataValueField;
                ddlModule.DataSource = ds1;
                ddlModule.DataBind();
            }

            ddlModule.Items.Insert(0, new ListItem("无", "0"));
        }

        public void DataBindEx(string archive_form_no)
        {
            string strSQL = "";
            if (!string.IsNullOrEmpty(archive_form_no))
            {
                strSQL = "archive_form_no='" + archive_form_no + "'";
            }
            DataSet ds1 = (new T_FileListTmp_BLL()).GetList(strSQL);
            //层次重排area_name
            Recursion(ds1.Tables[0], 0, 0);

            if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {
                DataTable table = ds1.Tables[0];
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string Text = ConvertEx.ToString(table.Rows[i]["bh"]) + "-----" + ConvertEx.ToString(table.Rows[i]["title"]);
                    string Value = ConvertEx.ToString(table.Rows[i]["recid"]);

                    ddlModule.Items.Add(new ListItem(Text, Value));
                }
            }

            ddlModule.Items.Insert(0, new ListItem("无父级", "0"));
        }
        public void Recursion(DataTable dt, int PID, int LevelID)
        {
            DataRow[] dr = dt.Select("PID='" + PID + "'", "OrderIndex");
            foreach (DataRow drr in dr)
            {
                T_FileListTmp_MDL mdl1 = new T_FileListTmp_MDL();
                mdl1.recid = Common.ConvertEx.ToInt(drr["recid"].ToString());
                mdl1.title = Comm.AddEmpty(drr["title"].ToString(), LevelID);
                arealist.Add(mdl1);
                int NewLevelID = LevelID + 1;
                Recursion(dt, Int32.Parse(drr["recid"].ToString()), NewLevelID);
            }
        }
        //public string addempty(string name, int ll_i)//填补空格
        //{
        //    for (int i = 0; i < ll_i; i++)
        //    {
        //        name = "　" + name;
        //    }
        //    return name;
        //}

        protected void ddlModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            BLL.T_FileListTmp_BLL docBLL = new T_FileListTmp_BLL();
            Model.T_FileListTmp_MDL docMDL = docBLL.GetModel(Common.ConvertEx.ToInt(ddlModule.SelectedValue));
            if (docMDL != null)
            {
                Label1.Text = docMDL.bh;
            }
        }


        /// <summary>
        /// 清除下拉框所有元素
        /// </summary>
        public void ItemClear()
        {
            ddlModule.Items.Clear();
        }

        /// <summary>
        /// 根据PID返回对应的归档目录模板
        /// </summary>
        /// <param name="PID">PID父节点ID</param>
        /// <param name="archive_form_no">模板类型</param>
        /// <param name="DataValueField">DataValueField绑定的字段</param>
        public void DataBindEx(int PID, string archive_form_no, string DataValueField)
        {
            DataSet ds1 = new T_FileListTmp_BLL().GetList("PID=" + PID + " and archive_form_no=" + archive_form_no + "");

            if (ds1 != null && ds1.Tables.Count > 0)
            {
                ddlModule.DataTextField = "Title";
                ddlModule.DataValueField = DataValueField;
                ddlModule.DataSource = ds1;
                ddlModule.DataBind();
            }

            ddlModule.Items.Insert(0, new ListItem("无", "0"));
        }
    }
}