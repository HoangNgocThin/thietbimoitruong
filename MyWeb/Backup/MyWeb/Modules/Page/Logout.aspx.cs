using System;
using System.Web;
using System.Web.Security;
using MyWeb.Common;

namespace MyWeb.Modules.Page
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["FullName"] = string.Empty;
            Session["UserName"] = string.Empty;
            Session["IsAdmin"] = string.Empty;
            Session.Abandon();
            FormsAuthentication.SetAuthCookie(string.Empty, false);
            Response.Redirect("/");
        }
    }
}