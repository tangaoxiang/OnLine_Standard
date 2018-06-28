using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//�����������
namespace DigiPower.Onlinecol.Standard.DAL
{
    /// <summary>
    /// ���ݷ�����T_QuestionType_DAL��
    /// </summary>
    public class T_QuestionType_DAL
    {
        public T_QuestionType_DAL()
        { }
        #region  ��Ա����

        /// <summary>
        /// �õ����ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("QuestionTypeID", "T_QuestionType");
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int QuestionTypeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_QuestionType");
            strSql.Append(" where QuestionTypeID=@QuestionTypeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@QuestionTypeID", SqlDbType.Int,8)};
            parameters[0].Value = QuestionTypeID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_QuestionType_MDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_QuestionType(");
            strSql.Append("Title,ToUserIDList,ToUserNameList,OnlyToMyDirectionUser,OrderIndex)");
            strSql.Append(" values (");
            strSql.Append("@Title,@ToUserIDList,@ToUserNameList,@OnlyToMyDirectionUser,@OrderIndex)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@ToUserIDList", SqlDbType.NVarChar,200),
					new SqlParameter("@ToUserNameList", SqlDbType.NVarChar,1000),
					new SqlParameter("@OnlyToMyDirectionUser", SqlDbType.Bit,1),
                    new SqlParameter("@OrderIndex", SqlDbType.Int,8)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.ToUserIDList;
            parameters[2].Value = model.ToUserNameList;
            parameters[3].Value = model.OnlyToMyDirectionUser;
            parameters[4].Value = model.OrderIndex;

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
        /// ����һ������
        /// </summary>
        public void Update(DigiPower.Onlinecol.Standard.Model.T_QuestionType_MDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_QuestionType set ");
            strSql.Append("Title=@Title,");
            strSql.Append("ToUserIDList=@ToUserIDList,");
            strSql.Append("ToUserNameList=@ToUserNameList,");
            strSql.Append("OnlyToMyDirectionUser=@OnlyToMyDirectionUser,");
            strSql.Append("OrderIndex=@OrderIndex ");
            strSql.Append(" where QuestionTypeID=@QuestionTypeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@QuestionTypeID", SqlDbType.Int,8),
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@ToUserIDList", SqlDbType.NVarChar,200),
					new SqlParameter("@ToUserNameList", SqlDbType.NVarChar,1000),
					new SqlParameter("@OnlyToMyDirectionUser", SqlDbType.Bit,1),
                    new SqlParameter("@OrderIndex", SqlDbType.Int,8) };

            parameters[0].Value = model.QuestionTypeID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.ToUserIDList;
            parameters[3].Value = model.ToUserNameList;
            parameters[4].Value = model.OnlyToMyDirectionUser;
            parameters[5].Value = model.OrderIndex;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int QuestionTypeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_QuestionType ");
            strSql.Append(" where QuestionTypeID=@QuestionTypeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@QuestionTypeID", SqlDbType.Int,8)};
            parameters[0].Value = QuestionTypeID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_QuestionType_MDL GetModel(int QuestionTypeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 QuestionTypeID,Title,ToUserIDList,ToUserNameList,OnlyToMyDirectionUser,OrderIndex from T_QuestionType ");
            strSql.Append(" where QuestionTypeID=@QuestionTypeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@QuestionTypeID", SqlDbType.Int,8)};
            parameters[0].Value = QuestionTypeID;

            DigiPower.Onlinecol.Standard.Model.T_QuestionType_MDL model = new DigiPower.Onlinecol.Standard.Model.T_QuestionType_MDL();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["QuestionTypeID"].ToString() != "")
                {
                    model.QuestionTypeID = int.Parse(ds.Tables[0].Rows[0]["QuestionTypeID"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.ToUserIDList = ds.Tables[0].Rows[0]["ToUserIDList"].ToString();
                model.ToUserNameList = ds.Tables[0].Rows[0]["ToUserNameList"].ToString();
                if (ds.Tables[0].Rows[0]["OnlyToMyDirectionUser"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["OnlyToMyDirectionUser"].ToString() == "1") || (ds.Tables[0].Rows[0]["OnlyToMyDirectionUser"].ToString().ToLower() == "true"))
                    {
                        model.OnlyToMyDirectionUser = true;
                    }
                    else
                    {
                        model.OnlyToMyDirectionUser = false;
                    }
                }

                if (ds.Tables[0].Rows[0]["OrderIndex"].ToString() != "")
                {
                    model.OrderIndex = int.Parse(ds.Tables[0].Rows[0]["OrderIndex"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select QuestionTypeID,Title,ToUserIDList,ToUserNameList,OnlyToMyDirectionUser,OrderIndex ");
            strSql.Append(" FROM T_QuestionType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by  OrderIndex ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// ��������б� ��ҳ
        /// </summary>
        /// <returns></returns>
        public DataTable GetList(string strWhere, int PageSize, int curPage, string PRIMARYKey, string OrderByName, out int recCoun)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select QuestionTypeID,Title,ToUserIDList,ToUserNameList,OnlyToMyDirectionUser,OrderIndex ");
            strSql.Append(" FROM T_QuestionType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return PageCtrl.QueryForDataTableSqlServer(strSql.ToString(), PageSize, curPage, PRIMARYKey, OrderByName, out recCoun).Tables[0];
        }


        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" QuestionTypeID,Title,ToUserIDList,ToUserNameList,OnlyToMyDirectionUser,OrderIndex ");
            strSql.Append(" FROM T_QuestionType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// ��ҳ��ȡ�����б�
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
            parameters[0].Value = "T_QuestionType";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  ��Ա����
    }
}

