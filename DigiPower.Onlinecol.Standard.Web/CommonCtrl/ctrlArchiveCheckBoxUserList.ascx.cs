using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.Model;
using System.Collections.Generic;


namespace DigiPower.Onlinecol.Standard.Web.CommonCtrl
{
    /// <summary>
    /// 档案员列表
    /// </summary>
    public partial class ctrlArchiveCheckBoxUserList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 绑定所有的档案员
        /// </summary>
        /// <param name="isSelectAll">是否全选</param>
        public void DataBindEx(bool isSelectAll)
        {
            T_CompanyArchiveUser_BLL bll = new T_CompanyArchiveUser_BLL();
            string strWhere = " 1=1 AND REGFLAG=1 ";
            if (Common.ConvertEx.ToBool(Common.Session.GetSession("SuperAdmin")) == true || Common.ConvertEx.ToBool(Common.Session.GetSession("IsCompany")) == false)
            { //管理员所有

            }
            else
            {//其他人只能看到自己所属公司
                strWhere += " AND COMPANYID=" + Common.Session.GetSession("CompanyId"); ;
            }


            DataSet ds = bll.GetList(strWhere);
            chk_ArchiveUserList.DataSource = ds;
            chk_ArchiveUserList.DataTextField = "USERNAME";
            chk_ArchiveUserList.DataValueField = "COMPANYARCHIVEUSERID";
            chk_ArchiveUserList.DataBind();

            if (isSelectAll)
            {
                ListItem item = new ListItem("全部档案员", "0");
                item.Attributes.Add("onclick", "SelectAll(this)");
                chk_ArchiveUserList.Items.Insert(0, item);
            }
        }

        /// <summary>
        /// 绑定培训计划下的所有档案员
        /// </summary>
        /// <param name="TrainPlanID">培训计划ID</param>
        /// <param name="isSelectAll">是否全选</param>
        /// <param name="firstSelectAll">第一次是否默认选中</param>
        public void DataBindEx(int TrainPlanID, bool isSelectAll, bool firstSelectAll)
        {
            T_Other_BLL bll = new T_Other_BLL();
            DataSet ds = bll.GetTrainPlanToArchiveUser(TrainPlanID);
            if (ds != null && ds.Tables.Count > 0)
            {
                chk_ArchiveUserList.DataSource = ds;
                chk_ArchiveUserList.DataTextField = "UserName";
                chk_ArchiveUserList.DataValueField = "COMPANYARCHIVEUSERID";
                chk_ArchiveUserList.DataBind();

                if (isSelectAll)
                {
                    ListItem item = new ListItem("全部档案员", "0");
                    item.Attributes.Add("onclick", "SelectAll(this)");
                    chk_ArchiveUserList.Items.Insert(0, item);
                }

                if (firstSelectAll)
                {
                    foreach (ListItem item in chk_ArchiveUserList.Items)
                    {
                        item.Selected = true;
                    }
                }
            }
        }

        /// <summary>
        /// 选中档案员
        /// </summary>
        /// <param name="ltKey">要选中的档案员ID</param>
        public void SetItemSelected(List<string> ltKey)
        {
            foreach (ListItem item in chk_ArchiveUserList.Items)
            {
                if (ltKey.Contains(item.Value))
                {
                    item.Selected = true;
                }
            }
        }

        /// <summary>
        /// 返回选中的档案员
        /// </summary>
        /// <returns></returns>
        public List<string> GetSelectList()
        {
            List<string> ltKey = new List<string>();

            foreach (ListItem item in chk_ArchiveUserList.Items)
            {
                if (item.Selected)
                {
                    ltKey.Add(item.Value);
                }
            }
            return ltKey;
        }
    }
}