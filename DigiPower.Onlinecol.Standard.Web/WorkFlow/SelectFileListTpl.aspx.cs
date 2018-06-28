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
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Model;

namespace DigiPower.Onlinecol.Standard.Web.WorkFlow
{
    public partial class SelectFileListTpl : System.Web.UI.Page
    {
        T_FileListTmp_BLL fileListTmpBLL = new T_FileListTmp_BLL();

        /// <summary>
        /// 总记录数
        /// </summary>
        int itemCount = 0;

        /// <summary>
        /// 每页页数
        /// </summary>
        int pageSize = SystemSet._PAGESIZE;

        protected void Page_Load(object sender, EventArgs e)
        {
            Ajax.Utility.RegisterTypeForAjax(typeof(SelectFileListTpl));
            if (!IsPostBack)
            {
                DataBindFileType();
                BindGrid(1);
            }
        }

        /// <summary>
        /// 绑定文件类型
        /// </summary>
        private void DataBindFileType()
        {
            string strWhere = string.Empty;
            strWhere = "PID=0 and archive_form_no in(select ProjectType from T_SingleProject where SingleProjectID=" + DNTRequest.GetQueryString("SingleProjectID") + ")";
            List<T_FileListTmp_MDL> list = fileListTmpBLL.GetModelList(strWhere);

            T_FileListTmp_MDL fileListTmpMDL = new T_FileListTmp_MDL();
            fileListTmpMDL.bh = "";
            fileListTmpMDL.title = "全部";

            list.Insert(0, fileListTmpMDL);
            ddlFileType.DataValueField = "bh";
            ddlFileType.DataTextField = "title";
            ddlFileType.DataSource = list;
            ddlFileType.DataBind();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="pageIndex"></param>
        private void BindGrid(int pageIndex)
        {
            string strWhere = " archive_form_no =(select ProjectType from T_SingleProject where SingleProjectID=" +
                DNTRequest.GetQueryString("SingleProjectID") + ")";

            if (!String.IsNullOrWhiteSpace(ddlFileType.SelectedValue))
                strWhere += " AND bh LIKE '%" + ddlFileType.SelectedValue + "%'";
            if (txtTitle.Text.Trim().Length > 0)
                strWhere += " AND title LIKE '%" + txtTitle.Text.Trim() + "%'";

            DataTable dt = fileListTmpBLL.GetListPaging(strWhere, pageSize, pageIndex, out itemCount); ;

            AspNetPager.AlwaysShow = true;
            AspNetPager.PageSize = pageSize;

            AspNetPager.RecordCount = itemCount;
            AspNetPager.CurrentPageIndex = pageIndex;

            rpData.DataSource = dt;
            rpData.DataBind();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid(1);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager_PageChanged(object sender, EventArgs e)
        {
            BindGrid(AspNetPager.CurrentPageIndex);
        }

        /// <summary>
        /// 新增归档目录
        /// </summary>
        /// <param name="recidList"></param>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public string AddFile(string recidList, string singleProjectID)
        {
            try
            {
                string[] SelectList = recidList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                T_FileList_BLL fileListBLL = new T_FileList_BLL();
                foreach (string ID in SelectList)
                {
                    T_FileListTmp_MDL mdl = fileListTmpBLL.GetModel(ConvertEx.ToInt(ID));
                    mdl.MustSubmitFlag = true;
                    fileListBLL.Add(singleProjectID, mdl, true);
                }
                return SystemSet._RETURN_SUCCESS_VALUE;
            }
            catch (Exception ex)
            {
                return SystemSet._RETURN_SUCCESS_VALUE + ex.Message;
            }
        }
    }
}