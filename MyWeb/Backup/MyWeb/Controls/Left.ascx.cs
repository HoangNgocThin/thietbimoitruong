using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Business;
using MyWeb.Common;

namespace MyWeb.Controls
{
    public partial class Left : System.Web.UI.UserControl
    {
        string pagLevel = "";
        private string Lang = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = Global.GetLang();
            if (!IsPostBack)
            {
                string strUrl = Request.Url.AbsolutePath.ToString().ToLower();
                string strgrnId = Page.RouteData.Values["Subject"] as string;
                List<Data.Page> list = new List<Data.Page>();
                list = strUrl.Contains("/news/") ? PageService.Page_GetByURL(strUrl, Lang, strgrnId) : PageService.Page_GetByURL(strUrl, Lang);
                if (list.Count > 0) pagLevel = list[0].Level;
                LoadLeftMenu();
            }
        }
        #region[LoadProductMenu]
        void LoadProductMenu() 
        {
            string strReturn = "";
            //if (pagLevel.Length > 0)
            //{
                List<Data.Category> list = CategoryService.Category_GetByAll(Lang);
                if (list.Count > 1)
                {
                    strReturn += "<div class=\"menu-pro\"><table>";
                    for (int i = 0; i < list.Count; i++)
                    {
                        string strLink = "/product/" + list[i].Id + ".aspx";
                        strReturn += string.Format("<tr><td> <a href=\"{0}\" title=\"{2}\"><img src=\"{1}\" alt=\"{2}\" /></a></td> <td><a href=\"{0}\" title=\"{2}\">{2}</a></td></tr>", strLink, list[i].Image, list[i].Name);
                    }
                    strReturn += "</table></div>";
                }
                list.Clear();
                list = null;
            //}
            //ltrMenu.Text = strReturn;
        }
        #endregion
        #region[LoadLeftMenu]
        void LoadLeftMenu()
        {
            string strReturn = "";
            if (pagLevel.Length > 0){
                List<Data.Page> list = PageService.Page_GetByLevel(pagLevel.Substring(0,5), Lang, "1");
                if (list.Count > 1){
                    strReturn += string.Format("<div class=\"nav\">{0}</div>", list[0].Name);
                    strReturn += "<div class=\"menu-left\"><ul>";
                    for (int i = 1; i < list.Count; i++)
                    {
                        if (pagLevel.Length > 5 && list[i].Level.Substring(0, 10) == pagLevel.Substring(0, 10))
                        {
                            strReturn += string.Format("<li><a class=\"selected\" href=\"{0}\" target=\"{1}\" title=\"{2}\">{2}</a></li>", list[i].Link, list[i].Target, list[i].Name);
                        }
                        else
                        {
                            strReturn += string.Format("<li><a href=\"{0}\" target=\"{1}\" title=\"{2}\">{2}</a></li>", list[i].Link, list[i].Target, list[i].Name);
                        }                   
                    }
                    strReturn += "</ul></div>";
                }
                list.Clear();
                list = null;
            }
            ltrMenu.Text = strReturn;
        }
        #endregion
    }
}