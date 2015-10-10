using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;

namespace MyWeb.Controls
{
    public partial class ucProductHome : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                LoadProduct();
            }
            
        }
        protected string Format_Price(string Price)
        {
            if (Price.Trim().Equals(""))
            {
                return "0";
            }
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
        private void LoadProduct() {
            List<Data.ProductCategory> listcate = new List<ProductCategory>();
            listcate = ProductCategoryService.ProductCategory_GetByTop("", "IsDisplayInHome=1", "Ord");

            if (listcate.Count > 0)
            {
                string strmain = "";
                string str = "";
                for (int j = 0; j < listcate.Count; j++)
                {
                    str = "";
                    List<Data.Product> list = new List<Product>();
                    list = ProductService.Product_GetByTop("8", "ProductCategoryID = " + listcate[j].ID, "ModifiedDate");
                    if (list.Count > 0)
                    {
                        str += "<div class='productList'>";
                        str += "<div class='productList_head'>";
                        str += "<span>" + listcate[j].Name + "</span>";
                        str += "</div>";
                        str += "<div class='productlist_main'>";
                        for (int i = 0; i < list.Count; i++)
                        {
                            if ((i % 4) == 0)
                            {
                                str += "<div class='productRow'>";
                            }
                            str += "<div class='product'>";
                            str += "<div class='p_img'>";
                            str += "<a href='/Product/" + list[i].ID + "/" + list[i].Tag + ".html'>";
                            str += "<img  src='" + list[i].Image + "' />";
                            str += "</a>";
                            str += "</div>";
                            str += "<div class='p_name'>";
                            str += "<a href='/Product/" + list[i].ID + "/" + list[i].Tag + ".html'>" + list[i].Name + "</a>";
                            str += "</div>";
                            str += "<div class='p_price'>";
                            str += "Giá: " + Format_Price(list[i].SalePrice) + " VND";
                            str += "</div>";
                            str += "<div class='p_cart'>";
                            str += "<a class='p_cart_a' href='/ShoppingCart/" + list[i].ID + "/" + list[i].Tag + ".html'>Đặt mua</a>";
                            str += "</div>";
                            str += "</div>";
                            if (((i + 1) % 4) == 0 && i != 0)
                            {
                                str += "<div class='clear'></div>";
                                str += "</div>";
                            }
                            else
                            {
                                if (i == (list.Count - 1))
                                {
                                    str += "<div class='clear'></div>";
                                    str += "</div>";
                                }
                            }
                        }
                        str += "</div>";
                        str += "</div>"; 
                    }
                    strmain += str;
                }
                ltrHome.Text = strmain;
            }
        }
    }
}