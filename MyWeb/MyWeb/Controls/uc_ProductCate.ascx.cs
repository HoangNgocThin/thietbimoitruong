using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWeb.Controls
{
    public partial class uc_ProductCate : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                Viewlistmen();
            }
        }
        void Viewlistmen()
        {
            string Chuoi = "";
            List<Data.ProductCategory> list = Business.ProductCategoryService.ProductCategory_GetByPosition("2", 5);
            list = list.OrderBy(x=>x.Ord).ToList();
            if (list.Count > 0) {
                Chuoi += "<ul id='sidebarmenu1'>";
            }
            for (int i = 0; i < list.Count; i++)
            {
                Chuoi += "<li><a href='/ProductList/" + list[i].ID + "/"+list[i].Tag+".html'>" + list[i].Name + "</a>";
                List<Data.ProductCategory> listsub = Business.ProductCategoryService.ProductCategory_GetByLevel(list[i].Level, 10);
                if (listsub.Count > 0)
                {
                    Chuoi += "<ul>";
                    for (int j = 0; j < listsub.Count; j++) {
                        Chuoi += "<li><a href='/ProductList/" + listsub[j].ID+ "/"+listsub[j].Tag+".html'>" + listsub[j].Name + "</a>";
                        List<Data.ProductCategory> listsub1 = Business.ProductCategoryService.ProductCategory_GetByLevel(listsub[j].Level, 15);
                        if (listsub1.Count > 0)
                        {
                            Chuoi += "<ul>";
                            for (int k = 0; k < listsub1.Count;k++ )
                            {
                                Chuoi += "<li><a href='/ProductList/" + listsub1[k].ID+ "/"+listsub1[k].Tag+".html'>" + listsub1[k].Name + "</a></li>";
                            }
                            Chuoi += "</ul>";
                        }
                        Chuoi += "</li>";
                    }
                    Chuoi += "</ul>";
                }
                Chuoi += "</li>";
            }
            if (list.Count > 0)
            {
                Chuoi += "</ul>";
            }
            ltrSidebar.Text = Chuoi;
            list.Clear();
            list = null;
        }
    }
}