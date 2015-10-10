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
    public partial class My_U_Link : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            showlist();
        }
        void showlist()
        {
            List<Data.Advertise> list = new List<Advertise>();
            list = AdvertiseService.Advertise_GetByTop("10","Position=3 and Active=1 and Lang='vi'","");
            string chuoi = "";
            chuoi += "<div id='dv_link'>";
            chuoi += "<div class='dv_top1'>";
            chuoi += "<span>Website link</span>";
            chuoi += "</div>";
            chuoi += "<div class='dv_middle1'>";
            if (list.Count > 0)
            {
                chuoi += "<table cellpadding='0' cellspacing='0'>\n";
                chuoi += "<tr>\n";
                int i;
                for (i = 0; i < list.Count; i++)
                {
                    chuoi += "<td align='center'>\n";
                    chuoi += "<div class='dv_link_img'>\n";
                    chuoi += "<a href='"+list[i].Link+"'><img src='"+list[i].Image+"' /></a>";
                    chuoi += "</div>\n";
                    chuoi += "</td>\n";
                    if ((i + 1) % 2 == 0)
                    {
                        chuoi += "</tr>\n";
                        chuoi += "<tr>\n";
                    }
                }
                if (i % 2 != 0)
                {
                    chuoi += "<td></td>\n</tr>\n";
                }
                chuoi += "</table>\n";
            }
            chuoi += "</div>";
            chuoi += "</div>";
            ltrlink.Text = chuoi;
        }
    }
}