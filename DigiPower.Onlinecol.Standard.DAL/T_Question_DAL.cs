using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL
{
    /// <summary>
    /// 数据访问类T_Question_DAL。
    /// </summary>
    public class T_Question_DAL
    {
        public T_Question_DAL()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("QuestionID", "T_Question");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int QuestionID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_Question");
            strSql.Append(" where QuestionID=@QuestionID ");
            SqlParameter[] parameters = {
					new SqlParameter("@QuestionID", SqlDbType.Int,8)};
            parameters[0].Value = QuestionID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_Question_MDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Question(");
            strSql.Append("SingleProjectID,QuestionTypeCode,FileListID,Title,Description,CreateUserID,CreateUserName,CreateDate,AnswerCount,ClickCount,AttachName,AttachPath,ReadFlag,DescriptionHtml)");
            strSql.Append(" values (");
            strSql.Append("@SingleProjectID,@QuestionTypeCode,@FileListID,@Title,@Description,@CreateUserID,@CreateUserName,@CreateDate,@AnswerCount,@ClickCount,@AttachName,@AttachPath,@ReadFlag,@DescriptionHtml)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@SingleProjectID", SqlDbType.Int,8),
					new SqlParameter("@QuestionTypeCode", SqlDbType.NVarChar,100),
					new SqlParameter("@FileListID", SqlDbType.Int,8),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@Description", SqlDbType.NVarChar,4000),
					new SqlParameter("@CreateUserID", SqlDbType.Int,8),
					new SqlParameter("@CreateUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@AnswerCount", SqlDbType.Int,8),
					new SqlParameter("@ClickCount", SqlDbType.Int,8),
					new SqlParameter("@AttachName", SqlDbType.NVarChar,250),
					new SqlParameter("@AttachPath", SqlDbType.NVarChar,250),
					new SqlParameter("@ReadFlag", SqlDbType.Bit,1),
                    new SqlParameter("@DescriptionHtml", SqlDbType.NVarChar,4000)};
            parameters[0].Value = model.SingleProjectID;
            parameters[1].Value = model.QuestionTypeCode;
            parameters[2].Value = model.FileListID;
            parameters[3].Value = model.Title;
            parameters[4].Value = model.Description;
            parameters[5].Value = model.CreateUserID;
            parameters[6].Value = model.CreateUserName;
            parameters[7].Value = model.CreateDate;
            parameters[8].Value = model.AnswerCount;
            parameters[9].Value = model.ClickCount;
            parameters[10].Value = model.AttachName;
            parameters[11].Value = model.AttachPath;
            parameters[12].Value = model.ReadFlag;
            parameters[13].Value = model.DescriptionHtml;
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
        public void Update(DigiPower.Onlinecol.Standard.Model.T_Question_MDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Question set ");
            strSql.Append("SingleProjectID=@SingleProjectID,");
            strSql.Append("QuestionTypeCode=@QuestionTypeCode,");
            strSql.Append("FileListID=@FileListID,");
            strSql.Append("Title=@Title,");
            strSql.Append("Description=@Description,");
            strSql.Append("CreateUserID=@CreateUserID,");
            strSql.Append("CreateUserName=@CreateUserName,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("AnswerCount=@AnswerCount,");
            strSql.Append("ClickCount=@ClickCount,");
            strSql.Append("AttachName=@AttachName,");
            strSql.Append("AttachPath=@AttachPath,");
            strSql.Append("ReadFlag=@ReadFlag,");
            strSql.Append("DescriptionHtml=@DescriptionHtml");
            
            strSql.Append(" where QuestionID=@QuestionID ");
            SqlParameter[] parameters = {
					new SqlParameter("@QuestionID", SqlDbType.Int,8),
					new SqlParameter("@SingleProjectID", SqlDbType.Int,8),
					new SqlParameter("@QuestionTypeCode", SqlDbType.NVarChar,100),
					new SqlParameter("@FileListID", SqlDbType.Int,8),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@Description", SqlDbType.NVarChar,4000),
					new SqlParameter("@CreateUserID", SqlDbType.Int,8),
					new SqlParameter("@CreateUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@AnswerCount", SqlDbType.Int,8),
					new SqlParameter("@ClickCount", SqlDbType.Int,8),
					new SqlParameter("@AttachName", SqlDbType.NVarChar,250),
					new SqlParameter("@AttachPath", SqlDbType.NVarChar,250),
					new SqlParameter("@ReadFlag", SqlDbType.Bit,1),
                    new SqlParameter("@DescriptionHtml", SqlDbType.NVarChar,4000)};
            parameters[0].Value = model.QuestionID;
            parameters[1].Value = model.SingleProjectID;
            parameters[2].Value = model.QuestionTypeCode;
            parameters[3].Value = model.FileListID;
            parameters[4].Value = model.Title;
            parameters[5].Value = model.Description;
            parameters[6].Value = model.CreateUserID;
            parameters[7].Value = model.CreateUserName;
            parameters[8].Value = model.CreateDate;
            parameters[9].Value = model.AnswerCount;
            parameters[10].Value = model.ClickCount;
            parameters[11].Value = model.AttachName;
            parameters[12].Value = model.AttachPath;
            parameters[13].Value = model.ReadFlag;
            parameters[14].Value = model.DescriptionHtml;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int QuestionID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Question ");
            strSql.Append(" where QuestionID=@QuestionID ");
            SqlParameter[] parameters = {
					new SqlParameter("@QuestionID", SqlDbType.Int,8)};
            parameters[0].Value = QuestionID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_Question_MDL GetModel(int QuestionID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 QuestionID,SingleProjectID,QuestionTypeCode,FileListID,Title,Description,CreateUserID,CreateUserName,CreateDate,AnswerCount,ClickCount,AttachName,AttachPath,ReadFlag,DescriptionHtml from T_Question ");
            strSql.Append(" where QuestionID=@QuestionID ");
            SqlParameter[] parameters = {
					new SqlParameter("@QuestionID", SqlDbType.Int,8)};
            parameters[0].Value = QuestionID;

            DigiPower.Onlinecol.Standard.Model.T_Question_MDL model = new DigiPower.Onlinecol.Standard.Model.T_Question_MDL();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["QuestionID"].ToString() != "")
                {
                    model.QuestionID = int.Parse(ds.Tables[0].Rows[0]["QuestionID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SingleProjectID"].ToString() != "")
                {
                    model.SingleProjectID = int.Parse(ds.Tables[0].Rows[0]["SingleProjectID"].ToString());
                }
 
                if (ds.Tables[0].Rows[0]["FileListID"].ToString() != "")
                {
                    model.FileListID = int.Parse(ds.Tables[0].Rows[0]["FileListID"].ToString());
                }
                model.QuestionTypeCode = ds.Tables[0].Rows[0]["QuestionTypeCode"].ToString();
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                if (ds.Tables[0].Rows[0]["CreateUserID"].ToString() != "")
                {
                    model.CreateUserID = int.Parse(ds.Tables[0].Rows[0]["CreateUserID"].ToString());
                }
                model.CreateUserName = ds.Tables[0].Rows[0]["CreateUserName"].ToString();
                if (ds.Tables[0].Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AnswerCount"].ToString() != "")
                {
                    model.AnswerCount = int.Parse(ds.Tables[0].Rows[0]["AnswerCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ClickCount"].ToString() != "")
                {
                    model.ClickCount = int.Parse(ds.Tables[0].Rows[0]["ClickCount"].ToString());
                }
                model.AttachName = ds.Tables[0].Rows[0]["AttachName"].ToString();
                model.AttachPath = ds.Tables[0].Rows[0]["AttachPath"].ToString();
                if (ds.Tables[0].Rows[0]["ReadFlag"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["ReadFlag"].ToString() == "1") || (ds.Tables[0].Rows[0]["ReadFlag"].ToString().ToLower() == "true"))
                    {
                        model.ReadFlag = true;
                    }
                    else
                    {
                        model.ReadFlag = false;
                    }
                }

                model.DescriptionHtml = ds.Tables[0].Rows[0]["DescriptionHtml"].ToString();
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
            strSql.Append("select QuestionID,SingleProjectID,QuestionTypeCode,FileListID,Title,Description,CreateUserID,CreateUserName,CreateDate,AnswerCount,ClickCount,AttachName,AttachPath,ReadFlag,DescriptionHtml  ");
            strSql.Append(" FROM T_Question ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            strSql.Append(" QuestionID,SingleProjectID,QuestionTypeCode,FileListID,Title,Description,CreateUserID,CreateUserName,CreateDate,AnswerCount,ClickCount,AttachName,AttachPath,ReadFlag,DescriptionHtml  ");
            strSql.Append(" FROM T_Question ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
 

        #endregion  成员方法

      

        public DataTable GetQuestionList(string strWhere, int PageSize, int curPage, string PRIMARYKey, string OrderByName, out int recCoun)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *,(select  f.SystemInfoName from T_SystemInfo f WHERE f.CurrentType='QuestionType' AND LOWER(f.SystemInfoCode)=t_question.QuestionTypeCode )as QuestionTypeTitle from t_question ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            return PageCtrl.QueryForDataTableSqlServer(strSql.ToString(), PageSize, curPage, PRIMARYKey, OrderByName, out recCoun).Tables[0];

        }
         
    }
}