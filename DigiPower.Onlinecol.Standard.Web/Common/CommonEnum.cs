using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace DigiPower.Onlinecol.Standard.Web
{
    public class CommonEnum
    {
        public enum PageState
        {
            ADD,
            EDIT,
            DELETE,
            VIEW,
            CHECK
        }

        //public enum SingleProjectStatus
        //{
        //    NoDo,//未处理
        //    RegFileInfo,
        //    Posted,
        //    UnPosted
        //}
    }
}
