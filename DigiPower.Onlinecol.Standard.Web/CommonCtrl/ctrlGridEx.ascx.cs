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
using System.Collections.Generic;
using DigiPower.Onlinecol.Standard.Common;

namespace DigiPower.Onlinecol.Standard.Web.CommonCtrl
{
    public partial class ctrlGridEx : System.Web.UI.UserControl
    {
        private string ModifyURL = "";
        public delegate void GridView_DataRowBound(object sender, GridViewRowEventArgs e);
        public event GridView_DataRowBound MyGridView_DataRowBound;

        public delegate void GridView_PreRender(object sender, EventArgs e);
        public event GridView_PreRender MyGridView_PreRender;

        private int _PageIndex = 0;
        public enum SelType
        {
            CheckBox,
            Radio
        }

        private SelType _selType = SelType.CheckBox;
        public SelType SelCheckType
        {
            set { _selType = value; }
            get { return _selType; }
        }

        public string PageIndex
        {
            get
            {
                return SmartGridView1.PageIndex.ToString();
            }
            set
            {
                _PageIndex = Common.ConvertEx.ToInt(value);
                SmartGridView1.PageIndex = _PageIndex;
            }
        }

        public bool ShowFooter
        {
            set { SmartGridView1.ShowFooter = value; }
        }

        public GridViewRowCollection Rows
        {
            get { return SmartGridView1.Rows; }
        }

        /// <summary>
        /// 返回选中行的主键
        /// </summary>
        /// <param name="index">选中行索引</param>
        /// <returns></returns>
        public string DataKeyValue(int index)
        {
            return Common.ConvertEx.ToString(SmartGridView1.DataKeys[index].Value);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["SortDirection"] = "DESC";
                TextBox1.Text = (_PageIndex + 1).ToString();
            }
            else
            {
                //MyDataBind();
            }
        }

        public void InitGrid(string tKeyName, List<string> ColExList, DataSet ds, string tModifyURL)
        {
            if (tModifyURL == "")
            {
                InitGrid(tKeyName, ColExList, ds, tModifyURL, false, false, "");
            }
            else
            {
                InitGrid(tKeyName, ColExList, ds, tModifyURL, true, true, "编辑");
            }
        }

        public void InitGrid(string tKeyName, List<string> ColExList, DataSet ds, string tModifyURL, bool AllowSorting, bool showEdit, string EditName)
        {
            List<GridExPara> NewColExList = new List<GridExPara>();
            foreach (string obj in ColExList)
            {
                GridExPara p1 = new GridExPara();
                p1.FieldName = obj;
                p1.bShow = true;
                p1.iType = 0;
                NewColExList.Add(p1);
            }
            InitGrid(tKeyName, NewColExList, ds, tModifyURL, AllowSorting, showEdit, EditName);
        }

        /// <summary>
        /// iType,0=Lable,1,TextBox,2,DropList,3,Image,99,上传控件
        /// </summary>
        /// <param name="tKeyName"></param>
        /// <param name="ColExList"></param>
        /// <param name="ds"></param>
        /// <param name="tModifyURL"></param>
        /// <param name="AllowSorting"></param>
        /// <param name="showEdit"></param>
        /// <param name="EditName"></param>
        public void InitGrid(string tKeyName, List<GridExPara> ColExList, DataSet ds, string tModifyURL, bool AllowSorting, bool showEdit, string EditName)
        {
            SmartGridView1.AllowSorting = AllowSorting;
            ViewState["DS"] = ds;
            SmartGridView1.Columns.Clear();

            //填加选择列
            ButtonField fldSelect = new ButtonField();
            fldSelect.HeaderText = "";
            SmartGridView1.Columns.Add(fldSelect);
            string[] KeyNames = new string[1];
            KeyNames[0] = tKeyName;

            int Pos1 = 1;

            BLL.T_Field_BLL fieldBll = new DigiPower.Onlinecol.Standard.BLL.T_Field_BLL();
            string TableName = ds.Tables[0].TableName;
            foreach (GridExPara paraEx in ColExList)
            {
                GridExPara.CtrlType cellType = paraEx.iType;// TemListShow[i].Split(',');
                switch (cellType)
                {
                    //普通列
                    case 0:
                        {
                            TemplateField tc = new TemplateField();
                            tc.Visible = paraEx.bShow;

                            if (paraEx.ShowName == "")
                            {
                                tc.HeaderText = fieldBll.GetCNFieldNameByFieldName(TableName, paraEx.FieldName);
                            }
                            else
                            {
                                tc.HeaderText = paraEx.ShowName;
                            }
                            tc.SortExpression = paraEx.FieldName;
                            ColumnTemplate ctp = new ColumnTemplate("Label", paraEx.FieldName, paraEx.iLength);

                            tc.ItemTemplate = ctp;
                            tc.HeaderStyle.Width = paraEx.iLength;
                            tc.ItemStyle.Width = paraEx.iLength;

                            SmartGridView1.Columns.Insert(Pos1++, tc);
                        }
                        break;

                    //可编辑的文本列
                    case GridExPara.CtrlType.TextBox:
                        {
                            TemplateField tc = new TemplateField();
                            tc.Visible = paraEx.bShow;
                            tc.HeaderText = fieldBll.GetCNFieldNameByFieldName(TableName, paraEx.FieldName);
                            tc.SortExpression = paraEx.FieldName;
                            ColumnTemplate ctp = new ColumnTemplate("TXT", paraEx.FieldName, paraEx.iLength);

                            tc.ItemTemplate = ctp;
                            tc.HeaderStyle.Width = paraEx.iLength;
                            tc.ItemStyle.Width = paraEx.iLength;

                            SmartGridView1.Columns.Insert(Pos1++, tc);

                        }
                        break;
                    //下拉列
                    case GridExPara.CtrlType.DropDownList:
                        {
                            TemplateField tc = new TemplateField();
                            tc.Visible = paraEx.bShow;
                            tc.HeaderText = fieldBll.GetCNFieldNameByFieldName(TableName, paraEx.FieldName);
                            tc.SortExpression = paraEx.FieldName;
                            ColumnTemplate ctp = new ColumnTemplate("DRP", "OperateUserName", 0);

                            tc.ItemTemplate = ctp;

                            SmartGridView1.Columns.Insert(Pos1++, tc);

                        }
                        break;
                    //图片列
                    case GridExPara.CtrlType.Image:
                        {
                            TemplateField tc = new TemplateField();
                            tc.Visible = paraEx.bShow;
                            tc.HeaderText = fieldBll.GetCNFieldNameByFieldName(TableName, paraEx.FieldName);
                            tc.SortExpression = paraEx.FieldName;
                            ColumnTemplate ctp = new ColumnTemplate("Image", paraEx.FieldName, paraEx.iLength);
                            tc.ItemTemplate = ctp;
                            tc.HeaderStyle.Width = paraEx.iLength;
                            tc.ItemStyle.Width = paraEx.iLength;
                            SmartGridView1.Columns.Insert(Pos1++, tc);
                        }
                        break;
                    //CheckBox
                    case GridExPara.CtrlType.CheckBox:
                        {
                            TemplateField tc = new TemplateField();
                            tc.Visible = paraEx.bShow;
                            tc.HeaderText = fieldBll.GetCNFieldNameByFieldName(TableName, paraEx.FieldName);
                            tc.SortExpression = paraEx.FieldName;
                            ColumnTemplate ctp = new ColumnTemplate("CheckBox", paraEx.FieldName, paraEx.iLength, paraEx.Enabled);
                            tc.ItemTemplate = ctp;
                            tc.HeaderStyle.Width = paraEx.iLength;
                            tc.ItemStyle.Width = paraEx.iLength;

                            SmartGridView1.Columns.Insert(Pos1++, tc);
                        }
                        break;
                    //上传控件
                    case GridExPara.CtrlType.FileUpload:
                        {
                            TemplateField tc = new TemplateField();
                            tc.Visible = paraEx.bShow;
                            tc.HeaderText = "";
                            ColumnTemplate ctp = new ColumnTemplate("FileUpload", paraEx.FieldName, paraEx.iLength);
                            tc.ItemTemplate = ctp;
                            tc.HeaderStyle.Width = paraEx.iLength;
                            tc.ItemStyle.Width = paraEx.iLength;
                            SmartGridView1.Columns.Insert(Pos1++, tc);
                        }
                        break;
                    case GridExPara.CtrlType.SystemInfo:
                        {
                            TemplateField tc = new TemplateField();
                            tc.Visible = paraEx.bShow;
                            tc.HeaderText = "";
                            ColumnTemplate ctp = new ColumnTemplate("SystemInfo", paraEx.FieldName, paraEx.iLength, paraEx.subType);
                            tc.ItemTemplate = ctp;
                            tc.HeaderStyle.Width = paraEx.iLength;
                            tc.ItemStyle.Width = paraEx.iLength;
                            SmartGridView1.Columns.Insert(Pos1++, tc);
                        }
                        break;
                }
            }
            //显示编辑列
            if (showEdit)
            {
                ModifyURL = tModifyURL;
                AddEditColumn(EditName);
            }
            SmartGridView1.DataKeyNames = KeyNames;
            SmartGridView1.DataSource = ds.Tables[0].DefaultView;
            MyDataBind(AllowSorting);
            if (SmartGridView1.Rows.Count > 0)
            {
                if (_selType == SelType.Radio)
                {
                    Control obj = SmartGridView1.Rows[0].FindControl("box2");
                    if (obj != null)
                    {
                        RadioButton c1 = (RadioButton)obj;
                        c1.Checked = true;
                    }
                }
            }
        }

        //增加编辑列
        void AddEditColumn(string EditName)
        {
            if (EditName == "")
                EditName = "编辑";

            TemplateField customerfield = new TemplateField();
            customerfield.ShowHeader = true;
            customerfield.HeaderTemplate = new MyItemTemplate(DataControlRowType.Header, "操作");
            MyItemTemplate grv = new MyItemTemplate(DataControlRowType.DataRow, "btnModify", EditName);
            customerfield.ItemTemplate = grv;
            customerfield.HeaderStyle.CssClass = "Table_Title_tr";
            customerfield.ItemStyle.CssClass = "Table_Title_border";
            customerfield.HeaderStyle.Width = Unit.Parse("30px");
            customerfield.ItemStyle.Width = Unit.Parse("30px");
            SmartGridView1.Columns.Add(customerfield);
        }

        private void AddSelectColumn()
        {
            if (SmartGridView1.HeaderRow != null && SmartGridView1.HeaderRow.Cells.Count > 0)
            {
                if (_selType == SelType.CheckBox)
                {
                    CheckBox box1 = new CheckBox();
                    box1.ID = "box1";
                    SmartGridView1.HeaderRow.Cells[0].Controls.Add(box1);
                }
                SmartGridView1.Columns[0].HeaderStyle.Width = 22;
                SmartGridView1.HeaderRow.Cells[0].CssClass = "Table_Title_tr";
            }

            foreach (GridViewRow row1 in SmartGridView1.Rows)
            {
                if (_selType == SelType.CheckBox)
                {
                    CheckBox box2 = new CheckBox();
                    box2.ID = "box2";
                    row1.Cells[0].Controls.Add(box2);

                }
                else if (_selType == SelType.Radio)
                {
                    RadioButton box2 = new RadioButton();
                    box2.ID = "box2";
                    box2.GroupName = "rad";
                    row1.Cells[0].Controls.Add(box2);
                }
                row1.Cells[0].CssClass = "Table_Title_tr";
            }
        }

        public void SmartGridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("onmouseover", "changeto()");
            e.Row.Attributes.Add("onmouseout", "changeback()");
            if (_selType == SelType.CheckBox)
                e.Row.Attributes.Add("onclick", "SetSelectBox()");
            else if (_selType == SelType.Radio)
                e.Row.Attributes.Add("onclick", "SelRadioButton('" + e.Row.ClientID + "')");

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                HyperLink b1 = (HyperLink)e.Row.FindControl("btnModify");
                if (b1 != null)
                {
                    b1.NavigateUrl = ModifyURL + "&ID=" + SmartGridView1.DataKeys[e.Row.RowIndex].Value;
                }
            }

            if (MyGridView_DataRowBound != null)
                MyGridView_DataRowBound(sender, e);
        }

        /// <summary>
        /// 取所有选中行的主键列表
        /// </summary>
        /// <returns></returns>
        public List<string> GetSelects()
        {
            List<string> list1 = new List<string>();
            for (int i1 = 0; i1 < SmartGridView1.Rows.Count; i1++)
            {

                if (_selType == SelType.CheckBox)
                {
                    CheckBox b1 = (CheckBox)SmartGridView1.Rows[i1].FindControl("box2");

                    if (b1 != null && b1.Checked == true)
                    {
                        list1.Add(SmartGridView1.DataKeys[i1].Value.ToString());
                    }
                }
                else if (_selType == SelType.Radio)
                {
                    RadioButton b1 = (RadioButton)SmartGridView1.Rows[i1].FindControl("box2");

                    if (b1 != null && b1.Checked == true)
                    {
                        list1.Add(SmartGridView1.DataKeys[i1].Value.ToString());
                    }
                }

            }
            return list1;
        }

        /// <summary>
        /// 最第一个选中的主键
        /// </summary>
        /// <returns></returns>
        public string GetFirstSelect()
        {
            string strOut = "";
            for (int i1 = 0; i1 < SmartGridView1.Rows.Count; i1++)
            {

                if (_selType == SelType.CheckBox)
                {
                    CheckBox b1 = (CheckBox)SmartGridView1.Rows[i1].FindControl("box2");

                    if (b1 != null && b1.Checked == true)
                    {
                        strOut = SmartGridView1.DataKeys[i1].Value.ToString();
                        break;
                    }
                }
                else if (_selType == SelType.Radio)
                {
                    RadioButton b1 = (RadioButton)SmartGridView1.Rows[i1].FindControl("box2");

                    if (b1 != null && b1.Checked == true)
                    {
                        strOut = SmartGridView1.DataKeys[i1].Value.ToString();
                        break;
                    }
                }

            }
            return strOut;
        }

        /// <summary>
        /// 取所有选中行的行索引
        /// </summary>
        /// <returns></returns>
        public List<int> GetSelectsRowIndexList()
        {
            List<int> list1 = new List<int>();
            for (int i1 = 0; i1 < SmartGridView1.Rows.Count; i1++)
            {

                if (_selType == SelType.CheckBox)
                {
                    CheckBox b1 = (CheckBox)SmartGridView1.Rows[i1].FindControl("box2");

                    if (b1 != null && b1.Checked == true)
                    {
                        list1.Add(i1);
                    }
                }
                else if (_selType == SelType.Radio)
                {
                    RadioButton b1 = (RadioButton)SmartGridView1.Rows[i1].FindControl("box2");

                    if (b1 != null && b1.Checked == true)
                    {
                        list1.Add(i1);
                    }
                }

            }
            return list1;
        }

        public List<string> GetAll()
        {
            List<string> list1 = new List<string>();
            for (int i1 = 0; i1 < SmartGridView1.Rows.Count; i1++)
            {

                if (_selType == SelType.CheckBox)
                {
                    CheckBox b1 = (CheckBox)SmartGridView1.Rows[i1].FindControl("box2");
                    list1.Add(SmartGridView1.DataKeys[i1].Value.ToString());
                }
                else if (_selType == SelType.Radio)
                {
                    RadioButton b1 = (RadioButton)SmartGridView1.Rows[i1].FindControl("box2");
                    list1.Add(SmartGridView1.DataKeys[i1].Value.ToString());
                }
            }
            return list1;
        }

        protected void SmartGridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["SortDirection"].ToString() == "ASC")
            {
                ViewState["SortDirection"] = "DESC";
            }
            else
            {
                ViewState["SortDirection"] = "ASC";
            }
            ViewState["SortExpression"] = e.SortExpression;
            MyDataBind();
        }

        private void MyDataBind()
        {
            MyDataBind(true);
        }

        private void MyDataBind(bool AllowSorting)
        {
            DataSet ds = (DataSet)ViewState["DS"];
            if (ds == null)
            {
                tbpage.Visible = false;
                return;
            }

            if (AllowSorting == true)
            {
                if (ViewState["SortExpression"] != null)
                {
                    ds.Tables[0].DefaultView.Sort = ViewState["SortExpression"].ToString() + " " + ViewState["SortDirection"].ToString();
                }
            }
            SmartGridView1.PageSize = Common.ConvertEx.ToInt(Common.Session.GetSession("PageCount"));
            SmartGridView1.DataSource = ds.Tables[0].DefaultView;
            SmartGridView1.DataBind();
            AddSelectColumn();
            int recordcount = ds.Tables[0].Rows.Count;
            lbRecordCount.Text = recordcount.ToString();
            lbCurPage.Text = (SmartGridView1.PageIndex + 1).ToString();//(int.Parse(ViewState["GridPageIndex"].ToString()) + 1).ToString();
            int pagecount;
            if (recordcount % SmartGridView1.PageSize == 0)
                pagecount = recordcount / SmartGridView1.PageSize;
            else
                pagecount = (recordcount / SmartGridView1.PageSize) + 1;
            lbPageCount.Text = pagecount.ToString();

            SetShowPageIndex();
            if (ds.Tables[0].Rows.Count > 0)
            {
                tbpage.Visible = true;
            }
            else
                tbpage.Visible = false;

            Session["PageIndex"] = SmartGridView1.PageIndex;
        }

        protected void SmartGridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
        }

        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            int PageIndex = Common.ConvertEx.ToInt(lbCurPage.Text);
            if (PageIndex > SmartGridView1.PageCount - 1)
                PageIndex = SmartGridView1.PageCount - 1;
            SmartGridView1.PageIndex = PageIndex;
            MyDataBind();
        }

        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            int PageIndex = Common.ConvertEx.ToInt(lbCurPage.Text) - 2;
            if (PageIndex < 0)
                PageIndex = 0;
            SmartGridView1.PageIndex = PageIndex;
            MyDataBind();
        }

        private void SetShowPageIndex()
        {
        }

        protected void SmartGridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            SmartGridView1.PageIndex = 0;
            MyDataBind();
        }

        /// <summary>
        /// 末页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            int pagecount;
            int recordcount = ((DataSet)ViewState["DS"]).Tables[0].Rows.Count;
            if (recordcount % SmartGridView1.PageSize == 0)
                pagecount = recordcount / SmartGridView1.PageSize;
            else
                pagecount = (recordcount / SmartGridView1.PageSize) + 1;
            SmartGridView1.PageIndex = pagecount - 1;
            MyDataBind();
        }

        protected void SmartGridView1_PreRender(object sender, EventArgs e)
        {
            if (MyGridView_PreRender != null)
                MyGridView_PreRender(sender, e);
        }

        //跳转到X页
        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            int pagecount;
            int recordcount = ((DataSet)ViewState["DS"]).Tables[0].Rows.Count;
            if (recordcount % SmartGridView1.PageSize == 0)
                pagecount = recordcount / SmartGridView1.PageSize;
            else
                pagecount = (recordcount / SmartGridView1.PageSize) + 1;

            if (ConvertEx.ToInt(TextBox1.Text) <= 0)
                SmartGridView1.PageIndex = 0;
            else if (ConvertEx.ToInt(TextBox1.Text) >= pagecount)
                SmartGridView1.PageIndex = pagecount - 1;
            else
                SmartGridView1.PageIndex = ConvertEx.ToInt(TextBox1.Text) - 1;

            MyDataBind();
        }

        public void SetSelectBox(string ID)
        {
            for (int i1 = 0; i1 < SmartGridView1.DataKeys.Count; i1++)
            {
                if (SmartGridView1.DataKeys[i1].Value.ToString() == ID)
                {
                    CheckBox c1 = (CheckBox)SmartGridView1.Rows[i1].Cells[0].Controls[1];
                    c1.Checked = true;
                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["PageCount"] = Common.ConvertEx.ToInt(DropDownList1.SelectedValue);// _PageCount;
            MyDataBind();
        }

        public void SetColumnTitle(int ColIndex, string ColName)
        {
            SmartGridView1.Columns[ColIndex].HeaderText = ColName;
        }
    }
}