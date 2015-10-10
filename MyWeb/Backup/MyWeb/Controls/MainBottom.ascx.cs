using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Business;
using MyWeb.Common;
using System.Data;

namespace MyWeb.Controls
{
    public partial class MainBottom : System.Web.UI.UserControl
    {
        private string Lang = "";
        string pagLevel = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = Global.GetLang();
            string strUrl = Request.Url.AbsolutePath.ToString().ToLower();
            string strgrnId = Page.RouteData.Values["Subject"] as string;
            List<Data.Page> list = new List<Data.Page>();
            list = strUrl.Contains("/news/") ? PageService.Page_GetByURL(strUrl, Lang, strgrnId) : PageService.Page_GetByURL(strUrl, Lang);
            if (list.Count > 0) pagLevel = list[0].Level;
            if (!IsPostBack)
            {
                LoadMenu_Bottom();
                //ltr_copyright.Text = GlobalClass.Copyright;
                //ViewPage();
                //Show_Title_By_Lang(Lang);
            }
        }
        //void Show_Title_By_Lang(string language)
        //{
        //    if (language.ToString().ToLower().Equals("en"))
        //    {
        //        Label1.Text = "Sign up to receive news from us";
        //        lblTitlesend.Text = "Your Email Address:";
        //    }
        //}
        private void LoadMenu_Bottom()
        {
            string Chuoi = "";
            List<Data.Page> list = Business.PageService.Page_GetByPosition("1", Lang, 5);
            if (list.Count > 0)
            {
                Chuoi += "<table id=\"Menu_Bottom\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">";
                Chuoi += "<tr>";
                int u = 0;
                for (int i = 0; i < list.Count; i++)
                {

                    u++;
                    Chuoi += string.Format("<td><div class=\"Menu_bt_cate\">{0}</div>", list[i].Name);
                    List<Data.Page> listsub = Business.PageService.Page_GetByLevel(list[i].Level, Lang, 10);
                    if (listsub.Count > 0)
                    {

                        Chuoi += "<div class=\"menu_bt_sub\">";
                        for (int j = 0; j < listsub.Count; j++)
                        {

                            Chuoi += string.Format("<a href=\"{0}\" target=\"{1}\" title=\"{2}\">{2}</a>", listsub[j].Link, listsub[j].Target, listsub[j].Name) + "\n";

                        }
                        Chuoi += "</div>";

                    }
                    Chuoi += "</td>";
                    listsub.Clear();
                    listsub = null;
                }
                Chuoi += "</tr>";
                Chuoi += "</table>";
            }
            list.Clear();
            list = null;
            this.ltr_Menu.Text = Chuoi;
        }

        //protected void ibtSendEmail_Click(object sender, ImageClickEventArgs e)
        //{
        //    if (this.txtEmail.Text.Trim().Length > 0)
        //    {
        //        //DataTable dtm = new DataTable();
        //        //DataSet ds = new DataSet();
        //        //ds.ReadXml(Server.MapPath("List_mail.xml"));
        //        //dtm = ds.Tables[0];
        //        //DataRow dr = dtm.NewRow();
        //        //dr["MAIL"] = this.txtEmail.Text.Trim();
        //        //dr["STATUS"] = "0";
        //        //dtm.Rows.Add(dr);
        //        //dtm.DataSet.WriteXml(Server.MapPath("List_mail.xml"));
        //        Data.EmailRegisters obj = new Data.EmailRegisters();
        //        obj.Email = this.txtEmail.Text.Trim();
        //        obj.Createdate = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
        //        obj.Status = "0";
        //        Business.EmailRegistersService.EmailRegisters_Insert(obj);
        //        this.txtEmail.Text = "";
        //    }
        //}
    }
}