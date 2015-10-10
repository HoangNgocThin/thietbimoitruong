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
    public partial class My_U_Promotional : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            showlist();
        }
        protected string Format_Price(string Price)
        {
            Price = Price.Replace(".", "");
            Price = Price.Replace(",", "");
            string tmp = "";
            while (Price.Length > 3)
            {
                tmp = "." + Price.Substring(Price.Length - 3) + tmp;
                Price = Price.Substring(0, Price.Length - 3);
            }
            tmp = Price + tmp;
            return tmp;
        }
        void showlist()
        {
            List<Data.Product> list = new List<Product>();
            list = ProductService.Product_GetByTop("10", "Active=1", "");
            string chuoi = "";
            chuoi += "<MARQUEE class=SmallText onmouseover=this.stop() onmouseout=this.start() scrollAmount=3 direction=up  height='300' align=center>";
            if (list.Count > 0)
            {

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (!list[i].PiceOld.Trim().Equals(""))
                        {
                            chuoi += "<div class='dv_km_img'>";
                            chuoi += "<a href='/Products/" + list[i].CatId + "/" + list[i].Id + "/" + list[i].Tag + ".aspx'><img alt='" + list[i].Tag + "' src='" + list[i].Image + "' /></a>";
                            chuoi += "<div class='dv_km_price'>";
                            chuoi += "<span> Giá : " + Format_Price(list[i].Price.ToString()) + " VND"+"</span>";
                            chuoi += "</div>";
                            chuoi += "</div>"; 
                        }
                    } 
                
            }
            chuoi += "</marquee>";
            ltrpromotions.Text = chuoi;
        }
    }
}