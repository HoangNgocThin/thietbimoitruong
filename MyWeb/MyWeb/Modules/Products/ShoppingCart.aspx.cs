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
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Page.RouteData.Values["Id"] != null) {
                    Session["productid"] = Page.RouteData.Values["Id"].ToString();
                    Session["quantity"] = "1";
                }
                if (Session["productid"] != null && Session["quantity"] != null)
                {
                    if (CheckProductID(Session["productid"].ToString()) == false)
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
                    rpt.DataSource = dtshow;
                    rpt.DataBind();
                }
                lblTotalAmount.Text = GetTotalAmount();
            }
            SetEnableButton();
        }

        private void SetEnableButton() { 
           DataTable dtshoppingcart = (DataTable)Session["Cart"];
           btncapnhat.Visible = (dtshoppingcart != null && dtshoppingcart.Rows.Count > 0);
           btnUpdate.Visible = (dtshoppingcart != null && dtshoppingcart.Rows.Count > 0);
        }
        void AddCart(string productid, string quantity)
        {
            DataTable dtshoppingcart;
            List<Data.Product> list = new List<Product>();
            if (Session["Cart"] == null)
            {
                dtshoppingcart = new DataTable("Shoppingcart");
                dtshoppingcart.Columns.Add("ProductID", typeof(String));
                dtshoppingcart.Columns.Add("Image", typeof(String));
                dtshoppingcart.Columns.Add("ProductName", typeof(String));
                dtshoppingcart.Columns.Add("Price", typeof(String));
                dtshoppingcart.Columns.Add("Quantity", typeof(String));
                dtshoppingcart.Columns.Add("Total", typeof(String));
                DataRow rows = dtshoppingcart.NewRow();
                list = ProductService.Product_GetById(productid);
                rows["ProductID"] = list[0].ID;
                rows["Image"] = list[0].Image;
                rows["ProductName"] = list[0].Name;
                rows["Price"] = list[0].SalePrice;
                rows["Quantity"] = quantity;
                rows["Total"] = (Int32.Parse(list[0].SalePrice) * Int32.Parse(quantity)).ToString();
                dtshoppingcart.Rows.Add(rows);

            }
            else
            {
                dtshoppingcart = (DataTable)Session["Cart"];
                DataRow rows = dtshoppingcart.NewRow();
                list = ProductService.Product_GetById(productid);
                rows["ProductID"] = list[0].ID;
                rows["Image"] = list[0].Image;
                rows["ProductName"] = list[0].Name;
                rows["Price"] = list[0].SalePrice;
                rows["Quantity"] = quantity;
                rows["Total"] = (Int32.Parse(list[0].SalePrice) * Int32.Parse(quantity)).ToString();
                dtshoppingcart.Rows.Add(rows);

            }
            lblTotalAmount.Text = GetTotalAmount();
            Session["Cart"] = dtshoppingcart;
            DataTable dt = (DataTable)Session["Cart"];
            rpt.DataSource = dt.DefaultView;
            rpt.DataBind();
            Session.Remove("productid");
        }
        private void BuilText() {
            DataTable dt = (DataTable)Session["cart"];
            if (dt != null)
            {
                Literal ltrCartInfor = (Literal)Common.PageHelper.FindControl(this.Master, "ltrCartInfor");
                if (ltrCartInfor != null) {
                    ltrCartInfor.Text = "Giỏ hàng đang có (" + dt.Rows.Count.ToString() + ") sản phẩm";
                }
            }
        }
        protected void rpt_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string strCA = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "Update":
                    Label lblProductID;
                    Label lbltotal;
                    for (int i = 0; i < rpt.Items.Count; i++)
                    {
                        lblProductID = (Label)rpt.Items[i].FindControl("lblproductid");
                        if (lblProductID.Text.Trim().Equals(strCA))
                        {
                            //Label lblprice = (Label)rpt.Items[i].FindControl("lblprice");
                            TextBox quantitytext = (TextBox)rpt.Items[i].FindControl("txtquantity");
                            //lbltotal = (Label)rpt.Items[i].FindControl("lbltotal");
                            //lblprice.Text = lblprice.Text.Substring(0, lblprice.Text.LastIndexOf("VND"));
                            if (quantitytext.Text.Trim().Equals("0"))
                            {
                                quantitytext.Text = "1";
                                //lbltotal.Text = Format_Price((Int32.Parse(lblprice.Text.ToString().Replace(".", "")) * Int32.Parse(quantitytext.Text.ToString())).ToString()) + " VND";
                            }
                            else
                            {
                                //lbltotal.Text = (Int32.Parse(lblprice.Text.ToString().Replace(".", "")) * Int32.Parse(quantitytext.Text.ToString())).ToString();
                            }
                            //lblprice.Text = lblprice.Text + " VND";
                            Cart_UpdateNumber((DataTable)Session["Cart"], strCA, quantitytext.Text);
                        }
                    }
                    DataTable dt = (DataTable)Session["Cart"];
                    rpt.DataSource = null;
                    rpt.DataSource = dt.DefaultView;
                    rpt.DataBind();
                    lblTotalAmount.Text = GetTotalAmount();
                    //Response.Redirect(Request.Url.LocalPath.ToString());

                    break;
                case "Delete":

                    DataTable dtdelete = new DataTable();
                    dtdelete = (DataTable)Session["Cart"];
                    for (int i = 0; i < dtdelete.Rows.Count; i++)
                    {
                        if (dtdelete.Rows[i]["ProductID"].ToString().Equals(strCA))
                        {
                            dtdelete.Rows.RemoveAt(i);
                        }
                    }
                    rpt.DataSource = null;
                    rpt.DataSource = dtdelete.DefaultView;
                    rpt.DataBind();
                    lblTotalAmount.Text = GetTotalAmount();
                    break;
            }
            SetEnableButton();
            BuilText();
        }
        protected void btndathang_Click(object sender, EventArgs e)
        {
            int sessiontotalprice = 0;
            for (int i = 0; i < rpt.Items.Count; i++)
            {
                Label lbltotalprice1 = (Label)rpt.Items[i].FindControl("lbltotal");
                lbltotalprice1.Text = lbltotalprice1.Text.Substring(0, lbltotalprice1.Text.LastIndexOf("VND")).Replace(".", "");
                sessiontotalprice += Int32.Parse(lbltotalprice1.Text);
            }
            Session["totalprice"] = sessiontotalprice.ToString();
            Response.Redirect("/ContactOrder.aspx");
        }

        private string GetTotalAmount()
        {
            string strResult = "Tổng tiền: 0 VND";
            DataTable dt = (DataTable)Session["Cart"];
            if (dt != null) {
                int totalprice = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    
                    totalprice += Int32.Parse(dt.Rows[i]["Total"].ToString());

                }
                if (totalprice != 0)
                {
                    strResult = "Tổng tiền :" + " " + Format_Price(totalprice.ToString()) + " VND";
                    Session["totalprice"] = Format_Price(totalprice.ToString()) + " VND";
                }
            }
            
           
            return strResult;
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
            bool flag = false;
            if (Session["Cart"] != null)
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
        protected string Format_Price(string Price)
        {
            if (Price.Trim().Equals(""))
            {
                return "0";
            }
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

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            Response.Redirect("/");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int sessiontotalprice = 0;
            for (int i = 0; i < rpt.Items.Count; i++)
            {
                Label lbltotalprice1 = (Label)rpt.Items[i].FindControl("lbltotal");
                lbltotalprice1.Text = lbltotalprice1.Text.Substring(0, lbltotalprice1.Text.LastIndexOf("VND")).Replace(".", "");
                sessiontotalprice += Int32.Parse(lbltotalprice1.Text);
            }
            Session["totalprice"] = sessiontotalprice.ToString();
            Response.Redirect("/ContactOrder.html");
            
        }

      

        protected void btncapnhat_Click(object sender, EventArgs e)
        {
            Label lblProductID;
            Label lbltotal;
            for (int i = 0; i < rpt.Items.Count; i++)
            {
                lblProductID = (Label)rpt.Items[i].FindControl("lblproductid");

                TextBox quantitytext = (TextBox)rpt.Items[i].FindControl("txtquantity");
                if (quantitytext.Text.Trim().Equals("0"))
                {
                    quantitytext.Text = "1";
                }
                Cart_UpdateNumber((DataTable)Session["Cart"], lblProductID.Text, quantitytext.Text);

            }
            DataTable dt = (DataTable)Session["Cart"];
            rpt.DataSource = null;
            rpt.DataSource = dt.DefaultView;
            rpt.DataBind();
            lblTotalAmount.Text = GetTotalAmount();
        }
    }
}