using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//窗口接收,业务审核,领导签字审核意见,针对案卷

namespace DigiPower.Onlinecol.Standard.Web.WorkFlow
{
    public partial class ZxyysCheck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                txtDoUserName.Text = Common.Session.GetSession("UserName");
                txtDoDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                ddlDoResult.SelectedValue = DNTRequest.GetQueryString("checkTypeFlag");
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            T_FileList_BLL fileListBLL = new T_FileList_BLL();
            T_WorkFlowDoResult_BLL doResultBLL = new T_WorkFlowDoResult_BLL();
            string[] FileListIDS = DNTRequest.GetQueryString("FileListIDS").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] MustSubmitFlags = DNTRequest.GetQueryString("mustSubmitFlags").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < FileListIDS.Length; i++)
            {
                T_FileList_MDL fileListMDL = fileListBLL.GetModel(ConvertEx.ToInt(FileListIDS[i]));
                if (fileListMDL != null && !fileListMDL.IsFolder)
                {
                    T_WorkFlowDoResult_MDL doResultMDL = new T_WorkFlowDoResult_MDL();
                    doResultMDL.FileListID = ConvertEx.ToInt(FileListIDS[i]);
                    doResultMDL.SingleProjectID = DNTRequest.GetQueryInt("SingleProjectID", 0);
                    doResultMDL.WorkFlowID = DNTRequest.GetQueryInt("workFlowID", 0);
                    doResultMDL.DoUserID = Common.ConvertEx.ToInt(Common.Session.GetSessionInt("UserID"));
                    doResultMDL.DoDateTime = System.DateTime.Now;
                    doResultMDL.DoResult = ddlDoResult.SelectedValue;
                    doResultMDL.DoRemark = DoRemark.Text.Trim();
                    doResultBLL.Add(doResultMDL);

                    fileListMDL.Remark = DoRemark.Text.Trim();
                    fileListMDL.MustSubmitFlag = ConvertEx.ToBool(MustSubmitFlags[i]);
                    fileListBLL.Update(fileListMDL);

                    FileAccept(FileListIDS[i], ConvertEx.ToBool(ddlDoResult.SelectedValue));
                }
            }
            Common.MessageBox.CloseLayerOpenWeb(this.Page);
        }

        /// <summary>
        /// 预验收完成后修改文件状态
        /// </summary>
        /// <param name="fileListID"></param>
        /// <param name="flag"></param>
        public void FileAccept(string fileListID, bool flag)
        {
            if (flag)
            { //验收通过 
                T_Other_BLL otherBLL = new T_Other_BLL();
                otherBLL.UpdateArchiveStatus(fileListID, 20, "0");
            }
            else
            { //验收不通过
                T_Other_BLL otherBLL = new T_Other_BLL();
                otherBLL.UpdateArchiveStatus(fileListID, 900, "0");
            }
        }
    }
}