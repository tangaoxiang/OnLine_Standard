using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.CBLL;
using DigiPower.Onlinecol.Standard.Common;

namespace DigiPower.Onlinecol.Standard.Web {
    public partial class BatchSignaturePdf : PageBase {
        public string mServerUrl;
        public string singleProjectID = string.Empty;          //工程ID
        T_FileList_BLL fileBLL = new T_FileList_BLL();

        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(BatchSignaturePdf));

            MyAddInit();
            if (!this.IsPostBack) {
                singleProjectID = Request.QueryString["SingleProjectID"];
                mServerUrl = string.Concat("http://", Request.Url.Authority, "//PDFServer.aspx?ProNo=",
                    singleProjectID, "&rn=", DateTime.Now.ToString("MMddhhmmssf"), "&action=view");


                string fileIDS = Common.DNTRequest.GetQueryString("fileIDS");
                string strWhere = "FileListID in(" + fileIDS + ")";
                IList<Model.T_FileList_MDL> fileList = fileBLL.GetModelList(strWhere);
                if (fileList.Count > 0) {
                    int index = 1;
                    foreach (Model.T_FileList_MDL file in fileList) {
                        string strHtml = "<a style=\"cursor:pointer\" href=\"BatchSignaturePdf.aspx?SignatureType={0}&ID={1}&SingleProjectID="
                        + "{2}&fileIDS={3}\" title=\"点击预览\">{4}</a><br/>";

                        ltHtml.Text += string.Format(strHtml, DNTRequest.GetQueryString("SignatureType"), file.FileListID,
                            file.SingleProjectID, fileIDS, "编号：" + file.BH + "-第" + index.ToString() + "份PDF");
                        index++;
                    }
                }
            }
        }
    }
}