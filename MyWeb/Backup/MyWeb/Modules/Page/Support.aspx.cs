using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWeb.Modules.Page
{
    public partial class Support : System.Web.UI.Page
    {
        private string Lang = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = Global.GetLang();
            string Chuoi = "";
            List<Data.Support> list = new List<Data.Support>();
            list = Business.SupportService.Support_GetByAll(Lang);
            for (int i = 0; i < list.Count; i++)
            {
                //Type Yahoo
                if(list[i].Type == "1"){
                    Chuoi += string.Format("<div class=\"sup_block\"><div class=\"sup_img\"><a href=\"ymsgr:sendim?{0}\"><img src=\"http://opi.yahoo.com/online?u={0}&amp;t=2\" alt=\"{1}\" align=\"middle\"/></a></div><span class=\"sup_name\">{1}</span><br/><span class=\"sup_tel\">{2}</span></div>", list[i].Nick, list[i].Name, list[i].Tel);
                }
                //Type Skype
                else{
                    Chuoi += string.Format("<div class=\"sup_block\"><div class=\"sup_img\"><a href=\"skype:{0}?chat\"><img src=\"http://mystatus.skype.com/smallclassic/{0}\" alt=\"{1}\" align=\"middle\"/></a></div><span class=\"sup_name\">{1}</span><br/><span id=\"sup_tel\">{2}</span></div>", list[i].Nick, list[i].Name, list[i].Tel);
                }
            }
            list.Clear();
            list = null;
            ltrSupport.Text = Chuoi;
        }
    }
}