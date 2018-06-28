using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

namespace DigiPower.Onlinecol.Standard.CBLL
{
    public class RoleManage
    {
        public RoleManage()
        { }

        /// <summary>
        /// 设置列表值
        /// </summary>
        /// <param name="DepartmentID"></param>
        //public string SetDrop(int DepartmentID)
        //{
        //    DigiPower.Onlinecol.Standard.BLL.UserOperate bll = new DigiPower.Onlinecol.Standard.BLL.UserOperate();

        //    //绑定区域
        //    DataSet ds = bll.GetDepartmentList("select DepartmentName from vwDepartmentInfo where DepartmentID =" + DepartmentID + "");

        //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {
        //        return ds.Tables[0].Rows[0][0].ToString();
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        ///// <summary>
        ///// 绑定部门列表
        ///// </summary>
        ///// <param name="drp"></param>
        ///// <param name="SqlWhere"></param>
        //public void BindDrop(DropDownList drp, string SqlWhere)
        //{
        //    DigiPower.Onlinecol.Standard.BLL.UserOperate bll = new DigiPower.Onlinecol.Standard.BLL.UserOperate();

        //    //绑定区域
        //    DataSet ds = bll.GetDepartmentList("select area_code,area_name from vwDepartmentInfo where "+ SqlWhere +" group by area_code,area_name");

        //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {
        //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //        {
        //            ListItem item = new ListItem();

        //            item.Text = ds.Tables[0].Rows[i]["area_name"].ToString();

        //            item.Value = ds.Tables[0].Rows[i]["area_code"].ToString();

        //            drp.Items.Add(item);

        //            //绑定单位
        //            this.BindCompany(drp, SqlWhere);
        //        }
        //    }
        //}

        ///// <summary>
        ///// 绑定单位
        ///// </summary>
        ///// <param name="drp"></param>
        ///// <param name="SqlWhere"></param>
        //private void BindCompany(DropDownList drp, string SqlWhere)
        //{
        //    DigiPower.Onlinecol.Standard.BLL.UserOperate bll = new DigiPower.Onlinecol.Standard.BLL.UserOperate();

        //    DataSet ds = bll.GetDepartmentList("select CompanyID,CompanyName from vwDepartmentInfo where " + SqlWhere + " group by CompanyID,CompanyName");

        //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {
        //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //        {
        //            ListItem item = new ListItem();

        //            item.Text = "　" + ds.Tables[0].Rows[i]["CompanyName"].ToString();

        //            item.Value = ds.Tables[0].Rows[i]["CompanyID"].ToString();

        //            drp.Items.Add(item);

        //            //绑定部门
        //            this.BindDepartment(drp, SqlWhere);
        //        }
        //    }
        //}

        ///// <summary>
        ///// 绑定部门
        ///// </summary>
        ///// <param name="drp"></param>
        ///// <param name="SqlWhere"></param>
        //private void BindDepartment(DropDownList drp, string SqlWhere)
        //{
        //    DigiPower.Onlinecol.Standard.BLL.UserOperate bll = new DigiPower.Onlinecol.Standard.BLL.UserOperate();

        //    DataSet ds = bll.GetDepartmentList("select DepartmentID,DepartmentName from vwDepartmentInfo where " + SqlWhere + " group by DepartmentID,DepartmentName");

        //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {
        //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //        {
        //            ListItem item = new ListItem();

        //            item.Text = "　" + ds.Tables[0].Rows[i]["DepartmentName"].ToString();

        //            item.Value = ds.Tables[0].Rows[i]["DepartmentID"].ToString();

        //            drp.Items.Add(item);
        //        }
        //    }
        //}
    }
}
