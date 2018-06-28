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

//生成报表查询条件

namespace DigiPower.Onlinecol.Standard.Web.CommonCtrl
{
    public partial class ctrl_Search_Para : System.Web.UI.UserControl
    {
        //in
        public string ReportCode = "";

        //out
        public Hashtable OutSqlList = new Hashtable();
        public ArrayList OutValueList = new ArrayList();
        public ArrayList OutValue = new ArrayList();
        public string strWhereSql = "";


        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void CreateChildControls()
        {
            if (Session["ReportCode"] != null)
                ReportCode = Session["ReportCode"].ToString();
            else
                return;

            T_Search_Field_BLL tsfBll = new T_Search_Field_BLL();
            DataTable dt1 = tsfBll.GetList("ReportCode='" + ReportCode + "' order by OrderId asc ").Tables[0];

            if (dt1 != null && dt1.Rows.Count > 0)
            {
                int LastLine = 0;
                for (int i1 = 0; i1 < dt1.Rows.Count; i1++)
                {
                    DataRow r1 = dt1.Rows[i1];

                    Panel panel1 = new Panel();
                    panel1.Style.Add("float", "left");
                    //panel1.Style.Add("clear", "right");                
                    panel1.Style.Add("padding-left", "2px");
                    panel1.Style.Add("padding-right", "2px");
                    panel1.Style.Add("margin-left", "2px");
                    panel1.Style.Add("margin-right", "2px");
                    //panel1.Style.Add("border-bottom", "1px dashed");
                    //panel1.Style.Add("border-left", "1px dashed");            
                    //panel1.Style.Add("height", "23px");
                    //panel1.Style.Add("width", "250px");
                    //panel1.Style.Add("width", "1px");

                    if (i1 > 0 && LastLine.ToString() != r1["Line"].ToString())
                    {
                        panel1.Style.Add("float", "left");
                        panel1.Style.Add("clear", "left");
                    }
                    LastLine = Common.ConvertEx.ToInt(r1["Line"].ToString());

                    Label l1 = new Label();
                    l1.Text = r1["LabelName"].ToString() + " ";
                    panel1.Controls.Add(l1);
                    //AddSpace(ref panel1);

                    DataTable dt2 = new T_Search_Para_BLL().GetList("Search_Field_ID=" + r1["Search_Field_ID"].ToString() + " order by OrderId asc ").Tables[0];
                    if (dt2 != null && dt2.Rows.Count > 0)
                    {
                        for (int K1 = 0; K1 < dt2.Rows.Count; K1++)
                        {
                            DataRow r2 = dt2.Rows[K1];
                            //宽
                            //panel1.Style.Add("width", int.Parse(r2["ControlWidth"].ToString()) * dt2.Rows.Count + l1.Text.Length * 20 + "px");

                            if (r2["ParaType"].ToString() == "TextBox" || r2["ParaType"].ToString() == "DateTime")
                            {
                                TextBox txt1 = new TextBox();
                                txt1.ID = r1["TableName"].ToString() + "|" + r1["FieldName"].ToString() + "|" + r1["Search_Field_ID"].ToString() + "|" + r2["Search_Para_ID"].ToString();
                                txt1.Text = r2["DefaultValue"].ToString();

                                if (r2["ControlWidth"] != null)
                                    txt1.Width = Unit.Parse(r2["ControlWidth"].ToString());

                                if (r2["ParaType"].ToString() == "DateTime")
                                {
                                    //if (r2["DefaultValue"].ToString() == "1")//月初
                                    //{
                                    //    DateTime firstDay = new DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, 1);
                                    //    txt1.Text = firstDay.ToString("yyyy-MM-dd");
                                    //}
                                    //else if (r2["DefaultValue"].ToString() == "2")//当前日期
                                    //{
                                    //    txt1.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                                    //}
                                    txt1.Text = DateTime.Now.ToString("yyyy-MM-dd");
                                    txt1.Attributes.Add("onblur", "return CheckValid(this,'','Date');");
                                    txt1.Attributes.Add("onclick", "new Calendar().show(this);");
                                }

                                panel1.Controls.Add(txt1);
                                AddSpace(ref panel1, K1, dt2.Rows.Count);
                            }
                            else if (r2["ParaType"].ToString() == "ComboBox")
                            {
                                DropDownList txt1 = new DropDownList();
                                txt1.ID = r1["TableName"].ToString() + "|" + r1["FieldName"].ToString() + "|" + r1["Search_Field_ID"].ToString() + "|" + r2["Search_Para_ID"].ToString();

                                if (r2["ControlWidth"] != null)
                                    txt1.Width = Unit.Parse(r2["ControlWidth"].ToString());

                                string SourceSql = r2["SourceSql"].ToString();
                                DataTable sourceDt = new T_Other_BLL().GetDataSet(SourceSql).Tables[0];
                                txt1.Items.Add("");//增加空
                                for (int J1 = 0; J1 < sourceDt.Rows.Count; J1++)
                                {
                                    ListItem listitem2 = new ListItem(sourceDt.Rows[J1][1].ToString(), sourceDt.Rows[J1][0].ToString());
                                    txt1.Items.Add(listitem2);
                                }
                                panel1.Controls.Add(txt1);
                                AddSpace(ref panel1, K1, dt2.Rows.Count);
                            }
                        }
                    }
                    this.CurrentPanel.Controls.Add(panel1);
                }
            }
            base.CreateChildControls();
        }

        private void AddSpace(ref Panel p1, int Index, int Count)
        {
            Literal space = new Literal();
            if (Count > 1 && Index < Count - 1)
            {
                space.Text = " 至 ";
            }
            else
            {
                //space.Text = "<span> </span>";
            }
            p1.Controls.Add(space);
        }

        public void Submit()
        {
            BLL.T_Search_Field_BLL bll1 = new BLL.T_Search_Field_BLL();

            //取界面上的所有控件值
            foreach (Control control2 in CurrentPanel.Controls)
            {
                foreach (Control control1 in control2.Controls)
                {
                    if (control1.ID == null)
                        continue;

                    string[] str1 = control1.ID.Split('|');
                    if (str1.Length == 4)
                    {
                        string TableName = str1[0].ToLower();
                        string FieldName = str1[1];
                        string Search_Field_ID = str1[2];
                        string Search_Para_ID = str1[3];

                        if (!OutSqlList.Contains(TableName))
                        {
                            OutSqlList.Add(TableName, "  1=1 ");
                        }
                        strWhereSql = OutSqlList[TableName].ToString();

                        DataTable fld_dt1 = new T_Search_Field_BLL().GetList("Search_Field_ID=" + Search_Field_ID).Tables[0];
                        DataTable para_dt1 = new T_Search_Para_BLL().GetList("Search_Para_ID=" + Search_Para_ID).Tables[0];
                        if (fld_dt1 != null && para_dt1 != null && fld_dt1.Rows.Count > 0 && para_dt1.Rows.Count > 0)
                        {
                            string control_Type = control1.GetType().Name;
                            if (control_Type == "TextBox" || control_Type == "DateTime")
                            {
                                TextBox txt1 = (TextBox)control1;
                                string Value = txt1.Text.Trim();

                                if (Common.ConvertEx.ToInt(fld_dt1.Rows[0]["IsDictionary"]) == 1)
                                    OutValue.Add(Value);


                                if (Value != "")
                                {
                                    string CompareType = para_dt1.Rows[0]["CompareType"].ToString();

                                    if (CompareType == "LIKE")
                                    {
                                        Value = "%" + Value + "%";
                                    }

                                    if (CompareType == "&gt;=") CompareType = ">=";
                                    if (CompareType == "&lt;=") CompareType = "<=";

                                    strWhereSql += " AND " + TableName + "." + FieldName + " " + CompareType + " '" + Value + "'";
                                }
                                OutValueList.Add(Value);
                            }
                            else if (control_Type == "DropDownList")
                            {
                                DropDownList txt1 = (DropDownList)control1;
                                string Value = txt1.Text.Trim();

                                if (Common.ConvertEx.ToInt(fld_dt1.Rows[0]["IsDictionary"]) == 1)
                                    OutValue.Add(Value);

                                if (Value != "")
                                {
                                    string CompareType = para_dt1.Rows[0]["CompareType"].ToString();

                                    if (CompareType == "LIKE")
                                    {
                                        Value = "%" + Value + "%";
                                    }

                                    if (CompareType == "&gt;=") CompareType = ">=";
                                    if (CompareType == "&lt;=") CompareType = "<=";

                                    strWhereSql += " AND " + TableName + "." + FieldName + " " + CompareType + " '" + Value + "'";
                                }
                                OutValueList.Add(Value);
                            }
                        }

                        OutSqlList[TableName] = strWhereSql;
                    }
                }
            }
        }
    }
}