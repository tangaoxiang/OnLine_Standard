using System;
using System.Data;
using System.Collections.Generic;


namespace Digi.DG.BLL
{
    public class PageCtrl
    {
        DigiPower.Onlinecol.Standard.DAL.PageCtrl dal = new DigiPower.Onlinecol.Standard.DAL.PageCtrl();

        public PageCtrl()
        { 
        
        }

        public DataSet GetPage(string TableName, string FieldList, string PrimaryKey, string Sqlwhere, string Order, int index, int PageSize, ref int TotalCount, ref int TotalPageCount)
        {
            return dal.GetPage(TableName, FieldList, PrimaryKey, Sqlwhere, Order, index, PageSize, ref TotalCount, ref TotalPageCount);
        }

    }
}
