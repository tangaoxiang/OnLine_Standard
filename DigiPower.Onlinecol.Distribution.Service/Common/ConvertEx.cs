using System;
using System.Collections.Generic;
using System.Text;

namespace DigiPower.Onlinecol.Distribution.Service {
    /// <summary>
    /// 数据类型转换类
    /// </summary>
    public class ConvertEx {
        public static string ToString(string InStr) {
            return InStr;
        }

        public static int ToInt(string oldString) {
            if (!String.IsNullOrEmpty(oldString)) {
                string strOut = "";
                char[] c1 = oldString.ToCharArray();
                for (int i1 = 0; i1 < c1.Length; i1++) {
                    if (c1[i1] >= 48 && c1[i1] <= 57) {
                        strOut += c1[i1];
                    }
                }

                if (strOut == "")
                    strOut = "0";
                return int.Parse(strOut);
            }

            return 0;
        }

        public static string ToString(object obj) {
            string strOut = "";
            if (obj != null) {
                strOut = obj.ToString();
            }
            return strOut;
        }

        public static int ToInt(object obj) {
            int strOut = 0;
            if (obj != null && obj.ToString() != "") {
                if (obj.ToString().ToLower() == "true")
                    strOut = 1;
                else if (obj.ToString().ToLower() == "false")
                    strOut = 0;
                else
                    strOut = ToInt(obj.ToString());
            }
            return strOut;
        }

        public static DateTime ToDate(object obj) {
            DateTime strOut = new DateTime();
            if (obj != null && obj.ToString() != "") {
                try {
                    strOut = DateTime.Parse(obj.ToString());
                } catch { }
            }
            return strOut;
        }

        public static float GetPercent(object obj) {
            float strOut = 0;
            try {
                if (obj != null && obj.ToString() != "") {
                    string str1 = obj.ToString();
                    int iPos1 = str1.IndexOf('%');
                    if (iPos1 > 0) {
                        str1 = str1.Replace("%", "");
                        float istr1 = float.Parse(str1);
                        strOut = istr1 / 100;
                    } else {
                        strOut = float.Parse(obj.ToString());
                    }
                }
            } catch {
                strOut = 0;
            }
            if (strOut > 1)
                strOut = 0;

            return strOut;
        }

        public static double ToDouble(object obj) {
            double strOut = 0;
            if (obj != null && obj.ToString() != "") {
                try {
                    strOut = double.Parse(obj.ToString());
                } catch { }
            }
            return strOut;
        }

        public static Decimal ToDecimal(object obj) {
            Decimal strOut = 0;
            if (obj != null && obj.ToString() != "") {
                try {
                    strOut = Decimal.Parse(obj.ToString());
                } catch { }
            }
            return strOut;
        }

        public static bool ToBool(object obj) {
            bool strOut = false;
            if (obj != null && obj.ToString() != "") {
                if (obj.ToString().ToLower() == "true" || obj.ToString().ToLower() == "false") {
                } else {
                    if (obj.ToString() == "0") {
                        obj = "false";
                    } else {
                        obj = "true";
                    }
                }
                strOut = bool.Parse(obj.ToString());
            }
            return strOut;
        }

        public static byte ToByte(object obj) {
            byte strOut = 0;
            if (obj != null && obj.ToString() != "") {
                try {
                    strOut = byte.Parse(obj.ToString());
                } catch { }
            }
            return strOut;
        }

        public static long ToLong(object obj) {
            long strOut = 0;
            if (obj != null && obj.ToString() != "") {
                strOut = long.Parse(obj.ToString());
            }
            return strOut;
        }
        #region 判断是否日期
        public static bool IsDate(string str) {
            DateTime dateMin = new DateTime(1753, 1, 1, 0, 0, 0);
            DateTime dateMax = new DateTime(3099, 1, 1, 0, 0, 0);
            DateTime dateTmp;
            bool result = true;
            try {
                dateTmp = DateTime.Parse(str);
                if (dateTmp < dateMin || dateTmp > dateMax)
                    result = false;
                //DateTime.ParseExact(str, "yyyy.M.d", DateTimeFormatInfo.CurrentInfo);
            } catch (FormatException) {
                result = false;
            }
            return result;
        }
        #endregion
        //public static System.Drawing.Color GetColorByName(string ColorName)//Gray
        //{
        //    System.Drawing.ColorConverter colorCov = new System.Drawing.ColorConverter();
        //    System.Drawing.Color color = (System.Drawing.Color)colorCov.ConvertFromString(ColorName);
        //    return color;
        //}
    }
}
