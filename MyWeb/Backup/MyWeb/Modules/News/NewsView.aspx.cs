using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWeb.Modules.News
{
    public partial class NewsView : System.Web.UI.Page
    {
        string date = "";
        string grnid = "";
        private string Lang = ""; 
        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = Global.GetLang();
            if (Page.RouteData.Values["Subject"] != null)
            {
                grnid = Page.RouteData.Values["Subject"] as string;
            }
            if (Page.RouteData.Values["date"] != null)
            {
                date = Page.RouteData.Values["date"] as string;
            }
            Literal ltrNav = (Literal)Common.PageHelper.FindControl(this.Master, "ltrNavContent");
            ltrNav.Text = grnid != "" ? Business.GroupNewsService.GroupNews_GetById(grnid)[0].Name : "Tin tức";
            if (!IsPostBack) {
                ViewInformation();
                Common.PageHelper.LoadDropDownListNumber(ddrYear, 2007, DateTime.Now.Year);
                Common.PageHelper.LoadDropDownListNumber(ddrMonth, 1, 12);
                Common.PageHelper.LoadDropDownListNumber(ddrDate, 1, 31);
                if (date.Length>0){
                    ddrDate.SelectedValue = Common.DateTimeClass.Convert2Date(date).Day.ToString();
                    ddrMonth.SelectedValue = Common.DateTimeClass.Convert2Date(date).Month.ToString();
                    ddrYear.SelectedValue = Common.DateTimeClass.Convert2Date(date).Year.ToString(); 
                }
                else{
                    ddrDate.SelectedValue = DateTime.Now.Day.ToString();
                    ddrMonth.SelectedValue = DateTime.Now.Month.ToString();
                    ddrYear.SelectedValue = DateTime.Now.Year.ToString();
                }
            }
        }
        #region[ViewInformation]
        void ViewInformation()
        {
            string Chuoi = "";
            List<Data.News> list = new List<Data.News>();
            if (date.Length>0)
            {
                list = Business.NewsService.News_GetByGroupNewsID_Date_Top(grnid, date, "10", Lang);
            }
            else
            {
                list = Business.NewsService.News_GetByGroupNewsID_Date_Top(grnid, "", "10", Lang);
            }
            for (int i = 0; i < list.Count; i++)
            {
                Chuoi += "<div class=\"cat-news clearfix\">";
                string strLink = "/News/" + list[i].GroupNewsId + "/" + list[i].Id + "/" + Common.StringClass.NameToTag(list[i].Name.ToString()) + ".aspx";
                if (list[i].Image.Length > 0)
                {
                    Chuoi += string.Format("<a href=\"{0}\" title=\"{2}\"><img src=\"{1}\" alt=\"{2}\" title=\"{2}\" /></a>", strLink, list[i].Image, list[i].Name);
                }
                Chuoi += string.Format("<h4><a href=\"{0}\" title=\"{1}\">{1}</a></h4>{2}<div class=\"news-more\"><a href=\"{0}\" title=\"{1}\">Xem tiếp</a></div>", strLink, list[i].Name, list[i].Content); 
  //
                Chuoi += "</div>";
            }
            list.Clear();
            list = null;
            ltrNews.Text = Chuoi;
        }
        #endregion
        #region[ViewByDate]
        protected void viewDate_Click(object sender, EventArgs e)
        {
            
            string Chuoi = "";
            Chuoi = ddrYear.SelectedValue + "-" + ddrMonth.SelectedValue + "-" + ddrDate.SelectedValue;
            Response.Redirect("/News/" + grnid + "/" + Chuoi + ".aspx");
        }
        #endregion
    }
}