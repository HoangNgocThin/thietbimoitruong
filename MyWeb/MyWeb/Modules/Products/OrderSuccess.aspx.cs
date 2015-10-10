using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using MyWeb.Data;
using MyWeb.Business;

namespace MyWeb.Modules.Products
{
    public partial class OrderSuccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ltrMessage.Text = "Bạn đã đặt hàng thành công. Chúng tôi sẽ liên lạc với bạn trong thời gian sớm nhất. Xin cảm ơn!";
        }
    }
}