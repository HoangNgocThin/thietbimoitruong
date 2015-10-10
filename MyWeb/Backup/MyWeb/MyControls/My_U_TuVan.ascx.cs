using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;

namespace MyWeb.MyControls
{
    public partial class My_U_TuVan : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            showlist();
        }
        void showlist()
        {
            List<Data.Support> list = new List<Support>();
            list = SupportService.Support_GetByTop("10000", "Type=1 and Active=1", "");
            string chuoi = "";
            chuoi += "<div id='dv_support'>";
            chuoi += "<div id='dv_topsupport'>";
            chuoi += "<div class='dv_top1'>";
            chuoi += "<span>Tư vấn trực tuyến</span>";
            chuoi += "<div id='dv_new'>";
            chuoi += "<img src='/../App_Themes/Default/img/img_news.png' />";
            chuoi += "</div>";
            chuoi += "</div>";
            chuoi += "</div>";
            chuoi += "<div class='dv_middle1'>";
            if (list.Count>0)
            {
                chuoi += "<table cellpadding='0' cellspacing='0'>\n";
                chuoi += "<tr>\n";
                int i;
                for (i = 0; i < list.Count; i++)
                {
                    chuoi += "<td align='center'>\n";
                    chuoi += "<div class='dv_tuvan'>\n";
                    chuoi += "<ul>\n";
                    chuoi += String.Format("<li><a href='ymsgr:sendim?{0}" + "'><img src=\"http://opi.yahoo.com/online?u={0}&m=g&t=1\" border=0></a></li>\n",list[i].Nick);
                    chuoi += "<li><a href='ymsgr:sendim?" + list[i].Nick + "'>" + list[i].Name + "</a></li>\n";
                    chuoi += "<li>(" + LoadLocation (list[i].Location)+ ")</li>";
                    chuoi += "<li>Tel: <span>" +list[i].Tel + "</span></li>\n";
                    chuoi += "</ul>\n";
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
            ltrtuvan.Text = chuoi;
        }
        private string LoadLocation(string ma)
        {
            string location = "";
            if (ma.Trim().Equals("0"))
            {
                location = "Miền bắc";
            }
            else if(ma.Trim().Equals("1"))
            {
                location = "Miền nam";
            }
            return location;
        }
    }
}