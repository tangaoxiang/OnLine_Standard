using System;
using System.Collections.Generic;
using System.Text;
using log4net;

namespace DigiPower.Onlinecol.Distribution.Service 
{
    /// <summary>
    /// 日志记录工具类
    /// </summary>
    public static class LogUtil
    {
        private static bool log4netInit = false;

        /// <summary>
        /// 取对象类名对应的日志对象
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>对应日志对象</returns>
        public static ILog GetLogger(object obj)
        {
            return GetLogger(obj.GetType());
        }

        /// <summary>
        /// 取类名对应的日志对象
        /// </summary>
        /// <param name="cls">类</param>
        /// <returns>对应日志对象</returns>
        public static ILog GetLogger(Type cls)
        {
            return GetLogger(cls.FullName);
        }

        /// <summary>
        /// 取名称对应的日志对象
        /// </summary>
        /// <param name="cls">类名</param>
        /// <returns>对应日志对象</returns>
        public static ILog GetLogger(string cls)
        {
            if (!log4netInit)
            {
                log4net.Config.XmlConfigurator.Configure();
                log4netInit = true;
            }
            return LogManager.GetLogger(cls);
        }

        /// <summary>
        /// 调试日志
        /// </summary>
        /// <param name="obj">产生日志的对象</param>
        /// <param name="debug">日志消息</param>
        public static void Debug(object obj, string debug)
        {
            ILog log = GetLogger(obj);
            log.Debug(debug);
        }

        /// <summary>
        /// 带异常的调试日志
        /// </summary>
        /// <param name="obj">产生日志的对象</param>
        /// <param name="debug">日志消息</param>
        /// <param name="e">异常</param>
        public static void Debug(object obj, string debug, Exception e)
        {
            ILog log = GetLogger(obj);
            log.Debug(debug, e);
        }

        /// <summary>
        /// 信息日志
        /// </summary>
        /// <param name="obj">产生日志的对象</param>
        /// <param name="debug">日志消息</param>
        public static void Info(object obj, string debug)
        {
            ILog log = GetLogger(obj);
            log.Info(debug);
        }

        /// <summary>
        /// 带异常的信息日志
        /// </summary>
        /// <param name="obj">产生日志的对象</param>
        /// <param name="debug">日志消息</param>
        /// <param name="e">异常</param>
        public static void Info(object obj, string debug, Exception e)
        {
            ILog log = GetLogger(obj);
            log.Info(debug, e);
        }

        /// <summary>
        /// 警告日志
        /// </summary>
        /// <param name="obj">产生日志的对象</param>
        /// <param name="debug">日志消息</param>
        public static void Warn(object obj, string debug)
        {
            ILog log = GetLogger(obj);
            log.Warn(debug);
        }

        /// <summary>
        /// 带异常的警告日志
        /// </summary>
        /// <param name="obj">产生日志的对象</param>
        /// <param name="debug">日志消息</param>
        /// <param name="e">异常</param>
        public static void Warn(object obj, string debug, Exception e)
        {
            ILog log = GetLogger(obj);
            log.Warn(debug, e);
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="obj">产生日志的对象</param>
        /// <param name="debug">日志消息</param>
        public static void Error(object obj, string debug)
        {
            ILog log = GetLogger(obj);
            log.Error(debug);
        }

        /// <summary>
        /// 带异常的错误日志
        /// </summary>
        /// <param name="obj">产生日志的对象</param>
        /// <param name="debug">日志消息</param>
        /// <param name="e">异常</param>
        public static void Error(object obj, string debug, Exception e)
        {
            ILog log = GetLogger(obj);
            log.Error(debug, e);
        }

        /// <summary>
        /// 致命错误日志
        /// </summary>
        /// <param name="obj">产生日志的对象</param>
        /// <param name="debug">日志消息</param>
        public static void Fatal(object obj, string debug)
        {
            ILog log = GetLogger(obj);
            log.Fatal(debug);
        }

        /// <summary>
        /// 带异常的致命错误日志
        /// </summary>
        /// <param name="obj">产生日志的对象</param>
        /// <param name="debug">日志消息</param>
        /// <param name="e">异常</param>
        public static void Fatal(object obj, string debug, Exception e)
        {
            ILog log = GetLogger(obj);
            log.Fatal(debug, e);
        }

        /// <summary>
        /// 使用TestDriven.NET进行单元测试的代码
        /// 注：因日志记录写在文件中，需人工检验日志文件的内容，故未使用Assert断语
        /// </summary>
        private static void testUtil()
        {
            object obj = new object();
            LogUtil.Debug(obj, "debug");
            try
            {
                throw new Exception("TEST EXCEPTION");
            }
            catch (Exception ex)
            {
                LogUtil.Debug(obj, "debug", ex);
            }
            LogUtil.Info(obj, "info");
            try
            {
                throw new Exception("TEST EXCEPTION");
            }
            catch (Exception ex)
            {
                LogUtil.Info(obj, "info", ex);
            }
            LogUtil.Warn(obj, "warn");
            try
            {
                throw new Exception("TEST EXCEPTION");
            }
            catch (Exception ex)
            {
                LogUtil.Info(obj, "warn", ex);
            }
            LogUtil.Error(obj, "error");
            try
            {
                throw new Exception("TEST EXCEPTION");
            }
            catch (Exception ex)
            {
                LogUtil.Error(obj, "error", ex);
            }
            LogUtil.Fatal(obj, "fatal");
            try
            {
                throw new Exception("TEST EXCEPTION");
            }
            catch (Exception ex)
            {
                LogUtil.Fatal(obj, "fatal", ex);
            }
        }
    }
}
