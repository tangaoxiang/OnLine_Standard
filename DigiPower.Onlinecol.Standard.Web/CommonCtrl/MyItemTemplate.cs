using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace DigiPower.Onlinecol.Standard.Web.CommonCtrl
{
    public class MyItemTemplate : ITemplate
    {
        public delegate void EventHandler(object sender, EventArgs e);

        public event EventHandler eh;

        private DataControlRowType templateType;

        private string columnName;

        private string controlID;

        public  MyItemTemplate(DataControlRowType type, string colname)
        {

            templateType = type;

            columnName = colname;

        }

        public MyItemTemplate(DataControlRowType type, string controlID, string colname)
        {

            templateType = type;

            this.controlID = controlID;

            columnName = colname;

        }

        public void InstantiateIn(System.Web.UI.Control container)
        {

            switch (templateType)
            {

                case DataControlRowType.Header:

                    Literal lc = new Literal();

                    lc.Text = columnName;

                    container.Controls.Add(lc);

                    break;

                case DataControlRowType.DataRow:

                    HyperLink lbtn = new HyperLink();

                    lbtn.ID = this.controlID;
                    lbtn.Text = columnName;

                    if (eh != null)
                    {

                        //lbtn.Click += new System.EventHandler(eh);

                    }

                    //lbtn.DataBinding += new System.EventHandler(lbtn_DataBinding);

                    container.Controls.Add(lbtn);

                    break;

                default:

                    break;

            }

        }

        void lbtn_DataBinding(object sender, EventArgs e)
        {

            LinkButton lbtn = sender as LinkButton;

            if (lbtn != null)
            {

                GridViewRow container = lbtn.NamingContainer as GridViewRow;

                if (container != null)
                {

                    object dataValue = DataBinder.Eval(container.DataItem, columnName);

                    if (dataValue != DBNull.Value)
                    {

                        lbtn.Text = dataValue.ToString();

                    }

                }

            }
        }

    }
}