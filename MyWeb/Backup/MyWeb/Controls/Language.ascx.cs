using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Common;
namespace MyWeb.Controls
{
    public partial class Language : System.Web.UI.UserControl
    {
        public static CookieClass Cookie = new CookieClass();
        private string Lang = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = Global.GetLang();
            //if (Lang == Global.LangDefault)
            //{
            //    this.lbtVi.CssClass = "select";
            //}
            //else
            //{
            //    this.lbtEn.CssClass = "select";
            //}
        }

        protected void lbtVi_Click(object sender, EventArgs e)
        {
            Cookie.SetCookie("Lang", "vi");
            Response.Redirect("/");
        }

        protected void lbtEn_Click(object sender, EventArgs e)
        {
            Cookie.SetCookie("Lang", "en");
            Response.Redirect("/");
        }
    }
}