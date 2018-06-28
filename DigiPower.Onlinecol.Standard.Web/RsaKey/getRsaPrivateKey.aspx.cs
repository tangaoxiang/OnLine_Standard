using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DigiPower.Onlinecol.Standard.Web.RsaKey
{
    public partial class getRsaPrivateKey : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            txtRsaPrivateKey.Text = rsa.ToXmlString(true);
        }
    }
}