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
    public partial class ProductView : System.Web.UI.Page
    {
        string cateid = "";
        string currentpage = "1";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(RouteData.Values["CateId"]!=null)
            {
                cateid = RouteData.Values["CateId"].ToString();
            }
            if (RouteData.Values["currentpage"]!=null)
            {
                currentpage = RouteData.Values["currentpage"].ToString();
                BindData(currentpage, "12");
            }
            BindData(currentpage,"12");
            //show();
            show1();
        }
        void show1()
        {
            string chuoi = "";
            List<Data.Product> listpage = new List<Data.Product>();
            listpage = ProductService.Product_GetByTop("", "CatId=" + cateid, "");
            List<Data.Category> listcate = new List<Category>();
            listcate = CategoryService.Category_GetById(cateid);
            lblheader.Text = listcate[0].Name;
            chuoi += "<ul>";
            if (listpage.Count > 12)
            {
                if ((listpage.Count) % 12 == 0)
                {
                    if (Int32.Parse(currentpage) == 1)
                    {
                        chuoi += "<li><a  class='li_first' href='/Products/" + cateid + ".aspx/page=1'>" + "Prev" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_first' href='/Products/" + cateid + ".aspx/page=" + (Int32.Parse(currentpage) - 1).ToString() + "'>" + "Prev" + "</a></li>";
                    }
                    for (int i = 1; i <= (listpage.Count /12); i++)
                    {
                        if (i.ToString().Equals(currentpage))
                        {
                            chuoi += "<li><a class='selected tab' href='/Products/" + cateid + ".aspx/page=" + i + "'>" + i + "</a></li>";
                        }
                        else
                        {
                            chuoi += "<li><a class='tab' href='/Products/" + cateid + ".aspx/page=" + i + "'>" + i + "</a></li>";
                        }
                    }
                    if (Int32.Parse(currentpage) == ((listpage.Count / 12) + 1))
                    {
                        chuoi += "<li><a class='li_last' href='/Products/" + cateid + ".aspx/page=" + currentpage + "'>" + "Next" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_last' href='/Products/" + cateid + ".aspx/page=" + (Int32.Parse(currentpage) + 1).ToString() + "'>" + "Next" + "</a></li>";
                    }
                }
                else
                {
                    if (Int32.Parse(currentpage) == 1)
                    {
                        chuoi += "<li><a class='li_first' href='/Products/" + cateid + ".aspx/page=1'>" + "Prev" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_first' href='/Products/" + cateid + ".aspx/page=" + (Int32.Parse(currentpage) - 1).ToString() + "'>" + "Prev" + "</a></li>";
                    }
                    
                    for (int i = 1; i <= (listpage.Count / 12)+1; i++)
                    {
                        if (i.ToString().Equals(currentpage))
                        {
                            chuoi += "<li><a class='selected tab' href='/Products/" + cateid + ".aspx/page=" + i + "'>" + i + "</a></li>";
                        }
                        else
                        {
                            chuoi += "<li><a class='tab' href='/Products/" + cateid + ".aspx/page=" + i + "'>" + i + "</a></li>";
                        }
                    }
                    if (Int32.Parse(currentpage) == ((listpage.Count / 12) + 1))
                    {
                        chuoi += "<li><a class='li_last' href='/Products/" + cateid + ".aspx/page=" + currentpage + "'>" + "Next" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_last' href='/Products/" + cateid + ".aspx/page=" + (Int32.Parse(currentpage) + 1).ToString() + "'>" + "Next" + "</a></li>";
                    }
                }
                
                //BindData(currentpage, "3");
            }
            else
            {
                dtlproductbycateloge.DataSource = listpage;
                dtlproductbycateloge.DataBind();
            }
            chuoi += "</ul>";
            ltrpaging.Text = chuoi;

        }
        void BindData(string currentpage, string pagesize)
        {
            List<Data.Product> list = new List<Product>();
            list = ProductService.Product_Paging(currentpage, pagesize, "CatId=" + cateid, "");
            dtlproductbycateloge.DataSource = list;
            dtlproductbycateloge.DataBind();
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
    }
}