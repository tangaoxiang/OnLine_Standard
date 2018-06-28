using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;

namespace DigiPower.Onlinecol.Standard.CBLL
{
    public class FieldManage
    {
        public FieldManage()
        { }

        /// <summary>
        /// 设置列表值
        /// </summary>
        /// <param name="DepartmentID"></param>
        //public string SetDrop(string table_name)
        //{
        //    DigiPower.Onlinecol.Standard.BLL.UserOperate bll = new DigiPower.Onlinecol.Standard.BLL.UserOperate();

        //    //绑定区域
        //    DataSet ds = bll.GetDepartmentList("select table_chn_name from Table_Description where table_name =" + table_name + "");

        //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {
        //        return ds.Tables[0].Rows[0][0].ToString();
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        /// <summary>
        /// 绑定列表
        /// </summary>
        /// <param name="drp"></param>
        /// <param name="SqlWhere"></param>
        //public void BindDrop(DropDownList drp, string SqlWhere)
        //{
        //    DigiPower.Onlinecol.Standard.BLL.UserOperate bll = new DigiPower.Onlinecol.Standard.BLL.UserOperate();

        //    //绑定区域
        //    DataSet ds = bll.GetDepartmentList("select table_name,table_chn_name from Table_Description where " + SqlWhere + " group by table_name,table_chn_name");

        //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {
        //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //        {
        //            ListItem item = new ListItem();

        //            item.Text = ds.Tables[0].Rows[i]["table_chn_name"].ToString();

        //            item.Value = ds.Tables[0].Rows[i]["table_name"].ToString();

        //            drp.Items.Add(item);
        //        }
        //    }
        //}
    }
}
