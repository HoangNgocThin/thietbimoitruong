using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Business;
using MyWeb.Data;

namespace MyWeb.MyControls
{
    public partial class My_U_Slide : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           showlist();
        }
        void showlist()
        {
            List<Data.Advertise> list = new List<Advertise>();
            list = AdvertiseService.Advertise_GetByPosition("4","vi");
            string chuoi = "";
            if(list.Count>0)
            {
                chuoi += "<div id='rotator'>\n";
                chuoi += "<ul>\n";
                for (int i = 0; i < list.Count;i++)
                {
                    if (i % list.Count == 0)
                    {
                        chuoi += "<li class='show'><a href='"+list[i].Link+"'><img src='" + list[i].Image + "' /></a></li>\n";
                    }
                    else
                    {
                        chuoi += "<li><a href='"+list[i].Link+"'><img src='" + list[i].Image + "'/></a></li>\n";
                    }
                   // chuoi += "<li><a href='#'><img src='" + list[i].Image + "'/></a></li>\n";
                }
                chuoi += "</ul>\n";
                chuoi += "</div>\n";
                chuoi += "<div class='clear'></div>";
            }
            
            ltrslide.Text = chuoi;
        }
    }
}