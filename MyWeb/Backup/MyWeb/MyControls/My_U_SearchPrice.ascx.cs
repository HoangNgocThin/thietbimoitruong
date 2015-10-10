using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWeb.MyControls
{
    public partial class My_U_SearchPrice : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["rdopricevalue"] != null)
                {
                    rdobtnprice.SelectedValue = Session["rdopricevalue"].ToString();
                } 
            }
        }

        protected void btnsearchprice_Click(object sender, EventArgs e)
        {
            Session.Remove("rdopricevalue");
            if (!rdobtnprice.SelectedValue.ToString().Equals(""))
            {
                Session["price_search"] = getstring(rdobtnprice.SelectedValue.ToString());
                Session["rdopricevalue"] = rdobtnprice.SelectedValue.ToString();
                Response.Redirect("/searchprice.aspx");
            }
            
        }
        string getstring(string values)
        {
            string strprice = "";
            if (Int32.Parse(values) == 0)
            {
                strprice = "Price < 50000";
            }
            if (Int32.Parse(values) == 1)
            {
                strprice = "Price >= 50000 and Price < 100000";
            }
            if (Int32.Parse(values) == 2)
            {
                strprice = "Price >= 100000 and Price < 150000";
            }
            if (Int32.Parse(values) == 3)
            {
                strprice = "Price >= 150000 and Price < 200000";
            }
            if (Int32.Parse(values) == 4)
            {
                strprice += "Price >= 200000 and Price < 300000";
            }
            return strprice;
        }
    }
}