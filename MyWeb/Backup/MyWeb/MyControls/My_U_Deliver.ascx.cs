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
    public partial class My_U_Deliver : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            showlist();
            if(!IsPostBack)
            {
                loadddlprovince();
            }
        }
        void showlist()
        {
            List<Data.Company> list = new List<Company>();
            list = CompanyService.Company_GetByAll();
            List<Data.Province> listpro = new List<Province>();
            listpro = ProvinceService.Province_GetByAll();
            string chuoi="";
            chuoi += "<h5>Phân phối tại Việt Nam:</h5>";
            if (list.Count>0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    chuoi += "<p>" + list[i].Name + "</p>";
                } 
            }
            ltrdeliver.Text = chuoi;
        }

        protected void imgbtnsearchrefer_Click(object sender, ImageClickEventArgs e)
        {
            //List<Data.Shop> shop = new List<Shop>();
            //shop = ShopService.Shop_GetByTop("","Address like '%"+txtsearchrefer.Text+"%'","");
            if (!ddlprovince.SelectedValue.ToString().Trim().Equals("0"))
            {
                Session["shopaddress"] = ddlprovince.SelectedItem.ToString();
                Response.Redirect("/ListShop.aspx");
            }
            else
            {
                Response.Redirect("/");
            }

        }
        void loadddlprovince()
        {
            List<Data.Province> list = new List<Province>();
            list = ProvinceService.Province_GetByAll();
            ddlprovince.Items.Add(new ListItem("=====chọn tỉnh=====","0"));
            for (int i = 0; i < list.Count;i++)
            {
                ddlprovince.Items.Add(new ListItem(list[i].Name,list[i].Id));
            }
            ddlprovince.DataBind();
        }
    }
}