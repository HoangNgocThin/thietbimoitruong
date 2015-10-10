﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;

namespace MyWeb.Modules.Products
{
    public partial class ProductList : System.Web.UI.Page
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
            listpage = ProductService.Product_GetByAll("vi");
            chuoi += "<ul>";
            if (listpage.Count > 12)
            {
                if ((listpage.Count) % 12 == 0)
                {
                    if (Int32.Parse(currentpage) == 1)
                    {
                        chuoi += "<li><a  class='li_first' href='/ProductList" +".aspx/page=1'>" + "Prev" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_first' href='/ProductList" + ".aspx/page=" + (Int32.Parse(currentpage) - 1).ToString() + "'>" + "Prev" + "</a></li>";
                    }
                    for (int i = 1; i <= (listpage.Count / 12); i++)
                    {
                        if (i.ToString().Equals(currentpage))
                        {
                            chuoi += "<li><a class='selected tab' href='/ProductList" + ".aspx/page=" + i + "'>" + i + "</a></li>";
                        }
                        else
                        {
                            chuoi += "<li><a class='tab' href='/ProductList"  + ".aspx/page=" + i + "'>" + i + "</a></li>";
                        }
                    }
                    if (Int32.Parse(currentpage) == ((listpage.Count / 12) + 1))
                    {
                        chuoi += "<li><a class='li_last' href='/ProductList" + ".aspx/page=" + currentpage + "'>" + "Next" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_last' href='/ProductList" + ".aspx/page=" + (Int32.Parse(currentpage) + 1).ToString() + "'>" + "Next" + "</a></li>";
                    }
                }
                else
                {
                    if (Int32.Parse(currentpage) == 1)
                    {
                        chuoi += "<li><a class='li_first' href='/ProductList"  + ".aspx/page=1'>" + "Prev" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_first' href='/ProductList"  + ".aspx/page=" + (Int32.Parse(currentpage) - 1).ToString() + "'>" + "Prev" + "</a></li>";
                    }

                    for (int i = 1; i <= (listpage.Count / 12) + 1; i++)
                    {
                        if (i.ToString().Equals(currentpage))
                        {
                            chuoi += "<li><a class='selected tab' href='/ProductList"  + ".aspx/page=" + i + "'>" + i + "</a></li>";
                        }
                        else
                        {
                            chuoi += "<li><a class='tab' href='/ProductList" + ".aspx/page=" + i + "'>" + i + "</a></li>";
                        }
                    }
                    if (Int32.Parse(currentpage) == ((listpage.Count / 12) + 1))
                    {
                        chuoi += "<li><a class='li_last' href='/ProductList" + ".aspx/page=" + currentpage + "'>" + "Next" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_last' href='/ProductList" + ".aspx/page=" + (Int32.Parse(currentpage) + 1).ToString() + "'>" + "Next" + "</a></li>";
                    }
                }

                //BindData(currentpage, "3");
            }
            else
            {
                dtlproductlist.DataSource = listpage;
                dtlproductlist.DataBind();
            }
            chuoi += "</ul>";
            ltrpaging.Text = chuoi;

        }
        void BindData(string currentpage, string pagesize)
        {
            List<Data.Product> list = new List<Product>();
            list = ProductService.Product_Paging(currentpage, pagesize, "Lang= 'vi'", "");
            dtlproductlist.DataSource = list;
            dtlproductlist.DataBind();
        }
    }
}