using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;
using System.Data;

namespace MyWeb.MyControls
{
    public partial class My_U_Top : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //showMenu();
           // showbanner();
            
            if(!IsPostBack)
            {
                loadsessioncart();
                Viewlistmen();
                loadlogobanner();
            }
        }
        //void showMenu()
        //{
        //    string chuoi="";
        //    List<Data.Page> list = new List<Data.Page>();
        //    list = PageService.Page_GetByTop("100","len(Level)=5","Level ASC");
        //    chuoi+="<div id='topnav'>";
        //    chuoi+="<ul>";
        //    if (list.Count>0)
        //    {
        //        for (int i = 0; i < list.Count; i++)
        //        {
        //            if (list[i].Link.Trim().Equals("/Default.aspx"))
        //            {
        //                chuoi += "<li><a href='" + list[i].Link + "'>" + list[i].Name + "</a></li>";
        //            }
        //            else
        //            {
        //                chuoi += "<li><a href='" + list[i].Link + "'>" + list[i].Name + "</a></li>";
        //            }
        //        } 
        //    }
        //    chuoi += "</ul>";
        //    chuoi += "</div>";
        //    ltrtopnav.Text = chuoi;
        //}
        //void showbanner()
        //{
        //    List<Data.Advertise> listlogo = new List<Advertise>();
        //    listlogo = AdvertiseService.Advertise_GetByTop("1","Name like '%Logo%' and Lang='vi'","");
        //    if(listlogo.Count>0)
        //    {
        //        ltrlogo.Text = "<a href='#'><img src='"+listlogo[0].Image+"' /></a>";
        //    }
        //    List<Data.Advertise> listbanner = new List<Advertise>();
        //    listbanner = AdvertiseService.Advertise_GetByTop("1", "Name like '%Banner%'  and Lang='vi'", "");
        //    if (listbanner.Count > 0)
        //    {
        //        ltrbanner.Text = "<img class='img_banner' src='" + listbanner[0].Image + "' />";
        //    }
        //}
        void Viewlistmen()
        {
            string Chuoi = "";
            string Chuoisub = "";
            List<Data.Page> list = Business.PageService.Page_GetByPosition("1","vi",5);
            for (int i = 0; i < list.Count; i++)
            {
                List<Data.Page> listsub = Business.PageService.Page_GetByLevel(list[i].Level, "vi", 10);
                if (listsub.Count > 0)
                {
                    if (list[i].Type == "1" || (list[i].Type == "2" && list[i].Link != "Default.aspx"))
                    {
                        Chuoi += "<li><a href=\"" + list[i].Link + "\" rel=\"ddsubmenu" + i + "\">" + list[i].Name + "</a></li>";
                    }
                    else
                    {
                        Chuoi += "<li><a href=\"" + list[i].Link + "\" rel=\"ddsubmenu" + i + "\">" + list[i].Name + "</a></li>";
                    }
                    Chuoisub += "<ul id=\"ddsubmenu" + i + "\" class=\"ddsubmenustyle\">";
                    for (int j = 0; j < listsub.Count; j++)
                    {
                        List<Data.Page> listsub1 = Business.PageService.Page_GetByLevel(listsub[j].Level, "vi", 15);
                        if (listsub1.Count > 0)
                        {
                            if (listsub[j].Type == "1" || (listsub[j].Type == "2" && listsub[j].Link != "Default.aspx"))
                            {
                                Chuoisub += "<li><a href=\"" + listsub[j].Link + "\">" + listsub[j].Name + "</a>";
                                Chuoisub += "<ul>";
                                for (int t = 0; t < listsub1.Count; t++)
                                {
                                    if (listsub1[j].Type == "1")
                                    {
                                        Chuoisub += "<li><a href=\"" + listsub1[t].Link + "\">" + listsub1[t].Name + "</a></li>";
                                    }
                                    else
                                    {
                                        Chuoisub += "<li><a href=\"" + listsub1[t].Link + "\">" + listsub1[t].Name + "</a></li>";
                                    }
                                }
                                Chuoisub += "</ul>";
                                Chuoisub += "</li>";
                            }
                            else
                            {
                                Chuoisub += "<li><a href=\"" + listsub[j].Link + "\">" + listsub[j].Name + "</a>";
                                Chuoisub += "<ul>";
                                for (int t = 0; t < listsub1.Count; t++)
                                {
                                    if (listsub1[j].Type == "1")
                                    {
                                        Chuoisub += "<li><a href=\"" + listsub1[t].Link + "\">" + listsub1[t].Name + "</a></li>";
                                    }
                                    else
                                    {
                                        Chuoisub += "<li><a href=\"" + listsub1[t].Link + "\">" + listsub1[t].Name + "</a></li>";
                                    }
                                }
                                Chuoisub += "</ul>";
                                Chuoisub += "</li>";
                            }
                        }
                        else
                        {
                            if (listsub[j].Type == "1" || (listsub[j].Type == "2" && listsub[j].Link != "Default.aspx"))
                            {
                                Chuoisub += "<li><a href=\"" + listsub[j].Link + "\">" + listsub[j].Name + "</a></li>";
                            }
                            else
                            {
                                Chuoisub += "<li><a href=\"" + listsub[j].Link + "\">" + listsub[j].Name + "</a></li>";
                            }
                        }
                    }
                    Chuoisub += "</ul>";
                }
                else
                {
                    if (list[i].Type == "1" || (list[i].Type == "2" && list[i].Link != "Default.aspx"))
                    {
                        Chuoi += "<li><a href=\"" + list[i].Link + "\">" + list[i].Name + "</a></li>";
                    }
                    else
                    {
                        Chuoi += "<li><a href=\"" + list[i].Link + "\"><span>" + list[i].Name + "</span></a></li>";
                    }
                }
            }
            ltrmain.Text = Chuoi;
            ltrsub.Text = Chuoisub;
            list.Clear();
            list = null;
        }
        void loadsessioncart()
        {
            if (Session["Cart"] != null)
            {
                DataTable dt = new DataTable();
                dt = (DataTable)Session["Cart"];
                Double price = 0;
                int quantity = 0;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        price += Double.Parse(dt.Rows[i]["Total"].ToString());
                        quantity += Int32.Parse(dt.Rows[i]["Quantity"].ToString());
                    }
                    string chuoi = "";
                    chuoi += "<li class='class_quantity'>Số lượng sản phẩm: " + quantity.ToString()+", " +"Tổng tiền: " + Format_Price(price.ToString()) + " VND" + "</li>";
                    ltrcartinfor.Text = chuoi;
                }
                else
                {
                    ltrcartinfor.Text = "";
                }
            }
            else
            {
                ltrcartinfor.Text = "";
            }
        }
        protected string Format_Price(string Price)
        {
            Price = Price.Replace(".", "");
            Price = Price.Replace(",", "");
            string tmp = "";
            while (Price.Length > 3)
            {
                tmp = "." + Price.Substring(Price.Length - 3) + tmp;
                Price = Price.Substring(0, Price.Length - 3);
            }
            tmp = Price + tmp;
            return tmp;
        }
        void loadlogobanner()
        {
            List<Data.Advertise> listadv = new List<Advertise>();
            listadv = AdvertiseService.Advertise_GetByPosition("1","vi");
            string chuoi = "";
            if(listadv.Count>0)
            {
                chuoi += "<a href='"+listadv[0].Link+"'><img src='"+listadv[0].Image+"'/></a>";
                ltrlogo.Text = chuoi;
            }

            List<Data.Advertise> listbanner = new List<Advertise>();
            listbanner = AdvertiseService.Advertise_GetByPosition("5","vi");
            string chuoi1 = "";
            if (listbanner.Count>0)
            {
                chuoi1 += "<img src='" + listbanner[0].Image + "'/>";
                ltrbanner.Text = chuoi1; 
            }
        }
    }
}