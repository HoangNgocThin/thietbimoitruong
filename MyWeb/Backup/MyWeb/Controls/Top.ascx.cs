using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using MyWeb.Business;
using MyWeb.Common;
using System.Data;

namespace MyWeb.Controls
{
    public partial class Top : System.Web.UI.UserControl
    {
        private string Lang = "";
        string pagLevel = "";
        #region[Page_Load]
        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = Global.GetLang();
            if (!IsPostBack)
            {
                string strUrl = Request.Url.AbsolutePath.ToString().ToLower();
                string strgrnId = Page.RouteData.Values["Subject"] as string;
                List<Data.Page> list = new List<Data.Page>();
                list = strUrl.Contains("/news/") ? PageService.Page_GetByURL(strUrl, Lang, strgrnId) : PageService.Page_GetByURL(strUrl, Lang);
                if (list.Count > 0) pagLevel = list[0].Level;
                ltrAdv.Text = Business.AdvertiseService.Advertise_ViewByPosition("1", Lang);
                LoadMetaConfig();
                //LoadMenuDropDownLevel();
                LoadMegaDropDownMenu();
                Show_Title_By_Lang(Lang);
                Show_Info_Shopcart();
            }
        }
        void Show_Title_By_Lang(string language)
        {
            if (language.ToString().ToLower().Equals("en"))
            {
                ltr_help.Text = "Help: 0989 868 999";
                lblsp.Text = "Products";
                lbltitlemoney.Text = "Amount";
                lbtviewcard.Text = "View Cart";
                lbtpay.Text = "Payment";
                this.txtearchen.Visible = true;
                this.txtsearch.Visible = false;
            }
        }
        #endregion
        #region[LoadMetaConfig]
        private void LoadMetaConfig()
        {
            Page.Header.Title = Common.StringClass.Check(Page.Header.Title) ? Page.Header.Title : GlobalClass.Title;
            Page.MetaDescription = Common.StringClass.Check(Page.MetaDescription) ? Page.MetaDescription : GlobalClass.Description;
            Page.MetaKeywords = Common.StringClass.Check(Page.MetaKeywords) ? Page.MetaKeywords : GlobalClass.Keyword;
        }
        #endregion
        #region[LoadTopMenu]
        private void LoadTopMenu()
        {
            string Chuoi = "";
            List<Data.Page> list = Business.PageService.Page_GetByPosition("1", Lang);
            for (int i = 0; i < list.Count; i++)
            {
                Chuoi += string.Format("<a href=\"{0}\">{1}</a> | ", list[i].Link, list[i].Name);
            }
            if (1==1){
                Chuoi += string.Format("<a href=\"/account/logon.aspx\" id=\"btnLogin\">{0}</a>", "Đăng nhập");
            }
            //ltrMenu.Text = Chuoi;
        }
        #endregion
        #region[LoadMenuDropDown]
        private void LoadMenuDropDown()
        {
            string Chuoi = "";
            List<Data.Page> list = Business.PageService.Page_GetByPosition("2", Lang, 5);
            if (list.Count > 0)
            {
                Chuoi += "<ul id=\"mdd\" class=\"clearfix\">";
                int u = 0;
                for (int i = 0; i < list.Count; i++)
                {
                    u = i + 1;
                    List<Data.Page> listsub = Business.PageService.Page_GetByLevel(list[i].Level, Lang, 10, "1");
                    string strSelected = string.Empty;
                    if (pagLevel.Length > 0 && list[i].Level.Substring(0, 5) == pagLevel.Substring(0, 5))
                    {
                        strSelected = " class= \"selected\"";
                    }
                    if (listsub.Count >0)
                    {
                        Chuoi += string.Format("<li{4}><a href=\"{0}\" target=\"{1}\" title=\"{2}\" onmouseover=\"mopen('m{3}')\" onmouseout=\"mclose()\">{2}</a> <div id=\"m{3}\" onmouseover=\"mcancelclose()\" onmouseout=\"mclose()\">", list[i].Link, list[i].Target, list[i].Name, u, strSelected);
                        for (int j = 0; j < listsub.Count; j++)
                        {
                            Chuoi += string.Format("<a href=\"{0}\" target=\"{1}\">{2}</a>", listsub[j].Link, listsub[j].Target, listsub[j].Name);
                        }
                        Chuoi += "</div></li>";
                    }
                    else{
                        Chuoi += string.Format("<li{3}><a href=\"{0}\" target=\"{1}\">{2}</a></li>", list[i].Link, list[i].Target, list[i].Name, strSelected);
                    }
                    //if (i < list.Count -1)
                    //{
                        Chuoi += "<li class=\"sep\">&nbsp;</li>";
                    //}
                }
                //Chuoi += "<li id=\"date\"></li></ul>";
                Chuoi += "</ul>";
            }
            list.Clear();
            list = null;
            //ltrMain.Text = Chuoi;
        }
        #endregion
        #region[LoadMenuDropDownLevel]
        private void LoadMenuDropDownLevel()
        {
            string strMenu = "";
            string strSubMenu = "";
            List<Data.Page> list = Business.PageService.Page_GetByPosition("2", Lang, 5);
            if (list.Count > 0)
            {
                strMenu += "<ul>";
                string mnu = string.Empty;
                for (int i = 0; i < list.Count; i++)
                {
                    mnu = "sub" + (i + 1).ToString();
                    string strSelected = string.Empty;
                    if (pagLevel.Length > 0 && list[i].Level.Substring(0, 5) == pagLevel.Substring(0, 5))
                    {
                        strSelected = " class= \"selected\"";
                    }
                    List<Data.Page> listsub = Business.PageService.Page_GetByLevel(list[i].Level, Lang, 1, "1");
                    if (listsub.Count > 0)
                    {
                        strMenu += string.Format("<li><a{3} href=\"{0}\" target=\"{1}\" rel=\"{4}\">{2}</a></li>", list[i].Link, list[i].Target, list[i].Name, strSelected, mnu);
                        //Begin sub
                        int ilevel = 0, iblevel = 0, k = 0, n = 1, ilength = 5, istartlevel = 1;
                        string tmpLevel = "";
                        for (int j = 0; j < listsub.Count; j++)
                        {
                            tmpLevel = listsub[j].Level;
                            ilevel = (tmpLevel.Length / ilength) - istartlevel;
                            if (ilevel > iblevel)
                            {
                                strSubMenu += ilevel == 1 ? string.Format("<ul id=\"{0}\" class=\"ddsubmenustyle\">", mnu) : "<ul>";
                            }
                            if (ilevel < iblevel)
                            {
                                for (k = 1; k <= (iblevel - ilevel); k++)
                                {
                                    strSubMenu += "</ul>";
                                    if (iblevel > 1) { strSubMenu += "</li>"; }
                                }
                                iblevel = ilevel;
                            }
                            string strName = listsub[j].Name;
                            strSubMenu += string.Format("<li><a href=\"{0}\" target=\"{1}\">{2}</a>", listsub[j].Link, listsub[j].Target, strName);
                            if (Business.PageService.Page_ExistByLevel(tmpLevel, Lang, "1") == false)
                            {
                                strSubMenu += "</li>";
                            }
                            iblevel = ilevel;
                            if (n == listsub.Count)
                            {
                                k = 0;
                                for (k = iblevel - 1; k == 1; k--)
                                {
                                    strSubMenu += "</ul>";
                                    if (iblevel > 1) { strSubMenu += "</ul></li>"; }
                                }
                            }
                            n++;
                        }
                        strSubMenu += "</ul>";
                        //End
                    }
                    else
                    {
                        strMenu += string.Format("<li><a{3} href=\"{0}\" target=\"{1}\">{2}</a></li>", list[i].Link, list[i].Target, list[i].Name, strSelected);
                    }
                    listsub.Clear();
                    listsub = null;
                }
                strMenu += "</ul>";
            }
            list.Clear();
            list = null;
            //ltrMainMenu.Text = strMenu;
            //ltrSubMenu.Text = strSubMenu;
        }
        #endregion

        #region[LoadMegaDropDownMenu]
        private void LoadMegaDropDownMenu()
        {
            string strMenu = "";
            List<Data.Page> list = Business.PageService.Page_GetByPosition("2", Lang);
            if (list.Count > 0)
            {
                int ilevel = 0, iblevel = 0, k = 0, n = 1, ilength = 5, istartlevel = 0;
                string tmpLevel = "";
                for (int j = 0; j < list.Count; j++)
                {
                    string strSelected = string.Empty;
                    if (pagLevel.Length > 0 && list[j].Level == pagLevel.Substring(0, 5))
                    {
                        strSelected = " class= \"mega-hover\"";
                    }
                    tmpLevel = list[j].Level;
                    ilevel = (tmpLevel.Length / ilength) - istartlevel;
                    if (ilevel > iblevel)
                    {
                        strMenu += ilevel == 1 ? string.Format("<ul id=\"mega-menu\" class=\"mega-menu\">") : "<ul>";
                    }
                    if (ilevel < iblevel)
                    {
                        for (k = 1; k <= (iblevel - ilevel); k++)
                        {
                            strMenu += "</ul>";
                            if (iblevel > 1) { strMenu += "</li>"; }
                        }
                        iblevel = ilevel;
                    }
                    string strName = list[j].Name;
                    strMenu += string.Format("<li" + strSelected + "><a href=\"{0}\" target=\"{1}\">{2}</a>", list[j].Link, list[j].Target, strName);
                    if (Business.PageService.Page_ExistByLevel(tmpLevel, Lang, "1") == false)
                    {
                        strMenu += "</li>";
                    }
                    iblevel = ilevel;
                    if (n == list.Count)
                    {
                        k = 0;
                        for (k = iblevel - 1; k == 1; k--)
                        {
                            strMenu += "</ul>";
                            if (iblevel > 1) { strMenu += "</ul></li>"; }
                        }
                    }
                    n++;
                }
                strMenu += "</ul>";
            }
            list.Clear();
            list = null;
            ltrMenu.Text = strMenu;
        }
        #endregion

        void Show_Info_Shopcart()
        {
            DataTable dtcart = new DataTable();
            if (Session["procart"] != null)
            {
                dtcart = (DataTable)Session["procart"];
            }
            if (dtcart.Rows.Count > 0)
            {
                this.lblNumpro.Text = dtcart.Rows.Count.ToString();
                Double SumMoney = 0;
                for (int i = 0; i < dtcart.Rows.Count; i++)
                {
                    SumMoney += double.Parse(dtcart.Rows[i]["money"].ToString());
                }
                this.lblMoney.Text =Format_Price(SumMoney.ToString())+"đ";
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

        protected void lbtviewcard_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Shopcart/0/0/0/0/Gio-hang.aspx");
        }
    }
}