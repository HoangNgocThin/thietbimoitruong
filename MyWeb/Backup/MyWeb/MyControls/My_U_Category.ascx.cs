using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;

namespace MyWeb.MyControls
{
    public partial class My_U_Category : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            showmenubar();
        }
        void showmenubar()
        {
            List<Data.Category> list = new List<Category>();
            list = CategoryService.Category_GetByTop("1000000","len(Level)=5 and Active=1","Level ASC");
            string chuoi = "";
            chuoi += "<div id='dv_menubar_left'>";
            chuoi += "<div class='dv_top'>";
            chuoi += "<span>Danh mục sản phẩm</span>";
            chuoi += "</div>";
            chuoi += "<div class='dv_middle'>";
            chuoi += "<ul>";
            if (list.Count>0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if ((i + 1) == list.Count)
                    {
                        chuoi += "<li class='li_last'><img src='/App_Themes/Default/img/img_menubar.png' /><a href='/Products/" + list[i].Id +"/"+list[i].Tag+ ".aspx'><span>" + list[i].Name + "<span></a></li>";
                    }
                    else
                    {
                        chuoi += "<li><img src='/App_Themes/Default/img/img_menubar.png' /><a href='/Products/" + list[i].Id + "/" + list[i].Tag + ".aspx'><span>" + list[i].Name + "<span></a></li><img class='img_border' src='/App_Themes/Default/img/border_menubar.png' />";
                    }
                }
            }
            chuoi += "</ul>";
            chuoi += "</div>";
            chuoi += "</div>";
            ltrcategory.Text = chuoi;
        }
    }
}