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
using DigiPower.Onlinecol.Standard.Web.CommonCtrl;

namespace DigiPower.Onlinecol.Standard.Web.SystemManage {
    public partial class HookUpSignature : System.Web.UI.Page {
        T_FileList_SignatureTmp_BLL signatureTmpBll = new T_FileList_SignatureTmp_BLL();

        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(HookUpSignature));
            if (!this.IsPostBack) {
                DataBindEx(ConvertEx.ToInt(DNTRequest.GetQueryInt("FileListID", 0)));
            }
        }

        /// <summary>
        /// 绑定所有的签章角色类型
        /// </summary>
        /// <param name="FileListID"></param>
        private void DataBindEx(int FileListID) {
            ViewState["ltSignatureTmp"] = signatureTmpBll.GetModelList("FileListID=" + FileListID + "");

            List<T_SystemInfo_MDL> ltSystemInfo = new T_SystemInfo_BLL().GetModelList("CurrentType='SignetType' AND IsShow=1");
            gvSignature.DataSource = ltSystemInfo;
            gvSignature.DataBind();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="fileListID"></param>
        /// <param name="signatureType"></param>
        /// <param name="signatureOrderIndex"></param>

        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public void Execute(int fileListID, string signatureType, int signatureOrderIndex) {
            if (ConvertEx.ToString(signatureType).Length < 1) {
                signatureTmpBll.DeleteForFileListID(fileListID);
            } else {
                T_FileList_SignatureTmp_MDL signatureTmpMdl = new T_FileList_SignatureTmp_MDL();
                signatureTmpMdl.FileListID = fileListID;
                signatureTmpMdl.SignatureType = signatureType.Trim();
                signatureTmpMdl.SignatureCount = 0;
                signatureTmpMdl.OrderIndex = signatureOrderIndex;
                signatureTmpBll.Add(signatureTmpMdl);
            }
        }

        protected void repNewsList_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
                T_SystemInfo_MDL view = e.Item.DataItem as T_SystemInfo_MDL;
                CheckBox chkSystemInfoCode = e.Item.FindControl("chkSystemInfoCode") as CheckBox;
                chkSystemInfoCode.InputAttributes.Add("value", view.SystemInfoCode);

                ctrlTextBoxEx txtOrderIndex = e.Item.FindControl("txtOrderIndex") as ctrlTextBoxEx;
                HiddenField txtHidSid = e.Item.FindControl("txtHidSid") as HiddenField;

                if (DNTRequest.GetQueryInt("SignatureTypeCount", 0) > 0)//已做过签章设置的 ,重新绑定
                {
                    List<T_FileList_SignatureTmp_MDL> ltSignatureTmp = ViewState["ltSignatureTmp"] as List<T_FileList_SignatureTmp_MDL>;
                    T_FileList_SignatureTmp_MDL SignatureTmpMdl = ltSignatureTmp.Where(r => r.SignatureType.ToLower() == view.SystemInfoCode.ToLower()).FirstOrDefault();
                    if (SignatureTmpMdl != null) {
                        chkSystemInfoCode.Checked = true;
                        txtOrderIndex.Text = ConvertEx.ToInt(SignatureTmpMdl.OrderIndex).ToString("D2");
                        txtHidSid.Value = SignatureTmpMdl.SID.ToString();
                    }
                } else {
                    txtHidSid.Value = "";
                }
            }
        }
    }
}