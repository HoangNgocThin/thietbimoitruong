using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;
using System.Data;

namespace MyWeb.Modules.Products
{
    public partial class Order : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {  
            
            if (!Page.IsPostBack)
            {               
                if (Session["productid"] != null && Session["quantity"] != null)
                {
                    if (CheckProductID(Session["productid"].ToString())==false)
                    {
                        AddCart(Session["productid"].ToString(), Session["quantity"].ToString());
                    }
                    else
                    {
                        Common.WebMsgBox.Show("Sản phẩm này đã có trong giỏ hàng của bạn!!");
                        Session.Remove("productid");
                        DataTable dtshowadd = new DataTable();
                        dtshowadd = (DataTable)Session["Cart"];
                        rpt.DataSource = dtshowadd;
                        rpt.DataBind();
                    }
                }
                else
                {
                    DataTable dtshow = new DataTable();
                    dtshow = (DataTable)Session["Cart"];
                    if (dtshow.Rows.Count == 0)
                    {
                        btndathang.Enabled = false;
                    }
                    else
                    {
                        btndathang.Enabled = true;
                    }
                    rpt.DataSource = dtshow;
                    rpt.DataBind();
                }
            }
        }
        void AddCart(string productid, string quantity)
        {
            DataTable dtshoppingcart;
            List<Data.Product> list = new List<Product>();
            if (Session["Cart"] == null)
            {
                dtshoppingcart = new DataTable("Shoppingcart");
                dtshoppingcart.Columns.Add("ProductID", typeof(String));
                dtshoppingcart.Columns.Add("ProductName", typeof(String));
                dtshoppingcart.Columns.Add("Price", typeof(String));
                dtshoppingcart.Columns.Add("Quantity", typeof(String));
                dtshoppingcart.Columns.Add("Total", typeof(String));
                DataRow rows = dtshoppingcart.NewRow();
                list = ProductService.Product_GetById(productid);
                rows["ProductID"] = list[0].Id;
                rows["ProductName"] = list[0].Name;
                rows["Price"] = list[0].Price;
                rows["Quantity"] = quantity;
                rows["Total"] = (Int32.Parse(list[0].Price) * Int32.Parse(quantity)).ToString();
                dtshoppingcart.Rows.Add(rows);
               
            }
            else
            {
                dtshoppingcart = (DataTable)Session["Cart"];
                DataRow rows = dtshoppingcart.NewRow();
                list = ProductService.Product_GetById(productid);
                rows["ProductID"] = list[0].Id;
                rows["ProductName"] = list[0].Name;
                rows["Price"] = list[0].Price;
                rows["Quantity"] = quantity;
                rows["Total"] = (Int32.Parse(list[0].Price) * Int32.Parse(quantity)).ToString();
                dtshoppingcart.Rows.Add(rows);
            
            }
            Session["Cart"] = dtshoppingcart;
            DataTable dt=(DataTable)Session["Cart"];
            rpt.DataSource = dt.DefaultView;
            rpt.DataBind();
            Session.Remove("productid");
        }

        protected void rpt_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string strCA = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "Update":
                    Label lblProductID;
                    Label lbltotal;
                    for (int i = 0; i < rpt.Items.Count;i++)
                    {
                        lblProductID=(Label)rpt.Items[i].FindControl("lblproductid");
                        if(lblProductID.Text.Trim().Equals(strCA))
                        {
                            Label lblprice = (Label)rpt.Items[i].FindControl("lblprice");
                            TextBox quantitytext = (TextBox)rpt.Items[i].FindControl("txtquantity");
                            lbltotal = (Label)rpt.Items[i].FindControl("lbltotal");
                            lblprice.Text = lblprice.Text.Substring(0, lblprice.Text.LastIndexOf("VND"));
                            if(quantitytext.Text.Trim().Equals("0"))
                            {
                                quantitytext.Text="1";
                                lbltotal.Text = (Int32.Parse(lblprice.Text.ToString().Replace(".", "")) * Int32.Parse(quantitytext.Text.ToString())).ToString() + " VND";
                            }
                            else
                            {
                                lbltotal.Text = (Int32.Parse(lblprice.Text.ToString().Replace(".","")) * Int32.Parse(quantitytext.Text.ToString())).ToString() + " VND";
                            }
                            lblprice.Text = lblprice.Text + " VND";
                            Cart_UpdateNumber((DataTable)Session["Cart"],strCA,quantitytext.Text);
                        }
                    }
                    Response.Redirect(Request.Url.LocalPath.ToString());
                   
                    break;
                case "Delete":
                   
                    DataTable dtdelete = new DataTable();
                    dtdelete = (DataTable)Session["Cart"];
                    for (int i = 0; i < dtdelete.Rows.Count;i++)
                    {
                        if (dtdelete.Rows[i]["ProductID"].ToString().Equals(strCA))
                        {
                            dtdelete.Rows.RemoveAt(i);
                        }
                    }
                    Response.Redirect(Request.Url.LocalPath.ToString());
                    break;
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
        protected void btndathang_Click(object sender, EventArgs e)
        {
            int sessiontotalprice = 0;
            for (int i = 0; i < rpt.Items.Count;i++ )
            {
                Label lbltotalprice1 = (Label)rpt.Items[i].FindControl("lbltotal");
                lbltotalprice1.Text = lbltotalprice1.Text.Substring(0,lbltotalprice1.Text.LastIndexOf("VND")).Replace(".","");
                sessiontotalprice += Int32.Parse(lbltotalprice1.Text);
            }
            Session["totalprice"] = sessiontotalprice.ToString();
            Response.Redirect("/ContactOrder.aspx");
        }

        protected void btnthanhtoan_Click(object sender, EventArgs e)
        {
            int totalprice = 0;
            for (int i = 0; i < rpt.Items.Count;i++)
            {
                Label lbltotalprice = (Label)rpt.Items[i].FindControl("lbltotal");
                lbltotalprice.Text = lbltotalprice.Text.Substring(0, lbltotalprice.Text.LastIndexOf("VND"));
                totalprice += Int32.Parse(lbltotalprice.Text);
                lbltotalprice.Text = lbltotalprice.Text + "VND";
            }
            lbltongtien.Text = "Tổng tiền :"+" "+ totalprice.ToString() +" VND";
        }

        protected void btnmuatiep_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Default.aspx");
        }
        void Cart_UpdateNumber(DataTable cartdetail, string proid, string inumber)
        {
            if (cartdetail.Rows.Count > 0)
            {
                for (int i = 0; i < cartdetail.Rows.Count; i++)
                {
                    if (cartdetail.Rows[i]["ProductID"].ToString().Equals(proid))
                    {
                        cartdetail.Rows[i]["Quantity"] = inumber;
                        // update money
                        cartdetail.Rows[i]["Total"] = Convert.ToInt32(inumber) * Convert.ToDouble(cartdetail.Rows[i]["Price"].ToString());
                        break;
                    }
                }
            }
        }
        bool CheckProductID(string proid)
        { 
            bool flag=false;
            if(Session["Cart"]!=null)
            {
                DataTable dtcheck = (DataTable)Session["Cart"];
                if (dtcheck.Rows.Count > 0)
                {
                    for (int i = 0; i < dtcheck.Rows.Count; i++)
                    {
                        if (dtcheck.Rows[i]["ProductID"].Equals(proid))
                        {
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                }
                else
                {
                    flag = false;
                }
            }
            return flag;
        }

    }
}