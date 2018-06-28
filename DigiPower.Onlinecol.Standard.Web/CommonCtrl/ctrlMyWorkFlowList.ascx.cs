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
    public partial class ctrlMyWorkFlowList : System.Web.UI.UserControl
    {
        public delegate void FlowClick();
        public event FlowClick MyFlowClick;

        #region 属性
        public string MyID
        {
            get { return hdId.Value; }
            set { hdId.Value = value; }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (hdSingleProjectID.Value != "")
            {
                CreatePage(hdSingleProjectID.Value);
            }
        }
        /// <summary>
        /// 创建页面控件
        /// </summary>
        public void CreatePage(string SingleProjectID)
        {
            hdSingleProjectID.Value = SingleProjectID;
            BLL.T_WorkFlowDefine_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_WorkFlowDefine_BLL();
            DataSet ds = bll.GetList("SingleProjectID=" + SingleProjectID);
            //对数据集按照父子关系排序
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            dt.Columns.Add("Del");
            OrderDs(dt, ds, "0");
            //创建HTML表格
            CreateTable(dt);
        }

        /// <summary>
        /// 创建HTML表格
        /// </summary>
        private void CreateTable(DataTable dt)
        {
            this.tbl.Controls.Clear();
            //创建table
            HtmlTable tablehtml = new HtmlTable();
            tablehtml.Width = "100%";
            tablehtml.CellPadding = 0;
            tablehtml.CellSpacing = 0;
            tablehtml.Border = 0;
            //创建tablerow
            if (dt != null && dt.Rows.Count > 0)
            {
                int TableCount = dt.Rows.Count / 5;
                if (dt.Rows.Count % 5 != 0)
                {
                    TableCount++;
                }
                int count = 1;
                for (int k = 0; k < TableCount; k++)
                {
                    if (k % 2 == 0)
                    {
                        //单行
                        count = TableAsc(dt, tablehtml, TableCount, count);
                        //删除多余标志
                        for (int m = 0; m < tablehtml.Rows[tablehtml.Rows.Count - 1].Cells.Count; m++)
                        {
                            if (tablehtml.Rows[tablehtml.Rows.Count - 1].Cells.Count < 9 && m != 0)
                            {
                                tablehtml.Rows[tablehtml.Rows.Count - 1].Cells[tablehtml.Rows[tablehtml.Rows.Count - 1].Cells.Count - 1].InnerHtml = "&nbsp;";
                                break;
                            }
                        }
                        //添加转行标志
                        HtmlTableRow rowDown = new HtmlTableRow();
                        for (int m = 0; m < 9; m++)
                        {
                            HtmlTableCell cellDown = new HtmlTableCell();
                            cellDown.Align = "center";
                            if (m != 8)
                            {
                                cellDown.InnerHtml = "&nbsp;";
                            }
                            else
                            {
                                cellDown.InnerHtml = "<img src='../images/jt3.png' style='text-align:center' />";                                
                            }
                            rowDown.Cells.Add(cellDown);
                        }
                        tablehtml.Rows.Add(rowDown);
                    }
                    else
                    {
                        //双行
                        count = TableDesc(dt, tablehtml, TableCount, count);
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
                            if (m != 0)
                            {
                                cellDown.InnerHtml = "&nbsp;";
                            }
                            else
                            {
                                cellDown.InnerHtml = "<img src='../images/jt3.png' style='text-align:center' />";
                            }
                            rowDown.Cells.Add(cellDown);
                        }
                        tablehtml.Rows.Add(rowDown);
                    }
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

        /// <summary>
        /// 单行
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="tablehtml"></param>
        /// <param name="TableCount"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        private int TableAsc(DataTable dt, HtmlTable tablehtml, int TableCount, int count)
        {
            HtmlTableRow rowhtml = new HtmlTableRow();

            for (int i = 0; i < 5; i++)
            {
                if (count <= dt.Rows.Count)
                {
                    //创建tablecell
                    HtmlTableCell cellFlow = new HtmlTableCell();
                    string DeleteFlag = "";
                    if (Common.ConvertEx.ToBool(dt.Rows[count - 1]["Del"]) == true)
                    {
                        DeleteFlag = "(忽略)";
                    }

                    cellFlow.Align = "center";
                    cellFlow.InnerHtml = "<input name='button' type='button' class='lc_btn' id='" + dt.Rows[count - 1]["ID"] + "' value='" + dt.Rows[count - 1]["Name"] + DeleteFlag + "' onclick='return Btn_Click(this)' />";
                    rowhtml.Cells.Add(cellFlow);
                    if (count % 5 != 0 || count == 1)
                    {
                        //如果不是最后一格则加图标
                        HtmlTableCell cellImage = new HtmlTableCell();
                        cellImage.Align = "center";
                        cellImage.InnerHtml = "<img src='../images/jt.png' width='28' height='19' />";
                        rowhtml.Cells.Add(cellImage);
                    }
                    count++;
                }
                int curryCellCount = rowhtml.Cells.Count;
                tablehtml.Rows.Add(rowhtml);
            }
            return count;
        }

        /// <summary>
        /// 双行
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="tablehtml"></param>
        /// <param name="TableCount"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        private int TableDesc(DataTable dt, HtmlTable tablehtml, int TableCount, int count)
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
                    string DeleteFlag = "";
                    if (Common.ConvertEx.ToBool(dt.Rows[count - 1]["Del"]) == true)
                    {
                        DeleteFlag = "(忽略)";
                    }
                    cellFlow.InnerHtml = "<input name='button' type='button' class='lc_btn' id='" + dt.Rows[count - 1]["ID"] + "' value='" + dt.Rows[count - 1]["Name"] + DeleteFlag + "' onclick='return Btn_Click(this)' />";
                    rowhtml.Cells.Add(cellFlow);
                    if (count % 5 != 0 || count == 1)
                    {
                        //如果不是最后一格则加图标
                        HtmlTableCell cellImage = new HtmlTableCell();
                        cellImage.Align = "center";
                        cellImage.InnerHtml = "<img src='../images/jt2.png' width='28' height='19' />";
                        rowhtml.Cells.Add(cellImage);
                    }
                    count++;
                }
            }

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
                dtr[0] = dsr[0]["WorkFlowDefineID"].ToString().Trim();
                dtr[1] = dsr[0]["WorkFlowName"].ToString().Trim();
                dtr["Del"] = dsr[0]["Del"].ToString().Trim();
                dt.Rows.Add(dtr);
                OrderDs(dt, ds, dsr[0]["WorkFlowID"].ToString().Trim());
            }
        }
        protected void btn_Click(object sender, EventArgs e)
        {
            if (MyFlowClick != null)
            {
                MyFlowClick();
            }
        }
    }
}