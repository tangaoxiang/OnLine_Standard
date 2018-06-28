using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DigiPower.Onlinecol.Standard.DbUtility;//请先添加引用
namespace DigiPower.Onlinecol.Standard.DAL
{
    /// <summary>
    /// 数据访问类T_Module_DAL。
    /// </summary>
    public class T_Module_DAL
    {
        public T_Module_DAL()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ModuleID", "T_Module");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ModuleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_Module");
            strSql.Append(" where ModuleID=@ModuleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleID", SqlDbType.Int,8)};
            parameters[0].Value = ModuleID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_Module_MDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Module(");
            strSql.Append("ParentID,BH,ModuleName,PictureIndex,SelectedIndex,FileName,IfVisible,OrderIndex,Description,Del,RightListID,IfInsidePage)");
            strSql.Append(" values (");
            strSql.Append("@ParentID,@BH,@ModuleName,@PictureIndex,@SelectedIndex,@FileName,@IfVisible,@OrderIndex,@Description,@Del,@RightListID,@IfInsidePage)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ParentID", SqlDbType.Int,8),
					new SqlParameter("@BH", SqlDbType.NVarChar,20),
					new SqlParameter("@ModuleName", SqlDbType.NVarChar,50),
					new SqlParameter("@PictureIndex", SqlDbType.SmallInt,2),
					new SqlParameter("@SelectedIndex", SqlDbType.SmallInt,2),
					new SqlParameter("@FileName", SqlDbType.NVarChar,255),
					new SqlParameter("@IfVisible", SqlDbType.Bit,1),
					new SqlParameter("@OrderIndex", SqlDbType.SmallInt,2),
					new SqlParameter("@Description", SqlDbType.NVarChar,255),
					new SqlParameter("@Del", SqlDbType.Bit,1),
                    new SqlParameter("@RightListID", SqlDbType.NVarChar,500),
                    new SqlParameter("@IfInsidePage", SqlDbType.Bit,1)};

            parameters[0].Value = model.ParentID;
            parameters[1].Value = model.BH;
            parameters[2].Value = model.ModuleName;
            parameters[3].Value = model.PictureIndex;
            parameters[4].Value = model.SelectedIndex;
            parameters[5].Value = model.FileName;
            parameters[6].Value = model.IfVisible;
            parameters[7].Value = model.OrderIndex;
            parameters[8].Value = model.Description;
            parameters[9].Value = model.Del;
            parameters[10].Value = model.RightListID;
            parameters[11].Value = model.IfInsidePage;

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
        public void Update(DigiPower.Onlinecol.Standard.Model.T_Module_MDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Module set ");
            strSql.Append("ParentID=@ParentID,");
            strSql.Append("BH=@BH,");
            strSql.Append("ModuleName=@ModuleName,");
            strSql.Append("PictureIndex=@PictureIndex,");
            strSql.Append("SelectedIndex=@SelectedIndex,");
            strSql.Append("FileName=@FileName,");
            strSql.Append("IfVisible=@IfVisible,");
            strSql.Append("OrderIndex=@OrderIndex,");
            strSql.Append("Description=@Description,");
            strSql.Append("Del=@Del,");
            strSql.Append("RightListID=@RightListID, ");
            strSql.Append("IfInsidePage=@IfInsidePage ");

            strSql.Append(" where ModuleID=@ModuleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleID", SqlDbType.Int,8),
					new SqlParameter("@ParentID", SqlDbType.Int,8),
					new SqlParameter("@BH", SqlDbType.NVarChar,20),
					new SqlParameter("@ModuleName", SqlDbType.NVarChar,50),
					new SqlParameter("@PictureIndex", SqlDbType.SmallInt,2),
					new SqlParameter("@SelectedIndex", SqlDbType.SmallInt,2),
					new SqlParameter("@FileName", SqlDbType.NVarChar,255),
					new SqlParameter("@IfVisible", SqlDbType.Bit,1),
					new SqlParameter("@OrderIndex", SqlDbType.SmallInt,2),
					new SqlParameter("@Description", SqlDbType.NVarChar,255),
					new SqlParameter("@Del", SqlDbType.Bit,1),
                    new SqlParameter("@RightListID", SqlDbType.NVarChar,500),
                    new SqlParameter("@IfInsidePage", SqlDbType.Bit,1) };

            parameters[0].Value = model.ModuleID;
            parameters[1].Value = model.ParentID;
            parameters[2].Value = model.BH;
            parameters[3].Value = model.ModuleName;
            parameters[4].Value = model.PictureIndex;
            parameters[5].Value = model.SelectedIndex;
            parameters[6].Value = model.FileName;
            parameters[7].Value = model.IfVisible;
            parameters[8].Value = model.OrderIndex;
            parameters[9].Value = model.Description;
            parameters[10].Value = model.Del;
            parameters[11].Value = model.RightListID;
            parameters[12].Value = model.IfInsidePage;


            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ModuleID)
        {

            //StringBuilder strSql=new StringBuilder();
            //strSql.Append("delete from T_Module ");
            //strSql.Append(" where ModuleID=@ModuleID ");
            //SqlParameter[] parameters = {
            //        new SqlParameter("@ModuleID", SqlDbType.Int,8)};
            //parameters[0].Value = ModuleID;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE T_Module SET DEL=1 ");
            strSql.Append(" where ModuleID=@ModuleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleID", SqlDbType.Int,8)};
            parameters[0].Value = ModuleID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DigiPower.Onlinecol.Standard.Model.T_Module_MDL GetModel(int ModuleID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ModuleID,ParentID,BH,ModuleName,PictureIndex,SelectedIndex,FileName,IfVisible,OrderIndex,Description,Del,RightListID,IfInsidePage from T_Module ");
            strSql.Append(" where ModuleID=@ModuleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleID", SqlDbType.Int,8)};
            parameters[0].Value = ModuleID;

            DigiPower.Onlinecol.Standard.Model.T_Module_MDL model = new DigiPower.Onlinecol.Standard.Model.T_Module_MDL();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ModuleID"].ToString() != "")
                {
                    model.ModuleID = int.Parse(ds.Tables[0].Rows[0]["ModuleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                }
                model.BH = ds.Tables[0].Rows[0]["BH"].ToString();
                model.ModuleName = ds.Tables[0].Rows[0]["ModuleName"].ToString();
                if (ds.Tables[0].Rows[0]["PictureIndex"].ToString() != "")
                {
                    model.PictureIndex = int.Parse(ds.Tables[0].Rows[0]["PictureIndex"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SelectedIndex"].ToString() != "")
                {
                    model.SelectedIndex = int.Parse(ds.Tables[0].Rows[0]["SelectedIndex"].ToString());
                }
                model.FileName = ds.Tables[0].Rows[0]["FileName"].ToString();
                if (ds.Tables[0].Rows[0]["IfVisible"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IfVisible"].ToString() == "1") || (ds.Tables[0].Rows[0]["IfVisible"].ToString().ToLower() == "true"))
                    {
                        model.IfVisible = true;
                    }
                    else
                    {
                        model.IfVisible = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["OrderIndex"].ToString() != "")
                {
                    model.OrderIndex = int.Parse(ds.Tables[0].Rows[0]["OrderIndex"].ToString());
                }
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                if (ds.Tables[0].Rows[0]["Del"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Del"].ToString() == "1") || (ds.Tables[0].Rows[0]["Del"].ToString().ToLower() == "true"))
                    {
                        model.Del = true;
                    }
                    else
                    {
                        model.Del = false;
                    }
                }
                model.RightListID = ds.Tables[0].Rows[0]["RightListID"].ToString();

                if (ds.Tables[0].Rows[0]["Del"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IfInsidePage"].ToString() == "1") || (ds.Tables[0].Rows[0]["IfInsidePage"].ToString().ToLower() == "true"))
                    {
                        model.IfInsidePage = true;
                    }
                    else
                    {
                        model.IfInsidePage = false;
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ModuleID,ParentID,BH,ModuleName,PictureIndex,SelectedIndex,FileName,IfVisible,OrderIndex,Description,Del,RightListID,IfInsidePage ");
            strSql.Append(" FROM T_Module WHERE DEL=0 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" AND " + strWhere);
            }
            strSql.Append(" Order By OrderIndex");
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
            strSql.Append(" ModuleID,ParentID,BH,ModuleName,PictureIndex,SelectedIndex,FileName,IfVisible,OrderIndex,Description,Del,RightListID,IfInsidePage ");
            strSql.Append(" FROM T_Module WHERE DEL=0 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" AND " + strWhere);
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
            parameters[0].Value = "T_Module";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法

        public void GetListByRole(DataSet pDS, string ParentID, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();

            //只要有权限，就显示菜单。否则连菜单都不要显示。
            strSql.Append("select distinct a.* from T_Module a ,T_RoleRight b where a.ModuleID=b.ModelID and enabled=1 AND ParentID=" + ParentID);
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            strSql.Append(" AND DEL=0 ORDER BY ParentID,OrderIndex");
            DataSet ds1 = DbHelperSQL.Query(strSql.ToString());
            for (int i1 = 0; i1 < ds1.Tables[0].Rows.Count; i1++)
            {
                if (pDS.Tables.Count <= 0)
                {
                    pDS.Tables.Add(ds1.Tables[0].Copy());
                    pDS.Tables[0].Rows.Clear();
                }
                ds1.Tables[0].Rows[i1]["ModuleName"] = ds1.Tables[0].Rows[i1]["ModuleName"];
                pDS.Tables[0].Rows.Add(ds1.Tables[0].Rows[i1].ItemArray);

                GetListByRole(pDS, ds1.Tables[0].Rows[i1]["ModuleID"].ToString(), strWhere);
            }
        }

        public void DeleteNoUse(string ModuleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Module set IfVisible=0 where ModuleID=" + ModuleID);

            DbHelperSQL.Query(strSql.ToString());
        }

        public string GetModelNameListByURL(string URL)
        {
            string ModuleNameList = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  * from T_Module ");
            strSql.Append(" where DEL=0 AND FileName =  '" + URL + "'");
            DigiPower.Onlinecol.Standard.Model.T_Module_MDL model = new DigiPower.Onlinecol.Standard.Model.T_Module_MDL();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ParentID = int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                model.ModuleName = ds.Tables[0].Rows[0]["ModuleName"].ToString();

                if (ModuleNameList == "")
                {
                    ModuleNameList = model.ModuleName;
                }
                else
                {
                    ModuleNameList = model.ModuleName + " -> " + ModuleNameList;
                }
                GetModelByURL(ref ModuleNameList, model.ParentID.ToString());
            }

            return ModuleNameList;
        }

        public string GetModelIDByURL(string URL)
        {
            string ModuleID = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  * from T_Module ");
            strSql.Append(" where Del=0 AND FileName like '%" + URL + "%'");
            DigiPower.Onlinecol.Standard.Model.T_Module_MDL model = new DigiPower.Onlinecol.Standard.Model.T_Module_MDL();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ModuleID = ds.Tables[0].Rows[0]["ModuleID"].ToString();
            }

            return ModuleID;
        }

        private void GetModelByURL(ref string ModuleNameList, string ModuleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  * from T_Module ");
            strSql.Append(" where DEL=0 AND ModuleID= " + ModuleID + "");
            DigiPower.Onlinecol.Standard.Model.T_Module_MDL model = new DigiPower.Onlinecol.Standard.Model.T_Module_MDL();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ParentID = int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                model.ModuleName = ds.Tables[0].Rows[0]["ModuleName"].ToString();

                ModuleNameList = model.ModuleName + " -> " + ModuleNameList;
                GetModelByURL(ref ModuleNameList, model.ParentID.ToString());
            }
        }

        /// <summary>
        /// 返回模块列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetCustomModuleList()
        {
            string strSql = "SELECT p.modulename as ParentName,p.Moduleid as MModuleid, SubMenu.* FROM T_MODULE P, ";
            strSql += "(SELECT Moduleid,parentid,modulename,orderindex,RightListID from T_MODULE where ifvisible=1 and del=0) ";
            strSql += "SubMenu Where P.Moduleid=SubMenu.Parentid order by P.Orderindex,P.Moduleid,SubMenu.Orderindex ";

            return DbHelperSQL.Query(strSql).Tables[0];
        }
    }
}