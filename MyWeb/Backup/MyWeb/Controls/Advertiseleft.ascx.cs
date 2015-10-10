using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Business;
namespace MyWeb.Controls
{
    public partial class Advertiseleft : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            showadvleft();
        }
        void showadvleft()
        {
            List<Data.Advertise> list = AdvertiseService.Advertise_GetByPosition("8", "vi");
            String advleft = "";
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    advleft += "<div class=\"advleft\">";
                    advleft +=String.Format("<a href=\"0\" title=\"2\"><img src=\"{1}\"/></a>",list[0].Link,list[0].Image,list[0].Name);
                    advleft += "</div>";
                }
            }
            ltladvleft.Text = advleft;
        }
    }
}