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
    public partial class NewsDetail : BaseClass.BaseDefault
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 

                if(Page.RouteData.Values !=null && !Page.RouteData.Values["Id"].ToString().Equals("")){
                    LoadNewsByID(Page.RouteData.Values["Id"].ToString());

                }
            }
        }

        private void LoadComment(string strLink)
        {
            ltrComment.Text = "<div class='fb-comments' data-href='" + strLink + "' data-width='800px' data-numposts='10' data-colorscheme='light'></div>";
        }
        private void LoadNewsByID(string id) {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            List<Data.News> list = new List<Data.News>();
            list = NewsService.News_GetById(id);
            if (list.Count > 0) {
                ltrNavigate.Text = "<ul class='breadcumb'><li><a href='/'>Trang chủ</a></li><li><a href='/NewsList.html'>" + "Tin tức" + "</a></li><li class='breadcumb_last' ><a>" + list[0].Name + "</a></li></ul>";
                if (list[0].Title.Equals(""))
                {
                    AddMetaKeyWordTitleDescription(list[0].Name, list[0].Keyword, list[0].Description);
                }
                else
                {
                    AddMetaKeyWordTitleDescription(list[0].Title, list[0].Keyword, list[0].Description);
                }

                ltrLike.Text = "<div class='fb-like' data-href='" + url + "' data-width='70' data-layout='button' data-action='like' data-show-faces='false' data-share='false'></div>";
                ltrShare.Text = "<div class='fb-share-button' data-href='" + url + "' data-width='100px' data-type='button_count'></div>";
                ltrGoogle.Text = "<div class='g-plusone' data-size='medium' data-annotation='inline' data-width='300'></div>";
                ltrNewsImage.Text = "<img src='" + list[0].Image + "'/>";
                ltrTitle.Text = list[0].Name;
                ltrPostedDate.Text ="Ngày đăng: "+ list[0].PostedDate;
                ltrDescription.Text = list[0].Content;
                ltrDetail.Text = list[0].Detail;
                if (list[0].NewsCategoryID !=null && list[0].NewsCategoryID.Trim() != "")
                {
                LoadReferenceNews(list[0].NewsCategoryID);
                }
                LoadComment(url);
            }
        }
        private void LoadReferenceNews(string cateid) {
            List<Data.News> list = new List<Data.News>();
            list = NewsService.News_GetByTop("10", "NewsCategoryID =" + cateid, "ModifiedDate Desc");
            if (list.Count > 0) {
                string str = "";
                for (int i = 0; i < list.Count; i++) {
                    str += "<li><a href='/News/"+list[i].Id+"/"+list[i].Tag+".html'>"+list[i].Name+"</a></li>";
                }
                ltrNewsRefer.Text = str;
            }
            
        }
    }
}