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
            if(!IsPostBack)
            {
                loadddlkhuvuc();
            }
        }
        void loadddlkhuvuc()
        {
            ddlkhuvuc.Items.Clear();
            ddlkhuvuc.Items.Add(new ListItem("==chọn khu vực==",""));
            ddlkhuvuc.Items.Add(new ListItem("Khu vực miền bắc","0"));
            ddlkhuvuc.Items.Add(new ListItem("Khu vực miền nam","1"));
        }
       
        protected void btndathang_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                Data.tbCUSTOMERS obj = new tbCUSTOMERS();
                string username = "KH" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Millisecond.ToString();
                obj.vusername = username;
                obj.vpassword = username;
                obj.vcusname = txthoten.Text;
                obj.dbirthday = Common.DateTimeClass.ConvertDateTime(txtngaysinh.Text, "MM/dd/yyyy");
                obj.vprovince = txttinh.Text;
                obj.vaddress = txtdiachi.Text;
                obj.vphone = txtsodienthoai.Text;
                obj.vmobile = txtdidong.Text;
                obj.vemail = txtemail.Text;
                obj.dcreatedate = Common.DateTimeClass.ConvertDateTime(DateTime.Now.ToShortDateString(), "MM/dd/yyyy");
                obj.istatus = "0";
                //List<Data.tbCUSTOMERS> listcustommer = new List<tbCUSTOMERS>();
                //listcustommer = tbCUSTOMERSService.tbCUSTOMERS_GetByTop("", "vusername='" + username + "' and vpassword='" + txtmatkhau.Text + "'", "");
                //if (listcustommer.Count > 0)
                //{
                //    //Common.WebMsgBox.Show("Đã tồn tại tài khoản này ");
                //    //txttendangnhap.Text = "";
                //    //txttendangnhap.Focus();
                //    //return;
                //}
                //else
                //{
                    tbCUSTOMERSService.tbCUSTOMERS_Insert(obj);
                    
                //}
                    Session["hoten"] = txthoten.Text;
                    Session["username"] = username;
                    Session["password"] = username;
                    Session["billlocation"] = ddlkhuvuc.SelectedValue.ToString();
                    Response.Redirect("/OrderSuccess.aspx");
                   
            }
        }
    }
}