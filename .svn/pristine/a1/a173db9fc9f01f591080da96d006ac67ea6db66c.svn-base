using System;
using System.Data;
using System.Text;
using System.Collections.Generic;

using System.Data.Common;

using DigiPower.Onlinecol.Standard.DbUtility;
using System.Data.SqlClient;
using System.Text.RegularExpressions;//请先添加引用

namespace DigiPower.Onlinecol.Standard.DAL
{
    public class PageCtrl
    {

        /// <summary>
        /// 返回数据根PageSize
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="PageSize">每页页数</param>
        /// <param name="curPage">当前页数</param>
        /// <param name="PRIMARYKey">主键</param>
        /// <param name="OrderByName">排序字段</param>
        /// <param name="recCount">总记录数</param>
        /// <returns></returns>
        public static DataSet QueryForDataTableSqlServer(string sql, int PageSize, int curPage, string PRIMARYKey, string OrderByName, out int recCount)
        {
            string strCount = "select count(*) from (" + sql + ") as temp_1";
            DataSet ds = new DataSet();
            try
            {
                recCount = Convert.ToInt32(DbHelperSQL.GetSingle(strCount));

                string strSql = "";

                int num = 0;
                string str = (Convert.ToDouble(recCount) / Convert.ToDouble(PageSize)).ToString();
                if (str.IndexOf(".") < 0)
                {
                    num = Convert.ToInt32(str);
                }
                else
                {
                    string[] strArray = Regex.Split(str, @"\.", RegexOptions.IgnoreCase);
                    if (!string.IsNullOrEmpty(strArray[1].ToString()))
                    {
                        num = Convert.ToInt32(strArray[0]) + 1;
                    }
                }
                if (num < curPage)
                    curPage = num;
                int End = PageSize * (curPage - 1);

                if (curPage == 1 || curPage == 0)
                {
                    strSql = " Select Top " + PageSize + " * from (" + sql + ") as temp_1 order by " + OrderByName;
                }
                else
                {
                    strSql = " Select Top " + PageSize + " * from (" + sql + ") as temp_1 where " + PRIMARYKey
                        + " not in (select top " + End + " " + PRIMARYKey + " from (" + sql + ") as temp_2 order by " + OrderByName + ") order by " + OrderByName;
                }

                ds = DbHelperSQL.Query(strSql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public PageCtrl()
        { }

        public DataSet GetPage(string TableName, string FieldList, string PrimaryKey, string Sqlwhere, string Order, int index, int PageSize, ref int TotalCount, ref int TotalPageCount)
        {
            SqlParameter[] arrPara = new SqlParameter[11];
            arrPara[0] = new SqlParameter("@TableName", System.Data.SqlDbType.VarChar, 200);
            arrPara[0].Value = TableName;
            arrPara[1] = new SqlParameter("@FieldList", System.Data.SqlDbType.VarChar, 2000);
            arrPara[1].Value = FieldList;
            arrPara[2] = new SqlParameter("@PrimaryKey", System.Data.SqlDbType.VarChar, 100);
            arrPara[2].Value = PrimaryKey;
            arrPara[3] = new SqlParameter("@Where", System.Data.SqlDbType.VarChar, 2000);
            arrPara[3].Value = Sqlwhere;
            arrPara[4] = new SqlParameter("@Order", System.Data.SqlDbType.VarChar, 100);
            arrPara[4].Value = Order;
            arrPara[5] = new SqlParameter("@SortType", System.Data.SqlDbType.Int, 4);
            arrPara[5].Value = 1;
            arrPara[6] = new SqlParameter("@RecorderCount", System.Data.SqlDbType.Int, 4);
            arrPara[6].Value = 0;
            arrPara[7] = new SqlParameter("@PageSize", System.Data.SqlDbType.Int, 4);
            arrPara[7].Value = PageSize;
            arrPara[8] = new SqlParameter("@PageIndex", System.Data.SqlDbType.Int, 4);
            arrPara[8].Value = index;
            arrPara[9] = new SqlParameter("@TotalCount", System.Data.SqlDbType.Int, 4);
            arrPara[9].Direction = ParameterDirection.Output;
            arrPara[10] = new SqlParameter("@TotalPageCount", System.Data.SqlDbType.Int, 4);
            arrPara[10].Direction = ParameterDirection.Output;

            DataSet ds = DbHelperSQL.RunProcedure("PageCount", arrPara, "ds");

            if (ds != null && ds.Tables.Count > 1)
            {
                TotalCount = Convert.ToInt32(ds.Tables[1].Rows[0]["TotalCount"]);

                TotalPageCount = Convert.ToInt32(ds.Tables[1].Rows[0]["TotalPageCount"]);

                return ds;
            }

            return null;
        }
    }
}
