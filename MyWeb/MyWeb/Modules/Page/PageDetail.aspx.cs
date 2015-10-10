using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Business;

namespace MyWeb.Modules.Page
{
    public partial class PageDetail : BaseClass.BaseDefault
    {
        string pagId = "";
        private string Lang = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = Global.GetLang();
            pagId = Page.RouteData.Values["page"] as string;
            List<Data.PageLink> list = new List<Data.PageLink>();
            list = PageLinkService.PageLink_GetById(pagId);
            if (list.Count > 0)
            {
                ltrContent.Text = list[0].Detail;
                if (list[0].Title.Equals(""))
                {
                    AddMetaKeyWordTitleDescription(list[0].Name, list[0].Keyword, list[0].Description);
                }
                else
                {
                    AddMetaKeyWordTitleDescription(list[0].Title, list[0].Keyword, list[0].Description);
                }
                
            }
            
        }
        
    }
}