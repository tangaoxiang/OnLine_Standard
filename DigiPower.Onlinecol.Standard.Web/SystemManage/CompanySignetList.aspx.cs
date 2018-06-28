using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.Model;

namespace DigiPower.Onlinecol.Standard.Web.SystemManage
{
    public partial class CompanySignetList : PageBase
    {
        int _CompanyID=0;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //MyInit(this.tblSearch);
                //this.btnSearch_Click(null, null);                
                
            }
            BindGrid();
        }

        void BindGrid()
        {
            _CompanyID = Common.ConvertEx.ToInt(Common.DNTRequest.GetString("CompanyID"));
            T_Company_MDL objCompany = (new T_Company_BLL()).GetModel(_CompanyID);
            T_SystemInfo_MDL objSystemInfo=(new T_SystemInfo_BLL()).GetModel(objCompany.CompanyType);

            T_Other_BLL otherBLL = new T_Other_BLL();
            DataSet ds = otherBLL.GetCompanySignet(_CompanyID, objSystemInfo.SystemInfoCode);

            List<GridExPara> collist = new List<GridExPara>();

            GridExPara p11 = new GridExPara();
            p11.FieldName = "AttachID";
            p11.bShow = false;
            collist.Add(p11);

            GridExPara p1 = new GridExPara();
            p1.FieldName = "SystemInfoName";
            collist.Add(p1);

            GridExPara p2 = new GridExPara();
            p2.FieldName = "SubType";
            collist.Add(p2);

            GridExPara p3 = new GridExPara();
            p3.FieldName = "AttachPath";
            p3.iType = GridExPara.CtrlType.Image;
            p3.iLength = 120;
            collist.Add(p3);

            GridExPara p99 = new GridExPara();
            p99.FieldName = "";
            p99.iType = GridExPara.CtrlType.FileUpload;          
            collist.Add(p99);
            //ctrlGridEx1.PageCount = Common.ConvertEx.ToInt(Common.Session.GetSession("PageCount"));
            ctrlGridEx1.InitGrid("SystemInfoID", collist, ds, "", false, false, "");
        }

        protected void lbtnAdd_Click(object sender, EventArgs e)
        {
            List<string> sellist = ctrlGridEx1.GetSelects();            
            if (sellist.Count > 0)
            {
                List<int> rowIndexList = ctrlGridEx1.GetSelectsRowIndexList();
                for (int i = 0; i < sellist.Count; i++)
                {
                    FileUpload f1 = (FileUpload)ctrlGridEx1.Rows[rowIndexList[i]].Cells[5].Controls[0];
                    string savePath = "/Upload/CompanySignet/";
                    string fileName = Common.Common.SaveFile(Server.MapPath(savePath), f1.PostedFile, "Signet_","jpg,gif,bmp");

                    if (fileName != "")
                    {
                        string SystemInfoID = sellist[i];
                        Model.T_SystemInfo_MDL sysMDL = (new BLL.T_SystemInfo_BLL()).GetModel(Common.ConvertEx.ToInt(SystemInfoID));

                        T_FileAttach_BLL fileAttBLL = new T_FileAttach_BLL();
                        T_FileAttach_MDL fileAttMDL=new T_FileAttach_MDL();

                        fileAttMDL.Flag = sysMDL.CurrentType;
                        fileAttMDL.PriKeyValue = Common.ConvertEx.ToInt(_CompanyID);
                        fileAttMDL.AttachPath = savePath + fileName;
                        fileAttMDL.AttachName = sysMDL.CurrentTypeCNName;
                        fileAttMDL.AttachCode = sysMDL.SystemInfoCode;
                        fileAttMDL.CreateDate = DateTime.Now;
                        fileAttMDL.OrderIndex = 1;
                        fileAttMDL.AttachID = Common.ConvertEx.ToInt(ctrlGridEx1.Rows[rowIndexList[i]].Cells[1].Text);

                        if (fileAttMDL.AttachID == 0)
                        {
                            fileAttBLL.Add(fileAttMDL);
                        }
                        else
                        {
                            fileAttBLL.Update(fileAttMDL);                             
                        }
                    }
                }
                BindGrid();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            List<string> sellist = ctrlGridEx1.GetSelects();
            if(sellist.Count>0)
            {
                List<int> rowIndexList = ctrlGridEx1.GetSelectsRowIndexList();
                for(int i=0;i<sellist.Count;i++)
                {
                    int AttachID=  Common.ConvertEx.ToInt(ctrlGridEx1.Rows[rowIndexList[i]].Cells[1].Text);
                    if (AttachID > 0)
                    {
                        (new T_FileAttach_BLL()).Delete(AttachID);
                    }
                }
                BindGrid();
            }            
        }

        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    Model.T_Company_MDL model = new DigiPower.Onlinecol.Standard.Model.T_Company_MDL();

        //    Search(this.tblSearch, model);

        //    this.BindGrid();
        //}
    }
}