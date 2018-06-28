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
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.CBLL;
using DigiPower.Onlinecol.Standard.Common;

namespace DigiPower.Onlinecol.Standard.Web.File
{
    public partial class BatchUploadFile : System.Web.UI.Page
    {
        /// <summary>
        /// 文件ID
        /// </summary>
        public string FileID = "";

        /// <summary>
        /// 工程ID
        /// </summary>
        public string ProNo = "000000";

        /// <summary>
        /// 电子文件存放起始路径
        /// </summary>
        string StartPath = "";

        /// <summary>
        /// 原始文件路径
        /// </summary>
        string OPath = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            StartPath = Common.Common.EFileStartPath;

            if (!String.IsNullOrEmpty(DNTRequest.GetQueryString("SingleProjectID")))
            {
                ProNo = DNTRequest.GetQueryString("SingleProjectID");
            }

            FileID = DNTRequest.GetQueryString("FileID");

            StartPath += ProNo;
            OPath = StartPath + "\\ODOC\\";

            CreateDic();
        }

        /// <summary>
        /// 创建电子文件存放目录
        /// </summary>
        private void CreateDic()
        {
            if (!System.IO.Directory.Exists(StartPath))
            {
                System.IO.Directory.CreateDirectory(StartPath);
            }
            if (!System.IO.Directory.Exists(OPath))
            {
                System.IO.Directory.CreateDirectory(OPath);
            }
        }
    }
}