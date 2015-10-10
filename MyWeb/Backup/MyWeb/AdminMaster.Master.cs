using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;
using MyWeb.Common;

namespace MyWeb
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Lang"] == null)
            {
                Session["Lang"] = Global.LangDefault;
            }
            if (Page.User.Identity.Name == null || Page.User.Identity.Name == "")
            {
                GlobalClass.ErrorMessage("authentication");
            }
            else
            {
                if (Session["UserName"] == null || Session["UserName"].ToString() == "")
                {
                    List<User> list = new List<User>();
                    list = UserService.User_GetByUsername(Page.User.Identity.Name);
                    if (list.Count > 0)
                    {
                        Session["FullName"] = list[0].Name.Trim();
                        Session["UserName"] = list[0].Username.Trim();
                        Session["IsAdmin"] = list[0].Admin;
                    }
                }
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            int i = 1;
            string JavaScript = "";
            while (i <= 10)
            {
                if (Session["currentPanel"] != null && Session["currentPanel"].ToString() == "div" + i)
                {
                }
                else
                {
                    JavaScript = JavaScript + "<script type=\"text/javascript\"> toggleXPMenu('div" + i + "'); </script>";
                }
                i++;
            }
            //ltrJavaScript.Text = JavaScript;
        }
    }
}