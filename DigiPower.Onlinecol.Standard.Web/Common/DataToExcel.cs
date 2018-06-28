using System;
using System.Diagnostics;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using System.Collections.Generic;

namespace DigiPower.Onlinecol.Standard.Web
{
    public static class ExcelHelp
    {
        /// <summary>
        /// �����µ� DataTable
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="ht"></param>
        /// <param name="isAddIndexNo">�Ƿ����������</param>
        public static DataTable NewDataTable(DataTable dtSource, Dictionary<string, string> dic, bool isAddIndexNo = false) {
            if (dtSource != null && dic.Count > 0) {
                DataTable newSource = new DataTable();
                if (isAddIndexNo)
                    newSource.Columns.Add("���");

                foreach (var de in dic) {
                    newSource.Columns.Add(de.Value.Trim());
                }

                var index = 0;
                foreach (DataRow drSourceRow in dtSource.Rows) {
                    index++;
                    DataRow drNewRow = newSource.NewRow();
                    foreach (var de in dic) {
                        if (dtSource.Columns.Contains(de.Key.Trim())) {
                            drNewRow[de.Value.Trim()] = drSourceRow[de.Key.Trim()];
                        }
                    }
                    if (isAddIndexNo) {
                        drNewRow["���"] = index;
                    }
                    newSource.Rows.Add(drNewRow);
                }
                return newSource;
            }
            return null;
        }

        /// <summary>
        /// DataTable������Excel�ļ�
        /// </summary>
        /// <param name="dtSource">ԴDataTable</param>     
        public static string DataTableToExcel(DataTable dtSource) {
            try {
                if (dtSource == null || dtSource.Rows.Count < 1)
                    return SystemSet._RETURN_FAILURE_VALUE + "Դ����Ϊ��!";

                HSSFWorkbook workbook = new HSSFWorkbook();
                HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet();

                //����ͷ
                HSSFRow dataRow = (HSSFRow)sheet.CreateRow(0);
                foreach (DataColumn column in dtSource.Columns) {
                    dataRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                }
                //�������
                for (int i = 0; i < dtSource.Rows.Count; i++) {
                    dataRow = (HSSFRow)sheet.CreateRow(i + 1);
                    for (int j = 0; j < dtSource.Columns.Count; j++) {
                        dataRow.CreateCell(j).SetCellValue(dtSource.Rows[i][j].ToString());
                    }
                }
                string strFileName = Guid.NewGuid().ToString() + ".xls";
                //����
                using (MemoryStream ms = new MemoryStream()) {
                    using (FileStream fs = new FileStream(HttpContext.Current.Server.MapPath("../Upload/TempReport/" + strFileName),
                        FileMode.Create, FileAccess.Write)) {
                        workbook.Write(fs);
                    }
                }
                return strFileName;
            }
            catch (Exception ex) {
                return SystemSet._RETURN_FAILURE_VALUE + ex.Message;
            }
        }
    }
}
