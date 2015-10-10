using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;
using MyWeb.Common;
using System.Linq;

namespace MyWeb.Admin
{
    public partial class tbBill_customers : System.Web.UI.Page
    {
        static string ibillId = "";
        static string Id = "";
        static bool Insert = false;
        static string Lang = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
                lbtDeleteB.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
                Lang = Session["Lang"].ToString();
                BindGrid();
            }
        }
        protected string ConvertState(string state) {
            string result = "";
            if (state == "1")
            {
                result = "Đã giao hàng";

            }
            else
            {
                result = "<strong style='color: red'>Chưa giao hàng</strong>";
            }

            return result;
        }
        private void BindGrid()
        {
            List<Data.tbBill_customers> list = new List<Data.tbBill_customers>();
            list = tbBill_customersService.tbBill_customers_GetByAll(Lang);
            list = list.OrderBy(x => x.state).OrderByDescending(x=>x.idate).ToList();
            grdtbBill_customers.DataSource = list;
            grdtbBill_customers.DataBind();
            if (grdtbBill_customers.PageCount <= 1)
            {
                grdtbBill_customers.PagerStyle.Visible = false;
            }
        }

      

        protected void grdtbBill_customers_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            ListItemType itemType = e.Item.ItemType;
            if ((itemType != ListItemType.Footer) && (itemType != ListItemType.Separator))
            {
                if (itemType == ListItemType.Header)
                {
                    object checkBox = e.Item.FindControl("chkSelectAll");
                    if ((checkBox != null))
                    {
                        ((CheckBox)checkBox).Attributes.Add("onClick", "Javascript:chkSelectAll_OnClick(this)");
                    }
                }
                else
                {
                    string tableRowId = grdtbBill_customers.ClientID + "_row" + e.Item.ItemIndex.ToString();
                    e.Item.Attributes.Add("id", tableRowId);
                    object checkBox = e.Item.FindControl("chkSelect");
                    if ((checkBox != null))
                    {
                        e.Item.Attributes.Add("onMouseMove", "Javascript:chkSelect_OnMouseMove(this)");
                        e.Item.Attributes.Add("onMouseOut", "Javascript:chkSelect_OnMouseOut(this," + e.Item.ItemIndex.ToString() + ")");
                        ((CheckBox)checkBox).Attributes.Add("onClick", "Javascript:chkSelect_OnClick(this," + e.Item.ItemIndex.ToString() + ")");
                    }
                }
            }
        }

        protected void grdtbBill_customers_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdtbBill_customers.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void grdtbBill_customers_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string strCA = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "View":
                    Insert = false;
                     Id= strCA;
                    List<Data.tbBill_customers> listE = tbBill_customersService.tbBill_customers_GetById(Id);
                    if(listE.Count>0){
                        ibillId = listE[0].state;
                        if (ibillId == "1")
                        {
                            btn.Enabled = false;

                        }
                        else
                        {
                            btn.Enabled = true;
                        }
                        lblCustomerName.Text = "Họ tên: " + listE[0].CustomerName;
                        lblBirthDate.Text = "Ngày sinh: " + Common.DateTimeClass.ConvertDate(listE[0].BirthDate,"dd/MM/yyyy");
                        lblMobile.Text = "Điện thoại: " + listE[0].Mobile ;
                        lblAddress.Text = "Địa chỉ: "+listE[0].Address;
                        lblEmail.Text = "Email: "+listE[0].Email;
                        lblTotalAmount.Text = "Tổng tiền: " + listE[0].totalmoney;
                        List<Data.tbBilldetail> listDetail = new List<Data.tbBilldetail>();
                        listDetail = tbBilldetailService.tbBilldetail_GetByTop("", "bilid = "+listE[0].billid.ToString(),"");
                        grdDetail.DataSource = null;
                        grdDetail.DataSource = listDetail;
                        grdDetail.DataBind();
                    }
                    pnView.Visible = false;
                    pnUpdate.Visible = true;
                    break;
                case "Active":
                    string strA = "";
                    string str = e.Item.Cells[2].Text;
                    strA = str == "1" ? "0" : "1";
                    SqlDataProvider sql = new SqlDataProvider();
                    sql.ExecuteNonQuery("Update tbBill_customers set state=" + strA + "  Where billid='" + strCA + "'");
                    BindGrid();
                    break;
                case "Delete":
                    tbBill_customersService.tbBill_customers_Delete(strCA);
                    BindGrid();
                    break;
            }
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
        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            DataGridItem item = default(DataGridItem);
            for (int i = 0; i < grdtbBill_customers.Items.Count; i++)
            {
                item = grdtbBill_customers.Items[i];
                if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                {
                    if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                    {
                        string strId = item.Cells[1].Text;
                        tbBill_customersService.tbBill_customers_Delete(strId);
                    }
                }
            }
            grdtbBill_customers.CurrentPageIndex = 0;
            BindGrid();
        }

        protected void RefreshButton_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

       
        protected void Back_Click(object sender, EventArgs e)
        {
            pnView.Visible = true;
            pnUpdate.Visible = false;
            Insert = false;
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            
            SqlDataProvider sql = new SqlDataProvider();
            sql.ExecuteNonQuery("Update tbBill_customers set state=1 Where billid='" + ibillId + "'");
            btn.Enabled = false;
        }
    }
}