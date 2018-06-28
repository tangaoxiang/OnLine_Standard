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
using System.Collections.Generic;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.Model;

//案卷管理

namespace DigiPower.Onlinecol.Standard.Web.WorkFlow
{
    public partial class MyArchiveAdd : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Ajax.Utility.RegisterTypeForAjax(typeof(ArchiveAdd));
            MyAddInit();
            if (!this.IsPostBack)
            {
                if ((CommonEnum.PageState)ViewState["ps"] == CommonEnum.PageState.VIEW)
                    btnSave.Visible = false;

                BindData();
            }
        }

        /// <summary>
        /// 绑定字典
        /// </summary>
        protected void BindData()
        {
            //boxType.DataBindEx();
            bgqx.DataBindEx();
            mj.DataBindEx();
            ajlx.DataBindEx();

            if (!String.IsNullOrEmpty(ID))
            {
                T_MyArchive_MDL Mdl = new T_MyArchive_BLL().GetModel(Common.ConvertEx.ToInt(ID));
                if (Mdl != null)
                {
                    ViewState["model"] = Mdl;
                    Comm.SetValueToPage(Mdl, this.tbl);
                }
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (((CommonEnum.PageState)ViewState["ps"]) == CommonEnum.PageState.EDIT)
            {
                T_MyArchive_MDL Mdl = new T_MyArchive_MDL();
                if (ViewState["model"] != null)
                {
                    Mdl = ViewState["model"] as T_MyArchive_MDL;
                    object obj = Comm.GetValueToObject(Mdl, this.tbl);
                    T_MyArchive_MDL newMdl = obj as T_MyArchive_MDL;

                    new T_MyArchive_BLL().Update(newMdl);
                }
            }
            Common.MessageBox.CloseLayerOpenWeb(this.Page);
        }
    }
}