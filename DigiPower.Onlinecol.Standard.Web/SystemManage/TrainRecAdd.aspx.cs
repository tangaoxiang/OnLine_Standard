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
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.BLL;
using System.Collections.Generic;
using DigiPower.Onlinecol.Standard.Web.CommonCtrl;

//培训记录新增/修改

namespace DigiPower.Onlinecol.Standard.Web.SystemManage
{
    public partial class TrainRecAdd : PageBase
    {
        #region 属性及其构造方法
        protected void Page_Load(object sender, EventArgs e)
        {
            MyAddInit();
            ddlTrainPlanID.MySelectChange+=new ctrlDropDownTrainPlan.SelectChange(ddlTrainPlanID_MySelectChange);
            
            if (!this.IsPostBack)
            {
                ddlTrainPlanID.BindTranPlan();
                ddlTrainPlanID.AutoPostBack = true;

                int TrainPlanID = Common.ConvertEx.ToInt(ddlTrainPlanID.SelectedValue);
                if (TrainPlanID > 0)
                {
                    chkArchiveUerList.DataBindEx(TrainPlanID, true, true);
                }
            }
        }
        #endregion


        #region 事件

        public void ddlTrainPlanID_MySelectChange()
        {
            int TrainPlanID = Common.ConvertEx.ToInt(ddlTrainPlanID.SelectedValue);
            if (TrainPlanID > 0)
            {
                chkArchiveUerList.DataBindEx(TrainPlanID, true, true);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int TrainPlanID = Common.ConvertEx.ToInt(ddlTrainPlanID.SelectedValue);
            string TrainDesc = txtTrainDesc.Text.Trim();
            string TrainResult = txtTrainResult.Text.Trim();
            List<string> ltKey = chkArchiveUerList.GetSelectList();

            if (TrainPlanID > 0 && ltKey.Count > 0)
            {
                foreach (string UserID in ltKey)
                {
                    if (Common.ConvertEx.ToInt(UserID) > 0)
                    {
                        new T_Other_BLL().SetTrainRecDescAndResult(TrainPlanID, Common.ConvertEx.ToInt(UserID), TrainDesc, TrainResult);
                    }
                }
            }
            Response.Redirect("TrainRecList.aspx?sqlwhere=" + SqlWhere + "&PageIndex=" + pPageIndex + "");
        }

        #endregion
    }
}
