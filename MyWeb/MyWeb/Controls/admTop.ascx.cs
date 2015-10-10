using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Common;

namespace MyWeb.Controls
{
    public partial class admTop : System.Web.UI.UserControl
    {
        public static CookieClass Cookie = new CookieClass();
        private string Lang = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = Global.GetLang();
            if (!IsPostBack){
                string strLanguage = "";
                if (Lang == "en"){
                    strLanguage = "Tiếng Anh";
                }else{
                    strLanguage = "Tiếng Việt";
                }
                ltrLanguage.Text = string.Format("| &nbsp; Ngôn ngữ đang dùng: <b>{0}</b> &nbsp;", strLanguage);
            }
        }

        protected void ibtEn_Click(object sender, ImageClickEventArgs e)
        {
            Cookie.SetCookie("Lang", "en");
            Response.Redirect("/admin/");
        }

        protected void ibtVi_Click(object sender, ImageClickEventArgs e)
        {
            Cookie.SetCookie("Lang", "vi");
            Response.Redirect("/admin/");
        }
    }
}