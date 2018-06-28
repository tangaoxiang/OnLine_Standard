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
using System.Text;
using System.IO;
using System.Collections.Generic;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.Model;
using Stimulsoft.Report;
using Stimulsoft.Report.Web;
using Stimulsoft.Report.Web.Design;
using Stimulsoft.Report.Dictionary;

namespace DigiPower.Onlinecol.Standard.Web
{
    public partial class ReportPdfView : System.Web.UI.Page
    {
        public string pdfURL = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            pdfURL = String.Concat("http://", Request.Url.Authority,
                "/Upload/TempReport/", DNTRequest.GetQueryString("pdfFileName"), "?rn=" + DateTime.Now.ToString("MMddHHmmssff"));
        }
    }
}
