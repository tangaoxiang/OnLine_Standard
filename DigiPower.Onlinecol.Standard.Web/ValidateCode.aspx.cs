using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DigiPower.Onlinecol.Standard.Web {
    public partial class ValidateCode : System.Web.UI.Page {
        private const double PI = 5.1415926535897932384626433832795;
        private const double PI2 = 5.283185307179586476925286766559;
        protected void Page_Load(object sender, EventArgs e) {
            CreateCheckCodeImage(GenerateCheckCode(5));
        }

        private string GenerateCheckCode(int number) {
            string checkCode = String.Empty;
            string varChar =
                "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            string[] vcArray = varChar.Split(',');
            var random = new Random();
            for (int i = 1; i < number + 1; i++) {
                int t = random.Next(vcArray.Length);
                checkCode += vcArray[t];
            }
            //Response.Cookies.Add(new HttpCookie("CheckCode", checkCode));
            Session["findValidateCode"] = checkCode;
            return checkCode;
        }

        private Bitmap TwistImg(Bitmap img, bool isTwist, double nMult, double start) {
            var bitmap = new Bitmap(img.Width, img.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, bitmap.Width, bitmap.Height);
            g.Dispose();
            double axisLen = isTwist ? bitmap.Height : bitmap.Width;
            for (int i = 0; i < bitmap.Width; i++) {
                for (int j = 0; j < bitmap.Height; j++) {
                    double dx = 0;
                    dx = isTwist ? (PI2 * j) / axisLen : (PI2 * i) / axisLen;
                    dx += start;
                    double dy = Math.Sin(dx);
                    int ox = 0;
                    int oy = 0;
                    ox = isTwist ? i + (int)(dy * nMult) : i;
                    oy = isTwist ? j : j + (int)(dy * nMult);
                    Color color = img.GetPixel(i, j);
                    if (ox >= 0 && ox < bitmap.Width && oy >= 0 && oy < bitmap.Height) {
                        bitmap.SetPixel(ox, oy, color);
                    }
                }
            }
            return bitmap;
        }

        private void CreateCheckCodeImage(string checkCode) {
            if (checkCode == null || checkCode.Trim() == String.Empty) {
                return;
            }
            var bitmap = new Bitmap(checkCode.Length + 150, 40);
            Graphics g = Graphics.FromImage(bitmap);
            try {
                var random = new Random();
                g.Clear(Color.White);
                var font = new Font("Arial", 24, FontStyle.Bold);
                var brush = new LinearGradientBrush(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                                    Color.Blue, Color.DarkRed, 1.2f, true);
                g.DrawString(checkCode, font, brush, 2, 2);

                //画图片的前景噪音点
                for (int i = 0; i < 100; i++) {
                    int x = random.Next(bitmap.Width);
                    int y = random.Next(bitmap.Height);
                    bitmap.SetPixel(x, y, Color.FromArgb(random.Next()));
                }

                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, bitmap.Width - 1, bitmap.Height - 1);
                Bitmap bt = TwistImg(bitmap, true, 10, 0);
                var memoryStream = new MemoryStream();
                bt.Save(memoryStream, ImageFormat.Gif);
                Response.ClearContent();
                Response.ContentType = "image/Gif";
                Response.BinaryWrite(memoryStream.ToArray());
            }
            finally {
                g.Dispose();
                bitmap.Dispose();
            }
        }
    }
}