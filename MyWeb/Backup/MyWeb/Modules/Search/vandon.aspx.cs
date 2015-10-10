using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWeb.Modules.Search
{
    public partial class vandon : System.Web.UI.Page
    {
        string Code = "";
        string Id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Literal ltrNav = (Literal)Common.PageHelper.FindControl(this.Master, "ltrNavContent");
            ltrNav.Text = "Tra cứu vận đơn";
            Code = Page.RouteData.Values["Code"] as string;
            Id = Page.RouteData.Values["Id"] as string;
            if (Common.StringClass.Check(Code))
            {
                cboCarriers.Value = Code;
                txtCode.Text = Code;
                ltrMessage.Text = "Không tìm thấy vận đơn!";
            }
            if (Common.StringClass.Check(Id))
            {
                txtAwbId.Text = Id;
            }
            //ltrResult.Text = "<tr><td class=\"col1\">&nbsp;</td><td class=\"col2\">&nbsp;</td><td class=\"col3\">&nbsp;</td><td class=\"col4\">&nbsp;</td><td class=\"col5\">&nbsp;</td><td class=\"col6\">&nbsp;</td><td class=\"col7\">&nbsp;</td><td class=\"col8\">&nbsp;</td></tr>";
        }
    }
}