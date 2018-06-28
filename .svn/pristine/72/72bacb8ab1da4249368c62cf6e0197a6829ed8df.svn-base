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

namespace DigiPower.Onlinecol.Standard.Web.CommonCtrl
{
    public partial class ctrlSwfUpload : System.Web.UI.UserControl
    {
        protected string _savePageUrl = string.Empty;//保存文件操作页面地址
        protected string _fileType = "*.*";//文件类型，默认为所有文件
        protected string _fileTypesDescription = "所有文件";//文件类型描述
        protected string _maxSize = "2";//最大文件尺寸，单位：兆，默认2兆
        protected string _maxQueue = "20";//最大文件队列，默认20个

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.ComponentModel.Browsable(true), System.ComponentModel.Description("保存文件操作页面地址")]
        public string savePageUrl
        {
            set { _savePageUrl = value; }
            get { return _savePageUrl; }
        }
        [System.ComponentModel.Browsable(true), System.ComponentModel.Description("文件类型，默认为所有文件")]
        public string fileType
        {
            set { _fileType = value; }
            get { return _fileType; }
        }
        [System.ComponentModel.Browsable(true), System.ComponentModel.Description("文件类型描述")]
        public string fileTypesDescription
        {
            set { _fileTypesDescription = value; }
            get { return _fileTypesDescription; }
        }
        [System.ComponentModel.Browsable(true), System.ComponentModel.Description("最大文件尺寸，单位：兆，默认2兆")]
        public string maxSize
        {
            set { _maxSize = value; }
            get { return _maxSize; }
        }
        [System.ComponentModel.Browsable(true), System.ComponentModel.Description("最大文件队列，默认20个")]
        public string maxQueue
        {
            set { _maxQueue = value; }
            get { return _maxQueue; }
        }
    }
}