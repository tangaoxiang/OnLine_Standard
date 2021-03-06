﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.CBLL;
using DigiPower.Onlinecol.Standard.Common;
using System.Data;

namespace DigiPower.Onlinecol.Standard.Web.File
{
    public partial class PreviewImage : System.Web.UI.Page
    {
        T_FileList_BLL fileListBLL = new T_FileList_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                int fileListID = DNTRequest.GetQueryInt("ID", 0);
                int singleProjectID = DNTRequest.GetQueryInt("SingleProjectID", 0);

                if (fileListID > 0 && singleProjectID > 0)
                {
                    T_FileList_MDL fileListMDL = fileListBLL.GetModel(fileListID);

                    DataTable tb = fileListBLL.GetList("SingleProjectID=" + singleProjectID + " and BH like 'S%' and RootPath !=''  and (PID=" +
                        fileListID + " or FileListID=" + fileListID + ")", "OrderIndex", true).Tables[0];
                    GetImageHTML(tb);
                }
                else
                {
                    MessageBox.ShowAndCloseWin(this, "参数不正确！");
                }
            }
        }

        private void GetImageHTML(DataTable tb)
        {
            StringBuilder strBuilder = new StringBuilder();
            if (tb != null)
            {
                string cssName = string.Empty;
                for (var i = 0; i < tb.Rows.Count; i++)
                {
                    if (i == 0) cssName = "liSelected";
                    else cssName = string.Empty;

                    string rootPath = ConvertEx.ToString(tb.Rows[i]["RootPath"]);                     //照片路径
                    string fileName = ConvertEx.ToString(tb.Rows[i]["wjbt"]);                         //文件名称

                    string LastPath = rootPath.Substring(0, rootPath.Length - 1);
                    LastPath = LastPath.Substring(LastPath.IndexOf('\\') + 1);

                    string imgURL = string.Concat("http://", Request.ServerVariables["HTTP_HOST"], "/", LastPath, "/", fileName);

                    ltImagBig.Text += "<li class=\"" + cssName + "\">";
                    ltImagBig.Text += "     <span class=\"sPic\">";
                    ltImagBig.Text += "         <i class=\"iBigPic\">";
                    ltImagBig.Text += "         <img alt=\"大图\" width=\"570px\" height=\"440px\" src=\"" + imgURL + "\"></a></i>";
                    ltImagBig.Text += "     </span>";
                    ltImagBig.Text += "     <span class=\"sSideBox\">";
                    ltImagBig.Text += "          <span class=\"sIntro\"><table><tr><td class=\"td1\">文件题名：</td><td>" + ConvertEx.ToString(tb.Rows[i]["title"]) + "</td></tr></table></span>";
                    ltImagBig.Text += "          <span class=\"sIntro\"><table><tr><td class=\"td1\">拍摄地点：</td><td>" + ConvertEx.ToString(tb.Rows[i]["psdd"]) + "</td></tr></table></span>";
                    ltImagBig.Text += "          <span class=\"sIntro\"><table><tr><td class=\"td1\">拍摄者：</td><td>" + ConvertEx.ToString(tb.Rows[i]["psz"]) + "</td></tr></table></span>";
                    ltImagBig.Text += "          <span class=\"sIntro\"><table><tr><td class=\"td1\">拍摄时间：</td><td>" +
                       ((tb.Rows[i]["pssj"] == DBNull.Value) ? "" : ConvertEx.ToDate(tb.Rows[i]["pssj"]).ToString("yyyy-MM-dd")) + "</td></tr></table></span>";
                    ltImagBig.Text += "          <span class=\"sIntro\"><table><tr><td class=\"td1\">色别：</td><td>" + ConvertEx.ToString(tb.Rows[i]["sb"]) + "</td></tr></table></span>";
                    ltImagBig.Text += "          <span class=\"sIntro\"><table><tr><td class=\"td1\">分别率：</td><td>" + ConvertEx.ToString(tb.Rows[i]["fbl"]) + "</td></tr></table></span>";
                    ltImagBig.Text += "          <span class=\"sIntro\"><table><tr><td class=\"td1\">相机品牌：</td><td>" + ConvertEx.ToString(tb.Rows[i]["xjpp"]) + "</td></tr></table></span>";
                    ltImagBig.Text += "          <span class=\"sIntro\"><table><tr><td class=\"td1\">相机型号：</td><td>" + ConvertEx.ToString(tb.Rows[i]["xjxh"]) + "</td></tr></table></span>";
                    ltImagBig.Text += "          <span class=\"sIntro\"><table><tr><td class=\"td1\">附注：</td><td>" + ConvertEx.ToString(tb.Rows[i]["bz"]) + "</td></tr></table></span>";
                    ltImagBig.Text += "          <span class=\"sMore\"><a href=\"" + imgURL + "\" target=\"_blank\">查看原图&gt;&gt;</a></span>";
                    ltImagBig.Text += "    </span>";
                    ltImagBig.Text += " </li>";

                    ltImageSmall.Text += "<li class=\"" + cssName + "\">";
                    ltImageSmall.Text += "     <span class=\"sPic\">";
                    ltImageSmall.Text += "         <img alt=\"" + ConvertEx.ToString(tb.Rows[i]["title"]) + "\" src=\"" + imgURL + "\" width=\"135\" height=\"100\"></span>";
                    ltImageSmall.Text += "     <span class=\"sTitle\">" + ConvertEx.ToString(tb.Rows[i]["title"]) + "</span>";
                    ltImageSmall.Text += "</li>";
                }
            }
        }
    }
}