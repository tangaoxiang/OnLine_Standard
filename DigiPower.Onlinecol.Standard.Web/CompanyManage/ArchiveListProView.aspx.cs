using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.Model;
using System.Collections.Generic;

//案卷跟踪

namespace DigiPower.Onlinecol.Standard.Web.CompanyManage
{
    public partial class ArchiveListProView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {
            if (!this.IsPostBack) {
                if (!string.IsNullOrWhiteSpace(DNTRequest.GetQueryString("SingleProjectID"))) {
                    ltHTML.Text = PartCountFileList(DNTRequest.GetQueryString("SingleProjectID"));
                }
            }
        }

        public string PartCountFileList(string singleProjectID) {
            try {
                T_FileList_BLL Bll = new T_FileList_BLL();
                DataTable tab = Bll.GetFinishFileCountByFileType(singleProjectID);  //归档目录标题 PID=0        

                if (tab != null && tab.Rows.Count > 0) {

                    StringBuilder strBuilder = new StringBuilder();
                    strBuilder.Append("<table class=\"layui-table\">");
                    strBuilder.Append("    <colgroup>");
                    strBuilder.Append("        <col width=\"230\">");
                    strBuilder.Append("        <col>");
                    strBuilder.Append("    </colgroup>");
                    strBuilder.Append("    <tbody>");

                    for (int i = 0; i < tab.Rows.Count; i++) {
                        int PerCent = 0;
                        int doCount = ConvertEx.ToInt(tab.Rows[i]["doCount"]);
                        int allCount = ConvertEx.ToInt(tab.Rows[i]["allCount"]);

                        if (doCount > 0 && allCount > 0) {
                            PerCent = ConvertEx.ToInt(ConvertEx.ToDouble(100 * doCount / allCount));
                        }
                        strBuilder.Append("        <tr>");
                        strBuilder.Append("            <td>" + String.Concat(tab.Rows[i]["BH"].ToString(), ":",
                            ConvertEx.ToString(tab.Rows[i]["Title"]), "&nbsp;<strong>", doCount, "/", allCount, "</strong>") + "</td>");
                        strBuilder.Append("            <td>");
                        strBuilder.Append("                 <div class=\"layui-progress layui-progress-big\" lay-showpercent=\"true\">");
                        strBuilder.Append("                     <div class=\"layui-progress-bar layui-bg-green\" lay-percent=\"" + PerCent + "%\"");
                        strBuilder.Append("                 </div>");
                        strBuilder.Append("           </td>");
                        strBuilder.Append("        </tr>");
                    }
                    strBuilder.Append("    </tbody>");
                    strBuilder.Append("</table>");
                    return strBuilder.ToString();
                } return "<blockquote class=\"layui-elem-quote\">该工程没有任何文件,原因:可能没有报建确认!</blockquote>";
            }
            catch (Exception ex) {
                throw ex;
            }
        }
    }
}