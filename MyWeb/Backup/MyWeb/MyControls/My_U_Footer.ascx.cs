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
    public partial class My_U_Footer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            showlist();
        }
        void showlist()
        {
            List<Data.Company> list = new List<Company>();
            list = CompanyService.Company_GetByAll();
            string chuoi = "";
            chuoi += "<div id='ft_left'>";
            if (list.Count>0)
            {
                chuoi += "<span>Copyright © by " + list[0].Name + "</span>"; 
            }
            chuoi += "<table>";
            chuoi += "<tr>";
            chuoi += "<td align='left' valign='top'>";
            chuoi += "<h5>Nhà sản xuất :</h5>";
            chuoi += "</td>";
            chuoi += "<td valign='top'>";
            chuoi += "<span>PAGIN BIOTECH CO.,Ltd (Korea)</span>";
            chuoi += "</td>";
            chuoi += "</tr>";
            chuoi += "<tr>";
            chuoi += "<td align='left' valign='top'>";
            chuoi += "<h5>Nhà phân phối :</h5>";
            chuoi += "</td>";
            chuoi += "<td valign='top'>";

            chuoi += "<p>" + list[0].Name +" - "+list[0].Address+ "</p>";
            chuoi += "<p>Số điện thoại :" + list[0].PhoneNumber + " Fax: " + list[0].Fax + " Website: <a href='http://paginvn.incontek.com/'>http://paginvn.incontek.com/</a>" + "</p>";
            chuoi += "</td>";
            chuoi += "</tr>";
            chuoi += "</table>";
            chuoi += "</div>";
            chuoi += "<div id='ft_right'>";
            chuoi += "<p>SẢN PHẨM CÓ BÁN TẠI :</p>";
            chuoi += "<p>Các cửa hàng chuyên nghiệp của Pagin</p>";
            chuoi += "<p>Các siêu thị trên toàn quốc</p>";
            chuoi += "</div>";
            ltrfooter.Text = chuoi;
        }
    }
}