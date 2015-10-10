using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Business;
using MyWeb.Data;

namespace MyWeb.Modules.Products
{
    public partial class ProductBySearch : System.Web.UI.Page
    {
        string currentPage = "1";
        string cateId = "";
        string catetag = "";
        int PageCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Page.RouteData.Values["currentPage"] != null)
            {
                currentPage = Page.RouteData.Values["currentPage"].ToString();
            }
            if(!IsPostBack){
                LoadProduct(currentPage, "12");
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
        private void LoadProduct(string current, string pageSize)
        {
            string strWhere = "";
            if (Session["ProductName"] != null)
            {
                strWhere = " Name like N'%" + Session["ProductName"].ToString()+ "%' ";
            }

            List<Data.Product> list = new List<Data.Product>();

            list = ProductService.Product_Paging_Where(current, pageSize, strWhere);
            if (list.Count > 0)
            {

                PageCount = int.Parse(list[0].PageCount);
                BuildPaging();
                string str = "";
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
                    str += "<a class='p_cart_a' href='/ShoppingCart.html'>Đặt mua</a>";
                    str += "</div>";
                    str += "</div>";
                    if (((i+1) % 4) == 0 && i != 0)
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
                ltrProduct.Text = str;
            }
        }
        private void BuildPaging()
        {
            string chuoi = "";
            chuoi += "<ul>";
            if (PageCount > 12)
            {
                if ((PageCount) % 12 == 0)
                {
                    if (Int32.Parse(currentPage) == 1)
                    {
                        chuoi += "<li><a  class='li_first' href='/ProductSearch/page1.html'>" + "Prev" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_first' href='/ProductSearch/page" + (Int32.Parse(currentPage) - 1).ToString() + ".html'>" + "Prev" + "</a></li>";
                    }
                    for (int i = 1; i <= (PageCount / 12); i++)
                    {
                        if (i.ToString().Equals(currentPage))
                        {
                            chuoi += "<li><a class='selected tab' href='/ProductSearch/page" + i + ".html'>" + i + "</a></li>";
                        }
                        else
                        {
                            chuoi += "<li><a class='tab' href='/ProductSearch/page" + i + ".html'>" + i + "</a></li>";
                        }
                    }
                    if (Int32.Parse(currentPage) == ((PageCount / 12) + 1))
                    {
                        chuoi += "<li><a class='li_last' href='/ProductSearch/page" + currentPage + ".html'>" + "Next" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_last' href='/ProductSearch/page" + (Int32.Parse(currentPage) + 1).ToString() + ".html'>" + "Next" + "</a></li>";
                    }
                }
                else
                {
                    if (Int32.Parse(currentPage) == 1)
                    {
                        chuoi += "<li><a class='li_first' href='/ProductSearch/page1.html'>" + "Prev" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_first' href='/ProductSearch/page" + (Int32.Parse(currentPage) - 1).ToString() + ".html'>" + "Prev" + "</a></li>";
                    }

                    for (int i = 1; i <= (PageCount / 12) + 1; i++)
                    {
                        if (i.ToString().Equals(currentPage))
                        {
                            chuoi += "<li><a class='selected tab' href='/ProductSearch/page" + i + ".html'>" + i + "</a></li>";
                        }
                        else
                        {
                            chuoi += "<li><a class='tab' href='/ProductSearch/page" + i + ".html'>" + i + "</a></li>";
                        }
                    }
                    if (Int32.Parse(currentPage) == ((PageCount / 12) + 1))
                    {
                        chuoi += "<li><a class='li_last' href='/ProductSearch/page" + currentPage + ".html'>" + "Next" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_last' href='/ProductSearch/page" + (Int32.Parse(currentPage) + 1).ToString() + ".hmtl'>" + "Next" + "</a></li>";
                    }
                }
            }
            else
            {

                //dtlproductlist.DataSource = listpage;
                //dtlproductlist.DataBind();
            }
            chuoi += "</ul>";
            ltrpaging.Text = chuoi;

        }
    }
}