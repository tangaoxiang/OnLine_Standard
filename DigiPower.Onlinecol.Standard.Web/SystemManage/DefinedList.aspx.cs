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
using System.Collections.Generic;

namespace DigiPower.Onlinecol.Standard.Web.SystemManage
{
    public partial class DefinedList : PageBase
    {
        #region 属性及构造方法

        DigiPower.Onlinecol.Standard.BLL.T_SystemInfo_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_SystemInfo_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            SystemInfoID.MySelectChanged += new DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownSystem.SelectChanged(drpType_SelectedIndexChanged);

            if (!IsPostBack)
            {
                SystemInfoID.DataBindEx();

                MyInit(this.tblSearch);

                this.btnSearch_Click(null, null);

                this.btnDelete.Attributes.Add("onclick", "javascript:return confirm('你确认要删除吗?')");

                
            }
            BindGridView();
        }

        #endregion

        #region 事件

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("DefinedAdd.aspx?Action=add&ID="+ this.SystemInfoID.SelectValue +"&sqlwhere=" + SqlWhere + "");
        }

        

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DigiPower.Onlinecol.Standard.BLL.T_DefineReult_BLL tbll = new DigiPower.Onlinecol.Standard.BLL.T_DefineReult_BLL();

            if (ctrlGridEx1.GetSelects().Count > 0)
            {
                for (int i = 0; i < ctrlGridEx1.GetSelects().Count; i++)
                {
                    tbll.Delete(Convert.ToInt32(ctrlGridEx1.GetSelects()[i]));

                }

                this.BindGridView();
            }
        }

        /// <summary>
        /// 列表选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void drpType_SelectedIndexChanged()
        {
            this.btnSearch_Click(null, null);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Model.T_SystemInfo_MDL model = new DigiPower.Onlinecol.Standard.Model.T_SystemInfo_MDL();

            Search(this.tblSearch, model);

            this.BindGridView();
        }

        #endregion

        #region 方法

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindGridView()
        {
            DigiPower.Onlinecol.Standard.BLL.UserOperate ubll = new DigiPower.Onlinecol.Standard.BLL.UserOperate();

            DataSet ds = new DataSet();

            if (ViewState["sqlwhere"] != null && !String.IsNullOrEmpty(ViewState["sqlwhere"].ToString()))
            {
                ds = ubll.GetDepartmentList("select * from vwDefine where " + ViewState["sqlwhere"].ToString());
            }
            else if (!String.IsNullOrEmpty(SqlWhere))
            {
                ds = ubll.GetDepartmentList("select * from vwDefine where " + SqlWhere);
            }
            else
            {
                ds = ubll.GetDepartmentList("select * from vwDefine where " + "1=1");
            }

            List<string> l1 = new List<string>();

            l1.Add("MainType");

            l1.Add("Split");

            l1.Add("TableName");

            l1.Add("FieldName");

            l1.Add("ShowName");

            l1.Add("StartLocation");

            l1.Add("EndLocation");

            l1.Add("IsSerial");

            ctrlGridEx1.InitGrid("DefineResultID", l1, ds, "~/SystemManage/DefinedAdd.aspx?Action=Edit");
        }

        #endregion
    }
}
