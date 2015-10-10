using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;
using System.Data;

namespace MyWeb.Modules.Products
{
    public partial class My_U_SP_Banchay : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            showlist();
        }
        void showlist()
        {
            List<Data.Product> list = new List<Product>();
            list = ProductService.Product_GetByTop("6", "Active=1", "Ord DESC");
            dtlspbanchay.DataSource = list;
            dtlspbanchay.DataBind();
            

        }
        protected string Format_Price(string Price)
        {
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
        protected void dtlspbanchay_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            
        }
    }
}