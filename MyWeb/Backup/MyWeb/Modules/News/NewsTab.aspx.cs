using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWeb.Modules.News
{
    public partial class NewsTab : System.Web.UI.Page
    {
        string grnid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            grnid = Page.RouteData.Values["Subject"] as string;
            string Chuoi = "";
            List<Data.News> list = new List<Data.News>();
            list = Business.NewsService.News_GetByGroupNewsID_Date_Top(grnid, "", "5","vi");
            Chuoi += "<div class=\"news-tab\"><ul>";
            for (int i = 0; i < list.Count; i++)
            {
                string strLink = "/News/" + list[i].GroupNewsId + "/" + list[i].Id + "/" + Common.StringClass.NameToTag(list[i].Name.ToString()) + ".aspx";
                Chuoi += string.Format("<li><a href=\"{0}\" title=\"{1}\">{1}</a></li>", strLink, list[i].Name);
            }
            Chuoi += "</ul></div>";
            list.Clear();
            list = null;
            ltrNews.Text = Chuoi;
        }
    }
}