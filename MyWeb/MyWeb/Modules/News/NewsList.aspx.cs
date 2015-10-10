using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;

namespace MyWeb.Modules.News
{
    public partial class NewsList : BaseClass.BaseDefault
    {
        
        string currentpage = "1";
        int PageCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RouteData.Values["currentpage"] != null)
            {
                currentpage = RouteData.Values["currentpage"].ToString();
                LoadNewList(currentpage, "10");
            }
            LoadNewList(currentpage, "10");
            BuildPaging();
            
        }

        private void LoadNewList(string currentPage, string pageSize)
        {
            List<Data.News> list = new List<Data.News>();
            list = NewsService.News_Paging(currentPage, pageSize);
            if (list.Count > 0)
            {
                PageCount =int.Parse(list[0].PageCount);
                string str = "";
                int mod = 0;
                for (int i = 0; i < list.Count; i++)
                {
                    mod += 1;
                    if (list.Count % 2 == 0)
                    {
                        if (i == (list.Count - 2))
                        {
                            str += "<div class='news_item news_item_last'>";
                        }
                        else
                        {
                            if (mod % 2 != 0)
                                str += "<div class='news_item'>";
                        }
                    }
                    else
                    {
                        if (i == (list.Count - 1))
                        {
                            str += "<div class='news_item news_item_last'>";
                        }
                        else
                        {
                            if (mod % 2 != 0)
                                str += "<div class='news_item'>";
                        }
                    }

                    str += "<div class='news_item_img'>";
                    str += "<a href='/News/" + list[i].Id + "/" + list[i].Tag + ".html'><img src='" + list[i].Image + "'/></a>";
                    str += "</div>";
                    str += "<div class='news_item_name'>";
                    str += "<a href='/News/" + list[i].Id + "/" + list[i].Tag + ".html'>" + list[i].Name + "</a>";
                    str += "<div class='dv_p'>" + list[i].Content + "</div>";
                    str += "</div>";
                    if (mod % 2 == 0)
                    {
                        str += "<div class='clear'></div>";
                        str += "</div>";
                    }
                    if (i == list.Count - 1 && list.Count % 2 != 0)
                    {
                        str += "<div class='clear'></div>";
                        str += "</div>";
                    }
                }
                ltrDetail.Text = str;
            }
        }

        private void BuildPaging()
        {
            string chuoi = "";
            chuoi += "<ul>";
            if (PageCount > 10)
            {
                if ((PageCount) % 10 == 0)
                {
                    if (Int32.Parse(currentpage) == 1)
                    {
                        chuoi += "<li><a  class='li_first' href='/NewsList" + "/page1.html'>" + "Prev" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_first' href='/NewsList" + "/page" + (Int32.Parse(currentpage) - 1).ToString() + ".html'>" + "Prev" + "</a></li>";
                    }
                    for (int i = 1; i <= (PageCount / 10); i++)
                    {
                        if (i.ToString().Equals(currentpage))
                        {
                            chuoi += "<li><a class='selected tab' href='/NewsList/page" + i + ".html'>" + i + "</a></li>";
                        }
                        else
                        {
                            chuoi += "<li><a class='tab' href='/NewsList/page" + i + ".html'>" + i + "</a></li>";
                        }
                    }
                    if (Int32.Parse(currentpage) == ((PageCount / 10) + 1))
                    {
                        chuoi += "<li><a class='li_last' href='/NewsList/page" + currentpage + ".html'>" + "Next" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_last' href='/NewsList/page" + (Int32.Parse(currentpage) + 1).ToString() + ".html'>" + "Next" + "</a></li>";
                    }
                }
                else
                {
                    if (Int32.Parse(currentpage) == 1)
                    {
                        chuoi += "<li><a class='li_first' href='/NewsList/page1.html'>" + "Prev" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_first' href='/NewsList/page" + (Int32.Parse(currentpage) - 1).ToString() + ".html'>" + "Prev" + "</a></li>";
                    }

                    for (int i = 1; i <= (PageCount / 10) + 1; i++)
                    {
                        if (i.ToString().Equals(currentpage))
                        {
                            chuoi += "<li><a class='selected tab' href='/NewsList/page" + i + ".html'>" + i + "</a></li>";
                        }
                        else
                        {
                            chuoi += "<li><a class='tab' href='/NewsList/page" + i + ".html'>" + i + "</a></li>";
                        }
                    }
                    if (Int32.Parse(currentpage) == ((PageCount / 10) + 1))
                    {
                        chuoi += "<li><a class='li_last' href='/NewsList/page" + currentpage + ".html'>" + "Next" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_last' href='/NewsList/page" + (Int32.Parse(currentpage) + 1).ToString() + ".hmtl'>" + "Next" + "</a></li>";
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