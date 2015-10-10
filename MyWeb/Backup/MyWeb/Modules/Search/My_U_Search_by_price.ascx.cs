using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;

namespace MyWeb.Modules.Search
{
    public partial class My_U_Search_by_price : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Session["price_search"]!=null)
                {
                    List<Data.Product> list = new List<Product>();
                    list = ProductService.Product_GetByTop("100000000"," " +Session["price_search"].ToString()+" ","");
                    if (list.Count > 0)
                    {
                        dtlsp_search_by_price.DataSource = list;
                        dtlsp_search_by_price.DataBind();
                    }
                    else
                    {
                        Response.Redirect("/searchResult.aspx");
                    }
                }
            }
        }
    }
}