using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;

namespace MyWeb.Modules.Page
{
    public partial class ListShop : System.Web.UI.Page
    {
        string shopaddress;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["shopaddress"] != null)
                {
                    shopaddress = Session["shopaddress"].ToString();
                }

                showlist(shopaddress); 
            }

        }
        void showlist(string address)
        {
            List<Data.Shop> list = new List<Shop>();
            list = ShopService.Shop_GetByAddress(address);
            string chuoi = "";
            if(list.Count>0)
            {
                for (int i = 0; i < list.Count;i++ )
                {
                    if ((i+1) == list.Count)
                    {
                        chuoi += "<div class='dv_listshop_last'>";
                        chuoi += "<h5>" + list[i].Name + "</h5>";
                        chuoi += "<p>" + list[i].Address + "</p>";
                        chuoi += "<p>Điện thoại :" + list[i].PhoneNumber + "</p>";
                        chuoi += "</div>";
                    }
                    else
                    {
                        chuoi += "<div class='dv_listshop'>";
                        chuoi += "<h5>" + list[i].Name + "</h5>";
                        chuoi += "<p>" + list[i].Address + "</p>";
                        chuoi += "<p>Điện thoại :" + list[i].PhoneNumber + "</p>";
                        chuoi += "</div>";
                    }
                }
            }
            ltrlistshop.Text = chuoi;
           // Session.Remove("shopaddress");
        }
    }
}