using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWeb.MyControls
{
    public partial class My_U_SearchKeyWord : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        {
            if (!txtkeyword.Text.Trim().Equals(""))
            {
                Session["keyword"] = txtkeyword.Text;
                Response.Redirect("/search.aspx");
            }
            else
            {
                Response.Redirect("/searchResult.aspx");
            }
        }
    }
}