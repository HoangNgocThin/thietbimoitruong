using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace MyWeb
{
    public partial class DefaultMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Viewlistmen();
                LoadBanner();
                DataTable dt = (DataTable)Session["cart"];
                if (dt != null)
                {

                    ltrCartInfor.Text = "Giỏ hàng đang có (" + dt.Rows.Count.ToString() + ") sản phẩm";

                }
            }
            this.countMe();

            DataSet tmpDs = new DataSet();
            tmpDs.ReadXml(Server.MapPath("~/counter.xml"));

            lblCounter.Text = tmpDs.Tables[0].Rows[0]["hits"].ToString();

        }

        private void countMe()
        {
            DataSet tmpDs = new DataSet();
            tmpDs.ReadXml(Server.MapPath("~/counter.xml"));

            int hits = Int32.Parse(tmpDs.Tables[0].Rows[0]["hits"].ToString());

            hits += 1;

            tmpDs.Tables[0].Rows[0]["hits"] = hits.ToString();

            tmpDs.WriteXml(Server.MapPath("~/counter.xml"));

        }

        void Viewlistmen()
        {
            string Chuoi = "";
            string Chuoisub = "";
            List<Data.PageLink> list = Business.PageLinkService.PageLink_GetByPosition("2", 5);
            list = list.OrderBy(x => x.Ord).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                List<Data.PageLink> listsub = Business.PageLinkService.PageLink_GetByLevel(list[i].Level, 10);
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
                        List<Data.PageLink> listsub1 = Business.PageLinkService.PageLink_GetByLevel(listsub[j].Level, 15);
                        if (listsub1.Count > 0)
                        {
                            if (listsub[j].Type == "1" || (listsub[j].Type == "2" && listsub[j].Link != "Default.aspx"))
                            {
                                Chuoisub += "<li><a href=\"" + listsub[j].Link + "\">" + listsub[j].Name + "</a>";
                                Chuoisub += "<ul class='mnuthreeChild'>";
                                for (int t = 0; t < listsub1.Count; t++)
                                {
                                    if (listsub1[t].Type == "1")
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
                    if (list[i].Name.Trim().Equals("Sản phẩm"))
                    {
                        Chuoi += "<li><a href=\"" + list[i].Link + "\" rel=\"ddsubmenu" + i + "\">" + list[i].Name + "</a></li>";
                        List<Data.ProductCategory> listprocate = new List<ProductCategory>();
                        listprocate = ProductCategoryService.ProductCategory_GetByPosition("2", 5);
                        if (listprocate.Count > 0)
                        {
                            Chuoisub += "<ul id=\"ddsubmenu" + i + "\" class=\"ddsubmenustyle\">";
                            for (int n = 0; n < listprocate.Count; n++)
                            {
                                List<Data.ProductCategory> listprocateSub = new List<ProductCategory>();
                                listprocateSub = ProductCategoryService.ProductCategory_GetByLevel(listprocate[n].Level, 10);
                                if (listprocateSub.Count > 0)
                                {
                                    Chuoisub += "<li><a href='/ProductList/"+listprocate[n].ID+"/"+listprocate[n].Tag+".html'>" + listprocate[n].Name + "</a>";
                                    Chuoisub += "<ul>";
                                    for (int k = 0; k < listprocateSub.Count; k++)
                                    {
                                        Chuoisub += "<li><a href='/ProductList/" + listprocateSub[k].ID + "/" + listprocateSub[k].Tag + ".html'>" + listprocateSub[k].Name + "</a></li>";
                                    }
                                    Chuoisub += "</ul>";
                                    Chuoisub += "</li>";
                                }
                                else
                                {
                                    Chuoisub += "<li><a href='/ProductList/" + listprocate[n].ID + "/" + listprocate[n].Tag + ".html'/>" + listprocate[n].Name + "</a></li>";
                                }
                            }
                            Chuoisub += "</ul>";
                        }
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
            }
            ltrmain.Text = Chuoi;
            ltrsub.Text = Chuoisub;
            list.Clear();
            list = null;
        }
        private void LoadBanner()
        {
            List<Data.Config> list = new List<Config>();
            list = ConfigService.Config_GetByTop("1", "IsApply=1", "");
            if (list.Count > 0)
            {
               ltrBanner.Text = "<img class='banner' src='" + list[0].Banner + "' />";
            }
        }
    }
}