using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;

namespace MyWeb.Modules.Products
{
    public partial class My_U_References : System.Web.UI.UserControl
    {
        string cateid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["proid"]!=null)
            {
                List<Data.Product> listpro = new List<Product>();
                listpro = ProductService.Product_GetById(Session["proid"].ToString());
                cateid = listpro[0].CatId;
            }
            if(!IsPostBack)
            {
                showlist();
            }
        }
        void showlist()
        {
            List<Data.Product> list = new List<Product>();
            list = ProductService.Product_GetByTop("6", "Active=1 and CatId=" + cateid, "Ord DESC");
            dtlsp_references.DataSource = list;
            dtlsp_references.DataBind();
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
    }
}