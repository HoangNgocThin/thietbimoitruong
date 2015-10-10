using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWeb.Controls
{
    public partial class Right : System.Web.UI.UserControl
    {
        private string Lang ="";
        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = Global.GetLang();
            if (!IsPostBack)
            {
                ltrAdv.Text = Business.AdvertiseService.Advertise_ViewByPosition("7", Lang);
            }
        }
    }
}