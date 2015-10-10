using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;

namespace MyWeb.Modules.Products
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            show();
        }
        void show()
        {
            List<Data.Product> list = new List<Product>();
            list = ProductService.Product_GetByTop("", "Active=1", "ord DESC");
            string chuoi = "";
            int i = 0;
            for (i = 0; i < list.Count;i++)
            {
                
                if ((i + 1) % 3 == 0)
                {
                    chuoi += "<div class='dv_box_sp_clear'>\n";
                    chuoi += "<table>\n";
                    chuoi += "<tr>\n";
                    chuoi += "<td>\n";
                    chuoi += "<div class=dv_box_sp_img>\n";
                    chuoi += "<img src='" + list[i].Image + "'/>\n";
                    chuoi += "</div>\n";
                    chuoi += "<h5>" + list[i].Name + "</h5>\n";
                    chuoi += "</td>\n";
                    chuoi += "</tr>\n";
                    chuoi += "</table>\n";
                    chuoi += "</div>";
                    chuoi += "<div class='clear'></div>\n";
                    chuoi += "<div style='width:100%; border-top: 1px dotted #ddd; margin:10px 0px 10px 0px;'></div>";
                }
                else
                {
                    chuoi += "<div class='dv_box_sp'>\n";
                    chuoi += "<table>\n";
                    chuoi += "<tr>\n";
                    chuoi += "<td>\n";
                    chuoi += "<div class=dv_box_sp_img>\n";
                    chuoi += "<img src='" + list[i].Image + "'/>\n";
                    chuoi += "</div>\n";
                    chuoi += "<h5>" + list[i].Name + "</h5>\n";
                    chuoi += "</td>\n";
                    chuoi += "</tr>\n";
                    chuoi += "</table>\n";
                    chuoi += "</div>";
                }  
            }
            if ((i + 1) % 3 != 0)
            {
                chuoi += "<div class='clear'></div>\n";
            }
            Literal1.Text = chuoi;
        }
    }
}