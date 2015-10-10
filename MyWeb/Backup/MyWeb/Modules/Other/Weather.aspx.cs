using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWeb.Modules.Other
{
    public partial class Weather : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strReturn = "";
            try
            {
                string URL = "http://www.nchmf.gov.vn/web/vi-VN/43/Default.aspx";
                string strStart = "<table id=\"_ctl1__ctl5__ctl0_dl_thoitiethieitai\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" width=\"100%\">";
                string strEnd = "<td class=\"trFoter\"><span id=\"_ctl1__ctl5__ctl0_lbl_DuBaoThoiTietCapNhatLuc\">";
                string str1 = Common.PageHelper.GetContent(URL, strStart, strEnd);
                string str2 = Common.PageHelper.GetContent(URL, strEnd, "<TD class=\"thoitiet_rightbox_ver\"></TD>");
                str2 = str2.Substring(0, str2.Length - 5);
                strReturn = str1 + str2;
            }
            catch
            {
                strReturn = "";
            }
            ltrWeather.Text = strReturn;
        }
    }
}