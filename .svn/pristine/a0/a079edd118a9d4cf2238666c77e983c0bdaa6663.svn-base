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
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Model;
using System.Collections.Generic;
using System.IO;
using System.Drawing.Imaging;
using System.Text;
using System.Net;
using System.Xml;
using System.Security.Cryptography;

namespace DigiPower.Onlinecol.Standard.Web
{
    public partial class UserLoginGather : System.Web.UI.Page
    {
        protected string strPublicKeyExponent = "";
        protected string strPublicKeyModulus = "";

        protected void Page_Load(object sender, EventArgs e) {
            if (!this.IsPostBack) {
                setRSAParameters();
                this.Title = SystemSet._APPAREA + SystemSet._APPTITLE;
                if (Request.Cookies["LoginName"] != null) {
                    txtUserName.Value = Server.UrlDecode(Request.Cookies["LoginName"].Value);
                }
            }
        }

        private string BytesToHexString(byte[] input) {
            StringBuilder hexString = new StringBuilder(64);

            for (int i = 0; i < input.Length; i++) {
                hexString.Append(String.Format("{0:X2}", input[i]));
            }
            return hexString.ToString();
        }

        public static byte[] HexStringToBytes(string hex) {
            if (hex.Length == 0) {
                return new byte[] { 0 };
            }

            if (hex.Length % 2 == 1) {
                hex = "0" + hex;
            }

            byte[] result = new byte[hex.Length / 2];

            for (int i = 0; i < hex.Length / 2; i++) {
                result[i] = byte.Parse(hex.Substring(2 * i, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            }

            return result;
        }

        /// <summary>
        /// 设置公匙参数
        /// </summary>
        private void setRSAParameters() {
            using (StreamReader reader = new StreamReader(Server.MapPath("/RsaKey/PrivateKey.xml"))) {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(reader.ReadToEnd());

                //把公钥适当转换，准备发往客户端
                RSAParameters parameter = rsa.ExportParameters(false);
                strPublicKeyExponent = BytesToHexString(parameter.Exponent);
                strPublicKeyModulus = BytesToHexString(parameter.Modulus);
            }
        }
    }
}
