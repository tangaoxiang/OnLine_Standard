using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL
{
    /// <summary>
    /// 数据访问类T_EFile_DAL。
    /// </summary>
    public class T_EFile_DAL
    {
        public T_EFile_DAL()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ArchiveListCellRptID", "T_EFile");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ArchiveListCellRptID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_EFile");
            strSql.Append(" where ArchiveListCellRptID=@ArchiveListCellRptID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ArchiveListCellRptID", SqlDbType.Int,8)};
            parameters[0].Value = ArchiveListCellRptID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_EFile_MDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_EFile(");
            strSql.Append("FileListID,DH,FileType,Status,Title,FilePath,PDFFilePath,PageCounts,Status_Text,CREATE_DT,CONVERT_FLAG,OrderIndex,RootPath)");
            strSql.Append(" values (");
            strSql.Append("@FileListID,@DH,@FileType,@Status,@Title,@FilePath,@PDFFilePath,@PageCounts,@Status_Text,@CREATE_DT,@CONVERT_FLAG,@OrderIndex,@RootPath)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@FileListID", SqlDbType.Int,8),
					new SqlParameter("@DH", SqlDbType.NVarChar,30),
					new SqlParameter("@FileType", SqlDbType.Int,8),
					new SqlParameter("@Status", SqlDbType.Int,8),
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@FilePath", SqlDbType.NVarChar,250),
					new SqlParameter("@PDFFilePath", SqlDbType.NVarChar,250),
					new SqlParameter("@PageCounts", SqlDbType.Int,8),
                    
                    new SqlParameter("@Status_Text", SqlDbType.NVarChar,20),
                    new SqlParameter("@CREATE_DT", SqlDbType.NVarChar,20),
                    new SqlParameter("@CONVERT_FLAG", SqlDbType.Bit,1),                    

					new SqlParameter("@OrderIndex", SqlDbType.Int,8),
                    new SqlParameter("@RootPath", SqlDbType.VarChar,100)
                                        };
            parameters[0].Value = model.FileListID;
            parameters[1].Value = model.DH;
            parameters[2].Value = model.FileType;
            parameters[3].Value = model.Status;
            parameters[4].Value = model.Title;
            parameters[5].Value = model.FilePath;
            parameters[6].Value = model.PDFFilePath;
            parameters[7].Value = model.PageCounts;
            parameters[8].Value = model.Status_Text;
            parameters[9].Value = model.CREATE_DT;
            parameters[10].Value = model.CONVERT_FLAG;
            parameters[11].Value = model.OrderIndex;
            parameters[12].Value = model.RootPath;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(DigiPower.Onlinecol.Standard.Model.T_EFile_MDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_EFile set ");
            strSql.Append("FileListID=@FileListID,");
            strSql.Append("DH=@DH,");
            strSql.Append("FileType=@FileType,");
            strSql.Append("Status=@Status,");
            strSql.Append("Title=@Title,");
            strSql.Append("FilePath=@FilePath,");
            strSql.Append("PDFFilePath=@PDFFilePath,");
            strSql.Append("PageCounts=@PageCounts,");
            strSql.Append("OrderIndex=@OrderIndex,");
            strSql.Append("RootPath=@RootPath");
            strSql.Append(" where ArchiveListCellRptID=@ArchiveListCellRptID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ArchiveListCellRptID", SqlDbType.Int,8),
					new SqlParameter("@FileListID", SqlDbType.Int,8),
					new SqlParameter("@DH", SqlDbType.NVarChar,30),
					new SqlParameter("@FileType", SqlDbType.Int,8),
					new SqlParameter("@Status", SqlDbType.Int,8),
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@FilePath", SqlDbType.NVarChar,250),
					new SqlParameter("@PDFFilePath", SqlDbType.NVarChar,250),
					new SqlParameter("@PageCounts", SqlDbType.Int,8),
					new SqlParameter("@OrderIndex", SqlDbType.Int,8),
                    new SqlParameter("@RootPath", SqlDbType.VarChar,100)};
            parameters[0].Value = model.ArchiveListCellRptID;
            parameters[1].Value = model.FileListID;
            parameters[2].Value = model.DH;
            parameters[3].Value = model.FileType;
            parameters[4].Value = model.Status;
            parameters[5].Value = model.Title;
            parameters[6].Value = model.FilePath;
            parameters[7].Value = model.PDFFilePath;
            parameters[8].Value = model.PageCounts;
            parameters[9].Value = model.OrderIndex;
            parameters[10].Value = model.RootPath;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ArchiveListCellRptID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_EFile ");
            strSql.Append(" where ArchiveListCellRptID=@ArchiveListCellRptID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ArchiveListCellRptID", SqlDbType.Int,8)};
            parameters[0].Value = ArchiveListCellRptID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_EFile_MDL GetModel(int ArchiveListCellRptID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ArchiveListCellRptID,FileListID,DH,FileType,Status,Title,FilePath,PDFFilePath,PageCounts,OrderIndex,RootPath from T_EFile ");
            strSql.Append(" where ArchiveListCellRptID=@ArchiveListCellRptID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ArchiveListCellRptID", SqlDbType.Int,8)};
            parameters[0].Value = ArchiveListCellRptID;

            DigiPower.Onlinecol.Standard.Model.T_EFile_MDL model = new DigiPower.Onlinecol.Standard.Model.T_EFile_MDL();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ArchiveListCellRptID"].ToString() != "")
                {
                    model.ArchiveListCellRptID = int.Parse(ds.Tables[0].Rows[0]["ArchiveListCellRptID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FileListID"].ToString() != "")
                {
                    model.FileListID = int.Parse(ds.Tables[0].Rows[0]["FileListID"].ToString());
                }
                model.DH = ds.Tables[0].Rows[0]["DH"].ToString();
                if (ds.Tables[0].Rows[0]["FileType"].ToString() != "")
                {
                    model.FileType = int.Parse(ds.Tables[0].Rows[0]["FileType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.FilePath = ds.Tables[0].Rows[0]["FilePath"].ToString();
                model.PDFFilePath = ds.Tables[0].Rows[0]["PDFFilePath"].ToString();
                if (ds.Tables[0].Rows[0]["PageCounts"].ToString() != "")
                {
                    model.PageCounts = int.Parse(ds.Tables[0].Rows[0]["PageCounts"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderIndex"].ToString() != "")
                {
                    model.OrderIndex = int.Parse(ds.Tables[0].Rows[0]["OrderIndex"].ToString());
                }
                model.RootPath = ds.Tables[0].Rows[0]["RootPath"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM T_EFile ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (!strWhere.ToLower().Contains("order"))
            {
                strSql.Append(" ORDER BY OrderIndex,ArchiveListCellRptID");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ArchiveListCellRptID,FileListID,DH,FileType,Status,Title,FilePath,PDFFilePath,PageCounts,OrderIndex,RootPath ");
            strSql.Append(" FROM T_EFile ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "T_EFile";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法


        /// <summary>
        /// 获得数据列表 分页
        /// </summary>
        /// <returns></returns>
        public DataTable GetList(string strWhere, int PageSize, int curPage, string PRIMARYKey, string OrderByName, out int recCoun)
        {
            StringBuilder strSql = new StringBuilder();
     
            strSql.Append("select * FROM T_EFile ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return PageCtrl.QueryForDataTableSqlServer(strSql.ToString(), PageSize, curPage, PRIMARYKey, OrderByName, out recCoun).Tables[0];
        }

        /// <summary>
        /// 得到最大文件序号
        /// </summary>
        public object GetEfileMaxOrderIndex(string filelistID)
        {
            return DbHelperSQL.GetSingle("select max(orderindex) from T_EFile where filelistid=" + filelistID + "");
        }
    }
}

