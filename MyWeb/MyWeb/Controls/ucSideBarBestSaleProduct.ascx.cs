using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Business;
using MyWeb.Data;

namespace MyWeb.Controls
{
    public partial class ucSideBarBestSaleProduct : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                LoadProduct();
            }
        }

        protected string Format_Price(string Price)
        {
            if (Price.Trim().Equals(""))
            {
                return "0";
            }
            Price = Price.Replace(".", "");
            Price = Price.Replace(",", "");
            string tmp = "";
            while (Price.Length > 3)
            {
                tmp = "." + Price.Substring(Price.Length - 3) + tmp;
                Price = Price.Substring(0, Price.Length - 3);
            }
            tmp = Price + tmp;
            return tmp;
        }
        private void LoadProduct()
        {
            List<Data.Product> list = new List<Data.Product>();
            list = ProductService.Product_GetByTop("10", "Active=1", "CountSale DESC");
            if (list.Count > 0)
            {
                string str = "";
                for (int i = 0; i < list.Count; i++)
                {
                    str += "<div class='dv_pr_adv'>";
                    str += "<a href='/Product/"+list[i].ID+"/"+list[i].Tag+".html'>";
                    str += " <img src='"+list[i].Image+"' /></a>";
                    str += "</br>";
                    str += "<p><a href='/Product/" + list[i].ID + "/" + list[i].Tag + ".html'>"+list[i].Name+"</a></p>";
                    str += "</div>";
                }
                ltrproductBestSale.Text = str;
            }
        }
    }
}