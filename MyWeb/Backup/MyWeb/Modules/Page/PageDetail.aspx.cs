using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Business;

namespace MyWeb.Modules.Page
{
    public partial class PageDetail : System.Web.UI.Page
    {
        string pagId = "";
        private string Lang = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = Global.GetLang();
            pagId = Page.RouteData.Values["page"] as string;
            List<Data.Page> list = new List<Data.Page>();
            list = PageService.Page_GetById(pagId);
            if (list.Count == 0) 
                list = PageService.Page_GetByTag(pagId, Lang);
            Literal ltrNav = (Literal)Common.PageHelper.FindControl(this.Master, "ltrNavContent");
            Literal ltrNav2 = (Literal)Common.PageHelper.FindControl(this.Master, "ltrNavContent2");
            ltrNav.Text = string.Format("<img src=\"/images/icon_root.gif\" align=\"baseline\"> <a class=\"last\" href=\"{0}\" title=\"{1}\">{1}</a> ", list[0].Link, list[0].Name);
            ltrNav2.Text = list[0].Name;
            ltrContent.Text = list[0].Detail;
            LoadMetaConfig(list[0].Name, list[0].Title, list[0].Description, list[0].Keyword);
        }
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