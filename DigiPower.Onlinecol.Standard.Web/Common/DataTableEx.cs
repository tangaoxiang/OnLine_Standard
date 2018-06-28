using System;
using System.Collections.Generic;
using System.Web;
using System.Data;

namespace DigiPower.Onlinecol.Standard.Web
{
    public static class DataTableEx
    {
        public static DataTable AddDataTableRowNO(DataTable srcTable)
        {
            System.Data.DataTable dstntnTable = new System.Data.DataTable();
            dstntnTable.Columns.Add("RowNO", typeof(Int32));
            for (int i = 0; i < srcTable.Columns.Count; i++)
                dstntnTable.Columns.Add(srcTable.Columns[i].ColumnName, srcTable.Columns[i].DataType);
            int srcColCount = srcTable.Columns.Count;
            int srcRowCount = srcTable.Rows.Count;
            int dstntnRowCount = 0;
            for (int j = 0; j < srcRowCount; j++)
            {
                DataRow newRow = dstntnTable.NewRow();
                newRow[0] = (++dstntnRowCount);
                for (int k = 0; k < srcColCount; k++)
                    newRow[k + 1] = srcTable.Rows[j][k];
                dstntnTable.Rows.Add(newRow);
            }
            return dstntnTable;
        }
    }
}