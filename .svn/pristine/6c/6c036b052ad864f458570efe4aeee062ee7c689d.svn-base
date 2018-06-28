using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Collections;

namespace DigiPower.Onlinecol.Standard.Web
{
    public static class PrevURLList
    {
        /// <summary>
        /// 加入当前URL，以便回退到这里
        /// </summary>
        /// <param name="URL"></param>
        public static void AddCurrentURL(string URL,string LocalFile)
        {
            ArrayList aList = new ArrayList();
            if (HttpContext.Current.Session["PrevURLList"] != null)
            {
                aList = (ArrayList)HttpContext.Current.Session["PrevURLList"];
                if (aList.Count > 0)
                {
                    string strTemp = aList[aList.Count - 1].ToString();
                    if (strTemp.Contains(LocalFile))
                    {//最后一条包启这个轨迹
                        return;
                    }
                }

                aList.Add(URL);
                for (int i1 = 100; i1 < aList.Count - 1; i1++)
                {//只记录100条
                    aList.RemoveAt(0);
                }
            }
            else
            {
                aList.Add(URL);
            }
            HttpContext.Current.Session["PrevURLList"] = aList;
        }

        /// <summary>
        /// 取最后一条URL，不删除
        /// </summary>
        /// <returns></returns>
        public static string GetListestURL()
        {
            string outString = "";
            if (HttpContext.Current.Session["PrevURLList"] != null)
            {
                ArrayList aList = (ArrayList)HttpContext.Current.Session["PrevURLList"];
                if (aList.Count > 0)
                {
                    outString = aList[aList.Count - 1].ToString();
                }
            }
            return outString;
        }

        /// <summary>
        /// 取最后一条URL，回退,删除
        /// </summary>
        /// <returns></returns>
        public static string GetListestURLAndBack()
        {
            string outString = "";
            if (HttpContext.Current.Session["PrevURLList"] != null)
            {
                ArrayList aList = (ArrayList)HttpContext.Current.Session["PrevURLList"];
                if (aList.Count > 0)
                {
                    outString = aList[aList.Count - 1].ToString();
                    aList.RemoveAt(0);
                    HttpContext.Current.Session["PrevURLList"] = aList;
                }
            }
            return outString;
        }

        public static void Clear()
        {
            HttpContext.Current.Session["PrevURLList"] = null;
        }
    }
}