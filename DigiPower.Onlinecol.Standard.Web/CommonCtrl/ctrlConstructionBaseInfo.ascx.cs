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

namespace DigiPower.Onlinecol.Standard.Web.CommonCtrl
{
    public partial class ctrlConstructionBaseInfo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {  
        }
        public void DataBindEx(int tConstructionProjectID)
        {
            constructionprojectid.Value = tConstructionProjectID.ToString();
            projecttype.DataBindEx();
            DataBindEx();
        }

        private void DataBindEx()
        {
            T_Construction_Project_MDL projectmdl = (new T_Construction_Project_BLL()).GetModel(ConvertEx.ToInt(constructionprojectid.Value));
            Comm.SetValueToPage(projectmdl, table1);
            if (jsdw.Text == "")
            {
                jsdw.Text = Common.Session.GetSession("CompanyName");
            }            
        }
        public T_Construction_Project_MDL GetModule(int tconstructionprojectid)
        {
            T_Construction_Project_MDL mdl = new T_Construction_Project_MDL();
            if (tconstructionprojectid > 0)
            {
                BLL.T_Construction_Project_BLL bll = new T_Construction_Project_BLL();
                mdl = bll.GetModel(tconstructionprojectid);
            }
            object obj = Comm.GetValueToObject(mdl, table1);
            return (T_Construction_Project_MDL)obj;
        }        
    }
}