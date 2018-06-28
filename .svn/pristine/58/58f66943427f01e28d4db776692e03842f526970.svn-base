using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace DigiPower.Onlinecol.Standard.CBLL
{
    public class ColorList
    {
        private Hashtable _colorList = new Hashtable();
        public ColorList()
        {
            BLL.T_SystemInfo_BLL bll = new DigiPower.Onlinecol.Standard.BLL.T_SystemInfo_BLL();
            DataSet ds1 = bll.GetList("CurrentType='118'");
            if (ds1.Tables.Count > 0)
            {
                foreach (DataRow row in ds1.Tables[0].Rows)
                {
                    _colorList.Add(row["SubType"], row["SystemInfoCode"]);
                }
            }
        }

        public System.Drawing.Color GetMyColor(string Status)
        {
            System.Drawing.Color outColor = System.Drawing.Color.White;
            foreach (DictionaryEntry obj in _colorList)
            {
                if (obj.Key.ToString().ToLower() == Status.ToLower())
                {
                    outColor = System.Drawing.Color.FromName(obj.Value.ToString());
                    break;
                }
            }

            return outColor;
        }

        public string GetMyColorString(string Status)
        {
            string outColor = "White";
            foreach (DictionaryEntry obj in _colorList)
            {
                if (obj.Key.ToString().ToLower() == Status.ToLower())
                {
                    outColor = obj.Value.ToString();
                    break;
                }
            }

            return outColor;
        }
    }
}