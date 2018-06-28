using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.Model;

namespace DigiPower.Onlinecol.Standard.Web.WorkFlow {
    public partial class FileSignatureSet : System.Web.UI.Page {
        T_FileList_BLL fileListBLL = new T_FileList_BLL();
        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(FileSignatureSet));
        }
            
        /// <summary>
        /// 更新文件签章标识  是否需要签章,是否按签章流程签章
        /// </summary>
        /// <param name="fileListID">文件ID</param>
        /// <param name="iSignaturePdf">是否需要签章</param>
        /// <param name="iSignatureWorkFlow">是否按签章流程签章</param>    
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public void SetFileListSignatureStatus(string fileListID, string iSignaturePdf, string iSignatureWorkFlow) {
            try { //注意:如果文件已开始顺签,后又混签,则没影响; 如果先混签,在设置为顺签,则有影响. 看是否需要过滤下如果文件已开始签章则不能更改 (是否按签章流程签章)标识
                T_FileList_MDL fileListMDL = fileListBLL.GetModel(ConvertEx.ToInt(fileListID));
                if (fileListMDL != null) {
                    fileListMDL.iSignaturePdf = ConvertEx.ToBool(iSignaturePdf);
                    fileListMDL.iSignatureWorkFlow = ConvertEx.ToBool(iSignatureWorkFlow);
                    fileListBLL.Update(fileListMDL);

                    PublicModel.writeLog(SystemSet.EumLogType.UpdData.ToString(), string.Concat("T_FileList;key=", fileListMDL.FileListID,
                    ";SingleProjectID=", fileListMDL.SingleProjectID, ";bh=", fileListMDL.BH, ";iSignaturePdf=", iSignaturePdf,
                    ";iSignatureWorkFlow=", iSignatureWorkFlow, ";Title=", fileListMDL.Title, ";文件登记页更新是否需要签章,是否按流程签章"));
                }
            } catch (Exception ex) {
                LogUtil.Debug(this, "文件登记归档目录保存操作", ex);
            }
        }
    }
}