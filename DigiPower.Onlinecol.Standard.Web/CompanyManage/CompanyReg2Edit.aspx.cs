﻿using System;
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

namespace DigiPower.Onlinecol.Standard.Web.SystemManage {
    public partial class CompanyReg2Edit : PageBase {
        protected void Page_Load(object sender, EventArgs e) {
            MyAddInit();
            if (!IsPostBack) {
                int ConstructrionProjectID = Common.ConvertEx.ToInt(Common.DNTRequest.GetQueryString("ID"));
                ctrlConstructionBaseInfo1.DataBindEx(ConstructrionProjectID);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e) {
            T_Construction_Project_BLL projectbll = new T_Construction_Project_BLL();
            T_Construction_Project_MDL obj = new T_Construction_Project_MDL();
            obj = ctrlConstructionBaseInfo1.GetModule(Common.ConvertEx.ToInt(Common.DNTRequest.GetQueryString("ID")));
            //object obj = Comm.GetValueToObject(tmdl1, table1);
            int SingleProjectID = 0;
            if (obj != null) {
                T_Construction_Project_MDL newprojectmdl = (T_Construction_Project_MDL)obj;
                newprojectmdl.jgrq = DateTime.Now;
                if (((CommonEnum.PageState)ViewState["ps"]) == CommonEnum.PageState.ADD) {
                    newprojectmdl.CompanyID = Common.ConvertEx.ToInt(Common.Session.GetSession("CompanyID"));

                    //Leo 新增时，需要自动产生项目号
                    T_Other_BLL otherBLL = new T_Other_BLL();
                    newprojectmdl.xmh = otherBLL.GetNewProjectID();

                    SingleProjectID = projectbll.Add(newprojectmdl);
                    PublicModel.writeLog(SystemSet.EumLogType.AddData.ToString(),
                      string.Concat("T_Construction_Project;key=", SingleProjectID, ";xmmc=", newprojectmdl.xmmc));
                } else {
                    projectbll.Update(newprojectmdl);
                    PublicModel.writeLog(SystemSet.EumLogType.UpdData.ToString(),
                      string.Concat("T_Construction_Project;key=", newprojectmdl.ConstructionProjectID, ";xmmc=", newprojectmdl.xmmc));
                }
            }
            Common.MessageBox.CloseLayerOpenWeb(this.Page);
        }
    }
}
