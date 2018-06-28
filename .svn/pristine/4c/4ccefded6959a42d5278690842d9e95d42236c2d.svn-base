using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用

namespace DigiPower.Onlinecol.Standard.DAL
{
    public class T_SingleProject_PIC_DAL
    {
        public T_SingleProject_PIC_DAL()
        { }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_SingleProject_PIC_MDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_SingleProject_PIC(");
            strSql.Append("PROJ_SID,PIC_TITLE,PIC_PATH,CREATE_DT,ORDER_INDEX)");
            strSql.Append(" values (");
            strSql.Append("@PROJ_SID,@PIC_TITLE,@PIC_PATH,@CREATE_DT,@ORDER_INDEX)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@PROJ_SID", SqlDbType.Int ,40),
                    new SqlParameter("@PIC_TITLE", SqlDbType.VarChar,250),
                    new SqlParameter("@PIC_PATH", SqlDbType.VarChar,500),
                    new SqlParameter("@CREATE_DT", SqlDbType.DateTime),
                    new SqlParameter("@ORDER_INDEX", SqlDbType.Int ,40)};

            parameters[0].Value = model.PROJ_SID;
            parameters[1].Value = model.PIC_TITLE;
            parameters[2].Value = model.PIC_PATH;
            parameters[3].Value = model.CREATE_DT;
            parameters[4].Value = model.ORDER_INDEX;

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
        /// 根据单位取工程信息
        /// </summary>
        /// <param name="projectid"></param>
        /// <returns></returns>
        public DataSet GetListByProjectidId(int projectid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select  sid ,proj_sid,pic_title,pic_path,order_index ,CONVERT(varchar(12) , create_dt, 111 ) create_dt from dbo.T_SingleProject_PIC   ");
            if (projectid > 0)
            {
                strSql.Append(" where  proj_sid=" + projectid);
            }

            strSql.Append(" Order By sid asc");

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int SingleProjectID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_SingleProject_PIC ");
            strSql.Append(" where sid=@sid ");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,8)};
            parameters[0].Value = SingleProjectID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Update(int SingleProjectID, string PIC_TITLEs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_SingleProject_PIC set ");
            strSql.Append("PIC_TITLE=@PIC_TITLEs ");


            strSql.Append(" where sid=@sids ");
            SqlParameter[] parameters = {
                                            new SqlParameter("@PIC_TITLEs", SqlDbType.VarChar,250),
					new SqlParameter("@sids", SqlDbType.Int,8)};


            parameters[0].Value = PIC_TITLEs;
            parameters[1].Value = SingleProjectID;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public DataSet GetListBysId(int sid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from  dbo.T_SingleProject_PIC ");
            if (sid > 0)
            {
                strSql.Append(" where  sid=" + sid);
            }

            strSql.Append(" Order By sid asc");

            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
