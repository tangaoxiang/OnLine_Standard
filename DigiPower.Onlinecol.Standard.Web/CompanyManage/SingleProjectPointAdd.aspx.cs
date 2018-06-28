using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.Model;
using System.Configuration;
using System.Data;

//工程坐标管理

namespace DigiPower.Onlinecol.Standard.Web.CompanyManage {
    public partial class SingleProjectPointAdd : System.Web.UI.Page {
        T_SingleProject_Point_BLL pointBLL = new T_SingleProject_Point_BLL();
        T_SingleProject_BLL singleBLL = new T_SingleProject_BLL();

        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(SingleProjectPointAdd));
            if (!this.IsPostBack) {
                DataBindEx();
            }
        }

        /// <summary>
        /// 绑定工程坐标
        /// </summary>
        private void DataBindEx() {
            string strSql = " SingleProjectID=" + DNTRequest.GetQueryString("SingleProjectID") + " ";
            DataTable dt = pointBLL.GetList(strSql).Tables[0];
            rpData.DataSource = dt;
            rpData.DataBind();
        }

        /// <summary>
        /// 判断同一个工程下的坐标序号出现的次数
        /// </summary>
        /// <param name="singleProjectID"></param>
        /// <param name="orderIndex"></param>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public int GetRecordCountForOrderIndex(string singleProjectID, string orderIndex, string pointID) {
            return pointBLL.GetRecordCount("SingleProjectID=" + singleProjectID + " and OrderIndex=" + orderIndex + " and PointID!=" + pointID);
        }

        /// <summary>
        /// 删除工程坐标
        /// </summary>                                      
        /// <param name="pointID"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public string DeleteSingleProjectPoint(int pointID) {
            string flag = SystemSet._RETURN_SUCCESS_VALUE;
            try {
                T_SingleProject_Point_MDL pointMDL = pointBLL.GetModel(pointID);
                if (pointMDL != null) {
                    PublicModel.writeLog(SystemSet.EumLogType.DelData.ToString(), string.Concat("T_SingleProject_Point;key=", pointMDL.PointID,
                        ";SingleProjectID=", pointMDL.SingleProjectID, ";删除工程坐标"));

                    pointBLL.Delete(pointID);
                }
            } catch (Exception ex) {
                flag = SystemSet._RETURN_FAILURE_VALUE + ex.Message;
                Common.LogUtil.Debug(this, "删除工程坐标", ex);
            }
            return flag;
        }

        /// <summary>
        /// 新增或保存工程坐标
        /// </summary>                                      
        /// <param name="pointID"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public string SaveSingleProjectPoint(string singleProjectID, string orderIndex, string pointID, string x, string y) {
            string flag = SystemSet._RETURN_SUCCESS_VALUE;
            try {
                T_SingleProject_Point_MDL pointMDL = new T_SingleProject_Point_MDL();
                if (ConvertEx.ToInt(pointID) > 0)
                    pointMDL = pointBLL.GetModel(ConvertEx.ToInt(pointID));

                pointMDL.SingleProjectID = ConvertEx.ToInt(singleProjectID);
                pointMDL.X = x;
                pointMDL.Y = y;
                pointMDL.OrderIndex = ConvertEx.ToInt(orderIndex);

                if (ConvertEx.ToInt(pointID) > 0) {
                    pointBLL.Update(pointMDL);
                    PublicModel.writeLog(SystemSet.EumLogType.UpdData.ToString(), string.Concat("T_SingleProject_Point;key=", pointMDL.PointID,
                        ";SingleProjectID=", pointMDL.SingleProjectID, ";修改工程坐标"));
                } else {
                    int tpPointID = pointBLL.Add(pointMDL);
                    PublicModel.writeLog(SystemSet.EumLogType.AddData.ToString(), string.Concat("T_SingleProject_Point;key=", tpPointID,
                        ";SingleProjectID=", pointMDL.SingleProjectID, ";新增工程坐标"));
                }
            } catch (Exception ex) {
                flag = SystemSet._RETURN_FAILURE_VALUE + ex.Message;
                Common.LogUtil.Debug(this, "保存工程坐标", ex);
            }
            return flag;
        }

    }
}