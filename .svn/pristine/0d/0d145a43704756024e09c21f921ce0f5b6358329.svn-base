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
using System.Collections.Generic;
using DigiPower.Onlinecol.Standard.Common;
using System.Text;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Model;

namespace DigiPower.Onlinecol.Standard.Web.File {
    public partial class FileInfoList : PageBase {
        T_FileList_BLL fileBLL = new T_FileList_BLL();

        protected void Page_Load(object sender, EventArgs e) {
            MyAddInit();
            if (!IsPostBack) {
                ztlx.DataBindEx();
                gg.DataBindEx();
                wjgbdm.DataBindEx();

                if ((CommonEnum.PageState)ViewState["ps"] == CommonEnum.PageState.EDIT) {
                    btnUp.Visible = true;
                    btnDown.Visible = true;
                    btnSave.Visible = true;
                }
                if (DNTRequest.GetQueryString("type").ToLower() == "supplement")   //补卷中,修改文件信息
                {
                    btnUp.Visible = false;
                    btnDown.Visible = false;
                }
                pageIndex = 1;
                BindPage(ID);
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e) {
            DigiPower.Onlinecol.Standard.Model.T_FileList_MDL model = null;
            if (pageIndex != 1)
                model = fileBLL.GetModel(Common.ConvertEx.ToInt(fileListID));
            else
                model = fileBLL.GetModel(Common.ConvertEx.ToInt(ID));

            model = (Model.T_FileList_MDL)Comm.GetValueToObject(model, tbl);
            if (model != null && !model.IsFolder) {
                if (ConvertEx.ToInt(model.ManualCount) > 0) {
                    if (model.wjgbdm == "ct" ||
                        model.wjgbdm == "yt" ||
                        model.wjgbdm == "dt" ||
                        model.wjgbdm == "lt") {
                        model.tzz = ConvertEx.ToInt(model.ManualCount);
                    } else {
                        model.sl = ConvertEx.ToInt(model.ManualCount);
                    }
                }
                model.qssj = DateTime.Now;
                model.zzsj = DateTime.Now;
                model.lrsj = DateTime.Now;
                model.shsj_1 = DateTime.Now;
                model.shsj_2 = DateTime.Now;
                model.shsj_3 = DateTime.Now;
                model.aipdate = DateTime.Now;
                model.pssj = DateTime.Now;
                model.CreateDate = DateTime.Now;
                model.Version = PublicModel.getFileVersion(model.SingleProjectID.ToString());  //获取文件的版本号
                fileBLL.Update(model);

                PublicModel.writeLog(SystemSet.EumLogType.UpdData.ToString(), string.Concat("T_FileList;key=", model.FileListID,
                    ";SingleProjectID=", model.SingleProjectID, ";bh=", model.BH, ";Title=", model.Title));

                T_Other_BLL otherBLL = new T_Other_BLL();
                otherBLL.UpdateArchiveStatus(model.FileListID.ToString(), 10, "0");
            }
            Common.MessageBox.CloseLayerOpenWeb(this.Page);
        }

        /// <summary>
        /// 绑定页面
        /// </summary>
        /// <param name="ID"></param>
        private void BindPage(string ID) {
            if (!String.IsNullOrWhiteSpace(ID)) {
                T_FileList_MDL model = fileBLL.GetModel(Convert.ToInt32(ID));
                if (model != null) {
                    fileListID = ID;
                    Comm.SetValueToPage(model, this.tbl);

                    if (model.StartTime.Length < 1)
                        StartTime.Text = "";

                    if (model.EndTime.Length < 1)
                        ENDTIME.Text = "";

                    if (ConvertEx.ToInt(model.Status) < 1 && String.IsNullOrWhiteSpace(model.zrr)) {
                        zrr.Text = Common.Session.GetSession("CompanyName");
                    }
                }
            }
        }

        /// <summary>
        /// 上一条,下一条绑定文件信息
        /// </summary>
        /// <param name="upOrDown"></param>
        private void BindPage(bool upOrDown) {
            T_FileList_MDL model = fileBLL.GetFileByPageIndex(fileListID, Common.Session.GetSession("FileInfostrWhere"), upOrDown);
            if (model != null) {
                fileListID = model.FileListID.ToString();
                DigiPower.Onlinecol.Standard.Web.Comm.SetValueToPage(model, this.tbl);

                if (model.StartTime.Length < 1)
                    StartTime.Text = "";

                if (model.EndTime.Length < 1)
                    ENDTIME.Text = "";


                if (ConvertEx.ToInt(model.Status) < 1) {
                    zrr.Text = Session["CompanyName"].ToString();
                }
            }
        }

        /// <summary>
        /// 当前索引页数
        /// </summary>
        public int pageIndex {
            get { return (int)ViewState["pageIndex"]; }
            set { ViewState["pageIndex"] = value; }
        }

        /// <summary>
        /// 文件ID
        /// </summary>
        public string fileListID {
            get { return (string)ViewState["fileListID"]; }
            set { ViewState["fileListID"] = value; }
        }

        /// <summary>
        /// 上一条
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUp_Click(object sender, EventArgs e) {
            if (pageIndex > 0) {
                pageIndex--;
                BindPage(true);
            }
        }

        /// <summary>
        /// 下一条
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDown_Click(object sender, EventArgs e) {
            if (fileBLL.GetFileCountByCompany(Common.Session.GetSession("FileInfostrWhere")) > 0) {
                pageIndex++;
                BindPage(false);
            }
        }
    }
}

















