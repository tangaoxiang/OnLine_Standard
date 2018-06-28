using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace DigiPower.Onlinecol.Standard.Common {
    public static class Session {
        public static string GetSession(string SessionName, bool isToLower = false) {
            string str = "";
            if (HttpContext.Current.Session[SessionName] != null) {
                str = HttpContext.Current.Session[SessionName].ToString();
            }
            if (isToLower)
                return str.ToLower();
            else
                return str;
        }

        public static int GetSessionInt(string SessionName) {
            int str = 0;
            if (HttpContext.Current.Session[SessionName] != null) {
                str = ConvertEx.ToInt(HttpContext.Current.Session[SessionName].ToString());
            }
            return str;
        }

        public static bool GetSessionBool(string SessionName) {
            bool str = false;
            if (HttpContext.Current.Session[SessionName] != null) {
                str = ConvertEx.ToBool(HttpContext.Current.Session[SessionName].ToString());
            }
            return str;
        }
    }
}