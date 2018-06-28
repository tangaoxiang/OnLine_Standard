using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Configuration;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.BLL;
using Stimulsoft.Report;
using System.Data;
using Stimulsoft.Report.Web;

namespace DigiPower.Onlinecol.Standard.Web {
    public static class ReportPDF {
        /// <summary>
        /// 判断某个工程的下的报表PDF是否存在
        /// </summary>
        /// <param name="ids">工程ID</param>
        /// <param name="reportCode">报表类型</param>                                   
        /// <returns></returns>
        public static bool CheckExistsReportPDF(string ids, string reportCode) {
            bool extFlag = true;
            string pdfFileName = String.Concat(ids, "-", reportCode, ".pdf");
            if (!System.IO.File.Exists(HttpContext.Current.Server.MapPath("../Upload/TempReport/" + pdfFileName)))
                extFlag = false;

            return extFlag;
        }

        /// <summary>
        /// 根据工程ID 将报表导出PDF,注意:报表必须预先在T_Report做出记录    , 
        /// 新生成的报表PDF文件名: pdfFileName=String.Concat(SingleProjectID, "-", ReportCode, ".pdf"); 
        /// 报表PDF存放路径: Server.MapPath("../Upload/TempReport/" + pdfFileName
        /// </summary>
        /// <param name="ids">ids 工程id或案卷id</param>
        /// <param name="reportCode">报表类型</param>
        /// <param name="delOldReportPdf">是否删除已生成的PDF,删除则重新生成</param>
        /// <returns></returns>
        public static string ReportExportPDF(string ids, string reportCode, bool delOldReportPdf) {
            string pdfFileName = String.Concat(ids, "-", reportCode, ".pdf");
            try {
                if (System.IO.File.Exists(HttpContext.Current.Server.MapPath("../Upload/TempReport/" + pdfFileName))) {
                    if (delOldReportPdf)
                        System.IO.File.Delete(HttpContext.Current.Server.MapPath("../Upload/TempReport/" + pdfFileName));
                    else
                        return pdfFileName;
                }

                List<T_Report_MDL> ltReport = new T_Report_BLL().GetModelList("lower(ReportCode)='" + reportCode.ToLower() + "'");
                if (ltReport == null || ltReport.Count < 1)
                    return SystemSet._RETURN_FAILURE_VALUE + "报表数据不存在!";

                T_Report_MDL trMdl = ltReport[0];
                T_Report_Type_MDL trtMdl = new T_Report_Type_BLL().GetModel(Common.ConvertEx.ToInt(trMdl.ReportTypeID));
                if (trMdl == null || trtMdl == null)
                    return SystemSet._RETURN_FAILURE_VALUE + "报表数据不存在!";

                if (!Directory.Exists(HttpContext.Current.Server.MapPath("../ajax"))) //如果不用报表空间预先加载报表,必须先创建此目录
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("../ajax"));

                if (!Directory.Exists(HttpContext.Current.Server.MapPath("../Upload/TempReport/")))//存放报表PDF的临时目录
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("../Upload/TempReport/"));

                string reportPath = HttpContext.Current.Server.MapPath("../Report/ReportFiles/" + trtMdl.ReportTypeName + "/" + trMdl.ReportFilePath);
                if (System.IO.File.Exists(reportPath)) {
                    StiReport Report = new StiReport();
                    Report.Load(reportPath);//加载报表         

                    DataSet ds = new DataSet();
                    if (reportCode.ToLower() == "zrs") {
                        string strSql = "select a.*,b.ReadyCheckBookCode from T_SingleProject a inner join T_ReadyCheckBook b ";
                        strSql += "on a.SingleProjectID=b.SingleProjectID where a.SingleProjectID=" + ids + " ";
                        ds = new T_Other_BLL().GetDataSet(strSql);
                    } else if (reportCode.ToLower() == "rkz") {
                        string strSql = "select a.*,b.ReadyCheckBookCode from T_SingleProject a inner join T_ReadyCheckBook b ";
                        strSql += "on a.SingleProjectID=b.SingleProjectID where a.SingleProjectID=" + ids + " ";
                        ds = new T_Other_BLL().GetDataSet(strSql);
                    } else if (reportCode.ToLower() == "zms") {
                        string strSql = "select P.gcbm,P.jsdw,P.gcmc,P.ghxkzh,P.gcdd,P.sgxkzh,"
                          + " (CASE P.ProjectType WHEN 1 then P1.jzmj WHEN 2 THEN P2.jzmj WHEN 3 THEN '' END) AS JZMJ, "
                          + " (CASE P.ProjectType WHEN 1 then P1.gcjs WHEN 2 THEN P2.zjs WHEN 3 THEN '' END) AS gczj, "
                          + " P.kgsj,P.jgsj from T_SingleProject P "
                          + " LEFT JOIN a_single_project P1 ON P.SingleProjectID=P1.SingleProjectID"
                          + " LEFT JOIN b_single_project P2 ON P.SingleProjectID=p2.SingleProjectID"
                          + " WHERE P.SingleProjectID=" + ids;

                        T_Other_BLL otherBLL = new T_Other_BLL();
                        ds = otherBLL.GetDataSet(strSql);
                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0) {
                            ds.Tables[0].Columns.Add(new DataColumn("wzCount")); //文字卷数
                            ds.Tables[0].Columns.Add(new DataColumn("tzCount")); //图纸卷数                                               
                        }

                        ds = new T_Other_BLL().GetDataSet(strSql);
                    } else if (reportCode.ToLower() == "archivefengpi") {
                        string strSql = "SELECT DH,ShortDH,AJTM,BZDW,lrsj,zzsj,t_systeminfo.systeminfoname as sys_mj,sys2.systeminfoname as sys_bgqx,XH,";
                        strSql += "(SELECT COUNT(0) FROM T_Archive WHERE SINGLEPROJECTID=T_Archive.SINGLEPROJECTID) as jzcs, ";
                        strSql += "(select SUM(isnull(ManualCount,0)) from t_filelist where t_filelist.ArchiveID=T_Archive.ArchiveID)as TotalPageNums ";
                        strSql += "FROM T_Archive left join t_systeminfo on t_archive.mj=t_systeminfo.systeminfoid left join t_systeminfo sys2 ";
                        strSql += "on t_archive.bgqx=sys2.systeminfoid WHERE ARCHIVEID=" + ids;

                        ds = new T_Other_BLL().GetDataSet(strSql);
                    } else if (reportCode.ToLower() == "archivemulu") {
                        string strSql = "select (ROW_NUMBER() over (PARTITION by ArchiveID ORDER BY OrderIndex)) as RowID,archiveid, ";
                        strSql += "w_t_h,Title,zrr,lrsj,StartTime,PagesCount,ManualCount,yc ";
                        strSql += "from t_filelist where archiveid in(" + ids + ") Order by ArchiveID,OrderIndex asc ";
                        ds = new T_Other_BLL().GetDataSet(strSql);
                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0) {//重排页次
                            DataTable dt = ds.Tables[0];

                            int PageIndexCount = 1;
                            for (var i = 0; i < dt.Rows.Count; i++) {
                                if (i == 0) {
                                    dt.Rows[i]["PagesCount"] = PageIndexCount;
                                    dt.Rows[i]["yc"] = PageIndexCount;
                                } else {
                                    if ((i + 1) < dt.Rows.Count && ConvertEx.ToInt(dt.Rows[i]["archiveid"]) != ConvertEx.ToInt(dt.Rows[i - 1]["archiveid"])) {
                                        PageIndexCount = 1;
                                    } else {
                                        PageIndexCount += ConvertEx.ToInt(dt.Rows[i - 1]["ManualCount"]);
                                    }

                                    dt.Rows[i]["PagesCount"] = PageIndexCount;
                                    dt.Rows[i]["yc"] = PageIndexCount;

                                    if (((i + 1) < dt.Rows.Count && ConvertEx.ToInt(dt.Rows[i]["archiveid"]) != ConvertEx.ToInt(dt.Rows[i + 1]["archiveid"])) ||
                                        (i + 1) >= dt.Rows.Count) {
                                        int lastManualCount = ConvertEx.ToInt(dt.Rows[i]["ManualCount"]);//每个案卷中的最后一份文件页次都是 *-*格式
                                        if (lastManualCount > 1) {
                                            dt.Rows[i]["yc"] = string.Concat(ConvertEx.ToInt(dt.Rows[i]["PagesCount"]), "-",
                                                ConvertEx.ToInt(dt.Rows[i]["PagesCount"]) - 1 + lastManualCount);
                                        } else if (lastManualCount == 1) {
                                            dt.Rows[i]["yc"] = string.Concat(dt.Rows[i]["yc"], "-", dt.Rows[i]["yc"]);
                                        }
                                    }
                                }
                            }
                        }
                    } else if (reportCode.ToLower() == "juanneibeikao") {
                        string strSql = "select T_Archive.lrr,T_Archive.lrsj,T_Archive.shr,T_Archive.shsj,sum(isnull(manualcount,0)) wzz, ";
                        strSql += "sum(isnull(t_filelist.tzz,0)) tzz,sum(isnull(zpz,0)) zpz,T_Archive.note from t_filelist,T_Archive where ";
                        strSql += "t_filelist.ArchiveID=T_Archive.ArchiveID AND t_filelist.archiveid=" + ids + " group by  T_Archive.lrr,";
                        strSql += " T_Archive.shr,T_Archive.note,T_Archive.lrsj,T_Archive.shsj";

                        ds = new T_Other_BLL().GetDataSet(strSql);
                    } else if (reportCode.ToLower() == "printarchive") {
                        string strSql = "select w_t_h,Title,zrr,lrsj,StartTime,PagesCount from t_filelist where Status<>0 AND ";
                        strSql += "SingleProjectID=" + ids + " Order by bh ";

                        ds = new T_Other_BLL().GetDataSet(strSql);
                    }

                    if (ds != null && ds.Tables.Count > 0) {
                        Report.RegData("Report", ds);
                        Report.Render(false);
                        Report.ExportDocument(StiExportFormat.Pdf, HttpContext.Current.Server.MapPath("../Upload/TempReport/" + pdfFileName));
                    } else {
                        pdfFileName = SystemSet._RETURN_FAILURE_VALUE + "无数据,不用打印!";
                    }
                } else {
                    pdfFileName = SystemSet._RETURN_FAILURE_VALUE + "报表模板文件不存在!";
                }
            } catch (Exception ex) {
                pdfFileName = SystemSet._RETURN_FAILURE_VALUE + ex.Message;
            }
            return pdfFileName;
        }
    }
}