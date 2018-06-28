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

namespace DigiPower.Onlinecol.Standard.Web.CommonCtrl
{
    public partial class ctrlWorkFlowList_HTML : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //构造页面控件
            CreatePage();
        }

        /// <summary>
        /// 创建页面控件
        /// </summary>
        private void CreatePage()
        {
            string From = "Front";

            BLL.T_WorkFlow_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_WorkFlow_BLL();
            string RoleID = Common.Session.GetSession("RoleID");
            string UserID = Common.Session.GetSession("UserID");
            string Area_Code = string.Empty;// Common.Session.GetSession("Area_Code");  jdk 2014.05.06
            if (Common.ConvertEx.ToBool(Common.Session.GetSession("SuperAdmin")))
            {//Leo 超级管理员，可以看全部
                //RoleID = "";
                //From = "Back";// 超级管理看全部的
                Area_Code = Common.Session.GetSession("Area_Code");
            }
            else
            {
                Area_Code = Common.Session.GetSession("OLD_AREA_CODE");
            }

            DataSet ds = bll.GetWorkFlowList(RoleID, UserID, Area_Code);

            //对数据集按照父子关系排序
            DataTable dt = new DataTable();
            dt.Columns.Add("WorkFlowID");
            dt.Columns.Add("WorkFlowName");
            dt.Columns.Add("DetailCount");
            dt.Columns.Add("roleid");
            dt.Columns.Add("userid");

            //Leo
            dt.Columns.Add("UseForCompany");
            dt.Columns.Add("OrderIndex");
            dt.Columns.Add("UseForSuperAdmin");
            OrderDs(dt, ds, "0");

            //创建HTML表格            
            CreateTable(dt, From);
        }

        /// <summary>
        /// 创建HTML表格
        /// </summary>
        private void CreateTable(DataTable dt, string From)
        {
            this.tbl.Controls.Clear();
            //创建table
            HtmlTable tablehtml = new HtmlTable();
            tablehtml.Width = "100%";
            tablehtml.CellPadding = 2;
            tablehtml.CellSpacing = 2;

            tablehtml.Border = 0;
            //创建tablerow
            if (dt != null && dt.Rows.Count > 0)
            {
                int iNewTableRowCount = dt.Rows.Count / 5;

                if (dt.Rows.Count % 5 != 0)
                {
                    iNewTableRowCount++;
                }

                bool FirstRow = true;
                int count = 1;
                for (int k = 0; k < iNewTableRowCount; k++)
                {
                    if (k % 2 == 0)
                    {//奇数行
                        FirstRow = true;
                    }
                    else
                    {//偶数行
                        FirstRow = false;
                    }
                    count = AddTableRow(dt, tablehtml, iNewTableRowCount, count, From, FirstRow);

                    //是否有空单元格
                    bool flag = false;

                    for (int m = 0; m < tablehtml.Rows[tablehtml.Rows.Count - 1].Cells.Count; m++)
                    {
                        if (tablehtml.Rows[tablehtml.Rows.Count - 1].Cells[m].InnerHtml == "&nbsp;")
                        {
                            flag = true;
                        }
                    }

                    if (flag)
                    {
                        //删除多余标志
                        for (int m = 0; m < tablehtml.Rows[tablehtml.Rows.Count - 1].Cells.Count; m++)
                        {
                            if (tablehtml.Rows[tablehtml.Rows.Count - 1].Cells[m].InnerHtml != "&nbsp;")
                            {
                                tablehtml.Rows[tablehtml.Rows.Count - 1].Cells[m].InnerHtml = "&nbsp;";
                                break;
                            }
                        }
                    }

                    //添加转行标志
                    HtmlTableRow rowDown = new HtmlTableRow();
                    for (int m = 0; m < 9; m++)
                    {
                        HtmlTableCell cellDown = new HtmlTableCell();
                        cellDown.Align = "center";
                        if (FirstRow == true)
                        {
                            if (m != 8)
                            {
                                cellDown.InnerHtml = "&nbsp;";
                            }
                            else
                            {
                                cellDown.InnerHtml = "<img src='../images/jt3.png' />";
                            }
                        }
                        else
                        {
                            if (m != 0)
                            {
                                cellDown.InnerHtml = "&nbsp;";
                            }
                            else
                            {
                                cellDown.InnerHtml = "<img src='../images/jt3.png' />";
                            }
                        }
                        rowDown.Cells.Add(cellDown);
                    }
                    tablehtml.Rows.Add(rowDown);
                }

                //如果最后一行是转行图标则删除最后一行
                if (tablehtml.Rows[tablehtml.Rows.Count - 1].Cells.Count != 0)
                {
                    if (tablehtml.Rows[tablehtml.Rows.Count - 1].Cells[1].InnerHtml == "&nbsp;" || tablehtml.Rows[tablehtml.Rows.Count - 1].Cells[7].InnerHtml == "&nbsp;")
                    {
                        tablehtml.Rows.Remove(tablehtml.Rows[tablehtml.Rows.Count - 1]);
                    }
                }
            }
            this.tbl.Controls.Add(tablehtml);
        }

        private int AddTableRow(DataTable dt, HtmlTable tablehtml, int iNewTableRowCount, int count, string From, bool FirstRow)
        {
            HtmlTableRow rowhtml = new HtmlTableRow();

            int CellCount = count % 5;

            for (int i = 0; i < 5; i++)
            {
                if (count <= dt.Rows.Count)
                {
                    //创建tablecell
                    HtmlTableCell cellFlow = new HtmlTableCell();

                    cellFlow.Align = "center";
                    string disable = "";
                    if (From == "Front")
                    {//Leo 前台才有权限，后台要显示全部流程
                        disable = GetEnabled(dt.Rows[count - 1]);
                    }
                    if (disable != "" || Common.Session.GetSessionBool("IsCompany") == true)
                    {
                        cellFlow.InnerHtml = "<input name='button'" + disable + " type='button' class='lc_btn' id='" +
                            dt.Rows[count - 1]["WorkFlowID"] + "' value='" +
                            dt.Rows[count - 1]["WorkFlowName"] + "' onclick=\"Btn_Click('" + dt.Rows[count - 1]["WorkFlowName"] + "'," +
                            dt.Rows[count - 1]["WorkFlowID"] + ")\"/>";
                    }
                    else
                    {
                        cellFlow.InnerHtml = "<input name='button'" + disable + " type='button' class='lc_btn' id='" + 
                            dt.Rows[count - 1]["WorkFlowID"] + "' value='" +
                            dt.Rows[count - 1]["WorkFlowName"] + "(" + dt.Rows[count - 1][2] + ")' onclick=\"Btn_Click('" + dt.Rows[count - 1]["WorkFlowName"] + "'," + 
                            dt.Rows[count - 1]["WorkFlowID"] + ")\" />";
                    }
                    rowhtml.Cells.Add(cellFlow);
                    if (count % 5 != 0 || count == 1)
                    {
                        //如果不是最后一格则加图标
                        HtmlTableCell cellImage = new HtmlTableCell();
                        cellImage.Align = "center";
                        string PicName = "jt.png";
                        if (FirstRow == false)
                        {
                            PicName = "jt2.png";
                        }
                        cellImage.InnerHtml = "<img src='../images/" + PicName + "' width='28' height='19' />";
                        rowhtml.Cells.Add(cellImage);
                    }

                    count++;
                }
            }

            if (FirstRow == false)
            {
                //补充空单元格
                if (rowhtml.Cells.Count < 9)
                {
                    int nbsp = 9 - rowhtml.Cells.Count;

                    for (int nb = 0; nb < nbsp; nb++)
                    {
                        HtmlTableCell cellNbsp = new HtmlTableCell();
                        cellNbsp.Align = "center";
                        cellNbsp.InnerHtml = "&nbsp;";
                        rowhtml.Cells.Add(cellNbsp);
                    }
                }

                //对当前行进行倒序
                for (int n = 0; n < rowhtml.Cells.Count; n++)
                {
                    if (rowhtml.Cells.Count - (n + 1) == n)
                    {
                        break;
                    }
                    HtmlTableCell cell = new HtmlTableCell();
                    cell.Align = rowhtml.Cells[n].Align;
                    cell.InnerHtml = rowhtml.Cells[n].InnerHtml;
                    rowhtml.Cells[n].InnerHtml = rowhtml.Cells[rowhtml.Cells.Count - (n + 1)].InnerHtml;
                    rowhtml.Cells[rowhtml.Cells.Count - (n + 1)].InnerHtml = cell.InnerHtml;
                }
            }
            tablehtml.Rows.Add(rowhtml);
            return count;
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="ds"></param>
        private void OrderDs(DataTable dt, DataSet ds, string PID)
        {
            DataRow dtr = dt.NewRow();
            DataRow[] dsr = ds.Tables[0].Select("PID = '" + PID + "'");
            if (dsr != null && dsr.Length > 0)
            {
                dtr[0] = dsr[0]["WorkFlowID"].ToString();

                dtr[1] = dsr[0]["WorkFlowName"].ToString();
                dtr[2] = dsr[0]["detailcount"].ToString();
                dtr[3] = dsr[0]["roleid"].ToString();
                dtr[4] = dsr[0]["userid"].ToString();
                dtr[5] = dsr[0]["UseForCompany"].ToString();
                dtr[6] = dsr[0]["OrderIndex"].ToString();
                dtr[7] = dsr[0]["UseForSuperAdmin"].ToString();
                dt.Rows.Add(dtr);
                OrderDs(dt, ds, dsr[0][0].ToString());
            }
        }

        private string GetEnabled(DataRow dr)
        {//按钮权限控件
            string disable = "";
            bool UseForCompany = Common.ConvertEx.ToBool(dr["UseForCompany"].ToString());
            bool useForSuperAdmin = Common.ConvertEx.ToBool(dr["UseForSuperAdmin"].ToString());
            string RoleID = Common.ConvertEx.ToString(dr["RoleID"].ToString());
            string UserID = Common.ConvertEx.ToString(dr["UserID"].ToString());
            if (UseForCompany == true && Common.ConvertEx.ToBool(Common.Session.GetSession("IsCompany")) == true)
            {
            }
            else if (Common.Session.GetSessionBool("IsCompany") == false)
            {
            }
            else
            {//除以上情况，都不可用
                disable = "disabled='disabled'";
            }
            if (RoleID != "0" && RoleID != "" && Common.ConvertEx.ToBool(Common.Session.GetSession("IsCompany")) == false)
            {//指定了用户的,档案馆需要再查一次权限
                if (UserID != "0" && UserID != "")
                {
                    if (UserID == Common.Session.GetSession("UserID"))
                    {
                    }
                    else if (RoleID == Common.Session.GetSession("RoleID"))
                    { 
                    }
                    else
                    {
                        disable = "disabled='disabled'";
                    }
                }
                //else
                //{
                //    if (RoleID == Common.Session.GetSession("RoleID"))
                //    {
                //    }
                //    else
                //    {
                //        disable = "disabled='disabled'";
                //    }
                //}
            }
            if (useForSuperAdmin && Common.ConvertEx.ToBool(Common.Session.GetSession("SuperAdmin")))
            {
                disable = "";
            }
            return disable;
        }
    }
}