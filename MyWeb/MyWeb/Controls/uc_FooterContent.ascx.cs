using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;

namespace MyWeb.Controls
{
    public partial class uc_FooterContent : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadFooter();
        }

        private void LoadFooter() {
            List<Data.Config> list = new List<Config>();
            list = ConfigService.Config_GetByTop("1", "IsApply=1","");
            if(list.Count>0){
                ltrFooter.Text = list[0].Footer;
            }
        }
    }
}