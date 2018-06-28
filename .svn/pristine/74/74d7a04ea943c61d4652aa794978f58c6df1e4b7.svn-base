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
using System.Drawing.Printing;
using System.IO;
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.BLL;
using System.Collections.Generic;

namespace DigiPower.Onlinecol.Standard.Web.File
{
    public partial class CellEdit : PageBase
    {
        protected string cellFilePath = null;   //华表模板路径
        protected string NewCellFilePath = null;  //上传后的文件路径,不包括工程主键
        protected string NewCellFullFilePath = null;  //上传后的文件路径

        protected int FileListID = 0;                   //电子文件对应的文件ID  
        protected string CompanyID = "";                //工程对应的单位ID
        protected string SingleProjectID = "";          //工程ID
        protected string ConstructionProjectID = "";    //项目ID
        protected int ArchiveListCellRptID = 0;         //电子文件ID
        string StartPath = string.Empty;
        //string EFileStartPath = Common.Common.EFileStartPath;

        protected void Page_Load(object sender, EventArgs e)
        {
            StartPath = Common.Common.EFileStartPath.Remove(0, 2).Replace('\\', '/');
            if (!this.IsPostBack)
            {
                MyAddInit();

                SingleProjectID = Request.QueryString["ProNo"];
                BLL.T_EFile_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_EFile_BLL();
                Model.T_EFile_MDL efileMDL = new DigiPower.Onlinecol.Standard.Model.T_EFile_MDL();
                efileMDL = bll.GetModel(Common.ConvertEx.ToInt(ID));

                if (efileMDL != null)
                {
                    FileListID = efileMDL.FileListID;
                    ArchiveListCellRptID = efileMDL.ArchiveListCellRptID;//给前面用的


                    //T_SingleProject_MDL SingProMdl = new T_SingleProject_BLL().GetModel(Common.ConvertEx.ToInt(SingleProjectID));
                    //T_Construction_Project_MDL ConProMdl = new T_Construction_Project_BLL().GetModel(Common.ConvertEx.ToInt(SingProMdl.ConstructionProjectID));
                    //if (ConProMdl != null)
                    //{
                    //    CompanyID = Common.ConvertEx.ToString(ConProMdl.CompanyID);
                    //    ConstructionProjectID = Common.ConvertEx.ToString(ConProMdl.ConstructionProjectID);
                    //}
                    //判断，如果华表是第一次则根据华表模板的路径读取华表
                    //否则直接读取电子文件的FilePath
                    if (Common.ConvertEx.ToInt(efileMDL.Status) == 0)
                    {
                        T_CellTmp_MDL ctMdl = new T_CellTmp_BLL().GetModel(Common.ConvertEx.ToInt(efileMDL.FilePath));
                        cellFilePath = "http://" + Request.ServerVariables["HTTP_HOST"] + "/" + ctMdl.FilePath.Substring(1).Replace(@"\", @"/");     //华表模板路径

                        string tempFileID = Guid.NewGuid().ToString() + ".cll";

                        //string cellPath = Server.MapPath(string.Concat(StartPath,"CellEFile/"

                        //CreateDirectory(StartPath + "CellEFile/" +  + "/", true);
                        CreateDirectory(string.Concat(StartPath, "/", SingleProjectID, "/CellEFile/"), true);

                        NewCellFilePath = string.Concat("/CellEFile/", tempFileID);//新华表存储路径           
                        NewCellFullFilePath = string.Concat(StartPath, SingleProjectID, "/CellEFile/", tempFileID);//新华表存储路径           
                    }
                    else if (Common.ConvertEx.ToInt(efileMDL.Status) == 1)
                    {
                        if (System.IO.File.Exists(Server.MapPath(string.Concat(StartPath, SingleProjectID, "/", efileMDL.FilePath))))
                        {
                            //Leo 存了绝对路径。等easyPDF好了，再回来来决定
                            cellFilePath = "http://" + Request.ServerVariables["HTTP_HOST"] +
                                string.Concat(StartPath, SingleProjectID, "/", efileMDL.FilePath);
                            NewCellFilePath = efileMDL.FilePath;
                            NewCellFullFilePath = string.Concat(StartPath, SingleProjectID, "/", efileMDL.FilePath);
                        }
                    }
                    try
                    {
                        string Action = Request.QueryString["Action"];
                        if (Action == "Show")
                        {
                            T_CellTmp_MDL ctMdl = new T_CellTmp_BLL().GetModel(Common.ConvertEx.ToInt(ID));
                            cellFilePath = "http://" + Request.ServerVariables["HTTP_HOST"] + "/" + ctMdl.FilePath.Substring(1).Replace(@"\", @"/");
                            CompanyID = "10";
                            ConstructionProjectID = "10";
                            return;
                        }
                    }
                    catch { }

                    T_SingleProject_MDL SingProMdl = new T_SingleProject_BLL().GetModel(Common.ConvertEx.ToInt(SingleProjectID));
                    T_Construction_Project_MDL ConProMdl = new T_Construction_Project_BLL().GetModel(Common.ConvertEx.ToInt(SingProMdl.ConstructionProjectID));
                    if (ConProMdl != null)
                    {
                        CompanyID = Common.ConvertEx.ToString(ConProMdl.CompanyID);
                        ConstructionProjectID = Common.ConvertEx.ToString(ConProMdl.ConstructionProjectID);
                    }
                }
            }
        }

        /// <summary>
        /// 判断文件夹是否存在，不存在则创建
        /// </summary>
        /// <param name="Path">文件夹路径</param>
        /// <param name="virtulaPath">是否为虚拟路径</param>
        private void CreateDirectory(string Path, bool virtulaPath)
        {
            if (virtulaPath)
            {
                if (!System.IO.File.Exists(Server.MapPath(Path)))
                    Directory.CreateDirectory(Server.MapPath(Path));
            }
            else
            {
                if (!System.IO.File.Exists(Path))
                    Directory.CreateDirectory(Path);
            }
        }
    }
}