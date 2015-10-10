using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWeb.Modules.Search
{
    public partial class lichbay : System.Web.UI.Page
    {
        string Code = "";
        string Date = "";
        string Type = ""; 
        protected void Page_Load(object sender, EventArgs e)
        {
            Literal ltrNav = (Literal)Common.PageHelper.FindControl(this.Master, "ltrNavContent");
            ltrNav.Text = "Tra cứu lịch bay";
            Code = Page.RouteData.Values["Code"] as string;
            Date = Page.RouteData.Values["Date"] as string;
            Type = Page.RouteData.Values["Type"] as string;
            if (IsPostBack){
                ltrMessage.Text = "";
            }
            if (radType.Text == "IMP")
            {
                ltrHour.Text = "Giờ hạ cánh (đến)";
                ltrType.Text = "Điểm xuất phát (đến)";
            }else
            {
                ltrHour.Text = "Giờ xuất phát (đi)";
                ltrType.Text = "Điểm đến (đi)";
            }
            if (Common.StringClass.Check(Code))
            {
                cboCarriers.Value = Code;
                ltrMessage.Text = "Không tìm thấy lịch bay!";
            }
            if (Common.StringClass.Check(Date))
            {
                txtDate.Text = Common.DateTimeClass.ConvertDate(Date);
            }
            if (Common.StringClass.Check(Type))
            {
                radType.Text = Type.ToUpper();
            }
            //ltrResult.Text = "<tr><td class=\"col1\">&nbsp;</td><td class=\"col2\">&nbsp;</td><td class=\"col3\">&nbsp;</td><td class=\"col4\">&nbsp;</td><td class=\"col5\">&nbsp;</td><td class=\"col6\">&nbsp;</td><td class=\"col7\">&nbsp;</td><td class=\"col8\">&nbsp;</td></tr>";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}