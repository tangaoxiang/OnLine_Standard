using System;
using System.Configuration;
namespace DigiPower.Onlinecol.Standard.DbUtility
{
    
    public class PubConstant
    {        
        /// <summary>
        /// ��ȡ�����ַ���
        /// </summary>
        public static string ConnectionString
        {           
            get 
            {
                string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                
                //string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
                //if (ConStringEncrypt == "true")
                //{
                //    _connectionString = DESEncrypt.Decrypt(_connectionString);
                //}
                return _connectionString; 
            }
        }

        //public static string ConnectionString2
        //{
        //    get
        //    {
        //        string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;

        //        //string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
        //        //if (ConStringEncrypt == "true")
        //        //{
        //        //    _connectionString = DESEncrypt.Decrypt(_connectionString);
        //        //}
        //        return _connectionString;
        //    }
        //}

        ///// <summary>
        ///// �õ�web.config������������ݿ������ַ�����
        ///// </summary>
        ///// <param name="configName"></param>
        ///// <returns></returns>
        //public static string GetConnectionString(string configName)
        //{
        //    string connectionString = ConfigurationManager.AppSettings[configName];
        //    string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
        //    if (ConStringEncrypt == "true")
        //    {
        //        connectionString = DESEncrypt.Decrypt(connectionString);
        //    }
        //    return connectionString;
        //}


    }
}
