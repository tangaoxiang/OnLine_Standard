﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Reflection;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Model;
using System.Web.UI.MobileControls;
using System.Collections.Generic;

//归档目录新增/修改

namespace DigiPower.Onlinecol.Standard.Web.SystemManage {
    public partial class FileListTmpAdd : PageBase {
        T_FileListTmp_BLL fileTmpBLL = new T_FileListTmp_BLL();

        protected void Page_Load(object sender, EventArgs e) {
            Ajax.Utility.RegisterTypeForAjax(typeof(FileListTmpAdd));
            MyAddInit();
            PID.AutoPostBack = false;
            archive_form_no.MyArchiveTypeChanged += new DigiPower.Onlinecol.Standard.Web.CommonCtrl.
                ctrlArchiveFormType.ArchiveTypeChanged(archive_form_no_MyArchiveTypeChanged);

            if (!IsPostBack) {
                archive_form_no.DataBindEx("0");
                archive_form_no.AutoPostBack = true;
                FileType.DataBindEx();
                FileFrom.DataBindEx();

                List<string> ltCompany = new List<string>();
                ltCompany.Add("ARCHIVE");
                DefaultCompanyType.DataBindEx(false, ltCompany);

                archive_form_no_MyArchiveTypeChanged();
                BindPage(ID);

                if ((CommonEnum.PageState)ViewState["ps"] == CommonEnum.PageState.VIEW)
                    btnSave.Visible = false;
                if ((CommonEnum.PageState)ViewState["ps"] == CommonEnum.PageState.EDIT)
                    archive_form_no.Enabled = false;
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e) {
            T_FileListTmp_MDL model = new T_FileListTmp_MDL();
            if (ViewState["model"] != null) model = (Model.T_FileListTmp_MDL)ViewState["model"];
            object obj = Comm.GetValueToObject(model, this.tbl);

            if (obj != null) {
                Model.T_FileListTmp_MDL Newmodel = (Model.T_FileListTmp_MDL)obj;
                switch ((CommonEnum.PageState)ViewState["ps"]) {
                    case CommonEnum.PageState.ADD:
                        ID = fileTmpBLL.Add(Newmodel).ToString();

                        PublicModel.writeLog(SystemSet.EumLogType.AddData.ToString(), string.Concat("T_FileListTmp;key=", ID,
                            ";archive_form_no=", Newmodel.archive_form_no, ";bh=", Newmodel.bh, ";title=", Newmodel.title));
                        break;
                    case CommonEnum.PageState.EDIT: {
                            Newmodel.recid = Convert.ToInt32(ID);
                            fileTmpBLL.Update(Newmodel);

                            PublicModel.writeLog(SystemSet.EumLogType.UpdData.ToString(), string.Concat("T_FileListTmp;key=", Newmodel.recid,
                                ";archive_form_no=", Newmodel.archive_form_no, ";bh=", Newmodel.bh, ";title=", Newmodel.title));
                        }
                        break;
                }
            }
            Common.MessageBox.CloseLayerOpenWeb(this.Page);
        }

        /// <summary>
        /// 绑定页面
        /// </summary>
        /// <param name="ID"></param>
        private void BindPage(string ID) {
            if (!String.IsNullOrWhiteSpace(ID)) {
                T_FileListTmp_MDL model = new T_FileListTmp_MDL();
                model = fileTmpBLL.GetModel(Convert.ToInt32(ID));
                if (model != null) {
                    PID.DataBindEx(model.archive_form_no);
                    Comm.SetValueToPage(model, this.tbl);
                    ViewState["model"] = model;
                }
            }
        }

        /// <summary>
        ///获取某一类归档目录 Isfolder=1 
        /// </summary>
        private void archive_form_no_MyArchiveTypeChanged() {
            PID.ItemClear();
            if (!String.IsNullOrWhiteSpace(archive_form_no.SelectValue))
                PID.DataBindEx(archive_form_no.SelectValue);
        }
    }
}
