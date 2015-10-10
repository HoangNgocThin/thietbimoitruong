using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MyWeb.MyControls
{
    public partial class My_U_CartInfo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Cart"]!=null)
            {
                DataTable dt = new DataTable();
                dt = (DataTable)Session["Cart"];
                Double price=0;
                int quantity = 0;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        price += Double.Parse(dt.Rows[i]["Total"].ToString());
                        quantity += Int32.Parse(dt.Rows[i]["Quantity"].ToString());
                    }
                    string chuoi = "";
                    chuoi += "<li class='class_quantity'>Số lượng sản phẩm : " + quantity.ToString() + "</li>";
                    chuoi += "<li>Tổng tiền :" + Format_Price(price.ToString()) + " VND" + "</li>";
                    ltrinforcart.Text = chuoi;
                }
                else
                {
                    Session.Remove("Cart");
                }
            }
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