using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;

namespace MyWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            showlist();
        }
        void showlist()
        {
            List<Data.Page> list = new List<Data.Page>();
            list = PageService.Page_GetByTop("1000000000","len(Level)=5","Level ASC");
            List<Data.Page> listsub = new List<Data.Page>();
            string chuoi = "";
            chuoi += "<div class=\"sidebarmenu\"\n>";
            chuoi += "<ul id=\"sidebarmenu1\">\n";
            for (int i = 0; i < list.Count;i++)
            {
                chuoi += "<li><a class='a_hover' href=\"#\">" + list[i].Name + "</a>\n";
                listsub = PageService.Page_GetByTop("1000000000", " len(Level)=10 and left(Level,5)='" + list[i].Level + "'", "");
                if (listsub.Count > 0)
                {
                    chuoi += "<ul>\n";
                    for (int j = 0; j < listsub.Count; j++)
                    {
                        chuoi += "<li><a class='a_hover' href=\"#\">" + listsub[j].Name + "</a></li>\n";
                    }
                    chuoi += "</ul>\n"; 
                    chuoi += "</li>\n";
                }
                else
                {
                    chuoi += "</li>\n";
                }
            }
            chuoi += "</ul>\n";
            chuoi += "</div>\n";
           // ltrmain.Text = chuoi;
        }
    }
}