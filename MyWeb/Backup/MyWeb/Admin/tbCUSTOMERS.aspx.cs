using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;
using MyWeb.Common;
using System.Data;

namespace MyWeb.Admin
{
	public partial class tbCUSTOMERS : System.Web.UI.Page
	{
		static string Id = "";
		static bool Insert = false;
		static string Lang = "";
		protected void Page_Load(object sender, EventArgs e)
		{
            Lang = Session["Lang"].ToString();
			if (!IsPostBack)
			{
				lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
				lbtDeleteB.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
				BindGrid();
			}
		}

		private void BindGrid()
		{
            DataTable dt = new DataTable();
            dt = tbCUSTOMERSService.Get_Customer_Order_By_lang(Lang).Tables[0];
            grdtbCUSTOMERS.DataSource = dt;
			grdtbCUSTOMERS.DataBind();
            if (grdtbCUSTOMERS.PageCount <= 1)
            {
                grdtbCUSTOMERS.PagerStyle.Visible = false;
            }
            else
            {
                grdtbCUSTOMERS.PagerStyle.Visible = true;  
            }
		}
        protected string Tensanpham(string ma)
        {
            List<Data.Product> listpr = Business.ProductService.Product_GetById(ma);
            return listpr[0].Name.ToString();
        }
		protected void grdtbCUSTOMERS_ItemDataBound(object sender, DataGridItemEventArgs e)
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
					string tableRowId = grdtbCUSTOMERS.ClientID + "_row" + e.Item.ItemIndex.ToString();
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
        protected string Hinh_anh(string proid)
        {
            string str = "";
            List<Data.Product> listpro = Business.ProductService.Product_GetById(proid);
            if (listpro.Count > 0)
            {
                if (listpro[0].Image.ToString().Length > 0)
                {
                    str = "<div class=imgpro><img src=\"" + listpro[0].Image + "\" align=\"left\" style=\"padding-right:6px;width:170px\" border=0></div>";
                }
            }
            listpro.Clear();
            listpro = null;
            return str;
        }
        protected string Color_Pro(string IdColor)
        {
            string t = "";
            if (Lang.ToString().ToLower().Equals("en"))
                t = "<b>Color: </b>";
            else
                t = "<b>Màu sắc: </b>";
            List<Data.Colors> listcolor = Business.ColorsService.Colors_GetById(IdColor);
            if (listcolor.Count > 0)
                return t.ToString() + listcolor[0].Name.ToString();
            else
                return "";
            listcolor.Clear();
            listcolor = null;
        }
        protected string Size_Pro(string Idsize)
        {

            List<Data.Sizes> list = Business.SizesService.Sizes_GetById(Idsize);
            if (list.Count > 0)
                return list[0].Name.ToString();
            else
                return "";
            list.Clear();
            list = null;
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
        protected string Trangthai(string ma)
        {
            if (ma.ToString().Equals("1"))
            {
                return "Đã giao hàng";
            }
            else
                return "Chưa giao hàng";
        }
        protected string Format_show(string ma,string valueformat)
        {
            if (ma.Equals("0"))
                return "<b>" + valueformat.ToString() + "</b>";
            else
                return valueformat.ToString();
        }
		protected void grdtbCUSTOMERS_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			grdtbCUSTOMERS.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}

		protected void grdtbCUSTOMERS_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			string strCA = e.CommandArgument.ToString();
            this.txtIdbill.Text = e.CommandArgument.ToString();
			switch (e.CommandName)
			{
                case "Edit":
                    {
                        List<Data.tbBill_customers> listbillcus = Business.tbBill_customersService.tbBill_customers_GetById(strCA);
                        if (listbillcus.Count > 0)
                        {
                            List<Data.tbCUSTOMERS> listcus = Business.tbCUSTOMERSService.tbCUSTOMERS_GetById(listbillcus[0].userid);
                            this.grdtbCUSTOMERSinfo.DataSource = listcus;
                            this.grdtbCUSTOMERSinfo.DataBind();
                            listcus.Clear();
                            listcus = null;
                            //List<Data.tbRecipient> listReci = Business.tbRecipientService.tbRecipient_GetByTop("", "iusid=" + listbillcus[0].userid, "");
                            //this.grdRecipient.DataSource = listReci;
                            //this.grdRecipient.DataBind();
                            //listReci.Clear();
                            //listReci = null;
                            // Update trang thai
                            Data.tbBill_customers obj = new tbBill_customers();
                            obj.billid = listbillcus[0].billid;
                            obj.userid = listbillcus[0].userid;
                            obj.totalmoney = listbillcus[0].totalmoney;
                            obj.xdate = Common.DateTimeClass.ConvertDateTime(listbillcus[0].xdate.ToString(), "MM/dd/yyyy HH:mm:ss");
                            obj.idate = Common.DateTimeClass.ConvertDateTime(listbillcus[0].idate.ToString(), "MM/dd/yyyy HH:mm:ss");
                            obj.request = listbillcus[0].request;
                            obj.typepay = listbillcus[0].typepay;
                            obj.state = listbillcus[0].state;
                            obj.lang = Lang;
                            obj.show = "1";
                            tbBill_customersService.tbBill_customers_Update(obj);
                        }
                        List<Data.tbBilldetail> listBill = Business.tbBilldetailService.tbBilldetail_GetByTop("1000000000", "bilid=" + strCA, "");
                        this.grdshopcard.DataSource = listBill;
                        this.grdshopcard.DataBind();
                        Double SumMoney = 0;
                        for (int i = 0; i < listBill.Count; i++)
                        {
                            SumMoney += double.Parse(listBill[i].bilmoney.ToString());
                        }
                        //this.lblsummoney.Text = Format_Price(SumMoney.ToString());
                        //SumMoney = SumMoney + double.Parse(Common.GlobalClass.FreeShipping);
                        //lblmoneyphi.Text = Format_Price(Common.GlobalClass.FreeShipping);
                        this.lblsumpay.Text = Format_Price(SumMoney.ToString());
                        listBill.Clear();
                        listBill = null;
                        listbillcus.Clear();
                        listbillcus = null;
                        pnView.Visible = false;
                        pnUpdate.Visible = true;
                    }
                    break;
				case "Delete":
                    try
                    {
                        tbBill_customersService.tbBill_customers_Delete(strCA);
                        BindGrid();
                    }
                    catch
                    {
                        Common.WebMsgBox.Show("Đơn hàng đã có dữ liệu đặt hàng không thể xóa");
                        return;
                    }
					break;
			}
		}

		protected void AddButton_Click(object sender, EventArgs e)
		{
			pnUpdate.Visible = true;
			ControlClass.ResetControlValues(this);
			pnView.Visible = false;
			Insert = true;
		}

		protected void DeleteButton_Click(object sender, EventArgs e)
		{
			DataGridItem item = default(DataGridItem);
			for (int i = 0; i < grdtbCUSTOMERS.Items.Count; i++)
			{
				item = grdtbCUSTOMERS.Items[i];
				if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
				{
					if (((CheckBox)item.FindControl("ChkSelect")).Checked)
					{
						string strId = item.Cells[1].Text;
                        tbBill_customersService.tbBill_customers_Delete(strId);
					}
				}
			}
			grdtbCUSTOMERS.CurrentPageIndex = 0;
			BindGrid();
		}

		protected void RefreshButton_Click(object sender, EventArgs e)
		{
			BindGrid();
		}

		protected void Update_Click(object sender, EventArgs e)
		{
            if (Page.IsValid)
            {
                List<Data.tbBill_customers> listbillcus = Business.tbBill_customersService.tbBill_customers_GetById(txtIdbill.Text.Trim());
                if (listbillcus.Count > 0)
                {
                    Data.tbBill_customers obj = new tbBill_customers();
                    obj.billid = listbillcus[0].billid;
                    obj.userid = listbillcus[0].userid;
                    obj.totalmoney = listbillcus[0].totalmoney;
                    obj.xdate = Common.DateTimeClass.ConvertDateTime(DateTime.Now, "MM/dd/yyyy HH:mm:ss");
                    obj.idate = Common.DateTimeClass.ConvertDateTime(listbillcus[0].idate, "MM/dd/yyyy HH:mm:ss");
                    obj.request = listbillcus[0].request;
                    obj.typepay = listbillcus[0].typepay;
                    obj.state = "1";
                    obj.lang = Lang;
                    obj.show = "1";
                    tbBill_customersService.tbBill_customers_Update(obj);
                }
                BindGrid();
                pnView.Visible = true;
                pnUpdate.Visible = false;
                Insert = false;
                this.txtIdbill.Text = "";
            }
		}

		protected void Back_Click(object sender, EventArgs e)
		{
			pnView.Visible = true;
			pnUpdate.Visible = false;
			Insert = false;
		}
	}
}