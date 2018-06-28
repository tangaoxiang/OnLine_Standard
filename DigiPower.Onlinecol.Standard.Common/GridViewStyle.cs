using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace DigiPower.Onlinecol.Standard.Common
{
    public class GridViewStyle
    {
        public GridViewStyle()
        { }

        public static GridView SetGridviewStyle(GridView dv)
        { 
            //197 231 252
           // dv.SelectedRowStyle.
            dv.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(221, 241, 253);

            dv.GridLines = GridLines.Both;

            return dv;
        }
    }
}
