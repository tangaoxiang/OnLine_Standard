using System;
using System.Configuration;
namespace DigiPower.Onlinecol.Distribution.Service {

    public class PubConstant {
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionString {
            get {
                string _connectionString = ConfigurationManager.AppSettings["ConnectionString"];
                string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
                if (ConStringEncrypt == "true") {
                    _connectionString = DESEncrypt.Decrypt(_connectionString);
                }
                return _connectionString;
            }
        }
 
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionStringOra {
            get {
                string _connectionString = ConfigurationManager.AppSettings["ConnectionString_ORA"];
                string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
                if (ConStringEncrypt == "true") {
                    _connectionString = DESEncrypt.Decrypt(_connectionString);
                }
                return _connectionString;
            }
        }

        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionStringSql {
            get {
                string _connectionString = ConfigurationManager.AppSettings["ConnectionString_SQL"];
                string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
                if (ConStringEncrypt == "true") {
                    _connectionString = DESEncrypt.Decrypt(_connectionString);
                }
                return _connectionString;
            }
        }

        /// <summary>
        /// 得到web.config里配置项的数据库连接字符串。
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string configName) {
            string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //string connectionString = ConfigurationManager.AppSettings[configName];
            //string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
            //if (ConStringEncrypt == "true")
            //{
            //    connectionString = DESEncrypt.Decrypt(connectionString);
            //}
            //return connectionString;
            return _connectionString;
        }
    }
}
