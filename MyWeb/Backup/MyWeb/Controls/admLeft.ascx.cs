using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Common;

namespace MyWeb.Controls
{
    public partial class admLeft : System.Web.UI.UserControl
    {
        string admin = "0";
        private const string default_path_file = "/Admin/Default.aspx";  
        public string LastLoadedPage
        {
            get {  return ViewState["LastLoaded"] as string; }
            set { ViewState["LastLoaded"] = value; } 
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                LastLoadedPage = default_path_file;
            }
            if (admin == "1")
            {             
                pnTintuc.Visible = true;
                pnNhomtin.Visible = true;
                //pnNhomanh.Visible = true;               
            }
            else
            {
                pnTintuc.Visible = true;               
                pnNhomtin.Visible = true;
                //pnNhomanh.Visible = true;
                

            }
        }

        protected void LinkButton_Click(object sender, EventArgs e)
        {
            LinkButton lbt = (LinkButton)sender;
            string strPage = lbt.ID.Replace("lbt", "/Admin/") + ".aspx";
            if (System.IO.File.Exists(GlobalClass.PhysicalApplicationPath(LastLoadedPage))){
                LastLoadedPage = strPage;
            }
            Panel currentPanel = (Panel)lbt.Parent;
            Session["currentPanel"] = currentPanel.ID;
            Response.Redirect(LastLoadedPage);
        }
    }
}