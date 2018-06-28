using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//�����������
namespace DigiPower.Onlinecol.Standard.DAL
{
    /// <summary>
    /// ���ݷ�����T_WorkFlowBtn_DAL��
    /// </summary>
    public class T_WorkFlowBtn_DAL
    {
        public T_WorkFlowBtn_DAL()
        { }
        #region  ��Ա����

        /// <summary>
        /// �õ����ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("WorkFlowBtnID", "T_WorkFlowBtn");
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int WorkFlowBtnID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_WorkFlowBtn");
            strSql.Append(" where WorkFlowBtnID=@WorkFlowBtnID ");
            SqlParameter[] parameters = {
					new SqlParameter("@WorkFlowBtnID", SqlDbType.Int,8)};
            parameters[0].Value = WorkFlowBtnID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_WorkFlowBtn_MDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_WorkFlowBtn(");
            strSql.Append("WorkFlowID,BtnCode,BtnName,EnabledFlag)");
            strSql.Append(" values (");
            strSql.Append("@WorkFlowID,@BtnCode,@BtnName,@EnabledFlag)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@WorkFlowID", SqlDbType.Int,8),
					new SqlParameter("@BtnCode", SqlDbType.NVarChar,50),
					new SqlParameter("@BtnName", SqlDbType.NVarChar,50),
					new SqlParameter("@EnabledFlag", SqlDbType.Bit,1)};
            parameters[0].Value = model.WorkFlowID;
            parameters[1].Value = model.BtnCode;
            parameters[2].Value = model.BtnName;
            parameters[3].Value = model.EnabledFlag;

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
        public void Update(DigiPower.Onlinecol.Standard.Model.T_WorkFlowBtn_MDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_WorkFlowBtn set ");
            strSql.Append("WorkFlowID=@WorkFlowID,");
            strSql.Append("BtnCode=@BtnCode,");
            strSql.Append("BtnName=@BtnName,");
            strSql.Append("EnabledFlag=@EnabledFlag");
            strSql.Append(" where WorkFlowBtnID=@WorkFlowBtnID ");
            SqlParameter[] parameters = {
					new SqlParameter("@WorkFlowBtnID", SqlDbType.Int,8),
					new SqlParameter("@WorkFlowID", SqlDbType.Int,8),
					new SqlParameter("@BtnCode", SqlDbType.NVarChar,50),
					new SqlParameter("@BtnName", SqlDbType.NVarChar,50),
					new SqlParameter("@EnabledFlag", SqlDbType.Bit,1)};
            parameters[0].Value = model.WorkFlowBtnID;
            parameters[1].Value = model.WorkFlowID;
            parameters[2].Value = model.BtnCode;
            parameters[3].Value = model.BtnName;
            parameters[4].Value = model.EnabledFlag;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int WorkFlowBtnID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_WorkFlowBtn ");
            strSql.Append(" where WorkFlowBtnID=@WorkFlowBtnID ");
            SqlParameter[] parameters = {
					new SqlParameter("@WorkFlowBtnID", SqlDbType.Int,8)};
            parameters[0].Value = WorkFlowBtnID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_WorkFlowBtn_MDL GetModel(int WorkFlowBtnID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 WorkFlowBtnID,WorkFlowID,BtnCode,BtnName,EnabledFlag from T_WorkFlowBtn ");
            strSql.Append(" where WorkFlowBtnID=@WorkFlowBtnID ");
            SqlParameter[] parameters = {
					new SqlParameter("@WorkFlowBtnID", SqlDbType.Int,8)};
            parameters[0].Value = WorkFlowBtnID;

            DigiPower.Onlinecol.Standard.Model.T_WorkFlowBtn_MDL model = new DigiPower.Onlinecol.Standard.Model.T_WorkFlowBtn_MDL();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["WorkFlowBtnID"].ToString() != "")
                {
                    model.WorkFlowBtnID = int.Parse(ds.Tables[0].Rows[0]["WorkFlowBtnID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WorkFlowID"].ToString() != "")
                {
                    model.WorkFlowID = int.Parse(ds.Tables[0].Rows[0]["WorkFlowID"].ToString());
                }
                model.BtnCode = ds.Tables[0].Rows[0]["BtnCode"].ToString();
                model.BtnName = ds.Tables[0].Rows[0]["BtnName"].ToString();
                if (ds.Tables[0].Rows[0]["EnabledFlag"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["EnabledFlag"].ToString() == "1") || (ds.Tables[0].Rows[0]["EnabledFlag"].ToString().ToLower() == "true"))
                    {
                        model.EnabledFlag = true;
                    }
                    else
                    {
                        model.EnabledFlag = false;
                    }
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
            strSql.Append("select WorkFlowBtnID,WorkFlowID,BtnCode,BtnName,EnabledFlag ");
            strSql.Append(" FROM T_WorkFlowBtn ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
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
            strSql.Append(" WorkFlowBtnID,WorkFlowID,BtnCode,BtnName,EnabledFlag ");
            strSql.Append(" FROM T_WorkFlowBtn ");
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
            parameters[0].Value = "T_WorkFlowBtn";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  ��Ա����

        public void AddAndUpdate(DigiPower.Onlinecol.Standard.Model.T_WorkFlowBtn_MDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_WorkFlowBtn WHERE WorkFlowID=" + model.WorkFlowID + " AND BtnCode='" + model.BtnCode + "'");
            if (DbHelperSQL.Exists(strSql.ToString()))
            {
                Update(model);
            }
            else
            {
                Add(model);
            }
        }        
    }
}