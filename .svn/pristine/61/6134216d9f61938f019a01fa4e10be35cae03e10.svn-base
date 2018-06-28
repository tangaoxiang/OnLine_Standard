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

//工程证件上传管理

namespace DigiPower.Onlinecol.Standard.Web.CompanyManage {
    public partial class SingleProjectFileAttachAdd : System.Web.UI.Page {
        T_FileAttach_BLL fileAttachBLL = new T_FileAttach_BLL();
        T_SingleProject_BLL singleBLL = new T_SingleProject_BLL();

        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(SingleProjectFileAttachAdd));
            if (!this.IsPostBack) {
                string strSql = " PriKeyValue=" + DNTRequest.GetQueryString("SingleProjectID") + " and LOWER(Flag)='company_registration' ";
                DataTable dt = fileAttachBLL.GetList(strSql).Tables[0];
                rpData.DataSource = dt;
                rpData.DataBind();
            }
        }

        /// <summary>
        /// 删除附件
        /// </summary>                                      
        /// <param name="attachID"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public string DeleteFileAttach(int attachID) {
            string flag = SystemSet._RETURN_SUCCESS_VALUE;
            try {
                T_FileAttach_MDL fileAttachMDL = fileAttachBLL.GetModel(attachID);
                if (fileAttachMDL != null) {
                    PublicModel.writeLog(SystemSet.EumLogType.AddData.ToString(), string.Concat("T_FileAttach;key=", attachID,
                        ";SingleProjectID=", fileAttachMDL.PriKeyValue, ";AttachCode=", fileAttachMDL.AttachCode, ";删除工程证书附件"));

                    fileAttachBLL.Delete(attachID);
                }
            } catch (Exception ex) {
                flag = SystemSet._RETURN_FAILURE_VALUE + ex.Message;
                Common.LogUtil.Debug(this, "删除工程证书附件", ex);
            }
            return flag;
        }

        public string getAttachCodeName(string attachCode) {
            if (string.Compare(attachCode, SystemSet.EumProject_Credentials.ghxkz.ToString()) == 0)
                return "规划许可证号";
            else if (string.Compare(attachCode, SystemSet.EumProject_Credentials.sgxkz.ToString()) == 0)
                return "施工许可证号";
            else if (string.Compare(attachCode, SystemSet.EumProject_Credentials.other.ToString()) == 0)
                return "其它证号";
            else
                return null;
        }

        /// <summary>
        /// 证书附件上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e) {
            int singleProjectID = DNTRequest.GetQueryInt("SingleProjectID", 0);
            if (singleProjectID > 0) {
                HttpFileCollection uploadFiles = HttpContext.Current.Request.Files;//获取所有客户端上传文件对象
                HttpPostedFile userPostFile = null;

                if (uploadFiles.Count > 0) {
                    for (int i = 0; i < uploadFiles.Count; i++) {
                        userPostFile = uploadFiles[i];//获取独立的文件对象
                        string fileName = Common.Common.SaveFile(Server.MapPath(savePath), userPostFile, "R");

                        if (fileName != "") {
                            T_FileAttach_MDL mdl = new T_FileAttach_MDL();
                            mdl.AttachName = fileName;
                            mdl.AttachPath = savePath + fileName;
                            mdl.CreateDate = DateTime.Now;
                            mdl.PriKeyValue = singleProjectID;
                            mdl.OrderIndex = 0;
                            mdl.Flag = "Company_Registration";

                            if (Hid_ghxkz.Value != "") {
                                Hid_ghxkz.Value = "";
                                mdl.AttachCode = SystemSet.EumProject_Credentials.ghxkz.ToString();
                                fileAttachBLL.DelFileAttach(singleProjectID.ToString(), mdl.AttachCode, mdl.Flag);
                            } else if (Hid_sgxkz.Value != "") {
                                Hid_sgxkz.Value = "";
                                mdl.AttachCode = SystemSet.EumProject_Credentials.sgxkz.ToString();
                                fileAttachBLL.DelFileAttach(singleProjectID.ToString(), mdl.AttachCode, mdl.Flag);
                            } else if (Hid_other.Value != "") {
                                mdl.AttachCode = SystemSet.EumProject_Credentials.other.ToString();
                            }

                            int attachID = fileAttachBLL.Add(mdl);
                            PublicModel.writeLog(SystemSet.EumLogType.AddData.ToString(), string.Concat("T_FileAttach;key=", attachID,
                                ";SingleProjectID=", singleProjectID, ";AttachCode=", mdl.AttachCode, ";上传工程证书附件"));
                        }
                    }
                }
                Common.MessageBox.CloseLayerOpenWeb(this.Page);
            }
        }
        string savePath = "/Upload/Pic/";
    }
}