using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Business;
namespace MyWeb.Controls
{
    public partial class Hotrotructuyen : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        void showHotrotructuyen()
        {
            List<Data.Support> listPro = SupportService.Support_GetByTop("3", "1=1", "");
            string strPro = "";
            if (listPro.Count > 0)
            {
                int k = 0;
                for (int i = 0; i < listPro.Count; i++)
                {
                    if (k == 0)
                    {
                        strPro += "<div class=line>\n";
                    }
                    if (i == listPro.Count - 1 || k == 4)
                        strPro += "<div class=\"last_itemblock\">\n";
                    else
                        strPro += "<div class=\"itemblock\">\n";
                    strPro += string.Format("<a href=\"ymsgr:sendim?" + listPro[i].Nick + "\" title=\"{0}\"><img src=\"{1}\" /></a>\n", listPro[i].Name, "../App_Themes/Default/images/yahooonline.gif");
                    strPro += string.Format("<a href=\"ymsgr:sendim?" + listPro[i].Nick + "\" title=\"{0}\">{1}</a>\n", listPro[i].Name, listPro[i].Name);
                     strPro += string.Format("<div class=\"by_price\">Giá bán: <font color=red><b>{0}đ</b></font></div>",listPro[0].Tel);

                    strPro += "</div>\n";
                    k++;

                    if (i % 5 == 0)
                    {
                        if (i == listPro.Count - 1)
                            strPro += "</div>\n";
                    }
                    else
                    {
                        //int m = dt.Rows.Count % 3;
                        //if (i == dt.Rows.Count - 1)
                        if (i % 5 > 0 && k == 2)
                        {
                            strPro += "</div>\n";
                            k = 0;
                        }
                        else
                        {
                            if (i == listPro.Count - 1)
                                strPro += "</div>\n";
                        }

                    }
                }
            }
            this.ltrlist.Text = strPro;
        }
    }
}