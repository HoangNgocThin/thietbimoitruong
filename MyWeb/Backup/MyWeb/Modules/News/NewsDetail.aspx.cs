using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWeb.Modules.News
{
    public partial class NewsDetail : System.Web.UI.Page
    {
        string grnid = "";
        string id = "";
        private string Lang = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = Global.GetLang();
            if (Page.RouteData.Values["Subject"] != null)
            {
                grnid = Page.RouteData.Values["Subject"] as string;
            }
            if (Page.RouteData.Values["Id"] != null)
            {
                id = Page.RouteData.Values["Id"] as string;
            }
            if (!IsPostBack) {
                Literal ltrNav = (Literal)Common.PageHelper.FindControl(this.Master, "ltrNavContent");
                ltrNav.Text = Business.GroupNewsService.GroupNews_GetById(grnid)[0].Name;
                ViewInformation(); 
            }
        }
        #region[ViewnInformation]
        void ViewInformation()
        {
            List<Data.News> list = Business.NewsService.News_GetById(id);
            if (list.Count > 0)
            {
                LoadMetaConfig(list[0].Name, list[0].Title, list[0].Description, list[0].Keyword);
                List<Data.News> listRelated = Business.NewsService.News_GetByNewsRelated(id, list[0].GroupNewsId, Lang);
                List<Data.News> listOther = Business.NewsService.News_GetByNewsOther(id, Common.DateTimeClass.ConvertDateTime(list[0].Date, "MM/dd/yyyy HH:mm:ss"), list[0].GroupNewsId, Lang);
                rpt_newDetails.DataSource = list;
                rpt_newDetails.DataBind();
                list.Clear();
                list = null;
                if (listRelated.Count > 0)
                {
                    string strRelated = "<div class=\"news-related clearfix\"><h3>Các tin mới</h3><ul>";
                    for (int i = 0; i < listRelated.Count; i++)
                    {
                        string strLink = "/News/" + listRelated[i].GroupNewsId + "/" + listRelated[i].Id + "/" + listRelated[i].Tag + ".aspx";
                        string NewToday = "";
                        if (Common.DateTimeClass.ConvertDate(listRelated[i].Date) == Common.DateTimeClass.ConvertDate(DateTime.Now.ToString()))
                        {
                            NewToday = " class=\"new\"";
                        }
                        strRelated += string.Format("<li" + NewToday + "><a href=\"{0}\" title=\"{1}\">{1} ({2})</a></li>", strLink, listRelated[i].Name, Common.DateTimeClass.ConvertDate(listRelated[i].Date, "dd/MM/yyyy"));
                    }
                    strRelated += "</ul></div>";
                    ltrNewsRelated.Text = strRelated;
                }
                listRelated.Clear();
                listRelated = null;
                if (listOther.Count > 0)
                {
                    string strOther = "<div class=\"news-other clearfix\"><h3>Các tin đã đăng</h3><ul>";
                    for (int i = 0; i < listOther.Count; i++)
                    {
                        string strLink = "/News/" + listOther[i].GroupNewsId + "/" + listOther[i].Id + "/" + listOther[i].Tag + ".aspx";
                        string NewToday = "";
                        if (Common.DateTimeClass.ConvertDate(listOther[i].Date) == Common.DateTimeClass.ConvertDate(DateTime.Now.ToString()))
                        {
                            NewToday = " class=\"new\"";
                        }
                        strOther += string.Format("<li" + NewToday + "><a href=\"{0}\" title=\"{1}\">{1} ({2})</a></li>", strLink, listOther[i].Name, Common.DateTimeClass.ConvertDate(listOther[i].Date, "dd/MM/yyyy"));
                    }
                    strOther += "</ul></div>";
                    ltrNewsOther.Text = strOther;
                }
                listOther.Clear();
                listOther = null;
            }
        }
        #endregion

        #region[LoadMetaConfig]
        void LoadMetaConfig(string strName, string strTitle, string strDescription, string strKeyword)
        {
            Page.Title = strTitle != "" ? strTitle : strName;
            Page.MetaDescription = strDescription != "" ? strDescription : Common.GlobalClass.Description;
            Page.MetaKeywords = strKeyword != "" ? strKeyword : Common.GlobalClass.Keyword;
        }
        #endregion
    }
}