using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWeb.Controls
{
    public partial class u_Hotrotructuyen : System.Web.UI.UserControl
    {
        string lang = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //lang = Session["lang"].ToString();
            //string strUrl = Request.Url.AbsolutePath.ToString().ToLower();
            //strUrl = strUrl == "" ? "/" : strUrl.Replace("default.aspx", "");
            //List<Data.Page> list = Business.PageService.Page_GetByLink(strUrl,lang);
            //string Chuoi = "";
            //if (list.Count > 0)
            //{
            //    List<Data.Support> listsubport = Business.SupportService.Support_GetByTop("20", "Lang='"+ lang +"'", "Ord");
            //    if (listsubport.Count > 0)
            //    {
            //        for (int i = 0; i < listsubport.Count; i++)
            //        {
            //            Chuoi += "<div class=\"online-box\"><a href=\"ymsgr:sendim?" + listsubport[i].Nick + "\" title=\"" + listsubport[i].Name + "\"><img src=\"http://opi.yahoo.com/online?u=" + listsubport[i].Nick + "&amp;\" style=\"border: 0px\" alt=\"" + listsubport[i].Name + "\" title=\"" + listsubport[i].Name + "\">" + listsubport[i].Name + "</a></div>";
            //        }
            //    }
            //    ltrlist.Text = Chuoi;
            //    listsubport.Clear();
            //    listsubport = null;
            //}
            //else
            //{
            //    List<Data.Support> listsubport = Business.SupportService.Support_GetByAll(lang);
            //    if (listsubport.Count > 0)
            //    {
            //        for (int i = 0; i < listsubport.Count; i++)
            //        {
            //            Chuoi += "<div class=\"online-box\"><a href=\"ymsgr:sendim?" + listsubport[i].Nick + "\" title=\"" + listsubport[i].Name + "\"><img src=\"http://opi.yahoo.com/online?u=" + listsubport[i].Nick + "&amp;\" style=\"border: 0px\" alt=\"" + listsubport[i].Name + "\" title=\"" + listsubport[i].Name + "\">" + listsubport[i].Name + "</a></div>";
            //        }
            //    }
            //    ltrlist.Text = Chuoi;
            //    listsubport.Clear();
            //    listsubport = null;
            //}
            //list.Clear();
            //list = null;
            //if (lang == "vi")
            //{
            //    ltrHead.Text = "Hỗ trợ trực tuyến";
            //}
            //else
            //{
            //    ltrHead.Text = "Online Support";
            //}
            string Chuoi = "";
            lang = Global.GetLang();
            List<Data.Support> list = new List<Data.Support>();
            list = Business.SupportService.Support_GetByAll(lang);
            int k = 0;
            for (int i = 0; i < list.Count; i++)
            {
                k++;
                if (k % 2 == 0)
                {
                    //Type Yahoo
                    if (list[i].Type == "1")
                    {
                        Chuoi += string.Format("<div class=\"sup_block\"><div class=\"sup_img\"><a href=\"ymsgr:sendim?{0}\"><img src=\"http://opi.yahoo.com/online?u={0}&amp;t=1\" alt=\"{1}\" align=\"middle\"/></a></div><span class=\"sup_name\">{1}</span><br/><span class=\"sup_tel\">{2}</span></div><br/>\n", list[i].Nick, list[i].Name, list[i].Tel);
                    }
                    //Type Skype
                    //else
                    //{
                    //    Chuoi += string.Format("<div class=\"sup_block\"><div class=\"sup_img\"><a href=\"skype:{0}?chat\"><img src=\"http://mystatus.skype.com/smallclassic/{0}\" alt=\"{1}\" align=\"middle\"/></a></div><span class=\"sup_name\">{1}</span><br/><span id=\"sup_tel\">{2}</span></div><br/>\n", list[i].Nick, list[i].Name, list[i].Tel);
                    //}
                }
                else
                {
                    if (list[i].Type == "1")
                    {
                        Chuoi += string.Format("<div class=\"sup_block\"><div class=\"sup_img\"><a href=\"ymsgr:sendim?{0}\"><img src=\"http://opi.yahoo.com/online?u={0}&amp;t=1\" alt=\"{1}\" align=\"middle\"/></a></div><span class=\"sup_name\">{1}</span><br/><span class=\"sup_tel\">{2}</span></div>\n", list[i].Nick, list[i].Name, list[i].Tel);
                    }
                    //Type Skype
                    //else
                    //{
                    //    Chuoi += string.Format("<div class=\"sup_block\"><div class=\"sup_img\"><a href=\"skype:{0}?chat\"><img src=\"http://mystatus.skype.com/smallclassic/{0}\" alt=\"{1}\" align=\"middle\"/></a></div><span class=\"sup_name\">{1}</span><br/><span id=\"sup_tel\">{2}</span></div>\n", list[i].Nick, list[i].Name, list[i].Tel);
                    //}
                }
            }
            list.Clear();
            list = null;
            ltrSupport.Text = Chuoi;
        }

    }
}