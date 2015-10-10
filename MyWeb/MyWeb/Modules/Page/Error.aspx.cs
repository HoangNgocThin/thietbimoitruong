using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWeb.Modules.Page
{
    public partial class Error : System.Web.UI.Page
    {
        public string strThongtin = "";
        string strRequest = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            strRequest = Request.QueryString["error"];
            Literal ltrNav = (Literal)Common.PageHelper.FindControl(this.Master, "ltrNavContent");
            ltrNav.Text = "Thông báo lỗi";
            if (strRequest == "authentication")
            {
                strRequest = "Bạn không có quyền hoặc phiên đăng nhập đã hết, bạn phải đăng nhập lại. ";
                strRequest = strRequest + "<br><br> Click <a href='/Logon.aspx'> vào đây</a> nếu muốn đăng nhập lại.";
            }
            ltrMessage.Text = strRequest;
        }
    }
}