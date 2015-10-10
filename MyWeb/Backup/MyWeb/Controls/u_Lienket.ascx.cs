using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWeb.Controls
{
    public partial class u_Lienket : System.Web.UI.UserControl
    {
        string lang = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["lang"] != null) { lang = Session["lang"].ToString(); } else { lang = "vi"; }
            if (!IsPostBack)
            {
                Viewlist();
                if (lang == "vi")
                {
                    ltrHead.Text = "Link liên kết";
                }
                else
                {
                    ltrHead.Text = "Links";
                }
            }
        }
        #region[Viewlist]
        void Viewlist()
        {
            drlLink.Items.Clear();
            if (lang == "vi")
            {
                drlLink.Items.Add(new ListItem("---Chọn liên kết---", "#"));
            }
            else
            {
                drlLink.Items.Add(new ListItem("---Selected Links---", "#"));
            }
            List<Data.Link> list = Business.LinkService.Link_GetByAll(lang);
            for (int i = 0; i < list.Count; i++)
            {
                drlLink.Items.Add(new ListItem(list[i].Name, list[i].Link1));
            }
            list.Clear();
            list = null;
        }
        #endregion

        protected void drlLink_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drlLink.SelectedValue == "#")
            {
                Response.Redirect(this.drlLink.SelectedValue);
            }
            else
            {
                //Response.Redirect(drlLink.SelectedValue);
                Response.Write("<script>window.open('" + drlLink.SelectedValue + "','_blank');</script>");
                //string ScriptBlog = "<script language='javascript'>window.open('" + drlLink.SelectedValue + "')</script>";
                //Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "SelectedIndexChanged", ScriptBlog);
            }
        }
    }
}