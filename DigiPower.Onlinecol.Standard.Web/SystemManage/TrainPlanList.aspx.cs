using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Model;
using System.Collections.Generic;

//培训计划列表

namespace DigiPower.Onlinecol.Standard.Web.SystemManage
{
    public partial class TrainPlanList : PageBase
    {
        #region 属性及其构造方法
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Session["PageCount"] = 5;
                MyInit(this.tblSearch);
            }
            BindGridView();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void BindGridView()
        {
            T_Train_Plan_BLL tpBll = new T_Train_Plan_BLL();

            #region 获得数据集

            DataSet ds = new DataSet();
            if (ViewState["sqlwhere"] != null && !String.IsNullOrEmpty(ViewState["sqlwhere"].ToString()))
            {
                ds = tpBll.GetList(ViewState["sqlwhere"].ToString());
            }
            else if (!String.IsNullOrEmpty(SqlWhere))
            {
                ds = tpBll.GetList(SqlWhere);
            }
            else
            {
                ds = tpBll.GetList("1=1");
            }

            #endregion

            #region GridView中显示的字段名

            List<string> ltFieldName = new List<string>();
            ltFieldName.Add("Subject");
            ltFieldName.Add("Teacher");
            ltFieldName.Add("PlanDate");
            ltFieldName.Add("FinishDate");
            ltFieldName.Add("PlanUserName");

            #endregion

            #region 绑定GridView
            //ctrlGridEx1.PageCount = Common.ConvertEx.ToInt(Common.Session.GetSession("PageCount"));
            ctrlGridEx1.InitGrid("TrainPlanID", ltFieldName, ds, "~/SystemManage/TrainPlanAdd.aspx?Action=edit");

            #endregion
        }
        #endregion

        #region 事件

        //添加
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("TrainPlanAdd.aspx?Action=add&ID=0&sqlwhere=" + SqlWhere + "");
        }

        //删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            List<string> keyList = ctrlGridEx1.GetSelects();//获取Gridview选中行的主键集合

            if (keyList.Count > 0)
            {
                for (int i = 0; i < keyList.Count; i++)
                {
                    DataSet ds = new T_Other_BLL().GetTrainPlanToArchiveUser(Common.ConvertEx.ToInt(keyList[i]));
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        Common.MessageBox.Show(this, "该培训计划已经有档案员参加,如要删除必须先删除档案员的培训记录!");
                        return;
                    }

                    new T_Train_Plan_BLL().Delete(Common.ConvertEx.ToInt(keyList[i]));
                }
                BindGridView();
            }
        }

        //查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            T_Train_Plan_MDL tpMdl = new T_Train_Plan_MDL();
            Search(tblSearch, tpMdl);
            BindGridView();
        }

        #endregion


    }
}
