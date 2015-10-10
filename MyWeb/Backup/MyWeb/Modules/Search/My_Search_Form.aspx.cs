using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;

namespace MyWeb.Modules.Search
{
    public partial class My_Search_Form : System.Web.UI.Page
    {
        string currentpage = "1";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RouteData.Values["currentpage"] != null)
            {
                currentpage = RouteData.Values["currentpage"].ToString();
                BindData(currentpage, "12");
            }
            BindData(currentpage, "12");
            //show();
            show1();
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
        void show1()
        {
            string chuoi = "";
            List<Data.Product> listpage = new List<Data.Product>();
            listpage = ProductService.Product_GetByTop("","Name like '%"+Session["keyword"].ToString()+"%'", "");
            chuoi += "<ul>";
            if (listpage.Count > 12)
            {
                if ((listpage.Count) % 12 == 0)
                {
                    if (Int32.Parse(currentpage) == 1)
                    {
                        chuoi += "<li><a  class='li_first' href='/search.aspx/page=1'>" + "Prev" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_first' href='/search.aspx/page=" + (Int32.Parse(currentpage) - 1).ToString() + "'>" + "Prev" + "</a></li>";
                    }
                    for (int i = 1; i <= (listpage.Count / 12); i++)
                    {
                        if (i.ToString().Equals(currentpage))
                        {
                            chuoi += "<li><a class='selected tab' href='/search.aspx/page=" + i + "'>" + i + "</a></li>";
                        }
                        else
                        {
                            chuoi += "<li><a class='tab' href='/search.aspx/page=" + i + "'>" + i + "</a></li>";
                        }
                    }
                    if (Int32.Parse(currentpage) == ((listpage.Count / 12) + 1))
                    {
                        chuoi += "<li><a class='li_last' href='/search.aspx/page=" + currentpage + "'>" + "Next" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_last' href='/search.aspx/page=" + (Int32.Parse(currentpage) + 1).ToString() + "'>" + "Next" + "</a></li>";
                    }
                }
                else
                {
                    if (Int32.Parse(currentpage) == 1)
                    {
                        chuoi += "<li><a class='li_first' href='/search.aspx/page=1'>" + "Prev" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_first' href='/search.aspx/page=" + (Int32.Parse(currentpage) - 1).ToString() + "'>" + "Prev" + "</a></li>";
                    }

                    for (int i = 1; i <= (listpage.Count / 12) + 1; i++)
                    {
                        if (i.ToString().Equals(currentpage))
                        {
                            chuoi += "<li><a class='selected tab' href='/search.aspx/page=" + i + "'>" + i + "</a></li>";
                        }
                        else
                        {
                            chuoi += "<li><a class='tab' href='/search.aspx/page=" + i + "'>" + i + "</a></li>";
                        }
                    }
                    if (Int32.Parse(currentpage) == ((listpage.Count / 12) + 1))
                    {
                        chuoi += "<li><a class='li_last' href='/search.aspx/page=" + currentpage + "'>" + "Next" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_last' href='/search.aspx/page=" + (Int32.Parse(currentpage) + 1).ToString() + "'>" + "Next" + "</a></li>";
                    }
                }

                //BindData(currentpage, "3");
            }
            else
            {
                dtlsp_search_by_keyword.DataSource = listpage;
                dtlsp_search_by_keyword.DataBind();
            }
            chuoi += "</ul>";
            ltrpaging.Text = chuoi;

        }
        void BindData(string currentpage, string pagesize)
        {
            if (Session["keyword"] != null)
            {
                List<Data.Product> list = new List<Product>();
                list = ProductService.Product_Paging(currentpage, pagesize, "Name like '%" + Session["keyword"].ToString() + "%' and Active=1", "");
                dtlsp_search_by_keyword.DataSource = list;
                dtlsp_search_by_keyword.DataBind(); 
            }
        }
    }
}