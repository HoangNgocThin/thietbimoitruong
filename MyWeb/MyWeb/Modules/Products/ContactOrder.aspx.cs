using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;
using MyWeb.Common;
using System.Data;
using System.Net.Mail;

namespace MyWeb.Modules.Products
{
    public partial class ContactOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btndathang_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Data.tbCUSTOMERS obj = new tbCUSTOMERS();
                string username = "KH" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Millisecond.ToString();
                obj.vusername = username;
                obj.vpassword = username;
                obj.vcusname = txthoten.Text;
                obj.dbirthday = Common.DateTimeClass.ConvertDateTime(DateTime.Now, "dd/MM/yyyy");
                obj.vaddress = txtdiachi.Text;
                obj.vphone = txtsodienthoai.Text;
                obj.vemail = txtemail.Text;
                obj.dcreatedate = Common.DateTimeClass.ConvertDateTime(DateTime.Now.ToShortDateString(), "MM/dd/yyyy");
                obj.istatus = "0";
                tbCUSTOMERSService.tbCUSTOMERS_Insert(obj);
                Session["hoten"] = txthoten.Text;
                Session["username"] = username;
                Session["password"] = username;
                SendEmail();
            }
        }
        protected string Format_Price(string Price)
        {
            if (Price != null || !Price.Trim().Equals(""))
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
            else
            {
                return "0";
            }

        }
        private void SendEmail()
        {
            if (Session["username"] != null && Session["password"] != null)
            {
                List<Data.tbCUSTOMERS> list = new List<tbCUSTOMERS>();
                list = tbCUSTOMERSService.tbCUSTOMERS_GetByTop("1", "vusername='" + Session["username"].ToString() + "' and vpassword='" + Session["password"].ToString() + "'", "");
                if (list.Count > 0)
                {
                    if (Session["totalprice"] != null)
                    {
                        Data.tbBill_customers obj = new tbBill_customers();
                        obj.userid = list[0].iusid;
                        obj.totalmoney = Session["totalprice"].ToString();
                        obj.idate = Common.DateTimeClass.ConvertDateTime(DateTime.Now.ToLongDateString(), "MM-dd-yyyy hh:mm:ss");
                        obj.xdate = Common.DateTimeClass.ConvertDateTime(DateTime.Now.AddDays(5).ToLongDateString(), "MM-dd-yyyy hh:mm:ss");
                        obj.request = "";
                        obj.typepay = "";
                        obj.state = "0";
                        obj.lang = "vi";
                        obj.show = "1";
                        //tbBill_customersService.tbBill_customers_Insert(obj);
                        string billid = tbBill_customersService.tbBill_customers_Insert1(obj);
                        DataTable dt = new DataTable();
                        dt = (DataTable)Session["Cart"];
                        if (dt.Rows.Count > 0)
                        {
                            string sohang = "Sản phẩm đặt mua:\n";
                            Double tongtien = 0;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                List<Product> listpro = ProductService.Product_GetById(dt.Rows[i]["ProductID"].ToString());

                                sohang += listpro[0].Name + " -- " + "số lượng: " + Format_Price(dt.Rows[i]["Quantity"].ToString()) + " -- " + " thành tiền: " + Format_Price(dt.Rows[i]["Total"].ToString()) + " VND" + "\n";
                                tongtien += Double.Parse(dt.Rows[i]["Total"].ToString());
                                Data.tbBilldetail objbilldetail = new tbBilldetail();
                                objbilldetail.bilid = billid;
                                objbilldetail.proid = dt.Rows[i]["ProductID"].ToString();
                                objbilldetail.sizeid = "0";
                                objbilldetail.colorid = "0";
                                objbilldetail.quantity = dt.Rows[i]["Quantity"].ToString();
                                objbilldetail.bilprice = dt.Rows[i]["Price"].ToString();
                                objbilldetail.bilpricevnd = dt.Rows[i]["Price"].ToString();
                                objbilldetail.bilmoney = dt.Rows[i]["Total"].ToString();
                                string order = (Int32.Parse(listpro[0].Ord) + Int32.Parse(dt.Rows[i]["Quantity"].ToString())).ToString();
                                tbBilldetailService.tbBilldetail_Insert(objbilldetail);
                            }
                          
                            Response.Redirect("OrderNotify.html");
                          
                            
                        }

                    }
                    else
                    {
                        Response.Redirect("/Default.aspx");
                    }
                }
            }
        }
    }
}