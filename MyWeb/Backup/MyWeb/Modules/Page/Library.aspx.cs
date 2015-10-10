using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWeb.Modules.Page
{
    public partial class Library : System.Web.UI.Page
    {
        string GroupLibraryId = "";
        private string Lang = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = Global.GetLang();
            if (Page.RouteData.Values["Subject"] != null)
            {
                GroupLibraryId = Page.RouteData.Values["Subject"] as string;
            }
            Literal ltrNav = (Literal)Common.PageHelper.FindControl(this.Master, "ltrNavContent");
            ltrNav.Text = "Thư viện";
            List<Data.GroupLibrary> glist = new List<Data.GroupLibrary>();
            List<Data.Library> list = new List<Data.Library>();
            glist = Business.GroupLibraryService.GroupLibrary_GetById(GroupLibraryId);
            string strReturn = "";
            if (glist.Count > 0)
            {
                glist = Business.GroupLibraryService.GroupLibrary_GetByLevel(glist[0].Level, Lang);
            }
            else
            {
                glist = Business.GroupLibraryService.GroupLibrary_GetByAll(Lang);
            }
            for (int i = 1; i < glist.Count; i++)
            {
                strReturn += "<div class=\"Library\">";
                string strSrc = Common.StringClass.Check(glist[i].Image) ? glist[i].Image : "/images/no_image.gif";
                strReturn += string.Format("<table><tr><td><a href=\"/library/{0}.aspx\" title=\"{1}\"><img src=\"{2}\" alt=\"{1}\"/></a></td></tr></table><div class=\"lbrname\"><a href=\"/library/{0}.aspx\" title=\"{1}\">{1}</a></div>", "" + glist[i].Id, glist[i].Name, strSrc);
                strReturn += "</div>";
            }
            list = Business.LibraryService.Library_GetByGroupLibraryId(GroupLibraryId, Lang);
            //if (glist.Count >0){
            //    glist = Business.GroupLibraryService.GroupLibrary_GetByLevel(glist[0].Level, Lang);
            //    for (int i = 1; i < glist.Count; i++)
            //    {
            //        strReturn += "<div class=\"Library\">";
            //        string strSrc = Common.StringClass.Check(glist[i].Image) ? glist[i].Image : "/images/no_image.gif";
            //        strReturn += string.Format("<table><tr><td><a href=\"/library/{0}.aspx\" title=\"{1}\"><img src=\"{2}\" alt=\"{1}\"/></a></td></tr></table><div class=\"lbrname\"><a href=\"/library/{0}.aspx\" title=\"{1}\">{1}</a></div>", "" + glist[i].Id, glist[i].Name, strSrc);
            //        strReturn += "</div>";
            //    }
            //    list = Business.LibraryService.Library_GetByGroupLibraryId(GroupLibraryId, Lang);
            //}else{
            //    list = Business.LibraryService.Library_GetByAll(Lang);
            //}

            for (int i = 0; i < list.Count; i++)
            {
                strReturn += "<div class=\"Library\">";
                //Neu la file tai lieu
                if (Common.StringClass.Check(list[i].File))
                {
                    string strSrc = Common.StringClass.Check(list[i].Image) ? Common.StringClass.ThumbImage(list[i].Image) : "/images/" + Common.StringClass.GetFileExtension(list[i].File) + ".gif";
                    strReturn += string.Format("<table><tr><td><a href=\"{0}\" title=\"{1}\"><img src=\"{2}\" alt=\"{1}\"/></a></td></tr></table><div class=\"lbrname\"><a href=\"{0}\" title=\"{1}\">{1}</a></div><div class=\"lbrdown\"><a href=\"{0}\" title=\"{1}\">Download <img src=\"/images/" + Common.StringClass.GetFileExtension(list[i].File) + ".gif\" alt=\"{1}\" width=\"16\"/></a></div>", list[i].File, list[i].Name, strSrc);
                }
                else if (Common.StringClass.Check(list[i].Image))
                {
                    string strSrc = Common.StringClass.Check(list[i].Image) ? Common.StringClass.ThumbImage(list[i].Image) : "/images/no_image.gif";
                    strReturn += string.Format("<table><tr><td><a href=\"{0}\" title=\"{1}\" class=\"highslide\" onClick=\"return hs.expand(this)\"><img src=\"{2}\" alt=\"{1}\"/></a></td></tr></table><div class=\"lbrname\"><a href=\"{0}\" title=\"{1}\" class=\"highslide\" onClick=\"return hs.expand(this)\">{1}</a></div>", list[i].Image, list[i].Name, strSrc);
                }
                strReturn += "</div>";
            }

            ltrLibrary.Text = strReturn;
        }
    }
}