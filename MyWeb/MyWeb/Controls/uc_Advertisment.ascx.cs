using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Business;
using MyWeb.Data;
namespace MyWeb.Controls
{
    public partial class uc_Advertisment : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                LoadAdvertisment();
            }
        }
        private void LoadAdvertisment()
        {
            List<Data.Advertise> list = new List<Advertise>();
            list = AdvertiseService.Advertise_GetByTop("", "Active=1 and Position=0", "Ord");
            if (list.Count > 0)
            {
                string str="";
                for (int i = 0; i < list.Count;i++ )
                {
                    str += "<li><a href='"+list[i].Link+"'> <img src='"+list[i].Image+"'/></a></li>";
                }
                ltrAdvertisment.Text = str;
            }
        }
    }
}