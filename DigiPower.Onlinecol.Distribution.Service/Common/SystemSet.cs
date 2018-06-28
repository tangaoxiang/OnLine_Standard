using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Configuration;

namespace DigiPower.Onlinecol.Distribution.Service {
    public static class SystemSet {
        /// <summary>
        ///程序是否自动运行  false:手动 true:自动
        /// </summary>
        public static readonly bool IsAutoRun = ConvertEx.ToBool(ConfigurationManager.AppSettings["IsAutoRun"].Trim());

        /// <summary>
        /// 数据类型：0-sqlserver；1-oracle
        /// </summary>
        public static readonly int DBType = ConvertEx.ToInt(ConfigurationManager.AppSettings["DBType"].Trim());

        /// <summary>
        ///包是否压缩成ZIP 0:不 1:要
        /// </summary>
        public static readonly bool IsSharpZip = ConvertEx.ToBool(ConfigurationManager.AppSettings["IsSharpZip"].Trim());

        /// <summary>
        ///是否打包工程外观图 0:不 1:要   T_SingleProject_PIC
        /// </summary>
        public static readonly bool IsSharpSingleOutSideView = ConvertEx.ToBool(ConfigurationManager.AppSettings["IsSharpSingleOutSideView"].Trim());

        /// <summary>
        ///ZIP包临时目录
        /// </summary>
        public static readonly string TmpPath = ConfigurationManager.AppSettings["TmpPath"].Trim();

        /// <summary>
        ///馆藏接收ZIP包工作目录
        /// </summary>
        public static readonly string ZipPath = ConfigurationManager.AppSettings["ZipPath"].Trim();

        /// <summary>
        ///馆藏接收工作子目录 ORG001
        /// </summary>
        public static readonly string SubDirectory = ConfigurationManager.AppSettings["SubDirectory"].Trim();

        /// <summary>
        ///在线系统根目录,存放工程外观图
        /// </summary>
        public static readonly string OnlineGuideRootPath = ConfigurationManager.AppSettings["OnlineGuideRootPath"].Trim();
    }
}