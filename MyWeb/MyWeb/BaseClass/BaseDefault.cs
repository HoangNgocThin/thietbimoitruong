using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace MyWeb.BaseClass
{
    public class BaseDefault : System.Web.UI.Page
    {
        protected void AddMetaKeyWordTitleDescription(string title, string keyword, string strdescription)
        {
            this.Page.Title = title;

            //Add Keywords Meta Tag
            HtmlMeta keywords = new HtmlMeta();
            keywords.HttpEquiv = "keywords";
            keywords.Name = "keywords";
            keywords.Content = keyword;
            this.Page.Header.Controls.Add(keywords);

            //Add Description Meta Tag
            HtmlMeta description = new HtmlMeta();
            description.HttpEquiv = "description";
            description.Name = "description";
            description.Content = strdescription;
            this.Page.Header.Controls.Add(description);
        }
    }
}