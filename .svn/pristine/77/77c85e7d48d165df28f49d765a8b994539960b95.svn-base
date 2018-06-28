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

//培训记录

namespace DigiPower.Onlinecol.Standard.Web.SystemManage
{
    public partial class TrainRecList : PageBase
    {
        #region 属性及其构造方法
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Session["PageCount"] = 10;
                MyInit(this.tblSearch);
                UserID.BindUser("UserType='ArchiveUser'", true);
            }
            BindGridView();
        }
        #endregion

        #region 事件

        //查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            T_Train_Rec_MDL trMdl = new T_Train_Rec_MDL();
            Search(tblSearch, trMdl);
            BindGridView();
        }

        //更改培训结果
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("TrainRecAdd.aspx?Action=&ID=0&sqlwhere=" + SqlWhere + "");
        }

        //删除记录
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            List<string> keyList = ctrlGridEx1.GetSelects();
            if (keyList.Count > 0)
            {
                for (int i = 0; i < keyList.Count; i++)
                {
                    new T_Train_Rec_BLL().Delete(Common.ConvertEx.ToInt(keyList[i]));
                }
                BindGridView();
            }
        }

        #endregion

        #region 方法
        private void BindGridView()
        {
            T_Other_BLL Bll = new T_Other_BLL();

            #region 获得数据集

            DataSet ds = new DataSet();
            if (ViewState["sqlwhere"] != null && !String.IsNullOrEmpty(ViewState["sqlwhere"].ToString()))
            {
                string strSql = ViewState["sqlwhere"].ToString();
                strSql = strSql.Replace("UserID", "Rec.UserID");

                ds = Bll.GetTrainRec(strSql);
            }
            else if (!String.IsNullOrEmpty(SqlWhere))
            {
                ds = Bll.GetTrainRec(SqlWhere);
            }
            else
            {
                ds = Bll.GetTrainRec("1=1");
            }

            #endregion

            #region GridView中显示的字段名

            List<string> ltFieldName = new List<string>();
            ltFieldName.Add("Subject");
            ltFieldName.Add("UserName");
            ltFieldName.Add("COMPANYNAME");
            ltFieldName.Add("PlanDate");
            ltFieldName.Add("FinishDate");

            #endregion

            #region 绑定GridView
            //ctrlGridEx1.PageCount = Common.ConvertEx.ToInt(Common.Session.GetSession("PageCount"));
            ctrlGridEx1.InitGrid("TrainRecID", ltFieldName, ds, "", true, false, "");

            #endregion

        }
        #endregion
    }
}
