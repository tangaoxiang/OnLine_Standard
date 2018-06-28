using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace DigiPower.Onlinecol.Standard.Web
{
    public class ColumnTemplate : System.Web.UI.ITemplate
    {
        //string id;

        //string bindField;

        private string templateType;
        private string columnName;
        private int objLength;
        private string subType = "";
        //private bool bShow = true;
        private bool Enabled = false;

        public ColumnTemplate(string type, string colname, int iLength)
        {
            templateType = type;
            columnName = colname;
            objLength = iLength;  
        }

        public ColumnTemplate(string type, string colname, int iLength, bool tenabled)
        {
            templateType = type;
            columnName = colname;
            objLength = iLength;
            Enabled = tenabled;
        }

        public ColumnTemplate(string type, string colname, int iLength, string ssubType)
        {
            templateType = type;
            columnName = colname;
            objLength = iLength;
            subType = ssubType;
        }

        public void InstantiateIn(Control container)
        {
            switch (templateType)
            {
                case "LBL":
                    {
                        Literal lc = new Literal();
                        lc.ID = columnName;
                        lc.Text = "<B>新加的</B>";
                        container.Controls.Add(lc);
                    }
                    break;
                case "Label":
                    {
                        Label lbtn = new Label();
                        lbtn.ID = columnName;
                        //lbtn.Visible = bShow;                        
                        lbtn.DataBinding += new EventHandler(Label_DataBinding);//创建数据绑定事件
                        container.Controls.Add(lbtn);
                    }
                    break;
                case "TXT":
                    {
                        TextBox lbtn = new TextBox();
                        lbtn.AutoCompleteType = AutoCompleteType.Disabled;
                        lbtn.ID = columnName;
                        if (objLength <= 10)
                        {
                            lbtn.Style.Add("width", "99%");
                        }
                        else
                        {
                            lbtn.Width = objLength - 2;
                            //lbtn.Style.Add("width", objLength.ToString())
                        }
                        lbtn.DataBinding += new EventHandler(TextBox_DataBinding);//创建数据绑定事件
                        container.Controls.Add(lbtn);
                    }
                    break;
                case "DRP":
                    {
                        DropDownList drp = new DropDownList();
                        drp.ID = columnName;
                        drp.DataBinding += new EventHandler(drp_DataBinding);//创建数据绑定事件
                        container.Controls.Add(drp);
                    }
                    break;
                case "Image":
                    {
                        Image drp = new Image();
                        drp.ID = columnName;
                        if (objLength > 50)
                        {
                            drp.Width = objLength - 2;
                        }
                        drp.DataBinding += new EventHandler(Image_DataBinding);//创建数据绑定事件
                        container.Controls.Add(drp);
                    }
                    break;
                case "CheckBox":
                    {
                        CheckBox drp = new CheckBox();
                        drp.ID = columnName;
                        drp.DataBinding += new EventHandler(CheckBox_DataBinding);//创建数据绑定事件
                        container.Controls.Add(drp);
                    }
                    break;
                case "FileUpload":
                    {
                        FileUpload drp = new FileUpload();
                        drp.ID = columnName;
                        drp.DataBinding += new EventHandler(FileUpload_DataBinding);//创建数据绑定事件
                        container.Controls.Add(drp);
                    }
                    break;
                case "SystemInfo":
                    {
                        CommonCtrl.ctrlDropDownSystemInfo drp = new DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownSystemInfo();
                        drp.CurrentType = subType;
                        drp.DataBindEx();

                        //FileUpload drp = new FileUpload();
                        drp.ID = columnName;
                        drp.DataBinding += new EventHandler(SystemInfo_DataBinding);//创建数据绑定事件
                        container.Controls.Add(drp);
                    }
                    break;
                default:
                    break;
            }
        }

        void drp_DataBinding(object sender, EventArgs e)
        {
            DropDownList drp = (DropDownList)sender;
            GridViewRow gr = (GridViewRow)drp.NamingContainer;
            BLL.T_UsersInfo_BLL Ubll = new DigiPower.Onlinecol.Standard.BLL.T_UsersInfo_BLL();
            DataSet ds = Ubll.GetAllList();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem item = new ListItem();
                item.Text = ds.Tables[0].Rows[i]["UserName"].ToString();
                item.Value = ds.Tables[0].Rows[i]["UserID"].ToString();
                drp.Items.Add(item);
            }

            //关键位置
            //使用DataBinder.Eval绑定数据
            //ProName,MyTemplate的属性.在创建MyTemplate实例时,为此属性赋值(数据源字段)
            string ArlistID = DataBinder.Eval(gr.DataItem, "FileListID").ToString();
            BLL.T_FileList_BLL Abll = new DigiPower.Onlinecol.Standard.BLL.T_FileList_BLL();
            Model.T_FileList_MDL Amodel = new DigiPower.Onlinecol.Standard.Model.T_FileList_MDL();
            Amodel = Abll.GetModel(Common.ConvertEx.ToInt(ArlistID));
            if (Amodel != null)
            {
                drp.SelectedValue = Amodel.OperateUserID.ToString();
            }
        }

        void Label_DataBinding(object sender, EventArgs e)
        {
            Label lbtn = (Label)sender;
            GridViewRow gr = (GridViewRow)lbtn.NamingContainer;
            lbtn.Text = DataBinder.Eval(gr.DataItem, columnName).ToString();
        }

        void TextBox_DataBinding(object sender, EventArgs e)
        {
            TextBox lbtn = (TextBox)sender;
            GridViewRow gr = (GridViewRow)lbtn.NamingContainer;
            lbtn.Text = DataBinder.Eval(gr.DataItem, columnName).ToString();
        }

        void Image_DataBinding(object sender, EventArgs e)
        {
            Image obj = (Image)sender;
            GridViewRow gr = (GridViewRow)obj.NamingContainer;
            obj.ImageUrl = DataBinder.Eval(gr.DataItem, columnName).ToString();
        }

        void CheckBox_DataBinding(object sender, EventArgs e)
        {
            CheckBox obj = (CheckBox)sender;
            GridViewRow gr = (GridViewRow)obj.NamingContainer;
            obj.Checked = Common.ConvertEx.ToBool(DataBinder.Eval(gr.DataItem, columnName));
            obj.Enabled = Enabled;
        }

        void FileUpload_DataBinding(object sender, EventArgs e)
        {
            FileUpload obj = (FileUpload)sender;
        }

        void SystemInfo_DataBinding(object sender, EventArgs e)
        {
            CommonCtrl.ctrlDropDownSystemInfo obj = (CommonCtrl.ctrlDropDownSystemInfo)sender;
        }
    }
}