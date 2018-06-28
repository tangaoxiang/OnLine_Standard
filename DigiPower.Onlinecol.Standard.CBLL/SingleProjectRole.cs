using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DigiPower.Onlinecol.Standard.CBLL
{
    public class SingleProjectUser
    {
        public void Update(int SingleProjectID, int RoleID, int UserID)
        {
            BLL.T_SingleProjectUser_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_SingleProjectUser_BLL();
            DataSet ds = bll.GetList("SingleProjectID=" + SingleProjectID + " AND RoleID=" + RoleID + " AND UserID=" + UserID);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                Model.T_SingleProjectUser_MDL mdl = new DigiPower.Onlinecol.Standard.Model.T_SingleProjectUser_MDL();
                mdl.SingleProjectID = SingleProjectID;
                mdl.RoleID = RoleID;
                mdl.UserID = UserID;
                mdl.CreateDate = System.DateTime.Now;
                bll.Add(mdl);
            }
        }
    }

    public class SingleProjectCompany
    {
        public void Update(int SingleProjectID, int CompanyID)
        {
            BLL.T_SingleProjectCompany_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_SingleProjectCompany_BLL();
            DataSet ds = bll.GetList("SingleProjectID=" + SingleProjectID + " AND CompanyID=" + CompanyID);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                Model.T_SingleProjectCompany_MDL mdl = new DigiPower.Onlinecol.Standard.Model.T_SingleProjectCompany_MDL();
                mdl.SingleProjectID = SingleProjectID;
                mdl.CompanyID = CompanyID;
                bll.Add(mdl);
            }
        }
    }
}
