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
    public partial class My_U_adv : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            showlist();
        }

        void showlist()
        {
            string chuoi = "";
            List<Data.Advertise> list = new List<Advertise>();
            list = AdvertiseService.Advertise_GetByTop("10","Lang='vi' and Active=1 and position=9","");
            if(list.Count>0)
            {
                for (int i = 0; i < list.Count; i++)
			        {
			            chuoi += "<div class='dv_km_img'>";
                        chuoi += "<a href='"+list[i].Link+"'><img alt='"+list[i].Name+"' src='"+list[i].Image+"'/></a> ";
                        chuoi += "</div>"; 
			        }
            }
            ltradv.Text = chuoi;
        }
    }
}