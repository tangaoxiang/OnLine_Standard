using System;
using System.Collections.Generic;
using System.Web;

using System.Net.Mail;
//using System.Xml;
//using System.Text;
//using System.IO;
using System.Configuration;

namespace DigiPower.Onlinecol.Standard.Web
{
    /// <summary>
    /// 发送邮件
    /// </summary>
    public class CSendEmail
    {
        public static bool SendEmail(string strFrom, string strTo, string strSubject, string strMsgBody, string strAttachFile)
        {
            bool bSuss = false;
            if (strTo == "")
            {
                return false;
            }

            MailMessage msg = new System.Net.Mail.MailMessage();
            string[] strToList = strTo.Split(';');
            for (int i1 = 0; i1 < strToList.Length; i1++)
            {
                if (strToList[i1] != "")
                {
                    msg.To.Add(strToList[i1]);
                }
            }

            string strEmailServerIP = ConfigurationManager.AppSettings["EmailServerIP"];
            string strEmailAddress = ConfigurationManager.AppSettings["EmailAddress"];
            string strEmailAddressPwd = ConfigurationManager.AppSettings["EmailAddressPwd"];
            msg.From = new MailAddress(strFrom + "<" + strEmailAddress + ">", strFrom, System.Text.Encoding.GetEncoding("GBK"));

            msg.Subject = strSubject;
            msg.SubjectEncoding = System.Text.Encoding.GetEncoding("GBK");
            msg.Body = strMsgBody;
            msg.BodyEncoding = System.Text.Encoding.GetEncoding("GBK");
            msg.IsBodyHtml = true;

            if (strAttachFile != "")
            {
                Attachment atta1 = new Attachment(strAttachFile);
                msg.Attachments.Add(atta1);
            }

            SmtpClient client = new SmtpClient();
            client.Host = strEmailServerIP;
            client.Credentials = new System.Net.NetworkCredential("" + strEmailAddress + "", "" + strEmailAddressPwd + "");
            try
            {
                client.Send(msg);
                bSuss = true;
                msg.Dispose();
                client = null;

            }
            catch (System.Net.Mail.SmtpException ex)
            {
                string outstr = ex.Message;
                bSuss = false;
            }
            return bSuss;
        }
    }
}