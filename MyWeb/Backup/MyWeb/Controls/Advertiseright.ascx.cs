using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Business;
namespace MyWeb.Controls
{
    public partial class Advertiseright : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Data.Advertise> list = AdvertiseService.Advertise_GetByPosition("9", "vi");
            String advright = "";
            advright += "<div class=\"nav\">Quảng cáo</div>";
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    advright += "<div class=\"advright\">";
                    advright += String.Format("<a href=\"0\" title=\"2\"><img src=\"{1}\"/></a>", list[0].Link, list[0].Image, list[0].Name);
                    advright += "</div>";
                }
            }
            ltladvright.Text = advright;
        }
    }
}