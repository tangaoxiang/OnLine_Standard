﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace DigiPower.Onlinecol.Standard.Web.CommonCtrl {
    public partial class ctrlTextBoxEx : System.Web.UI.UserControl {
        string _initDate = string.Empty;

        public delegate void TextChanged();
        public event TextChanged MyTextChanged;

        private TextBoxExMode _Mode;
        private ControlStatus _Status;


        protected void Page_Load(object sender, EventArgs e) {
        }

        #region 属性


        /// <summary>
        /// 添加自定义属性
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="Value"></param>
        public void Attributes(string Key, string Value) {
            TextBox1.Attributes.Add(Key, Value);
        }


        ///// <summary>
        ///// 是否可空
        ///// </summary>
        ///// <param name="b"></param>
        //public void EnableNotEmpty(bool b)
        //{
        //    if (b == true)
        //    {
        //    }
        //    else
        //    {

        //        this.Controls.Remove(this.FindControl("RequiredFieldValidator1"));
        //    }
        //}

        /// <summary>
        ///字段说明,提示信息用
        /// </summary>
        public string labelTitle {
            set {
                if (!String.IsNullOrWhiteSpace(value))
                    TextBox1.Attributes.Add("labelTitle", value);
                else
                    TextBox1.Attributes.Add("labelTitle", "");
            }
        }

        /// <summary>
        /// 获取或设置当鼠标指针悬停在 Web 服务器控件上时显示的文本。
        /// </summary>
        public string ToolTipString {
            set {
                TextBox1.ToolTip = value;
            }
        }

        /// <summary>
        /// 是否可空
        /// </summary>
        public bool canEmpty {
            set {
                if (!value) {
                    //this.Controls.Remove(this.FindControl("RequiredFieldValidator1"));
                    //RequiredFieldValidator requiredValidator = new RequiredFieldValidator();
                    //requiredValidator.ControlToValidate = "TextBox1";
                    //requiredValidator.ErrorMessage = "";
                    //requiredValidator.SetFocusOnError = true;
                    //this.Controls.Add(requiredValidator);
                    lb1.Visible = true;
                }
                TextBox1.Attributes.Add("canEmpty", value ? "true" : "false");
            }
        }
        public string Text {
            set {
                if (mode == TextBoxExMode.Date) {
                    if (!string.IsNullOrEmpty(value))
                        TextBox1.Text = Common.ConvertEx.ToDate(value).ToString("yyyy-MM-dd");
                } else {
                    TextBox1.Text = value;
                    TextBox1.ToolTip = value;
                }
            }
            get {
                if (Status == ControlStatus.Select)
                    return CheckStr(TextBox1.Text);
                else
                    return CheckStr(TextBox1.Text.Trim());
            }
        }

        private string CheckStr(string text) {
            string[] ErrorStr = { "'", "%", @"\", "&" };
            if (text.Trim().Length > 0) {
                foreach (string Str in ErrorStr) {
                    text = text.Replace(Str, "#");
                }
            }
            return text;
        }

        public enum ControlStatus {
            Add,
            Select
        }

        /// <summary>
        /// 设置控件的状态，如果是查询，则过滤特殊字符，新增则不考虑
        /// </summary>
        public ControlStatus Status {
            set { _Status = value; }
            get { return _Status; }
        }

        public TextBoxMode TextMode {
            set {
                TextBox1.TextMode = value;
                if (TextBox1.TextMode == TextBoxMode.MultiLine && this.MaxLength > 0) {
                    TextBox1.Attributes.Add("onpropertychange", "Common.isTextAreaCheckLength(this," + this.MaxLength + ")");
                    TextBox1.Attributes.Add("oninput", "Common.isTextAreaCheckLength(this," + this.MaxLength + ")");
                    TextBox1.Attributes.Add("onkeyup", "Common.isTextAreaCheckLength(this," + this.MaxLength + ")");
                }
            }
        }

        public enum TextBoxExMode {
            NULL,
            Date,
            DateNoTip,
            Int,
            Float,
            Email,
            PostCode,
            ID,
            Chinese
        }

        public TextBoxExMode mode {
            set {
                TextBox1.Attributes.Add("mode", value.ToString());
                switch (value) {
                    case TextBoxExMode.Date:
                        if (Status == ControlStatus.Select) {
                            TextBox1.Attributes.Add("onkeydown", "return false;");
                            //TextBox1.ReadOnly = true;
                            //TextBox1.Attributes.Add("onclick", "new Calendar().show(this);");
                            //TextBox1.Attributes.Add("onfocus", "this.blur();");
                        }

                        //TextBox1.Attributes.Add("onblur", "return CheckValid(this,'" + _description + "','Date');");
                        lbdate.Visible = true;
                        break;
                    //case TextBoxExMode.DateNoTip:
                    //    TextBox1.Attributes.Add("onclick", "new Calendar().show(this);");
                    //    TextBox1.Attributes.Add("onblur", "return CheckValid(this,'" + _description + "','Date');");
                    //    break;
                    //case TextBoxExMode.Int:
                    //    TextBox1.Attributes.Add("onblur", "return CheckValid(this,'" + _description + "','Numeric');");
                    //    break;
                    //case TextBoxExMode.Email:
                    //    TextBox1.Attributes.Add("onblur", "return CheckValid(this,'" + _description + "','Email')");
                    //    break;
                    //case TextBoxExMode.Float:
                    //    TextBox1.Attributes.Add("onblur", "return CheckValid(this,'" + _description + "','Float')");
                    //    break;
                    //case TextBoxExMode.PostCode:
                    //    TextBox1.Attributes.Add("onblur", "return CheckValid(this,'" + _description + "','PostalCode')");
                    //    break;
                    //case TextBoxExMode.ID:
                    //    TextBox1.Attributes.Add("onblur", "return CheckValid(this,'" + _description + "','ID')");
                    //    break; 
                }
                _Mode = value;
            }
            get {
                return _Mode;
            }
        }

        public bool enabled {
            set { TextBox1.Enabled = value; }
            get {
                return TextBox1.Enabled;
            }
        }

        public bool readOnly {
            set { TextBox1.ReadOnly = value; }
            get {
                return TextBox1.ReadOnly;
            }
        }

        public bool Visible {
            set { TextBox1.Visible = value; }
        }

        public string initDate {
            set {
                if (DigiPower.Onlinecol.Standard.Common.Utils.IsDateString(value)) {
                    _initDate = value;
                }
            }
        }

        public bool ShowLblDate {
            set { lbdate.Visible = value; }
        }

        public new string ClientID {
            get {
                return TextBox1.ClientID;
            }
        }

        public string width {
            set { TextBox1.Width = new Unit(value); }
        }

        public string height {
            set { TextBox1.Height = new Unit(value); }
        }

        public int Rows {
            set {
                TextBox1.TextMode = TextBoxMode.MultiLine;
                TextBox1.Rows = value;
            }
        }

        public string CssClass {
            set { TextBox1.CssClass = value; }
        }

        public int MaxLength {
            set { TextBox1.MaxLength = value; }
            get { return TextBox1.MaxLength; }
        }

        private string _description = "";

        public string Description {
            set { _description = value; }
        }

        #endregion

        protected void TextBox1_TextChanged(object sender, EventArgs e) {
            if (MyTextChanged != null) {
                MyTextChanged();
            }
        }
    }
}