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
    public partial class OrderSuccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["username"]!=null && Session["password"]!=null)
            {
                List<Data.tbCUSTOMERS> list = new List<tbCUSTOMERS>();
                list = tbCUSTOMERSService.tbCUSTOMERS_GetByTop("1","vusername='"+Session["username"].ToString()+"' and vpassword='"+Session["password"].ToString()+"'","");
                if (list.Count>0)
	            {
		            if (Session["totalprice"] != null)
                            {
                                Data.tbBill_customers obj = new tbBill_customers();
                                obj.userid = list[0].iusid;
                                obj.totalmoney = Session["totalprice"].ToString();
                                obj.idate = Common.DateTimeClass.ConvertDateTime(DateTime.Now.ToShortDateString(),"MM-dd-yyyy");
                                obj.xdate = Common.DateTimeClass.ConvertDateTime(DateTime.Now.AddDays(5).ToShortDateString(), "MM-dd-yyyy");
                                obj.request = "";
                                obj.typepay = "";
                                obj.state = "0";
                                obj.lang = "vi";
                                obj.show = "1";
                                //tbBill_customersService.tbBill_customers_Insert(obj);
                                string billid = tbBill_customersService.tbBill_customers_Insert1(obj);
                                DataTable dt= new DataTable();
                                dt=(DataTable)Session["Cart"];
                                if (dt.Rows.Count>0)
                                {
                                    string sohang = "Sản phẩm đặt mua:\n";
                                    Double tongtien = 0;
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        List<Product> listpro = ProductService.Product_GetById(dt.Rows[i]["ProductID"].ToString());

                                        sohang += listpro[0].Name + " -- " + "số lượng: " + Format_Price(dt.Rows[i]["Quantity"].ToString())+ " -- " + " thành tiền: " + Format_Price(dt.Rows[i]["Total"].ToString()) + " VND" + "\n";
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
                                        objbilldetail.Billlocation = Session["billlocation"].ToString();
                                        string order = (Int32.Parse(listpro[0].Ord) + Int32.Parse(dt.Rows[i]["Quantity"].ToString())).ToString();
                                        ProductService.Product_Update_order(order,dt.Rows[i]["ProductID"].ToString());
                                        tbBilldetailService.tbBilldetail_Insert(objbilldetail);
                                    }
                                    #region[Sendmail]
                                    System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
                                    List<Config> list1 = new List<Config>();
                                    list1 = ConfigService.Config_GetByTop("1", "Location='" + Session["billlocation"].ToString() + "'","");
                                    string mailto = list1[0].Mail_Info;
                                    string pas = list1[0].Mail_Password;
                                    string host = list1[0].Mail_Smtp;
                                    int post = 0;
                                    if (list1[0].Mail_Port.Length > 0)
                                    {
                                        post = int.Parse(list1[0].Mail_Port);
                                    }
                                    else
                                    {
                                        post = 587;
                                    }
                                    if (list1[0].Mail_Smtp.Length > 0)
                                    {
                                        host = list1[0].Mail_Smtp;
                                    }
                                    else
                                    {
                                        host = "smtp.gmail.com";
                                    }
                                    string cc = "nhoksieuquay9x@gmail.com";
                                    mailMessage.From = (new MailAddress(mailto, Session["hoten"].ToString(), System.Text.Encoding.UTF8));
                                    mailMessage.To.Add(mailto);
                                    mailMessage.Bcc.Add(cc);
                                    mailMessage.Subject = "Thông tin gửi hàng";
                                    mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                                    sohang += "Tổng số tiền: " + Format_Price(tongtien.ToString()) + " VND";
                                    mailMessage.Body = sohang;

                                    mailMessage.IsBodyHtml = true;
                                    mailMessage.BodyEncoding = System.Text.Encoding.UTF8;

                                    System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential();
                                    mailAuthentication.UserName = "nhoksieuquay9x@gmail.com";
                                    mailAuthentication.Password = "quanghong";
                                    //System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient("" + host + "", post);
                                    System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
                                    mailClient.EnableSsl = true;
                                    mailClient.UseDefaultCredentials = false;
                                    mailClient.Credentials = mailAuthentication;
                                    try
                                    {
                                        mailClient.Send(mailMessage);
                                        ltrmessage.Text = "Bạn đã đặt hàng thành công, chúng tôi sé liên hệ với bạn trong thời gian sớm nhất!!";
                                        //return;
                                    }
                                    catch
                                    {
                                        ltrmessage.Text = "Hệ thống đã nhận đặt hàng của bạn nhưng đã có lỗi xẩy ra khi gửi mail cho ban quản trị !!";
                                        Session.Clear();
                                        return;
                                    }
                                    #endregion
                                    Session.Clear();
                                }
                                
                            }
                     else
                            {
                                Response.Redirect("/Default.aspx");
                            } 
	            }
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
    }
}