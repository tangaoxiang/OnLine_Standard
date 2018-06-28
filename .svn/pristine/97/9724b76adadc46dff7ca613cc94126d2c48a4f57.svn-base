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
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.BLL;

//发放证书必须手填的相关信息

namespace DigiPower.Onlinecol.Standard.Web.WorkFlow
{
    public partial class SubmittedInfo : PageBase
    {
        T_SingleProject_BLL singleBLL = new T_SingleProject_BLL();
        T_ReadyCheckBook_BLL readBLL = new T_ReadyCheckBook_BLL();
        T_FileList_BLL fileBLL = new T_FileList_BLL();

        string singleProjectID = string.Empty;
        string reportType = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            Ajax.Utility.RegisterTypeForAjax(typeof(SubmittedInfo));

            singleProjectID = DNTRequest.GetQueryString("singleProjectID");//工程ID
            reportType = DNTRequest.GetQueryString("reportType");          //报表类型

            if (!IsPostBack)
            {   
                T_SingleProject_MDL singMDL = singleBLL.GetModel(ConvertEx.ToInt(singleProjectID));
                if (singMDL != null)
                {
                    ReadyCheckBookCode.Text = singMDL.gcbm;
                    jsdw.Text = singMDL.jsdw;
                }

                if (string.Compare(reportType, "rkz", true) == 0)
                {
                    //ltTitle.Text = SystemSet._APPAREA + "建设工程档案认可意见书";
                    ltReadyCheckBookCode.Text = "预验收编号:";
                    ReadyCheckBookCode.labelTitle = ltReadyCheckBookCode.Text;
                    TableRowShow(7, Table1.Rows.Count);
                }
                else if (string.Compare(reportType, "zms", true) == 0)
                {
                    //ltTitle.Text = SystemSet._APPAREA + "建设工程档案移交证明书";
                    ltReadyCheckBookCode.Text = "验收编号:";
                    ReadyCheckBookCode.labelTitle = ltReadyCheckBookCode.Text;
                    TableRowShow(2, 7);
                }
                else if (string.Compare(reportType, "zrs", true) == 0)
                {
                    //ltTitle.Text = SystemSet._APPAREA + "建设工程档案移交证明书";
                    ltReadyCheckBookCode.Text = "责任书编号:";
                    ReadyCheckBookCode.labelTitle = ltReadyCheckBookCode.Text;
                    TableRowShow(2, Table1.Rows.Count);
                }
                string strWhere = "SingleProjectID='" + singleProjectID + "' and lower(CodeType)='" + reportType.ToLower() + "'";
                IList<T_ReadyCheckBook_MDL> ltMdl = readBLL.GetModelList(strWhere);
                if (ltMdl != null && ltMdl.Count > 0)
                {
                    T_ReadyCheckBook_MDL readMDL = ltMdl[0];
                    txtTotalScroll.Text = ConvertEx.ToString(readMDL.TOTAL_SCROLL);
                    txtCharacterScroll.Text = ConvertEx.ToString(readMDL.CHARACTER_SCROLL);
                    txtPicScroll.Text = ConvertEx.ToString(readMDL.PIC_SCROLL);
                    txtPhotoPageCount.Text = ConvertEx.ToString(readMDL.PHOTO_COUNT);
                    txtRadioCount.Text = ConvertEx.ToString(readMDL.RADIO_COUNT);
                    txtOtherMaterial.Text = readMDL.OTHER_MATERIAL;
                    txtDirectoryScroll.Text = ConvertEx.ToString(readMDL.Directory_SCROLL);
                    txtDirectoryPage.Text = ConvertEx.ToString(readMDL.Directory_PAGE_COUNT);
                    ReadyCheckBookCode.Text = readMDL.ReadyCheckBookCode;
                    jsdwfzr_Name.Text = readMDL.jsdwfzr_Name;
                    jsdwfzr_Tel.Text = readMDL.jsdwfzr_Tel;
                    ArchiveUserName.Text = readMDL.ArchiveUserName;
                    ArchiveUser_Tel.Text = readMDL.ArchiveUser_Tel;

                    ViewState["objModel"] = readMDL;
                }
                else
                {
                    DataSet ds = new T_Other_BLL().GetArchiveInfo(singleProjectID);
                    if (ds.Tables.Count > 0)
                    {
                        DataTable table = ds.Tables[0];
                        txtTotalScroll.Text = Common.ConvertEx.ToString(table.Rows[0]["archiveCount"]);                 //案卷总卷数
                        txtCharacterScroll.Text = Common.ConvertEx.ToString(table.Rows[0]["wz"]);                       //文字 卷数  
                        txtPicScroll.Text = Common.ConvertEx.ToString(table.Rows[0]["tzz"]);                            //图纸 卷数      
                    }
                }
            }
        }

        /// <summary>
        /// 控制影藏或显示的TR
        /// </summary>
        /// <param name="startindex"></param>
        /// <param name="endindex"></param>
        protected void TableRowShow(int startindex, int endindex)
        {
            for (int i = startindex; i < endindex; i++)
            {
                Table1.Rows[i].Visible = false;
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            T_ReadyCheckBook_MDL readMDL = ViewState["objModel"] as T_ReadyCheckBook_MDL;
            if (readMDL == null)
                readMDL = new T_ReadyCheckBook_MDL();

            if (string.Compare(reportType, "zms", true) == 0)
            {
                readMDL.TOTAL_SCROLL = ConvertEx.ToInt(txtTotalScroll.Text);
                readMDL.CHARACTER_SCROLL = ConvertEx.ToInt(txtCharacterScroll.Text);
                readMDL.PIC_SCROLL = ConvertEx.ToInt(txtPicScroll.Text);
                readMDL.PHOTO_COUNT = ConvertEx.ToInt(txtPhotoPageCount.Text);
                readMDL.RADIO_COUNT = ConvertEx.ToInt(txtRadioCount.Text);
                readMDL.OTHER_MATERIAL = txtOtherMaterial.Text.Trim();
                readMDL.Directory_SCROLL = ConvertEx.ToInt(txtDirectoryScroll.Text);
                readMDL.Directory_PAGE_COUNT = ConvertEx.ToInt(txtDirectoryPage.Text);
            }
            if (string.Compare(reportType, "rkz", true) == 0)
            {
                readMDL.jsdwfzr_Name = jsdwfzr_Name.Text;
                readMDL.jsdwfzr_Tel = jsdwfzr_Tel.Text;
                readMDL.ArchiveUserName = ArchiveUserName.Text;
                readMDL.ArchiveUser_Tel = ArchiveUser_Tel.Text;
            }
            readMDL.ReadyCheckBookCode = ReadyCheckBookCode.Text.Trim();
            readMDL.SingleProjectID = ConvertEx.ToInt(singleProjectID);
            readMDL.EndDate = System.DateTime.Now;
            readMDL.BeginDate = System.DateTime.Now;
            readMDL.CreateTime = DateTime.Now;
            readMDL.CreateUserID = Common.Session.GetSessionInt("UserID");
            readMDL.CodeType = reportType;

            if (ViewState["objModel"] != null)
                readBLL.Update(readMDL);
            else
                readBLL.Add(readMDL);
            Common.MessageBox.CloseLayerOpenWeb(this.Page);
        }
    }
}