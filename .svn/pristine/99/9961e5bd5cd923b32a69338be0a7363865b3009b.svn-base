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
using System.IO;
using System.Text;


namespace DigiPower.Onlinecol.Standard.Web.File
{
    public partial class UpLoadEFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["url"] != null)
            {
                try
                {
                    string filePath = Server.MapPath(Request.QueryString["url"]);
                    Response.Buffer = true;
                    byte[] bt = Request.BinaryRead(Request.TotalBytes);

                    FileStream ft = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    ft.Write(bt, 0, bt.Length);
                    ft.Flush();
                    ft.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
