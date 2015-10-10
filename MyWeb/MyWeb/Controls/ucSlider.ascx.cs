using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Business;

namespace MyWeb.Controls
{
    public partial class ucSlider : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAdvertisment();
            }
        }
        private void LoadAdvertisment()
        {
            List<Data.Advertise> list = new List<Data.Advertise>();
            list = AdvertiseService.Advertise_GetByTop("", "Active=1 and Position=2", "Ord");
            if (list.Count > 0)
            {
                string str = "";
                for (int i = 0; i < list.Count; i++)
                {                    
                    str += "<img src='" + list[i].Image + "'/>";
                    str += "<div class='SliderName_2Description'><strong>" + list[i].Content + "</strong></div>";
                }
                ltrslider.Text = str;
            }
        }
    }
}