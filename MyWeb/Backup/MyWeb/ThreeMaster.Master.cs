using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;
using MyWeb.Common;

namespace MyWeb
{
    public partial class ThreeMaster : System.Web.UI.MasterPage
    {
        private string Lang = "";
        public string strHome = "Trang chủ";
        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = Global.GetLang();
            if (Lang == "vi")
            {
                strHome = "Trang chủ";
            }
            else
            {
                strHome = "Home";
            }
            LoadConfigVariable();
            ltrAdvMid.Text = Business.AdvertiseService.Advertise_ViewByPosition("5", Lang);
            string strAdv = "";
            string strAdvLeft = Business.AdvertiseService.Advertise_ViewByPosition("8", Lang);
            string strAdvRight = Business.AdvertiseService.Advertise_ViewByPosition("9", Lang);
            strAdv += "<div id=\"divAdvLeft\">" + strAdvLeft + "</div>";
            strAdv += "<div id=\"divAdvRight\">" + strAdvLeft + "</div>";
            ltrAdv.Text = strAdv;
            string htmlHead = Common.StringClass.Check(GlobalClass.PlaceHead) ? GlobalClass.PlaceHead : string.Empty;
            if (Common.StringClass.Check(GlobalClass.GoogleId))
            {
                htmlHead += "<script language=\"javascript\" type=\"text/javascript\"> var _gaq=_gaq||[];_gaq.push(['_setAccount','" + GlobalClass.GoogleId + "']);_gaq.push(['_trackPageview']);(function(){var a=document.createElement('script');a.type='text/javascript';a.async=true;a.src=('https:'==document.location.protocol?'https://ssl':'http://www')+'.google-analytics.com/ga.js';var b=document.getElementsByTagName('script')[0];b.parentNode.insertBefore(a,b)})() </script>";
            }
            ltrHead.Text = htmlHead;
            //ltrBody.Text = Common.StringClass.Check(GlobalClass.PlaceBody) ? GlobalClass.PlaceBody : string.Empty;
        }

        void LoadConfigVariable()
        {
            List<Data.Config> list = ConfigService.Config_GetByAll(Lang);
            if (list.Count > 0)
            {
                GlobalClass.Mail_Smtp = list[0].Mail_Smtp;
                GlobalClass.Mail_Port = list[0].Mail_Port;
                GlobalClass.Mail_Noreply = list[0].Mail_Noreply;
                GlobalClass.Mail_Info = list[0].Mail_Info;
                GlobalClass.Mail_Password = list[0].Mail_Password;
                GlobalClass.PlaceHead = list[0].PlaceHead;
                GlobalClass.PlaceBody = list[0].PlaceBody;
                GlobalClass.GoogleId = list[0].GoogleId;
                GlobalClass.Contact = list[0].Contact;
                GlobalClass.Copyright = list[0].Copyright;
                GlobalClass.Title = list[0].Title;
                GlobalClass.Description = list[0].Description;
                GlobalClass.Keyword = list[0].Keyword;
            }
        }
    }
}