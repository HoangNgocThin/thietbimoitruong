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
    public partial class ProductDetail : System.Web.UI.Page
    {
        string id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(RouteData.Values["Id"]!=null)
            {
                id = RouteData.Values["Id"].ToString();
            }
            if(!IsPostBack)
            {
                ShowList();
            }
            Session["proid"] = id;
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
        void ShowList()
        {
            List<Data.Product> list = new List<Product>();
            list = ProductService.Product_GetById(id);
            List<Data.Category> listcate = new List<Category>();
            listcate = CategoryService.Category_GetById(list[0].CatId);
            txtsoluong.Text = "1";
            lblheader.Text = listcate[0].Name;
            lblname.Text = list[0].Name;
            lblmasanpham.Text = list[0].Codepro;
            lblgiathitruong.Text =Format_Price(list[0].Price.ToString())+ " VND";
            lbltrongluong.Text = "đang cập nhật";
            ltrdetail.Text = list[0].Detail;
            ltrimg.Text = "<img src='"+list[0].Image+"'/>";
        }

        protected void imgbtndatmua_Click(object sender, ImageClickEventArgs e)
        {
            Session["productid"] = id;
            if (txtsoluong.Text.Trim().Equals(""))
            {
                Session["quantity"] = "1";
            }
            else
            {
                Session["quantity"] = txtsoluong.Text;
            }
            Response.Redirect("/Order.aspx");
        }
    }
}