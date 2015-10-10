using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;
using MyWeb.Common;

namespace MyWeb.Admin
{
    public partial class Shop : System.Web.UI.Page
    {
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

        private void BindGrid()
        {
            grdShop.DataSource = ShopService.Shop_GetByAll();
            grdShop.DataBind();
            if (grdShop.PageCount <= 1)
            {
                grdShop.PagerStyle.Visible = false;
            }
            else
            { 
                grdShop.PagerStyle.Visible = true;
            }
        }

        private void LoadCompanyDropDownList()
		{
			ddltinh.Items.Clear();
			ddltinh.Items.Add(new ListItem("==chọn tỉnh thành==", ""));
            List<Data.Province> list = ProvinceService.Province_GetByAll();
			for (int i = 0; i < list.Count; i++)
			{
				ddltinh.Items.Add(new ListItem(list[i].Name, list[i].Id));
			}
			ddltinh.DataBind();
		}

        protected void grdShop_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grdShop.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

        protected void grdShop_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdShop.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void grdShop_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string strCA = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "Edit":
                    Insert = false;
                    Id = strCA;
                    List<Data.Shop> listE = ShopService.Shop_GetById(Id);
                    //txtid.Text = listE[0].id;
                    txtName.Text = listE[0].Name;
                    txtAddress.Text = listE[0].Address;
                    txtPhoneNumber.Text = listE[0].PhoneNumber;
                    LoadCompanyDropDownList();
                    List<Data.Company> listcompany = new List<Data.Company>();
                    listcompany = CompanyService.Company_GetById(listE[0].CompanyId);
                    ddltinh.SelectedValue = listcompany[0].ProvinceId;
                    pnView.Visible = false;
                    pnUpdate.Visible = true;
                    break;
                case "Delete":
                    ShopService.Shop_Delete(strCA);
                    BindGrid();
                    break;
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            pnUpdate.Visible = true;
            ControlClass.ResetControlValues(this);
            LoadCompanyDropDownList();
            pnView.Visible = false;
            Insert = true;
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            DataGridItem item = default(DataGridItem);
            for (int i = 0; i < grdShop.Items.Count; i++)
            {
                item = grdShop.Items[i];
                if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                {
                    if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                    {
                        string strId = item.Cells[1].Text;
                        ShopService.Shop_Delete(strId);
                    }
                }
            }
            grdShop.CurrentPageIndex = 0;
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
                Data.Shop obj = new Data.Shop();
                obj.id = Id;
                obj.Name = txtName.Text;
                obj.Address = txtAddress.Text;
                obj.PhoneNumber = txtPhoneNumber.Text;
                List<Data.Company> company= new List<Data.Company>();
                company=CompanyService.Company_GetByAll();
                obj.CompanyId = company[0].id;
                if (Insert == true)
                {
                    ShopService.Shop_Insert(obj);
                }
                else
                {
                    ShopService.Shop_Update(obj);
                }
                BindGrid();
                pnView.Visible = true;
                pnUpdate.Visible = false;
                Insert = false;
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