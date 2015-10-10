using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using MyWeb.Business;
using MyWeb.Common;

namespace MyWeb.Controls
{
    public partial class Bootom : System.Web.UI.UserControl
    {
        private string Lang = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = Global.GetLang();
            if (!IsPostBack)
            {
                //ViewInformation();
                ltrContent.Text = GlobalClass.Copyright;
                //ViewPage();
            }
        }
        #region[ViewPage]
        void ViewPage()
        {
            string Chuoi = "";
            List<Data.Page> list = Business.PageService.Page_GetByPosition("3", Lang, 5);
            for (int i = 0; i < list.Count; i++)
            {
                Chuoi += string.Format("<a href=\"{0}\" title=\"{1}\">{1}</a>", list[i].Link, list[i].Name);
                if (i != list.Count - 1)
                {
                    Chuoi += " | ";
                }
            }
            //ltrmenu.Text = Chuoi;
            list.Clear();
            list = null;
        }
        #endregion

       
    }
}