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
    public partial class AboutUs : System.Web.UI.Page
    {
        string pageid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(RouteData.Values["pageid"]!=null)
            {
                pageid = RouteData.Values["pageid"].ToString();
            }
            if(!IsPostBack)
            {
                loadpage();
            }
        }
        void loadpage()
        {
            List<Data.Page> list = new List<Data.Page>();
            list = PageService.Page_GetById(pageid);
            lblheader.Text = list[0].Name;
            ltrpage.Text = list[0].Detail;
        }
    }
}