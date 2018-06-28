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
using System.Text;
using System.IO;

//电子文件转换详情预览

namespace DigiPower.Onlinecol.Standard.Web.SystemManage
{
    public partial class EfileConvertLogView : PageBase
    {
        T_EFile_ConvertLog_BLL efileLogBLL = new T_EFile_ConvertLog_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            MyAddInit();
            if (!IsPostBack)
            {
                T_EFile_ConvertLog_MDL efileLogMDL = efileLogBLL.GetModel(ConvertEx.ToInt(ID));
                if (efileLogMDL != null)
                {
                    ltgcbm.Text = DNTRequest.GetQueryString("gcbm");
                    ltSingleProjectID.Text = efileLogMDL.SingleProjectID.ToString();
                    ltFileListID.Text = efileLogMDL.FileListID.ToString();
                    ltEFileID.Text = efileLogMDL.EFileID.ToString();
                    ltFileName.Text = efileLogMDL.FileName;
                    ltCreateDate.Text = ConvertEx.ToDate(efileLogMDL.CreateDate).ToString("yyyy-MM-dd HH:mm:ss");
                    ltDescription.Text = efileLogMDL.Description;
                    ltDownUrl.Text = GetEFileURL(efileLogMDL.EFileStartPath, efileLogMDL.FileName, efileLogMDL.SingleProjectID.ToString());
                }
            }
        }

        /// <summary>
        /// 获取电子文件下载URL
        /// </summary>
        /// <param name="RootPath"></param>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public string GetEFileURL(string RootPath, string FilePath, string SingleProjectID)
        {
            if (System.IO.File.Exists(Path.Combine(RootPath, SingleProjectID, "ODOC", FilePath)))
            {
                string LastPath = RootPath.Substring(0, RootPath.Length - 1);
                int iPos1 = LastPath.LastIndexOf('\\');
                LastPath = LastPath.Substring(iPos1 + 1);
                string mHttpUrl = "http://" + Request.ServerVariables["HTTP_HOST"] + "/" + LastPath;

                string strFormat = "<a style=\"cursor: pointer;\" target=\"_blank\" href=\"" + (
                    mHttpUrl + "/" + SingleProjectID + "/ODOC/" + FilePath) + "\" title=\"点击下载查看转换失败的原文\">";
                strFormat += "<img src=\"../Javascript/Layer/image/EFILE.png\" alt=\"\" /></a>";
                return strFormat;
            }
            else
                return string.Empty;
        }
    }
}